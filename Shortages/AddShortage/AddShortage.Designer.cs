namespace AddShortage
{
    partial class AddShortage
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
            this.cbddProductLine = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbQuantityRequired = new System.Windows.Forms.TextBox();
            this.dtpRequiredDate = new System.Windows.Forms.DateTimePicker();
            this.cbStockOut = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbddGroup = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbddItemCode = new System.Windows.Forms.ComboBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbCustomItem = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPoWo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbProject = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbProjectDescription = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbComments = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbddPlannerBuyer = new System.Windows.Forms.ComboBox();
            this.Badd = new System.Windows.Forms.Button();
            this.tbCustomItem = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbddProductLine
            // 
            this.cbddProductLine.FormattingEnabled = true;
            this.cbddProductLine.Items.AddRange(new object[] {
            "INST",
            "PPS",
            "OPT"});
            this.cbddProductLine.Location = new System.Drawing.Point(161, 36);
            this.cbddProductLine.Name = "cbddProductLine";
            this.cbddProductLine.Size = new System.Drawing.Size(121, 24);
            this.cbddProductLine.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Product Line";
            // 
            // tbQuantityRequired
            // 
            this.tbQuantityRequired.Location = new System.Drawing.Point(161, 150);
            this.tbQuantityRequired.Name = "tbQuantityRequired";
            this.tbQuantityRequired.Size = new System.Drawing.Size(100, 23);
            this.tbQuantityRequired.TabIndex = 2;
            // 
            // dtpRequiredDate
            // 
            this.dtpRequiredDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRequiredDate.Location = new System.Drawing.Point(161, 424);
            this.dtpRequiredDate.Name = "dtpRequiredDate";
            this.dtpRequiredDate.Size = new System.Drawing.Size(200, 23);
            this.dtpRequiredDate.TabIndex = 3;
            // 
            // cbStockOut
            // 
            this.cbStockOut.AutoSize = true;
            this.cbStockOut.Location = new System.Drawing.Point(161, 114);
            this.cbStockOut.Name = "cbStockOut";
            this.cbStockOut.Size = new System.Drawing.Size(89, 21);
            this.cbStockOut.TabIndex = 4;
            this.cbStockOut.Text = "Stock Out";
            this.cbStockOut.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Group";
            // 
            // cbddGroup
            // 
            this.cbddGroup.FormattingEnabled = true;
            this.cbddGroup.Location = new System.Drawing.Point(161, 74);
            this.cbddGroup.Name = "cbddGroup";
            this.cbddGroup.Size = new System.Drawing.Size(200, 24);
            this.cbddGroup.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Quantity Required";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Item Code";
            // 
            // cbddItemCode
            // 
            this.cbddItemCode.FormattingEnabled = true;
            this.cbddItemCode.Location = new System.Drawing.Point(161, 231);
            this.cbddItemCode.Name = "cbddItemCode";
            this.cbddItemCode.Size = new System.Drawing.Size(179, 24);
            this.cbddItemCode.TabIndex = 8;
            this.cbddItemCode.SelectedIndexChanged += new System.EventHandler(this.cbddItemCode_SelectedIndexChanged);
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(161, 270);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(344, 23);
            this.tbDescription.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Description";
            // 
            // cbCustomItem
            // 
            this.cbCustomItem.AutoSize = true;
            this.cbCustomItem.Location = new System.Drawing.Point(161, 192);
            this.cbCustomItem.Name = "cbCustomItem";
            this.cbCustomItem.Size = new System.Drawing.Size(104, 21);
            this.cbCustomItem.TabIndex = 12;
            this.cbCustomItem.Text = "Custom Item";
            this.cbCustomItem.UseVisualStyleBackColor = true;
            this.cbCustomItem.CheckedChanged += new System.EventHandler(this.cbCustomItem_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 388);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Purchase Order";
            // 
            // tbPoWo
            // 
            this.tbPoWo.Location = new System.Drawing.Point(161, 382);
            this.tbPoWo.Name = "tbPoWo";
            this.tbPoWo.Size = new System.Drawing.Size(179, 23);
            this.tbPoWo.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 308);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Project";
            // 
            // tbProject
            // 
            this.tbProject.Location = new System.Drawing.Point(161, 308);
            this.tbProject.Name = "tbProject";
            this.tbProject.Size = new System.Drawing.Size(179, 23);
            this.tbProject.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 349);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "Project Description";
            // 
            // tbProjectDescription
            // 
            this.tbProjectDescription.Location = new System.Drawing.Point(161, 343);
            this.tbProjectDescription.Name = "tbProjectDescription";
            this.tbProjectDescription.Size = new System.Drawing.Size(344, 23);
            this.tbProjectDescription.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 424);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 17);
            this.label9.TabIndex = 19;
            this.label9.Text = "Required Date";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 474);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 17);
            this.label10.TabIndex = 21;
            this.label10.Text = "Comments";
            // 
            // tbComments
            // 
            this.tbComments.Location = new System.Drawing.Point(161, 468);
            this.tbComments.Name = "tbComments";
            this.tbComments.Size = new System.Drawing.Size(344, 23);
            this.tbComments.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 510);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 17);
            this.label11.TabIndex = 23;
            this.label11.Text = "Planner/Buyer";
            // 
            // cbddPlannerBuyer
            // 
            this.cbddPlannerBuyer.FormattingEnabled = true;
            this.cbddPlannerBuyer.Location = new System.Drawing.Point(161, 507);
            this.cbddPlannerBuyer.Name = "cbddPlannerBuyer";
            this.cbddPlannerBuyer.Size = new System.Drawing.Size(179, 24);
            this.cbddPlannerBuyer.TabIndex = 22;
            // 
            // Badd
            // 
            this.Badd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(50)))));
            this.Badd.Location = new System.Drawing.Point(161, 553);
            this.Badd.Name = "Badd";
            this.Badd.Size = new System.Drawing.Size(226, 41);
            this.Badd.TabIndex = 24;
            this.Badd.Text = "Add Shortage to List";
            this.Badd.UseVisualStyleBackColor = false;
            this.Badd.Click += new System.EventHandler(this.Badd_Click);
            // 
            // tbCustomItem
            // 
            this.tbCustomItem.Location = new System.Drawing.Point(271, 192);
            this.tbCustomItem.Name = "tbCustomItem";
            this.tbCustomItem.Size = new System.Drawing.Size(171, 23);
            this.tbCustomItem.TabIndex = 25;
            this.tbCustomItem.Visible = false;
            // 
            // AddShortage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(150)))), ((int)(((byte)(90)))));
            this.ClientSize = new System.Drawing.Size(534, 618);
            this.Controls.Add(this.tbCustomItem);
            this.Controls.Add(this.Badd);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbddPlannerBuyer);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbComments);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbProjectDescription);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbProject);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbPoWo);
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
            this.Name = "AddShortage";
            this.Text = "Add Shortage Item";
            this.Load += new System.EventHandler(this.AddShortage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbddProductLine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbQuantityRequired;
        private System.Windows.Forms.DateTimePicker dtpRequiredDate;
        private System.Windows.Forms.CheckBox cbStockOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbddGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbddItemCode;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbCustomItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPoWo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbProject;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbProjectDescription;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbComments;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbddPlannerBuyer;
        private System.Windows.Forms.Button Badd;
        private System.Windows.Forms.TextBox tbCustomItem;
    }
}

