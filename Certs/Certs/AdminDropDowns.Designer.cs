
namespace Certs
{
    partial class AdminDropDowns
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
            this.bFound = new System.Windows.Forms.Button();
            this.bTestType = new System.Windows.Forms.Button();
            this.bProcedure = new System.Windows.Forms.Button();
            this.bResults = new System.Windows.Forms.Button();
            this.bRefStandards = new System.Windows.Forms.Button();
            this.bLeft = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bFound
            // 
            this.bFound.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(200)))), ((int)(((byte)(80)))));
            this.bFound.Location = new System.Drawing.Point(48, 43);
            this.bFound.Name = "bFound";
            this.bFound.Size = new System.Drawing.Size(160, 58);
            this.bFound.TabIndex = 1;
            this.bFound.Text = "As Found Condition";
            this.bFound.UseVisualStyleBackColor = false;
            this.bFound.Click += new System.EventHandler(this.bFound_Click);
            // 
            // bTestType
            // 
            this.bTestType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(200)))), ((int)(((byte)(80)))));
            this.bTestType.Location = new System.Drawing.Point(48, 466);
            this.bTestType.Name = "bTestType";
            this.bTestType.Size = new System.Drawing.Size(160, 58);
            this.bTestType.TabIndex = 2;
            this.bTestType.Text = "Test Type";
            this.bTestType.UseVisualStyleBackColor = false;
            this.bTestType.Click += new System.EventHandler(this.bTestType_Click);
            // 
            // bProcedure
            // 
            this.bProcedure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(200)))), ((int)(((byte)(80)))));
            this.bProcedure.Location = new System.Drawing.Point(48, 240);
            this.bProcedure.Name = "bProcedure";
            this.bProcedure.Size = new System.Drawing.Size(160, 58);
            this.bProcedure.TabIndex = 3;
            this.bProcedure.Text = "Calibration Procedure";
            this.bProcedure.UseVisualStyleBackColor = false;
            this.bProcedure.Click += new System.EventHandler(this.bProcedure_Click);
            // 
            // bResults
            // 
            this.bResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(200)))), ((int)(((byte)(80)))));
            this.bResults.Location = new System.Drawing.Point(48, 352);
            this.bResults.Name = "bResults";
            this.bResults.Size = new System.Drawing.Size(160, 58);
            this.bResults.TabIndex = 4;
            this.bResults.Text = "Certified Results";
            this.bResults.UseVisualStyleBackColor = false;
            this.bResults.Click += new System.EventHandler(this.bResults_Click);
            // 
            // bRefStandards
            // 
            this.bRefStandards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(200)))), ((int)(((byte)(80)))));
            this.bRefStandards.Location = new System.Drawing.Point(48, 574);
            this.bRefStandards.Name = "bRefStandards";
            this.bRefStandards.Size = new System.Drawing.Size(160, 58);
            this.bRefStandards.TabIndex = 5;
            this.bRefStandards.Text = "Reference Standards";
            this.bRefStandards.UseVisualStyleBackColor = false;
            this.bRefStandards.Click += new System.EventHandler(this.bRefStandards_Click);
            // 
            // bLeft
            // 
            this.bLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(200)))), ((int)(((byte)(80)))));
            this.bLeft.Location = new System.Drawing.Point(48, 137);
            this.bLeft.Name = "bLeft";
            this.bLeft.Size = new System.Drawing.Size(160, 58);
            this.bLeft.TabIndex = 6;
            this.bLeft.Text = "As Left Condition";
            this.bLeft.UseVisualStyleBackColor = false;
            this.bLeft.Click += new System.EventHandler(this.bLeft_Click);
            // 
            // AdminDropDowns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(25)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(264, 683);
            this.Controls.Add(this.bLeft);
            this.Controls.Add(this.bRefStandards);
            this.Controls.Add(this.bResults);
            this.Controls.Add(this.bProcedure);
            this.Controls.Add(this.bTestType);
            this.Controls.Add(this.bFound);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AdminDropDowns";
            this.Text = "AdminDropDowns";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bFound;
        private System.Windows.Forms.Button bTestType;
        private System.Windows.Forms.Button bProcedure;
        private System.Windows.Forms.Button bResults;
        private System.Windows.Forms.Button bRefStandards;
        private System.Windows.Forms.Button bLeft;
    }
}