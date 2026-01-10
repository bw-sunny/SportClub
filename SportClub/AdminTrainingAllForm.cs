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
	public partial class AdminTrainingAllForm : Form
	{
		public AdminTrainingAllForm()
		{
			InitializeComponent();
		}

		private void AdminTrainingAllForm_Load(object sender, EventArgs e)
		{
			// Загружаем данные при загрузке формы
			LoadTrainingData();
		}

		// МЕТОД ДЛЯ ЗАГРУЗКИ ДАННЫХ
		private void LoadTrainingData()
		{
			try
			{
				// Обновляем данные через TableAdapter (как в других формах)
				this.вид_Тренировки_С_ТренерамиTableAdapter.Fill(this.fitnessClubDataSet3.Вид_Тренировки_С_Тренерами);

				// Настраиваем DataGridView
				ConfigureDataGridView();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка загрузки данных: {ex.Message}\n\n" +
							  "Возможные причины:\n" +
							  "1. Представление 'Вид_Тренировки_С_Тренерами' не существует в БД\n" +
							  "2. Нет данных в таблицах Тренировки или Тренеры\n" +
							  "3. Проблемы с подключением к БД",
							  "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// НАСТРОЙКА DATAGRIDVIEW
		private void ConfigureDataGridView()
		{
			if (dataGridView1.Columns.Count > 0)
			{
				// Настраиваем ширину столбцов
				dataGridView1.Columns["iDТренировкиDataGridViewTextBoxColumn"].Width = 50;
				dataGridView1.Columns["названиетренировкиDataGridViewTextBoxColumn"].Width = 150;
				dataGridView1.Columns["длительностьDataGridViewTextBoxColumn"].Width = 80;
				dataGridView1.Columns["залDataGridViewTextBoxColumn"].Width = 120;
				dataGridView1.Columns["фИОтренераDataGridViewTextBoxColumn"].Width = 150;

				// Устанавливаем русские заголовки
				dataGridView1.Columns["iDТренировкиDataGridViewTextBoxColumn"].HeaderText = "ID";
				dataGridView1.Columns["названиетренировкиDataGridViewTextBoxColumn"].HeaderText = "Название тренировки";
				dataGridView1.Columns["длительностьDataGridViewTextBoxColumn"].HeaderText = "Длительность (мин)";
				dataGridView1.Columns["залDataGridViewTextBoxColumn"].HeaderText = "Зал";
				dataGridView1.Columns["фИОтренераDataGridViewTextBoxColumn"].HeaderText = "Тренер";

				// Отключаем добавление новых строк
				dataGridView1.AllowUserToAddRows = false;

				// Включаем сортировку
				foreach (DataGridViewColumn column in dataGridView1.Columns)
				{
					column.SortMode = DataGridViewColumnSortMode.Automatic;
				}
			}
		}

		// ========== КНОПКИ ==========

		private void button1_Click(object sender, EventArgs e) // создать
		{
			AdminTrainingCreateForm createForm = new AdminTrainingCreateForm();
			if (createForm.ShowDialog() == DialogResult.OK)
			{
				// Обновляем данные после создания
				LoadTrainingData();
			}
		}

		private void button2_Click(object sender, EventArgs e) // редактировать
		{
			if (dataGridView1.SelectedRows.Count > 0)
			{
				DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

				try
				{
					// Получаем данные из выбранной строки
					int trainingId = Convert.ToInt32(selectedRow.Cells["iDТренировкиDataGridViewTextBoxColumn"].Value);
					string trainerFIO = selectedRow.Cells["фИОтренераDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
					string trainingName = selectedRow.Cells["названиетренировкиDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
					int duration = Convert.ToInt32(selectedRow.Cells["длительностьDataGridViewTextBoxColumn"].Value);
					string hall = selectedRow.Cells["залDataGridViewTextBoxColumn"].Value?.ToString() ?? "";

					// Открываем форму редактирования
					AdminTrainingEditForm editForm = new AdminTrainingEditForm(
						trainingId, trainerFIO, trainingName, duration, hall);

					if (editForm.ShowDialog() == DialogResult.OK)
					{
						// Обновляем данные после редактирования
						LoadTrainingData();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
				}
			}
			else
			{
				MessageBox.Show("Выберите тренировку для редактирования", "Внимание");
			}
		}

		private void button3_Click(object sender, EventArgs e) // удалить
		{
			if (dataGridView1.SelectedRows.Count > 0)
			{
				DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

				try
				{
					int trainingId = Convert.ToInt32(selectedRow.Cells["iDТренировкиDataGridViewTextBoxColumn"].Value);
					string trainingName = selectedRow.Cells["названиетренировкиDataGridViewTextBoxColumn"].Value?.ToString() ?? "Неизвестно";
					string trainerName = selectedRow.Cells["фИОтренераDataGridViewTextBoxColumn"].Value?.ToString() ?? "Неизвестно";

					DialogResult result = MessageBox.Show(
						$"Удалить тренировку?\n\n" +
						$"ID: {trainingId}\n" +
						$"Название: {trainingName}\n" +
						$"Тренер: {trainerName}\n\n" +
						$"Это действие нельзя отменить!",
						"Подтверждение удаления",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Warning,
						MessageBoxDefaultButton.Button2); // По умолчанию "Нет"

					if (result == DialogResult.Yes)
					{
						// Строка подключения
						string connectionString = @"Data Source=DESKTOP-PGUAQQC\SQLEXPRESS;Initial Catalog=FitnessClub;Integrated Security=True";

						using (SqlConnection connection = new SqlConnection(connectionString))
						{
							connection.Open();
							string query = "DELETE FROM Тренировки WHERE ID_Тренировки = @id";

							using (SqlCommand cmd = new SqlCommand(query, connection))
							{
								cmd.Parameters.AddWithValue("@id", trainingId);
								int rowsAffected = cmd.ExecuteNonQuery();

								if (rowsAffected > 0)
								{
									MessageBox.Show("Тренировка успешно удалена", "Успешно");

									// Обновляем данные после удаления
									LoadTrainingData();
								}
								else
								{
									MessageBox.Show("Тренировка не найдена", "Ошибка");
								}
							}
						}
					}
				}
				catch (SqlException ex) when (ex.Number == 547)
				{
					MessageBox.Show("Нельзя удалить тренировку, так как она используется в расписании занятий",
								   "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
				}
			}
			else
			{
				MessageBox.Show("Выберите тренировку для удаления", "Внимание");
			}
		}

		private void button6_Click(object sender, EventArgs e) // обновить
		{
			try
			{
				this.вид_Тренировки_С_ТренерамиTableAdapter.Fill(this.fitnessClubDataSet3.Вид_Тренировки_С_Тренерами);
				dataGridView1.ClearSelection();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка обновления: {ex.Message}", "Ошибка");
			}
		}

		private void button4_Click(object sender, EventArgs e) // закрыть
		{
			this.Close();
		}


		// ДОПОЛНИТЕЛЬНЫЙ МЕТОД ДЛЯ ТЕСТА - загрузка напрямую из таблиц
		private void buttonTestLoad_Click(object sender, EventArgs e)
		{
			try
			{
				string connectionString = @"Data Source=DESKTOP-PGUAQQC\SQLEXPRESS;Initial Catalog=FitnessClub;Integrated Security=True";

				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					// Прямой запрос к таблицам
					string query = @"
                        SELECT 
                            t.ID_Тренировки AS [ID],
                            t.Название AS [Название тренировки],
                            t.Длительность AS [Длительность (мин)],
                            t.Зал AS [Зал],
                            tr.ФИО AS [Тренер]
                        FROM Тренировки t
                        INNER JOIN Тренеры tr ON t.ID_Тренера = tr.ID_Тренера
                        ORDER BY t.ID_Тренировки";

					SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
					DataTable dataTable = new DataTable();
					adapter.Fill(dataTable);

					// Показываем результат
					MessageBox.Show($"Прямой запрос вернул {dataTable.Rows.Count} записей",
								  "Результат теста", MessageBoxButtons.OK, MessageBoxIcon.Information);

					// Если есть данные, показываем их
					if (dataTable.Rows.Count > 0)
					{
						string sample = "Пример данных:\n";
						for (int i = 0; i < Math.Min(3, dataTable.Rows.Count); i++)
						{
							sample += $"{dataTable.Rows[i]["ID"]}: {dataTable.Rows[i]["Название тренировки"]} ({dataTable.Rows[i]["Тренер"]})\n";
						}
						MessageBox.Show(sample, "Пример данных");
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка теста: {ex.Message}", "Ошибка");
			}
		}
	}
}