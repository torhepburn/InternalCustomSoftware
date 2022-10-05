namespace CapacityCalendar
{
    partial class CapacityCalendar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.startCalendar = new System.Windows.Forms.MonthCalendar();
            this.endCalendar = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rbDays = new System.Windows.Forms.RadioButton();
            this.rbWeeks = new System.Windows.Forms.RadioButton();
            this.rbMonths = new System.Windows.Forms.RadioButton();
            this.rbQuarters = new System.Windows.Forms.RadioButton();
            this.bFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(25, 304);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(688, 362);
            this.DGV.TabIndex = 1;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // startCalendar
            // 
            this.startCalendar.Location = new System.Drawing.Point(25, 31);
            this.startCalendar.Name = "startCalendar";
            this.startCalendar.TabIndex = 2;
            // 
            // endCalendar
            // 
            this.endCalendar.Location = new System.Drawing.Point(486, 31);
            this.endCalendar.Name = "endCalendar";
            this.endCalendar.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.label1.Location = new System.Drawing.Point(100, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "START DATE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.label2.Location = new System.Drawing.Point(561, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "END DATE";
            // 
            // rbDays
            // 
            this.rbDays.AutoSize = true;
            this.rbDays.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.rbDays.Location = new System.Drawing.Point(327, 57);
            this.rbDays.Name = "rbDays";
            this.rbDays.Size = new System.Drawing.Size(54, 17);
            this.rbDays.TabIndex = 6;
            this.rbDays.TabStop = true;
            this.rbDays.Text = "DAYS";
            this.rbDays.UseVisualStyleBackColor = false;
            // 
            // rbWeeks
            // 
            this.rbWeeks.AutoSize = true;
            this.rbWeeks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.rbWeeks.Location = new System.Drawing.Point(327, 89);
            this.rbWeeks.Name = "rbWeeks";
            this.rbWeeks.Size = new System.Drawing.Size(64, 17);
            this.rbWeeks.TabIndex = 7;
            this.rbWeeks.TabStop = true;
            this.rbWeeks.Text = "WEEKS";
            this.rbWeeks.UseVisualStyleBackColor = false;
            // 
            // rbMonths
            // 
            this.rbMonths.AutoSize = true;
            this.rbMonths.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.rbMonths.Location = new System.Drawing.Point(327, 122);
            this.rbMonths.Name = "rbMonths";
            this.rbMonths.Size = new System.Drawing.Size(72, 17);
            this.rbMonths.TabIndex = 8;
            this.rbMonths.TabStop = true;
            this.rbMonths.Text = "MONTHS";
            this.rbMonths.UseVisualStyleBackColor = false;
            // 
            // rbQuarters
            // 
            this.rbQuarters.AutoSize = true;
            this.rbQuarters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.rbQuarters.Location = new System.Drawing.Point(327, 156);
            this.rbQuarters.Name = "rbQuarters";
            this.rbQuarters.Size = new System.Drawing.Size(85, 17);
            this.rbQuarters.TabIndex = 9;
            this.rbQuarters.TabStop = true;
            this.rbQuarters.Text = "QUARTERS";
            this.rbQuarters.UseVisualStyleBackColor = false;
            // 
            // bFilter
            // 
            this.bFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(80)))));
            this.bFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bFilter.Location = new System.Drawing.Point(35, 228);
            this.bFilter.Name = "bFilter";
            this.bFilter.Size = new System.Drawing.Size(677, 38);
            this.bFilter.TabIndex = 10;
            this.bFilter.Text = "CLICK TO FILTER DATA";
            this.bFilter.UseVisualStyleBackColor = false;
            this.bFilter.Click += new System.EventHandler(this.bFilter_Click);
            // 
            // CapacityCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(759, 702);
            this.Controls.Add(this.bFilter);
            this.Controls.Add(this.rbQuarters);
            this.Controls.Add(this.rbMonths);
            this.Controls.Add(this.rbWeeks);
            this.Controls.Add(this.rbDays);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.endCalendar);
            this.Controls.Add(this.startCalendar);
            this.Controls.Add(this.DGV);
            this.Name = "CapacityCalendar";
            this.Text = "Capacity Calendar";
            this.Load += new System.EventHandler(this.CapacityCalendar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.MonthCalendar startCalendar;
        private System.Windows.Forms.MonthCalendar endCalendar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbDays;
        private System.Windows.Forms.RadioButton rbWeeks;
        private System.Windows.Forms.RadioButton rbMonths;
        private System.Windows.Forms.RadioButton rbQuarters;
        private System.Windows.Forms.Button bFilter;
    }
}

