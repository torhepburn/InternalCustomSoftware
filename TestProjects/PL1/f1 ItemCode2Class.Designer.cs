namespace PL1
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DGV2 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bsearchItem = new System.Windows.Forms.Button();
            this.tbSearchItem = new System.Windows.Forms.TextBox();
            this.DGV1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bSearchDescription = new System.Windows.Forms.Button();
            this.tbSearchLocation = new System.Windows.Forms.TextBox();
            this.bSearchClassCode = new System.Windows.Forms.Button();
            this.bAssign = new System.Windows.Forms.Button();
            this.LLocation = new System.Windows.Forms.Label();
            this.LItem = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGV2
            // 
            this.DGV2.AllowUserToAddRows = false;
            this.DGV2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DGV2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DGV2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV2.Location = new System.Drawing.Point(17, 117);
            this.DGV2.Name = "DGV2";
            this.DGV2.ReadOnly = true;
            this.DGV2.Size = new System.Drawing.Size(443, 315);
            this.DGV2.TabIndex = 22;
            this.DGV2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV2_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(125)))), ((int)(((byte)(165)))));
            this.groupBox2.Controls.Add(this.bsearchItem);
            this.groupBox2.Controls.Add(this.tbSearchItem);
            this.groupBox2.Controls.Add(this.DGV1);
            this.groupBox2.Location = new System.Drawing.Point(43, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(362, 456);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            // 
            // bsearchItem
            // 
            this.bsearchItem.BackColor = System.Drawing.Color.Gray;
            this.bsearchItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsearchItem.Location = new System.Drawing.Point(232, 25);
            this.bsearchItem.Name = "bsearchItem";
            this.bsearchItem.Size = new System.Drawing.Size(116, 69);
            this.bsearchItem.TabIndex = 26;
            this.bsearchItem.Text = "Search Item";
            this.bsearchItem.UseVisualStyleBackColor = false;
            this.bsearchItem.Click += new System.EventHandler(this.bsearchItem_Click);
            // 
            // tbSearchItem
            // 
            this.tbSearchItem.Location = new System.Drawing.Point(14, 46);
            this.tbSearchItem.Name = "tbSearchItem";
            this.tbSearchItem.Size = new System.Drawing.Size(163, 20);
            this.tbSearchItem.TabIndex = 25;
            // 
            // DGV1
            // 
            this.DGV1.AllowUserToAddRows = false;
            this.DGV1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.DGV1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGV1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV1.Location = new System.Drawing.Point(14, 119);
            this.DGV1.Name = "DGV1";
            this.DGV1.ReadOnly = true;
            this.DGV1.Size = new System.Drawing.Size(334, 315);
            this.DGV1.TabIndex = 21;
            this.DGV1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV1_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.groupBox1.Controls.Add(this.bSearchDescription);
            this.groupBox1.Controls.Add(this.tbSearchLocation);
            this.groupBox1.Controls.Add(this.bSearchClassCode);
            this.groupBox1.Controls.Add(this.DGV2);
            this.groupBox1.Location = new System.Drawing.Point(429, 137);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 455);
            this.groupBox1.TabIndex = 37;
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
            this.bSearchDescription.Click += new System.EventHandler(this.bSearchDescription_Click);
            // 
            // tbSearchLocation
            // 
            this.tbSearchLocation.Location = new System.Drawing.Point(164, 44);
            this.tbSearchLocation.Name = "tbSearchLocation";
            this.tbSearchLocation.Size = new System.Drawing.Size(153, 20);
            this.tbSearchLocation.TabIndex = 28;
            // 
            // bSearchClassCode
            // 
            this.bSearchClassCode.BackColor = System.Drawing.Color.Gray;
            this.bSearchClassCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearchClassCode.Location = new System.Drawing.Point(17, 23);
            this.bSearchClassCode.Name = "bSearchClassCode";
            this.bSearchClassCode.Size = new System.Drawing.Size(116, 69);
            this.bSearchClassCode.TabIndex = 27;
            this.bSearchClassCode.Text = "Search Class Code";
            this.bSearchClassCode.UseVisualStyleBackColor = false;
            this.bSearchClassCode.Click += new System.EventHandler(this.bSearchClassCode_Click);
            // 
            // bAssign
            // 
            this.bAssign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(50)))));
            this.bAssign.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAssign.ForeColor = System.Drawing.Color.Black;
            this.bAssign.Location = new System.Drawing.Point(662, 39);
            this.bAssign.Name = "bAssign";
            this.bAssign.Size = new System.Drawing.Size(227, 50);
            this.bAssign.TabIndex = 33;
            this.bAssign.Text = "Assign Class Code";
            this.bAssign.UseVisualStyleBackColor = false;
            this.bAssign.Click += new System.EventHandler(this.bAssign_Click);
            // 
            // LLocation
            // 
            this.LLocation.AutoSize = true;
            this.LLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLocation.ForeColor = System.Drawing.Color.Maroon;
            this.LLocation.Location = new System.Drawing.Point(442, 52);
            this.LLocation.Name = "LLocation";
            this.LLocation.Size = new System.Drawing.Size(0, 24);
            this.LLocation.TabIndex = 35;
            // 
            // LItem
            // 
            this.LItem.AutoSize = true;
            this.LItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LItem.ForeColor = System.Drawing.Color.Maroon;
            this.LItem.Location = new System.Drawing.Point(53, 52);
            this.LItem.Name = "LItem";
            this.LItem.Size = new System.Drawing.Size(0, 24);
            this.LItem.TabIndex = 34;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(200)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(971, 631);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bAssign);
            this.Controls.Add(this.LLocation);
            this.Controls.Add(this.LItem);
            this.Name = "Form1";
            this.Text = "Edit Item Code to Class Relationship";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bsearchItem;
        private System.Windows.Forms.TextBox tbSearchItem;
        private System.Windows.Forms.DataGridView DGV1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bSearchDescription;
        private System.Windows.Forms.TextBox tbSearchLocation;
        private System.Windows.Forms.Button bSearchClassCode;
        private System.Windows.Forms.Button bAssign;
        private System.Windows.Forms.Label LLocation;
        private System.Windows.Forms.Label LItem;

    }
}

