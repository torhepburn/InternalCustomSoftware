namespace PMiR
{
    partial class PMinitialRequests
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
            this.pFilters = new System.Windows.Forms.Panel();
            this.Lsite = new System.Windows.Forms.Label();
            this.cbddSite = new System.Windows.Forms.ComboBox();
            this.bFilter = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbddReportedBy = new System.Windows.Forms.ComboBox();
            this.cbddOwner = new System.Windows.Forms.ComboBox();
            this.cbddCostCenter = new System.Windows.Forms.ComboBox();
            this.cbddCategory = new System.Windows.Forms.ComboBox();
            this.cbddSeverity = new System.Windows.Forms.ComboBox();
            this.cbddEquipment = new System.Windows.Forms.ComboBox();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.LrecordCount = new System.Windows.Forms.Label();
            this.pFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // pFilters
            // 
            this.pFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.pFilters.Controls.Add(this.Lsite);
            this.pFilters.Controls.Add(this.cbddSite);
            this.pFilters.Controls.Add(this.bFilter);
            this.pFilters.Controls.Add(this.label7);
            this.pFilters.Controls.Add(this.label5);
            this.pFilters.Controls.Add(this.label4);
            this.pFilters.Controls.Add(this.label3);
            this.pFilters.Controls.Add(this.label2);
            this.pFilters.Controls.Add(this.label1);
            this.pFilters.Controls.Add(this.cbddReportedBy);
            this.pFilters.Controls.Add(this.cbddOwner);
            this.pFilters.Controls.Add(this.cbddCostCenter);
            this.pFilters.Controls.Add(this.cbddCategory);
            this.pFilters.Controls.Add(this.cbddSeverity);
            this.pFilters.Controls.Add(this.cbddEquipment);
            this.pFilters.Location = new System.Drawing.Point(242, 13);
            this.pFilters.Name = "pFilters";
            this.pFilters.Size = new System.Drawing.Size(475, 256);
            this.pFilters.TabIndex = 0;
            // 
            // Lsite
            // 
            this.Lsite.AutoSize = true;
            this.Lsite.Location = new System.Drawing.Point(64, 187);
            this.Lsite.Name = "Lsite";
            this.Lsite.Size = new System.Drawing.Size(31, 13);
            this.Lsite.TabIndex = 16;
            this.Lsite.Text = "SITE";
            this.Lsite.Visible = false;
            // 
            // cbddSite
            // 
            this.cbddSite.FormattingEnabled = true;
            this.cbddSite.Items.AddRange(new object[] {
            "",
            "Costa Mesa",
            "Middlefield",
            "Richmond",
            "Tucson"});
            this.cbddSite.Location = new System.Drawing.Point(178, 184);
            this.cbddSite.Name = "cbddSite";
            this.cbddSite.Size = new System.Drawing.Size(121, 21);
            this.cbddSite.TabIndex = 15;
            this.cbddSite.Visible = false;
            // 
            // bFilter
            // 
            this.bFilter.Location = new System.Drawing.Point(366, 15);
            this.bFilter.Name = "bFilter";
            this.bFilter.Size = new System.Drawing.Size(75, 23);
            this.bFilter.TabIndex = 14;
            this.bFilter.Text = "FILTER";
            this.bFilter.UseVisualStyleBackColor = true;
            this.bFilter.Click += new System.EventHandler(this.bFilter_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(64, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "REPORTED BY";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "OWNER";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "COST CENTER";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "CATEGORY";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "SEVERITY";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "EQUIPMENT ID";
            // 
            // cbddReportedBy
            // 
            this.cbddReportedBy.FormattingEnabled = true;
            this.cbddReportedBy.Location = new System.Drawing.Point(178, 157);
            this.cbddReportedBy.Name = "cbddReportedBy";
            this.cbddReportedBy.Size = new System.Drawing.Size(121, 21);
            this.cbddReportedBy.TabIndex = 6;
            // 
            // cbddOwner
            // 
            this.cbddOwner.FormattingEnabled = true;
            this.cbddOwner.Location = new System.Drawing.Point(178, 130);
            this.cbddOwner.Name = "cbddOwner";
            this.cbddOwner.Size = new System.Drawing.Size(121, 21);
            this.cbddOwner.TabIndex = 4;
            // 
            // cbddCostCenter
            // 
            this.cbddCostCenter.FormattingEnabled = true;
            this.cbddCostCenter.Location = new System.Drawing.Point(178, 103);
            this.cbddCostCenter.Name = "cbddCostCenter";
            this.cbddCostCenter.Size = new System.Drawing.Size(121, 21);
            this.cbddCostCenter.TabIndex = 3;
            // 
            // cbddCategory
            // 
            this.cbddCategory.FormattingEnabled = true;
            this.cbddCategory.Items.AddRange(new object[] {
            "",
            "Continuous Improvement",
            "Machine Down - Production Stopped",
            "Repair",
            "Safety"});
            this.cbddCategory.Location = new System.Drawing.Point(178, 76);
            this.cbddCategory.Name = "cbddCategory";
            this.cbddCategory.Size = new System.Drawing.Size(121, 21);
            this.cbddCategory.TabIndex = 2;
            // 
            // cbddSeverity
            // 
            this.cbddSeverity.FormattingEnabled = true;
            this.cbddSeverity.Items.AddRange(new object[] {
            "",
            "Routine",
            "Severe",
            "Urgent"});
            this.cbddSeverity.Location = new System.Drawing.Point(178, 49);
            this.cbddSeverity.Name = "cbddSeverity";
            this.cbddSeverity.Size = new System.Drawing.Size(121, 21);
            this.cbddSeverity.TabIndex = 1;
            // 
            // cbddEquipment
            // 
            this.cbddEquipment.FormattingEnabled = true;
            this.cbddEquipment.Location = new System.Drawing.Point(178, 22);
            this.cbddEquipment.Name = "cbddEquipment";
            this.cbddEquipment.Size = new System.Drawing.Size(121, 21);
            this.cbddEquipment.TabIndex = 0;
            // 
            // DGV
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(13, 275);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(936, 368);
            this.DGV.TabIndex = 1;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // LrecordCount
            // 
            this.LrecordCount.AutoSize = true;
            this.LrecordCount.Location = new System.Drawing.Point(748, 256);
            this.LrecordCount.Name = "LrecordCount";
            this.LrecordCount.Size = new System.Drawing.Size(97, 13);
            this.LrecordCount.TabIndex = 8;
            this.LrecordCount.Text = "RECORD COUNT:";
            // 
            // PMinitialRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.ClientSize = new System.Drawing.Size(961, 655);
            this.Controls.Add(this.LrecordCount);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.pFilters);
            this.Name = "PMinitialRequests";
            this.Text = "PM Initial Requests";
            this.Load += new System.EventHandler(this.PMinitialRequests_Load);
            this.pFilters.ResumeLayout(false);
            this.pFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pFilters;
        private System.Windows.Forms.Button bFilter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbddReportedBy;
        private System.Windows.Forms.ComboBox cbddOwner;
        private System.Windows.Forms.ComboBox cbddCostCenter;
        private System.Windows.Forms.ComboBox cbddCategory;
        private System.Windows.Forms.ComboBox cbddSeverity;
        private System.Windows.Forms.ComboBox cbddEquipment;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Label Lsite;
        private System.Windows.Forms.ComboBox cbddSite;
        private System.Windows.Forms.Label LrecordCount;
    }
}

