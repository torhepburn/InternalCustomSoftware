namespace Service
{
    partial class EquipmentHistory
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
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.Lnotes = new System.Windows.Forms.Label();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.bSave = new System.Windows.Forms.Button();
            this.tbAccessoryPartNumber = new System.Windows.Forms.TextBox();
            this.Laccpn = new System.Windows.Forms.Label();
            this.Laccsn = new System.Windows.Forms.Label();
            this.tbAccessorySerialNumber = new System.Windows.Forms.TextBox();
            this.Lmodel = new System.Windows.Forms.Label();
            this.Lsn = new System.Windows.Forms.Label();
            this.dtpPmDue = new System.Windows.Forms.DateTimePicker();
            this.cbPMDue = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // tbNotes
            // 
            this.tbNotes.Location = new System.Drawing.Point(117, 56);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(562, 64);
            this.tbNotes.TabIndex = 0;
            // 
            // Lnotes
            // 
            this.Lnotes.AutoSize = true;
            this.Lnotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Lnotes.Location = new System.Drawing.Point(52, 63);
            this.Lnotes.Name = "Lnotes";
            this.Lnotes.Size = new System.Drawing.Size(60, 17);
            this.Lnotes.TabIndex = 1;
            this.Lnotes.Text = "NOTES:";
            // 
            // DGV
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(55, 294);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(624, 197);
            this.DGV.TabIndex = 2;
            // 
            // bSave
            // 
            this.bSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.bSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bSave.Location = new System.Drawing.Point(556, 218);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(123, 53);
            this.bSave.TabIndex = 3;
            this.bSave.Text = "SAVE DATA";
            this.bSave.UseVisualStyleBackColor = false;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // tbAccessoryPartNumber
            // 
            this.tbAccessoryPartNumber.Location = new System.Drawing.Point(237, 144);
            this.tbAccessoryPartNumber.Name = "tbAccessoryPartNumber";
            this.tbAccessoryPartNumber.Size = new System.Drawing.Size(200, 20);
            this.tbAccessoryPartNumber.TabIndex = 4;
            // 
            // Laccpn
            // 
            this.Laccpn.AutoSize = true;
            this.Laccpn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Laccpn.Location = new System.Drawing.Point(52, 145);
            this.Laccpn.Name = "Laccpn";
            this.Laccpn.Size = new System.Drawing.Size(161, 17);
            this.Laccpn.TabIndex = 5;
            this.Laccpn.Text = "Accessory Part Number:";
            // 
            // Laccsn
            // 
            this.Laccsn.AutoSize = true;
            this.Laccsn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Laccsn.Location = new System.Drawing.Point(52, 186);
            this.Laccsn.Name = "Laccsn";
            this.Laccsn.Size = new System.Drawing.Size(171, 17);
            this.Laccsn.TabIndex = 7;
            this.Laccsn.Text = "Accessory Serial Number:";
            // 
            // tbAccessorySerialNumber
            // 
            this.tbAccessorySerialNumber.Location = new System.Drawing.Point(237, 185);
            this.tbAccessorySerialNumber.Name = "tbAccessorySerialNumber";
            this.tbAccessorySerialNumber.Size = new System.Drawing.Size(200, 20);
            this.tbAccessorySerialNumber.TabIndex = 6;
            // 
            // Lmodel
            // 
            this.Lmodel.AutoSize = true;
            this.Lmodel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Lmodel.Location = new System.Drawing.Point(52, 20);
            this.Lmodel.Name = "Lmodel";
            this.Lmodel.Size = new System.Drawing.Size(52, 20);
            this.Lmodel.TabIndex = 10;
            this.Lmodel.Text = "Model";
            // 
            // Lsn
            // 
            this.Lsn.AutoSize = true;
            this.Lsn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Lsn.Location = new System.Drawing.Point(478, 20);
            this.Lsn.Name = "Lsn";
            this.Lsn.Size = new System.Drawing.Size(105, 20);
            this.Lsn.TabIndex = 11;
            this.Lsn.Text = "SerialNumber";
            // 
            // dtpPmDue
            // 
            this.dtpPmDue.Location = new System.Drawing.Point(237, 221);
            this.dtpPmDue.Name = "dtpPmDue";
            this.dtpPmDue.Size = new System.Drawing.Size(200, 20);
            this.dtpPmDue.TabIndex = 12;
            this.dtpPmDue.Visible = false;
            // 
            // cbPMDue
            // 
            this.cbPMDue.AutoSize = true;
            this.cbPMDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbPMDue.Location = new System.Drawing.Point(56, 224);
            this.cbPMDue.Name = "cbPMDue";
            this.cbPMDue.Size = new System.Drawing.Size(115, 21);
            this.cbPMDue.TabIndex = 13;
            this.cbPMDue.Text = "Enter PM Due";
            this.cbPMDue.UseVisualStyleBackColor = true;
            this.cbPMDue.CheckedChanged += new System.EventHandler(this.cbPMDue_CheckedChanged);
            // 
            // EquipmentHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(105)))), ((int)(((byte)(160)))));
            this.ClientSize = new System.Drawing.Size(739, 538);
            this.Controls.Add(this.cbPMDue);
            this.Controls.Add(this.dtpPmDue);
            this.Controls.Add(this.Lsn);
            this.Controls.Add(this.Lmodel);
            this.Controls.Add(this.Laccsn);
            this.Controls.Add(this.tbAccessorySerialNumber);
            this.Controls.Add(this.Laccpn);
            this.Controls.Add(this.tbAccessoryPartNumber);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.Lnotes);
            this.Controls.Add(this.tbNotes);
            this.Name = "EquipmentHistory";
            this.Text = "EquipmentHistory";
            this.Load += new System.EventHandler(this.EquipmentHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.Label Lnotes;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.TextBox tbAccessoryPartNumber;
        private System.Windows.Forms.Label Laccpn;
        private System.Windows.Forms.Label Laccsn;
        private System.Windows.Forms.TextBox tbAccessorySerialNumber;
        private System.Windows.Forms.Label Lmodel;
        private System.Windows.Forms.Label Lsn;
        private System.Windows.Forms.DateTimePicker dtpPmDue;
        private System.Windows.Forms.CheckBox cbPMDue;
    }
}