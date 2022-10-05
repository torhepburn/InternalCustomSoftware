
namespace PriceList
{
    partial class MakeFullPriceList
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
            this.BmakePL.Location = new System.Drawing.Point(70, 61);
            this.BmakePL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BmakePL.Name = "BmakePL";
            this.BmakePL.Size = new System.Drawing.Size(218, 91);
            this.BmakePL.TabIndex = 1;
            this.BmakePL.Text = "Make Price List";
            this.BmakePL.UseVisualStyleBackColor = false;
            this.BmakePL.Click += new System.EventHandler(this.BmakePL_Click);
            // 
            // MakeFullPriceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 207);
            this.Controls.Add(this.BmakePL);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MakeFullPriceList";
            this.Text = "MakeFullPriceList";
            this.Load += new System.EventHandler(this.MakeFullPriceList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BmakePL;
    }
}