namespace AuditReportRevenue
{
    partial class F3_ClosingBalance
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
            this.Lbalance = new System.Windows.Forms.Label();
            this.Bexport = new System.Windows.Forms.Button();
            this.Bexit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Lbalance
            // 
            this.Lbalance.AutoSize = true;
            this.Lbalance.Location = new System.Drawing.Point(29, 38);
            this.Lbalance.Name = "Lbalance";
            this.Lbalance.Size = new System.Drawing.Size(125, 17);
            this.Lbalance.TabIndex = 0;
            this.Lbalance.Text = "Closing Balance = ";
            // 
            // Bexport
            // 
            this.Bexport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(180)))), ((int)(((byte)(20)))));
            this.Bexport.Location = new System.Drawing.Point(32, 102);
            this.Bexport.Name = "Bexport";
            this.Bexport.Size = new System.Drawing.Size(219, 74);
            this.Bexport.TabIndex = 1;
            this.Bexport.Text = "EXPORT TO EXCEL";
            this.Bexport.UseVisualStyleBackColor = false;
            this.Bexport.Click += new System.EventHandler(this.Bexport_Click);
            // 
            // Bexit
            // 
            this.Bexit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(180)))), ((int)(((byte)(20)))));
            this.Bexit.Location = new System.Drawing.Point(32, 206);
            this.Bexit.Name = "Bexit";
            this.Bexit.Size = new System.Drawing.Size(219, 74);
            this.Bexit.TabIndex = 2;
            this.Bexit.Text = "EXIT";
            this.Bexit.UseVisualStyleBackColor = false;
            this.Bexit.Click += new System.EventHandler(this.Bexit_Click);
            // 
            // F3_ClosingBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(70)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(287, 322);
            this.Controls.Add(this.Bexit);
            this.Controls.Add(this.Bexport);
            this.Controls.Add(this.Lbalance);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "F3_ClosingBalance";
            this.Text = "F3_ClosingBalance";
            this.Load += new System.EventHandler(this.F3_ClosingBalance_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbalance;
        private System.Windows.Forms.Button Bexport;
        private System.Windows.Forms.Button Bexit;
    }
}