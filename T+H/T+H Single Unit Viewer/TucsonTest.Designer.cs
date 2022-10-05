namespace T_H_Single_Unit_Viewer
{
    partial class TucsonTest
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
            this.LhumLabel = new System.Windows.Forms.Label();
            this.LtempLabel = new System.Windows.Forms.Label();
            this.LUnit = new System.Windows.Forms.Label();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.LHum = new System.Windows.Forms.Label();
            this.LTemp = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LhumLabel
            // 
            this.LhumLabel.AutoSize = true;
            this.LhumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LhumLabel.Location = new System.Drawing.Point(250, 87);
            this.LhumLabel.Name = "LhumLabel";
            this.LhumLabel.Size = new System.Drawing.Size(138, 18);
            this.LhumLabel.TabIndex = 11;
            this.LhumLabel.Text = "Average Humidity";
            // 
            // LtempLabel
            // 
            this.LtempLabel.AutoSize = true;
            this.LtempLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LtempLabel.Location = new System.Drawing.Point(63, 87);
            this.LtempLabel.Name = "LtempLabel";
            this.LtempLabel.Size = new System.Drawing.Size(168, 18);
            this.LtempLabel.TabIndex = 10;
            this.LtempLabel.Text = "Average Temperature";
            // 
            // LUnit
            // 
            this.LUnit.AutoSize = true;
            this.LUnit.Location = new System.Drawing.Point(24, 45);
            this.LUnit.Name = "LUnit";
            this.LUnit.Size = new System.Drawing.Size(104, 13);
            this.LUnit.TabIndex = 9;
            this.LUnit.Text = "Test Unit 128.7.0.73";
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
            this.DGV.Location = new System.Drawing.Point(57, 230);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.Size = new System.Drawing.Size(442, 228);
            this.DGV.TabIndex = 8;
            // 
            // LHum
            // 
            this.LHum.AutoSize = true;
            this.LHum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.LHum.Location = new System.Drawing.Point(15, 25);
            this.LHum.Name = "LHum";
            this.LHum.Size = new System.Drawing.Size(84, 13);
            this.LHum.TabIndex = 7;
            this.LHum.Text = "not implemented";
            // 
            // LTemp
            // 
            this.LTemp.AutoSize = true;
            this.LTemp.Location = new System.Drawing.Point(12, 25);
            this.LTemp.Name = "LTemp";
            this.LTemp.Size = new System.Drawing.Size(84, 13);
            this.LTemp.TabIndex = 6;
            this.LTemp.Text = "not implemented";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.panel2.Controls.Add(this.LHum);
            this.panel2.Location = new System.Drawing.Point(237, 122);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(174, 60);
            this.panel2.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.panel1.Controls.Add(this.LTemp);
            this.panel1.Location = new System.Drawing.Point(57, 122);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(174, 60);
            this.panel1.TabIndex = 6;
            // 
            // TucsonTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 502);
            this.Controls.Add(this.LhumLabel);
            this.Controls.Add(this.LtempLabel);
            this.Controls.Add(this.LUnit);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "TucsonTest";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.TucsonTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LhumLabel;
        private System.Windows.Forms.Label LtempLabel;
        private System.Windows.Forms.Label LUnit;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label LHum;
        private System.Windows.Forms.Label LTemp;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}