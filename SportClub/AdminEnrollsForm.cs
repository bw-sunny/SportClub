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
    public partial class AdminEnrollsForm : Form
    {
        public AdminEnrollsForm()
        {
            InitializeComponent();
        }

        private void AdminEnrollsForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "fitnessClubDataSet4.Вид_Записи_на_занятия". При необходимости она может быть перемещена или удалена.
            this.вид_Записи_на_занятияTableAdapter.Fill(this.fitnessClubDataSet4.Вид_Записи_на_занятия);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form AdminEnrollsNew = new AdminEnrollsNew();
            AdminEnrollsNew.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
			this.вид_Записи_на_занятияTableAdapter.Fill(this.fitnessClubDataSet4.Вид_Записи_на_занятия);
		}
    }
}
