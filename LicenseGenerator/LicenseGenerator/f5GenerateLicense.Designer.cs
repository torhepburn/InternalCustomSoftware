namespace LicenseGenerator
{
    partial class f5GenerateLicense
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
            this.tbDongle = new System.Windows.Forms.TextBox();
            this.tbSalesOrder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbDuration = new System.Windows.Forms.ComboBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.bLicense = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbApplication = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bAnother = new System.Windows.Forms.Button();
            this.bPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbDongle
            // 
            this.tbDongle.Location = new System.Drawing.Point(255, 40);
            this.tbDongle.Name = "tbDongle";
            this.tbDongle.Size = new System.Drawing.Size(204, 26);
            this.tbDongle.TabIndex = 0;
            // 
            // tbSalesOrder
            // 
            this.tbSalesOrder.Location = new System.Drawing.Point(255, 236);
            this.tbSalesOrder.Name = "tbSalesOrder";
            this.tbSalesOrder.Size = new System.Drawing.Size(204, 26);
            this.tbSalesOrder.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "DongleID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Start Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Duration";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Sales Order Number";
            // 
            // cbDuration
            // 
            this.cbDuration.FormattingEnabled = true;
            this.cbDuration.Items.AddRange(new object[] {
            "14 Days",
            "30 Days",
            "60 Days",
            "90 Days",
            "120 Days",
            "6 Months",
            "9 Months",
            "1 Year",
            "3 Years",
            "5 Years",
            "10 Years",
            "15 Years",
            "20 Years",
            "21 Years"});
            this.cbDuration.Location = new System.Drawing.Point(255, 183);
            this.cbDuration.Name = "cbDuration";
            this.cbDuration.Size = new System.Drawing.Size(204, 28);
            this.cbDuration.TabIndex = 8;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "";
            this.dtpStart.Location = new System.Drawing.Point(146, 137);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(313, 26);
            this.dtpStart.TabIndex = 9;
            // 
            // bLicense
            // 
            this.bLicense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(250)))), ((int)(((byte)(100)))));
            this.bLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLicense.Location = new System.Drawing.Point(44, 290);
            this.bLicense.Name = "bLicense";
            this.bLicense.Size = new System.Drawing.Size(415, 72);
            this.bLicense.TabIndex = 10;
            this.bLicense.Text = "Generate License";
            this.bLicense.UseVisualStyleBackColor = false;
            this.bLicense.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Application";
            // 
            // cbApplication
            // 
            this.cbApplication.AccessibleDescription = "A";
            this.cbApplication.FormattingEnabled = true;
            this.cbApplication.Location = new System.Drawing.Point(146, 90);
            this.cbApplication.Name = "cbApplication";
            this.cbApplication.Size = new System.Drawing.Size(313, 28);
            this.cbApplication.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 402);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 20);
            this.label6.TabIndex = 14;
            // 
            // bAnother
            // 
            this.bAnother.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.bAnother.Location = new System.Drawing.Point(48, 452);
            this.bAnother.Name = "bAnother";
            this.bAnother.Size = new System.Drawing.Size(182, 50);
            this.bAnother.TabIndex = 15;
            this.bAnother.Text = "Generate Another License";
            this.bAnother.UseVisualStyleBackColor = false;
            this.bAnother.Click += new System.EventHandler(this.bAnother_Click);
            // 
            // bPrint
            // 
            this.bPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(250)))));
            this.bPrint.Location = new System.Drawing.Point(277, 452);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(182, 50);
            this.bPrint.TabIndex = 16;
            this.bPrint.Text = "Print License";
            this.bPrint.UseVisualStyleBackColor = false;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // f5GenerateLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(497, 523);
            this.Controls.Add(this.bPrint);
            this.Controls.Add(this.bAnother);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbApplication);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bLicense);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.cbDuration);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSalesOrder);
            this.Controls.Add(this.tbDongle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "f5GenerateLicense";
            this.Text = "Make License";
            this.Load += new System.EventHandler(this.Test_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDongle;
        private System.Windows.Forms.TextBox tbSalesOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbDuration;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Button bLicense;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbApplication;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bAnother;
        private System.Windows.Forms.Button bPrint;
    }
}