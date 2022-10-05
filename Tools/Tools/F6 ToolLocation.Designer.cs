namespace Tools
{
    partial class F6_ToolLocation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bBack = new System.Windows.Forms.Button();
            this.bSearchDescription = new System.Windows.Forms.Button();
            this.tbSearchLocation = new System.Windows.Forms.TextBox();
            this.bSearchLocation = new System.Windows.Forms.Button();
            this.bsearchItem = new System.Windows.Forms.Button();
            this.tbSearchItem = new System.Windows.Forms.TextBox();
            this.LLocation = new System.Windows.Forms.Label();
            this.LItem = new System.Windows.Forms.Label();
            this.DGV2 = new System.Windows.Forms.DataGridView();
            this.DGV1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bAssign = new System.Windows.Forms.Button();
            this.bAddLocation = new System.Windows.Forms.Button();
            this.bSetupSheet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bBack
            // 
            this.bBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(50)))));
            this.bBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBack.Location = new System.Drawing.Point(919, 31);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(59, 504);
            this.bBack.TabIndex = 36;
            this.bBack.Text = "BACK";
            this.bBack.UseVisualStyleBackColor = false;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
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
            this.bSearchDescription.Visible = false;
            this.bSearchDescription.Click += new System.EventHandler(this.bSearchDescription_Click);
            // 
            // tbSearchLocation
            // 
            this.tbSearchLocation.Location = new System.Drawing.Point(164, 44);
            this.tbSearchLocation.Name = "tbSearchLocation";
            this.tbSearchLocation.Size = new System.Drawing.Size(153, 26);
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
            this.bSearchLocation.Text = "Search Location";
            this.bSearchLocation.UseVisualStyleBackColor = false;
            this.bSearchLocation.Click += new System.EventHandler(this.bSearchLocation_Click);
            // 
            // bsearchItem
            // 
            this.bsearchItem.BackColor = System.Drawing.Color.Gray;
            this.bsearchItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsearchItem.Location = new System.Drawing.Point(232, 25);
            this.bsearchItem.Name = "bsearchItem";
            this.bsearchItem.Size = new System.Drawing.Size(116, 69);
            this.bsearchItem.TabIndex = 26;
            this.bsearchItem.Text = "Search SN";
            this.bsearchItem.UseVisualStyleBackColor = false;
            this.bsearchItem.Click += new System.EventHandler(this.bsearchItem_Click);
            // 
            // tbSearchItem
            // 
            this.tbSearchItem.Location = new System.Drawing.Point(14, 46);
            this.tbSearchItem.Name = "tbSearchItem";
            this.tbSearchItem.Size = new System.Drawing.Size(163, 26);
            this.tbSearchItem.TabIndex = 25;
            // 
            // LLocation
            // 
            this.LLocation.AutoSize = true;
            this.LLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLocation.ForeColor = System.Drawing.Color.Maroon;
            this.LLocation.Location = new System.Drawing.Point(427, 31);
            this.LLocation.Name = "LLocation";
            this.LLocation.Size = new System.Drawing.Size(21, 24);
            this.LLocation.TabIndex = 35;
            this.LLocation.Text = "x";
            // 
            // LItem
            // 
            this.LItem.AutoSize = true;
            this.LItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LItem.ForeColor = System.Drawing.Color.Maroon;
            this.LItem.Location = new System.Drawing.Point(38, 31);
            this.LItem.Name = "LItem";
            this.LItem.Size = new System.Drawing.Size(21, 24);
            this.LItem.TabIndex = 34;
            this.LItem.Text = "x";
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
            this.DGV2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV2_CellContentClick);
            // 
            // DGV1
            // 
            this.DGV1.AllowUserToAddRows = false;
            this.DGV1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.DGV1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV1.Location = new System.Drawing.Point(14, 119);
            this.DGV1.Name = "DGV1";
            this.DGV1.ReadOnly = true;
            this.DGV1.Size = new System.Drawing.Size(334, 315);
            this.DGV1.TabIndex = 21;
            this.DGV1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV1_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(120)))), ((int)(((byte)(160)))));
            this.groupBox2.Controls.Add(this.bsearchItem);
            this.groupBox2.Controls.Add(this.tbSearchItem);
            this.groupBox2.Controls.Add(this.DGV1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox2.Location = new System.Drawing.Point(28, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(362, 456);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.groupBox1.Controls.Add(this.bSearchDescription);
            this.groupBox1.Controls.Add(this.tbSearchLocation);
            this.groupBox1.Controls.Add(this.bSearchLocation);
            this.groupBox1.Controls.Add(this.DGV2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(414, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 455);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            // 
            // bAssign
            // 
            this.bAssign.BackColor = System.Drawing.Color.White;
            this.bAssign.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAssign.ForeColor = System.Drawing.Color.Black;
            this.bAssign.Location = new System.Drawing.Point(647, 31);
            this.bAssign.Name = "bAssign";
            this.bAssign.Size = new System.Drawing.Size(227, 50);
            this.bAssign.TabIndex = 33;
            this.bAssign.Text = "Assign to Location";
            this.bAssign.UseVisualStyleBackColor = false;
            this.bAssign.Click += new System.EventHandler(this.bAssign_Click);
            // 
            // bAddLocation
            // 
            this.bAddLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(180)))), ((int)(((byte)(50)))));
            this.bAddLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAddLocation.ForeColor = System.Drawing.Color.Black;
            this.bAddLocation.Location = new System.Drawing.Point(668, 576);
            this.bAddLocation.Name = "bAddLocation";
            this.bAddLocation.Size = new System.Drawing.Size(227, 50);
            this.bAddLocation.TabIndex = 39;
            this.bAddLocation.Text = "Add Location";
            this.bAddLocation.UseVisualStyleBackColor = false;
            this.bAddLocation.Click += new System.EventHandler(this.bAddLocation_Click);
            // 
            // bSetupSheet
            // 
            this.bSetupSheet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(180)))), ((int)(((byte)(50)))));
            this.bSetupSheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSetupSheet.ForeColor = System.Drawing.Color.Black;
            this.bSetupSheet.Location = new System.Drawing.Point(28, 576);
            this.bSetupSheet.Name = "bSetupSheet";
            this.bSetupSheet.Size = new System.Drawing.Size(227, 50);
            this.bSetupSheet.TabIndex = 40;
            this.bSetupSheet.Text = "Choose Setup Sheet";
            this.bSetupSheet.UseVisualStyleBackColor = false;
            this.bSetupSheet.Click += new System.EventHandler(this.bSetupSheet_Click);
            // 
            // F6_ToolLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(1006, 649);
            this.Controls.Add(this.bSetupSheet);
            this.Controls.Add(this.bAddLocation);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.LLocation);
            this.Controls.Add(this.LItem);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bAssign);
            this.Name = "F6_ToolLocation";
            this.Text = "F6 Tool Location";
            this.Activated += new System.EventHandler(this.F6_ToolLocation_Activated);
            this.Load += new System.EventHandler(this.F6_ToolLocationorm2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bBack;
        private System.Windows.Forms.Button bSearchDescription;
        private System.Windows.Forms.TextBox tbSearchLocation;
        private System.Windows.Forms.Button bSearchLocation;
        private System.Windows.Forms.Button bsearchItem;
        private System.Windows.Forms.TextBox tbSearchItem;
        private System.Windows.Forms.Label LLocation;
        private System.Windows.Forms.Label LItem;
        private System.Windows.Forms.DataGridView DGV2;
        private System.Windows.Forms.DataGridView DGV1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bAssign;
        private System.Windows.Forms.Button bAddLocation;
        private System.Windows.Forms.Button bSetupSheet;
    }
}