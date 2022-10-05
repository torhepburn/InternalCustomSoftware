namespace aaAdjustableShortageReview
{
    partial class AoTest
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
            this.cbHot = new System.Windows.Forms.CheckBox();
            this.cbPOEntire = new System.Windows.Forms.CheckBox();
            this.tbPO = new System.Windows.Forms.TextBox();
            this.LshortageEntered = new System.Windows.Forms.Label();
            this.cbddComments = new System.Windows.Forms.ComboBox();
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
            this.SuspendLayout();
            // 
            // cbHot
            // 
            this.cbHot.AutoSize = true;
            this.cbHot.Location = new System.Drawing.Point(513, 551);
            this.cbHot.Name = "cbHot";
            this.cbHot.Size = new System.Drawing.Size(43, 17);
            this.cbHot.TabIndex = 245;
            this.cbHot.Text = "Hot";
            this.cbHot.UseVisualStyleBackColor = true;
            // 
            // cbPOEntire
            // 
            this.cbPOEntire.AutoSize = true;
            this.cbPOEntire.Location = new System.Drawing.Point(498, 429);
            this.cbPOEntire.Name = "cbPOEntire";
            this.cbPOEntire.Size = new System.Drawing.Size(117, 17);
            this.cbPOEntire.TabIndex = 244;
            this.cbPOEntire.Text = "Add All Lines of PO";
            this.cbPOEntire.UseVisualStyleBackColor = true;
            // 
            // tbPO
            // 
            this.tbPO.Location = new System.Drawing.Point(298, 427);
            this.tbPO.Name = "tbPO";
            this.tbPO.Size = new System.Drawing.Size(179, 20);
            this.tbPO.TabIndex = 243;
            // 
            // LshortageEntered
            // 
            this.LshortageEntered.AutoSize = true;
            this.LshortageEntered.Location = new System.Drawing.Point(295, 658);
            this.LshortageEntered.Name = "LshortageEntered";
            this.LshortageEntered.Size = new System.Drawing.Size(169, 13);
            this.LshortageEntered.TabIndex = 242;
            this.LshortageEntered.Text = "ShortageID x entered in database.";
            this.LshortageEntered.Visible = false;
            // 
            // cbddComments
            // 
            this.cbddComments.FormattingEnabled = true;
            this.cbddComments.Items.AddRange(new object[] {
            "",
            "Confirm Delivery.",
            "Expedite Delivery.",
            "Pull In."});
            this.cbddComments.Location = new System.Drawing.Point(298, 509);
            this.cbddComments.Name = "cbddComments";
            this.cbddComments.Size = new System.Drawing.Size(344, 21);
            this.cbddComments.TabIndex = 241;
            // 
            // tbCustomItem
            // 
            this.tbCustomItem.Location = new System.Drawing.Point(408, 234);
            this.tbCustomItem.Name = "tbCustomItem";
            this.tbCustomItem.Size = new System.Drawing.Size(234, 20);
            this.tbCustomItem.TabIndex = 240;
            this.tbCustomItem.Visible = false;
            // 
            // Badd
            // 
            this.Badd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(50)))));
            this.Badd.Location = new System.Drawing.Point(298, 595);
            this.Badd.Name = "Badd";
            this.Badd.Size = new System.Drawing.Size(226, 41);
            this.Badd.TabIndex = 239;
            this.Badd.Text = "Add Shortage to List";
            this.Badd.UseVisualStyleBackColor = false;
            this.Badd.Click += new System.EventHandler(this.Badd_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(158, 552);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 13);
            this.label11.TabIndex = 238;
            this.label11.Text = "Planner/Buyer";
            // 
            // cbddPlannerBuyer
            // 
            this.cbddPlannerBuyer.FormattingEnabled = true;
            this.cbddPlannerBuyer.Location = new System.Drawing.Point(298, 549);
            this.cbddPlannerBuyer.Name = "cbddPlannerBuyer";
            this.cbddPlannerBuyer.Size = new System.Drawing.Size(179, 21);
            this.cbddPlannerBuyer.TabIndex = 237;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(158, 516);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 236;
            this.label10.Text = "Comments";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(158, 466);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 235;
            this.label9.Text = "Required Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(158, 391);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 234;
            this.label8.Text = "Project Description";
            // 
            // tbProjectDescription
            // 
            this.tbProjectDescription.Location = new System.Drawing.Point(298, 385);
            this.tbProjectDescription.Name = "tbProjectDescription";
            this.tbProjectDescription.Size = new System.Drawing.Size(344, 20);
            this.tbProjectDescription.TabIndex = 233;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(158, 350);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 232;
            this.label7.Text = "Project";
            // 
            // tbProject
            // 
            this.tbProject.Location = new System.Drawing.Point(298, 350);
            this.tbProject.Name = "tbProject";
            this.tbProject.Size = new System.Drawing.Size(179, 20);
            this.tbProject.TabIndex = 231;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(158, 430);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 230;
            this.label6.Text = "Purchase Order";
            // 
            // cbCustomItem
            // 
            this.cbCustomItem.AutoSize = true;
            this.cbCustomItem.Location = new System.Drawing.Point(298, 234);
            this.cbCustomItem.Name = "cbCustomItem";
            this.cbCustomItem.Size = new System.Drawing.Size(84, 17);
            this.cbCustomItem.TabIndex = 229;
            this.cbCustomItem.Text = "Custom Item";
            this.cbCustomItem.UseVisualStyleBackColor = true;
            this.cbCustomItem.CheckedChanged += new System.EventHandler(this.cbCustomItem_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(158, 315);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 228;
            this.label5.Text = "Description";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(298, 312);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(344, 20);
            this.tbDescription.TabIndex = 227;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 226;
            this.label4.Text = "Item Code";
            // 
            // cbddItemCode
            // 
            this.cbddItemCode.FormattingEnabled = true;
            this.cbddItemCode.Location = new System.Drawing.Point(298, 273);
            this.cbddItemCode.Name = "cbddItemCode";
            this.cbddItemCode.Size = new System.Drawing.Size(344, 21);
            this.cbddItemCode.TabIndex = 225;
            this.cbddItemCode.SelectedIndexChanged += new System.EventHandler(this.cbddItemCode_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 224;
            this.label3.Text = "Quantity Required";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 223;
            this.label2.Text = "Group";
            // 
            // cbddGroup
            // 
            this.cbddGroup.FormattingEnabled = true;
            this.cbddGroup.Location = new System.Drawing.Point(298, 116);
            this.cbddGroup.Name = "cbddGroup";
            this.cbddGroup.Size = new System.Drawing.Size(200, 21);
            this.cbddGroup.TabIndex = 222;
            // 
            // cbStockOut
            // 
            this.cbStockOut.AutoSize = true;
            this.cbStockOut.Location = new System.Drawing.Point(298, 156);
            this.cbStockOut.Name = "cbStockOut";
            this.cbStockOut.Size = new System.Drawing.Size(74, 17);
            this.cbStockOut.TabIndex = 221;
            this.cbStockOut.Text = "Stock Out";
            this.cbStockOut.UseVisualStyleBackColor = true;
            // 
            // dtpRequiredDate
            // 
            this.dtpRequiredDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRequiredDate.Location = new System.Drawing.Point(298, 466);
            this.dtpRequiredDate.Name = "dtpRequiredDate";
            this.dtpRequiredDate.Size = new System.Drawing.Size(200, 20);
            this.dtpRequiredDate.TabIndex = 220;
            // 
            // tbQuantityRequired
            // 
            this.tbQuantityRequired.Location = new System.Drawing.Point(298, 192);
            this.tbQuantityRequired.Name = "tbQuantityRequired";
            this.tbQuantityRequired.Size = new System.Drawing.Size(100, 20);
            this.tbQuantityRequired.TabIndex = 219;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 247;
            this.label1.Text = "Product Line";
            // 
            // cbddProductLine
            // 
            this.cbddProductLine.FormattingEnabled = true;
            this.cbddProductLine.Items.AddRange(new object[] {
            "INST",
            "PPS",
            "OPT",
            "ZEOS",
            "WAR"});
            this.cbddProductLine.Location = new System.Drawing.Point(152, 21);
            this.cbddProductLine.Name = "cbddProductLine";
            this.cbddProductLine.Size = new System.Drawing.Size(121, 21);
            this.cbddProductLine.TabIndex = 246;
            // 
            // AoTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 748);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbddProductLine);
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
            this.Name = "AoTest";
            this.Text = "AoTest";
            this.Load += new System.EventHandler(this.AoTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbHot;
        private System.Windows.Forms.CheckBox cbPOEntire;
        private System.Windows.Forms.TextBox tbPO;
        private System.Windows.Forms.Label LshortageEntered;
        private System.Windows.Forms.ComboBox cbddComments;
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
    }
}