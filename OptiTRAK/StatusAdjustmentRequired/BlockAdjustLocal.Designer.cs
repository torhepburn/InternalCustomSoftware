namespace StatusAdjustmentRequired
{
    partial class BlockAdjustLocal
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Lcustomer = new System.Windows.Forms.Label();
            this.bAdjustDays = new System.Windows.Forms.Button();
            this.tbCmpAdjDays = new System.Windows.Forms.TextBox();
            this.DGV2 = new System.Windows.Forms.DataGridView();
            this.DGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(451, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 20);
            this.label2.TabIndex = 39;
            this.label2.Text = "Days to Adjust (Hold Only)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(236, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 20);
            this.label1.TabIndex = 38;
            this.label1.Text = "Orders to be Adjusted.";
            // 
            // Lcustomer
            // 
            this.Lcustomer.AutoSize = true;
            this.Lcustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Lcustomer.Location = new System.Drawing.Point(-1, 27);
            this.Lcustomer.Name = "Lcustomer";
            this.Lcustomer.Size = new System.Drawing.Size(190, 20);
            this.Lcustomer.TabIndex = 37;
            this.Lcustomer.Text = "Select DueDate to Adjust";
            // 
            // bAdjustDays
            // 
            this.bAdjustDays.BackColor = System.Drawing.Color.Pink;
            this.bAdjustDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bAdjustDays.Location = new System.Drawing.Point(604, 196);
            this.bAdjustDays.Name = "bAdjustDays";
            this.bAdjustDays.Size = new System.Drawing.Size(162, 70);
            this.bAdjustDays.TabIndex = 36;
            this.bAdjustDays.Text = "ADJUST ORDERS";
            this.bAdjustDays.UseVisualStyleBackColor = false;
            this.bAdjustDays.Click += new System.EventHandler(this.bAdjustDays_Click);
            // 
            // tbCmpAdjDays
            // 
            this.tbCmpAdjDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbCmpAdjDays.Location = new System.Drawing.Point(524, 75);
            this.tbCmpAdjDays.Name = "tbCmpAdjDays";
            this.tbCmpAdjDays.Size = new System.Drawing.Size(47, 23);
            this.tbCmpAdjDays.TabIndex = 35;
            // 
            // DGV2
            // 
            this.DGV2.AllowUserToAddRows = false;
            this.DGV2.AllowUserToDeleteRows = false;
            this.DGV2.AllowUserToResizeColumns = false;
            this.DGV2.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue;
            this.DGV2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DGV2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(100)))));
            this.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV2.Location = new System.Drawing.Point(200, 75);
            this.DGV2.Name = "DGV2";
            this.DGV2.ReadOnly = true;
            this.DGV2.RowHeadersVisible = false;
            this.DGV2.RowHeadersWidth = 20;
            this.DGV2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV2.Size = new System.Drawing.Size(250, 366);
            this.DGV2.TabIndex = 34;
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.AllowUserToResizeColumns = false;
            this.DGV.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(100)))));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(37, 75);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersVisible = false;
            this.DGV.RowHeadersWidth = 20;
            this.DGV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV.Size = new System.Drawing.Size(94, 167);
            this.DGV.TabIndex = 33;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // BlockAdjustLocal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(185)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(819, 468);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lcustomer);
            this.Controls.Add(this.bAdjustDays);
            this.Controls.Add(this.tbCmpAdjDays);
            this.Controls.Add(this.DGV2);
            this.Controls.Add(this.DGV);
            this.Name = "BlockAdjustLocal";
            this.Text = "BlockAdjustLocal";
            this.Load += new System.EventHandler(this.BlockAdjustLocal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Lcustomer;
        private System.Windows.Forms.Button bAdjustDays;
        private System.Windows.Forms.TextBox tbCmpAdjDays;
        private System.Windows.Forms.DataGridView DGV2;
        private System.Windows.Forms.DataGridView DGV;
    }
}