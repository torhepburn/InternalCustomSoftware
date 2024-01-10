namespace LicenseGenerator
{
    partial class f1SelectProduct
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
            this.bMetroPro = new System.Windows.Forms.Button();
            this.bMPX = new System.Windows.Forms.Button();
            this.bZeMaps = new System.Windows.Forms.Button();
            this.bAssembly = new System.Windows.Forms.Button();
            this.Bblock = new System.Windows.Forms.Button();
            this.Bunblock = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bMetroPro
            // 
            this.bMetroPro.BackColor = System.Drawing.Color.LightCoral;
            this.bMetroPro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bMetroPro.Location = new System.Drawing.Point(52, 51);
            this.bMetroPro.Name = "bMetroPro";
            this.bMetroPro.Size = new System.Drawing.Size(148, 57);
            this.bMetroPro.TabIndex = 0;
            this.bMetroPro.Text = "MetroPro";
            this.bMetroPro.UseVisualStyleBackColor = false;
            this.bMetroPro.Click += new System.EventHandler(this.bMetroPro_Click);
            // 
            // bMPX
            // 
            this.bMPX.BackColor = System.Drawing.Color.LightCoral;
            this.bMPX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bMPX.Location = new System.Drawing.Point(240, 51);
            this.bMPX.Name = "bMPX";
            this.bMPX.Size = new System.Drawing.Size(148, 57);
            this.bMPX.TabIndex = 1;
            this.bMPX.Text = "MX";
            this.bMPX.UseVisualStyleBackColor = false;
            this.bMPX.Click += new System.EventHandler(this.bMPX_Click);
            // 
            // bZeMaps
            // 
            this.bZeMaps.BackColor = System.Drawing.Color.LightCoral;
            this.bZeMaps.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bZeMaps.Location = new System.Drawing.Point(440, 51);
            this.bZeMaps.Name = "bZeMaps";
            this.bZeMaps.Size = new System.Drawing.Size(148, 57);
            this.bZeMaps.TabIndex = 2;
            this.bZeMaps.Text = "ZeMaps";
            this.bZeMaps.UseVisualStyleBackColor = false;
            this.bZeMaps.Click += new System.EventHandler(this.bZeMaps_Click);
            // 
            // bAssembly
            // 
            this.bAssembly.BackColor = System.Drawing.Color.GreenYellow;
            this.bAssembly.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAssembly.Location = new System.Drawing.Point(240, 133);
            this.bAssembly.Name = "bAssembly";
            this.bAssembly.Size = new System.Drawing.Size(148, 57);
            this.bAssembly.TabIndex = 3;
            this.bAssembly.Text = "Assembly";
            this.bAssembly.UseVisualStyleBackColor = false;
            this.bAssembly.Click += new System.EventHandler(this.bAssembly_Click);
            // 
            // Bblock
            // 
            this.Bblock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.Bblock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bblock.Location = new System.Drawing.Point(52, 133);
            this.Bblock.Name = "Bblock";
            this.Bblock.Size = new System.Drawing.Size(148, 57);
            this.Bblock.TabIndex = 4;
            this.Bblock.Text = "Block Customer";
            this.Bblock.UseVisualStyleBackColor = false;
            this.Bblock.Visible = false;
            this.Bblock.Click += new System.EventHandler(this.Bblock_Click);
            // 
            // Bunblock
            // 
            this.Bunblock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(100)))), ((int)(((byte)(205)))));
            this.Bunblock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bunblock.Location = new System.Drawing.Point(440, 133);
            this.Bunblock.Name = "Bunblock";
            this.Bunblock.Size = new System.Drawing.Size(148, 57);
            this.Bunblock.TabIndex = 5;
            this.Bunblock.Text = "Unblock Customer";
            this.Bunblock.UseVisualStyleBackColor = false;
            this.Bunblock.Visible = false;
            this.Bunblock.Click += new System.EventHandler(this.Bunblock_Click);
            // 
            // f1SelectProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Goldenrod;
            this.ClientSize = new System.Drawing.Size(644, 242);
            this.Controls.Add(this.Bunblock);
            this.Controls.Add(this.Bblock);
            this.Controls.Add(this.bAssembly);
            this.Controls.Add(this.bZeMaps);
            this.Controls.Add(this.bMPX);
            this.Controls.Add(this.bMetroPro);
            this.Name = "f1SelectProduct";
            this.ShowInTaskbar = false;
            this.Text = "f1 Select Product";
            this.Load += new System.EventHandler(this.f1SelectProduct_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bMetroPro;
        private System.Windows.Forms.Button bMPX;
        private System.Windows.Forms.Button bZeMaps;
        private System.Windows.Forms.Button bAssembly;
        private System.Windows.Forms.Button Bblock;
        private System.Windows.Forms.Button Bunblock;
    }
}

