using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SportClub
{
	public partial class AdminEnrollsNew : Form
	{
		private string connectionString = @"Data Source=DESKTOP-PGUAQQC\SQLEXPRESS;Initial Catalog=FitnessClub;Integrated Security=True";

		public AdminEnrollsNew()
		{
			InitializeComponent();
			SetupForm();
		}

		private void SetupForm()
		{
			// Настройка формы
			this.Text = "Новая запись на занятие";
			this.StartPosition = FormStartPosition.CenterScreen;

			// Настройка DateTimePicker
			dateTimePicker1.Format = DateTimePickerFormat.Custom;
			dateTimePicker1.CustomFormat = "dd.MM.yyyy HH:mm";
			dateTimePicker1.Value = DateTime.Now.AddDays(1).Date.AddHours(18);
			dateTimePicker1.ShowUpDown = true;

			// Настройка подсказок в TextBox
			textBox1.Text = "Начните вводить ФИО клиента...";
			textBox1.ForeColor = Color.Gray;
			textBox2.Text = "Начните вводить название тренировки...";
			textBox2.ForeColor = Color.Gray;

			// Настройка кнопок
			button1.Text = "Записать";
			button2.Text = "Отмена";

			// Загрузка автодополнения
			LoadAutoCompleteData();
		}

		// ==================== АВТОДОПОЛНЕНИЕ ====================
		private void LoadAutoCompleteData()
		{
			SetupClientAutoComplete();
			SetupTrainingAutoComplete();
		}

		private void SetupClientAutoComplete()
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string query = "SELECT ФИО FROM Клиенты ORDER BY ФИО";

					SqlCommand cmd = new SqlCommand(query, connection);
					SqlDataReader reader = cmd.ExecuteReader();

					AutoCompleteStringCollection clientCollection = new AutoCompleteStringCollection();

					while (reader.Read())
					{
						clientCollection.Add(reader["ФИО"].ToString());
					}

					reader.Close();

					textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
					textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
					textBox1.AutoCompleteCustomSource = clientCollection;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка загрузки автодополнения клиентов: " + ex.Message,
					"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void SetupTrainingAutoComplete()
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string query = @"
                        SELECT t.Название + ' - ' + tr.ФИО as ПолноеНазвание
                        FROM Тренировки t
                        JOIN Тренеры tr ON t.ID_Тренера = tr.ID_Тренера
                        ORDER BY t.Название";

					SqlCommand cmd = new SqlCommand(query, connection);
					SqlDataReader reader = cmd.ExecuteReader();

					AutoCompleteStringCollection trainingCollection = new AutoCompleteStringCollection();

					while (reader.Read())
					{
						trainingCollection.Add(reader["ПолноеНазвание"].ToString());
					}

					reader.Close();

					textBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
					textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
					textBox2.AutoCompleteCustomSource = trainingCollection;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка загрузки автодополнения тренировок: " + ex.Message,
					"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// ==================== ПОДСКАЗКИ В TEXTBOX ====================
		private void textBox1_Enter(object sender, EventArgs e)
		{
			if (textBox1.Text == "Начните вводить ФИО клиента...")
			{
				textBox1.Text = "";
				textBox1.ForeColor = Color.Black;
			}
		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(textBox1.Text))
			{
				textBox1.Text = "Начните вводить ФИО клиента...";
				textBox1.ForeColor = Color.Gray;
			}
		}

		private void textBox2_Enter(object sender, EventArgs e)
		{
			if (textBox2.Text == "Начните вводить название тренировки...")
			{
				textBox2.Text = "";
				textBox2.ForeColor = Color.Black;
			}
		}

		private void textBox2_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(textBox2.Text))
			{
				textBox2.Text = "Начните вводить название тренировки...";
				textBox2.ForeColor = Color.Gray;
			}
		}

		// ==================== ПРОВЕРКА КЛИЕНТА ПРИ ВВОДЕ ====================
		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			string searchText = textBox1.Text.Trim();

			if (!string.IsNullOrEmpty(searchText) && searchText != "Начните вводить ФИО клиента...")
			{
				CheckClientExists(searchText);
			}
			else
			{
				textBox1.BackColor = Color.White;
			}
		}

		private void CheckClientExists(string clientName)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					string query = "SELECT COUNT(*) FROM Клиенты WHERE ФИО = @ClientName";
					SqlCommand cmd = new SqlCommand(query, connection);
					cmd.Parameters.AddWithValue("@ClientName", clientName);

					int count = Convert.ToInt32(cmd.ExecuteScalar());

					if (count == 0)
					{
						textBox1.BackColor = Color.LightPink;
						FindSimilarClients(clientName);
					}
					else
					{
						textBox1.BackColor = Color.LightGreen;
						CheckClientSubscription(clientName);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка проверки клиента: " + ex.Message,
					"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void FindSimilarClients(string partialName)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					string query = "SELECT TOP 5 ФИО FROM Клиенты WHERE ФИО LIKE @PartialName ORDER BY ФИО";
					SqlCommand cmd = new SqlCommand(query, connection);
					cmd.Parameters.AddWithValue("@PartialName", "%" + partialName + "%");

					SqlDataReader reader = cmd.ExecuteReader();
					List<string> similarClients = new List<string>();

					while (reader.Read())
					{
						similarClients.Add(reader["ФИО"].ToString());
					}
					reader.Close();

					if (similarClients.Count > 0 && similarClients.Count == 1)
					{
						DialogResult result = MessageBox.Show(
							$"Клиент '{partialName}' не найден.\n\nНайден похожий клиент: {similarClients[0]}\n\nИспользовать его?",
							"Подсказка",
							MessageBoxButtons.YesNo,
							MessageBoxIcon.Question);

						if (result == DialogResult.Yes)
						{
							textBox1.Text = similarClients[0];
							textBox1.BackColor = Color.LightGreen;
						}
					}
				}
			}
			catch
			{
				// Игнорируем ошибку поиска похожих
			}
		}

		private void CheckClientSubscription(string clientName)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					// Находим ID клиента
					string query = "SELECT ID_Клиента FROM Клиенты WHERE ФИО = @ClientName";
					SqlCommand cmd = new SqlCommand(query, connection);
					cmd.Parameters.AddWithValue("@ClientName", clientName);

					object clientIdObj = cmd.ExecuteScalar();

					if (clientIdObj != null)
					{
						int clientId = Convert.ToInt32(clientIdObj);

						// ИСПРАВЛЕНО: Используем правильное имя таблицы Абонементы
						query = @"
                            SELECT TOP 1 Количество_занятий, Дата_оформления
                            FROM Абонементы 
                            WHERE ID_Клиента = @ClientId
                            ORDER BY Дата_оформления DESC";

						cmd = new SqlCommand(query, connection);
						cmd.Parameters.AddWithValue("@ClientId", clientId);

						SqlDataReader reader = cmd.ExecuteReader();

						if (reader.Read())
						{
							int remainingVisits = Convert.ToInt32(reader["Количество_занятий"]);
							DateTime issueDate = Convert.ToDateTime(reader["Дата_оформления"]);

							if (remainingVisits <= 0)
							{
								MessageBox.Show($"У клиента '{clientName}' закончились занятия по абонементу!\nПоследний абонемент от: {issueDate:dd.MM.yyyy}",
									"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							}
						}
						else
						{
							MessageBox.Show($"У клиента '{clientName}' нет активного абонемента!",
								"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}

						reader.Close();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка проверки абонемента: " + ex.Message,
					"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// ==================== ПРОВЕРКА ТРЕНИРОВКИ ПРИ ВВОДЕ ====================
		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			string searchText = textBox2.Text.Trim();

			if (!string.IsNullOrEmpty(searchText) && searchText != "Начните вводить название тренировки...")
			{
				CheckTrainingExists(searchText);
			}
			else
			{
				textBox2.BackColor = Color.White;
			}
		}

		private void CheckTrainingExists(string trainingName)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					string cleanTrainingName = trainingName;
					if (trainingName.Contains(" - "))
					{
						cleanTrainingName = trainingName.Split(new[] { " - " }, StringSplitOptions.None)[0];
					}

					string query = "SELECT COUNT(*) FROM Тренировки WHERE Название = @TrainingName";
					SqlCommand cmd = new SqlCommand(query, connection);
					cmd.Parameters.AddWithValue("@TrainingName", cleanTrainingName);

					int count = Convert.ToInt32(cmd.ExecuteScalar());

					if (count == 0)
					{
						textBox2.BackColor = Color.LightPink;
						FindSimilarTrainings(cleanTrainingName);
					}
					else
					{
						textBox2.BackColor = Color.LightGreen;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка проверки тренировки: " + ex.Message,
					"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void FindSimilarTrainings(string partialName)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					string query = @"
                        SELECT TOP 5 t.Название + ' - ' + tr.ФИО as ПолноеНазвание
                        FROM Тренировки t
                        JOIN Тренеры tr ON t.ID_Тренера = tr.ID_Тренера
                        WHERE t.Название LIKE @PartialName 
                        ORDER BY t.Название";

					SqlCommand cmd = new SqlCommand(query, connection);
					cmd.Parameters.AddWithValue("@PartialName", "%" + partialName + "%");

					SqlDataReader reader = cmd.ExecuteReader();
					List<string> similarTrainings = new List<string>();

					while (reader.Read())
					{
						similarTrainings.Add(reader["ПолноеНазвание"].ToString());
					}
					reader.Close();

					if (similarTrainings.Count > 0 && similarTrainings.Count == 1)
					{
						DialogResult result = MessageBox.Show(
							$"Тренировка '{partialName}' не найдена.\n\nНайдена похожая тренировка: {similarTrainings[0]}\n\nИспользовать ее?",
							"Подсказка",
							MessageBoxButtons.YesNo,
							MessageBoxIcon.Question);

						if (result == DialogResult.Yes)
						{
							textBox2.Text = similarTrainings[0];
							textBox2.BackColor = Color.LightGreen;
						}
					}
				}
			}
			catch
			{
				// Игнорируем ошибку поиска похожих
			}
		}

		// ==================== КНОПКА ЗАПИСАТЬ ====================
		private void button1_Click(object sender, EventArgs e)
		{
			// 1. Проверка ввода клиента
			if (string.IsNullOrWhiteSpace(textBox1.Text) ||
				textBox1.Text == "Начните вводить ФИО клиента...")
			{
				MessageBox.Show("Введите ФИО клиента!", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				textBox1.Focus();
				return;
			}

			// 2. Проверка ввода тренировки
			if (string.IsNullOrWhiteSpace(textBox2.Text) ||
				textBox2.Text == "Начните вводить название тренировки...")
			{
				MessageBox.Show("Введите название тренировки!", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				textBox2.Focus();
				return;
			}

			// 3. Проверка формата даты
			DateTime selectedDateTime = dateTimePicker1.Value;
			if (selectedDateTime < DateTime.Now)
			{
				DialogResult result = MessageBox.Show(
					$"Вы выбрали прошедшую дату: {selectedDateTime:dd.MM.yyyy HH:mm}\n\nПродолжить?",
					"Внимание",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Warning);

				if (result != DialogResult.Yes)
				{
					dateTimePicker1.Focus();
					return;
				}
			}

			// 4. Получение ID клиента
			string clientName = textBox1.Text.Trim();
			int? clientId = GetClientIdByName(clientName);

			if (!clientId.HasValue)
			{
				MessageBox.Show($"Клиент '{clientName}' не найден!\nПроверьте правильность ввода.",
					"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				textBox1.Focus();
				return;
			}

			// 5. Получение ID тренировки
			string trainingFullName = textBox2.Text.Trim();
			int? trainingId = GetTrainingIdByName(trainingFullName);

			if (!trainingId.HasValue)
			{
				MessageBox.Show($"Тренировка '{trainingFullName}' не найдена!\nПроверьте правильность ввода.",
					"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				textBox2.Focus();
				return;
			}

			// 6. Проверка наличия занятия в расписании
			if (!CheckScheduleExists(trainingId.Value, selectedDateTime))
			{
				MessageBox.Show($"Тренировка не проводится в выбранное время: {selectedDateTime:dd.MM.yyyy HH:mm}",
					"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// 7. Проверка активного абонемента у клиента
			if (!CheckActiveSubscription(clientId.Value))
			{
				MessageBox.Show($"У клиента нет активного абонемента или закончились занятия!",
					"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// 8. Проверка на дублирование записи
			if (CheckDuplicateEnrollment(clientId.Value, trainingId.Value, selectedDateTime))
			{
				MessageBox.Show($"Клиент уже записан на эту тренировку в указанное время!",
					"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// 9. Вызов хранимой процедуры
			ExecuteEnrollmentProcedure(clientId.Value, trainingId.Value, selectedDateTime);
		}

		private int? GetClientIdByName(string clientName)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					string query = "SELECT ID_Клиента FROM Клиенты WHERE ФИО = @ClientName";
					SqlCommand cmd = new SqlCommand(query, connection);
					cmd.Parameters.AddWithValue("@ClientName", clientName);

					object result = cmd.ExecuteScalar();

					if (result != null)
					{
						return Convert.ToInt32(result);
					}

					return null;
				}
			}
			catch
			{
				return null;
			}
		}

		private int? GetTrainingIdByName(string trainingFullName)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					string trainingName = trainingFullName;
					if (trainingFullName.Contains(" - "))
					{
						trainingName = trainingFullName.Split(new[] { " - " }, StringSplitOptions.None)[0];
					}

					string query = "SELECT ID_Тренировки FROM Тренировки WHERE Название = @TrainingName";
					SqlCommand cmd = new SqlCommand(query, connection);
					cmd.Parameters.AddWithValue("@TrainingName", trainingName);

					object result = cmd.ExecuteScalar();

					if (result != null)
					{
						return Convert.ToInt32(result);
					}

					return null;
				}
			}
			catch
			{
				return null;
			}
		}

		private bool CheckScheduleExists(int trainingId, DateTime scheduleTime)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					string query = @"
                        SELECT COUNT(*) 
                        FROM Расписание_тренировок 
                        WHERE ID_Тренировки = @TrainingId 
                        AND Дата_время = @ScheduleTime";

					SqlCommand cmd = new SqlCommand(query, connection);
					cmd.Parameters.AddWithValue("@TrainingId", trainingId);
					cmd.Parameters.AddWithValue("@ScheduleTime", scheduleTime);

					int count = Convert.ToInt32(cmd.ExecuteScalar());

					return count > 0;
				}
			}
			catch
			{
				return false;
			}
		}

		private bool CheckActiveSubscription(int clientId)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					// ИСПРАВЛЕНО: Используем правильное имя таблицы Абонементы
					string query = @"
                        SELECT TOP 1 Количество_занятий
                        FROM Абонементы 
                        WHERE ID_Клиента = @ClientId
                        ORDER BY Дата_оформления DESC";

					SqlCommand cmd = new SqlCommand(query, connection);
					cmd.Parameters.AddWithValue("@ClientId", clientId);

					object result = cmd.ExecuteScalar();

					if (result != null)
					{
						int remainingVisits = Convert.ToInt32(result);
						return remainingVisits > 0;
					}

					return false;
				}
			}
			catch
			{
				return false;
			}
		}

		private bool CheckDuplicateEnrollment(int clientId, int trainingId, DateTime scheduleTime)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					string query = @"
                        SELECT COUNT(*) 
                        FROM Записи_на_занятия 
                        WHERE ID_Клиента = @ClientId 
                        AND ID_Тренировки = @TrainingId
                        AND Дата_время = @ScheduleTime";

					SqlCommand cmd = new SqlCommand(query, connection);
					cmd.Parameters.AddWithValue("@ClientId", clientId);
					cmd.Parameters.AddWithValue("@TrainingId", trainingId);
					cmd.Parameters.AddWithValue("@ScheduleTime", scheduleTime);

					int count = Convert.ToInt32(cmd.ExecuteScalar());

					return count > 0;
				}
			}
			catch
			{
				return false;
			}
		}

		private void ExecuteEnrollmentProcedure(int clientId, int trainingId, DateTime scheduleTime)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					SqlCommand cmd = new SqlCommand("[Добавление новой записи]", connection);
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@ID_Тренировки", trainingId);
					cmd.Parameters.AddWithValue("@ID_Клиента", clientId);
					cmd.Parameters.AddWithValue("@Дата_время", scheduleTime);

					SqlParameter errorParam = new SqlParameter("@ErrorMessage", SqlDbType.VarChar, 500);
					errorParam.Direction = ParameterDirection.Output;
					cmd.Parameters.Add(errorParam);

					cmd.ExecuteNonQuery();

					string message = errorParam.Value?.ToString();

					if (!string.IsNullOrEmpty(message))
					{
						if (message.Contains("успешно"))
						{
							MessageBox.Show("Запись успешно добавлена!", "Успех",
								MessageBoxButtons.OK, MessageBoxIcon.Information);

							this.DialogResult = DialogResult.OK;
							this.Close();
						}
						else
						{
							MessageBox.Show(message, "Ошибка",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
					else
					{
						MessageBox.Show("Запись добавлена успешно!", "Успех",
							MessageBoxButtons.OK, MessageBoxIcon.Information);
						this.DialogResult = DialogResult.OK;
						this.Close();
					}
				}
			}
			catch (SqlException sqlEx)
			{
				MessageBox.Show($"Ошибка базы данных: {sqlEx.Message}", "Ошибка SQL",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// ==================== КНОПКА ОТМЕНА ====================
		private void button2_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void AdminEnrollsNew_Load(object sender, EventArgs e)
		{
			// Дополнительная настройка при загрузке
		}

		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			// Можно добавить проверку доступности времени
		}

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }
    }
}