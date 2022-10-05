namespace ShippedBoardsAddProduct
{
    partial class AddProductLaser
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
            this.tbItemCode = new System.Windows.Forms.TextBox();
            this.LitemCode = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.Ldescription = new System.Windows.Forms.Label();
            this.tbModel = new System.Windows.Forms.TextBox();
            this.Lmodel = new System.Windows.Forms.Label();
            this.bAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbItemCode
            // 
            this.tbItemCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.tbItemCode.Location = new System.Drawing.Point(188, 193);
            this.tbItemCode.Name = "tbItemCode";
            this.tbItemCode.Size = new System.Drawing.Size(258, 26);
            this.tbItemCode.TabIndex = 9;
            // 
            // LitemCode
            // 
            this.LitemCode.AutoSize = true;
            this.LitemCode.Location = new System.Drawing.Point(44, 193);
            this.LitemCode.Name = "LitemCode";
            this.LitemCode.Size = new System.Drawing.Size(83, 20);
            this.LitemCode.TabIndex = 12;
            this.LitemCode.Text = "Item Code";
            // 
            // tbDescription
            // 
            this.tbDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.tbDescription.Location = new System.Drawing.Point(188, 119);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(258, 26);
            this.tbDescription.TabIndex = 7;
            // 
            // Ldescription
            // 
            this.Ldescription.AutoSize = true;
            this.Ldescription.Location = new System.Drawing.Point(44, 119);
            this.Ldescription.Name = "Ldescription";
            this.Ldescription.Size = new System.Drawing.Size(89, 20);
            this.Ldescription.TabIndex = 10;
            this.Ldescription.Text = "Description";
            // 
            // tbModel
            // 
            this.tbModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.tbModel.Location = new System.Drawing.Point(188, 51);
            this.tbModel.Name = "tbModel";
            this.tbModel.Size = new System.Drawing.Size(258, 26);
            this.tbModel.TabIndex = 6;
            // 
            // Lmodel
            // 
            this.Lmodel.AutoSize = true;
            this.Lmodel.Location = new System.Drawing.Point(44, 51);
            this.Lmodel.Name = "Lmodel";
            this.Lmodel.Size = new System.Drawing.Size(52, 20);
            this.Lmodel.TabIndex = 8;
            this.Lmodel.Text = "Model";
            // 
            // bAdd
            // 
            this.bAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.bAdd.Location = new System.Drawing.Point(188, 271);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(219, 50);
            this.bAdd.TabIndex = 11;
            this.bAdd.Text = "ADD DATA";
            this.bAdd.UseVisualStyleBackColor = false;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // AddProductLaser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(140)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(600, 363);
            this.Controls.Add(this.tbItemCode);
            this.Controls.Add(this.LitemCode);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.Ldescription);
            this.Controls.Add(this.tbModel);
            this.Controls.Add(this.Lmodel);
            this.Controls.Add(this.bAdd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AddProductLaser";
            this.Text = "Add Product - Laser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbItemCode;
        private System.Windows.Forms.Label LitemCode;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label Ldescription;
        private System.Windows.Forms.TextBox tbModel;
        private System.Windows.Forms.Label Lmodel;
        private System.Windows.Forms.Button bAdd;
    }
}

