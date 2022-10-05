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
using System.Diagnostics;
using System.IO;

namespace PPS_PD_Label
{
    public partial class Form1 : Form
    {
        SqlConnection cnxn;
        private string board;
        private string boardRev;
        private string firmware;
        private string firmwareRev;
        private int labelQuantity;

        private string productionOrder;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            if (tbPDNumber.Text.Length > 0)
            {
                productionOrder = tbPDNumber.Text.Substring(0, tbPDNumber.Text.IndexOf('/')).ToUpper();

                cnxn = new SqlConnection("server=PA-HOR-AS408; user=navdb_read; password=2018#ameteK;" +
                           "database=ZYGO-NAV-PROD; encrypt=false;");

                SqlCommand cmd = new SqlCommand("select " +
                    "pbl.[Production BOM No_] " +
                    ",i.[Revision Level] " +
                    ",pbl.No_ " +
                    ",ii.[Revision Level] " +
                    "from [ZYGO$Prod_ Order Line] pol " +
                    "INNER JOIN[ZYGO$Production BOM Line] pbl ON pol.[Item No_] = pbl.[Production BOM No_] " +
                    "INNER JOIN ZYGO$Item i ON pbl.[Production BOM No_] = i.No_ " +
                    "INNER JOIN ZYGO$Item ii ON pbl.[No_] = ii.No_ " +
                    "WHERE pol.[Prod_ Order No_] = '" + productionOrder + "' " +
                    "AND pbl.No_ LIKE 'SPM%'", cnxn);

                try
                {
                    DataTable table = new DataTable();

                    cnxn.Open();

                    SqlDataReader dr;

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        board = dr.GetString(0).Trim();
                        boardRev = dr.GetString(1).Trim();
                        firmware = dr.GetString(2).Trim();
                        firmwareRev = dr.GetString(3).Trim();
                    }
                    //table.Load(dr);
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    cnxn.Close();

                }

                File.WriteAllText(@"C:\labels\pn.txt", board);
                File.WriteAllText(@"C:\labels\pnREV.txt", boardRev);
                File.WriteAllText(@"C:\labels\fw.txt", firmware);
                File.WriteAllText(@"C:\labels\fwREV.txt", firmwareRev);

                if (rb1.Checked)
                {
                    labelQuantity = 1;
                }
                if (rb2.Checked)
                {
                    labelQuantity = 2;
                }
                if (rb3.Checked)
                {
                    labelQuantity = 3;
                }
                if (rb4.Checked)
                {
                    labelQuantity = 4;
                }

                for (int i = 0; i < labelQuantity; i++)
                {
                    Process P = new Process();
                    P.StartInfo.FileName = @"C:\Program Files (x86)\Seagull\BarTender Suite\bartend.exe";
                    P.StartInfo.Arguments = @" /F=C:\labels\pn-fw.btw /P /X";
                    //P.StartInfo.Arguments = @" /F=C:\labels\pn-fw.btw";
                    P.Start();
                }
            }
        }

    }
}
