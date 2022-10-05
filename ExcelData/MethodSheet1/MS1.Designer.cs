namespace MethodSheet1
{
    partial class MS1
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
            this.bFind = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bFind
            // 
            this.bFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(140)))), ((int)(((byte)(20)))));
            this.bFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bFind.Location = new System.Drawing.Point(350, 57);
            this.bFind.Name = "bFind";
            this.bFind.Size = new System.Drawing.Size(117, 79);
            this.bFind.TabIndex = 1;
            this.bFind.Text = "FIND PART NUMBER";
            this.bFind.UseVisualStyleBackColor = false;
            this.bFind.Click += new System.EventHandler(this.bFind_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(43, 86);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(252, 23);
            this.tbSearch.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(43, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Part Number:";
            // 
            // MS1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(120)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(512, 525);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.bFind);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MS1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MS1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bFind;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label1;
    }
}

