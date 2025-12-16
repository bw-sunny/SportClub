namespace SportClub
{
    partial class AdminEnrollsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminEnrollsForm));
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.iDЗаписиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.фИОклиентаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.названиетренировкиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.датавремяDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.залDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.тренерDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.длительностьDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.статусзаписиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.видЗаписиназанятияBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.fitnessClubDataSet4 = new SportClub.FitnessClubDataSet4();
			this.вид_Записи_на_занятияTableAdapter = new SportClub.FitnessClubDataSet4TableAdapters.Вид_Записи_на_занятияTableAdapter();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.видЗаписиназанятияBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fitnessClubDataSet4)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDЗаписиDataGridViewTextBoxColumn,
            this.фИОклиентаDataGridViewTextBoxColumn,
            this.названиетренировкиDataGridViewTextBoxColumn,
            this.датавремяDataGridViewTextBoxColumn,
            this.залDataGridViewTextBoxColumn,
            this.тренерDataGridViewTextBoxColumn,
            this.длительностьDataGridViewTextBoxColumn,
            this.статусзаписиDataGridViewTextBoxColumn});
			this.dataGridView1.DataSource = this.видЗаписиназанятияBindingSource;
			this.dataGridView1.Location = new System.Drawing.Point(29, 121);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(1192, 501);
			this.dataGridView1.TabIndex = 0;
			// 
			// iDЗаписиDataGridViewTextBoxColumn
			// 
			this.iDЗаписиDataGridViewTextBoxColumn.DataPropertyName = "ID_Записи";
			this.iDЗаписиDataGridViewTextBoxColumn.HeaderText = "ID";
			this.iDЗаписиDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.iDЗаписиDataGridViewTextBoxColumn.Name = "iDЗаписиDataGridViewTextBoxColumn";
			this.iDЗаписиDataGridViewTextBoxColumn.Width = 50;
			// 
			// фИОклиентаDataGridViewTextBoxColumn
			// 
			this.фИОклиентаDataGridViewTextBoxColumn.DataPropertyName = "ФИО_клиента";
			this.фИОклиентаDataGridViewTextBoxColumn.HeaderText = "Клиент";
			this.фИОклиентаDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.фИОклиентаDataGridViewTextBoxColumn.Name = "фИОклиентаDataGridViewTextBoxColumn";
			this.фИОклиентаDataGridViewTextBoxColumn.Width = 125;
			// 
			// названиетренировкиDataGridViewTextBoxColumn
			// 
			this.названиетренировкиDataGridViewTextBoxColumn.DataPropertyName = "Название_тренировки";
			this.названиетренировкиDataGridViewTextBoxColumn.HeaderText = "Тренировка";
			this.названиетренировкиDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.названиетренировкиDataGridViewTextBoxColumn.Name = "названиетренировкиDataGridViewTextBoxColumn";
			this.названиетренировкиDataGridViewTextBoxColumn.Width = 125;
			//   
			// датавремяDataGridViewTextBoxColumn
			// 
			this.датавремяDataGridViewTextBoxColumn.DataPropertyName = "Дата_время";
			this.датавремяDataGridViewTextBoxColumn.HeaderText = "Дата и время";
			this.датавремяDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.датавремяDataGridViewTextBoxColumn.Name = "датавремяDataGridViewTextBoxColumn";
			this.датавремяDataGridViewTextBoxColumn.Width = 125;
			// 
			// залDataGridViewTextBoxColumn
			// 
			this.залDataGridViewTextBoxColumn.DataPropertyName = "Зал";
			this.залDataGridViewTextBoxColumn.HeaderText = "Зал";
			this.залDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.залDataGridViewTextBoxColumn.Name = "залDataGridViewTextBoxColumn";
			this.залDataGridViewTextBoxColumn.Width = 125;
			// 
			// тренерDataGridViewTextBoxColumn
			// 
			this.тренерDataGridViewTextBoxColumn.DataPropertyName = "Тренер";
			this.тренерDataGridViewTextBoxColumn.HeaderText = "Тренер";
			this.тренерDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.тренерDataGridViewTextBoxColumn.Name = "тренерDataGridViewTextBoxColumn";
			this.тренерDataGridViewTextBoxColumn.Width = 125;
			// 
			// длительностьDataGridViewTextBoxColumn
			// 
			this.длительностьDataGridViewTextBoxColumn.DataPropertyName = "Длительность";
			this.длительностьDataGridViewTextBoxColumn.HeaderText = "Длительность";
			this.длительностьDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.длительностьDataGridViewTextBoxColumn.Name = "длительностьDataGridViewTextBoxColumn";
			this.длительностьDataGridViewTextBoxColumn.Width = 125;
			// 
			// статусзаписиDataGridViewTextBoxColumn
			// 
			this.статусзаписиDataGridViewTextBoxColumn.DataPropertyName = "Статус_записи";
			this.статусзаписиDataGridViewTextBoxColumn.HeaderText = "Статус_записи";
			this.статусзаписиDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.статусзаписиDataGridViewTextBoxColumn.Name = "статусзаписиDataGridViewTextBoxColumn";
			this.статусзаписиDataGridViewTextBoxColumn.ReadOnly = true;
			this.статусзаписиDataGridViewTextBoxColumn.Width = 125;
			// 
			// видЗаписиназанятияBindingSource
			// 
			this.видЗаписиназанятияBindingSource.DataMember = "Вид_Записи_на_занятия";
			this.видЗаписиназанятияBindingSource.DataSource = this.fitnessClubDataSet4;
			// 
			// fitnessClubDataSet4
			// 
			this.fitnessClubDataSet4.DataSetName = "FitnessClubDataSet4";
			this.fitnessClubDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// вид_Записи_на_занятияTableAdapter
			// 
			this.вид_Записи_на_занятияTableAdapter.ClearBeforeFill = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(47, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(102, 29);
			this.label1.TabIndex = 1;
			this.label1.Text = "Записи";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(29, 66);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(144, 39);
			this.button1.TabIndex = 2;
			this.button1.Text = "Добавить";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button6
			// 
			this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
			this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.button6.Location = new System.Drawing.Point(1165, 69);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(40, 36);
			this.button6.TabIndex = 15;
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(1158, 15);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(47, 32);
			this.button4.TabIndex = 14;
			this.button4.Text = "<-";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// AdminEnrollsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1245, 634);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dataGridView1);
			this.Name = "AdminEnrollsForm";
			this.Text = "AdminEnrollsForm";
			this.Load += new System.EventHandler(this.AdminEnrollsForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.видЗаписиназанятияBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fitnessClubDataSet4)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private FitnessClubDataSet4 fitnessClubDataSet4;
        private System.Windows.Forms.BindingSource видЗаписиназанятияBindingSource;
        private FitnessClubDataSet4TableAdapters.Вид_Записи_на_занятияTableAdapter вид_Записи_на_занятияTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDЗаписиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn фИОклиентаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn названиетренировкиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датавремяDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn залDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn тренерDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn длительностьDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn статусзаписиDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button4;
    }
}