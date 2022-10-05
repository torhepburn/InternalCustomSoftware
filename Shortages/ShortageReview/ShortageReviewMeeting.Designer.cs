namespace ShortageReview
{
    partial class ShortageReviewMeeting
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bRefresh = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.DGV_History = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bArchive = new System.Windows.Forms.Button();
            this.Lgroup = new System.Windows.Forms.Label();
            this.LitemNumber = new System.Windows.Forms.Label();
            this.Lstatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbComments = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbReqDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbActionRqd = new System.Windows.Forms.CheckBox();
            this.DGV_ShortageItem = new System.Windows.Forms.DataGridView();
            this.cbHot = new System.Windows.Forms.CheckBox();
            this.Bprevious = new System.Windows.Forms.Button();
            this.cbddGroup = new System.Windows.Forms.ComboBox();
            this.DGV_TRACK_WH = new System.Windows.Forms.DataGridView();
            this.DGV_TRACK_QC = new System.Windows.Forms.DataGridView();
            this.DGV_PROD = new System.Windows.Forms.DataGridView();
            this.DGV_RECEIPTS = new System.Windows.Forms.DataGridView();
            this.tbCurrDueDate = new System.Windows.Forms.TextBox();
            this.Bnext = new System.Windows.Forms.Button();
            this.DGV_PURCH = new System.Windows.Forms.DataGridView();
            this.DGV_PLANNEDST = new System.Windows.Forms.DataGridView();
            this.DGV_ItemData = new System.Windows.Forms.DataGridView();
            this.bTrackingDetails = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_History)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ShortageItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_TRACK_WH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_TRACK_QC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_PROD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_RECEIPTS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_PURCH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_PLANNEDST)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ItemData)).BeginInit();
            this.SuspendLayout();
            // 
            // bRefresh
            // 
            this.bRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(120)))), ((int)(((byte)(192)))));
            this.bRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.bRefresh.Location = new System.Drawing.Point(808, 77);
            this.bRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.bRefresh.Name = "bRefresh";
            this.bRefresh.Size = new System.Drawing.Size(164, 51);
            this.bRefresh.TabIndex = 196;
            this.bRefresh.Text = "Refresh Shortage List";
            this.bRefresh.UseVisualStyleBackColor = false;
            this.bRefresh.Click += new System.EventHandler(this.bRefresh_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(676, 241);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(255, 9);
            this.label12.TabIndex = 195;
            this.label12.Text = "CURRENT CONFIRMED DUE DATE CHANGE HISTORY:";
            // 
            // DGV_History
            // 
            this.DGV_History.AllowUserToAddRows = false;
            this.DGV_History.AllowUserToDeleteRows = false;
            this.DGV_History.AllowUserToResizeColumns = false;
            this.DGV_History.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DGV_History.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_History.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_History.ColumnHeadersHeight = 30;
            this.DGV_History.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_History.Cursor = System.Windows.Forms.Cursors.Default;
            this.DGV_History.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGV_History.Location = new System.Drawing.Point(678, 252);
            this.DGV_History.Margin = new System.Windows.Forms.Padding(2);
            this.DGV_History.Name = "DGV_History";
            this.DGV_History.RowHeadersVisible = false;
            this.DGV_History.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_History.Size = new System.Drawing.Size(294, 122);
            this.DGV_History.TabIndex = 194;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(498, 594);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(308, 9);
            this.label11.TabIndex = 193;
            this.label11.Text = "TRACKER INFO (MOVED OUT TO A WAREHOUSE IN LAST 7 DAYS)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(11, 594);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(293, 9);
            this.label10.TabIndex = 192;
            this.label10.Text = "TRACKER INFO (MOVED OUT BY QC OPERATOR LAST 7 DAYS)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(498, 500);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(149, 9);
            this.label9.TabIndex = 191;
            this.label9.Text = "PRODUCTION ORDERS (OPEN)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 500);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 9);
            this.label8.TabIndex = 190;
            this.label8.Text = "RECEIPTS (AWAITING QC)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 380);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 9);
            this.label7.TabIndex = 189;
            this.label7.Text = "PURCHASE ORDERS (OPEN)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 9);
            this.label6.TabIndex = 188;
            this.label6.Text = "PLANNED STOCK TRANSACTIONS:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 9);
            this.label5.TabIndex = 187;
            this.label5.Text = "ITEM MASTER DATA:";
            // 
            // bArchive
            // 
            this.bArchive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(158)))), ((int)(((byte)(192)))));
            this.bArchive.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.bArchive.Location = new System.Drawing.Point(11, 127);
            this.bArchive.Margin = new System.Windows.Forms.Padding(2);
            this.bArchive.Name = "bArchive";
            this.bArchive.Size = new System.Drawing.Size(60, 25);
            this.bArchive.TabIndex = 186;
            this.bArchive.Text = "Archive";
            this.bArchive.UseVisualStyleBackColor = false;
            this.bArchive.Click += new System.EventHandler(this.bArchive_Click);
            // 
            // Lgroup
            // 
            this.Lgroup.AutoSize = true;
            this.Lgroup.Location = new System.Drawing.Point(212, 119);
            this.Lgroup.Name = "Lgroup";
            this.Lgroup.Size = new System.Drawing.Size(0, 13);
            this.Lgroup.TabIndex = 185;
            this.Lgroup.Visible = false;
            // 
            // LitemNumber
            // 
            this.LitemNumber.AutoSize = true;
            this.LitemNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.LitemNumber.Location = new System.Drawing.Point(80, 72);
            this.LitemNumber.Name = "LitemNumber";
            this.LitemNumber.Size = new System.Drawing.Size(61, 13);
            this.LitemNumber.TabIndex = 184;
            this.LitemNumber.Text = "Number  of ";
            // 
            // Lstatus
            // 
            this.Lstatus.AutoSize = true;
            this.Lstatus.BackColor = System.Drawing.Color.Yellow;
            this.Lstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lstatus.Location = new System.Drawing.Point(145, 93);
            this.Lstatus.Name = "Lstatus";
            this.Lstatus.Size = new System.Drawing.Size(60, 13);
            this.Lstatus.TabIndex = 183;
            this.Lstatus.Text = "STATUS:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(442, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 182;
            this.label4.Text = "Comments";
            // 
            // tbComments
            // 
            this.tbComments.Location = new System.Drawing.Point(508, 74);
            this.tbComments.Margin = new System.Windows.Forms.Padding(2);
            this.tbComments.Multiline = true;
            this.tbComments.Name = "tbComments";
            this.tbComments.Size = new System.Drawing.Size(277, 85);
            this.tbComments.TabIndex = 181;
            this.tbComments.Enter += new System.EventHandler(this.tbComments_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(339, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 180;
            this.label3.Text = "Required Date";
            // 
            // tbReqDate
            // 
            this.tbReqDate.Location = new System.Drawing.Point(350, 137);
            this.tbReqDate.Margin = new System.Windows.Forms.Padding(2);
            this.tbReqDate.Name = "tbReqDate";
            this.tbReqDate.Size = new System.Drawing.Size(65, 20);
            this.tbReqDate.TabIndex = 179;
            this.tbReqDate.Enter += new System.EventHandler(this.tbReqDate_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(325, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 178;
            this.label2.Text = "Confirmed Due Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 177;
            this.label1.Text = "Edit Group";
            // 
            // cbActionRqd
            // 
            this.cbActionRqd.AutoSize = true;
            this.cbActionRqd.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbActionRqd.ForeColor = System.Drawing.Color.Black;
            this.cbActionRqd.Location = new System.Drawing.Point(91, 135);
            this.cbActionRqd.Name = "cbActionRqd";
            this.cbActionRqd.Size = new System.Drawing.Size(61, 14);
            this.cbActionRqd.TabIndex = 176;
            this.cbActionRqd.Text = "Action Rqd";
            this.cbActionRqd.UseVisualStyleBackColor = true;
            this.cbActionRqd.Click += new System.EventHandler(this.cbActionRqd_Click);
            // 
            // DGV_ShortageItem
            // 
            this.DGV_ShortageItem.AllowUserToAddRows = false;
            this.DGV_ShortageItem.AllowUserToDeleteRows = false;
            this.DGV_ShortageItem.AllowUserToResizeColumns = false;
            this.DGV_ShortageItem.AllowUserToResizeRows = false;
            this.DGV_ShortageItem.ColumnHeadersHeight = 30;
            this.DGV_ShortageItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_ShortageItem.Cursor = System.Windows.Forms.Cursors.Default;
            this.DGV_ShortageItem.Location = new System.Drawing.Point(10, 7);
            this.DGV_ShortageItem.Margin = new System.Windows.Forms.Padding(1);
            this.DGV_ShortageItem.MultiSelect = false;
            this.DGV_ShortageItem.Name = "DGV_ShortageItem";
            this.DGV_ShortageItem.ReadOnly = true;
            this.DGV_ShortageItem.RowHeadersVisible = false;
            this.DGV_ShortageItem.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DGV_ShortageItem.Size = new System.Drawing.Size(965, 55);
            this.DGV_ShortageItem.TabIndex = 175;
            // 
            // cbHot
            // 
            this.cbHot.AutoSize = true;
            this.cbHot.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHot.ForeColor = System.Drawing.Color.Red;
            this.cbHot.Location = new System.Drawing.Point(91, 110);
            this.cbHot.Name = "cbHot";
            this.cbHot.Size = new System.Drawing.Size(44, 14);
            this.cbHot.TabIndex = 174;
            this.cbHot.Text = "HOT";
            this.cbHot.UseVisualStyleBackColor = true;
            this.cbHot.Click += new System.EventHandler(this.cbHot_Click);
            // 
            // Bprevious
            // 
            this.Bprevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(120)))), ((int)(((byte)(50)))));
            this.Bprevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.Bprevious.Location = new System.Drawing.Point(11, 95);
            this.Bprevious.Margin = new System.Windows.Forms.Padding(2);
            this.Bprevious.Name = "Bprevious";
            this.Bprevious.Size = new System.Drawing.Size(60, 25);
            this.Bprevious.TabIndex = 173;
            this.Bprevious.Text = "Previous";
            this.Bprevious.UseVisualStyleBackColor = false;
            this.Bprevious.Click += new System.EventHandler(this.Bprevious_Click);
            // 
            // cbddGroup
            // 
            this.cbddGroup.FormattingEnabled = true;
            this.cbddGroup.Location = new System.Drawing.Point(234, 137);
            this.cbddGroup.Name = "cbddGroup";
            this.cbddGroup.Size = new System.Drawing.Size(72, 21);
            this.cbddGroup.TabIndex = 172;
            this.cbddGroup.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbddGroup_MouseClick);
            // 
            // DGV_TRACK_WH
            // 
            this.DGV_TRACK_WH.AllowUserToAddRows = false;
            this.DGV_TRACK_WH.AllowUserToDeleteRows = false;
            this.DGV_TRACK_WH.AllowUserToResizeColumns = false;
            this.DGV_TRACK_WH.AllowUserToResizeRows = false;
            this.DGV_TRACK_WH.ColumnHeadersHeight = 30;
            this.DGV_TRACK_WH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_TRACK_WH.Cursor = System.Windows.Forms.Cursors.Default;
            this.DGV_TRACK_WH.Location = new System.Drawing.Point(500, 605);
            this.DGV_TRACK_WH.Margin = new System.Windows.Forms.Padding(2);
            this.DGV_TRACK_WH.Name = "DGV_TRACK_WH";
            this.DGV_TRACK_WH.RowHeadersVisible = false;
            this.DGV_TRACK_WH.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_TRACK_WH.Size = new System.Drawing.Size(375, 70);
            this.DGV_TRACK_WH.TabIndex = 171;
            // 
            // DGV_TRACK_QC
            // 
            this.DGV_TRACK_QC.AllowUserToAddRows = false;
            this.DGV_TRACK_QC.AllowUserToDeleteRows = false;
            this.DGV_TRACK_QC.AllowUserToResizeColumns = false;
            this.DGV_TRACK_QC.AllowUserToResizeRows = false;
            this.DGV_TRACK_QC.ColumnHeadersHeight = 30;
            this.DGV_TRACK_QC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_TRACK_QC.Cursor = System.Windows.Forms.Cursors.Default;
            this.DGV_TRACK_QC.Location = new System.Drawing.Point(10, 605);
            this.DGV_TRACK_QC.Margin = new System.Windows.Forms.Padding(2);
            this.DGV_TRACK_QC.Name = "DGV_TRACK_QC";
            this.DGV_TRACK_QC.RowHeadersVisible = false;
            this.DGV_TRACK_QC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_TRACK_QC.Size = new System.Drawing.Size(475, 70);
            this.DGV_TRACK_QC.TabIndex = 170;
            // 
            // DGV_PROD
            // 
            this.DGV_PROD.AllowUserToAddRows = false;
            this.DGV_PROD.AllowUserToDeleteRows = false;
            this.DGV_PROD.AllowUserToResizeColumns = false;
            this.DGV_PROD.AllowUserToResizeRows = false;
            this.DGV_PROD.ColumnHeadersHeight = 30;
            this.DGV_PROD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_PROD.Cursor = System.Windows.Forms.Cursors.Default;
            this.DGV_PROD.Location = new System.Drawing.Point(500, 511);
            this.DGV_PROD.Margin = new System.Windows.Forms.Padding(2);
            this.DGV_PROD.Name = "DGV_PROD";
            this.DGV_PROD.RowHeadersVisible = false;
            this.DGV_PROD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_PROD.Size = new System.Drawing.Size(475, 75);
            this.DGV_PROD.TabIndex = 169;
            // 
            // DGV_RECEIPTS
            // 
            this.DGV_RECEIPTS.AllowUserToAddRows = false;
            this.DGV_RECEIPTS.AllowUserToDeleteRows = false;
            this.DGV_RECEIPTS.AllowUserToResizeColumns = false;
            this.DGV_RECEIPTS.AllowUserToResizeRows = false;
            this.DGV_RECEIPTS.ColumnHeadersHeight = 30;
            this.DGV_RECEIPTS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_RECEIPTS.Cursor = System.Windows.Forms.Cursors.Default;
            this.DGV_RECEIPTS.Location = new System.Drawing.Point(10, 511);
            this.DGV_RECEIPTS.Margin = new System.Windows.Forms.Padding(2);
            this.DGV_RECEIPTS.Name = "DGV_RECEIPTS";
            this.DGV_RECEIPTS.RowHeadersVisible = false;
            this.DGV_RECEIPTS.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_RECEIPTS.Size = new System.Drawing.Size(475, 75);
            this.DGV_RECEIPTS.TabIndex = 168;
            // 
            // tbCurrDueDate
            // 
            this.tbCurrDueDate.Location = new System.Drawing.Point(350, 91);
            this.tbCurrDueDate.Margin = new System.Windows.Forms.Padding(2);
            this.tbCurrDueDate.Name = "tbCurrDueDate";
            this.tbCurrDueDate.Size = new System.Drawing.Size(65, 20);
            this.tbCurrDueDate.TabIndex = 167;
            this.tbCurrDueDate.Enter += new System.EventHandler(this.tbCurrDueDate_Enter);
            // 
            // Bnext
            // 
            this.Bnext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(128)))), ((int)(((byte)(192)))));
            this.Bnext.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.Bnext.Location = new System.Drawing.Point(11, 66);
            this.Bnext.Margin = new System.Windows.Forms.Padding(2);
            this.Bnext.Name = "Bnext";
            this.Bnext.Size = new System.Drawing.Size(60, 25);
            this.Bnext.TabIndex = 166;
            this.Bnext.Text = "NEXT";
            this.Bnext.UseVisualStyleBackColor = false;
            this.Bnext.Click += new System.EventHandler(this.Bnext_Click);
            // 
            // DGV_PURCH
            // 
            this.DGV_PURCH.AllowUserToAddRows = false;
            this.DGV_PURCH.AllowUserToDeleteRows = false;
            this.DGV_PURCH.AllowUserToResizeColumns = false;
            this.DGV_PURCH.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.DGV_PURCH.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_PURCH.ColumnHeadersHeight = 30;
            this.DGV_PURCH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_PURCH.Cursor = System.Windows.Forms.Cursors.Default;
            this.DGV_PURCH.Location = new System.Drawing.Point(10, 391);
            this.DGV_PURCH.Margin = new System.Windows.Forms.Padding(2);
            this.DGV_PURCH.Name = "DGV_PURCH";
            this.DGV_PURCH.RowHeadersVisible = false;
            this.DGV_PURCH.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_PURCH.Size = new System.Drawing.Size(962, 100);
            this.DGV_PURCH.TabIndex = 165;
            // 
            // DGV_PLANNEDST
            // 
            this.DGV_PLANNEDST.AllowUserToAddRows = false;
            this.DGV_PLANNEDST.AllowUserToDeleteRows = false;
            this.DGV_PLANNEDST.AllowUserToResizeColumns = false;
            this.DGV_PLANNEDST.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DGV_PLANNEDST.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_PLANNEDST.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DGV_PLANNEDST.ColumnHeadersHeight = 30;
            this.DGV_PLANNEDST.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_PLANNEDST.Cursor = System.Windows.Forms.Cursors.Default;
            this.DGV_PLANNEDST.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGV_PLANNEDST.Location = new System.Drawing.Point(10, 252);
            this.DGV_PLANNEDST.Margin = new System.Windows.Forms.Padding(2);
            this.DGV_PLANNEDST.Name = "DGV_PLANNEDST";
            this.DGV_PLANNEDST.RowHeadersVisible = false;
            this.DGV_PLANNEDST.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_PLANNEDST.Size = new System.Drawing.Size(600, 122);
            this.DGV_PLANNEDST.TabIndex = 164;
            // 
            // DGV_ItemData
            // 
            this.DGV_ItemData.AllowUserToAddRows = false;
            this.DGV_ItemData.AllowUserToDeleteRows = false;
            this.DGV_ItemData.AllowUserToResizeColumns = false;
            this.DGV_ItemData.AllowUserToResizeRows = false;
            this.DGV_ItemData.ColumnHeadersHeight = 30;
            this.DGV_ItemData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_ItemData.Cursor = System.Windows.Forms.Cursors.No;
            this.DGV_ItemData.Enabled = false;
            this.DGV_ItemData.Location = new System.Drawing.Point(10, 172);
            this.DGV_ItemData.Margin = new System.Windows.Forms.Padding(2);
            this.DGV_ItemData.Name = "DGV_ItemData";
            this.DGV_ItemData.ReadOnly = true;
            this.DGV_ItemData.RowHeadersVisible = false;
            this.DGV_ItemData.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DGV_ItemData.Size = new System.Drawing.Size(900, 60);
            this.DGV_ItemData.TabIndex = 163;
            // 
            // bTrackingDetails
            // 
            this.bTrackingDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(200)))), ((int)(((byte)(120)))));
            this.bTrackingDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.bTrackingDetails.Location = new System.Drawing.Point(889, 605);
            this.bTrackingDetails.Margin = new System.Windows.Forms.Padding(2);
            this.bTrackingDetails.Name = "bTrackingDetails";
            this.bTrackingDetails.Size = new System.Drawing.Size(84, 70);
            this.bTrackingDetails.TabIndex = 197;
            this.bTrackingDetails.Text = "Tracking Details";
            this.bTrackingDetails.UseVisualStyleBackColor = false;
            this.bTrackingDetails.Click += new System.EventHandler(this.bTrackingDetails_Click);
            // 
            // ShortageReviewMeeting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 687);
            this.Controls.Add(this.bTrackingDetails);
            this.Controls.Add(this.bRefresh);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.DGV_History);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bArchive);
            this.Controls.Add(this.Lgroup);
            this.Controls.Add(this.LitemNumber);
            this.Controls.Add(this.Lstatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbComments);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbReqDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbActionRqd);
            this.Controls.Add(this.DGV_ShortageItem);
            this.Controls.Add(this.cbHot);
            this.Controls.Add(this.Bprevious);
            this.Controls.Add(this.cbddGroup);
            this.Controls.Add(this.DGV_TRACK_WH);
            this.Controls.Add(this.DGV_TRACK_QC);
            this.Controls.Add(this.DGV_PROD);
            this.Controls.Add(this.DGV_RECEIPTS);
            this.Controls.Add(this.tbCurrDueDate);
            this.Controls.Add(this.Bnext);
            this.Controls.Add(this.DGV_PURCH);
            this.Controls.Add(this.DGV_PLANNEDST);
            this.Controls.Add(this.DGV_ItemData);
            this.Name = "ShortageReviewMeeting";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ShortageReviewMeeting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_History)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ShortageItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_TRACK_WH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_TRACK_QC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_PROD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_RECEIPTS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_PURCH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_PLANNEDST)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ItemData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bRefresh;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView DGV_History;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bArchive;
        private System.Windows.Forms.Label Lgroup;
        private System.Windows.Forms.Label LitemNumber;
        private System.Windows.Forms.Label Lstatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbComments;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbReqDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbActionRqd;
        private System.Windows.Forms.DataGridView DGV_ShortageItem;
        private System.Windows.Forms.CheckBox cbHot;
        private System.Windows.Forms.Button Bprevious;
        private System.Windows.Forms.ComboBox cbddGroup;
        private System.Windows.Forms.DataGridView DGV_TRACK_WH;
        private System.Windows.Forms.DataGridView DGV_TRACK_QC;
        private System.Windows.Forms.DataGridView DGV_PROD;
        private System.Windows.Forms.DataGridView DGV_RECEIPTS;
        private System.Windows.Forms.TextBox tbCurrDueDate;
        private System.Windows.Forms.Button Bnext;
        private System.Windows.Forms.DataGridView DGV_PURCH;
        private System.Windows.Forms.DataGridView DGV_PLANNEDST;
        private System.Windows.Forms.DataGridView DGV_ItemData;
        private System.Windows.Forms.Button bTrackingDetails;
    }
}

