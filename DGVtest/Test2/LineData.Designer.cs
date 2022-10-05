namespace Test2
{
    partial class LineData
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
            this.tbItemCode = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.tbBoxes = new System.Windows.Forms.TextBox();
            this.tbInstallOn = new System.Windows.Forms.TextBox();
            this.tbKitWith = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbItemCode
            // 
            this.tbItemCode.Location = new System.Drawing.Point(225, 111);
            this.tbItemCode.Name = "tbItemCode";
            this.tbItemCode.Size = new System.Drawing.Size(241, 30);
            this.tbItemCode.TabIndex = 0;
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(225, 179);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(478, 30);
            this.tbDescription.TabIndex = 1;
            // 
            // tbQuantity
            // 
            this.tbQuantity.Location = new System.Drawing.Point(225, 245);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(85, 30);
            this.tbQuantity.TabIndex = 2;
            // 
            // tbBoxes
            // 
            this.tbBoxes.Location = new System.Drawing.Point(225, 314);
            this.tbBoxes.Name = "tbBoxes";
            this.tbBoxes.Size = new System.Drawing.Size(85, 30);
            this.tbBoxes.TabIndex = 3;
            // 
            // tbInstallOn
            // 
            this.tbInstallOn.Location = new System.Drawing.Point(225, 381);
            this.tbInstallOn.Name = "tbInstallOn";
            this.tbInstallOn.Size = new System.Drawing.Size(241, 30);
            this.tbInstallOn.TabIndex = 4;
            // 
            // tbKitWith
            // 
            this.tbKitWith.Location = new System.Drawing.Point(225, 443);
            this.tbKitWith.Name = "tbKitWith";
            this.tbKitWith.Size = new System.Drawing.Size(241, 30);
            this.tbKitWith.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Item Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Quantity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 314);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Boxes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 384);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Install on";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 446);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Kit with";
            // 
            // bSave
            // 
            this.bSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(100)))));
            this.bSave.Location = new System.Drawing.Point(135, 532);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(617, 71);
            this.bSave.TabIndex = 12;
            this.bSave.Text = "Save Data";
            this.bSave.UseVisualStyleBackColor = false;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // LineData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(230)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(918, 703);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbKitWith);
            this.Controls.Add(this.tbInstallOn);
            this.Controls.Add(this.tbBoxes);
            this.Controls.Add(this.tbQuantity);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbItemCode);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LineData";
            this.Text = "LineData";
            this.Load += new System.EventHandler(this.LineData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbItemCode;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.TextBox tbBoxes;
        private System.Windows.Forms.TextBox tbInstallOn;
        private System.Windows.Forms.TextBox tbKitWith;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bSave;
    }
}