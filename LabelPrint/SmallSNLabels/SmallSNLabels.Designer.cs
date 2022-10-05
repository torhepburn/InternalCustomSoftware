namespace SmallSNLabels
{
    partial class SmallSNLabels
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
            this.bPrint = new System.Windows.Forms.Button();
            this.tbSerialNumber = new System.Windows.Forms.TextBox();
            this.rb01Silver = new System.Windows.Forms.RadioButton();
            this.rb02Gold = new System.Windows.Forms.RadioButton();
            this.rb03Green = new System.Windows.Forms.RadioButton();
            this.rb04Blue = new System.Windows.Forms.RadioButton();
            this.rb00Red = new System.Windows.Forms.RadioButton();
            this.gbQuantity = new System.Windows.Forms.GroupBox();
            this.rbOneHundred = new System.Windows.Forms.RadioButton();
            this.rbTen = new System.Windows.Forms.RadioButton();
            this.rbOne = new System.Windows.Forms.RadioButton();
            this.rbFreeText = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.gbQuantity.SuspendLayout();
            this.SuspendLayout();
            // 
            // bPrint
            // 
            this.bPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(240)))), ((int)(((byte)(160)))));
            this.bPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bPrint.Location = new System.Drawing.Point(390, 137);
            this.bPrint.Margin = new System.Windows.Forms.Padding(4);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(124, 52);
            this.bPrint.TabIndex = 11;
            this.bPrint.Text = "Print Label";
            this.bPrint.UseVisualStyleBackColor = false;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // tbSerialNumber
            // 
            this.tbSerialNumber.Location = new System.Drawing.Point(402, 76);
            this.tbSerialNumber.Name = "tbSerialNumber";
            this.tbSerialNumber.Size = new System.Drawing.Size(100, 23);
            this.tbSerialNumber.TabIndex = 10;
            // 
            // rb01Silver
            // 
            this.rb01Silver.AutoSize = true;
            this.rb01Silver.Location = new System.Drawing.Point(41, 68);
            this.rb01Silver.Name = "rb01Silver";
            this.rb01Silver.Size = new System.Drawing.Size(155, 21);
            this.rb01Silver.TabIndex = 0;
            this.rb01Silver.TabStop = true;
            this.rb01Silver.Text = "1000-1044-01 Silver";
            this.rb01Silver.UseVisualStyleBackColor = true;
            this.rb01Silver.CheckedChanged += new System.EventHandler(this.rb01Silver_CheckedChanged);
            // 
            // rb02Gold
            // 
            this.rb02Gold.AutoSize = true;
            this.rb02Gold.Location = new System.Drawing.Point(41, 95);
            this.rb02Gold.Name = "rb02Gold";
            this.rb02Gold.Size = new System.Drawing.Size(150, 21);
            this.rb02Gold.TabIndex = 1;
            this.rb02Gold.TabStop = true;
            this.rb02Gold.Text = "1000-1044-02 Gold";
            this.rb02Gold.UseVisualStyleBackColor = true;
            this.rb02Gold.CheckedChanged += new System.EventHandler(this.rb02Gold_CheckedChanged);
            // 
            // rb03Green
            // 
            this.rb03Green.AutoSize = true;
            this.rb03Green.Location = new System.Drawing.Point(41, 122);
            this.rb03Green.Name = "rb03Green";
            this.rb03Green.Size = new System.Drawing.Size(160, 21);
            this.rb03Green.TabIndex = 2;
            this.rb03Green.TabStop = true;
            this.rb03Green.Text = "1000-1044-03 Green";
            this.rb03Green.UseVisualStyleBackColor = true;
            this.rb03Green.CheckedChanged += new System.EventHandler(this.rb03Green_CheckedChanged);
            // 
            // rb04Blue
            // 
            this.rb04Blue.AutoSize = true;
            this.rb04Blue.Location = new System.Drawing.Point(41, 149);
            this.rb04Blue.Name = "rb04Blue";
            this.rb04Blue.Size = new System.Drawing.Size(148, 21);
            this.rb04Blue.TabIndex = 3;
            this.rb04Blue.TabStop = true;
            this.rb04Blue.Text = "1000-1044-04 Blue";
            this.rb04Blue.UseVisualStyleBackColor = true;
            this.rb04Blue.CheckedChanged += new System.EventHandler(this.rb04Blue_CheckedChanged);
            // 
            // rb00Red
            // 
            this.rb00Red.AutoSize = true;
            this.rb00Red.Location = new System.Drawing.Point(41, 44);
            this.rb00Red.Name = "rb00Red";
            this.rb00Red.Size = new System.Drawing.Size(146, 21);
            this.rb00Red.TabIndex = 12;
            this.rb00Red.TabStop = true;
            this.rb00Red.Text = "1000-1042-03 Red";
            this.rb00Red.UseVisualStyleBackColor = true;
            this.rb00Red.CheckedChanged += new System.EventHandler(this.rb00Red_CheckedChanged);
            // 
            // gbQuantity
            // 
            this.gbQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(160)))), ((int)(((byte)(80)))));
            this.gbQuantity.Controls.Add(this.rbOneHundred);
            this.gbQuantity.Controls.Add(this.rbTen);
            this.gbQuantity.Controls.Add(this.rbOne);
            this.gbQuantity.Location = new System.Drawing.Point(37, 211);
            this.gbQuantity.Name = "gbQuantity";
            this.gbQuantity.Size = new System.Drawing.Size(477, 82);
            this.gbQuantity.TabIndex = 13;
            this.gbQuantity.TabStop = false;
            this.gbQuantity.Text = "Print one or a series";
            // 
            // rbOneHundred
            // 
            this.rbOneHundred.AutoSize = true;
            this.rbOneHundred.Location = new System.Drawing.Point(212, 36);
            this.rbOneHundred.Name = "rbOneHundred";
            this.rbOneHundred.Size = new System.Drawing.Size(112, 21);
            this.rbOneHundred.TabIndex = 16;
            this.rbOneHundred.TabStop = true;
            this.rbOneHundred.Text = "One Hundred";
            this.rbOneHundred.UseVisualStyleBackColor = true;
            // 
            // rbTen
            // 
            this.rbTen.AutoSize = true;
            this.rbTen.Location = new System.Drawing.Point(111, 36);
            this.rbTen.Name = "rbTen";
            this.rbTen.Size = new System.Drawing.Size(51, 21);
            this.rbTen.TabIndex = 15;
            this.rbTen.TabStop = true;
            this.rbTen.Text = "Ten";
            this.rbTen.UseVisualStyleBackColor = true;
            // 
            // rbOne
            // 
            this.rbOne.AutoSize = true;
            this.rbOne.Checked = true;
            this.rbOne.Location = new System.Drawing.Point(18, 36);
            this.rbOne.Name = "rbOne";
            this.rbOne.Size = new System.Drawing.Size(53, 21);
            this.rbOne.TabIndex = 14;
            this.rbOne.TabStop = true;
            this.rbOne.Text = "One";
            this.rbOne.UseVisualStyleBackColor = true;
            // 
            // rbFreeText
            // 
            this.rbFreeText.AutoSize = true;
            this.rbFreeText.Location = new System.Drawing.Point(41, 176);
            this.rbFreeText.Name = "rbFreeText";
            this.rbFreeText.Size = new System.Drawing.Size(90, 21);
            this.rbFreeText.TabIndex = 14;
            this.rbFreeText.TabStop = true;
            this.rbFreeText.Text = " Free Text";
            this.rbFreeText.UseVisualStyleBackColor = true;
            this.rbFreeText.CheckedChanged += new System.EventHandler(this.rbFreeText_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Label Part Numbers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "YY3NNN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "YYNNNN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(212, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "YY1NNN";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(212, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "YY2NNN";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(212, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "YY25NN";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(212, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "Prefills Text Box";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(312, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(209, 17);
            this.label9.TabIndex = 23;
            this.label9.Text = "N digits = calculated starting SN";
            // 
            // SmallSNLabels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(120)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(554, 360);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbFreeText);
            this.Controls.Add(this.gbQuantity);
            this.Controls.Add(this.rb00Red);
            this.Controls.Add(this.rb04Blue);
            this.Controls.Add(this.rb03Green);
            this.Controls.Add(this.rb02Gold);
            this.Controls.Add(this.rb01Silver);
            this.Controls.Add(this.tbSerialNumber);
            this.Controls.Add(this.bPrint);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SmallSNLabels";
            this.Text = "Print Small Serial Number Labels";
            this.Load += new System.EventHandler(this.SmallSNLabels_Load);
            this.gbQuantity.ResumeLayout(false);
            this.gbQuantity.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bPrint;
        private System.Windows.Forms.TextBox tbSerialNumber;
        private System.Windows.Forms.RadioButton rb01Silver;
        private System.Windows.Forms.RadioButton rb02Gold;
        private System.Windows.Forms.RadioButton rb03Green;
        private System.Windows.Forms.RadioButton rb04Blue;
        private System.Windows.Forms.RadioButton rb00Red;
        private System.Windows.Forms.GroupBox gbQuantity;
        private System.Windows.Forms.RadioButton rbOneHundred;
        private System.Windows.Forms.RadioButton rbTen;
        private System.Windows.Forms.RadioButton rbOne;
        private System.Windows.Forms.RadioButton rbFreeText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

