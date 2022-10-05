namespace Tools
{
    partial class F42_Edit_Setup_Sheet_Tools
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
            this.tbMachine = new System.Windows.Forms.TextBox();
            this.bSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPosition = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSN = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMinUsable = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbMinDiamond = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbHolder = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbMachine
            // 
            this.tbMachine.Location = new System.Drawing.Point(192, 41);
            this.tbMachine.Name = "tbMachine";
            this.tbMachine.Size = new System.Drawing.Size(100, 24);
            this.tbMachine.TabIndex = 0;
            // 
            // bSave
            // 
            this.bSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(0)))));
            this.bSave.Location = new System.Drawing.Point(93, 423);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(236, 48);
            this.bSave.TabIndex = 7;
            this.bSave.Text = "SAVE / ENTER DATA";
            this.bSave.UseVisualStyleBackColor = false;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Machine";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Position";
            // 
            // tbPosition
            // 
            this.tbPosition.Location = new System.Drawing.Point(192, 93);
            this.tbPosition.Name = "tbPosition";
            this.tbPosition.Size = new System.Drawing.Size(100, 24);
            this.tbPosition.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Serial Number";
            // 
            // tbSN
            // 
            this.tbSN.Location = new System.Drawing.Point(192, 145);
            this.tbSN.Name = "tbSN";
            this.tbSN.Size = new System.Drawing.Size(100, 24);
            this.tbSN.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Min Usable Length";
            // 
            // tbMinUsable
            // 
            this.tbMinUsable.Location = new System.Drawing.Point(192, 194);
            this.tbMinUsable.Name = "tbMinUsable";
            this.tbMinUsable.Size = new System.Drawing.Size(100, 24);
            this.tbMinUsable.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Min Diamond Length";
            // 
            // tbMinDiamond
            // 
            this.tbMinDiamond.Location = new System.Drawing.Point(192, 251);
            this.tbMinDiamond.Name = "tbMinDiamond";
            this.tbMinDiamond.Size = new System.Drawing.Size(100, 24);
            this.tbMinDiamond.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 305);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 18);
            this.label6.TabIndex = 12;
            this.label6.Text = "Holder n Nut Size";
            // 
            // tbHolder
            // 
            this.tbHolder.Location = new System.Drawing.Point(192, 302);
            this.tbHolder.Name = "tbHolder";
            this.tbHolder.Size = new System.Drawing.Size(100, 24);
            this.tbHolder.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 361);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 18);
            this.label7.TabIndex = 14;
            this.label7.Text = "Part Name";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(192, 358);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(210, 24);
            this.tbName.TabIndex = 6;
            // 
            // F42_Edit_Setup_Sheet_Tools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(426, 483);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbHolder);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbMinDiamond);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbMinUsable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbSN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPosition);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.tbMachine);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "F42_Edit_Setup_Sheet_Tools";
            this.Text = "F42 Edit Setup Sheet Tools";
            this.Load += new System.EventHandler(this.F42_Edit_Setup_Sheet_Tools_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMachine;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPosition;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbMinUsable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbMinDiamond;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbHolder;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbName;
    }
}