
namespace Certs
{
    partial class AddNewCopy
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
            this.bNew = new System.Windows.Forms.Button();
            this.bCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bNew
            // 
            this.bNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(80)))));
            this.bNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bNew.Location = new System.Drawing.Point(50, 40);
            this.bNew.Name = "bNew";
            this.bNew.Size = new System.Drawing.Size(387, 50);
            this.bNew.TabIndex = 2;
            this.bNew.Text = "Add New Entry - Blank Form";
            this.bNew.UseVisualStyleBackColor = false;
            this.bNew.Click += new System.EventHandler(this.bNew_Click);
            // 
            // bCopy
            // 
            this.bCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(80)))));
            this.bCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bCopy.Location = new System.Drawing.Point(50, 130);
            this.bCopy.Name = "bCopy";
            this.bCopy.Size = new System.Drawing.Size(387, 50);
            this.bCopy.TabIndex = 3;
            this.bCopy.Text = "Add New Entry - Copy Data from Existing Entry";
            this.bCopy.UseVisualStyleBackColor = false;
            this.bCopy.Click += new System.EventHandler(this.bCopy_Click);
            // 
            // AddNewCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(100)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(520, 240);
            this.Controls.Add(this.bCopy);
            this.Controls.Add(this.bNew);
            this.Name = "AddNewCopy";
            this.Text = "AddNewCopy";
            this.Load += new System.EventHandler(this.AddNewCopy_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bNew;
        private System.Windows.Forms.Button bCopy;
    }
}