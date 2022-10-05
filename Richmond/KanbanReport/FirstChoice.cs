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

namespace KanbanReport
{
    public partial class FirstChoice : Form
    {
        private string[] plannerinitials = new string[20000];
        private string[] customer = new string[20000];
        private string[] project = new string[20000];
        private string[] elementname = new string[20000];
        private string[] elementWrap = new string[20000];
        private string[] itemcode = new string[20000];
        private string[] kblocation = new string[20000];
        private string[] locationWrap = new string[20000];
        private string[] WIP = new string[20000];
        private string[] INV = new string[20000];
        private string[] total = new string[20000];
        private string[] min = new string[20000];
        private string[] max = new string[20000];
        private string[] parentitemcode = new string[20];
        private string[] BOMitemcode = new string[20];
        private string[] BOMitem = new string[20];
        private string[] BOMitemWRAP = new string[20];
        private string[] BOMlevel = new string[20];
        private int[] BOMwip = new int[20];
        private int[] BOMinv = new int[20];
        private string[] BOMlocation = new string[20];
        private int kbtotal;

        private int i = 0;
        private int ii = 0;
        private int sourceCount = 1;
        private int pagesPrinted = 0;
        private bool rawPrinted = false;
        private bool finishedPrinted = false;
        private int lineNo = 0;
        SqlCommand cmd;
        SqlConnection cnxn;
        SqlDataReader dr;

        public FirstChoice()
        {
            InitializeComponent();
        }

        private void FirstChoice_Load(object sender, EventArgs e)
        {
            string applicationVersion = Application.ProductVersion.Trim();
            this.Text = "Kanban Report   v" + applicationVersion;
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            KBReport r = new KBReport();
            r.ShowDialog();
        }

        private void bExport_Click(object sender, EventArgs e)
        {  
           /*  old code from OptiTRAK below     */
            
            //File.WriteAllText(@"C:\Kanban_Report\Kanban.csv", "KANBAN REPORT" + Environment.NewLine);

            //cnxn = new SqlConnection(g.db);

            //cmd = new SqlCommand
            //    ("select  " +
            //     "PlannerInitials, " +
            //     "Customer, " +
            //     "Project, " +
            //     "ElementName, " +
            //     "Item_Code, " +
            //     "KB_location, " +
            //     "WIP, " +
            //     "INV, " +
            //     "WIP + INV Total, " +
            //     "KBMin, " +
            //     "KBMax " +
            //     "from KBinventory i left join  " +
            //     "tblJobInfo j " +
            //     "on i.Item_Code = j.PartDrawingNumber + j.PartDrawingRev " +
            //     "left join tblPlanner p " +
            //     "on j.PlannerID = p.PlannerID " +
            //     "left join tblkanban k " +
            //     "on k.KBLocationName = KB_location and k.JobID = j.JobID " +
            //     "where JobComplete = 0 " +
            //     "order by PlannerInitials,Item_Code, KB_sequence", cnxn);

            //cnxn.Open();

            //dr = cmd.ExecuteReader();


            //while (dr.Read())
            //{
            //    try
            //    {
            //        if (!dr.IsDBNull(0)) { plannerinitials[i] = dr.GetString(0).Trim(); }
            //        if (!dr.IsDBNull(1)) { customer[i] = dr.GetString(1).Trim(); }
            //        if (!dr.IsDBNull(2)) { project[i] = dr.GetString(2).Trim(); }

            //        if (!dr.IsDBNull(4)) { itemcode[i] = dr.GetString(4).Trim(); }
            //        if (!dr.IsDBNull(5)) { kblocation[i] = dr.GetString(5).Trim(); }
            //        if (!dr.IsDBNull(6)) { WIP[i] = dr.GetInt32(6).ToString(); }
            //        if (!dr.IsDBNull(7)) { INV[i] = dr.GetInt32(7).ToString(); }
            //        if (!dr.IsDBNull(8)) { total[i] = dr.GetInt32(8).ToString(); }
            //        if (!dr.IsDBNull(9)) { min[i] = dr.GetInt32(9).ToString(); }
            //        if (!dr.IsDBNull(10)) { max[i] = dr.GetInt32(10).ToString(); }

            //        //word wrap Element
            //        if (!dr.IsDBNull(3))
            //        {
            //            if (dr.GetString(3).Length > 20)
            //            {
            //                int lastword = dr.GetString(3).Substring(0, 20).LastIndexOf(" ");
            //                elementname[i] = dr.GetString(3).Substring(0, lastword);
            //                elementWrap[i] = dr.GetString(3).Substring(lastword + 1, dr.GetString(3).Length - (lastword + 1));
            //            }
            //            else
            //            {
            //                elementname[i] = dr.GetString(3).Trim();
            //                elementWrap[i] = "N";
            //            }
            //        }
            //        i++;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.ToString());
            //    }
            //}
            //cnxn.Close();


            //string date = DateTime.Now.ToString();
            //int count = 0;
            ///*   int linesPerpage = 40;
            //   //int lineNo = this.pagesPrinted * linesPerpage;
            //   int pageNo = pagesPrinted + 1;
            //   double NumPages = Math.Ceiling(((i - 1) / 24.0));
            //   string penflag = "BK";
            //   Pen pen = new Pen(Color.Red);
            //   Pen Gpen = new Pen(Color.Green);
            //   Gpen.Width = 3;
            //   pen.Width = 1;
            //   Font arial = new Font("arial", 9, FontStyle.Regular);
            //   Font title = new Font("arial", 16, FontStyle.Bold);
            //   Font heading = new Font("arial", 9, FontStyle.Bold);
            //   Font leaders = new Font("arial", 9, FontStyle.Bold);
            //   */

            //File.AppendAllText(@"C:\Kanban_Report\Kanban.csv",

            //"Planner," +
            //"Custome," +
            //"Project," +
            //"Element," +
            //"Part Number," +
            //"Kanban Location," +
            //"WIP," +
            //"Inv," +
            //"Total," +
            //"Min," +
            //"Max" + Environment.NewLine);

            //while (count < i)
            //{
            //    if (rawPrinted == false)
            //    {
            //        File.AppendAllText(@"C:\Kanban_Report\Kanban.csv", Environment.NewLine);

            //        cmd = new SqlCommand
            //        ("select " +
            //        "ITEM_CODE, " +
            //        "REPLACE(ITEM_DESC, ',' , ' ') item_desc, " +
            //        "'Raw Material' KanbanLocation, " +
            //        "STOCK_ON_ORDER WIP, " +
            //        "STOCK_ON_HAND Inv " +
            //        "from AccessFrontEnds.dbo.MMX_BOM_IND_BILL " +
            //        "where BEGIN_ITEM_CODE = '" + itemcode[lineNo] + "' " +
            //        "and BOM_LEVEL = 1 " +
            //        "order by BEGIN_ITEM_CODE, BOM_LEVEL", cnxn);

            //        cnxn.Open();

            //        //using MMX_BOM_IND_BILL right now but Bill D says it is updated only once a day.
            //        //could use MMX_ITEM_DATA_BY_WAREHOUSE for more up to date data

            //        dr = cmd.ExecuteReader();

            //        while (dr.Read())
            //        {
            //            try
            //            {
            //                if (!dr.IsDBNull(0)) { BOMitemcode[0] = dr.GetString(0).Trim(); }

            //                //word wrap BOM item
            //                if (!dr.IsDBNull(1))
            //                {
            //                    if (dr.GetString(1).Length > 20)
            //                    {
            //                        int lastword = dr.GetString(1).Substring(0, 20).LastIndexOf(" ");
            //                        BOMitem[0] = dr.GetString(1).Substring(0, lastword);
            //                        BOMitemWRAP[0] = dr.GetString(1).Substring(lastword + 1, dr.GetString(1).Length - (lastword + 1));
            //                    }
            //                    else
            //                    {
            //                        BOMitem[0] = dr.GetString(1).Trim();
            //                        BOMitemWRAP[0] = "N";
            //                    }
            //                }
            //                //if (!dr.IsDBNull(2)) { BOMlocation[0] = dr.GetString(2).Trim(); }
            //                if (!dr.IsDBNull(3)) { BOMwip[0] = dr.GetInt32(3); }
            //                if (!dr.IsDBNull(4)) { BOMinv[0] = dr.GetInt32(4); }
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show(ex.ToString());
            //            }
            //        }
            //        cnxn.Close();

            //        File.AppendAllText(@"C:\Kanban_Report\Kanban.csv", plannerinitials[lineNo] + "," +
            //            customer[lineNo] + "," +
            //            project[lineNo] + "," +
            //            BOMitem[0] + ",");
            //        /*
            //            if (BOMitemWRAP[0] != "N")
            //            {
            //                File.AppendAllText(@"C:\Kanban_Report\Kanban.csv", BOMitemWRAP[0] + ",";
            //            }
            //            */
            //        File.AppendAllText(@"C:\Kanban_Report\Kanban.csv", BOMitemcode[0] + "," +
            //        "Raw Material, " +
            //         BOMwip[0].ToString() + ",");

            //        File.AppendAllText(@"C:\Kanban_Report\Kanban.csv", BOMinv[0].ToString() + ",");

            //        File.AppendAllText(@"C:\Kanban_Report\Kanban.csv", (BOMwip[0] + BOMinv[0]).ToString() + "," +

            //            min[lineNo] + "," +
            //            max[lineNo] + Environment.NewLine);
            //        count++;
            //        lineNo++;

            //        rawPrinted = true;
            //    }
            //    else     //if raw printed == true
            //    {
            //        if (kblocation[lineNo] != "Raw Material")
            //        {
            //            File.AppendAllText(@"C:\Kanban_Report\Kanban.csv",
            //                plannerinitials[lineNo] + "," +
            //                elementname[lineNo] + "," +
            //                customer[lineNo] + "," +
            //                project[lineNo] + "," +
            //                itemcode[lineNo] + "," +
            //                kblocation[lineNo] + ",");

            //            if (kblocation[lineNo] != "Finished Goods")
            //            {
            //                File.AppendAllText(@"C:\Kanban_Report\Kanban.csv", WIP[lineNo] + ",");
            //                File.AppendAllText(@"C:\Kanban_Report\Kanban.csv", INV[lineNo] + ",");
            //                File.AppendAllText(@"C:\Kanban_Report\Kanban.csv", total[lineNo] + ",");

            //                File.AppendAllText(@"C:\Kanban_Report\Kanban.csv",
            //                    min[lineNo] + "," +
            //                    max[lineNo] + Environment.NewLine);
            //                count++;
            //                lineNo++;
            //            }
            //            else
            //            {
            //                string MRRinv = "0";

            //                cnxn.Open();

            //                cmd = new SqlCommand
            //                    ("SELECT STOCK_ON_HAND FROM AccessFrontEnds.dbo.MMX_ITEM_DATA_BY_WAREHOUSE " +
            //                     "WHERE warehouse = 'MRR' AND item_code = '" + itemcode[lineNo] + "' ", cnxn);
            //                try
            //                {
            //                    object o = cmd.ExecuteScalar();
            //                    if (o == null)
            //                    {
            //                        MRRinv = "0";
            //                    }
            //                    else
            //                    {
            //                        MRRinv = o.ToString();
            //                    }
            //                }
            //                catch (Exception ex)
            //                {
            //                    MessageBox.Show(ex.ToString());
            //                }
            //                finally
            //                {
            //                    cnxn.Close();
            //                }

            //                cnxn.Open();

            //                cmd = new SqlCommand
            //                    ("SELECT SUM(STOCK_ON_HAND) FROM AccessFrontEnds.dbo.MMX_ITEM_DATA_BY_WAREHOUSE " +
            //                     "WHERE warehouse != 'MRR' AND item_code = '" + itemcode[lineNo] + "' ", cnxn);
            //                try
            //                {
            //                    BOMinv[0] = Convert.ToInt32(cmd.ExecuteScalar());
            //                }
            //                catch (Exception ex)
            //                {
            //                    MessageBox.Show(ex.ToString());
            //                }
            //                finally
            //                {
            //                    cnxn.Close();
            //                }



            //                //totals need to be step total plus inventory
            //                File.AppendAllText(@"C:\Kanban_Report\Kanban.csv", WIP[lineNo] + ",");
            //                File.AppendAllText(@"C:\Kanban_Report\Kanban.csv", INV[lineNo] + ",");

            //                File.AppendAllText(@"C:\Kanban_Report\Kanban.csv", (BOMinv[0] + Convert.ToInt32(total[lineNo])).ToString() + ",");

            //                File.AppendAllText(@"C:\Kanban_Report\Kanban.csv", min[lineNo] + "," +
            //                max[lineNo] + Environment.NewLine);
            //                count++;
            //                lineNo++;

            //                File.AppendAllText(@"C:\Kanban_Report\Kanban.csv", ",,,,,,,MRR," +
            //                MRRinv + Environment.NewLine);
            //                count++;
            //                lineNo++;

            //            }





            //        }
            //        /*
            //        if (itemcode[lineNo] != itemcode[lineNo + 1] && finishedPrinted == false)
            //        {
            //            string MRRinv = "0";

            //            cnxn.Open();

            //            cmd = new SqlCommand
            //                ("SELECT STOCK_ON_HAND FROM AccessFrontEnds.dbo.MMX_ITEM_DATA_BY_WAREHOUSE " +
            //                 "WHERE warehouse = 'MRR' AND item_code = '" + itemcode[lineNo] + "' ", cnxn);
            //            try
            //            {
            //                object o = cmd.ExecuteScalar();
            //                if (o == null)
            //                {
            //                    MRRinv = "0";
            //                }
            //                else
            //                {
            //                    MRRinv = o.ToString();
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show(ex.ToString());
            //            }
            //            finally
            //            {
            //                cnxn.Close();
            //            }

            //            cnxn.Open();

            //            cmd = new SqlCommand
            //                ("SELECT SUM(STOCK_ON_HAND) FROM AccessFrontEnds.dbo.MMX_ITEM_DATA_BY_WAREHOUSE " +
            //                 "WHERE warehouse != 'MRR' AND item_code = '" + itemcode[lineNo] + "' ", cnxn);
            //            try
            //            {
            //                BOMinv[0] = Convert.ToInt32(cmd.ExecuteScalar());
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show(ex.ToString());
            //            }
            //            finally
            //            {
            //                cnxn.Close();
            //            }


            //            //ev.Graphics.DrawString(BOMwip[0].ToString(), arial, Brushes.Black, 800, linedrop);

            //            //conditional color formatting

            //            //File.AppendAllText(@"C:\Kanban_Report\Kanban.csv", BOMinv[0].ToString() + "," );


            //            //totals need to be step total plus inventory
            //            File.AppendAllText(@"C:\Kanban_Report\Kanban.csv", WIP[lineNo] + ",");
            //            File.AppendAllText(@"C:\Kanban_Report\Kanban.csv", INV[lineNo] + ",");
                        
            //            File.AppendAllText(@"C:\Kanban_Report\Kanban.csv",(BOMinv[0] + Convert.ToInt32(total[lineNo])).ToString() + ",");

            //            File.AppendAllText(@"C:\Kanban_Report\Kanban.csv", min[lineNo] + "," +
            //            max[lineNo] + Environment.NewLine);
            //            count++;
            //            lineNo++;

            //            File.AppendAllText(@"C:\Kanban_Report\Kanban.csv",",,,,,,,MRR," +
            //            MRRinv + Environment.NewLine );
            //            count++;
            //            lineNo++;


            //            finishedPrinted = true;
            //        }*/

            //        if (itemcode[lineNo] != itemcode[lineNo + 1] && finishedPrinted == true)
            //        {
            //            rawPrinted = false;
            //            finishedPrinted = false;
            //        }

            //    }
            //}

            //this.Close();

        }
    }
}
