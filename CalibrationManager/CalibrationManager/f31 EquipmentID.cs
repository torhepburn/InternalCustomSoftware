using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CalibrationManager
{
    public partial class f31_EquipmentID : Form
    {
        
        
        public f31_EquipmentID()
        {
            InitializeComponent();
        }

        private void bID_Click(object sender, EventArgs e)
        {
            string idFormat = tbTemplate.Text.ToString().Trim().ToUpper();

            if (idFormat.StartsWith("SML"))
            {
                if (g.facility == "ZEP")
                {

                    SqlConnection cnxn = new SqlConnection(g.db);
                    SqlCommand cmd = new SqlCommand
                        ("Select ID from equipment where ID = '" +
                         idFormat + "' ", cnxn);
                    cnxn.Open();
                    object o = cmd.ExecuteScalar();
                    cnxn.Close();

                    if (o != null)
                    {
                        MessageBox.Show(idFormat + " has already been issued.");
                    }
                    else
                    {
                        g.iID = idFormat;
                    }
                }
                else
                {
                    MessageBox.Show("SML numbers are reserved for Richmond.");
                    tbTemplate.Text = "";
                    return;
                }
            }
            else
            {

                SqlConnection cnxn = new SqlConnection(g.db);
                SqlCommand cmd = new SqlCommand
                    ("declare @format nchar(10); " +
                     "set @format = '" + idFormat + "'; " +
                     "Select ID from equipment where left(ID, len(@format))" +
                     " = @format and " +
                     "unicode(substring(id, (len(@format)+1),1)) > 47 and " +
                     "unicode(substring(id, (len(@format)+1),1)) < 58 " +
                     "order by id desc");
                cmd.Connection = cnxn;
                cnxn.Open();
                object o = cmd.ExecuteScalar();
                cnxn.Close();
                if (o != null)
                {
                    string temp = o.ToString().Trim();
                    string number = temp.Substring(idFormat.Length, (temp.Length - idFormat.Length));
                    int InitialNumberLength = number.Length;
                    int idNumber = Convert.ToInt32(number);
                    idNumber = idNumber + 1;
                    int NewNumberLength = idNumber.ToString().Length;
                    if (InitialNumberLength - NewNumberLength == 0)
                    { g.iID = idFormat + idNumber.ToString().Trim(); }
                    if (InitialNumberLength - NewNumberLength == 1)
                    { g.iID = idFormat + "0" + idNumber.ToString().Trim(); }
                    if (InitialNumberLength - NewNumberLength == 2)
                    { g.iID = idFormat + "00" + idNumber.ToString().Trim(); }
                    if (InitialNumberLength - NewNumberLength == 3)
                    { g.iID = idFormat + "000" + idNumber.ToString().Trim(); }
                }
                else
                {
                    g.iID = idFormat + "0001";
                }
            }
            tbTemplate.Text = "";
            this.Close();
            f30_Edit_Items f30 = new f30_Edit_Items();
            f30.Show();
        }

        private void tbTemplate_TextChanged(object sender, EventArgs e)
        {
            if (tbTemplate.Text.Length > 3)
            {
                if (tbTemplate.Text.ToUpper().Substring(0, 3) != "SML")
                {
                    if (tbTemplate.Text.Length > 5)
                    {
                        MessageBox.Show("Prefix too long.");
                        tbTemplate.Text = "";
                        tbTemplate.Focus();
                    }
                }
            }
        }

    }
}