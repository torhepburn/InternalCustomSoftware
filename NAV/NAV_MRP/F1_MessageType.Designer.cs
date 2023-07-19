namespace NAV_MRP
{
    partial class F1_MessageType
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
            this.BNotCancel = new System.Windows.Forms.Button();
            this.BCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BNotCancel
            // 
            this.BNotCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(153)))), ((int)(((byte)(164)))));
            this.BNotCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BNotCancel.Location = new System.Drawing.Point(22, 42);
            this.BNotCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BNotCancel.Name = "BNotCancel";
            this.BNotCancel.Size = new System.Drawing.Size(219, 68);
            this.BNotCancel.TabIndex = 2;
            this.BNotCancel.Text = "Non-Cancel Messages";
            this.BNotCancel.UseVisualStyleBackColor = false;
            this.BNotCancel.Click += new System.EventHandler(this.BNotCancel_Click);
            // 
            // BCancel
            // 
            this.BCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(153)))), ((int)(((byte)(64)))));
            this.BCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BCancel.Location = new System.Drawing.Point(275, 42);
            this.BCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BCancel.Name = "BCancel";
            this.BCancel.Size = new System.Drawing.Size(219, 68);
            this.BCancel.TabIndex = 3;
            this.BCancel.Text = "Cancel Messages";
            this.BCancel.UseVisualStyleBackColor = false;
            this.BCancel.Click += new System.EventHandler(this.BCancel_Click);
            // 
            // F1_MessageType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 148);
            this.Controls.Add(this.BCancel);
            this.Controls.Add(this.BNotCancel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F1_MessageType";
            this.Text = "F1_MessageType";
            this.Load += new System.EventHandler(this.F1_MessageType_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BNotCancel;
        private System.Windows.Forms.Button BCancel;
    }
}