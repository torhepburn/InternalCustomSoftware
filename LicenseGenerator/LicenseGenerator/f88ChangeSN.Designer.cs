namespace LicenseGenerator
{
    partial class f88ChangeSN
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
            this.tbSerialNo = new System.Windows.Forms.TextBox();
            this.bChange = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LDongleID = new System.Windows.Forms.Label();
            this.LSerialNo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbSerialNo
            // 
            this.tbSerialNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbSerialNo.Location = new System.Drawing.Point(386, 54);
            this.tbSerialNo.Name = "tbSerialNo";
            this.tbSerialNo.Size = new System.Drawing.Size(156, 23);
            this.tbSerialNo.TabIndex = 0;
            // 
            // bChange
            // 
            this.bChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(207)))), ((int)(((byte)(196)))));
            this.bChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bChange.Location = new System.Drawing.Point(445, 131);
            this.bChange.Name = "bChange";
            this.bChange.Size = new System.Drawing.Size(156, 84);
            this.bChange.TabIndex = 1;
            this.bChange.Text = "Change Serial Number";
            this.bChange.UseVisualStyleBackColor = false;
            this.bChange.Click += new System.EventHandler(this.bChange_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(364, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter New Serial Number";
            // 
            // LDongleID
            // 
            this.LDongleID.AutoSize = true;
            this.LDongleID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.LDongleID.Location = new System.Drawing.Point(34, 63);
            this.LDongleID.Name = "LDongleID";
            this.LDongleID.Size = new System.Drawing.Size(103, 24);
            this.LDongleID.TabIndex = 3;
            this.LDongleID.Text = "DongleID:  ";
            // 
            // LSerialNo
            // 
            this.LSerialNo.AutoSize = true;
            this.LSerialNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.LSerialNo.Location = new System.Drawing.Point(34, 140);
            this.LSerialNo.Name = "LSerialNo";
            this.LSerialNo.Size = new System.Drawing.Size(213, 24);
            this.LSerialNo.TabIndex = 4;
            this.LSerialNo.Text = "Current Serial Number:  ";
            // 
            // f88ChangeSN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(127)))), ((int)(((byte)(136)))));
            this.ClientSize = new System.Drawing.Size(631, 245);
            this.Controls.Add(this.LSerialNo);
            this.Controls.Add(this.LDongleID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bChange);
            this.Controls.Add(this.tbSerialNo);
            this.Name = "f88ChangeSN";
            this.Text = "f88ChangeSN";
            this.Load += new System.EventHandler(this.f88ChangeSN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSerialNo;
        private System.Windows.Forms.Button bChange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LDongleID;
        private System.Windows.Forms.Label LSerialNo;
    }
}