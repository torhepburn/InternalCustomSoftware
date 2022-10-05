namespace PriceLists
{
    partial class PriceLists
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
            this.BpriceList = new System.Windows.Forms.Button();
            this.Bitemdata = new System.Windows.Forms.Button();
            this.Bitemtext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BpriceList
            // 
            this.BpriceList.Location = new System.Drawing.Point(38, 35);
            this.BpriceList.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.BpriceList.Name = "BpriceList";
            this.BpriceList.Size = new System.Drawing.Size(144, 63);
            this.BpriceList.TabIndex = 0;
            this.BpriceList.Text = "Price Lists";
            this.BpriceList.UseVisualStyleBackColor = true;
            this.BpriceList.Click += new System.EventHandler(this.button1_Click);
            // 
            // Bitemdata
            // 
            this.Bitemdata.Location = new System.Drawing.Point(38, 136);
            this.Bitemdata.Margin = new System.Windows.Forms.Padding(5);
            this.Bitemdata.Name = "Bitemdata";
            this.Bitemdata.Size = new System.Drawing.Size(144, 63);
            this.Bitemdata.TabIndex = 1;
            this.Bitemdata.Text = "Item Data";
            this.Bitemdata.UseVisualStyleBackColor = true;
            this.Bitemdata.Click += new System.EventHandler(this.Bitemdata_Click);
            // 
            // Bitemtext
            // 
            this.Bitemtext.Location = new System.Drawing.Point(38, 240);
            this.Bitemtext.Margin = new System.Windows.Forms.Padding(5);
            this.Bitemtext.Name = "Bitemtext";
            this.Bitemtext.Size = new System.Drawing.Size(144, 63);
            this.Bitemtext.TabIndex = 2;
            this.Bitemtext.Text = "Item Text";
            this.Bitemtext.UseVisualStyleBackColor = true;
            // 
            // PriceLists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 350);
            this.Controls.Add(this.Bitemtext);
            this.Controls.Add(this.Bitemdata);
            this.Controls.Add(this.BpriceList);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "PriceLists";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BpriceList;
        private System.Windows.Forms.Button Bitemdata;
        private System.Windows.Forms.Button Bitemtext;
    }
}

