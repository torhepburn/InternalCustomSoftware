namespace RMAX_TAB_A
{
    partial class F13_Op90
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
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label25 = new System.Windows.Forms.Label();
            this.tbInsp = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.bEnterData = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LserialNumber = new System.Windows.Forms.Label();
            this.cbDataSaved = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "MM/dd/yyyy";
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(712, 232);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(102, 24);
            this.dtpDate.TabIndex = 238;
            this.dtpDate.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(265, 235);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(25, 13);
            this.label25.TabIndex = 234;
            this.label25.Text = "Yes";
            // 
            // tbInsp
            // 
            this.tbInsp.Location = new System.Drawing.Point(575, 232);
            this.tbInsp.Name = "tbInsp";
            this.tbInsp.Size = new System.Drawing.Size(100, 26);
            this.tbInsp.TabIndex = 233;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(93, 230);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(93, 20);
            this.label26.TabIndex = 232;
            this.label26.Text = "Data Saved";
            // 
            // bEnterData
            // 
            this.bEnterData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(150)))), ((int)(((byte)(50)))));
            this.bEnterData.Location = new System.Drawing.Point(90, 286);
            this.bEnterData.Name = "bEnterData";
            this.bEnterData.Size = new System.Drawing.Size(662, 62);
            this.bEnterData.TabIndex = 231;
            this.bEnterData.Text = "ENTER DATA";
            this.bEnterData.UseVisualStyleBackColor = false;
            this.bEnterData.Click += new System.EventHandler(this.bEnterData_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(708, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 20);
            this.label7.TabIndex = 230;
            this.label7.Text = "Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(580, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.TabIndex = 229;
            this.label6.Text = "Inspector";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(474, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 228;
            this.label5.Text = "Actual";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(265, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 13);
            this.label4.TabIndex = 227;
            this.label4.Text = "Nominal       (-)        (+)     Units";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 226;
            this.label3.Text = "Requirement";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 20);
            this.label2.TabIndex = 225;
            this.label2.Text = "Dimensional Inspection";
            // 
            // LserialNumber
            // 
            this.LserialNumber.AutoSize = true;
            this.LserialNumber.Location = new System.Drawing.Point(74, 70);
            this.LserialNumber.Name = "LserialNumber";
            this.LserialNumber.Size = new System.Drawing.Size(51, 20);
            this.LserialNumber.TabIndex = 224;
            this.LserialNumber.Text = "label1";
            // 
            // cbDataSaved
            // 
            this.cbDataSaved.AutoSize = true;
            this.cbDataSaved.Location = new System.Drawing.Point(454, 235);
            this.cbDataSaved.Name = "cbDataSaved";
            this.cbDataSaved.Size = new System.Drawing.Size(56, 24);
            this.cbDataSaved.TabIndex = 239;
            this.cbDataSaved.Text = "Yes";
            this.cbDataSaved.UseVisualStyleBackColor = true;
            // 
            // F13_Op90
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(180)))), ((int)(((byte)(150)))));
            this.ClientSize = new System.Drawing.Size(888, 418);
            this.Controls.Add(this.cbDataSaved);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.tbInsp);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.bEnterData);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LserialNumber);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F13_Op90";
            this.Text = "F13_Op90";
            this.Load += new System.EventHandler(this.F13_Op90_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox tbInsp;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button bEnterData;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LserialNumber;
        private System.Windows.Forms.CheckBox cbDataSaved;
    }
}