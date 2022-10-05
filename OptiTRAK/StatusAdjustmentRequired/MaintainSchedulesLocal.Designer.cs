namespace StatusAdjustmentRequired
{
    partial class MaintainSchedulesLocal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bStatus = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDelay = new System.Windows.Forms.TextBox();
            this.bFixCompletedNError = new System.Windows.Forms.Button();
            this.DGV2 = new System.Windows.Forms.DataGridView();
            this.bPrint = new System.Windows.Forms.Button();
            this.Lsubsequent = new System.Windows.Forms.Label();
            this.LitemCode = new System.Windows.Forms.Label();
            this.Lfg48 = new System.Windows.Forms.Label();
            this.Lstep = new System.Windows.Forms.Label();
            this.Lsn = new System.Windows.Forms.Label();
            this.bAdjustDays = new System.Windows.Forms.Button();
            this.tbExtend = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Lelement = new System.Windows.Forms.Label();
            this.Lproject = new System.Windows.Forms.Label();
            this.Lcustomer = new System.Windows.Forms.Label();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.bBlockAdjust = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // bStatus
            // 
            this.bStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.bStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bStatus.Location = new System.Drawing.Point(718, 23);
            this.bStatus.Name = "bStatus";
            this.bStatus.Size = new System.Drawing.Size(99, 70);
            this.bStatus.TabIndex = 64;
            this.bStatus.Text = "HOLD STATUS";
            this.bStatus.UseVisualStyleBackColor = false;
            this.bStatus.Click += new System.EventHandler(this.bStatus_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(420, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 63;
            this.label4.Text = "EXTEND";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(431, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 62;
            this.label1.Text = "DELAY";
            // 
            // tbDelay
            // 
            this.tbDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbDelay.Location = new System.Drawing.Point(500, 38);
            this.tbDelay.Name = "tbDelay";
            this.tbDelay.Size = new System.Drawing.Size(47, 23);
            this.tbDelay.TabIndex = 61;
            // 
            // bFixCompletedNError
            // 
            this.bFixCompletedNError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(153)))));
            this.bFixCompletedNError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bFixCompletedNError.Location = new System.Drawing.Point(11, 213);
            this.bFixCompletedNError.Name = "bFixCompletedNError";
            this.bFixCompletedNError.Size = new System.Drawing.Size(293, 39);
            this.bFixCompletedNError.TabIndex = 60;
            this.bFixCompletedNError.Text = "FIX COMPLETED IN ERROR";
            this.bFixCompletedNError.UseVisualStyleBackColor = false;
            this.bFixCompletedNError.Click += new System.EventHandler(this.bFixCompletedNError_Click);
            // 
            // DGV2
            // 
            this.DGV2.AllowUserToAddRows = false;
            this.DGV2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Blue;
            this.DGV2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV2.Location = new System.Drawing.Point(320, 102);
            this.DGV2.Name = "DGV2";
            this.DGV2.ReadOnly = true;
            this.DGV2.RowHeadersWidth = 20;
            this.DGV2.Size = new System.Drawing.Size(621, 185);
            this.DGV2.TabIndex = 59;
            // 
            // bPrint
            // 
            this.bPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(100)))));
            this.bPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bPrint.Location = new System.Drawing.Point(836, 24);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(101, 70);
            this.bPrint.TabIndex = 57;
            this.bPrint.Text = "PRINT";
            this.bPrint.UseVisualStyleBackColor = false;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // Lsubsequent
            // 
            this.Lsubsequent.AutoSize = true;
            this.Lsubsequent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Lsubsequent.Location = new System.Drawing.Point(40, 133);
            this.Lsubsequent.Name = "Lsubsequent";
            this.Lsubsequent.Size = new System.Drawing.Size(133, 20);
            this.Lsubsequent.TabIndex = 56;
            this.Lsubsequent.Text = "Subsequent days";
            // 
            // LitemCode
            // 
            this.LitemCode.AutoSize = true;
            this.LitemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LitemCode.Location = new System.Drawing.Point(40, 102);
            this.LitemCode.Name = "LitemCode";
            this.LitemCode.Size = new System.Drawing.Size(83, 20);
            this.LitemCode.TabIndex = 55;
            this.LitemCode.Text = "Item Code";
            // 
            // Lfg48
            // 
            this.Lfg48.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Lfg48.AutoSize = true;
            this.Lfg48.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Lfg48.Location = new System.Drawing.Point(31, 658);
            this.Lfg48.Name = "Lfg48";
            this.Lfg48.Size = new System.Drawing.Size(273, 26);
            this.Lfg48.TabIndex = 54;
            this.Lfg48.Text = "Warehouse 48 Inventory = ";
            // 
            // Lstep
            // 
            this.Lstep.AutoSize = true;
            this.Lstep.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Lstep.Location = new System.Drawing.Point(312, 68);
            this.Lstep.Name = "Lstep";
            this.Lstep.Size = new System.Drawing.Size(57, 26);
            this.Lstep.TabIndex = 53;
            this.Lstep.Text = "Step";
            // 
            // Lsn
            // 
            this.Lsn.AutoSize = true;
            this.Lsn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Lsn.Location = new System.Drawing.Point(312, 23);
            this.Lsn.Name = "Lsn";
            this.Lsn.Size = new System.Drawing.Size(43, 26);
            this.Lsn.TabIndex = 52;
            this.Lsn.Text = "SN";
            // 
            // bAdjustDays
            // 
            this.bAdjustDays.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(120)))), ((int)(((byte)(100)))));
            this.bAdjustDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bAdjustDays.Location = new System.Drawing.Point(561, 23);
            this.bAdjustDays.Name = "bAdjustDays";
            this.bAdjustDays.Size = new System.Drawing.Size(136, 70);
            this.bAdjustDays.TabIndex = 51;
            this.bAdjustDays.Text = "ADJUST DAYS";
            this.bAdjustDays.UseVisualStyleBackColor = false;
            this.bAdjustDays.Click += new System.EventHandler(this.bAdjustDays_Click);
            // 
            // tbExtend
            // 
            this.tbExtend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbExtend.Location = new System.Drawing.Point(500, 67);
            this.tbExtend.Name = "tbExtend";
            this.tbExtend.Size = new System.Drawing.Size(47, 23);
            this.tbExtend.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label3.Location = new System.Drawing.Point(220, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 26);
            this.label3.TabIndex = 49;
            this.label3.Text = "Current";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(96, 261);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 26);
            this.label2.TabIndex = 48;
            this.label2.Text = "Completed";
            // 
            // Lelement
            // 
            this.Lelement.AutoSize = true;
            this.Lelement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Lelement.Location = new System.Drawing.Point(40, 77);
            this.Lelement.Name = "Lelement";
            this.Lelement.Size = new System.Drawing.Size(68, 20);
            this.Lelement.TabIndex = 47;
            this.Lelement.Text = "Element";
            // 
            // Lproject
            // 
            this.Lproject.AutoSize = true;
            this.Lproject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Lproject.Location = new System.Drawing.Point(40, 52);
            this.Lproject.Name = "Lproject";
            this.Lproject.Size = new System.Drawing.Size(58, 20);
            this.Lproject.TabIndex = 46;
            this.Lproject.Text = "Project";
            // 
            // Lcustomer
            // 
            this.Lcustomer.AutoSize = true;
            this.Lcustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Lcustomer.Location = new System.Drawing.Point(40, 27);
            this.Lcustomer.Name = "Lcustomer";
            this.Lcustomer.Size = new System.Drawing.Size(78, 20);
            this.Lcustomer.TabIndex = 45;
            this.Lcustomer.Text = "Customer";
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Blue;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(11, 293);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersWidth = 20;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGV.Size = new System.Drawing.Size(930, 349);
            this.DGV.TabIndex = 44;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // bBlockAdjust
            // 
            this.bBlockAdjust.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(130)))), ((int)(((byte)(100)))));
            this.bBlockAdjust.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bBlockAdjust.Location = new System.Drawing.Point(12, 168);
            this.bBlockAdjust.Name = "bBlockAdjust";
            this.bBlockAdjust.Size = new System.Drawing.Size(293, 39);
            this.bBlockAdjust.TabIndex = 65;
            this.bBlockAdjust.Text = "ADJUST DAYS BY BLOCK";
            this.bBlockAdjust.UseVisualStyleBackColor = false;
            this.bBlockAdjust.Click += new System.EventHandler(this.bBlockAdjust_Click);
            // 
            // MaintainSchedulesLocal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.ClientSize = new System.Drawing.Size(952, 706);
            this.Controls.Add(this.bBlockAdjust);
            this.Controls.Add(this.bStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDelay);
            this.Controls.Add(this.bFixCompletedNError);
            this.Controls.Add(this.DGV2);
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
            this.Name = "MaintainSchedulesLocal";
            this.Text = "MaintainSchedulesLocal";
            this.Load += new System.EventHandler(this.MaintainSchedulesLocal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDelay;
        private System.Windows.Forms.Button bFixCompletedNError;
        private System.Windows.Forms.DataGridView DGV2;
        private System.Windows.Forms.Button bPrint;
        private System.Windows.Forms.Label Lsubsequent;
        private System.Windows.Forms.Label LitemCode;
        private System.Windows.Forms.Label Lfg48;
        private System.Windows.Forms.Label Lstep;
        private System.Windows.Forms.Label Lsn;
        private System.Windows.Forms.Button bAdjustDays;
        private System.Windows.Forms.TextBox tbExtend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Lelement;
        private System.Windows.Forms.Label Lproject;
        private System.Windows.Forms.Label Lcustomer;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Button bBlockAdjust;
    }
}