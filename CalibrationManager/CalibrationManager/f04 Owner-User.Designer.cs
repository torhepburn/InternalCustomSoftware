namespace CalibrationManager
{
    partial class f04_Owner
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bAssign = new System.Windows.Forms.Button();
            this.Lbench = new System.Windows.Forms.Label();
            this.DGV1 = new System.Windows.Forms.DataGridView();
            this.DGV2 = new System.Windows.Forms.DataGridView();
            this.lLocation = new System.Windows.Forms.Label();
            this.lEmployee = new System.Windows.Forms.Label();
            this.tbSearchItem = new System.Windows.Forms.TextBox();
            this.bsearchItem = new System.Windows.Forms.Button();
            this.bsearchUserOwner = new System.Windows.Forms.Button();
            this.tbSearchEmployee = new System.Windows.Forms.TextBox();
            this.bSearchEmployee = new System.Windows.Forms.Button();
            this.bBack = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bAssign
            // 
            this.bAssign.BackColor = System.Drawing.Color.White;
            this.bAssign.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAssign.ForeColor = System.Drawing.Color.Black;
            this.bAssign.Location = new System.Drawing.Point(660, 27);
            this.bAssign.Name = "bAssign";
            this.bAssign.Size = new System.Drawing.Size(227, 50);
            this.bAssign.TabIndex = 9;
            this.bAssign.Text = "Assign to Employee";
            this.bAssign.UseVisualStyleBackColor = false;
            this.bAssign.Click += new System.EventHandler(this.bAssign_Click);
            // 
            // Lbench
            // 
            this.Lbench.AutoSize = true;
            this.Lbench.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbench.ForeColor = System.Drawing.Color.White;
            this.Lbench.Location = new System.Drawing.Point(-68, 108);
            this.Lbench.Name = "Lbench";
            this.Lbench.Size = new System.Drawing.Size(0, 24);
            this.Lbench.TabIndex = 7;
            // 
            // DGV1
            // 
            this.DGV1.AllowUserToAddRows = false;
            this.DGV1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.DGV1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV1.ColumnHeadersHeight = 30;
            this.DGV1.Location = new System.Drawing.Point(24, 136);
            this.DGV1.Name = "DGV1";
            this.DGV1.ReadOnly = true;
            this.DGV1.Size = new System.Drawing.Size(505, 315);
            this.DGV1.TabIndex = 10;
            this.DGV1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV1_CellClick);
            // 
            // DGV2
            // 
            this.DGV2.AllowUserToAddRows = false;
            this.DGV2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DGV2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV2.Location = new System.Drawing.Point(22, 133);
            this.DGV2.Name = "DGV2";
            this.DGV2.ReadOnly = true;
            this.DGV2.Size = new System.Drawing.Size(280, 315);
            this.DGV2.TabIndex = 11;
            this.DGV2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV2_CellClick);
            // 
            // lLocation
            // 
            this.lLocation.AutoSize = true;
            this.lLocation.ForeColor = System.Drawing.Color.White;
            this.lLocation.Location = new System.Drawing.Point(51, 27);
            this.lLocation.Name = "lLocation";
            this.lLocation.Size = new System.Drawing.Size(0, 20);
            this.lLocation.TabIndex = 12;
            // 
            // lEmployee
            // 
            this.lEmployee.AutoSize = true;
            this.lEmployee.ForeColor = System.Drawing.Color.White;
            this.lEmployee.Location = new System.Drawing.Point(440, 27);
            this.lEmployee.Name = "lEmployee";
            this.lEmployee.Size = new System.Drawing.Size(0, 20);
            this.lEmployee.TabIndex = 13;
            // 
            // tbSearchItem
            // 
            this.tbSearchItem.Location = new System.Drawing.Point(24, 63);
            this.tbSearchItem.Name = "tbSearchItem";
            this.tbSearchItem.Size = new System.Drawing.Size(163, 26);
            this.tbSearchItem.TabIndex = 14;
            // 
            // bsearchItem
            // 
            this.bsearchItem.BackColor = System.Drawing.Color.Gray;
            this.bsearchItem.Location = new System.Drawing.Point(242, 42);
            this.bsearchItem.Name = "bsearchItem";
            this.bsearchItem.Size = new System.Drawing.Size(116, 69);
            this.bsearchItem.TabIndex = 15;
            this.bsearchItem.Text = "Search Item";
            this.bsearchItem.UseVisualStyleBackColor = false;
            this.bsearchItem.Click += new System.EventHandler(this.bsearchItem_Click);
            // 
            // bsearchUserOwner
            // 
            this.bsearchUserOwner.BackColor = System.Drawing.Color.Gray;
            this.bsearchUserOwner.Location = new System.Drawing.Point(413, 42);
            this.bsearchUserOwner.Name = "bsearchUserOwner";
            this.bsearchUserOwner.Size = new System.Drawing.Size(116, 69);
            this.bsearchUserOwner.TabIndex = 16;
            this.bsearchUserOwner.Text = "Search User/Owner";
            this.bsearchUserOwner.UseVisualStyleBackColor = false;
            this.bsearchUserOwner.Click += new System.EventHandler(this.bsearchUserOwner_Click);
            // 
            // tbSearchEmployee
            // 
            this.tbSearchEmployee.Location = new System.Drawing.Point(22, 60);
            this.tbSearchEmployee.Name = "tbSearchEmployee";
            this.tbSearchEmployee.Size = new System.Drawing.Size(137, 26);
            this.tbSearchEmployee.TabIndex = 17;
            // 
            // bSearchEmployee
            // 
            this.bSearchEmployee.BackColor = System.Drawing.Color.Gray;
            this.bSearchEmployee.Location = new System.Drawing.Point(186, 39);
            this.bSearchEmployee.Name = "bSearchEmployee";
            this.bSearchEmployee.Size = new System.Drawing.Size(116, 69);
            this.bSearchEmployee.TabIndex = 18;
            this.bSearchEmployee.Text = "Search Employee";
            this.bSearchEmployee.UseVisualStyleBackColor = false;
            this.bSearchEmployee.Click += new System.EventHandler(this.bSearchEmployee_Click);
            // 
            // bBack
            // 
            this.bBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(50)))));
            this.bBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBack.Location = new System.Drawing.Point(932, 27);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(59, 504);
            this.bBack.TabIndex = 19;
            this.bBack.Text = "BACK";
            this.bBack.UseVisualStyleBackColor = false;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(20)))));
            this.groupBox1.Controls.Add(this.bsearchUserOwner);
            this.groupBox1.Controls.Add(this.bsearchItem);
            this.groupBox1.Controls.Add(this.tbSearchItem);
            this.groupBox1.Controls.Add(this.DGV1);
            this.groupBox1.Location = new System.Drawing.Point(31, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(542, 474);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(20)))), ((int)(((byte)(0)))));
            this.groupBox2.Controls.Add(this.bSearchEmployee);
            this.groupBox2.Controls.Add(this.tbSearchEmployee);
            this.groupBox2.Controls.Add(this.DGV2);
            this.groupBox2.Location = new System.Drawing.Point(585, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(327, 473);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            // 
            // f04_Owner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1035, 580);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.lEmployee);
            this.Controls.Add(this.lLocation);
            this.Controls.Add(this.bAssign);
            this.Controls.Add(this.Lbench);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "f04_Owner";
            this.Text = "f04 Owner";
            this.Load += new System.EventHandler(this.f04_Owner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bAssign;
        private System.Windows.Forms.Label Lbench;
        private System.Windows.Forms.DataGridView DGV1;
        private System.Windows.Forms.DataGridView DGV2;
        private System.Windows.Forms.Label lLocation;
        private System.Windows.Forms.Label lEmployee;
        private System.Windows.Forms.TextBox tbSearchItem;
        private System.Windows.Forms.Button bsearchItem;
        private System.Windows.Forms.Button bsearchUserOwner;
        private System.Windows.Forms.TextBox tbSearchEmployee;
        private System.Windows.Forms.Button bSearchEmployee;
        private System.Windows.Forms.Button bBack;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}