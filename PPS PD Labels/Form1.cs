using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace PPS_PD_Labels
{
    public partial class Form1 : Form
    {
        SqlConnection cnxn;
        SqlCommand cmd;
        private string board;
        private string boardRev;
        private string firmware;
        private string firmwareRev;
        DataTable table;
        private string productionOrder;
        private string topLevel;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "PPS Label Output v." + Application.ProductVersion;
            tbQuantity.Focus();
        }

        private void bGetData_Click(object sender, EventArgs e)
        {
            int quantity;
            if (Int32.TryParse(tbQuantity.Text.Trim(), out quantity))
            {

            }
            else
            {
                MessageBox.Show("Must enter a number.");
                tbQuantity.Text = String.Empty;
                tbQuantity.Focus();
                return;
            }

            //string tt = tbPDNumber.Text;
            //string ttt = tbPDNumber.Text.Substring(0, 2);
            //bool xx = tbPDNumber.Text.ToUpper().Contains("P");

            if (tbPDNumber.Text.Substring(0, 3).ToUpper() == "%P%")     /* the scan of the WO puts '%P%' in front of the WO #   */
            {
                productionOrder = tbPDNumber.Text.Substring(3, 8).ToUpper();
            }
            else if ((tbPDNumber.Text.Length > 0 & tbPDNumber.Text.IndexOf('/') > 0))
            {
                productionOrder = tbPDNumber.Text.Substring(0, tbPDNumber.Text.IndexOf('/')).ToUpper(); /*  at some point entering manually must have put a / in at the end of the text   */
            }
            else if (tbPDNumber.Text.Length > 0)
            {
                productionOrder = tbPDNumber.Text.ToUpper();
            }

            if (productionOrder.Length > 0)
            {


                cnxn = new("server=PA-HOR-AS408.ametek.com; user=navdb_read; password=2018#ameteK;" +
                           "database=ZYGO-NAV-PROD; encrypt=false;");

                cmd = new("select " +
                    "pbl.[Production BOM No_] " +
                    ",i.[Revision Level] " +
                    ",pbl.No_ " +
                    ",ii.[Revision Level] " +
                    "from [ZYGO$Prod_ Order Line] pol " +
                    "INNER JOIN[ZYGO$Production BOM Line] pbl ON pol.[Item No_] = pbl.[Production BOM No_] " +
                    "INNER JOIN ZYGO$Item i ON pbl.[Production BOM No_] = i.No_ " +
                    "INNER JOIN ZYGO$Item ii ON pbl.[No_] = ii.No_ " +
                    "WHERE pol.[Prod_ Order No_] = '" + productionOrder + "' " +
                    "AND (pbl.[Production BOM No_] LIKE '8020-0104-%' OR pbl.[Production BOM No_] in " +
                    "(SELECT [Production BOM No_] FROM [ZYGO$Production BOM Line] WHERE [Production BOM No_] LIKE '8020-8610%') " +
                    "OR pbl.[Production BOM No_] LIKE '8020-0450%') " +
                    "AND ii.Description LIKE 'ZMI%' " +
                    "AND pbl.No_ LIKE 'SPM%'", cnxn);
                               

                try
                    {
                        table = new DataTable();

                        cnxn.Open();

                        SqlDataReader dr;

                        dr = cmd.ExecuteReader();

                        table.Load(dr);

                        if (table.Rows.Count > 0)
                        {
                            dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                board = dr.GetString(0).Trim();
                                boardRev = dr.GetString(1).Trim();
                                firmware = dr.GetString(2).Trim();
                                firmwareRev = dr.GetString(3).Trim();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        cnxn.Close();

                    }

                if (table.Rows.Count > 0)
                {

                    File.WriteAllText(@"C:\labels\pn.txt", board);
                    File.WriteAllText(@"C:\labels\pnREV.txt", boardRev);
                    File.WriteAllText(@"C:\labels\fw.txt", firmware);
                    File.WriteAllText(@"C:\labels\fwREV.txt", firmwareRev);


                    for (int i = 0; i < quantity; i++)
                    {
                        Process P = new Process();
                        P.StartInfo.FileName = @"C:\Program Files (x86)\Seagull\BarTender Suite\bartend.exe";
                        P.StartInfo.Arguments = @" /F=C:\labels\pn-fw.btw /P /X";
                        P.Start();
                    }
                }
                else
                {
                    MessageBox.Show("No data available to print.");
                }
                //string printer = "ZDesigner GK420t";
            }
            else
            {
                MessageBox.Show("Must scan bar code from operation section.");
                tbPDNumber.Text = String.Empty;
                tbPDNumber.Focus();
                return;
            }

        }

    }
}
