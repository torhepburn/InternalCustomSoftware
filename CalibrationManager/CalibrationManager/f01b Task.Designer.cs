namespace CalibrationManager
{
    partial class f01_Task
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
            this.bAdd = new System.Windows.Forms.Button();
            this.bEdit = new System.Windows.Forms.Button();
            this.bDelete = new System.Windows.Forms.Button();
            this.bOwnerUser = new System.Windows.Forms.Button();
            this.LownerButtonWarning = new System.Windows.Forms.Label();
            this.bBack = new System.Windows.Forms.Button();
            this.bLocation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bAdd
            // 
            this.bAdd.BackColor = System.Drawing.Color.PaleGreen;
            this.bAdd.Location = new System.Drawing.Point(49, 52);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(153, 71);
            this.bAdd.TabIndex = 0;
            this.bAdd.Text = "ADD";
            this.bAdd.UseVisualStyleBackColor = false;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bEdit
            // 
            this.bEdit.BackColor = System.Drawing.Color.PaleGreen;
            this.bEdit.Location = new System.Drawing.Point(49, 185);
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(153, 71);
            this.bEdit.TabIndex = 1;
            this.bEdit.Text = "EDIT";
            this.bEdit.UseVisualStyleBackColor = false;
            this.bEdit.Click += new System.EventHandler(this.bEdit_Click);
            // 
            // bDelete
            // 
            this.bDelete.BackColor = System.Drawing.Color.PaleGreen;
            this.bDelete.Location = new System.Drawing.Point(253, 52);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(153, 71);
            this.bDelete.TabIndex = 2;
            this.bDelete.Text = "DELETE";
            this.bDelete.UseVisualStyleBackColor = false;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // bOwnerUser
            // 
            this.bOwnerUser.BackColor = System.Drawing.Color.PaleGreen;
            this.bOwnerUser.Location = new System.Drawing.Point(253, 185);
            this.bOwnerUser.Name = "bOwnerUser";
            this.bOwnerUser.Size = new System.Drawing.Size(153, 71);
            this.bOwnerUser.TabIndex = 3;
            this.bOwnerUser.Text = "OWNER / USER";
            this.bOwnerUser.UseVisualStyleBackColor = false;
            this.bOwnerUser.Click += new System.EventHandler(this.bOwner_Click);
            // 
            // LownerButtonWarning
            // 
            this.LownerButtonWarning.AutoSize = true;
            this.LownerButtonWarning.Location = new System.Drawing.Point(61, 141);
            this.LownerButtonWarning.Name = "LownerButtonWarning";
            this.LownerButtonWarning.Size = new System.Drawing.Size(286, 20);
            this.LownerButtonWarning.TabIndex = 4;
            this.LownerButtonWarning.Text = "The USER button results are slow.";
            this.LownerButtonWarning.Visible = false;
            // 
            // bBack
            // 
            this.bBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(50)))));
            this.bBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBack.Location = new System.Drawing.Point(463, 52);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(59, 204);
            this.bBack.TabIndex = 6;
            this.bBack.Text = "BACK";
            this.bBack.UseVisualStyleBackColor = false;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // bLocation
            // 
            this.bLocation.BackColor = System.Drawing.Color.PaleGreen;
            this.bLocation.Location = new System.Drawing.Point(49, 294);
            this.bLocation.Name = "bLocation";
            this.bLocation.Size = new System.Drawing.Size(357, 71);
            this.bLocation.TabIndex = 7;
            this.bLocation.Text = "LOCATION";
            this.bLocation.UseVisualStyleBackColor = false;
            this.bLocation.Click += new System.EventHandler(this.bLocation_Click);
            // 
            // f01_Task
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(563, 394);
            this.Controls.Add(this.bLocation);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.LownerButtonWarning);
            this.Controls.Add(this.bOwnerUser);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.bEdit);
            this.Controls.Add(this.bAdd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "f01_Task";
            this.Text = "f01_Task";
            this.Load += new System.EventHandler(this.f01_Task_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button bEdit;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.Button bOwnerUser;
        private System.Windows.Forms.Label LownerButtonWarning;
        private System.Windows.Forms.Button bBack;
        private System.Windows.Forms.Button bLocation;
    }
}