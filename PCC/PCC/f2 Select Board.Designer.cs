namespace PCC
{
    partial class f2_Select_Board
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
            this.b4004 = new System.Windows.Forms.Button();
            this.b4104 = new System.Windows.Forms.Button();
            this.rbMCert = new System.Windows.Forms.RadioButton();
            this.rbProduction = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // b4004
            // 
            this.b4004.BackColor = System.Drawing.Color.CadetBlue;
            this.b4004.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b4004.Location = new System.Drawing.Point(47, 140);
            this.b4004.Name = "b4004";
            this.b4004.Size = new System.Drawing.Size(237, 101);
            this.b4004.TabIndex = 0;
            this.b4004.Text = "4004";
            this.b4004.UseVisualStyleBackColor = false;
            this.b4004.Click += new System.EventHandler(this.b4004_Click);
            // 
            // b4104
            // 
            this.b4104.BackColor = System.Drawing.Color.CornflowerBlue;
            this.b4104.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b4104.Location = new System.Drawing.Point(47, 275);
            this.b4104.Name = "b4104";
            this.b4104.Size = new System.Drawing.Size(237, 101);
            this.b4104.TabIndex = 1;
            this.b4104.Text = "4104";
            this.b4104.UseVisualStyleBackColor = false;
            this.b4104.Click += new System.EventHandler(this.b4104_Click);
            // 
            // rbMCert
            // 
            this.rbMCert.AutoSize = true;
            this.rbMCert.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.rbMCert.Location = new System.Drawing.Point(92, 31);
            this.rbMCert.Name = "rbMCert";
            this.rbMCert.Size = new System.Drawing.Size(106, 35);
            this.rbMCert.TabIndex = 2;
            this.rbMCert.TabStop = true;
            this.rbMCert.Text = "MCert";
            this.rbMCert.UseVisualStyleBackColor = true;
            // 
            // rbProduction
            // 
            this.rbProduction.AutoSize = true;
            this.rbProduction.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.rbProduction.Location = new System.Drawing.Point(92, 72);
            this.rbProduction.Name = "rbProduction";
            this.rbProduction.Size = new System.Drawing.Size(162, 35);
            this.rbProduction.TabIndex = 3;
            this.rbProduction.TabStop = true;
            this.rbProduction.Text = "Production";
            this.rbProduction.UseVisualStyleBackColor = true;
            // 
            // f2_Select_Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(332, 434);
            this.Controls.Add(this.rbProduction);
            this.Controls.Add(this.rbMCert);
            this.Controls.Add(this.b4104);
            this.Controls.Add(this.b4004);
            this.Name = "f2_Select_Board";
            this.Text = "f2 Select Board for Graphing";
            this.Load += new System.EventHandler(this.f2_Select_Board_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b4004;
        private System.Windows.Forms.Button b4104;
        private System.Windows.Forms.RadioButton rbMCert;
        private System.Windows.Forms.RadioButton rbProduction;
    }
}