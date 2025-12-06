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
	public partial class AdminTrainerForm : Form
	{
		private string connectionString = @"Data Source=DESKTOP-PGUAQQC\SQLEXPRESS;Initial Catalog=FitnessClub;Integrated Security=True";

		public AdminTrainerForm()
		{
			InitializeComponent();
		}

		private void AdminTrainerForm_Load(object sender, EventArgs e)
		{
			// Загружаем всех тренеров
			LoadAllTrainers();

			// Устанавливаем фильтр "Все тренеры" по умолчанию
			radioButton1.Checked = true;

			// Обновляем статус с количеством тренеров
			UpdateTrainerCount();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			AdminForm adminForm = new AdminForm();
			adminForm.Show();
			this.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			AdminTrainerCreateForm createForm = new AdminTrainerCreateForm();
			createForm.ShowDialog();
			// Обновляем данные после закрытия формы создания
			RefreshTrainersList();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			AdminTrainersEditForm editForm = new AdminTrainersEditForm();
			editForm.ShowDialog();
			// Обновляем данные после закрытия формы редактирования
			RefreshTrainersList();
		}

		private void button2_Click(object sender, EventArgs e) // удаление
		{
			// 1. Проверяем, выбрана ли строка в DataGridView
			if (dataGridView1.SelectedRows.Count == 0)
			{
				MessageBox.Show("Пожалуйста, выберите тренера для удаления",
					"Не выбран тренер",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return;
			}

			// 2. Получаем данные выбранного тренера
			DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

			int trainerId = 0;
			string trainerFIO = "";
			string trainerQualification = "";
			string trainerBirthDate = "";

			try
			{
				// Пробуем разные варианты имен столбцов
				if (selectedRow.Cells["IDТренераDataGridViewTextBoxColumn"] != null && selectedRow.Cells["IDТренераDataGridViewTextBoxColumn"].Value != null)
				{
					trainerId = Convert.ToInt32(selectedRow.Cells["IDТренераDataGridViewTextBoxColumn"].Value);
				}
				else if (selectedRow.Cells["ID_Тренера"] != null && selectedRow.Cells["ID_Тренера"].Value != null)
				{
					trainerId = Convert.ToInt32(selectedRow.Cells["ID_Тренера"].Value);
				}
				else if (selectedRow.Cells["Column1"] != null && selectedRow.Cells["Column1"].Value != null)
				{
					trainerId = Convert.ToInt32(selectedRow.Cells["Column1"].Value);
				}
				else
				{
					// Используем первый столбец
					trainerId = Convert.ToInt32(selectedRow.Cells[0].Value);
				}

				// Аналогично для остальных полей
				trainerFIO = GetCellValue(selectedRow, "ФИОDataGridViewTextBoxColumn", "ФИО", "Column2", 1)?.ToString() ?? "";
				trainerQualification = GetCellValue(selectedRow, "КвалификацияDataGridViewTextBoxColumn", "Квалификация", "Column4", 3)?.ToString() ?? "";

				object birthDateValue = GetCellValue(selectedRow, "ДатаРожденияDataGridViewTextBoxColumn", "Дата_рождения", "Column3", 2);
				if (birthDateValue != null && birthDateValue != DBNull.Value)
				{
					trainerBirthDate = Convert.ToDateTime(birthDateValue).ToString("dd.MM.yyyy");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка получения данных тренера:\n{ex.Message}",
					"Ошибка",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				DebugColumnNames(); // Показываем отладку
				return;
			}

			// 3. Формируем сообщение с информацией о тренере
			string message = $"Вы действительно хотите удалить тренера?\n";

			// 4. Показываем окно подтверждения
			DialogResult result = MessageBox.Show(
				message,
				"Подтверждение удаления",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Warning,
				MessageBoxDefaultButton.Button2);

			// 5. Если пользователь подтвердил удаление
			if (result == DialogResult.Yes)
			{
				// 6. Выполняем удаление
				try
				{
					using (SqlConnection connection = new SqlConnection(connectionString))
					{
						connection.Open();

						// SQL-запрос для удаления тренера
						string deleteQuery = "DELETE FROM Тренеры WHERE ID_Тренера = @id";

						using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
						{
							cmd.Parameters.AddWithValue("@id", trainerId);
							int rowsAffected = cmd.ExecuteNonQuery();

							if (rowsAffected > 0)
							{
								// 7. Успешное удаление
								MessageBox.Show($"Тренер '{trainerFIO}' успешно удален",
									"Успешно",
									MessageBoxButtons.OK,
									MessageBoxIcon.Information);

								// 8. Обновляем таблицу
								RefreshTrainersList();
							}
							else
							{
								MessageBox.Show("Тренер не найден в базе данных",
									"Ошибка",
									MessageBoxButtons.OK,
									MessageBoxIcon.Error);
							}
						}
					}
				}
				catch (SqlException ex)
				{
					// Обработка ошибок SQL
					if (ex.Number == 547) // Ошибка внешнего ключа
					{
						MessageBox.Show(
							"Невозможно удалить тренера! Есть связанные записи (тренировки, расписание).\n" +
							"Удалите сначала все связанные записи.",
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

		private void radioButton1_CheckedChanged(object sender, EventArgs e) // Все тренеры
		{
			if (radioButton1.Checked)
			{
				LoadAllTrainers();
			}
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e) // Стажер
		{
			if (radioButton2.Checked)
			{
				LoadTrainersByQualification("Стажер");
			}
		}

		private void radioButton3_CheckedChanged(object sender, EventArgs e) // Сертифицированные
		{
			if (radioButton3.Checked)
			{
				LoadTrainersByQualification("Сертифицированный тренер");
			}
		}

		private void radioButton4_CheckedChanged(object sender, EventArgs e) // профессиональные
		{
			if (radioButton4.Checked)
			{
				LoadTrainersByQualification("Профессиональный тренер");
			}
		}

		// Метод для загрузки всех тренеров
		private void LoadAllTrainers()
		{
			try
			{
				// Очищаем текущие данные
				fitnessClubDataSet1.Тренеры.Clear();

				// Загружаем данные через TableAdapter
				this.тренерыTableAdapter.Fill(this.fitnessClubDataSet1.Тренеры);

				// Обновляем заголовки
				UpdateDataGridViewColumns();

				// Обновляем количество тренеров
				UpdateTrainerCount();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка загрузки тренеров:\n{ex.Message}",
					"Ошибка",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		// Метод для загрузки тренеров по квалификации через функцию БД
		private void LoadTrainersByQualification(string qualification)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					// Используем функцию БД для фильтрации
					string query = @"SELECT * FROM dbo.[Получить тренера по квалификации](@qualification)";

					using (SqlCommand cmd = new SqlCommand(query, connection))
					{
						cmd.Parameters.AddWithValue("@qualification", qualification);

						// Создаем временный DataTable
						DataTable tempTable = new DataTable();

						using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
						{
							adapter.Fill(tempTable);
						}

						// Очищаем основной DataSet
						fitnessClubDataSet1.Тренеры.Clear();

						// Если в DataTable есть данные, копируем их в DataSet
						if (tempTable.Rows.Count > 0)
						{
							// Копируем схему и данные
							foreach (DataRow row in tempTable.Rows)
							{
								DataRow newRow = fitnessClubDataSet1.Тренеры.NewRow();

								// Копируем значения по именам столбцов
								foreach (DataColumn column in tempTable.Columns)
								{
									if (fitnessClubDataSet1.Тренеры.Columns.Contains(column.ColumnName))
									{
										newRow[column.ColumnName] = row[column.ColumnName];
									}
								}

								fitnessClubDataSet1.Тренеры.Rows.Add(newRow);
							}
						}

						// Обновляем заголовки
						UpdateDataGridViewColumns();

						// Обновляем количество тренеров
						UpdateTrainerCount();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка загрузки тренеров по квалификации '{qualification}':\n{ex.Message}",
					"Ошибка",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				// В случае ошибки загружаем всех тренеров
				LoadAllTrainers();
			}
		}

		// ВАРИАНТ 2: Более простой способ с прямым SQL запросом
		private void LoadTrainersByQualificationSimple(string qualification)
		{
			try
			{
				string query = @"SELECT ID_Тренера, ФИО, Дата_рождения, Квалификация 
                               FROM Тренеры 
                               WHERE Квалификация = @qualification";

				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					using (SqlCommand cmd = new SqlCommand(query, connection))
					{
						cmd.Parameters.AddWithValue("@qualification", qualification);

						using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
						{
							// Создаем новый DataTable
							DataTable tempTable = new DataTable();
							adapter.Fill(tempTable);

							// Очищаем текущие данные
							fitnessClubDataSet1.Тренеры.Clear();

							// Привязываем DataTable к DataGridView
							dataGridView1.DataSource = tempTable;

							// Обновляем заголовки
							UpdateDataGridViewHeaders();

							// Обновляем количество тренеров
							UpdateTrainerCount();
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка загрузки тренеров по квалификации '{qualification}':\n{ex.Message}",
					"Ошибка",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		// Метод для обновления списка тренеров в зависимости от выбранного фильтра
		private void RefreshTrainersList()
		{
			if (radioButton1.Checked)
			{
				LoadAllTrainers();
			}
			else if (radioButton2.Checked)
			{
				LoadTrainersByQualification("Стажер");
			}
			else if (radioButton3.Checked)
			{
				LoadTrainersByQualification("Сертифицированный тренер");
			}
			else if (radioButton4.Checked)
			{
				LoadTrainersByQualification("Профессиональный тренер");
			}
		}

		// Кнопка "Обновить" - аналогично клиентам
		private void button5_Click(object sender, EventArgs e)
		{
			RefreshTrainersList();
			dataGridView1.ClearSelection();

			// Обновляем количество тренеров
			UpdateTrainerCount();
		}

		// Обработчик события SelectionChanged для DataGridView
		private void dataGridView1_SelectionChanged(object sender, EventArgs e)
		{
			// Визуальное выделение строки
			if (dataGridView1.SelectedRows.Count > 0)
			{
				foreach (DataGridViewRow row in dataGridView1.Rows)
				{
					row.DefaultCellStyle.BackColor = Color.White;
				}
				dataGridView1.SelectedRows[0].DefaultCellStyle.BackColor = Color.LightBlue;
			}
		}

		// Метод для отладки имен столбцов
		private void DebugColumnNames()
		{
			string columnNames = "Имена столбцов DataGridView:\n";
			foreach (DataGridViewColumn column in dataGridView1.Columns)
			{
				columnNames += $"Имя: {column.Name}, Свойство данных: {column.DataPropertyName}, Заголовок: {column.HeaderText}\n";
			}
			MessageBox.Show(columnNames, "Отладка столбцов", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		// Вспомогательный метод для получения значения ячейки
		private object GetCellValue(DataGridViewRow row, params object[] possibleColumnNames)
		{
			foreach (object columnName in possibleColumnNames)
			{
				if (columnName is string name && row.Cells[name] != null && row.Cells[name].Value != null)
				{
					return row.Cells[name].Value;
				}
				else if (columnName is int index && index >= 0 && index < row.Cells.Count && row.Cells[index].Value != null)
				{
					return row.Cells[index].Value;
				}
			}
			return null;
		}

		// Обновление заголовков столбцов DataGridView
		private void UpdateDataGridViewColumns()
		{
			if (dataGridView1.Columns.Count > 0)
			{
				// Устанавливаем понятные заголовки
				foreach (DataGridViewColumn column in dataGridView1.Columns)
				{
					switch (column.DataPropertyName)
					{
						case "ID_Тренера":
						case "IDТренера":
							column.HeaderText = "ID";
							column.Width = 50;
							break;
						case "ФИО":
							column.HeaderText = "ФИО тренера";
							column.Width = 200;
							break;
						case "Дата_рождения":
						case "ДатаРождения":
							column.HeaderText = "Дата рождения";
							column.Width = 120;
							break;
						case "Квалификация":
							column.HeaderText = "Квалификация";
							column.Width = 170;
							break;
					}
				}
			}
		}

		// Альтернативный метод для обновления заголовков
		private void UpdateDataGridViewHeaders()
		{
			if (dataGridView1.Columns.Contains("ID_Тренера"))
				dataGridView1.Columns["ID_Тренера"].HeaderText = "ID";
			if (dataGridView1.Columns.Contains("ФИО"))
				dataGridView1.Columns["ФИО"].HeaderText = "ФИО тренера";
			if (dataGridView1.Columns.Contains("Дата_рождения"))
				dataGridView1.Columns["Дата_рождения"].HeaderText = "Дата рождения";
			if (dataGridView1.Columns.Contains("Квалификация"))
				dataGridView1.Columns["Квалификация"].HeaderText = "Квалификация";
		}

		// Дополнительно: кнопка для отладки (можно добавить на форму скрытую кнопку)
		private void buttonDebug_Click(object sender, EventArgs e)
		{
			DebugColumnNames();
		}

		private void toolStripStatusLabel1_Click(object sender, EventArgs e)
		{
			// При клике на статус-лейбл показываем детальную статистику
			ShowDetailedStatistics();
		}

		// Метод для обновления количества тренеров в статус-баре
		private void UpdateTrainerCount()
		{
			try
			{
				int currentViewCount = 0;
				int selectedCount = 0;
				string qualificationFilter = "";

				// Определяем текущий фильтр
				if (radioButton1.Checked)
				{
					qualificationFilter = "Все тренеры";
				}
				else if (radioButton2.Checked)
				{
					qualificationFilter = "Стажеры";
				}
				else if (radioButton3.Checked)
				{
					qualificationFilter = "Сертифицированные";
				}
				else if (radioButton4.Checked)
				{
					qualificationFilter = "Профессиональные";
				}

				// Количество тренеров в текущем представлении
				if (dataGridView1.Rows != null)
				{
					// Исключаем пустую строку для добавления, если она есть
					currentViewCount = dataGridView1.Rows.Count;
					if (dataGridView1.AllowUserToAddRows && currentViewCount > 0)
					{
						currentViewCount--;
					}
				}

				// Количество выбранных строк
				selectedCount = dataGridView1.SelectedRows.Count;

				// Формируем текст для статус-бара (УБРАЛ "всего в базе")
				string statusText = $"Количество тренеров: {currentViewCount}";

				// Если есть фильтр, добавляем его
				if (!string.IsNullOrEmpty(qualificationFilter) && qualificationFilter != "Все тренеры")
				{
					statusText = $"Фильтр: {qualificationFilter} | {statusText}";
				}

				// Если есть выбранные строки, добавляем информацию
				if (selectedCount > 0)
				{
					statusText += $" | Выбрано: {selectedCount}";
				}

				// Обновляем текст в статус-баре
				if (toolStripStatusLabel1 != null)
				{
					toolStripStatusLabel1.Text = statusText;

					// Цвет НЕ МЕНЯЕМ - оставляем как есть
				}  
			}
			catch (Exception ex)
			{
				// В случае ошибки просто показываем базовую информацию
				if (toolStripStatusLabel1 != null)
				{
					int rowCount = dataGridView1.Rows.Count;
					if (dataGridView1.AllowUserToAddRows && rowCount > 0)
					{
						rowCount--;
					}
					toolStripStatusLabel1.Text = $"Количество тренеров: {rowCount}";
				}
			}
		}

		// Метод для показа детальной статистики при клике на статус-лейбл
		private void ShowDetailedStatistics()
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					// Получаем статистику по квалификациям
					string statsQuery = @"
						SELECT 
							Квалификация,
							COUNT(*) as Количество
						FROM Тренеры
						GROUP BY Квалификация
						ORDER BY Количество DESC";

					StringBuilder statsMessage = new StringBuilder();
					statsMessage.AppendLine("📊 Статистика по тренерам:\n");

					using (SqlCommand cmd = new SqlCommand(statsQuery, connection))
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						int total = 0;
						while (reader.Read())
						{
							string qualification = reader["Квалификация"].ToString();
							int count = Convert.ToInt32(reader["Количество"]);
							total += count;

							statsMessage.AppendLine($"▸ {qualification}: {count} чел.");
						}

						statsMessage.AppendLine($"\n✅Всего тренеров: {total}");
					}

					// Добавляем информацию о текущем фильтре
					string currentFilter = "Все тренеры";
					if (radioButton2.Checked) currentFilter = "Стажеры";
					else if (radioButton3.Checked) currentFilter = "Сертифицированные";
					else if (radioButton4.Checked) currentFilter = "Профессиональные";

					statsMessage.AppendLine($"\nТекущий фильтр: {currentFilter}");
					statsMessage.AppendLine($"Показано в таблице: {GetVisibleTrainerCount()}");

					MessageBox.Show(statsMessage.ToString(),
						"Статистика тренеров",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Не удалось получить статистику:\n{ex.Message}",
					"Ошибка",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		// Вспомогательный метод для получения количества видимых тренеров
		private int GetVisibleTrainerCount()
		{
			if (dataGridView1.Rows == null) return 0;

			int count = dataGridView1.Rows.Count;
			if (dataGridView1.AllowUserToAddRows && count > 0)
			{
				count--;
			}
			return count;
		}

		// Обновляем количество тренеров при изменении данных
		private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			UpdateTrainerCount();
		}

		// Обновляем количество при изменении выбора строк
		private void dataGridView1_SelectionChangedExtended(object sender, EventArgs e)
		{
			// Сначала выполняем стандартную обработку выделения
			if (dataGridView1.SelectedRows.Count > 0)
			{
				foreach (DataGridViewRow row in dataGridView1.Rows)
				{
					row.DefaultCellStyle.BackColor = Color.White;
				}
				dataGridView1.SelectedRows[0].DefaultCellStyle.BackColor = Color.LightBlue;
			}

			// Затем обновляем счетчик
			UpdateTrainerCount();
		}
	}
}