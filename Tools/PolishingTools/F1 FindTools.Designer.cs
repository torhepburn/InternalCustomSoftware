namespace PolishingTools
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.bFind = new System.Windows.Forms.Button();
            this.bExit = new System.Windows.Forms.Button();
            this.Ldim2 = new System.Windows.Forms.Label();
            this.Ldim1 = new System.Windows.Forms.Label();
            this.Lshape = new System.Windows.Forms.Label();
            this.tbDim2 = new System.Windows.Forms.TextBox();
            this.tbDim1 = new System.Windows.Forms.TextBox();
            this.cbddShape = new System.Windows.Forms.ComboBox();
            this.cbR144 = new System.Windows.Forms.CheckBox();
            this.cbR96 = new System.Windows.Forms.CheckBox();
            this.cbR48 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
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
            this.DGV.Location = new System.Drawing.Point(81, 198);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.Size = new System.Drawing.Size(768, 377);
            this.DGV.TabIndex = 127;
            // 
            // bFind
            // 
            this.bFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            this.bFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bFind.Location = new System.Drawing.Point(81, 142);
            this.bFind.Name = "bFind";
            this.bFind.Size = new System.Drawing.Size(768, 38);
            this.bFind.TabIndex = 126;
            this.bFind.Text = "FIND";
            this.bFind.UseVisualStyleBackColor = false;
            this.bFind.Click += new System.EventHandler(this.bFind_Click);
            // 
            // bExit
            // 
            this.bExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(100)))), ((int)(((byte)(40)))));
            this.bExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bExit.Location = new System.Drawing.Point(859, 28);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(62, 52);
            this.bExit.TabIndex = 125;
            this.bExit.Text = "EXIT";
            this.bExit.UseVisualStyleBackColor = false;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // Ldim2
            // 
            this.Ldim2.AutoSize = true;
            this.Ldim2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ldim2.ForeColor = System.Drawing.Color.Black;
            this.Ldim2.Location = new System.Drawing.Point(461, 28);
            this.Ldim2.Name = "Ldim2";
            this.Ldim2.Size = new System.Drawing.Size(53, 24);
            this.Ldim2.TabIndex = 123;
            this.Ldim2.Text = "Dim2";
            // 
            // Ldim1
            // 
            this.Ldim1.AutoSize = true;
            this.Ldim1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ldim1.ForeColor = System.Drawing.Color.Black;
            this.Ldim1.Location = new System.Drawing.Point(316, 28);
            this.Ldim1.Name = "Ldim1";
            this.Ldim1.Size = new System.Drawing.Size(53, 24);
            this.Ldim1.TabIndex = 122;
            this.Ldim1.Text = "Dim1";
            // 
            // Lshape
            // 
            this.Lshape.AutoSize = true;
            this.Lshape.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lshape.ForeColor = System.Drawing.Color.Black;
            this.Lshape.Location = new System.Drawing.Point(135, 28);
            this.Lshape.Name = "Lshape";
            this.Lshape.Size = new System.Drawing.Size(65, 24);
            this.Lshape.TabIndex = 121;
            this.Lshape.Text = "Shape";
            // 
            // tbDim2
            // 
            this.tbDim2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbDim2.Location = new System.Drawing.Point(438, 66);
            this.tbDim2.Name = "tbDim2";
            this.tbDim2.Size = new System.Drawing.Size(100, 26);
            this.tbDim2.TabIndex = 119;
            // 
            // tbDim1
            // 
            this.tbDim1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbDim1.Location = new System.Drawing.Point(294, 66);
            this.tbDim1.Name = "tbDim1";
            this.tbDim1.Size = new System.Drawing.Size(100, 26);
            this.tbDim1.TabIndex = 118;
            // 
            // cbddShape
            // 
            this.cbddShape.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cbddShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbddShape.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbddShape.FormattingEnabled = true;
            this.cbddShape.Items.AddRange(new object[] {
            "Circle",
            "Square",
            "Rectangle",
            "Irregular",
            "Ellipse"});
            this.cbddShape.Location = new System.Drawing.Point(108, 64);
            this.cbddShape.Name = "cbddShape";
            this.cbddShape.Size = new System.Drawing.Size(152, 28);
            this.cbddShape.TabIndex = 117;
            this.cbddShape.SelectedIndexChanged += new System.EventHandler(this.cbddShape_SelectedIndexChanged);
            // 
            // cbR144
            // 
            this.cbR144.AutoSize = true;
            this.cbR144.Location = new System.Drawing.Point(570, 38);
            this.cbR144.Name = "cbR144";
            this.cbR144.Size = new System.Drawing.Size(151, 24);
            this.cbR144.TabIndex = 128;
            this.cbR144.Text = "144 Ring Carriers";
            this.cbR144.UseVisualStyleBackColor = true;
            // 
            // cbR96
            // 
            this.cbR96.AutoSize = true;
            this.cbR96.Location = new System.Drawing.Point(570, 68);
            this.cbR96.Name = "cbR96";
            this.cbR96.Size = new System.Drawing.Size(142, 24);
            this.cbR96.TabIndex = 129;
            this.cbR96.Text = "96 Ring Carriers";
            this.cbR96.UseVisualStyleBackColor = true;
            // 
            // cbR48
            // 
            this.cbR48.AutoSize = true;
            this.cbR48.Location = new System.Drawing.Point(570, 98);
            this.cbR48.Name = "cbR48";
            this.cbR48.Size = new System.Drawing.Size(142, 24);
            this.cbR48.TabIndex = 130;
            this.cbR48.Text = "48 Ring Carriers";
            this.cbR48.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(165)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(943, 635);
            this.Controls.Add(this.cbR48);
            this.Controls.Add(this.cbR96);
            this.Controls.Add(this.cbR144);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.bFind);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.Ldim2);
            this.Controls.Add(this.Ldim1);
            this.Controls.Add(this.Lshape);
            this.Controls.Add(this.tbDim2);
            this.Controls.Add(this.tbDim1);
            this.Controls.Add(this.cbddShape);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "F1 FindTools";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Button bFind;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.Label Ldim2;
        private System.Windows.Forms.Label Ldim1;
        private System.Windows.Forms.Label Lshape;
        private System.Windows.Forms.TextBox tbDim2;
        private System.Windows.Forms.TextBox tbDim1;
        private System.Windows.Forms.ComboBox cbddShape;
        private System.Windows.Forms.CheckBox cbR144;
        private System.Windows.Forms.CheckBox cbR96;
        private System.Windows.Forms.CheckBox cbR48;
    }
}

