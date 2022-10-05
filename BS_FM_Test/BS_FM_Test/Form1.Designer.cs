namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.btnTestPart = new System.Windows.Forms.Button();
            this.maskedTxtSerialNumber = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblReflectedPercentage = new System.Windows.Forms.Label();
            this.lblTransmittedPowerPercentage = new System.Windows.Forms.Label();
            this.txtRefPwrPct = new System.Windows.Forms.TextBox();
            this.txtTranPwrPct = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnTestPart
            // 
            this.btnTestPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestPart.ForeColor = System.Drawing.Color.Black;
            this.btnTestPart.Location = new System.Drawing.Point(51, 85);
            this.btnTestPart.Name = "btnTestPart";
            this.btnTestPart.Size = new System.Drawing.Size(177, 69);
            this.btnTestPart.TabIndex = 11;
            this.btnTestPart.UseVisualStyleBackColor = true;
            this.btnTestPart.Visible = false;
            this.btnTestPart.Click += new System.EventHandler(this.btnTestPart_Click);
            // 
            // maskedTxtSerialNumber
            // 
            this.maskedTxtSerialNumber.AsciiOnly = true;
            this.maskedTxtSerialNumber.BackColor = System.Drawing.Color.Yellow;
            this.maskedTxtSerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTxtSerialNumber.Location = new System.Drawing.Point(119, 57);
            this.maskedTxtSerialNumber.Mask = "0000";
            this.maskedTxtSerialNumber.Name = "maskedTxtSerialNumber";
            this.maskedTxtSerialNumber.Size = new System.Drawing.Size(40, 22);
            this.maskedTxtSerialNumber.TabIndex = 14;
            this.maskedTxtSerialNumber.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTxtSerialNumber_MaskInputRejected);
            this.maskedTxtSerialNumber.TextChanged += new System.EventHandler(this.maskedTxtSerialNumber_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(23, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Enter 4-Digit Serial Number Below.";
            // 
            // lblReflectedPercentage
            // 
            this.lblReflectedPercentage.AutoSize = true;
            this.lblReflectedPercentage.Location = new System.Drawing.Point(62, 168);
            this.lblReflectedPercentage.Name = "lblReflectedPercentage";
            this.lblReflectedPercentage.Size = new System.Drawing.Size(97, 13);
            this.lblReflectedPercentage.TabIndex = 17;
            this.lblReflectedPercentage.Text = "Relected Power %:";
            // 
            // lblTransmittedPowerPercentage
            // 
            this.lblTransmittedPowerPercentage.AutoSize = true;
            this.lblTransmittedPowerPercentage.Location = new System.Drawing.Point(50, 192);
            this.lblTransmittedPowerPercentage.Name = "lblTransmittedPowerPercentage";
            this.lblTransmittedPowerPercentage.Size = new System.Drawing.Size(109, 13);
            this.lblTransmittedPowerPercentage.TabIndex = 18;
            this.lblTransmittedPowerPercentage.Text = "Transmitted Power %:";
            // 
            // txtRefPwrPct
            // 
            this.txtRefPwrPct.Location = new System.Drawing.Point(166, 168);
            this.txtRefPwrPct.Name = "txtRefPwrPct";
            this.txtRefPwrPct.Size = new System.Drawing.Size(50, 20);
            this.txtRefPwrPct.TabIndex = 19;
            // 
            // txtTranPwrPct
            // 
            this.txtTranPwrPct.Location = new System.Drawing.Point(166, 189);
            this.txtTranPwrPct.Name = "txtTranPwrPct";
            this.txtTranPwrPct.Size = new System.Drawing.Size(50, 20);
            this.txtTranPwrPct.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 239);
            this.Controls.Add(this.txtTranPwrPct);
            this.Controls.Add(this.txtRefPwrPct);
            this.Controls.Add(this.lblTransmittedPowerPercentage);
            this.Controls.Add(this.lblReflectedPercentage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maskedTxtSerialNumber);
            this.Controls.Add(this.btnTestPart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "B/S - F/M Test";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTestPart;
        private System.Windows.Forms.MaskedTextBox maskedTxtSerialNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblReflectedPercentage;
        private System.Windows.Forms.Label lblTransmittedPowerPercentage;
        private System.Windows.Forms.TextBox txtRefPwrPct;
        private System.Windows.Forms.TextBox txtTranPwrPct;
    }
}

