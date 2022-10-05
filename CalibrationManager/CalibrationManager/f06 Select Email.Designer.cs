namespace CalibrationManager
{
    partial class f06_Select_Email
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
            this.bOverdue = new System.Windows.Forms.Button();
            this.bThisMonth = new System.Windows.Forms.Button();
            this.bNextMonth = new System.Windows.Forms.Button();
            this.bBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bOverdue
            // 
            this.bOverdue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(150)))), ((int)(((byte)(10)))));
            this.bOverdue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bOverdue.Location = new System.Drawing.Point(56, 54);
            this.bOverdue.Name = "bOverdue";
            this.bOverdue.Size = new System.Drawing.Size(328, 82);
            this.bOverdue.TabIndex = 0;
            this.bOverdue.Text = "OVERDUE";
            this.bOverdue.UseVisualStyleBackColor = false;
            this.bOverdue.Click += new System.EventHandler(this.bOverdue_Click);
            // 
            // bThisMonth
            // 
            this.bThisMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(150)))));
            this.bThisMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bThisMonth.Location = new System.Drawing.Point(55, 169);
            this.bThisMonth.Name = "bThisMonth";
            this.bThisMonth.Size = new System.Drawing.Size(328, 82);
            this.bThisMonth.TabIndex = 1;
            this.bThisMonth.Text = "DUE THIS MONTH";
            this.bThisMonth.UseVisualStyleBackColor = false;
            this.bThisMonth.Click += new System.EventHandler(this.bThisMonth_Click);
            // 
            // bNextMonth
            // 
            this.bNextMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(10)))));
            this.bNextMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bNextMonth.Location = new System.Drawing.Point(55, 291);
            this.bNextMonth.Name = "bNextMonth";
            this.bNextMonth.Size = new System.Drawing.Size(328, 82);
            this.bNextMonth.TabIndex = 2;
            this.bNextMonth.Text = "DUE NEXT MONTH";
            this.bNextMonth.UseVisualStyleBackColor = false;
            this.bNextMonth.Click += new System.EventHandler(this.bNextMonth_Click);
            // 
            // bBack
            // 
            this.bBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(50)))));
            this.bBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBack.Location = new System.Drawing.Point(431, 54);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(59, 319);
            this.bBack.TabIndex = 6;
            this.bBack.Text = "BACK";
            this.bBack.UseVisualStyleBackColor = false;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // f06_Select_Email
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(50)))), ((int)(((byte)(10)))));
            this.ClientSize = new System.Drawing.Size(536, 420);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.bNextMonth);
            this.Controls.Add(this.bThisMonth);
            this.Controls.Add(this.bOverdue);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "f06_Select_Email";
            this.Text = "f06 Select Email";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bOverdue;
        private System.Windows.Forms.Button bThisMonth;
        private System.Windows.Forms.Button bNextMonth;
        private System.Windows.Forms.Button bBack;
    }
}