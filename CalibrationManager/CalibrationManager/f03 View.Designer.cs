namespace CalibrationManager
{
    partial class f03_View
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
            this.bSearchBench = new System.Windows.Forms.Button();
            this.LtbSearch = new System.Windows.Forms.Label();
            this.bSearchID = new System.Windows.Forms.Button();
            this.bBenchSearch = new System.Windows.Forms.Button();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bIDsearch = new System.Windows.Forms.Button();
            this.bBack = new System.Windows.Forms.Button();
            this.Lrowcount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // bSearchBench
            // 
            this.bSearchBench.BackColor = System.Drawing.Color.LimeGreen;
            this.bSearchBench.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearchBench.Location = new System.Drawing.Point(108, -105);
            this.bSearchBench.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bSearchBench.Name = "bSearchBench";
            this.bSearchBench.Size = new System.Drawing.Size(262, 78);
            this.bSearchBench.TabIndex = 9;
            this.bSearchBench.Text = "Bench";
            this.bSearchBench.UseVisualStyleBackColor = false;
            // 
            // LtbSearch
            // 
            this.LtbSearch.AutoSize = true;
            this.LtbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LtbSearch.Location = new System.Drawing.Point(-134, -215);
            this.LtbSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LtbSearch.Name = "LtbSearch";
            this.LtbSearch.Size = new System.Drawing.Size(112, 24);
            this.LtbSearch.TabIndex = 7;
            this.LtbSearch.Text = "Search for:";
            // 
            // bSearchID
            // 
            this.bSearchID.BackColor = System.Drawing.Color.LimeGreen;
            this.bSearchID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearchID.Location = new System.Drawing.Point(-237, -105);
            this.bSearchID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bSearchID.Name = "bSearchID";
            this.bSearchID.Size = new System.Drawing.Size(262, 78);
            this.bSearchID.TabIndex = 6;
            this.bSearchID.Text = "ID";
            this.bSearchID.UseVisualStyleBackColor = false;
            // 
            // bBenchSearch
            // 
            this.bBenchSearch.BackColor = System.Drawing.Color.LimeGreen;
            this.bBenchSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBenchSearch.Location = new System.Drawing.Point(389, 127);
            this.bBenchSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bBenchSearch.Name = "bBenchSearch";
            this.bBenchSearch.Size = new System.Drawing.Size(150, 75);
            this.bBenchSearch.TabIndex = 14;
            this.bBenchSearch.Text = "Location";
            this.bBenchSearch.UseVisualStyleBackColor = false;
            this.bBenchSearch.Click += new System.EventHandler(this.bBenchSearch_Click);
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV.BackgroundColor = System.Drawing.Color.DarkSeaGreen;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(176, 236);
            this.DGV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.Size = new System.Drawing.Size(571, 291);
            this.DGV.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(213, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "Search for:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.SpringGreen;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(389, 55);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(210, 29);
            this.textBox1.TabIndex = 0;
            // 
            // bIDsearch
            // 
            this.bIDsearch.BackColor = System.Drawing.Color.LimeGreen;
            this.bIDsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bIDsearch.Location = new System.Drawing.Point(176, 127);
            this.bIDsearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bIDsearch.Name = "bIDsearch";
            this.bIDsearch.Size = new System.Drawing.Size(150, 75);
            this.bIDsearch.TabIndex = 11;
            this.bIDsearch.Text = "ID";
            this.bIDsearch.UseVisualStyleBackColor = false;
            this.bIDsearch.Click += new System.EventHandler(this.bIDsearch_Click);
            // 
            // bBack
            // 
            this.bBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(50)))));
            this.bBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBack.Location = new System.Drawing.Point(55, 55);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(59, 472);
            this.bBack.TabIndex = 16;
            this.bBack.Text = "BACK";
            this.bBack.UseVisualStyleBackColor = false;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // Lrowcount
            // 
            this.Lrowcount.AutoSize = true;
            this.Lrowcount.Location = new System.Drawing.Point(172, 211);
            this.Lrowcount.Name = "Lrowcount";
            this.Lrowcount.Size = new System.Drawing.Size(92, 20);
            this.Lrowcount.TabIndex = 18;
            this.Lrowcount.Text = "Row Count:";
            // 
            // f03_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(798, 591);
            this.Controls.Add(this.Lrowcount);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.bBenchSearch);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.bIDsearch);
            this.Controls.Add(this.bSearchBench);
            this.Controls.Add(this.LtbSearch);
            this.Controls.Add(this.bSearchID);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "f03_View";
            this.Text = "f03 View";
            this.Load += new System.EventHandler(this.f03_View_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bSearchBench;
        private System.Windows.Forms.Label LtbSearch;
         private System.Windows.Forms.Button bSearchID;
        private System.Windows.Forms.Button bBenchSearch;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button bIDsearch;
        private System.Windows.Forms.Button bBack;
        private System.Windows.Forms.Label Lrowcount;
    }
}