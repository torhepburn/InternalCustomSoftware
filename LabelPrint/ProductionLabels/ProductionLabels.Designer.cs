namespace ProductionLabels
{
    partial class ProductionLabels
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
            this.Bprint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbProductionOrder = new System.Windows.Forms.TextBox();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.cbAll = new System.Windows.Forms.CheckBox();
            this.bPrintSelectedLine = new System.Windows.Forms.Button();
            this.cbReference = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // Bprint
            // 
            this.Bprint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(60)))));
            this.Bprint.Location = new System.Drawing.Point(60, 154);
            this.Bprint.Name = "Bprint";
            this.Bprint.Size = new System.Drawing.Size(278, 79);
            this.Bprint.TabIndex = 11;
            this.Bprint.Text = "PRINT";
            this.Bprint.UseVisualStyleBackColor = false;
            this.Bprint.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Production Order Number:";
            // 
            // tbProductionOrder
            // 
            this.tbProductionOrder.Location = new System.Drawing.Point(250, 47);
            this.tbProductionOrder.Name = "tbProductionOrder";
            this.tbProductionOrder.Size = new System.Drawing.Size(100, 23);
            this.tbProductionOrder.TabIndex = 7;
            // 
            // DGV
            // 
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(60, 253);
            this.DGV.Name = "DGV";
            this.DGV.RowHeadersVisible = false;
            this.DGV.RowHeadersWidth = 5;
            this.DGV.Size = new System.Drawing.Size(111, 150);
            this.DGV.TabIndex = 12;
            this.DGV.Visible = false;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // cbAll
            // 
            this.cbAll.AutoSize = true;
            this.cbAll.Checked = true;
            this.cbAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cbAll.Location = new System.Drawing.Point(60, 99);
            this.cbAll.Name = "cbAll";
            this.cbAll.Size = new System.Drawing.Size(292, 28);
            this.cbAll.TabIndex = 13;
            this.cbAll.Text = "Print All Production Order Lines";
            this.cbAll.UseVisualStyleBackColor = true;
            // 
            // bPrintSelectedLine
            // 
            this.bPrintSelectedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(60)))));
            this.bPrintSelectedLine.Location = new System.Drawing.Point(213, 285);
            this.bPrintSelectedLine.Name = "bPrintSelectedLine";
            this.bPrintSelectedLine.Size = new System.Drawing.Size(139, 79);
            this.bPrintSelectedLine.TabIndex = 14;
            this.bPrintSelectedLine.Text = "PRINT";
            this.bPrintSelectedLine.UseVisualStyleBackColor = false;
            this.bPrintSelectedLine.Visible = false;
            this.bPrintSelectedLine.Click += new System.EventHandler(this.bPrintSelectedLine_Click);
            // 
            // cbReference
            // 
            this.cbReference.AutoSize = true;
            this.cbReference.Checked = true;
            this.cbReference.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cbReference.Location = new System.Drawing.Point(60, 120);
            this.cbReference.Name = "cbReference";
            this.cbReference.Size = new System.Drawing.Size(272, 28);
            this.cbReference.TabIndex = 15;
            this.cbReference.Text = "Print Reference Components";
            this.cbReference.UseVisualStyleBackColor = true;
            // 
            // ProductionLabels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(100)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(417, 435);
            this.Controls.Add(this.cbReference);
            this.Controls.Add(this.bPrintSelectedLine);
            this.Controls.Add(this.cbAll);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.Bprint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbProductionOrder);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProductionLabels";
            this.Text = "Production Labels";
            this.Load += new System.EventHandler(this.ProductionLabels_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Bprint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbProductionOrder;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.CheckBox cbAll;
        private System.Windows.Forms.Button bPrintSelectedLine;
        private System.Windows.Forms.CheckBox cbReference;
    }
}

