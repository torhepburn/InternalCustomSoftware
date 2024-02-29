
namespace R_T_V
{
    partial class RTView
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
            this.DGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bFilter = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cbddDepartment = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbddRequestedBy = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbddDesigner = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbddPart = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbddProject = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbddPriority = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbddStatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbddRequest = new System.Windows.Forms.ComboBox();
            this.LrecordCount = new System.Windows.Forms.Label();
            this.bExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGV
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(14, 348);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(1374, 376);
            this.DGV.TabIndex = 0;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 316);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "USE SLIDER BAR TO VIEW ALL COLUMNS.";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.panel1.Controls.Add(this.bFilter);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cbddDepartment);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cbddRequestedBy);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cbddDesigner);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cbddPart);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbddProject);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbddPriority);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbddStatus);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbddRequest);
            this.panel1.Location = new System.Drawing.Point(321, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 300);
            this.panel1.TabIndex = 2;
            // 
            // bFilter
            // 
            this.bFilter.Location = new System.Drawing.Point(409, 21);
            this.bFilter.Name = "bFilter";
            this.bFilter.Size = new System.Drawing.Size(100, 42);
            this.bFilter.TabIndex = 3;
            this.bFilter.Text = "FILTER";
            this.bFilter.UseVisualStyleBackColor = true;
            this.bFilter.Click += new System.EventHandler(this.bFilter_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(77, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 15);
            this.label8.TabIndex = 17;
            this.label8.Text = "DEPARTMENT";
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
            "WorkCell",
            "QC",
            "ASSEMBLY",
            "ENGINEERING",
            "SmallOptics",
            "Other"});
            this.cbddDepartment.Location = new System.Drawing.Point(210, 229);
            this.cbddDepartment.Name = "cbddDepartment";
            this.cbddDepartment.Size = new System.Drawing.Size(140, 23);
            this.cbddDepartment.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(77, 203);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "REQUESTED BY";
            // 
            // cbddRequestedBy
            // 
            this.cbddRequestedBy.FormattingEnabled = true;
            this.cbddRequestedBy.Location = new System.Drawing.Point(210, 200);
            this.cbddRequestedBy.Name = "cbddRequestedBy";
            this.cbddRequestedBy.Size = new System.Drawing.Size(140, 23);
            this.cbddRequestedBy.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(77, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "DESIGNER";
            // 
            // cbddDesigner
            // 
            this.cbddDesigner.FormattingEnabled = true;
            this.cbddDesigner.Location = new System.Drawing.Point(210, 171);
            this.cbddDesigner.Name = "cbddDesigner";
            this.cbddDesigner.Size = new System.Drawing.Size(140, 23);
            this.cbddDesigner.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(77, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "PART";
            // 
            // cbddPart
            // 
            this.cbddPart.FormattingEnabled = true;
            this.cbddPart.Location = new System.Drawing.Point(210, 142);
            this.cbddPart.Name = "cbddPart";
            this.cbddPart.Size = new System.Drawing.Size(140, 23);
            this.cbddPart.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(77, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "PROJECT";
            // 
            // cbddProject
            // 
            this.cbddProject.FormattingEnabled = true;
            this.cbddProject.Location = new System.Drawing.Point(210, 113);
            this.cbddProject.Name = "cbddProject";
            this.cbddProject.Size = new System.Drawing.Size(140, 23);
            this.cbddProject.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "PRIORITY";
            // 
            // cbddPriority
            // 
            this.cbddPriority.FormattingEnabled = true;
            this.cbddPriority.Items.AddRange(new object[] {
            "",
            "Routine",
            "Urgent",
            "Production down"});
            this.cbddPriority.Location = new System.Drawing.Point(210, 84);
            this.cbddPriority.Name = "cbddPriority";
            this.cbddPriority.Size = new System.Drawing.Size(140, 23);
            this.cbddPriority.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "STATUS";
            // 
            // cbddStatus
            // 
            this.cbddStatus.FormattingEnabled = true;
            this.cbddStatus.Items.AddRange(new object[] {
            "",
            "Completed",
            "On Hold",
            "Design Review",
            "In Prog - Design",
            "In Prog - Fab"});
            this.cbddStatus.Location = new System.Drawing.Point(210, 55);
            this.cbddStatus.Name = "cbddStatus";
            this.cbddStatus.Size = new System.Drawing.Size(140, 23);
            this.cbddStatus.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "REQUEST ID";
            // 
            // cbddRequest
            // 
            this.cbddRequest.FormattingEnabled = true;
            this.cbddRequest.Location = new System.Drawing.Point(210, 26);
            this.cbddRequest.Name = "cbddRequest";
            this.cbddRequest.Size = new System.Drawing.Size(140, 23);
            this.cbddRequest.TabIndex = 0;
            // 
            // LrecordCount
            // 
            this.LrecordCount.AutoSize = true;
            this.LrecordCount.Location = new System.Drawing.Point(890, 316);
            this.LrecordCount.Name = "LrecordCount";
            this.LrecordCount.Size = new System.Drawing.Size(111, 15);
            this.LrecordCount.TabIndex = 3;
            this.LrecordCount.Text = "RECORD COUNT: ";
            // 
            // bExport
            // 
            this.bExport.Location = new System.Drawing.Point(995, 68);
            this.bExport.Name = "bExport";
            this.bExport.Size = new System.Drawing.Size(87, 81);
            this.bExport.TabIndex = 19;
            this.bExport.Text = "Export to Excel";
            this.bExport.UseVisualStyleBackColor = true;
            this.bExport.Click += new System.EventHandler(this.bExport_Click);
            // 
            // RTView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(1402, 786);
            this.Controls.Add(this.bExport);
            this.Controls.Add(this.LrecordCount);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGV);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.Name = "RTView";
            this.Text = "RTView";
            this.Load += new System.EventHandler(this.RTView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbddRequest;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbddDesigner;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbddPart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbddProject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbddPriority;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbddStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbddDepartment;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbddRequestedBy;
        private System.Windows.Forms.Button bFilter;
        private System.Windows.Forms.Label LrecordCount;
        private System.Windows.Forms.Button bExport;
    }
}