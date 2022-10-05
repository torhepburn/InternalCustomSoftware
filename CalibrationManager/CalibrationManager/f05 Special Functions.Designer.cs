namespace CalibrationManager
{
    partial class f05_Special_Functions
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
            this.bSetCalIntervalbyType = new System.Windows.Forms.Button();
            this.bBack = new System.Windows.Forms.Button();
            this.bCalSource = new System.Windows.Forms.Button();
            this.bCoordinatorUser = new System.Windows.Forms.Button();
            this.bLocationOwner = new System.Windows.Forms.Button();
            this.bAddUser = new System.Windows.Forms.Button();
            this.bDeleteUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bSetCalIntervalbyType
            // 
            this.bSetCalIntervalbyType.BackColor = System.Drawing.Color.Olive;
            this.bSetCalIntervalbyType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSetCalIntervalbyType.Location = new System.Drawing.Point(51, 42);
            this.bSetCalIntervalbyType.Name = "bSetCalIntervalbyType";
            this.bSetCalIntervalbyType.Size = new System.Drawing.Size(383, 70);
            this.bSetCalIntervalbyType.TabIndex = 0;
            this.bSetCalIntervalbyType.Text = "Set Calibration Interval by Type";
            this.bSetCalIntervalbyType.UseVisualStyleBackColor = false;
            this.bSetCalIntervalbyType.Click += new System.EventHandler(this.bSetCalIntervalbyType_Click);
            // 
            // bBack
            // 
            this.bBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(50)))));
            this.bBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBack.Location = new System.Drawing.Point(495, 42);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(59, 329);
            this.bBack.TabIndex = 6;
            this.bBack.Text = "BACK";
            this.bBack.UseVisualStyleBackColor = false;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // bCalSource
            // 
            this.bCalSource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(175)))), ((int)(((byte)(250)))));
            this.bCalSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCalSource.Location = new System.Drawing.Point(51, 135);
            this.bCalSource.Name = "bCalSource";
            this.bCalSource.Size = new System.Drawing.Size(383, 70);
            this.bCalSource.TabIndex = 7;
            this.bCalSource.Text = "Remove Company from Cal Source List";
            this.bCalSource.UseVisualStyleBackColor = false;
            this.bCalSource.Click += new System.EventHandler(this.bCalSource_Click);
            // 
            // bCoordinatorUser
            // 
            this.bCoordinatorUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(150)))), ((int)(((byte)(100)))));
            this.bCoordinatorUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCoordinatorUser.Location = new System.Drawing.Point(51, 228);
            this.bCoordinatorUser.Name = "bCoordinatorUser";
            this.bCoordinatorUser.Size = new System.Drawing.Size(383, 70);
            this.bCoordinatorUser.TabIndex = 8;
            this.bCoordinatorUser.Text = "Report Items Assigned to Calibration Coordinator";
            this.bCoordinatorUser.UseVisualStyleBackColor = false;
            this.bCoordinatorUser.Click += new System.EventHandler(this.bCoordinatorUser_Click);
            // 
            // bLocationOwner
            // 
            this.bLocationOwner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(150)))), ((int)(((byte)(250)))));
            this.bLocationOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLocationOwner.Location = new System.Drawing.Point(51, 321);
            this.bLocationOwner.Name = "bLocationOwner";
            this.bLocationOwner.Size = new System.Drawing.Size(383, 70);
            this.bLocationOwner.TabIndex = 9;
            this.bLocationOwner.Text = "Report Locations Assigned to Calibration Coordinator";
            this.bLocationOwner.UseVisualStyleBackColor = false;
            this.bLocationOwner.Click += new System.EventHandler(this.bLocationOwner_Click);
            // 
            // bAddUser
            // 
            this.bAddUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(50)))));
            this.bAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAddUser.Location = new System.Drawing.Point(51, 417);
            this.bAddUser.Name = "bAddUser";
            this.bAddUser.Size = new System.Drawing.Size(177, 70);
            this.bAddUser.TabIndex = 10;
            this.bAddUser.Text = "Add Calibration Manager User";
            this.bAddUser.UseVisualStyleBackColor = false;
            this.bAddUser.Click += new System.EventHandler(this.bAddUser_Click);
            // 
            // bDeleteUser
            // 
            this.bDeleteUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(100)))), ((int)(((byte)(50)))));
            this.bDeleteUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bDeleteUser.Location = new System.Drawing.Point(257, 417);
            this.bDeleteUser.Name = "bDeleteUser";
            this.bDeleteUser.Size = new System.Drawing.Size(177, 70);
            this.bDeleteUser.TabIndex = 11;
            this.bDeleteUser.Text = "Delete Calibration Manager User";
            this.bDeleteUser.UseVisualStyleBackColor = false;
            this.bDeleteUser.Click += new System.EventHandler(this.bDeleteUser_Click);
            // 
            // f05_Special_Functions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OliveDrab;
            this.ClientSize = new System.Drawing.Size(601, 530);
            this.Controls.Add(this.bDeleteUser);
            this.Controls.Add(this.bAddUser);
            this.Controls.Add(this.bLocationOwner);
            this.Controls.Add(this.bCoordinatorUser);
            this.Controls.Add(this.bCalSource);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.bSetCalIntervalbyType);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "f05_Special_Functions";
            this.Text = "f05 Special Functions";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bSetCalIntervalbyType;
        private System.Windows.Forms.Button bBack;
        private System.Windows.Forms.Button bCalSource;
        private System.Windows.Forms.Button bCoordinatorUser;
        private System.Windows.Forms.Button bLocationOwner;
        private System.Windows.Forms.Button bAddUser;
        private System.Windows.Forms.Button bDeleteUser;
    }
}