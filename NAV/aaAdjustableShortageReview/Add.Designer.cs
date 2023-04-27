namespace aaAdjustableShortageReview
{
    partial class Add
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
            this.tbCustomItem = new System.Windows.Forms.TextBox();
            this.Badd = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.cbddPlannerBuyer = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbProjectDescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbProject = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbCustomItem = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbddItemCode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbddGroup = new System.Windows.Forms.ComboBox();
            this.cbStockOut = new System.Windows.Forms.CheckBox();
            this.dtpRequiredDate = new System.Windows.Forms.DateTimePicker();
            this.tbQuantityRequired = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbddProductLine = new System.Windows.Forms.ComboBox();
            this.cbddComments = new System.Windows.Forms.ComboBox();
            this.LshortageEntered = new System.Windows.Forms.Label();
            this.tbPO = new System.Windows.Forms.TextBox();
            this.cbPOEntire = new System.Windows.Forms.CheckBox();
            this.cbHot = new System.Windows.Forms.CheckBox();
            this.tbProdOrder = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbSalesOrder = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpSalesODate = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpShipDate = new System.Windows.Forms.DateTimePicker();
            this.tbSOLineNo = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbCustomItem
            // 
            this.tbCustomItem.Location = new System.Drawing.Point(275, 186);
            this.tbCustomItem.Name = "tbCustomItem";
            this.tbCustomItem.Size = new System.Drawing.Size(234, 23);
            this.tbCustomItem.TabIndex = 51;
            this.tbCustomItem.Visible = false;
            // 
            // Badd
            // 
            this.Badd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(50)))));
            this.Badd.Location = new System.Drawing.Point(165, 709);
            this.Badd.Name = "Badd";
            this.Badd.Size = new System.Drawing.Size(226, 41);
            this.Badd.TabIndex = 50;
            this.Badd.Text = "Add Shortage to List";
            this.Badd.UseVisualStyleBackColor = false;
            this.Badd.Click += new System.EventHandler(this.Badd_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 666);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 17);
            this.label11.TabIndex = 49;
            this.label11.Text = "Planner/Buyer";
            // 
            // cbddPlannerBuyer
            // 
            this.cbddPlannerBuyer.FormattingEnabled = true;
            this.cbddPlannerBuyer.Location = new System.Drawing.Point(165, 663);
            this.cbddPlannerBuyer.Name = "cbddPlannerBuyer";
            this.cbddPlannerBuyer.Size = new System.Drawing.Size(179, 24);
            this.cbddPlannerBuyer.TabIndex = 48;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 627);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 17);
            this.label10.TabIndex = 47;
            this.label10.Text = "Comments";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 580);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 17);
            this.label9.TabIndex = 45;
            this.label9.Text = "Required Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 343);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 17);
            this.label8.TabIndex = 44;
            this.label8.Text = "Project Description";
            // 
            // tbProjectDescription
            // 
            this.tbProjectDescription.Location = new System.Drawing.Point(165, 337);
            this.tbProjectDescription.Name = "tbProjectDescription";
            this.tbProjectDescription.Size = new System.Drawing.Size(344, 23);
            this.tbProjectDescription.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 302);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 17);
            this.label7.TabIndex = 42;
            this.label7.Text = "Project";
            // 
            // tbProject
            // 
            this.tbProject.Location = new System.Drawing.Point(165, 302);
            this.tbProject.Name = "tbProject";
            this.tbProject.Size = new System.Drawing.Size(179, 23);
            this.tbProject.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 382);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 17);
            this.label6.TabIndex = 40;
            this.label6.Text = "Purchase Order";
            // 
            // cbCustomItem
            // 
            this.cbCustomItem.AutoSize = true;
            this.cbCustomItem.Location = new System.Drawing.Point(165, 186);
            this.cbCustomItem.Name = "cbCustomItem";
            this.cbCustomItem.Size = new System.Drawing.Size(104, 21);
            this.cbCustomItem.TabIndex = 38;
            this.cbCustomItem.Text = "Custom Item";
            this.cbCustomItem.UseVisualStyleBackColor = true;
            this.cbCustomItem.CheckedChanged += new System.EventHandler(this.cbCustomItem_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 37;
            this.label5.Text = "Description";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(165, 264);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(344, 23);
            this.tbDescription.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 35;
            this.label4.Text = "Item Code";
            // 
            // cbddItemCode
            // 
            this.cbddItemCode.FormattingEnabled = true;
            this.cbddItemCode.Location = new System.Drawing.Point(165, 225);
            this.cbddItemCode.Name = "cbddItemCode";
            this.cbddItemCode.Size = new System.Drawing.Size(344, 24);
            this.cbddItemCode.TabIndex = 34;
            this.cbddItemCode.SelectedIndexChanged += new System.EventHandler(this.cbddItemCode_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 17);
            this.label3.TabIndex = 33;
            this.label3.Text = "Quantity Required";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 32;
            this.label2.Text = "Group";
            // 
            // cbddGroup
            // 
            this.cbddGroup.FormattingEnabled = true;
            this.cbddGroup.Location = new System.Drawing.Point(165, 68);
            this.cbddGroup.Name = "cbddGroup";
            this.cbddGroup.Size = new System.Drawing.Size(200, 24);
            this.cbddGroup.TabIndex = 31;
            // 
            // cbStockOut
            // 
            this.cbStockOut.AutoSize = true;
            this.cbStockOut.Location = new System.Drawing.Point(165, 108);
            this.cbStockOut.Name = "cbStockOut";
            this.cbStockOut.Size = new System.Drawing.Size(89, 21);
            this.cbStockOut.TabIndex = 30;
            this.cbStockOut.Text = "Stock Out";
            this.cbStockOut.UseVisualStyleBackColor = true;
            // 
            // dtpRequiredDate
            // 
            this.dtpRequiredDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRequiredDate.Location = new System.Drawing.Point(165, 580);
            this.dtpRequiredDate.Name = "dtpRequiredDate";
            this.dtpRequiredDate.Size = new System.Drawing.Size(200, 23);
            this.dtpRequiredDate.TabIndex = 29;
            // 
            // tbQuantityRequired
            // 
            this.tbQuantityRequired.Location = new System.Drawing.Point(165, 144);
            this.tbQuantityRequired.Name = "tbQuantityRequired";
            this.tbQuantityRequired.Size = new System.Drawing.Size(100, 23);
            this.tbQuantityRequired.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "Product Line";
            // 
            // cbddProductLine
            // 
            this.cbddProductLine.FormattingEnabled = true;
            this.cbddProductLine.Items.AddRange(new object[] {
            "INST",
            "PPS",
            "OPT",
            "EPO",
            "ZEOS",
            "SERrpt"});
            this.cbddProductLine.Location = new System.Drawing.Point(165, 30);
            this.cbddProductLine.Name = "cbddProductLine";
            this.cbddProductLine.Size = new System.Drawing.Size(121, 24);
            this.cbddProductLine.TabIndex = 26;
            this.cbddProductLine.SelectedIndexChanged += new System.EventHandler(this.cbddProductLine_SelectedIndexChanged);
            // 
            // cbddComments
            // 
            this.cbddComments.FormattingEnabled = true;
            this.cbddComments.Items.AddRange(new object[] {
            "",
            "Confirm Delivery.",
            "Expedite Delivery.",
            "Pull In."});
            this.cbddComments.Location = new System.Drawing.Point(165, 623);
            this.cbddComments.Name = "cbddComments";
            this.cbddComments.Size = new System.Drawing.Size(344, 24);
            this.cbddComments.TabIndex = 212;
            // 
            // LshortageEntered
            // 
            this.LshortageEntered.AutoSize = true;
            this.LshortageEntered.Location = new System.Drawing.Point(162, 772);
            this.LshortageEntered.Name = "LshortageEntered";
            this.LshortageEntered.Size = new System.Drawing.Size(224, 17);
            this.LshortageEntered.TabIndex = 213;
            this.LshortageEntered.Text = "ShortageID x entered in database.";
            this.LshortageEntered.Visible = false;
            // 
            // tbPO
            // 
            this.tbPO.Location = new System.Drawing.Point(165, 379);
            this.tbPO.Name = "tbPO";
            this.tbPO.Size = new System.Drawing.Size(179, 23);
            this.tbPO.TabIndex = 214;
            // 
            // cbPOEntire
            // 
            this.cbPOEntire.AutoSize = true;
            this.cbPOEntire.Location = new System.Drawing.Point(365, 381);
            this.cbPOEntire.Name = "cbPOEntire";
            this.cbPOEntire.Size = new System.Drawing.Size(149, 21);
            this.cbPOEntire.TabIndex = 215;
            this.cbPOEntire.Text = "Add All Lines of PO";
            this.cbPOEntire.UseVisualStyleBackColor = true;
            // 
            // cbHot
            // 
            this.cbHot.AutoSize = true;
            this.cbHot.Location = new System.Drawing.Point(380, 665);
            this.cbHot.Name = "cbHot";
            this.cbHot.Size = new System.Drawing.Size(49, 21);
            this.cbHot.TabIndex = 216;
            this.cbHot.Text = "Hot";
            this.cbHot.UseVisualStyleBackColor = true;
            // 
            // tbProdOrder
            // 
            this.tbProdOrder.Location = new System.Drawing.Point(166, 420);
            this.tbProdOrder.Name = "tbProdOrder";
            this.tbProdOrder.Size = new System.Drawing.Size(179, 23);
            this.tbProdOrder.TabIndex = 218;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(26, 423);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 17);
            this.label12.TabIndex = 217;
            this.label12.Text = "Production Order";
            // 
            // tbSalesOrder
            // 
            this.tbSalesOrder.Location = new System.Drawing.Point(168, 461);
            this.tbSalesOrder.Name = "tbSalesOrder";
            this.tbSalesOrder.Size = new System.Drawing.Size(118, 23);
            this.tbSalesOrder.TabIndex = 220;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(28, 464);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 17);
            this.label13.TabIndex = 219;
            this.label13.Text = "Sales Order";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(28, 503);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(118, 17);
            this.label14.TabIndex = 222;
            this.label14.Text = "Sales Order Date";
            // 
            // dtpSalesODate
            // 
            this.dtpSalesODate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSalesODate.Location = new System.Drawing.Point(168, 503);
            this.dtpSalesODate.Name = "dtpSalesODate";
            this.dtpSalesODate.Size = new System.Drawing.Size(200, 23);
            this.dtpSalesODate.TabIndex = 221;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(26, 544);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 17);
            this.label15.TabIndex = 224;
            this.label15.Text = "Ship Date";
            // 
            // dtpShipDate
            // 
            this.dtpShipDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpShipDate.Location = new System.Drawing.Point(166, 544);
            this.dtpShipDate.Name = "dtpShipDate";
            this.dtpShipDate.Size = new System.Drawing.Size(200, 23);
            this.dtpShipDate.TabIndex = 223;
            // 
            // tbSOLineNo
            // 
            this.tbSOLineNo.Location = new System.Drawing.Point(396, 461);
            this.tbSOLineNo.Name = "tbSOLineNo";
            this.tbSOLineNo.Size = new System.Drawing.Size(52, 23);
            this.tbSOLineNo.TabIndex = 226;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(302, 464);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(85, 17);
            this.label16.TabIndex = 225;
            this.label16.Text = "SO Line No.";
            // 
            // Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(150)))), ((int)(((byte)(90)))));
            this.ClientSize = new System.Drawing.Size(541, 807);
            this.Controls.Add(this.tbSOLineNo);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dtpShipDate);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dtpSalesODate);
            this.Controls.Add(this.tbSalesOrder);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tbProdOrder);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cbHot);
            this.Controls.Add(this.cbPOEntire);
            this.Controls.Add(this.tbPO);
            this.Controls.Add(this.LshortageEntered);
            this.Controls.Add(this.cbddComments);
            this.Controls.Add(this.tbCustomItem);
            this.Controls.Add(this.Badd);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbddPlannerBuyer);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbProjectDescription);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbProject);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbCustomItem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbddItemCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbddGroup);
            this.Controls.Add(this.cbStockOut);
            this.Controls.Add(this.dtpRequiredDate);
            this.Controls.Add(this.tbQuantityRequired);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbddProductLine);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Add";
            this.Text = "Add";
            this.Load += new System.EventHandler(this.Add_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbCustomItem;
        private System.Windows.Forms.Button Badd;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbddPlannerBuyer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbProjectDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbProject;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbCustomItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbddItemCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbddGroup;
        private System.Windows.Forms.CheckBox cbStockOut;
        private System.Windows.Forms.DateTimePicker dtpRequiredDate;
        private System.Windows.Forms.TextBox tbQuantityRequired;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbddProductLine;
        private System.Windows.Forms.ComboBox cbddComments;
        private System.Windows.Forms.Label LshortageEntered;
        private System.Windows.Forms.TextBox tbPO;
        private System.Windows.Forms.CheckBox cbPOEntire;
        private System.Windows.Forms.CheckBox cbHot;
        private System.Windows.Forms.TextBox tbProdOrder;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbSalesOrder;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpSalesODate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpShipDate;
        private System.Windows.Forms.TextBox tbSOLineNo;
        private System.Windows.Forms.Label label16;
    }
}