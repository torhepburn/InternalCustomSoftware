namespace TaiwanLicenseGenerator
{
    partial class F1
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            bLicense = new Button();
            bChangeSN = new Button();
            bAnother = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(425, 45);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(250, 26);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(298, 225);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(365, 26);
            textBox2.TabIndex = 1;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(292, 90);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(378, 26);
            comboBox1.TabIndex = 2;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(225, 180);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(441, 26);
            comboBox2.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(251, 135);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(417, 26);
            dateTimePicker1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 45);
            label1.Name = "label1";
            label1.Size = new Size(73, 18);
            label1.TabIndex = 5;
            label1.Text = "DongleID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 90);
            label2.Name = "label2";
            label2.Size = new Size(86, 18);
            label2.TabIndex = 6;
            label2.Text = "Application";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 135);
            label3.Name = "label3";
            label3.Size = new Size(79, 18);
            label3.TabIndex = 7;
            label3.Text = "Start Date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 180);
            label4.Name = "label4";
            label4.Size = new Size(67, 18);
            label4.TabIndex = 8;
            label4.Text = "Duration";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 225);
            label5.Name = "label5";
            label5.Size = new Size(164, 18);
            label5.TabIndex = 9;
            label5.Text = "System Serial Number";
            // 
            // bLicense
            // 
            bLicense.BackColor = Color.LimeGreen;
            bLicense.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bLicense.Location = new Point(35, 303);
            bLicense.Name = "bLicense";
            bLicense.Size = new Size(628, 96);
            bLicense.TabIndex = 10;
            bLicense.Text = "Generate License";
            bLicense.UseVisualStyleBackColor = false;
            bLicense.Click += bLicense_Click;
            // 
            // bChangeSN
            // 
            bChangeSN.BackColor = Color.FromArgb(250, 250, 100);
            bChangeSN.Location = new Point(334, 507);
            bChangeSN.Name = "bChangeSN";
            bChangeSN.Size = new Size(316, 50);
            bChangeSN.TabIndex = 11;
            bChangeSN.Text = "Change SN (DongleID entry needed)";
            bChangeSN.UseVisualStyleBackColor = false;
            bChangeSN.Click += bChangeSN_Click;
            // 
            // bAnother
            // 
            bAnother.BackColor = Color.FromArgb(250, 100, 100);
            bAnother.Location = new Point(12, 576);
            bAnother.Name = "bAnother";
            bAnother.Size = new Size(316, 50);
            bAnother.TabIndex = 12;
            bAnother.Text = "Generate Another License";
            bAnother.UseVisualStyleBackColor = false;
            bAnother.Click += bAnother_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(0, 150, 250);
            button2.Location = new Point(334, 576);
            button2.Name = "button2";
            button2.Size = new Size(316, 50);
            button2.TabIndex = 13;
            button2.Text = "Print License";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // F1
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleGoldenrod;
            ClientSize = new Size(722, 653);
            Controls.Add(button2);
            Controls.Add(bAnother);
            Controls.Add(bChangeSN);
            Controls.Add(bLicense);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateTimePicker1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "F1";
            Text = "F1 Generate License";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private DateTimePicker dateTimePicker1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button bLicense;
        private Button bChangeSN;
        private Button bAnother;
        private Button button2;
    }
}
