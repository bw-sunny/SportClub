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
    public partial class AdminClientsCreateForm : Form
    {
        public AdminClientsCreateForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
			try
			{
				// 1. Строка подключения
				string connectionString = @"Data Source=DESKTOP-PGUAQQC\SQLEXPRESS;Initial Catalog=FitnessClub;Integrated Security=True";

				// 2. Получаем данные из полей
				string fio = textBoxFIO.Text;
				string phone = textBoxPhone.Text;
				string birthDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");

				// 3. Находим максимальный ID
				int newId = 1;

				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					// Находим максимальный ID
					string maxIdQuery = "SELECT ISNULL(MAX(ID_Клиента), 0) FROM Клиенты";
					using (SqlCommand maxIdCommand = new SqlCommand(maxIdQuery, connection))
					{
						object result = maxIdCommand.ExecuteScalar();
						int maxId = Convert.ToInt32(result);
						newId = maxId + 1;
					}

					// 4. SQL команда для добавления с указанием ID
					string sql = $"INSERT INTO Клиенты (ID_Клиента, ФИО, Номер_телефона, Дата_рождения) " +
								$"VALUES ({newId}, '{fio}', '{phone}', '{birthDate}')";

					// 5. Выполняем команду добавления
					using (SqlCommand insertCommand = new SqlCommand(sql, connection))
					{
						insertCommand.ExecuteNonQuery();
					}
				}

				// 6. Сообщение об успехе с указанием нового ID
				MessageBox.Show($"Клиент добавлен! ID: {newId}");

				// 7. Закрываем форму
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка: " + ex.Message);
			}
		}
    }
}
