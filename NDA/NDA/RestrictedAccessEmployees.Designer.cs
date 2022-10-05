namespace NDA
{
    partial class RestrictedAccessEmployees
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbddZygoEmployee = new System.Windows.Forms.ComboBox();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.Badd = new System.Windows.Forms.Button();
            this.Bdelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // cbddZygoEmployee
            // 
            this.cbddZygoEmployee.FormattingEnabled = true;
            this.cbddZygoEmployee.Location = new System.Drawing.Point(145, 46);
            this.cbddZygoEmployee.Name = "cbddZygoEmployee";
            this.cbddZygoEmployee.Size = new System.Drawing.Size(203, 24);
            this.cbddZygoEmployee.TabIndex = 29;
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(155, 118);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersVisible = false;
            this.DGV.Size = new System.Drawing.Size(180, 150);
            this.DGV.TabIndex = 43;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // Badd
            // 
            this.Badd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.Badd.Location = new System.Drawing.Point(31, 30);
            this.Badd.Name = "Badd";
            this.Badd.Size = new System.Drawing.Size(75, 40);
            this.Badd.TabIndex = 44;
            this.Badd.Text = "ADD";
            this.Badd.UseVisualStyleBackColor = false;
            this.Badd.Click += new System.EventHandler(this.Badd_Click);
            // 
            // Bdelete
            // 
            this.Bdelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(89)))), ((int)(((byte)(180)))));
            this.Bdelete.Location = new System.Drawing.Point(385, 30);
            this.Bdelete.Name = "Bdelete";
            this.Bdelete.Size = new System.Drawing.Size(75, 40);
            this.Bdelete.TabIndex = 45;
            this.Bdelete.Text = "DELETE";
            this.Bdelete.UseVisualStyleBackColor = false;
            this.Bdelete.Click += new System.EventHandler(this.Bdelete_Click);
            // 
            // RestrictedAccessEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(89)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(487, 322);
            this.Controls.Add(this.Bdelete);
            this.Controls.Add(this.Badd);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.cbddZygoEmployee);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RestrictedAccessEmployees";
            this.Text = "RestrictedAccessEmployees";
            this.Load += new System.EventHandler(this.RestrictedAccessEmployees_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbddZygoEmployee;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Button Badd;
        private System.Windows.Forms.Button Bdelete;
    }
}