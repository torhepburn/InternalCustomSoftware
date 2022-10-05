namespace EnterStatus
{
    partial class StatusData
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
            this.Lcustomer = new System.Windows.Forms.Label();
            this.Lproject = new System.Windows.Forms.Label();
            this.LpartName = new System.Windows.Forms.Label();
            this.LtravelerRev = new System.Windows.Forms.Label();
            this.cbPartSN = new System.Windows.Forms.ComboBox();
            this.LpartID = new System.Windows.Forms.Label();
            this.LprocessStatus = new System.Windows.Forms.Label();
            this.cbPstatus = new System.Windows.Forms.ComboBox();
            this.LtravelerStep = new System.Windows.Forms.Label();
            this.cbTravelerStep = new System.Windows.Forms.ComboBox();
            this.bEnter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Lcustomer
            // 
            this.Lcustomer.AutoSize = true;
            this.Lcustomer.Location = new System.Drawing.Point(49, 43);
            this.Lcustomer.Name = "Lcustomer";
            this.Lcustomer.Size = new System.Drawing.Size(46, 17);
            this.Lcustomer.TabIndex = 0;
            this.Lcustomer.Text = "label1";
            // 
            // Lproject
            // 
            this.Lproject.AutoSize = true;
            this.Lproject.Location = new System.Drawing.Point(49, 77);
            this.Lproject.Name = "Lproject";
            this.Lproject.Size = new System.Drawing.Size(46, 17);
            this.Lproject.TabIndex = 1;
            this.Lproject.Text = "label1";
            // 
            // LpartName
            // 
            this.LpartName.AutoSize = true;
            this.LpartName.Location = new System.Drawing.Point(49, 110);
            this.LpartName.Name = "LpartName";
            this.LpartName.Size = new System.Drawing.Size(46, 17);
            this.LpartName.TabIndex = 2;
            this.LpartName.Text = "label1";
            // 
            // LtravelerRev
            // 
            this.LtravelerRev.AutoSize = true;
            this.LtravelerRev.Location = new System.Drawing.Point(49, 140);
            this.LtravelerRev.Name = "LtravelerRev";
            this.LtravelerRev.Size = new System.Drawing.Size(46, 17);
            this.LtravelerRev.TabIndex = 3;
            this.LtravelerRev.Text = "label1";
            // 
            // cbPartSN
            // 
            this.cbPartSN.FormattingEnabled = true;
            this.cbPartSN.Location = new System.Drawing.Point(171, 168);
            this.cbPartSN.Name = "cbPartSN";
            this.cbPartSN.Size = new System.Drawing.Size(121, 24);
            this.cbPartSN.TabIndex = 4;
            // 
            // LpartID
            // 
            this.LpartID.AutoSize = true;
            this.LpartID.Location = new System.Drawing.Point(49, 171);
            this.LpartID.Name = "LpartID";
            this.LpartID.Size = new System.Drawing.Size(51, 17);
            this.LpartID.TabIndex = 5;
            this.LpartID.Text = "Part ID";
            // 
            // LprocessStatus
            // 
            this.LprocessStatus.AutoSize = true;
            this.LprocessStatus.Location = new System.Drawing.Point(49, 214);
            this.LprocessStatus.Name = "LprocessStatus";
            this.LprocessStatus.Size = new System.Drawing.Size(103, 17);
            this.LprocessStatus.TabIndex = 7;
            this.LprocessStatus.Text = "Process Status";
            // 
            // cbPstatus
            // 
            this.cbPstatus.FormattingEnabled = true;
            this.cbPstatus.Items.AddRange(new object[] {
            "Active",
            "Complete",
            "Waiting"});
            this.cbPstatus.Location = new System.Drawing.Point(171, 211);
            this.cbPstatus.Name = "cbPstatus";
            this.cbPstatus.Size = new System.Drawing.Size(121, 24);
            this.cbPstatus.TabIndex = 6;
            // 
            // LtravelerStep
            // 
            this.LtravelerStep.AutoSize = true;
            this.LtravelerStep.Location = new System.Drawing.Point(49, 255);
            this.LtravelerStep.Name = "LtravelerStep";
            this.LtravelerStep.Size = new System.Drawing.Size(94, 17);
            this.LtravelerStep.TabIndex = 9;
            this.LtravelerStep.Text = "Traveler Step";
            // 
            // cbTravelerStep
            // 
            this.cbTravelerStep.FormattingEnabled = true;
            this.cbTravelerStep.Location = new System.Drawing.Point(171, 252);
            this.cbTravelerStep.Name = "cbTravelerStep";
            this.cbTravelerStep.Size = new System.Drawing.Size(218, 24);
            this.cbTravelerStep.TabIndex = 8;
            // 
            // bEnter
            // 
            this.bEnter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(120)))), ((int)(((byte)(240)))));
            this.bEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bEnter.Location = new System.Drawing.Point(64, 314);
            this.bEnter.Name = "bEnter";
            this.bEnter.Size = new System.Drawing.Size(325, 75);
            this.bEnter.TabIndex = 10;
            this.bEnter.Text = "ENTER DATA";
            this.bEnter.UseVisualStyleBackColor = false;
            this.bEnter.Click += new System.EventHandler(this.bEnter_Click);
            // 
            // StatusData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(120)))), ((int)(((byte)(140)))));
            this.ClientSize = new System.Drawing.Size(455, 440);
            this.Controls.Add(this.bEnter);
            this.Controls.Add(this.LtravelerStep);
            this.Controls.Add(this.cbTravelerStep);
            this.Controls.Add(this.LprocessStatus);
            this.Controls.Add(this.cbPstatus);
            this.Controls.Add(this.LpartID);
            this.Controls.Add(this.cbPartSN);
            this.Controls.Add(this.LtravelerRev);
            this.Controls.Add(this.LpartName);
            this.Controls.Add(this.Lproject);
            this.Controls.Add(this.Lcustomer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "StatusData";
            this.Text = "StatusData";
            this.Load += new System.EventHandler(this.StatusData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lcustomer;
        private System.Windows.Forms.Label Lproject;
        private System.Windows.Forms.Label LpartName;
        private System.Windows.Forms.Label LtravelerRev;
        private System.Windows.Forms.ComboBox cbPartSN;
        private System.Windows.Forms.Label LpartID;
        private System.Windows.Forms.Label LprocessStatus;
        private System.Windows.Forms.ComboBox cbPstatus;
        private System.Windows.Forms.Label LtravelerStep;
        private System.Windows.Forms.ComboBox cbTravelerStep;
        private System.Windows.Forms.Button bEnter;
    }
}