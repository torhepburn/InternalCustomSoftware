namespace PMR
{
    partial class ProcessWorkRequest
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
            this.LaverageHours = new System.Windows.Forms.Label();
            this.tbReportedDate = new System.Windows.Forms.TextBox();
            this.dtpRepairDate = new System.Windows.Forms.DateTimePicker();
            this.tbSerial = new System.Windows.Forms.TextBox();
            this.tbCostCenter = new System.Windows.Forms.TextBox();
            this.bSaveData = new System.Windows.Forms.Button();
            this.bTask = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.tbDownTime = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tbLaborTime = new System.Windows.Forms.TextBox();
            this.tbRootCause = new System.Windows.Forms.TextBox();
            this.tbRepairMade = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.tbPlannedHours = new System.Windows.Forms.TextBox();
            this.LDaysHours = new System.Windows.Forms.Label();
            this.LTimeOpen = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tbWorkRequestNumber = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tbSuperComment = new System.Windows.Forms.TextBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbAssigned = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbReportedBy = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbTrouble = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbSeverity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbLocation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbProject = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCategory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbManufact = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LaverageHours
            // 
            this.LaverageHours.AutoSize = true;
            this.LaverageHours.Location = new System.Drawing.Point(473, 401);
            this.LaverageHours.Name = "LaverageHours";
            this.LaverageHours.Size = new System.Drawing.Size(95, 13);
            this.LaverageHours.TabIndex = 108;
            this.LaverageHours.Text = "PAST AVERAGE: ";
            // 
            // tbReportedDate
            // 
            this.tbReportedDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.tbReportedDate.Location = new System.Drawing.Point(504, 141);
            this.tbReportedDate.Name = "tbReportedDate";
            this.tbReportedDate.ReadOnly = true;
            this.tbReportedDate.Size = new System.Drawing.Size(183, 20);
            this.tbReportedDate.TabIndex = 107;
            // 
            // dtpRepairDate
            // 
            this.dtpRepairDate.Location = new System.Drawing.Point(221, 398);
            this.dtpRepairDate.Name = "dtpRepairDate";
            this.dtpRepairDate.Size = new System.Drawing.Size(200, 20);
            this.dtpRepairDate.TabIndex = 106;
            this.dtpRepairDate.Enter += new System.EventHandler(this.dtpRepairDate_Enter);
            // 
            // tbSerial
            // 
            this.tbSerial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.tbSerial.Location = new System.Drawing.Point(144, 56);
            this.tbSerial.Name = "tbSerial";
            this.tbSerial.ReadOnly = true;
            this.tbSerial.Size = new System.Drawing.Size(216, 20);
            this.tbSerial.TabIndex = 105;
            // 
            // tbCostCenter
            // 
            this.tbCostCenter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.tbCostCenter.Location = new System.Drawing.Point(165, 164);
            this.tbCostCenter.Name = "tbCostCenter";
            this.tbCostCenter.ReadOnly = true;
            this.tbCostCenter.Size = new System.Drawing.Size(123, 20);
            this.tbCostCenter.TabIndex = 104;
            // 
            // bSaveData
            // 
            this.bSaveData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(180)))), ((int)(((byte)(90)))));
            this.bSaveData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSaveData.Location = new System.Drawing.Point(476, 610);
            this.bSaveData.Name = "bSaveData";
            this.bSaveData.Size = new System.Drawing.Size(181, 51);
            this.bSaveData.TabIndex = 103;
            this.bSaveData.Text = "SAVE DATA";
            this.bSaveData.UseVisualStyleBackColor = false;
            this.bSaveData.Click += new System.EventHandler(this.bSaveData_Click);
            // 
            // bTask
            // 
            this.bTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(120)))));
            this.bTask.Location = new System.Drawing.Point(504, 60);
            this.bTask.Name = "bTask";
            this.bTask.Size = new System.Drawing.Size(178, 23);
            this.bTask.TabIndex = 102;
            this.bTask.Text = "GO TO TASK";
            this.bTask.UseVisualStyleBackColor = false;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(298, 25);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(160, 13);
            this.label25.TabIndex = 101;
            this.label25.Text = "BLUE FIELDS ARE REQUIRED";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(390, 586);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(186, 13);
            this.label24.TabIndex = 100;
            this.label24.Text = "EQUIPMENT DOWN TIME (HOURS)";
            // 
            // tbDownTime
            // 
            this.tbDownTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(180)))), ((int)(((byte)(250)))));
            this.tbDownTime.Location = new System.Drawing.Point(582, 583);
            this.tbDownTime.Name = "tbDownTime";
            this.tbDownTime.Size = new System.Drawing.Size(100, 20);
            this.tbDownTime.TabIndex = 99;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(52, 583);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(163, 13);
            this.label23.TabIndex = 98;
            this.label23.Text = "REPAIR TIME (LABOR HOURS)";
            // 
            // tbLaborTime
            // 
            this.tbLaborTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(180)))), ((int)(((byte)(250)))));
            this.tbLaborTime.Location = new System.Drawing.Point(221, 580);
            this.tbLaborTime.Name = "tbLaborTime";
            this.tbLaborTime.Size = new System.Drawing.Size(100, 20);
            this.tbLaborTime.TabIndex = 97;
            // 
            // tbRootCause
            // 
            this.tbRootCause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(180)))), ((int)(((byte)(250)))));
            this.tbRootCause.Location = new System.Drawing.Point(221, 529);
            this.tbRootCause.Multiline = true;
            this.tbRootCause.Name = "tbRootCause";
            this.tbRootCause.Size = new System.Drawing.Size(461, 46);
            this.tbRootCause.TabIndex = 96;
            // 
            // tbRepairMade
            // 
            this.tbRepairMade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(180)))), ((int)(((byte)(250)))));
            this.tbRepairMade.Location = new System.Drawing.Point(221, 476);
            this.tbRepairMade.Multiline = true;
            this.tbRepairMade.Name = "tbRepairMade";
            this.tbRepairMade.Size = new System.Drawing.Size(461, 46);
            this.tbRepairMade.TabIndex = 95;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(133, 401);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(82, 13);
            this.label22.TabIndex = 94;
            this.label22.Text = "REPAIR DATE:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(473, 376);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(103, 13);
            this.label21.TabIndex = 93;
            this.label21.Text = "PLANNED HOURS:";
            // 
            // tbPlannedHours
            // 
            this.tbPlannedHours.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(180)))), ((int)(((byte)(250)))));
            this.tbPlannedHours.Location = new System.Drawing.Point(582, 373);
            this.tbPlannedHours.Name = "tbPlannedHours";
            this.tbPlannedHours.Size = new System.Drawing.Size(100, 20);
            this.tbPlannedHours.TabIndex = 92;
            // 
            // LDaysHours
            // 
            this.LDaysHours.AutoSize = true;
            this.LDaysHours.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.LDaysHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LDaysHours.Location = new System.Drawing.Point(350, 316);
            this.LDaysHours.Name = "LDaysHours";
            this.LDaysHours.Size = new System.Drawing.Size(97, 20);
            this.LDaysHours.TabIndex = 91;
            this.LDaysHours.Text = "DAYS/HRS:";
            // 
            // LTimeOpen
            // 
            this.LTimeOpen.AutoSize = true;
            this.LTimeOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.LTimeOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LTimeOpen.Location = new System.Drawing.Point(72, 316);
            this.LTimeOpen.Name = "LTimeOpen";
            this.LTimeOpen.Size = new System.Drawing.Size(148, 20);
            this.LTimeOpen.TabIndex = 90;
            this.LTimeOpen.Text = "TIME OPEN (HRS):";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(409, 281);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(149, 13);
            this.label18.TabIndex = 89;
            this.label18.Text = "WORK REQUEST NUMBER:";
            // 
            // tbWorkRequestNumber
            // 
            this.tbWorkRequestNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.tbWorkRequestNumber.Location = new System.Drawing.Point(564, 278);
            this.tbWorkRequestNumber.Name = "tbWorkRequestNumber";
            this.tbWorkRequestNumber.ReadOnly = true;
            this.tbWorkRequestNumber.Size = new System.Drawing.Size(123, 20);
            this.tbWorkRequestNumber.TabIndex = 88;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(59, 531);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(151, 13);
            this.label15.TabIndex = 87;
            this.label15.Text = "ROOT CAUSE OF TROUBLE:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(126, 479);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(84, 13);
            this.label16.TabIndex = 86;
            this.label16.Text = "REPAIR MADE:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(95, 427);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(115, 13);
            this.label17.TabIndex = 85;
            this.label17.Text = "SUPERV. COMMENT:";
            // 
            // tbSuperComment
            // 
            this.tbSuperComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(180)))), ((int)(((byte)(250)))));
            this.tbSuperComment.Location = new System.Drawing.Point(221, 424);
            this.tbSuperComment.Multiline = true;
            this.tbSuperComment.Name = "tbSuperComment";
            this.tbSuperComment.Size = new System.Drawing.Size(461, 46);
            this.tbSuperComment.TabIndex = 84;
            // 
            // cbStatus
            // 
            this.cbStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(180)))), ((int)(((byte)(250)))));
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "Requested",
            "Assigned",
            "Closed"});
            this.cbStatus.Location = new System.Drawing.Point(221, 346);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(197, 21);
            this.cbStatus.TabIndex = 83;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(162, 349);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 82;
            this.label14.Text = "STATUS:";
            // 
            // cbAssigned
            // 
            this.cbAssigned.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(180)))), ((int)(((byte)(250)))));
            this.cbAssigned.FormattingEnabled = true;
            this.cbAssigned.Location = new System.Drawing.Point(221, 372);
            this.cbAssigned.Name = "cbAssigned";
            this.cbAssigned.Size = new System.Drawing.Size(197, 21);
            this.cbAssigned.TabIndex = 81;
            this.cbAssigned.SelectedIndexChanged += new System.EventHandler(this.cbAssigned_SelectedIndexChanged);
            this.cbAssigned.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cbAssigned_MouseDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(132, 375);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 13);
            this.label13.TabIndex = 80;
            this.label13.Text = "ASSIGNED TO:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(73, 167);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 13);
            this.label12.TabIndex = 79;
            this.label12.Text = "COST CENTER:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(409, 250);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 78;
            this.label9.Text = "PH EXT:";
            // 
            // tbPhone
            // 
            this.tbPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.tbPhone.Location = new System.Drawing.Point(504, 247);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.ReadOnly = true;
            this.tbPhone.Size = new System.Drawing.Size(183, 20);
            this.tbPhone.TabIndex = 77;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(409, 224);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 76;
            this.label10.Text = "E-MAIL:";
            // 
            // tbEmail
            // 
            this.tbEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.tbEmail.Location = new System.Drawing.Point(504, 221);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.ReadOnly = true;
            this.tbEmail.Size = new System.Drawing.Size(183, 20);
            this.tbEmail.TabIndex = 75;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(409, 198);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 74;
            this.label11.Text = "RPTD BY:";
            // 
            // tbReportedBy
            // 
            this.tbReportedBy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.tbReportedBy.Location = new System.Drawing.Point(504, 195);
            this.tbReportedBy.Name = "tbReportedBy";
            this.tbReportedBy.ReadOnly = true;
            this.tbReportedBy.Size = new System.Drawing.Size(183, 20);
            this.tbReportedBy.TabIndex = 73;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(72, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 72;
            this.label8.Text = "TROUBLE:";
            // 
            // tbTrouble
            // 
            this.tbTrouble.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.tbTrouble.Location = new System.Drawing.Point(144, 191);
            this.tbTrouble.Multiline = true;
            this.tbTrouble.Name = "tbTrouble";
            this.tbTrouble.ReadOnly = true;
            this.tbTrouble.Size = new System.Drawing.Size(216, 107);
            this.tbTrouble.TabIndex = 71;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(409, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 70;
            this.label7.Text = "REPORTED ON:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(409, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 69;
            this.label6.Text = "SEVERITY:";
            // 
            // tbSeverity
            // 
            this.tbSeverity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.tbSeverity.Location = new System.Drawing.Point(504, 115);
            this.tbSeverity.Name = "tbSeverity";
            this.tbSeverity.ReadOnly = true;
            this.tbSeverity.Size = new System.Drawing.Size(183, 20);
            this.tbSeverity.TabIndex = 68;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(409, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 67;
            this.label5.Text = "LOCATION:";
            // 
            // tbLocation
            // 
            this.tbLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.tbLocation.Location = new System.Drawing.Point(504, 89);
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.ReadOnly = true;
            this.tbLocation.Size = new System.Drawing.Size(183, 20);
            this.tbLocation.TabIndex = 66;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 65;
            this.label4.Text = "PROJECT";
            // 
            // tbProject
            // 
            this.tbProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.tbProject.Location = new System.Drawing.Point(144, 138);
            this.tbProject.Name = "tbProject";
            this.tbProject.ReadOnly = true;
            this.tbProject.Size = new System.Drawing.Size(216, 20);
            this.tbProject.TabIndex = 64;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 63;
            this.label3.Text = "CATEGORY:";
            // 
            // tbCategory
            // 
            this.tbCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.tbCategory.Location = new System.Drawing.Point(144, 112);
            this.tbCategory.Name = "tbCategory";
            this.tbCategory.ReadOnly = true;
            this.tbCategory.Size = new System.Drawing.Size(216, 20);
            this.tbCategory.TabIndex = 62;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 61;
            this.label2.Text = "MANUFACT:";
            // 
            // tbManufact
            // 
            this.tbManufact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.tbManufact.Location = new System.Drawing.Point(144, 86);
            this.tbManufact.Name = "tbManufact";
            this.tbManufact.ReadOnly = true;
            this.tbManufact.Size = new System.Drawing.Size(216, 20);
            this.tbManufact.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "EQUIP ID:";
            // 
            // ProcessWorkRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(140)))), ((int)(((byte)(90)))));
            this.ClientSize = new System.Drawing.Size(738, 687);
            this.Controls.Add(this.LaverageHours);
            this.Controls.Add(this.tbReportedDate);
            this.Controls.Add(this.dtpRepairDate);
            this.Controls.Add(this.tbSerial);
            this.Controls.Add(this.tbCostCenter);
            this.Controls.Add(this.bSaveData);
            this.Controls.Add(this.bTask);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.tbDownTime);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.tbLaborTime);
            this.Controls.Add(this.tbRootCause);
            this.Controls.Add(this.tbRepairMade);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.tbPlannedHours);
            this.Controls.Add(this.LDaysHours);
            this.Controls.Add(this.LTimeOpen);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.tbWorkRequestNumber);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.tbSuperComment);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cbAssigned);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbPhone);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbReportedBy);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbTrouble);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbSeverity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbLocation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbProject);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbManufact);
            this.Controls.Add(this.label1);
            this.Name = "ProcessWorkRequest";
            this.Text = "ProcessWorkRequest";
            this.Load += new System.EventHandler(this.ProcessWorkRequest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LaverageHours;
        private System.Windows.Forms.TextBox tbReportedDate;
        private System.Windows.Forms.DateTimePicker dtpRepairDate;
        private System.Windows.Forms.TextBox tbSerial;
        private System.Windows.Forms.TextBox tbCostCenter;
        private System.Windows.Forms.Button bSaveData;
        private System.Windows.Forms.Button bTask;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox tbDownTime;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox tbLaborTime;
        private System.Windows.Forms.TextBox tbRootCause;
        private System.Windows.Forms.TextBox tbRepairMade;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tbPlannedHours;
        private System.Windows.Forms.Label LDaysHours;
        private System.Windows.Forms.Label LTimeOpen;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbWorkRequestNumber;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbSuperComment;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbAssigned;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbReportedBy;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbTrouble;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbSeverity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbProject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbManufact;
        private System.Windows.Forms.Label label1;
    }
}