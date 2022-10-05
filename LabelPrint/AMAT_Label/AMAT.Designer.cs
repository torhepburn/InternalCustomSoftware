namespace AMAT_Label
{
    partial class AMAT
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
            this.bExit = new System.Windows.Forms.Button();
            this.bPrint = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbLabelQuantity = new System.Windows.Forms.TextBox();
            this.Litem = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bExit
            // 
            this.bExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(80)))));
            this.bExit.Location = new System.Drawing.Point(292, 206);
            this.bExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(128, 135);
            this.bExit.TabIndex = 34;
            this.bExit.Text = "EXIT";
            this.bExit.UseVisualStyleBackColor = false;
            this.bExit.Click += new System.EventHandler(this.bExit_Click_1);
            // 
            // bPrint
            // 
            this.bPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(200)))), ((int)(((byte)(180)))));
            this.bPrint.Location = new System.Drawing.Point(31, 206);
            this.bPrint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(231, 135);
            this.bPrint.TabIndex = 33;
            this.bPrint.Text = "PRINT LABEL";
            this.bPrint.UseVisualStyleBackColor = false;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(61, 114);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(137, 20);
            this.label10.TabIndex = 32;
            this.label10.Text = "Quantity of Labels";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 62);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "Part Number";
            // 
            // tbLabelQuantity
            // 
            this.tbLabelQuantity.Location = new System.Drawing.Point(287, 114);
            this.tbLabelQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbLabelQuantity.Name = "tbLabelQuantity";
            this.tbLabelQuantity.Size = new System.Drawing.Size(46, 26);
            this.tbLabelQuantity.TabIndex = 25;
            this.tbLabelQuantity.Text = "1";
            // 
            // Litem
            // 
            this.Litem.AutoSize = true;
            this.Litem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(172)))), ((int)(((byte)(135)))));
            this.Litem.Location = new System.Drawing.Point(288, 62);
            this.Litem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Litem.Name = "Litem";
            this.Litem.Size = new System.Drawing.Size(97, 20);
            this.Litem.TabIndex = 21;
            this.Litem.Text = "0240-B9851";
            // 
            // AMAT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(172)))), ((int)(((byte)(135)))));
            this.ClientSize = new System.Drawing.Size(472, 390);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.bPrint);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbLabelQuantity);
            this.Controls.Add(this.Litem);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AMAT";
            this.Text = "AMAT";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.Button bPrint;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbLabelQuantity;
        private System.Windows.Forms.Label Litem;
    }
}

