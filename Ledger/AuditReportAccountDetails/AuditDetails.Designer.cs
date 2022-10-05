namespace AuditReportAccountDetails
{
    partial class AuditDetails
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bsearchItem = new System.Windows.Forms.Button();
            this.tbSearchItem = new System.Windows.Forms.TextBox();
            this.DGV1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bSearchDescription = new System.Windows.Forms.Button();
            this.tbSearchLocation = new System.Windows.Forms.TextBox();
            this.bSearchLocation = new System.Windows.Forms.Button();
            this.DGV2 = new System.Windows.Forms.DataGridView();
            this.LcostCenters = new System.Windows.Forms.Label();
            this.LaccountCodes = new System.Windows.Forms.Label();
            this.bGetData = new System.Windows.Forms.Button();
            this.tbAccountCode = new System.Windows.Forms.TextBox();
            this.tbCostCenters = new System.Windows.Forms.TextBox();
            this.bCurrentFY = new System.Windows.Forms.Button();
            this.bLastFY = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(125)))), ((int)(((byte)(165)))));
            this.groupBox2.Controls.Add(this.bsearchItem);
            this.groupBox2.Controls.Add(this.tbSearchItem);
            this.groupBox2.Controls.Add(this.DGV1);
            this.groupBox2.Location = new System.Drawing.Point(33, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(177, 456);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            // 
            // bsearchItem
            // 
            this.bsearchItem.BackColor = System.Drawing.Color.Gray;
            this.bsearchItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsearchItem.Location = new System.Drawing.Point(26, 77);
            this.bsearchItem.Name = "bsearchItem";
            this.bsearchItem.Size = new System.Drawing.Size(116, 69);
            this.bsearchItem.TabIndex = 26;
            this.bsearchItem.Text = "Search A/C";
            this.bsearchItem.UseVisualStyleBackColor = false;
            // 
            // tbSearchItem
            // 
            this.tbSearchItem.Location = new System.Drawing.Point(14, 46);
            this.tbSearchItem.Name = "tbSearchItem";
            this.tbSearchItem.Size = new System.Drawing.Size(145, 20);
            this.tbSearchItem.TabIndex = 25;
            // 
            // DGV1
            // 
            this.DGV1.AllowUserToAddRows = false;
            this.DGV1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DGV1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV1.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGV1.Location = new System.Drawing.Point(14, 166);
            this.DGV1.Name = "DGV1";
            this.DGV1.ReadOnly = true;
            this.DGV1.Size = new System.Drawing.Size(145, 268);
            this.DGV1.TabIndex = 21;
            this.DGV1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV1_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.groupBox1.Controls.Add(this.bSearchDescription);
            this.groupBox1.Controls.Add(this.tbSearchLocation);
            this.groupBox1.Controls.Add(this.bSearchLocation);
            this.groupBox1.Controls.Add(this.DGV2);
            this.groupBox1.Location = new System.Drawing.Point(419, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 455);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            // 
            // bSearchDescription
            // 
            this.bSearchDescription.BackColor = System.Drawing.Color.Gray;
            this.bSearchDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearchDescription.Location = new System.Drawing.Point(344, 23);
            this.bSearchDescription.Name = "bSearchDescription";
            this.bSearchDescription.Size = new System.Drawing.Size(116, 69);
            this.bSearchDescription.TabIndex = 29;
            this.bSearchDescription.Text = "Search Description";
            this.bSearchDescription.UseVisualStyleBackColor = false;
            // 
            // tbSearchLocation
            // 
            this.tbSearchLocation.Location = new System.Drawing.Point(164, 44);
            this.tbSearchLocation.Name = "tbSearchLocation";
            this.tbSearchLocation.Size = new System.Drawing.Size(153, 20);
            this.tbSearchLocation.TabIndex = 28;
            // 
            // bSearchLocation
            // 
            this.bSearchLocation.BackColor = System.Drawing.Color.Gray;
            this.bSearchLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearchLocation.Location = new System.Drawing.Point(17, 23);
            this.bSearchLocation.Name = "bSearchLocation";
            this.bSearchLocation.Size = new System.Drawing.Size(116, 69);
            this.bSearchLocation.TabIndex = 27;
            this.bSearchLocation.Text = "Search Cost Center";
            this.bSearchLocation.UseVisualStyleBackColor = false;
            // 
            // DGV2
            // 
            this.DGV2.AllowUserToAddRows = false;
            this.DGV2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DGV2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV2.Location = new System.Drawing.Point(17, 117);
            this.DGV2.Name = "DGV2";
            this.DGV2.ReadOnly = true;
            this.DGV2.Size = new System.Drawing.Size(443, 315);
            this.DGV2.TabIndex = 22;
            this.DGV2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV2_CellClick);
            // 
            // LcostCenters
            // 
            this.LcostCenters.AutoSize = true;
            this.LcostCenters.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LcostCenters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(100)))), ((int)(((byte)(50)))));
            this.LcostCenters.Location = new System.Drawing.Point(248, 324);
            this.LcostCenters.Name = "LcostCenters";
            this.LcostCenters.Size = new System.Drawing.Size(119, 24);
            this.LcostCenters.TabIndex = 35;
            this.LcostCenters.Text = "Cost Center";
            // 
            // LaccountCodes
            // 
            this.LaccountCodes.AutoSize = true;
            this.LaccountCodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LaccountCodes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(100)))), ((int)(((byte)(50)))));
            this.LaccountCodes.Location = new System.Drawing.Point(278, 70);
            this.LaccountCodes.Name = "LaccountCodes";
            this.LaccountCodes.Size = new System.Drawing.Size(44, 24);
            this.LaccountCodes.TabIndex = 34;
            this.LaccountCodes.Text = "A/C";
            // 
            // bGetData
            // 
            this.bGetData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(195)))), ((int)(((byte)(40)))));
            this.bGetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bGetData.ForeColor = System.Drawing.Color.Black;
            this.bGetData.Location = new System.Drawing.Point(652, 25);
            this.bGetData.Name = "bGetData";
            this.bGetData.Size = new System.Drawing.Size(227, 50);
            this.bGetData.TabIndex = 33;
            this.bGetData.Text = "Get Data";
            this.bGetData.UseVisualStyleBackColor = false;
            this.bGetData.Click += new System.EventHandler(this.bGetData_Click);
            // 
            // tbAccountCode
            // 
            this.tbAccountCode.Location = new System.Drawing.Point(233, 97);
            this.tbAccountCode.Multiline = true;
            this.tbAccountCode.Name = "tbAccountCode";
            this.tbAccountCode.Size = new System.Drawing.Size(145, 201);
            this.tbAccountCode.TabIndex = 27;
            // 
            // tbCostCenters
            // 
            this.tbCostCenters.Location = new System.Drawing.Point(233, 351);
            this.tbCostCenters.Multiline = true;
            this.tbCostCenters.Name = "tbCostCenters";
            this.tbCostCenters.Size = new System.Drawing.Size(145, 201);
            this.tbCostCenters.TabIndex = 38;
            // 
            // bCurrentFY
            // 
            this.bCurrentFY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(175)))), ((int)(((byte)(40)))));
            this.bCurrentFY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.bCurrentFY.ForeColor = System.Drawing.Color.Black;
            this.bCurrentFY.Location = new System.Drawing.Point(33, 25);
            this.bCurrentFY.Name = "bCurrentFY";
            this.bCurrentFY.Size = new System.Drawing.Size(159, 33);
            this.bCurrentFY.TabIndex = 39;
            this.bCurrentFY.Text = "This Fiscal Year";
            this.bCurrentFY.UseVisualStyleBackColor = false;
            this.bCurrentFY.Click += new System.EventHandler(this.bCurrentFY_Click);
            // 
            // bLastFY
            // 
            this.bLastFY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(105)))), ((int)(((byte)(40)))));
            this.bLastFY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.bLastFY.ForeColor = System.Drawing.Color.Black;
            this.bLastFY.Location = new System.Drawing.Point(208, 25);
            this.bLastFY.Name = "bLastFY";
            this.bLastFY.Size = new System.Drawing.Size(159, 33);
            this.bLastFY.TabIndex = 40;
            this.bLastFY.Text = "Last Fiscal Year";
            this.bLastFY.UseVisualStyleBackColor = false;
            this.bLastFY.Click += new System.EventHandler(this.bLastFY_Click);
            // 
            // AuditDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(150)))));
            this.ClientSize = new System.Drawing.Size(932, 577);
            this.Controls.Add(this.bLastFY);
            this.Controls.Add(this.bCurrentFY);
            this.Controls.Add(this.tbCostCenters);
            this.Controls.Add(this.tbAccountCode);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LcostCenters);
            this.Controls.Add(this.LaccountCodes);
            this.Controls.Add(this.bGetData);
            this.Name = "AuditDetails";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bsearchItem;
        private System.Windows.Forms.TextBox tbSearchItem;
        private System.Windows.Forms.DataGridView DGV1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bSearchDescription;
        private System.Windows.Forms.TextBox tbSearchLocation;
        private System.Windows.Forms.Button bSearchLocation;
        private System.Windows.Forms.DataGridView DGV2;
        private System.Windows.Forms.Label LcostCenters;
        private System.Windows.Forms.Label LaccountCodes;
        private System.Windows.Forms.Button bGetData;
        private System.Windows.Forms.TextBox tbAccountCode;
        private System.Windows.Forms.TextBox tbCostCenters;
        private System.Windows.Forms.Button bCurrentFY;
        private System.Windows.Forms.Button bLastFY;
    }
}

