namespace NAV_MRP
{
    partial class F0_SelectSource
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
            this.BProd = new System.Windows.Forms.Button();
            this.BTest = new System.Windows.Forms.Button();
            this.BCopy = new System.Windows.Forms.Button();
            this.BRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BProd
            // 
            this.BProd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(153)))), ((int)(((byte)(64)))));
            this.BProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BProd.Location = new System.Drawing.Point(61, 53);
            this.BProd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BProd.Name = "BProd";
            this.BProd.Size = new System.Drawing.Size(219, 68);
            this.BProd.TabIndex = 1;
            this.BProd.Text = "ZYGO-NAV-PROD";
            this.BProd.UseVisualStyleBackColor = false;
            this.BProd.Click += new System.EventHandler(this.BProd_Click);
            // 
            // BTest
            // 
            this.BTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(153)))), ((int)(((byte)(64)))));
            this.BTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BTest.Location = new System.Drawing.Point(321, 53);
            this.BTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BTest.Name = "BTest";
            this.BTest.Size = new System.Drawing.Size(219, 68);
            this.BTest.TabIndex = 2;
            this.BTest.Text = "ZYGO-NAV-TEST";
            this.BTest.UseVisualStyleBackColor = false;
            this.BTest.Click += new System.EventHandler(this.BTest_Click);
            // 
            // BCopy
            // 
            this.BCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(153)))), ((int)(((byte)(64)))));
            this.BCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BCopy.Location = new System.Drawing.Point(321, 161);
            this.BCopy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BCopy.Name = "BCopy";
            this.BCopy.Size = new System.Drawing.Size(219, 68);
            this.BCopy.TabIndex = 3;
            this.BCopy.Text = "ZYGO-NAV-COPY";
            this.BCopy.UseVisualStyleBackColor = false;
            this.BCopy.Click += new System.EventHandler(this.BCopy_Click);
            // 
            // BRefresh
            // 
            this.BRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(153)))), ((int)(((byte)(64)))));
            this.BRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BRefresh.Location = new System.Drawing.Point(61, 161);
            this.BRefresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BRefresh.Name = "BRefresh";
            this.BRefresh.Size = new System.Drawing.Size(219, 68);
            this.BRefresh.TabIndex = 4;
            this.BRefresh.Text = "ZYGO-NAV-REFRESH";
            this.BRefresh.UseVisualStyleBackColor = false;
            this.BRefresh.Click += new System.EventHandler(this.BRefresh_Click);
            // 
            // F0_SelectSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(606, 280);
            this.Controls.Add(this.BRefresh);
            this.Controls.Add(this.BCopy);
            this.Controls.Add(this.BTest);
            this.Controls.Add(this.BProd);
            this.Name = "F0_SelectSource";
            this.Text = "F0_SelectCategory";
            this.Load += new System.EventHandler(this.F0_SelectCategory_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BProd;
        private System.Windows.Forms.Button BTest;
        private System.Windows.Forms.Button BCopy;
        private System.Windows.Forms.Button BRefresh;
    }
}