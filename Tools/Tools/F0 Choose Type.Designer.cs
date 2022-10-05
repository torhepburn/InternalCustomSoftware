namespace Tools
{
    partial class F0_Choose_Type
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
            this.bCNC = new System.Windows.Forms.Button();
            this.bLFO = new System.Windows.Forms.Button();
            this.Bvacuumchucks = new System.Windows.Forms.Button();
            this.Bfixtures = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bCNC
            // 
            this.bCNC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(165)))), ((int)(((byte)(160)))));
            this.bCNC.Location = new System.Drawing.Point(46, 52);
            this.bCNC.Name = "bCNC";
            this.bCNC.Size = new System.Drawing.Size(150, 186);
            this.bCNC.TabIndex = 0;
            this.bCNC.Text = "CNC";
            this.bCNC.UseVisualStyleBackColor = false;
            this.bCNC.Click += new System.EventHandler(this.bCNC_Click);
            // 
            // bLFO
            // 
            this.bLFO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(145)))), ((int)(((byte)(160)))));
            this.bLFO.Location = new System.Drawing.Point(233, 52);
            this.bLFO.Name = "bLFO";
            this.bLFO.Size = new System.Drawing.Size(150, 186);
            this.bLFO.TabIndex = 1;
            this.bLFO.Text = "LFO";
            this.bLFO.UseVisualStyleBackColor = false;
            this.bLFO.Click += new System.EventHandler(this.bLFO_Click);
            // 
            // Bvacuumchucks
            // 
            this.Bvacuumchucks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(105)))), ((int)(((byte)(0)))));
            this.Bvacuumchucks.Location = new System.Drawing.Point(232, 280);
            this.Bvacuumchucks.Name = "Bvacuumchucks";
            this.Bvacuumchucks.Size = new System.Drawing.Size(150, 186);
            this.Bvacuumchucks.TabIndex = 3;
            this.Bvacuumchucks.Text = "Vacuum Chucks";
            this.Bvacuumchucks.UseVisualStyleBackColor = false;
            this.Bvacuumchucks.Click += new System.EventHandler(this.Bvacuumchucks_Click);
            // 
            // Bfixtures
            // 
            this.Bfixtures.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.Bfixtures.Location = new System.Drawing.Point(45, 280);
            this.Bfixtures.Name = "Bfixtures";
            this.Bfixtures.Size = new System.Drawing.Size(150, 186);
            this.Bfixtures.TabIndex = 2;
            this.Bfixtures.Text = "Fixtures";
            this.Bfixtures.UseVisualStyleBackColor = false;
            this.Bfixtures.Click += new System.EventHandler(this.Bfixtures_Click);
            // 
            // F0_Choose_Type
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(165)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(426, 518);
            this.Controls.Add(this.Bvacuumchucks);
            this.Controls.Add(this.Bfixtures);
            this.Controls.Add(this.bLFO);
            this.Controls.Add(this.bCNC);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F0_Choose_Type";
            this.Text = "F0 Choose DB";
            this.Load += new System.EventHandler(this.F0_Choose_Type_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bCNC;
        private System.Windows.Forms.Button bLFO;
        private System.Windows.Forms.Button Bvacuumchucks;
        private System.Windows.Forms.Button Bfixtures;
    }
}