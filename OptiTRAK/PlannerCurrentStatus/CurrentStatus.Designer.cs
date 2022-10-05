namespace PlannerCurrentStatus
{
    partial class CurrentStatus
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bSearch = new System.Windows.Forms.Button();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.tbCustomer = new System.Windows.Forms.TextBox();
            this.bPrint = new System.Windows.Forms.Button();
            this.tbProject = new System.Windows.Forms.TextBox();
            this.tbElement = new System.Windows.Forms.TextBox();
            this.Lcustomer = new System.Windows.Forms.Label();
            this.Lproject = new System.Windows.Forms.Label();
            this.Lelement = new System.Windows.Forms.Label();
            this.Lplanner = new System.Windows.Forms.Label();
            this.tbPlanner = new System.Windows.Forms.TextBox();
            this.bExplanatoryText = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // bSearch
            // 
            this.bSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearch.Location = new System.Drawing.Point(525, 12);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(195, 125);
            this.bSearch.TabIndex = 10;
            this.bSearch.Text = "SEARCH PATTERN";
            this.bSearch.UseVisualStyleBackColor = false;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.OrangeRed;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(36, 221);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersWidth = 20;
            this.DGV.Size = new System.Drawing.Size(958, 377);
            this.DGV.TabIndex = 9;
            // 
            // tbCustomer
            // 
            this.tbCustomer.Location = new System.Drawing.Point(270, 48);
            this.tbCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCustomer.Name = "tbCustomer";
            this.tbCustomer.Size = new System.Drawing.Size(203, 23);
            this.tbCustomer.TabIndex = 8;
            // 
            // bPrint
            // 
            this.bPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPrint.Location = new System.Drawing.Point(802, 12);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(195, 125);
            this.bPrint.TabIndex = 11;
            this.bPrint.Text = "PRINT";
            this.bPrint.UseVisualStyleBackColor = false;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // tbProject
            // 
            this.tbProject.Location = new System.Drawing.Point(270, 89);
            this.tbProject.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbProject.Name = "tbProject";
            this.tbProject.Size = new System.Drawing.Size(203, 23);
            this.tbProject.TabIndex = 12;
            // 
            // tbElement
            // 
            this.tbElement.Location = new System.Drawing.Point(270, 133);
            this.tbElement.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbElement.Name = "tbElement";
            this.tbElement.Size = new System.Drawing.Size(203, 23);
            this.tbElement.TabIndex = 14;
            // 
            // Lcustomer
            // 
            this.Lcustomer.AutoSize = true;
            this.Lcustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Lcustomer.Location = new System.Drawing.Point(91, 48);
            this.Lcustomer.Name = "Lcustomer";
            this.Lcustomer.Size = new System.Drawing.Size(138, 20);
            this.Lcustomer.TabIndex = 15;
            this.Lcustomer.Text = "Customer Pattern:";
            // 
            // Lproject
            // 
            this.Lproject.AutoSize = true;
            this.Lproject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Lproject.Location = new System.Drawing.Point(91, 92);
            this.Lproject.Name = "Lproject";
            this.Lproject.Size = new System.Drawing.Size(118, 20);
            this.Lproject.TabIndex = 16;
            this.Lproject.Text = "Project Pattern:";
            // 
            // Lelement
            // 
            this.Lelement.AutoSize = true;
            this.Lelement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Lelement.Location = new System.Drawing.Point(91, 133);
            this.Lelement.Name = "Lelement";
            this.Lelement.Size = new System.Drawing.Size(128, 20);
            this.Lelement.TabIndex = 17;
            this.Lelement.Text = "Element Pattern:";
            // 
            // Lplanner
            // 
            this.Lplanner.AutoSize = true;
            this.Lplanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Lplanner.Location = new System.Drawing.Point(91, 180);
            this.Lplanner.Name = "Lplanner";
            this.Lplanner.Size = new System.Drawing.Size(172, 20);
            this.Lplanner.TabIndex = 19;
            this.Lplanner.Text = "Planner Initials Pattern:";
            this.Lplanner.Click += new System.EventHandler(this.Lplanner_Click);
            // 
            // tbPlanner
            // 
            this.tbPlanner.Location = new System.Drawing.Point(270, 180);
            this.tbPlanner.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPlanner.Name = "tbPlanner";
            this.tbPlanner.Size = new System.Drawing.Size(203, 23);
            this.tbPlanner.TabIndex = 18;
            // 
            // bExplanatoryText
            // 
            this.bExplanatoryText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bExplanatoryText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bExplanatoryText.Location = new System.Drawing.Point(525, 156);
            this.bExplanatoryText.Name = "bExplanatoryText";
            this.bExplanatoryText.Size = new System.Drawing.Size(469, 47);
            this.bExplanatoryText.TabIndex = 20;
            this.bExplanatoryText.Text = "EXPLANATORY TEXT";
            this.bExplanatoryText.UseVisualStyleBackColor = false;
            this.bExplanatoryText.Click += new System.EventHandler(this.bExplanatoryText_Click);
            // 
            // CurrentStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(1021, 630);
            this.Controls.Add(this.bExplanatoryText);
            this.Controls.Add(this.Lplanner);
            this.Controls.Add(this.tbPlanner);
            this.Controls.Add(this.Lelement);
            this.Controls.Add(this.Lproject);
            this.Controls.Add(this.Lcustomer);
            this.Controls.Add(this.tbElement);
            this.Controls.Add(this.tbProject);
            this.Controls.Add(this.bPrint);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.tbCustomer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CurrentStatus";
            this.Text = "CurrentStatus";
            this.Load += new System.EventHandler(this.CurrentStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.TextBox tbCustomer;
        private System.Windows.Forms.Button bPrint;
        private System.Windows.Forms.TextBox tbProject;
        private System.Windows.Forms.TextBox tbElement;
        private System.Windows.Forms.Label Lcustomer;
        private System.Windows.Forms.Label Lproject;
        private System.Windows.Forms.Label Lelement;
        private System.Windows.Forms.Label Lplanner;
        private System.Windows.Forms.TextBox tbPlanner;
        private System.Windows.Forms.Button bExplanatoryText;
    }
}

