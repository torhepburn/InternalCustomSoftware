namespace ListBoxSelect
{
    partial class LBSelect
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
            this.LBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // LBox
            // 
            this.LBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBox.FormattingEnabled = true;
            this.LBox.ItemHeight = 20;
            this.LBox.Location = new System.Drawing.Point(38, 81);
            this.LBox.Name = "LBox";
            this.LBox.Size = new System.Drawing.Size(431, 144);
            this.LBox.TabIndex = 0;
            this.LBox.SelectedIndexChanged += new System.EventHandler(this.LBox_SelectedIndexChanged);
            // 
            // LBSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(204)))), ((int)(((byte)(89)))));
            this.ClientSize = new System.Drawing.Size(510, 262);
            this.Controls.Add(this.LBox);
            this.Name = "LBSelect";
            this.Text = "LBSelect";
            this.Load += new System.EventHandler(this.LBSelect_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LBox;
    }
}

