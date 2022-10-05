namespace CalibrationManager
{
    partial class f63_Calibration_Interval
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
            this.bSetCalbyType = new System.Windows.Forms.Button();
            this.LselectType = new System.Windows.Forms.Label();
            this.comBoxType = new System.Windows.Forms.ComboBox();
            this.Linterval = new System.Windows.Forms.Label();
            this.mtbMonths = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // bSetCalbyType
            // 
            this.bSetCalbyType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSetCalbyType.Location = new System.Drawing.Point(81, 277);
            this.bSetCalbyType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bSetCalbyType.Name = "bSetCalbyType";
            this.bSetCalbyType.Size = new System.Drawing.Size(254, 74);
            this.bSetCalbyType.TabIndex = 0;
            this.bSetCalbyType.Text = "Set Calibration Interval";
            this.bSetCalbyType.UseVisualStyleBackColor = true;
            this.bSetCalbyType.Click += new System.EventHandler(this.bSetCalbyType_Click);
            // 
            // LselectType
            // 
            this.LselectType.AutoSize = true;
            this.LselectType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LselectType.Location = new System.Drawing.Point(77, 37);
            this.LselectType.Name = "LselectType";
            this.LselectType.Size = new System.Drawing.Size(108, 20);
            this.LselectType.TabIndex = 2;
            this.LselectType.Text = "Select Type:";
            // 
            // comBoxType
            // 
            this.comBoxType.FormattingEnabled = true;
            this.comBoxType.Location = new System.Drawing.Point(81, 84);
            this.comBoxType.Name = "comBoxType";
            this.comBoxType.Size = new System.Drawing.Size(254, 28);
            this.comBoxType.TabIndex = 3;
            // 
            // Linterval
            // 
            this.Linterval.AutoSize = true;
            this.Linterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Linterval.Location = new System.Drawing.Point(95, 156);
            this.Linterval.Name = "Linterval";
            this.Linterval.Size = new System.Drawing.Size(216, 20);
            this.Linterval.TabIndex = 4;
            this.Linterval.Text = "Choose Interval (Months):";
            // 
            // mtbMonths
            // 
            this.mtbMonths.Location = new System.Drawing.Point(177, 204);
            this.mtbMonths.Mask = "000";
            this.mtbMonths.Name = "mtbMonths";
            this.mtbMonths.Size = new System.Drawing.Size(44, 26);
            this.mtbMonths.TabIndex = 5;
            // 
            // f63_Calibration_Interval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(427, 408);
            this.Controls.Add(this.mtbMonths);
            this.Controls.Add(this.Linterval);
            this.Controls.Add(this.comBoxType);
            this.Controls.Add(this.LselectType);
            this.Controls.Add(this.bSetCalbyType);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "f63_Calibration_Interval";
            this.Text = "f63 Calibration Interval";
            this.Load += new System.EventHandler(this.f63_Calibration_Interval_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bSetCalbyType;
        private System.Windows.Forms.Label LselectType;
        private System.Windows.Forms.ComboBox comBoxType;
        private System.Windows.Forms.Label Linterval;
        private System.Windows.Forms.MaskedTextBox mtbMonths;
    }
}