namespace NDA
{
    partial class ProcurementChoices
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
            this.BAdd = new System.Windows.Forms.Button();
            this.BEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BAdd
            // 
            this.BAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(180)))), ((int)(((byte)(0)))));
            this.BAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BAdd.Location = new System.Drawing.Point(115, 56);
            this.BAdd.Name = "BAdd";
            this.BAdd.Size = new System.Drawing.Size(131, 78);
            this.BAdd.TabIndex = 0;
            this.BAdd.Text = "Add NDA";
            this.BAdd.UseVisualStyleBackColor = false;
            this.BAdd.Click += new System.EventHandler(this.BAdd_Click);
            // 
            // BEdit
            // 
            this.BEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.BEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BEdit.Location = new System.Drawing.Point(115, 178);
            this.BEdit.Name = "BEdit";
            this.BEdit.Size = new System.Drawing.Size(131, 78);
            this.BEdit.TabIndex = 1;
            this.BEdit.Text = "Edit NDA";
            this.BEdit.UseVisualStyleBackColor = false;
            this.BEdit.Click += new System.EventHandler(this.BEdit_Click);
            // 
            // ProcurementChoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(122)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(379, 322);
            this.Controls.Add(this.BEdit);
            this.Controls.Add(this.BAdd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ProcurementChoices";
            this.Text = "ProcurementChoices";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BAdd;
        private System.Windows.Forms.Button BEdit;
    }
}