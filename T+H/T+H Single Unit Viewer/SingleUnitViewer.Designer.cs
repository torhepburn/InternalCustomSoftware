namespace T_H_Single_Unit_Viewer
{
    partial class UnitViewer
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LTemp = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LHum = new System.Windows.Forms.Label();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.LUnit = new System.Windows.Forms.Label();
            this.LtempLabel = new System.Windows.Forms.Label();
            this.LhumLabel = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.panel1.Controls.Add(this.LTemp);
            this.panel1.Location = new System.Drawing.Point(69, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(174, 60);
            this.panel1.TabIndex = 0;
            // 
            // LTemp
            // 
            this.LTemp.AutoSize = true;
            this.LTemp.Location = new System.Drawing.Point(12, 25);
            this.LTemp.Name = "LTemp";
            this.LTemp.Size = new System.Drawing.Size(142, 20);
            this.LTemp.TabIndex = 6;
            this.LTemp.Text = "not implemented";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.panel2.Controls.Add(this.LHum);
            this.panel2.Location = new System.Drawing.Point(249, 110);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(174, 60);
            this.panel2.TabIndex = 1;
            // 
            // LHum
            // 
            this.LHum.AutoSize = true;
            this.LHum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.LHum.Location = new System.Drawing.Point(15, 25);
            this.LHum.Name = "LHum";
            this.LHum.Size = new System.Drawing.Size(142, 20);
            this.LHum.TabIndex = 7;
            this.LHum.Text = "not implemented";
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.AllowUserToResizeColumns = false;
            this.DGV.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(150)))));
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(69, 218);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.Size = new System.Drawing.Size(442, 228);
            this.DGV.TabIndex = 2;
            // 
            // LUnit
            // 
            this.LUnit.AutoSize = true;
            this.LUnit.Location = new System.Drawing.Point(36, 33);
            this.LUnit.Name = "LUnit";
            this.LUnit.Size = new System.Drawing.Size(241, 20);
            this.LUnit.TabIndex = 3;
            this.LUnit.Text = "SERVER ROOM 172.16.1.12";
            // 
            // LtempLabel
            // 
            this.LtempLabel.AutoSize = true;
            this.LtempLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LtempLabel.Location = new System.Drawing.Point(75, 75);
            this.LtempLabel.Name = "LtempLabel";
            this.LtempLabel.Size = new System.Drawing.Size(168, 18);
            this.LtempLabel.TabIndex = 4;
            this.LtempLabel.Text = "Average Temperature";
            // 
            // LhumLabel
            // 
            this.LhumLabel.AutoSize = true;
            this.LhumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LhumLabel.Location = new System.Drawing.Point(262, 75);
            this.LhumLabel.Name = "LhumLabel";
            this.LhumLabel.Size = new System.Drawing.Size(138, 18);
            this.LhumLabel.TabIndex = 5;
            this.LhumLabel.Text = "Average Humidity";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // UnitViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(210)))), ((int)(((byte)(150)))));
            this.ClientSize = new System.Drawing.Size(591, 515);
            this.Controls.Add(this.LhumLabel);
            this.Controls.Add(this.LtempLabel);
            this.Controls.Add(this.LUnit);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "UnitViewer";
            this.Text = "Clean Room 172.16.1.11";
            this.Load += new System.EventHandler(this.UnitViewer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Label LTemp;
        private System.Windows.Forms.Label LHum;
        private System.Windows.Forms.Label LUnit;
        private System.Windows.Forms.Label LtempLabel;
        private System.Windows.Forms.Label LhumLabel;
        private System.Windows.Forms.Timer timer;
    }
}

