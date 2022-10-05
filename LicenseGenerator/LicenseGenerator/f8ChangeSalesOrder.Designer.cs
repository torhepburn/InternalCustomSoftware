namespace LicenseGenerator
{
    partial class f8ChangeSalesOrder
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbSalesOrder = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.LsalesOrder = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LDongleID = new System.Windows.Forms.Label();
            this.LcurrentSO = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dongle ID:";
            // 
            // tbSalesOrder
            // 
            this.tbSalesOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(0)))));
            this.tbSalesOrder.Location = new System.Drawing.Point(340, 71);
            this.tbSalesOrder.Name = "tbSalesOrder";
            this.tbSalesOrder.Size = new System.Drawing.Size(181, 26);
            this.tbSalesOrder.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(200)))), ((int)(((byte)(120)))));
            this.button1.Location = new System.Drawing.Point(340, 153);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 49);
            this.button1.TabIndex = 2;
            this.button1.Text = "Change Sales Order Number";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LsalesOrder
            // 
            this.LsalesOrder.AutoSize = true;
            this.LsalesOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LsalesOrder.Location = new System.Drawing.Point(296, 25);
            this.LsalesOrder.Name = "LsalesOrder";
            this.LsalesOrder.Size = new System.Drawing.Size(264, 20);
            this.LsalesOrder.TabIndex = 3;
            this.LsalesOrder.Text = "Enter New Sales Order Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Current Sales Order Number:";
            // 
            // LDongleID
            // 
            this.LDongleID.AutoSize = true;
            this.LDongleID.Location = new System.Drawing.Point(56, 105);
            this.LDongleID.Name = "LDongleID";
            this.LDongleID.Size = new System.Drawing.Size(0, 20);
            this.LDongleID.TabIndex = 5;
            // 
            // LcurrentSO
            // 
            this.LcurrentSO.AutoSize = true;
            this.LcurrentSO.Location = new System.Drawing.Point(56, 167);
            this.LcurrentSO.Name = "LcurrentSO";
            this.LcurrentSO.Size = new System.Drawing.Size(0, 20);
            this.LcurrentSO.TabIndex = 6;
            // 
            // f8ChangeSalesOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(120)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(595, 244);
            this.Controls.Add(this.LcurrentSO);
            this.Controls.Add(this.LDongleID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LsalesOrder);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbSalesOrder);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "f8ChangeSalesOrder";
            this.Text = "f8ChangeSalesOrder";
            this.Load += new System.EventHandler(this.f8ChangeSalesOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSalesOrder;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label LsalesOrder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LDongleID;
        private System.Windows.Forms.Label LcurrentSO;
    }
}