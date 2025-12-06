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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SportClub
{
	public partial class AdminTrainersEditForm : Form
	{
		private string connectionString = @"Data Source=DESKTOP-PGUAQQC\SQLEXPRESS;Initial Catalog=FitnessClub;Integrated Security=True";
		private int currentTrainerId = 0;

		public AdminTrainersEditForm()
		{
			InitializeComponent();
		}

		private void AdminTrainersEditForm_Load(object sender, EventArgs e)
		{
			// Настраиваем выпадающий список с квалификациями
			InitializeQualificationsComboBox();
		}

		private void InitializeQualificationsComboBox()
		{
			// Добавляем три варианта квалификации
			comboBoxQualification.Items.Add("Стажер");
			comboBoxQualification.Items.Add("Сертифицированный тренер");
			comboBoxQualification.Items.Add("Профессиональный тренер");

			// Устанавливаем выпадающий стиль (только выбор из списка)
			comboBoxQualification.DropDownStyle = ComboBoxStyle.DropDownList;
		}

		private void button1_Click(object sender, EventArgs e) // Найти
		{
			try
			{
				if (!int.TryParse(textBoxId.Text, out int trainerId))
				{
					MessageBox.Show("Введите корректный ID тренера (только цифры)", "Ошибка");
					textBoxId.Focus();
					textBoxId.SelectAll();
					return;
				}

				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					string query = "SELECT ФИО, Дата_рождения, Квалификация FROM Тренеры WHERE ID_Тренера = @ID";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@ID", trainerId);

						using (SqlDataReader reader = command.ExecuteReader())
						{
							if (reader.Read())
							{
								// Тренер найден - заполняем поля данными
								currentTrainerId = trainerId; // Сохраняем ID для обновления
								textBoxFIO.Text = reader["ФИО"].ToString();

								if (reader["Дата_рождения"] != DBNull.Value)
								{
									dateTimePicker1.Value = Convert.ToDateTime(reader["Дата_рождения"]);
								}

								// Устанавливаем квалификацию в ComboBox
								string qualification = reader["Квалификация"].ToString();
								SetQualificationInComboBox(qualification);
							}
							else
							{
								MessageBox.Show($"Тренер с ID {trainerId} не найден в базе данных", "Ошибка");
								ClearFormFields();
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка при поиске тренера: {ex.Message}", "Ошибка");
			}
		}

		private void button2_Click(object sender, EventArgs e) // Сохранить
		{
			try
			{
				if (currentTrainerId == 0)
				{
					MessageBox.Show("Сначала найдите тренера по ID", "Ошибка");
					return;
				}

				if (!ValidateData())
				{
					return;
				}

				string fio = textBoxFIO.Text;
				string qualification = comboBoxQualification.SelectedItem.ToString();
				string birthDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");

				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					// Используем простой формат UPDATE как в примере с клиентами
					string sql = $"UPDATE Тренеры  " +
								$"SET ФИО = '{fio}', Дата_рождения = '{birthDate}', Квалификация = '{qualification}' " +
								$"WHERE ID_Тренера = {currentTrainerId}";

					using (SqlCommand insertCommand = new SqlCommand(sql, connection))
					{
						int rowsAffected = insertCommand.ExecuteNonQuery();

						if (rowsAffected > 0)
						{
							MessageBox.Show($"Данные тренера успешно изменены!");
							this.Close();
						}
						else
						{
							MessageBox.Show("Тренер не найден или данные не изменились", "Ошибка");
						}
					}
				}
			}
			catch (SqlException sqlEx)
			{
				MessageBox.Show($"Ошибка базы данных:\n{sqlEx.Message}", "Ошибка");
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
			}
		}

		private void button3_Click(object sender, EventArgs e) // Отмена
		{
			this.Close();
		}

		// Вспомогательный метод для установки квалификации в ComboBox
		private void SetQualificationInComboBox(string qualification)
		{
			// Ищем квалификацию в списке
			int index = comboBoxQualification.Items.IndexOf(qualification);
			if (index >= 0)
			{
				comboBoxQualification.SelectedIndex = index;
			}
			else
			{
				// Если квалификация не найдена в стандартном списке, добавляем ее
				comboBoxQualification.Items.Add(qualification);
				comboBoxQualification.SelectedItem = qualification;
			}
		}

		// Метод для очистки полей формы
		private void ClearFormFields()
		{
			currentTrainerId = 0;
			textBoxFIO.Text = "";
			comboBoxQualification.SelectedIndex = -1;
		}

		// Метод для валидации данных
		private bool ValidateData()
		{
			// Проверка ФИО
			if (string.IsNullOrWhiteSpace(textBoxFIO.Text))
			{
				MessageBox.Show("Пожалуйста, введите ФИО тренера",
								"Ошибка ввода",
								MessageBoxButtons.OK,
								MessageBoxIcon.Warning);
				textBoxFIO.Focus();
				return false;
			}

			// Проверка квалификации
			if (comboBoxQualification.SelectedItem == null)
			{
				MessageBox.Show("Пожалуйста, выберите квалификацию тренера",
								"Ошибка ввода",
								MessageBoxButtons.OK,
								MessageBoxIcon.Warning);
				comboBoxQualification.Focus();
				return false;
			}

			return true;
		}

		// Обработчик клавиши Esc для закрытия формы
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Escape)
			{
				this.Close();
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		// Обработчик Enter в поле ID для поиска
		private void textBoxId_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				button1.PerformClick(); // Нажимаем кнопку "Найти"
			}
		}

		private void label1_Click(object sender, EventArgs e)
		{
			// Пустой обработчик для клика по метке
		}
	}
}