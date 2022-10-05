namespace CalibrationManager
{
    partial class CustomerOwned_Equipment
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
            this.LCustomer = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cbCustomer = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // LCustomer
            // 
            this.LCustomer.AutoSize = true;
            this.LCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCustomer.Location = new System.Drawing.Point(54, 49);
            this.LCustomer.Name = "LCustomer";
            this.LCustomer.Size = new System.Drawing.Size(147, 20);
            this.LCustomer.TabIndex = 0;
            this.LCustomer.Text = "Select Customer:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(180)))), ((int)(((byte)(0)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(53, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(321, 45);
            this.button1.TabIndex = 2;
            this.button1.Text = "Get Customer Owned Equipment List";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbCustomer
            // 
            this.cbCustomer.FormattingEnabled = true;
            this.cbCustomer.Location = new System.Drawing.Point(53, 102);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(320, 28);
            this.cbCustomer.TabIndex = 3;
            // 
            // CustomerOwned_Equipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(40)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(438, 270);
            this.Controls.Add(this.cbCustomer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LCustomer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CustomerOwned_Equipment";
            this.Text = "Customer Owned Equipment";
            this.Load += new System.EventHandler(this.CustomerOwned_Equipment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LCustomer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbCustomer;
    }
}