namespace EditStatus
{
    partial class EditStatus
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
            this.bSearch = new System.Windows.Forms.Button();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.DGV2 = new System.Windows.Forms.DataGridView();
            this.tbCustomer = new System.Windows.Forms.TextBox();
            this.tbProject = new System.Windows.Forms.TextBox();
            this.tbElement = new System.Windows.Forms.TextBox();
            this.tbSFO = new System.Windows.Forms.TextBox();
            this.tbPartID = new System.Windows.Forms.TextBox();
            this.tbTravelerRev = new System.Windows.Forms.TextBox();
            this.Lholdstatus = new System.Windows.Forms.Label();
            this.bSave = new System.Windows.Forms.Button();
            this.cbHoldStatus = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).BeginInit();
            this.SuspendLayout();
            // 
            // bSearch
            // 
            this.bSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(180)))), ((int)(((byte)(80)))));
            this.bSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearch.Location = new System.Drawing.Point(257, 30);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(103, 53);
            this.bSearch.TabIndex = 11;
            this.bSearch.Text = "SEARCH PATTERN";
            this.bSearch.UseVisualStyleBackColor = false;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.OrangeRed;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(23, 116);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersWidth = 20;
            this.DGV.Size = new System.Drawing.Size(869, 100);
            this.DGV.TabIndex = 9;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(374, 43);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(192, 23);
            this.tbSearch.TabIndex = 8;
            // 
            // DGV2
            // 
            this.DGV2.AllowUserToAddRows = false;
            this.DGV2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.OrangeRed;
            this.DGV2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV2.Location = new System.Drawing.Point(23, 285);
            this.DGV2.Name = "DGV2";
            this.DGV2.ReadOnly = true;
            this.DGV2.RowHeadersWidth = 20;
            this.DGV2.Size = new System.Drawing.Size(869, 251);
            this.DGV2.TabIndex = 12;
            this.DGV2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV2_CellClick);
            // 
            // tbCustomer
            // 
            this.tbCustomer.Location = new System.Drawing.Point(23, 239);
            this.tbCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCustomer.Name = "tbCustomer";
            this.tbCustomer.Size = new System.Drawing.Size(138, 23);
            this.tbCustomer.TabIndex = 13;
            // 
            // tbProject
            // 
            this.tbProject.Location = new System.Drawing.Point(169, 239);
            this.tbProject.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbProject.Name = "tbProject";
            this.tbProject.Size = new System.Drawing.Size(192, 23);
            this.tbProject.TabIndex = 14;
            // 
            // tbElement
            // 
            this.tbElement.Location = new System.Drawing.Point(369, 239);
            this.tbElement.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbElement.Name = "tbElement";
            this.tbElement.Size = new System.Drawing.Size(218, 23);
            this.tbElement.TabIndex = 15;
            // 
            // tbSFO
            // 
            this.tbSFO.Location = new System.Drawing.Point(595, 239);
            this.tbSFO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSFO.Name = "tbSFO";
            this.tbSFO.Size = new System.Drawing.Size(98, 23);
            this.tbSFO.TabIndex = 16;
            // 
            // tbPartID
            // 
            this.tbPartID.Location = new System.Drawing.Point(701, 239);
            this.tbPartID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPartID.Name = "tbPartID";
            this.tbPartID.Size = new System.Drawing.Size(71, 23);
            this.tbPartID.TabIndex = 17;
            // 
            // tbTravelerRev
            // 
            this.tbTravelerRev.Location = new System.Drawing.Point(780, 239);
            this.tbTravelerRev.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbTravelerRev.Name = "tbTravelerRev";
            this.tbTravelerRev.Size = new System.Drawing.Size(71, 23);
            this.tbTravelerRev.TabIndex = 18;
            // 
            // Lholdstatus
            // 
            this.Lholdstatus.AutoSize = true;
            this.Lholdstatus.Location = new System.Drawing.Point(199, 575);
            this.Lholdstatus.Name = "Lholdstatus";
            this.Lholdstatus.Size = new System.Drawing.Size(122, 17);
            this.Lholdstatus.TabIndex = 20;
            this.Lholdstatus.Text = "Add Hold Status : ";
            // 
            // bSave
            // 
            this.bSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(0)))));
            this.bSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSave.Location = new System.Drawing.Point(627, 561);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(245, 53);
            this.bSave.TabIndex = 21;
            this.bSave.Text = "ENTER HOLD STATUS";
            this.bSave.UseVisualStyleBackColor = false;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // cbHoldStatus
            // 
            this.cbHoldStatus.FormattingEnabled = true;
            this.cbHoldStatus.Location = new System.Drawing.Point(327, 572);
            this.cbHoldStatus.Name = "cbHoldStatus";
            this.cbHoldStatus.Size = new System.Drawing.Size(260, 24);
            this.cbHoldStatus.TabIndex = 22;
            // 
            // EditStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(240)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(915, 626);
            this.Controls.Add(this.cbHoldStatus);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.Lholdstatus);
            this.Controls.Add(this.tbTravelerRev);
            this.Controls.Add(this.tbPartID);
            this.Controls.Add(this.tbSFO);
            this.Controls.Add(this.tbElement);
            this.Controls.Add(this.tbProject);
            this.Controls.Add(this.tbCustomer);
            this.Controls.Add(this.DGV2);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.tbSearch);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EditStatus";
            this.Text = "Edit Status";
            this.Load += new System.EventHandler(this.EditStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.DataGridView DGV2;
        private System.Windows.Forms.TextBox tbCustomer;
        private System.Windows.Forms.TextBox tbProject;
        private System.Windows.Forms.TextBox tbElement;
        private System.Windows.Forms.TextBox tbSFO;
        private System.Windows.Forms.TextBox tbPartID;
        private System.Windows.Forms.TextBox tbTravelerRev;
        private System.Windows.Forms.Label Lholdstatus;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.ComboBox cbHoldStatus;
    }
}

