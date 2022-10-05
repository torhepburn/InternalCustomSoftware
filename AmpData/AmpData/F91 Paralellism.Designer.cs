namespace AmpData
{
    partial class F91_Paralellism
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
            this.LserialNumber = new System.Windows.Forms.Label();
            this.bEnterData = new System.Windows.Forms.Button();
            this.dtpParaDate = new System.Windows.Forms.DateTimePicker();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.tbParaInsp = new System.Windows.Forms.TextBox();
            this.tbParallelism = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSeconds = new System.Windows.Forms.TextBox();
            this.rbShort = new System.Windows.Forms.RadioButton();
            this.rbLong = new System.Windows.Forms.RadioButton();
            this.rbDiagonal = new System.Windows.Forms.RadioButton();
            this.bCalculate = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LserialNumber
            // 
            this.LserialNumber.AutoSize = true;
            this.LserialNumber.Location = new System.Drawing.Point(65, 56);
            this.LserialNumber.Name = "LserialNumber";
            this.LserialNumber.Size = new System.Drawing.Size(51, 20);
            this.LserialNumber.TabIndex = 151;
            this.LserialNumber.Text = "label1";
            // 
            // bEnterData
            // 
            this.bEnterData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(50)))));
            this.bEnterData.Location = new System.Drawing.Point(93, 251);
            this.bEnterData.Name = "bEnterData";
            this.bEnterData.Size = new System.Drawing.Size(662, 62);
            this.bEnterData.TabIndex = 9;
            this.bEnterData.Text = "ENTER DATA";
            this.bEnterData.UseVisualStyleBackColor = false;
            this.bEnterData.Click += new System.EventHandler(this.bEnterData_Click);
            // 
            // dtpParaDate
            // 
            this.dtpParaDate.CustomFormat = "MM/dd/yyyy";
            this.dtpParaDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpParaDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpParaDate.Location = new System.Drawing.Point(680, 181);
            this.dtpParaDate.Name = "dtpParaDate";
            this.dtpParaDate.Size = new System.Drawing.Size(102, 24);
            this.dtpParaDate.TabIndex = 8;
            this.dtpParaDate.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(379, 184);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(43, 13);
            this.label27.TabIndex = 159;
            this.label27.Text = "microns";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(341, 184);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(19, 13);
            this.label28.TabIndex = 158;
            this.label28.Text = "16";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(313, 184);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(13, 13);
            this.label29.TabIndex = 157;
            this.label29.Text = "0";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(275, 184);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(13, 13);
            this.label30.TabIndex = 156;
            this.label30.Text = "0";
            // 
            // tbParaInsp
            // 
            this.tbParaInsp.Location = new System.Drawing.Point(564, 179);
            this.tbParaInsp.Name = "tbParaInsp";
            this.tbParaInsp.Size = new System.Drawing.Size(100, 26);
            this.tbParaInsp.TabIndex = 7;
            // 
            // tbParallelism
            // 
            this.tbParallelism.Location = new System.Drawing.Point(448, 179);
            this.tbParallelism.Name = "tbParallelism";
            this.tbParallelism.Size = new System.Drawing.Size(100, 26);
            this.tbParallelism.TabIndex = 6;
            this.tbParallelism.TextChanged += new System.EventHandler(this.tbParallelism_TextChanged_1);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(63, 179);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(141, 20);
            this.label31.TabIndex = 153;
            this.label31.Text = "Parallelism S1 - S2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(251, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 13);
            this.label4.TabIndex = 161;
            this.label4.Text = "Nominal       (-)        (+)     Units";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(579, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 162;
            this.label1.Text = "Initials";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(370, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 164;
            this.label3.Text = "Seconds";
            // 
            // tbSeconds
            // 
            this.tbSeconds.Location = new System.Drawing.Point(448, 55);
            this.tbSeconds.Name = "tbSeconds";
            this.tbSeconds.Size = new System.Drawing.Size(100, 26);
            this.tbSeconds.TabIndex = 1;
            // 
            // rbShort
            // 
            this.rbShort.AutoSize = true;
            this.rbShort.Checked = true;
            this.rbShort.Location = new System.Drawing.Point(570, 28);
            this.rbShort.Name = "rbShort";
            this.rbShort.Size = new System.Drawing.Size(66, 24);
            this.rbShort.TabIndex = 2;
            this.rbShort.TabStop = true;
            this.rbShort.Text = "Short";
            this.rbShort.UseVisualStyleBackColor = true;
            // 
            // rbLong
            // 
            this.rbLong.AutoSize = true;
            this.rbLong.Location = new System.Drawing.Point(570, 57);
            this.rbLong.Name = "rbLong";
            this.rbLong.Size = new System.Drawing.Size(63, 24);
            this.rbLong.TabIndex = 3;
            this.rbLong.Text = "Long";
            this.rbLong.UseVisualStyleBackColor = true;
            // 
            // rbDiagonal
            // 
            this.rbDiagonal.AutoSize = true;
            this.rbDiagonal.Location = new System.Drawing.Point(570, 87);
            this.rbDiagonal.Name = "rbDiagonal";
            this.rbDiagonal.Size = new System.Drawing.Size(90, 24);
            this.rbDiagonal.TabIndex = 4;
            this.rbDiagonal.Text = "Diagonal";
            this.rbDiagonal.UseVisualStyleBackColor = true;
            // 
            // bCalculate
            // 
            this.bCalculate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.bCalculate.Location = new System.Drawing.Point(680, 21);
            this.bCalculate.Name = "bCalculate";
            this.bCalculate.Size = new System.Drawing.Size(132, 83);
            this.bCalculate.TabIndex = 5;
            this.bCalculate.Text = "CALCULATE MICRONS";
            this.bCalculate.UseVisualStyleBackColor = false;
            this.bCalculate.Click += new System.EventHandler(this.bCalculate_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(694, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 20);
            this.label7.TabIndex = 168;
            this.label7.Text = "Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(578, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.TabIndex = 167;
            this.label6.Text = "Inspector";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(460, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 166;
            this.label5.Text = "Actual";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 165;
            this.label2.Text = "Requirement";
            // 
            // F91_Paralellism
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(845, 378);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bCalculate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbSeconds);
            this.Controls.Add(this.rbDiagonal);
            this.Controls.Add(this.rbLong);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbShort);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpParaDate);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.tbParaInsp);
            this.Controls.Add(this.tbParallelism);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.bEnterData);
            this.Controls.Add(this.LserialNumber);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F91_Paralellism";
            this.Text = "F91_Paralellism";
            this.Load += new System.EventHandler(this.F91_Paralellism_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LserialNumber;
        private System.Windows.Forms.Button bEnterData;
        private System.Windows.Forms.DateTimePicker dtpParaDate;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox tbParaInsp;
        private System.Windows.Forms.TextBox tbParallelism;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSeconds;
        private System.Windows.Forms.RadioButton rbShort;
        private System.Windows.Forms.RadioButton rbLong;
        private System.Windows.Forms.RadioButton rbDiagonal;
        private System.Windows.Forms.Button bCalculate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
    }
}