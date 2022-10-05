
namespace PrinterManager
{
    partial class EditData
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
            this.tbComputer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbApplication = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPrinter = new System.Windows.Forms.TextBox();
            this.bSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbLocation = new System.Windows.Forms.TextBox();
            this.cbZPL = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbComputer
            // 
            this.tbComputer.Location = new System.Drawing.Point(168, 40);
            this.tbComputer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbComputer.Name = "tbComputer";
            this.tbComputer.Size = new System.Drawing.Size(265, 26);
            this.tbComputer.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(42, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "Computer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(42, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 33;
            this.label2.Text = "Log In";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(168, 99);
            this.tbLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(265, 26);
            this.tbLogin.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(42, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "Application";
            // 
            // tbApplication
            // 
            this.tbApplication.Location = new System.Drawing.Point(168, 159);
            this.tbApplication.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbApplication.Name = "tbApplication";
            this.tbApplication.Size = new System.Drawing.Size(265, 26);
            this.tbApplication.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(42, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.TabIndex = 37;
            this.label4.Text = "Printer";
            // 
            // tbPrinter
            // 
            this.tbPrinter.Location = new System.Drawing.Point(168, 224);
            this.tbPrinter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPrinter.Name = "tbPrinter";
            this.tbPrinter.Size = new System.Drawing.Size(265, 26);
            this.tbPrinter.TabIndex = 36;
            // 
            // bSave
            // 
            this.bSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.bSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.bSave.Location = new System.Drawing.Point(71, 412);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(336, 62);
            this.bSave.TabIndex = 38;
            this.bSave.Text = "SAVE TEXT  ENTRIES";
            this.bSave.UseVisualStyleBackColor = false;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(42, 293);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.TabIndex = 40;
            this.label5.Text = "Location";
            // 
            // tbLocation
            // 
            this.tbLocation.Location = new System.Drawing.Point(168, 290);
            this.tbLocation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.Size = new System.Drawing.Size(265, 26);
            this.tbLocation.TabIndex = 39;
            // 
            // cbZPL
            // 
            this.cbZPL.AutoSize = true;
            this.cbZPL.Location = new System.Drawing.Point(253, 355);
            this.cbZPL.Name = "cbZPL";
            this.cbZPL.Size = new System.Drawing.Size(57, 24);
            this.cbZPL.TabIndex = 42;
            this.cbZPL.Text = "ZPL";
            this.cbZPL.UseVisualStyleBackColor = true;
            this.cbZPL.CheckedChanged += new System.EventHandler(this.cbZLP_CheckedChanged);
            // 
            // EditData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(225)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(496, 512);
            this.Controls.Add(this.cbZPL);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbLocation);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbPrinter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbApplication);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbComputer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EditData";
            this.Text = "EditData";
            this.Load += new System.EventHandler(this.EditData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbComputer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbApplication;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPrinter;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbLocation;
        private System.Windows.Forms.CheckBox cbZPL;
    }
}