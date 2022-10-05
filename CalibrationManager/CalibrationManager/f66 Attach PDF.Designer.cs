namespace CalibrationManager
{
    partial class f66_Attach_PDF
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bCert = new System.Windows.Forms.Button();
            this.bRisk = new System.Windows.Forms.Button();
            this.bDocs = new System.Windows.Forms.Button();
            this.bRepair = new System.Windows.Forms.Button();
            this.bBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "(*.pdf)|*.pdf";
            // 
            // bCert
            // 
            this.bCert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.bCert.Location = new System.Drawing.Point(41, 34);
            this.bCert.Name = "bCert";
            this.bCert.Size = new System.Drawing.Size(304, 59);
            this.bCert.TabIndex = 0;
            this.bCert.Text = "Calibration Certificate";
            this.bCert.UseVisualStyleBackColor = false;
            this.bCert.Click += new System.EventHandler(this.bCert_Click);
            // 
            // bRisk
            // 
            this.bRisk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.bRisk.Location = new System.Drawing.Point(41, 108);
            this.bRisk.Name = "bRisk";
            this.bRisk.Size = new System.Drawing.Size(304, 59);
            this.bRisk.TabIndex = 1;
            this.bRisk.Text = "Risk Assessment";
            this.bRisk.UseVisualStyleBackColor = false;
            this.bRisk.Click += new System.EventHandler(this.bRisk_Click);
            // 
            // bDocs
            // 
            this.bDocs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(100)))), ((int)(((byte)(250)))));
            this.bDocs.Location = new System.Drawing.Point(41, 184);
            this.bDocs.Name = "bDocs";
            this.bDocs.Size = new System.Drawing.Size(304, 59);
            this.bDocs.TabIndex = 2;
            this.bDocs.Text = "Calibration Documents";
            this.bDocs.UseVisualStyleBackColor = false;
            this.bDocs.Click += new System.EventHandler(this.bDocs_Click);
            // 
            // bRepair
            // 
            this.bRepair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(250)))));
            this.bRepair.Location = new System.Drawing.Point(41, 262);
            this.bRepair.Name = "bRepair";
            this.bRepair.Size = new System.Drawing.Size(304, 59);
            this.bRepair.TabIndex = 3;
            this.bRepair.Text = "Repair Documents";
            this.bRepair.UseVisualStyleBackColor = false;
            this.bRepair.Click += new System.EventHandler(this.bRepair_Click);
            // 
            // bBack
            // 
            this.bBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(50)))));
            this.bBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBack.Location = new System.Drawing.Point(378, 34);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(59, 287);
            this.bBack.TabIndex = 6;
            this.bBack.Text = "BACK";
            this.bBack.UseVisualStyleBackColor = false;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // f66_Attach_PDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(471, 365);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.bRepair);
            this.Controls.Add(this.bDocs);
            this.Controls.Add(this.bRisk);
            this.Controls.Add(this.bCert);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "f66_Attach_PDF";
            this.Text = "f66_Attach_PDF";
            this.Load += new System.EventHandler(this.f66_Attach_PDF_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button bCert;
        private System.Windows.Forms.Button bRisk;
        private System.Windows.Forms.Button bDocs;
        private System.Windows.Forms.Button bRepair;
        private System.Windows.Forms.Button bBack;
    }
}