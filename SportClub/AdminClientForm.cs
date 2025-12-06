using System;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SportClub
{
	public partial class AdminClientForm : Form
	{

		private string connectionString = @"Data Source=DESKTOP-PGUAQQC\SQLEXPRESS;Initial Catalog=FitnessClub;Integrated Security=True";
		public AdminClientForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			AdminClientsCreateForm createForm = new AdminClientsCreateForm();
			createForm.ShowDialog();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Form AdminClientsEditForm = new AdminClientsEditForm();
			AdminClientsEditForm.Show();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			AdminForm adminForm = new AdminForm();
			adminForm.Show();
			this.Close();
		}

		private void AdminClientForm_Load(object sender, EventArgs e)
		{
			// TODO: данная строка кода позволяет загрузить данные в таблицу "fitnessClubDataSet.Клиенты". При необходимости она может быть перемещена или удалена.
			this.клиентыTableAdapter1.Fill(this.fitnessClubDataSet.Клиенты);

		}

		private void button2_Click(object sender, EventArgs e) //Кнопка удалить
		{
			// 1. Проверяем, выбрана ли строка в DataGridView
			if (dataGridView1.SelectedRows.Count == 0)
			{
				MessageBox.Show("Пожалуйста, выберите клиента для удаления",
					"Не выбран клиент",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return;
			}

			// 2. Получаем данные выбранного клиента с ПРАВИЛЬНЫМИ именами столбцов
			DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

			int clientId = 0;
			string clientFIO = "";
			string clientPhone = "";
			string clientBirthDate = "";

			try
			{
				// Используем правильные имена столбцов
				clientId = Convert.ToInt32(selectedRow.Cells["IDКлиентаDataGridViewTextBoxColumn"].Value);
				clientFIO = selectedRow.Cells["ФИОDataGridViewTextBoxColumn"].Value.ToString();
				clientPhone = selectedRow.Cells["номертелефонаDataGridViewTextBoxColumn"].Value?.ToString() ?? "";

				// Получаем дату рождения
				if (selectedRow.Cells["датарожденияDataGridViewTextBoxColumn"].Value != null &&
					selectedRow.Cells["датарожденияDataGridViewTextBoxColumn"].Value != DBNull.Value)
				{
					clientBirthDate = Convert.ToDateTime(
						selectedRow.Cells["датарожденияDataGridViewTextBoxColumn"].Value).ToString("dd.MM.yyyy");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка получения данных клиента:\n{ex.Message}",
					"Ошибка",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}

			// 3. Формируем сообщение с информацией о клиенте
			string message = $"Вы действительно хотите удалить клиента?\n\n";

			// 4. Показываем окно подтверждения
			DialogResult result = MessageBox.Show(
				message,
				"Подтверждение удаления",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Warning,
				MessageBoxDefaultButton.Button2); // По умолчанию выбран "Нет"

			// 5. Если пользователь подтвердил удаление
			if (result == DialogResult.Yes)
			{
				// 6. Выполняем удаление
				try
				{
					using (SqlConnection connection = new SqlConnection(connectionString))
					{
						connection.Open();

						// SQL-запрос для удаления клиента
						string deleteQuery = "DELETE FROM Клиенты WHERE ID_Клиента = @id";

						using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
						{
							cmd.Parameters.AddWithValue("@id", clientId);
							int rowsAffected = cmd.ExecuteNonQuery();

							if (rowsAffected > 0)
							{
								// 7. Успешное удаление
								MessageBox.Show($"Клиент '{clientFIO}' успешно удален",
									"Успешно",
									MessageBoxButtons.OK,
									MessageBoxIcon.Information);

								// 8. Обновляем таблицу
								this.клиентыTableAdapter1.Fill(this.fitnessClubDataSet.Клиенты);
							}
							else
							{
								MessageBox.Show("Клиент не найден в базе данных",
									"Ошибка",
									MessageBoxButtons.OK,
									MessageBoxIcon.Error);
							}
						}
					}
				}
				catch (SqlException ex)
				{
					if (ex.Message.Contains("Нельзя удалить клиента") ||
						ex.Message.Contains("активные абонементы") ||
						ex.Message.Contains("ОШИБКА:"))
					{
						// Показываем сообщение от триггера как есть
						MessageBox.Show(
							$"{ex.Message}\n\n" +
							$"Клиент: {clientFIO}\n",
							"Ошибка удаления",
							MessageBoxButtons.OK,
							MessageBoxIcon.Error);
					}
					else if (ex.Number == 547) // Ошибка внешнего ключа
					{
						MessageBox.Show(
							"Ошибка удаления! Есть связанные записи в других таблицах.",
							"Ошибка целостности данных",
							MessageBoxButtons.OK,
							MessageBoxIcon.Error);
					}
					else
					{
						MessageBox.Show($"Ошибка базы данных:\n{ex.Message}",
							"Ошибка",
							MessageBoxButtons.OK,
							MessageBoxIcon.Error);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Ошибка:\n{ex.Message}",
						"Ошибка",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				}
			}
		}

        private void button6_Click(object sender, EventArgs e)
        {
			клиентыTableAdapter1.Fill(fitnessClubDataSet.Клиенты);

			dataGridView1.ClearSelection();
		}
    }
}