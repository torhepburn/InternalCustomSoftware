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


namespace BOMRoutings
{
    public partial class Routing : Form
    {
        SqlConnection cnxn = new SqlConnection(g.db);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable table;
        DataTable table1;
        DataTable table2;
        private string SQL1 = string.Empty;
        private decimal totalCurrentSetupTime = 0;
        private decimal totalCurrentRunTime = 0;

        public Routing()
        {
            InitializeComponent();
        }

        private void Routing_Load(object sender, EventArgs e)
        {
            try
            {
                cnxn.Open();
                da = new SqlDataAdapter(
                    "SELECT " +
                    " [Operation No_] OP " +
                    ",[Work Center No_] WC " +
                    ",[Description] " +
                    ",FORMAT([Setup Time], 'N3') [Setup Time] " +
                    ",FORMAT([Run Time], 'N3') [Run Time]" +
                    " FROM [" + g.NAVprefix + "Routing Line] " +
                    " WHERE [Routing No_] = '" + g.routingNumber + "' " +
                    " AND [Version Code] = 01 ORDER BY [Operation No_]", cnxn);
                table = new DataTable();
                table1 = new DataTable();
                da.Fill(table);
                da.Fill(table1);

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Routing Detail Page " + ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            
            try
            {
                cnxn.Open();
                da = new SqlDataAdapter(
                    "SELECT " +
                    " FORMAT(SUM([Setup Time]), 'N3')" +
                    ",FORMAT(SUM([Run Time]), 'N3')" +
                    " FROM [" + g.NAVprefix + "Routing Line] " +
                    " WHERE [Routing No_] = '" + g.routingNumber + "' " +
                    " AND [Version Code] = 01 "
                    , cnxn);
                table2 = new DataTable();
                da.Fill(table2);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Routing Detail Page " + ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }


            LcurrentSetupTime.Text = "Total Setup Time (hours): " + table2.Rows[0][0].ToString();
            totalCurrentSetupTime = Convert.ToDecimal(table2.Rows[0][0].ToString());
            LcurrentRunTime.Text = "Total Run Time (hours): " + table2.Rows[0][1].ToString();
            totalCurrentRunTime = Convert.ToDecimal(table2.Rows[0][1].ToString());
            LproposedSetupTime.Text = "Total Proposed Setup Time (hours): " + table2.Rows[0][0].ToString();
            g.totalSetupTime = Convert.ToDecimal(table2.Rows[0][0].ToString());
            LproposedRunTime.Text = "Total Proposed Run Time (hours): " + table2.Rows[0][1].ToString();
            g.totalRunTime = Convert.ToDecimal(table2.Rows[0][1].ToString());

            DGV.DataSource = table;
            DGV.Show();
            DGV.Columns[0].Width = 45;
            DGV.Columns[1].Width = 40;
            DGV.Columns[2].Width = 180;
            DGV.Columns[3].Width = 50;
            DGV.Columns[4].Width = 50;

            RefreshGrid2();

        }

        private void DGVright_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 2)
            {
                return;
            }
            else
            {
                g.rRowIndex = e.RowIndex;

                if (e.ColumnIndex == 1)
                {
                    WorkCenters w = new WorkCenters();
                    w.ShowDialog();

                    table1.Rows[g.rRowIndex][1] = g.workCenter;
                    table1.Rows[g.rRowIndex][2] = g.workCenterDescription;

                    DGVright.CurrentCell = DGVright.Rows[g.rRowIndex].Cells[2];

                    RefreshGrid2();
                }

                /*  click on operation then either add or delete row with button action   */

                if (e.ColumnIndex == 0)
                {
                    BAddOp.Enabled = true;
                    BDeleteOp.Enabled = true;
                    g.modifyOperation = true;

                }


                if (e.ColumnIndex == 3)
                {
                    if (table1.Rows[g.rRowIndex][3].ToString().Length > 0)
                    {
                        g.currentTime = Convert.ToDecimal(table1.Rows[g.rRowIndex][3].ToString());
                    }
                    else
                    {
                        g.currentTime = Convert.ToDecimal("0");
                    }

                    Time t = new Time();
                    t.ShowDialog();

                    table1.Rows[g.rRowIndex][3] = g.newTime;
                    g.totalSetupTime = (g.totalSetupTime - g.currentTime) + g.newTime;
                    LproposedSetupTime.Text = "Total Proposed Setup Time (hours): " + g.totalSetupTime.ToString();
                    if (totalCurrentSetupTime != g.totalSetupTime)
                    {
                        DGVright.BackgroundColor = Color.FromArgb(240, 100, 100);
                        LRoutingTimesDiffer.Visible = true;
                    }
                    else
                    {
                        DGVright.BackgroundColor = Color.FromArgb(240, 210, 100);
                        LRoutingTimesDiffer.Visible = false;
                    }
                }

                if (e.ColumnIndex == 4)
                {
                    if (table1.Rows[g.rRowIndex][4].ToString().Length > 0)
                    {
                        g.currentTime = Convert.ToDecimal(table1.Rows[g.rRowIndex][4].ToString());
                    }
                    else
                    {
                        g.currentTime = Convert.ToDecimal("0");
                    }
                    
                    Time t = new Time();
                    t.ShowDialog();

                    table1.Rows[g.rRowIndex][4] = g.newTime;
                    g.totalRunTime = (g.totalRunTime - g.currentTime) + g.newTime;
                    LproposedRunTime.Text = "Total Proposed Run Time (hours): " + g.totalRunTime.ToString();

                    if (totalCurrentRunTime != g.totalRunTime)
                    {
                        DGVright.BackgroundColor = Color.FromArgb(240, 100, 100);
                        LRoutingTimesDiffer.Visible = true;
                    }
                    else
                    {
                        DGVright.BackgroundColor = Color.FromArgb(240, 210, 100);
                        LRoutingTimesDiffer.Visible = false;
                    }
                }
            }
            }

        private void RefreshGrid2()
        {
            DGVright.DataSource = table1;
            DGVright.Show();
            DGVright.Columns[0].Width = 45;
            DGVright.Columns[1].Width = 40;
            DGVright.Columns[2].Width = 180;
            DGVright.Columns[3].Width = 50;
            DGVright.Columns[4].Width = 50;

        }

        private void BaddOp_Click(object sender, EventArgs e)
        {
            if (g.modifyOperation)
            {
                int start = g.rRowIndex;

                DataRow row = table1.NewRow();
                table1.Rows.InsertAt(row, g.rRowIndex);

                RefreshGrid2();

                g.modifyOperation = false;
                BAddOp.Enabled = false;
            }
            
        }

        private void BdeleteOp_Click(object sender, EventArgs e)
        {
            if (g.modifyOperation)
            {
                int start = g.rRowIndex;

                table1.Rows.RemoveAt(g.rRowIndex);

                RefreshGrid2();

                g.modifyOperation = false;
                BDeleteOp.Enabled = false;
            }
        }
    }
}
