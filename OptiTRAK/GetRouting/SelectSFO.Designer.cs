namespace GetRouting
{
    partial class SelectSFO
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
            this.Lelement = new System.Windows.Forms.Label();
            this.Lproject = new System.Windows.Forms.Label();
            this.Ljob = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // bSearch
            // 
            this.bSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(180)))), ((int)(((byte)(40)))));
            this.bSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearch.Location = new System.Drawing.Point(34, 68);
            this.bSearch.Margin = new System.Windows.Forms.Padding(4);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(137, 65);
            this.bSearch.TabIndex = 10;
            this.bSearch.Text = "SEARCH PATTERN";
            this.bSearch.UseVisualStyleBackColor = false;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.OrangeRed;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(111, 214);
            this.DGV.Margin = new System.Windows.Forms.Padding(4);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersWidth = 20;
            this.DGV.Size = new System.Drawing.Size(131, 268);
            this.DGV.TabIndex = 9;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(200, 89);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(102, 23);
            this.tbSearch.TabIndex = 8;
            // 
            // Lelement
            // 
            this.Lelement.AutoSize = true;
            this.Lelement.Location = new System.Drawing.Point(357, 556);
            this.Lelement.Name = "Lelement";
            this.Lelement.Size = new System.Drawing.Size(63, 17);
            this.Lelement.TabIndex = 16;
            this.Lelement.Text = "Element:";
            // 
            // Lproject
            // 
            this.Lproject.AutoSize = true;
            this.Lproject.Location = new System.Drawing.Point(212, 556);
            this.Lproject.Name = "Lproject";
            this.Lproject.Size = new System.Drawing.Size(56, 17);
            this.Lproject.TabIndex = 15;
            this.Lproject.Text = "Project:";
            // 
            // Ljob
            // 
            this.Ljob.AutoSize = true;
            this.Ljob.Location = new System.Drawing.Point(57, 556);
            this.Ljob.Name = "Ljob";
            this.Ljob.Size = new System.Drawing.Size(35, 17);
            this.Ljob.TabIndex = 14;
            this.Ljob.Text = "Job:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(30, 507);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(569, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Locate Traveler Release Authorization in appropriate folder after selecting SFO.";
            // 
            // SelectSFO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(867, 713);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lelement);
            this.Controls.Add(this.Lproject);
            this.Controls.Add(this.Ljob);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.tbSearch);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SelectSFO";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.SelectSFO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label Lelement;
        private System.Windows.Forms.Label Lproject;
        private System.Windows.Forms.Label Ljob;
        private System.Windows.Forms.Label label1;
    }
}

