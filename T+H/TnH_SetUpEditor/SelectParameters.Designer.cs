namespace TnH_SetUpEditor
{
    partial class SelectParameters
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
            this.bEmailTo = new System.Windows.Forms.Button();
            this.bTemperatureLimits = new System.Windows.Forms.Button();
            this.bHumidityLimits = new System.Windows.Forms.Button();
            this.bEmailIntervals = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bEmailTo
            // 
            this.bEmailTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(180)))), ((int)(((byte)(30)))));
            this.bEmailTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bEmailTo.Location = new System.Drawing.Point(50, 44);
            this.bEmailTo.Name = "bEmailTo";
            this.bEmailTo.Size = new System.Drawing.Size(151, 90);
            this.bEmailTo.TabIndex = 0;
            this.bEmailTo.Text = "Notification  Recipients";
            this.bEmailTo.UseVisualStyleBackColor = false;
            // 
            // bTemperatureLimits
            // 
            this.bTemperatureLimits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(180)))), ((int)(((byte)(30)))));
            this.bTemperatureLimits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bTemperatureLimits.Location = new System.Drawing.Point(50, 170);
            this.bTemperatureLimits.Name = "bTemperatureLimits";
            this.bTemperatureLimits.Size = new System.Drawing.Size(151, 90);
            this.bTemperatureLimits.TabIndex = 1;
            this.bTemperatureLimits.Text = "Temperature Limits";
            this.bTemperatureLimits.UseVisualStyleBackColor = false;
            // 
            // bHumidityLimits
            // 
            this.bHumidityLimits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(180)))), ((int)(((byte)(30)))));
            this.bHumidityLimits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bHumidityLimits.Location = new System.Drawing.Point(50, 294);
            this.bHumidityLimits.Name = "bHumidityLimits";
            this.bHumidityLimits.Size = new System.Drawing.Size(151, 90);
            this.bHumidityLimits.TabIndex = 2;
            this.bHumidityLimits.Text = "Humidity Limits";
            this.bHumidityLimits.UseVisualStyleBackColor = false;
            // 
            // bEmailIntervals
            // 
            this.bEmailIntervals.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(180)))), ((int)(((byte)(30)))));
            this.bEmailIntervals.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bEmailIntervals.Location = new System.Drawing.Point(50, 415);
            this.bEmailIntervals.Name = "bEmailIntervals";
            this.bEmailIntervals.Size = new System.Drawing.Size(151, 90);
            this.bEmailIntervals.TabIndex = 3;
            this.bEmailIntervals.Text = "Intervals Between Emails";
            this.bEmailIntervals.UseVisualStyleBackColor = false;
            // 
            // SelectParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(160)))));
            this.ClientSize = new System.Drawing.Size(251, 550);
            this.Controls.Add(this.bEmailIntervals);
            this.Controls.Add(this.bHumidityLimits);
            this.Controls.Add(this.bTemperatureLimits);
            this.Controls.Add(this.bEmailTo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SelectParameters";
            this.Text = "Select Parameters";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bEmailTo;
        private System.Windows.Forms.Button bTemperatureLimits;
        private System.Windows.Forms.Button bHumidityLimits;
        private System.Windows.Forms.Button bEmailIntervals;
    }
}

