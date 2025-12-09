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
	public partial class AdminTrainingEditForm : Form
	{
		private string connectionString = @"Data Source=DESKTOP-PGUAQQC\SQLEXPRESS;Initial Catalog=FitnessClub;Integrated Security=True";
		private int trainingId;
		private Dictionary<string, int> trainersDictionary;

		// Новый конструктор с передачей всех данных
		public AdminTrainingEditForm(int trainingId, string trainerFIO, string trainingName, int duration, string hall)
		{
			InitializeComponent();

			// Сохраняем ID
			this.trainingId = trainingId;

			// НАПРЯМУЮ заполняем форму полученными данными
			textBox1.Text = trainerFIO;
			textBox2.Text = trainingName;
			numericUpDown1.Value = duration;

			// Выбираем зал в comboBox
			SelectHallInComboBox(hall);

			// Настраиваем автодополнение
			SetupAutoComplete();

			// Для отладки
			Console.WriteLine($"Форма создана с данными:");
			Console.WriteLine($"ID: {trainingId}");
			Console.WriteLine($"Тренер: {trainerFIO}");
			Console.WriteLine($"Название: {trainingName}");
			Console.WriteLine($"Длительность: {duration}");
			Console.WriteLine($"Зал: {hall}");
		}

		private void AdminTrainingEditForm_Load(object sender, EventArgs e)
		{
			// Загружаем данные для автодополнения
			LoadTrainers();
			LoadTrainingNames();

			// Фокус на поле тренера
			textBox1.Focus();
		}

		private void SetupAutoComplete()
		{
			// Настройка для textBox1 (Тренер)
			textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;

			// Настройка для textBox2 (Название)
			textBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
		}

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

						// Устанавливаем коллекцию для автодополнения
						textBox1.AutoCompleteCustomSource = collection;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка загрузки тренеров: {ex.Message}", "Ошибка");
			}
		}

		private void LoadTrainingNames()
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string query = "SELECT DISTINCT Название FROM Тренировки WHERE ID_Тренировки != @id ORDER BY Название";

					using (SqlCommand cmd = new SqlCommand(query, connection))
					{
						cmd.Parameters.AddWithValue("@id", trainingId);

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

							textBox2.AutoCompleteCustomSource = collection;
						}
					}
				}
			}
			catch (Exception ex)
			{
				// Игнорируем ошибку
			}
		}

		private void SelectHallInComboBox(string hall)
		{
			// Проверяем, что comboBox инициализирован
			if (comboBox1 == null || comboBox1.Items == null)
			{
				MessageBox.Show("comboBox1 не инициализирован", "Ошибка");
				return;
			}

			// Ищем зал в comboBox1
			for (int i = 0; i < comboBox1.Items.Count; i++)
			{
				if (comboBox1.Items[i].ToString().Equals(hall, StringComparison.OrdinalIgnoreCase))
				{
					comboBox1.SelectedIndex = i;
					return;
				}
			}

			// Если зал не найден, добавляем его
			comboBox1.Items.Add(hall);
			comboBox1.SelectedItem = hall;
		}

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

		private void button1_Click(object sender, EventArgs e)
		{
			// Валидация
			if (string.IsNullOrWhiteSpace(textBox1.Text))
			{
				MessageBox.Show("Введите ФИО тренера", "Ошибка");
				textBox1.Focus();
				return;
			}

			if (string.IsNullOrWhiteSpace(textBox2.Text))
			{
				MessageBox.Show("Введите название тренировки", "Ошибка");
				textBox2.Focus();
				return;
			}

			if (comboBox1.SelectedItem == null)
			{
				MessageBox.Show("Выберите зал", "Ошибка");
				comboBox1.Focus();
				return;
			}

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

				// Обновляем тренировку
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					string query = @"
                        UPDATE Тренировки 
                        SET ID_Тренера = @trainerId,
                            Название = @name,
                            Длительность = @duration,
                            Зал = @hall
                        WHERE ID_Тренировки = @id";

					using (SqlCommand cmd = new SqlCommand(query, connection))
					{
						cmd.Parameters.AddWithValue("@id", trainingId);
						cmd.Parameters.AddWithValue("@trainerId", trainerId);
						cmd.Parameters.AddWithValue("@name", textBox2.Text.Trim());
						cmd.Parameters.AddWithValue("@duration", (int)numericUpDown1.Value);
						cmd.Parameters.AddWithValue("@hall", comboBox1.SelectedItem.ToString());

						int rowsAffected = cmd.ExecuteNonQuery();

						if (rowsAffected > 0)
						{
							MessageBox.Show("Тренировка успешно обновлена", "Успешно");
							this.DialogResult = DialogResult.OK;
							this.Close();
						}
						else
						{
							MessageBox.Show("Тренировка не найдена", "Ошибка");
						}
					}
				}
			}
			catch (SqlException ex)
			{
				if (ex.Number == 2627) // Ошибка уникальности
				{
					MessageBox.Show("Тренировка с таким названием уже существует", "Ошибка");
					textBox2.Focus();
					textBox2.SelectAll();
				}
				else
				{
					MessageBox.Show($"Ошибка БД: {ex.Message}", "Ошибка");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		// Остальные методы остаются без изменений...
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
				button1.PerformClick();
				e.Handled = true;
			}
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Escape)
			{
				this.Close();
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void label2_Click(object sender, EventArgs e)
		{
			// Пустая реализация
		}
	}
}