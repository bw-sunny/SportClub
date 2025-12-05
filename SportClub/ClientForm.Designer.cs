namespace SportClub
{
    partial class ClientForm
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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(33, 82);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(163, 34);
			this.button1.TabIndex = 0;
			this.button1.Text = "Расписание";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(217, 82);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(157, 34);
			this.button2.TabIndex = 1;
			this.button2.Text = "Записаться";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(49, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(101, 29);
			this.label1.TabIndex = 2;
			this.label1.Text = "Клиент";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(709, 12);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(40, 25);
			this.button4.TabIndex = 6;
			this.button4.Text = "<-";
			this.button4.UseVisualStyleBackColor = true;
			// 
			// ClientForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "ClientForm";
			this.Text = "ClientForm";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
    }
}