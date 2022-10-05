namespace PMManager
{
    partial class EmergencyRepair
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
            this.tbCategory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbEquipID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbLocation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTrouble = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDateTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCostCenter = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbContactEmail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbOwnerEmail = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbCategory
            // 
            this.tbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbCategory.Location = new System.Drawing.Point(195, 53);
            this.tbCategory.Name = "tbCategory";
            this.tbCategory.Size = new System.Drawing.Size(401, 26);
            this.tbCategory.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(100, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Category";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.Location = new System.Drawing.Point(410, 623);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(186, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(100, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Equip ID";
            // 
            // tbEquipID
            // 
            this.tbEquipID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbEquipID.Location = new System.Drawing.Point(195, 108);
            this.tbEquipID.Name = "tbEquipID";
            this.tbEquipID.Size = new System.Drawing.Size(401, 26);
            this.tbEquipID.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(100, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Location";
            // 
            // tbLocation
            // 
            this.tbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbLocation.Location = new System.Drawing.Point(195, 159);
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.Size = new System.Drawing.Size(401, 26);
            this.tbLocation.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(100, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Trouble";
            // 
            // tbTrouble
            // 
            this.tbTrouble.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbTrouble.Location = new System.Drawing.Point(195, 216);
            this.tbTrouble.Name = "tbTrouble";
            this.tbTrouble.Size = new System.Drawing.Size(401, 26);
            this.tbTrouble.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(64, 443);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Date and time";
            // 
            // tbDateTime
            // 
            this.tbDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbDateTime.Location = new System.Drawing.Point(195, 437);
            this.tbDateTime.Name = "tbDateTime";
            this.tbDateTime.Size = new System.Drawing.Size(401, 26);
            this.tbDateTime.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(57, 380);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Cost Center";
            // 
            // tbCostCenter
            // 
            this.tbCostCenter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbCostCenter.Location = new System.Drawing.Point(195, 380);
            this.tbCostCenter.Name = "tbCostCenter";
            this.tbCostCenter.Size = new System.Drawing.Size(401, 26);
            this.tbCostCenter.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(54, 335);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Contact Email";
            // 
            // tbContactEmail
            // 
            this.tbContactEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbContactEmail.Location = new System.Drawing.Point(195, 329);
            this.tbContactEmail.Name = "tbContactEmail";
            this.tbContactEmail.Size = new System.Drawing.Size(401, 26);
            this.tbContactEmail.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.Location = new System.Drawing.Point(100, 277);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbName.Location = new System.Drawing.Point(195, 274);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(401, 26);
            this.tbName.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label9.Location = new System.Drawing.Point(64, 496);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "Owner Email";
            // 
            // tbOwnerEmail
            // 
            this.tbOwnerEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbOwnerEmail.Location = new System.Drawing.Point(195, 490);
            this.tbOwnerEmail.Name = "tbOwnerEmail";
            this.tbOwnerEmail.Size = new System.Drawing.Size(401, 26);
            this.tbOwnerEmail.TabIndex = 17;
            // 
            // EmergencyRepair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(640, 693);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbOwnerEmail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbDateTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbCostCenter);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbContactEmail);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbTrouble);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbEquipID);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCategory);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "EmergencyRepair";
            this.Text = "EmergencyRepair";
            this.Load += new System.EventHandler(this.EmergencyRepair_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbEquipID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTrouble;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDateTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCostCenter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbContactEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbOwnerEmail;
    }
}