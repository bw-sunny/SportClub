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
    public partial class AdminSubscriptionForm : Form
    {
        public AdminSubscriptionForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form AdminSubscriptionsSellingForm = new AdminSubscriptionsSellingForm();
            AdminSubscriptionsSellingForm.Show();
		}

        private void button2_Click(object sender, EventArgs e)
        {
			Form AdminSubscriptionsReturnForm = new AdminSubscriptionsReturnForm();
			AdminSubscriptionsReturnForm.Show();
		}

        private void button4_Click(object sender, EventArgs e)
        {
            Form AdminForm = new AdminForm();
            AdminForm.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form AdminSubscriptionsView = new AdminSubscriptionsViewForm();
            AdminSubscriptionsView.Show();
            this.Close();

		}
    }
}
