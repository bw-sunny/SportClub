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
    public partial class MainForm : Form
    {
		public string TestLogin { get; private set; }
		public MainForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TestLogin = Login.Text;
            if (TestLogin == "тренер") {
				Form ТrainerForm = new ТrainerForm();
				ТrainerForm.Show();
				this.Hide();
			}
            else
            {
				MessageBox.Show("Для входа как тренер введите логин", "Ошибка",
							  MessageBoxButtons.OK, MessageBoxIcon.Warning);
				Login.Focus(); 
				Login.SelectAll();
			}
           

		}

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
			TestLogin = Login.Text;
            if (TestLogin == "администратор")
            {
                Form AdminForm = new AdminForm();
                AdminForm.Show();
                this.Hide();
            }
			else
			{
				MessageBox.Show("Для входа как админ введите логин", "Ошибка",
							  MessageBoxButtons.OK, MessageBoxIcon.Warning);
				Login.Focus();
				Login.SelectAll();
			}
		}
    }
}
