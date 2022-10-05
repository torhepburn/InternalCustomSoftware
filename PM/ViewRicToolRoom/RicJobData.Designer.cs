namespace ViewRicToolRoom
{
    partial class JobData
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
            this.tbFabTime = new System.Windows.Forms.TextBox();
            this.Benter = new System.Windows.Forms.Button();
            this.cbCompleted = new System.Windows.Forms.CheckBox();
            this.LID = new System.Windows.Forms.Label();
            this.bOpenPDF = new System.Windows.Forms.Button();
            this.Lhours = new System.Windows.Forms.Label();
            this.tbRequest = new System.Windows.Forms.TextBox();
            this.dtpCompletionDate = new System.Windows.Forms.DateTimePicker();
            this.tbComments = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Bexit = new System.Windows.Forms.Button();
            this.BOpenDxf = new System.Windows.Forms.Button();
            this.bEditRequest = new System.Windows.Forms.Button();
            this.Breject = new System.Windows.Forms.Button();
            this.tbAdditionalInformation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTechnicalContactName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDesignReviewParticipants = new System.Windows.Forms.TextBox();
            this.dtpEstimatedDueDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbDesignTime = new System.Windows.Forms.TextBox();
            this.cbddStatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbJob = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbMachinist = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbDesigner = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbToolDescription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbFabTime
            // 
            this.tbFabTime.Location = new System.Drawing.Point(251, 286);
            this.tbFabTime.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbFabTime.Name = "tbFabTime";
            this.tbFabTime.Size = new System.Drawing.Size(116, 23);
            this.tbFabTime.TabIndex = 0;
            // 
            // Benter
            // 
            this.Benter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(240)))));
            this.Benter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Benter.Location = new System.Drawing.Point(61, 641);
            this.Benter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Benter.Name = "Benter";
            this.Benter.Size = new System.Drawing.Size(175, 58);
            this.Benter.TabIndex = 1;
            this.Benter.Text = "ENTER DATA";
            this.Benter.UseVisualStyleBackColor = false;
            this.Benter.Click += new System.EventHandler(this.Benter_Click);
            // 
            // cbCompleted
            // 
            this.cbCompleted.AutoSize = true;
            this.cbCompleted.Location = new System.Drawing.Point(734, 595);
            this.cbCompleted.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbCompleted.Name = "cbCompleted";
            this.cbCompleted.Size = new System.Drawing.Size(189, 19);
            this.cbCompleted.TabIndex = 2;
            this.cbCompleted.Text = "Completed.  Select date below:";
            this.cbCompleted.UseVisualStyleBackColor = true;
            // 
            // LID
            // 
            this.LID.AutoSize = true;
            this.LID.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LID.Location = new System.Drawing.Point(149, 28);
            this.LID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LID.Name = "LID";
            this.LID.Size = new System.Drawing.Size(70, 26);
            this.LID.TabIndex = 3;
            this.LID.Text = "label1";
            // 
            // bOpenPDF
            // 
            this.bOpenPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(240)))));
            this.bOpenPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bOpenPDF.Location = new System.Drawing.Point(512, 205);
            this.bOpenPDF.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bOpenPDF.Name = "bOpenPDF";
            this.bOpenPDF.Size = new System.Drawing.Size(144, 60);
            this.bOpenPDF.TabIndex = 4;
            this.bOpenPDF.Text = "OPEN PDF FILE";
            this.bOpenPDF.UseVisualStyleBackColor = false;
            this.bOpenPDF.Visible = false;
            this.bOpenPDF.Click += new System.EventHandler(this.bOpenPDF_Click);
            // 
            // Lhours
            // 
            this.Lhours.AutoSize = true;
            this.Lhours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Lhours.Location = new System.Drawing.Point(60, 288);
            this.Lhours.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lhours.Name = "Lhours";
            this.Lhours.Size = new System.Drawing.Size(171, 17);
            this.Lhours.TabIndex = 5;
            this.Lhours.Text = "Estimated Fab Time (hrs):";
            // 
            // tbRequest
            // 
            this.tbRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(160)))));
            this.tbRequest.Location = new System.Drawing.Point(61, 84);
            this.tbRequest.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbRequest.Multiline = true;
            this.tbRequest.Name = "tbRequest";
            this.tbRequest.ReadOnly = true;
            this.tbRequest.Size = new System.Drawing.Size(594, 109);
            this.tbRequest.TabIndex = 6;
            // 
            // dtpCompletionDate
            // 
            this.dtpCompletionDate.Location = new System.Drawing.Point(734, 632);
            this.dtpCompletionDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtpCompletionDate.Name = "dtpCompletionDate";
            this.dtpCompletionDate.Size = new System.Drawing.Size(233, 23);
            this.dtpCompletionDate.TabIndex = 8;
            // 
            // tbComments
            // 
            this.tbComments.Location = new System.Drawing.Point(61, 505);
            this.tbComments.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbComments.Multiline = true;
            this.tbComments.Name = "tbComments";
            this.tbComments.Size = new System.Drawing.Size(594, 109);
            this.tbComments.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(57, 481);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Notes/Comments:";
            // 
            // Bexit
            // 
            this.Bexit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.Bexit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Bexit.Location = new System.Drawing.Point(481, 641);
            this.Bexit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Bexit.Name = "Bexit";
            this.Bexit.Size = new System.Drawing.Size(175, 58);
            this.Bexit.TabIndex = 11;
            this.Bexit.Text = "EXIT";
            this.Bexit.UseVisualStyleBackColor = false;
            this.Bexit.Click += new System.EventHandler(this.Bexit_Click);
            // 
            // BOpenDxf
            // 
            this.BOpenDxf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(180)))), ((int)(((byte)(120)))));
            this.BOpenDxf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BOpenDxf.Location = new System.Drawing.Point(341, 205);
            this.BOpenDxf.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BOpenDxf.Name = "BOpenDxf";
            this.BOpenDxf.Size = new System.Drawing.Size(144, 60);
            this.BOpenDxf.TabIndex = 13;
            this.BOpenDxf.Text = "OPEN DXF FILE";
            this.BOpenDxf.UseVisualStyleBackColor = false;
            this.BOpenDxf.Visible = false;
            this.BOpenDxf.Click += new System.EventHandler(this.BOpenDxf_Click);
            // 
            // bEditRequest
            // 
            this.bEditRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(220)))), ((int)(((byte)(125)))));
            this.bEditRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bEditRequest.Location = new System.Drawing.Point(1125, 12);
            this.bEditRequest.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bEditRequest.Name = "bEditRequest";
            this.bEditRequest.Size = new System.Drawing.Size(144, 60);
            this.bEditRequest.TabIndex = 15;
            this.bEditRequest.Text = "EDIT REQUEST";
            this.bEditRequest.UseVisualStyleBackColor = false;
            this.bEditRequest.Click += new System.EventHandler(this.bEditRequest_Click);
            // 
            // Breject
            // 
            this.Breject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(200)))), ((int)(((byte)(100)))));
            this.Breject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Breject.Location = new System.Drawing.Point(272, 641);
            this.Breject.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Breject.Name = "Breject";
            this.Breject.Size = new System.Drawing.Size(175, 58);
            this.Breject.TabIndex = 16;
            this.Breject.Text = "REJECT";
            this.Breject.UseVisualStyleBackColor = false;
            this.Breject.Click += new System.EventHandler(this.Breject_Click);
            // 
            // tbAdditionalInformation
            // 
            this.tbAdditionalInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(160)))));
            this.tbAdditionalInformation.Location = new System.Drawing.Point(675, 84);
            this.tbAdditionalInformation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbAdditionalInformation.Multiline = true;
            this.tbAdditionalInformation.Name = "tbAdditionalInformation";
            this.tbAdditionalInformation.ReadOnly = true;
            this.tbAdditionalInformation.Size = new System.Drawing.Size(594, 109);
            this.tbAdditionalInformation.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(60, 435);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Contact for technical info:";
            // 
            // tbTechnicalContactName
            // 
            this.tbTechnicalContactName.Location = new System.Drawing.Point(231, 433);
            this.tbTechnicalContactName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbTechnicalContactName.Name = "tbTechnicalContactName";
            this.tbTechnicalContactName.Size = new System.Drawing.Size(268, 23);
            this.tbTechnicalContactName.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(61, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "Tool Requirements:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(675, 64);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "Additional Info:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(533, 435);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 17);
            this.label5.TabIndex = 23;
            this.label5.Text = "Design Review Participants:";
            // 
            // tbDesignReviewParticipants
            // 
            this.tbDesignReviewParticipants.Location = new System.Drawing.Point(724, 433);
            this.tbDesignReviewParticipants.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbDesignReviewParticipants.Multiline = true;
            this.tbDesignReviewParticipants.Name = "tbDesignReviewParticipants";
            this.tbDesignReviewParticipants.Size = new System.Drawing.Size(268, 98);
            this.tbDesignReviewParticipants.TabIndex = 22;
            // 
            // dtpEstimatedDueDate
            // 
            this.dtpEstimatedDueDate.Location = new System.Drawing.Point(226, 373);
            this.dtpEstimatedDueDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtpEstimatedDueDate.Name = "dtpEstimatedDueDate";
            this.dtpEstimatedDueDate.Size = new System.Drawing.Size(233, 23);
            this.dtpEstimatedDueDate.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(60, 376);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 17);
            this.label6.TabIndex = 25;
            this.label6.Text = "Estimated Due Date:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(60, 331);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(191, 17);
            this.label7.TabIndex = 27;
            this.label7.Text = "Estimated Design Time (hrs):";
            // 
            // tbDesignTime
            // 
            this.tbDesignTime.Location = new System.Drawing.Point(252, 329);
            this.tbDesignTime.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbDesignTime.Name = "tbDesignTime";
            this.tbDesignTime.Size = new System.Drawing.Size(116, 23);
            this.tbDesignTime.TabIndex = 26;
            // 
            // cbddStatus
            // 
            this.cbddStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbddStatus.FormattingEnabled = true;
            this.cbddStatus.Items.AddRange(new object[] {
            "",
            "Design Review",
            "On Hold",
            "In Progress",
            "Completed"});
            this.cbddStatus.Location = new System.Drawing.Point(916, 221);
            this.cbddStatus.Name = "cbddStatus";
            this.cbddStatus.Size = new System.Drawing.Size(139, 29);
            this.cbddStatus.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(847, 223);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 17);
            this.label8.TabIndex = 32;
            this.label8.Text = "Status:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(532, 333);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 17);
            this.label9.TabIndex = 36;
            this.label9.Text = "Code";
            // 
            // tbCode
            // 
            this.tbCode.Location = new System.Drawing.Point(698, 331);
            this.tbCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(116, 23);
            this.tbCode.TabIndex = 35;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(533, 290);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 17);
            this.label10.TabIndex = 34;
            this.label10.Text = "Job:";
            // 
            // tbJob
            // 
            this.tbJob.Location = new System.Drawing.Point(698, 288);
            this.tbJob.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbJob.Name = "tbJob";
            this.tbJob.Size = new System.Drawing.Size(116, 23);
            this.tbJob.TabIndex = 33;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(532, 378);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 17);
            this.label11.TabIndex = 38;
            this.label11.Text = "Number";
            // 
            // tbNumber
            // 
            this.tbNumber.Location = new System.Drawing.Point(698, 376);
            this.tbNumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(116, 23);
            this.tbNumber.TabIndex = 37;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(898, 380);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 17);
            this.label12.TabIndex = 44;
            this.label12.Text = "Machinist:";
            // 
            // tbMachinist
            // 
            this.tbMachinist.Location = new System.Drawing.Point(1064, 378);
            this.tbMachinist.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbMachinist.Name = "tbMachinist";
            this.tbMachinist.Size = new System.Drawing.Size(116, 23);
            this.tbMachinist.TabIndex = 43;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(898, 335);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 17);
            this.label13.TabIndex = 42;
            this.label13.Text = "Designer:";
            // 
            // tbDesigner
            // 
            this.tbDesigner.Location = new System.Drawing.Point(1064, 333);
            this.tbDesigner.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbDesigner.Name = "tbDesigner";
            this.tbDesigner.Size = new System.Drawing.Size(116, 23);
            this.tbDesigner.TabIndex = 41;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(899, 292);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(115, 17);
            this.label14.TabIndex = 40;
            this.label14.Text = "Tool Description:";
            // 
            // tbToolDescription
            // 
            this.tbToolDescription.Location = new System.Drawing.Point(1064, 290);
            this.tbToolDescription.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbToolDescription.Name = "tbToolDescription";
            this.tbToolDescription.Size = new System.Drawing.Size(270, 23);
            this.tbToolDescription.TabIndex = 39;
            // 
            // JobData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(200)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1361, 727);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbMachinist);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tbDesigner);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tbToolDescription);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbNumber);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbJob);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbddStatus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbDesignTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpEstimatedDueDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbDesignReviewParticipants);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbTechnicalContactName);
            this.Controls.Add(this.tbAdditionalInformation);
            this.Controls.Add(this.Breject);
            this.Controls.Add(this.bEditRequest);
            this.Controls.Add(this.BOpenDxf);
            this.Controls.Add(this.Bexit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbComments);
            this.Controls.Add(this.dtpCompletionDate);
            this.Controls.Add(this.tbRequest);
            this.Controls.Add(this.Lhours);
            this.Controls.Add(this.bOpenPDF);
            this.Controls.Add(this.LID);
            this.Controls.Add(this.cbCompleted);
            this.Controls.Add(this.Benter);
            this.Controls.Add(this.tbFabTime);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "JobData";
            this.Text = "JobData";
            this.Load += new System.EventHandler(this.JobData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFabTime;
        private System.Windows.Forms.Button Benter;
        private System.Windows.Forms.CheckBox cbCompleted;
        private System.Windows.Forms.Label LID;
        private System.Windows.Forms.Button bOpenPDF;
        private System.Windows.Forms.Label Lhours;
        private System.Windows.Forms.TextBox tbRequest;
        private System.Windows.Forms.DateTimePicker dtpCompletionDate;
        private System.Windows.Forms.TextBox tbComments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Bexit;
        private System.Windows.Forms.Button BOpenDxf;
        private System.Windows.Forms.Button bEditRequest;
        private System.Windows.Forms.Button Breject;
        private System.Windows.Forms.TextBox tbAdditionalInformation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTechnicalContactName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDesignReviewParticipants;
        private System.Windows.Forms.DateTimePicker dtpEstimatedDueDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbDesignTime;
        private System.Windows.Forms.ComboBox cbddStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbJob;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbNumber;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbMachinist;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbDesigner;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbToolDescription;
    }
}