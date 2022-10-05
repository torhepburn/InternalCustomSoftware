namespace Tools
{
    partial class F63_ChooseSetupSheet
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
            this.DGV = new System.Windows.Forms.DataGridView();
            this.rbToSheet = new System.Windows.Forms.RadioButton();
            this.rbFromSheet = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV
            // 
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(70, 68);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(452, 283);
            this.DGV.TabIndex = 0;
            this.DGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellContentClick);
            // 
            // rbToSheet
            // 
            this.rbToSheet.AutoSize = true;
            this.rbToSheet.Location = new System.Drawing.Point(70, 30);
            this.rbToSheet.Name = "rbToSheet";
            this.rbToSheet.Size = new System.Drawing.Size(143, 24);
            this.rbToSheet.TabIndex = 1;
            this.rbToSheet.TabStop = true;
            this.rbToSheet.Text = "To Setup  Sheet";
            this.rbToSheet.UseVisualStyleBackColor = true;
            // 
            // rbFromSheet
            // 
            this.rbFromSheet.AutoSize = true;
            this.rbFromSheet.Location = new System.Drawing.Point(364, 30);
            this.rbFromSheet.Name = "rbFromSheet";
            this.rbFromSheet.Size = new System.Drawing.Size(158, 24);
            this.rbFromSheet.TabIndex = 2;
            this.rbFromSheet.TabStop = true;
            this.rbFromSheet.Text = "From Setup Sheet";
            this.rbFromSheet.UseVisualStyleBackColor = true;
            // 
            // F63_ChooseSetupSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(185)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(601, 403);
            this.Controls.Add(this.rbFromSheet);
            this.Controls.Add(this.rbToSheet);
            this.Controls.Add(this.DGV);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F63_ChooseSetupSheet";
            this.Text = "F63_ChooseSetupSheet";
            this.Load += new System.EventHandler(this.F63_ChooseSetupSheet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.RadioButton rbToSheet;
        private System.Windows.Forms.RadioButton rbFromSheet;
    }
}