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
			this.label1 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.button5 = new System.Windows.Forms.Button();
			this.fitnessClubDataSet5 = new SportClub.FitnessClubDataSet5();
			this.видРасписаниеКраткоBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.вид_Расписание_КраткоTableAdapter = new SportClub.FitnessClubDataSet5TableAdapters.Вид_Расписание_КраткоTableAdapter();
			this.iDРасписанияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.датаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.деньDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.времяDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.тренировкаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.тренерDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.залDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fitnessClubDataSet5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.видРасписаниеКраткоBindingSource)).BeginInit();
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
			this.dataGridView1.Location = new System.Drawing.Point(12, 292);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(1329, 509);
			this.dataGridView1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(36, 58);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Дата:";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(101, 53);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(269, 22);
			this.dateTimePicker1.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(36, 85);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Тренер:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(101, 82);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(269, 22);
			this.textBox1.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(36, 113);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "Зал:";
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(101, 110);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(269, 24);
			this.comboBox1.TabIndex = 6;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(39, 150);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 32);
			this.button1.TabIndex = 7;
			this.button1.Text = "Применить";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(141, 150);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(96, 32);
			this.button2.TabIndex = 8;
			this.button2.Text = "Сбросить";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(39, 226);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(96, 32);
			this.button3.TabIndex = 9;
			this.button3.Text = "Добавить";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(141, 226);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(124, 32);
			this.button4.TabIndex = 10;
			this.button4.Text = "Редактировать";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(1265, 43);
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
			this.button8.Location = new System.Drawing.Point(1265, 224);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(40, 36);
			this.button8.TabIndex = 14;
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(181, 23);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 16);
			this.label4.TabIndex = 15;
			this.label4.Text = "Фильтр";
			// 
			// button5
			// 
			this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.button5.Location = new System.Drawing.Point(271, 224);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(124, 32);
			this.button5.TabIndex = 16;
			this.button5.Text = "Удалить";
			this.button5.UseVisualStyleBackColor = false;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// fitnessClubDataSet5
			// 
			this.fitnessClubDataSet5.DataSetName = "FitnessClubDataSet5";
			this.fitnessClubDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// видРасписаниеКраткоBindingSource
			// 
			this.видРасписаниеКраткоBindingSource.DataMember = "Вид_Расписание_Кратко";
			this.видРасписаниеКраткоBindingSource.DataSource = this.fitnessClubDataSet5;
			// 
			// вид_Расписание_КраткоTableAdapter
			// 
			this.вид_Расписание_КраткоTableAdapter.ClearBeforeFill = true;
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
			// AdminScheduleForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1353, 813);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dataGridView1);
			this.Name = "AdminScheduleForm";
			this.Text = "AdminScheduleForm";
			this.Load += new System.EventHandler(this.AdminScheduleForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fitnessClubDataSet5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.видРасписаниеКраткоBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label4;
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
    }
}