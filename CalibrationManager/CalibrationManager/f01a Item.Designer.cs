namespace CalibrationManager
{
    partial class f0_Entry_Point
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
            this.bEquipment = new System.Windows.Forms.Button();
            this.bLOCATION = new System.Windows.Forms.Button();
            this.bRoom = new System.Windows.Forms.Button();
            this.bSpecial = new System.Windows.Forms.Button();
            this.bBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bEquipment
            // 
            this.bEquipment.BackColor = System.Drawing.Color.Yellow;
            this.bEquipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bEquipment.Location = new System.Drawing.Point(55, 54);
            this.bEquipment.Name = "bEquipment";
            this.bEquipment.Size = new System.Drawing.Size(155, 72);
            this.bEquipment.TabIndex = 0;
            this.bEquipment.Text = "EQUIPMENT";
            this.bEquipment.UseVisualStyleBackColor = false;
            this.bEquipment.Click += new System.EventHandler(this.bEquipment_Click);
            // 
            // bLOCATION
            // 
            this.bLOCATION.BackColor = System.Drawing.Color.Yellow;
            this.bLOCATION.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLOCATION.Location = new System.Drawing.Point(55, 165);
            this.bLOCATION.Name = "bLOCATION";
            this.bLOCATION.Size = new System.Drawing.Size(155, 72);
            this.bLOCATION.TabIndex = 1;
            this.bLOCATION.Text = "LOCATION";
            this.bLOCATION.UseVisualStyleBackColor = false;
            this.bLOCATION.Click += new System.EventHandler(this.bLOCATION_Click);
            // 
            // bRoom
            // 
            this.bRoom.BackColor = System.Drawing.Color.Yellow;
            this.bRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bRoom.Location = new System.Drawing.Point(249, 165);
            this.bRoom.Name = "bRoom";
            this.bRoom.Size = new System.Drawing.Size(155, 72);
            this.bRoom.TabIndex = 2;
            this.bRoom.Text = "ROOM";
            this.bRoom.UseVisualStyleBackColor = false;
            this.bRoom.Click += new System.EventHandler(this.bRoom_Click);
            // 
            // bSpecial
            // 
            this.bSpecial.BackColor = System.Drawing.Color.Yellow;
            this.bSpecial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSpecial.Location = new System.Drawing.Point(249, 54);
            this.bSpecial.Name = "bSpecial";
            this.bSpecial.Size = new System.Drawing.Size(155, 72);
            this.bSpecial.TabIndex = 3;
            this.bSpecial.Text = "SPECIAL";
            this.bSpecial.UseVisualStyleBackColor = false;
            this.bSpecial.Visible = false;
            this.bSpecial.Click += new System.EventHandler(this.bSpecial_Click);
            // 
            // bBack
            // 
            this.bBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(50)))));
            this.bBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBack.Location = new System.Drawing.Point(447, 54);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(59, 183);
            this.bBack.TabIndex = 6;
            this.bBack.Text = "BACK";
            this.bBack.UseVisualStyleBackColor = false;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // f0_Entry_Point
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(539, 300);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.bSpecial);
            this.Controls.Add(this.bRoom);
            this.Controls.Add(this.bLOCATION);
            this.Controls.Add(this.bEquipment);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "f0_Entry_Point";
            this.Text = "f01a Setup";
            this.Load += new System.EventHandler(this.f0_Entry_Point_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bEquipment;
        private System.Windows.Forms.Button bLOCATION;
        private System.Windows.Forms.Button bRoom;
        private System.Windows.Forms.Button bSpecial;
        private System.Windows.Forms.Button bBack;
    }
}