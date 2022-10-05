namespace PM_Validation_Test
{
    partial class ChangePermissions
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
            this.bView = new System.Windows.Forms.Button();
            this.bUpdate = new System.Windows.Forms.Button();
            this.bAssign = new System.Windows.Forms.Button();
            this.bAllSites = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bView
            // 
            this.bView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(155)))), ((int)(((byte)(200)))));
            this.bView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bView.Location = new System.Drawing.Point(47, 47);
            this.bView.Name = "bView";
            this.bView.Size = new System.Drawing.Size(325, 47);
            this.bView.TabIndex = 0;
            this.bView.Text = "View Only";
            this.bView.UseVisualStyleBackColor = false;
            this.bView.Click += new System.EventHandler(this.bView_Click);
            // 
            // bUpdate
            // 
            this.bUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(130)))), ((int)(((byte)(100)))));
            this.bUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bUpdate.Location = new System.Drawing.Point(47, 125);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(325, 47);
            this.bUpdate.TabIndex = 1;
            this.bUpdate.Text = "CanUpdateData";
            this.bUpdate.UseVisualStyleBackColor = false;
            this.bUpdate.Click += new System.EventHandler(this.bUpdate_Click);
            // 
            // bAssign
            // 
            this.bAssign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
            this.bAssign.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bAssign.Location = new System.Drawing.Point(47, 210);
            this.bAssign.Name = "bAssign";
            this.bAssign.Size = new System.Drawing.Size(325, 47);
            this.bAssign.TabIndex = 2;
            this.bAssign.Text = "CanAssign";
            this.bAssign.UseVisualStyleBackColor = false;
            this.bAssign.Click += new System.EventHandler(this.bAssign_Click);
            // 
            // bAllSites
            // 
            this.bAllSites.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(150)))), ((int)(((byte)(55)))));
            this.bAllSites.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bAllSites.Location = new System.Drawing.Point(47, 292);
            this.bAllSites.Name = "bAllSites";
            this.bAllSites.Size = new System.Drawing.Size(325, 47);
            this.bAllSites.TabIndex = 3;
            this.bAllSites.Text = "AllSites";
            this.bAllSites.UseVisualStyleBackColor = false;
            this.bAllSites.Click += new System.EventHandler(this.bAllSites_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(58, 379);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // ChangePermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(424, 437);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bAllSites);
            this.Controls.Add(this.bAssign);
            this.Controls.Add(this.bUpdate);
            this.Controls.Add(this.bView);
            this.Name = "ChangePermissions";
            this.Text = "Change Permissions for Validation";
            this.Load += new System.EventHandler(this.ChangePermissions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bView;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.Button bAssign;
        private System.Windows.Forms.Button bAllSites;
        private System.Windows.Forms.Label label1;
    }
}

