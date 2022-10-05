namespace WorkPlanning
{
    partial class FirstPage
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
            this.bSearch = new System.Windows.Forms.Button();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.bCreateSchedule = new System.Windows.Forms.Button();
            this.bMaintainSchedule = new System.Windows.Forms.Button();
            this.LformFunction = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // bSearch
            // 
            this.bSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(180)))), ((int)(((byte)(80)))));
            this.bSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearch.Location = new System.Drawing.Point(287, 26);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(103, 53);
            this.bSearch.TabIndex = 10;
            this.bSearch.Text = "SEARCH PATTERN";
            this.bSearch.UseVisualStyleBackColor = false;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(179)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.OrangeRed;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(53, 112);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersWidth = 20;
            this.DGV.Size = new System.Drawing.Size(869, 306);
            this.DGV.TabIndex = 9;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(404, 39);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(192, 20);
            this.tbSearch.TabIndex = 8;
            // 
            // bCreateSchedule
            // 
            this.bCreateSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(200)))));
            this.bCreateSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCreateSchedule.Location = new System.Drawing.Point(819, 26);
            this.bCreateSchedule.Name = "bCreateSchedule";
            this.bCreateSchedule.Size = new System.Drawing.Size(103, 53);
            this.bCreateSchedule.TabIndex = 11;
            this.bCreateSchedule.Text = "CREATE SCHEDULE";
            this.bCreateSchedule.UseVisualStyleBackColor = false;
            this.bCreateSchedule.Click += new System.EventHandler(this.bCreateSchedule_Click);
            // 
            // bMaintainSchedule
            // 
            this.bMaintainSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(179)))), ((int)(((byte)(219)))));
            this.bMaintainSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bMaintainSchedule.Location = new System.Drawing.Point(53, 26);
            this.bMaintainSchedule.Name = "bMaintainSchedule";
            this.bMaintainSchedule.Size = new System.Drawing.Size(103, 53);
            this.bMaintainSchedule.TabIndex = 12;
            this.bMaintainSchedule.Text = "MAINTAIN SCHEDULE";
            this.bMaintainSchedule.UseVisualStyleBackColor = false;
            this.bMaintainSchedule.Click += new System.EventHandler(this.bMaintainSchedule_Click);
            // 
            // LformFunction
            // 
            this.LformFunction.AutoSize = true;
            this.LformFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.LformFunction.Location = new System.Drawing.Point(49, 85);
            this.LformFunction.Name = "LformFunction";
            this.LformFunction.Size = new System.Drawing.Size(60, 24);
            this.LformFunction.TabIndex = 13;
            this.LformFunction.Text = "label1";
            // 
            // f1_SelectJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(100)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(977, 488);
            this.Controls.Add(this.LformFunction);
            this.Controls.Add(this.bMaintainSchedule);
            this.Controls.Add(this.bCreateSchedule);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.tbSearch);
            this.Name = "f1_SelectJob";
            this.Text = "f1_SelectJob";
            this.Load += new System.EventHandler(this.f1_SelectJob_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button bCreateSchedule;
        private System.Windows.Forms.Button bMaintainSchedule;
        private System.Windows.Forms.Label LformFunction;
    }
}