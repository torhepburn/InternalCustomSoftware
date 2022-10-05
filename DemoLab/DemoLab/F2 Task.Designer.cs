namespace DemoLab
{
    partial class F2_Task
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
            this.bLocation = new System.Windows.Forms.Button();
            this.bBack = new System.Windows.Forms.Button();
            this.bOwnerUser = new System.Windows.Forms.Button();
            this.bDelete = new System.Windows.Forms.Button();
            this.bEdit = new System.Windows.Forms.Button();
            this.bAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bLocation
            // 
            this.bLocation.BackColor = System.Drawing.Color.PaleGreen;
            this.bLocation.Location = new System.Drawing.Point(33, 285);
            this.bLocation.Name = "bLocation";
            this.bLocation.Size = new System.Drawing.Size(357, 71);
            this.bLocation.TabIndex = 20;
            this.bLocation.Text = "LOCATION";
            this.bLocation.UseVisualStyleBackColor = false;
            // 
            // bBack
            // 
            this.bBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(50)))));
            this.bBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBack.Location = new System.Drawing.Point(447, 43);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(59, 204);
            this.bBack.TabIndex = 19;
            this.bBack.Text = "BACK";
            this.bBack.UseVisualStyleBackColor = false;
            // 
            // bOwnerUser
            // 
            this.bOwnerUser.BackColor = System.Drawing.Color.PaleGreen;
            this.bOwnerUser.Location = new System.Drawing.Point(237, 176);
            this.bOwnerUser.Name = "bOwnerUser";
            this.bOwnerUser.Size = new System.Drawing.Size(153, 71);
            this.bOwnerUser.TabIndex = 18;
            this.bOwnerUser.Text = "OWNER / USER";
            this.bOwnerUser.UseVisualStyleBackColor = false;
            // 
            // bDelete
            // 
            this.bDelete.BackColor = System.Drawing.Color.PaleGreen;
            this.bDelete.Location = new System.Drawing.Point(237, 43);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(153, 71);
            this.bDelete.TabIndex = 17;
            this.bDelete.Text = "DELETE";
            this.bDelete.UseVisualStyleBackColor = false;
            // 
            // bEdit
            // 
            this.bEdit.BackColor = System.Drawing.Color.PaleGreen;
            this.bEdit.Location = new System.Drawing.Point(33, 176);
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(153, 71);
            this.bEdit.TabIndex = 16;
            this.bEdit.Text = "EDIT";
            this.bEdit.UseVisualStyleBackColor = false;
            // 
            // bAdd
            // 
            this.bAdd.BackColor = System.Drawing.Color.PaleGreen;
            this.bAdd.Location = new System.Drawing.Point(33, 43);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(153, 71);
            this.bAdd.TabIndex = 15;
            this.bAdd.Text = "ADD";
            this.bAdd.UseVisualStyleBackColor = false;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // F2_Task
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(150)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(549, 392);
            this.Controls.Add(this.bLocation);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.bOwnerUser);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.bEdit);
            this.Controls.Add(this.bAdd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F2_Task";
            this.Text = "F2_Task";
            this.Load += new System.EventHandler(this.F2_Task_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bLocation;
        private System.Windows.Forms.Button bBack;
        private System.Windows.Forms.Button bOwnerUser;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.Button bEdit;
        private System.Windows.Forms.Button bAdd;
    }
}