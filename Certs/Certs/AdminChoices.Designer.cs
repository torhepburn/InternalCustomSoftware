
namespace Certs
{
    partial class AdminChoices
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
            this.bDropDownLists = new System.Windows.Forms.Button();
            this.bProgramPermissionss = new System.Windows.Forms.Button();
            this.bAddUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bDropDownLists
            // 
            this.bDropDownLists.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(200)))), ((int)(((byte)(80)))));
            this.bDropDownLists.Location = new System.Drawing.Point(57, 30);
            this.bDropDownLists.Name = "bDropDownLists";
            this.bDropDownLists.Size = new System.Drawing.Size(160, 58);
            this.bDropDownLists.TabIndex = 0;
            this.bDropDownLists.Text = "Edit Drop Down Lists";
            this.bDropDownLists.UseVisualStyleBackColor = false;
            this.bDropDownLists.Click += new System.EventHandler(this.bDropDownLists_Click);
            // 
            // bProgramPermissionss
            // 
            this.bProgramPermissionss.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(200)))), ((int)(((byte)(80)))));
            this.bProgramPermissionss.Location = new System.Drawing.Point(265, 31);
            this.bProgramPermissionss.Name = "bProgramPermissionss";
            this.bProgramPermissionss.Size = new System.Drawing.Size(160, 58);
            this.bProgramPermissionss.TabIndex = 1;
            this.bProgramPermissionss.Text = "Edit Program Permissions";
            this.bProgramPermissionss.UseVisualStyleBackColor = false;
            this.bProgramPermissionss.Click += new System.EventHandler(this.bProgramPermissionss_Click);
            // 
            // bAddUser
            // 
            this.bAddUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(200)))), ((int)(((byte)(80)))));
            this.bAddUser.Location = new System.Drawing.Point(468, 30);
            this.bAddUser.Name = "bAddUser";
            this.bAddUser.Size = new System.Drawing.Size(160, 58);
            this.bAddUser.TabIndex = 2;
            this.bAddUser.Text = "Add User";
            this.bAddUser.UseVisualStyleBackColor = false;
            this.bAddUser.Click += new System.EventHandler(this.bAddUser_Click);
            // 
            // AdminChoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(120)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(690, 115);
            this.Controls.Add(this.bAddUser);
            this.Controls.Add(this.bProgramPermissionss);
            this.Controls.Add(this.bDropDownLists);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AdminChoices";
            this.Text = "AdminChoices";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bDropDownLists;
        private System.Windows.Forms.Button bProgramPermissionss;
        private System.Windows.Forms.Button bAddUser;
    }
}