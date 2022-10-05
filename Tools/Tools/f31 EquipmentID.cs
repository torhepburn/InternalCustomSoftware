using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Tools
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
                     "Select sn from tools where left(SN, len(@format))" +
                     " = @format and " +
                     "unicode(substring(sn, (len(@format)+1),1)) > 47 and " +
                     "unicode(substring(sn, (len(@format)+1),1)) < 58 " +
                     "order by sn desc");
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
                    { g.SN = idFormat + idNumber.ToString().Trim(); }
                    if (InitialNumberLength - NewNumberLength == 1)
                    { g.SN = idFormat + "0" + idNumber.ToString().Trim(); }
                    if (InitialNumberLength - NewNumberLength == 2)
                    { g.SN = idFormat + "00" + idNumber.ToString().Trim(); }
                    if (InitialNumberLength - NewNumberLength == 3)
                    { g.SN = idFormat + "000" + idNumber.ToString().Trim(); }
                }
                else
                {
                    g.SN = idFormat + "0001";
                }
            }
            tbTemplate.Text = "";
            this.Close();

            F4_Edit f4 = new F4_Edit();
            f4.Show();
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