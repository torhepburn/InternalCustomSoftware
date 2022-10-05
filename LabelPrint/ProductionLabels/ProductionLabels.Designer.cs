namespace ProductionLabels
{
    partial class ProductionLabels
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
            this.Bprint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbProductionOrder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Bprint
            // 
            this.Bprint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(60)))));
            this.Bprint.Location = new System.Drawing.Point(60, 103);
            this.Bprint.Name = "Bprint";
            this.Bprint.Size = new System.Drawing.Size(278, 79);
            this.Bprint.TabIndex = 11;
            this.Bprint.Text = "PRINT";
            this.Bprint.UseVisualStyleBackColor = false;
            this.Bprint.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Production Order Number:";
            // 
            // tbProductionOrder
            // 
            this.tbProductionOrder.Location = new System.Drawing.Point(250, 47);
            this.tbProductionOrder.Name = "tbProductionOrder";
            this.tbProductionOrder.Size = new System.Drawing.Size(100, 23);
            this.tbProductionOrder.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F);
            this.label2.Location = new System.Drawing.Point(95, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 91);
            this.label2.TabIndex = 12;
            this.label2.Text = "NAV";
            // 
            // ProductionLabels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(100)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(417, 317);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Bprint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbProductionOrder);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProductionLabels";
            this.Text = "Production Labels";
            this.Load += new System.EventHandler(this.ProductionLabels_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Bprint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbProductionOrder;
        private System.Windows.Forms.Label label2;
    }
}

