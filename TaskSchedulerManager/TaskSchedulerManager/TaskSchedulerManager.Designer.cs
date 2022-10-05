namespace TaskSchedulerManager
{
    partial class TaskSchedulerManager
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
            this.bUpdate = new System.Windows.Forms.Button();
            this.bCalcBUDall09 = new System.Windows.Forms.Button();
            this.bCalcOps = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bUpdate
            // 
            this.bUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(105)))));
            this.bUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bUpdate.Location = new System.Drawing.Point(30, 28);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(230, 52);
            this.bUpdate.TabIndex = 0;
            this.bUpdate.Text = "BPM Update";
            this.bUpdate.UseVisualStyleBackColor = false;
            this.bUpdate.Click += new System.EventHandler(this.button1_Click);
            // 
            // bCalcBUDall09
            // 
            this.bCalcBUDall09.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(155)))), ((int)(((byte)(205)))));
            this.bCalcBUDall09.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bCalcBUDall09.Location = new System.Drawing.Point(27, 105);
            this.bCalcBUDall09.Name = "bCalcBUDall09";
            this.bCalcBUDall09.Size = new System.Drawing.Size(230, 52);
            this.bCalcBUDall09.TabIndex = 1;
            this.bCalcBUDall09.Text = "BPM Calc - Bud All 09";
            this.bCalcBUDall09.UseVisualStyleBackColor = false;
            this.bCalcBUDall09.Click += new System.EventHandler(this.bCalcBUDall09_Click);
            // 
            // bCalcOps
            // 
            this.bCalcOps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(155)))), ((int)(((byte)(105)))));
            this.bCalcOps.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bCalcOps.Location = new System.Drawing.Point(30, 182);
            this.bCalcOps.Name = "bCalcOps";
            this.bCalcOps.Size = new System.Drawing.Size(230, 52);
            this.bCalcOps.TabIndex = 2;
            this.bCalcOps.Text = "BPM Calc - Ops";
            this.bCalcOps.UseVisualStyleBackColor = false;
            this.bCalcOps.Click += new System.EventHandler(this.bCalcOps_Click);
            // 
            // TaskSchedulerManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(205)))), ((int)(((byte)(105)))));
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.bCalcOps);
            this.Controls.Add(this.bCalcBUDall09);
            this.Controls.Add(this.bUpdate);
            this.Name = "TaskSchedulerManager";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.Button bCalcBUDall09;
        private System.Windows.Forms.Button bCalcOps;
    }
}

