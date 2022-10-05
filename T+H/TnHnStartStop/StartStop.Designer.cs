namespace TnHnStartStop
{
    partial class TnHStartStop
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
            this.components = new System.ComponentModel.Container();
            this.b73 = new System.Windows.Forms.Button();
            this.b74 = new System.Windows.Forms.Button();
            this.b79 = new System.Windows.Forms.Button();
            this.b81 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bCRM = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b73
            // 
            this.b73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(187)))), ((int)(((byte)(120)))));
            this.b73.Location = new System.Drawing.Point(34, 31);
            this.b73.Name = "b73";
            this.b73.Size = new System.Drawing.Size(75, 52);
            this.b73.TabIndex = 0;
            this.b73.Text = "73";
            this.b73.UseVisualStyleBackColor = false;
            this.b73.Click += new System.EventHandler(this.b73_Click);
            // 
            // b74
            // 
            this.b74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(187)))), ((int)(((byte)(120)))));
            this.b74.Location = new System.Drawing.Point(34, 104);
            this.b74.Name = "b74";
            this.b74.Size = new System.Drawing.Size(75, 52);
            this.b74.TabIndex = 1;
            this.b74.Text = "74";
            this.b74.UseVisualStyleBackColor = false;
            this.b74.Click += new System.EventHandler(this.b74_Click);
            // 
            // b79
            // 
            this.b79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(187)))), ((int)(((byte)(120)))));
            this.b79.Location = new System.Drawing.Point(34, 174);
            this.b79.Name = "b79";
            this.b79.Size = new System.Drawing.Size(75, 52);
            this.b79.TabIndex = 2;
            this.b79.Text = "79";
            this.b79.UseVisualStyleBackColor = false;
            this.b79.Click += new System.EventHandler(this.b79_Click);
            // 
            // b81
            // 
            this.b81.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(187)))), ((int)(((byte)(120)))));
            this.b81.Location = new System.Drawing.Point(34, 247);
            this.b81.Name = "b81";
            this.b81.Size = new System.Drawing.Size(75, 52);
            this.b81.TabIndex = 3;
            this.b81.Text = "81";
            this.b81.UseVisualStyleBackColor = false;
            this.b81.Click += new System.EventHandler(this.b81_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bCRM
            // 
            this.bCRM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(187)))), ((int)(((byte)(120)))));
            this.bCRM.Location = new System.Drawing.Point(125, 31);
            this.bCRM.Name = "bCRM";
            this.bCRM.Size = new System.Drawing.Size(75, 52);
            this.bCRM.TabIndex = 4;
            this.bCRM.Text = "CRM";
            this.bCRM.UseVisualStyleBackColor = false;
            this.bCRM.Click += new System.EventHandler(this.bCRM_Click);
            // 
            // TnHStartStop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(87)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(426, 330);
            this.Controls.Add(this.bCRM);
            this.Controls.Add(this.b81);
            this.Controls.Add(this.b79);
            this.Controls.Add(this.b74);
            this.Controls.Add(this.b73);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TnHStartStop";
            this.Text = "TnH Start Stop";
            this.Load += new System.EventHandler(this.TnHStartStop_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b73;
        private System.Windows.Forms.Button b74;
        private System.Windows.Forms.Button b79;
        private System.Windows.Forms.Button b81;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button bCRM;
    }
}

