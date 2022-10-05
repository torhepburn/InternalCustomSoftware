namespace PlannerIDLabels
{
    partial class SelectRange
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DGVstart = new System.Windows.Forms.DataGridView();
            this.DGVend = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rbSmall = new System.Windows.Forms.RadioButton();
            this.rbLarge = new System.Windows.Forms.RadioButton();
            this.rbQ1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbQ4 = new System.Windows.Forms.RadioButton();
            this.rbQ3 = new System.Windows.Forms.RadioButton();
            this.rbQ2 = new System.Windows.Forms.RadioButton();
            this.Lprinter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVstart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVend)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGVstart
            // 
            this.DGVstart.AllowUserToAddRows = false;
            this.DGVstart.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.OrangeRed;
            this.DGVstart.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.DGVstart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DGVstart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVstart.Location = new System.Drawing.Point(44, 224);
            this.DGVstart.Margin = new System.Windows.Forms.Padding(4);
            this.DGVstart.Name = "DGVstart";
            this.DGVstart.ReadOnly = true;
            this.DGVstart.RowHeadersVisible = false;
            this.DGVstart.Size = new System.Drawing.Size(84, 288);
            this.DGVstart.TabIndex = 21;
            this.DGVstart.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVstart_CellClick);
            // 
            // DGVend
            // 
            this.DGVend.AllowUserToAddRows = false;
            this.DGVend.AllowUserToDeleteRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.OrangeRed;
            this.DGVend.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.DGVend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DGVend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVend.Location = new System.Drawing.Point(196, 224);
            this.DGVend.Margin = new System.Windows.Forms.Padding(4);
            this.DGVend.Name = "DGVend";
            this.DGVend.ReadOnly = true;
            this.DGVend.RowHeadersVisible = false;
            this.DGVend.Size = new System.Drawing.Size(84, 288);
            this.DGVend.TabIndex = 22;
            this.DGVend.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVend_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Start SFO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "End SFO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(238, 51);
            this.label3.TabIndex = 25;
            this.label3.Text = "Select a Start SFO and an End SFO.\r\nAfter you select the End SFO the \r\nlabels wil" +
    "l print.";
            // 
            // rbSmall
            // 
            this.rbSmall.AutoSize = true;
            this.rbSmall.Location = new System.Drawing.Point(50, 25);
            this.rbSmall.Name = "rbSmall";
            this.rbSmall.Size = new System.Drawing.Size(99, 21);
            this.rbSmall.TabIndex = 26;
            this.rbSmall.TabStop = true;
            this.rbSmall.Text = "Small Label";
            this.rbSmall.UseVisualStyleBackColor = true;
            this.rbSmall.CheckedChanged += new System.EventHandler(this.rbSmall_CheckedChanged);
            // 
            // rbLarge
            // 
            this.rbLarge.AutoSize = true;
            this.rbLarge.Location = new System.Drawing.Point(175, 25);
            this.rbLarge.Name = "rbLarge";
            this.rbLarge.Size = new System.Drawing.Size(102, 21);
            this.rbLarge.TabIndex = 27;
            this.rbLarge.TabStop = true;
            this.rbLarge.Text = "Large Label";
            this.rbLarge.UseVisualStyleBackColor = true;
            this.rbLarge.CheckedChanged += new System.EventHandler(this.rbLarge_CheckedChanged);
            // 
            // rbQ1
            // 
            this.rbQ1.AutoSize = true;
            this.rbQ1.Location = new System.Drawing.Point(16, 22);
            this.rbQ1.Name = "rbQ1";
            this.rbQ1.Size = new System.Drawing.Size(53, 21);
            this.rbQ1.TabIndex = 27;
            this.rbQ1.TabStop = true;
            this.rbQ1.Text = "One";
            this.rbQ1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(190)))), ((int)(((byte)(120)))));
            this.groupBox1.Controls.Add(this.rbQ4);
            this.groupBox1.Controls.Add(this.rbQ3);
            this.groupBox1.Controls.Add(this.rbQ2);
            this.groupBox1.Controls.Add(this.rbQ1);
            this.groupBox1.Location = new System.Drawing.Point(13, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 56);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quantity";
            // 
            // rbQ4
            // 
            this.rbQ4.AutoSize = true;
            this.rbQ4.Location = new System.Drawing.Point(202, 22);
            this.rbQ4.Name = "rbQ4";
            this.rbQ4.Size = new System.Drawing.Size(55, 21);
            this.rbQ4.TabIndex = 30;
            this.rbQ4.TabStop = true;
            this.rbQ4.Text = "Four";
            this.rbQ4.UseVisualStyleBackColor = true;
            // 
            // rbQ3
            // 
            this.rbQ3.AutoSize = true;
            this.rbQ3.Location = new System.Drawing.Point(133, 22);
            this.rbQ3.Name = "rbQ3";
            this.rbQ3.Size = new System.Drawing.Size(64, 21);
            this.rbQ3.TabIndex = 29;
            this.rbQ3.TabStop = true;
            this.rbQ3.Text = "Three";
            this.rbQ3.UseVisualStyleBackColor = true;
            // 
            // rbQ2
            // 
            this.rbQ2.AutoSize = true;
            this.rbQ2.Location = new System.Drawing.Point(75, 22);
            this.rbQ2.Name = "rbQ2";
            this.rbQ2.Size = new System.Drawing.Size(52, 21);
            this.rbQ2.TabIndex = 28;
            this.rbQ2.TabStop = true;
            this.rbQ2.Text = "Two";
            this.rbQ2.UseVisualStyleBackColor = true;
            // 
            // Lprinter
            // 
            this.Lprinter.AutoSize = true;
            this.Lprinter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lprinter.Location = new System.Drawing.Point(2, 531);
            this.Lprinter.Name = "Lprinter";
            this.Lprinter.Size = new System.Drawing.Size(92, 20);
            this.Lprinter.TabIndex = 29;
            this.Lprinter.Text = "Printing on :";
            // 
            // SelectRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(190)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(323, 560);
            this.Controls.Add(this.Lprinter);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rbLarge);
            this.Controls.Add(this.rbSmall);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGVend);
            this.Controls.Add(this.DGVstart);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SelectRange";
            this.Text = "SelectRange";
            this.Load += new System.EventHandler(this.SelectRange_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVstart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVend)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVstart;
        private System.Windows.Forms.DataGridView DGVend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbSmall;
        private System.Windows.Forms.RadioButton rbLarge;
        private System.Windows.Forms.RadioButton rbQ1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbQ4;
        private System.Windows.Forms.RadioButton rbQ3;
        private System.Windows.Forms.RadioButton rbQ2;
        private System.Windows.Forms.Label Lprinter;
    }
}