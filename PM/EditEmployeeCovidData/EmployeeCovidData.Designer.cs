namespace EditEmployeeCovidData
{
    partial class EmployeeCovidData
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
            this.bSearch = new System.Windows.Forms.Button();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.tbSearchEquipment = new System.Windows.Forms.TextBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.bUpdate = new System.Windows.Forms.Button();
            this.tbTestDate = new System.Windows.Forms.TextBox();
            this.bContractors = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // bSearch
            // 
            this.bSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(124)))));
            this.bSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearch.Location = new System.Drawing.Point(74, 33);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(103, 53);
            this.bSearch.TabIndex = 7;
            this.bSearch.Text = "SEARCH PATTERN";
            this.bSearch.UseVisualStyleBackColor = false;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Green;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(74, 118);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersWidth = 12;
            this.DGV.Size = new System.Drawing.Size(437, 306);
            this.DGV.TabIndex = 5;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            this.DGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellContentClick);
            // 
            // tbSearchEquipment
            // 
            this.tbSearchEquipment.Location = new System.Drawing.Point(191, 46);
            this.tbSearchEquipment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSearchEquipment.Name = "tbSearchEquipment";
            this.tbSearchEquipment.Size = new System.Drawing.Size(192, 23);
            this.tbSearchEquipment.TabIndex = 4;
            this.tbSearchEquipment.TextChanged += new System.EventHandler(this.tbSearchEquipment_TextChanged);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(91, 446);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 8;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // bUpdate
            // 
            this.bUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bUpdate.Location = new System.Drawing.Point(395, 542);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(103, 53);
            this.bUpdate.TabIndex = 9;
            this.bUpdate.Text = "UPDATE";
            this.bUpdate.UseVisualStyleBackColor = true;
            this.bUpdate.Click += new System.EventHandler(this.bUpdate_Click);
            // 
            // tbTestDate
            // 
            this.tbTestDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbTestDate.Location = new System.Drawing.Point(401, 474);
            this.tbTestDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbTestDate.Name = "tbTestDate";
            this.tbTestDate.Size = new System.Drawing.Size(97, 26);
            this.tbTestDate.TabIndex = 10;
            this.tbTestDate.TextChanged += new System.EventHandler(this.tbTestDate_TextChanged);
            // 
            // bContractors
            // 
            this.bContractors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(240)))));
            this.bContractors.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bContractors.Location = new System.Drawing.Point(110, 635);
            this.bContractors.Name = "bContractors";
            this.bContractors.Size = new System.Drawing.Size(173, 53);
            this.bContractors.TabIndex = 11;
            this.bContractors.Text = "Contractors";
            this.bContractors.UseVisualStyleBackColor = false;
            this.bContractors.Click += new System.EventHandler(this.bContractors_Click);
            // 
            // EmployeeCovidData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(180)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1008, 723);
            this.Controls.Add(this.bContractors);
            this.Controls.Add(this.tbTestDate);
            this.Controls.Add(this.bUpdate);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.tbSearchEquipment);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EmployeeCovidData";
            this.Text = "Employee COVID Data";
            this.Load += new System.EventHandler(this.EmployeeCovidData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.TextBox tbSearchEquipment;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.TextBox tbTestDate;
        private System.Windows.Forms.Button bContractors;
    }
}

