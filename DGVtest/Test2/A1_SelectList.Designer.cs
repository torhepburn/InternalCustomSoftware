namespace Test2
{
    partial class A1_SelectList
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSearchPartNumber = new System.Windows.Forms.TextBox();
            this.bSearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.bExit = new System.Windows.Forms.Button();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.rbEdit = new System.Windows.Forms.RadioButton();
            this.rbCopy = new System.Windows.Forms.RadioButton();
            this.rbDelete = new System.Windows.Forms.RadioButton();
            this.rbCopyNew = new System.Windows.Forms.RadioButton();
            this.tbNewRev = new System.Windows.Forms.TextBox();
            this.tbNewNumber = new System.Windows.Forms.TextBox();
            this.LNewRev = new System.Windows.Forms.Label();
            this.LNewNumber = new System.Windows.Forms.Label();
            this.rbEditByLine = new System.Windows.Forms.RadioButton();
            this.bADDfromWord = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(227, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 20);
            this.label5.TabIndex = 38;
            this.label5.Text = "ENTRY BOX:";
            // 
            // tbSearchPartNumber
            // 
            this.tbSearchPartNumber.Location = new System.Drawing.Point(227, 211);
            this.tbSearchPartNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSearchPartNumber.Name = "tbSearchPartNumber";
            this.tbSearchPartNumber.Size = new System.Drawing.Size(215, 23);
            this.tbSearchPartNumber.TabIndex = 36;
            // 
            // bSearch
            // 
            this.bSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(195)))));
            this.bSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearch.Location = new System.Drawing.Point(105, 190);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(103, 62);
            this.bSearch.TabIndex = 35;
            this.bSearch.Text = "SEARCH PATTERN";
            this.bSearch.UseVisualStyleBackColor = false;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(52, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(648, 16);
            this.label4.TabIndex = 34;
            this.label4.Text = "CLICK ON THE PACKING LIST PART NUMBER TO GET THE LIST YOU WANT TO WORK ON.";
            // 
            // bExit
            // 
            this.bExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(195)))), ((int)(((byte)(150)))));
            this.bExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bExit.Location = new System.Drawing.Point(27, 552);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(31, 140);
            this.bExit.TabIndex = 33;
            this.bExit.Text = "EXIT";
            this.bExit.UseVisualStyleBackColor = false;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(84, 264);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.Size = new System.Drawing.Size(602, 350);
            this.DGV.TabIndex = 28;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 16);
            this.label1.TabIndex = 39;
            this.label1.Text = "SELECT WHAT YOU WANT TO DO.";
            // 
            // rbEdit
            // 
            this.rbEdit.AutoSize = true;
            this.rbEdit.Checked = true;
            this.rbEdit.Location = new System.Drawing.Point(55, 50);
            this.rbEdit.Name = "rbEdit";
            this.rbEdit.Size = new System.Drawing.Size(128, 21);
            this.rbEdit.TabIndex = 40;
            this.rbEdit.TabStop = true;
            this.rbEdit.Text = "Edit Existing List";
            this.rbEdit.UseVisualStyleBackColor = true;
            // 
            // rbCopy
            // 
            this.rbCopy.AutoSize = true;
            this.rbCopy.Location = new System.Drawing.Point(208, 50);
            this.rbCopy.Name = "rbCopy";
            this.rbCopy.Size = new System.Drawing.Size(148, 21);
            this.rbCopy.TabIndex = 41;
            this.rbCopy.Text = "Copy list to new rev";
            this.rbCopy.UseVisualStyleBackColor = true;
            this.rbCopy.CheckedChanged += new System.EventHandler(this.rbCopy_CheckedChanged);
            // 
            // rbDelete
            // 
            this.rbDelete.AutoSize = true;
            this.rbDelete.Location = new System.Drawing.Point(597, 50);
            this.rbDelete.Name = "rbDelete";
            this.rbDelete.Size = new System.Drawing.Size(93, 21);
            this.rbDelete.TabIndex = 42;
            this.rbDelete.Text = "Delete List";
            this.rbDelete.UseVisualStyleBackColor = true;
            this.rbDelete.CheckedChanged += new System.EventHandler(this.rbDelete_CheckedChanged);
            // 
            // rbCopyNew
            // 
            this.rbCopyNew.AutoSize = true;
            this.rbCopyNew.Location = new System.Drawing.Point(385, 50);
            this.rbCopyNew.Name = "rbCopyNew";
            this.rbCopyNew.Size = new System.Drawing.Size(181, 21);
            this.rbCopyNew.TabIndex = 43;
            this.rbCopyNew.Text = "Copy List to new number";
            this.rbCopyNew.UseVisualStyleBackColor = true;
            this.rbCopyNew.CheckedChanged += new System.EventHandler(this.rbCopyNew_CheckedChanged);
            // 
            // tbNewRev
            // 
            this.tbNewRev.Location = new System.Drawing.Point(220, 113);
            this.tbNewRev.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbNewRev.Name = "tbNewRev";
            this.tbNewRev.Size = new System.Drawing.Size(36, 23);
            this.tbNewRev.TabIndex = 44;
            this.tbNewRev.Visible = false;
            // 
            // tbNewNumber
            // 
            this.tbNewNumber.Location = new System.Drawing.Point(397, 113);
            this.tbNewNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbNewNumber.Name = "tbNewNumber";
            this.tbNewNumber.Size = new System.Drawing.Size(215, 23);
            this.tbNewNumber.TabIndex = 45;
            this.tbNewNumber.Visible = false;
            // 
            // LNewRev
            // 
            this.LNewRev.AutoSize = true;
            this.LNewRev.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LNewRev.Location = new System.Drawing.Point(137, 116);
            this.LNewRev.Name = "LNewRev";
            this.LNewRev.Size = new System.Drawing.Size(76, 20);
            this.LNewRev.TabIndex = 46;
            this.LNewRev.Text = "New Rev:";
            this.LNewRev.Visible = false;
            // 
            // LNewNumber
            // 
            this.LNewNumber.AutoSize = true;
            this.LNewNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LNewNumber.Location = new System.Drawing.Point(285, 116);
            this.LNewNumber.Name = "LNewNumber";
            this.LNewNumber.Size = new System.Drawing.Size(104, 20);
            this.LNewNumber.TabIndex = 47;
            this.LNewNumber.Text = "New Number:";
            this.LNewNumber.Visible = false;
            // 
            // rbEditByLine
            // 
            this.rbEditByLine.AutoSize = true;
            this.rbEditByLine.Location = new System.Drawing.Point(55, 75);
            this.rbEditByLine.Name = "rbEditByLine";
            this.rbEditByLine.Size = new System.Drawing.Size(209, 21);
            this.rbEditByLine.TabIndex = 48;
            this.rbEditByLine.Text = "Edit Existing List Line by Line";
            this.rbEditByLine.UseVisualStyleBackColor = true;
            // 
            // bADDfromWord
            // 
            this.bADDfromWord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(195)))));
            this.bADDfromWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bADDfromWord.Location = new System.Drawing.Point(406, 9);
            this.bADDfromWord.Name = "bADDfromWord";
            this.bADDfromWord.Size = new System.Drawing.Size(200, 35);
            this.bADDfromWord.TabIndex = 49;
            this.bADDfromWord.Text = "Add from Word";
            this.toolTip1.SetToolTip(this.bADDfromWord, "File name needs to be saved in A drive \r\nwith rev number.  \r\n\r\nExample: PL6317-03" +
        "01-03A");
            this.bADDfromWord.UseVisualStyleBackColor = false;
            this.bADDfromWord.Click += new System.EventHandler(this.bADDfromWord_Click);
            // 
            // A1_SelectList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.ClientSize = new System.Drawing.Size(763, 704);
            this.Controls.Add(this.bADDfromWord);
            this.Controls.Add(this.rbEditByLine);
            this.Controls.Add(this.LNewNumber);
            this.Controls.Add(this.LNewRev);
            this.Controls.Add(this.tbNewNumber);
            this.Controls.Add(this.tbNewRev);
            this.Controls.Add(this.rbCopyNew);
            this.Controls.Add(this.rbDelete);
            this.Controls.Add(this.rbCopy);
            this.Controls.Add(this.rbEdit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbSearchPartNumber);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.DGV);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "A1_SelectList";
            this.Text = "A1_SelectList";
            this.Load += new System.EventHandler(this.A1_SelectList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSearchPartNumber;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbEdit;
        private System.Windows.Forms.RadioButton rbCopy;
        private System.Windows.Forms.RadioButton rbDelete;
        private System.Windows.Forms.RadioButton rbCopyNew;
        private System.Windows.Forms.TextBox tbNewRev;
        private System.Windows.Forms.TextBox tbNewNumber;
        private System.Windows.Forms.Label LNewRev;
        private System.Windows.Forms.Label LNewNumber;
        private System.Windows.Forms.RadioButton rbEditByLine;
        private System.Windows.Forms.Button bADDfromWord;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}