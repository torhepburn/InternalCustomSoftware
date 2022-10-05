
namespace Certs
{
    partial class AdminAddUser
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
            this.cbddEmployees = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbddPermission = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbddPermissionValue = new System.Windows.Forms.ComboBox();
            this.bSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbddEmployees
            // 
            this.cbddEmployees.FormattingEnabled = true;
            this.cbddEmployees.Location = new System.Drawing.Point(198, 64);
            this.cbddEmployees.Name = "cbddEmployees";
            this.cbddEmployees.Size = new System.Drawing.Size(246, 24);
            this.cbddEmployees.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(79, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Employee:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(79, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Permission:";
            // 
            // cbddPermission
            // 
            this.cbddPermission.FormattingEnabled = true;
            this.cbddPermission.Items.AddRange(new object[] {
            "ACCESS",
            "EDIT",
            "ADMIN"});
            this.cbddPermission.Location = new System.Drawing.Point(198, 137);
            this.cbddPermission.Name = "cbddPermission";
            this.cbddPermission.Size = new System.Drawing.Size(246, 24);
            this.cbddPermission.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(25, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Permission Value:";
            // 
            // cbddPermissionValue
            // 
            this.cbddPermissionValue.FormattingEnabled = true;
            this.cbddPermissionValue.Items.AddRange(new object[] {
            "TRUE",
            "FALSE"});
            this.cbddPermissionValue.Location = new System.Drawing.Point(198, 218);
            this.cbddPermissionValue.Name = "cbddPermissionValue";
            this.cbddPermissionValue.Size = new System.Drawing.Size(246, 24);
            this.cbddPermissionValue.TabIndex = 4;
            // 
            // bSave
            // 
            this.bSave.BackColor = System.Drawing.Color.White;
            this.bSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bSave.Location = new System.Drawing.Point(149, 285);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(258, 64);
            this.bSave.TabIndex = 6;
            this.bSave.Text = "SAVE SATA";
            this.bSave.UseVisualStyleBackColor = false;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // AdminAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(50)))), ((int)(((byte)(150)))));
            this.ClientSize = new System.Drawing.Size(535, 394);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbddPermissionValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbddPermission);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbddEmployees);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AdminAddUser";
            this.Text = "AdminAddUser";
            this.Load += new System.EventHandler(this.AdminAddUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbddEmployees;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbddPermission;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbddPermissionValue;
        private System.Windows.Forms.Button bSave;
    }
}