namespace AuditRevenuesExcel2010
{
    partial class Form3
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
            this.Bexit = new System.Windows.Forms.Button();
            this.Bexport = new System.Windows.Forms.Button();
            this.Lbalance = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Bexit
            // 
            this.Bexit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(180)))), ((int)(((byte)(20)))));
            this.Bexit.Location = new System.Drawing.Point(50, 205);
            this.Bexit.Name = "Bexit";
            this.Bexit.Size = new System.Drawing.Size(219, 74);
            this.Bexit.TabIndex = 5;
            this.Bexit.Text = "EXIT";
            this.Bexit.UseVisualStyleBackColor = false;
            this.Bexit.Click += new System.EventHandler(this.Bexit_Click);
            // 
            // Bexport
            // 
            this.Bexport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(180)))), ((int)(((byte)(20)))));
            this.Bexport.Location = new System.Drawing.Point(50, 101);
            this.Bexport.Name = "Bexport";
            this.Bexport.Size = new System.Drawing.Size(219, 74);
            this.Bexport.TabIndex = 4;
            this.Bexport.Text = "EXPORT TO EXCEL";
            this.Bexport.UseVisualStyleBackColor = false;
            this.Bexport.Click += new System.EventHandler(this.Bexport_Click);
            // 
            // Lbalance
            // 
            this.Lbalance.AutoSize = true;
            this.Lbalance.Location = new System.Drawing.Point(47, 37);
            this.Lbalance.Name = "Lbalance";
            this.Lbalance.Size = new System.Drawing.Size(95, 13);
            this.Lbalance.TabIndex = 3;
            this.Lbalance.Text = "Closing Balance = ";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 326);
            this.Controls.Add(this.Bexit);
            this.Controls.Add(this.Bexport);
            this.Controls.Add(this.Lbalance);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Bexit;
        private System.Windows.Forms.Button Bexport;
        private System.Windows.Forms.Label Lbalance;
    }
}