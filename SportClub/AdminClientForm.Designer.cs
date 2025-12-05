namespace SportClub
{
    partial class AdminClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.клиентыBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.fitnessClubClients = new SportClub.FitnessClubClients();
			this.клиентыTableAdapter = new SportClub.FitnessClubClientsTableAdapters.КлиентыTableAdapter();
			this.label2 = new System.Windows.Forms.Label();
			this.fitnessClubClientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.fitnessClubDataSet = new SportClub.FitnessClubDataSet();
			this.клиентыBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.клиентыTableAdapter1 = new SportClub.FitnessClubDataSetTableAdapters.КлиентыTableAdapter();
			this.iDКлиентаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.фИОDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.номертелефонаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.датарожденияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.клиентыBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fitnessClubClients)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fitnessClubClientsBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fitnessClubDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.клиентыBindingSource1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(34, 80);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(100, 36);
			this.button1.TabIndex = 0;
			this.button1.Text = "Создать";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.button2.Location = new System.Drawing.Point(293, 80);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(100, 36);
			this.button2.TabIndex = 1;
			this.button2.Text = "Удалить";
			this.button2.UseVisualStyleBackColor = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(47, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(118, 29);
			this.label1.TabIndex = 2;
			this.label1.Text = "Клиенты";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(140, 80);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(147, 36);
			this.button3.TabIndex = 3;
			this.button3.Text = "Редактировать";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(712, 27);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(40, 25);
			this.button4.TabIndex = 6;
			this.button4.Text = "<-";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDКлиентаDataGridViewTextBoxColumn,
            this.фИОDataGridViewTextBoxColumn,
            this.номертелефонаDataGridViewTextBoxColumn,
            this.датарожденияDataGridViewTextBoxColumn});
			this.dataGridView1.DataSource = this.клиентыBindingSource1;
			this.dataGridView1.Location = new System.Drawing.Point(34, 175);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(699, 263);
			this.dataGridView1.TabIndex = 7;
			// 
			// клиентыBindingSource
			// 
			this.клиентыBindingSource.DataMember = "Клиенты";
			this.клиентыBindingSource.DataSource = this.fitnessClubClients;
			// 
			// fitnessClubClients
			// 
			this.fitnessClubClients.DataSetName = "FitnessClubClients";
			this.fitnessClubClients.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// клиентыTableAdapter
			// 
			this.клиентыTableAdapter.ClearBeforeFill = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(31, 146);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(122, 16);
			this.label2.TabIndex = 8;
			this.label2.Text = "Список клиентов:";
			// 
			// fitnessClubClientsBindingSource
			// 
			this.fitnessClubClientsBindingSource.DataSource = this.fitnessClubClients;
			this.fitnessClubClientsBindingSource.Position = 0;
			// 
			// fitnessClubDataSet
			// 
			this.fitnessClubDataSet.DataSetName = "FitnessClubDataSet";
			this.fitnessClubDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// клиентыBindingSource1
			// 
			this.клиентыBindingSource1.DataMember = "Клиенты";
			this.клиентыBindingSource1.DataSource = this.fitnessClubDataSet;
			// 
			// клиентыTableAdapter1
			// 
			this.клиентыTableAdapter1.ClearBeforeFill = true;
			// 
			// iDКлиентаDataGridViewTextBoxColumn
			// 
			this.iDКлиентаDataGridViewTextBoxColumn.DataPropertyName = "ID_Клиента";
			this.iDКлиентаDataGridViewTextBoxColumn.HeaderText = "ID";
			this.iDКлиентаDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.iDКлиентаDataGridViewTextBoxColumn.Name = "iDКлиентаDataGridViewTextBoxColumn";
			this.iDКлиентаDataGridViewTextBoxColumn.ReadOnly = true;
			this.iDКлиентаDataGridViewTextBoxColumn.Width = 50;
			// 
			// фИОDataGridViewTextBoxColumn
			// 
			this.фИОDataGridViewTextBoxColumn.DataPropertyName = "ФИО";
			this.фИОDataGridViewTextBoxColumn.HeaderText = "ФИО";
			this.фИОDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.фИОDataGridViewTextBoxColumn.Name = "фИОDataGridViewTextBoxColumn";
			this.фИОDataGridViewTextBoxColumn.ReadOnly = true;
			this.фИОDataGridViewTextBoxColumn.Width = 200;
			// 
			// номертелефонаDataGridViewTextBoxColumn
			// 
			this.номертелефонаDataGridViewTextBoxColumn.DataPropertyName = "Номер_телефона";
			this.номертелефонаDataGridViewTextBoxColumn.HeaderText = "Номер телефона";
			this.номертелефонаDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.номертелефонаDataGridViewTextBoxColumn.Name = "номертелефонаDataGridViewTextBoxColumn";
			this.номертелефонаDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// датарожденияDataGridViewTextBoxColumn
			// 
			this.датарожденияDataGridViewTextBoxColumn.DataPropertyName = "Дата_рождения";
			this.датарожденияDataGridViewTextBoxColumn.HeaderText = "Дата рождения";
			this.датарожденияDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.датарожденияDataGridViewTextBoxColumn.Name = "датарожденияDataGridViewTextBoxColumn";
			this.датарожденияDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// AdminClientForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "AdminClientForm";
			this.Text = "Администратор - Клиенты";
			this.Load += new System.EventHandler(this.AdminClientForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.клиентыBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fitnessClubClients)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fitnessClubClientsBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fitnessClubDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.клиентыBindingSource1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private FitnessClubClients fitnessClubClients;
        private System.Windows.Forms.BindingSource клиентыBindingSource;
        private FitnessClubClientsTableAdapters.КлиентыTableAdapter клиентыTableAdapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource fitnessClubClientsBindingSource;
        private FitnessClubDataSet fitnessClubDataSet;
        private System.Windows.Forms.BindingSource клиентыBindingSource1;
        private FitnessClubDataSetTableAdapters.КлиентыTableAdapter клиентыTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDКлиентаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn фИОDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn номертелефонаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датарожденияDataGridViewTextBoxColumn;
    }
}