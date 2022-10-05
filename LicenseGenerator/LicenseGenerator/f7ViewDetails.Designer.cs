namespace LicenseGenerator
{
    partial class f7ViewDetails
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
            this.bSearch = new System.Windows.Forms.Button();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.bGoTo = new System.Windows.Forms.Button();
            this.L2Bdeleted = new System.Windows.Forms.Label();
            this.LDelete = new System.Windows.Forms.Label();
            this.bDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // bSearch
            // 
            this.bSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(100)))), ((int)(((byte)(50)))));
            this.bSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.bSearch.Location = new System.Drawing.Point(46, 37);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(103, 53);
            this.bSearch.TabIndex = 10;
            this.bSearch.Text = "SEARCH";
            this.bSearch.UseVisualStyleBackColor = false;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.OrangeRed;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            //this.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(96, 122);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.Size = new System.Drawing.Size(724, 306);
            this.DGV.TabIndex = 2;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(177, 53);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(183, 26);
            this.tbSearch.TabIndex = 0;
            // 
            // bGoTo
            // 
            this.bGoTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(100)))), ((int)(((byte)(50)))));
            this.bGoTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.bGoTo.Location = new System.Drawing.Point(384, 40);
            this.bGoTo.Name = "bGoTo";
            this.bGoTo.Size = new System.Drawing.Size(103, 53);
            this.bGoTo.TabIndex = 1;
            this.bGoTo.Text = "GO TO";
            this.bGoTo.UseVisualStyleBackColor = false;
            this.bGoTo.Click += new System.EventHandler(this.bGoTo_Click);
            // 
            // L2Bdeleted
            // 
            this.L2Bdeleted.AutoSize = true;
            this.L2Bdeleted.Location = new System.Drawing.Point(173, 20);
            this.L2Bdeleted.Name = "L2Bdeleted";
            this.L2Bdeleted.Size = new System.Drawing.Size(119, 20);
            this.L2Bdeleted.TabIndex = 12;
            this.L2Bdeleted.Text = "To Be Deleted: ";
            this.L2Bdeleted.Visible = false;
            // 
            // LDelete
            // 
            this.LDelete.AutoSize = true;
            this.LDelete.Location = new System.Drawing.Point(298, 20);
            this.LDelete.Name = "LDelete";
            this.LDelete.Size = new System.Drawing.Size(0, 20);
            this.LDelete.TabIndex = 11;
            // 
            // bDelete
            // 
            this.bDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.bDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.bDelete.Location = new System.Drawing.Point(518, 40);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(139, 53);
            this.bDelete.TabIndex = 13;
            this.bDelete.Text = "DELETE";
            this.bDelete.UseVisualStyleBackColor = false;
            this.bDelete.Visible = false;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // f7ViewDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(150)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(917, 476);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.L2Bdeleted);
            this.Controls.Add(this.bGoTo);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.LDelete);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.DGV);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "f7ViewDetails";
            this.Text = "f7ViewDetails";
            this.Load += new System.EventHandler(this.f7ViewDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button bGoTo;
        private System.Windows.Forms.Label L2Bdeleted;
        private System.Windows.Forms.Label LDelete;
        private System.Windows.Forms.Button bDelete;

    }
}