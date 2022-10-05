namespace NDA
{
    partial class SelectNDA
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbSearchPartNumber = new System.Windows.Forms.TextBox();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.bSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Badd = new System.Windows.Forms.Button();
            this.BDelete = new System.Windows.Forms.Button();
            this.BviewPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSearchPartNumber
            // 
            this.tbSearchPartNumber.Location = new System.Drawing.Point(340, 25);
            this.tbSearchPartNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSearchPartNumber.Name = "tbSearchPartNumber";
            this.tbSearchPartNumber.Size = new System.Drawing.Size(215, 23);
            this.tbSearchPartNumber.TabIndex = 27;
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Aquamarine;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(48, 105);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersWidth = 20;
            this.DGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGV.Size = new System.Drawing.Size(782, 460);
            this.DGV.TabIndex = 28;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            this.DGV.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_ColumnHeaderMouseClick);
            // 
            // bSearch
            // 
            this.bSearch.BackColor = System.Drawing.Color.LightSalmon;
            this.bSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearch.Location = new System.Drawing.Point(574, 6);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(100, 60);
            this.bSearch.TabIndex = 30;
            this.bSearch.Text = "SEARCH PATTERN";
            this.bSearch.UseVisualStyleBackColor = false;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(389, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "ENTRY BOX:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(281, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(294, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "Click on grid below to directly select item.";
            // 
            // Badd
            // 
            this.Badd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(200)))), ((int)(((byte)(45)))));
            this.Badd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Badd.Location = new System.Drawing.Point(87, 6);
            this.Badd.Name = "Badd";
            this.Badd.Size = new System.Drawing.Size(100, 60);
            this.Badd.TabIndex = 33;
            this.Badd.Text = "NEW NDA";
            this.Badd.UseVisualStyleBackColor = false;
            this.Badd.Click += new System.EventHandler(this.Badd_Click);
            // 
            // BDelete
            // 
            this.BDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(45)))));
            this.BDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BDelete.ForeColor = System.Drawing.Color.Coral;
            this.BDelete.Location = new System.Drawing.Point(711, 6);
            this.BDelete.Name = "BDelete";
            this.BDelete.Size = new System.Drawing.Size(100, 60);
            this.BDelete.TabIndex = 34;
            this.BDelete.Text = "Delete NDA";
            this.BDelete.UseVisualStyleBackColor = false;
            this.BDelete.Click += new System.EventHandler(this.BDelete_Click);
            // 
            // BviewPDF
            // 
            this.BviewPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(140)))), ((int)(((byte)(205)))));
            this.BviewPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BviewPDF.Location = new System.Drawing.Point(214, 6);
            this.BviewPDF.Name = "BviewPDF";
            this.BviewPDF.Size = new System.Drawing.Size(100, 60);
            this.BviewPDF.TabIndex = 35;
            this.BviewPDF.Text = "VIEW  PDF";
            this.BviewPDF.UseVisualStyleBackColor = false;
            this.BviewPDF.Click += new System.EventHandler(this.BviewPDF_Click);
            // 
            // SelectNDA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(150)))));
            this.ClientSize = new System.Drawing.Size(885, 615);
            this.Controls.Add(this.BviewPDF);
            this.Controls.Add(this.BDelete);
            this.Controls.Add(this.Badd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.tbSearchPartNumber);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SelectNDA";
            this.Text = "SelectNDA";
            this.Load += new System.EventHandler(this.SelectNDA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSearchPartNumber;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Badd;
        private System.Windows.Forms.Button BDelete;
        private System.Windows.Forms.Button BviewPDF;
    }
}