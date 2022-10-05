namespace SQLServerUtility
{
    partial class DatabaseDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.bExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(56, 90);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(664, 464);
            this.DGV.TabIndex = 2;
            // 
            // bExcel
            // 
            this.bExcel.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.bExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bExcel.Location = new System.Drawing.Point(56, 12);
            this.bExcel.Name = "bExcel";
            this.bExcel.Size = new System.Drawing.Size(109, 51);
            this.bExcel.TabIndex = 9;
            this.bExcel.Text = "EXCEL EXPORT";
            this.bExcel.UseVisualStyleBackColor = false;
            this.bExcel.Click += new System.EventHandler(this.bExcel_Click);
            // 
            // DatabaseDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(771, 607);
            this.Controls.Add(this.bExcel);
            this.Controls.Add(this.DGV);
            this.Name = "DatabaseDetails";
            this.Text = "DatabaseDetails";
            this.Load += new System.EventHandler(this.DatabaseDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Button bExcel;
    }
}