namespace OpenPOreports
{
    partial class OpenPO_Supplier
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
            this.DGV = new System.Windows.Forms.DataGridView();
            this.tbSupplierName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSupplierNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbItemCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDays = new System.Windows.Forms.TextBox();
            this.BgetData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(33, 110);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.Size = new System.Drawing.Size(1055, 432);
            this.DGV.TabIndex = 0;
            // 
            // tbSupplierName
            // 
            this.tbSupplierName.Location = new System.Drawing.Point(146, 58);
            this.tbSupplierName.Name = "tbSupplierName";
            this.tbSupplierName.Size = new System.Drawing.Size(175, 20);
            this.tbSupplierName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(225)))), ((int)(((byte)(200)))));
            this.label1.Location = new System.Drawing.Point(200, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Supplier Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(225)))), ((int)(((byte)(200)))));
            this.label2.Location = new System.Drawing.Point(379, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Supplier Number";
            // 
            // tbSupplierNumber
            // 
            this.tbSupplierNumber.Location = new System.Drawing.Point(352, 58);
            this.tbSupplierNumber.Name = "tbSupplierNumber";
            this.tbSupplierNumber.Size = new System.Drawing.Size(175, 20);
            this.tbSupplierNumber.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(225)))), ((int)(((byte)(200)))));
            this.label3.Location = new System.Drawing.Point(611, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Item Code";
            // 
            // tbItemCode
            // 
            this.tbItemCode.Location = new System.Drawing.Point(563, 58);
            this.tbItemCode.Name = "tbItemCode";
            this.tbItemCode.Size = new System.Drawing.Size(175, 20);
            this.tbItemCode.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(225)))), ((int)(((byte)(200)))));
            this.label4.Location = new System.Drawing.Point(793, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Maximum Days until Due";
            // 
            // tbDays
            // 
            this.tbDays.Location = new System.Drawing.Point(771, 58);
            this.tbDays.Name = "tbDays";
            this.tbDays.Size = new System.Drawing.Size(175, 20);
            this.tbDays.TabIndex = 7;
            // 
            // BgetData
            // 
            this.BgetData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(225)))), ((int)(((byte)(200)))));
            this.BgetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BgetData.Location = new System.Drawing.Point(988, 31);
            this.BgetData.Name = "BgetData";
            this.BgetData.Size = new System.Drawing.Size(100, 58);
            this.BgetData.TabIndex = 9;
            this.BgetData.Text = "Get Data";
            this.BgetData.UseVisualStyleBackColor = false;
            this.BgetData.Click += new System.EventHandler(this.BgetData_Click);
            // 
            // OpenPO_Supplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(125)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(1118, 588);
            this.Controls.Add(this.BgetData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbDays);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbItemCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSupplierNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSupplierName);
            this.Controls.Add(this.DGV);
            this.Name = "OpenPO_Supplier";
            this.Text = "Open PO Supplier Report";
            this.Load += new System.EventHandler(this.OpenPO_Supplier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.TextBox tbSupplierName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSupplierNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbItemCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDays;
        private System.Windows.Forms.Button BgetData;
    }
}

