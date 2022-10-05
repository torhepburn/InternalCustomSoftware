namespace CreatePartSchedule
{
    partial class CreatePartSchedule
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DGV2 = new System.Windows.Forms.DataGridView();
            this.DGV3 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpRelease = new System.Windows.Forms.DateTimePicker();
            this.bEnterData = new System.Windows.Forms.Button();
            this.tbPartCycleDaySum = new System.Windows.Forms.TextBox();
            this.tbJobCycleDaySum = new System.Windows.Forms.TextBox();
            this.tbCmpAdjDays = new System.Windows.Forms.TextBox();
            this.LopNum = new System.Windows.Forms.Label();
            this.bAdjustDays = new System.Windows.Forms.Button();
            this.Lcustomer = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.LdrawingNoText = new System.Windows.Forms.Label();
            this.LelementText = new System.Windows.Forms.Label();
            this.LprojectText = new System.Windows.Forms.Label();
            this.LcustomerText = new System.Windows.Forms.Label();
            this.Lpdd = new System.Windows.Forms.Label();
            this.Lcrd = new System.Windows.Forms.Label();
            this.Lopd = new System.Windows.Forms.Label();
            this.Lod = new System.Windows.Forms.Label();
            this.tbPartSubsequent = new System.Windows.Forms.TextBox();
            this.Ljswcd = new System.Windows.Forms.Label();
            this.LcurrentOp = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.LpShipDate = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.LcurrentOpStart = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(301, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Maintain Part Schedule";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(31, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "1.  Customer Data";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(31, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "2.  Select Part ID";
            // 
            // DGV2
            // 
            this.DGV2.AllowUserToAddRows = false;
            this.DGV2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.DGV2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV2.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV2.Location = new System.Drawing.Point(35, 232);
            this.DGV2.Name = "DGV2";
            this.DGV2.ReadOnly = true;
            this.DGV2.RowHeadersWidth = 20;
            this.DGV2.Size = new System.Drawing.Size(166, 25);
            this.DGV2.TabIndex = 10;
            this.DGV2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV2_CellClick);
            // 
            // DGV3
            // 
            this.DGV3.AllowUserToAddRows = false;
            this.DGV3.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.DGV3.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(240)))), ((int)(((byte)(105)))));
            this.DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV3.Location = new System.Drawing.Point(35, 343);
            this.DGV3.Name = "DGV3";
            this.DGV3.ReadOnly = true;
            this.DGV3.RowHeadersWidth = 20;
            this.DGV3.Size = new System.Drawing.Size(856, 25);
            this.DGV3.TabIndex = 11;
            this.DGV3.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV3_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(312, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "3. Enter Release Date";
            // 
            // dtpRelease
            // 
            this.dtpRelease.Location = new System.Drawing.Point(366, 74);
            this.dtpRelease.Name = "dtpRelease";
            this.dtpRelease.Size = new System.Drawing.Size(200, 20);
            this.dtpRelease.TabIndex = 13;
            // 
            // bEnterData
            // 
            this.bEnterData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(200)))));
            this.bEnterData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.bEnterData.Location = new System.Drawing.Point(692, 225);
            this.bEnterData.Name = "bEnterData";
            this.bEnterData.Size = new System.Drawing.Size(199, 55);
            this.bEnterData.TabIndex = 20;
            this.bEnterData.Text = "CREATE NEW SCHEDULE";
            this.bEnterData.UseVisualStyleBackColor = false;
            this.bEnterData.Click += new System.EventHandler(this.bEnterData_Click);
            // 
            // tbPartCycleDaySum
            // 
            this.tbPartCycleDaySum.Enabled = false;
            this.tbPartCycleDaySum.Location = new System.Drawing.Point(844, 126);
            this.tbPartCycleDaySum.Name = "tbPartCycleDaySum";
            this.tbPartCycleDaySum.Size = new System.Drawing.Size(47, 20);
            this.tbPartCycleDaySum.TabIndex = 23;
            // 
            // tbJobCycleDaySum
            // 
            this.tbJobCycleDaySum.Enabled = false;
            this.tbJobCycleDaySum.Location = new System.Drawing.Point(844, 76);
            this.tbJobCycleDaySum.Name = "tbJobCycleDaySum";
            this.tbJobCycleDaySum.Size = new System.Drawing.Size(47, 20);
            this.tbJobCycleDaySum.TabIndex = 22;
            // 
            // tbCmpAdjDays
            // 
            this.tbCmpAdjDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbCmpAdjDays.Location = new System.Drawing.Point(288, 567);
            this.tbCmpAdjDays.Name = "tbCmpAdjDays";
            this.tbCmpAdjDays.Size = new System.Drawing.Size(47, 23);
            this.tbCmpAdjDays.TabIndex = 24;
            // 
            // LopNum
            // 
            this.LopNum.AutoSize = true;
            this.LopNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LopNum.Location = new System.Drawing.Point(42, 570);
            this.LopNum.Name = "LopNum";
            this.LopNum.Size = new System.Drawing.Size(0, 17);
            this.LopNum.TabIndex = 25;
            // 
            // bAdjustDays
            // 
            this.bAdjustDays.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(130)))), ((int)(((byte)(100)))));
            this.bAdjustDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.bAdjustDays.Location = new System.Drawing.Point(348, 548);
            this.bAdjustDays.Name = "bAdjustDays";
            this.bAdjustDays.Size = new System.Drawing.Size(191, 61);
            this.bAdjustDays.TabIndex = 26;
            this.bAdjustDays.Text = "ADJUST DAYS";
            this.bAdjustDays.UseVisualStyleBackColor = false;
            this.bAdjustDays.Click += new System.EventHandler(this.bAdjustDays_Click);
            // 
            // Lcustomer
            // 
            this.Lcustomer.AutoSize = true;
            this.Lcustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Lcustomer.Location = new System.Drawing.Point(32, 77);
            this.Lcustomer.Name = "Lcustomer";
            this.Lcustomer.Size = new System.Drawing.Size(68, 17);
            this.Lcustomer.TabIndex = 27;
            this.Lcustomer.Text = "Customer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(32, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "Project";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(32, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 17);
            this.label6.TabIndex = 29;
            this.label6.Text = "Element";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(32, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 17);
            this.label7.TabIndex = 30;
            this.label7.Text = "Drawing Number";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.Location = new System.Drawing.Point(313, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(149, 17);
            this.label8.TabIndex = 31;
            this.label8.Text = "Planned Delivery Date";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label9.Location = new System.Drawing.Point(313, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(146, 17);
            this.label9.TabIndex = 32;
            this.label9.Text = "Current Request Date";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label10.Location = new System.Drawing.Point(314, 155);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(146, 17);
            this.label10.TabIndex = 33;
            this.label10.Text = "Original Promise Date";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label11.Location = new System.Drawing.Point(313, 181);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 17);
            this.label11.TabIndex = 34;
            this.label11.Text = "Order Date";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label12.Location = new System.Drawing.Point(314, 205);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(222, 17);
            this.label12.TabIndex = 35;
            this.label12.Text = "Job Subsequent Work Cycle Days";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label13.Location = new System.Drawing.Point(314, 236);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(225, 17);
            this.label13.TabIndex = 36;
            this.label13.Text = "Part Subsequent Work Cycle Days";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label14.Location = new System.Drawing.Point(613, 79);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(188, 34);
            this.label14.TabIndex = 37;
            this.label14.Text = "Standard Cycle Days for Job\r\n(excludes Part adjustments)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label15.Location = new System.Drawing.Point(613, 126);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(204, 34);
            this.label15.TabIndex = 38;
            this.label15.Text = "Cycle Days Sum for this Part ID\r\n(includes Part adjustments)";
            // 
            // LdrawingNoText
            // 
            this.LdrawingNoText.AutoSize = true;
            this.LdrawingNoText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(140)))));
            this.LdrawingNoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LdrawingNoText.Location = new System.Drawing.Point(151, 157);
            this.LdrawingNoText.Name = "LdrawingNoText";
            this.LdrawingNoText.Size = new System.Drawing.Size(113, 17);
            this.LdrawingNoText.TabIndex = 42;
            this.LdrawingNoText.Text = "Drawing Number";
            // 
            // LelementText
            // 
            this.LelementText.AutoSize = true;
            this.LelementText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(140)))));
            this.LelementText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LelementText.Location = new System.Drawing.Point(151, 129);
            this.LelementText.Name = "LelementText";
            this.LelementText.Size = new System.Drawing.Size(59, 17);
            this.LelementText.TabIndex = 41;
            this.LelementText.Text = "Element";
            // 
            // LprojectText
            // 
            this.LprojectText.AutoSize = true;
            this.LprojectText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(140)))));
            this.LprojectText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LprojectText.Location = new System.Drawing.Point(151, 103);
            this.LprojectText.Name = "LprojectText";
            this.LprojectText.Size = new System.Drawing.Size(52, 17);
            this.LprojectText.TabIndex = 40;
            this.LprojectText.Text = "Project";
            // 
            // LcustomerText
            // 
            this.LcustomerText.AutoSize = true;
            this.LcustomerText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(140)))));
            this.LcustomerText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LcustomerText.Location = new System.Drawing.Point(151, 77);
            this.LcustomerText.Name = "LcustomerText";
            this.LcustomerText.Size = new System.Drawing.Size(68, 17);
            this.LcustomerText.TabIndex = 39;
            this.LcustomerText.Text = "Customer";
            // 
            // Lpdd
            // 
            this.Lpdd.AutoSize = true;
            this.Lpdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(140)))));
            this.Lpdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Lpdd.Location = new System.Drawing.Point(476, 103);
            this.Lpdd.Name = "Lpdd";
            this.Lpdd.Size = new System.Drawing.Size(48, 17);
            this.Lpdd.TabIndex = 43;
            this.Lpdd.Text = "          ";
            // 
            // Lcrd
            // 
            this.Lcrd.AutoSize = true;
            this.Lcrd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(140)))));
            this.Lcrd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Lcrd.Location = new System.Drawing.Point(476, 129);
            this.Lcrd.Name = "Lcrd";
            this.Lcrd.Size = new System.Drawing.Size(48, 17);
            this.Lcrd.TabIndex = 44;
            this.Lcrd.Text = "          ";
            // 
            // Lopd
            // 
            this.Lopd.AutoSize = true;
            this.Lopd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(140)))));
            this.Lopd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Lopd.Location = new System.Drawing.Point(476, 157);
            this.Lopd.Name = "Lopd";
            this.Lopd.Size = new System.Drawing.Size(48, 17);
            this.Lopd.TabIndex = 45;
            this.Lopd.Text = "          ";
            // 
            // Lod
            // 
            this.Lod.AutoSize = true;
            this.Lod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(140)))));
            this.Lod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Lod.Location = new System.Drawing.Point(476, 184);
            this.Lod.Name = "Lod";
            this.Lod.Size = new System.Drawing.Size(48, 17);
            this.Lod.TabIndex = 46;
            this.Lod.Text = "          ";
            // 
            // tbPartSubsequent
            // 
            this.tbPartSubsequent.Location = new System.Drawing.Point(542, 235);
            this.tbPartSubsequent.Name = "tbPartSubsequent";
            this.tbPartSubsequent.Size = new System.Drawing.Size(47, 20);
            this.tbPartSubsequent.TabIndex = 19;
            this.tbPartSubsequent.TextChanged += new System.EventHandler(this.tbPartSubsequent_TextChanged);
            // 
            // Ljswcd
            // 
            this.Ljswcd.AutoSize = true;
            this.Ljswcd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(140)))));
            this.Ljswcd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Ljswcd.Location = new System.Drawing.Point(542, 209);
            this.Ljswcd.Name = "Ljswcd";
            this.Ljswcd.Size = new System.Drawing.Size(48, 17);
            this.Ljswcd.TabIndex = 47;
            this.Ljswcd.Text = "          ";
            // 
            // LcurrentOp
            // 
            this.LcurrentOp.AutoSize = true;
            this.LcurrentOp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LcurrentOp.Location = new System.Drawing.Point(284, 307);
            this.LcurrentOp.Name = "LcurrentOp";
            this.LcurrentOp.Size = new System.Drawing.Size(140, 20);
            this.LcurrentOp.TabIndex = 48;
            this.LcurrentOp.Text = "Current Operation:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label16.Location = new System.Drawing.Point(430, 307);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 20);
            this.label16.TabIndex = 49;
            this.label16.Text = "          ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label17.Location = new System.Drawing.Point(688, 307);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 20);
            this.label17.TabIndex = 51;
            this.label17.Text = "          ";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label18.Location = new System.Drawing.Point(510, 307);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(172, 20);
            this.label18.TabIndex = 50;
            this.label18.Text = "Completed Operations:";
            // 
            // LpShipDate
            // 
            this.LpShipDate.AutoSize = true;
            this.LpShipDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(140)))));
            this.LpShipDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LpShipDate.Location = new System.Drawing.Point(815, 183);
            this.LpShipDate.Name = "LpShipDate";
            this.LpShipDate.Size = new System.Drawing.Size(48, 17);
            this.LpShipDate.TabIndex = 53;
            this.LpShipDate.Text = "          ";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label20.Location = new System.Drawing.Point(652, 181);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(134, 17);
            this.label20.TabIndex = 52;
            this.label20.Text = "Projected Ship Date";
            // 
            // LcurrentOpStart
            // 
            this.LcurrentOpStart.AutoSize = true;
            this.LcurrentOpStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LcurrentOpStart.Location = new System.Drawing.Point(284, 273);
            this.LcurrentOpStart.Name = "LcurrentOpStart";
            this.LcurrentOpStart.Size = new System.Drawing.Size(218, 20);
            this.LcurrentOpStart.TabIndex = 54;
            this.LcurrentOpStart.Text = "Current Operation Start Date:";
            // 
            // CreatePartSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(938, 612);
            this.Controls.Add(this.LcurrentOpStart);
            this.Controls.Add(this.LpShipDate);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.LcurrentOp);
            this.Controls.Add(this.Ljswcd);
            this.Controls.Add(this.Lod);
            this.Controls.Add(this.Lopd);
            this.Controls.Add(this.Lcrd);
            this.Controls.Add(this.Lpdd);
            this.Controls.Add(this.LdrawingNoText);
            this.Controls.Add(this.LelementText);
            this.Controls.Add(this.LprojectText);
            this.Controls.Add(this.LcustomerText);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Lcustomer);
            this.Controls.Add(this.bAdjustDays);
            this.Controls.Add(this.LopNum);
            this.Controls.Add(this.tbCmpAdjDays);
            this.Controls.Add(this.tbPartCycleDaySum);
            this.Controls.Add(this.tbJobCycleDaySum);
            this.Controls.Add(this.bEnterData);
            this.Controls.Add(this.tbPartSubsequent);
            this.Controls.Add(this.dtpRelease);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DGV3);
            this.Controls.Add(this.DGV2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CreatePartSchedule";
            this.Text = "Create Part Schedule";
            this.Load += new System.EventHandler(this.CreatePartSchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DGV2;
        private System.Windows.Forms.DataGridView DGV3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpRelease;
        private System.Windows.Forms.Button bEnterData;
        private System.Windows.Forms.TextBox tbPartCycleDaySum;
        private System.Windows.Forms.TextBox tbJobCycleDaySum;
        private System.Windows.Forms.TextBox tbCmpAdjDays;
        private System.Windows.Forms.Label LopNum;
        private System.Windows.Forms.Button bAdjustDays;
        private System.Windows.Forms.Label Lcustomer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label LdrawingNoText;
        private System.Windows.Forms.Label LelementText;
        private System.Windows.Forms.Label LprojectText;
        private System.Windows.Forms.Label LcustomerText;
        private System.Windows.Forms.Label Lpdd;
        private System.Windows.Forms.Label Lcrd;
        private System.Windows.Forms.Label Lopd;
        private System.Windows.Forms.Label Lod;
        private System.Windows.Forms.TextBox tbPartSubsequent;
        private System.Windows.Forms.Label Ljswcd;
        private System.Windows.Forms.Label LcurrentOp;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label LpShipDate;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label LcurrentOpStart;
    }
}

