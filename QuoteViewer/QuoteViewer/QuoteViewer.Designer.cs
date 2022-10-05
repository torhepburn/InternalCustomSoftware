namespace QuoteViewer
{
    partial class QuoteViewer
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
            this.tbQuoteNumber = new System.Windows.Forms.TextBox();
            this.lEnterQuoteNumber = new System.Windows.Forms.Label();
            this.bGetQuoteDetails = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbQuoteNumber
            // 
            this.tbQuoteNumber.Location = new System.Drawing.Point(200, 46);
            this.tbQuoteNumber.Name = "tbQuoteNumber";
            this.tbQuoteNumber.Size = new System.Drawing.Size(100, 26);
            this.tbQuoteNumber.TabIndex = 0;
            // 
            // lEnterQuoteNumber
            // 
            this.lEnterQuoteNumber.AutoSize = true;
            this.lEnterQuoteNumber.Location = new System.Drawing.Point(34, 49);
            this.lEnterQuoteNumber.Name = "lEnterQuoteNumber";
            this.lEnterQuoteNumber.Size = new System.Drawing.Size(160, 20);
            this.lEnterQuoteNumber.TabIndex = 1;
            this.lEnterQuoteNumber.Text = "Enter Quote Number:";
            // 
            // bGetQuoteDetails
            // 
            this.bGetQuoteDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(160)))), ((int)(((byte)(80)))));
            this.bGetQuoteDetails.Location = new System.Drawing.Point(43, 93);
            this.bGetQuoteDetails.Name = "bGetQuoteDetails";
            this.bGetQuoteDetails.Size = new System.Drawing.Size(257, 53);
            this.bGetQuoteDetails.TabIndex = 2;
            this.bGetQuoteDetails.Text = "Get Quote Details";
            this.bGetQuoteDetails.UseVisualStyleBackColor = false;
            this.bGetQuoteDetails.Click += new System.EventHandler(this.bGetQuoteDetails_Click);
            // 
            // QuoteViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(336, 179);
            this.Controls.Add(this.bGetQuoteDetails);
            this.Controls.Add(this.lEnterQuoteNumber);
            this.Controls.Add(this.tbQuoteNumber);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "QuoteViewer";
            this.Text = "QuoteViewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbQuoteNumber;
        private System.Windows.Forms.Label lEnterQuoteNumber;
        private System.Windows.Forms.Button bGetQuoteDetails;
    }
}

