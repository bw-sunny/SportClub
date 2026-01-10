namespace SportClub
{
    partial class AdminScheduleForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminScheduleForm));
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.iDРасписанияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.датаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.деньDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.времяDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.тренировкаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.тренерDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.залDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.видРасписаниеКраткоBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.fitnessClubDataSet5 = new SportClub.FitnessClubDataSet5();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.вид_Расписание_КраткоTableAdapter = new SportClub.FitnessClubDataSet5TableAdapters.Вид_Расписание_КраткоTableAdapter();
			this.label6 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.видРасписаниеКраткоBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fitnessClubDataSet5)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDРасписанияDataGridViewTextBoxColumn,
            this.датаDataGridViewTextBoxColumn,
            this.деньDataGridViewTextBoxColumn,
            this.времяDataGridViewTextBoxColumn,
            this.тренировкаDataGridViewTextBoxColumn,
            this.тренерDataGridViewTextBoxColumn,
            this.залDataGridViewTextBoxColumn});
			this.dataGridView1.DataSource = this.видРасписаниеКраткоBindingSource;
			this.dataGridView1.Location = new System.Drawing.Point(12, 168);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(1329, 509);
			this.dataGridView1.TabIndex = 0;
			// 
			// iDРасписанияDataGridViewTextBoxColumn
			// 
			this.iDРасписанияDataGridViewTextBoxColumn.DataPropertyName = "ID_Расписания";
			this.iDРасписанияDataGridViewTextBoxColumn.HeaderText = "ID";
			this.iDРасписанияDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.iDРасписанияDataGridViewTextBoxColumn.Name = "iDРасписанияDataGridViewTextBoxColumn";
			this.iDРасписанияDataGridViewTextBoxColumn.Width = 50;
			// 
			// датаDataGridViewTextBoxColumn
			// 
			this.датаDataGridViewTextBoxColumn.DataPropertyName = "Дата";
			this.датаDataGridViewTextBoxColumn.HeaderText = "Дата";
			this.датаDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.датаDataGridViewTextBoxColumn.Name = "датаDataGridViewTextBoxColumn";
			this.датаDataGridViewTextBoxColumn.ReadOnly = true;
			this.датаDataGridViewTextBoxColumn.Width = 75;
			// 
			// деньDataGridViewTextBoxColumn
			// 
			this.деньDataGridViewTextBoxColumn.DataPropertyName = "День";
			this.деньDataGridViewTextBoxColumn.HeaderText = "День";
			this.деньDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.деньDataGridViewTextBoxColumn.Name = "деньDataGridViewTextBoxColumn";
			this.деньDataGridViewTextBoxColumn.ReadOnly = true;
			this.деньDataGridViewTextBoxColumn.Width = 125;
			// 
			// времяDataGridViewTextBoxColumn
			// 
			this.времяDataGridViewTextBoxColumn.DataPropertyName = "Время";
			this.времяDataGridViewTextBoxColumn.HeaderText = "Время";
			this.времяDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.времяDataGridViewTextBoxColumn.Name = "времяDataGridViewTextBoxColumn";
			this.времяDataGridViewTextBoxColumn.ReadOnly = true;
			this.времяDataGridViewTextBoxColumn.Width = 125;
			// 
			// тренировкаDataGridViewTextBoxColumn
			// 
			this.тренировкаDataGridViewTextBoxColumn.DataPropertyName = "Тренировка";
			this.тренировкаDataGridViewTextBoxColumn.HeaderText = "Тренировка";
			this.тренировкаDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.тренировкаDataGridViewTextBoxColumn.Name = "тренировкаDataGridViewTextBoxColumn";
			this.тренировкаDataGridViewTextBoxColumn.Width = 200;
			// 
			// тренерDataGridViewTextBoxColumn
			// 
			this.тренерDataGridViewTextBoxColumn.DataPropertyName = "Тренер";
			this.тренерDataGridViewTextBoxColumn.HeaderText = "Тренер";
			this.тренерDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.тренерDataGridViewTextBoxColumn.Name = "тренерDataGridViewTextBoxColumn";
			this.тренерDataGridViewTextBoxColumn.Width = 200;
			// 
			// залDataGridViewTextBoxColumn
			// 
			this.залDataGridViewTextBoxColumn.DataPropertyName = "Зал";
			this.залDataGridViewTextBoxColumn.HeaderText = "Зал";
			this.залDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.залDataGridViewTextBoxColumn.Name = "залDataGridViewTextBoxColumn";
			this.залDataGridViewTextBoxColumn.Width = 125;
			// 
			// видРасписаниеКраткоBindingSource
			// 
			this.видРасписаниеКраткоBindingSource.DataMember = "Вид_Расписание_Кратко";
			this.видРасписаниеКраткоBindingSource.DataSource = this.fitnessClubDataSet5;
			// 
			// fitnessClubDataSet5
			// 
			this.fitnessClubDataSet5.DataSetName = "FitnessClubDataSet5";
			this.fitnessClubDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(39, 110);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(96, 32);
			this.button3.TabIndex = 9;
			this.button3.Text = "Добавить";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(141, 110);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(124, 32);
			this.button4.TabIndex = 10;
			this.button4.Text = "Редактировать";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(1258, 26);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(47, 32);
			this.button7.TabIndex = 13;
			this.button7.Text = "<-";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button8
			// 
			this.button8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button8.BackgroundImage")));
			this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.button8.Location = new System.Drawing.Point(1265, 108);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(40, 36);
			this.button8.TabIndex = 14;
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// button5
			// 
			this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.button5.Location = new System.Drawing.Point(271, 108);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(124, 32);
			this.button5.TabIndex = 16;
			this.button5.Text = "Удалить";
			this.button5.UseVisualStyleBackColor = false;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// вид_Расписание_КраткоTableAdapter
			// 
			this.вид_Расписание_КраткоTableAdapter.ClearBeforeFill = true;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(497, 168);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(0, 16);
			this.label6.TabIndex = 18;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(34, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(308, 29);
			this.label1.TabIndex = 19;
			this.label1.Text = "Расписание тренировок";
			// 
			// AdminScheduleForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1353, 694);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.dataGridView1);
			this.Name = "AdminScheduleForm";
			this.Text = "AdminScheduleForm";
			this.Load += new System.EventHandler(this.AdminScheduleForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.видРасписаниеКраткоBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fitnessClubDataSet5)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button5;
        private FitnessClubDataSet5 fitnessClubDataSet5;
        private System.Windows.Forms.BindingSource видРасписаниеКраткоBindingSource;
        private FitnessClubDataSet5TableAdapters.Вид_Расписание_КраткоTableAdapter вид_Расписание_КраткоTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDРасписанияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn деньDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn времяDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn тренировкаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn тренерDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn залDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
    }
}