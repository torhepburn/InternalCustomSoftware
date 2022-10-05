namespace BarTenderPrinter
{
    partial class BarTenderPrinter
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
            this.rb3Labels = new System.Windows.Forms.RadioButton();
            this.rb4Labels = new System.Windows.Forms.RadioButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bPrint = new System.Windows.Forms.Button();
            this.rb1Label = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rb3Labels
            // 
            this.rb3Labels.AutoSize = true;
            this.rb3Labels.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb3Labels.Location = new System.Drawing.Point(65, 85);
            this.rb3Labels.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb3Labels.Name = "rb3Labels";
            this.rb3Labels.Size = new System.Drawing.Size(261, 24);
            this.rb3Labels.TabIndex = 0;
            this.rb3Labels.TabStop = true;
            this.rb3Labels.Text = "Print (3) Three of Every Label";
            this.rb3Labels.UseVisualStyleBackColor = true;
            this.rb3Labels.CheckedChanged += new System.EventHandler(this.rb3Labels_CheckedChanged);
            // 
            // rb4Labels
            // 
            this.rb4Labels.AutoSize = true;
            this.rb4Labels.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb4Labels.Location = new System.Drawing.Point(65, 145);
            this.rb4Labels.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb4Labels.Name = "rb4Labels";
            this.rb4Labels.Size = new System.Drawing.Size(252, 24);
            this.rb4Labels.TabIndex = 1;
            this.rb4Labels.TabStop = true;
            this.rb4Labels.Text = "Print (4) Four of Every Label";
            this.rb4Labels.UseVisualStyleBackColor = true;
            this.rb4Labels.CheckedChanged += new System.EventHandler(this.rb4Labels_CheckedChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // bPrint
            // 
            this.bPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.bPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPrint.Location = new System.Drawing.Point(35, 226);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(316, 63);
            this.bPrint.TabIndex = 2;
            this.bPrint.Text = "Print Labels";
            this.bPrint.UseVisualStyleBackColor = false;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // rb1Label
            // 
            this.rb1Label.AutoSize = true;
            this.rb1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb1Label.Location = new System.Drawing.Point(65, 33);
            this.rb1Label.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb1Label.Name = "rb1Label";
            this.rb1Label.Size = new System.Drawing.Size(248, 24);
            this.rb1Label.TabIndex = 3;
            this.rb1Label.TabStop = true;
            this.rb1Label.Text = "Print (1) One of Every Label";
            this.rb1Label.UseVisualStyleBackColor = true;
            this.rb1Label.CheckedChanged += new System.EventHandler(this.rb1Label_CheckedChanged);
            // 
            // BarTenderPrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(180)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(387, 320);
            this.Controls.Add(this.rb1Label);
            this.Controls.Add(this.bPrint);
            this.Controls.Add(this.rb4Labels);
            this.Controls.Add(this.rb3Labels);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BarTenderPrinter";
            this.Text = "BarTenderPrinter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rb3Labels;
        private System.Windows.Forms.RadioButton rb4Labels;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button bPrint;
        private System.Windows.Forms.RadioButton rb1Label;
    }
}

