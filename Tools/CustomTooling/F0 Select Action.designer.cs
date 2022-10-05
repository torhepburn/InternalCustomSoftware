namespace CustomTooling
{
    partial class F0_Select_Action
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
            this.bFind = new System.Windows.Forms.Button();
            this.bReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bAdd
            // 
            this.bAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(100)))), ((int)(((byte)(150)))));
            this.bAdd.Location = new System.Drawing.Point(54, 37);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(150, 150);
            this.bAdd.TabIndex = 0;
            this.bAdd.Text = "ADD";
            this.bAdd.UseVisualStyleBackColor = false;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bEdit
            // 
            this.bEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(50)))));
            this.bEdit.Location = new System.Drawing.Point(235, 37);
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(150, 150);
            this.bEdit.TabIndex = 1;
            this.bEdit.Text = "EDIT";
            this.bEdit.UseVisualStyleBackColor = false;
            this.bEdit.Click += new System.EventHandler(this.bEdit_Click);
            // 
            // bFind
            // 
            this.bFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(100)))), ((int)(((byte)(50)))));
            this.bFind.Location = new System.Drawing.Point(54, 219);
            this.bFind.Name = "bFind";
            this.bFind.Size = new System.Drawing.Size(150, 150);
            this.bFind.TabIndex = 2;
            this.bFind.Text = "FIND";
            this.bFind.UseVisualStyleBackColor = false;
            this.bFind.Click += new System.EventHandler(this.bFind_Click);
            // 
            // bReport
            // 
            this.bReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(250)))), ((int)(((byte)(150)))));
            this.bReport.Location = new System.Drawing.Point(235, 219);
            this.bReport.Name = "bReport";
            this.bReport.Size = new System.Drawing.Size(150, 150);
            this.bReport.TabIndex = 3;
            this.bReport.UseVisualStyleBackColor = false;
            // 
            // F0_Select_Action
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.ClientSize = new System.Drawing.Size(443, 403);
            this.Controls.Add(this.bReport);
            this.Controls.Add(this.bFind);
            this.Controls.Add(this.bEdit);
            this.Controls.Add(this.bAdd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F0_Select_Action";
            this.Text = "F0 Custom Optics Tooling Database";
            this.Load += new System.EventHandler(this.F0_Select_Action_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button bEdit;
        private System.Windows.Forms.Button bFind;
        private System.Windows.Forms.Button bReport;
    }
}