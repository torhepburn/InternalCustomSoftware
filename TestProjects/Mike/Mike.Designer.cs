namespace Mike
{
    partial class Mike
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
            this.LBx = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // LBx
            // 
            this.LBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBx.FormattingEnabled = true;
            this.LBx.ItemHeight = 20;
            this.LBx.Location = new System.Drawing.Point(29, 72);
            this.LBx.Name = "LBx";
            this.LBx.Size = new System.Drawing.Size(516, 144);
            this.LBx.TabIndex = 1;
            this.LBx.SelectedIndexChanged += new System.EventHandler(this.LBx_SelectedIndexChanged);
            // 
            // Mike
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(576, 262);
            this.Controls.Add(this.LBx);
            this.Name = "Mike";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Mike_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LBx;
    }
}

