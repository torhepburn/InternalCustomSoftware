namespace TnH_ServerRoom
{
    partial class ServerRoomRichmond
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
            this.label4 = new System.Windows.Forms.Label();
            this.Ltime = new System.Windows.Forms.Label();
            this.Lhum = new System.Windows.Forms.Label();
            this.Ltemp = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(240)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label4.Location = new System.Drawing.Point(101, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(375, 31);
            this.label4.TabIndex = 19;
            this.label4.Text = "RICHMOND SERVER ROOM";
            // 
            // Ltime
            // 
            this.Ltime.AutoSize = true;
            this.Ltime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(240)))));
            this.Ltime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.Ltime.Location = new System.Drawing.Point(245, 206);
            this.Ltime.Name = "Ltime";
            this.Ltime.Size = new System.Drawing.Size(0, 31);
            this.Ltime.TabIndex = 18;
            // 
            // Lhum
            // 
            this.Lhum.AutoSize = true;
            this.Lhum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(240)))));
            this.Lhum.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.Lhum.Location = new System.Drawing.Point(245, 155);
            this.Lhum.Name = "Lhum";
            this.Lhum.Size = new System.Drawing.Size(0, 31);
            this.Lhum.TabIndex = 17;
            // 
            // Ltemp
            // 
            this.Ltemp.AutoSize = true;
            this.Ltemp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(240)))));
            this.Ltemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.Ltemp.Location = new System.Drawing.Point(245, 105);
            this.Ltemp.Name = "Ltemp";
            this.Ltemp.Size = new System.Drawing.Size(0, 31);
            this.Ltemp.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(56, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "DATE  + TIME:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(56, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "HUMIDITY:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(56, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "TEMPERATURE:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ServerRoomRichmond
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(190)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(584, 282);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Ltime);
            this.Controls.Add(this.Lhum);
            this.Controls.Add(this.Ltemp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ServerRoomRichmond";
            this.Text = "ServerRoomRichmond";
            this.Load += new System.EventHandler(this.ServerRoomRichmond_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Ltime;
        private System.Windows.Forms.Label Lhum;
        private System.Windows.Forms.Label Ltemp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}