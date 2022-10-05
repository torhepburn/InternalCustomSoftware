namespace Tools
{
    partial class F44_Copy_Setup_Machine2Machine
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
            this.cbddSetupSheet = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bEnterData = new System.Windows.Forms.Button();
            this.cbddMachine = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbddSetupSheet
            // 
            this.cbddSetupSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbddSetupSheet.FormattingEnabled = true;
            this.cbddSetupSheet.Location = new System.Drawing.Point(198, 49);
            this.cbddSetupSheet.Name = "cbddSetupSheet";
            this.cbddSetupSheet.Size = new System.Drawing.Size(653, 28);
            this.cbddSetupSheet.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Setup Sheet:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select Machine to copy to:";
            // 
            // bEnterData
            // 
            this.bEnterData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.bEnterData.Location = new System.Drawing.Point(441, 135);
            this.bEnterData.Name = "bEnterData";
            this.bEnterData.Size = new System.Drawing.Size(410, 66);
            this.bEnterData.TabIndex = 4;
            this.bEnterData.Text = "ENTER DATA";
            this.bEnterData.UseVisualStyleBackColor = false;
            this.bEnterData.Click += new System.EventHandler(this.bEnterData_Click);
            // 
            // cbddMachine
            // 
            this.cbddMachine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbddMachine.FormattingEnabled = true;
            this.cbddMachine.Location = new System.Drawing.Point(266, 135);
            this.cbddMachine.Name = "cbddMachine";
            this.cbddMachine.Size = new System.Drawing.Size(139, 28);
            this.cbddMachine.TabIndex = 5;
            // 
            // F44_Copy_Setup_Machine2Machine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(884, 235);
            this.Controls.Add(this.cbddMachine);
            this.Controls.Add(this.bEnterData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbddSetupSheet);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F44_Copy_Setup_Machine2Machine";
            this.Text = "F44 Copy Setup from one Machine to Another";
            this.Load += new System.EventHandler(this.F44_Copy_Setup_Machine2Machine_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbddSetupSheet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bEnterData;
        private System.Windows.Forms.ComboBox cbddMachine;
    }
}