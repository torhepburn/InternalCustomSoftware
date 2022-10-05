namespace PriceList
{
    partial class f4_MakePriceList
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
            this.BmakePL = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BmakePL
            // 
            this.BmakePL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.BmakePL.Location = new System.Drawing.Point(44, 53);
            this.BmakePL.Name = "BmakePL";
            this.BmakePL.Size = new System.Drawing.Size(145, 59);
            this.BmakePL.TabIndex = 0;
            this.BmakePL.Text = "Make Price List";
            this.BmakePL.UseVisualStyleBackColor = false;
            // 
            // f4_MakePriceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(50)))), ((int)(((byte)(130)))));
            this.ClientSize = new System.Drawing.Size(438, 420);
            this.Controls.Add(this.BmakePL);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "f4_MakePriceList";
            this.Text = "f4_MakePriceList";
            this.Load += new System.EventHandler(this.f4_MakePriceList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BmakePL;
    }
}