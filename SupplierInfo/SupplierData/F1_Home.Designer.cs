namespace SupplierData
{
    partial class F1_Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DGV = new DataGridView();
            bSearch = new Button();
            bItem = new Button();
            tbSearch = new TextBox();
            cbRegion = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            cbCommodity = new ComboBox();
            label3 = new Label();
            cbTitle = new ComboBox();
            label4 = new Label();
            cbPurchaser = new ComboBox();
            bFilters = new Button();
            ((System.ComponentModel.ISupportInitialize)DGV).BeginInit();
            SuspendLayout();
            // 
            // DGV
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(192, 255, 192);
            DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DGV.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGV.BackgroundColor = Color.Black;
            DGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV.Location = new Point(22, 185);
            DGV.Name = "DGV";
            DGV.Size = new Size(1447, 436);
            DGV.TabIndex = 0;
            DGV.CellContentClick += DGV_CellContentClick;
            // 
            // bSearch
            // 
            bSearch.BackColor = Color.FromArgb(100, 230, 230);
            bSearch.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bSearch.Location = new Point(268, 95);
            bSearch.Name = "bSearch";
            bSearch.Size = new Size(210, 62);
            bSearch.TabIndex = 1;
            bSearch.Text = "SEARCH Supplier Name";
            bSearch.UseVisualStyleBackColor = false;
            bSearch.Click += bSearch_Click;
            // 
            // bItem
            // 
            bItem.BackColor = Color.FromArgb(230, 100, 230);
            bItem.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bItem.Location = new Point(690, 95);
            bItem.Name = "bItem";
            bItem.Size = new Size(247, 56);
            bItem.TabIndex = 2;
            bItem.Text = "GET Supplier Number";
            bItem.UseVisualStyleBackColor = false;
            bItem.Click += bItem_Click;
            // 
            // tbSearch
            // 
            tbSearch.Location = new Point(484, 117);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(200, 23);
            tbSearch.TabIndex = 3;
            // 
            // cbRegion
            // 
            cbRegion.FormattingEnabled = true;
            cbRegion.Location = new Point(134, 50);
            cbRegion.Name = "cbRegion";
            cbRegion.Size = new Size(201, 23);
            cbRegion.TabIndex = 7;
            cbRegion.SelectionChangeCommitted += CbRegion_SelectionChangeCommitted;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 50);
            label1.Name = "label1";
            label1.Size = new Size(106, 20);
            label1.TabIndex = 8;
            label1.Text = "Location/Region";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(348, 51);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 10;
            label2.Text = "Commodity";
            // 
            // cbCommodity
            // 
            cbCommodity.FormattingEnabled = true;
            cbCommodity.Location = new Point(460, 51);
            cbCommodity.Name = "cbCommodity";
            cbCommodity.Size = new Size(278, 23);
            cbCommodity.TabIndex = 9;
            cbCommodity.SelectionChangeCommitted += cbCommodity_SelectionChangeCommitted;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(748, 51);
            label3.Name = "label3";
            label3.Size = new Size(81, 20);
            label3.TabIndex = 12;
            label3.Text = "Vendor Title";
            // 
            // cbTitle
            // 
            cbTitle.FormattingEnabled = true;
            cbTitle.Location = new Point(860, 51);
            cbTitle.Name = "cbTitle";
            cbTitle.Size = new Size(186, 23);
            cbTitle.TabIndex = 11;
            cbTitle.SelectionChangeCommitted += cbTitle_SelectionChangeCommitted;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(1069, 54);
            label4.Name = "label4";
            label4.Size = new Size(106, 20);
            label4.TabIndex = 14;
            label4.Text = "Purchaser Code";
            // 
            // cbPurchaser
            // 
            cbPurchaser.FormattingEnabled = true;
            cbPurchaser.Location = new Point(1181, 51);
            cbPurchaser.Name = "cbPurchaser";
            cbPurchaser.Size = new Size(186, 23);
            cbPurchaser.TabIndex = 13;
            cbPurchaser.SelectionChangeCommitted += cbPurchaser_SelectionChangeCommitted;
            // 
            // bFilters
            // 
            bFilters.BackColor = Color.FromArgb(230, 130, 100);
            bFilters.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bFilters.Location = new Point(22, 95);
            bFilters.Name = "bFilters";
            bFilters.Size = new Size(210, 62);
            bFilters.TabIndex = 19;
            bFilters.Text = "Apply Filters";
            bFilters.UseVisualStyleBackColor = false;
            bFilters.Click += bFilters_Click;
            // 
            // F1_Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 230, 100);
            ClientSize = new Size(1494, 649);
            Controls.Add(bFilters);
            Controls.Add(label4);
            Controls.Add(cbPurchaser);
            Controls.Add(label3);
            Controls.Add(cbTitle);
            Controls.Add(label2);
            Controls.Add(cbCommodity);
            Controls.Add(label1);
            Controls.Add(cbRegion);
            Controls.Add(tbSearch);
            Controls.Add(bItem);
            Controls.Add(bSearch);
            Controls.Add(DGV);
            Name = "F1_Home";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)DGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DGV;
        private Button bSearch;
        private Button bItem;
        private TextBox tbSearch;
        private ComboBox cbRegion;
        private Label label1;
        private Label label2;
        private ComboBox cbCommodity;
        private Label label3;
        private ComboBox cbTitle;
        private Label label4;
        private ComboBox cbPurchaser;
        private Button bFilters;
    }
}
