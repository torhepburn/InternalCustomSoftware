namespace PPS_PD_Label
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bPrint = new System.Windows.Forms.Button();
            this.tbPDNumber = new System.Windows.Forms.TextBox();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.rb4 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // bPrint
            // 
            this.bPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(180)))), ((int)(((byte)(60)))));
            this.bPrint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bPrint.Location = new System.Drawing.Point(335, 156);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(162, 57);
            this.bPrint.TabIndex = 0;
            this.bPrint.Text = "PRINT LABEL";
            this.bPrint.UseVisualStyleBackColor = false;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // tbPDNumber
            // 
            this.tbPDNumber.Location = new System.Drawing.Point(58, 176);
            this.tbPDNumber.Name = "tbPDNumber";
            this.tbPDNumber.Size = new System.Drawing.Size(181, 23);
            this.tbPDNumber.TabIndex = 1;
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rb1.Location = new System.Drawing.Point(81, 36);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(118, 25);
            this.rb1.TabIndex = 2;
            this.rb1.TabStop = true;
            this.rb1.Text = "Print 1 Each";
            this.rb1.UseVisualStyleBackColor = true;
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rb2.Location = new System.Drawing.Point(81, 67);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(118, 25);
            this.rb2.TabIndex = 3;
            this.rb2.TabStop = true;
            this.rb2.Text = "Print 2 Each";
            this.rb2.UseVisualStyleBackColor = true;
            // 
            // rb3
            // 
            this.rb3.AutoSize = true;
            this.rb3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rb3.Location = new System.Drawing.Point(276, 36);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(118, 25);
            this.rb3.TabIndex = 4;
            this.rb3.TabStop = true;
            this.rb3.Text = "Print 3 Each";
            this.rb3.UseVisualStyleBackColor = true;
            // 
            // rb4
            // 
            this.rb4.AutoSize = true;
            this.rb4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rb4.Location = new System.Drawing.Point(276, 67);
            this.rb4.Name = "rb4";
            this.rb4.Size = new System.Drawing.Size(118, 25);
            this.rb4.TabIndex = 5;
            this.rb4.TabStop = true;
            this.rb4.Text = "Print 4 Each";
            this.rb4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(110)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(538, 248);
            this.Controls.Add(this.rb4);
            this.Controls.Add(this.rb3);
            this.Controls.Add(this.rb2);
            this.Controls.Add(this.rb1);
            this.Controls.Add(this.tbPDNumber);
            this.Controls.Add(this.bPrint);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bPrint;
        private System.Windows.Forms.TextBox tbPDNumber;
        private System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.RadioButton rb2;
        private System.Windows.Forms.RadioButton rb3;
        private System.Windows.Forms.RadioButton rb4;
    }
}
