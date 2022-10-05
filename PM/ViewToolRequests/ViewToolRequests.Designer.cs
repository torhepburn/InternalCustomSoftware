namespace ViewToolRequests
{
    partial class ViewToolRequests
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
            this.LrecordCount = new System.Windows.Forms.Label();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.pFilters = new System.Windows.Forms.Panel();
            this.Lstatus = new System.Windows.Forms.Label();
            this.cbddStatus = new System.Windows.Forms.ComboBox();
            this.Lsite = new System.Windows.Forms.Label();
            this.cbddSite = new System.Windows.Forms.ComboBox();
            this.bFilter = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbddRequestedBy = new System.Windows.Forms.ComboBox();
            this.cbddOwner = new System.Windows.Forms.ComboBox();
            this.cbddCostCenter = new System.Windows.Forms.ComboBox();
            this.cbddCompleted = new System.Windows.Forms.ComboBox();
            this.cbddPriority = new System.Windows.Forms.ComboBox();
            this.cbddRequest = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.pFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // LrecordCount
            // 
            this.LrecordCount.AutoSize = true;
            this.LrecordCount.Location = new System.Drawing.Point(747, 282);
            this.LrecordCount.Name = "LrecordCount";
            this.LrecordCount.Size = new System.Drawing.Size(97, 13);
            this.LrecordCount.TabIndex = 11;
            this.LrecordCount.Text = "RECORD COUNT:";
            // 
            // DGV
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(12, 301);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(936, 368);
            this.DGV.TabIndex = 10;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // pFilters
            // 
            this.pFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.pFilters.Controls.Add(this.Lstatus);
            this.pFilters.Controls.Add(this.cbddStatus);
            this.pFilters.Controls.Add(this.Lsite);
            this.pFilters.Controls.Add(this.cbddSite);
            this.pFilters.Controls.Add(this.bFilter);
            this.pFilters.Controls.Add(this.label7);
            this.pFilters.Controls.Add(this.label5);
            this.pFilters.Controls.Add(this.label4);
            this.pFilters.Controls.Add(this.label3);
            this.pFilters.Controls.Add(this.label2);
            this.pFilters.Controls.Add(this.label1);
            this.pFilters.Controls.Add(this.cbddRequestedBy);
            this.pFilters.Controls.Add(this.cbddOwner);
            this.pFilters.Controls.Add(this.cbddCostCenter);
            this.pFilters.Controls.Add(this.cbddCompleted);
            this.pFilters.Controls.Add(this.cbddPriority);
            this.pFilters.Controls.Add(this.cbddRequest);
            this.pFilters.Location = new System.Drawing.Point(241, 39);
            this.pFilters.Name = "pFilters";
            this.pFilters.Size = new System.Drawing.Size(475, 256);
            this.pFilters.TabIndex = 9;
            // 
            // Lstatus
            // 
            this.Lstatus.AutoSize = true;
            this.Lstatus.Location = new System.Drawing.Point(64, 52);
            this.Lstatus.Name = "Lstatus";
            this.Lstatus.Size = new System.Drawing.Size(50, 13);
            this.Lstatus.TabIndex = 18;
            this.Lstatus.Text = "STATUS";
            // 
            // cbddStatus
            // 
            this.cbddStatus.FormattingEnabled = true;
            this.cbddStatus.Items.AddRange(new object[] {
            "",
            "Completed",
            "Not Completed"});
            this.cbddStatus.Location = new System.Drawing.Point(178, 49);
            this.cbddStatus.Name = "cbddStatus";
            this.cbddStatus.Size = new System.Drawing.Size(121, 21);
            this.cbddStatus.TabIndex = 17;
            // 
            // Lsite
            // 
            this.Lsite.AutoSize = true;
            this.Lsite.Location = new System.Drawing.Point(64, 214);
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
            this.cbddSite.Location = new System.Drawing.Point(178, 211);
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
            this.label7.Location = new System.Drawing.Point(64, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "REQUESTED BY";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "OWNER";
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "COST CENTER";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "COMPLETED";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "PRIORITY";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "REQUEST ID";
            // 
            // cbddRequestedBy
            // 
            this.cbddRequestedBy.FormattingEnabled = true;
            this.cbddRequestedBy.Location = new System.Drawing.Point(178, 184);
            this.cbddRequestedBy.Name = "cbddRequestedBy";
            this.cbddRequestedBy.Size = new System.Drawing.Size(121, 21);
            this.cbddRequestedBy.TabIndex = 6;
            // 
            // cbddOwner
            // 
            this.cbddOwner.FormattingEnabled = true;
            this.cbddOwner.Location = new System.Drawing.Point(178, 157);
            this.cbddOwner.Name = "cbddOwner";
            this.cbddOwner.Size = new System.Drawing.Size(121, 21);
            this.cbddOwner.TabIndex = 4;
            this.cbddOwner.Visible = false;
            // 
            // cbddCostCenter
            // 
            this.cbddCostCenter.FormattingEnabled = true;
            this.cbddCostCenter.Location = new System.Drawing.Point(178, 130);
            this.cbddCostCenter.Name = "cbddCostCenter";
            this.cbddCostCenter.Size = new System.Drawing.Size(121, 21);
            this.cbddCostCenter.TabIndex = 3;
            // 
            // cbddCompleted
            // 
            this.cbddCompleted.AutoCompleteCustomSource.AddRange(new string[] {
            "",
            "0,",
            "1"});
            this.cbddCompleted.FormattingEnabled = true;
            this.cbddCompleted.Items.AddRange(new object[] {
            "",
            "0,",
            "1"});
            this.cbddCompleted.Location = new System.Drawing.Point(178, 103);
            this.cbddCompleted.Name = "cbddCompleted";
            this.cbddCompleted.Size = new System.Drawing.Size(121, 21);
            this.cbddCompleted.TabIndex = 2;
            this.cbddCompleted.Visible = false;
            // 
            // cbddPriority
            // 
            this.cbddPriority.FormattingEnabled = true;
            this.cbddPriority.Items.AddRange(new object[] {
            "",
            "Routine",
            "Urgent"});
            this.cbddPriority.Location = new System.Drawing.Point(178, 76);
            this.cbddPriority.Name = "cbddPriority";
            this.cbddPriority.Size = new System.Drawing.Size(121, 21);
            this.cbddPriority.TabIndex = 1;
            // 
            // cbddRequest
            // 
            this.cbddRequest.FormattingEnabled = true;
            this.cbddRequest.Location = new System.Drawing.Point(178, 22);
            this.cbddRequest.Name = "cbddRequest";
            this.cbddRequest.Size = new System.Drawing.Size(121, 21);
            this.cbddRequest.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(226, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "USE SLIDER BAR TO VIEW ALL COLUMNS.";
            // 
            // bExport
            // 
            this.bExport.Location = new System.Drawing.Point(848, 54);
            this.bExport.Name = "bExport";
            this.bExport.Size = new System.Drawing.Size(75, 50);
            this.bExport.TabIndex = 19;
            this.bExport.Text = "Export to Excel";
            this.bExport.UseVisualStyleBackColor = true;
            this.bExport.Click += new System.EventHandler(this.bExport_Click);
            // 
            // ViewToolRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(960, 708);
            this.Controls.Add(this.bExport);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LrecordCount);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.pFilters);
            this.Name = "ViewToolRequests";
            this.Text = "View Tool Requests";
            this.Load += new System.EventHandler(this.ViewToolRequests_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.pFilters.ResumeLayout(false);
            this.pFilters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LrecordCount;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Panel pFilters;
        private System.Windows.Forms.Label Lsite;
        private System.Windows.Forms.ComboBox cbddSite;
        private System.Windows.Forms.Button bFilter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbddRequestedBy;
        private System.Windows.Forms.ComboBox cbddOwner;
        private System.Windows.Forms.ComboBox cbddCostCenter;
        private System.Windows.Forms.ComboBox cbddCompleted;
        private System.Windows.Forms.ComboBox cbddPriority;
        private System.Windows.Forms.ComboBox cbddRequest;
        private System.Windows.Forms.Label Lstatus;
        private System.Windows.Forms.ComboBox cbddStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bExport;
    }
}

