namespace PMclose
{
    partial class PMSelect
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
            this.bSearch = new System.Windows.Forms.Button();
            this.bItem = new System.Windows.Forms.Button();
            this.tbSearchEquipment = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(160)))), ((int)(((byte)(150)))));
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(80, 111);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(441, 351);
            this.DGV.TabIndex = 0;
            this.DGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellContentClick);
            // 
            // bSearch
            // 
            this.bSearch.BackColor = System.Drawing.Color.DarkOrange;
            this.bSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearch.Location = new System.Drawing.Point(87, 32);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(103, 53);
            this.bSearch.TabIndex = 6;
            this.bSearch.Text = "SEARCH PATTERN";
            this.bSearch.UseVisualStyleBackColor = false;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // bItem
            // 
            this.bItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bItem.Location = new System.Drawing.Point(409, 32);
            this.bItem.Name = "bItem";
            this.bItem.Size = new System.Drawing.Size(103, 53);
            this.bItem.TabIndex = 5;
            this.bItem.Text = "GET ITEM";
            this.bItem.UseVisualStyleBackColor = true;
            this.bItem.Click += new System.EventHandler(this.bItem_Click);
            // 
            // tbSearchEquipment
            // 
            this.tbSearchEquipment.Location = new System.Drawing.Point(204, 45);
            this.tbSearchEquipment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSearchEquipment.Name = "tbSearchEquipment";
            this.tbSearchEquipment.Size = new System.Drawing.Size(192, 26);
            this.tbSearchEquipment.TabIndex = 4;
            // 
            // PMSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(160)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(610, 520);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.bItem);
            this.Controls.Add(this.tbSearchEquipment);
            this.Controls.Add(this.DGV);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PMSelect";
            this.Text = "PMSelect";
            this.Load += new System.EventHandler(this.PMSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.Button bItem;
        private System.Windows.Forms.TextBox tbSearchEquipment;
    }
}