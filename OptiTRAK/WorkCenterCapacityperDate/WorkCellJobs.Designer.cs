namespace WorkCenterCapacityperDate
{
    partial class WorkCellJobs
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
            this.LworkCell = new System.Windows.Forms.Label();
            this.LworkCellDescription = new System.Windows.Forms.Label();
            this.LrunningDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.OrangeRed;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(54, 101);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersWidth = 20;
            this.DGV.Size = new System.Drawing.Size(751, 525);
            this.DGV.TabIndex = 14;
            // 
            // LworkCell
            // 
            this.LworkCell.AutoSize = true;
            this.LworkCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(175)))), ((int)(((byte)(150)))));
            this.LworkCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LworkCell.Location = new System.Drawing.Point(71, 26);
            this.LworkCell.Name = "LworkCell";
            this.LworkCell.Size = new System.Drawing.Size(51, 20);
            this.LworkCell.TabIndex = 15;
            this.LworkCell.Text = "label1";
            // 
            // LworkCellDescription
            // 
            this.LworkCellDescription.AutoSize = true;
            this.LworkCellDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(175)))), ((int)(((byte)(150)))));
            this.LworkCellDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LworkCellDescription.Location = new System.Drawing.Point(245, 26);
            this.LworkCellDescription.Name = "LworkCellDescription";
            this.LworkCellDescription.Size = new System.Drawing.Size(51, 20);
            this.LworkCellDescription.TabIndex = 16;
            this.LworkCellDescription.Text = "label2";
            // 
            // LrunningDate
            // 
            this.LrunningDate.AutoSize = true;
            this.LrunningDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(175)))), ((int)(((byte)(150)))));
            this.LrunningDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LrunningDate.Location = new System.Drawing.Point(71, 65);
            this.LrunningDate.Name = "LrunningDate";
            this.LrunningDate.Size = new System.Drawing.Size(51, 20);
            this.LrunningDate.TabIndex = 17;
            this.LrunningDate.Text = "label3";
            // 
            // WorkCellJobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(75)))), ((int)(((byte)(150)))));
            this.ClientSize = new System.Drawing.Size(867, 703);
            this.Controls.Add(this.LrunningDate);
            this.Controls.Add(this.LworkCellDescription);
            this.Controls.Add(this.LworkCell);
            this.Controls.Add(this.DGV);
            this.Name = "WorkCellJobs";
            this.Text = "WorkCellJobs";
            this.Load += new System.EventHandler(this.WorkCellJobs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Label LworkCell;
        private System.Windows.Forms.Label LworkCellDescription;
        private System.Windows.Forms.Label LrunningDate;
    }
}