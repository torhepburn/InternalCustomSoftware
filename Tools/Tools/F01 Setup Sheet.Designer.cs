namespace Tools
{
    partial class F01_Setup_Sheet
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
            this.bCopy = new System.Windows.Forms.Button();
            this.bDeleteLine = new System.Windows.Forms.Button();
            this.bDeleteSheet = new System.Windows.Forms.Button();
            this.bView = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bAdd
            // 
            this.bAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.bAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(100)))));
            this.bAdd.Location = new System.Drawing.Point(63, 68);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(159, 64);
            this.bAdd.TabIndex = 0;
            this.bAdd.Text = "ADD";
            this.bAdd.UseVisualStyleBackColor = false;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bEdit
            // 
            this.bEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.bEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(100)))));
            this.bEdit.Location = new System.Drawing.Point(63, 166);
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(159, 64);
            this.bEdit.TabIndex = 1;
            this.bEdit.Text = "EDIT";
            this.bEdit.UseVisualStyleBackColor = false;
            // 
            // bCopy
            // 
            this.bCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.bCopy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(100)))));
            this.bCopy.Location = new System.Drawing.Point(255, 68);
            this.bCopy.Name = "bCopy";
            this.bCopy.Size = new System.Drawing.Size(159, 64);
            this.bCopy.TabIndex = 2;
            this.bCopy.Text = "COPY";
            this.bCopy.UseVisualStyleBackColor = false;
            this.bCopy.Click += new System.EventHandler(this.bCopy_Click);
            // 
            // bDeleteLine
            // 
            this.bDeleteLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.bDeleteLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(100)))));
            this.bDeleteLine.Location = new System.Drawing.Point(255, 166);
            this.bDeleteLine.Name = "bDeleteLine";
            this.bDeleteLine.Size = new System.Drawing.Size(159, 64);
            this.bDeleteLine.TabIndex = 3;
            this.bDeleteLine.Text = "DELETE LINE";
            this.bDeleteLine.UseVisualStyleBackColor = false;
            // 
            // bDeleteSheet
            // 
            this.bDeleteSheet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.bDeleteSheet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(100)))));
            this.bDeleteSheet.Location = new System.Drawing.Point(255, 264);
            this.bDeleteSheet.Name = "bDeleteSheet";
            this.bDeleteSheet.Size = new System.Drawing.Size(159, 64);
            this.bDeleteSheet.TabIndex = 5;
            this.bDeleteSheet.Text = "DELETE SHEET";
            this.bDeleteSheet.UseVisualStyleBackColor = false;
            // 
            // bView
            // 
            this.bView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.bView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(100)))));
            this.bView.Location = new System.Drawing.Point(63, 264);
            this.bView.Name = "bView";
            this.bView.Size = new System.Drawing.Size(159, 64);
            this.bView.TabIndex = 4;
            this.bView.Text = "VIEW";
            this.bView.UseVisualStyleBackColor = false;
            this.bView.Click += new System.EventHandler(this.bView_Click);
            // 
            // F01_Setup_Sheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(488, 372);
            this.Controls.Add(this.bDeleteSheet);
            this.Controls.Add(this.bView);
            this.Controls.Add(this.bDeleteLine);
            this.Controls.Add(this.bCopy);
            this.Controls.Add(this.bEdit);
            this.Controls.Add(this.bAdd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F01_Setup_Sheet";
            this.Text = "F01_Setup_Sheet";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button bEdit;
        private System.Windows.Forms.Button bCopy;
        private System.Windows.Forms.Button bDeleteLine;
        private System.Windows.Forms.Button bDeleteSheet;
        private System.Windows.Forms.Button bView;
    }
}