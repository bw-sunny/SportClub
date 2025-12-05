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
    public partial class ТrainerForm : Form
    {
        public ТrainerForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form MainForm = new MainForm();
            MainForm.Show();
            this.Close();
        }
    }
}
