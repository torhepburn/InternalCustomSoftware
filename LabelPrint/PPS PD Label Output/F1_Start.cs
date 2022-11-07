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
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace PPS_PD_Label_Output
{
    public partial class F1_Start : Form
    {
        SqlConnection cnxn;
        private string board;
        private string boardRev;
        private string firmware;
        private string firmwareRev;
        DataTable table;

        private string productionOrder;
        public F1_Start()
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
            
            
            if (tbPDNumber.Text.Length > 0 & tbPDNumber.Text.IndexOf('/') > 0)
            {
                productionOrder = tbPDNumber.Text.Substring(0, tbPDNumber.Text.IndexOf('/')).ToUpper();

                cnxn = new("server=PA-HOR-AS408; user=navdb_read; password=2018#ameteK;" +
                           "database=ZYGO-NAV-PROD; encrypt=false;");

                SqlCommand cmd = new("select " +
                    "pbl.[Production BOM No_] " +
                    ",i.[Revision Level] " +
                    ",pbl.No_ " +
                    ",ii.[Revision Level] " +
                    "from [ZYGO$Prod_ Order Line] pol " +
                    "INNER JOIN[ZYGO$Production BOM Line] pbl ON pol.[Item No_] = pbl.[Production BOM No_] " +
                    "INNER JOIN ZYGO$Item i ON pbl.[Production BOM No_] = i.No_ " +
                    "INNER JOIN ZYGO$Item ii ON pbl.[No_] = ii.No_ " +
                    "WHERE pol.[Prod_ Order No_] = '" + productionOrder + "' " +
                    "AND (pbl.[Production BOM No_] LIKE '8020-0104-%' OR pbl.[Production BOM No_] in ('8020-8610-01','8020-8610-02')) " +
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
                        //P.StartInfo.Arguments = @" /F=C:\labels\pn-fw.btw";
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
