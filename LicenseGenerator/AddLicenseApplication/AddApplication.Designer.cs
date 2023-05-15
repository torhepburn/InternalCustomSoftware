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
            this.tbApplication = new System.Windows.Forms.TextBox();
            this.bAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAssembly = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbApplication
            // 
            this.tbApplication.Location = new System.Drawing.Point(87, 58);
            this.tbApplication.Name = "tbApplication";
            this.tbApplication.Size = new System.Drawing.Size(249, 26);
            this.tbApplication.TabIndex = 3;
            // 
            // bAdd
            // 
            this.bAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(180)))), ((int)(((byte)(0)))));
            this.bAdd.Location = new System.Drawing.Point(116, 198);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(185, 55);
            this.bAdd.TabIndex = 4;
            this.bAdd.Text = "ADD";
            this.bAdd.UseVisualStyleBackColor = false;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Application Required by Software to function";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(237, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Application Display for Assembly";
            // 
            // tbAssembly
            // 
            this.tbAssembly.Location = new System.Drawing.Point(87, 135);
            this.tbAssembly.Name = "tbAssembly";
            this.tbAssembly.Size = new System.Drawing.Size(249, 26);
            this.tbAssembly.TabIndex = 6;
            // 
            // F1AddApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(426, 301);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbAssembly);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.tbApplication);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F1AddApplication";
            this.Text = "F1 Add Application";
            this.Load += new System.EventHandler(this.F1AddApplication_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbApplication;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbAssembly;
    }
}

