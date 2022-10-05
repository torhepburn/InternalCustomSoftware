namespace OptiTRAK
{
    partial class F0_Choices
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
            this.bDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bAdd
            // 
            this.bAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(155)))), ((int)(((byte)(15)))));
            this.bAdd.Location = new System.Drawing.Point(120, 45);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(170, 129);
            this.bAdd.TabIndex = 0;
            this.bAdd.Text = "ADD";
            this.bAdd.UseVisualStyleBackColor = false;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bDelete
            // 
            this.bDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(155)))), ((int)(((byte)(15)))));
            this.bDelete.Location = new System.Drawing.Point(120, 224);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(170, 129);
            this.bDelete.TabIndex = 1;
            this.bDelete.Text = "DELETE";
            this.bDelete.UseVisualStyleBackColor = false;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // F0_Choices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(55)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(426, 403);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.bAdd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F0_Choices";
            this.Text = "F0_Choices";
            this.Load += new System.EventHandler(this.F0_Choices_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button bDelete;
    }
}