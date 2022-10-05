namespace PhoneList
{
    partial class F2EditEmployee
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
            this.tbLast = new System.Windows.Forms.TextBox();
            this.tbFirst = new System.Windows.Forms.TextBox();
            this.tbExt = new System.Windows.Forms.TextBox();
            this.tbDept = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.bEnterData = new System.Windows.Forms.Button();
            this.cbLocation = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tbLast
            // 
            this.tbLast.Location = new System.Drawing.Point(198, 53);
            this.tbLast.Name = "tbLast";
            this.tbLast.Size = new System.Drawing.Size(271, 26);
            this.tbLast.TabIndex = 0;
            // 
            // tbFirst
            // 
            this.tbFirst.Location = new System.Drawing.Point(198, 100);
            this.tbFirst.Name = "tbFirst";
            this.tbFirst.Size = new System.Drawing.Size(271, 26);
            this.tbFirst.TabIndex = 1;
            // 
            // tbExt
            // 
            this.tbExt.Location = new System.Drawing.Point(198, 197);
            this.tbExt.Name = "tbExt";
            this.tbExt.Size = new System.Drawing.Size(271, 26);
            this.tbExt.TabIndex = 3;
            // 
            // tbDept
            // 
            this.tbDept.Location = new System.Drawing.Point(198, 294);
            this.tbDept.Name = "tbDept";
            this.tbDept.Size = new System.Drawing.Size(100, 26);
            this.tbDept.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Last Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "First Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Phone Extension";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 297);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Department";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(49, 347);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "Location";
            // 
            // bEnterData
            // 
            this.bEnterData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(150)))), ((int)(((byte)(10)))));
            this.bEnterData.Location = new System.Drawing.Point(53, 399);
            this.bEnterData.Name = "bEnterData";
            this.bEnterData.Size = new System.Drawing.Size(416, 46);
            this.bEnterData.TabIndex = 16;
            this.bEnterData.Text = "ENTER DATA";
            this.bEnterData.UseVisualStyleBackColor = false;
            this.bEnterData.Click += new System.EventHandler(this.bEnterData_Click);
            // 
            // cbLocation
            // 
            this.cbLocation.FormattingEnabled = true;
            this.cbLocation.Location = new System.Drawing.Point(198, 344);
            this.cbLocation.Name = "cbLocation";
            this.cbLocation.Size = new System.Drawing.Size(271, 28);
            this.cbLocation.TabIndex = 18;
            this.cbLocation.Enter += new System.EventHandler(this.cbLocation_Enter);
            // 
            // F2EditEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(50)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(513, 519);
            this.Controls.Add(this.cbLocation);
            this.Controls.Add(this.bEnterData);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDept);
            this.Controls.Add(this.tbExt);
            this.Controls.Add(this.tbFirst);
            this.Controls.Add(this.tbLast);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F2EditEmployee";
            this.Text = "Edit Phone List Employee";
            this.Load += new System.EventHandler(this.F2EditEmployee_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLast;
        private System.Windows.Forms.TextBox tbFirst;
        private System.Windows.Forms.TextBox tbExt;
        private System.Windows.Forms.TextBox tbDept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button bEnterData;
        private System.Windows.Forms.ComboBox cbLocation;
    }
}

