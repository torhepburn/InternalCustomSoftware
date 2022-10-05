namespace WindowsFormApps
{
    partial class FileList
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
            this.bInstrument = new System.Windows.Forms.Button();
            this.bPPS = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bInstrument
            // 
            this.bInstrument.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(130)))));
            this.bInstrument.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bInstrument.Location = new System.Drawing.Point(54, 22);
            this.bInstrument.Name = "bInstrument";
            this.bInstrument.Size = new System.Drawing.Size(223, 67);
            this.bInstrument.TabIndex = 0;
            this.bInstrument.Text = "Instrument";
            this.bInstrument.UseVisualStyleBackColor = false;
            this.bInstrument.Click += new System.EventHandler(this.bInstrument_Click);
            // 
            // bPPS
            // 
            this.bPPS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(130)))));
            this.bPPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bPPS.Location = new System.Drawing.Point(54, 121);
            this.bPPS.Name = "bPPS";
            this.bPPS.Size = new System.Drawing.Size(223, 67);
            this.bPPS.TabIndex = 1;
            this.bPPS.Text = "PPS";
            this.bPPS.UseVisualStyleBackColor = false;
            // 
            // FileList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.ClientSize = new System.Drawing.Size(343, 231);
            this.Controls.Add(this.bPPS);
            this.Controls.Add(this.bInstrument);
            this.Name = "FileList";
            this.Text = "Select Product Group";
            this.Load += new System.EventHandler(this.FileList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bInstrument;
        private System.Windows.Forms.Button bPPS;
    }
}

