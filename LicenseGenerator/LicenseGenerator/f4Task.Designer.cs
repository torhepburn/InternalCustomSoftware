namespace LicenseGenerator
{
    partial class f4Task
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
            this.bLicense = new System.Windows.Forms.Button();
            this.bDetails = new System.Windows.Forms.Button();
            this.bCustomer = new System.Windows.Forms.Button();
            this.bSalesOrder = new System.Windows.Forms.Button();
            this.bExpirationLT5Y = new System.Windows.Forms.Button();
            this.bExpirationAll = new System.Windows.Forms.Button();
            this.bDelete = new System.Windows.Forms.Button();
            this.bChange = new System.Windows.Forms.Button();
            this.bDongleByApp = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbApplication = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bLicense
            // 
            this.bLicense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(155)))));
            this.bLicense.Location = new System.Drawing.Point(84, 50);
            this.bLicense.Name = "bLicense";
            this.bLicense.Size = new System.Drawing.Size(145, 54);
            this.bLicense.TabIndex = 0;
            this.bLicense.Text = "Make License";
            this.bLicense.UseVisualStyleBackColor = false;
            this.bLicense.Click += new System.EventHandler(this.bLicense_Click);
            // 
            // bDetails
            // 
            this.bDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(155)))));
            this.bDetails.Location = new System.Drawing.Point(84, 135);
            this.bDetails.Name = "bDetails";
            this.bDetails.Size = new System.Drawing.Size(145, 54);
            this.bDetails.TabIndex = 1;
            this.bDetails.Text = "Dongle ID Details";
            this.bDetails.UseVisualStyleBackColor = false;
            this.bDetails.Click += new System.EventHandler(this.bDetails_Click);
            // 
            // bCustomer
            // 
            this.bCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(155)))));
            this.bCustomer.Location = new System.Drawing.Point(84, 211);
            this.bCustomer.Name = "bCustomer";
            this.bCustomer.Size = new System.Drawing.Size(145, 54);
            this.bCustomer.TabIndex = 2;
            this.bCustomer.Text = "Dongle ID by Customer";
            this.bCustomer.UseVisualStyleBackColor = false;
            this.bCustomer.Click += new System.EventHandler(this.bCustomer_Click);
            // 
            // bSalesOrder
            // 
            this.bSalesOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(155)))));
            this.bSalesOrder.Location = new System.Drawing.Point(84, 297);
            this.bSalesOrder.Name = "bSalesOrder";
            this.bSalesOrder.Size = new System.Drawing.Size(145, 54);
            this.bSalesOrder.TabIndex = 3;
            this.bSalesOrder.Text = "Dongle ID by Sales Order";
            this.bSalesOrder.UseVisualStyleBackColor = false;
            this.bSalesOrder.Click += new System.EventHandler(this.bSalesOrder_Click);
            // 
            // bExpirationLT5Y
            // 
            this.bExpirationLT5Y.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(155)))));
            this.bExpirationLT5Y.Location = new System.Drawing.Point(313, 297);
            this.bExpirationLT5Y.Name = "bExpirationLT5Y";
            this.bExpirationLT5Y.Size = new System.Drawing.Size(145, 54);
            this.bExpirationLT5Y.TabIndex = 7;
            this.bExpirationLT5Y.Text = "Expiration < 5 Years";
            this.bExpirationLT5Y.UseVisualStyleBackColor = false;
            this.bExpirationLT5Y.Click += new System.EventHandler(this.bExpirationLT5Y_Click);
            // 
            // bExpirationAll
            // 
            this.bExpirationAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(155)))));
            this.bExpirationAll.Location = new System.Drawing.Point(313, 211);
            this.bExpirationAll.Name = "bExpirationAll";
            this.bExpirationAll.Size = new System.Drawing.Size(145, 54);
            this.bExpirationAll.TabIndex = 6;
            this.bExpirationAll.Text = "Expiration (All)";
            this.bExpirationAll.UseVisualStyleBackColor = false;
            this.bExpirationAll.Click += new System.EventHandler(this.bExpirationAll_Click);
            // 
            // bDelete
            // 
            this.bDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(155)))));
            this.bDelete.Location = new System.Drawing.Point(313, 135);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(145, 54);
            this.bDelete.TabIndex = 5;
            this.bDelete.Text = "Delete License Lines";
            this.bDelete.UseVisualStyleBackColor = false;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // bChange
            // 
            this.bChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(155)))));
            this.bChange.Location = new System.Drawing.Point(313, 50);
            this.bChange.Name = "bChange";
            this.bChange.Size = new System.Drawing.Size(145, 54);
            this.bChange.TabIndex = 4;
            this.bChange.Text = "Change License SO";
            this.bChange.UseVisualStyleBackColor = false;
            this.bChange.Click += new System.EventHandler(this.bChange_Click);
            // 
            // bDongleByApp
            // 
            this.bDongleByApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(155)))));
            this.bDongleByApp.Location = new System.Drawing.Point(17, 17);
            this.bDongleByApp.Name = "bDongleByApp";
            this.bDongleByApp.Size = new System.Drawing.Size(145, 54);
            this.bDongleByApp.TabIndex = 8;
            this.bDongleByApp.Text = "Dongle ID by App";
            this.bDongleByApp.UseVisualStyleBackColor = false;
            this.bDongleByApp.Click += new System.EventHandler(this.bDongleByApp_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.panel1.Controls.Add(this.cbApplication);
            this.panel1.Controls.Add(this.bDongleByApp);
            this.panel1.Location = new System.Drawing.Point(39, 373);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(471, 88);
            this.panel1.TabIndex = 9;
            // 
            // cbApplication
            // 
            this.cbApplication.AccessibleDescription = "A";
            this.cbApplication.FormattingEnabled = true;
            this.cbApplication.Location = new System.Drawing.Point(168, 30);
            this.cbApplication.Name = "cbApplication";
            this.cbApplication.Size = new System.Drawing.Size(285, 28);
            this.cbApplication.TabIndex = 14;
            // 
            // f4Task
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.ClientSize = new System.Drawing.Size(547, 478);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bExpirationLT5Y);
            this.Controls.Add(this.bExpirationAll);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.bChange);
            this.Controls.Add(this.bSalesOrder);
            this.Controls.Add(this.bCustomer);
            this.Controls.Add(this.bDetails);
            this.Controls.Add(this.bLicense);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "f4Task";
            this.ShowInTaskbar = false;
            this.Text = "f4Task";
            this.Load += new System.EventHandler(this.f4Task_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bLicense;
        private System.Windows.Forms.Button bDetails;
        private System.Windows.Forms.Button bCustomer;
        private System.Windows.Forms.Button bSalesOrder;
        private System.Windows.Forms.Button bExpirationLT5Y;
        private System.Windows.Forms.Button bExpirationAll;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.Button bChange;
        private System.Windows.Forms.Button bDongleByApp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbApplication;
    }
}