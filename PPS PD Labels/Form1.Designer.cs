namespace PPS_PD_Labels
{
    partial class Form1
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
            bGetData = new Button();
            label1 = new Label();
            tbQuantity = new TextBox();
            tbPDNumber = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // bGetData
            // 
            bGetData.BackColor = Color.FromArgb(50, 180, 60);
            bGetData.Location = new Point(339, 144);
            bGetData.Name = "bGetData";
            bGetData.Size = new Size(141, 60);
            bGetData.TabIndex = 3;
            bGetData.Text = "Get Data/PRINT";
            bGetData.UseVisualStyleBackColor = false;
            bGetData.Click += bGetData_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(30, 58);
            label1.Name = "label1";
            label1.Size = new Size(220, 19);
            label1.TabIndex = 1;
            label1.Text = "Enter label quantity to print:";
            // 
            // tbQuantity
            // 
            tbQuantity.Location = new Point(256, 51);
            tbQuantity.Name = "tbQuantity";
            tbQuantity.Size = new Size(64, 26);
            tbQuantity.TabIndex = 1;
            // 
            // tbPDNumber
            // 
            tbPDNumber.Location = new Point(52, 162);
            tbPDNumber.Name = "tbPDNumber";
            tbPDNumber.Size = new Size(213, 26);
            tbPDNumber.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Location = new Point(46, 131);
            label2.Name = "label2";
            label2.Size = new Size(132, 18);
            label2.TabIndex = 4;
            label2.Text = "Enter PD number:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 110, 60);
            ClientSize = new Size(519, 268);
            Controls.Add(label2);
            Controls.Add(tbPDNumber);
            Controls.Add(tbQuantity);
            Controls.Add(label1);
            Controls.Add(bGetData);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 4, 4, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button bGetData;
        private Label label1;
        private TextBox tbQuantity;
        private TextBox tbPDNumber;
        private Label label2;
    }
}
