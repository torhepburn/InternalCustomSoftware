namespace SERLabelList
{
    partial class SERLabelList
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
            this.rb1Label = new System.Windows.Forms.RadioButton();
            this.bPrint = new System.Windows.Forms.Button();
            this.rb4Labels = new System.Windows.Forms.RadioButton();
            this.rb3Labels = new System.Windows.Forms.RadioButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // rb1Label
            // 
            this.rb1Label.AutoSize = true;
            this.rb1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb1Label.Location = new System.Drawing.Point(64, 33);
            this.rb1Label.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb1Label.Name = "rb1Label";
            this.rb1Label.Size = new System.Drawing.Size(248, 24);
            this.rb1Label.TabIndex = 7;
            this.rb1Label.TabStop = true;
            this.rb1Label.Text = "Print (1) One of Every Label";
            this.rb1Label.UseVisualStyleBackColor = true;
            this.rb1Label.CheckedChanged += new System.EventHandler(this.rb1Label_CheckedChanged);
            // 
            // bPrint
            // 
            this.bPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.bPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPrint.Location = new System.Drawing.Point(34, 226);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(316, 63);
            this.bPrint.TabIndex = 6;
            this.bPrint.Text = "Print Labels";
            this.bPrint.UseVisualStyleBackColor = false;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // rb4Labels
            // 
            this.rb4Labels.AutoSize = true;
            this.rb4Labels.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb4Labels.Location = new System.Drawing.Point(64, 145);
            this.rb4Labels.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb4Labels.Name = "rb4Labels";
            this.rb4Labels.Size = new System.Drawing.Size(252, 24);
            this.rb4Labels.TabIndex = 5;
            this.rb4Labels.TabStop = true;
            this.rb4Labels.Text = "Print (4) Four of Every Label";
            this.rb4Labels.UseVisualStyleBackColor = true;
            this.rb4Labels.CheckedChanged += new System.EventHandler(this.rb4Labels_CheckedChanged);
            // 
            // rb3Labels
            // 
            this.rb3Labels.AutoSize = true;
            this.rb3Labels.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb3Labels.Location = new System.Drawing.Point(64, 85);
            this.rb3Labels.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb3Labels.Name = "rb3Labels";
            this.rb3Labels.Size = new System.Drawing.Size(261, 24);
            this.rb3Labels.TabIndex = 4;
            this.rb3Labels.TabStop = true;
            this.rb3Labels.Text = "Print (3) Three of Every Label";
            this.rb3Labels.UseVisualStyleBackColor = true;
            this.rb3Labels.CheckedChanged += new System.EventHandler(this.rb3Labels_CheckedChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(64, 339);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersVisible = false;
            this.DGV.Size = new System.Drawing.Size(240, 101);
            this.DGV.TabIndex = 8;
            this.DGV.Visible = false;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 307);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Selected Printer:";
            // 
            // SERLabelList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(180)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(384, 498);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.rb1Label);
            this.Controls.Add(this.bPrint);
            this.Controls.Add(this.rb4Labels);
            this.Controls.Add(this.rb3Labels);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SERLabelList";
            this.Text = "SER Label List";
            this.Load += new System.EventHandler(this.SERLabelList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rb1Label;
        private System.Windows.Forms.Button bPrint;
        private System.Windows.Forms.RadioButton rb4Labels;
        private System.Windows.Forms.RadioButton rb3Labels;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Label label1;
    }
}

