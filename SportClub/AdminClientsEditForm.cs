using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportClub
{
	public partial class AdminClientsEditForm : Form
	{
		public AdminClientsEditForm()
		{
			InitializeComponent();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}
		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				string connectionString = @"Data Source=DESKTOP-PGUAQQC\SQLEXPRESS;Initial Catalog=FitnessClub;Integrated Security=True";

				string text = textBoxId.Text;
				int id = Convert.ToInt32(text);
				string fio = textBoxFIO.Text;
				string phone = textBoxPhone.Text;
				string birthDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");

				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					string sql = $"UPDATE Клиенты  " +
								$"SET ФИО = '{fio}', Номер_телефона = '{phone}', Дата_рождения = '{birthDate}' " +
								$"WHERE ID_Клиента = {id}";

					using (SqlCommand insertCommand = new SqlCommand(sql, connection))
					{
						int rowsAffected = insertCommand.ExecuteNonQuery();

						if (rowsAffected > 0)
						{
							MessageBox.Show($"Данные клиента успешно изменены!");
							this.Close();
						}
						else
						{
							MessageBox.Show("Клиент не найден или данные не изменились", "Ошибка");
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка: " + ex.Message);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void buttonFind_Click(object sender, EventArgs e)
		{
			try
			{
				if (!int.TryParse(textBoxId.Text, out int clientId))
				{
					MessageBox.Show("Введите корректный ID клиента (только цифры)", "Ошибка");
					textBoxId.Focus();
					textBoxId.SelectAll();
					return;
				}

				string connectionString = @"Data Source=DESKTOP-PGUAQQC\SQLEXPRESS;Initial Catalog=FitnessClub;Integrated Security=True";

				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					string query = "SELECT ФИО, Номер_телефона, Дата_рождения FROM Клиенты WHERE ID_Клиента = @ID";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@ID", clientId);

						using (SqlDataReader reader = command.ExecuteReader())
						{
							if (reader.Read())
							{
								// Клиент найден - заполняем поля данными
								textBoxFIO.Text = reader["ФИО"].ToString();
								textBoxPhone.Text = reader["Номер_телефона"].ToString();

								if (reader["Дата_рождения"] != DBNull.Value)
								{
									dateTimePicker1.Value = Convert.ToDateTime(reader["Дата_рождения"]);
								}
							}
							else
							{
								MessageBox.Show($"Клиент с ID {clientId} не найден в базе данных", "Ошибка");
								textBoxFIO.Text = "";
								textBoxPhone.Text = "";
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка при поиске клиента: {ex.Message}", "Ошибка");
			}
		}
	}
}