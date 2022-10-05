namespace CapacityChart
{
    partial class CapacityChart1
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
            this.optiTrakDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.optiTrakDataSet = new CapacityChart.OptiTrakDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.optiTrakDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optiTrakDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // optiTrakDataSetBindingSource
            // 
            this.optiTrakDataSetBindingSource.DataSource = this.optiTrakDataSet;
            this.optiTrakDataSetBindingSource.Position = 0;
            // 
            // optiTrakDataSet
            // 
            this.optiTrakDataSet.DataSetName = "OptiTrakDataSet";
            this.optiTrakDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CapacityChart1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(150)))), ((int)(((byte)(130)))));
            this.ClientSize = new System.Drawing.Size(872, 618);
            this.Name = "CapacityChart1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.optiTrakDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optiTrakDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource optiTrakDataSetBindingSource;
        private OptiTrakDataSet optiTrakDataSet;
    }
}

