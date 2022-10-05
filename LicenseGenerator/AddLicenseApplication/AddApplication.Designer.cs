namespace AddLicenseApplication
{
    partial class F1AddApplication
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
            this.rbMTP = new System.Windows.Forms.RadioButton();
            this.rbMX = new System.Windows.Forms.RadioButton();
            this.rbZMP = new System.Windows.Forms.RadioButton();
            this.tbApplication = new System.Windows.Forms.TextBox();
            this.bAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbMTP
            // 
            this.rbMTP.AutoSize = true;
            this.rbMTP.Location = new System.Drawing.Point(148, 50);
            this.rbMTP.Name = "rbMTP";
            this.rbMTP.Size = new System.Drawing.Size(92, 24);
            this.rbMTP.TabIndex = 0;
            this.rbMTP.TabStop = true;
            this.rbMTP.Text = "MetroPro";
            this.rbMTP.UseVisualStyleBackColor = true;
            // 
            // rbMX
            // 
            this.rbMX.AutoSize = true;
            this.rbMX.Location = new System.Drawing.Point(148, 90);
            this.rbMX.Name = "rbMX";
            this.rbMX.Size = new System.Drawing.Size(47, 24);
            this.rbMX.TabIndex = 1;
            this.rbMX.TabStop = true;
            this.rbMX.Text = "Mx";
            this.rbMX.UseVisualStyleBackColor = true;
            // 
            // rbZMP
            // 
            this.rbZMP.AutoSize = true;
            this.rbZMP.Location = new System.Drawing.Point(148, 130);
            this.rbZMP.Name = "rbZMP";
            this.rbZMP.Size = new System.Drawing.Size(85, 24);
            this.rbZMP.TabIndex = 2;
            this.rbZMP.TabStop = true;
            this.rbZMP.Text = "ZeMaps";
            this.rbZMP.UseVisualStyleBackColor = true;
            // 
            // tbApplication
            // 
            this.tbApplication.Location = new System.Drawing.Point(87, 202);
            this.tbApplication.Name = "tbApplication";
            this.tbApplication.Size = new System.Drawing.Size(249, 26);
            this.tbApplication.TabIndex = 3;
            // 
            // bAdd
            // 
            this.bAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(180)))), ((int)(((byte)(0)))));
            this.bAdd.Location = new System.Drawing.Point(111, 283);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(185, 55);
            this.bAdd.TabIndex = 4;
            this.bAdd.Text = "ADD";
            this.bAdd.UseVisualStyleBackColor = false;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // F1AddApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(426, 403);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.tbApplication);
            this.Controls.Add(this.rbZMP);
            this.Controls.Add(this.rbMX);
            this.Controls.Add(this.rbMTP);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F1AddApplication";
            this.Text = "F1 Add Application";
            this.Load += new System.EventHandler(this.F1AddApplication_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbMTP;
        private System.Windows.Forms.RadioButton rbMX;
        private System.Windows.Forms.RadioButton rbZMP;
        private System.Windows.Forms.TextBox tbApplication;
        private System.Windows.Forms.Button bAdd;
    }
}

