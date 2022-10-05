namespace CalibrationManager
{
    partial class f00_Start
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
            this.bSetup = new System.Windows.Forms.Button();
            this.bData = new System.Windows.Forms.Button();
            this.bReport = new System.Windows.Forms.Button();
            this.bEmail = new System.Windows.Forms.Button();
            this.bViewsReports = new System.Windows.Forms.Button();
            this.bBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bSetup
            // 
            this.bSetup.BackColor = System.Drawing.Color.DarkOrange;
            this.bSetup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSetup.Location = new System.Drawing.Point(57, 299);
            this.bSetup.Name = "bSetup";
            this.bSetup.Size = new System.Drawing.Size(325, 58);
            this.bSetup.TabIndex = 0;
            this.bSetup.Text = "ENTER SETUP";
            this.bSetup.UseVisualStyleBackColor = false;
            this.bSetup.Click += new System.EventHandler(this.bSetup_Click);
            // 
            // bData
            // 
            this.bData.BackColor = System.Drawing.Color.OrangeRed;
            this.bData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bData.Location = new System.Drawing.Point(57, 49);
            this.bData.Name = "bData";
            this.bData.Size = new System.Drawing.Size(325, 58);
            this.bData.TabIndex = 1;
            this.bData.Text = "ENTER DATA";
            this.bData.UseVisualStyleBackColor = false;
            this.bData.Click += new System.EventHandler(this.bData_Click);
            // 
            // bReport
            // 
            this.bReport.BackColor = System.Drawing.Color.Firebrick;
            this.bReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bReport.Location = new System.Drawing.Point(57, 136);
            this.bReport.Name = "bReport";
            this.bReport.Size = new System.Drawing.Size(325, 58);
            this.bReport.TabIndex = 2;
            this.bReport.Text = "VIEW DATA";
            this.bReport.UseVisualStyleBackColor = false;
            this.bReport.Click += new System.EventHandler(this.bReport_Click);
            // 
            // bEmail
            // 
            this.bEmail.BackColor = System.Drawing.Color.Red;
            this.bEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bEmail.Location = new System.Drawing.Point(57, 218);
            this.bEmail.Name = "bEmail";
            this.bEmail.Size = new System.Drawing.Size(325, 58);
            this.bEmail.TabIndex = 3;
            this.bEmail.Text = "EMAIL";
            this.bEmail.UseVisualStyleBackColor = false;
            this.bEmail.Click += new System.EventHandler(this.bEmail_Click);
            // 
            // bViewsReports
            // 
            this.bViewsReports.BackColor = System.Drawing.Color.Cyan;
            this.bViewsReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bViewsReports.Location = new System.Drawing.Point(57, 382);
            this.bViewsReports.Name = "bViewsReports";
            this.bViewsReports.Size = new System.Drawing.Size(325, 58);
            this.bViewsReports.TabIndex = 4;
            this.bViewsReports.Text = "VIEWS  /  REPORTS";
            this.bViewsReports.UseVisualStyleBackColor = false;
            this.bViewsReports.Click += new System.EventHandler(this.bViewsReports_Click);
            // 
            // bBack
            // 
            this.bBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(50)))));
            this.bBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBack.Location = new System.Drawing.Point(415, 49);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(59, 390);
            this.bBack.TabIndex = 5;
            this.bBack.Text = "E X  I  T";
            this.bBack.UseVisualStyleBackColor = false;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // f00_Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(501, 477);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.bViewsReports);
            this.Controls.Add(this.bEmail);
            this.Controls.Add(this.bReport);
            this.Controls.Add(this.bData);
            this.Controls.Add(this.bSetup);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "f00_Start";
            this.Text = "f00_Start";
            this.Load += new System.EventHandler(this.f00_Start_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bSetup;
        private System.Windows.Forms.Button bData;
        private System.Windows.Forms.Button bReport;
        private System.Windows.Forms.Button bEmail;
        private System.Windows.Forms.Button bViewsReports;
        private System.Windows.Forms.Button bBack;
    }
}