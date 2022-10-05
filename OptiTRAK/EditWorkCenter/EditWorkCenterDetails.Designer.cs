namespace EditWorkCenter
{
    partial class EditWorkCenterDetails
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
            this.tbWCdescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCostCenter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCostCenterDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCapacity = new System.Windows.Forms.TextBox();
            this.LworkCenter = new System.Windows.Forms.Label();
            this.bENTER = new System.Windows.Forms.Button();
            this.tbWorkCenter = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbWCdescription
            // 
            this.tbWCdescription.Location = new System.Drawing.Point(198, 82);
            this.tbWCdescription.Name = "tbWCdescription";
            this.tbWCdescription.Size = new System.Drawing.Size(227, 20);
            this.tbWCdescription.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(25, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "WORK CENTER DESCRIPTION:  ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "COST CENTER:";
            // 
            // tbCostCenter
            // 
            this.tbCostCenter.Location = new System.Drawing.Point(198, 143);
            this.tbCostCenter.Name = "tbCostCenter";
            this.tbCostCenter.Size = new System.Drawing.Size(227, 20);
            this.tbCostCenter.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "COST CENTER DESCRIPTION:";
            // 
            // tbCostCenterDescription
            // 
            this.tbCostCenterDescription.Location = new System.Drawing.Point(198, 201);
            this.tbCostCenterDescription.Name = "tbCostCenterDescription";
            this.tbCostCenterDescription.Size = new System.Drawing.Size(227, 20);
            this.tbCostCenterDescription.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "CAPACITY ( hours per day ):";
            // 
            // tbCapacity
            // 
            this.tbCapacity.Location = new System.Drawing.Point(198, 254);
            this.tbCapacity.Name = "tbCapacity";
            this.tbCapacity.Size = new System.Drawing.Size(227, 20);
            this.tbCapacity.TabIndex = 7;
            // 
            // LworkCenter
            // 
            this.LworkCenter.AutoSize = true;
            this.LworkCenter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LworkCenter.Location = new System.Drawing.Point(36, 31);
            this.LworkCenter.Name = "LworkCenter";
            this.LworkCenter.Size = new System.Drawing.Size(111, 13);
            this.LworkCenter.TabIndex = 9;
            this.LworkCenter.Text = "WORK CENTER:  ";
            // 
            // bENTER
            // 
            this.bENTER.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(85)))), ((int)(((byte)(35)))));
            this.bENTER.Location = new System.Drawing.Point(53, 320);
            this.bENTER.Name = "bENTER";
            this.bENTER.Size = new System.Drawing.Size(349, 55);
            this.bENTER.TabIndex = 10;
            this.bENTER.Text = "ENTER DATA";
            this.bENTER.UseVisualStyleBackColor = false;
            this.bENTER.Click += new System.EventHandler(this.bENTER_Click);
            // 
            // tbWorkCenter
            // 
            this.tbWorkCenter.Location = new System.Drawing.Point(198, 28);
            this.tbWorkCenter.Name = "tbWorkCenter";
            this.tbWorkCenter.Size = new System.Drawing.Size(227, 20);
            this.tbWorkCenter.TabIndex = 11;
            // 
            // EditWorkCenterDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(65)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(462, 428);
            this.Controls.Add(this.tbWorkCenter);
            this.Controls.Add(this.bENTER);
            this.Controls.Add(this.LworkCenter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbCapacity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbCostCenterDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCostCenter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbWCdescription);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "EditWorkCenterDetails";
            this.Text = "EditWorkCenterDetails";
            this.Load += new System.EventHandler(this.EditWorkCenterDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbWCdescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCostCenter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCostCenterDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCapacity;
        private System.Windows.Forms.Label LworkCenter;
        private System.Windows.Forms.Button bENTER;
        private System.Windows.Forms.TextBox tbWorkCenter;
    }
}