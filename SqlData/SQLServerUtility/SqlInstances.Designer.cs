namespace SQLServerUtility
{
    partial class SqlInstances
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbEditionExpress = new System.Windows.Forms.CheckBox();
            this.cbEditionDesktopEngine = new System.Windows.Forms.CheckBox();
            this.cbInstanceSQLExpress = new System.Windows.Forms.CheckBox();
            this.cbInstanceACT = new System.Windows.Forms.CheckBox();
            this.bFilter = new System.Windows.Forms.Button();
            this.bExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(68, 160);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(456, 447);
            this.DGV.TabIndex = 1;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(74, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // cbEditionExpress
            // 
            this.cbEditionExpress.AutoSize = true;
            this.cbEditionExpress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbEditionExpress.Location = new System.Drawing.Point(240, 16);
            this.cbEditionExpress.Name = "cbEditionExpress";
            this.cbEditionExpress.Size = new System.Drawing.Size(195, 21);
            this.cbEditionExpress.TabIndex = 3;
            this.cbEditionExpress.Text = "Exclude Edition = \'Express\'";
            this.cbEditionExpress.UseVisualStyleBackColor = true;
            // 
            // cbEditionDesktopEngine
            // 
            this.cbEditionDesktopEngine.AutoSize = true;
            this.cbEditionDesktopEngine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbEditionDesktopEngine.Location = new System.Drawing.Point(240, 43);
            this.cbEditionDesktopEngine.Name = "cbEditionDesktopEngine";
            this.cbEditionDesktopEngine.Size = new System.Drawing.Size(245, 21);
            this.cbEditionDesktopEngine.TabIndex = 4;
            this.cbEditionDesktopEngine.Text = "Exclude Edition = \'Desktop Engine\'";
            this.cbEditionDesktopEngine.UseVisualStyleBackColor = true;
            // 
            // cbInstanceSQLExpress
            // 
            this.cbInstanceSQLExpress.AutoSize = true;
            this.cbInstanceSQLExpress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbInstanceSQLExpress.Location = new System.Drawing.Point(240, 70);
            this.cbInstanceSQLExpress.Name = "cbInstanceSQLExpress";
            this.cbInstanceSQLExpress.Size = new System.Drawing.Size(323, 21);
            this.cbInstanceSQLExpress.TabIndex = 5;
            this.cbInstanceSQLExpress.Text = "Exclude Instance Name contains \'SQL Express\'";
            this.cbInstanceSQLExpress.UseVisualStyleBackColor = true;
            // 
            // cbInstanceACT
            // 
            this.cbInstanceACT.AutoSize = true;
            this.cbInstanceACT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbInstanceACT.Location = new System.Drawing.Point(240, 97);
            this.cbInstanceACT.Name = "cbInstanceACT";
            this.cbInstanceACT.Size = new System.Drawing.Size(268, 21);
            this.cbInstanceACT.TabIndex = 6;
            this.cbInstanceACT.Text = "Exclude Instance Name contains \'ACT\'";
            this.cbInstanceACT.UseVisualStyleBackColor = true;
            // 
            // bFilter
            // 
            this.bFilter.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bFilter.Location = new System.Drawing.Point(68, 13);
            this.bFilter.Name = "bFilter";
            this.bFilter.Size = new System.Drawing.Size(109, 51);
            this.bFilter.TabIndex = 7;
            this.bFilter.Text = "FILTER";
            this.bFilter.UseVisualStyleBackColor = false;
            this.bFilter.Click += new System.EventHandler(this.bFilter_Click);
            // 
            // bExcel
            // 
            this.bExcel.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.bExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bExcel.Location = new System.Drawing.Point(68, 70);
            this.bExcel.Name = "bExcel";
            this.bExcel.Size = new System.Drawing.Size(109, 51);
            this.bExcel.TabIndex = 8;
            this.bExcel.Text = "EXCEL EXPORT";
            this.bExcel.UseVisualStyleBackColor = false;
            this.bExcel.Click += new System.EventHandler(this.bExcel_Click);
            // 
            // SqlInstances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(597, 675);
            this.Controls.Add(this.bExcel);
            this.Controls.Add(this.bFilter);
            this.Controls.Add(this.cbInstanceACT);
            this.Controls.Add(this.cbInstanceSQLExpress);
            this.Controls.Add(this.cbEditionDesktopEngine);
            this.Controls.Add(this.cbEditionExpress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGV);
            this.Name = "SqlInstances";
            this.Text = "SQL Instances";
            this.Load += new System.EventHandler(this.SqlInstances_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbEditionExpress;
        private System.Windows.Forms.CheckBox cbEditionDesktopEngine;
        private System.Windows.Forms.CheckBox cbInstanceSQLExpress;
        private System.Windows.Forms.CheckBox cbInstanceACT;
        private System.Windows.Forms.Button bFilter;
        private System.Windows.Forms.Button bExcel;
    }
}

