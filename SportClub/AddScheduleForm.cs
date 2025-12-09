using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SportClub
{
	public partial class AddScheduleForm : Form
	{
		private string connectionString = @"Data Source=DESKTOP-PGUAQQC\SQLEXPRESS;Initial Catalog=FitnessClub;Integrated Security=True";
		private int selectedTrainingId = -1;

		public AddScheduleForm()
		{
			InitializeComponent();
			SetupControlsInConstructor();
		}

		private void SetupControlsInConstructor()
		{
			// Настройка DateTimePicker2 для времени
			dateTimePicker2.Format = DateTimePickerFormat.Custom;
			dateTimePicker2.CustomFormat = "HH:mm";
			dateTimePicker2.ShowUpDown = true;
			dateTimePicker2.ShowCheckBox = false;
			dateTimePicker2.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 0, 0);

			// Настройка DateTimePicker1 для даты
			dateTimePicker1.Format = DateTimePickerFormat.Short;
			dateTimePicker1.Value = DateTime.Today;
			dateTimePicker1.MinDate = DateTime.Today;
		}

		private void AddScheduleForm_Load(object sender, EventArgs e)
		{
			LoadTrainings();
			textBox1.Focus();
			label1.Text = "Тренировка: не выбрана";
			label2.Text = "Тренер: не выбран";
			label3.Text = "Зал: не выбран";
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

						textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
						textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
						textBox1.AutoCompleteCustomSource = collection;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка загрузки тренировок: {ex.Message}", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// Кнопка "Добавить" (button1)
		private void button1_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(textBox1.Text))
			{
				MessageBox.Show("Введите название тренировки", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			try
			{
				// 1. Находим ID тренировки
				int trainingId = FindTrainingId(textBox1.Text.Trim());
				if (trainingId == -1)
				{
					MessageBox.Show("Тренировка не найдена", "Ошибка",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				// 2. Собираем дату и время
				DateTime selectedDate = dateTimePicker1.Value.Date;
				TimeSpan selectedTime = dateTimePicker2.Value.TimeOfDay;
				DateTime selectedDateTime = selectedDate.Add(selectedTime);

				// 3. Проверяем, что время в будущем
				if (selectedDateTime < DateTime.Now)
				{
					MessageBox.Show("Выберите будущее время", "Ошибка",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				// 4. Генерируем новый ID
				int newId = GetNewScheduleId();

				// 5. Сохраняем в базу
				SaveToDatabase(newId, trainingId, selectedDateTime);

				MessageBox.Show($"Занятие добавлено! ID: {newId}", "Успех",
					MessageBoxButtons.OK, MessageBoxIcon.Information);

				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (SqlException ex)
			{
				// ДЕТАЛЬНАЯ обработка ошибок SQL
				string errorMessage = $"Ошибка SQL #{ex.Number}: {ex.Message}";

				if (ex.Number == 2627) // Дублирование первичного ключа
				{
					errorMessage = "Такое занятие уже существует (дублирование ID)";
				}
				else if (ex.Number == 547) // Ошибка внешнего ключа
				{
					errorMessage = "Ошибка внешнего ключа. Проверьте ID тренировки.";
				}
				else if (ex.Number == 515) // NULL в NOT NULL поле
				{
					errorMessage = "Не все обязательные поля заполнены";
				}
				else if (ex.Message.Contains("тренер") || ex.Message.Contains("занят"))
				{
					errorMessage = "Тренер уже занят в это время!";
				}
				else if (ex.Message.Contains("ID_Расписания") || ex.Message.Contains("недопустимое имя столбца"))
				{
					// Проверим структуру таблицы
					CheckTableStructure();
					errorMessage = $"Ошибка в названии столбца. Проверил структуру таблицы.\n{ex.Message}";
				}

				MessageBox.Show(errorMessage, "Ошибка БД",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// Метод для проверки структуры таблицы
		private void CheckTableStructure()
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();
					string query = @"
                    SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE
                    FROM INFORMATION_SCHEMA.COLUMNS
                    WHERE TABLE_NAME = 'Расписание_тренировок'
                    ORDER BY ORDINAL_POSITION";

					using (SqlCommand cmd = new SqlCommand(query, conn))
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						string structure = "Структура таблицы Расписание_тренировок:\n";
						while (reader.Read())
						{
							structure += $"{reader["COLUMN_NAME"]} ({reader["DATA_TYPE"]}, NULL: {reader["IS_NULLABLE"]})\n";
						}

						MessageBox.Show(structure, "Информация о таблице",
							MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Не удалось проверить структуру: {ex.Message}", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private int GetNewScheduleId()
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();
					// Пробуем разные варианты названий столбцов
					string[] possibleColumnNames = {
						"ID_Расписания",
						"ID_Раписания",
						"ID_расписания",
						"ID"
					};

					foreach (string columnName in possibleColumnNames)
					{
						try
						{
							string query = $"SELECT ISNULL(MAX({columnName}), 0) + 1 FROM Расписание_тренировок";
							using (SqlCommand cmd = new SqlCommand(query, conn))
							{
								object result = cmd.ExecuteScalar();
								if (result != null)
								{
									return Convert.ToInt32(result);
								}
							}
						}
						catch
						{
							continue; // Пробуем следующий вариант
						}
					}

					throw new Exception("Не удалось определить название столбца ID");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка генерации ID: {ex.Message}\nИспользую ID = 1", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return 1;
			}
		}

		private void SaveToDatabase(int id, int trainingId, DateTime dateTime)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();

				// Пробуем разные варианты названий столбцов
				string[] possibleQueries = {
					@"INSERT INTO Расписание_тренировок (ID_Расписания, ID_Тренировки, Дата_время) VALUES (@ID, @TrainingId, @DateTime)",
					@"INSERT INTO Расписание_тренировок (ID_Раписания, ID_Тренировки, Дата_время) VALUES (@ID, @TrainingId, @DateTime)",
					@"INSERT INTO Расписание_тренировок (ID, ID_Тренировки, Дата_время) VALUES (@ID, @TrainingId, @DateTime)",
					@"INSERT INTO Расписание_тренировок VALUES (@ID, @TrainingId, @DateTime)"
				};

				foreach (string query in possibleQueries)
				{
					try
					{
						using (SqlCommand cmd = new SqlCommand(query, conn))
						{
							cmd.Parameters.AddWithValue("@ID", id);
							cmd.Parameters.AddWithValue("@TrainingId", trainingId);
							cmd.Parameters.AddWithValue("@DateTime", dateTime);
							cmd.ExecuteNonQuery();

							return;
						}
					}
					catch (SqlException sqlEx)
					{
						if (sqlEx.Number == 213) // Неправильное имя столбца
						{
							continue; // Пробуем следующий вариант
						}
						throw; // Другие ошибки прокидываем дальше
					}
					catch
					{
						continue;
					}
				}

				throw new Exception("Не удалось выполнить INSERT с любым вариантом названий столбцов");
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

		// Кнопка "Отмена" (button2)
		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		// При изменении текста - показываем информацию
		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(textBox1.Text))
			{
				ShowTrainingInfo(textBox1.Text.Trim());
			}
			else
			{
				label1.Text = "Тренировка: не выбрана";
				label2.Text = "Тренер: не выбран";
				label3.Text = "Зал: не выбран";
				selectedTrainingId = -1;
			}
		}

		private void ShowTrainingInfo(string trainingName)
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();
					string query = @"SELECT t.ID_Тренировки, t.Название, tr.ФИО, t.Зал, t.Длительность
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
								selectedTrainingId = Convert.ToInt32(reader["ID_Тренировки"]);
								label1.Text = $"Тренировка: {reader["Название"]}";
								label2.Text = $"Тренер: {reader["ФИО"]}";
								label3.Text = $"Зал: {reader["Зал"]} ({reader["Длительность"]} мин)";
							}
							else
							{
								label1.Text = $"Тренировка: '{trainingName}' не найдена";
								label2.Text = "Тренер: не выбран";
								label3.Text = "Зал: не выбран";
								selectedTrainingId = -1;
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

		// Кнопка для тестирования (можно добавить скрытую кнопку)
		private void buttonTest_Click(object sender, EventArgs e)
		{
			CheckTableStructure();
		}
	}
}