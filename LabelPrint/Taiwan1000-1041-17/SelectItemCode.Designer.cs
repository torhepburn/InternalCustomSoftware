namespace Taiwan1000_1041_17
{
    partial class SelectItemCode
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
            this.B11 = new System.Windows.Forms.Button();
            this.B01 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // B11
            // 
            this.B11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.B11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.B11.Location = new System.Drawing.Point(60, 146);
            this.B11.Name = "B11";
            this.B11.Size = new System.Drawing.Size(164, 47);
            this.B11.TabIndex = 3;
            this.B11.Text = "6405-8504-04";
            this.B11.UseVisualStyleBackColor = false;
            this.B11.Click += new System.EventHandler(this.B11_Click);
            // 
            // B01
            // 
            this.B01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.B01.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.B01.Location = new System.Drawing.Point(60, 70);
            this.B01.Name = "B01";
            this.B01.Size = new System.Drawing.Size(164, 47);
            this.B01.TabIndex = 2;
            this.B01.Text = "6450-8509-01";
            this.B01.UseVisualStyleBackColor = false;
            this.B01.Click += new System.EventHandler(this.B01_Click);
            // 
            // SelectItemCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.B11);
            this.Controls.Add(this.B01);
            this.Name = "SelectItemCode";
            this.Text = "SelectItemCode";
            this.Load += new System.EventHandler(this.SelectItemCode_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button B11;
        private System.Windows.Forms.Button B01;
    }
}