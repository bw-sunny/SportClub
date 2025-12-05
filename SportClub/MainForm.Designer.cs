namespace SportClub
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.Login = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(205, 169);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(194, 71);
			this.button1.TabIndex = 0;
			this.button1.Text = "Администратор";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(205, 246);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(194, 67);
			this.button2.TabIndex = 1;
			this.button2.Text = "Тренер";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(205, 319);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(194, 71);
			this.button3.TabIndex = 2;
			this.button3.Text = "Клиент";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// Login
			// 
			this.Login.Location = new System.Drawing.Point(205, 70);
			this.Login.Name = "Login";
			this.Login.Size = new System.Drawing.Size(194, 22);
			this.Login.TabIndex = 3;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(616, 501);
			this.Controls.Add(this.Login);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "MainForm";
			this.Text = "Главное меню";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox Login;
    }
}

