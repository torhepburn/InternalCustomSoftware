namespace MethodSheet1
{
    partial class F2_EnterReleaseData
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
            this.tbWOnumber = new System.Windows.Forms.TextBox();
            this.tbLotSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbInitials = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbRevision = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSerialNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPartNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bEnterData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "WO Number";
            // 
            // tbWOnumber
            // 
            this.tbWOnumber.Location = new System.Drawing.Point(191, 74);
            this.tbWOnumber.Name = "tbWOnumber";
            this.tbWOnumber.Size = new System.Drawing.Size(228, 26);
            this.tbWOnumber.TabIndex = 1;
            // 
            // tbLotSize
            // 
            this.tbLotSize.Location = new System.Drawing.Point(191, 127);
            this.tbLotSize.Name = "tbLotSize";
            this.tbLotSize.Size = new System.Drawing.Size(228, 26);
            this.tbLotSize.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lot Size";
            // 
            // tbInitials
            // 
            this.tbInitials.Location = new System.Drawing.Point(191, 183);
            this.tbInitials.Name = "tbInitials";
            this.tbInitials.Size = new System.Drawing.Size(228, 26);
            this.tbInitials.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Initials";
            // 
            // tbRevision
            // 
            this.tbRevision.Location = new System.Drawing.Point(191, 238);
            this.tbRevision.Name = "tbRevision";
            this.tbRevision.Size = new System.Drawing.Size(228, 26);
            this.tbRevision.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Revision";
            // 
            // tbSerialNumber
            // 
            this.tbSerialNumber.Location = new System.Drawing.Point(191, 294);
            this.tbSerialNumber.Name = "tbSerialNumber";
            this.tbSerialNumber.Size = new System.Drawing.Size(228, 26);
            this.tbSerialNumber.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Serial Number";
            // 
            // tbPartNumber
            // 
            this.tbPartNumber.Location = new System.Drawing.Point(191, 25);
            this.tbPartNumber.Name = "tbPartNumber";
            this.tbPartNumber.Size = new System.Drawing.Size(228, 26);
            this.tbPartNumber.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Part Number";
            // 
            // bEnterData
            // 
            this.bEnterData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(140)))));
            this.bEnterData.Location = new System.Drawing.Point(60, 357);
            this.bEnterData.Name = "bEnterData";
            this.bEnterData.Size = new System.Drawing.Size(358, 49);
            this.bEnterData.TabIndex = 6;
            this.bEnterData.Text = "ENTER DATA";
            this.bEnterData.UseVisualStyleBackColor = false;
            this.bEnterData.Click += new System.EventHandler(this.bEnterData_Click);
            // 
            // F2_EnterReleaseData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(160)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(493, 434);
            this.Controls.Add(this.bEnterData);
            this.Controls.Add(this.tbPartNumber);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbSerialNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbRevision);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbInitials);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbLotSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbWOnumber);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F2_EnterReleaseData";
            this.Text = "F2_EnterReleaseData";
            this.Load += new System.EventHandler(this.F2_EnterReleaseData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbWOnumber;
        private System.Windows.Forms.TextBox tbLotSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbInitials;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbRevision;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSerialNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbPartNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bEnterData;
    }
}