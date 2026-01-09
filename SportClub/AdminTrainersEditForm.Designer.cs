namespace SportClub
{
    partial class AdminTrainersEditForm
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
			this.textBoxFIO = new System.Windows.Forms.TextBox();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.comboBoxQualification = new System.Windows.Forms.ComboBox();
			this.textBoxId = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBoxFIO
			// 
			this.textBoxFIO.Location = new System.Drawing.Point(196, 159);
			this.textBoxFIO.Name = "textBoxFIO";
			this.textBoxFIO.Size = new System.Drawing.Size(210, 22);
			this.textBoxFIO.TabIndex = 0;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(196, 187);
			this.dateTimePicker1.MaxDate = new System.DateTime(2007, 1, 1, 0, 0, 0, 0);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(210, 22);
			this.dateTimePicker1.TabIndex = 1;
			this.dateTimePicker1.Value = new System.DateTime(2007, 1, 1, 0, 0, 0, 0);
			// 
			// comboBoxQualification
			// 
			this.comboBoxQualification.FormattingEnabled = true;
			this.comboBoxQualification.Items.AddRange(new object[] {
            "Стажер",
            "Сертифицированный тренер",
            "Профессиональный тренер"});
			this.comboBoxQualification.Location = new System.Drawing.Point(166, 215);
			this.comboBoxQualification.Name = "comboBoxQualification";
			this.comboBoxQualification.Size = new System.Drawing.Size(240, 24);
			this.comboBoxQualification.TabIndex = 2;
			// 
			// textBoxId
			// 
			this.textBoxId.Location = new System.Drawing.Point(187, 36);
			this.textBoxId.Name = "textBoxId";
			this.textBoxId.Size = new System.Drawing.Size(73, 22);
			this.textBoxId.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(148, 39);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(23, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "ID:";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(101, 162);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "ФИО:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(72, 192);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(109, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "Дата рождения:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(51, 218);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(107, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "Квалификация:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(266, 32);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 31);
			this.button1.TabIndex = 8;
			this.button1.Text = "Найти";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(118, 301);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(109, 35);
			this.button2.TabIndex = 9;
			this.button2.Text = "Сохранить";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.button3.Location = new System.Drawing.Point(282, 301);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(111, 35);
			this.button3.TabIndex = 10;
			this.button3.Text = "Отмена";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// AdminTrainersEditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(511, 399);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxId);
			this.Controls.Add(this.comboBoxQualification);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.textBoxFIO);
			this.Name = "AdminTrainersEditForm";
			this.Text = "Редактирование тренера";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFIO;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBoxQualification;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}