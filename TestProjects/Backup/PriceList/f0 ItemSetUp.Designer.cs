namespace PriceList
{
    partial class f0_ItemSetUp
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
            this.bViewPriceListItems = new System.Windows.Forms.Button();
            this.bEditPLitems = new System.Windows.Forms.Button();
            this.bEditItemClasses = new System.Windows.Forms.Button();
            this.bViewItemClasses = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bViewPriceListItems
            // 
            this.bViewPriceListItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(105)))), ((int)(((byte)(210)))));
            this.bViewPriceListItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bViewPriceListItems.Location = new System.Drawing.Point(32, 64);
            this.bViewPriceListItems.Name = "bViewPriceListItems";
            this.bViewPriceListItems.Size = new System.Drawing.Size(158, 57);
            this.bViewPriceListItems.TabIndex = 0;
            this.bViewPriceListItems.Text = "View Price List Items";
            this.bViewPriceListItems.UseVisualStyleBackColor = false;
            this.bViewPriceListItems.Click += new System.EventHandler(this.bViewPriceListItems_Click);
            // 
            // bEditPLitems
            // 
            this.bEditPLitems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(105)))), ((int)(((byte)(210)))));
            this.bEditPLitems.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bEditPLitems.Location = new System.Drawing.Point(253, 64);
            this.bEditPLitems.Name = "bEditPLitems";
            this.bEditPLitems.Size = new System.Drawing.Size(158, 57);
            this.bEditPLitems.TabIndex = 1;
            this.bEditPLitems.Text = "Edit Price List Items";
            this.bEditPLitems.UseVisualStyleBackColor = false;
            // 
            // bEditItemClasses
            // 
            this.bEditItemClasses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(105)))), ((int)(((byte)(210)))));
            this.bEditItemClasses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bEditItemClasses.Location = new System.Drawing.Point(251, 182);
            this.bEditItemClasses.Name = "bEditItemClasses";
            this.bEditItemClasses.Size = new System.Drawing.Size(158, 57);
            this.bEditItemClasses.TabIndex = 3;
            this.bEditItemClasses.Text = "Edit Item Classes";
            this.bEditItemClasses.UseVisualStyleBackColor = false;
            // 
            // bViewItemClasses
            // 
            this.bViewItemClasses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(105)))), ((int)(((byte)(210)))));
            this.bViewItemClasses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bViewItemClasses.Location = new System.Drawing.Point(30, 182);
            this.bViewItemClasses.Name = "bViewItemClasses";
            this.bViewItemClasses.Size = new System.Drawing.Size(158, 57);
            this.bViewItemClasses.TabIndex = 2;
            this.bViewItemClasses.Text = "View Item Classes";
            this.bViewItemClasses.UseVisualStyleBackColor = false;
            // 
            // f0_ItemSetUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(75)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(438, 298);
            this.Controls.Add(this.bEditItemClasses);
            this.Controls.Add(this.bViewItemClasses);
            this.Controls.Add(this.bEditPLitems);
            this.Controls.Add(this.bViewPriceListItems);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "f0_ItemSetUp";
            this.Text = "f0_ItemSetUp";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bViewPriceListItems;
        private System.Windows.Forms.Button bEditPLitems;
        private System.Windows.Forms.Button bEditItemClasses;
        private System.Windows.Forms.Button bViewItemClasses;
    }
}