namespace SportClub
{
    partial class AdminTrainerForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminTrainerForm));
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.iDТренераDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.фИОDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.датарожденияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.квалификацияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.тренерыBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.fitnessClubDataSet1 = new SportClub.FitnessClubDataSet1();
			this.тренерыTableAdapter = new SportClub.FitnessClubDataSet1TableAdapters.ТренерыTableAdapter();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.тренерыBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fitnessClubDataSet1)).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(146, 131);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(147, 36);
			this.button3.TabIndex = 6;
			this.button3.Text = "Редактировать";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.button2.Location = new System.Drawing.Point(299, 131);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(100, 36);
			this.button2.TabIndex = 5;
			this.button2.Text = "Удалить";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(40, 131);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(100, 36);
			this.button1.TabIndex = 4;
			this.button1.Text = "Создать";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button6
			// 
			this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
			this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.button6.Location = new System.Drawing.Point(782, 131);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(40, 36);
			this.button6.TabIndex = 12;
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(782, 23);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(40, 25);
			this.button4.TabIndex = 11;
			this.button4.Text = "<-";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(57, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(121, 29);
			this.label1.TabIndex = 13;
			this.label1.Text = "Тренеры";
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.AntiqueWhite;
			this.groupBox1.Controls.Add(this.radioButton4);
			this.groupBox1.Controls.Add(this.radioButton3);
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Location = new System.Drawing.Point(41, 62);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(674, 50);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Фильтр:";
			// 
			// radioButton4
			// 
			this.radioButton4.AutoSize = true;
			this.radioButton4.Location = new System.Drawing.Point(444, 21);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(209, 20);
			this.radioButton4.TabIndex = 18;
			this.radioButton4.TabStop = true;
			this.radioButton4.Text = "Профессиональный тренер";
			this.radioButton4.UseVisualStyleBackColor = true;
			this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(198, 21);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(218, 20);
			this.radioButton3.TabIndex = 17;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "Сертифицированный тренер";
			this.radioButton3.UseVisualStyleBackColor = true;
			this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(95, 21);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(77, 20);
			this.radioButton2.TabIndex = 16;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "Стажер";
			this.radioButton2.UseVisualStyleBackColor = true;
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(21, 21);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(52, 20);
			this.radioButton1.TabIndex = 15;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Все";
			this.radioButton1.UseVisualStyleBackColor = true;
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDТренераDataGridViewTextBoxColumn,
            this.фИОDataGridViewTextBoxColumn,
            this.датарожденияDataGridViewTextBoxColumn,
            this.квалификацияDataGridViewTextBoxColumn});
			this.dataGridView1.DataSource = this.тренерыBindingSource;
			this.dataGridView1.Location = new System.Drawing.Point(40, 185);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(815, 253);
			this.dataGridView1.TabIndex = 15;
			// 
			// iDТренераDataGridViewTextBoxColumn
			// 
			this.iDТренераDataGridViewTextBoxColumn.DataPropertyName = "ID_Тренера";
			this.iDТренераDataGridViewTextBoxColumn.HeaderText = "ID";
			this.iDТренераDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.iDТренераDataGridViewTextBoxColumn.Name = "iDТренераDataGridViewTextBoxColumn";
			this.iDТренераDataGridViewTextBoxColumn.Width = 50;
			// 
			// фИОDataGridViewTextBoxColumn
			// 
			this.фИОDataGridViewTextBoxColumn.DataPropertyName = "ФИО";
			this.фИОDataGridViewTextBoxColumn.HeaderText = "ФИО";
			this.фИОDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.фИОDataGridViewTextBoxColumn.Name = "фИОDataGridViewTextBoxColumn";
			this.фИОDataGridViewTextBoxColumn.Width = 200;
			// 
			// датарожденияDataGridViewTextBoxColumn
			// 
			this.датарожденияDataGridViewTextBoxColumn.DataPropertyName = "Дата_рождения";
			this.датарожденияDataGridViewTextBoxColumn.HeaderText = "Дата_рождения";
			this.датарожденияDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.датарожденияDataGridViewTextBoxColumn.Name = "датарожденияDataGridViewTextBoxColumn";
			this.датарожденияDataGridViewTextBoxColumn.Width = 120;
			// 
			// квалификацияDataGridViewTextBoxColumn
			// 
			this.квалификацияDataGridViewTextBoxColumn.DataPropertyName = "Квалификация";
			this.квалификацияDataGridViewTextBoxColumn.HeaderText = "Квалификация";
			this.квалификацияDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.квалификацияDataGridViewTextBoxColumn.Name = "квалификацияDataGridViewTextBoxColumn";
			this.квалификацияDataGridViewTextBoxColumn.Width = 150;
			// 
			// тренерыBindingSource
			// 
			this.тренерыBindingSource.DataMember = "Тренеры";
			this.тренерыBindingSource.DataSource = this.fitnessClubDataSet1;
			// 
			// fitnessClubDataSet1
			// 
			this.fitnessClubDataSet1.DataSetName = "FitnessClubDataSet1";
			this.fitnessClubDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// тренерыTableAdapter
			// 
			this.тренерыTableAdapter.ClearBeforeFill = true;
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 470);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(901, 26);
			this.statusStrip1.TabIndex = 16;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(121, 20);
			this.toolStripStatusLabel1.Text = "Всего тренеров:";
			this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
			// 
			// AdminTrainerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(901, 496);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "AdminTrainerForm";
			this.Text = "Администратор - Тренеры";
			this.Load += new System.EventHandler(this.AdminTrainerForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.тренерыBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fitnessClubDataSet1)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private FitnessClubDataSet1 fitnessClubDataSet1;
        private System.Windows.Forms.BindingSource тренерыBindingSource;
        private FitnessClubDataSet1TableAdapters.ТренерыTableAdapter тренерыTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDТренераDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn фИОDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датарожденияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn квалификацияDataGridViewTextBoxColumn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}