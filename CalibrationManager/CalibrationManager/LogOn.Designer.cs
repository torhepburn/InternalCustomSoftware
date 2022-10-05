namespace CalibrationManager
{
    partial class LogOn
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
            this.LUser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bLogIn = new System.Windows.Forms.Button();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LUser
            // 
            this.LUser.AutoSize = true;
            this.LUser.Location = new System.Drawing.Point(27, 41);
            this.LUser.Name = "LUser";
            this.LUser.Size = new System.Drawing.Size(147, 20);
            this.LUser.TabIndex = 0;
            this.LUser.Text = "Enter user name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter password:";
            // 
            // bLogIn
            // 
            this.bLogIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.bLogIn.Location = new System.Drawing.Point(50, 151);
            this.bLogIn.Name = "bLogIn";
            this.bLogIn.Size = new System.Drawing.Size(357, 48);
            this.bLogIn.TabIndex = 2;
            this.bLogIn.Text = "Log In";
            this.bLogIn.UseVisualStyleBackColor = false;
            this.bLogIn.Click += new System.EventHandler(this.bLogIn_Click);
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(180, 38);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(227, 26);
            this.tbUserName.TabIndex = 0;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(180, 97);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = 'x';
            this.tbPassword.Size = new System.Drawing.Size(227, 26);
            this.tbPassword.TabIndex = 1;
            // 
            // LogOn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(120)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(459, 222);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.bLogIn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LUser);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "LogOn";
            this.Text = "LogOn";
            this.Load += new System.EventHandler(this.LogOn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bLogIn;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.TextBox tbPassword;
    }
}