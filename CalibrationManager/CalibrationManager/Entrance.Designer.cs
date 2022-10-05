namespace CalibrationManager
{
    partial class Entrance
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
            this.bMiddlefield = new System.Windows.Forms.Button();
            this.bTucson = new System.Windows.Forms.Button();
            this.bCostaMesa = new System.Windows.Forms.Button();
            this.bRichmond = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bMiddlefield
            // 
            this.bMiddlefield.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(240)))));
            this.bMiddlefield.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bMiddlefield.Location = new System.Drawing.Point(48, 67);
            this.bMiddlefield.Name = "bMiddlefield";
            this.bMiddlefield.Size = new System.Drawing.Size(147, 93);
            this.bMiddlefield.TabIndex = 0;
            this.bMiddlefield.Text = "Middlefield";
            this.bMiddlefield.UseVisualStyleBackColor = false;
            this.bMiddlefield.Click += new System.EventHandler(this.bMiddlefield_Click);
            // 
            // bTucson
            // 
            this.bTucson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(240)))));
            this.bTucson.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bTucson.Location = new System.Drawing.Point(48, 209);
            this.bTucson.Name = "bTucson";
            this.bTucson.Size = new System.Drawing.Size(147, 93);
            this.bTucson.TabIndex = 1;
            this.bTucson.Text = "Tucson";
            this.bTucson.UseVisualStyleBackColor = false;
            this.bTucson.Visible = false;
            this.bTucson.Click += new System.EventHandler(this.bTucson_Click);
            // 
            // bCostaMesa
            // 
            this.bCostaMesa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(240)))));
            this.bCostaMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCostaMesa.Location = new System.Drawing.Point(239, 67);
            this.bCostaMesa.Name = "bCostaMesa";
            this.bCostaMesa.Size = new System.Drawing.Size(147, 93);
            this.bCostaMesa.TabIndex = 2;
            this.bCostaMesa.Text = "Irvine";
            this.bCostaMesa.UseVisualStyleBackColor = false;
            this.bCostaMesa.Click += new System.EventHandler(this.bCostaMesa_Click);
            // 
            // bRichmond
            // 
            this.bRichmond.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(240)))));
            this.bRichmond.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bRichmond.Location = new System.Drawing.Point(239, 209);
            this.bRichmond.Name = "bRichmond";
            this.bRichmond.Size = new System.Drawing.Size(147, 93);
            this.bRichmond.TabIndex = 3;
            this.bRichmond.Text = "Richmond";
            this.bRichmond.UseVisualStyleBackColor = false;
            this.bRichmond.Click += new System.EventHandler(this.bRichmond_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(137, 376);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 93);
            this.button1.TabIndex = 4;
            this.button1.Text = "EXIT";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Entrance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(200)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(438, 499);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bRichmond);
            this.Controls.Add(this.bCostaMesa);
            this.Controls.Add(this.bTucson);
            this.Controls.Add(this.bMiddlefield);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Entrance";
            this.Text = "Entrance";
            this.Load += new System.EventHandler(this.Entrance_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bMiddlefield;
        private System.Windows.Forms.Button bTucson;
        private System.Windows.Forms.Button bCostaMesa;
        private System.Windows.Forms.Button bRichmond;
        private System.Windows.Forms.Button button1;
    }
}