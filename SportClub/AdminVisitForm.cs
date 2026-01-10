using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace FitnessClub
{
	public partial class AdminVisitForm : Form
	{
		private string connectionString = @"Data Source=DESKTOP-PGUAQQC\SQLEXPRESS;Initial Catalog=FitnessClub;Integrated Security=True";
		private DataTable clientsTable;
		private Timer searchTimer;
		private AutoCompleteStringCollection trainingSuggestions;

		public AdminVisitForm()
		{
			InitializeComponent();
			SetupDataGridViewColumns();
			SetupAutoComplete();
			LoadAllTrainingsForAutoComplete();
		}

		private void SetupDataGridViewColumns()
		{
			// Очищаем существующие колонки
			dataGridView1.Columns.Clear();

			// Добавляем колонки
			dataGridView1.Columns.Add("ID_Клиента", "ID");
			dataGridView1.Columns.Add("ФИО", "Клиент");
			dataGridView1.Columns.Add("Телефон", "Телефон");

			// Колонка со статусом (текст)
			dataGridView1.Columns.Add("Статус", "Статус посещения");
			dataGridView1.Columns["Статус"].Width = 120;

			// Колонка с CheckBox для отметки
			DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
			checkColumn.Name = "Отметить";
			checkColumn.HeaderText = "Отметить посещение";
			checkColumn.TrueValue = true;
			checkColumn.FalseValue = false;
			checkColumn.Width = 120;
			dataGridView1.Columns.Add(checkColumn);

			// Скрываем ID
			dataGridView1.Columns["ID_Клиента"].Visible = false;
		}

		private void SetupAutoComplete()
		{
			// Настраиваем TextBox для автодополнения
			textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;

			// Инициализируем коллекцию для предложений
			trainingSuggestions = new AutoCompleteStringCollection();
			textBox1.AutoCompleteCustomSource = trainingSuggestions;

			// Создаем таймер для отложенного поиска
			searchTimer = new Timer();
			searchTimer.Interval = 300;
			searchTimer.Tick += SearchTimer_Tick;

			// Обработчики событий
			textBox1.TextChanged += TextBox1_TextChanged;
			textBox1.KeyDown += TextBox1_KeyDown;

			// Добавляем placeholder
			textBox1.Text = "Начните вводить название тренировки...";
			textBox1.ForeColor = SystemColors.GrayText;
			textBox1.GotFocus += TextBox1_GotFocus;
			textBox1.LostFocus += TextBox1_LostFocus;
		}

		private void TextBox1_GotFocus(object sender, EventArgs e)
		{
			if (textBox1.Text == "Начните вводить название тренировки...")
			{
				textBox1.Text = "";
				textBox1.ForeColor = SystemColors.WindowText;
			}
		}

		private void TextBox1_LostFocus(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(textBox1.Text))
			{
				textBox1.Text = "Начните вводить название тренировки...";
				textBox1.ForeColor = SystemColors.GrayText;
			}
		}

		private void LoadAllTrainingsForAutoComplete()
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					// Загружаем все тренировки для автодополнения
					string query = @"
                        SELECT 
                            t.Название + ' - ' + tr.ФИО as DisplayText
                        FROM Тренировки t
                        JOIN Тренеры tr ON t.ID_Тренера = tr.ID_Тренера
                        JOIN Расписание_тренировок r ON t.ID_Тренировки = r.ID_Тренировки
                        WHERE r.Дата_время >= GETDATE()
                        GROUP BY t.Название, tr.ФИО
                        ORDER BY t.Название";

					SqlCommand command = new SqlCommand(query, connection);
					SqlDataReader reader = command.ExecuteReader();

					trainingSuggestions.Clear();
					while (reader.Read())
					{
						trainingSuggestions.Add(reader["DisplayText"].ToString());
					}

					reader.Close();

					textBox1.AutoCompleteCustomSource = trainingSuggestions;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка загрузки тренировок: " + ex.Message,
					"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void TextBox1_TextChanged(object sender, EventArgs e)
		{
			if (textBox1.Text == "Начните вводить название тренировки...")
				return;

			if (textBox1.Text.Length >= 2)
			{
				searchTimer.Stop();
				searchTimer.Start();
			}
			else
			{
				UpdateAutoCompleteSuggestions("");
			}
		}

		private void SearchTimer_Tick(object sender, EventArgs e)
		{
			searchTimer.Stop();
			UpdateAutoCompleteSuggestions(textBox1.Text.Trim());
		}

		private void UpdateAutoCompleteSuggestions(string searchText)
		{
			if (string.IsNullOrEmpty(searchText) || searchText.Length < 2)
			{
				LoadAllTrainingsForAutoComplete();
				return;
			}

			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					string query = @"
                        SELECT 
                            t.Название + ' - ' + tr.ФИО as DisplayText
                        FROM Тренировки t
                        JOIN Тренеры tr ON t.ID_Тренера = tr.ID_Тренера
                        JOIN Расписание_тренировок r ON t.ID_Тренировки = r.ID_Тренировки
                        WHERE (t.Название LIKE '%' + @SearchText + '%' 
                               OR tr.ФИО LIKE '%' + @SearchText + '%'
                               OR t.Название + ' - ' + tr.ФИО LIKE '%' + @SearchText + '%')
                        AND r.Дата_время >= GETDATE()
                        GROUP BY t.Название, tr.ФИО
                        ORDER BY t.Название";

					SqlCommand command = new SqlCommand(query, connection);
					command.Parameters.AddWithValue("@SearchText", searchText);

					SqlDataReader reader = command.ExecuteReader();

					AutoCompleteStringCollection filteredSuggestions = new AutoCompleteStringCollection();

					while (reader.Read())
					{
						filteredSuggestions.Add(reader["DisplayText"].ToString());
					}

					reader.Close();

					textBox1.AutoCompleteCustomSource = filteredSuggestions;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка автодополнения: " + ex.Message,
					"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void TextBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				FindEnrolledClients();
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			FindEnrolledClients();
		}

		private void FindEnrolledClients()
		{
			if (string.IsNullOrWhiteSpace(textBox1.Text) ||
				textBox1.Text == "Начните вводить название тренировки...")
			{
				MessageBox.Show("Введите название тренировки", "Внимание",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				textBox1.Focus();
				return;
			}

			if (!textBox1.Text.Contains("-"))
			{
				MessageBox.Show("Формат: 'Название тренировки - Тренер'\nВыберите из списка автодополнения",
					"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			DateTime selectedDateTime = dateTimePicker1.Value.Date.Add(dateTimePicker2.Value.TimeOfDay);

			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					string findTrainingQuery = @"
                        SELECT TOP 1 r.ID_Тренировки, r.Дата_время
                        FROM Расписание_тренировок r
                        JOIN Тренировки t ON r.ID_Тренировки = t.ID_Тренировки
                        JOIN Тренеры tr ON t.ID_Тренера = tr.ID_Тренера
                        WHERE CONCAT(t.Название, ' - ', tr.ФИО) = @TrainingName
                        AND ABS(DATEDIFF(MINUTE, r.Дата_время, @SelectedDateTime)) <= 30
                        ORDER BY ABS(DATEDIFF(MINUTE, r.Дата_время, @SelectedDateTime))";

					SqlCommand findCommand = new SqlCommand(findTrainingQuery, connection);
					findCommand.Parameters.AddWithValue("@TrainingName", textBox1.Text.Trim());
					findCommand.Parameters.AddWithValue("@SelectedDateTime", selectedDateTime);

					SqlDataReader reader = findCommand.ExecuteReader();

					if (!reader.HasRows)
					{
						reader.Close();
						MessageBox.Show("Тренировка не найдена в расписании.\nПроверьте дату и время.",
							"Не найдено", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}

					reader.Read();
					int trainingId = reader.GetInt32(0);
					DateTime actualDateTime = reader.GetDateTime(1);
					reader.Close();

					dateTimePicker1.Value = actualDateTime.Date;
					dateTimePicker2.Value = DateTime.Today.Add(actualDateTime.TimeOfDay);

					string query = @"
                        SELECT 
                            c.ID_Клиента,
                            c.ФИО,
                            c.Номер_телефона,
                            CASE 
                                WHEN EXISTS (SELECT 1 FROM Посещения p 
                                           WHERE p.ID_клиента = c.ID_Клиента 
                                           AND ABS(DATEDIFF(MINUTE, p.Дата_посещения, @TrainingDateTime)) <= 5) 
                                THEN 1 
                                ELSE 0 
                            END as Посетил
                        FROM Записи_на_занятия z
                        JOIN Клиенты c ON z.ID_Клиента = c.ID_Клиента
                        WHERE z.ID_Тренировки = @TrainingId
                        AND ABS(DATEDIFF(MINUTE, z.Дата_время, @TrainingDateTime)) <= 5
                        ORDER BY c.ФИО";

					SqlCommand command = new SqlCommand(query, connection);
					command.Parameters.AddWithValue("@TrainingId", trainingId);
					command.Parameters.AddWithValue("@TrainingDateTime", actualDateTime);

					SqlDataAdapter adapter = new SqlDataAdapter(command);
					clientsTable = new DataTable();
					adapter.Fill(clientsTable);

					dataGridView1.Rows.Clear();

					foreach (DataRow row in clientsTable.Rows)
					{
						int rowIndex = dataGridView1.Rows.Add();
						dataGridView1.Rows[rowIndex].Cells["ID_Клиента"].Value = row["ID_Клиента"];
						dataGridView1.Rows[rowIndex].Cells["ФИО"].Value = row["ФИО"];
						dataGridView1.Rows[rowIndex].Cells["Телефон"].Value = row["Номер_телефона"];

						bool visited = Convert.ToBoolean(row["Посетил"]);

						// Устанавливаем статус
						dataGridView1.Rows[rowIndex].Cells["Статус"].Value = visited ? "✓ Посещено" : "Не посещено";

						// Устанавливаем значение CheckBox
						dataGridView1.Rows[rowIndex].Cells["Отметить"].Value = false;

						// Разрешаем/запрещаем редактирование CheckBox
						dataGridView1.Rows[rowIndex].Cells["Отметить"].ReadOnly = visited;
					}

					// ОБНОВЛЯЕМ ЦВЕТА ПОСЛЕ ЗАПОЛНЕНИЯ
					UpdateRowColors();

					label4.Text = $"Найдено: {clientsTable.Rows.Count} клиентов";
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка поиска: " + ex.Message, "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			// Кнопка "Отметить всех доступных" - отмечает всех, кого можно
			MarkAllAvailable();
		}

		private void MarkAllAvailable()
		{
			if (dataGridView1.Rows.Count == 0)
			{
				MessageBox.Show("Сначала найдите клиентов", "Внимание",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			int markedCount = 0;

			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				bool canMark = !dataGridView1.Rows[i].Cells["Отметить"].ReadOnly;
				if (canMark)
				{
					dataGridView1.Rows[i].Cells["Отметить"].Value = true;
					markedCount++;
				}
			}

			MessageBox.Show($"Отмечено для отметки: {markedCount} клиентов", "Информация",
				MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			// Кнопка "Сохранить изменения" - добавляет посещения в БД
			SaveVisitsToDatabase();
		}

		private void SaveVisitsToDatabase()
		{
			if (dataGridView1.Rows.Count == 0)
			{
				MessageBox.Show("Нет клиентов для сохранения", "Внимание",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			if (MessageBox.Show("Сохранить отмеченные посещения в базу данных?", "Подтверждение",
				MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
			{
				return;
			}

			DateTime selectedDateTime = dateTimePicker1.Value.Date.Add(dateTimePicker2.Value.TimeOfDay);
			int successCount = 0;
			int errorCount = 0;
			List<string> errorMessages = new List<string>();

			try
			{
				int trainingId = GetTrainingId(selectedDateTime);
				if (trainingId == -1)
				{
					MessageBox.Show("Тренировка не найдена", "Ошибка",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					for (int i = 0; i < dataGridView1.Rows.Count; i++)
					{
						try
						{
							bool isChecked = false;
							object checkValue = dataGridView1.Rows[i].Cells["Отметить"].Value;

							if (checkValue != null && checkValue != DBNull.Value)
							{
								isChecked = Convert.ToBoolean(checkValue);
							}

							bool alreadyVisited = dataGridView1.Rows[i].Cells["Статус"].Value?.ToString() == "✓ Посещено";

							if (isChecked && !alreadyVisited)
							{
								int clientId = Convert.ToInt32(dataGridView1.Rows[i].Cells["ID_Клиента"].Value);
								string clientName = dataGridView1.Rows[i].Cells["ФИО"].Value?.ToString() ?? "Неизвестный";

								using (SqlCommand cmd = new SqlCommand("[Отметка о посещении]", connection))
								{
									cmd.CommandType = CommandType.StoredProcedure;

									cmd.Parameters.AddWithValue("@ID_Клиента", clientId);
									cmd.Parameters.AddWithValue("@ID_Тренировки", trainingId);
									cmd.Parameters.AddWithValue("@Дата_время_тренировки", selectedDateTime);

									SqlParameter errorParam = new SqlParameter("@ErrorMessage", SqlDbType.VarChar, 500);
									errorParam.Direction = ParameterDirection.Output;
									cmd.Parameters.Add(errorParam);

									SqlParameter returnParam = new SqlParameter("@ReturnValue", SqlDbType.Int);
									returnParam.Direction = ParameterDirection.ReturnValue;
									cmd.Parameters.Add(returnParam);

									cmd.ExecuteNonQuery();

									int result = (int)returnParam.Value;
									string message = errorParam.Value?.ToString() ?? "Неизвестная ошибка";

									if (result == 0)
									{
										// Обновляем статус в DataGridView
										dataGridView1.Rows[i].Cells["Статус"].Value = "✓ Посещено";
										dataGridView1.Rows[i].Cells["Отметить"].Value = false;
										dataGridView1.Rows[i].Cells["Отметить"].ReadOnly = true;

										successCount++;
									}
									else
									{
										errorCount++;
										errorMessages.Add($"Клиент {clientName} (ID: {clientId}): {message}");
										Console.WriteLine($"Ошибка для клиента {clientName}: {message}");
									}
								}
							}
						}
						catch (Exception ex)
						{
							errorCount++;
							string clientName = dataGridView1.Rows[i].Cells["ФИО"].Value?.ToString() ?? "Неизвестный";
							errorMessages.Add($"Клиент {clientName}: {ex.Message}");
							Console.WriteLine($"Исключение для клиента {clientName}: {ex.Message}");
						}
					}
				}

				// Показываем результаты
				string resultMessage = $"Успешно сохранено: {successCount} посещений";

				if (errorCount > 0)
				{
					resultMessage += $"\nОшибок: {errorCount}";

					// Показываем первые 5 ошибок
					string detailedErrors = "";
					int errorsToShow = Math.Min(5, errorMessages.Count);

					for (int i = 0; i < errorsToShow; i++)
					{
						detailedErrors += errorMessages[i] + "\n";
					}

					if (errorMessages.Count > 5)
					{
						detailedErrors += $"... и еще {errorMessages.Count - 5} ошибок";
					}

					MessageBox.Show($"{resultMessage}\n\nПодробности ошибок:\n{detailedErrors}",
						"Результат сохранения с ошибками",
						MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
				else
				{
					MessageBox.Show(resultMessage, "Успешно сохранено",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				label4.Text = $"Сохранено: {successCount}, Ошибок: {errorCount}";

				// ОБНОВЛЯЕМ ЦВЕТА ВСЕХ СТРОК
				UpdateRowColors();

			}
			catch (Exception ex)
			{
				MessageBox.Show($"Критическая ошибка при сохранении: {ex.Message}\n\nStackTrace: {ex.StackTrace}",
					"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// МЕТОД ДЛЯ ОБНОВЛЕНИЯ ЦВЕТОВ СТРОК
		private void UpdateRowColors()
		{
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				bool visited = dataGridView1.Rows[i].Cells["Статус"].Value?.ToString() == "✓ Посещено";

				if (visited)
				{
					// Устанавливаем зеленый цвет для всей строки
					dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
					dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.DarkGreen;

					// Блокируем CheckBox
					dataGridView1.Rows[i].Cells["Отметить"].ReadOnly = true;
				}
				else
				{
					// Устанавливаем желтый цвет для всей строки
					dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightYellow;
					dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;

					// Разрешаем CheckBox
					dataGridView1.Rows[i].Cells["Отметить"].ReadOnly = false;
				}
			}

			// Обновляем отображение
			dataGridView1.Refresh();
		}

		private int GetTrainingId(DateTime selectedDateTime)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string query = @"
                        SELECT TOP 1 r.ID_Тренировки
                        FROM Расписание_тренировок r
                        JOIN Тренировки t ON r.ID_Тренировки = t.ID_Тренировки
                        JOIN Тренеры tr ON t.ID_Тренера = tr.ID_Тренера
                        WHERE CONCAT(t.Название, ' - ', tr.ФИО) = @TrainingName
                        AND ABS(DATEDIFF(MINUTE, r.Дата_время, @SelectedDateTime)) <= 30";

					SqlCommand command = new SqlCommand(query, connection);
					command.Parameters.AddWithValue("@TrainingName", textBox1.Text.Trim());
					command.Parameters.AddWithValue("@SelectedDateTime", selectedDateTime);

					object result = command.ExecuteScalar();
					return result != null ? Convert.ToInt32(result) : -1;
				}
			}
			catch
			{
				return -1;
			}
		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(textBox1.Text) && textBox1.Text.Contains("-"))
			{
				AutoSetDateTimeFromTraining();
			}
		}

		private void AutoSetDateTimeFromTraining()
		{
			if (string.IsNullOrWhiteSpace(textBox1.Text) || !textBox1.Text.Contains("-"))
				return;

			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					string query = @"
                        SELECT TOP 1 
                            r.Дата_время
                        FROM Расписание_тренировок r
                        JOIN Тренировки t ON r.ID_Тренировки = t.ID_Тренировки
                        JOIN Тренеры tr ON t.ID_Тренера = tr.ID_Тренера
                        WHERE CONCAT(t.Название, ' - ', tr.ФИО) = @TrainingName
                        AND r.Дата_время >= GETDATE()
                        ORDER BY r.Дата_время";

					SqlCommand command = new SqlCommand(query, connection);
					command.Parameters.AddWithValue("@TrainingName", textBox1.Text.Trim());

					object result = command.ExecuteScalar();

					if (result != null && result != DBNull.Value)
					{
						DateTime trainingDateTime = Convert.ToDateTime(result);
						dateTimePicker1.Value = trainingDateTime.Date;
						dateTimePicker2.Value = DateTime.Today.Add(trainingDateTime.TimeOfDay);
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Auto-set error: " + ex.Message);
			}
		}

		// Дополнительно: двойной клик по строке для быстрой отметки
		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
			{
				// Если кликнули на ячейку "Отметить" и ее можно редактировать
				if (e.ColumnIndex == dataGridView1.Columns["Отметить"].Index)
				{
					bool canMark = !dataGridView1.Rows[e.RowIndex].Cells["Отметить"].ReadOnly;
					if (canMark)
					{
						bool currentValue = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells["Отметить"].Value);
						dataGridView1.Rows[e.RowIndex].Cells["Отметить"].Value = !currentValue;
					}
				}
			}
		}

		// Обработчик для обновления цветов при изменении значения CheckBox
		private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
			{
				// Если изменилось значение CheckBox, обновляем строку
				if (dataGridView1.Columns[e.ColumnIndex].Name == "Отметить")
				{
					UpdateRowColors();
				}
			}
		}
	}
}