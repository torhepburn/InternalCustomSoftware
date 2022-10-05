namespace CalibrationManager
{
    partial class f17a_Select_Bench
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
            this.DGridView = new System.Windows.Forms.DataGridView();
            this.bDelete = new System.Windows.Forms.Button();
            this.bBack = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.LSearch = new System.Windows.Forms.Label();
            this.bNarrowSelection = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DGridView
            // 
            this.DGridView.AllowUserToAddRows = false;
            this.DGridView.AllowUserToDeleteRows = false;
            this.DGridView.AllowUserToResizeColumns = false;
            this.DGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkKhaki;
            this.DGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGridView.BackgroundColor = System.Drawing.Color.BurlyWood;
            this.DGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGridView.Location = new System.Drawing.Point(56, 142);
            this.DGridView.Name = "DGridView";
            this.DGridView.ReadOnly = true;
            this.DGridView.Size = new System.Drawing.Size(688, 414);
            this.DGridView.TabIndex = 0;
            this.DGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGridView_CellClick);
            // 
            // bDelete
            // 
            this.bDelete.BackColor = System.Drawing.Color.White;
            this.bDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bDelete.Location = new System.Drawing.Point(491, 45);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(253, 51);
            this.bDelete.TabIndex = 2;
            this.bDelete.Text = "Confirm Deletion";
            this.bDelete.UseVisualStyleBackColor = false;
            this.bDelete.Visible = false;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // bBack
            // 
            this.bBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(50)))));
            this.bBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBack.Location = new System.Drawing.Point(798, 45);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(59, 511);
            this.bBack.TabIndex = 6;
            this.bBack.Text = "BACK";
            this.bBack.UseVisualStyleBackColor = false;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(56, 70);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(157, 26);
            this.tbSearch.TabIndex = 7;
            // 
            // LSearch
            // 
            this.LSearch.AutoSize = true;
            this.LSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LSearch.Location = new System.Drawing.Point(52, 45);
            this.LSearch.Name = "LSearch";
            this.LSearch.Size = new System.Drawing.Size(98, 20);
            this.LSearch.TabIndex = 8;
            this.LSearch.Text = "Search for:";
            // 
            // bNarrowSelection
            // 
            this.bNarrowSelection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(250)))));
            this.bNarrowSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bNarrowSelection.Location = new System.Drawing.Point(237, 45);
            this.bNarrowSelection.Name = "bNarrowSelection";
            this.bNarrowSelection.Size = new System.Drawing.Size(80, 63);
            this.bNarrowSelection.TabIndex = 9;
            this.bNarrowSelection.Text = "Find";
            this.bNarrowSelection.UseVisualStyleBackColor = false;
            this.bNarrowSelection.Click += new System.EventHandler(this.bNarrowSelection_Click);
            // 
            // f17a_Select_Bench
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SandyBrown;
            this.ClientSize = new System.Drawing.Size(907, 606);
            this.Controls.Add(this.bNarrowSelection);
            this.Controls.Add(this.LSearch);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.DGridView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "f17a_Select_Bench";
            this.Text = "f17a Select Location";
            this.Load += new System.EventHandler(this.f17a_Select_Bench_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.f17a_Select_Bench_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.DGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGridView;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.Button bBack;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label LSearch;
        private System.Windows.Forms.Button bNarrowSelection;
    }
}