namespace CEA_Archive
{
    partial class Archive
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
            this.bBack = new System.Windows.Forms.Button();
            this.LB = new System.Windows.Forms.ListBox();
            this.bArchive = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bBack
            // 
            this.bBack.BackColor = System.Drawing.Color.Yellow;
            this.bBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBack.ForeColor = System.Drawing.Color.Black;
            this.bBack.Location = new System.Drawing.Point(270, 328);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(128, 58);
            this.bBack.TabIndex = 0;
            this.bBack.Text = "Top Directory";
            this.bBack.UseVisualStyleBackColor = false;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // LB
            // 
            this.LB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(100)))));
            this.LB.FormattingEnabled = true;
            this.LB.ItemHeight = 20;
            this.LB.Location = new System.Drawing.Point(44, 41);
            this.LB.Name = "LB";
            this.LB.ScrollAlwaysVisible = true;
            this.LB.Size = new System.Drawing.Size(321, 184);
            this.LB.Sorted = true;
            this.LB.TabIndex = 1;
            this.LB.SelectedIndexChanged += new System.EventHandler(this.LB_SelectedIndexChanged);
            // 
            // bArchive
            // 
            this.bArchive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.bArchive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bArchive.ForeColor = System.Drawing.Color.Black;
            this.bArchive.Location = new System.Drawing.Point(44, 328);
            this.bArchive.Name = "bArchive";
            this.bArchive.Size = new System.Drawing.Size(200, 58);
            this.bArchive.TabIndex = 2;
            this.bArchive.Text = "Archive";
            this.bArchive.UseVisualStyleBackColor = false;
            this.bArchive.Click += new System.EventHandler(this.bArchive_Click);
            // 
            // Archive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(75)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(410, 398);
            this.Controls.Add(this.bArchive);
            this.Controls.Add(this.LB);
            this.Controls.Add(this.bBack);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Archive";
            this.Text = "Archive";
            this.Load += new System.EventHandler(this.Archive_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bBack;
        private System.Windows.Forms.ListBox LB;
        private System.Windows.Forms.Button bArchive;


    }
}

