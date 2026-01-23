namespace SalesProductionLabels
{
    partial class SalesProductionLabels
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            tbSalesOrder = new TextBox();
            DGV = new DataGridView();
            bPrint = new Button();
            ((System.ComponentModel.ISupportInitialize)DGV).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(46, 39);
            label1.Name = "label1";
            label1.Size = new Size(169, 19);
            label1.TabIndex = 0;
            label1.Text = "Sales Order Number:";
            // 
            // tbSalesOrder
            // 
            tbSalesOrder.Location = new Point(251, 39);
            tbSalesOrder.Name = "tbSalesOrder";
            tbSalesOrder.Size = new Size(100, 23);
            tbSalesOrder.TabIndex = 1;
            // 
            // DGV
            // 
            DGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV.Location = new Point(143, 221);
            DGV.Name = "DGV";
            DGV.Size = new Size(100, 150);
            DGV.TabIndex = 2;
            // 
            // bPrint
            // 
            bPrint.BackColor = Color.FromArgb(10, 150, 185);
            bPrint.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bPrint.Location = new Point(56, 123);
            bPrint.Name = "bPrint";
            bPrint.Size = new Size(295, 69);
            bPrint.TabIndex = 3;
            bPrint.Text = "PRINT";
            bPrint.UseVisualStyleBackColor = false;
            bPrint.Click += this.BPrint_Click;
            // 
            // SalesProductionLabels
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(185, 150, 10);
            ClientSize = new Size(415, 414);
            Controls.Add(bPrint);
            Controls.Add(DGV);
            Controls.Add(tbSalesOrder);
            Controls.Add(label1);
            Name = "SalesProductionLabels";
            RightToLeftLayout = true;
            Text = "Sales Production Labels";
            Load += SalesProductionLabels_Load;
            ((System.ComponentModel.ISupportInitialize)DGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbSalesOrder;
        private DataGridView DGV;
        private Button bPrint;
    }
}
