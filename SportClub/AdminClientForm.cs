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
    public partial class AdminClientForm : Form
    {
        public AdminClientForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form AdminClientsCreateForm = new AdminClientsCreateForm();
            AdminClientsCreateForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Редактирование");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form AdminForm = new AdminForm();
            AdminForm.Show();
            this.Close();
        }

        private void AdminClientForm_Load(object sender, EventArgs e)
        {
			// TODO: данная строка кода позволяет загрузить данные в таблицу "fitnessClubClients.Клиенты". При необходимости она может быть перемещена или удалена.
			this.клиентыTableAdapter.Fill(this.fitnessClubClients.Клиенты);

		}

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
