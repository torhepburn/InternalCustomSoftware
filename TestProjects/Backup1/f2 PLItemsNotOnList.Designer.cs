namespace PL1
{
    partial class f2_PLItemsNotOnList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DGV1 = new System.Windows.Forms.DataGridView();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.tbTrade = new System.Windows.Forms.TextBox();
            this.Lnotes = new System.Windows.Forms.Label();
            this.Ltrade = new System.Windows.Forms.Label();
            this.l = new System.Windows.Forms.Label();
            this.Ltext = new System.Windows.Forms.Label();
            this.Litem = new System.Windows.Forms.Label();
            this.bEnter = new System.Windows.Forms.Button();
            this.DGV2 = new System.Windows.Forms.DataGridView();
            this.LitemClass = new System.Windows.Forms.Label();
            this.Lclass = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bNewClass = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV1
            // 
            this.DGV1.AllowUserToAddRows = false;
            this.DGV1.AllowUserToDeleteRows = false;
            this.DGV1.AllowUserToResizeColumns = false;
            this.DGV1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.DGV1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV1.Location = new System.Drawing.Point(38, 58);
            this.DGV1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DGV1.Name = "DGV1";
            this.DGV1.ReadOnly = true;
            this.DGV1.RowHeadersWidth = 15;
            this.DGV1.Size = new System.Drawing.Size(273, 158);
            this.DGV1.TabIndex = 0;
            this.DGV1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV1_CellContentClick);
            // 
            // tbNotes
            // 
            this.tbNotes.Location = new System.Drawing.Point(594, 90);
            this.tbNotes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(100, 26);
            this.tbNotes.TabIndex = 1;
            // 
            // tbTrade
            // 
            this.tbTrade.Location = new System.Drawing.Point(594, 142);
            this.tbTrade.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbTrade.Name = "tbTrade";
            this.tbTrade.Size = new System.Drawing.Size(100, 26);
            this.tbTrade.TabIndex = 2;
            this.tbTrade.Text = "0.00";
            // 
            // Lnotes
            // 
            this.Lnotes.AutoSize = true;
            this.Lnotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lnotes.Location = new System.Drawing.Point(399, 92);
            this.Lnotes.Name = "Lnotes";
            this.Lnotes.Size = new System.Drawing.Size(110, 20);
            this.Lnotes.TabIndex = 3;
            this.Lnotes.Text = "Enter Notes:";
            // 
            // Ltrade
            // 
            this.Ltrade.AutoSize = true;
            this.Ltrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ltrade.Location = new System.Drawing.Point(399, 146);
            this.Ltrade.Name = "Ltrade";
            this.Ltrade.Size = new System.Drawing.Size(176, 20);
            this.Ltrade.TabIndex = 4;
            this.Ltrade.Text = "EnterTrade In Value:";
            // 
            // l
            // 
            this.l.AutoSize = true;
            this.l.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l.Location = new System.Drawing.Point(34, 21);
            this.l.Name = "l";
            this.l.Size = new System.Drawing.Size(212, 20);
            this.l.TabIndex = 5;
            this.l.Text = "Select Item for Price List:";
            // 
            // Ltext
            // 
            this.Ltext.AutoSize = true;
            this.Ltext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ltext.Location = new System.Drawing.Point(399, 42);
            this.Ltext.Name = "Ltext";
            this.Ltext.Size = new System.Drawing.Size(126, 20);
            this.Ltext.TabIndex = 6;
            this.Ltext.Text = "Selected Item:";
            // 
            // Litem
            // 
            this.Litem.AutoSize = true;
            this.Litem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Litem.Location = new System.Drawing.Point(590, 42);
            this.Litem.Name = "Litem";
            this.Litem.Size = new System.Drawing.Size(45, 20);
            this.Litem.TabIndex = 7;
            this.Litem.Text = "Item";
            // 
            // bEnter
            // 
            this.bEnter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(50)))));
            this.bEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bEnter.Location = new System.Drawing.Point(582, 299);
            this.bEnter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bEnter.Name = "bEnter";
            this.bEnter.Size = new System.Drawing.Size(130, 44);
            this.bEnter.TabIndex = 8;
            this.bEnter.Text = "Enter Data";
            this.bEnter.UseVisualStyleBackColor = false;
            this.bEnter.Click += new System.EventHandler(this.bEnter_Click);
            // 
            // DGV2
            // 
            this.DGV2.AllowUserToAddRows = false;
            this.DGV2.AllowUserToDeleteRows = false;
            this.DGV2.AllowUserToResizeColumns = false;
            this.DGV2.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.DGV2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV2.Location = new System.Drawing.Point(38, 299);
            this.DGV2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DGV2.Name = "DGV2";
            this.DGV2.ReadOnly = true;
            this.DGV2.RowHeadersWidth = 15;
            this.DGV2.Size = new System.Drawing.Size(511, 166);
            this.DGV2.TabIndex = 9;
            this.DGV2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV2_CellContentClick);
            // 
            // LitemClass
            // 
            this.LitemClass.AutoSize = true;
            this.LitemClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LitemClass.Location = new System.Drawing.Point(34, 258);
            this.LitemClass.Name = "LitemClass";
            this.LitemClass.Size = new System.Drawing.Size(155, 20);
            this.LitemClass.TabIndex = 10;
            this.LitemClass.Text = "Select Item Class:";
            // 
            // Lclass
            // 
            this.Lclass.AutoSize = true;
            this.Lclass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lclass.Location = new System.Drawing.Point(590, 212);
            this.Lclass.Name = "Lclass";
            this.Lclass.Size = new System.Drawing.Size(53, 20);
            this.Lclass.TabIndex = 12;
            this.Lclass.Text = "Class";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(399, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Selected Item Class:";
            // 
            // bNewClass
            // 
            this.bNewClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(50)))));
            this.bNewClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bNewClass.Location = new System.Drawing.Point(136, 484);
            this.bNewClass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bNewClass.Name = "bNewClass";
            this.bNewClass.Size = new System.Drawing.Size(318, 36);
            this.bNewClass.TabIndex = 13;
            this.bNewClass.Text = "Class Not Found - Need New Class";
            this.bNewClass.UseVisualStyleBackColor = false;
            this.bNewClass.Click += new System.EventHandler(this.bNewClass_Click);
            // 
            // f2_PLItemsNotOnList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(80)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(770, 546);
            this.Controls.Add(this.bNewClass);
            this.Controls.Add(this.Lclass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LitemClass);
            this.Controls.Add(this.DGV2);
            this.Controls.Add(this.bEnter);
            this.Controls.Add(this.Litem);
            this.Controls.Add(this.Ltext);
            this.Controls.Add(this.l);
            this.Controls.Add(this.Ltrade);
            this.Controls.Add(this.Lnotes);
            this.Controls.Add(this.tbTrade);
            this.Controls.Add(this.tbNotes);
            this.Controls.Add(this.DGV1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "f2_PLItemsNotOnList";
            this.Text = "f2_PLItemsNotOnList";
            this.Load += new System.EventHandler(this.f2_PLItemsNotOnList_Load);
            this.Activated += new System.EventHandler(this.f2_PLItemsNotOnList_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV1;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.TextBox tbTrade;
        private System.Windows.Forms.Label Lnotes;
        private System.Windows.Forms.Label Ltrade;
        private System.Windows.Forms.Label l;
        private System.Windows.Forms.Label Ltext;
        private System.Windows.Forms.Label Litem;
        private System.Windows.Forms.Button bEnter;
        private System.Windows.Forms.DataGridView DGV2;
        private System.Windows.Forms.Label LitemClass;
        private System.Windows.Forms.Label Lclass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bNewClass;
    }
}