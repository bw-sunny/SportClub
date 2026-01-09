namespace SportClub
{
    partial class AdminClientsEditForm
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
			this.textBoxId = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.textBoxFIO = new System.Windows.Forms.TextBox();
			this.textBoxPhone = new System.Windows.Forms.TextBox();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.buttonFind = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBoxId
			// 
			this.textBoxId.Location = new System.Drawing.Point(222, 26);
			this.textBoxId.Name = "textBoxId";
			this.textBoxId.Size = new System.Drawing.Size(79, 22);
			this.textBoxId.TabIndex = 0;
			this.textBoxId.TextChanged += new System.EventHandler(this.textBoxId_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(64, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(142, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Поиск по ID клиента:";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(134, 271);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(129, 35);
			this.button1.TabIndex = 2;
			this.button1.Text = "Редактировать";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.button2.Location = new System.Drawing.Point(267, 271);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(96, 35);
			this.button2.TabIndex = 3;
			this.button2.Text = "Отмена";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// textBoxFIO
			// 
			this.textBoxFIO.Location = new System.Drawing.Point(222, 126);
			this.textBoxFIO.Name = "textBoxFIO";
			this.textBoxFIO.Size = new System.Drawing.Size(200, 22);
			this.textBoxFIO.TabIndex = 4;
			// 
			// textBoxPhone
			// 
			this.textBoxPhone.Location = new System.Drawing.Point(222, 163);
			this.textBoxPhone.Name = "textBoxPhone";
			this.textBoxPhone.Size = new System.Drawing.Size(200, 22);
			this.textBoxPhone.TabIndex = 5;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(222, 200);
			this.dateTimePicker1.MaxDate = new System.DateTime(2007, 1, 1, 0, 0, 0, 0);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
			this.dateTimePicker1.TabIndex = 6;
			this.dateTimePicker1.Value = new System.DateTime(2005, 12, 12, 0, 0, 0, 0);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(121, 126);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 16);
			this.label2.TabIndex = 7;
			this.label2.Text = "ФИО:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(84, 166);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(122, 16);
			this.label3.TabIndex = 8;
			this.label3.Text = "Номер телефона:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(97, 205);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(109, 16);
			this.label4.TabIndex = 9;
			this.label4.Text = "Дата рождения:";
			// 
			// buttonFind
			// 
			this.buttonFind.Location = new System.Drawing.Point(307, 22);
			this.buttonFind.Name = "buttonFind";
			this.buttonFind.Size = new System.Drawing.Size(118, 31);
			this.buttonFind.TabIndex = 10;
			this.buttonFind.Text = "Найти";
			this.buttonFind.UseVisualStyleBackColor = true;
			this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
			// 
			// AdminClientsEditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(511, 399);
			this.Controls.Add(this.buttonFind);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.textBoxPhone);
			this.Controls.Add(this.textBoxFIO);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxId);
			this.Name = "AdminClientsEditForm";
			this.Text = "Редактирование клиента";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxFIO;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonFind;
    }
}