namespace NAVCanonLabelPrint
{
    partial class f29999
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BbExit = new System.Windows.Forms.Button();
            this.BbPrint = new System.Windows.Forms.Button();
            this.BbClear = new System.Windows.Forms.Button();
            this.BbSelectAll = new System.Windows.Forms.Button();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.bChangeDate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // BbExit
            // 
            this.BbExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(175)))), ((int)(((byte)(150)))));
            this.BbExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BbExit.Location = new System.Drawing.Point(742, 31);
            this.BbExit.Name = "BbExit";
            this.BbExit.Size = new System.Drawing.Size(126, 48);
            this.BbExit.TabIndex = 19;
            this.BbExit.Text = "EXIT";
            this.BbExit.UseVisualStyleBackColor = false;
            this.BbExit.Click += new System.EventHandler(this.BbExit_Click);
            // 
            // BbPrint
            // 
            this.BbPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(175)))), ((int)(((byte)(250)))));
            this.BbPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BbPrint.Location = new System.Drawing.Point(348, 31);
            this.BbPrint.Name = "BbPrint";
            this.BbPrint.Size = new System.Drawing.Size(372, 48);
            this.BbPrint.TabIndex = 18;
            this.BbPrint.Text = "PRINT SELECTED LABELS";
            this.BbPrint.UseVisualStyleBackColor = false;
            this.BbPrint.Click += new System.EventHandler(this.BbPrint_Click);
            // 
            // BbClear
            // 
            this.BbClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(75)))), ((int)(((byte)(250)))));
            this.BbClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BbClear.Location = new System.Drawing.Point(199, 31);
            this.BbClear.Name = "BbClear";
            this.BbClear.Size = new System.Drawing.Size(126, 48);
            this.BbClear.TabIndex = 17;
            this.BbClear.Text = "CLEAR";
            this.BbClear.UseVisualStyleBackColor = false;
            this.BbClear.Click += new System.EventHandler(this.BbClear_Click);
            // 
            // BbSelectAll
            // 
            this.BbSelectAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(75)))), ((int)(((byte)(250)))));
            this.BbSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BbSelectAll.Location = new System.Drawing.Point(50, 31);
            this.BbSelectAll.Name = "BbSelectAll";
            this.BbSelectAll.Size = new System.Drawing.Size(126, 48);
            this.BbSelectAll.TabIndex = 16;
            this.BbSelectAll.Text = "SELECT ALL";
            this.BbSelectAll.UseVisualStyleBackColor = false;
            this.BbSelectAll.Click += new System.EventHandler(this.BbSelectAll_Click);
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.AllowUserToResizeColumns = false;
            this.DGV.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.OrangeRed;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(75)))), ((int)(((byte)(100)))));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DGV.Location = new System.Drawing.Point(50, 97);
            this.DGV.Margin = new System.Windows.Forms.Padding(2);
            this.DGV.Name = "DGV";
            this.DGV.RowHeadersVisible = false;
            this.DGV.Size = new System.Drawing.Size(958, 254);
            this.DGV.TabIndex = 15;
            // 
            // bChangeDate
            // 
            this.bChangeDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(175)))), ((int)(((byte)(150)))));
            this.bChangeDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bChangeDate.Location = new System.Drawing.Point(920, 12);
            this.bChangeDate.Name = "bChangeDate";
            this.bChangeDate.Size = new System.Drawing.Size(126, 67);
            this.bChangeDate.TabIndex = 20;
            this.bChangeDate.Text = "CHANGE SHIPMENT DATE";
            this.bChangeDate.UseVisualStyleBackColor = false;
            this.bChangeDate.Visible = false;
            this.bChangeDate.Click += new System.EventHandler(this.bChangeDate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(195, 362);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(593, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Change the shipment date by editing the field and then clicking on  the Print but" +
    "ton.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(195, 389);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(557, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "The label will only show up on a list where all the shipment dates are the same.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(211, 414);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(485, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "You can change the position number in the same manner as above.";
            // 
            // f29999
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(195)))), ((int)(((byte)(145)))));
            this.ClientSize = new System.Drawing.Size(1059, 453);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bChangeDate);
            this.Controls.Add(this.BbExit);
            this.Controls.Add(this.BbPrint);
            this.Controls.Add(this.BbClear);
            this.Controls.Add(this.BbSelectAll);
            this.Controls.Add(this.DGV);
            this.Name = "f29999";
            this.Text = "Select Labels to Print - 9999AJ";
            this.Load += new System.EventHandler(this.f29999_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BbExit;
        private System.Windows.Forms.Button BbPrint;
        private System.Windows.Forms.Button BbClear;
        private System.Windows.Forms.Button BbSelectAll;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Button bChangeDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}