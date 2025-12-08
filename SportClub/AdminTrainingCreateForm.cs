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
	public partial class AdminTrainingCreateForm : Form
	{
		private string connectionString = @"Data Source=DESKTOP-PGUAQQC\SQLEXPRESS;Initial Catalog=FitnessClub;Integrated Security=True";
		private Dictionary<string, int> trainersDictionary; // Для сопоставления ФИО с ID

		public AdminTrainingCreateForm()
		{
			InitializeComponent();
		}

		private void AdminTrainingCreateForm_Load(object sender, EventArgs e)
		{
			// Загружаем данные для автодополнения
			LoadTrainers();
			LoadTrainingNames();

			// Фокус на поле тренера
			textBox1.Focus();
		}

		// Загрузка тренеров для автодополнения
		private void LoadTrainers()
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string query = "SELECT ID_Тренера, ФИО FROM Тренеры ORDER BY ФИО";

					using (SqlCommand cmd = new SqlCommand(query, connection))
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
						trainersDictionary = new Dictionary<string, int>();

						while (reader.Read())
						{
							string fio = reader["ФИО"].ToString();
							int id = Convert.ToInt32(reader["ID_Тренера"]);

							if (!string.IsNullOrWhiteSpace(fio))
							{
								collection.Add(fio.Trim());
								trainersDictionary[fio.Trim()] = id;
							}
						}

						// Настройка автодополнения для поля Тренер (textBox1)
						textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
						textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
						textBox1.AutoCompleteCustomSource = collection;

						// Проверка загрузки (для отладки)
						if (collection.Count == 0)
						{
							MessageBox.Show("В базе нет тренеров. Сначала добавьте тренеров.",
										  "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка загрузки тренеров: {ex.Message}", "Ошибка",
							  MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// Загрузка существующих названий тренировок для автодополнения
		private void LoadTrainingNames()
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string query = "SELECT DISTINCT Название FROM Тренировки ORDER BY Название";

					using (SqlCommand cmd = new SqlCommand(query, connection))
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

						while (reader.Read())
						{
							string name = reader["Название"].ToString();
							if (!string.IsNullOrWhiteSpace(name))
							{
								collection.Add(name.Trim());
							}
						}

						// Настройка автодополнения для поля Название (textBox2)
						textBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
						textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
						textBox2.AutoCompleteCustomSource = collection;
					}
				}
			}
			catch (Exception ex)
			{
				// Молча игнорируем, если нет тренировок или ошибка
				// Можно добавить логирование: Console.WriteLine($"Не удалось загрузить названия тренировок: {ex.Message}");
			}
		}

		// Получение ID тренера по ФИО
		private int GetTrainerIdByName(string trainerFIO)
		{
			if (trainersDictionary != null && trainersDictionary.ContainsKey(trainerFIO.Trim()))
			{
				return trainersDictionary[trainerFIO.Trim()];
			}

			// Если не нашли в кэше, ищем в базе
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string query = "SELECT ID_Тренера FROM Тренеры WHERE ФИО = @fio";

					using (SqlCommand cmd = new SqlCommand(query, connection))
					{
						cmd.Parameters.AddWithValue("@fio", trainerFIO.Trim());
						object result = cmd.ExecuteScalar();

						if (result != null && result != DBNull.Value)
						{
							return Convert.ToInt32(result);
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка поиска тренера: {ex.Message}", "Ошибка");
			}

			return -1; // Тренер не найден
		}

		// Кнопка подтверждения создания (button1)
		private void button1_Click(object sender, EventArgs e)
		{
			// Валидация ввода
			if (!ValidateInput())
				return;

			try
			{
				// Получаем ID тренера по ФИО
				string trainerFIO = textBox1.Text.Trim();
				int trainerId = GetTrainerIdByName(trainerFIO);

				if (trainerId == -1)
				{
					MessageBox.Show($"Тренер '{trainerFIO}' не найден в базе данных", "Ошибка");
					textBox1.Focus();
					textBox1.SelectAll();
					return;
				}

				// Получаем остальные данные
				string trainingName = textBox2.Text.Trim();
				int duration = (int)numericUpDown1.Value;
				string hall = comboBox1.SelectedItem.ToString(); // Предполагаем, что comboBox1 для залов

				// Получаем следующий ID тренировки
				int nextTrainingId = GetNextTrainingId();

				// Добавляем тренировку в БД
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					string query = @"
                        INSERT INTO Тренировки (ID_Тренировки, ID_Тренера, Название, Длительность, Зал)
                        VALUES (@id, @trainerId, @name, @duration, @hall)";

					using (SqlCommand cmd = new SqlCommand(query, connection))
					{
						cmd.Parameters.AddWithValue("@id", nextTrainingId);
						cmd.Parameters.AddWithValue("@trainerId", trainerId);
						cmd.Parameters.AddWithValue("@name", trainingName);
						cmd.Parameters.AddWithValue("@duration", duration);
						cmd.Parameters.AddWithValue("@hall", hall);

						int rowsAffected = cmd.ExecuteNonQuery();

						if (rowsAffected > 0)
						{
							MessageBox.Show($"Тренировка успешно создана!\n\n" +
										  $"ID тренировки: {nextTrainingId}\n" +
										  $"Название: {trainingName}\n" +
										  $"Тренер: {trainerFIO}\n" +
										  $"Длительность: {duration} мин\n" +
										  $"Зал: {hall}",
										  "Успешно",
										  MessageBoxButtons.OK,
										  MessageBoxIcon.Information);

							this.DialogResult = DialogResult.OK;
							this.Close();
						}
					}
				}
			}
			catch (SqlException sqlEx)
			{
				if (sqlEx.Number == 2627) // Ошибка нарушения уникальности
				{
					MessageBox.Show("Тренировка с таким названием уже существует", "Ошибка");
					textBox2.Focus();
					textBox2.SelectAll();
				}
				else
				{
					MessageBox.Show($"Ошибка базы данных: {sqlEx.Message}\nНомер ошибки: {sqlEx.Number}", "Ошибка");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
			}
		}

		// Получение следующего ID тренировки
		private int GetNextTrainingId()
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string query = "SELECT ISNULL(MAX(ID_Тренировки), 0) + 1 FROM Тренировки";

					using (SqlCommand cmd = new SqlCommand(query, connection))
					{
						return Convert.ToInt32(cmd.ExecuteScalar());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка получения следующего ID: {ex.Message}", "Ошибка");
				return 1; // Возвращаем 1 в случае ошибки
			}
		}

		// Валидация ввода
		private bool ValidateInput()
		{
			// Проверка тренера
			if (string.IsNullOrWhiteSpace(textBox1.Text))
			{
				MessageBox.Show("Введите ФИО тренера", "Ошибка");
				textBox1.Focus();
				return false;
			}

			// Проверка названия тренировки
			if (string.IsNullOrWhiteSpace(textBox2.Text))
			{
				MessageBox.Show("Введите название тренировки", "Ошибка");
				textBox2.Focus();
				return false;
			}

			// Проверка длительности
			if (numericUpDown1.Value < 15 || numericUpDown1.Value > 180)
			{
				MessageBox.Show("Длительность должна быть от 15 до 180 минут", "Ошибка");
				numericUpDown1.Focus();
				return false;
			}

			// Проверка зала
			if (comboBox1.SelectedItem == null)
			{
				MessageBox.Show("Выберите зал", "Ошибка");
				comboBox1.Focus();
				return false;
			}

			return true;
		}

		// Кнопка отмены (button2)
		private void button2_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		// Обработка клавиши Enter в полях ввода
		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				textBox2.Focus();
				textBox2.SelectAll();
				e.Handled = true;
			}
		}

		private void textBox2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				numericUpDown1.Focus();
				e.Handled = true;
			}
		}

		private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				comboBox1.Focus();
				e.Handled = true;
			}
		}

		private void comboBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				button1.PerformClick(); // Нажимаем кнопку Создать
				e.Handled = true;
			}
		}

		// Обработка клавиши Esc
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Escape)
			{
				this.Close();
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		// Обработчик изменения текста в поле тренера
		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			// Можно добавить дополнительную валидацию
		}

		// Обработчик изменения текста в поле названия
		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			// Можно добавить дополнительную валидацию
		}

		// Метод для обновления списка тренеров при повторном открытии формы
		public void RefreshTrainersList()
		{
			LoadTrainers();
		}

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}