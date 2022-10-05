namespace CalibrationManager
{
    partial class f053_Access_Rights
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
            this.ddlUserType = new System.Windows.Forms.ComboBox();
            this.ddlFacility = new System.Windows.Forms.ComboBox();
            this.LddlUserType = new System.Windows.Forms.Label();
            this.LddlFacility = new System.Windows.Forms.Label();
            this.tbUserLogin = new System.Windows.Forms.TextBox();
            this.LuserLogin = new System.Windows.Forms.Label();
            this.LuserName = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.bSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ddlUserType
            // 
            this.ddlUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlUserType.FormattingEnabled = true;
            this.ddlUserType.Items.AddRange(new object[] {
            "View+Data",
            "Limited",
            "Full",
            "System",
            "SystemAC"});
            this.ddlUserType.Location = new System.Drawing.Point(189, 162);
            this.ddlUserType.Name = "ddlUserType";
            this.ddlUserType.Size = new System.Drawing.Size(174, 28);
            this.ddlUserType.TabIndex = 2;
            // 
            // ddlFacility
            // 
            this.ddlFacility.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlFacility.FormattingEnabled = true;
            this.ddlFacility.Items.AddRange(new object[] {
            "Irvine",
            "Middlefield",
            "Richmond",
            "Tucson"});
            this.ddlFacility.Location = new System.Drawing.Point(189, 224);
            this.ddlFacility.Name = "ddlFacility";
            this.ddlFacility.Size = new System.Drawing.Size(174, 28);
            this.ddlFacility.TabIndex = 3;
            // 
            // LddlUserType
            // 
            this.LddlUserType.AutoSize = true;
            this.LddlUserType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LddlUserType.Location = new System.Drawing.Point(32, 165);
            this.LddlUserType.Name = "LddlUserType";
            this.LddlUserType.Size = new System.Drawing.Size(151, 20);
            this.LddlUserType.TabIndex = 4;
            this.LddlUserType.Text = "Select User Type:";
            // 
            // LddlFacility
            // 
            this.LddlFacility.AutoSize = true;
            this.LddlFacility.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LddlFacility.Location = new System.Drawing.Point(32, 227);
            this.LddlFacility.Name = "LddlFacility";
            this.LddlFacility.Size = new System.Drawing.Size(126, 20);
            this.LddlFacility.TabIndex = 5;
            this.LddlFacility.Text = "Select Facility:";
            // 
            // tbUserLogin
            // 
            this.tbUserLogin.Location = new System.Drawing.Point(486, 80);
            this.tbUserLogin.Name = "tbUserLogin";
            this.tbUserLogin.Size = new System.Drawing.Size(174, 26);
            this.tbUserLogin.TabIndex = 6;
            // 
            // LuserLogin
            // 
            this.LuserLogin.AutoSize = true;
            this.LuserLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LuserLogin.Location = new System.Drawing.Point(32, 83);
            this.LuserLogin.Name = "LuserLogin";
            this.LuserLogin.Size = new System.Drawing.Size(448, 20);
            this.LuserLogin.TabIndex = 7;
            this.LuserLogin.Text = "Enter Login user uses when logging onto Zygo domain:";
            // 
            // LuserName
            // 
            this.LuserName.AutoSize = true;
            this.LuserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LuserName.Location = new System.Drawing.Point(32, 34);
            this.LuserName.Name = "LuserName";
            this.LuserName.Size = new System.Drawing.Size(103, 20);
            this.LuserName.TabIndex = 8;
            this.LuserName.Text = "User Name:";
            // 
            // tbUserName
            // 
            this.tbUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(200)))), ((int)(((byte)(240)))));
            this.tbUserName.Location = new System.Drawing.Point(190, 31);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(174, 26);
            this.tbUserName.TabIndex = 9;
            // 
            // bSave
            // 
            this.bSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.bSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSave.Location = new System.Drawing.Point(190, 289);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(295, 44);
            this.bSave.TabIndex = 10;
            this.bSave.Text = "SAVE";
            this.bSave.UseVisualStyleBackColor = false;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "(For Example: thepburn)";
            // 
            // bBack
            // 
            this.bBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(50)))));
            this.bBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBack.Location = new System.Drawing.Point(601, 138);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(59, 195);
            this.bBack.TabIndex = 12;
            this.bBack.Text = "BACK";
            this.bBack.UseVisualStyleBackColor = false;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // f053_Access_Rights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.ClientSize = new System.Drawing.Size(711, 363);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.LuserName);
            this.Controls.Add(this.LuserLogin);
            this.Controls.Add(this.tbUserLogin);
            this.Controls.Add(this.LddlFacility);
            this.Controls.Add(this.LddlUserType);
            this.Controls.Add(this.ddlFacility);
            this.Controls.Add(this.ddlUserType);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.InfoText;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "f053_Access_Rights";
            this.Text = "f053 Access Rights";
            this.Load += new System.EventHandler(this.f053_Access_Rights_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlUserType;
        private System.Windows.Forms.ComboBox ddlFacility;
        private System.Windows.Forms.Label LddlUserType;
        private System.Windows.Forms.Label LddlFacility;
        private System.Windows.Forms.TextBox tbUserLogin;
        private System.Windows.Forms.Label LuserLogin;
        private System.Windows.Forms.Label LuserName;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bBack;

    }
}