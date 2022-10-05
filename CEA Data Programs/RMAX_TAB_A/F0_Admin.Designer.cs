namespace RMAX_TAB_A
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
            this.bEnterProgram = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.tbSerialNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bEnterProgram
            // 
            this.bEnterProgram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bEnterProgram.Location = new System.Drawing.Point(99, 47);
            this.bEnterProgram.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bEnterProgram.Name = "bEnterProgram";
            this.bEnterProgram.Size = new System.Drawing.Size(194, 57);
            this.bEnterProgram.TabIndex = 0;
            this.bEnterProgram.Text = "Use Program";
            this.bEnterProgram.UseVisualStyleBackColor = false;
            this.bEnterProgram.Click += new System.EventHandler(this.bEnterProgram_Click);
            // 
            // bSave
            // 
            this.bSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(140)))), ((int)(((byte)(100)))));
            this.bSave.Location = new System.Drawing.Point(99, 242);
            this.bSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(194, 60);
            this.bSave.TabIndex = 2;
            this.bSave.Text = "Enter Data";
            this.bSave.UseVisualStyleBackColor = false;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // tbSerialNumber
            // 
            this.tbSerialNumber.Location = new System.Drawing.Point(179, 150);
            this.tbSerialNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSerialNumber.Name = "tbSerialNumber";
            this.tbSerialNumber.Size = new System.Drawing.Size(148, 26);
            this.tbSerialNumber.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 153);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter Serial Number:";
            // 
            // F0_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(160)))));
            this.ClientSize = new System.Drawing.Size(407, 358);
            this.Controls.Add(this.bEnterProgram);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.tbSerialNumber);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F0_Admin";
            this.Text = "F0_Admin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bEnterProgram;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.TextBox tbSerialNumber;
        private System.Windows.Forms.Label label1;
    }
}

