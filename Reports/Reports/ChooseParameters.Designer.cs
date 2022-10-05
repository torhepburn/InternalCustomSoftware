namespace Reports
{
    partial class ChooseParameters
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
            this.BviewReport = new System.Windows.Forms.Button();
            this.rbItemCode = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rbProductionDate = new System.Windows.Forms.RadioButton();
            this.rbDeliveryDate = new System.Windows.Forms.RadioButton();
            this.rbOrderNo = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.endCalendar = new System.Windows.Forms.MonthCalendar();
            this.startCalendar = new System.Windows.Forms.MonthCalendar();
            this.cbDateRange = new System.Windows.Forms.CheckBox();
            this.cbddWarehouse = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rbPlanner = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // BviewReport
            // 
            this.BviewReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(230)))), ((int)(((byte)(100)))));
            this.BviewReport.Location = new System.Drawing.Point(340, 604);
            this.BviewReport.Name = "BviewReport";
            this.BviewReport.Size = new System.Drawing.Size(150, 63);
            this.BviewReport.TabIndex = 0;
            this.BviewReport.Text = "View Report";
            this.BviewReport.UseVisualStyleBackColor = false;
            this.BviewReport.Click += new System.EventHandler(this.BviewReport_Click);
            // 
            // rbItemCode
            // 
            this.rbItemCode.AutoSize = true;
            this.rbItemCode.Location = new System.Drawing.Point(147, 75);
            this.rbItemCode.Name = "rbItemCode";
            this.rbItemCode.Size = new System.Drawing.Size(165, 24);
            this.rbItemCode.TabIndex = 1;
            this.rbItemCode.TabStop = true;
            this.rbItemCode.Text = "Order by Item Code";
            this.rbItemCode.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select report order  and click on button.";
            // 
            // rbProductionDate
            // 
            this.rbProductionDate.AutoSize = true;
            this.rbProductionDate.Location = new System.Drawing.Point(147, 105);
            this.rbProductionDate.Name = "rbProductionDate";
            this.rbProductionDate.Size = new System.Drawing.Size(206, 24);
            this.rbProductionDate.TabIndex = 4;
            this.rbProductionDate.TabStop = true;
            this.rbProductionDate.Text = "Order by Production Date";
            this.rbProductionDate.UseVisualStyleBackColor = true;
            // 
            // rbDeliveryDate
            // 
            this.rbDeliveryDate.AutoSize = true;
            this.rbDeliveryDate.Location = new System.Drawing.Point(147, 135);
            this.rbDeliveryDate.Name = "rbDeliveryDate";
            this.rbDeliveryDate.Size = new System.Drawing.Size(185, 24);
            this.rbDeliveryDate.TabIndex = 5;
            this.rbDeliveryDate.TabStop = true;
            this.rbDeliveryDate.Text = "Order by Delivery Date";
            this.rbDeliveryDate.UseVisualStyleBackColor = true;
            // 
            // rbOrderNo
            // 
            this.rbOrderNo.AutoSize = true;
            this.rbOrderNo.Location = new System.Drawing.Point(147, 45);
            this.rbOrderNo.Name = "rbOrderNo";
            this.rbOrderNo.Size = new System.Drawing.Size(191, 24);
            this.rbOrderNo.TabIndex = 6;
            this.rbOrderNo.TabStop = true;
            this.rbOrderNo.Text = "Order by Order Number";
            this.rbOrderNo.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.label2.Location = new System.Drawing.Point(89, 448);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "END DATE";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.label3.Location = new System.Drawing.Point(93, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "START DATE";
            this.label3.Visible = false;
            // 
            // endCalendar
            // 
            this.endCalendar.Location = new System.Drawing.Point(18, 470);
            this.endCalendar.Name = "endCalendar";
            this.endCalendar.TabIndex = 11;
            this.endCalendar.Visible = false;
            // 
            // startCalendar
            // 
            this.startCalendar.Location = new System.Drawing.Point(18, 265);
            this.startCalendar.Name = "startCalendar";
            this.startCalendar.TabIndex = 10;
            this.startCalendar.Visible = false;
            // 
            // cbDateRange
            // 
            this.cbDateRange.AutoSize = true;
            this.cbDateRange.Location = new System.Drawing.Point(31, 209);
            this.cbDateRange.Name = "cbDateRange";
            this.cbDateRange.Size = new System.Drawing.Size(148, 24);
            this.cbDateRange.TabIndex = 14;
            this.cbDateRange.Text = "Use Date Range";
            this.cbDateRange.UseVisualStyleBackColor = true;
            this.cbDateRange.CheckedChanged += new System.EventHandler(this.cbDateRange_CheckedChanged);
            // 
            // cbddWarehouse
            // 
            this.cbddWarehouse.FormattingEnabled = true;
            this.cbddWarehouse.Location = new System.Drawing.Point(318, 265);
            this.cbddWarehouse.Name = "cbddWarehouse";
            this.cbddWarehouse.Size = new System.Drawing.Size(121, 28);
            this.cbddWarehouse.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(245, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Select Warehouse or leave blank.";
            // 
            // rbPlanner
            // 
            this.rbPlanner.AutoSize = true;
            this.rbPlanner.Location = new System.Drawing.Point(147, 165);
            this.rbPlanner.Name = "rbPlanner";
            this.rbPlanner.Size = new System.Drawing.Size(145, 24);
            this.rbPlanner.TabIndex = 17;
            this.rbPlanner.TabStop = true;
            this.rbPlanner.Text = "Order by Planner";
            this.rbPlanner.UseVisualStyleBackColor = true;
            // 
            // ChooseParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(230)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(509, 693);
            this.Controls.Add(this.rbPlanner);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbddWarehouse);
            this.Controls.Add(this.cbDateRange);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.endCalendar);
            this.Controls.Add(this.startCalendar);
            this.Controls.Add(this.rbOrderNo);
            this.Controls.Add(this.rbDeliveryDate);
            this.Controls.Add(this.rbProductionDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbItemCode);
            this.Controls.Add(this.BviewReport);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ChooseParameters";
            this.Text = "ChooseParameters";
            this.Load += new System.EventHandler(this.ChooseParameters_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BviewReport;
        private System.Windows.Forms.RadioButton rbItemCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbProductionDate;
        private System.Windows.Forms.RadioButton rbDeliveryDate;
        private System.Windows.Forms.RadioButton rbOrderNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MonthCalendar endCalendar;
        private System.Windows.Forms.MonthCalendar startCalendar;
        private System.Windows.Forms.CheckBox cbDateRange;
        private System.Windows.Forms.ComboBox cbddWarehouse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbPlanner;
    }
}