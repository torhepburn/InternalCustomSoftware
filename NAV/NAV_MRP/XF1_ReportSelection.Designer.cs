namespace NAV_MRP
{
    partial class XF1_ReportSelection
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
            this.BMainReport = new System.Windows.Forms.Button();
            this.BMinMax = new System.Windows.Forms.Button();
            this.Bx = new System.Windows.Forms.Button();
            this.BIrvine = new System.Windows.Forms.Button();
            this.Brichmond = new System.Windows.Forms.Button();
            this.bKBP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BMainReport
            // 
            this.BMainReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(153)))), ((int)(((byte)(64)))));
            this.BMainReport.Location = new System.Drawing.Point(133, 35);
            this.BMainReport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BMainReport.Name = "BMainReport";
            this.BMainReport.Size = new System.Drawing.Size(219, 68);
            this.BMainReport.TabIndex = 0;
            this.BMainReport.Text = "Main Report";
            this.BMainReport.UseVisualStyleBackColor = false;
            this.BMainReport.Click += new System.EventHandler(this.BMainReport_Click);
            // 
            // BMinMax
            // 
            this.BMinMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(175)))), ((int)(((byte)(0)))));
            this.BMinMax.Location = new System.Drawing.Point(133, 137);
            this.BMinMax.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BMinMax.Name = "BMinMax";
            this.BMinMax.Size = new System.Drawing.Size(219, 68);
            this.BMinMax.TabIndex = 1;
            this.BMinMax.Text = "Min Max Report";
            this.BMinMax.UseVisualStyleBackColor = false;
            this.BMinMax.Click += new System.EventHandler(this.BMinMax_Click);
            // 
            // Bx
            // 
            this.Bx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(175)))), ((int)(((byte)(217)))));
            this.Bx.Location = new System.Drawing.Point(133, 242);
            this.Bx.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Bx.Name = "Bx";
            this.Bx.Size = new System.Drawing.Size(219, 68);
            this.Bx.TabIndex = 2;
            this.Bx.Text = "X Report";
            this.Bx.UseVisualStyleBackColor = false;
            this.Bx.Click += new System.EventHandler(this.Bx_Click);
            // 
            // BIrvine
            // 
            this.BIrvine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(153)))), ((int)(((byte)(64)))));
            this.BIrvine.Location = new System.Drawing.Point(395, 37);
            this.BIrvine.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BIrvine.Name = "BIrvine";
            this.BIrvine.Size = new System.Drawing.Size(219, 68);
            this.BIrvine.TabIndex = 3;
            this.BIrvine.Text = "Irvine";
            this.BIrvine.UseVisualStyleBackColor = false;
            this.BIrvine.Click += new System.EventHandler(this.BIrvine_Click);
            // 
            // Brichmond
            // 
            this.Brichmond.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(153)))), ((int)(((byte)(164)))));
            this.Brichmond.Location = new System.Drawing.Point(395, 137);
            this.Brichmond.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Brichmond.Name = "Brichmond";
            this.Brichmond.Size = new System.Drawing.Size(219, 68);
            this.Brichmond.TabIndex = 4;
            this.Brichmond.Text = "Richmond";
            this.Brichmond.UseVisualStyleBackColor = false;
            this.Brichmond.Click += new System.EventHandler(this.bRichmond_Click);
            // 
            // bKBP
            // 
            this.bKBP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(130)))), ((int)(((byte)(184)))));
            this.bKBP.Location = new System.Drawing.Point(395, 242);
            this.bKBP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bKBP.Name = "bKBP";
            this.bKBP.Size = new System.Drawing.Size(219, 68);
            this.bKBP.TabIndex = 5;
            this.bKBP.Text = "Kanban";
            this.bKBP.UseVisualStyleBackColor = false;
            this.bKBP.Click += new System.EventHandler(this.bKBP_Click);
            // 
            // F1_ReportSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(45)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(768, 367);
            this.Controls.Add(this.bKBP);
            this.Controls.Add(this.Brichmond);
            this.Controls.Add(this.BIrvine);
            this.Controls.Add(this.Bx);
            this.Controls.Add(this.BMinMax);
            this.Controls.Add(this.BMainReport);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F1_ReportSelection";
            this.Text = "F1_ReportSelection";
            this.Load += new System.EventHandler(this.F1_ReportSelection_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BMainReport;
        private System.Windows.Forms.Button BMinMax;
        private System.Windows.Forms.Button Bx;
        private System.Windows.Forms.Button BIrvine;
        private System.Windows.Forms.Button Brichmond;
        private System.Windows.Forms.Button bKBP;
    }
}