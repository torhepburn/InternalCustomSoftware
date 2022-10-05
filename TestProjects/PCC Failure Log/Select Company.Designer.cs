namespace PCC_Failure_Log
{
    partial class Select_Company
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
            this.Ltask = new System.Windows.Forms.Label();
            this.bCEI = new System.Windows.Forms.Button();
            this.bZygo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Ltask
            // 
            this.Ltask.AutoSize = true;
            this.Ltask.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ltask.Location = new System.Drawing.Point(44, 26);
            this.Ltask.Name = "Ltask";
            this.Ltask.Size = new System.Drawing.Size(227, 31);
            this.Ltask.TabIndex = 8;
            this.Ltask.Text = "Select Company";
            // 
            // bCEI
            // 
            this.bCEI.BackColor = System.Drawing.Color.DarkOrange;
            this.bCEI.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCEI.Location = new System.Drawing.Point(44, 295);
            this.bCEI.Name = "bCEI";
            this.bCEI.Size = new System.Drawing.Size(245, 91);
            this.bCEI.TabIndex = 7;
            this.bCEI.Text = "CEI";
            this.bCEI.UseVisualStyleBackColor = false;
            this.bCEI.Click += new System.EventHandler(this.bCEI_Click);
            // 
            // bZygo
            // 
            this.bZygo.BackColor = System.Drawing.Color.SandyBrown;
            this.bZygo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bZygo.Location = new System.Drawing.Point(44, 183);
            this.bZygo.Name = "bZygo";
            this.bZygo.Size = new System.Drawing.Size(245, 91);
            this.bZygo.TabIndex = 6;
            this.bZygo.Text = "Zygo";
            this.bZygo.UseVisualStyleBackColor = false;
            this.bZygo.Click += new System.EventHandler(this.bZygo_Click);
            // 
            // Select_Company
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(120)))), ((int)(((byte)(10)))));
            this.ClientSize = new System.Drawing.Size(339, 420);
            this.Controls.Add(this.Ltask);
            this.Controls.Add(this.bCEI);
            this.Controls.Add(this.bZygo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "Select_Company";
            this.Text = "Select_Company";
            this.Load += new System.EventHandler(this.Select_Company_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Ltask;
        private System.Windows.Forms.Button bCEI;
        private System.Windows.Forms.Button bZygo;
    }
}