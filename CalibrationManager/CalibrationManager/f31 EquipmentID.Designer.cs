namespace CalibrationManager
{
    partial class f31_EquipmentID
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
            this.tbTemplate = new System.Windows.Forms.TextBox();
            this.bID = new System.Windows.Forms.Button();
            this.lEnterTemplate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbTemplate
            // 
            this.tbTemplate.BackColor = System.Drawing.Color.LightGreen;
            this.tbTemplate.Location = new System.Drawing.Point(124, 106);
            this.tbTemplate.Name = "tbTemplate";
            this.tbTemplate.Size = new System.Drawing.Size(169, 26);
            this.tbTemplate.TabIndex = 0;
            this.tbTemplate.TextChanged += new System.EventHandler(this.tbTemplate_TextChanged);
            // 
            // bID
            // 
            this.bID.BackColor = System.Drawing.Color.Aquamarine;
            this.bID.Location = new System.Drawing.Point(124, 177);
            this.bID.Name = "bID";
            this.bID.Size = new System.Drawing.Size(169, 53);
            this.bID.TabIndex = 1;
            this.bID.Text = "Assign ID";
            this.bID.UseVisualStyleBackColor = false;
            this.bID.Click += new System.EventHandler(this.bID_Click);
            // 
            // lEnterTemplate
            // 
            this.lEnterTemplate.AutoSize = true;
            this.lEnterTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lEnterTemplate.Location = new System.Drawing.Point(33, 24);
            this.lEnterTemplate.Name = "lEnterTemplate";
            this.lEnterTemplate.Size = new System.Drawing.Size(322, 24);
            this.lEnterTemplate.TabIndex = 2;
            this.lEnterTemplate.Text = "Enter ID prefix: up to 5 characters";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "               or \'SML\' number";
            // 
            // f31_EquipmentID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(423, 285);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lEnterTemplate);
            this.Controls.Add(this.bID);
            this.Controls.Add(this.tbTemplate);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "f31_EquipmentID";
            this.Text = "f31 Equipment ID";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbTemplate;
        private System.Windows.Forms.Button bID;
        private System.Windows.Forms.Label lEnterTemplate;
        private System.Windows.Forms.Label label1;
    }
}