namespace SportClub
{
    partial class AdminTrainingAllForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminTrainingAllForm));
			this.fitnessClubDataSet3 = new SportClub.FitnessClubDataSet3();
			this.видТренировкиСТренерамиBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.вид_Тренировки_С_ТренерамиTableAdapter = new SportClub.FitnessClubDataSet3TableAdapters.Вид_Тренировки_С_ТренерамиTableAdapter();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.button6 = new System.Windows.Forms.Button();
			this.iDТренировкиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.названиетренировкиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.длительностьDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.залDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.фИОтренераDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.fitnessClubDataSet3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.видТренировкиСТренерамиBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// fitnessClubDataSet3
			// 
			this.fitnessClubDataSet3.DataSetName = "FitnessClubDataSet3";
			this.fitnessClubDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// видТренировкиСТренерамиBindingSource
			// 
			this.видТренировкиСТренерамиBindingSource.DataMember = "Вид_Тренировки_С_Тренерами";
			this.видТренировкиСТренерамиBindingSource.DataSource = this.fitnessClubDataSet3;
			// 
			// вид_Тренировки_С_ТренерамиTableAdapter
			// 
			this.вид_Тренировки_С_ТренерамиTableAdapter.ClearBeforeFill = true;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDТренировкиDataGridViewTextBoxColumn,
            this.названиетренировкиDataGridViewTextBoxColumn,
            this.длительностьDataGridViewTextBoxColumn,
            this.залDataGridViewTextBoxColumn,
            this.фИОтренераDataGridViewTextBoxColumn});
			this.dataGridView1.DataSource = this.видТренировкиСТренерамиBindingSource;
			this.dataGridView1.Location = new System.Drawing.Point(12, 156);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(836, 310);
			this.dataGridView1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 76);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(107, 32);
			this.button1.TabIndex = 1;
			this.button1.Text = "Создать";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(125, 76);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(144, 32);
			this.button2.TabIndex = 2;
			this.button2.Text = "Редактировать";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.button3.Location = new System.Drawing.Point(275, 76);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(108, 32);
			this.button3.TabIndex = 3;
			this.button3.Text = "Удалить";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(769, 12);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(47, 32);
			this.button4.TabIndex = 4;
			this.button4.Text = "<-";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(12, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(209, 29);
			this.label1.TabIndex = 5;
			this.label1.Text = "Все тренировки";
			// 
			// button6
			// 
			this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
			this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.button6.Location = new System.Drawing.Point(807, 114);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(40, 36);
			this.button6.TabIndex = 13;
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// iDТренировкиDataGridViewTextBoxColumn
			// 
			this.iDТренировкиDataGridViewTextBoxColumn.DataPropertyName = "ID_Тренировки";
			this.iDТренировкиDataGridViewTextBoxColumn.HeaderText = "ID";
			this.iDТренировкиDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.iDТренировкиDataGridViewTextBoxColumn.Name = "iDТренировкиDataGridViewTextBoxColumn";
			this.iDТренировкиDataGridViewTextBoxColumn.Width = 50;
			// 
			// названиетренировкиDataGridViewTextBoxColumn
			// 
			this.названиетренировкиDataGridViewTextBoxColumn.DataPropertyName = "Название_тренировки";
			this.названиетренировкиDataGridViewTextBoxColumn.HeaderText = "Название";
			this.названиетренировкиDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.названиетренировкиDataGridViewTextBoxColumn.Name = "названиетренировкиDataGridViewTextBoxColumn";
			this.названиетренировкиDataGridViewTextBoxColumn.Width = 125;
			// 
			// длительностьDataGridViewTextBoxColumn
			// 
			this.длительностьDataGridViewTextBoxColumn.DataPropertyName = "Длительность";
			this.длительностьDataGridViewTextBoxColumn.HeaderText = "Длительность";
			this.длительностьDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.длительностьDataGridViewTextBoxColumn.Name = "длительностьDataGridViewTextBoxColumn";
			this.длительностьDataGridViewTextBoxColumn.Width = 50;
			// 
			// залDataGridViewTextBoxColumn
			// 
			this.залDataGridViewTextBoxColumn.DataPropertyName = "Зал";
			this.залDataGridViewTextBoxColumn.HeaderText = "Зал";
			this.залDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.залDataGridViewTextBoxColumn.Name = "залDataGridViewTextBoxColumn";
			this.залDataGridViewTextBoxColumn.Width = 125;
			// 
			// фИОтренераDataGridViewTextBoxColumn
			// 
			this.фИОтренераDataGridViewTextBoxColumn.DataPropertyName = "ФИО_тренера";
			this.фИОтренераDataGridViewTextBoxColumn.HeaderText = "Тренер";
			this.фИОтренераDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.фИОтренераDataGridViewTextBoxColumn.Name = "фИОтренераDataGridViewTextBoxColumn";
			this.фИОтренераDataGridViewTextBoxColumn.Width = 200;
			// 
			// AdminTrainingAllForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(859, 478);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dataGridView1);
			this.Name = "AdminTrainingAllForm";
			this.Text = "AdminTrainingAllForm";
			this.Load += new System.EventHandler(this.AdminTrainingAllForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.fitnessClubDataSet3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.видТренировкиСТренерамиBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private FitnessClubDataSet3 fitnessClubDataSet3;
        private System.Windows.Forms.BindingSource видТренировкиСТренерамиBindingSource;
        private FitnessClubDataSet3TableAdapters.Вид_Тренировки_С_ТренерамиTableAdapter вид_Тренировки_С_ТренерамиTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDТренировкиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn названиетренировкиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn длительностьDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn залDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn фИОтренераDataGridViewTextBoxColumn;
    }
}