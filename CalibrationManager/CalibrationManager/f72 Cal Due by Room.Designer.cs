namespace CalibrationManager
{
    partial class f72_Cal_Due_by_Room
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
            this.bPrint = new System.Windows.Forms.Button();
            this.monthCalendarDueAfter = new System.Windows.Forms.MonthCalendar();
            this.LdueAfter = new System.Windows.Forms.Label();
            this.monthCalendarDueB4 = new System.Windows.Forms.MonthCalendar();
            this.bFilter = new System.Windows.Forms.Button();
            this.LdueB4 = new System.Windows.Forms.Label();
            this.Lroom = new System.Windows.Forms.Label();
            this.Lstatus = new System.Windows.Forms.Label();
            this.comboxRoom = new System.Windows.Forms.ComboBox();
            this.comboxStatus = new System.Windows.Forms.ComboBox();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.bBack = new System.Windows.Forms.Button();
            this.bStatus = new System.Windows.Forms.Button();
            this.Lrowcount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // bPrint
            // 
            this.bPrint.BackColor = System.Drawing.Color.LightSkyBlue;
            this.bPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPrint.Location = new System.Drawing.Point(888, 174);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(61, 28);
            this.bPrint.TabIndex = 24;
            this.bPrint.Text = "Print";
            this.bPrint.UseVisualStyleBackColor = false;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // monthCalendarDueAfter
            // 
            this.monthCalendarDueAfter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthCalendarDueAfter.Location = new System.Drawing.Point(261, 103);
            this.monthCalendarDueAfter.Name = "monthCalendarDueAfter";
            this.monthCalendarDueAfter.TabIndex = 23;
            this.monthCalendarDueAfter.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarDueAfter_DateChanged);
            // 
            // LdueAfter
            // 
            this.LdueAfter.AutoSize = true;
            this.LdueAfter.BackColor = System.Drawing.Color.LightSteelBlue;
            this.LdueAfter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LdueAfter.Location = new System.Drawing.Point(137, 172);
            this.LdueAfter.Name = "LdueAfter";
            this.LdueAfter.Padding = new System.Windows.Forms.Padding(5);
            this.LdueAfter.Size = new System.Drawing.Size(102, 30);
            this.LdueAfter.TabIndex = 22;
            this.LdueAfter.Text = "Due After:";
            // 
            // monthCalendarDueB4
            // 
            this.monthCalendarDueB4.BackColor = System.Drawing.SystemColors.Window;
            this.monthCalendarDueB4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthCalendarDueB4.Location = new System.Drawing.Point(659, 103);
            this.monthCalendarDueB4.Name = "monthCalendarDueB4";
            this.monthCalendarDueB4.TabIndex = 21;
            this.monthCalendarDueB4.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarDueB4_DateChanged);
            // 
            // bFilter
            // 
            this.bFilter.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.bFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bFilter.Location = new System.Drawing.Point(34, 288);
            this.bFilter.Name = "bFilter";
            this.bFilter.Size = new System.Drawing.Size(915, 37);
            this.bFilter.TabIndex = 20;
            this.bFilter.Text = "FIND";
            this.bFilter.UseVisualStyleBackColor = false;
            this.bFilter.Click += new System.EventHandler(this.bFilter_Click);
            // 
            // LdueB4
            // 
            this.LdueB4.AutoSize = true;
            this.LdueB4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.LdueB4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LdueB4.Location = new System.Drawing.Point(512, 172);
            this.LdueB4.Name = "LdueB4";
            this.LdueB4.Padding = new System.Windows.Forms.Padding(5);
            this.LdueB4.Size = new System.Drawing.Size(116, 30);
            this.LdueB4.TabIndex = 19;
            this.LdueB4.Text = "Due Before:";
            // 
            // Lroom
            // 
            this.Lroom.AutoSize = true;
            this.Lroom.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Lroom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lroom.Location = new System.Drawing.Point(530, 41);
            this.Lroom.Name = "Lroom";
            this.Lroom.Padding = new System.Windows.Forms.Padding(5);
            this.Lroom.Size = new System.Drawing.Size(71, 30);
            this.Lroom.TabIndex = 18;
            this.Lroom.Text = "Room:";
            // 
            // Lstatus
            // 
            this.Lstatus.AutoSize = true;
            this.Lstatus.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Lstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lstatus.Location = new System.Drawing.Point(131, 41);
            this.Lstatus.Name = "Lstatus";
            this.Lstatus.Padding = new System.Windows.Forms.Padding(5);
            this.Lstatus.Size = new System.Drawing.Size(77, 30);
            this.Lstatus.TabIndex = 17;
            this.Lstatus.Text = "Status:";
            // 
            // comboxRoom
            // 
            this.comboxRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.comboxRoom.FormattingEnabled = true;
            this.comboxRoom.Location = new System.Drawing.Point(607, 41);
            this.comboxRoom.Name = "comboxRoom";
            this.comboxRoom.Size = new System.Drawing.Size(232, 21);
            this.comboxRoom.TabIndex = 16;
            // 
            // comboxStatus
            // 
            this.comboxStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.comboxStatus.FormattingEnabled = true;
            this.comboxStatus.Location = new System.Drawing.Point(214, 41);
            this.comboxStatus.Name = "comboxStatus";
            this.comboxStatus.Size = new System.Drawing.Size(151, 21);
            this.comboxStatus.TabIndex = 15;
            this.comboxStatus.SelectedIndexChanged += new System.EventHandler(this.comboxStatus_SelectedIndexChanged);
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
            this.DGV.Location = new System.Drawing.Point(34, 358);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.Size = new System.Drawing.Size(915, 287);
            this.DGV.TabIndex = 14;
            // 
            // bBack
            // 
            this.bBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(50)))));
            this.bBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBack.Location = new System.Drawing.Point(34, 41);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(59, 217);
            this.bBack.TabIndex = 25;
            this.bBack.Text = "BACK";
            this.bBack.UseVisualStyleBackColor = false;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // bStatus
            // 
            this.bStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bStatus.Location = new System.Drawing.Point(371, 36);
            this.bStatus.Name = "bStatus";
            this.bStatus.Size = new System.Drawing.Size(57, 30);
            this.bStatus.TabIndex = 26;
            this.bStatus.Text = "All";
            this.bStatus.UseVisualStyleBackColor = false;
            this.bStatus.Click += new System.EventHandler(this.bStatus_Click);
            // 
            // Lrowcount
            // 
            this.Lrowcount.AutoSize = true;
            this.Lrowcount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Lrowcount.Location = new System.Drawing.Point(31, 328);
            this.Lrowcount.Name = "Lrowcount";
            this.Lrowcount.Size = new System.Drawing.Size(80, 17);
            this.Lrowcount.TabIndex = 27;
            this.Lrowcount.Text = "Row Count:";
            // 
            // f72_Cal_Due_by_Room
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
            this.ClientSize = new System.Drawing.Size(983, 687);
            this.Controls.Add(this.Lrowcount);
            this.Controls.Add(this.bStatus);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.bPrint);
            this.Controls.Add(this.monthCalendarDueAfter);
            this.Controls.Add(this.LdueAfter);
            this.Controls.Add(this.monthCalendarDueB4);
            this.Controls.Add(this.bFilter);
            this.Controls.Add(this.LdueB4);
            this.Controls.Add(this.Lroom);
            this.Controls.Add(this.Lstatus);
            this.Controls.Add(this.comboxRoom);
            this.Controls.Add(this.comboxStatus);
            this.Controls.Add(this.DGV);
            this.Name = "f72_Cal_Due_by_Room";
            this.Text = "f72 Cal Due by Room";
            this.Load += new System.EventHandler(this.f72_Cal_Due_by_Room_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bPrint;
        private System.Windows.Forms.MonthCalendar monthCalendarDueAfter;
        private System.Windows.Forms.Label LdueAfter;
        private System.Windows.Forms.MonthCalendar monthCalendarDueB4;
        private System.Windows.Forms.Button bFilter;
        private System.Windows.Forms.Label LdueB4;
        private System.Windows.Forms.Label Lroom;
        private System.Windows.Forms.Label Lstatus;
        private System.Windows.Forms.ComboBox comboxRoom;
        private System.Windows.Forms.ComboBox comboxStatus;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Button bBack;
        private System.Windows.Forms.Button bStatus;
        private System.Windows.Forms.Label Lrowcount;
    }
}