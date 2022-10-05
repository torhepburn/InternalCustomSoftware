namespace PMManager
{
    partial class F3_Work_Request_Reports
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
            this.bcontinuousImprovement = new System.Windows.Forms.Button();
            this.bMachineDown = new System.Windows.Forms.Button();
            this.bRepair = new System.Windows.Forms.Button();
            this.bSafety = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bcontinuousImprovement
            // 
            this.bcontinuousImprovement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.bcontinuousImprovement.Location = new System.Drawing.Point(36, 79);
            this.bcontinuousImprovement.Name = "bcontinuousImprovement";
            this.bcontinuousImprovement.Size = new System.Drawing.Size(139, 95);
            this.bcontinuousImprovement.TabIndex = 0;
            this.bcontinuousImprovement.Text = "Continuous Improvement";
            this.bcontinuousImprovement.UseVisualStyleBackColor = false;
            this.bcontinuousImprovement.Click += new System.EventHandler(this.button1_Click);
            // 
            // bMachineDown
            // 
            this.bMachineDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.bMachineDown.Location = new System.Drawing.Point(224, 79);
            this.bMachineDown.Name = "bMachineDown";
            this.bMachineDown.Size = new System.Drawing.Size(139, 95);
            this.bMachineDown.TabIndex = 1;
            this.bMachineDown.Text = "Machine Down  /  Production Stopped";
            this.bMachineDown.UseVisualStyleBackColor = false;
            this.bMachineDown.Click += new System.EventHandler(this.bMachineDown_Click);
            // 
            // bRepair
            // 
            this.bRepair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.bRepair.Location = new System.Drawing.Point(36, 233);
            this.bRepair.Name = "bRepair";
            this.bRepair.Size = new System.Drawing.Size(139, 95);
            this.bRepair.TabIndex = 2;
            this.bRepair.Text = "Repair";
            this.bRepair.UseVisualStyleBackColor = false;
            this.bRepair.Click += new System.EventHandler(this.bRepair_Click);
            // 
            // bSafety
            // 
            this.bSafety.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.bSafety.Location = new System.Drawing.Point(224, 233);
            this.bSafety.Name = "bSafety";
            this.bSafety.Size = new System.Drawing.Size(139, 95);
            this.bSafety.TabIndex = 3;
            this.bSafety.Text = "Safety";
            this.bSafety.UseVisualStyleBackColor = false;
            this.bSafety.Click += new System.EventHandler(this.bSafety_Click);
            // 
            // F3_Work_Request_Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(150)))), ((int)(((byte)(90)))));
            this.ClientSize = new System.Drawing.Size(426, 403);
            this.Controls.Add(this.bSafety);
            this.Controls.Add(this.bRepair);
            this.Controls.Add(this.bMachineDown);
            this.Controls.Add(this.bcontinuousImprovement);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F3_Work_Request_Reports";
            this.Text = "F3_Work_Request_Reports";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bcontinuousImprovement;
        private System.Windows.Forms.Button bMachineDown;
        private System.Windows.Forms.Button bRepair;
        private System.Windows.Forms.Button bSafety;
    }
}