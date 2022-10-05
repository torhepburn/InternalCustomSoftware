namespace LLNL_Amp_Write2File
{
    partial class F2_Errors
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
            this.tb1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tb1
            // 
            this.tb1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(145)))), ((int)(((byte)(123)))));
            this.tb1.Location = new System.Drawing.Point(74, 50);
            this.tb1.Multiline = true;
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(495, 434);
            this.tb1.TabIndex = 0;
            // 
            // F2_Errors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(145)))), ((int)(((byte)(167)))));
            this.ClientSize = new System.Drawing.Size(653, 518);
            this.Controls.Add(this.tb1);
            this.Name = "F2_Errors";
            this.Text = "F2_Errors";
            this.Load += new System.EventHandler(this.F2_Errors_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb1;

    }
}