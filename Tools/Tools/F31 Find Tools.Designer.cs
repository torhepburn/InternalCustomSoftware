namespace Tools
{
    partial class F31_Find_Tools
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
            this.cbddType = new System.Windows.Forms.ComboBox();
            this.tbDiameter = new System.Windows.Forms.TextBox();
            this.tbUsableLength = new System.Windows.Forms.TextBox();
            this.cbddGrit = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bExit = new System.Windows.Forms.Button();
            this.bFind = new System.Windows.Forms.Button();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.bPrint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbddTNumber = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // cbddType
            // 
            this.cbddType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cbddType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbddType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbddType.FormattingEnabled = true;
            this.cbddType.Location = new System.Drawing.Point(39, 45);
            this.cbddType.Name = "cbddType";
            this.cbddType.Size = new System.Drawing.Size(152, 28);
            this.cbddType.TabIndex = 69;
            this.cbddType.SelectedIndexChanged += new System.EventHandler(this.cbddType_SelectedIndexChanged);
            // 
            // tbDiameter
            // 
            this.tbDiameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbDiameter.Location = new System.Drawing.Point(225, 47);
            this.tbDiameter.Name = "tbDiameter";
            this.tbDiameter.Size = new System.Drawing.Size(100, 26);
            this.tbDiameter.TabIndex = 70;
            this.tbDiameter.TextChanged += new System.EventHandler(this.tbDiameter_TextChanged);
            // 
            // tbUsableLength
            // 
            this.tbUsableLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbUsableLength.Location = new System.Drawing.Point(369, 47);
            this.tbUsableLength.Name = "tbUsableLength";
            this.tbUsableLength.Size = new System.Drawing.Size(100, 26);
            this.tbUsableLength.TabIndex = 71;
            this.tbUsableLength.TextChanged += new System.EventHandler(this.tbUsableLength_TextChanged);
            // 
            // cbddGrit
            // 
            this.cbddGrit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cbddGrit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbddGrit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbddGrit.FormattingEnabled = true;
            this.cbddGrit.Location = new System.Drawing.Point(517, 47);
            this.cbddGrit.Name = "cbddGrit";
            this.cbddGrit.Size = new System.Drawing.Size(152, 28);
            this.cbddGrit.TabIndex = 72;
            this.cbddGrit.SelectedIndexChanged += new System.EventHandler(this.cbddGrit_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(66, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 24);
            this.label4.TabIndex = 73;
            this.label4.Text = "Tool Type";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(231, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 24);
            this.label7.TabIndex = 74;
            this.label7.Text = "Diameter";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(351, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 24);
            this.label2.TabIndex = 75;
            this.label2.Text = "Usable Length";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(570, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 24);
            this.label3.TabIndex = 76;
            this.label3.Text = "Grit";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // bExit
            // 
            this.bExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(100)))), ((int)(((byte)(40)))));
            this.bExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bExit.Location = new System.Drawing.Point(891, 23);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(62, 52);
            this.bExit.TabIndex = 114;
            this.bExit.Text = "EXIT";
            this.bExit.UseVisualStyleBackColor = false;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // bFind
            // 
            this.bFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            this.bFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bFind.Location = new System.Drawing.Point(12, 95);
            this.bFind.Name = "bFind";
            this.bFind.Size = new System.Drawing.Size(1080, 38);
            this.bFind.TabIndex = 115;
            this.bFind.Text = "FIND";
            this.bFind.UseVisualStyleBackColor = false;
            this.bFind.Click += new System.EventHandler(this.bFind_Click);
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.AllowUserToOrderColumns = true;
            this.DGV.AllowUserToResizeColumns = false;
            this.DGV.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(12, 153);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.Size = new System.Drawing.Size(1080, 171);
            this.DGV.TabIndex = 116;
            this.DGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellContentClick);
            // 
            // bPrint
            // 
            this.bPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(40)))));
            this.bPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPrint.Location = new System.Drawing.Point(984, 23);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(108, 52);
            this.bPrint.TabIndex = 117;
            this.bPrint.Text = "PRINT";
            this.bPrint.UseVisualStyleBackColor = false;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(705, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 24);
            this.label1.TabIndex = 119;
            this.label1.Text = "Tool Number";
            // 
            // cbddTNumber
            // 
            this.cbddTNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cbddTNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbddTNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbddTNumber.FormattingEnabled = true;
            this.cbddTNumber.Location = new System.Drawing.Point(694, 47);
            this.cbddTNumber.Name = "cbddTNumber";
            this.cbddTNumber.Size = new System.Drawing.Size(152, 28);
            this.cbddTNumber.TabIndex = 118;
            // 
            // F31_Find_Tools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1104, 336);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbddTNumber);
            this.Controls.Add(this.bPrint);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.bFind);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbddGrit);
            this.Controls.Add(this.tbUsableLength);
            this.Controls.Add(this.tbDiameter);
            this.Controls.Add(this.cbddType);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "F31_Find_Tools";
            this.Text = "F31_Find_Tools";
            this.Load += new System.EventHandler(this.F31_Find_Tools_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbddType;
        private System.Windows.Forms.TextBox tbDiameter;
        private System.Windows.Forms.TextBox tbUsableLength;
        private System.Windows.Forms.ComboBox cbddGrit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.Button bFind;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Button bPrint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbddTNumber;
    }
}