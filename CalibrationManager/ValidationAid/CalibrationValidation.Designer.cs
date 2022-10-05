namespace ValidationAid
{
    partial class CalibrationValidation
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
            this.rbSystem = new System.Windows.Forms.RadioButton();
            this.rbSystemAC = new System.Windows.Forms.RadioButton();
            this.rbFull = new System.Windows.Forms.RadioButton();
            this.rbViewData = new System.Windows.Forms.RadioButton();
            this.rbLimited = new System.Windows.Forms.RadioButton();
            this.bPermissions = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(73, 165);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(436, 320);
            this.DGV.TabIndex = 0;
            // 
            // rbSystem
            // 
            this.rbSystem.AutoSize = true;
            this.rbSystem.Location = new System.Drawing.Point(252, 34);
            this.rbSystem.Name = "rbSystem";
            this.rbSystem.Size = new System.Drawing.Size(86, 24);
            this.rbSystem.TabIndex = 1;
            this.rbSystem.TabStop = true;
            this.rbSystem.Text = "System";
            this.rbSystem.UseVisualStyleBackColor = true;
            this.rbSystem.CheckedChanged += new System.EventHandler(this.rbSystem_CheckedChanged);
            // 
            // rbSystemAC
            // 
            this.rbSystemAC.AutoSize = true;
            this.rbSystemAC.Location = new System.Drawing.Point(252, 54);
            this.rbSystemAC.Name = "rbSystemAC";
            this.rbSystemAC.Size = new System.Drawing.Size(110, 24);
            this.rbSystemAC.TabIndex = 2;
            this.rbSystemAC.TabStop = true;
            this.rbSystemAC.Text = "SystemAC";
            this.rbSystemAC.UseVisualStyleBackColor = true;
            this.rbSystemAC.CheckedChanged += new System.EventHandler(this.rbSystemAC_CheckedChanged);
            // 
            // rbFull
            // 
            this.rbFull.AutoSize = true;
            this.rbFull.Location = new System.Drawing.Point(252, 75);
            this.rbFull.Name = "rbFull";
            this.rbFull.Size = new System.Drawing.Size(56, 24);
            this.rbFull.TabIndex = 3;
            this.rbFull.TabStop = true;
            this.rbFull.Text = "Full";
            this.rbFull.UseVisualStyleBackColor = true;
            this.rbFull.CheckedChanged += new System.EventHandler(this.rbFull_CheckedChanged);
            // 
            // rbViewData
            // 
            this.rbViewData.AutoSize = true;
            this.rbViewData.Location = new System.Drawing.Point(252, 96);
            this.rbViewData.Name = "rbViewData";
            this.rbViewData.Size = new System.Drawing.Size(114, 24);
            this.rbViewData.TabIndex = 4;
            this.rbViewData.TabStop = true;
            this.rbViewData.Text = "View+Data";
            this.rbViewData.UseVisualStyleBackColor = true;
            this.rbViewData.CheckedChanged += new System.EventHandler(this.rbViewData_CheckedChanged);
            // 
            // rbLimited
            // 
            this.rbLimited.AutoSize = true;
            this.rbLimited.Location = new System.Drawing.Point(252, 117);
            this.rbLimited.Name = "rbLimited";
            this.rbLimited.Size = new System.Drawing.Size(85, 24);
            this.rbLimited.TabIndex = 5;
            this.rbLimited.TabStop = true;
            this.rbLimited.Text = "Limited";
            this.rbLimited.UseVisualStyleBackColor = true;
            this.rbLimited.CheckedChanged += new System.EventHandler(this.rbLimited_CheckedChanged);
            // 
            // bPermissions
            // 
            this.bPermissions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(180)))), ((int)(((byte)(0)))));
            this.bPermissions.Location = new System.Drawing.Point(73, 19);
            this.bPermissions.Name = "bPermissions";
            this.bPermissions.Size = new System.Drawing.Size(153, 140);
            this.bPermissions.TabIndex = 6;
            this.bPermissions.Text = "Change Current User Permissions";
            this.bPermissions.UseVisualStyleBackColor = false;
            this.bPermissions.Click += new System.EventHandler(this.bPermissions_Click);
            // 
            // CalibrationValidation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(180)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(583, 559);
            this.Controls.Add(this.bPermissions);
            this.Controls.Add(this.rbLimited);
            this.Controls.Add(this.rbViewData);
            this.Controls.Add(this.rbFull);
            this.Controls.Add(this.rbSystemAC);
            this.Controls.Add(this.rbSystem);
            this.Controls.Add(this.DGV);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CalibrationValidation";
            this.Text = "Change User Permissions";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.RadioButton rbSystem;
        private System.Windows.Forms.RadioButton rbSystemAC;
        private System.Windows.Forms.RadioButton rbFull;
        private System.Windows.Forms.RadioButton rbViewData;
        private System.Windows.Forms.RadioButton rbLimited;
        private System.Windows.Forms.Button bPermissions;
    }
}

