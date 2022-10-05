namespace PCC_Failure_Log
{
    partial class Select_Purpose
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
            this.Ltask = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bProduction = new System.Windows.Forms.Button();
            this.bMCertTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Ltask
            // 
            this.Ltask.AutoSize = true;
            this.Ltask.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ltask.Location = new System.Drawing.Point(47, -31);
            this.Ltask.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Ltask.Name = "Ltask";
            this.Ltask.Size = new System.Drawing.Size(221, 31);
            this.Ltask.TabIndex = 5;
            this.Ltask.Text = "Select Purpose:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 31);
            this.label1.TabIndex = 8;
            this.label1.Text = "Select Purpose:";
            // 
            // bProduction
            // 
            this.bProduction.BackColor = System.Drawing.Color.Yellow;
            this.bProduction.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bProduction.Location = new System.Drawing.Point(40, 275);
            this.bProduction.Name = "bProduction";
            this.bProduction.Size = new System.Drawing.Size(242, 90);
            this.bProduction.TabIndex = 7;
            this.bProduction.Text = "Production";
            this.bProduction.UseVisualStyleBackColor = false;
            this.bProduction.Click += new System.EventHandler(this.bProduction_Click);
            // 
            // bMCertTest
            // 
            this.bMCertTest.BackColor = System.Drawing.Color.Olive;
            this.bMCertTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bMCertTest.Location = new System.Drawing.Point(40, 153);
            this.bMCertTest.Name = "bMCertTest";
            this.bMCertTest.Size = new System.Drawing.Size(242, 90);
            this.bMCertTest.TabIndex = 6;
            this.bMCertTest.Text = "M Cert Test";
            this.bMCertTest.UseVisualStyleBackColor = false;
            this.bMCertTest.Click += new System.EventHandler(this.bMCertTest_Click);
            // 
            // Select_Purpose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(150)))), ((int)(((byte)(10)))));
            this.ClientSize = new System.Drawing.Size(326, 420);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bProduction);
            this.Controls.Add(this.bMCertTest);
            this.Controls.Add(this.Ltask);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "Select_Purpose";
            this.Text = "Select_Purpose";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Ltask;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bProduction;
        private System.Windows.Forms.Button bMCertTest;
    }
}