namespace NAVISIONpermission
{
    partial class F1_Start
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            bSearch = new Button();
            DGV = new DataGridView();
            cbddRole = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            cbddADGroup = new ComboBox();
            bUpdate = new Button();
            label3 = new Label();
            cbddUser = new ComboBox();
            label4 = new Label();
            comboBox1 = new ComboBox();
            bClearFilters = new Button();
            bExport = new Button();
            ((System.ComponentModel.ISupportInitialize)DGV).BeginInit();
            SuspendLayout();
            // 
            // bSearch
            // 
            bSearch.BackColor = Color.FromArgb(210, 255, 145);
            bSearch.Location = new Point(208, 84);
            bSearch.Name = "bSearch";
            bSearch.Size = new Size(134, 51);
            bSearch.TabIndex = 0;
            bSearch.Text = "Filter";
            bSearch.UseVisualStyleBackColor = false;
            bSearch.Click += bSearch_Click;
            // 
            // DGV
            // 
            dataGridViewCellStyle2.BackColor = Color.FromArgb(180, 240, 255);
            DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            DGV.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV.Location = new Point(37, 185);
            DGV.Name = "DGV";
            DGV.Size = new Size(1360, 313);
            DGV.TabIndex = 2;
            // 
            // cbddRole
            // 
            cbddRole.BackColor = Color.FromArgb(192, 192, 255);
            cbddRole.FormattingEnabled = true;
            cbddRole.Location = new Point(98, 32);
            cbddRole.Name = "cbddRole";
            cbddRole.Size = new Size(223, 26);
            cbddRole.TabIndex = 3;
            cbddRole.SelectionChangeCommitted += cbddRole_SelectionChangeCommitted;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 35);
            label1.Name = "label1";
            label1.Size = new Size(59, 18);
            label1.TabIndex = 4;
            label1.Text = "Role ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(359, 38);
            label2.Name = "label2";
            label2.Size = new Size(78, 18);
            label2.TabIndex = 6;
            label2.Text = "AD Group";
            // 
            // cbddADGroup
            // 
            cbddADGroup.BackColor = Color.FromArgb(192, 192, 255);
            cbddADGroup.FormattingEnabled = true;
            cbddADGroup.Location = new Point(443, 35);
            cbddADGroup.Name = "cbddADGroup";
            cbddADGroup.Size = new Size(310, 26);
            cbddADGroup.TabIndex = 5;
            cbddADGroup.SelectionChangeCommitted += cbddADGroup_SelectionChangeCommitted;
            // 
            // bUpdate
            // 
            bUpdate.BackColor = Color.FromArgb(100, 150, 255);
            bUpdate.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bUpdate.Location = new Point(33, 78);
            bUpdate.Name = "bUpdate";
            bUpdate.Size = new Size(150, 62);
            bUpdate.TabIndex = 7;
            bUpdate.Text = "Update Data";
            bUpdate.UseVisualStyleBackColor = false;
            bUpdate.Click += bUpdate_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(782, 41);
            label3.Name = "label3";
            label3.Size = new Size(41, 18);
            label3.TabIndex = 9;
            label3.Text = "User";
            // 
            // cbddUser
            // 
            cbddUser.BackColor = Color.FromArgb(192, 192, 255);
            cbddUser.FormattingEnabled = true;
            cbddUser.Location = new Point(847, 38);
            cbddUser.Name = "cbddUser";
            cbddUser.Size = new Size(223, 26);
            cbddUser.TabIndex = 8;
            cbddUser.SelectionChangeCommitted += cbddUser_SelectionChangeCommitted;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1090, 44);
            label4.Name = "label4";
            label4.Size = new Size(90, 18);
            label4.TabIndex = 11;
            label4.Text = "Object Type";
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.FromArgb(192, 192, 255);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "TableData", "Table", "Form", "Report", "Dataport", "Codeunit", "XMLport", "MenuSuite", "Page", "Query" });
            comboBox1.Location = new Point(1186, 41);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(176, 26);
            comboBox1.TabIndex = 10;
            comboBox1.SelectionChangeCommitted += comboBox1_SelectionChangeCommitted;
            // 
            // bClearFilters
            // 
            bClearFilters.BackColor = Color.FromArgb(255, 215, 145);
            bClearFilters.Location = new Point(371, 84);
            bClearFilters.Name = "bClearFilters";
            bClearFilters.Size = new Size(134, 51);
            bClearFilters.TabIndex = 12;
            bClearFilters.Text = "Clear Filters";
            bClearFilters.UseVisualStyleBackColor = false;
            bClearFilters.Click += bClearFilters_Click;
            // 
            // bExport
            // 
            bExport.BackColor = Color.FromArgb(135, 245, 125);
            bExport.Location = new Point(531, 84);
            bExport.Name = "bExport";
            bExport.Size = new Size(134, 51);
            bExport.TabIndex = 13;
            bExport.Text = "Export to Excel";
            bExport.UseVisualStyleBackColor = false;
            bExport.Click += bExport_Click;
            // 
            // F1_Start
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(210, 145, 255);
            ClientSize = new Size(1437, 540);
            Controls.Add(bExport);
            Controls.Add(bClearFilters);
            Controls.Add(label4);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(cbddUser);
            Controls.Add(bUpdate);
            Controls.Add(label2);
            Controls.Add(cbddADGroup);
            Controls.Add(label1);
            Controls.Add(cbddRole);
            Controls.Add(DGV);
            Controls.Add(bSearch);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "F1_Start";
            Text = "F1_Start";
            Load += F1_Start_Load;
            ((System.ComponentModel.ISupportInitialize)DGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button bSearch;
        private DataGridView DGV;
        private ComboBox cbddRole;
        private Label label1;
        private Label label2;
        private ComboBox cbddADGroup;
        private Button bUpdate;
        private Label label3;
        private ComboBox cbddUser;
        private Label label4;
        private ComboBox comboBox1;
        private Button bClearFilters;
        private Button bExport;
    }
}