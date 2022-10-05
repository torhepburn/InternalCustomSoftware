namespace MethodSheet1
{
    partial class EditPartData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditPartData));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.accessFrontEndsDataSet = new MethodSheet1.AccessFrontEndsDataSet();
            this.opticsMethodSheetDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.opticsMethodSheetDataTableAdapter = new MethodSheet1.AccessFrontEndsDataSetTableAdapters.OpticsMethodSheetDataTableAdapter();
            this.tableAdapterManager = new MethodSheet1.AccessFrontEndsDataSetTableAdapters.TableAdapterManager();
            this.opticsMethodSheetDataBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.opticsMethodSheetDataBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.opticsMethodSheetDataDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.accessFrontEndsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opticsMethodSheetDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opticsMethodSheetDataBindingNavigator)).BeginInit();
            this.opticsMethodSheetDataBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opticsMethodSheetDataDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // accessFrontEndsDataSet
            // 
            this.accessFrontEndsDataSet.DataSetName = "AccessFrontEndsDataSet";
            this.accessFrontEndsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // opticsMethodSheetDataBindingSource
            // 
            this.opticsMethodSheetDataBindingSource.DataMember = "OpticsMethodSheetData";
            this.opticsMethodSheetDataBindingSource.DataSource = this.accessFrontEndsDataSet;
            // 
            // opticsMethodSheetDataTableAdapter
            // 
            this.opticsMethodSheetDataTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.OpticsMethodSheetDataTableAdapter = this.opticsMethodSheetDataTableAdapter;
            this.tableAdapterManager.UpdateOrder = MethodSheet1.AccessFrontEndsDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // opticsMethodSheetDataBindingNavigator
            // 
            this.opticsMethodSheetDataBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.opticsMethodSheetDataBindingNavigator.BindingSource = this.opticsMethodSheetDataBindingSource;
            this.opticsMethodSheetDataBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.opticsMethodSheetDataBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.opticsMethodSheetDataBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.opticsMethodSheetDataBindingNavigatorSaveItem});
            this.opticsMethodSheetDataBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.opticsMethodSheetDataBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.opticsMethodSheetDataBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.opticsMethodSheetDataBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.opticsMethodSheetDataBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.opticsMethodSheetDataBindingNavigator.Name = "opticsMethodSheetDataBindingNavigator";
            this.opticsMethodSheetDataBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.opticsMethodSheetDataBindingNavigator.Size = new System.Drawing.Size(738, 25);
            this.opticsMethodSheetDataBindingNavigator.TabIndex = 0;
            this.opticsMethodSheetDataBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // opticsMethodSheetDataBindingNavigatorSaveItem
            // 
            this.opticsMethodSheetDataBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.opticsMethodSheetDataBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("opticsMethodSheetDataBindingNavigatorSaveItem.Image")));
            this.opticsMethodSheetDataBindingNavigatorSaveItem.Name = "opticsMethodSheetDataBindingNavigatorSaveItem";
            this.opticsMethodSheetDataBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.opticsMethodSheetDataBindingNavigatorSaveItem.Text = "Save Data";
            this.opticsMethodSheetDataBindingNavigatorSaveItem.Click += new System.EventHandler(this.opticsMethodSheetDataBindingNavigatorSaveItem_Click_1);
            // 
            // opticsMethodSheetDataDataGridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.opticsMethodSheetDataDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.opticsMethodSheetDataDataGridView.AutoGenerateColumns = false;
            this.opticsMethodSheetDataDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.opticsMethodSheetDataDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12});
            this.opticsMethodSheetDataDataGridView.DataSource = this.opticsMethodSheetDataBindingSource;
            this.opticsMethodSheetDataDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opticsMethodSheetDataDataGridView.Location = new System.Drawing.Point(0, 25);
            this.opticsMethodSheetDataDataGridView.Name = "opticsMethodSheetDataDataGridView";
            this.opticsMethodSheetDataDataGridView.Size = new System.Drawing.Size(738, 449);
            this.opticsMethodSheetDataDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Customer";
            this.dataGridViewTextBoxColumn1.HeaderText = "Customer";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PartNumber";
            this.dataGridViewTextBoxColumn2.HeaderText = "PartNumber";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "LastWoReleased";
            this.dataGridViewTextBoxColumn3.HeaderText = "LastWoReleased";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DESCRIPTION";
            this.dataGridViewTextBoxColumn4.HeaderText = "DESCRIPTION";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Rev";
            this.dataGridViewTextBoxColumn5.HeaderText = "Rev";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "LotSize";
            this.dataGridViewTextBoxColumn6.HeaderText = "LotSize";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "initials";
            this.dataGridViewTextBoxColumn7.HeaderText = "initials";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "LastReleaseDate";
            this.dataGridViewTextBoxColumn8.HeaderText = "LastReleaseDate";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "NewMethod";
            this.dataGridViewTextBoxColumn9.HeaderText = "NewMethod";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "MethodSheetReviewDate";
            this.dataGridViewTextBoxColumn10.HeaderText = "MethodSheetReviewDate";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "FilePath";
            this.dataGridViewTextBoxColumn11.HeaderText = "FilePath";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Serial";
            this.dataGridViewTextBoxColumn12.HeaderText = "Serial";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // EditPartData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(120)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(738, 474);
            this.Controls.Add(this.opticsMethodSheetDataDataGridView);
            this.Controls.Add(this.opticsMethodSheetDataBindingNavigator);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EditPartData";
            this.Text = "EditPartData";
            this.Load += new System.EventHandler(this.EditPartData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accessFrontEndsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opticsMethodSheetDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opticsMethodSheetDataBindingNavigator)).EndInit();
            this.opticsMethodSheetDataBindingNavigator.ResumeLayout(false);
            this.opticsMethodSheetDataBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opticsMethodSheetDataDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AccessFrontEndsDataSet accessFrontEndsDataSet;
        private System.Windows.Forms.BindingSource opticsMethodSheetDataBindingSource;
        private AccessFrontEndsDataSetTableAdapters.OpticsMethodSheetDataTableAdapter opticsMethodSheetDataTableAdapter;
        private AccessFrontEndsDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator opticsMethodSheetDataBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton opticsMethodSheetDataBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView opticsMethodSheetDataDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;

    }
}