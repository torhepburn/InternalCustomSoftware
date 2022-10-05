namespace BOMRoutings
{
    partial class Routing
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
            this.DGV = new System.Windows.Forms.DataGridView();
            this.DGVright = new System.Windows.Forms.DataGridView();
            this.LcurrentRunTime = new System.Windows.Forms.Label();
            this.LcurrentSetupTime = new System.Windows.Forms.Label();
            this.LproposedSetupTime = new System.Windows.Forms.Label();
            this.LproposedRunTime = new System.Windows.Forms.Label();
            this.LRoutingTimesDiffer = new System.Windows.Forms.Label();
            this.BAddOp = new System.Windows.Forms.Button();
            this.BDeleteOp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVright)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.OrangeRed;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(210)))), ((int)(((byte)(100)))));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(48, 74);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersVisible = false;
            this.DGV.Size = new System.Drawing.Size(375, 375);
            this.DGV.TabIndex = 20;
            // 
            // DGVright
            // 
            this.DGVright.AllowUserToAddRows = false;
            this.DGVright.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.OrangeRed;
            this.DGVright.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVright.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(210)))), ((int)(((byte)(100)))));
            this.DGVright.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVright.Location = new System.Drawing.Point(475, 74);
            this.DGVright.Name = "DGVright";
            this.DGVright.RowHeadersVisible = false;
            this.DGVright.Size = new System.Drawing.Size(375, 375);
            this.DGVright.TabIndex = 21;
            this.DGVright.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVright_CellClick);
            // 
            // LcurrentRunTime
            // 
            this.LcurrentRunTime.AutoSize = true;
            this.LcurrentRunTime.Location = new System.Drawing.Point(45, 504);
            this.LcurrentRunTime.Name = "LcurrentRunTime";
            this.LcurrentRunTime.Size = new System.Drawing.Size(34, 17);
            this.LcurrentRunTime.TabIndex = 22;
            this.LcurrentRunTime.Text = "Run";
            // 
            // LcurrentSetupTime
            // 
            this.LcurrentSetupTime.AutoSize = true;
            this.LcurrentSetupTime.Location = new System.Drawing.Point(45, 473);
            this.LcurrentSetupTime.Name = "LcurrentSetupTime";
            this.LcurrentSetupTime.Size = new System.Drawing.Size(45, 17);
            this.LcurrentSetupTime.TabIndex = 23;
            this.LcurrentSetupTime.Text = "Setup";
            // 
            // LproposedSetupTime
            // 
            this.LproposedSetupTime.AutoSize = true;
            this.LproposedSetupTime.Location = new System.Drawing.Point(515, 473);
            this.LproposedSetupTime.Name = "LproposedSetupTime";
            this.LproposedSetupTime.Size = new System.Drawing.Size(110, 17);
            this.LproposedSetupTime.TabIndex = 25;
            this.LproposedSetupTime.Text = "Proposed Setup";
            // 
            // LproposedRunTime
            // 
            this.LproposedRunTime.AutoSize = true;
            this.LproposedRunTime.Location = new System.Drawing.Point(515, 504);
            this.LproposedRunTime.Name = "LproposedRunTime";
            this.LproposedRunTime.Size = new System.Drawing.Size(99, 17);
            this.LproposedRunTime.TabIndex = 24;
            this.LproposedRunTime.Text = "Proposed Run";
            // 
            // LRoutingTimesDiffer
            // 
            this.LRoutingTimesDiffer.AutoSize = true;
            this.LRoutingTimesDiffer.Location = new System.Drawing.Point(265, 27);
            this.LRoutingTimesDiffer.Name = "LRoutingTimesDiffer";
            this.LRoutingTimesDiffer.Size = new System.Drawing.Size(254, 17);
            this.LRoutingTimesDiffer.TabIndex = 26;
            this.LRoutingTimesDiffer.Text = "WARNING:  Total Routing Times Differ!";
            this.LRoutingTimesDiffer.Visible = false;
            // 
            // BAddOp
            // 
            this.BAddOp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(240)))), ((int)(((byte)(180)))));
            this.BAddOp.Enabled = false;
            this.BAddOp.Location = new System.Drawing.Point(560, 12);
            this.BAddOp.Name = "BAddOp";
            this.BAddOp.Size = new System.Drawing.Size(101, 56);
            this.BAddOp.TabIndex = 27;
            this.BAddOp.Text = "Add Operation";
            this.BAddOp.UseVisualStyleBackColor = false;
            this.BAddOp.Click += new System.EventHandler(this.BaddOp_Click);
            // 
            // BDeleteOp
            // 
            this.BDeleteOp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(160)))), ((int)(((byte)(180)))));
            this.BDeleteOp.Enabled = false;
            this.BDeleteOp.Location = new System.Drawing.Point(681, 12);
            this.BDeleteOp.Name = "BDeleteOp";
            this.BDeleteOp.Size = new System.Drawing.Size(101, 56);
            this.BDeleteOp.TabIndex = 28;
            this.BDeleteOp.Text = "Delete Operation";
            this.BDeleteOp.UseVisualStyleBackColor = false;
            this.BDeleteOp.Click += new System.EventHandler(this.BdeleteOp_Click);
            // 
            // Routing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(881, 554);
            this.Controls.Add(this.BDeleteOp);
            this.Controls.Add(this.BAddOp);
            this.Controls.Add(this.LRoutingTimesDiffer);
            this.Controls.Add(this.LproposedSetupTime);
            this.Controls.Add(this.LproposedRunTime);
            this.Controls.Add(this.LcurrentSetupTime);
            this.Controls.Add(this.LcurrentRunTime);
            this.Controls.Add(this.DGVright);
            this.Controls.Add(this.DGV);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Routing";
            this.Text = "Routings";
            this.Load += new System.EventHandler(this.Routing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVright)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.DataGridView DGVright;
        private System.Windows.Forms.Label LcurrentRunTime;
        private System.Windows.Forms.Label LcurrentSetupTime;
        private System.Windows.Forms.Label LproposedSetupTime;
        private System.Windows.Forms.Label LproposedRunTime;
        private System.Windows.Forms.Label LRoutingTimesDiffer;
        private System.Windows.Forms.Button BAddOp;
        private System.Windows.Forms.Button BDeleteOp;
    }
}

