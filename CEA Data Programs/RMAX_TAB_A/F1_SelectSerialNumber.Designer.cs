namespace RMAX_TAB_A
{
    partial class F1_SelectSerialNumber
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
            this.bGetItem = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.DGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // bGetItem
            // 
            this.bGetItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(0)))));
            this.bGetItem.Location = new System.Drawing.Point(191, 35);
            this.bGetItem.Name = "bGetItem";
            this.bGetItem.Size = new System.Drawing.Size(111, 57);
            this.bGetItem.TabIndex = 4;
            this.bGetItem.Text = "GET ITEM";
            this.bGetItem.UseVisualStyleBackColor = false;
            this.bGetItem.Click += new System.EventHandler(this.bGetItem_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(53, 66);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(100, 26);
            this.tbSearch.TabIndex = 3;
            // 
            // DGV
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(39, 115);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(207, 292);
            this.DGV.TabIndex = 5;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // F1_SelectSerialNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(160)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(342, 454);
            this.Controls.Add(this.bGetItem);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.DGV);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F1_SelectSerialNumber";
            this.Text = "F1_SelectSerialNumber";
            this.Load += new System.EventHandler(this.F1_SelectSerialNumber_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bGetItem;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.DataGridView DGV;
    }
}