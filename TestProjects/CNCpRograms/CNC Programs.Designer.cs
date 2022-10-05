namespace CNCpRograms
{
    partial class CNC_Programs
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
            this.LB1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPart = new System.Windows.Forms.TextBox();
            this.bAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bCompany = new System.Windows.Forms.Button();
            this.tbCompany = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LB1
            // 
            this.LB1.AllowDrop = true;
            this.LB1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.LB1.FormattingEnabled = true;
            this.LB1.ItemHeight = 20;
            this.LB1.Location = new System.Drawing.Point(51, 40);
            this.LB1.Name = "LB1";
            this.LB1.Size = new System.Drawing.Size(231, 124);
            this.LB1.Sorted = true;
            this.LB1.TabIndex = 0;
            this.LB1.SelectedIndexChanged += new System.EventHandler(this.LB1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(180)))), ((int)(((byte)(150)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "No Company Selected";
            // 
            // tbPart
            // 
            this.tbPart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tbPart.Location = new System.Drawing.Point(51, 314);
            this.tbPart.Name = "tbPart";
            this.tbPart.Size = new System.Drawing.Size(231, 26);
            this.tbPart.TabIndex = 2;
            // 
            // bAdd
            // 
            this.bAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.bAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAdd.Location = new System.Drawing.Point(59, 361);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(216, 51);
            this.bAdd.TabIndex = 3;
            this.bAdd.Text = "Add Part";
            this.bAdd.UseVisualStyleBackColor = false;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(180)))), ((int)(((byte)(150)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Company Selected:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(180)))), ((int)(((byte)(250)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(55, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Part to be added:";
            // 
            // bCompany
            // 
            this.bCompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.bCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCompany.Location = new System.Drawing.Point(59, 436);
            this.bCompany.Name = "bCompany";
            this.bCompany.Size = new System.Drawing.Size(216, 51);
            this.bCompany.TabIndex = 6;
            this.bCompany.Text = "Add Company";
            this.bCompany.UseVisualStyleBackColor = false;
            this.bCompany.Click += new System.EventHandler(this.bCompany_Click);
            // 
            // tbCompany
            // 
            this.tbCompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.tbCompany.Location = new System.Drawing.Point(51, 513);
            this.tbCompany.Name = "tbCompany";
            this.tbCompany.Size = new System.Drawing.Size(231, 26);
            this.tbCompany.TabIndex = 7;
            // 
            // CNC_Programs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.ClientSize = new System.Drawing.Size(346, 576);
            this.Controls.Add(this.tbCompany);
            this.Controls.Add(this.bCompany);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.tbPart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LB1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CNC_Programs";
            this.Text = "CNC Programs";
            this.Load += new System.EventHandler(this.CNC_Programs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LB1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPart;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bCompany;
        private System.Windows.Forms.TextBox tbCompany;
    }
}

