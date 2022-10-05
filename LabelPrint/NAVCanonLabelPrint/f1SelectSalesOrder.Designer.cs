namespace NAVCanonLabelPrint
{
    partial class f1SelectSalesOrder
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
            this.bRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bItem = new System.Windows.Forms.Button();
            this.tbSearchPartNumber = new System.Windows.Forms.TextBox();
            this.bSearch = new System.Windows.Forms.Button();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // bRefresh
            // 
            this.bRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(160)))), ((int)(((byte)(45)))));
            this.bRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bRefresh.Location = new System.Drawing.Point(37, 153);
            this.bRefresh.Name = "bRefresh";
            this.bRefresh.Size = new System.Drawing.Size(103, 62);
            this.bRefresh.TabIndex = 24;
            this.bRefresh.Text = "REFRESH DATA";
            this.bRefresh.UseVisualStyleBackColor = false;
            this.bRefresh.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(171, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "ENTRY BOX:";
            // 
            // bItem
            // 
            this.bItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(216)))), ((int)(((byte)(55)))));
            this.bItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bItem.Location = new System.Drawing.Point(414, 56);
            this.bItem.Name = "bItem";
            this.bItem.Size = new System.Drawing.Size(103, 53);
            this.bItem.TabIndex = 22;
            this.bItem.Text = "GET ITEM";
            this.bItem.UseVisualStyleBackColor = false;
            this.bItem.Visible = false;
            this.bItem.Click += new System.EventHandler(this.bItem_Click);
            // 
            // tbSearchPartNumber
            // 
            this.tbSearchPartNumber.Location = new System.Drawing.Point(171, 69);
            this.tbSearchPartNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSearchPartNumber.Name = "tbSearchPartNumber";
            this.tbSearchPartNumber.Size = new System.Drawing.Size(215, 26);
            this.tbSearchPartNumber.TabIndex = 21;
            // 
            // bSearch
            // 
            this.bSearch.BackColor = System.Drawing.Color.DarkOrange;
            this.bSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearch.Location = new System.Drawing.Point(37, 52);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(103, 62);
            this.bSearch.TabIndex = 20;
            this.bSearch.Text = "SEARCH PATTERN";
            this.bSearch.UseVisualStyleBackColor = false;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.OrangeRed;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(75)))), ((int)(((byte)(100)))));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(156, 140);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersVisible = false;
            this.DGV.Size = new System.Drawing.Size(244, 230);
            this.DGV.TabIndex = 19;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(69, 373);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(406, 60);
            this.label2.TabIndex = 25;
            this.label2.Text = "If the Sales Order Line is missing from the selected date\r\nselect \"NO\" when asked" +
    " if you want to use the previously\r\nretreived data and your data should be refre" +
    "shed.";
            // 
            // f1SelectSalesOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(175)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(554, 459);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bRefresh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bItem);
            this.Controls.Add(this.tbSearchPartNumber);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.DGV);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "f1SelectSalesOrder";
            this.Text = "Select Sales Order";
            this.Load += new System.EventHandler(this.f1SelectSalesOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bItem;
        private System.Windows.Forms.TextBox tbSearchPartNumber;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Label label2;
    }
}

