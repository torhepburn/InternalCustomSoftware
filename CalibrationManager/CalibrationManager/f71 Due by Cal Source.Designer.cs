namespace CalibrationManager
{
    partial class f71_Due_by_Cal_Source
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
            this.comboxStatus = new System.Windows.Forms.ComboBox();
            this.comboxCalSource = new System.Windows.Forms.ComboBox();
            this.Lstatus = new System.Windows.Forms.Label();
            this.Lsource = new System.Windows.Forms.Label();
            this.LdueB4 = new System.Windows.Forms.Label();
            this.bFilter = new System.Windows.Forms.Button();
            this.monthCalendarDueB4 = new System.Windows.Forms.MonthCalendar();
            this.LdueAfter = new System.Windows.Forms.Label();
            this.monthCalendarDueAfter = new System.Windows.Forms.MonthCalendar();
            this.bPrint = new System.Windows.Forms.Button();
            this.bBack = new System.Windows.Forms.Button();
            this.bStatus = new System.Windows.Forms.Button();
            this.bCalSource = new System.Windows.Forms.Button();
            this.Lrowcount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(31, 332);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.Size = new System.Drawing.Size(915, 287);
            this.DGV.TabIndex = 0;
            // 
            // comboxStatus
            // 
            this.comboxStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.comboxStatus.FormattingEnabled = true;
            this.comboxStatus.Location = new System.Drawing.Point(211, 15);
            this.comboxStatus.Name = "comboxStatus";
            this.comboxStatus.Size = new System.Drawing.Size(151, 28);
            this.comboxStatus.TabIndex = 1;
            this.comboxStatus.SelectedIndexChanged += new System.EventHandler(this.comboxStatus_SelectedIndexChanged);
            // 
            // comboxCalSource
            // 
            this.comboxCalSource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.comboxCalSource.FormattingEnabled = true;
            this.comboxCalSource.Location = new System.Drawing.Point(638, 15);
            this.comboxCalSource.Name = "comboxCalSource";
            this.comboxCalSource.Size = new System.Drawing.Size(232, 28);
            this.comboxCalSource.TabIndex = 2;
            // 
            // Lstatus
            // 
            this.Lstatus.AutoSize = true;
            this.Lstatus.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Lstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lstatus.Location = new System.Drawing.Point(128, 15);
            this.Lstatus.Name = "Lstatus";
            this.Lstatus.Padding = new System.Windows.Forms.Padding(5);
            this.Lstatus.Size = new System.Drawing.Size(77, 30);
            this.Lstatus.TabIndex = 4;
            this.Lstatus.Text = "Status:";
            // 
            // Lsource
            // 
            this.Lsource.AutoSize = true;
            this.Lsource.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Lsource.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lsource.Location = new System.Drawing.Point(460, 15);
            this.Lsource.Name = "Lsource";
            this.Lsource.Padding = new System.Windows.Forms.Padding(5);
            this.Lsource.Size = new System.Drawing.Size(172, 30);
            this.Lsource.TabIndex = 5;
            this.Lsource.Text = "Calibration Source:";
            // 
            // LdueB4
            // 
            this.LdueB4.AutoSize = true;
            this.LdueB4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.LdueB4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LdueB4.Location = new System.Drawing.Point(509, 146);
            this.LdueB4.Name = "LdueB4";
            this.LdueB4.Padding = new System.Windows.Forms.Padding(5);
            this.LdueB4.Size = new System.Drawing.Size(116, 30);
            this.LdueB4.TabIndex = 6;
            this.LdueB4.Text = "Due Before:";
            // 
            // bFilter
            // 
            this.bFilter.BackColor = System.Drawing.Color.PaleVioletRed;
            this.bFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bFilter.Location = new System.Drawing.Point(31, 262);
            this.bFilter.Name = "bFilter";
            this.bFilter.Size = new System.Drawing.Size(915, 37);
            this.bFilter.TabIndex = 8;
            this.bFilter.Text = "Filter";
            this.bFilter.UseVisualStyleBackColor = false;
            this.bFilter.Click += new System.EventHandler(this.bFilter_Click);
            // 
            // monthCalendarDueB4
            // 
            this.monthCalendarDueB4.BackColor = System.Drawing.SystemColors.Window;
            this.monthCalendarDueB4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthCalendarDueB4.Location = new System.Drawing.Point(656, 77);
            this.monthCalendarDueB4.Name = "monthCalendarDueB4";
            this.monthCalendarDueB4.TabIndex = 10;
            this.monthCalendarDueB4.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarDueB4_DateChanged);
            this.monthCalendarDueB4.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarDueB4_DateSelected);
            // 
            // LdueAfter
            // 
            this.LdueAfter.AutoSize = true;
            this.LdueAfter.BackColor = System.Drawing.Color.LightSteelBlue;
            this.LdueAfter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LdueAfter.Location = new System.Drawing.Point(134, 146);
            this.LdueAfter.Name = "LdueAfter";
            this.LdueAfter.Padding = new System.Windows.Forms.Padding(5);
            this.LdueAfter.Size = new System.Drawing.Size(102, 30);
            this.LdueAfter.TabIndex = 11;
            this.LdueAfter.Text = "Due After:";
            // 
            // monthCalendarDueAfter
            // 
            this.monthCalendarDueAfter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthCalendarDueAfter.Location = new System.Drawing.Point(258, 77);
            this.monthCalendarDueAfter.Name = "monthCalendarDueAfter";
            this.monthCalendarDueAfter.TabIndex = 12;
            this.monthCalendarDueAfter.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarDueAfter_DateChanged);
            // 
            // bPrint
            // 
            this.bPrint.BackColor = System.Drawing.Color.LightSkyBlue;
            this.bPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPrint.Location = new System.Drawing.Point(885, 148);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(61, 28);
            this.bPrint.TabIndex = 13;
            this.bPrint.Text = "Print";
            this.bPrint.UseVisualStyleBackColor = false;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // bBack
            // 
            this.bBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(50)))));
            this.bBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBack.Location = new System.Drawing.Point(31, 12);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(59, 220);
            this.bBack.TabIndex = 14;
            this.bBack.Text = "BACK";
            this.bBack.UseVisualStyleBackColor = false;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // bStatus
            // 
            this.bStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bStatus.Location = new System.Drawing.Point(368, 15);
            this.bStatus.Name = "bStatus";
            this.bStatus.Size = new System.Drawing.Size(57, 30);
            this.bStatus.TabIndex = 15;
            this.bStatus.Text = "All";
            this.bStatus.UseVisualStyleBackColor = false;
            this.bStatus.Click += new System.EventHandler(this.bStatus_Click);
            // 
            // bCalSource
            // 
            this.bCalSource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bCalSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCalSource.Location = new System.Drawing.Point(876, 15);
            this.bCalSource.Name = "bCalSource";
            this.bCalSource.Size = new System.Drawing.Size(57, 30);
            this.bCalSource.TabIndex = 16;
            this.bCalSource.Text = "All";
            this.bCalSource.UseVisualStyleBackColor = false;
            this.bCalSource.Click += new System.EventHandler(this.bCalSource_Click);
            // 
            // Lrowcount
            // 
            this.Lrowcount.AutoSize = true;
            this.Lrowcount.Location = new System.Drawing.Point(31, 306);
            this.Lrowcount.Name = "Lrowcount";
            this.Lrowcount.Size = new System.Drawing.Size(92, 20);
            this.Lrowcount.TabIndex = 17;
            this.Lrowcount.Text = "Row Count:";
            // 
            // f71_Due_by_Cal_Source
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(978, 677);
            this.Controls.Add(this.Lrowcount);
            this.Controls.Add(this.bCalSource);
            this.Controls.Add(this.bStatus);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.bPrint);
            this.Controls.Add(this.monthCalendarDueAfter);
            this.Controls.Add(this.LdueAfter);
            this.Controls.Add(this.monthCalendarDueB4);
            this.Controls.Add(this.bFilter);
            this.Controls.Add(this.LdueB4);
            this.Controls.Add(this.Lsource);
            this.Controls.Add(this.Lstatus);
            this.Controls.Add(this.comboxCalSource);
            this.Controls.Add(this.comboxStatus);
            this.Controls.Add(this.DGV);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "f71_Due_by_Cal_Source";
            this.Text = "f71 Due by Cal Source";
            this.Load += new System.EventHandler(this.f71_Due_by_Cal_Source_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.ComboBox comboxStatus;
        private System.Windows.Forms.ComboBox comboxCalSource;
        private System.Windows.Forms.Label Lstatus;
        private System.Windows.Forms.Label Lsource;
        private System.Windows.Forms.Label LdueB4;
        private System.Windows.Forms.Button bFilter;
        private System.Windows.Forms.MonthCalendar monthCalendarDueB4;
        private System.Windows.Forms.Label LdueAfter;
        private System.Windows.Forms.MonthCalendar monthCalendarDueAfter;
        private System.Windows.Forms.Button bPrint;
        private System.Windows.Forms.Button bBack;
        private System.Windows.Forms.Button bStatus;
        private System.Windows.Forms.Button bCalSource;
        private System.Windows.Forms.Label Lrowcount;
    }
}