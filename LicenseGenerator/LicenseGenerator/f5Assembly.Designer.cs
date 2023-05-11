namespace LicenseGenerator
{
    partial class f5Assembly
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
            this.bPrint = new System.Windows.Forms.Button();
            this.bAnother = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbApplication = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bLicense = new System.Windows.Forms.Button();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.cbDuration = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSalesOrder = new System.Windows.Forms.TextBox();
            this.tbDongle = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bPrint
            // 
            this.bPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(250)))));
            this.bPrint.Location = new System.Drawing.Point(364, 549);
            this.bPrint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(290, 62);
            this.bPrint.TabIndex = 30;
            this.bPrint.Text = "Print License";
            this.bPrint.UseVisualStyleBackColor = false;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // bAnother
            // 
            this.bAnother.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.bAnother.Location = new System.Drawing.Point(56, 549);
            this.bAnother.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bAnother.Name = "bAnother";
            this.bAnother.Size = new System.Drawing.Size(300, 62);
            this.bAnother.TabIndex = 29;
            this.bAnother.Text = "Generate Another License";
            this.bAnother.UseVisualStyleBackColor = false;
            this.bAnother.Click += new System.EventHandler(this.bAnother_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 487);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 17);
            this.label6.TabIndex = 28;
            // 
            // cbApplication
            // 
            this.cbApplication.AccessibleDescription = "A";
            this.cbApplication.FormattingEnabled = true;
            this.cbApplication.Location = new System.Drawing.Point(187, 103);
            this.cbApplication.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbApplication.Name = "cbApplication";
            this.cbApplication.Size = new System.Drawing.Size(468, 24);
            this.cbApplication.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 107);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 17);
            this.label5.TabIndex = 26;
            this.label5.Text = "Application";
            // 
            // bLicense
            // 
            this.bLicense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(250)))), ((int)(((byte)(100)))));
            this.bLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLicense.Location = new System.Drawing.Point(51, 350);
            this.bLicense.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bLicense.Name = "bLicense";
            this.bLicense.Size = new System.Drawing.Size(605, 89);
            this.bLicense.TabIndex = 25;
            this.bLicense.Text = "Generate License";
            this.bLicense.UseVisualStyleBackColor = false;
            this.bLicense.Click += new System.EventHandler(this.bLicense_Click);
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "";
            this.dtpStart.Location = new System.Drawing.Point(187, 161);
            this.dtpStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(468, 23);
            this.dtpStart.TabIndex = 24;
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
            this.cbDuration.Location = new System.Drawing.Point(332, 218);
            this.cbDuration.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbDuration.Name = "cbDuration";
            this.cbDuration.Size = new System.Drawing.Size(322, 24);
            this.cbDuration.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 287);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Sales Order Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 222);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Duration";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 161);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "Start Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "DongleID";
            // 
            // tbSalesOrder
            // 
            this.tbSalesOrder.Location = new System.Drawing.Point(332, 283);
            this.tbSalesOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbSalesOrder.Name = "tbSalesOrder";
            this.tbSalesOrder.Size = new System.Drawing.Size(322, 23);
            this.tbSalesOrder.TabIndex = 18;
            // 
            // tbDongle
            // 
            this.tbDongle.Location = new System.Drawing.Point(332, 42);
            this.tbDongle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbDongle.Name = "tbDongle";
            this.tbDongle.Size = new System.Drawing.Size(322, 23);
            this.tbDongle.TabIndex = 17;
            // 
            // f5Assembly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(707, 652);
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
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "f5Assembly";
            this.Text = "f5Assembly";
            this.Load += new System.EventHandler(this.f5Assembly_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bPrint;
        private System.Windows.Forms.Button bAnother;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbApplication;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bLicense;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.ComboBox cbDuration;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSalesOrder;
        private System.Windows.Forms.TextBox tbDongle;
    }
}