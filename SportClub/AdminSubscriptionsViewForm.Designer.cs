namespace SportClub
{
    partial class AdminSubscriptionsViewForm
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
			this.vIEW1FitnessClubDataSet = new SportClub.VIEW1FitnessClubDataSet();
			this.абонементыСКлиентамиBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.абонементы_С_КлиентамиTableAdapter = new SportClub.VIEW1FitnessClubDataSetTableAdapters.Абонементы_С_КлиентамиTableAdapter();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.fitnessClubDataSet2 = new SportClub.FitnessClubDataSet2();
			this.абонементыСКлиентамиBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.абонементы_С_КлиентамиTableAdapter1 = new SportClub.FitnessClubDataSet2TableAdapters.Абонементы_С_КлиентамиTableAdapter();
			this.iDАбонементаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.фИОклиентаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.количествозанятийDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.датаоформленияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.статусDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.button4 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.vIEW1FitnessClubDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.абонементыСКлиентамиBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fitnessClubDataSet2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.абонементыСКлиентамиBindingSource1)).BeginInit();
			this.SuspendLayout();
			// 
			// vIEW1FitnessClubDataSet
			// 
			this.vIEW1FitnessClubDataSet.DataSetName = "VIEW1FitnessClubDataSet";
			this.vIEW1FitnessClubDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// абонементыСКлиентамиBindingSource
			// 
			this.абонементыСКлиентамиBindingSource.DataMember = "Абонементы_С_Клиентами";
			this.абонементыСКлиентамиBindingSource.DataSource = this.vIEW1FitnessClubDataSet;
			// 
			// абонементы_С_КлиентамиTableAdapter
			// 
			this.абонементы_С_КлиентамиTableAdapter.ClearBeforeFill = true;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDАбонементаDataGridViewTextBoxColumn,
            this.фИОклиентаDataGridViewTextBoxColumn,
            this.количествозанятийDataGridViewTextBoxColumn,
            this.датаоформленияDataGridViewTextBoxColumn,
            this.статусDataGridViewTextBoxColumn});
			this.dataGridView1.DataSource = this.абонементыСКлиентамиBindingSource1;
			this.dataGridView1.Location = new System.Drawing.Point(12, 58);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(904, 439);
			this.dataGridView1.TabIndex = 0;
			// 
			// fitnessClubDataSet2
			// 
			this.fitnessClubDataSet2.DataSetName = "FitnessClubDataSet2";
			this.fitnessClubDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// абонементыСКлиентамиBindingSource1
			// 
			this.абонементыСКлиентамиBindingSource1.DataMember = "Абонементы_С_Клиентами";
			this.абонементыСКлиентамиBindingSource1.DataSource = this.fitnessClubDataSet2;
			// 
			// абонементы_С_КлиентамиTableAdapter1
			// 
			this.абонементы_С_КлиентамиTableAdapter1.ClearBeforeFill = true;
			// 
			// iDАбонементаDataGridViewTextBoxColumn
			// 
			this.iDАбонементаDataGridViewTextBoxColumn.DataPropertyName = "ID_Абонемента";
			this.iDАбонементаDataGridViewTextBoxColumn.HeaderText = "ID Абонемента";
			this.iDАбонементаDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.iDАбонементаDataGridViewTextBoxColumn.Name = "iDАбонементаDataGridViewTextBoxColumn";
			// 
			// фИОклиентаDataGridViewTextBoxColumn
			// 
			this.фИОклиентаDataGridViewTextBoxColumn.DataPropertyName = "ФИО_клиента";
			this.фИОклиентаDataGridViewTextBoxColumn.HeaderText = "ФИО";
			this.фИОклиентаDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.фИОклиентаDataGridViewTextBoxColumn.Name = "фИОклиентаDataGridViewTextBoxColumn";
			this.фИОклиентаDataGridViewTextBoxColumn.Width = 200;
			// 
			// количествозанятийDataGridViewTextBoxColumn
			// 
			this.количествозанятийDataGridViewTextBoxColumn.DataPropertyName = "Количество_занятий";
			this.количествозанятийDataGridViewTextBoxColumn.HeaderText = "Количество занятий";
			this.количествозанятийDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.количествозанятийDataGridViewTextBoxColumn.Name = "количествозанятийDataGridViewTextBoxColumn";
			// 
			// датаоформленияDataGridViewTextBoxColumn
			// 
			this.датаоформленияDataGridViewTextBoxColumn.DataPropertyName = "Дата_оформления";
			this.датаоформленияDataGridViewTextBoxColumn.HeaderText = "Дата оформления";
			this.датаоформленияDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.датаоформленияDataGridViewTextBoxColumn.Name = "датаоформленияDataGridViewTextBoxColumn";
			// 
			// статусDataGridViewTextBoxColumn
			// 
			this.статусDataGridViewTextBoxColumn.DataPropertyName = "Статус";
			this.статусDataGridViewTextBoxColumn.HeaderText = "Статус";
			this.статусDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.статусDataGridViewTextBoxColumn.Name = "статусDataGridViewTextBoxColumn";
			this.статусDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(854, 18);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(40, 25);
			this.button4.TabIndex = 5;
			this.button4.Text = "<-";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(23, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(168, 29);
			this.label1.TabIndex = 6;
			this.label1.Text = "Абонементы";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// AdminSubscriptionsViewForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(927, 510);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.dataGridView1);
			this.Name = "AdminSubscriptionsViewForm";
			this.Text = "AdminSubscriptionsView";
			this.Load += new System.EventHandler(this.AdminSubscriptionsViewForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.vIEW1FitnessClubDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.абонементыСКлиентамиBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fitnessClubDataSet2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.абонементыСКлиентамиBindingSource1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private VIEW1FitnessClubDataSet vIEW1FitnessClubDataSet;
        private System.Windows.Forms.BindingSource абонементыСКлиентамиBindingSource;
        private VIEW1FitnessClubDataSetTableAdapters.Абонементы_С_КлиентамиTableAdapter абонементы_С_КлиентамиTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private FitnessClubDataSet2 fitnessClubDataSet2;
        private System.Windows.Forms.BindingSource абонементыСКлиентамиBindingSource1;
        private FitnessClubDataSet2TableAdapters.Абонементы_С_КлиентамиTableAdapter абонементы_С_КлиентамиTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDАбонементаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn фИОклиентаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn количествозанятийDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаоформленияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn статусDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
    }
}