namespace RepairLabels
{
    partial class F1_Select
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
            this.tbSearchPartNumber = new System.Windows.Forms.TextBox();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.bItem = new System.Windows.Forms.Button();
            this.bSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bFreeText = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSearchPartNumber
            // 
            this.tbSearchPartNumber.Location = new System.Drawing.Point(172, 58);
            this.tbSearchPartNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSearchPartNumber.Name = "tbSearchPartNumber";
            this.tbSearchPartNumber.Size = new System.Drawing.Size(215, 20);
            this.tbSearchPartNumber.TabIndex = 15;
            this.tbSearchPartNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearchPartNumber_KeyDown);
            this.tbSearchPartNumber.Leave += new System.EventHandler(this.tbSearchPartNumber_Leave);
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.OrangeRed;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(66, 156);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.Size = new System.Drawing.Size(425, 281);
            this.DGV.TabIndex = 16;
            this.DGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellContentClick);
            // 
            // bItem
            // 
            this.bItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(166)))), ((int)(((byte)(55)))));
            this.bItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bItem.Location = new System.Drawing.Point(411, 58);
            this.bItem.Name = "bItem";
            this.bItem.Size = new System.Drawing.Size(103, 53);
            this.bItem.TabIndex = 17;
            this.bItem.Text = "GET ITEM";
            this.bItem.UseVisualStyleBackColor = false;
            this.bItem.Click += new System.EventHandler(this.bItem_Click);
            // 
            // bSearch
            // 
            this.bSearch.BackColor = System.Drawing.Color.DarkOrange;
            this.bSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearch.Location = new System.Drawing.Point(46, 32);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(103, 106);
            this.bSearch.TabIndex = 18;
            this.bSearch.Text = "SEARCH PATTERN";
            this.bSearch.UseVisualStyleBackColor = false;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(168, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "ENTRY BOX:";
            // 
            // bFreeText
            // 
            this.bFreeText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(186)))), ((int)(((byte)(255)))));
            this.bFreeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bFreeText.Location = new System.Drawing.Point(172, 97);
            this.bFreeText.Name = "bFreeText";
            this.bFreeText.Size = new System.Drawing.Size(215, 41);
            this.bFreeText.TabIndex = 21;
            this.bFreeText.Text = "FREE TEXT";
            this.bFreeText.UseVisualStyleBackColor = false;
            this.bFreeText.Click += new System.EventHandler(this.bFreeText_Click);
            // 
            // F1_Select
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(100)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(561, 453);
            this.Controls.Add(this.bFreeText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.bItem);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.tbSearchPartNumber);
            this.Name = "F1_Select";
            this.Text = "Select Label";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSearchPartNumber;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Button bItem;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bFreeText;

    }
}

