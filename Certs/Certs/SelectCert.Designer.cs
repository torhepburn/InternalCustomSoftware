namespace Certs
{
    partial class SelectCert
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
            this.bSearch = new System.Windows.Forms.Button();
            this.bItem = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.gbType = new System.Windows.Forms.GroupBox();
            this.rbCompliance = new System.Windows.Forms.RadioButton();
            this.rbCalibration = new System.Windows.Forms.RadioButton();
            this.cbISO17025 = new System.Windows.Forms.CheckBox();
            this.BPrint = new System.Windows.Forms.Button();
            this.bSaveToFolder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.gbType.SuspendLayout();
            this.SuspendLayout();
            // 
            // bSearch
            // 
            this.bSearch.BackColor = System.Drawing.Color.DarkOrange;
            this.bSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearch.Location = new System.Drawing.Point(142, 139);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(103, 53);
            this.bSearch.TabIndex = 23;
            this.bSearch.Text = "SEARCH PATTERN";
            this.bSearch.UseVisualStyleBackColor = false;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // bItem
            // 
            this.bItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(120)))), ((int)(((byte)(200)))));
            this.bItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bItem.Location = new System.Drawing.Point(464, 139);
            this.bItem.Name = "bItem";
            this.bItem.Size = new System.Drawing.Size(103, 53);
            this.bItem.TabIndex = 22;
            this.bItem.Text = "GET ITEM";
            this.bItem.UseVisualStyleBackColor = false;
            this.bItem.Click += new System.EventHandler(this.bItem_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(259, 152);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(192, 20);
            this.tbSearch.TabIndex = 20;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGV.Location = new System.Drawing.Point(73, 207);
            this.DGV.Name = "DGV";
            this.DGV.RowHeadersWidth = 15;
            this.DGV.Size = new System.Drawing.Size(690, 303);
            this.DGV.TabIndex = 27;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // gbType
            // 
            this.gbType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(160)))), ((int)(((byte)(115)))));
            this.gbType.Controls.Add(this.rbCompliance);
            this.gbType.Controls.Add(this.rbCalibration);
            this.gbType.Location = new System.Drawing.Point(111, 9);
            this.gbType.Name = "gbType";
            this.gbType.Size = new System.Drawing.Size(311, 54);
            this.gbType.TabIndex = 29;
            this.gbType.TabStop = false;
            this.gbType.Text = "Select type of Certification";
            this.gbType.Visible = false;
            // 
            // rbCompliance
            // 
            this.rbCompliance.AutoSize = true;
            this.rbCompliance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.rbCompliance.Location = new System.Drawing.Point(164, 19);
            this.rbCompliance.Name = "rbCompliance";
            this.rbCompliance.Size = new System.Drawing.Size(129, 28);
            this.rbCompliance.TabIndex = 28;
            this.rbCompliance.TabStop = true;
            this.rbCompliance.Text = "Compliance";
            this.rbCompliance.UseVisualStyleBackColor = true;
            this.rbCompliance.CheckedChanged += new System.EventHandler(this.rbCompliance_CheckedChanged);
            // 
            // rbCalibration
            // 
            this.rbCalibration.AutoSize = true;
            this.rbCalibration.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.rbCalibration.Location = new System.Drawing.Point(31, 19);
            this.rbCalibration.Name = "rbCalibration";
            this.rbCalibration.Size = new System.Drawing.Size(116, 28);
            this.rbCalibration.TabIndex = 27;
            this.rbCalibration.TabStop = true;
            this.rbCalibration.Text = "Calibration";
            this.rbCalibration.UseVisualStyleBackColor = true;
            this.rbCalibration.CheckedChanged += new System.EventHandler(this.rbCalibration_CheckedChanged);
            // 
            // cbISO17025
            // 
            this.cbISO17025.AutoSize = true;
            this.cbISO17025.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbISO17025.Location = new System.Drawing.Point(464, 28);
            this.cbISO17025.Name = "cbISO17025";
            this.cbISO17025.Size = new System.Drawing.Size(105, 24);
            this.cbISO17025.TabIndex = 30;
            this.cbISO17025.Text = "ISO 17025";
            this.cbISO17025.UseVisualStyleBackColor = true;
            this.cbISO17025.CheckedChanged += new System.EventHandler(this.cbISO17025_CheckedChanged);
            // 
            // BPrint
            // 
            this.BPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(240)))));
            this.BPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BPrint.Location = new System.Drawing.Point(259, 79);
            this.BPrint.Name = "BPrint";
            this.BPrint.Size = new System.Drawing.Size(192, 53);
            this.BPrint.TabIndex = 31;
            this.BPrint.Text = "Print Grid Data";
            this.BPrint.UseVisualStyleBackColor = false;
            this.BPrint.Visible = false;
            this.BPrint.Click += new System.EventHandler(this.BPrint_Click);
            // 
            // bSaveToFolder
            // 
            this.bSaveToFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(100)))));
            this.bSaveToFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSaveToFolder.Location = new System.Drawing.Point(23, 79);
            this.bSaveToFolder.Name = "bSaveToFolder";
            this.bSaveToFolder.Size = new System.Drawing.Size(194, 53);
            this.bSaveToFolder.TabIndex = 32;
            this.bSaveToFolder.Text = "Save File to Folder";
            this.bSaveToFolder.UseVisualStyleBackColor = false;
            this.bSaveToFolder.Visible = false;
            this.bSaveToFolder.Click += new System.EventHandler(this.button1_Click);
            // 
            // SelectCert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(180)))), ((int)(((byte)(165)))));
            this.ClientSize = new System.Drawing.Size(859, 542);
            this.Controls.Add(this.bSaveToFolder);
            this.Controls.Add(this.BPrint);
            this.Controls.Add(this.cbISO17025);
            this.Controls.Add(this.gbType);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.bItem);
            this.Controls.Add(this.tbSearch);
            this.Name = "SelectCert";
            this.Text = "SelectCert";
            this.Activated += new System.EventHandler(this.SelectCert_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectCert_FormClosing);
            this.Load += new System.EventHandler(this.SelectCert_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.gbType.ResumeLayout(false);
            this.gbType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.Button bItem;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.GroupBox gbType;
        private System.Windows.Forms.RadioButton rbCompliance;
        private System.Windows.Forms.RadioButton rbCalibration;
        private System.Windows.Forms.CheckBox cbISO17025;
        private System.Windows.Forms.Button BPrint;
        private System.Windows.Forms.Button bSaveToFolder;
    }
}