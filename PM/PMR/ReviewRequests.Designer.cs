namespace PMR
{
    partial class ReviewRequests
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
            this.bSearch = new System.Windows.Forms.Button();
            this.bItem = new System.Windows.Forms.Button();
            this.tbSearchEquipment = new System.Windows.Forms.TextBox();
            this.rbOpen = new System.Windows.Forms.RadioButton();
            this.rbClosed = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.cbDDEquipment = new System.Windows.Forms.ComboBox();
            this.cbDDworkRequestNo = new System.Windows.Forms.ComboBox();
            this.cbDDassignedto = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LrecordCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.OrangeRed;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(68, 212);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.Size = new System.Drawing.Size(787, 378);
            this.DGV.TabIndex = 2;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // bSearch
            // 
            this.bSearch.BackColor = System.Drawing.Color.DarkOrange;
            this.bSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearch.Location = new System.Drawing.Point(124, 45);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(103, 53);
            this.bSearch.TabIndex = 6;
            this.bSearch.Text = "FILTER";
            this.bSearch.UseVisualStyleBackColor = false;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // bItem
            // 
            this.bItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.bItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bItem.Location = new System.Drawing.Point(446, 45);
            this.bItem.Name = "bItem";
            this.bItem.Size = new System.Drawing.Size(170, 70);
            this.bItem.TabIndex = 5;
            this.bItem.Text = "GET WORK REFERENCE NUMBER";
            this.bItem.UseVisualStyleBackColor = false;
            this.bItem.Click += new System.EventHandler(this.bItem_Click);
            // 
            // tbSearchEquipment
            // 
            this.tbSearchEquipment.Location = new System.Drawing.Point(241, 58);
            this.tbSearchEquipment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSearchEquipment.Name = "tbSearchEquipment";
            this.tbSearchEquipment.Size = new System.Drawing.Size(192, 20);
            this.tbSearchEquipment.TabIndex = 4;
            // 
            // rbOpen
            // 
            this.rbOpen.AutoSize = true;
            this.rbOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOpen.Location = new System.Drawing.Point(636, 23);
            this.rbOpen.Name = "rbOpen";
            this.rbOpen.Size = new System.Drawing.Size(132, 24);
            this.rbOpen.TabIndex = 7;
            this.rbOpen.TabStop = true;
            this.rbOpen.Text = "Open Tickets";
            this.rbOpen.UseVisualStyleBackColor = true;
            // 
            // rbClosed
            // 
            this.rbClosed.AutoSize = true;
            this.rbClosed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbClosed.Location = new System.Drawing.Point(636, 59);
            this.rbClosed.Name = "rbClosed";
            this.rbClosed.Size = new System.Drawing.Size(144, 24);
            this.rbClosed.TabIndex = 8;
            this.rbClosed.TabStop = true;
            this.rbClosed.Text = "Closed Tickets";
            this.rbClosed.UseVisualStyleBackColor = true;
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAll.Location = new System.Drawing.Point(636, 91);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(109, 24);
            this.rbAll.TabIndex = 9;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "All Tickets";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // cbDDEquipment
            // 
            this.cbDDEquipment.FormattingEnabled = true;
            this.cbDDEquipment.Location = new System.Drawing.Point(124, 130);
            this.cbDDEquipment.Name = "cbDDEquipment";
            this.cbDDEquipment.Size = new System.Drawing.Size(309, 21);
            this.cbDDEquipment.TabIndex = 10;
            this.cbDDEquipment.Text = "Equipment";
            // 
            // cbDDworkRequestNo
            // 
            this.cbDDworkRequestNo.FormattingEnabled = true;
            this.cbDDworkRequestNo.Location = new System.Drawing.Point(124, 157);
            this.cbDDworkRequestNo.Name = "cbDDworkRequestNo";
            this.cbDDworkRequestNo.Size = new System.Drawing.Size(309, 21);
            this.cbDDworkRequestNo.TabIndex = 11;
            this.cbDDworkRequestNo.Text = "Work Request Number";
            // 
            // cbDDassignedto
            // 
            this.cbDDassignedto.FormattingEnabled = true;
            this.cbDDassignedto.Location = new System.Drawing.Point(446, 130);
            this.cbDDassignedto.Name = "cbDDassignedto";
            this.cbDDassignedto.Size = new System.Drawing.Size(309, 21);
            this.cbDDassignedto.TabIndex = 12;
            this.cbDDassignedto.Text = "Assigned To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(773, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Assigned To Filter";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Work Request Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Equipment Filter";
            // 
            // LrecordCount
            // 
            this.LrecordCount.AutoSize = true;
            this.LrecordCount.Location = new System.Drawing.Point(65, 196);
            this.LrecordCount.Name = "LrecordCount";
            this.LrecordCount.Size = new System.Drawing.Size(97, 13);
            this.LrecordCount.TabIndex = 18;
            this.LrecordCount.Text = "RECORD COUNT:";
            // 
            // ReviewRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(75)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(915, 650);
            this.Controls.Add(this.LrecordCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDDassignedto);
            this.Controls.Add(this.cbDDworkRequestNo);
            this.Controls.Add(this.cbDDEquipment);
            this.Controls.Add(this.rbAll);
            this.Controls.Add(this.rbClosed);
            this.Controls.Add(this.rbOpen);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.bItem);
            this.Controls.Add(this.tbSearchEquipment);
            this.Controls.Add(this.DGV);
            this.Name = "ReviewRequests";
            this.Text = "ReviewRequests";
            this.Load += new System.EventHandler(this.ReviewRequests_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.Button bItem;
        private System.Windows.Forms.TextBox tbSearchEquipment;
        private System.Windows.Forms.RadioButton rbOpen;
        private System.Windows.Forms.RadioButton rbClosed;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.ComboBox cbDDEquipment;
        private System.Windows.Forms.ComboBox cbDDworkRequestNo;
        private System.Windows.Forms.ComboBox cbDDassignedto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LrecordCount;
    }
}