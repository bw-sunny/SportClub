using System;
using System.Drawing;
using System.Windows.Forms;

namespace SportClub
{
	public partial class AdminClientForm : Form
	{
		// Переменные для хранения выбранного клиента
		public AdminClientForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			AdminClientsCreateForm createForm = new AdminClientsCreateForm();
			createForm.ShowDialog();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Form AdminClientsEditForm = new AdminClientsEditForm();
			AdminClientsEditForm.Show();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			AdminForm adminForm = new AdminForm();
			adminForm.Show();
			this.Close();
		}

		private void AdminClientForm_Load(object sender, EventArgs e)
		{
			// TODO: данная строка кода позволяет загрузить данные в таблицу "fitnessClubDataSet.Клиенты". При необходимости она может быть перемещена или удалена.
			this.клиентыTableAdapter1.Fill(this.fitnessClubDataSet.Клиенты);

		}
	}
}