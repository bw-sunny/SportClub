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
    public partial class AdminSubscriptionsViewForm : Form
    {
        public AdminSubscriptionsViewForm()
        {
            InitializeComponent();
        }

        private void AdminSubscriptionsViewForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "fitnessClubDataSet2.Абонементы_С_Клиентами". При необходимости она может быть перемещена или удалена.
            this.абонементы_С_КлиентамиTableAdapter1.Fill(this.fitnessClubDataSet2.Абонементы_С_Клиентами);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form AdminSubscriptionForm = new AdminSubscriptionForm();
            AdminSubscriptionForm.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
