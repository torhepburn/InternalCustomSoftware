namespace AmpData
{
    partial class F0_Admin
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
            this.tbSerialNumber = new System.Windows.Forms.TextBox();
            this.bSave = new System.Windows.Forms.Button();
            this.bEnterProgram = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Serial Number:";
            // 
            // tbSerialNumber
            // 
            this.tbSerialNumber.Location = new System.Drawing.Point(243, 168);
            this.tbSerialNumber.Name = "tbSerialNumber";
            this.tbSerialNumber.Size = new System.Drawing.Size(100, 26);
            this.tbSerialNumber.TabIndex = 1;
            // 
            // bSave
            // 
            this.bSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(140)))), ((int)(((byte)(100)))));
            this.bSave.Location = new System.Drawing.Point(110, 234);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(211, 59);
            this.bSave.TabIndex = 2;
            this.bSave.Text = "Enter Data";
            this.bSave.UseVisualStyleBackColor = false;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bEnterProgram
            // 
            this.bEnterProgram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bEnterProgram.Location = new System.Drawing.Point(110, 35);
            this.bEnterProgram.Name = "bEnterProgram";
            this.bEnterProgram.Size = new System.Drawing.Size(211, 59);
            this.bEnterProgram.TabIndex = 0;
            this.bEnterProgram.Text = "Use Program";
            this.bEnterProgram.UseVisualStyleBackColor = false;
            this.bEnterProgram.Click += new System.EventHandler(this.bEnterProgram_Click);
            // 
            // F0_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(200)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(426, 325);
            this.Controls.Add(this.bEnterProgram);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.tbSerialNumber);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F0_Admin";
            this.Text = "F0_Admin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSerialNumber;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bEnterProgram;
    }
}