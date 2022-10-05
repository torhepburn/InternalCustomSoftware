namespace COVIDLog
{
    partial class COVIDLog
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbValidCovidTest = new System.Windows.Forms.CheckBox();
            this.bSave = new System.Windows.Forms.Button();
            this.tbEmployeeName = new System.Windows.Forms.TextBox();
            this.tbEmployeeNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpCovidTestDate = new System.Windows.Forms.DateTimePicker();
            this.rbPass = new System.Windows.Forms.RadioButton();
            this.rbHigh = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbOutsideService = new System.Windows.Forms.RadioButton();
            this.rbEmployee = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbSelectDate = new System.Windows.Forms.RadioButton();
            this.rbTestDate14 = new System.Windows.Forms.RadioButton();
            this.rbTestDate13 = new System.Windows.Forms.RadioButton();
            this.rbTestDate12 = new System.Windows.Forms.RadioButton();
            this.rbTestDate11 = new System.Windows.Forms.RadioButton();
            this.rbOther = new System.Windows.Forms.RadioButton();
            this.rbTestDate10 = new System.Windows.Forms.RadioButton();
            this.rbTestDate9 = new System.Windows.Forms.RadioButton();
            this.rbTestDate8 = new System.Windows.Forms.RadioButton();
            this.rbTestDate7 = new System.Windows.Forms.RadioButton();
            this.rbTestDate6 = new System.Windows.Forms.RadioButton();
            this.rbTestDate5 = new System.Windows.Forms.RadioButton();
            this.rbTestDate4 = new System.Windows.Forms.RadioButton();
            this.rbTestDate3 = new System.Windows.Forms.RadioButton();
            this.rbTestDate2 = new System.Windows.Forms.RadioButton();
            this.rbTestDate1 = new System.Windows.Forms.RadioButton();
            this.pnlValid = new System.Windows.Forms.Panel();
            this.cbddEmployees = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 185);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // cbValidCovidTest
            // 
            this.cbValidCovidTest.AutoSize = true;
            this.cbValidCovidTest.Location = new System.Drawing.Point(467, 372);
            this.cbValidCovidTest.Margin = new System.Windows.Forms.Padding(4);
            this.cbValidCovidTest.Name = "cbValidCovidTest";
            this.cbValidCovidTest.Size = new System.Drawing.Size(136, 21);
            this.cbValidCovidTest.TabIndex = 4;
            this.cbValidCovidTest.Text = "Valid COVID Test";
            this.cbValidCovidTest.UseVisualStyleBackColor = true;
            // 
            // bSave
            // 
            this.bSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bSave.Location = new System.Drawing.Point(712, 750);
            this.bSave.Margin = new System.Windows.Forms.Padding(4);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(284, 64);
            this.bSave.TabIndex = 8;
            this.bSave.Text = "SAVE DATA";
            this.bSave.UseVisualStyleBackColor = false;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // tbEmployeeName
            // 
            this.tbEmployeeName.Location = new System.Drawing.Point(224, 182);
            this.tbEmployeeName.Margin = new System.Windows.Forms.Padding(4);
            this.tbEmployeeName.Name = "tbEmployeeName";
            this.tbEmployeeName.Size = new System.Drawing.Size(271, 23);
            this.tbEmployeeName.TabIndex = 2;
            this.tbEmployeeName.Leave += new System.EventHandler(this.tbEmployeeName_Leave);
            // 
            // tbEmployeeNumber
            // 
            this.tbEmployeeNumber.Location = new System.Drawing.Point(224, 137);
            this.tbEmployeeNumber.Margin = new System.Windows.Forms.Padding(4);
            this.tbEmployeeNumber.Name = "tbEmployeeNumber";
            this.tbEmployeeNumber.Size = new System.Drawing.Size(271, 23);
            this.tbEmployeeNumber.TabIndex = 1;
            this.tbEmployeeNumber.Leave += new System.EventHandler(this.tbEmployeeNumber_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 140);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Employee Number";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 739);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Temperature";
            // 
            // dtpCovidTestDate
            // 
            this.dtpCovidTestDate.Location = new System.Drawing.Point(421, 622);
            this.dtpCovidTestDate.Name = "dtpCovidTestDate";
            this.dtpCovidTestDate.Size = new System.Drawing.Size(271, 23);
            this.dtpCovidTestDate.TabIndex = 5;
            this.dtpCovidTestDate.Visible = false;
            this.dtpCovidTestDate.ValueChanged += new System.EventHandler(this.dtpCovidTestDate_ValueChanged);
            // 
            // rbPass
            // 
            this.rbPass.AutoSize = true;
            this.rbPass.Checked = true;
            this.rbPass.Location = new System.Drawing.Point(191, 739);
            this.rbPass.Name = "rbPass";
            this.rbPass.Size = new System.Drawing.Size(57, 21);
            this.rbPass.TabIndex = 16;
            this.rbPass.TabStop = true;
            this.rbPass.Text = "Pass";
            this.rbPass.UseVisualStyleBackColor = true;
            // 
            // rbHigh
            // 
            this.rbHigh.AutoSize = true;
            this.rbHigh.Location = new System.Drawing.Point(320, 739);
            this.rbHigh.Name = "rbHigh";
            this.rbHigh.Size = new System.Drawing.Size(60, 21);
            this.rbHigh.TabIndex = 17;
            this.rbHigh.Text = "HIGH";
            this.rbHigh.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.groupBox1.Controls.Add(this.rbOutsideService);
            this.groupBox1.Controls.Add(this.rbEmployee);
            this.groupBox1.Location = new System.Drawing.Point(44, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 105);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Employee or Outside Service";
            // 
            // rbOutsideService
            // 
            this.rbOutsideService.AutoSize = true;
            this.rbOutsideService.Location = new System.Drawing.Point(63, 64);
            this.rbOutsideService.Name = "rbOutsideService";
            this.rbOutsideService.Size = new System.Drawing.Size(296, 21);
            this.rbOutsideService.TabIndex = 19;
            this.rbOutsideService.Text = "Outside Service - Enter Name in Name box";
            this.rbOutsideService.UseVisualStyleBackColor = true;
            // 
            // rbEmployee
            // 
            this.rbEmployee.AutoSize = true;
            this.rbEmployee.Checked = true;
            this.rbEmployee.Location = new System.Drawing.Point(63, 37);
            this.rbEmployee.Name = "rbEmployee";
            this.rbEmployee.Size = new System.Drawing.Size(340, 21);
            this.rbEmployee.TabIndex = 18;
            this.rbEmployee.TabStop = true;
            this.rbEmployee.Text = "Employee - Scan Badge to Employee Number box";
            this.rbEmployee.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(543, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(453, 85);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Problems";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 28);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(433, 34);
            this.label8.TabIndex = 20;
            this.label8.Text = "If employee badge does not pull up data, type data into other boxes\r\nor select fr" +
    "om below..";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 235);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "Select COVID Test Date";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(180)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.rbSelectDate);
            this.panel1.Controls.Add(this.rbTestDate14);
            this.panel1.Controls.Add(this.rbTestDate13);
            this.panel1.Controls.Add(this.rbTestDate12);
            this.panel1.Controls.Add(this.rbTestDate11);
            this.panel1.Controls.Add(this.rbOther);
            this.panel1.Controls.Add(this.rbTestDate10);
            this.panel1.Controls.Add(this.rbTestDate9);
            this.panel1.Controls.Add(this.rbTestDate8);
            this.panel1.Controls.Add(this.rbTestDate7);
            this.panel1.Controls.Add(this.rbTestDate6);
            this.panel1.Controls.Add(this.rbTestDate5);
            this.panel1.Controls.Add(this.rbTestDate4);
            this.panel1.Controls.Add(this.rbTestDate3);
            this.panel1.Controls.Add(this.rbTestDate2);
            this.panel1.Controls.Add(this.rbTestDate1);
            this.panel1.Location = new System.Drawing.Point(223, 222);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(168, 496);
            this.panel1.TabIndex = 21;
            // 
            // rbSelectDate
            // 
            this.rbSelectDate.AutoSize = true;
            this.rbSelectDate.Checked = true;
            this.rbSelectDate.Location = new System.Drawing.Point(22, 438);
            this.rbSelectDate.Name = "rbSelectDate";
            this.rbSelectDate.Size = new System.Drawing.Size(99, 21);
            this.rbSelectDate.TabIndex = 36;
            this.rbSelectDate.TabStop = true;
            this.rbSelectDate.Text = "Select Date";
            this.rbSelectDate.UseVisualStyleBackColor = true;
            // 
            // rbTestDate14
            // 
            this.rbTestDate14.AutoSize = true;
            this.rbTestDate14.Location = new System.Drawing.Point(22, 400);
            this.rbTestDate14.Name = "rbTestDate14";
            this.rbTestDate14.Size = new System.Drawing.Size(57, 21);
            this.rbTestDate14.TabIndex = 35;
            this.rbTestDate14.Text = "Pass";
            this.rbTestDate14.UseVisualStyleBackColor = true;
            this.rbTestDate14.CheckedChanged += new System.EventHandler(this.rbTestDate14_CheckedChanged);
            // 
            // rbTestDate13
            // 
            this.rbTestDate13.AutoSize = true;
            this.rbTestDate13.Location = new System.Drawing.Point(22, 370);
            this.rbTestDate13.Name = "rbTestDate13";
            this.rbTestDate13.Size = new System.Drawing.Size(57, 21);
            this.rbTestDate13.TabIndex = 34;
            this.rbTestDate13.Text = "Pass";
            this.rbTestDate13.UseVisualStyleBackColor = true;
            this.rbTestDate13.CheckedChanged += new System.EventHandler(this.rbTestDate13_CheckedChanged);
            // 
            // rbTestDate12
            // 
            this.rbTestDate12.AutoSize = true;
            this.rbTestDate12.Location = new System.Drawing.Point(22, 340);
            this.rbTestDate12.Name = "rbTestDate12";
            this.rbTestDate12.Size = new System.Drawing.Size(57, 21);
            this.rbTestDate12.TabIndex = 33;
            this.rbTestDate12.Text = "Pass";
            this.rbTestDate12.UseVisualStyleBackColor = true;
            this.rbTestDate12.CheckedChanged += new System.EventHandler(this.rbTestDate12_CheckedChanged);
            // 
            // rbTestDate11
            // 
            this.rbTestDate11.AutoSize = true;
            this.rbTestDate11.Location = new System.Drawing.Point(22, 310);
            this.rbTestDate11.Name = "rbTestDate11";
            this.rbTestDate11.Size = new System.Drawing.Size(42, 21);
            this.rbTestDate11.TabIndex = 32;
            this.rbTestDate11.Text = "32";
            this.rbTestDate11.UseVisualStyleBackColor = true;
            this.rbTestDate11.CheckedChanged += new System.EventHandler(this.rbTestDate11_CheckedChanged);
            // 
            // rbOther
            // 
            this.rbOther.AutoSize = true;
            this.rbOther.Location = new System.Drawing.Point(22, 468);
            this.rbOther.Name = "rbOther";
            this.rbOther.Size = new System.Drawing.Size(134, 21);
            this.rbOther.TabIndex = 37;
            this.rbOther.Text = "Enter Other Date";
            this.rbOther.UseVisualStyleBackColor = true;
            this.rbOther.CheckedChanged += new System.EventHandler(this.rbOther_CheckedChanged);
            // 
            // rbTestDate10
            // 
            this.rbTestDate10.AutoSize = true;
            this.rbTestDate10.Location = new System.Drawing.Point(22, 280);
            this.rbTestDate10.Name = "rbTestDate10";
            this.rbTestDate10.Size = new System.Drawing.Size(57, 21);
            this.rbTestDate10.TabIndex = 31;
            this.rbTestDate10.Text = "Pass";
            this.rbTestDate10.UseVisualStyleBackColor = true;
            this.rbTestDate10.CheckedChanged += new System.EventHandler(this.rbTestDate10_CheckedChanged);
            // 
            // rbTestDate9
            // 
            this.rbTestDate9.AutoSize = true;
            this.rbTestDate9.Location = new System.Drawing.Point(22, 250);
            this.rbTestDate9.Name = "rbTestDate9";
            this.rbTestDate9.Size = new System.Drawing.Size(57, 21);
            this.rbTestDate9.TabIndex = 30;
            this.rbTestDate9.Text = "Pass";
            this.rbTestDate9.UseVisualStyleBackColor = true;
            this.rbTestDate9.CheckedChanged += new System.EventHandler(this.rbTestDate9_CheckedChanged);
            // 
            // rbTestDate8
            // 
            this.rbTestDate8.AutoSize = true;
            this.rbTestDate8.Location = new System.Drawing.Point(22, 220);
            this.rbTestDate8.Name = "rbTestDate8";
            this.rbTestDate8.Size = new System.Drawing.Size(57, 21);
            this.rbTestDate8.TabIndex = 29;
            this.rbTestDate8.Text = "Pass";
            this.rbTestDate8.UseVisualStyleBackColor = true;
            this.rbTestDate8.CheckedChanged += new System.EventHandler(this.rbTestDate8_CheckedChanged);
            // 
            // rbTestDate7
            // 
            this.rbTestDate7.AutoSize = true;
            this.rbTestDate7.Location = new System.Drawing.Point(22, 190);
            this.rbTestDate7.Name = "rbTestDate7";
            this.rbTestDate7.Size = new System.Drawing.Size(57, 21);
            this.rbTestDate7.TabIndex = 28;
            this.rbTestDate7.Text = "Pass";
            this.rbTestDate7.UseVisualStyleBackColor = true;
            this.rbTestDate7.CheckedChanged += new System.EventHandler(this.rbTestDate7_CheckedChanged);
            // 
            // rbTestDate6
            // 
            this.rbTestDate6.AutoSize = true;
            this.rbTestDate6.Location = new System.Drawing.Point(22, 160);
            this.rbTestDate6.Name = "rbTestDate6";
            this.rbTestDate6.Size = new System.Drawing.Size(57, 21);
            this.rbTestDate6.TabIndex = 27;
            this.rbTestDate6.Text = "Pass";
            this.rbTestDate6.UseVisualStyleBackColor = true;
            this.rbTestDate6.CheckedChanged += new System.EventHandler(this.rbTestDate6_CheckedChanged);
            // 
            // rbTestDate5
            // 
            this.rbTestDate5.AutoSize = true;
            this.rbTestDate5.Location = new System.Drawing.Point(22, 130);
            this.rbTestDate5.Name = "rbTestDate5";
            this.rbTestDate5.Size = new System.Drawing.Size(57, 21);
            this.rbTestDate5.TabIndex = 26;
            this.rbTestDate5.Text = "Pass";
            this.rbTestDate5.UseVisualStyleBackColor = true;
            this.rbTestDate5.CheckedChanged += new System.EventHandler(this.rbTestDate5_CheckedChanged);
            // 
            // rbTestDate4
            // 
            this.rbTestDate4.AutoSize = true;
            this.rbTestDate4.Location = new System.Drawing.Point(22, 100);
            this.rbTestDate4.Name = "rbTestDate4";
            this.rbTestDate4.Size = new System.Drawing.Size(57, 21);
            this.rbTestDate4.TabIndex = 25;
            this.rbTestDate4.Text = "Pass";
            this.rbTestDate4.UseVisualStyleBackColor = true;
            this.rbTestDate4.CheckedChanged += new System.EventHandler(this.rbTestDate4_CheckedChanged);
            // 
            // rbTestDate3
            // 
            this.rbTestDate3.AutoSize = true;
            this.rbTestDate3.Location = new System.Drawing.Point(22, 70);
            this.rbTestDate3.Name = "rbTestDate3";
            this.rbTestDate3.Size = new System.Drawing.Size(57, 21);
            this.rbTestDate3.TabIndex = 24;
            this.rbTestDate3.Text = "Pass";
            this.rbTestDate3.UseVisualStyleBackColor = true;
            this.rbTestDate3.CheckedChanged += new System.EventHandler(this.rbTestDate3_CheckedChanged);
            // 
            // rbTestDate2
            // 
            this.rbTestDate2.AutoSize = true;
            this.rbTestDate2.Location = new System.Drawing.Point(22, 40);
            this.rbTestDate2.Name = "rbTestDate2";
            this.rbTestDate2.Size = new System.Drawing.Size(57, 21);
            this.rbTestDate2.TabIndex = 23;
            this.rbTestDate2.Text = "Pass";
            this.rbTestDate2.UseVisualStyleBackColor = true;
            this.rbTestDate2.CheckedChanged += new System.EventHandler(this.rbTestDate2_CheckedChanged);
            // 
            // rbTestDate1
            // 
            this.rbTestDate1.AutoSize = true;
            this.rbTestDate1.Location = new System.Drawing.Point(22, 10);
            this.rbTestDate1.Name = "rbTestDate1";
            this.rbTestDate1.Size = new System.Drawing.Size(57, 21);
            this.rbTestDate1.TabIndex = 22;
            this.rbTestDate1.Text = "Pass";
            this.rbTestDate1.UseVisualStyleBackColor = true;
            this.rbTestDate1.CheckedChanged += new System.EventHandler(this.rbTestDate1_CheckedChanged);
            // 
            // pnlValid
            // 
            this.pnlValid.Location = new System.Drawing.Point(421, 400);
            this.pnlValid.Name = "pnlValid";
            this.pnlValid.Size = new System.Drawing.Size(253, 141);
            this.pnlValid.TabIndex = 22;
            // 
            // cbddEmployees
            // 
            this.cbddEmployees.FormattingEnabled = true;
            this.cbddEmployees.Location = new System.Drawing.Point(709, 136);
            this.cbddEmployees.Name = "cbddEmployees";
            this.cbddEmployees.Size = new System.Drawing.Size(264, 24);
            this.cbddEmployees.TabIndex = 23;
            this.cbddEmployees.SelectedIndexChanged += new System.EventHandler(this.cbddEmployees_SelectedIndexChanged);
            // 
            // COVIDLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 842);
            this.Controls.Add(this.cbddEmployees);
            this.Controls.Add(this.pnlValid);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rbHigh);
            this.Controls.Add(this.rbPass);
            this.Controls.Add(this.dtpCovidTestDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbEmployeeNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbEmployeeName);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.cbValidCovidTest);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "COVIDLog";
            this.Text = "Building Entry Log";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbValidCovidTest;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.TextBox tbEmployeeName;
        private System.Windows.Forms.TextBox tbEmployeeNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpCovidTestDate;
        private System.Windows.Forms.RadioButton rbPass;
        private System.Windows.Forms.RadioButton rbHigh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbOutsideService;
        private System.Windows.Forms.RadioButton rbEmployee;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbTestDate1;
        private System.Windows.Forms.RadioButton rbTestDate4;
        private System.Windows.Forms.RadioButton rbTestDate3;
        private System.Windows.Forms.RadioButton rbTestDate2;
        private System.Windows.Forms.RadioButton rbTestDate10;
        private System.Windows.Forms.RadioButton rbTestDate9;
        private System.Windows.Forms.RadioButton rbTestDate8;
        private System.Windows.Forms.RadioButton rbTestDate7;
        private System.Windows.Forms.RadioButton rbTestDate6;
        private System.Windows.Forms.RadioButton rbTestDate5;
        private System.Windows.Forms.RadioButton rbOther;
        private System.Windows.Forms.RadioButton rbTestDate14;
        private System.Windows.Forms.RadioButton rbTestDate13;
        private System.Windows.Forms.RadioButton rbTestDate12;
        private System.Windows.Forms.RadioButton rbTestDate11;
        private System.Windows.Forms.RadioButton rbSelectDate;
        private System.Windows.Forms.Panel pnlValid;
        private System.Windows.Forms.ComboBox cbddEmployees;
    }
}

