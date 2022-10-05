namespace CalibrationManager
{
    partial class f06_Email_Type
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
            this.bSingle = new System.Windows.Forms.Button();
            this.bAll = new System.Windows.Forms.Button();
            this.bBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bSingle
            // 
            this.bSingle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(180)))), ((int)(((byte)(70)))));
            this.bSingle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSingle.Location = new System.Drawing.Point(31, 24);
            this.bSingle.Name = "bSingle";
            this.bSingle.Size = new System.Drawing.Size(175, 138);
            this.bSingle.TabIndex = 0;
            this.bSingle.Text = "Select Individual User";
            this.bSingle.UseVisualStyleBackColor = false;
            this.bSingle.Click += new System.EventHandler(this.bSingle_Click);
            // 
            // bAll
            // 
            this.bAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(170)))));
            this.bAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAll.Location = new System.Drawing.Point(235, 24);
            this.bAll.Name = "bAll";
            this.bAll.Size = new System.Drawing.Size(175, 138);
            this.bAll.TabIndex = 1;
            this.bAll.Text = "Email All";
            this.bAll.UseVisualStyleBackColor = false;
            this.bAll.Click += new System.EventHandler(this.bAll_Click);
            // 
            // bBack
            // 
            this.bBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(50)))));
            this.bBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBack.Location = new System.Drawing.Point(433, 12);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(59, 170);
            this.bBack.TabIndex = 8;
            this.bBack.Text = "BACK";
            this.bBack.UseVisualStyleBackColor = false;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // f06_Email_Type
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(80)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(522, 194);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.bAll);
            this.Controls.Add(this.bSingle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "f06_Email_Type";
            this.Text = "f06 Email Type";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bSingle;
        private System.Windows.Forms.Button bAll;
        private System.Windows.Forms.Button bBack;
    }
}