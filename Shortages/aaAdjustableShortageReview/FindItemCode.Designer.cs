namespace aaAdjustableShortageReview
{
    partial class FindItemCode
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
            this.DGV = new System.Windows.Forms.DataGridView();
            this.bSearch = new System.Windows.Forms.Button();
            this.bItem = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.bINST = new System.Windows.Forms.Button();
            this.bPPS = new System.Windows.Forms.Button();
            this.bOPTICS = new System.Windows.Forms.Button();
            this.bAdd = new System.Windows.Forms.Button();
            this.bZEOS = new System.Windows.Forms.Button();
            this.Bzeosreport = new System.Windows.Forms.Button();
            this.Bopticsreport = new System.Windows.Forms.Button();
            this.Bppsreport = new System.Windows.Forms.Button();
            this.Binstreport = new System.Windows.Forms.Button();
            this.bSERreport = new System.Windows.Forms.Button();
            this.bWarRoom = new System.Windows.Forms.Button();
            this.bEPO = new System.Windows.Forms.Button();
            this.bEPOreport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(69, 420);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersVisible = false;
            this.DGV.Size = new System.Drawing.Size(330, 244);
            this.DGV.TabIndex = 0;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // bSearch
            // 
            this.bSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.bSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearch.Location = new System.Drawing.Point(26, 331);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(103, 68);
            this.bSearch.TabIndex = 6;
            this.bSearch.Text = "SEARCH PART NUMBER";
            this.bSearch.UseVisualStyleBackColor = false;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // bItem
            // 
            this.bItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(220)))), ((int)(((byte)(140)))));
            this.bItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bItem.Location = new System.Drawing.Point(348, 346);
            this.bItem.Name = "bItem";
            this.bItem.Size = new System.Drawing.Size(103, 53);
            this.bItem.TabIndex = 5;
            this.bItem.Text = "GET ID";
            this.bItem.UseVisualStyleBackColor = false;
            this.bItem.Click += new System.EventHandler(this.bItem_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(143, 359);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(192, 23);
            this.tbSearch.TabIndex = 4;
            // 
            // bINST
            // 
            this.bINST.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(225)))), ((int)(((byte)(128)))));
            this.bINST.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bINST.Location = new System.Drawing.Point(31, 57);
            this.bINST.Name = "bINST";
            this.bINST.Size = new System.Drawing.Size(103, 88);
            this.bINST.TabIndex = 7;
            this.bINST.Text = "INST MEETING";
            this.bINST.UseVisualStyleBackColor = false;
            this.bINST.Click += new System.EventHandler(this.bINST_Click);
            // 
            // bPPS
            // 
            this.bPPS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(120)))));
            this.bPPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPPS.Location = new System.Drawing.Point(185, 57);
            this.bPPS.Name = "bPPS";
            this.bPPS.Size = new System.Drawing.Size(103, 88);
            this.bPPS.TabIndex = 8;
            this.bPPS.Text = "PPS MEETING";
            this.bPPS.UseVisualStyleBackColor = false;
            this.bPPS.Click += new System.EventHandler(this.bPPS_Click);
            // 
            // bOPTICS
            // 
            this.bOPTICS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(225)))));
            this.bOPTICS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bOPTICS.Location = new System.Drawing.Point(338, 57);
            this.bOPTICS.Name = "bOPTICS";
            this.bOPTICS.Size = new System.Drawing.Size(103, 88);
            this.bOPTICS.TabIndex = 9;
            this.bOPTICS.Text = "OPTICS MEETING";
            this.bOPTICS.UseVisualStyleBackColor = false;
            this.bOPTICS.Click += new System.EventHandler(this.bOPTICS_Click);
            // 
            // bAdd
            // 
            this.bAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(20)))));
            this.bAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAdd.Location = new System.Drawing.Point(493, 346);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(103, 88);
            this.bAdd.TabIndex = 10;
            this.bAdd.Text = "ADD SHORTAGE";
            this.bAdd.UseVisualStyleBackColor = false;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bZEOS
            // 
            this.bZEOS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(225)))));
            this.bZEOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bZEOS.Location = new System.Drawing.Point(493, 57);
            this.bZEOS.Name = "bZEOS";
            this.bZEOS.Size = new System.Drawing.Size(103, 88);
            this.bZEOS.TabIndex = 11;
            this.bZEOS.Text = "IRVINE MEETING";
            this.bZEOS.UseVisualStyleBackColor = false;
            this.bZEOS.Click += new System.EventHandler(this.bZEOS_Click);
            // 
            // Bzeosreport
            // 
            this.Bzeosreport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(225)))));
            this.Bzeosreport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bzeosreport.Location = new System.Drawing.Point(493, 194);
            this.Bzeosreport.Name = "Bzeosreport";
            this.Bzeosreport.Size = new System.Drawing.Size(103, 88);
            this.Bzeosreport.TabIndex = 15;
            this.Bzeosreport.Text = "PRINT IRVINE REPORT";
            this.Bzeosreport.UseVisualStyleBackColor = false;
            this.Bzeosreport.Click += new System.EventHandler(this.Bzeosreport_Click);
            // 
            // Bopticsreport
            // 
            this.Bopticsreport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(225)))));
            this.Bopticsreport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bopticsreport.Location = new System.Drawing.Point(338, 194);
            this.Bopticsreport.Name = "Bopticsreport";
            this.Bopticsreport.Size = new System.Drawing.Size(103, 88);
            this.Bopticsreport.TabIndex = 14;
            this.Bopticsreport.Text = "PRINT OPTICS REPORT";
            this.Bopticsreport.UseVisualStyleBackColor = false;
            this.Bopticsreport.Click += new System.EventHandler(this.Bopticsreport_Click);
            // 
            // Bppsreport
            // 
            this.Bppsreport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(120)))));
            this.Bppsreport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bppsreport.Location = new System.Drawing.Point(185, 194);
            this.Bppsreport.Name = "Bppsreport";
            this.Bppsreport.Size = new System.Drawing.Size(103, 88);
            this.Bppsreport.TabIndex = 13;
            this.Bppsreport.Text = "PRINT PPS REPORT";
            this.Bppsreport.UseVisualStyleBackColor = false;
            this.Bppsreport.Click += new System.EventHandler(this.Bppsreport_Click);
            // 
            // Binstreport
            // 
            this.Binstreport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(225)))), ((int)(((byte)(128)))));
            this.Binstreport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Binstreport.Location = new System.Drawing.Point(31, 194);
            this.Binstreport.Name = "Binstreport";
            this.Binstreport.Size = new System.Drawing.Size(103, 88);
            this.Binstreport.TabIndex = 12;
            this.Binstreport.Text = "PRINT INST REPORT";
            this.Binstreport.UseVisualStyleBackColor = false;
            this.Binstreport.Click += new System.EventHandler(this.Binstreport_Click);
            // 
            // bSERreport
            // 
            this.bSERreport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(120)))), ((int)(((byte)(125)))));
            this.bSERreport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSERreport.Location = new System.Drawing.Point(641, 194);
            this.bSERreport.Name = "bSERreport";
            this.bSERreport.Size = new System.Drawing.Size(103, 88);
            this.bSERreport.TabIndex = 16;
            this.bSERreport.Text = "PRINT WARROOM REPORT";
            this.bSERreport.UseVisualStyleBackColor = false;
            this.bSERreport.Click += new System.EventHandler(this.bSERreport_Click);
            // 
            // bWarRoom
            // 
            this.bWarRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(120)))), ((int)(((byte)(125)))));
            this.bWarRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bWarRoom.Location = new System.Drawing.Point(641, 57);
            this.bWarRoom.Name = "bWarRoom";
            this.bWarRoom.Size = new System.Drawing.Size(103, 88);
            this.bWarRoom.TabIndex = 17;
            this.bWarRoom.Text = "WAR ROOM";
            this.bWarRoom.UseVisualStyleBackColor = false;
            this.bWarRoom.Click += new System.EventHandler(this.bWarRoom_Click);
            // 
            // bEPO
            // 
            this.bEPO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(100)))), ((int)(((byte)(215)))));
            this.bEPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bEPO.Location = new System.Drawing.Point(790, 57);
            this.bEPO.Name = "bEPO";
            this.bEPO.Size = new System.Drawing.Size(103, 88);
            this.bEPO.TabIndex = 19;
            this.bEPO.Text = "EPO MEETING";
            this.bEPO.UseVisualStyleBackColor = false;
            this.bEPO.Click += new System.EventHandler(this.bEPO_Click);
            // 
            // bEPOreport
            // 
            this.bEPOreport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(100)))), ((int)(((byte)(215)))));
            this.bEPOreport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bEPOreport.Location = new System.Drawing.Point(790, 194);
            this.bEPOreport.Name = "bEPOreport";
            this.bEPOreport.Size = new System.Drawing.Size(103, 88);
            this.bEPOreport.TabIndex = 18;
            this.bEPOreport.Text = "PRINT EPO REPORT";
            this.bEPOreport.UseVisualStyleBackColor = false;
            this.bEPOreport.Click += new System.EventHandler(this.bEPOreport_Click);
            // 
            // FindItemCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(160)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(925, 691);
            this.Controls.Add(this.bEPO);
            this.Controls.Add(this.bEPOreport);
            this.Controls.Add(this.bWarRoom);
            this.Controls.Add(this.bSERreport);
            this.Controls.Add(this.Bzeosreport);
            this.Controls.Add(this.Bopticsreport);
            this.Controls.Add(this.Bppsreport);
            this.Controls.Add(this.Binstreport);
            this.Controls.Add(this.bZEOS);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.bOPTICS);
            this.Controls.Add(this.bPPS);
            this.Controls.Add(this.bINST);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.bItem);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.DGV);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FindItemCode";
            this.Text = "FindItemCode";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FindItemCode_FormClosed);
            this.Load += new System.EventHandler(this.FindItemCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.Button bItem;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button bINST;
        private System.Windows.Forms.Button bPPS;
        private System.Windows.Forms.Button bOPTICS;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button bZEOS;
        private System.Windows.Forms.Button Bzeosreport;
        private System.Windows.Forms.Button Bopticsreport;
        private System.Windows.Forms.Button Bppsreport;
        private System.Windows.Forms.Button Binstreport;
        private System.Windows.Forms.Button bSERreport;
        private System.Windows.Forms.Button bWarRoom;
        private System.Windows.Forms.Button bEPO;
        private System.Windows.Forms.Button bEPOreport;
    }
}