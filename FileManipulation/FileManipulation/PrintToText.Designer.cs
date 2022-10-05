namespace FileManipulation
{
    partial class PrintToText
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
            this.tbBOM = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bPrint
            // 
            this.bPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(50)))));
            this.bPrint.Location = new System.Drawing.Point(87, 150);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(88, 42);
            this.bPrint.TabIndex = 1;
            this.bPrint.Text = "PRINT";
            this.bPrint.UseVisualStyleBackColor = false;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // tbBOM
            // 
            this.tbBOM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(10)))));
            this.tbBOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbBOM.Location = new System.Drawing.Point(64, 78);
            this.tbBOM.Name = "tbBOM";
            this.tbBOM.Size = new System.Drawing.Size(147, 26);
            this.tbBOM.TabIndex = 0;
            // 
            // PrintToText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(200)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tbBOM);
            this.Controls.Add(this.bPrint);
            this.Name = "PrintToText";
            this.Text = "PrintToText";
            this.Load += new System.EventHandler(this.PrintToText_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bPrint;
        private System.Windows.Forms.TextBox tbBOM;
    }
}