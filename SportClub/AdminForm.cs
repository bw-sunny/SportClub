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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form MainForm = new MainForm();
            MainForm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form AdminClientForm = new AdminClientForm();
            AdminClientForm.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form AdminSubscripitonsForm = new AdminSubscriptionForm();
            AdminSubscripitonsForm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
			Form AdminTrainerForm = new AdminTrainerForm();
			AdminTrainerForm.Show();
			this.Close();
		}

        private void button3_Click(object sender, EventArgs e)
        {
			Form AdminTrainingForm = new AdminTrainingForm();
			AdminTrainingForm.Show();
			this.Close();
		}
    }
}
