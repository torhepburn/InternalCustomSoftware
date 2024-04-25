using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CanonLabelEdit
{
    public partial class EditLabels : Form
    {
        public EditLabels()
        {
            InitializeComponent();
        }

        private void zygoCanonMappingsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.zygoCanonMappingsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.accessFrontEndsDataSet);

        }

        private void EditLabels_Load(object sender, EventArgs e)
        {
            this.Text = "Canon Label Edit v" + Application.ProductVersion.Trim();

            System.Security.Principal.WindowsIdentity userBase;
            userBase = System.Security.Principal.WindowsIdentity.GetCurrent();

            string user = string.Empty;

            if (userBase.Name.IndexOf("Z") == 0)
            {
                user = userBase.Name.ToUpper().Replace("ZYGOMIS\\", "");
            }
            else
            {
                user = userBase.Name.ToUpper().Replace("AMETEK-AD\\", "");
            }

            if (user != "THEPBURN" & user != "SWROBEL" & user != "BNOU")
            {
                MessageBox.Show("You are not logged in as Thepburn, SWROBEL, or BNOU");

                this.Close();
            }

            // TODO: This line of code loads data into the 'accessFrontEndsDataSet.ZygoCanonMappings' table. You can move, or remove it, as needed.
            this.zygoCanonMappingsTableAdapter.Fill(this.accessFrontEndsDataSet.ZygoCanonMappings);

        }
    }
}
