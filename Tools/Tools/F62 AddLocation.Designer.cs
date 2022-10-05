namespace Tools
{
    partial class F62_AddLocation
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
            this.tbLocation = new System.Windows.Forms.TextBox();
            this.bAddLocation = new System.Windows.Forms.Button();
            this.LtbLocation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbLocation
            // 
            this.tbLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(0)))));
            this.tbLocation.Location = new System.Drawing.Point(212, 49);
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.Size = new System.Drawing.Size(178, 26);
            this.tbLocation.TabIndex = 0;
            // 
            // bAddLocation
            // 
            this.bAddLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(120)))));
            this.bAddLocation.Location = new System.Drawing.Point(40, 110);
            this.bAddLocation.Name = "bAddLocation";
            this.bAddLocation.Size = new System.Drawing.Size(350, 46);
            this.bAddLocation.TabIndex = 1;
            this.bAddLocation.Text = "ADD LOCATION";
            this.bAddLocation.UseVisualStyleBackColor = false;
            this.bAddLocation.Click += new System.EventHandler(this.bAddLocation_Click);
            // 
            // LtbLocation
            // 
            this.LtbLocation.AutoSize = true;
            this.LtbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LtbLocation.Location = new System.Drawing.Point(36, 52);
            this.LtbLocation.Name = "LtbLocation";
            this.LtbLocation.Size = new System.Drawing.Size(163, 20);
            this.LtbLocation.TabIndex = 2;
            this.LtbLocation.Text = "Enter new location:";
            // 
            // F62_AddLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(210)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(426, 194);
            this.Controls.Add(this.LtbLocation);
            this.Controls.Add(this.bAddLocation);
            this.Controls.Add(this.tbLocation);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F62_AddLocation";
            this.Text = "F62_AddLocation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLocation;
        private System.Windows.Forms.Button bAddLocation;
        private System.Windows.Forms.Label LtbLocation;
    }
}