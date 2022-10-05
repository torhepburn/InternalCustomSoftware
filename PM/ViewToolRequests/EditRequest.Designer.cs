namespace ViewToolRequests
{
    partial class EditRequest
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
            this.tbRequest = new System.Windows.Forms.TextBox();
            this.dtpDateNeeded = new System.Windows.Forms.DateTimePicker();
            this.cbddRequestor = new System.Windows.Forms.ComboBox();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.cbddType = new System.Windows.Forms.ComboBox();
            this.Lhours = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTimeSavingsEstimate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCostSavingsEstimate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbddPriority = new System.Windows.Forms.ComboBox();
            this.LID = new System.Windows.Forms.Label();
            this.Bexit = new System.Windows.Forms.Button();
            this.Benter = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tbRevenueSavingsEstimate = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbRequest
            // 
            this.tbRequest.BackColor = System.Drawing.Color.White;
            this.tbRequest.Location = new System.Drawing.Point(121, 388);
            this.tbRequest.Multiline = true;
            this.tbRequest.Name = "tbRequest";
            this.tbRequest.Size = new System.Drawing.Size(510, 95);
            this.tbRequest.TabIndex = 7;
            // 
            // dtpDateNeeded
            // 
            this.dtpDateNeeded.Location = new System.Drawing.Point(121, 99);
            this.dtpDateNeeded.Name = "dtpDateNeeded";
            this.dtpDateNeeded.Size = new System.Drawing.Size(240, 26);
            this.dtpDateNeeded.TabIndex = 9;
            // 
            // cbddRequestor
            // 
            this.cbddRequestor.FormattingEnabled = true;
            this.cbddRequestor.Location = new System.Drawing.Point(121, 147);
            this.cbddRequestor.Name = "cbddRequestor";
            this.cbddRequestor.Size = new System.Drawing.Size(240, 28);
            this.cbddRequestor.TabIndex = 15;
            // 
            // tbQuantity
            // 
            this.tbQuantity.Location = new System.Drawing.Point(121, 234);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(100, 26);
            this.tbQuantity.TabIndex = 18;
            // 
            // cbddType
            // 
            this.cbddType.FormattingEnabled = true;
            this.cbddType.Items.AddRange(new object[] {
            "ROUTINE",
            "URGENT",
            "PRODUCTION DOWN"});
            this.cbddType.Location = new System.Drawing.Point(121, 190);
            this.cbddType.Name = "cbddType";
            this.cbddType.Size = new System.Drawing.Size(240, 28);
            this.cbddType.TabIndex = 19;
            // 
            // Lhours
            // 
            this.Lhours.AutoSize = true;
            this.Lhours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Lhours.Location = new System.Drawing.Point(22, 59);
            this.Lhours.Name = "Lhours";
            this.Lhours.Size = new System.Drawing.Size(67, 20);
            this.Lhours.TabIndex = 20;
            this.Lhours.Text = "Priority:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(22, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Date Needed:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(22, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Requestor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(22, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(22, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "Quantity:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(22, 281);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(186, 20);
            this.label5.TabIndex = 26;
            this.label5.Text = "Time Savings Estimate:";
            // 
            // tbTimeSavingsEstimate
            // 
            this.tbTimeSavingsEstimate.Location = new System.Drawing.Point(182, 278);
            this.tbTimeSavingsEstimate.Name = "tbTimeSavingsEstimate";
            this.tbTimeSavingsEstimate.Size = new System.Drawing.Size(100, 26);
            this.tbTimeSavingsEstimate.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(22, 322);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(184, 20);
            this.label6.TabIndex = 28;
            this.label6.Text = "Cost Savings Estimate:";
            // 
            // tbCostSavingsEstimate
            // 
            this.tbCostSavingsEstimate.Location = new System.Drawing.Point(181, 319);
            this.tbCostSavingsEstimate.Name = "tbCostSavingsEstimate";
            this.tbCostSavingsEstimate.Size = new System.Drawing.Size(100, 26);
            this.tbCostSavingsEstimate.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(22, 391);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 20);
            this.label7.TabIndex = 29;
            this.label7.Text = "Request Text:";
            // 
            // cbddPriority
            // 
            this.cbddPriority.FormattingEnabled = true;
            this.cbddPriority.Items.AddRange(new object[] {
            "PRODUCTION",
            "PROTOTYPE",
            "TOOLING"});
            this.cbddPriority.Location = new System.Drawing.Point(121, 56);
            this.cbddPriority.Name = "cbddPriority";
            this.cbddPriority.Size = new System.Drawing.Size(240, 28);
            this.cbddPriority.TabIndex = 30;
            // 
            // LID
            // 
            this.LID.AutoSize = true;
            this.LID.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.LID.Location = new System.Drawing.Point(30, 19);
            this.LID.Name = "LID";
            this.LID.Size = new System.Drawing.Size(86, 31);
            this.LID.TabIndex = 31;
            this.LID.Text = "label1";
            // 
            // Bexit
            // 
            this.Bexit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.Bexit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Bexit.Location = new System.Drawing.Point(385, 514);
            this.Bexit.Name = "Bexit";
            this.Bexit.Size = new System.Drawing.Size(208, 52);
            this.Bexit.TabIndex = 33;
            this.Bexit.Text = "EXIT";
            this.Bexit.UseVisualStyleBackColor = false;
            this.Bexit.Click += new System.EventHandler(this.Bexit_Click);
            // 
            // Benter
            // 
            this.Benter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(240)))));
            this.Benter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Benter.Location = new System.Drawing.Point(83, 514);
            this.Benter.Name = "Benter";
            this.Benter.Size = new System.Drawing.Size(208, 52);
            this.Benter.TabIndex = 32;
            this.Benter.Text = "ENTER DATA";
            this.Benter.UseVisualStyleBackColor = false;
            this.Benter.Click += new System.EventHandler(this.Benter_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.Location = new System.Drawing.Point(321, 282);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(214, 20);
            this.label8.TabIndex = 35;
            this.label8.Text = "Revenue Savings Estimate:";
            // 
            // tbRevenueSavingsEstimate
            // 
            this.tbRevenueSavingsEstimate.Location = new System.Drawing.Point(541, 279);
            this.tbRevenueSavingsEstimate.Name = "tbRevenueSavingsEstimate";
            this.tbRevenueSavingsEstimate.Size = new System.Drawing.Size(100, 26);
            this.tbRevenueSavingsEstimate.TabIndex = 34;
            // 
            // EditRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(200)))), ((int)(((byte)(190)))));
            this.ClientSize = new System.Drawing.Size(665, 583);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbRevenueSavingsEstimate);
            this.Controls.Add(this.Bexit);
            this.Controls.Add(this.Benter);
            this.Controls.Add(this.LID);
            this.Controls.Add(this.cbddPriority);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbCostSavingsEstimate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbTimeSavingsEstimate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lhours);
            this.Controls.Add(this.cbddType);
            this.Controls.Add(this.tbQuantity);
            this.Controls.Add(this.cbddRequestor);
            this.Controls.Add(this.dtpDateNeeded);
            this.Controls.Add(this.tbRequest);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EditRequest";
            this.Text = "EditRequest";
            this.Load += new System.EventHandler(this.EditRequest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbRequest;
        private System.Windows.Forms.DateTimePicker dtpDateNeeded;
        private System.Windows.Forms.ComboBox cbddRequestor;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.ComboBox cbddType;
        private System.Windows.Forms.Label Lhours;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbTimeSavingsEstimate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCostSavingsEstimate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbddPriority;
        private System.Windows.Forms.Label LID;
        private System.Windows.Forms.Button Bexit;
        private System.Windows.Forms.Button Benter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbRevenueSavingsEstimate;
    }
}