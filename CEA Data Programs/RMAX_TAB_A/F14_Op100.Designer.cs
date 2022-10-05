namespace RMAX_TAB_A
{
    partial class F14_Op100
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
            this.cbSurfaceMap = new System.Windows.Forms.CheckBox();
            this.dtpMapDate = new System.Windows.Forms.DateTimePicker();
            this.label30 = new System.Windows.Forms.Label();
            this.tbMapInsp = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.dtpThickDate = new System.Windows.Forms.DateTimePicker();
            this.bEnterData = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tbThickInsp = new System.Windows.Forms.TextBox();
            this.tbThickness = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LserialNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbSurfaceMap
            // 
            this.cbSurfaceMap.AutoSize = true;
            this.cbSurfaceMap.Location = new System.Drawing.Point(427, 249);
            this.cbSurfaceMap.Name = "cbSurfaceMap";
            this.cbSurfaceMap.Size = new System.Drawing.Size(89, 24);
            this.cbSurfaceMap.TabIndex = 260;
            this.cbSurfaceMap.Text = "Provided";
            this.cbSurfaceMap.UseVisualStyleBackColor = true;
            // 
            // dtpMapDate
            // 
            this.dtpMapDate.CustomFormat = "MM/dd/yyyy";
            this.dtpMapDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpMapDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMapDate.Location = new System.Drawing.Point(661, 246);
            this.dtpMapDate.Name = "dtpMapDate";
            this.dtpMapDate.Size = new System.Drawing.Size(102, 24);
            this.dtpMapDate.TabIndex = 259;
            this.dtpMapDate.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(233, 249);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(49, 13);
            this.label30.TabIndex = 258;
            this.label30.Text = "Provided";
            // 
            // tbMapInsp
            // 
            this.tbMapInsp.Location = new System.Drawing.Point(543, 244);
            this.tbMapInsp.Name = "tbMapInsp";
            this.tbMapInsp.Size = new System.Drawing.Size(100, 26);
            this.tbMapInsp.TabIndex = 257;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(42, 244);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(100, 20);
            this.label31.TabIndex = 256;
            this.label31.Text = "Surface Map";
            // 
            // dtpThickDate
            // 
            this.dtpThickDate.CustomFormat = "MM/dd/yyyy";
            this.dtpThickDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpThickDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpThickDate.Location = new System.Drawing.Point(661, 202);
            this.dtpThickDate.Name = "dtpThickDate";
            this.dtpThickDate.Size = new System.Drawing.Size(102, 24);
            this.dtpThickDate.TabIndex = 239;
            this.dtpThickDate.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpThickDate.Leave += new System.EventHandler(this.dtpThickDate_Leave);
            // 
            // bEnterData
            // 
            this.bEnterData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(150)))), ((int)(((byte)(50)))));
            this.bEnterData.Location = new System.Drawing.Point(59, 317);
            this.bEnterData.Name = "bEnterData";
            this.bEnterData.Size = new System.Drawing.Size(662, 62);
            this.bEnterData.TabIndex = 237;
            this.bEnterData.Text = "ENTER DATA";
            this.bEnterData.UseVisualStyleBackColor = false;
            this.bEnterData.Click += new System.EventHandler(this.bEnterData_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(358, 205);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 13);
            this.label12.TabIndex = 236;
            this.label12.Text = "mm";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(325, 205);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(28, 13);
            this.label13.TabIndex = 235;
            this.label13.Text = "1.00";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(288, 205);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(28, 13);
            this.label14.TabIndex = 234;
            this.label14.Text = "1.00";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(233, 205);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(19, 13);
            this.label15.TabIndex = 233;
            this.label15.Text = "80";
            // 
            // tbThickInsp
            // 
            this.tbThickInsp.Location = new System.Drawing.Point(543, 200);
            this.tbThickInsp.Name = "tbThickInsp";
            this.tbThickInsp.Size = new System.Drawing.Size(100, 26);
            this.tbThickInsp.TabIndex = 232;
            this.tbThickInsp.Leave += new System.EventHandler(this.tbThickInsp_Leave);
            // 
            // tbThickness
            // 
            this.tbThickness.Location = new System.Drawing.Point(427, 200);
            this.tbThickness.Name = "tbThickness";
            this.tbThickness.Size = new System.Drawing.Size(100, 26);
            this.tbThickness.TabIndex = 231;
            this.tbThickness.TextChanged += new System.EventHandler(this.tbThickness_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(42, 200);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(118, 20);
            this.label16.TabIndex = 230;
            this.label16.Text = "Final Thickness";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(679, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 20);
            this.label7.TabIndex = 225;
            this.label7.Text = "Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(551, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.TabIndex = 224;
            this.label6.Text = "Inspector";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(445, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 222;
            this.label5.Text = "Actual";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(235, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 13);
            this.label4.TabIndex = 220;
            this.label4.Text = "Nominal       (-)        (+)     Units";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(235, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 219;
            this.label3.Text = "Requirement";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 20);
            this.label2.TabIndex = 218;
            this.label2.Text = "Dimensional Inspection";
            // 
            // LserialNumber
            // 
            this.LserialNumber.AutoSize = true;
            this.LserialNumber.Location = new System.Drawing.Point(45, 29);
            this.LserialNumber.Name = "LserialNumber";
            this.LserialNumber.Size = new System.Drawing.Size(51, 20);
            this.LserialNumber.TabIndex = 216;
            this.LserialNumber.Text = "label1";
            // 
            // F14_Op100
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(820, 434);
            this.Controls.Add(this.cbSurfaceMap);
            this.Controls.Add(this.dtpMapDate);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.tbMapInsp);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.dtpThickDate);
            this.Controls.Add(this.bEnterData);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbThickInsp);
            this.Controls.Add(this.tbThickness);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LserialNumber);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F14_Op100";
            this.Text = "F14_Op100";
            this.Load += new System.EventHandler(this.F14_Op100_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbSurfaceMap;
        private System.Windows.Forms.DateTimePicker dtpMapDate;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox tbMapInsp;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.DateTimePicker dtpThickDate;
        private System.Windows.Forms.Button bEnterData;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbThickInsp;
        private System.Windows.Forms.TextBox tbThickness;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LserialNumber;
    }
}