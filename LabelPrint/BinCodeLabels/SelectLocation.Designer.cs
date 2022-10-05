
namespace BinCodeLabels
{
    partial class SelectLocation
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
            this.cbddLocationCode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbddLocationCode
            // 
            this.cbddLocationCode.FormattingEnabled = true;
            this.cbddLocationCode.Location = new System.Drawing.Point(203, 52);
            this.cbddLocationCode.Name = "cbddLocationCode";
            this.cbddLocationCode.Size = new System.Drawing.Size(178, 29);
            this.cbddLocationCode.TabIndex = 12;
            this.cbddLocationCode.SelectedIndexChanged += new System.EventHandler(this.cbddLocationCode_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 21);
            this.label4.TabIndex = 11;
            this.label4.Text = "Location Code";
            // 
            // SelectLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(80)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(502, 126);
            this.Controls.Add(this.cbddLocationCode);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SelectLocation";
            this.Text = "SelectLocation";
            this.Load += new System.EventHandler(this.SelectLocation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbddLocationCode;
        private System.Windows.Forms.Label label4;
    }
}