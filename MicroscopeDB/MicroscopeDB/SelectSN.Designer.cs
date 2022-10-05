namespace MicroscopeDB
{
    partial class SelectSN
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
            this.bItem = new System.Windows.Forms.Button();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.tbSearchEquipment = new System.Windows.Forms.TextBox();
            this.rbSystem = new System.Windows.Forms.RadioButton();
            this.rbAccessories = new System.Windows.Forms.RadioButton();
            this.rbAPCAL = new System.Windows.Forms.RadioButton();
            this.rbATP = new System.Windows.Forms.RadioButton();
            this.LproductLine = new System.Windows.Forms.Label();
            this.bBack = new System.Windows.Forms.Button();
            this.rbDelete = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // bSearch
            // 
            this.bSearch.BackColor = System.Drawing.Color.DarkOrange;
            this.bSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearch.Location = new System.Drawing.Point(89, 120);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(103, 53);
            this.bSearch.TabIndex = 7;
            this.bSearch.Text = "SEARCH PATTERN";
            this.bSearch.UseVisualStyleBackColor = false;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // bItem
            // 
            this.bItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bItem.Location = new System.Drawing.Point(411, 120);
            this.bItem.Name = "bItem";
            this.bItem.Size = new System.Drawing.Size(103, 53);
            this.bItem.TabIndex = 6;
            this.bItem.Text = "GET ITEM";
            this.bItem.UseVisualStyleBackColor = true;
            this.bItem.Click += new System.EventHandler(this.bItem_Click);
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.OrangeRed;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(89, 205);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.Size = new System.Drawing.Size(425, 306);
            this.DGV.TabIndex = 5;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // tbSearchEquipment
            // 
            this.tbSearchEquipment.Location = new System.Drawing.Point(206, 133);
            this.tbSearchEquipment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSearchEquipment.Name = "tbSearchEquipment";
            this.tbSearchEquipment.Size = new System.Drawing.Size(192, 23);
            this.tbSearchEquipment.TabIndex = 4;
            // 
            // rbSystem
            // 
            this.rbSystem.AutoSize = true;
            this.rbSystem.Checked = true;
            this.rbSystem.Location = new System.Drawing.Point(47, 68);
            this.rbSystem.Name = "rbSystem";
            this.rbSystem.Size = new System.Drawing.Size(99, 21);
            this.rbSystem.TabIndex = 8;
            this.rbSystem.TabStop = true;
            this.rbSystem.Text = "System Info";
            this.rbSystem.UseVisualStyleBackColor = true;
            // 
            // rbAccessories
            // 
            this.rbAccessories.AutoSize = true;
            this.rbAccessories.Location = new System.Drawing.Point(173, 68);
            this.rbAccessories.Name = "rbAccessories";
            this.rbAccessories.Size = new System.Drawing.Size(102, 21);
            this.rbAccessories.TabIndex = 9;
            this.rbAccessories.Text = "Accessories";
            this.rbAccessories.UseVisualStyleBackColor = true;
            // 
            // rbAPCAL
            // 
            this.rbAPCAL.AutoSize = true;
            this.rbAPCAL.Location = new System.Drawing.Point(398, 68);
            this.rbAPCAL.Name = "rbAPCAL";
            this.rbAPCAL.Size = new System.Drawing.Size(82, 21);
            this.rbAPCAL.TabIndex = 11;
            this.rbAPCAL.Text = "AP / CAL";
            this.rbAPCAL.UseVisualStyleBackColor = true;
            // 
            // rbATP
            // 
            this.rbATP.AutoSize = true;
            this.rbATP.Location = new System.Drawing.Point(304, 68);
            this.rbATP.Name = "rbATP";
            this.rbATP.Size = new System.Drawing.Size(53, 21);
            this.rbATP.TabIndex = 10;
            this.rbATP.Text = "ATP";
            this.rbATP.UseVisualStyleBackColor = true;
            // 
            // LproductLine
            // 
            this.LproductLine.AutoSize = true;
            this.LproductLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.LproductLine.Location = new System.Drawing.Point(12, 9);
            this.LproductLine.Name = "LproductLine";
            this.LproductLine.Size = new System.Drawing.Size(70, 24);
            this.LproductLine.TabIndex = 183;
            this.LproductLine.Text = "label22";
            // 
            // bBack
            // 
            this.bBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(240)))), ((int)(((byte)(100)))));
            this.bBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bBack.Location = new System.Drawing.Point(275, 12);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(315, 33);
            this.bBack.TabIndex = 184;
            this.bBack.Text = "Back";
            this.bBack.UseVisualStyleBackColor = false;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // rbDelete
            // 
            this.rbDelete.AutoSize = true;
            this.rbDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            this.rbDelete.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbDelete.Location = new System.Drawing.Point(496, 68);
            this.rbDelete.Name = "rbDelete";
            this.rbDelete.Size = new System.Drawing.Size(80, 21);
            this.rbDelete.TabIndex = 185;
            this.rbDelete.Text = "DELETE";
            this.rbDelete.UseVisualStyleBackColor = false;
            this.rbDelete.CheckedChanged += new System.EventHandler(this.rbDelete_CheckedChanged);
            // 
            // SelectSN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
            this.ClientSize = new System.Drawing.Size(602, 567);
            this.Controls.Add(this.rbDelete);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.LproductLine);
            this.Controls.Add(this.rbAPCAL);
            this.Controls.Add(this.rbATP);
            this.Controls.Add(this.rbAccessories);
            this.Controls.Add(this.rbSystem);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.bItem);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.tbSearchEquipment);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SelectSN";
            this.Text = "SelectSN";
            this.Load += new System.EventHandler(this.SelectSN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.Button bItem;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.TextBox tbSearchEquipment;
        private System.Windows.Forms.RadioButton rbSystem;
        private System.Windows.Forms.RadioButton rbAccessories;
        private System.Windows.Forms.RadioButton rbAPCAL;
        private System.Windows.Forms.RadioButton rbATP;
        private System.Windows.Forms.Label LproductLine;
        private System.Windows.Forms.Button bBack;
        private System.Windows.Forms.RadioButton rbDelete;
    }
}