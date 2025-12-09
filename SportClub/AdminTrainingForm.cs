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
    public partial class AdminTrainingForm : Form
    {
        public AdminTrainingForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form AdminTrainingAllForm = new AdminTrainingAllForm();
            AdminTrainingAllForm.Show();

		}

        private void button4_Click(object sender, EventArgs e)
        {
			Form AdminForm = new AdminForm();
			AdminForm.Show();
            this.Close();
		}

        private void button2_Click(object sender, EventArgs e)
        {
            Form AdminEnrollsForm = new AdminEnrollsForm();
            AdminEnrollsForm.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
			Form AdminScheduleForm = new AdminScheduleForm();
			AdminScheduleForm.Show();
		}
    }
}
