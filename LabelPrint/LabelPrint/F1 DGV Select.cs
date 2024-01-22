using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LabelPrint
{
    public partial class F1_DGV_SELECT : Form
    {
        SqlConnection cnxn = new SqlConnection(g.db);
        SqlDataAdapter da;
        DataTable table;
        
        
        public F1_DGV_SELECT()
        {
            InitializeComponent();
        }

        private void F1_DGV_SELECT_Load(object sender, EventArgs e)
        {

            System.Security.Principal.WindowsIdentity userBase;
            userBase = System.Security.Principal.WindowsIdentity.GetCurrent();

            string user = userBase.Name.ToUpper(); ;

            if (userBase.Name.IndexOf("Z") == 0)
            {
                user = userBase.Name.Replace("ZYGOMIS\\", "");
            }
            else
            {
                user = userBase.Name.Replace("AMETEK-AD\\", "");
            }

            string computername = Environment.MachineName;

            user = "TSTUART";
            computername = "tstuart-dt";

            SqlConnection cnxn = new SqlConnection(g.db);

            try
            {
                da = new SqlDataAdapter(
                 " Select permission, permissionvalue from applicationsetup " +
                 " where application = 'shippinglabel' and " +
                 " pcid = '" + computername + "' and " +
                 " username = '" + user + "' order by permission desc ", cnxn);
                table = new DataTable();
                da.Fill(table);

                if (table.Rows.Count > 0)
                {
                    /*  putting print server into table on CT-MID-SQL11  */
                    //g.printer = "\\\\midprtsrv\\" + table.Rows[0][1].ToString().Trim();
                    g.printer = table.Rows[0][1].ToString().Trim();
                }
                else
                {
                    MessageBox.Show("Either this user " + user + " or this computer (" + computername + ") does not have permission to use this program.");
                    this.Close();
                }

                if (table.Rows.Count == 2 && table.Rows[1][1].ToString().Trim() == "YES")
                {
                    g.editRevision = "YES";
                }


            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

            }




            //g.printer = "Zdesigner GX430t";
            //g.printer = "ZDesigner ZD421-203dpi ZPL";

            this.Text = "Select Serial Number  v" + Application.ProductVersion;

            /*
             * for Taiwan local printer
             * 
            Lprinter.Text = "Printing on: " + g.printer.Substring(17,(g.printer.Length - (17 )));
            */

            Lprinter.Text = "Printing on: " + g.printer.Substring(17, (g.printer.Length - (17)));

            cnxn = new SqlConnection(g.dbNAV);

            try
            {
                cnxn.Open();
                da = new SqlDataAdapter(
                    "SELECT No_, [Description], [Revision Level] FROM " + g.NAVprefix + "Item " +
                    "ORDER BY No_"
                    , cnxn);
                table = new DataTable();
                da.Fill(table);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            DGV.DataSource = table;
            DGV.Show();
            DGV.Columns[0].Width = 90;
            DGV.Columns[1].Width = 250;
            DGV.Columns[2].Width = 40;
        }


         private void bSearch_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.dbNAV);
            da = new SqlDataAdapter
                ("SELECT No_, [Description], [Revision Level] FROM " + g.NAVprefix + "Item " +
                 " where No_ LIKE '%" + tbSearchPartNumber.Text + "%' " +
                 "or [Description] like '%" + tbSearchPartNumber.Text + "%' " +
                 " order by No_", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;
        }

        private void bItem_Click_1(object sender, EventArgs e)
        {
            g.item = tbSearchPartNumber.Text.ToString().Trim().ToUpper();
            tbSearchPartNumber.Text = "";
            SqlCommand cmd = new SqlCommand(
                "SELECT No_ FROM " + g.NAVprefix + "Item " +
                "where No_ = '" + g.item + "'" );
            cnxn = new SqlConnection(g.dbNAV);
            cmd.Connection = cnxn;
            cnxn.Open();
            object o = cmd.ExecuteScalar();

            if (o == null)
            {
                F3_Non_Standard_Parts f3 = new F3_Non_Standard_Parts();
                //f3.ShowDialog();
                f3.Show();
                //tbSearchPartNumber.Focus();
            }
            else
            {
                cnxn = new SqlConnection(g.dbNAV);
                cnxn.Open();
                da = new SqlDataAdapter(
                    "SELECT No_, [Description], [Revision Level] FROM " + g.NAVprefix + "Item " +
                    "where No_ = '" + g.item + "'", cnxn);
                DataTable table2 = new System.Data.DataTable();
                da.Fill(table2);
                g.item = table2.Rows[0].ItemArray[0].ToString().Trim(); 
                g.iDescription = table2.Rows[0].ItemArray[1].ToString().Trim();
                g.iRevision = table2.Rows[0].ItemArray[2].ToString().Trim(); ;

                if (g.item == "8040-0130-01" | g.item == "8080-0363-32")
                {
                    F2A_Special_SN f2a = new F2A_Special_SN();
                    f2a.Show();
                }
                else
                {
                    F2_Label_Details f2 = new F2_Label_Details();
                    f2.Show();
                }
            }

            
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.item = cell.EditedFormattedValue.ToString().Trim();
                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                g.iDescription = cell.EditedFormattedValue.ToString().Trim();
                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                g.iRevision = cell.EditedFormattedValue.ToString().Trim();

                if (g.item == "8040-0130-01" | g.item == "8080-0363-32")
                {
                    F2A_Special_SN f2a = new F2A_Special_SN();
                    f2a.ShowDialog();
                }
                else
                {
                    F2_Label_Details f2 = new F2_Label_Details();
                    f2.Show();
                }
            }
        }


        private void bFreeText_Click(object sender, EventArgs e)
        {
            g.item = tbSearchPartNumber.Text.ToString().Trim().ToUpper();
            tbSearchPartNumber.Text = "";
            F3_Non_Standard_Parts f3 = new F3_Non_Standard_Parts();
            //f3.ShowDialog();
            f3.Show();
        }

        private void tbSearchPartNumber_Leave(object sender, EventArgs e)
        {
            tbSearchPartNumber.Text = tbSearchPartNumber.Text.Trim().ToUpper();
        }

        private void tbSearchPartNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                bItem.Focus(); 
            }
        }
 
    }

    public static class g
    {
        public static string user;
        public static string item;
        public static string iDescription;
        public static string iRevision;
        public static string editRevision;
        public static string iSerialNumber;
        public static string iQuantity;
        public static string iNumberofBoxes;
        public static string iLabelQuantity;
        public static string printer;
        public static string db = "server = CT-MID-SQL11; password = Read+Write!; " +
                                  "user = readwrite; database = AccessFrontEnds;";
        public static string dbNAV = "server = pa-hor-as408.ametek.com; password = 2018#ameteK; " +
                            "user = navdb_read; database = ZYGO-NAV-PROD;";
        public static string NAVprefix = "ZYGO$";
    }
}
