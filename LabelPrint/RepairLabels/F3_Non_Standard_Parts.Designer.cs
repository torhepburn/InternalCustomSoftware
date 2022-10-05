namespace RepairLabels
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
            this.bBack = new System.Windows.Forms.Button();
            this.bEnter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbPartNumber = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bBack
            // 
            this.bBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(150)))), ((int)(((byte)(20)))));
            this.bBack.Location = new System.Drawing.Point(53, 266);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(334, 57);
            this.bBack.TabIndex = 8;
            this.bBack.Text = "BACK";
            this.bBack.UseVisualStyleBackColor = false;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // bEnter
            // 
            this.bEnter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(150)))), ((int)(((byte)(60)))));
            this.bEnter.Location = new System.Drawing.Point(53, 183);
            this.bEnter.Name = "bEnter";
            this.bEnter.Size = new System.Drawing.Size(334, 57);
            this.bEnter.TabIndex = 6;
            this.bEnter.Text = "ENTER DATA";
            this.bEnter.UseVisualStyleBackColor = false;
            this.bEnter.Click += new System.EventHandler(this.bEnter_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Part Number";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(148, 116);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(239, 23);
            this.tbDescription.TabIndex = 5;
            this.tbDescription.Leave += new System.EventHandler(this.tbDescription_Leave);
            // 
            // tbPartNumber
            // 
            this.tbPartNumber.Location = new System.Drawing.Point(148, 48);
            this.tbPartNumber.Name = "tbPartNumber";
            this.tbPartNumber.Size = new System.Drawing.Size(128, 23);
            this.tbPartNumber.TabIndex = 10;
            this.tbPartNumber.Leave += new System.EventHandler(this.tbPartNumber_Leave);
            // 
            // F3_Non_Standard_Parts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(150)))));
            this.ClientSize = new System.Drawing.Size(442, 377);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.bEnter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbPartNumber);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "F3_Non_Standard_Parts";
            this.Text = "F3_Non_Standard_Parts";
            this.Load += new System.EventHandler(this.F3_Non_Standard_Parts_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bBack;
        private System.Windows.Forms.Button bEnter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbPartNumber;
    }
}