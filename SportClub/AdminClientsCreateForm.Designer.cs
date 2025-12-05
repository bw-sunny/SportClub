namespace SportClub
{
    partial class AdminClientsCreateForm
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
			this.textBoxPhone = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBoxFIO
			// 
			this.textBoxFIO.Location = new System.Drawing.Point(192, 123);
			this.textBoxFIO.Name = "textBoxFIO";
			this.textBoxFIO.Size = new System.Drawing.Size(216, 22);
			this.textBoxFIO.TabIndex = 0;
			// 
			// textBoxPhone
			// 
			this.textBoxPhone.Location = new System.Drawing.Point(192, 154);
			this.textBoxPhone.Name = "textBoxPhone";
			this.textBoxPhone.Size = new System.Drawing.Size(216, 22);
			this.textBoxPhone.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(112, 126);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "ФИО:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(64, 157);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(122, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "Номер телефона:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(77, 190);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(109, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "Дата рождения:";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(192, 185);
			this.dateTimePicker1.MaxDate = new System.DateTime(2007, 12, 12, 0, 0, 0, 0);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(216, 22);
			this.dateTimePicker1.TabIndex = 6;
			this.dateTimePicker1.Value = new System.DateTime(2007, 1, 1, 0, 0, 0, 0);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(80, 232);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(156, 23);
			this.button1.TabIndex = 7;
			this.button1.Text = "Создать";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.button2.Location = new System.Drawing.Point(252, 232);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(156, 23);
			this.button2.TabIndex = 8;
			this.button2.Text = "Отмена";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// AdminClientsCreateForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(511, 399);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxPhone);
			this.Controls.Add(this.textBoxFIO);
			this.Name = "AdminClientsCreateForm";
			this.Text = "Создание клиента";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFIO;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}