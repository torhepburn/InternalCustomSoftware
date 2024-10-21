namespace NDA
{
    partial class DataEntryForm
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
            this.cbddStatus = new System.Windows.Forms.ComboBox();
            this.cbddTerminationNotice = new System.Windows.Forms.ComboBox();
            this.cbddLifeAfterTermination = new System.Windows.Forms.ComboBox();
            this.cbddPartyProtected = new System.Windows.Forms.ComboBox();
            this.cbddSubjectProtected = new System.Windows.Forms.ComboBox();
            this.cbddProductLine = new System.Windows.Forms.ComboBox();
            this.dtpDateRequested = new System.Windows.Forms.DateTimePicker();
            this.dtpEffectiveDate = new System.Windows.Forms.DateTimePicker();
            this.dtpDateOriginalFiled = new System.Windows.Forms.DateTimePicker();
            this.dtpContractEnds = new System.Windows.Forms.DateTimePicker();
            this.tbCity = new System.Windows.Forms.TextBox();
            this.tbCompany = new System.Windows.Forms.TextBox();
            this.LNdaID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCompanyContact = new System.Windows.Forms.TextBox();
            this.tbState = new System.Windows.Forms.TextBox();
            this.tbCountry = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbddZygoContact = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbddZygoAdministrator = new System.Windows.Forms.ComboBox();
            this.cbRestrictedAccess = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cbddZygoSigner = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.DgvNotes = new System.Windows.Forms.DataGridView();
            this.LStatusNotes = new System.Windows.Forms.Label();
            this.LStatusDate = new System.Windows.Forms.Label();
            this.dtpStatusDate = new System.Windows.Forms.DateTimePicker();
            this.tbStatusNotes = new System.Windows.Forms.TextBox();
            this.dtpDestructionDate = new System.Windows.Forms.DateTimePicker();
            this.label23 = new System.Windows.Forms.Label();
            this.cbddAgreementType = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.tbDoingBusinessAs = new System.Windows.Forms.TextBox();
            this.tbParent = new System.Windows.Forms.TextBox();
            this.Bsave = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.cbddVendor = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.cbddCustomer = new System.Windows.Forms.ComboBox();
            this.cbEffectiveDate = new System.Windows.Forms.CheckBox();
            this.cbDateRequested = new System.Windows.Forms.CheckBox();
            this.cbContractEnds = new System.Windows.Forms.CheckBox();
            this.cbDateOriginalFiled = new System.Windows.Forms.CheckBox();
            this.cbDestructionDate = new System.Windows.Forms.CheckBox();
            this.bPrint = new System.Windows.Forms.Button();
            this.cbProcurement = new System.Windows.Forms.CheckBox();
            this.Bpdf = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.LpdfStored = new System.Windows.Forms.Label();
            this.Lrequested = new System.Windows.Forms.Label();
            this.Leffective = new System.Windows.Forms.Label();
            this.Lcontract = new System.Windows.Forms.Label();
            this.Lfiled = new System.Windows.Forms.Label();
            this.Ldestruction = new System.Windows.Forms.Label();
            this.cbInactiveForProcurement = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvNotes)).BeginInit();
            this.SuspendLayout();
            // 
            // cbddStatus
            // 
            this.cbddStatus.FormattingEnabled = true;
            this.cbddStatus.Items.AddRange(new object[] {
            "Dead Issue",
            "Expired",
            "Expires Soon",
            "Filed",
            "Read and Reviewed",
            "Received",
            "Waiting - Company Signoff",
            "Waiting - Zygo Signoff",
            "Zygo Corporation (One-Way)"});
            this.cbddStatus.Location = new System.Drawing.Point(236, 9);
            this.cbddStatus.Name = "cbddStatus";
            this.cbddStatus.Size = new System.Drawing.Size(203, 24);
            this.cbddStatus.TabIndex = 0;
            this.cbddStatus.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbddStatus_MouseClick);
            // 
            // cbddTerminationNotice
            // 
            this.cbddTerminationNotice.FormattingEnabled = true;
            this.cbddTerminationNotice.Items.AddRange(new object[] {
            "5 Days Written",
            "10 Days Written",
            "30 Days Written",
            "60 Days Written"});
            this.cbddTerminationNotice.Location = new System.Drawing.Point(159, 447);
            this.cbddTerminationNotice.Name = "cbddTerminationNotice";
            this.cbddTerminationNotice.Size = new System.Drawing.Size(175, 24);
            this.cbddTerminationNotice.TabIndex = 17;
            // 
            // cbddLifeAfterTermination
            // 
            this.cbddLifeAfterTermination.FormattingEnabled = true;
            this.cbddLifeAfterTermination.Location = new System.Drawing.Point(499, 449);
            this.cbddLifeAfterTermination.Name = "cbddLifeAfterTermination";
            this.cbddLifeAfterTermination.Size = new System.Drawing.Size(274, 24);
            this.cbddLifeAfterTermination.TabIndex = 20;
            // 
            // cbddPartyProtected
            // 
            this.cbddPartyProtected.FormattingEnabled = true;
            this.cbddPartyProtected.Location = new System.Drawing.Point(159, 382);
            this.cbddPartyProtected.Name = "cbddPartyProtected";
            this.cbddPartyProtected.Size = new System.Drawing.Size(204, 24);
            this.cbddPartyProtected.TabIndex = 15;
            // 
            // cbddSubjectProtected
            // 
            this.cbddSubjectProtected.FormattingEnabled = true;
            this.cbddSubjectProtected.Location = new System.Drawing.Point(159, 417);
            this.cbddSubjectProtected.Name = "cbddSubjectProtected";
            this.cbddSubjectProtected.Size = new System.Drawing.Size(614, 24);
            this.cbddSubjectProtected.TabIndex = 16;
            // 
            // cbddProductLine
            // 
            this.cbddProductLine.FormattingEnabled = true;
            this.cbddProductLine.Items.AddRange(new object[] {
            "",
            "Instrument",
            "Optics",
            "NAVITAR",
            "PPS",
            "Global",
            "ZYG-NAV"});
            this.cbddProductLine.Location = new System.Drawing.Point(639, 13);
            this.cbddProductLine.Name = "cbddProductLine";
            this.cbddProductLine.Size = new System.Drawing.Size(121, 24);
            this.cbddProductLine.TabIndex = 1;
            // 
            // dtpDateRequested
            // 
            this.dtpDateRequested.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateRequested.Location = new System.Drawing.Point(166, 533);
            this.dtpDateRequested.Name = "dtpDateRequested";
            this.dtpDateRequested.Size = new System.Drawing.Size(120, 23);
            this.dtpDateRequested.TabIndex = 23;
            this.dtpDateRequested.Visible = false;
            // 
            // dtpEffectiveDate
            // 
            this.dtpEffectiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEffectiveDate.Location = new System.Drawing.Point(302, 533);
            this.dtpEffectiveDate.Name = "dtpEffectiveDate";
            this.dtpEffectiveDate.Size = new System.Drawing.Size(120, 23);
            this.dtpEffectiveDate.TabIndex = 25;
            this.dtpEffectiveDate.Visible = false;
            // 
            // dtpDateOriginalFiled
            // 
            this.dtpDateOriginalFiled.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOriginalFiled.Location = new System.Drawing.Point(568, 533);
            this.dtpDateOriginalFiled.Name = "dtpDateOriginalFiled";
            this.dtpDateOriginalFiled.Size = new System.Drawing.Size(120, 23);
            this.dtpDateOriginalFiled.TabIndex = 29;
            this.dtpDateOriginalFiled.Visible = false;
            // 
            // dtpContractEnds
            // 
            this.dtpContractEnds.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpContractEnds.Location = new System.Drawing.Point(434, 533);
            this.dtpContractEnds.Name = "dtpContractEnds";
            this.dtpContractEnds.Size = new System.Drawing.Size(120, 23);
            this.dtpContractEnds.TabIndex = 27;
            this.dtpContractEnds.Visible = false;
            // 
            // tbCity
            // 
            this.tbCity.Location = new System.Drawing.Point(159, 184);
            this.tbCity.Name = "tbCity";
            this.tbCity.Size = new System.Drawing.Size(280, 23);
            this.tbCity.TabIndex = 8;
            // 
            // tbCompany
            // 
            this.tbCompany.Location = new System.Drawing.Point(107, 50);
            this.tbCompany.Name = "tbCompany";
            this.tbCompany.Size = new System.Drawing.Size(332, 23);
            this.tbCompany.TabIndex = 3;
            // 
            // LNdaID
            // 
            this.LNdaID.AutoSize = true;
            this.LNdaID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LNdaID.Location = new System.Drawing.Point(12, 9);
            this.LNdaID.Name = "LNdaID";
            this.LNdaID.Size = new System.Drawing.Size(68, 20);
            this.LNdaID.TabIndex = 15;
            this.LNdaID.Text = "NDA ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(548, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Product Line";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "Company";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 17);
            this.label6.TabIndex = 21;
            this.label6.Text = "Company Contact";
            // 
            // tbCompanyContact
            // 
            this.tbCompanyContact.Location = new System.Drawing.Point(159, 155);
            this.tbCompanyContact.Name = "tbCompanyContact";
            this.tbCompanyContact.Size = new System.Drawing.Size(280, 23);
            this.tbCompanyContact.TabIndex = 7;
            // 
            // tbState
            // 
            this.tbState.Location = new System.Drawing.Point(159, 213);
            this.tbState.Name = "tbState";
            this.tbState.Size = new System.Drawing.Size(280, 23);
            this.tbState.TabIndex = 9;
            // 
            // tbCountry
            // 
            this.tbCountry.Location = new System.Drawing.Point(159, 242);
            this.tbCountry.Name = "tbCountry";
            this.tbCountry.Size = new System.Drawing.Size(280, 23);
            this.tbCountry.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(124, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 17);
            this.label7.TabIndex = 24;
            this.label7.Text = "City";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(115, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 17);
            this.label8.TabIndex = 25;
            this.label8.Text = "State";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(98, 246);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 17);
            this.label9.TabIndex = 26;
            this.label9.Text = "Country";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(65, 351);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 17);
            this.label11.TabIndex = 29;
            this.label11.Text = "Zygo Contact";
            // 
            // cbddZygoContact
            // 
            this.cbddZygoContact.FormattingEnabled = true;
            this.cbddZygoContact.Location = new System.Drawing.Point(160, 347);
            this.cbddZygoContact.Name = "cbddZygoContact";
            this.cbddZygoContact.Size = new System.Drawing.Size(203, 24);
            this.cbddZygoContact.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(438, 349);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(127, 17);
            this.label12.TabIndex = 31;
            this.label12.Text = "Zygo Administrator";
            // 
            // cbddZygoAdministrator
            // 
            this.cbddZygoAdministrator.FormattingEnabled = true;
            this.cbddZygoAdministrator.Location = new System.Drawing.Point(569, 344);
            this.cbddZygoAdministrator.Name = "cbddZygoAdministrator";
            this.cbddZygoAdministrator.Size = new System.Drawing.Size(203, 24);
            this.cbddZygoAdministrator.TabIndex = 18;
            // 
            // cbRestrictedAccess
            // 
            this.cbRestrictedAccess.AutoSize = true;
            this.cbRestrictedAccess.Location = new System.Drawing.Point(516, 175);
            this.cbRestrictedAccess.Name = "cbRestrictedAccess";
            this.cbRestrictedAccess.Size = new System.Drawing.Size(246, 21);
            this.cbRestrictedAccess.TabIndex = 13;
            this.cbRestrictedAccess.Text = "Restricted Employees Access Only";
            this.cbRestrictedAccess.UseVisualStyleBackColor = true;
            this.cbRestrictedAccess.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbRestrictedAccess_MouseClick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(50, 386);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 17);
            this.label13.TabIndex = 33;
            this.label13.Text = "Party Protected";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(36, 420);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(120, 17);
            this.label14.TabIndex = 34;
            this.label14.Text = "Subject Protected";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(438, 384);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(85, 17);
            this.label18.TabIndex = 39;
            this.label18.Text = "Zygo Signer";
            // 
            // cbddZygoSigner
            // 
            this.cbddZygoSigner.FormattingEnabled = true;
            this.cbddZygoSigner.Location = new System.Drawing.Point(569, 379);
            this.cbddZygoSigner.Name = "cbddZygoSigner";
            this.cbddZygoSigner.Size = new System.Drawing.Size(203, 24);
            this.cbddZygoSigner.TabIndex = 19;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(28, 450);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(127, 17);
            this.label19.TabIndex = 41;
            this.label19.Text = "Termination Notice";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(352, 453);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(144, 17);
            this.label20.TabIndex = 42;
            this.label20.Text = "Life After Termination";
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(531, 204);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersVisible = false;
            this.DGV.Size = new System.Drawing.Size(240, 112);
            this.DGV.TabIndex = 0;
            // 
            // DgvNotes
            // 
            this.DgvNotes.AllowUserToAddRows = false;
            this.DgvNotes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DgvNotes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvNotes.Location = new System.Drawing.Point(62, 662);
            this.DgvNotes.Name = "DgvNotes";
            this.DgvNotes.ReadOnly = true;
            this.DgvNotes.RowHeadersVisible = false;
            this.DgvNotes.Size = new System.Drawing.Size(755, 150);
            this.DgvNotes.TabIndex = 43;
            // 
            // LStatusNotes
            // 
            this.LStatusNotes.AutoSize = true;
            this.LStatusNotes.Location = new System.Drawing.Point(10, 636);
            this.LStatusNotes.Name = "LStatusNotes";
            this.LStatusNotes.Size = new System.Drawing.Size(93, 17);
            this.LStatusNotes.TabIndex = 44;
            this.LStatusNotes.Text = "Status Notes:";
            // 
            // LStatusDate
            // 
            this.LStatusDate.AutoSize = true;
            this.LStatusDate.Location = new System.Drawing.Point(45, 512);
            this.LStatusDate.Name = "LStatusDate";
            this.LStatusDate.Size = new System.Drawing.Size(82, 17);
            this.LStatusDate.TabIndex = 46;
            this.LStatusDate.Text = "Status Date";
            // 
            // dtpStatusDate
            // 
            this.dtpStatusDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStatusDate.Location = new System.Drawing.Point(27, 533);
            this.dtpStatusDate.Name = "dtpStatusDate";
            this.dtpStatusDate.Size = new System.Drawing.Size(120, 23);
            this.dtpStatusDate.TabIndex = 21;
            // 
            // tbStatusNotes
            // 
            this.tbStatusNotes.Location = new System.Drawing.Point(105, 633);
            this.tbStatusNotes.Name = "tbStatusNotes";
            this.tbStatusNotes.Size = new System.Drawing.Size(544, 23);
            this.tbStatusNotes.TabIndex = 33;
            // 
            // dtpDestructionDate
            // 
            this.dtpDestructionDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDestructionDate.Location = new System.Drawing.Point(703, 533);
            this.dtpDestructionDate.Name = "dtpDestructionDate";
            this.dtpDestructionDate.Size = new System.Drawing.Size(120, 23);
            this.dtpDestructionDate.TabIndex = 31;
            this.dtpDestructionDate.Visible = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(521, 80);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(113, 17);
            this.label23.TabIndex = 52;
            this.label23.Text = "Agreement Type";
            // 
            // cbddAgreementType
            // 
            this.cbddAgreementType.FormattingEnabled = true;
            this.cbddAgreementType.Items.AddRange(new object[] {
            "Mutual Zygo",
            "One-Way Zygo",
            "Mutual Supplied",
            "One-Way Supplied",
            "Multi-Party",
            "Other"});
            this.cbddAgreementType.Location = new System.Drawing.Point(638, 75);
            this.cbddAgreementType.Name = "cbddAgreementType";
            this.cbddAgreementType.Size = new System.Drawing.Size(172, 24);
            this.cbddAgreementType.TabIndex = 4;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(30, 305);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(126, 17);
            this.label24.TabIndex = 56;
            this.label24.Tag = "";
            this.label24.Text = "Doing Business As";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(106, 275);
            this.label25.Name = "label25";
            this.label25.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label25.Size = new System.Drawing.Size(50, 17);
            this.label25.TabIndex = 55;
            this.label25.Text = "Parent";
            // 
            // tbDoingBusinessAs
            // 
            this.tbDoingBusinessAs.Location = new System.Drawing.Point(159, 300);
            this.tbDoingBusinessAs.Name = "tbDoingBusinessAs";
            this.tbDoingBusinessAs.Size = new System.Drawing.Size(280, 23);
            this.tbDoingBusinessAs.TabIndex = 12;
            // 
            // tbParent
            // 
            this.tbParent.Location = new System.Drawing.Point(159, 271);
            this.tbParent.Name = "tbParent";
            this.tbParent.Size = new System.Drawing.Size(280, 23);
            this.tbParent.TabIndex = 11;
            // 
            // Bsave
            // 
            this.Bsave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(150)))), ((int)(((byte)(80)))));
            this.Bsave.ForeColor = System.Drawing.Color.White;
            this.Bsave.Location = new System.Drawing.Point(166, 576);
            this.Bsave.Name = "Bsave";
            this.Bsave.Size = new System.Drawing.Size(522, 38);
            this.Bsave.TabIndex = 32;
            this.Bsave.Text = "Save Data";
            this.Bsave.UseVisualStyleBackColor = false;
            this.Bsave.Click += new System.EventHandler(this.Bsave_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(20, 93);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(60, 17);
            this.label26.TabIndex = 59;
            this.label26.Text = "Supplier";
            // 
            // cbddVendor
            // 
            this.cbddVendor.FormattingEnabled = true;
            this.cbddVendor.Items.AddRange(new object[] {
            "Dead Issue",
            "Expired",
            "Expires Soon",
            "Filed",
            "Read and Reviewed",
            "Received",
            "Waiting - Company Signoff",
            "Waiting - Zygo Signoff",
            "Zygo Corporation (One-Way)"});
            this.cbddVendor.Location = new System.Drawing.Point(83, 89);
            this.cbddVendor.Name = "cbddVendor";
            this.cbddVendor.Size = new System.Drawing.Size(357, 24);
            this.cbddVendor.TabIndex = 5;
            this.cbddVendor.SelectedIndexChanged += new System.EventHandler(this.cbddVendor_SelectedIndexChanged);
            this.cbddVendor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbddVendor_MouseClick);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(12, 123);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(68, 17);
            this.label27.TabIndex = 61;
            this.label27.Text = "Customer";
            // 
            // cbddCustomer
            // 
            this.cbddCustomer.FormattingEnabled = true;
            this.cbddCustomer.Items.AddRange(new object[] {
            "Dead Issue",
            "Expired",
            "Expires Soon",
            "Filed",
            "Read and Reviewed",
            "Received",
            "Waiting - Company Signoff",
            "Waiting - Zygo Signoff",
            "Zygo Corporation (One-Way)"});
            this.cbddCustomer.Location = new System.Drawing.Point(83, 119);
            this.cbddCustomer.Name = "cbddCustomer";
            this.cbddCustomer.Size = new System.Drawing.Size(357, 24);
            this.cbddCustomer.TabIndex = 6;
            this.cbddCustomer.SelectedIndexChanged += new System.EventHandler(this.cbddCustomer_SelectedIndexChanged);
            this.cbddCustomer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbddCustomer_MouseClick);
            // 
            // cbEffectiveDate
            // 
            this.cbEffectiveDate.AutoSize = true;
            this.cbEffectiveDate.Location = new System.Drawing.Point(302, 490);
            this.cbEffectiveDate.Name = "cbEffectiveDate";
            this.cbEffectiveDate.Size = new System.Drawing.Size(115, 21);
            this.cbEffectiveDate.TabIndex = 24;
            this.cbEffectiveDate.Text = "Effective Date";
            this.cbEffectiveDate.UseVisualStyleBackColor = true;
            this.cbEffectiveDate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbEffectiveDate_MouseClick);
            // 
            // cbDateRequested
            // 
            this.cbDateRequested.AutoSize = true;
            this.cbDateRequested.Location = new System.Drawing.Point(159, 489);
            this.cbDateRequested.Name = "cbDateRequested";
            this.cbDateRequested.Size = new System.Drawing.Size(130, 21);
            this.cbDateRequested.TabIndex = 22;
            this.cbDateRequested.Text = "Date Requested";
            this.cbDateRequested.UseVisualStyleBackColor = true;
            this.cbDateRequested.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbDateRequested_MouseClick);
            // 
            // cbContractEnds
            // 
            this.cbContractEnds.AutoSize = true;
            this.cbContractEnds.Location = new System.Drawing.Point(436, 489);
            this.cbContractEnds.Name = "cbContractEnds";
            this.cbContractEnds.Size = new System.Drawing.Size(116, 21);
            this.cbContractEnds.TabIndex = 26;
            this.cbContractEnds.Text = "Contract Ends";
            this.cbContractEnds.UseVisualStyleBackColor = true;
            this.cbContractEnds.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbContractEnds_MouseClick);
            // 
            // cbDateOriginalFiled
            // 
            this.cbDateOriginalFiled.AutoSize = true;
            this.cbDateOriginalFiled.Location = new System.Drawing.Point(555, 489);
            this.cbDateOriginalFiled.Name = "cbDateOriginalFiled";
            this.cbDateOriginalFiled.Size = new System.Drawing.Size(144, 21);
            this.cbDateOriginalFiled.TabIndex = 28;
            this.cbDateOriginalFiled.Text = "Date Original Filed";
            this.cbDateOriginalFiled.UseVisualStyleBackColor = true;
            this.cbDateOriginalFiled.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbDateOriginalFiled_MouseClick);
            // 
            // cbDestructionDate
            // 
            this.cbDestructionDate.AutoSize = true;
            this.cbDestructionDate.Location = new System.Drawing.Point(698, 489);
            this.cbDestructionDate.Name = "cbDestructionDate";
            this.cbDestructionDate.Size = new System.Drawing.Size(133, 21);
            this.cbDestructionDate.TabIndex = 30;
            this.cbDestructionDate.Text = "Destruction Date";
            this.cbDestructionDate.UseVisualStyleBackColor = true;
            this.cbDestructionDate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbDestructionDate_MouseClick);
            // 
            // bPrint
            // 
            this.bPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(150)))));
            this.bPrint.ForeColor = System.Drawing.Color.White;
            this.bPrint.Location = new System.Drawing.Point(779, 9);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(76, 56);
            this.bPrint.TabIndex = 35;
            this.bPrint.Text = "Print";
            this.bPrint.UseVisualStyleBackColor = false;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // cbProcurement
            // 
            this.cbProcurement.AutoSize = true;
            this.cbProcurement.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbProcurement.Location = new System.Drawing.Point(508, 48);
            this.cbProcurement.Name = "cbProcurement";
            this.cbProcurement.Size = new System.Drawing.Size(141, 21);
            this.cbProcurement.TabIndex = 2;
            this.cbProcurement.Text = "Procurement NDA";
            this.cbProcurement.UseVisualStyleBackColor = true;
            // 
            // Bpdf
            // 
            this.Bpdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(150)))));
            this.Bpdf.ForeColor = System.Drawing.Color.White;
            this.Bpdf.Location = new System.Drawing.Point(711, 576);
            this.Bpdf.Name = "Bpdf";
            this.Bpdf.Size = new System.Drawing.Size(120, 38);
            this.Bpdf.TabIndex = 62;
            this.Bpdf.Text = "Add PDF";
            this.Bpdf.UseVisualStyleBackColor = false;
            this.Bpdf.Click += new System.EventHandler(this.Bpdf_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "(*.pdf)|*.pdf";
            // 
            // LpdfStored
            // 
            this.LpdfStored.AutoSize = true;
            this.LpdfStored.Location = new System.Drawing.Point(513, 126);
            this.LpdfStored.Name = "LpdfStored";
            this.LpdfStored.Size = new System.Drawing.Size(96, 17);
            this.LpdfStored.TabIndex = 63;
            this.LpdfStored.Text = "pdf Filed = No";
            // 
            // Lrequested
            // 
            this.Lrequested.AutoSize = true;
            this.Lrequested.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.Lrequested.Location = new System.Drawing.Point(175, 512);
            this.Lrequested.Name = "Lrequested";
            this.Lrequested.Size = new System.Drawing.Size(60, 17);
            this.Lrequested.TabIndex = 64;
            this.Lrequested.Text = "no entry";
            // 
            // Leffective
            // 
            this.Leffective.AutoSize = true;
            this.Leffective.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.Leffective.Location = new System.Drawing.Point(321, 512);
            this.Leffective.Name = "Leffective";
            this.Leffective.Size = new System.Drawing.Size(60, 17);
            this.Leffective.TabIndex = 65;
            this.Leffective.Text = "no entry";
            // 
            // Lcontract
            // 
            this.Lcontract.AutoSize = true;
            this.Lcontract.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.Lcontract.Location = new System.Drawing.Point(452, 512);
            this.Lcontract.Name = "Lcontract";
            this.Lcontract.Size = new System.Drawing.Size(60, 17);
            this.Lcontract.TabIndex = 66;
            this.Lcontract.Text = "no entry";
            // 
            // Lfiled
            // 
            this.Lfiled.AutoSize = true;
            this.Lfiled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.Lfiled.Location = new System.Drawing.Point(577, 512);
            this.Lfiled.Name = "Lfiled";
            this.Lfiled.Size = new System.Drawing.Size(60, 17);
            this.Lfiled.TabIndex = 67;
            this.Lfiled.Text = "no entry";
            // 
            // Ldestruction
            // 
            this.Ldestruction.AutoSize = true;
            this.Ldestruction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.Ldestruction.Location = new System.Drawing.Point(718, 512);
            this.Ldestruction.Name = "Ldestruction";
            this.Ldestruction.Size = new System.Drawing.Size(60, 17);
            this.Ldestruction.TabIndex = 68;
            this.Ldestruction.Text = "no entry";
            // 
            // cbInactiveForProcurement
            // 
            this.cbInactiveForProcurement.AutoSize = true;
            this.cbInactiveForProcurement.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbInactiveForProcurement.Location = new System.Drawing.Point(629, 126);
            this.cbInactiveForProcurement.Name = "cbInactiveForProcurement";
            this.cbInactiveForProcurement.Size = new System.Drawing.Size(181, 21);
            this.cbInactiveForProcurement.TabIndex = 69;
            this.cbInactiveForProcurement.Text = "Inactive for Procurement";
            this.cbInactiveForProcurement.UseVisualStyleBackColor = true;
            // 
            // DataEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(864, 900);
            this.Controls.Add(this.cbInactiveForProcurement);
            this.Controls.Add(this.Ldestruction);
            this.Controls.Add(this.Lfiled);
            this.Controls.Add(this.Lcontract);
            this.Controls.Add(this.Leffective);
            this.Controls.Add(this.Lrequested);
            this.Controls.Add(this.LpdfStored);
            this.Controls.Add(this.Bpdf);
            this.Controls.Add(this.cbProcurement);
            this.Controls.Add(this.bPrint);
            this.Controls.Add(this.cbDestructionDate);
            this.Controls.Add(this.cbDateOriginalFiled);
            this.Controls.Add(this.cbContractEnds);
            this.Controls.Add(this.cbDateRequested);
            this.Controls.Add(this.cbEffectiveDate);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.cbddCustomer);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.cbddVendor);
            this.Controls.Add(this.Bsave);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.tbDoingBusinessAs);
            this.Controls.Add(this.tbParent);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.cbddAgreementType);
            this.Controls.Add(this.dtpDestructionDate);
            this.Controls.Add(this.tbStatusNotes);
            this.Controls.Add(this.LStatusDate);
            this.Controls.Add(this.dtpStatusDate);
            this.Controls.Add(this.LStatusNotes);
            this.Controls.Add(this.DgvNotes);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.cbddZygoSigner);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cbRestrictedAccess);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cbddZygoAdministrator);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbddZygoContact);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbCountry);
            this.Controls.Add(this.tbState);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbCompanyContact);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LNdaID);
            this.Controls.Add(this.tbCompany);
            this.Controls.Add(this.tbCity);
            this.Controls.Add(this.dtpContractEnds);
            this.Controls.Add(this.dtpDateOriginalFiled);
            this.Controls.Add(this.dtpEffectiveDate);
            this.Controls.Add(this.dtpDateRequested);
            this.Controls.Add(this.cbddProductLine);
            this.Controls.Add(this.cbddSubjectProtected);
            this.Controls.Add(this.cbddPartyProtected);
            this.Controls.Add(this.cbddLifeAfterTermination);
            this.Controls.Add(this.cbddTerminationNotice);
            this.Controls.Add(this.cbddStatus);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DataEntryForm";
            this.Text = "Non Disclosure Agreement Data Entry Form";
            this.Load += new System.EventHandler(this.DataEntryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvNotes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbddStatus;
        private System.Windows.Forms.ComboBox cbddTerminationNotice;
        private System.Windows.Forms.ComboBox cbddLifeAfterTermination;
        private System.Windows.Forms.ComboBox cbddPartyProtected;
        private System.Windows.Forms.ComboBox cbddSubjectProtected;
        private System.Windows.Forms.ComboBox cbddProductLine;
        private System.Windows.Forms.DateTimePicker dtpDateRequested;
        private System.Windows.Forms.DateTimePicker dtpEffectiveDate;
        private System.Windows.Forms.DateTimePicker dtpDateOriginalFiled;
        private System.Windows.Forms.DateTimePicker dtpContractEnds;
        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.TextBox tbCompany;
        private System.Windows.Forms.Label LNdaID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCompanyContact;
        private System.Windows.Forms.TextBox tbState;
        private System.Windows.Forms.TextBox tbCountry;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbddZygoContact;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbddZygoAdministrator;
        private System.Windows.Forms.CheckBox cbRestrictedAccess;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbddZygoSigner;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.DataGridView DgvNotes;
        private System.Windows.Forms.Label LStatusNotes;
        private System.Windows.Forms.Label LStatusDate;
        private System.Windows.Forms.DateTimePicker dtpStatusDate;
        private System.Windows.Forms.TextBox tbStatusNotes;
        private System.Windows.Forms.DateTimePicker dtpDestructionDate;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cbddAgreementType;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox tbDoingBusinessAs;
        private System.Windows.Forms.TextBox tbParent;
        private System.Windows.Forms.Button Bsave;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox cbddVendor;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox cbddCustomer;
        private System.Windows.Forms.CheckBox cbEffectiveDate;
        private System.Windows.Forms.CheckBox cbDateRequested;
        private System.Windows.Forms.CheckBox cbContractEnds;
        private System.Windows.Forms.CheckBox cbDateOriginalFiled;
        private System.Windows.Forms.CheckBox cbDestructionDate;
        private System.Windows.Forms.Button bPrint;
        private System.Windows.Forms.CheckBox cbProcurement;
        private System.Windows.Forms.Button Bpdf;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label LpdfStored;
        private System.Windows.Forms.Label Lrequested;
        private System.Windows.Forms.Label Leffective;
        private System.Windows.Forms.Label Lcontract;
        private System.Windows.Forms.Label Lfiled;
        private System.Windows.Forms.Label Ldestruction;
        private System.Windows.Forms.CheckBox cbInactiveForProcurement;
    }
}

