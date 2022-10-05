namespace LabelPrint
{
    partial class F3_Non_Standard_Parts
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
            this.tbPartNumber = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bEnter = new System.Windows.Forms.Button();
            this.bBack = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbRevision = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbPartNumber
            // 
            this.tbPartNumber.Location = new System.Drawing.Point(146, 41);
            this.tbPartNumber.Name = "tbPartNumber";
            this.tbPartNumber.Size = new System.Drawing.Size(128, 26);
            this.tbPartNumber.TabIndex = 4;
            this.tbPartNumber.Leave += new System.EventHandler(this.tbPartNumber_Leave);
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(146, 88);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(239, 26);
            this.tbDescription.TabIndex = 1;
            this.tbDescription.Leave += new System.EventHandler(this.tbDescription_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Part Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description";
            // 
            // bEnter
            // 
            this.bEnter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(150)))), ((int)(((byte)(60)))));
            this.bEnter.Location = new System.Drawing.Point(51, 191);
            this.bEnter.Name = "bEnter";
            this.bEnter.Size = new System.Drawing.Size(334, 57);
            this.bEnter.TabIndex = 2;
            this.bEnter.Text = "ENTER DATA";
            this.bEnter.UseVisualStyleBackColor = false;
            this.bEnter.Click += new System.EventHandler(this.bEnter_Click);
            // 
            // bBack
            // 
            this.bBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(150)))), ((int)(((byte)(20)))));
            this.bBack.Location = new System.Drawing.Point(51, 274);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(334, 57);
            this.bBack.TabIndex = 3;
            this.bBack.Text = "BACK";
            this.bBack.UseVisualStyleBackColor = false;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Revision";
            // 
            // tbRevision
            // 
            this.tbRevision.Location = new System.Drawing.Point(146, 134);
            this.tbRevision.Name = "tbRevision";
            this.tbRevision.Size = new System.Drawing.Size(40, 26);
            this.tbRevision.TabIndex = 6;
            // 
            // F3_Non_Standard_Parts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(150)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(426, 364);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbRevision);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.bEnter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbPartNumber);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F3_Non_Standard_Parts";
            this.Text = "F3_Non_Standard_Parts";
            this.Load += new System.EventHandler(this.F3_Non_Standard_Parts_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPartNumber;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bEnter;
        private System.Windows.Forms.Button bBack;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbRevision;
    }
}