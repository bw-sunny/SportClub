using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            // TODO: данная строка кода позволяет загрузить данные в таблицу "fitnessClubDataSet3.Вид_Тренировки_С_Тренерами". При необходимости она может быть перемещена или удалена.
            this.вид_Тренировки_С_ТренерамиTableAdapter.Fill(this.fitnessClubDataSet3.Вид_Тренировки_С_Тренерами);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) // кнопка создать новую тренировку
        {
            Form AdminTrainingCreateForm = new AdminTrainingCreateForm();
            AdminTrainingCreateForm.Show();
        }

        private void button2_Click(object sender, EventArgs e) // редактировать существующую тренировку
        {

        }

        private void button3_Click(object sender, EventArgs e) // удалить тренировку
        {

        }

        private void button6_Click(object sender, EventArgs e) // обновление dataGridView
        {

        }
    }
}
