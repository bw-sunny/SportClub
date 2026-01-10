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
	public partial class AdminTrainerCreateForm : Form
	{
		private string connectionString = @"Data Source=DESKTOP-PGUAQQC\SQLEXPRESS;Initial Catalog=FitnessClub;Integrated Security=True";

		public AdminTrainerCreateForm()
		{
			InitializeComponent();
		}

		private void AdminTrainerCreateForm_Load(object sender, EventArgs e)
		{
			// Настраиваем выпадающий список с квалификациями при загрузке формы
			InitializeQualificationsComboBox();

			// Настраиваем DateTimePicker
			dateTimePicker1.Format = DateTimePickerFormat.Short;

			// Устанавливаем фокус на поле ФИО
			textBox1.Focus();
		}

		private void InitializeQualificationsComboBox()
		{
			// Добавляем три варианта квалификации
			comboBox1.Items.Add("Стажер");
			comboBox1.Items.Add("Сертифицированный тренер");
			comboBox1.Items.Add("Профессиональный тренер");

			// Устанавливаем выпадающий стиль (только выбор из списка)
			comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

			// Выбираем первый элемент по умолчанию
			if (comboBox1.Items.Count > 0)
			{
				comboBox1.SelectedIndex = 0;
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			// Обработчик изменения текста в поле ФИО
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Обработчик изменения выбора в комбобоксе
		}

		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			// Обработчик изменения даты
		}

		private void button2_Click(object sender, EventArgs e) // Кнопка "Отмена"
		{
			this.Close();
		}

		private void button1_Click(object sender, EventArgs e) // Кнопка "Сохранить"
		{
			try
			{
				// 1. Проверяем валидацию данных
				if (!ValidateData())
				{
					return;
				}

				// 2. Получаем данные из полей
				string fio = textBox1.Text.Trim();
				string qualification = comboBox1.SelectedItem.ToString();
				string birthDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");

				// 3. Находим максимальный ID
				int newId = 1;

				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					// Находим максимальный ID
					string maxIdQuery = "SELECT ISNULL(MAX(ID_Тренера), 0) FROM Тренеры";
					using (SqlCommand maxIdCommand = new SqlCommand(maxIdQuery, connection))
					{
						object result = maxIdCommand.ExecuteScalar();
						int maxId = Convert.ToInt32(result);
						newId = maxId + 1;
					}

					// 4. SQL команда для добавления - упрощенный формат как в примере
					string sql = $"INSERT INTO Тренеры VALUES ({newId}, '{fio}', '{birthDate}', '{qualification}')";

					// 5. Выполняем команду добавления
					using (SqlCommand insertCommand = new SqlCommand(sql, connection))
					{
						insertCommand.ExecuteNonQuery();
					}
				}

				// 6. Сообщение об успехе с указанием нового ID
				MessageBox.Show($"Тренер добавлен! ID: {newId}",
								"Успешно",
								MessageBoxButtons.OK,
								MessageBoxIcon.Information);

				// 7. Закрываем форму
				this.Close();
			}
			catch (SqlException sqlEx)
			{
				// Обработка ошибок SQL
				MessageBox.Show($"Ошибка базы данных:\n{sqlEx.Message}",
								"Ошибка",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка: {ex.Message}",
								"Ошибка",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error);
			}
		}

		// Метод для валидации данных
		private bool ValidateData()
		{
			// Проверка ФИО
			if (string.IsNullOrWhiteSpace(textBox1.Text))
			{
				MessageBox.Show("Пожалуйста, введите ФИО тренера",
								"Ошибка ввода",
								MessageBoxButtons.OK,
								MessageBoxIcon.Warning);
				textBox1.Focus();
				return false;
			}

			// Проверка квалификации
			if (comboBox1.SelectedItem == null)
			{
				MessageBox.Show("Пожалуйста, выберите квалификацию тренера",
								"Ошибка ввода",
								MessageBoxButtons.OK,
								MessageBoxIcon.Warning);
				comboBox1.Focus();
				return false;
			}

			return true;
		}

		// Обработчик клавиши Esc для закрытия формы (оставляем, это удобно)
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Escape)
			{
				this.Close(); // Просто закрываем форму
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}
	}
}