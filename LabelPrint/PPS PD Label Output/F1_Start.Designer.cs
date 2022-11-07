namespace PPS_PD_Label_Output
{
    partial class F1_Start
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F1_Start));
            this.tbPDNumber = new System.Windows.Forms.TextBox();
            this.bGetData = new System.Windows.Forms.Button();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbPDNumber
            // 
            this.tbPDNumber.Location = new System.Drawing.Point(57, 143);
            this.tbPDNumber.Name = "tbPDNumber";
            this.tbPDNumber.Size = new System.Drawing.Size(193, 23);
            this.tbPDNumber.TabIndex = 1;
            // 
            // bGetData
            // 
            this.bGetData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(180)))), ((int)(((byte)(60)))));
            this.bGetData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bGetData.Location = new System.Drawing.Point(289, 124);
            this.bGetData.Name = "bGetData";
            this.bGetData.Size = new System.Drawing.Size(135, 54);
            this.bGetData.TabIndex = 2;
            this.bGetData.Text = "Get Data/PRINT";
            this.bGetData.UseVisualStyleBackColor = false;
            this.bGetData.Click += new System.EventHandler(this.bGetData_Click);
            // 
            // tbQuantity
            // 
            this.tbQuantity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbQuantity.Location = new System.Drawing.Point(249, 49);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(36, 29);
            this.tbQuantity.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(29, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter label quantity to print:";
            // 
            // F1_Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(110)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(494, 220);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbQuantity);
            this.Controls.Add(this.bGetData);
            this.Controls.Add(this.tbPDNumber);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "F1_Start";
            this.Text = "PPS PD Label";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPDNumber;
        private System.Windows.Forms.Button bGetData;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.Label label1;
    }
}
