namespace ExcelData
{
    partial class Form1
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
            this.bCloseExcl = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(100)))));
            this.button1.Location = new System.Drawing.Point(83, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 101);
            this.button1.TabIndex = 0;
            this.button1.Text = "PPS";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(250)))), ((int)(((byte)(100)))));
            this.button2.Location = new System.Drawing.Point(248, 66);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 101);
            this.button2.TabIndex = 1;
            this.button2.Text = "G+R 2012";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // bCloseExcl
            // 
            this.bCloseExcl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(250)))), ((int)(((byte)(100)))));
            this.bCloseExcl.Location = new System.Drawing.Point(164, 207);
            this.bCloseExcl.Name = "bCloseExcl";
            this.bCloseExcl.Size = new System.Drawing.Size(104, 64);
            this.bCloseExcl.TabIndex = 2;
            this.bCloseExcl.Text = "Close Programs";
            this.bCloseExcl.UseVisualStyleBackColor = false;
            this.bCloseExcl.Click += new System.EventHandler(this.bCloseExcl_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(100)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(456, 315);
            this.Controls.Add(this.bCloseExcl);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button bCloseExcl;
    }
}

