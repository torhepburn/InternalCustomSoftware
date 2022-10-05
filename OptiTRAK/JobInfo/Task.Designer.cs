namespace JobInfo
{
    partial class Task
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
            this.bCloseJobs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bAdd
            // 
            this.bAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(134)))), ((int)(((byte)(134)))));
            this.bAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bAdd.Location = new System.Drawing.Point(47, 50);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(191, 75);
            this.bAdd.TabIndex = 0;
            this.bAdd.Text = "Add Job Info";
            this.bAdd.UseVisualStyleBackColor = false;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bEdit
            // 
            this.bEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(184)))), ((int)(((byte)(134)))));
            this.bEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bEdit.Location = new System.Drawing.Point(47, 157);
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(191, 75);
            this.bEdit.TabIndex = 1;
            this.bEdit.Text = "Edit Job Info";
            this.bEdit.UseVisualStyleBackColor = false;
            this.bEdit.Click += new System.EventHandler(this.bEdit_Click);
            // 
            // bCloseJobs
            // 
            this.bCloseJobs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.bCloseJobs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bCloseJobs.Location = new System.Drawing.Point(47, 264);
            this.bCloseJobs.Name = "bCloseJobs";
            this.bCloseJobs.Size = new System.Drawing.Size(191, 75);
            this.bCloseJobs.TabIndex = 2;
            this.bCloseJobs.Text = "Close Jobs";
            this.bCloseJobs.UseVisualStyleBackColor = false;
            this.bCloseJobs.Visible = false;
            this.bCloseJobs.Click += new System.EventHandler(this.bCloseJobs_Click);
            // 
            // Task
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(134)))), ((int)(((byte)(134)))));
            this.ClientSize = new System.Drawing.Size(284, 379);
            this.Controls.Add(this.bCloseJobs);
            this.Controls.Add(this.bEdit);
            this.Controls.Add(this.bAdd);
            this.Name = "Task";
            this.Text = "Task";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button bEdit;
        private System.Windows.Forms.Button bCloseJobs;
    }
}