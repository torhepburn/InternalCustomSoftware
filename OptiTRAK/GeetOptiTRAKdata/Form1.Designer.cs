namespace GeetOptiTRAKdata
{
    partial class Form1
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
            this.bAccess = new System.Windows.Forms.Button();
            this.bExcel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bAccess
            // 
            this.bAccess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(80)))), ((int)(((byte)(40)))));
            this.bAccess.ForeColor = System.Drawing.Color.Black;
            this.bAccess.Location = new System.Drawing.Point(72, 62);
            this.bAccess.Name = "bAccess";
            this.bAccess.Size = new System.Drawing.Size(264, 169);
            this.bAccess.TabIndex = 0;
            this.bAccess.Text = "MDB";
            this.bAccess.UseVisualStyleBackColor = false;
            this.bAccess.Click += new System.EventHandler(this.bAccess_Click);
            // 
            // bExcel
            // 
            this.bExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.bExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(10)))));
            this.bExcel.Location = new System.Drawing.Point(72, 248);
            this.bExcel.Name = "bExcel";
            this.bExcel.Size = new System.Drawing.Size(264, 169);
            this.bExcel.TabIndex = 1;
            this.bExcel.Text = "EXCEL";
            this.bExcel.UseVisualStyleBackColor = false;
            this.bExcel.Click += new System.EventHandler(this.bExcel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(180)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(426, 459);
            this.Controls.Add(this.bExcel);
            this.Controls.Add(this.bAccess);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bAccess;
        private System.Windows.Forms.Button bExcel;
    }
}

