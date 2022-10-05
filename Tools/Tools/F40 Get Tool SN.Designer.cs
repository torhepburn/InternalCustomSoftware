namespace Tools
{
    partial class F40_Add_Tool_SN
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
            this.tbGrit = new System.Windows.Forms.TextBox();
            this.bEnter = new System.Windows.Forms.Button();
            this.Lsn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Grit";
            // 
            // tbGrit
            // 
            this.tbGrit.Location = new System.Drawing.Point(157, 96);
            this.tbGrit.Name = "tbGrit";
            this.tbGrit.Size = new System.Drawing.Size(100, 26);
            this.tbGrit.TabIndex = 1;
            // 
            // bEnter
            // 
            this.bEnter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.bEnter.Location = new System.Drawing.Point(90, 163);
            this.bEnter.Name = "bEnter";
            this.bEnter.Size = new System.Drawing.Size(229, 49);
            this.bEnter.TabIndex = 2;
            this.bEnter.Text = "ENTER DATA";
            this.bEnter.UseVisualStyleBackColor = false;
            this.bEnter.Click += new System.EventHandler(this.bEnter_Click);
            // 
            // Lsn
            // 
            this.Lsn.AutoSize = true;
            this.Lsn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(120)))), ((int)(((byte)(80)))));
            this.Lsn.Location = new System.Drawing.Point(160, 40);
            this.Lsn.Name = "Lsn";
            this.Lsn.Size = new System.Drawing.Size(31, 20);
            this.Lsn.TabIndex = 3;
            this.Lsn.Text = "SN";
            // 
            // F40_Add_Tool_SN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(120)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(426, 247);
            this.Controls.Add(this.Lsn);
            this.Controls.Add(this.bEnter);
            this.Controls.Add(this.tbGrit);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F40_Add_Tool_SN";
            this.Text = "F40_Get_Tool_SN";
            this.Load += new System.EventHandler(this.F40_Add_Tool_SN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbGrit;
        private System.Windows.Forms.Button bEnter;
        private System.Windows.Forms.Label Lsn;
    }
}