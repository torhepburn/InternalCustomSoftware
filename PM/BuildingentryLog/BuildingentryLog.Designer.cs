namespace BuildingentryLog
{
    partial class BuildingentryLog
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCovidTestDate = new System.Windows.Forms.TextBox();
            this.cbddEmployees = new System.Windows.Forms.ComboBox();
            this.dtpCovidTestDate = new System.Windows.Forms.DateTimePicker();
            this.tbEmployeeNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlValid = new System.Windows.Forms.Panel();
            this.cbValidCovidTest = new System.Windows.Forms.CheckBox();
            this.rbHigh = new System.Windows.Forms.RadioButton();
            this.rbPass = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.bSave = new System.Windows.Forms.Button();
            this.cbDisplayCalendar = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbddContractors = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbddContact = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbCompany = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(213, 234);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(232, 17);
            this.label5.TabIndex = 34;
            this.label5.Text = "Current COVID Test Date on record";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 122);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 17);
            this.label4.TabIndex = 33;
            this.label4.Text = "Employee Name";
            // 
            // tbCovidTestDate
            // 
            this.tbCovidTestDate.Location = new System.Drawing.Point(459, 231);
            this.tbCovidTestDate.Margin = new System.Windows.Forms.Padding(4);
            this.tbCovidTestDate.Name = "tbCovidTestDate";
            this.tbCovidTestDate.ReadOnly = true;
            this.tbCovidTestDate.Size = new System.Drawing.Size(271, 23);
            this.tbCovidTestDate.TabIndex = 32;
            // 
            // cbddEmployees
            // 
            this.cbddEmployees.FormattingEnabled = true;
            this.cbddEmployees.Location = new System.Drawing.Point(219, 119);
            this.cbddEmployees.Name = "cbddEmployees";
            this.cbddEmployees.Size = new System.Drawing.Size(264, 24);
            this.cbddEmployees.TabIndex = 31;
            this.cbddEmployees.SelectedIndexChanged += new System.EventHandler(this.cbddEmployees_SelectedIndexChanged);
            // 
            // dtpCovidTestDate
            // 
            this.dtpCovidTestDate.Location = new System.Drawing.Point(414, 328);
            this.dtpCovidTestDate.Name = "dtpCovidTestDate";
            this.dtpCovidTestDate.Size = new System.Drawing.Size(271, 23);
            this.dtpCovidTestDate.TabIndex = 29;
            this.dtpCovidTestDate.Visible = false;
            this.dtpCovidTestDate.ValueChanged += new System.EventHandler(this.dtpCovidTestDate_ValueChanged);
            // 
            // tbEmployeeNumber
            // 
            this.tbEmployeeNumber.Location = new System.Drawing.Point(219, 53);
            this.tbEmployeeNumber.Margin = new System.Windows.Forms.Padding(4);
            this.tbEmployeeNumber.Name = "tbEmployeeNumber";
            this.tbEmployeeNumber.Size = new System.Drawing.Size(271, 23);
            this.tbEmployeeNumber.TabIndex = 27;
            this.tbEmployeeNumber.Enter += new System.EventHandler(this.tbEmployeeNumber_Enter);
            this.tbEmployeeNumber.Leave += new System.EventHandler(this.tbEmployeeNumber_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 17);
            this.label2.TabIndex = 28;
            this.label2.Text = "Employee Number";
            // 
            // pnlValid
            // 
            this.pnlValid.Location = new System.Drawing.Point(414, 403);
            this.pnlValid.Name = "pnlValid";
            this.pnlValid.Size = new System.Drawing.Size(253, 141);
            this.pnlValid.TabIndex = 36;
            // 
            // cbValidCovidTest
            // 
            this.cbValidCovidTest.AutoSize = true;
            this.cbValidCovidTest.Location = new System.Drawing.Point(460, 375);
            this.cbValidCovidTest.Margin = new System.Windows.Forms.Padding(4);
            this.cbValidCovidTest.Name = "cbValidCovidTest";
            this.cbValidCovidTest.Size = new System.Drawing.Size(136, 21);
            this.cbValidCovidTest.TabIndex = 35;
            this.cbValidCovidTest.Text = "Valid COVID Test";
            this.cbValidCovidTest.UseVisualStyleBackColor = true;
            // 
            // rbHigh
            // 
            this.rbHigh.AutoSize = true;
            this.rbHigh.Location = new System.Drawing.Point(653, 581);
            this.rbHigh.Name = "rbHigh";
            this.rbHigh.Size = new System.Drawing.Size(60, 21);
            this.rbHigh.TabIndex = 39;
            this.rbHigh.Text = "HIGH";
            this.rbHigh.UseVisualStyleBackColor = true;
            // 
            // rbPass
            // 
            this.rbPass.AutoSize = true;
            this.rbPass.Checked = true;
            this.rbPass.Location = new System.Drawing.Point(524, 581);
            this.rbPass.Name = "rbPass";
            this.rbPass.Size = new System.Drawing.Size(57, 21);
            this.rbPass.TabIndex = 38;
            this.rbPass.TabStop = true;
            this.rbPass.Text = "Pass";
            this.rbPass.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(380, 581);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 17);
            this.label7.TabIndex = 37;
            this.label7.Text = "Temperature";
            // 
            // bSave
            // 
            this.bSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bSave.Location = new System.Drawing.Point(401, 616);
            this.bSave.Margin = new System.Windows.Forms.Padding(4);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(284, 64);
            this.bSave.TabIndex = 40;
            this.bSave.Text = "SAVE DATA";
            this.bSave.UseVisualStyleBackColor = false;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // cbDisplayCalendar
            // 
            this.cbDisplayCalendar.AutoSize = true;
            this.cbDisplayCalendar.Location = new System.Drawing.Point(285, 291);
            this.cbDisplayCalendar.Margin = new System.Windows.Forms.Padding(4);
            this.cbDisplayCalendar.Name = "cbDisplayCalendar";
            this.cbDisplayCalendar.Size = new System.Drawing.Size(339, 21);
            this.cbDisplayCalendar.TabIndex = 41;
            this.cbDisplayCalendar.Text = "If COVID Test Date requires updating select here:";
            this.cbDisplayCalendar.UseVisualStyleBackColor = true;
            this.cbDisplayCalendar.CheckedChanged += new System.EventHandler(this.cbDisplayCalendar_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(249, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 24);
            this.label1.TabIndex = 42;
            this.label1.Text = "Employees";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label3.Location = new System.Drawing.Point(699, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 24);
            this.label3.TabIndex = 43;
            this.label3.Text = "Outside Services";
            // 
            // cbddContractors
            // 
            this.cbddContractors.FormattingEnabled = true;
            this.cbddContractors.Location = new System.Drawing.Point(743, 56);
            this.cbddContractors.Name = "cbddContractors";
            this.cbddContractors.Size = new System.Drawing.Size(264, 24);
            this.cbddContractors.TabIndex = 44;
            this.cbddContractors.SelectedIndexChanged += new System.EventHandler(this.cbddContractors_SelectedIndexChanged);
            this.cbddContractors.Enter += new System.EventHandler(this.cbddContractors_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(595, 59);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 17);
            this.label6.TabIndex = 45;
            this.label6.Text = "Employee";
            // 
            // cbddContact
            // 
            this.cbddContact.FormattingEnabled = true;
            this.cbddContact.Items.AddRange(new object[] {
            "one",
            "two",
            "three",
            "2442"});
            this.cbddContact.Location = new System.Drawing.Point(743, 176);
            this.cbddContact.Name = "cbddContact";
            this.cbddContact.Size = new System.Drawing.Size(264, 24);
            this.cbddContact.TabIndex = 46;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(595, 179);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 17);
            this.label8.TabIndex = 47;
            this.label8.Text = "AMETEK Contact";
            // 
            // tbCompany
            // 
            this.tbCompany.Location = new System.Drawing.Point(743, 119);
            this.tbCompany.Margin = new System.Windows.Forms.Padding(4);
            this.tbCompany.Name = "tbCompany";
            this.tbCompany.Size = new System.Drawing.Size(271, 23);
            this.tbCompany.TabIndex = 48;
            this.tbCompany.Enter += new System.EventHandler(this.tbCompany_Enter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(601, 122);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 17);
            this.label9.TabIndex = 49;
            this.label9.Text = "Company";
            // 
            // BuildingentryLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 709);
            this.Controls.Add(this.tbCompany);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbddContact);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbddContractors);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDisplayCalendar);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.rbHigh);
            this.Controls.Add(this.rbPass);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pnlValid);
            this.Controls.Add(this.cbValidCovidTest);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbCovidTestDate);
            this.Controls.Add(this.cbddEmployees);
            this.Controls.Add(this.dtpCovidTestDate);
            this.Controls.Add(this.tbEmployeeNumber);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BuildingentryLog";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.BuildingentryLog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCovidTestDate;
        private System.Windows.Forms.ComboBox cbddEmployees;
        private System.Windows.Forms.DateTimePicker dtpCovidTestDate;
        private System.Windows.Forms.TextBox tbEmployeeNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlValid;
        private System.Windows.Forms.CheckBox cbValidCovidTest;
        private System.Windows.Forms.RadioButton rbHigh;
        private System.Windows.Forms.RadioButton rbPass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.CheckBox cbDisplayCalendar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbddContractors;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbddContact;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbCompany;
        private System.Windows.Forms.Label label9;
    }
}

