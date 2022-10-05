namespace QuoteReporting
{
    partial class QuoteReport
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
            this.SuspendLayout();
            // 
            // QuoteReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(661, 530);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "QuoteReport";
            this.Text = "QuoteReport";
            this.Activated += new System.EventHandler(this.QuoteReport_Activated);
            this.Load += new System.EventHandler(this.QuoteReport_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}