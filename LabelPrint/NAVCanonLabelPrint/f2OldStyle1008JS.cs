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
using System.IO;
using System.Threading;

namespace NAVCanonLabelPrint
{
    public partial class f2OldStyle1008JS : Form
    {
        SqlConnection cnxn = new SqlConnection(g.db);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable table;
        private object o;
        private string sn;
        private string printQuantity;

        public f2OldStyle1008JS()
        {
            InitializeComponent();
        }

        private void f2OldStyle1008JS_Load(object sender, EventArgs e)
        {
            GetData();

            try
            {
                cmd = new SqlCommand(
                    "UPDATE labels.canonlabels " +
                    "SET PRINTthis = 1, " +
                    "PRINTextraLabels = 0 " +
                    "where " + g.orderplusdate
                    , cnxn);
                cnxn.Open();
                cmd.ExecuteNonQuery();
                cnxn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }
        }

        private void bSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand(
                    "UPDATE labels.canonlabels " +
                    "SET PRINTthis = 1, " +
                    "PRINTextraLabels = 0 " +
                    "where " + g.orderplusdate
                    ,cnxn);
                cnxn.Open();
                cmd.ExecuteNonQuery();
                cnxn.Close();

                GetData();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

        }

        private void bClear_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand(
                    "UPDATE labels.canonlabels " +
                    "SET PRINTthis = 0, " +
                    "PRINTextraLabels = 0 " +
                    "where " + g.orderplusdate
                    , cnxn);
                cnxn.Open();
                cmd.ExecuteNonQuery();
                cnxn.Close();

                GetData();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"C:\labels\canon\canonlabel.txt",
                "Copies \t BarCode \t Canon_PN \t Zygo_PN \t Item_Description " +
                "\t CanonGlobalCode \t ZygoSN" + Environment.NewLine);

            // create valid update command
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(table);

            try
            {
                cmd = new SqlCommand(
                        "Select id from labels.canonlabels where " +
                        g.orderplusdate +
                        "and serializethis = 1 " +
                        "and zygoSN is null " +
                        "and printthis = 1", cnxn);
                cnxn.Open();
                o = cmd.ExecuteScalar();
                cnxn.Close();


            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            if (o != null)
            {
                MessageBox.Show("Can't print serialized labels without serial numbers.");
                return;
            }
            else
            {

                try
                {
                    /*
                     *
                     *This data adapter and table are just to make testing easier 
                     * 
                    

                    SqlDataAdapter da = new SqlDataAdapter
                        ("Select " +
                         "IIF(ZygoSN is null, " +
                         "'91' + LEFT(canon_global_code, 8) + '^1' + '92' + " +
                         "RIGHT(canon_global_code, 2) + '^1' + '21', " +
                         "'91' + LEFT(canon_global_code, 8) + '^1' + '92' + " +
                         "RIGHT(canon_global_code, 2) + '^1' + '21' + " +
                         "ZygoSN) as Barcode, " +
                         "m.Canon_PN, " +
                         "m.Zygo_PN, " +
                         "m.Item_Description, " +
                         "LEFT(Canon_Global_Code,8) + '[' + RIGHT(Canon_Global_Code,2) + ']' CanonGlobalCode, " +
                         "UPPER(ZygoSN) ZygoSN, " +
                         "SerializeThis, " +
                         "CASE " +
                         "  WHEN PrintExtraLabels = 0 THEN Delivered_Quantity " +
                         "  WHEN PrintExtraLabels > 0 THEN PrintExtraLabels " +
                         "End Delivered_Quantity " +
                         "from labels.CanonLabels l " +
                         "inner join labels.ZygoCanonMappings m " +
                         "on l.Canon_Subsidiary = m.Canon_Subsidiary " +
                         "and l.ITEM_CODE = m.Zygo_PN " +
                         "where PICKING_LIST_NUMBER = '" +
                         g.pickingListNumber + "' and printthis = 1" +
                        "order by position desc, serialized desc", cnxn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    */

                    cmd = new SqlCommand
                        ("Select " +
                         "IIF(ZygoSN is null, " +
                         "'91' + LEFT(canon_global_code, 8) + '^1' + '92' + " +
                         "RIGHT(canon_global_code, 2) + '^1' + '21', " +
                         "'91' + LEFT(canon_global_code, 8) + '^1' + '92' + " +
                         "RIGHT(canon_global_code, 2) + '^1' + '21' + " +
                         "ZygoSN) as Barcode, " +
                         "m.Canon_PN, " +
                         "m.Zygo_PN, " +
                         "m.Item_Description, " +
                         "LEFT(Canon_Global_Code,8) + '[' + RIGHT(Canon_Global_Code,2) + ']' CanonGlobalCode, " +
                         "UPPER(ZygoSN) ZygoSN, " +
                         "SerializeThis, " +
                         "CASE " +
                         "  WHEN PrintExtraLabels = 0 THEN Delivered_Quantity " +
                         "  WHEN PrintExtraLabels > 0 THEN PrintExtraLabels " +
                         "End Delivered_Quantity " +
                         "from labels.CanonLabels l " +
                         "inner join labels.ZygoCanonMappings m " +
                         "on l.Canon_Subsidiary = m.Canon_Subsidiary " +
                         "and l.ITEM_CODE = m.Zygo_PN " +
                         "where " + g.orderplusdate + "' and printthis = 1" +
                        "order by position desc, serialized desc", cnxn);
                    cnxn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        if (!dr.IsDBNull(5))
                        { sn = dr.GetString(5).Trim(); }
                        else
                        { sn = ""; }

                        if (dr.GetBoolean(6) == false)
                        {
                            printQuantity = dr.GetInt32(7).ToString();
                        }
                        else
                        {
                            printQuantity = "1";
                        }

                        File.AppendAllText(@"C:\labels\canon\canonlabel.txt",
                            printQuantity + " \t " +
                            dr.GetString(0).Trim() + " \t " +
                            dr.GetString(1).Trim() + " \t " +
                            dr.GetString(2).Trim() + " \t " +
                            dr.GetString(3).Trim() + " \t " +
                            dr.GetString(4).Trim() + " \t " +
                            sn + Environment.NewLine);
                    }
                    cnxn.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn.Close();
                }

                System.Diagnostics.Process.Start("C:\\Program Files (x86)\\Seagull" +
               "\\Bartender Suite\\bartend.exe",
                "/P /X /F=\\\\zygocorp\\departments\\shiprcvg\\labels\\labelformats\\ZebraCanontext_sn22.btw /d=" +
               "c:\\labels\\canon\\canonlabel.txt");
                Thread.Sleep(5 * 1000);
            }


            this.Close();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetData()
        {
            try
            {
                cnxn.Open();
                da = new SqlDataAdapter(
                    "select " +
                    "printThis [Print], " +
                    "PrintExtraLabels, " +
                    "ZygoSN, " +
                    "Barcode [Bar Code], " +
                    "SerializeThis [Serialize], " +
                    "Serialized [Line No], " +
                    "Order_no, " +
                    "position POS, " +
                    "Customer, " +
                    "Item_Code [Item Code], " +
                    "Delivered_quantity [Deliver Qty], " +
                    "Customer_PO [Customer PO], " +
                    "id " +
                    "from labels.CanonLabels " +
                    "where " + g.orderplusdate +
                    "order by position, serialized", cnxn);
                table = new DataTable();
                da.Fill(table);
                cnxn.Close();
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
            DGV.Columns[0].Width = 50;
            DGV.Columns[1].Width = 50;
            DGV.Columns[2].Width = 100;
            DGV.Columns[3].Width = 50;
            DGV.Columns[3].ReadOnly = true;
            DGV.Columns[4].Width = 50;
            DGV.Columns[4].ReadOnly = true;
            DGV.Columns[5].Width = 50;
            DGV.Columns[5].ReadOnly = true;
            DGV.Columns[7].Width = 100;
            DGV.Columns[6].ReadOnly = true;
            DGV.Columns[7].Width = 50;
            DGV.Columns[7].ReadOnly = true;
            DGV.Columns[8].Width = 60;
            DGV.Columns[8].ReadOnly = true;
            DGV.Columns[9].Width = 80;
            DGV.Columns[9].ReadOnly = true;
            DGV.Columns[10].Width = 50;
            DGV.Columns[10].ReadOnly = true;
            DGV.Columns[11].Width = 200;
            DGV.Columns[11].ReadOnly = true;
            DGV.Columns[12].Visible = false;
        }
    }
}
