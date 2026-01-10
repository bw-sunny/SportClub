using System;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace SportClub
{
	public partial class EditScheduleForm : Form
	{
		private string connectionString = @"Data Source=DESKTOP-PGUAQQC\SQLEXPRESS;Initial Catalog=FitnessClub;Integrated Security=True";
		private int scheduleId;
		private int originalTrainingId;
		private DateTime originalDateTime;

		public EditScheduleForm(int scheduleId)
		{
			InitializeComponent();
			this.scheduleId = scheduleId;
		}

		private void EditScheduleForm_Load(object sender, EventArgs e)
		{
			// Настройка второго DateTimePicker для времени
			dateTimePicker2.Format = DateTimePickerFormat.Custom;
			dateTimePicker2.CustomFormat = "HH:mm";
			dateTimePicker2.ShowUpDown = true;

			// Загрузка данных
			LoadScheduleData();

			// Настройка автодополнения
			LoadTrainings();

			// Фокус на поле тренировки
			textBox1.Focus();
		}

		private void LoadScheduleData()
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();

					// ИСПРАВЛЕНО: правильное название столбца ID_Тренировки
					string query = @"
                    SELECT 
                        r.ID_Расписания,
                        r.Дата_время,
                        t.ID_Тренировки,
                        t.Название,
                        tr.ФИО,
                        t.Зал,
                        t.Длительность
                    FROM Расписание_тренировок r
                    JOIN Тренировки t ON r.ID_Тренировки = t.ID_Тренировки
                    JOIN Тренеры tr ON t.ID_Тренера = tr.ID_Тренера
                    WHERE r.ID_Расписания = @ScheduleId";

					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@ScheduleId", scheduleId);

						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							if (reader.Read())
							{
								// Сохраняем оригинальные данные
								originalTrainingId = Convert.ToInt32(reader["ID_Тренировки"]);
								originalDateTime = Convert.ToDateTime(reader["Дата_время"]);

								// Показываем ID
								label1.Text = $"ID занятия: {reader["ID_Расписания"]}";

								// Заполняем поле тренировки
								textBox1.Text = reader["Название"].ToString();

								// Устанавливаем дату и время
								dateTimePicker1.Value = originalDateTime.Date;
								dateTimePicker2.Value = originalDateTime;

								// Показываем информацию
								label2.Text = $"Тренер: {reader["ФИО"]}";
								label3.Text = $"Зал: {reader["Зал"]} ({reader["Длительность"]} мин)";
							}
							else
							{
								MessageBox.Show("Занятие не найдено", "Ошибка",
									MessageBoxButtons.OK, MessageBoxIcon.Error);
								this.Close();
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
			}
		}

		private void LoadTrainings()
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();
					string query = "SELECT Название FROM Тренировки ORDER BY Название";

					using (SqlCommand cmd = new SqlCommand(query, conn))
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

						while (reader.Read())
						{
							collection.Add(reader["Название"].ToString());
						}

						// Настройка автодополнения
						textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
						textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
						textBox1.AutoCompleteCustomSource = collection;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка загрузки тренировок: {ex.Message}", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		// Кнопка "Сохранить" (button1)
		private void button1_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(textBox1.Text))
			{
				MessageBox.Show("Введите название тренировки", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				textBox1.Focus();
				return;
			}

			try
			{
				// 1. Находим ID новой тренировки
				int newTrainingId = FindTrainingId(textBox1.Text.Trim());
				if (newTrainingId == -1)
				{
					MessageBox.Show("Тренировка не найдена", "Ошибка",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					textBox1.Focus();
					textBox1.SelectAll();
					return;
				}

				// 2. Собираем новую дату и время
				DateTime selectedDate = dateTimePicker1.Value.Date;
				TimeSpan selectedTime = dateTimePicker2.Value.TimeOfDay;
				DateTime newDateTime = selectedDate.Add(selectedTime);

				// 3. Проверяем, что время в будущем
				if (newDateTime < DateTime.Now)
				{
					MessageBox.Show("Нельзя устанавливать прошедшее время", "Ошибка",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					dateTimePicker1.Focus();
					return;
				}

				// 4. Проверяем, есть ли изменения
				if (newTrainingId == originalTrainingId && newDateTime == originalDateTime)
				{
					MessageBox.Show("Нет изменений для сохранения", "Информация",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				// 5. Сохраняем изменения
				SaveChanges(newTrainingId, newDateTime);

				MessageBox.Show("Изменения сохранены", "Успех",
					MessageBoxButtons.OK, MessageBoxIcon.Information);

				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (SqlException ex)
			{
				// Обработка ошибок триггеров
				if (ex.Message.Contains("тренер") || ex.Message.Contains("занят") || ex.Message.Contains("ROLLBACK"))
				{
					MessageBox.Show("Тренер уже занят в это время!", "Ошибка",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					MessageBox.Show($"Ошибка БД: {ex.Message}", "Ошибка",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private int FindTrainingId(string trainingName)
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();
					string query = "SELECT ID_Тренировки FROM Тренировки WHERE Название = @Name";

					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@Name", trainingName);
						object result = cmd.ExecuteScalar();
						return result != null ? Convert.ToInt32(result) : -1;
					}
				}
			}
			catch
			{
				return -1;
			}
		}

		private void SaveChanges(int trainingId, DateTime dateTime)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();
				string query = @"
                UPDATE Расписание_тренировок 
                SET ID_Тренировки = @TrainingId, 
                    Дата_время = @DateTime 
                WHERE ID_Расписания = @ScheduleId";

				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@TrainingId", trainingId);
					cmd.Parameters.AddWithValue("@DateTime", dateTime);
					cmd.Parameters.AddWithValue("@ScheduleId", scheduleId);
					cmd.ExecuteNonQuery();
				}
			}
		}

		// Кнопка "Отмена" (button2)
		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		// При изменении текста тренировки
		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(textBox1.Text))
			{
				// Показываем информацию о тренировке
				ShowTrainingInfo(textBox1.Text.Trim());
			}
			else
			{
				// Очищаем информацию
				label2.Text = "Тренер:";
				label3.Text = "Зал:";
			}
		}

		private void ShowTrainingInfo(string trainingName)
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();
					string query = @"
                    SELECT t.Название, tr.ФИО, t.Зал, t.Длительность
                    FROM Тренировки t
                    JOIN Тренеры tr ON t.ID_Тренера = tr.ID_Тренера
                    WHERE t.Название = @Name";

					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@Name", trainingName);

						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							if (reader.Read())
							{
								label2.Text = $"Тренер: {reader["ФИО"]}";
								label3.Text = $"Зал: {reader["Зал"]} ({reader["Длительность"]} мин)";
							}
							else
							{
								label2.Text = "Тренер: не найден";
								label3.Text = "Зал: не найден";
							}
						}
					}
				}
			}
			catch
			{
				// Игнорируем ошибки
			}
		}

		// Нажатие Enter в поле тренировки
		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.Handled = true;
				dateTimePicker1.Focus();
			}
		}

		// Нажатие Enter в dateTimePicker1
		private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.Handled = true;
				dateTimePicker2.Focus();
			}
		}

		// Нажатие Enter в dateTimePicker2
		private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.Handled = true;
				button1.PerformClick();
			}
		}

		// Обработчик Esc
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Escape)
			{
				this.Close();
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

        
    }
}