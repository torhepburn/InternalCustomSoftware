namespace Taiwan1000_1041_05
{
    partial class LabelSelection
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
            this.B01 = new System.Windows.Forms.Button();
            this.B11 = new System.Windows.Forms.Button();
            this.bFreeText = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // B01
            // 
            this.B01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(0)))));
            this.B01.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.B01.Location = new System.Drawing.Point(54, 51);
            this.B01.Name = "B01";
            this.B01.Size = new System.Drawing.Size(164, 47);
            this.B01.TabIndex = 0;
            this.B01.Text = "6311-0100-01";
            this.B01.UseVisualStyleBackColor = false;
            this.B01.Click += new System.EventHandler(this.B01_Click);
            // 
            // B11
            // 
            this.B11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(250)))), ((int)(((byte)(0)))));
            this.B11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.B11.Location = new System.Drawing.Point(54, 127);
            this.B11.Name = "B11";
            this.B11.Size = new System.Drawing.Size(164, 47);
            this.B11.TabIndex = 1;
            this.B11.Text = "6311-0100-11";
            this.B11.UseVisualStyleBackColor = false;
            this.B11.Click += new System.EventHandler(this.B11_Click);
            // 
            // bFreeText
            // 
            this.bFreeText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(216)))), ((int)(((byte)(255)))));
            this.bFreeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bFreeText.Location = new System.Drawing.Point(54, 200);
            this.bFreeText.Name = "bFreeText";
            this.bFreeText.Size = new System.Drawing.Size(164, 53);
            this.bFreeText.TabIndex = 15;
            this.bFreeText.Text = "FREE TEXT";
            this.bFreeText.UseVisualStyleBackColor = false;
            this.bFreeText.Click += new System.EventHandler(this.bFreeText_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "label1";
            // 
            // LabelSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 293);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bFreeText);
            this.Controls.Add(this.B11);
            this.Controls.Add(this.B01);
            this.Name = "LabelSelection";
            this.Text = "1000-1041-05 ID & SN Label";
            this.Load += new System.EventHandler(this.LabelSelection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B01;
        private System.Windows.Forms.Button B11;
        private System.Windows.Forms.Button bFreeText;
        private System.Windows.Forms.Label label1;
    }
}