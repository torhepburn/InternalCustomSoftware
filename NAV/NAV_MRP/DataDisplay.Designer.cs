namespace NAV_MRP
{
    partial class DataDisplay
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
            this.DGV_TRACK_QC = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.LorigDue = new System.Windows.Forms.Label();
            this.dtpOrigDue = new System.Windows.Forms.DateTimePicker();
            this.Lpo = new System.Windows.Forms.Label();
            this.cbddPO = new System.Windows.Forms.ComboBox();
            this.Lsuppliers = new System.Windows.Forms.Label();
            this.cbddSupplier = new System.Windows.Forms.ComboBox();
            this.Lbuyer = new System.Windows.Forms.Label();
            this.cbddComments = new System.Windows.Forms.ComboBox();
            this.cbddPlannerBuyer = new System.Windows.Forms.ComboBox();
            this.dtpCurrDueDate = new System.Windows.Forms.DateTimePicker();
            this.dtpRequiredDate = new System.Windows.Forms.DateTimePicker();
            this.LeditGroup = new System.Windows.Forms.Label();
            this.cbddGroup = new System.Windows.Forms.ComboBox();
            this.DGV_Comments = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.cbReceived = new System.Windows.Forms.CheckBox();
            this.LrequiredDate = new System.Windows.Forms.Label();
            this.LconfirmedDueDate = new System.Windows.Forms.Label();
            this.bRefresh = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.TLP = new System.Windows.Forms.TableLayoutPanel();
            this.DGV_ShortageItem = new System.Windows.Forms.DataGridView();
            this.TLP2 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.DGV_ItemData = new System.Windows.Forms.DataGridView();
            this.DGV_PLANNEDST = new System.Windows.Forms.DataGridView();
            this.DGV_History = new System.Windows.Forms.DataGridView();
            this.DGV_PURCH = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bArchive = new System.Windows.Forms.Button();
            this.LitemNumber = new System.Windows.Forms.Label();
            this.Bnext = new System.Windows.Forms.Button();
            this.Bprevious = new System.Windows.Forms.Button();
            this.Lquantity = new System.Windows.Forms.Label();
            this.TLP3 = new System.Windows.Forms.TableLayoutPanel();
            this.DGV_RECEIPTS = new System.Windows.Forms.DataGridView();
            this.DGV_PROD = new System.Windows.Forms.DataGridView();
            this.bTrackingDetails = new System.Windows.Forms.Button();
            this.DGV_TRACK_WH = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.cbActionRqd = new System.Windows.Forms.CheckBox();
            this.cbHot = new System.Windows.Forms.CheckBox();
            this.Lstatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_TRACK_QC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Comments)).BeginInit();
            this.TLP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ShortageItem)).BeginInit();
            this.TLP2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ItemData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_PLANNEDST)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_History)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_PURCH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.TLP3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_RECEIPTS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_PROD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_TRACK_WH)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_TRACK_QC
            // 
            this.DGV_TRACK_QC.AllowUserToAddRows = false;
            this.DGV_TRACK_QC.AllowUserToDeleteRows = false;
            this.DGV_TRACK_QC.AllowUserToResizeColumns = false;
            this.DGV_TRACK_QC.AllowUserToResizeRows = false;
            this.DGV_TRACK_QC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_TRACK_QC.ColumnHeadersHeight = 30;
            this.DGV_TRACK_QC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_TRACK_QC.Cursor = System.Windows.Forms.Cursors.Default;
            this.DGV_TRACK_QC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_TRACK_QC.Location = new System.Drawing.Point(2, 116);
            this.DGV_TRACK_QC.Margin = new System.Windows.Forms.Padding(2);
            this.DGV_TRACK_QC.Name = "DGV_TRACK_QC";
            this.DGV_TRACK_QC.RowHeadersVisible = false;
            this.DGV_TRACK_QC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_TRACK_QC.Size = new System.Drawing.Size(619, 71);
            this.DGV_TRACK_QC.TabIndex = 197;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 9);
            this.label8.TabIndex = 191;
            this.label8.Text = "RECEIPTS (AWAITING QC)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(641, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(149, 9);
            this.label9.TabIndex = 192;
            this.label9.Text = "PRODUCTION ORDERS (OPEN)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(641, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(293, 9);
            this.label10.TabIndex = 193;
            this.label10.Text = "TRACKER INFO (MOVED OUT BY QC OPERATOR LAST 7 DAYS)";
            // 
            // tbQuantity
            // 
            this.tbQuantity.Location = new System.Drawing.Point(869, 140);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(100, 20);
            this.tbQuantity.TabIndex = 253;
            this.tbQuantity.Visible = false;
            // 
            // LorigDue
            // 
            this.LorigDue.AutoSize = true;
            this.LorigDue.Location = new System.Drawing.Point(806, 116);
            this.LorigDue.Name = "LorigDue";
            this.LorigDue.Size = new System.Drawing.Size(52, 13);
            this.LorigDue.TabIndex = 251;
            this.LorigDue.Text = "Orig Due:";
            this.LorigDue.Visible = false;
            // 
            // dtpOrigDue
            // 
            this.dtpOrigDue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrigDue.Location = new System.Drawing.Point(869, 110);
            this.dtpOrigDue.Name = "dtpOrigDue";
            this.dtpOrigDue.Size = new System.Drawing.Size(104, 20);
            this.dtpOrigDue.TabIndex = 250;
            this.dtpOrigDue.Visible = false;
            // 
            // Lpo
            // 
            this.Lpo.AutoSize = true;
            this.Lpo.Location = new System.Drawing.Point(418, 145);
            this.Lpo.Name = "Lpo";
            this.Lpo.Size = new System.Drawing.Size(25, 13);
            this.Lpo.TabIndex = 249;
            this.Lpo.Text = "PO:";
            this.Lpo.Visible = false;
            // 
            // cbddPO
            // 
            this.cbddPO.FormattingEnabled = true;
            this.cbddPO.Location = new System.Drawing.Point(477, 140);
            this.cbddPO.Name = "cbddPO";
            this.cbddPO.Size = new System.Drawing.Size(121, 21);
            this.cbddPO.TabIndex = 248;
            this.cbddPO.Visible = false;
            // 
            // Lsuppliers
            // 
            this.Lsuppliers.AutoSize = true;
            this.Lsuppliers.Location = new System.Drawing.Point(418, 122);
            this.Lsuppliers.Name = "Lsuppliers";
            this.Lsuppliers.Size = new System.Drawing.Size(53, 13);
            this.Lsuppliers.TabIndex = 247;
            this.Lsuppliers.Text = "Suppliers:";
            this.Lsuppliers.Visible = false;
            // 
            // cbddSupplier
            // 
            this.cbddSupplier.FormattingEnabled = true;
            this.cbddSupplier.Location = new System.Drawing.Point(477, 115);
            this.cbddSupplier.Name = "cbddSupplier";
            this.cbddSupplier.Size = new System.Drawing.Size(304, 21);
            this.cbddSupplier.TabIndex = 246;
            this.cbddSupplier.Visible = false;
            // 
            // Lbuyer
            // 
            this.Lbuyer.AutoSize = true;
            this.Lbuyer.Location = new System.Drawing.Point(418, 94);
            this.Lbuyer.Name = "Lbuyer";
            this.Lbuyer.Size = new System.Drawing.Size(42, 13);
            this.Lbuyer.TabIndex = 245;
            this.Lbuyer.Text = "Buyers:";
            this.Lbuyer.Visible = false;
            // 
            // cbddComments
            // 
            this.cbddComments.FormattingEnabled = true;
            this.cbddComments.Items.AddRange(new object[] {
            "",
            "Confirm Delivery.",
            "Expedite Delivery.",
            "Waiting for reply."});
            this.cbddComments.Location = new System.Drawing.Point(491, 60);
            this.cbddComments.Name = "cbddComments";
            this.cbddComments.Size = new System.Drawing.Size(275, 21);
            this.cbddComments.TabIndex = 244;
            // 
            // cbddPlannerBuyer
            // 
            this.cbddPlannerBuyer.FormattingEnabled = true;
            this.cbddPlannerBuyer.Location = new System.Drawing.Point(477, 89);
            this.cbddPlannerBuyer.Name = "cbddPlannerBuyer";
            this.cbddPlannerBuyer.Size = new System.Drawing.Size(289, 21);
            this.cbddPlannerBuyer.TabIndex = 243;
            this.cbddPlannerBuyer.Visible = false;
            // 
            // dtpCurrDueDate
            // 
            this.dtpCurrDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCurrDueDate.Location = new System.Drawing.Point(282, 84);
            this.dtpCurrDueDate.Name = "dtpCurrDueDate";
            this.dtpCurrDueDate.Size = new System.Drawing.Size(104, 20);
            this.dtpCurrDueDate.TabIndex = 242;
            // 
            // dtpRequiredDate
            // 
            this.dtpRequiredDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRequiredDate.Location = new System.Drawing.Point(282, 135);
            this.dtpRequiredDate.Name = "dtpRequiredDate";
            this.dtpRequiredDate.Size = new System.Drawing.Size(104, 20);
            this.dtpRequiredDate.TabIndex = 241;
            // 
            // LeditGroup
            // 
            this.LeditGroup.AutoSize = true;
            this.LeditGroup.Location = new System.Drawing.Point(137, 110);
            this.LeditGroup.Name = "LeditGroup";
            this.LeditGroup.Size = new System.Drawing.Size(57, 13);
            this.LeditGroup.TabIndex = 240;
            this.LeditGroup.Text = "Edit Group";
            this.LeditGroup.Visible = false;
            // 
            // cbddGroup
            // 
            this.cbddGroup.FormattingEnabled = true;
            this.cbddGroup.Location = new System.Drawing.Point(201, 105);
            this.cbddGroup.Name = "cbddGroup";
            this.cbddGroup.Size = new System.Drawing.Size(185, 21);
            this.cbddGroup.TabIndex = 239;
            this.cbddGroup.Visible = false;
            // 
            // DGV_Comments
            // 
            this.DGV_Comments.AllowUserToAddRows = false;
            this.DGV_Comments.AllowUserToDeleteRows = false;
            this.DGV_Comments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Comments.Location = new System.Drawing.Point(403, 87);
            this.DGV_Comments.Name = "DGV_Comments";
            this.DGV_Comments.RowHeadersVisible = false;
            this.DGV_Comments.Size = new System.Drawing.Size(391, 78);
            this.DGV_Comments.TabIndex = 238;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(406, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 237;
            this.label4.Text = "Comments";
            // 
            // cbReceived
            // 
            this.cbReceived.AutoSize = true;
            this.cbReceived.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbReceived.ForeColor = System.Drawing.Color.Black;
            this.cbReceived.Location = new System.Drawing.Point(171, 110);
            this.cbReceived.Name = "cbReceived";
            this.cbReceived.Size = new System.Drawing.Size(56, 14);
            this.cbReceived.TabIndex = 236;
            this.cbReceived.Text = "Received";
            this.cbReceived.UseVisualStyleBackColor = true;
            // 
            // LrequiredDate
            // 
            this.LrequiredDate.AutoSize = true;
            this.LrequiredDate.Location = new System.Drawing.Point(297, 113);
            this.LrequiredDate.Name = "LrequiredDate";
            this.LrequiredDate.Size = new System.Drawing.Size(76, 13);
            this.LrequiredDate.TabIndex = 235;
            this.LrequiredDate.Text = "Required Date";
            // 
            // LconfirmedDueDate
            // 
            this.LconfirmedDueDate.AutoSize = true;
            this.LconfirmedDueDate.Location = new System.Drawing.Point(283, 71);
            this.LconfirmedDueDate.Name = "LconfirmedDueDate";
            this.LconfirmedDueDate.Size = new System.Drawing.Size(103, 13);
            this.LconfirmedDueDate.TabIndex = 234;
            this.LconfirmedDueDate.Text = "Confirmed Due Date";
            // 
            // bRefresh
            // 
            this.bRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(240)))));
            this.bRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.bRefresh.Location = new System.Drawing.Point(809, 66);
            this.bRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.bRefresh.Name = "bRefresh";
            this.bRefresh.Size = new System.Drawing.Size(164, 37);
            this.bRefresh.TabIndex = 233;
            this.bRefresh.Text = "Refresh Shortage List";
            this.bRefresh.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 94);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(308, 9);
            this.label11.TabIndex = 194;
            this.label11.Text = "TRACKER INFO (MOVED OUT TO A WAREHOUSE IN LAST 7 DAYS)";
            // 
            // TLP
            // 
            this.TLP.ColumnCount = 1;
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP.Controls.Add(this.DGV_ShortageItem, 0, 0);
            this.TLP.Dock = System.Windows.Forms.DockStyle.Top;
            this.TLP.Location = new System.Drawing.Point(0, 0);
            this.TLP.Name = "TLP";
            this.TLP.RowCount = 1;
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.TLP.Size = new System.Drawing.Size(1281, 57);
            this.TLP.TabIndex = 221;
            // 
            // DGV_ShortageItem
            // 
            this.DGV_ShortageItem.AllowUserToAddRows = false;
            this.DGV_ShortageItem.AllowUserToDeleteRows = false;
            this.DGV_ShortageItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_ShortageItem.ColumnHeadersHeight = 34;
            this.DGV_ShortageItem.Cursor = System.Windows.Forms.Cursors.Default;
            this.DGV_ShortageItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_ShortageItem.Location = new System.Drawing.Point(1, 1);
            this.DGV_ShortageItem.Margin = new System.Windows.Forms.Padding(1);
            this.DGV_ShortageItem.MultiSelect = false;
            this.DGV_ShortageItem.Name = "DGV_ShortageItem";
            this.DGV_ShortageItem.ReadOnly = true;
            this.DGV_ShortageItem.RowHeadersVisible = false;
            this.DGV_ShortageItem.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DGV_ShortageItem.Size = new System.Drawing.Size(1279, 55);
            this.DGV_ShortageItem.TabIndex = 176;
            // 
            // TLP2
            // 
            this.TLP2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TLP2.ColumnCount = 3;
            this.TLP2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.06123F));
            this.TLP2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.836735F));
            this.TLP2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.TLP2.Controls.Add(this.label7, 0, 3);
            this.TLP2.Controls.Add(this.label6, 0, 1);
            this.TLP2.Controls.Add(this.label12, 2, 1);
            this.TLP2.Controls.Add(this.DGV_ItemData, 0, 0);
            this.TLP2.Controls.Add(this.DGV_PLANNEDST, 0, 2);
            this.TLP2.Controls.Add(this.DGV_History, 2, 2);
            this.TLP2.Controls.Add(this.DGV_PURCH, 0, 4);
            this.TLP2.Location = new System.Drawing.Point(1, 172);
            this.TLP2.Name = "TLP2";
            this.TLP2.RowCount = 5;
            this.TLP2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.83981F));
            this.TLP2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.TLP2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.58009F));
            this.TLP2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.TLP2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.58009F));
            this.TLP2.Size = new System.Drawing.Size(980, 320);
            this.TLP2.TabIndex = 227;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 9);
            this.label7.TabIndex = 195;
            this.label7.Text = "PURCHASE ORDERS (OPEN)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 9);
            this.label6.TabIndex = 194;
            this.label6.Text = "PLANNED STOCK TRANSACTIONS:";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(688, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(255, 9);
            this.label12.TabIndex = 196;
            this.label12.Text = "CURRENT CONFIRMED DUE DATE CHANGE HISTORY:";
            // 
            // DGV_ItemData
            // 
            this.DGV_ItemData.AllowUserToAddRows = false;
            this.DGV_ItemData.AllowUserToDeleteRows = false;
            this.DGV_ItemData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_ItemData.ColumnHeadersHeight = 30;
            this.TLP2.SetColumnSpan(this.DGV_ItemData, 3);
            this.DGV_ItemData.Cursor = System.Windows.Forms.Cursors.Default;
            this.DGV_ItemData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_ItemData.Enabled = false;
            this.DGV_ItemData.Location = new System.Drawing.Point(2, 2);
            this.DGV_ItemData.Margin = new System.Windows.Forms.Padding(2);
            this.DGV_ItemData.Name = "DGV_ItemData";
            this.DGV_ItemData.ReadOnly = true;
            this.DGV_ItemData.RowHeadersVisible = false;
            this.DGV_ItemData.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DGV_ItemData.Size = new System.Drawing.Size(976, 62);
            this.DGV_ItemData.TabIndex = 164;
            // 
            // DGV_PLANNEDST
            // 
            this.DGV_PLANNEDST.AllowUserToAddRows = false;
            this.DGV_PLANNEDST.AllowUserToDeleteRows = false;
            this.DGV_PLANNEDST.AllowUserToResizeColumns = false;
            this.DGV_PLANNEDST.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DGV_PLANNEDST.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_PLANNEDST.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_PLANNEDST.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_PLANNEDST.ColumnHeadersHeight = 30;
            this.DGV_PLANNEDST.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_PLANNEDST.Cursor = System.Windows.Forms.Cursors.Default;
            this.DGV_PLANNEDST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_PLANNEDST.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGV_PLANNEDST.Location = new System.Drawing.Point(2, 83);
            this.DGV_PLANNEDST.Margin = new System.Windows.Forms.Padding(2);
            this.DGV_PLANNEDST.Name = "DGV_PLANNEDST";
            this.DGV_PLANNEDST.ReadOnly = true;
            this.DGV_PLANNEDST.RowHeadersVisible = false;
            this.DGV_PLANNEDST.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_PLANNEDST.Size = new System.Drawing.Size(663, 107);
            this.DGV_PLANNEDST.TabIndex = 165;
            // 
            // DGV_History
            // 
            this.DGV_History.AllowUserToAddRows = false;
            this.DGV_History.AllowUserToDeleteRows = false;
            this.DGV_History.AllowUserToResizeColumns = false;
            this.DGV_History.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DGV_History.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_History.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_History.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_History.ColumnHeadersHeight = 30;
            this.DGV_History.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_History.Cursor = System.Windows.Forms.Cursors.Default;
            this.DGV_History.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_History.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGV_History.Location = new System.Drawing.Point(687, 83);
            this.DGV_History.Margin = new System.Windows.Forms.Padding(2);
            this.DGV_History.Name = "DGV_History";
            this.DGV_History.RowHeadersVisible = false;
            this.DGV_History.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_History.Size = new System.Drawing.Size(291, 107);
            this.DGV_History.TabIndex = 197;
            // 
            // DGV_PURCH
            // 
            this.DGV_PURCH.AllowUserToAddRows = false;
            this.DGV_PURCH.AllowUserToDeleteRows = false;
            this.DGV_PURCH.AllowUserToResizeColumns = false;
            this.DGV_PURCH.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.DGV_PURCH.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DGV_PURCH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_PURCH.ColumnHeadersHeight = 30;
            this.DGV_PURCH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.TLP2.SetColumnSpan(this.DGV_PURCH, 3);
            this.DGV_PURCH.Cursor = System.Windows.Forms.Cursors.Default;
            this.DGV_PURCH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_PURCH.Location = new System.Drawing.Point(2, 209);
            this.DGV_PURCH.Margin = new System.Windows.Forms.Padding(2);
            this.DGV_PURCH.Name = "DGV_PURCH";
            this.DGV_PURCH.ReadOnly = true;
            this.DGV_PURCH.RowHeadersVisible = false;
            this.DGV_PURCH.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_PURCH.Size = new System.Drawing.Size(976, 109);
            this.DGV_PURCH.TabIndex = 198;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridView1.Location = new System.Drawing.Point(13, 312);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(1);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView1.Size = new System.Drawing.Size(961, 157);
            this.dataGridView1.TabIndex = 222;
            // 
            // bArchive
            // 
            this.bArchive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(0)))));
            this.bArchive.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.bArchive.Location = new System.Drawing.Point(11, 127);
            this.bArchive.Margin = new System.Windows.Forms.Padding(2);
            this.bArchive.Name = "bArchive";
            this.bArchive.Size = new System.Drawing.Size(60, 25);
            this.bArchive.TabIndex = 225;
            this.bArchive.Text = "Archive";
            this.bArchive.UseVisualStyleBackColor = false;
            // 
            // LitemNumber
            // 
            this.LitemNumber.AutoSize = true;
            this.LitemNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.LitemNumber.Location = new System.Drawing.Point(80, 66);
            this.LitemNumber.Name = "LitemNumber";
            this.LitemNumber.Size = new System.Drawing.Size(61, 13);
            this.LitemNumber.TabIndex = 226;
            this.LitemNumber.Text = "Number  of ";
            // 
            // Bnext
            // 
            this.Bnext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(128)))), ((int)(((byte)(192)))));
            this.Bnext.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.Bnext.Location = new System.Drawing.Point(11, 66);
            this.Bnext.Margin = new System.Windows.Forms.Padding(2);
            this.Bnext.Name = "Bnext";
            this.Bnext.Size = new System.Drawing.Size(60, 25);
            this.Bnext.TabIndex = 223;
            this.Bnext.Text = "NEXT";
            this.Bnext.UseVisualStyleBackColor = false;
            // 
            // Bprevious
            // 
            this.Bprevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(250)))), ((int)(((byte)(50)))));
            this.Bprevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.Bprevious.Location = new System.Drawing.Point(11, 95);
            this.Bprevious.Margin = new System.Windows.Forms.Padding(2);
            this.Bprevious.Name = "Bprevious";
            this.Bprevious.Size = new System.Drawing.Size(60, 25);
            this.Bprevious.TabIndex = 224;
            this.Bprevious.Text = "Previous";
            this.Bprevious.UseVisualStyleBackColor = false;
            // 
            // Lquantity
            // 
            this.Lquantity.AutoSize = true;
            this.Lquantity.Location = new System.Drawing.Point(806, 145);
            this.Lquantity.Name = "Lquantity";
            this.Lquantity.Size = new System.Drawing.Size(49, 13);
            this.Lquantity.TabIndex = 252;
            this.Lquantity.Text = "Quantity:";
            this.Lquantity.Visible = false;
            // 
            // TLP3
            // 
            this.TLP3.ColumnCount = 5;
            this.TLP3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
            this.TLP3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.TLP3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
            this.TLP3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.TLP3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.TLP3.Controls.Add(this.DGV_TRACK_QC, 0, 3);
            this.TLP3.Controls.Add(this.label8, 0, 0);
            this.TLP3.Controls.Add(this.label9, 2, 0);
            this.TLP3.Controls.Add(this.label10, 2, 2);
            this.TLP3.Controls.Add(this.label11, 0, 2);
            this.TLP3.Controls.Add(this.DGV_RECEIPTS, 0, 1);
            this.TLP3.Controls.Add(this.DGV_PROD, 2, 1);
            this.TLP3.Controls.Add(this.bTrackingDetails, 4, 3);
            this.TLP3.Controls.Add(this.DGV_TRACK_WH, 2, 3);
            this.TLP3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TLP3.Location = new System.Drawing.Point(0, 550);
            this.TLP3.Name = "TLP3";
            this.TLP3.RowCount = 4;
            this.TLP3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP3.Size = new System.Drawing.Size(1281, 189);
            this.TLP3.TabIndex = 232;
            // 
            // DGV_RECEIPTS
            // 
            this.DGV_RECEIPTS.AllowUserToAddRows = false;
            this.DGV_RECEIPTS.AllowUserToDeleteRows = false;
            this.DGV_RECEIPTS.AllowUserToResizeColumns = false;
            this.DGV_RECEIPTS.AllowUserToResizeRows = false;
            this.DGV_RECEIPTS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_RECEIPTS.ColumnHeadersHeight = 30;
            this.DGV_RECEIPTS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_RECEIPTS.Cursor = System.Windows.Forms.Cursors.Default;
            this.DGV_RECEIPTS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_RECEIPTS.Location = new System.Drawing.Point(2, 22);
            this.DGV_RECEIPTS.Margin = new System.Windows.Forms.Padding(2);
            this.DGV_RECEIPTS.Name = "DGV_RECEIPTS";
            this.DGV_RECEIPTS.RowHeadersVisible = false;
            this.DGV_RECEIPTS.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_RECEIPTS.Size = new System.Drawing.Size(619, 70);
            this.DGV_RECEIPTS.TabIndex = 195;
            // 
            // DGV_PROD
            // 
            this.DGV_PROD.AllowUserToAddRows = false;
            this.DGV_PROD.AllowUserToDeleteRows = false;
            this.DGV_PROD.AllowUserToResizeColumns = false;
            this.DGV_PROD.AllowUserToResizeRows = false;
            this.DGV_PROD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_PROD.ColumnHeadersHeight = 30;
            this.DGV_PROD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.TLP3.SetColumnSpan(this.DGV_PROD, 3);
            this.DGV_PROD.Cursor = System.Windows.Forms.Cursors.Default;
            this.DGV_PROD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_PROD.Location = new System.Drawing.Point(640, 22);
            this.DGV_PROD.Margin = new System.Windows.Forms.Padding(2);
            this.DGV_PROD.Name = "DGV_PROD";
            this.DGV_PROD.RowHeadersVisible = false;
            this.DGV_PROD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_PROD.Size = new System.Drawing.Size(639, 70);
            this.DGV_PROD.TabIndex = 196;
            // 
            // bTrackingDetails
            // 
            this.bTrackingDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(200)))), ((int)(((byte)(120)))));
            this.bTrackingDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bTrackingDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.bTrackingDetails.Location = new System.Drawing.Point(1154, 116);
            this.bTrackingDetails.Margin = new System.Windows.Forms.Padding(2);
            this.bTrackingDetails.Name = "bTrackingDetails";
            this.bTrackingDetails.Size = new System.Drawing.Size(125, 71);
            this.bTrackingDetails.TabIndex = 198;
            this.bTrackingDetails.Text = "Tracking Details";
            this.bTrackingDetails.UseVisualStyleBackColor = false;
            // 
            // DGV_TRACK_WH
            // 
            this.DGV_TRACK_WH.AllowUserToAddRows = false;
            this.DGV_TRACK_WH.AllowUserToDeleteRows = false;
            this.DGV_TRACK_WH.AllowUserToResizeColumns = false;
            this.DGV_TRACK_WH.AllowUserToResizeRows = false;
            this.DGV_TRACK_WH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_TRACK_WH.ColumnHeadersHeight = 30;
            this.DGV_TRACK_WH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_TRACK_WH.Cursor = System.Windows.Forms.Cursors.Default;
            this.DGV_TRACK_WH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_TRACK_WH.Location = new System.Drawing.Point(640, 116);
            this.DGV_TRACK_WH.Margin = new System.Windows.Forms.Padding(2);
            this.DGV_TRACK_WH.Name = "DGV_TRACK_WH";
            this.DGV_TRACK_WH.RowHeadersVisible = false;
            this.DGV_TRACK_WH.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_TRACK_WH.Size = new System.Drawing.Size(495, 71);
            this.DGV_TRACK_WH.TabIndex = 199;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 9);
            this.label5.TabIndex = 231;
            this.label5.Text = "ITEM MASTER DATA:";
            // 
            // cbActionRqd
            // 
            this.cbActionRqd.AutoSize = true;
            this.cbActionRqd.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbActionRqd.ForeColor = System.Drawing.Color.Black;
            this.cbActionRqd.Location = new System.Drawing.Point(85, 130);
            this.cbActionRqd.Name = "cbActionRqd";
            this.cbActionRqd.Size = new System.Drawing.Size(61, 14);
            this.cbActionRqd.TabIndex = 230;
            this.cbActionRqd.Text = "Action Rqd";
            this.cbActionRqd.UseVisualStyleBackColor = true;
            // 
            // cbHot
            // 
            this.cbHot.AutoSize = true;
            this.cbHot.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHot.ForeColor = System.Drawing.Color.Red;
            this.cbHot.Location = new System.Drawing.Point(85, 110);
            this.cbHot.Name = "cbHot";
            this.cbHot.Size = new System.Drawing.Size(44, 14);
            this.cbHot.TabIndex = 229;
            this.cbHot.Text = "HOT";
            this.cbHot.UseVisualStyleBackColor = true;
            // 
            // Lstatus
            // 
            this.Lstatus.AutoSize = true;
            this.Lstatus.BackColor = System.Drawing.Color.Yellow;
            this.Lstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lstatus.Location = new System.Drawing.Point(80, 90);
            this.Lstatus.Name = "Lstatus";
            this.Lstatus.Size = new System.Drawing.Size(60, 13);
            this.Lstatus.TabIndex = 228;
            this.Lstatus.Text = "STATUS:";
            // 
            // DataDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(120)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1281, 739);
            this.Controls.Add(this.tbQuantity);
            this.Controls.Add(this.LorigDue);
            this.Controls.Add(this.dtpOrigDue);
            this.Controls.Add(this.Lpo);
            this.Controls.Add(this.cbddPO);
            this.Controls.Add(this.Lsuppliers);
            this.Controls.Add(this.cbddSupplier);
            this.Controls.Add(this.Lbuyer);
            this.Controls.Add(this.cbddComments);
            this.Controls.Add(this.cbddPlannerBuyer);
            this.Controls.Add(this.dtpCurrDueDate);
            this.Controls.Add(this.dtpRequiredDate);
            this.Controls.Add(this.LeditGroup);
            this.Controls.Add(this.cbddGroup);
            this.Controls.Add(this.DGV_Comments);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbReceived);
            this.Controls.Add(this.LrequiredDate);
            this.Controls.Add(this.LconfirmedDueDate);
            this.Controls.Add(this.bRefresh);
            this.Controls.Add(this.TLP);
            this.Controls.Add(this.TLP2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.bArchive);
            this.Controls.Add(this.LitemNumber);
            this.Controls.Add(this.Bnext);
            this.Controls.Add(this.Bprevious);
            this.Controls.Add(this.Lquantity);
            this.Controls.Add(this.TLP3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbActionRqd);
            this.Controls.Add(this.cbHot);
            this.Controls.Add(this.Lstatus);
            this.Name = "DataDisplay";
            this.Text = "MRP Data Display";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_TRACK_QC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Comments)).EndInit();
            this.TLP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ShortageItem)).EndInit();
            this.TLP2.ResumeLayout(false);
            this.TLP2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ItemData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_PLANNEDST)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_History)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_PURCH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.TLP3.ResumeLayout(false);
            this.TLP3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_RECEIPTS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_PROD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_TRACK_WH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_TRACK_QC;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.Label LorigDue;
        private System.Windows.Forms.DateTimePicker dtpOrigDue;
        private System.Windows.Forms.Label Lpo;
        private System.Windows.Forms.ComboBox cbddPO;
        private System.Windows.Forms.Label Lsuppliers;
        private System.Windows.Forms.ComboBox cbddSupplier;
        private System.Windows.Forms.Label Lbuyer;
        private System.Windows.Forms.ComboBox cbddComments;
        private System.Windows.Forms.ComboBox cbddPlannerBuyer;
        private System.Windows.Forms.DateTimePicker dtpCurrDueDate;
        private System.Windows.Forms.DateTimePicker dtpRequiredDate;
        private System.Windows.Forms.Label LeditGroup;
        private System.Windows.Forms.ComboBox cbddGroup;
        private System.Windows.Forms.DataGridView DGV_Comments;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbReceived;
        private System.Windows.Forms.Label LrequiredDate;
        private System.Windows.Forms.Label LconfirmedDueDate;
        private System.Windows.Forms.Button bRefresh;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TableLayoutPanel TLP;
        private System.Windows.Forms.DataGridView DGV_ShortageItem;
        private System.Windows.Forms.TableLayoutPanel TLP2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView DGV_ItemData;
        private System.Windows.Forms.DataGridView DGV_PLANNEDST;
        private System.Windows.Forms.DataGridView DGV_History;
        private System.Windows.Forms.DataGridView DGV_PURCH;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bArchive;
        private System.Windows.Forms.Label LitemNumber;
        private System.Windows.Forms.Button Bnext;
        private System.Windows.Forms.Button Bprevious;
        private System.Windows.Forms.Label Lquantity;
        private System.Windows.Forms.TableLayoutPanel TLP3;
        private System.Windows.Forms.DataGridView DGV_RECEIPTS;
        private System.Windows.Forms.DataGridView DGV_PROD;
        private System.Windows.Forms.Button bTrackingDetails;
        private System.Windows.Forms.DataGridView DGV_TRACK_WH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbActionRqd;
        private System.Windows.Forms.CheckBox cbHot;
        private System.Windows.Forms.Label Lstatus;
    }
}

