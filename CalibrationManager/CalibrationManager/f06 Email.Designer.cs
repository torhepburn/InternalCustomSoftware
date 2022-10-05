namespace CalibrationManager
{
    partial class f06_Email
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
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.tbSubject = new System.Windows.Forms.TextBox();
            this.bSend = new System.Windows.Forms.Button();
            this.LSubject = new System.Windows.Forms.Label();
            this.LBody = new System.Windows.Forms.Label();
            this.bBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbMessage
            // 
            this.tbMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            this.tbMessage.Location = new System.Drawing.Point(59, 119);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(685, 400);
            this.tbMessage.TabIndex = 0;
            // 
            // tbSubject
            // 
            this.tbSubject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            this.tbSubject.Location = new System.Drawing.Point(59, 51);
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Size = new System.Drawing.Size(684, 26);
            this.tbSubject.TabIndex = 1;
            // 
            // bSend
            // 
            this.bSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSend.Location = new System.Drawing.Point(59, 545);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(685, 40);
            this.bSend.TabIndex = 2;
            this.bSend.Text = "SEND";
            this.bSend.UseVisualStyleBackColor = false;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // LSubject
            // 
            this.LSubject.AutoSize = true;
            this.LSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LSubject.Location = new System.Drawing.Point(68, 28);
            this.LSubject.Name = "LSubject";
            this.LSubject.Size = new System.Drawing.Size(114, 20);
            this.LSubject.TabIndex = 3;
            this.LSubject.Text = "Subject Line:";
            // 
            // LBody
            // 
            this.LBody.AutoSize = true;
            this.LBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBody.Location = new System.Drawing.Point(68, 96);
            this.LBody.Name = "LBody";
            this.LBody.Size = new System.Drawing.Size(118, 20);
            this.LBody.TabIndex = 4;
            this.LBody.Text = "Text of Email:";
            // 
            // bBack
            // 
            this.bBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(50)))));
            this.bBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBack.Location = new System.Drawing.Point(789, 51);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(59, 534);
            this.bBack.TabIndex = 7;
            this.bBack.Text = "BACK";
            this.bBack.UseVisualStyleBackColor = false;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // f06_Email
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(0)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(891, 607);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.LBody);
            this.Controls.Add(this.LSubject);
            this.Controls.Add(this.bSend);
            this.Controls.Add(this.tbSubject);
            this.Controls.Add(this.tbMessage);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "f06_Email";
            this.Text = "f06_Email";
            this.Load += new System.EventHandler(this.f06_Email_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.TextBox tbSubject;
        private System.Windows.Forms.Button bSend;
        private System.Windows.Forms.Label LSubject;
        private System.Windows.Forms.Label LBody;
        private System.Windows.Forms.Button bBack;
    }
}