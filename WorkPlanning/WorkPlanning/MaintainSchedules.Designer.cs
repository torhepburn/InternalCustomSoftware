namespace WorkPlanning
{
    partial class MaintainSchedules
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.Lcustomer = new System.Windows.Forms.Label();
            this.Lproject = new System.Windows.Forms.Label();
            this.Lelement = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bAdjustDays = new System.Windows.Forms.Button();
            this.tbExtend = new System.Windows.Forms.TextBox();
            this.Lsn = new System.Windows.Forms.Label();
            this.Lstep = new System.Windows.Forms.Label();
            this.Lfg48 = new System.Windows.Forms.Label();
            this.LitemCode = new System.Windows.Forms.Label();
            this.Lsubsequent = new System.Windows.Forms.Label();
            this.bPrint = new System.Windows.Forms.Button();
            this.bBlockAdjust = new System.Windows.Forms.Button();
            this.DGV2 = new System.Windows.Forms.DataGridView();
            this.bFixCompletedNError = new System.Windows.Forms.Button();
            this.tbDelay = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bStatus = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(21, 276);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersWidth = 20;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV.Size = new System.Drawing.Size(930, 349);
            this.DGV.TabIndex = 6;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // Lcustomer
            // 
            this.Lcustomer.AutoSize = true;
            this.Lcustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Lcustomer.Location = new System.Drawing.Point(50, 10);
            this.Lcustomer.Name = "Lcustomer";
            this.Lcustomer.Size = new System.Drawing.Size(78, 20);
            this.Lcustomer.TabIndex = 7;
            this.Lcustomer.Text = "Customer";
            // 
            // Lproject
            // 
            this.Lproject.AutoSize = true;
            this.Lproject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Lproject.Location = new System.Drawing.Point(50, 35);
            this.Lproject.Name = "Lproject";
            this.Lproject.Size = new System.Drawing.Size(58, 20);
            this.Lproject.TabIndex = 8;
            this.Lproject.Text = "Project";
            // 
            // Lelement
            // 
            this.Lelement.AutoSize = true;
            this.Lelement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Lelement.Location = new System.Drawing.Point(50, 60);
            this.Lelement.Name = "Lelement";
            this.Lelement.Size = new System.Drawing.Size(68, 20);
            this.Lelement.TabIndex = 9;
            this.Lelement.Text = "Element";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(106, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 26);
            this.label2.TabIndex = 12;
            this.label2.Text = "Completed";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label3.Location = new System.Drawing.Point(230, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 26);
            this.label3.TabIndex = 13;
            this.label3.Text = "Current";
            // 
            // bAdjustDays
            // 
            this.bAdjustDays.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(120)))), ((int)(((byte)(100)))));
            this.bAdjustDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bAdjustDays.Location = new System.Drawing.Point(571, 6);
            this.bAdjustDays.Name = "bAdjustDays";
            this.bAdjustDays.Size = new System.Drawing.Size(136, 70);
            this.bAdjustDays.TabIndex = 28;
            this.bAdjustDays.Text = "ADJUST DAYS";
            this.bAdjustDays.UseVisualStyleBackColor = false;
            this.bAdjustDays.Click += new System.EventHandler(this.bAdjustDays_Click);
            // 
            // tbExtend
            // 
            this.tbExtend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbExtend.Location = new System.Drawing.Point(510, 50);
            this.tbExtend.Name = "tbExtend";
            this.tbExtend.Size = new System.Drawing.Size(47, 23);
            this.tbExtend.TabIndex = 27;
            // 
            // Lsn
            // 
            this.Lsn.AutoSize = true;
            this.Lsn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Lsn.Location = new System.Drawing.Point(322, 6);
            this.Lsn.Name = "Lsn";
            this.Lsn.Size = new System.Drawing.Size(43, 26);
            this.Lsn.TabIndex = 29;
            this.Lsn.Text = "SN";
            // 
            // Lstep
            // 
            this.Lstep.AutoSize = true;
            this.Lstep.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Lstep.Location = new System.Drawing.Point(322, 51);
            this.Lstep.Name = "Lstep";
            this.Lstep.Size = new System.Drawing.Size(57, 26);
            this.Lstep.TabIndex = 30;
            this.Lstep.Text = "Step";
            // 
            // Lfg48
            // 
            this.Lfg48.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Lfg48.AutoSize = true;
            this.Lfg48.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Lfg48.Location = new System.Drawing.Point(41, 641);
            this.Lfg48.Name = "Lfg48";
            this.Lfg48.Size = new System.Drawing.Size(273, 26);
            this.Lfg48.TabIndex = 31;
            this.Lfg48.Text = "Warehouse 48 Inventory = ";
            // 
            // LitemCode
            // 
            this.LitemCode.AutoSize = true;
            this.LitemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LitemCode.Location = new System.Drawing.Point(50, 85);
            this.LitemCode.Name = "LitemCode";
            this.LitemCode.Size = new System.Drawing.Size(83, 20);
            this.LitemCode.TabIndex = 32;
            this.LitemCode.Text = "Item Code";
            // 
            // Lsubsequent
            // 
            this.Lsubsequent.AutoSize = true;
            this.Lsubsequent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Lsubsequent.Location = new System.Drawing.Point(50, 116);
            this.Lsubsequent.Name = "Lsubsequent";
            this.Lsubsequent.Size = new System.Drawing.Size(133, 20);
            this.Lsubsequent.TabIndex = 34;
            this.Lsubsequent.Text = "Subsequent days";
            // 
            // bPrint
            // 
            this.bPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(100)))));
            this.bPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bPrint.Location = new System.Drawing.Point(846, 7);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(101, 70);
            this.bPrint.TabIndex = 35;
            this.bPrint.Text = "PRINT";
            this.bPrint.UseVisualStyleBackColor = false;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // bBlockAdjust
            // 
            this.bBlockAdjust.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(130)))), ((int)(((byte)(100)))));
            this.bBlockAdjust.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bBlockAdjust.Location = new System.Drawing.Point(21, 151);
            this.bBlockAdjust.Name = "bBlockAdjust";
            this.bBlockAdjust.Size = new System.Drawing.Size(293, 39);
            this.bBlockAdjust.TabIndex = 37;
            this.bBlockAdjust.Text = "ADJUST DAYS BY BLOCK";
            this.bBlockAdjust.UseVisualStyleBackColor = false;
            this.bBlockAdjust.Click += new System.EventHandler(this.bBlockAdjust_Click);
            // 
            // DGV2
            // 
            this.DGV2.AllowUserToAddRows = false;
            this.DGV2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Blue;
            this.DGV2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV2.Location = new System.Drawing.Point(330, 85);
            this.DGV2.Name = "DGV2";
            this.DGV2.ReadOnly = true;
            this.DGV2.RowHeadersWidth = 20;
            this.DGV2.Size = new System.Drawing.Size(621, 185);
            this.DGV2.TabIndex = 38;
            // 
            // bFixCompletedNError
            // 
            this.bFixCompletedNError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(153)))));
            this.bFixCompletedNError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bFixCompletedNError.Location = new System.Drawing.Point(21, 196);
            this.bFixCompletedNError.Name = "bFixCompletedNError";
            this.bFixCompletedNError.Size = new System.Drawing.Size(293, 39);
            this.bFixCompletedNError.TabIndex = 39;
            this.bFixCompletedNError.Text = "FIX COMPLETED IN ERROR";
            this.bFixCompletedNError.UseVisualStyleBackColor = false;
            this.bFixCompletedNError.Click += new System.EventHandler(this.bFixCompletedNError_Click);
            // 
            // tbDelay
            // 
            this.tbDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbDelay.Location = new System.Drawing.Point(510, 21);
            this.tbDelay.Name = "tbDelay";
            this.tbDelay.Size = new System.Drawing.Size(47, 23);
            this.tbDelay.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(441, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 41;
            this.label1.Text = "DELAY";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(430, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 42;
            this.label4.Text = "EXTEND";
            // 
            // bStatus
            // 
            this.bStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.bStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bStatus.Location = new System.Drawing.Point(728, 6);
            this.bStatus.Name = "bStatus";
            this.bStatus.Size = new System.Drawing.Size(99, 70);
            this.bStatus.TabIndex = 43;
            this.bStatus.Text = "HOLD STATUS";
            this.bStatus.UseVisualStyleBackColor = false;
            this.bStatus.Click += new System.EventHandler(this.bStatus_Click);
            // 
            // MaintainSchedules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(129)))), ((int)(((byte)(162)))));
            this.ClientSize = new System.Drawing.Size(974, 709);
            this.Controls.Add(this.bStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDelay);
            this.Controls.Add(this.bFixCompletedNError);
            this.Controls.Add(this.DGV2);
            this.Controls.Add(this.bBlockAdjust);
            this.Controls.Add(this.bPrint);
            this.Controls.Add(this.Lsubsequent);
            this.Controls.Add(this.LitemCode);
            this.Controls.Add(this.Lfg48);
            this.Controls.Add(this.Lstep);
            this.Controls.Add(this.Lsn);
            this.Controls.Add(this.bAdjustDays);
            this.Controls.Add(this.tbExtend);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Lelement);
            this.Controls.Add(this.Lproject);
            this.Controls.Add(this.Lcustomer);
            this.Controls.Add(this.DGV);
            this.Name = "MaintainSchedules";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MaintainSchedules_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Label Lcustomer;
        private System.Windows.Forms.Label Lproject;
        private System.Windows.Forms.Label Lelement;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bAdjustDays;
        private System.Windows.Forms.TextBox tbExtend;
        private System.Windows.Forms.Label Lsn;
        private System.Windows.Forms.Label Lstep;
        private System.Windows.Forms.Label Lfg48;
        private System.Windows.Forms.Label LitemCode;
        private System.Windows.Forms.Label Lsubsequent;
        private System.Windows.Forms.Button bPrint;
        private System.Windows.Forms.Button bBlockAdjust;
        private System.Windows.Forms.DataGridView DGV2;
        private System.Windows.Forms.Button bFixCompletedNError;
        private System.Windows.Forms.TextBox tbDelay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bStatus;
    }
}

