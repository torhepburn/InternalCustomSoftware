namespace TrainingTool
{
    partial class Training
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Training));
            this.Bschedule = new System.Windows.Forms.Button();
            this.Brouting = new System.Windows.Forms.Button();
            this.Bpart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Bschedule
            // 
            this.Bschedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(150)))), ((int)(((byte)(60)))));
            this.Bschedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Bschedule.Location = new System.Drawing.Point(69, 403);
            this.Bschedule.Name = "Bschedule";
            this.Bschedule.Size = new System.Drawing.Size(228, 44);
            this.Bschedule.TabIndex = 0;
            this.Bschedule.Text = "Delete Training Schedule";
            this.Bschedule.UseVisualStyleBackColor = false;
            this.Bschedule.Click += new System.EventHandler(this.bRemove_Click);
            // 
            // Brouting
            // 
            this.Brouting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(150)))), ((int)(((byte)(60)))));
            this.Brouting.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Brouting.Location = new System.Drawing.Point(69, 244);
            this.Brouting.Name = "Brouting";
            this.Brouting.Size = new System.Drawing.Size(228, 45);
            this.Brouting.TabIndex = 1;
            this.Brouting.Text = "Delete Training Routing";
            this.Brouting.UseVisualStyleBackColor = false;
            this.Brouting.Click += new System.EventHandler(this.Brouting_Click);
            // 
            // Bpart
            // 
            this.Bpart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(150)))), ((int)(((byte)(60)))));
            this.Bpart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Bpart.Location = new System.Drawing.Point(69, 322);
            this.Bpart.Name = "Bpart";
            this.Bpart.Size = new System.Drawing.Size(228, 45);
            this.Bpart.TabIndex = 2;
            this.Bpart.Text = "Delete Training Part";
            this.Bpart.UseVisualStyleBackColor = false;
            this.Bpart.Click += new System.EventHandler(this.Bpart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(11, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 180);
            this.label1.TabIndex = 3;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // Training
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(373, 477);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Bpart);
            this.Controls.Add(this.Brouting);
            this.Controls.Add(this.Bschedule);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Training";
            this.Text = "OptiTrak Training Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Bschedule;
        private System.Windows.Forms.Button Brouting;
        private System.Windows.Forms.Button Bpart;
        private System.Windows.Forms.Label label1;
    }
}

