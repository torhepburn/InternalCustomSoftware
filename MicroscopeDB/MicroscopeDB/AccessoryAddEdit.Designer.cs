namespace MicroscopeDB
{
    partial class AccessoryAddEdit
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
            this.label7 = new System.Windows.Forms.Label();
            this.tbPartNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSerialNumber = new System.Windows.Forms.TextBox();
            this.Bsave = new System.Windows.Forms.Button();
            this.bBack = new System.Windows.Forms.Button();
            this.rbObjective = new System.Windows.Forms.RadioButton();
            this.rbStandard = new System.Windows.Forms.RadioButton();
            this.rbOther = new System.Windows.Forms.RadioButton();
            this.LproductLine = new System.Windows.Forms.Label();
            this.Lsn = new System.Windows.Forms.Label();
            this.LDateCode = new System.Windows.Forms.Label();
            this.LserialNumber = new System.Windows.Forms.Label();
            this.bDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(47, 143);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 17);
            this.label7.TabIndex = 160;
            this.label7.Text = "Part Number";
            // 
            // tbPartNumber
            // 
            this.tbPartNumber.Location = new System.Drawing.Point(162, 139);
            this.tbPartNumber.Margin = new System.Windows.Forms.Padding(4);
            this.tbPartNumber.Name = "tbPartNumber";
            this.tbPartNumber.Size = new System.Drawing.Size(197, 23);
            this.tbPartNumber.TabIndex = 162;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(47, 192);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 163;
            this.label1.Text = "Description";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(162, 188);
            this.tbDescription.Margin = new System.Windows.Forms.Padding(4);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(333, 23);
            this.tbDescription.TabIndex = 164;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(47, 237);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 165;
            this.label2.Text = "Serial Number";
            // 
            // tbSerialNumber
            // 
            this.tbSerialNumber.Location = new System.Drawing.Point(162, 233);
            this.tbSerialNumber.Margin = new System.Windows.Forms.Padding(4);
            this.tbSerialNumber.Name = "tbSerialNumber";
            this.tbSerialNumber.Size = new System.Drawing.Size(197, 23);
            this.tbSerialNumber.TabIndex = 166;
            // 
            // Bsave
            // 
            this.Bsave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(50)))));
            this.Bsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Bsave.Location = new System.Drawing.Point(67, 282);
            this.Bsave.Name = "Bsave";
            this.Bsave.Size = new System.Drawing.Size(320, 80);
            this.Bsave.TabIndex = 167;
            this.Bsave.Text = "Save Data";
            this.Bsave.UseVisualStyleBackColor = false;
            this.Bsave.Click += new System.EventHandler(this.Bsave_Click);
            // 
            // bBack
            // 
            this.bBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(240)))), ((int)(((byte)(100)))));
            this.bBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bBack.Location = new System.Drawing.Point(152, 396);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(315, 33);
            this.bBack.TabIndex = 171;
            this.bBack.Text = "Back";
            this.bBack.UseVisualStyleBackColor = false;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // rbObjective
            // 
            this.rbObjective.AutoSize = true;
            this.rbObjective.Location = new System.Drawing.Point(78, 92);
            this.rbObjective.Name = "rbObjective";
            this.rbObjective.Size = new System.Drawing.Size(85, 21);
            this.rbObjective.TabIndex = 172;
            this.rbObjective.TabStop = true;
            this.rbObjective.Text = "Objective";
            this.rbObjective.UseVisualStyleBackColor = true;
            // 
            // rbStandard
            // 
            this.rbStandard.AutoSize = true;
            this.rbStandard.Location = new System.Drawing.Point(229, 92);
            this.rbStandard.Name = "rbStandard";
            this.rbStandard.Size = new System.Drawing.Size(84, 21);
            this.rbStandard.TabIndex = 173;
            this.rbStandard.TabStop = true;
            this.rbStandard.Text = "Standard";
            this.rbStandard.UseVisualStyleBackColor = true;
            // 
            // rbOther
            // 
            this.rbOther.AutoSize = true;
            this.rbOther.Location = new System.Drawing.Point(392, 92);
            this.rbOther.Name = "rbOther";
            this.rbOther.Size = new System.Drawing.Size(131, 21);
            this.rbOther.TabIndex = 174;
            this.rbOther.TabStop = true;
            this.rbOther.Text = "Other Accessory";
            this.rbOther.UseVisualStyleBackColor = true;
            // 
            // LproductLine
            // 
            this.LproductLine.AutoSize = true;
            this.LproductLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.LproductLine.Location = new System.Drawing.Point(22, 9);
            this.LproductLine.Name = "LproductLine";
            this.LproductLine.Size = new System.Drawing.Size(70, 24);
            this.LproductLine.TabIndex = 182;
            this.LproductLine.Text = "label22";
            // 
            // Lsn
            // 
            this.Lsn.AutoSize = true;
            this.Lsn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lsn.Location = new System.Drawing.Point(184, 46);
            this.Lsn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lsn.Name = "Lsn";
            this.Lsn.Size = new System.Drawing.Size(69, 20);
            this.Lsn.TabIndex = 190;
            this.Lsn.Text = "XXXXX";
            // 
            // LDateCode
            // 
            this.LDateCode.AutoSize = true;
            this.LDateCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LDateCode.Location = new System.Drawing.Point(133, 46);
            this.LDateCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LDateCode.Name = "LDateCode";
            this.LDateCode.Size = new System.Drawing.Size(63, 20);
            this.LDateCode.TabIndex = 189;
            this.LDateCode.Text = "XX-XX-";
            // 
            // LserialNumber
            // 
            this.LserialNumber.AutoSize = true;
            this.LserialNumber.Location = new System.Drawing.Point(23, 46);
            this.LserialNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LserialNumber.Name = "LserialNumber";
            this.LserialNumber.Size = new System.Drawing.Size(102, 17);
            this.LserialNumber.TabIndex = 188;
            this.LserialNumber.Text = "Serial Number:";
            // 
            // bDelete
            // 
            this.bDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(80)))), ((int)(((byte)(50)))));
            this.bDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bDelete.Location = new System.Drawing.Point(427, 282);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(96, 80);
            this.bDelete.TabIndex = 191;
            this.bDelete.Text = "Delete";
            this.bDelete.UseVisualStyleBackColor = false;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // AccessoryAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(130)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(604, 456);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.Lsn);
            this.Controls.Add(this.LDateCode);
            this.Controls.Add(this.LserialNumber);
            this.Controls.Add(this.LproductLine);
            this.Controls.Add(this.rbOther);
            this.Controls.Add(this.rbStandard);
            this.Controls.Add(this.rbObjective);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.Bsave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSerialNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbPartNumber);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AccessoryAddEdit";
            this.Text = "AccessoryAddEdit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AccessoryAddEdit_FormClosing);
            this.Load += new System.EventHandler(this.AccessoryAddEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbPartNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSerialNumber;
        private System.Windows.Forms.Button Bsave;
        private System.Windows.Forms.Button bBack;
        private System.Windows.Forms.RadioButton rbObjective;
        private System.Windows.Forms.RadioButton rbStandard;
        private System.Windows.Forms.RadioButton rbOther;
        private System.Windows.Forms.Label LproductLine;
        private System.Windows.Forms.Label Lsn;
        private System.Windows.Forms.Label LDateCode;
        private System.Windows.Forms.Label LserialNumber;
        private System.Windows.Forms.Button bDelete;
    }
}