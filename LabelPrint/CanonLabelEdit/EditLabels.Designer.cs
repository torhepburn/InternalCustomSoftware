namespace CanonLabelEdit
{
    partial class EditLabels
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditLabels));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.accessFrontEndsDataSet = new CanonLabelEdit.AccessFrontEndsDataSet();
            this.zygoCanonMappingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.zygoCanonMappingsTableAdapter = new CanonLabelEdit.AccessFrontEndsDataSetTableAdapters.ZygoCanonMappingsTableAdapter();
            this.tableAdapterManager = new CanonLabelEdit.AccessFrontEndsDataSetTableAdapters.TableAdapterManager();
            this.zygoCanonMappingsBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.zygoCanonMappingsBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.zygoCanonMappingsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.accessFrontEndsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zygoCanonMappingsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zygoCanonMappingsBindingNavigator)).BeginInit();
            this.zygoCanonMappingsBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zygoCanonMappingsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // accessFrontEndsDataSet
            // 
            this.accessFrontEndsDataSet.DataSetName = "AccessFrontEndsDataSet";
            this.accessFrontEndsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // zygoCanonMappingsBindingSource
            // 
            this.zygoCanonMappingsBindingSource.DataMember = "ZygoCanonMappings";
            this.zygoCanonMappingsBindingSource.DataSource = this.accessFrontEndsDataSet;
            // 
            // zygoCanonMappingsTableAdapter
            // 
            this.zygoCanonMappingsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.UpdateOrder = CanonLabelEdit.AccessFrontEndsDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.ZygoCanonMappingsTableAdapter = this.zygoCanonMappingsTableAdapter;
            // 
            // zygoCanonMappingsBindingNavigator
            // 
            this.zygoCanonMappingsBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.zygoCanonMappingsBindingNavigator.BindingSource = this.zygoCanonMappingsBindingSource;
            this.zygoCanonMappingsBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.zygoCanonMappingsBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.zygoCanonMappingsBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.zygoCanonMappingsBindingNavigatorSaveItem});
            this.zygoCanonMappingsBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.zygoCanonMappingsBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.zygoCanonMappingsBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.zygoCanonMappingsBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.zygoCanonMappingsBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.zygoCanonMappingsBindingNavigator.Name = "zygoCanonMappingsBindingNavigator";
            this.zygoCanonMappingsBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.zygoCanonMappingsBindingNavigator.Size = new System.Drawing.Size(743, 25);
            this.zygoCanonMappingsBindingNavigator.TabIndex = 0;
            this.zygoCanonMappingsBindingNavigator.Text = "bindingNavigator1";
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
            // zygoCanonMappingsBindingNavigatorSaveItem
            // 
            this.zygoCanonMappingsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zygoCanonMappingsBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("zygoCanonMappingsBindingNavigatorSaveItem.Image")));
            this.zygoCanonMappingsBindingNavigatorSaveItem.Name = "zygoCanonMappingsBindingNavigatorSaveItem";
            this.zygoCanonMappingsBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.zygoCanonMappingsBindingNavigatorSaveItem.Text = "Save Data";
            this.zygoCanonMappingsBindingNavigatorSaveItem.Click += new System.EventHandler(this.zygoCanonMappingsBindingNavigatorSaveItem_Click);
            // 
            // zygoCanonMappingsDataGridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.zygoCanonMappingsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.zygoCanonMappingsDataGridView.AutoGenerateColumns = false;
            this.zygoCanonMappingsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.zygoCanonMappingsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewCheckBoxColumn1});
            this.zygoCanonMappingsDataGridView.DataSource = this.zygoCanonMappingsBindingSource;
            this.zygoCanonMappingsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zygoCanonMappingsDataGridView.Location = new System.Drawing.Point(0, 25);
            this.zygoCanonMappingsDataGridView.Name = "zygoCanonMappingsDataGridView";
            this.zygoCanonMappingsDataGridView.Size = new System.Drawing.Size(743, 326);
            this.zygoCanonMappingsDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Zygo_PN";
            this.dataGridViewTextBoxColumn2.HeaderText = "Zygo_PN";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Canon_Subsidiary";
            this.dataGridViewTextBoxColumn3.HeaderText = "Canon_Subsidiary";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Canon_PN";
            this.dataGridViewTextBoxColumn4.HeaderText = "Canon_PN";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Item_Description";
            this.dataGridViewTextBoxColumn5.HeaderText = "Item_Description";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Canon_Global_Code";
            this.dataGridViewTextBoxColumn6.HeaderText = "Canon_Global_Code";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "Serialized_YN";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Serialized_YN";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // EditLabels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 351);
            this.Controls.Add(this.zygoCanonMappingsDataGridView);
            this.Controls.Add(this.zygoCanonMappingsBindingNavigator);
            this.Name = "EditLabels";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.EditLabels_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accessFrontEndsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zygoCanonMappingsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zygoCanonMappingsBindingNavigator)).EndInit();
            this.zygoCanonMappingsBindingNavigator.ResumeLayout(false);
            this.zygoCanonMappingsBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zygoCanonMappingsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AccessFrontEndsDataSet accessFrontEndsDataSet;
        private System.Windows.Forms.BindingSource zygoCanonMappingsBindingSource;
        private AccessFrontEndsDataSetTableAdapters.ZygoCanonMappingsTableAdapter zygoCanonMappingsTableAdapter;
        private AccessFrontEndsDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator zygoCanonMappingsBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton zygoCanonMappingsBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView zygoCanonMappingsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
    }
}

