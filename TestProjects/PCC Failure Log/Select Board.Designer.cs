namespace PCC_Failure_Log
{
    partial class Select_Board
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
            this.b4104 = new System.Windows.Forms.Button();
            this.b4004 = new System.Windows.Forms.Button();
            this.Ltask = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // b4104
            // 
            this.b4104.BackColor = System.Drawing.Color.CornflowerBlue;
            this.b4104.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b4104.Location = new System.Drawing.Point(54, 312);
            this.b4104.Name = "b4104";
            this.b4104.Size = new System.Drawing.Size(237, 101);
            this.b4104.TabIndex = 3;
            this.b4104.Text = "4104";
            this.b4104.UseVisualStyleBackColor = false;
            this.b4104.Click += new System.EventHandler(this.b4104_Click);
            // 
            // b4004
            // 
            this.b4004.BackColor = System.Drawing.Color.CadetBlue;
            this.b4004.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b4004.Location = new System.Drawing.Point(54, 177);
            this.b4004.Name = "b4004";
            this.b4004.Size = new System.Drawing.Size(237, 101);
            this.b4004.TabIndex = 2;
            this.b4004.Text = "4004";
            this.b4004.UseVisualStyleBackColor = false;
            this.b4004.Click += new System.EventHandler(this.b4004_Click);
            // 
            // Ltask
            // 
            this.Ltask.AutoSize = true;
            this.Ltask.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ltask.Location = new System.Drawing.Point(48, 34);
            this.Ltask.Name = "Ltask";
            this.Ltask.Size = new System.Drawing.Size(227, 31);
            this.Ltask.TabIndex = 9;
            this.Ltask.Text = "Select Company";
            // 
            // Select_Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(110)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(355, 464);
            this.Controls.Add(this.Ltask);
            this.Controls.Add(this.b4104);
            this.Controls.Add(this.b4004);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "Select_Board";
            this.Text = "Select_Board";
            this.Load += new System.EventHandler(this.Select_Board_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b4104;
        private System.Windows.Forms.Button b4004;
        private System.Windows.Forms.Label Ltask;
    }
}