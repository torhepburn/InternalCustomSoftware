namespace Service
{
    partial class CoverageDetails
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
            this.Lcustomer = new System.Windows.Forms.Label();
            this.Lregion = new System.Windows.Forms.Label();
            this.Llocation = new System.Windows.Forms.Label();
            this.Lcontract = new System.Windows.Forms.Label();
            this.Ltype = new System.Windows.Forms.Label();
            this.Lexpiration = new System.Windows.Forms.Label();
            this.DGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // Lcustomer
            // 
            this.Lcustomer.AutoSize = true;
            this.Lcustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.Lcustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Lcustomer.Location = new System.Drawing.Point(65, 47);
            this.Lcustomer.Name = "Lcustomer";
            this.Lcustomer.Size = new System.Drawing.Size(75, 20);
            this.Lcustomer.TabIndex = 0;
            this.Lcustomer.Text = "customer";
            // 
            // Lregion
            // 
            this.Lregion.AutoSize = true;
            this.Lregion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.Lregion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Lregion.Location = new System.Drawing.Point(378, 47);
            this.Lregion.Name = "Lregion";
            this.Lregion.Size = new System.Drawing.Size(53, 20);
            this.Lregion.TabIndex = 1;
            this.Lregion.Text = "region";
            // 
            // Llocation
            // 
            this.Llocation.AutoSize = true;
            this.Llocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.Llocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Llocation.Location = new System.Drawing.Point(515, 47);
            this.Llocation.Name = "Llocation";
            this.Llocation.Size = new System.Drawing.Size(64, 20);
            this.Llocation.TabIndex = 2;
            this.Llocation.Text = "location";
            // 
            // Lcontract
            // 
            this.Lcontract.AutoSize = true;
            this.Lcontract.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.Lcontract.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Lcontract.Location = new System.Drawing.Point(65, 122);
            this.Lcontract.Name = "Lcontract";
            this.Lcontract.Size = new System.Drawing.Size(67, 20);
            this.Lcontract.TabIndex = 3;
            this.Lcontract.Text = "contract";
            // 
            // Ltype
            // 
            this.Ltype.AutoSize = true;
            this.Ltype.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.Ltype.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Ltype.Location = new System.Drawing.Point(243, 122);
            this.Ltype.Name = "Ltype";
            this.Ltype.Size = new System.Drawing.Size(39, 20);
            this.Ltype.TabIndex = 4;
            this.Ltype.Text = "type";
            // 
            // Lexpiration
            // 
            this.Lexpiration.AutoSize = true;
            this.Lexpiration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.Lexpiration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Lexpiration.Location = new System.Drawing.Point(378, 122);
            this.Lexpiration.Name = "Lexpiration";
            this.Lexpiration.Size = new System.Drawing.Size(77, 20);
            this.Lexpiration.TabIndex = 5;
            this.Lexpiration.Text = "expiration";
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(45, 208);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersWidth = 20;
            this.DGV.Size = new System.Drawing.Size(570, 273);
            this.DGV.TabIndex = 12;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // CoverageDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(140)))), ((int)(((byte)(170)))));
            this.ClientSize = new System.Drawing.Size(663, 519);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.Lexpiration);
            this.Controls.Add(this.Ltype);
            this.Controls.Add(this.Lcontract);
            this.Controls.Add(this.Llocation);
            this.Controls.Add(this.Lregion);
            this.Controls.Add(this.Lcustomer);
            this.Name = "CoverageDetails";
            this.Text = "CoverageDetails";
            this.Load += new System.EventHandler(this.CoverageDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lcustomer;
        private System.Windows.Forms.Label Lregion;
        private System.Windows.Forms.Label Llocation;
        private System.Windows.Forms.Label Lcontract;
        private System.Windows.Forms.Label Ltype;
        private System.Windows.Forms.Label Lexpiration;
        private System.Windows.Forms.DataGridView DGV;
    }
}