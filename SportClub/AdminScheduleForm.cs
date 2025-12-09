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
	public partial class AdminScheduleForm : Form
	{
		private SqlConnection connection;
		private DataView scheduleDataView;

		public AdminScheduleForm()
		{
			InitializeComponent();
			connection = new SqlConnection(@"Data Source=DESKTOP-PGUAQQC\SQLEXPRESS;Initial Catalog=FitnessClub;Integrated Security=True");
		}

		private void button1_Click(object sender, EventArgs e) // кнопка применить фильтр
		{
			ApplyFilters();
		}

		private void ApplyFilters()
		{
			if (scheduleDataView != null)
			{
				string filter = "";

				// Фильтр по дате
				string selectedDate = dateTimePicker1.Value.ToString("dd.MM.yyyy");
				filter = $"Дата = '{selectedDate}'";

				// Фильтр по тренеру (если введен)
				if (!string.IsNullOrWhiteSpace(textBox1.Text))
				{
					filter += $" AND Тренер LIKE '%{textBox1.Text}%'";
				}

				scheduleDataView.RowFilter = filter;
			}
		}

		private void button2_Click(object sender, EventArgs e) // кнопка сбросить фильтр
		{
			textBox1.Text = "";
			dateTimePicker1.Value = DateTime.Today;

			if (scheduleDataView != null)
			{
				scheduleDataView.RowFilter = "";
			}
		}

		private void button3_Click(object sender, EventArgs e) // кнопка добавить расписание
		{
			// Форма создания расписания
			using (AddScheduleForm addForm = new AddScheduleForm())
			{
				if (addForm.ShowDialog() == DialogResult.OK)
				{
					LoadScheduleData();
					MessageBox.Show("Новое занятие добавлено в расписание", "Успех",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void button4_Click(object sender, EventArgs e) // редактировать расписание
		{
			//if (dataGridView1.SelectedRows.Count == 0)
			//{
			//	MessageBox.Show("Выберите занятие для редактирования", "Информация",
			//		MessageBoxButtons.OK, MessageBoxIcon.Information);
			//	return;
			//}

			//DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

			//// Получаем ID из столбца iDРасписанияDataGridViewTextBoxColumn
			//int scheduleId = Convert.ToInt32(selectedRow.Cells["iDРасписанияDataGridViewTextBoxColumn"].Value);

			//// Форма редактирования расписания
			//using (EditScheduleForm editForm = new EditScheduleForm(scheduleId))
			//{
			//	if (editForm.ShowDialog() == DialogResult.OK)
			//	{
			//		LoadScheduleData();
			//	}
			//}
		}

		private void button6_Click(object sender, EventArgs e) // кнопка записать клиента здесь не нужна, удалено
		{
			// Можно оставить пустым или удалить этот метод
		}

		private void button7_Click(object sender, EventArgs e) // кнопка назад
		{
			this.Close();
		}

		private void button8_Click(object sender, EventArgs e) // обновить таблицу
		{
			LoadScheduleData();
			MessageBox.Show("Расписание обновлено", "Информация",
				MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void button5_Click(object sender, EventArgs e) // кнопка удалить
		{
			if (dataGridView1.SelectedRows.Count == 0)
			{
				MessageBox.Show("Выберите занятие для удаления", "Информация",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

			// Получаем ID из столбца iDРасписанияDataGridViewTextBoxColumn
			int scheduleId = Convert.ToInt32(selectedRow.Cells["iDРасписанияDataGridViewTextBoxColumn"].Value);

			// Получаем данные из столбцов с вашими названиями
			string trainingName = selectedRow.Cells["тренировкаDataGridViewTextBoxColumn"].Value.ToString();
			string dateStr = selectedRow.Cells["датаDataGridViewTextBoxColumn"].Value.ToString();
			string timeStr = selectedRow.Cells["времяDataGridViewTextBoxColumn"].Value.ToString();
			string dateTime = $"{dateStr} {timeStr}";

			DialogResult result = MessageBox.Show(
				$"Удалить занятие из расписания?\n\n" +
				$"Тренировка: {trainingName}\n" +
				$"Дата и время: {dateTime}",
				"Подтверждение удаления",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				DeleteSchedule(scheduleId);
			}
		}

		private void DeleteSchedule(int scheduleId)
		{
			try
			{
				string query = "DELETE FROM Расписание_тренировок WHERE ID_Раписания = @ID";

				using (SqlCommand cmd = new SqlCommand(query, connection))
				{
					cmd.Parameters.AddWithValue("@ID", scheduleId);

					connection.Open();
					int rowsAffected = cmd.ExecuteNonQuery();
					connection.Close();

					if (rowsAffected > 0)
					{
						MessageBox.Show("Занятие удалено из расписания", "Успех",
							MessageBoxButtons.OK, MessageBoxIcon.Information);
						LoadScheduleData();
					}
				}
			}
			catch (SqlException ex)
			{
				if (ex.Number == 547) // Ошибка внешнего ключа
				{
					MessageBox.Show("Нельзя удалить занятие!\nНа это занятие уже есть записи клиентов.",
						"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					MessageBox.Show($"Ошибка базы данных: {ex.Message}", "Ошибка",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void AdminScheduleForm_Load(object sender, EventArgs e)
		{
			// TODO: данная строка кода позволяет загрузить данные в таблицу "fitnessClubDataSet5.Вид_Расписание_Кратко". При необходимости она может быть перемещена или удалена.
			this.вид_Расписание_КраткоTableAdapter.Fill(this.fitnessClubDataSet5.Вид_Расписание_Кратко);

			// Настраиваем DataGridView
			SetupDataGridView();

			// Получаем DataView для фильтрации
			scheduleDataView = this.fitnessClubDataSet5.Вид_Расписание_Кратко.DefaultView;

			// Настраиваем автодополнение для TextBox
			SetupAutoComplete();

			// Устанавливаем сегодняшнюю дату
			dateTimePicker1.Value = DateTime.Today;

			// Настраиваем ширину столбцов
			AdjustColumnWidths();
		}

		private void SetupDataGridView()
		{
			if (dataGridView1.Columns.Count > 0)
			{
				// Настраиваем порядок столбцов (если нужно)
				// Столбцы уже связаны через DataSource, порядок определен там

				// Настройка внешнего вида
				dataGridView1.RowHeadersVisible = false;
				dataGridView1.AllowUserToAddRows = false;
				dataGridView1.AllowUserToDeleteRows = false;
				dataGridView1.ReadOnly = true;
				dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

				// Подключаем обработчик двойного клика
				dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;

				// Подключаем обработчик нажатия клавиш
				dataGridView1.KeyDown += DataGridView1_KeyDown;
			}
		}

		private void AdjustColumnWidths()
		{
			if (dataGridView1.Columns.Count > 0)
			{
				// Настраиваем ширину столбцов под ваши названия
				if (dataGridView1.Columns.Contains("деньDataGridViewTextBoxColumn"))
					dataGridView1.Columns["деньDataGridViewTextBoxColumn"].Width = 100;

				if (dataGridView1.Columns.Contains("датаDataGridViewTextBoxColumn"))
					dataGridView1.Columns["датаDataGridViewTextBoxColumn"].Width = 80;

				if (dataGridView1.Columns.Contains("времяDataGridViewTextBoxColumn"))
					dataGridView1.Columns["времяDataGridViewTextBoxColumn"].Width = 70;

				if (dataGridView1.Columns.Contains("тренировкаDataGridViewTextBoxColumn"))
					dataGridView1.Columns["тренировкаDataGridViewTextBoxColumn"].Width = 150;

				if (dataGridView1.Columns.Contains("тренерDataGridViewTextBoxColumn"))
					dataGridView1.Columns["тренерDataGridViewTextBoxColumn"].Width = 120;

				if (dataGridView1.Columns.Contains("залDataGridViewTextBoxColumn"))
					dataGridView1.Columns["залDataGridViewTextBoxColumn"].Width = 100;

				// Скрываем ID если нужно (по желанию)
				if (dataGridView1.Columns.Contains("iDРасписанияDataGridViewTextBoxColumn"))
					dataGridView1.Columns["iDРасписанияDataGridViewTextBoxColumn"].Visible = false;
			}
		}

		private void SetupAutoComplete()
		{
			try
			{
				AutoCompleteStringCollection trainerNames = new AutoCompleteStringCollection();

				string query = "SELECT DISTINCT ФИО FROM Тренеры ORDER BY ФИО";
				using (SqlCommand cmd = new SqlCommand(query, connection))
				{
					connection.Open();
					SqlDataReader reader = cmd.ExecuteReader();

					while (reader.Read())
					{
						trainerNames.Add(reader["ФИО"].ToString());
					}

					reader.Close();
					connection.Close();
				}

				textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
				textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
				textBox1.AutoCompleteCustomSource = trainerNames;
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка при загрузке тренеров: {ex.Message}",
					"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void LoadScheduleData()
		{
			try
			{
				this.вид_Расписание_КраткоTableAdapter.Fill(this.fitnessClubDataSet5.Вид_Расписание_Кратко);
				scheduleDataView = this.fitnessClubDataSet5.Вид_Расписание_Кратко.DefaultView;

				// Обновляем DataGridView
				dataGridView1.Refresh();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка при обновлении расписания: {ex.Message}",
					"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				// При двойном клике вызываем редактирование
				button4_Click(sender, e);
			}
		}

		private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
		{
			// Удаление по клавише Delete
			if (e.KeyCode == Keys.Delete && dataGridView1.SelectedRows.Count > 0)
			{
				button5_Click(sender, e);
				e.Handled = true; // Предотвращаем стандартную обработку
			}
		}

		// Дополнительные обработчики для удобства

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			// При нажатии Enter применяем фильтр
			if (e.KeyChar == (char)Keys.Enter)
			{
				ApplyFilters();
				e.Handled = true;
			}
		}

		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			// Автоматическое применение фильтра при изменении даты
			// Раскомментировать, если нужно автоматическое применение фильтра:
			// ApplyFilters();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			// Автоматическое применение фильтра при вводе текста
			// Раскомментировать, если нужно автоматическое применение фильтра:
			// ApplyFilters();
		}

		// Метод для форматирования строк (раскраска по дню недели)
		private void DataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
		{
			// Это можно добавить как обработчик события RowPrePaint
			// Показываю как вариант
		}

		// Альтернативный способ форматирования
		private void FormatDataGridViewRows()
		{
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				if (row.Cells["деньDataGridViewTextBoxColumn"].Value != null)
				{
					string day = row.Cells["деньDataGridViewTextBoxColumn"].Value.ToString();

					if (day == "Суббота" || day == "Воскресенье")
					{
						row.DefaultCellStyle.BackColor = Color.LavenderBlush;
					}
				}
			}
		}
	}
}