namespace ViewToolRequests
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
            this.tbHours = new System.Windows.Forms.TextBox();
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
            this.cbSavings = new System.Windows.Forms.CheckBox();
            this.BOpenDxf = new System.Windows.Forms.Button();
            this.cbddType = new System.Windows.Forms.ComboBox();
            this.bEditRequest = new System.Windows.Forms.Button();
            this.Breject = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbHours
            // 
            this.tbHours.Location = new System.Drawing.Point(148, 258);
            this.tbHours.Name = "tbHours";
            this.tbHours.Size = new System.Drawing.Size(100, 20);
            this.tbHours.TabIndex = 0;
            // 
            // Benter
            // 
            this.Benter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(240)))));
            this.Benter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Benter.Location = new System.Drawing.Point(52, 427);
            this.Benter.Name = "Benter";
            this.Benter.Size = new System.Drawing.Size(150, 50);
            this.Benter.TabIndex = 1;
            this.Benter.Text = "ENTER DATA";
            this.Benter.UseVisualStyleBackColor = false;
            this.Benter.Click += new System.EventHandler(this.Benter_Click);
            // 
            // cbCompleted
            // 
            this.cbCompleted.AutoSize = true;
            this.cbCompleted.Location = new System.Drawing.Point(52, 187);
            this.cbCompleted.Name = "cbCompleted";
            this.cbCompleted.Size = new System.Drawing.Size(173, 17);
            this.cbCompleted.TabIndex = 2;
            this.cbCompleted.Text = "Completed.  Select date below:";
            this.cbCompleted.UseVisualStyleBackColor = true;
            // 
            // LID
            // 
            this.LID.AutoSize = true;
            this.LID.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.LID.Location = new System.Drawing.Point(128, 24);
            this.LID.Name = "LID";
            this.LID.Size = new System.Drawing.Size(70, 26);
            this.LID.TabIndex = 3;
            this.LID.Text = "label1";
            // 
            // bOpenPDF
            // 
            this.bOpenPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(240)))));
            this.bOpenPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bOpenPDF.Location = new System.Drawing.Point(439, 187);
            this.bOpenPDF.Name = "bOpenPDF";
            this.bOpenPDF.Size = new System.Drawing.Size(123, 52);
            this.bOpenPDF.TabIndex = 4;
            this.bOpenPDF.Text = "OPEN PDF FILE";
            this.bOpenPDF.UseVisualStyleBackColor = false;
            this.bOpenPDF.Visible = false;
            this.bOpenPDF.Click += new System.EventHandler(this.bOpenPDF_Click);
            // 
            // Lhours
            // 
            this.Lhours.AutoSize = true;
            this.Lhours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Lhours.Location = new System.Drawing.Point(49, 258);
            this.Lhours.Name = "Lhours";
            this.Lhours.Size = new System.Drawing.Size(93, 17);
            this.Lhours.TabIndex = 5;
            this.Lhours.Text = "Actual Hours:";
            // 
            // tbRequest
            // 
            this.tbRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(160)))));
            this.tbRequest.Location = new System.Drawing.Point(52, 73);
            this.tbRequest.Multiline = true;
            this.tbRequest.Name = "tbRequest";
            this.tbRequest.ReadOnly = true;
            this.tbRequest.Size = new System.Drawing.Size(510, 95);
            this.tbRequest.TabIndex = 6;
            // 
            // dtpCompletionDate
            // 
            this.dtpCompletionDate.Location = new System.Drawing.Point(52, 219);
            this.dtpCompletionDate.Name = "dtpCompletionDate";
            this.dtpCompletionDate.Size = new System.Drawing.Size(200, 20);
            this.dtpCompletionDate.TabIndex = 8;
            // 
            // tbComments
            // 
            this.tbComments.Location = new System.Drawing.Point(52, 309);
            this.tbComments.Multiline = true;
            this.tbComments.Name = "tbComments";
            this.tbComments.Size = new System.Drawing.Size(510, 95);
            this.tbComments.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(49, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Notes/Comments:";
            // 
            // Bexit
            // 
            this.Bexit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.Bexit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Bexit.Location = new System.Drawing.Point(412, 427);
            this.Bexit.Name = "Bexit";
            this.Bexit.Size = new System.Drawing.Size(150, 50);
            this.Bexit.TabIndex = 11;
            this.Bexit.Text = "EXIT";
            this.Bexit.UseVisualStyleBackColor = false;
            this.Bexit.Click += new System.EventHandler(this.Bexit_Click);
            // 
            // cbSavings
            // 
            this.cbSavings.AutoSize = true;
            this.cbSavings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbSavings.Location = new System.Drawing.Point(277, 258);
            this.cbSavings.Name = "cbSavings";
            this.cbSavings.Size = new System.Drawing.Size(148, 24);
            this.cbSavings.TabIndex = 12;
            this.cbSavings.Text = "COST SAVINGS";
            this.cbSavings.UseVisualStyleBackColor = true;
            // 
            // BOpenDxf
            // 
            this.BOpenDxf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(180)))), ((int)(((byte)(120)))));
            this.BOpenDxf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BOpenDxf.Location = new System.Drawing.Point(292, 187);
            this.BOpenDxf.Name = "BOpenDxf";
            this.BOpenDxf.Size = new System.Drawing.Size(123, 52);
            this.BOpenDxf.TabIndex = 13;
            this.BOpenDxf.Text = "OPEN DXF FILE";
            this.BOpenDxf.UseVisualStyleBackColor = false;
            this.BOpenDxf.Visible = false;
            this.BOpenDxf.Click += new System.EventHandler(this.BOpenDxf_Click);
            // 
            // cbddType
            // 
            this.cbddType.FormattingEnabled = true;
            this.cbddType.Items.AddRange(new object[] {
            "PRODUCTION",
            "PROTOTYPE",
            "TOOLING"});
            this.cbddType.Location = new System.Drawing.Point(441, 258);
            this.cbddType.Name = "cbddType";
            this.cbddType.Size = new System.Drawing.Size(121, 21);
            this.cbddType.TabIndex = 14;
            // 
            // bEditRequest
            // 
            this.bEditRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(220)))), ((int)(((byte)(125)))));
            this.bEditRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bEditRequest.Location = new System.Drawing.Point(439, 12);
            this.bEditRequest.Name = "bEditRequest";
            this.bEditRequest.Size = new System.Drawing.Size(123, 52);
            this.bEditRequest.TabIndex = 15;
            this.bEditRequest.Text = "EDIT REQUEST";
            this.bEditRequest.UseVisualStyleBackColor = false;
            this.bEditRequest.Click += new System.EventHandler(this.bEditRequest_Click);
            // 
            // Breject
            // 
            this.Breject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(200)))), ((int)(((byte)(100)))));
            this.Breject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Breject.Location = new System.Drawing.Point(233, 427);
            this.Breject.Name = "Breject";
            this.Breject.Size = new System.Drawing.Size(150, 50);
            this.Breject.TabIndex = 16;
            this.Breject.Text = "REJECT";
            this.Breject.UseVisualStyleBackColor = false;
            this.Breject.Click += new System.EventHandler(this.Breject_Click);
            // 
            // JobData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(200)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(636, 506);
            this.Controls.Add(this.Breject);
            this.Controls.Add(this.bEditRequest);
            this.Controls.Add(this.cbddType);
            this.Controls.Add(this.BOpenDxf);
            this.Controls.Add(this.cbSavings);
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
            this.Controls.Add(this.tbHours);
            this.Name = "JobData";
            this.Text = "JobData";
            this.Load += new System.EventHandler(this.JobData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbHours;
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
        private System.Windows.Forms.CheckBox cbSavings;
        private System.Windows.Forms.Button BOpenDxf;
        private System.Windows.Forms.ComboBox cbddType;
        private System.Windows.Forms.Button bEditRequest;
        private System.Windows.Forms.Button Breject;
    }
}