namespace MicroscopeDB
{
    partial class Accessories
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Lsn = new System.Windows.Forms.Label();
            this.LDateCode = new System.Windows.Forms.Label();
            this.LserialNumber = new System.Windows.Forms.Label();
            this.DGV1 = new System.Windows.Forms.DataGridView();
            this.DGV2 = new System.Windows.Forms.DataGridView();
            this.DGV3 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bBack = new System.Windows.Forms.Button();
            this.LproductLine = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV3)).BeginInit();
            this.SuspendLayout();
            // 
            // Lsn
            // 
            this.Lsn.AutoSize = true;
            this.Lsn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lsn.Location = new System.Drawing.Point(180, 37);
            this.Lsn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lsn.Name = "Lsn";
            this.Lsn.Size = new System.Drawing.Size(69, 20);
            this.Lsn.TabIndex = 187;
            this.Lsn.Text = "XXXXX";
            // 
            // LDateCode
            // 
            this.LDateCode.AutoSize = true;
            this.LDateCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LDateCode.Location = new System.Drawing.Point(129, 37);
            this.LDateCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LDateCode.Name = "LDateCode";
            this.LDateCode.Size = new System.Drawing.Size(63, 20);
            this.LDateCode.TabIndex = 186;
            this.LDateCode.Text = "XX-XX-";
            // 
            // LserialNumber
            // 
            this.LserialNumber.AutoSize = true;
            this.LserialNumber.Location = new System.Drawing.Point(19, 37);
            this.LserialNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LserialNumber.Name = "LserialNumber";
            this.LserialNumber.Size = new System.Drawing.Size(102, 17);
            this.LserialNumber.TabIndex = 185;
            this.LserialNumber.Text = "Serial Number:";
            // 
            // DGV1
            // 
            this.DGV1.AllowUserToAddRows = false;
            this.DGV1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.DGV1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV1.Location = new System.Drawing.Point(47, 83);
            this.DGV1.Name = "DGV1";
            this.DGV1.ReadOnly = true;
            this.DGV1.Size = new System.Drawing.Size(720, 180);
            this.DGV1.TabIndex = 188;
            this.DGV1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV1_CellClick);
            // 
            // DGV2
            // 
            this.DGV2.AllowUserToAddRows = false;
            this.DGV2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.DGV2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV2.Location = new System.Drawing.Point(47, 304);
            this.DGV2.Name = "DGV2";
            this.DGV2.ReadOnly = true;
            this.DGV2.Size = new System.Drawing.Size(720, 180);
            this.DGV2.TabIndex = 189;
            this.DGV2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV2_CellClick);
            // 
            // DGV3
            // 
            this.DGV3.AllowUserToAddRows = false;
            this.DGV3.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(164)))), ((int)(((byte)(50)))));
            this.DGV3.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV3.Location = new System.Drawing.Point(47, 525);
            this.DGV3.Name = "DGV3";
            this.DGV3.ReadOnly = true;
            this.DGV3.Size = new System.Drawing.Size(720, 180);
            this.DGV3.TabIndex = 190;
            this.DGV3.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV3_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 191;
            this.label1.Text = "Objectives";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 285);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 192;
            this.label2.Text = "Standards";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(60, 506);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 16);
            this.label3.TabIndex = 193;
            this.label3.Text = "Other Accessories";
            // 
            // bBack
            // 
            this.bBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(240)))), ((int)(((byte)(100)))));
            this.bBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bBack.Location = new System.Drawing.Point(501, 5);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(315, 33);
            this.bBack.TabIndex = 194;
            this.bBack.Text = "Back";
            this.bBack.UseVisualStyleBackColor = false;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // LproductLine
            // 
            this.LproductLine.AutoSize = true;
            this.LproductLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.LproductLine.Location = new System.Drawing.Point(22, 8);
            this.LproductLine.Name = "LproductLine";
            this.LproductLine.Size = new System.Drawing.Size(70, 24);
            this.LproductLine.TabIndex = 195;
            this.LproductLine.Text = "label22";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(782, 732);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 17);
            this.label9.TabIndex = 196;
            // 
            // Accessories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSalmon;
            this.ClientSize = new System.Drawing.Size(828, 758);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.LproductLine);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGV3);
            this.Controls.Add(this.DGV2);
            this.Controls.Add(this.DGV1);
            this.Controls.Add(this.Lsn);
            this.Controls.Add(this.LDateCode);
            this.Controls.Add(this.LserialNumber);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Accessories";
            this.Text = "Accessories";
            this.Load += new System.EventHandler(this.Accessories_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lsn;
        private System.Windows.Forms.Label LDateCode;
        private System.Windows.Forms.Label LserialNumber;
        private System.Windows.Forms.DataGridView DGV1;
        private System.Windows.Forms.DataGridView DGV2;
        private System.Windows.Forms.DataGridView DGV3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bBack;
        private System.Windows.Forms.Label LproductLine;
        private System.Windows.Forms.Label label9;
    }
}