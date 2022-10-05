namespace QuoteWerksServiceExport
{
    partial class ChooseData
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
            this.BItems = new System.Windows.Forms.Button();
            this.BContracts = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BItems
            // 
            this.BItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(250)))));
            this.BItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BItems.Location = new System.Drawing.Point(65, 65);
            this.BItems.Name = "BItems";
            this.BItems.Size = new System.Drawing.Size(160, 59);
            this.BItems.TabIndex = 0;
            this.BItems.Text = "Service Items";
            this.BItems.UseVisualStyleBackColor = false;
            this.BItems.Click += new System.EventHandler(this.BItems_Click);
            // 
            // BContracts
            // 
            this.BContracts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(250)))));
            this.BContracts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BContracts.Location = new System.Drawing.Point(64, 196);
            this.BContracts.Name = "BContracts";
            this.BContracts.Size = new System.Drawing.Size(160, 59);
            this.BContracts.TabIndex = 1;
            this.BContracts.Text = "Service Contracts";
            this.BContracts.UseVisualStyleBackColor = false;
            this.BContracts.Click += new System.EventHandler(this.BContracts_Click);
            // 
            // ChooseData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(200)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(288, 332);
            this.Controls.Add(this.BContracts);
            this.Controls.Add(this.BItems);
            this.Name = "ChooseData";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BItems;
        private System.Windows.Forms.Button BContracts;
    }
}

