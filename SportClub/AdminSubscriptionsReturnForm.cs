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
	public partial class AdminSubscriptionsReturnForm : Form
	{
		private string connectionString = @"Data Source=DESKTOP-PGUAQQC\SQLEXPRESS;Initial Catalog=FitnessClub;Integrated Security=True";

		public AdminSubscriptionsReturnForm()
		{
			InitializeComponent();
			// Настраиваем автодополнение в конструкторе
			SetupAutoComplete();

			// Загружаем клиентов асинхронно но БЕЗ обновления UI из другого потока
			LoadClientsInBackground();
		}

		private void AdminSubscriptionsReturnForm_Load(object sender, EventArgs e)
		{
			// Фокус на поле ФИО
			textBox1.Focus();
		}

		// Настройка автодополнения
		private void SetupAutoComplete()
		{
			textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
		}

		// Загрузка клиентов в фоновом режиме БЕЗ проблем с потоками
		private void LoadClientsInBackground()
		{
			// Используем BackgroundWorker для безопасной работы с UI
			var worker = new BackgroundWorker();
			worker.DoWork += Worker_DoWork;
			worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
			worker.RunWorkerAsync();
		}

		private void Worker_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string query = "SELECT ФИО FROM Клиенты ORDER BY ФИО";

					using (SqlCommand cmd = new SqlCommand(query, connection))
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						var collection = new AutoCompleteStringCollection();

						while (reader.Read())
						{
							string fio = reader["ФИО"].ToString();
							if (!string.IsNullOrWhiteSpace(fio))
							{
								collection.Add(fio.Trim());
							}
						}

						e.Result = collection;
					}
				}
			}
			catch (Exception ex)
			{
				e.Result = ex;
			}
		}

		private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				MessageBox.Show($"Ошибка загрузки клиентов: {e.Error.Message}",
							  "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (e.Result is Exception)
			{
				MessageBox.Show($"Ошибка загрузки клиентов: {((Exception)e.Result).Message}",
							  "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (e.Result is AutoCompleteStringCollection collection)
			{
				// Это ВАЖНО: обновляем UI только из UI-потока
				textBox1.AutoCompleteCustomSource = collection;

				// Для отладки можно показать количество
				// MessageBox.Show($"Загружено {collection.Count} клиентов", "Информация");
			}
		}

		// Альтернативный простой синхронный метод
		private void LoadClients()
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string query = "SELECT ФИО FROM Клиенты ORDER BY ФИО";

					using (SqlCommand cmd = new SqlCommand(query, connection))
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						var collection = new AutoCompleteStringCollection();

						while (reader.Read())
						{
							string fio = reader["ФИО"].ToString();
							if (!string.IsNullOrWhiteSpace(fio))
							{
								collection.Add(fio.Trim());
							}
						}

						// Убеждаемся, что мы в UI потоке
						if (textBox1.InvokeRequired)
						{
							textBox1.Invoke(new Action(() =>
							{
								textBox1.AutoCompleteCustomSource = collection;
							}));
						}
						else
						{
							textBox1.AutoCompleteCustomSource = collection;
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка загрузки клиентов: {ex.Message}",
							  "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			// Ничего не делаем здесь
		}

		private void button1_Click(object sender, EventArgs e)//кнопка подтвердить
		{
			// Проверка ФИО клиента
			if (string.IsNullOrWhiteSpace(textBox1.Text))
			{
				MessageBox.Show("Введите ФИО клиента", "Ошибка");
				textBox1.Focus();
				return;
			}

			string clientFIO = textBox1.Text.Trim();

			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					// 1. Находим ID клиента
					string findClientQuery = "SELECT ID_Клиента FROM Клиенты WHERE ФИО = @clientFIO";
					int clientId = 0;

					using (SqlCommand cmd = new SqlCommand(findClientQuery, connection))
					{
						cmd.Parameters.AddWithValue("@clientFIO", clientFIO);
						object clientResult = cmd.ExecuteScalar();

						if (clientResult == null || clientResult == DBNull.Value)
						{
							MessageBox.Show($"Клиент '{clientFIO}' не найден", "Ошибка");
							return;
						}

						clientId = Convert.ToInt32(clientResult);
					}

					// 2. Ищем активный абонемент клиента
					string findAbonementQuery = @"
                        SELECT TOP 1 
                            ID_Абонемента,
                            Количество_занятий,
                            Дата_оформления
                        FROM Абонементы
                        WHERE ID_Клиента = @clientId
                          AND Количество_занятий > 0
                        ORDER BY ID_Абонемента DESC";

					int abonementId = 0;
					int remainingWorkouts = 0;
					DateTime registrationDate = DateTime.Now;

					using (SqlCommand cmd = new SqlCommand(findAbonementQuery, connection))
					{
						cmd.Parameters.AddWithValue("@clientId", clientId);

						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							if (reader.Read())
							{
								abonementId = Convert.ToInt32(reader["ID_Абонемента"]);
								remainingWorkouts = Convert.ToInt32(reader["Количество_занятий"]);

								if (reader["Дата_оформления"] != DBNull.Value)
								{
									registrationDate = Convert.ToDateTime(reader["Дата_оформления"]);
								}
							}
							else
							{
								MessageBox.Show($"У клиента '{clientFIO}' не найден активный абонемент", "Информация");
								return;
							}
						}
					}
					
					// 3. Показываем информацию об абонементе
					textBox2.Text = abonementId.ToString();
					textBox3.Text = remainingWorkouts.ToString();
					dateTimePicker1.Value = registrationDate;
					int price = Convert.ToInt32(remainingWorkouts) * 1000;
					string returnSumma = price.ToString("N0") + " руб.";

					// 4. Подтверждение возврата
					DialogResult dialogResult = MessageBox.Show(
						$"Вы уверены, что хотите вернуть абонемент?\n\n" +
						$"Клиент: {clientFIO}\n" +
						$"ID абонемента: {abonementId}\n" +
						$"Осталось занятий: {remainingWorkouts}\n\n" +
						$"После возврата абонемент будет аннулирован.",
						"Подтверждение возврата",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Question,
						MessageBoxDefaultButton.Button2);

					if (dialogResult == DialogResult.Yes)
					{
						// 5. Выполняем возврат
						string returnQuery = @"
                            UPDATE Абонементы 
                            SET Количество_занятий = 0
                            WHERE ID_Абонемента = @abonementId";

						using (SqlCommand cmd = new SqlCommand(returnQuery, connection))
						{
							cmd.Parameters.AddWithValue("@abonementId", abonementId);

							int rowsAffected = cmd.ExecuteNonQuery();

							if (rowsAffected > 0)
							{
								MessageBox.Show($"Абонемент успешно возвращен!\n\n" +
											  $"ID абонемента: {abonementId}\n" +
											  $"Клиент: {clientFIO}\n" +
											  $"Сумма к возврату: {returnSumma}",
											  "Успешно",
											  MessageBoxButtons.OK,
											  MessageBoxIcon.Information);

								// Очищаем форму
								textBox1.Text = "";
								textBox2.Text = "";
								textBox3.Text = "";
								dateTimePicker1.Value = DateTime.Now;

								// Перезагружаем список клиентов
								LoadClientsInBackground();

								textBox1.Focus();
							}
						}
					}
				}
			}
			catch (SqlException ex)
			{
				MessageBox.Show($"Ошибка базы данных:\n{ex.Message}", "Ошибка");
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
			}
		}

		private void button2_Click(object sender, EventArgs e)//кнопка отмены
		{
			this.Close();
		}

		private void textBox3_TextChanged(object sender, EventArgs e) // колво занятий
		{
			// Пусто
		}

		private void textBox2_TextChanged(object sender, EventArgs e) // id абонемента
		{
			// Пусто
		}

		private void dateTimePicker1_ValueChanged(object sender, EventArgs e) //дата оформления
		{
			// Пусто
		}

	}
}