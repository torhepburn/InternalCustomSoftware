namespace KanbanReport
{
    partial class FirstChoice
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
            this.bExport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bPrint
            // 
            this.bPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(250)))), ((int)(((byte)(100)))));
            this.bPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bPrint.Location = new System.Drawing.Point(57, 47);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(172, 69);
            this.bPrint.TabIndex = 0;
            this.bPrint.Text = "Print Report";
            this.bPrint.UseVisualStyleBackColor = false;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // bExport
            // 
            this.bExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(250)))), ((int)(((byte)(100)))));
            this.bExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bExport.Location = new System.Drawing.Point(57, 148);
            this.bExport.Name = "bExport";
            this.bExport.Size = new System.Drawing.Size(172, 69);
            this.bExport.TabIndex = 1;
            this.bExport.Text = "Export Data";
            this.bExport.UseVisualStyleBackColor = false;
            this.bExport.Click += new System.EventHandler(this.bExport_Click);
            // 
            // FirstChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.bExport);
            this.Controls.Add(this.bPrint);
            this.Name = "FirstChoice";
            this.Text = "FirstChoice";
            this.Load += new System.EventHandler(this.FirstChoice_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bPrint;
        private System.Windows.Forms.Button bExport;
    }
}