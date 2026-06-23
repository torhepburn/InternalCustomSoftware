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
            bSearch = new Button();
            tbSearch = new TextBox();
            DGV = new DataGridView();
            cbddRole = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)DGV).BeginInit();
            SuspendLayout();
            // 
            // bSearch
            // 
            bSearch.BackColor = Color.FromArgb(210, 255, 145);
            bSearch.Location = new Point(72, 118);
            bSearch.Name = "bSearch";
            bSearch.Size = new Size(134, 51);
            bSearch.TabIndex = 0;
            bSearch.Text = "Search";
            bSearch.UseVisualStyleBackColor = false;
            bSearch.Click += bSearch_Click;
            // 
            // tbSearch
            // 
            tbSearch.Location = new Point(271, 131);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(178, 26);
            tbSearch.TabIndex = 1;
            // 
            // DGV
            // 
            DGV.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV.Location = new Point(37, 185);
            DGV.Name = "DGV";
            DGV.Size = new Size(725, 313);
            DGV.TabIndex = 2;
            // 
            // cbddRole
            // 
            cbddRole.FormattingEnabled = true;
            cbddRole.Location = new Point(191, 35);
            cbddRole.Name = "cbddRole";
            cbddRole.Size = new Size(121, 26);
            cbddRole.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 35);
            label1.Name = "label1";
            label1.Size = new Size(50, 18);
            label1.TabIndex = 4;
            label1.Text = "label1";
            // 
            // F1_Start
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(210, 145, 255);
            ClientSize = new Size(802, 540);
            Controls.Add(label1);
            Controls.Add(cbddRole);
            Controls.Add(DGV);
            Controls.Add(tbSearch);
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
        private TextBox tbSearch;
        private DataGridView DGV;
        private ComboBox cbddRole;
        private Label label1;
    }
}