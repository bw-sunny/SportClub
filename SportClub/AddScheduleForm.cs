using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SportClub
{
	public partial class AddScheduleForm : Form
	{
		private string connectionString = @"Data Source=DESKTOP-PGUAQQC\SQLEXPRESS;Initial Catalog=FitnessClub;Integrated Security=True";
		private int selectedTrainingId = -1;
		private DataTable trainingDataTable = new DataTable();
		private ListBox listBoxSuggestions;
		private Timer searchTimer;
		private bool isListBoxVisible = false;

		public AddScheduleForm()
		{
			InitializeComponent();
			SetupControlsInConstructor();
			SetupListBox();
			SetupSearchTimer();
		}

		private void SetupControlsInConstructor()
		{
			// Настройка DateTimePicker2 для времени
			dateTimePicker2.Format = DateTimePickerFormat.Custom;
			dateTimePicker2.CustomFormat = "HH:mm";
			dateTimePicker2.ShowUpDown = true;
			dateTimePicker2.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 0, 0);

			// Настройка DateTimePicker1 для даты
			dateTimePicker1.Format = DateTimePickerFormat.Short;
			dateTimePicker1.Value = DateTime.Today;
			dateTimePicker1.MinDate = DateTime.Today;

			// Настройка текста-подсказки в textBox1
			SetupTextBoxPlaceholder();
		}

		private void SetupTextBoxPlaceholder()
		{
			textBox1.GotFocus += (s, e) =>
			{
				if (textBox1.Text == "Начните вводить название тренировки...")
				{
					textBox1.Text = "";
					textBox1.ForeColor = Color.Black;
				}
			};

			textBox1.LostFocus += (s, e) =>
			{
				if (string.IsNullOrWhiteSpace(textBox1.Text))
				{
					textBox1.Text = "Начните вводить название тренировки...";
					textBox1.ForeColor = Color.Gray;
				}
			};

			textBox1.Text = "Начните вводить название тренировки...";
			textBox1.ForeColor = Color.Gray;
		}

		private void SetupListBox()
		{
			// Создаем ListBox для подсказок
			listBoxSuggestions = new ListBox
			{
				Visible = false,
				Font = textBox1.Font,
				BorderStyle = BorderStyle.FixedSingle,
				BackColor = Color.White,
				ForeColor = Color.Black,
				Height = 150,
				ItemHeight = 20,
				IntegralHeight = false,
				SelectionMode = SelectionMode.One,
				TabStop = false
			};

			// Добавляем ListBox на форму
			this.Controls.Add(listBoxSuggestions);
			listBoxSuggestions.BringToFront();

			// Обработчики событий для ListBox
			listBoxSuggestions.Click += ListBoxSuggestions_Click;
			listBoxSuggestions.KeyDown += ListBoxSuggestions_KeyDown;
			listBoxSuggestions.LostFocus += ListBoxSuggestions_LostFocus;
			listBoxSuggestions.MouseMove += ListBoxSuggestions_MouseMove;
		}

		private void SetupSearchTimer()
		{
			searchTimer = new Timer();
			searchTimer.Interval = 300; // 300ms задержка после ввода
			searchTimer.Tick += SearchTimer_Tick;
		}

		private void AddScheduleForm_Load_1(object sender, EventArgs e)
		{
			LoadAllTrainings();
			textBox1.Focus();
		}

		private void LoadAllTrainings()
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();
					string query = @"
                        SELECT 
                            t.ID_Тренировки,
                            t.Название,
                            tr.ФИО AS Тренер,
                            t.Зал,
                            t.Длительность,
                            t.Название + ' (' + tr.ФИО + ')' AS Отображение
                        FROM Тренировки t
                        JOIN Тренеры tr ON t.ID_Тренера = tr.ID_Тренера
                        ORDER BY t.Название";

					SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
					trainingDataTable.Clear();
					adapter.Fill(trainingDataTable);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка загрузки тренировок: {ex.Message}", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// ==================== ПОИСК И ПОДСКАЗКИ ====================

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(textBox1.Text) ||
				textBox1.Text == "Начните вводить название тренировки...")
			{
				HideSuggestions();
				return;
			}

			// Перезапускаем таймер для поиска
			searchTimer.Stop();
			searchTimer.Start();
		}

		private void SearchTimer_Tick(object sender, EventArgs e)
		{
			searchTimer.Stop();
			SearchTrainings(textBox1.Text.Trim());
		}

		private void SearchTrainings(string searchText)
		{
			if (string.IsNullOrWhiteSpace(searchText) ||
				searchText == "Начните вводить название тренировки...")
			{
				HideSuggestions();
				return;
			}

			try
			{
				var filteredRows = trainingDataTable.AsEnumerable()
					.Where(row => row.Field<string>("Название").ToLower().Contains(searchText.ToLower()) ||
								  row.Field<string>("Тренер").ToLower().Contains(searchText.ToLower()))
					.Take(10) // Ограничиваем 10 результатами
					.ToList();

				if (filteredRows.Any())
				{
					ShowSuggestions(filteredRows);
				}
				else
				{
					HideSuggestions();
				}
			}
			catch
			{
				HideSuggestions();
			}
		}

		private void ShowSuggestions(List<DataRow> filteredRows)
		{
			if (listBoxSuggestions == null) return;

			listBoxSuggestions.Items.Clear();

			foreach (var row in filteredRows)
			{
				listBoxSuggestions.Items.Add(row["Отображение"]);
			}

			if (listBoxSuggestions.Items.Count > 0)
			{
				// Позиционируем ListBox под textBox1
				Point location = textBox1.PointToScreen(new Point(0, textBox1.Height));
				location = this.PointToClient(location);

				listBoxSuggestions.Location = location;
				listBoxSuggestions.Width = textBox1.Width;
				listBoxSuggestions.Visible = true;
				isListBoxVisible = true;

				// Автоматически выбираем первую строку
				listBoxSuggestions.SelectedIndex = 0;
			}
			else
			{
				HideSuggestions();
			}
		}

		private void HideSuggestions()
		{
			if (listBoxSuggestions != null)
			{
				listBoxSuggestions.Visible = false;
			}
			isListBoxVisible = false;
		}

		// ==================== ВЫБОР ИЗ СПИСКА ====================

		private void ListBoxSuggestions_Click(object sender, EventArgs e)
		{
			if (listBoxSuggestions == null) return;

			if (listBoxSuggestions.SelectedIndex >= 0)
			{
				SelectTrainingFromList();
			}
		}

		private void SelectTrainingFromList()
		{
			if (listBoxSuggestions == null) return;

			if (listBoxSuggestions.SelectedIndex >= 0)
			{
				var selectedText = listBoxSuggestions.SelectedItem.ToString();

				// Ищем соответствующий DataRow
				var row = trainingDataTable.AsEnumerable()
					.FirstOrDefault(r => r.Field<string>("Отображение") == selectedText);

				if (row != null)
				{
					textBox1.Text = row["Название"].ToString();
					textBox1.ForeColor = Color.Black;
					selectedTrainingId = Convert.ToInt32(row["ID_Тренировки"]);
					HideSuggestions();
					textBox1.Focus();
				}
			}
		}

		// ==================== ОБРАБОТКА КЛАВИАТУРЫ ====================

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (listBoxSuggestions == null) return;

			if (e.KeyCode == Keys.Down)
			{
				if (isListBoxVisible && listBoxSuggestions.Items.Count > 0)
				{
					listBoxSuggestions.Focus();
					if (listBoxSuggestions.SelectedIndex < listBoxSuggestions.Items.Count - 1)
					{
						listBoxSuggestions.SelectedIndex++;
					}
					e.Handled = true;
				}
			}
			else if (e.KeyCode == Keys.Up)
			{
				if (isListBoxVisible && listBoxSuggestions.Items.Count > 0)
				{
					listBoxSuggestions.Focus();
					if (listBoxSuggestions.SelectedIndex > 0)
					{
						listBoxSuggestions.SelectedIndex--;
					}
					else
					{
						// Если на первом элементе, возвращаем фокус в textBox1
						textBox1.Focus();
					}
					e.Handled = true;
				}
			}
			else if (e.KeyCode == Keys.Enter)
			{
				if (isListBoxVisible && listBoxSuggestions.SelectedIndex >= 0)
				{
					SelectTrainingFromList();
					e.Handled = true;
				}
				else
				{
					e.Handled = true;
					dateTimePicker1.Focus();
				}
			}
			else if (e.KeyCode == Keys.Escape)
			{
				if (isListBoxVisible)
				{
					HideSuggestions();
					e.Handled = true;
				}
			}
		}

		private void ListBoxSuggestions_KeyDown(object sender, KeyEventArgs e)
		{
			if (listBoxSuggestions == null) return;

			if (e.KeyCode == Keys.Enter)
			{
				SelectTrainingFromList();
				e.Handled = true;
			}
			else if (e.KeyCode == Keys.Escape)
			{
				HideSuggestions();
				textBox1.Focus();
				e.Handled = true;
			}
		}

		// ==================== ОБРАБОТКА ФОКУСА И МЫШИ ====================

		private void ListBoxSuggestions_LostFocus(object sender, EventArgs e)
		{
			if (listBoxSuggestions == null) return;

			// Не скрываем сразу, даем время для клика
			if (!textBox1.Focused && !listBoxSuggestions.Focused)
			{
				System.Threading.Thread.Sleep(100);
				if (!textBox1.Focused && !listBoxSuggestions.Focused)
				{
					HideSuggestions();
				}
			}
		}

		private void ListBoxSuggestions_MouseMove(object sender, MouseEventArgs e)
		{
			if (listBoxSuggestions == null) return;

			// Подсвечиваем элемент под курсором мыши
			int index = listBoxSuggestions.IndexFromPoint(e.Location);
			if (index >= 0 && index < listBoxSuggestions.Items.Count)
			{
				listBoxSuggestions.SelectedIndex = index;
			}
		}

		// Скрываем подсказки при клике вне textBox1 и listBoxSuggestions
		private void AddScheduleForm_Click(object sender, EventArgs e)
		{
			if (listBoxSuggestions == null) return;

			if (!textBox1.Bounds.Contains(PointToClient(MousePosition)) &&
				!listBoxSuggestions.Bounds.Contains(PointToClient(MousePosition)))
			{
				HideSuggestions();
			}
		}

		// ==================== КНОПКА ДОБАВИТЬ ====================

		private void button1_Click(object sender, EventArgs e)
		{
			if (selectedTrainingId == -1)
			{
				MessageBox.Show("Выберите тренировку", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				textBox1.Focus();
				return;
			}

			if (string.IsNullOrWhiteSpace(textBox1.Text) ||
				textBox1.Text == "Начните вводить название тренировки...")
			{
				MessageBox.Show("Введите название тренировки", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				textBox1.Focus();
				return;
			}

			try
			{
				// 1. Получаем ID тренировки
				int trainingId = selectedTrainingId;

				// 2. Собираем дату и время
				DateTime selectedDate = dateTimePicker1.Value.Date;
				TimeSpan selectedTime = dateTimePicker2.Value.TimeOfDay;
				DateTime selectedDateTime = selectedDate.Add(selectedTime);

				// 3. Проверяем, что время в будущем
				if (selectedDateTime < DateTime.Now)
				{
					MessageBox.Show("Выберите будущее время", "Ошибка",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				// 4. Генерируем новый ID
				int newId = GetNewScheduleId();

				// 5. Сохраняем в базу
				SaveToDatabase(newId, trainingId, selectedDateTime);

				MessageBox.Show($"Занятие добавлено! ID: {newId}", "Успех",
					MessageBoxButtons.OK, MessageBoxIcon.Information);

				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (SqlException ex)
			{
				string errorMessage = $"Ошибка SQL #{ex.Number}: {ex.Message}";

				if (ex.Number == 2627)
				{
					errorMessage = "Такое занятие уже существует (дублирование ID)";
				}
				else if (ex.Number == 547)
				{
					errorMessage = "Ошибка внешнего ключа. Проверьте ID тренировки.";
				}
				else if (ex.Number == 515)
				{
					errorMessage = "Не все обязательные поля заполнены";
				}
				else if (ex.Message.Contains("тренер") || ex.Message.Contains("занят"))
				{
					errorMessage = "Тренер уже занят в это время!";
				}

				MessageBox.Show(errorMessage, "Ошибка БД",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// ==================== КНОПКА ОТМЕНА ====================

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		// ==================== ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ ====================

		private int GetNewScheduleId()
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();
					string[] possibleColumnNames = {
						"ID_Расписания",
						"ID_Раписания",
						"ID_расписания",
						"ID"
					};

					foreach (string columnName in possibleColumnNames)
					{
						try
						{
							string query = $"SELECT ISNULL(MAX({columnName}), 0) + 1 FROM Расписание_тренировок";
							using (SqlCommand cmd = new SqlCommand(query, conn))
							{
								object result = cmd.ExecuteScalar();
								if (result != null)
								{
									return Convert.ToInt32(result);
								}
							}
						}
						catch
						{
							continue;
						}
					}

					throw new Exception("Не удалось определить название столбца ID");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка генерации ID: {ex.Message}\nИспользую ID = 1", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return 1;
			}
		}

		private void SaveToDatabase(int id, int trainingId, DateTime dateTime)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();

				string[] possibleQueries = {
					@"INSERT INTO Расписание_тренировок (ID_Расписания, ID_Тренировки, Дата_время) VALUES (@ID, @TrainingId, @DateTime)",
					@"INSERT INTO Расписание_тренировок (ID_Раписания, ID_Тренировки, Дата_время) VALUES (@ID, @TrainingId, @DateTime)",
					@"INSERT INTO Расписание_тренировок (ID, ID_Тренировки, Дата_время) VALUES (@ID, @TrainingId, @DateTime)",
					@"INSERT INTO Расписание_тренировок VALUES (@ID, @TrainingId, @DateTime)"
				};

				foreach (string query in possibleQueries)
				{
					try
					{
						using (SqlCommand cmd = new SqlCommand(query, conn))
						{
							cmd.Parameters.AddWithValue("@ID", id);
							cmd.Parameters.AddWithValue("@TrainingId", trainingId);
							cmd.Parameters.AddWithValue("@DateTime", dateTime);
							cmd.ExecuteNonQuery();
							return;
						}
					}
					catch (SqlException sqlEx)
					{
						if (sqlEx.Number == 213)
						{
							continue;
						}
						throw;
					}
					catch
					{
						continue;
					}
				}

				throw new Exception("Не удалось выполнить INSERT с любым вариантом названий столбцов");
			}
		}

		// ==================== ОБРАБОТКА НАЖАТИЯ ENTER ====================

		private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.Handled = true;
				dateTimePicker2.Focus();
			}
		}

		private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.Handled = true;
				button1.PerformClick();
			}
		}

		// ==================== ОБРАБОТКА ESCAPE ====================

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Escape)
			{
				if (isListBoxVisible)
				{
					HideSuggestions();
					return true;
				}
				this.Close();
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		// Добавляем обработчик для движения формы
		private void AddScheduleForm_Move(object sender, EventArgs e)
		{
			HideSuggestions();
		}

		// Добавляем обработчик для изменения размера формы
		private void AddScheduleForm_Resize(object sender, EventArgs e)
		{
			HideSuggestions();
		}
	}
}