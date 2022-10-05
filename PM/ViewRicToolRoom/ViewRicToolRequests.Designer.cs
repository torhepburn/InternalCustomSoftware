namespace ViewRicToolRoom
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
            this.cbddDepartment = new System.Windows.Forms.ComboBox();
            this.bFilter = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbddRequestedBy = new System.Windows.Forms.ComboBox();
            this.cbddCustomer = new System.Windows.Forms.ComboBox();
            this.cbddPart = new System.Windows.Forms.ComboBox();
            this.cbddProject = new System.Windows.Forms.ComboBox();
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
            this.LrecordCount.Location = new System.Drawing.Point(872, 325);
            this.LrecordCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LrecordCount.Name = "LrecordCount";
            this.LrecordCount.Size = new System.Drawing.Size(98, 15);
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
            this.DGV.Location = new System.Drawing.Point(14, 347);
            this.DGV.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(1092, 425);
            this.DGV.TabIndex = 10;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // pFilters
            // 
            this.pFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.pFilters.Controls.Add(this.Lstatus);
            this.pFilters.Controls.Add(this.cbddStatus);
            this.pFilters.Controls.Add(this.Lsite);
            this.pFilters.Controls.Add(this.cbddDepartment);
            this.pFilters.Controls.Add(this.bFilter);
            this.pFilters.Controls.Add(this.label7);
            this.pFilters.Controls.Add(this.label5);
            this.pFilters.Controls.Add(this.label4);
            this.pFilters.Controls.Add(this.label3);
            this.pFilters.Controls.Add(this.label2);
            this.pFilters.Controls.Add(this.label1);
            this.pFilters.Controls.Add(this.cbddRequestedBy);
            this.pFilters.Controls.Add(this.cbddCustomer);
            this.pFilters.Controls.Add(this.cbddPart);
            this.pFilters.Controls.Add(this.cbddProject);
            this.pFilters.Controls.Add(this.cbddPriority);
            this.pFilters.Controls.Add(this.cbddRequest);
            this.pFilters.Location = new System.Drawing.Point(281, 45);
            this.pFilters.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pFilters.Name = "pFilters";
            this.pFilters.Size = new System.Drawing.Size(554, 295);
            this.pFilters.TabIndex = 9;
            // 
            // Lstatus
            // 
            this.Lstatus.AutoSize = true;
            this.Lstatus.Location = new System.Drawing.Point(75, 60);
            this.Lstatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lstatus.Name = "Lstatus";
            this.Lstatus.Size = new System.Drawing.Size(45, 15);
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
            this.cbddStatus.Location = new System.Drawing.Point(208, 57);
            this.cbddStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbddStatus.Name = "cbddStatus";
            this.cbddStatus.Size = new System.Drawing.Size(140, 23);
            this.cbddStatus.TabIndex = 17;
            // 
            // Lsite
            // 
            this.Lsite.AutoSize = true;
            this.Lsite.Location = new System.Drawing.Point(75, 247);
            this.Lsite.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lsite.Name = "Lsite";
            this.Lsite.Size = new System.Drawing.Size(79, 15);
            this.Lsite.TabIndex = 16;
            this.Lsite.Text = "DEPARTMENT";
            // 
            // cbddDepartment
            // 
            this.cbddDepartment.FormattingEnabled = true;
            this.cbddDepartment.Items.AddRange(new object[] {
            "",
            "CCOS",
            "IBF",
            "METROLOGY",
            "CNC",
            "Work Cell",
            "QC",
            "ASSEMBLY",
            "ENGINEERING",
            "SMALL OPTICS",
            "Other"});
            this.cbddDepartment.Location = new System.Drawing.Point(208, 243);
            this.cbddDepartment.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbddDepartment.Name = "cbddDepartment";
            this.cbddDepartment.Size = new System.Drawing.Size(140, 23);
            this.cbddDepartment.TabIndex = 15;
            // 
            // bFilter
            // 
            this.bFilter.Location = new System.Drawing.Point(427, 17);
            this.bFilter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bFilter.Name = "bFilter";
            this.bFilter.Size = new System.Drawing.Size(88, 27);
            this.bFilter.TabIndex = 14;
            this.bFilter.Text = "FILTER";
            this.bFilter.UseVisualStyleBackColor = true;
            this.bFilter.Click += new System.EventHandler(this.bFilter_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(75, 216);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "REQUESTED BY";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 185);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "CUSTOMER";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 153);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "PART";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 122);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "PROJECT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "PRIORITY";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "REQUEST ID";
            // 
            // cbddRequestedBy
            // 
            this.cbddRequestedBy.FormattingEnabled = true;
            this.cbddRequestedBy.Location = new System.Drawing.Point(208, 212);
            this.cbddRequestedBy.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbddRequestedBy.Name = "cbddRequestedBy";
            this.cbddRequestedBy.Size = new System.Drawing.Size(140, 23);
            this.cbddRequestedBy.TabIndex = 6;
            // 
            // cbddCustomer
            // 
            this.cbddCustomer.FormattingEnabled = true;
            this.cbddCustomer.Location = new System.Drawing.Point(208, 181);
            this.cbddCustomer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbddCustomer.Name = "cbddCustomer";
            this.cbddCustomer.Size = new System.Drawing.Size(140, 23);
            this.cbddCustomer.TabIndex = 4;
            // 
            // cbddPart
            // 
            this.cbddPart.FormattingEnabled = true;
            this.cbddPart.Location = new System.Drawing.Point(208, 150);
            this.cbddPart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbddPart.Name = "cbddPart";
            this.cbddPart.Size = new System.Drawing.Size(140, 23);
            this.cbddPart.TabIndex = 3;
            // 
            // cbddProject
            // 
            this.cbddProject.AutoCompleteCustomSource.AddRange(new string[] {
            "",
            "0,",
            "1"});
            this.cbddProject.FormattingEnabled = true;
            this.cbddProject.Items.AddRange(new object[] {
            "",
            "0,",
            "1"});
            this.cbddProject.Location = new System.Drawing.Point(208, 119);
            this.cbddProject.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbddProject.Name = "cbddProject";
            this.cbddProject.Size = new System.Drawing.Size(140, 23);
            this.cbddProject.TabIndex = 2;
            // 
            // cbddPriority
            // 
            this.cbddPriority.FormattingEnabled = true;
            this.cbddPriority.Items.AddRange(new object[] {
            "",
            "Routine",
            "Urgent"});
            this.cbddPriority.Location = new System.Drawing.Point(208, 88);
            this.cbddPriority.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbddPriority.Name = "cbddPriority";
            this.cbddPriority.Size = new System.Drawing.Size(140, 23);
            this.cbddPriority.TabIndex = 1;
            // 
            // cbddRequest
            // 
            this.cbddRequest.FormattingEnabled = true;
            this.cbddRequest.Location = new System.Drawing.Point(208, 25);
            this.cbddRequest.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbddRequest.Name = "cbddRequest";
            this.cbddRequest.Size = new System.Drawing.Size(140, 23);
            this.cbddRequest.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 325);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(224, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "USE SLIDER BAR TO VIEW ALL COLUMNS.";
            // 
            // bExport
            // 
            this.bExport.Location = new System.Drawing.Point(989, 62);
            this.bExport.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bExport.Name = "bExport";
            this.bExport.Size = new System.Drawing.Size(88, 58);
            this.bExport.TabIndex = 19;
            this.bExport.Text = "Export to Excel";
            this.bExport.UseVisualStyleBackColor = true;
            this.bExport.Click += new System.EventHandler(this.bExport_Click);
            // 
            // ViewToolRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(1120, 817);
            this.Controls.Add(this.bExport);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LrecordCount);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.pFilters);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ViewToolRequests";
            this.Text = "View Richmond Tool Requests";
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
        private System.Windows.Forms.ComboBox cbddDepartment;
        private System.Windows.Forms.Button bFilter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbddRequestedBy;
        private System.Windows.Forms.ComboBox cbddCustomer;
        private System.Windows.Forms.ComboBox cbddPart;
        private System.Windows.Forms.ComboBox cbddProject;
        private System.Windows.Forms.ComboBox cbddPriority;
        private System.Windows.Forms.ComboBox cbddRequest;
        private System.Windows.Forms.Label Lstatus;
        private System.Windows.Forms.ComboBox cbddStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bExport;
    }
}

