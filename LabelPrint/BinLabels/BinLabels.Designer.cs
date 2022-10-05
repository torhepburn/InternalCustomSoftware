namespace BinLabels
{
    partial class BinLabels
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
            this.components = new System.ComponentModel.Container();
            this.tbStart = new System.Windows.Forms.TextBox();
            this.tbEnd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbLabelQuantity = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cbMultiLevel = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbStart
            // 
            this.tbStart.Location = new System.Drawing.Point(347, 102);
            this.tbStart.Margin = new System.Windows.Forms.Padding(6);
            this.tbStart.Name = "tbStart";
            this.tbStart.Size = new System.Drawing.Size(196, 30);
            this.tbStart.TabIndex = 0;
            // 
            // tbEnd
            // 
            this.tbEnd.Location = new System.Drawing.Point(347, 182);
            this.tbEnd.Margin = new System.Windows.Forms.Padding(6);
            this.tbEnd.Name = "tbEnd";
            this.tbEnd.Size = new System.Drawing.Size(196, 30);
            this.tbEnd.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 110);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Starting Production Order Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 189);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(306, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ending Production Order Number:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(240)))));
            this.button1.Location = new System.Drawing.Point(90, 348);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(406, 88);
            this.button1.TabIndex = 4;
            this.button1.Text = "PRINT";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 281);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Number of Bin Labels:";
            // 
            // tbLabelQuantity
            // 
            this.tbLabelQuantity.Location = new System.Drawing.Point(347, 275);
            this.tbLabelQuantity.Margin = new System.Windows.Forms.Padding(6);
            this.tbLabelQuantity.Name = "tbLabelQuantity";
            this.tbLabelQuantity.Size = new System.Drawing.Size(59, 30);
            this.tbLabelQuantity.TabIndex = 5;
            this.tbLabelQuantity.Text = "1";
            // 
            // cbMultiLevel
            // 
            this.cbMultiLevel.AutoSize = true;
            this.cbMultiLevel.Location = new System.Drawing.Point(178, 38);
            this.cbMultiLevel.Margin = new System.Windows.Forms.Padding(4);
            this.cbMultiLevel.Name = "cbMultiLevel";
            this.cbMultiLevel.Size = new System.Drawing.Size(244, 29);
            this.cbMultiLevel.TabIndex = 7;
            this.cbMultiLevel.Text = "Check if multi-level SFO";
            this.cbMultiLevel.UseVisualStyleBackColor = true;
            // 
            // BinLabels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(180)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(591, 496);
            this.Controls.Add(this.cbMultiLevel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbLabelQuantity);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbEnd);
            this.Controls.Add(this.tbStart);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "BinLabels";
            this.Text = "Print Bin Labels";
            this.Load += new System.EventHandler(this.BinLabels_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbStart;
        private System.Windows.Forms.TextBox tbEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbLabelQuantity;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox cbMultiLevel;
    }
}

