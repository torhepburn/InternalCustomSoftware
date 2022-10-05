namespace DirectPrint
{
    partial class PrintTest
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
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbPartNumber = new System.Windows.Forms.TextBox();
            this.tbAmps = new System.Windows.Forms.TextBox();
            this.tbVolts = new System.Windows.Forms.TextBox();
            this.tbHertz = new System.Windows.Forms.TextBox();
            this.bExit = new System.Windows.Forms.Button();
            this.bPrint = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbModel = new System.Windows.Forms.TextBox();
            this.tbSerialNumber = new System.Windows.Forms.TextBox();
            this.tbRevision = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbLabelQuantity = new System.Windows.Forms.TextBox();
            this.tbNumberOfBoxes = new System.Windows.Forms.TextBox();
            this.tbQty = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbDescription
            // 
            this.tbDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(180)))), ((int)(((byte)(220)))));
            this.tbDescription.Location = new System.Drawing.Point(183, 78);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ReadOnly = true;
            this.tbDescription.Size = new System.Drawing.Size(419, 20);
            this.tbDescription.TabIndex = 59;
            // 
            // tbPartNumber
            // 
            this.tbPartNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(180)))), ((int)(((byte)(220)))));
            this.tbPartNumber.Location = new System.Drawing.Point(183, 38);
            this.tbPartNumber.Name = "tbPartNumber";
            this.tbPartNumber.Size = new System.Drawing.Size(150, 20);
            this.tbPartNumber.TabIndex = 58;
            // 
            // tbAmps
            // 
            this.tbAmps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(180)))), ((int)(((byte)(220)))));
            this.tbAmps.Location = new System.Drawing.Point(183, 242);
            this.tbAmps.Name = "tbAmps";
            this.tbAmps.Size = new System.Drawing.Size(51, 20);
            this.tbAmps.TabIndex = 63;
            // 
            // tbVolts
            // 
            this.tbVolts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(180)))), ((int)(((byte)(220)))));
            this.tbVolts.Location = new System.Drawing.Point(183, 202);
            this.tbVolts.Name = "tbVolts";
            this.tbVolts.Size = new System.Drawing.Size(51, 20);
            this.tbVolts.TabIndex = 62;
            // 
            // tbHertz
            // 
            this.tbHertz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(180)))), ((int)(((byte)(220)))));
            this.tbHertz.Location = new System.Drawing.Point(183, 162);
            this.tbHertz.Name = "tbHertz";
            this.tbHertz.Size = new System.Drawing.Size(51, 20);
            this.tbHertz.TabIndex = 61;
            // 
            // bExit
            // 
            this.bExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(180)))));
            this.bExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bExit.Location = new System.Drawing.Point(285, 341);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(212, 88);
            this.bExit.TabIndex = 72;
            this.bExit.Text = "EXIT";
            this.bExit.UseVisualStyleBackColor = false;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // bPrint
            // 
            this.bPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(200)))), ((int)(((byte)(180)))));
            this.bPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPrint.Location = new System.Drawing.Point(33, 341);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(212, 88);
            this.bPrint.TabIndex = 71;
            this.bPrint.Text = "PRINT LABEL";
            this.bPrint.UseVisualStyleBackColor = false;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label10.Location = new System.Drawing.Point(32, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 20);
            this.label10.TabIndex = 70;
            this.label10.Text = "Model No.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label9.Location = new System.Drawing.Point(32, 285);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 20);
            this.label9.TabIndex = 69;
            this.label9.Text = "Serial Number";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.Location = new System.Drawing.Point(32, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 20);
            this.label8.TabIndex = 68;
            this.label8.Text = "Amps";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(32, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 20);
            this.label7.TabIndex = 67;
            this.label7.Text = "Volts";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(32, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 20);
            this.label6.TabIndex = 66;
            this.label6.Text = "Hertz (Hz)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(29, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 65;
            this.label5.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(29, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 20);
            this.label4.TabIndex = 64;
            this.label4.Text = "Part Number";
            // 
            // tbModel
            // 
            this.tbModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(180)))), ((int)(((byte)(220)))));
            this.tbModel.Location = new System.Drawing.Point(183, 121);
            this.tbModel.Name = "tbModel";
            this.tbModel.ReadOnly = true;
            this.tbModel.Size = new System.Drawing.Size(208, 20);
            this.tbModel.TabIndex = 60;
            // 
            // tbSerialNumber
            // 
            this.tbSerialNumber.Location = new System.Drawing.Point(183, 285);
            this.tbSerialNumber.Name = "tbSerialNumber";
            this.tbSerialNumber.Size = new System.Drawing.Size(150, 20);
            this.tbSerialNumber.TabIndex = 57;
            // 
            // tbRevision
            // 
            this.tbRevision.Location = new System.Drawing.Point(610, 123);
            this.tbRevision.Name = "tbRevision";
            this.tbRevision.Size = new System.Drawing.Size(51, 20);
            this.tbRevision.TabIndex = 74;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(459, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 73;
            this.label1.Text = "Revision";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(716, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 84;
            this.label3.Text = "Label sets to print.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(716, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 83;
            this.label2.Text = "to make one stockable unit.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(716, 166);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 13);
            this.label11.TabIndex = 82;
            this.label11.Text = "Pieces in this box.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(459, 243);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 13);
            this.label12.TabIndex = 81;
            this.label12.Text = "Quantity of Labels";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(459, 203);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 13);
            this.label13.TabIndex = 80;
            this.label13.Text = "Number of Boxes";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(459, 163);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 13);
            this.label14.TabIndex = 79;
            this.label14.Text = "Quantity";
            // 
            // tbLabelQuantity
            // 
            this.tbLabelQuantity.Location = new System.Drawing.Point(610, 243);
            this.tbLabelQuantity.Name = "tbLabelQuantity";
            this.tbLabelQuantity.Size = new System.Drawing.Size(100, 20);
            this.tbLabelQuantity.TabIndex = 78;
            this.tbLabelQuantity.Text = "1";
            // 
            // tbNumberOfBoxes
            // 
            this.tbNumberOfBoxes.Location = new System.Drawing.Point(610, 203);
            this.tbNumberOfBoxes.Name = "tbNumberOfBoxes";
            this.tbNumberOfBoxes.Size = new System.Drawing.Size(100, 20);
            this.tbNumberOfBoxes.TabIndex = 77;
            this.tbNumberOfBoxes.Text = "1";
            // 
            // tbQty
            // 
            this.tbQty.Location = new System.Drawing.Point(610, 163);
            this.tbQty.Name = "tbQty";
            this.tbQty.Size = new System.Drawing.Size(100, 20);
            this.tbQty.TabIndex = 76;
            this.tbQty.Text = "1";
            // 
            // PrintTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 467);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tbLabelQuantity);
            this.Controls.Add(this.tbNumberOfBoxes);
            this.Controls.Add(this.tbQty);
            this.Controls.Add(this.tbRevision);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbPartNumber);
            this.Controls.Add(this.tbAmps);
            this.Controls.Add(this.tbVolts);
            this.Controls.Add(this.tbHertz);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.bPrint);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbModel);
            this.Controls.Add(this.tbSerialNumber);
            this.Name = "PrintTest";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbPartNumber;
        private System.Windows.Forms.TextBox tbAmps;
        private System.Windows.Forms.TextBox tbVolts;
        private System.Windows.Forms.TextBox tbHertz;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.Button bPrint;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbModel;
        private System.Windows.Forms.TextBox tbSerialNumber;
        private System.Windows.Forms.TextBox tbRevision;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbLabelQuantity;
        private System.Windows.Forms.TextBox tbNumberOfBoxes;
        private System.Windows.Forms.TextBox tbQty;
    }
}

