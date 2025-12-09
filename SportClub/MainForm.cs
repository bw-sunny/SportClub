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
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestLogin = "администратор";
            if (TestLogin == "администратор")
            {
                Form AdminForm = new AdminForm();
                AdminForm.Show();
                this.Hide();
            }
		}
    }
}
