using System;
using System.Data;
using System.Windows.Forms;

namespace Certs
{
    public partial class AdminChoices : Form
    {
        public AdminChoices()
        {
            InitializeComponent();
        }

        private void bDropDownLists_Click(object sender, EventArgs e)
        {
            AdminDropDowns d = new AdminDropDowns();
            d.ShowDialog();
        }

        private void bProgramPermissionss_Click(object sender, EventArgs e)
        {
            g.task = "EDIT";
            AdminPermissions p = new AdminPermissions();
            p.ShowDialog();
        }

        private void bAddUser_Click(object sender, EventArgs e)
        {
            g.task = "ADD";
            AdminAddUser u = new AdminAddUser();
            u.ShowDialog();
        }
    }
}
