namespace OptiTRAK
{
    partial class f1_AddOrder
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
            this.bEnterData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbItemDescription = new System.Windows.Forms.TextBox();
            this.tbItemCode = new System.Windows.Forms.TextBox();
            this.tbPosition = new System.Windows.Forms.TextBox();
            this.tbOrder = new System.Windows.Forms.TextBox();
            this.dtpPl_Dlvry = new System.Windows.Forms.DateTimePicker();
            this.dtpCurr_Req_Dt = new System.Windows.Forms.DateTimePicker();
            this.dtpOrig_Prom_Dt = new System.Windows.Forms.DateTimePicker();
            this.dtpOrder_Date = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.bExit = new System.Windows.Forms.Button();
            this.bNewOrderNumber = new System.Windows.Forms.Button();
            this.cbCustomer = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // bEnterData
            // 
            this.bEnterData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(180)))), ((int)(((byte)(185)))));
            this.bEnterData.Location = new System.Drawing.Point(55, 597);
            this.bEnterData.Name = "bEnterData";
            this.bEnterData.Size = new System.Drawing.Size(198, 72);
            this.bEnterData.TabIndex = 0;
            this.bEnterData.Text = "ENTER DATA";
            this.bEnterData.UseVisualStyleBackColor = false;
            this.bEnterData.Click += new System.EventHandler(this.bEnterData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Customer";
            // 
            // tbItemDescription
            // 
            this.tbItemDescription.Location = new System.Drawing.Point(194, 308);
            this.tbItemDescription.Name = "tbItemDescription";
            this.tbItemDescription.Size = new System.Drawing.Size(209, 26);
            this.tbItemDescription.TabIndex = 3;
            // 
            // tbItemCode
            // 
            this.tbItemCode.Location = new System.Drawing.Point(194, 237);
            this.tbItemCode.Name = "tbItemCode";
            this.tbItemCode.Size = new System.Drawing.Size(209, 26);
            this.tbItemCode.TabIndex = 5;
            // 
            // tbPosition
            // 
            this.tbPosition.Location = new System.Drawing.Point(194, 168);
            this.tbPosition.Name = "tbPosition";
            this.tbPosition.Size = new System.Drawing.Size(209, 26);
            this.tbPosition.TabIndex = 6;
            // 
            // tbOrder
            // 
            this.tbOrder.Enabled = false;
            this.tbOrder.Location = new System.Drawing.Point(194, 30);
            this.tbOrder.Name = "tbOrder";
            this.tbOrder.Size = new System.Drawing.Size(209, 26);
            this.tbOrder.TabIndex = 7;
            // 
            // dtpPl_Dlvry
            // 
            this.dtpPl_Dlvry.CustomFormat = "MM/dd/yyyy";
            this.dtpPl_Dlvry.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPl_Dlvry.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPl_Dlvry.Location = new System.Drawing.Point(301, 377);
            this.dtpPl_Dlvry.Name = "dtpPl_Dlvry";
            this.dtpPl_Dlvry.Size = new System.Drawing.Size(102, 24);
            this.dtpPl_Dlvry.TabIndex = 128;
            // 
            // dtpCurr_Req_Dt
            // 
            this.dtpCurr_Req_Dt.CustomFormat = "MM/dd/yyyy";
            this.dtpCurr_Req_Dt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCurr_Req_Dt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCurr_Req_Dt.Location = new System.Drawing.Point(301, 431);
            this.dtpCurr_Req_Dt.Name = "dtpCurr_Req_Dt";
            this.dtpCurr_Req_Dt.Size = new System.Drawing.Size(102, 24);
            this.dtpCurr_Req_Dt.TabIndex = 129;
            // 
            // dtpOrig_Prom_Dt
            // 
            this.dtpOrig_Prom_Dt.CustomFormat = "MM/dd/yyyy";
            this.dtpOrig_Prom_Dt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpOrig_Prom_Dt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrig_Prom_Dt.Location = new System.Drawing.Point(301, 485);
            this.dtpOrig_Prom_Dt.Name = "dtpOrig_Prom_Dt";
            this.dtpOrig_Prom_Dt.Size = new System.Drawing.Size(102, 24);
            this.dtpOrig_Prom_Dt.TabIndex = 130;
            // 
            // dtpOrder_Date
            // 
            this.dtpOrder_Date.CustomFormat = "MM/dd/yyyy";
            this.dtpOrder_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpOrder_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrder_Date.Location = new System.Drawing.Point(301, 542);
            this.dtpOrder_Date.Name = "dtpOrder_Date";
            this.dtpOrder_Date.Size = new System.Drawing.Size(102, 24);
            this.dtpOrder_Date.TabIndex = 131;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 132;
            this.label2.Text = "Item Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 308);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 20);
            this.label3.TabIndex = 133;
            this.label3.Text = "Item Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 134;
            this.label4.Text = "Position";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 377);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 20);
            this.label5.TabIndex = 135;
            this.label5.Text = "Planned Delivery Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 431);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 20);
            this.label6.TabIndex = 136;
            this.label6.Text = "Current Required Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 485);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(171, 20);
            this.label7.TabIndex = 137;
            this.label7.Text = "Original Promised Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(51, 542);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 20);
            this.label8.TabIndex = 138;
            this.label8.Text = "Order Date";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(56, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 20);
            this.label9.TabIndex = 139;
            this.label9.Text = "Order Number";
            // 
            // bExit
            // 
            this.bExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.bExit.Location = new System.Drawing.Point(301, 597);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(121, 72);
            this.bExit.TabIndex = 140;
            this.bExit.Text = "EXIT";
            this.bExit.UseVisualStyleBackColor = false;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // bNewOrderNumber
            // 
            this.bNewOrderNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(180)))), ((int)(((byte)(55)))));
            this.bNewOrderNumber.Location = new System.Drawing.Point(55, 684);
            this.bNewOrderNumber.Name = "bNewOrderNumber";
            this.bNewOrderNumber.Size = new System.Drawing.Size(367, 39);
            this.bNewOrderNumber.TabIndex = 141;
            this.bNewOrderNumber.Text = "NEW ORDER NUMBER";
            this.bNewOrderNumber.UseVisualStyleBackColor = false;
            this.bNewOrderNumber.Click += new System.EventHandler(this.bNewOrderNumber_Click);
            // 
            // cbCustomer
            // 
            this.cbCustomer.FormattingEnabled = true;
            this.cbCustomer.Location = new System.Drawing.Point(194, 103);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(209, 28);
            this.cbCustomer.TabIndex = 142;
            // 
            // f1_AddOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(180)))), ((int)(((byte)(85)))));
            this.ClientSize = new System.Drawing.Size(492, 744);
            this.Controls.Add(this.cbCustomer);
            this.Controls.Add(this.bNewOrderNumber);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpOrder_Date);
            this.Controls.Add(this.dtpOrig_Prom_Dt);
            this.Controls.Add(this.dtpCurr_Req_Dt);
            this.Controls.Add(this.dtpPl_Dlvry);
            this.Controls.Add(this.tbOrder);
            this.Controls.Add(this.tbPosition);
            this.Controls.Add(this.tbItemCode);
            this.Controls.Add(this.tbItemDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bEnterData);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "f1_AddOrder";
            this.Text = "Add Order";
            this.Load += new System.EventHandler(this.f1_AddOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bEnterData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbItemDescription;
        private System.Windows.Forms.TextBox tbItemCode;
        private System.Windows.Forms.TextBox tbPosition;
        private System.Windows.Forms.TextBox tbOrder;
        private System.Windows.Forms.DateTimePicker dtpPl_Dlvry;
        private System.Windows.Forms.DateTimePicker dtpCurr_Req_Dt;
        private System.Windows.Forms.DateTimePicker dtpOrig_Prom_Dt;
        private System.Windows.Forms.DateTimePicker dtpOrder_Date;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.Button bNewOrderNumber;
        private System.Windows.Forms.ComboBox cbCustomer;
    }
}

