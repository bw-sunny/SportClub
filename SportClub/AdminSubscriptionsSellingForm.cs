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
	public partial class AdminSubscriptionsSellingForm : Form
	{
		private string connectionString = @"Data Source=DESKTOP-PGUAQQC\SQLEXPRESS;Initial Catalog=FitnessClub;Integrated Security=True";

		public AdminSubscriptionsSellingForm()
		{
			InitializeComponent();
		}

		private void AdminSubscriptionsSellingForm_Load(object sender, EventArgs e)
		{
			// Загрузка списка клиентов для автозаполнения
			LoadClients();

			// Расчет начальной стоимости
			CalculatePrice();

			// Фокус на поле ФИО
			textBox1.Focus();
		}

		// Загрузка списка клиентов для автодополнения
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
						AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

						while (reader.Read())
						{
							collection.Add(reader["ФИО"].ToString());
						}

						// Настройка автодополнения
						textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
						textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
						textBox1.AutoCompleteCustomSource = collection;
					}
				}
			}
			catch (Exception ex)
			{
				// Можно вывести сообщение или просто игнорировать ошибку загрузки
			}
		}

		// Расчет стоимости: Количество * 1000 руб.
		private void CalculatePrice()
		{
			int count = (int)numericUpDown1.Value;
			int price = count * 1000;
			textBox2.Text = price.ToString("N0") + " руб.";
		}

		// Изменение количества занятий
		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			CalculatePrice();
		}

		// Кнопка "Продать" (button1)
		private void button1_Click(object sender, EventArgs e)
		{
			if (!ValidateInput())
				return;

			try
			{
				string clientFIO = textBox1.Text.Trim();
				int workoutCount = (int)numericUpDown1.Value;
				string result = "";

				// Вызов хранимой процедуры
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					using (SqlCommand cmd = new SqlCommand("[ПродажаАбонемента]", connection))
					{
						cmd.CommandType = CommandType.StoredProcedure;

						// Входные параметры
						cmd.Parameters.AddWithValue("@ФИО_клиента", clientFIO);
						cmd.Parameters.AddWithValue("@КоличествоЗанятий", workoutCount);

						// Выходной параметр
						SqlParameter outputParam = new SqlParameter("@Результат", SqlDbType.VarChar, 100);
						outputParam.Direction = ParameterDirection.Output;
						cmd.Parameters.Add(outputParam);

						// Выполнение процедуры
						cmd.ExecuteNonQuery();

						// Получение результата
						result = outputParam.Value.ToString();
					}
				}

				// Обработка результата
				if (result.Contains("успешно") || result.Contains("ID:"))
				{
					// Показываем сообщение с ID абонемента
					string message = result + "\n\nКлиент: " + clientFIO +
									"\nКоличество занятий: " + workoutCount +
									"\nСтоимость: " + textBox2.Text;

					MessageBox.Show(message, "Абонемент продан",
								  MessageBoxButtons.OK, MessageBoxIcon.Information);

					// Закрываем форму
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
				else
				{
					MessageBox.Show(result, "Триггер",
								  MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (SqlException ex)
			{
				// Обработка ошибок триггеров
				if (ex.Message.Contains("активные абонементы") ||
					ex.Message.Contains("дата оформления"))
				{
					MessageBox.Show(ex.Message, "Триггер",
								  MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
				else
				{
					MessageBox.Show($"Ошибка базы данных: {ex.Message}", "Ошибка");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
			}
		}

		// Валидация ввода
		private bool ValidateInput()
		{
			// Проверка ФИО клиента
			if (string.IsNullOrWhiteSpace(textBox1.Text))
			{
				MessageBox.Show("Введите ФИО клиента", "Ошибка");
				textBox1.Focus();
				return false;
			}

			// Проверка количества занятий
			if (numericUpDown1.Value < 1)
			{
				MessageBox.Show("Количество занятий должно быть не менее 1", "Ошибка");
				numericUpDown1.Focus();
				return false;
			}

			return true;
		}

		// Кнопка "Отмена" (button2)
		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		// Обработчик клавиши Enter в поле ФИО
		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				numericUpDown1.Focus();
				numericUpDown1.Select(0, numericUpDown1.Text.Length);
			}
		}

		// Обработчик клавиши Enter в NumericUpDown
		private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				button1.PerformClick();
			}
		}

		// Обработчик клавиши Esc
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