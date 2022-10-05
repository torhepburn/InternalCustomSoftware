namespace PolishingTools
{
    partial class SelectType
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
            this.bCarriers = new System.Windows.Forms.Button();
            this.bFloaters = new System.Windows.Forms.Button();
            this.bTestPlates = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bCarriers
            // 
            this.bCarriers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.bCarriers.Location = new System.Drawing.Point(31, 27);
            this.bCarriers.Name = "bCarriers";
            this.bCarriers.Size = new System.Drawing.Size(185, 185);
            this.bCarriers.TabIndex = 0;
            this.bCarriers.Text = "CARRIERS";
            this.bCarriers.UseVisualStyleBackColor = false;
            this.bCarriers.Click += new System.EventHandler(this.bCarrier_Click);
            // 
            // bFloaters
            // 
            this.bFloaters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(220)))), ((int)(((byte)(50)))));
            this.bFloaters.Location = new System.Drawing.Point(238, 27);
            this.bFloaters.Name = "bFloaters";
            this.bFloaters.Size = new System.Drawing.Size(185, 185);
            this.bFloaters.TabIndex = 1;
            this.bFloaters.Text = "FLOATERS";
            this.bFloaters.UseVisualStyleBackColor = false;
            this.bFloaters.Click += new System.EventHandler(this.bFloaters_Click);
            // 
            // bTestPlates
            // 
            this.bTestPlates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(220)))));
            this.bTestPlates.Location = new System.Drawing.Point(448, 27);
            this.bTestPlates.Name = "bTestPlates";
            this.bTestPlates.Size = new System.Drawing.Size(185, 185);
            this.bTestPlates.TabIndex = 2;
            this.bTestPlates.Text = "TEST PLATES";
            this.bTestPlates.UseVisualStyleBackColor = false;
            this.bTestPlates.Click += new System.EventHandler(this.bTestPlates_Click);
            // 
            // SelectType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(660, 234);
            this.Controls.Add(this.bTestPlates);
            this.Controls.Add(this.bFloaters);
            this.Controls.Add(this.bCarriers);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SelectType";
            this.Text = "SelectType";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bCarriers;
        private System.Windows.Forms.Button bFloaters;
        private System.Windows.Forms.Button bTestPlates;
    }
}