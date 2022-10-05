using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace ViewToolRequests
{
    public partial class ViewToolRequests : Form
    {
        SqlDataAdapter da;
        SqlConnection cnxn;
        SqlCommand cmd;
        SqlDataReader dr;
        private string selection;
        private string BasicSelection;
        DataTable t;

     
        public ViewToolRequests()
        {
            InitializeComponent();
        }

        private void ViewToolRequests_Load(object sender, EventArgs e)
        {
            this.Text = "View Tool Requests v" + Application.ProductVersion; 

            cnxn = new SqlConnection(g.db);

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

            try
            {
                cmd = new SqlCommand(
                 " Select permission, permissionvalue from applicationsetup " +
                 " where application = 'View Tool Requests' and " +
                 " username = '" + user + "' " +
                 " order by permission desc ", cnxn);
                DataTable table1 = new DataTable();

                cnxn.Open();

                dr = cmd.ExecuteReader();
                table1.Load(dr);


                if (table1.Rows.Count > 0)
                {
                    g.permission = "EDIT";
                }
                else
                {
                    MessageBox.Show("This user " + user + " has read only permission to use this program: View Tool Requests.");
                    g.permission = "VIEW";
                }


            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }


            //Request ID
            cmd = new SqlCommand
                ("select ' ' as id union " +
                 "select distinct id from tool_requests " +
                 "order by id", cnxn);

            cnxn.Open();

            dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(dr);
            cbddRequest.DataSource = dt;
            cbddRequest.DisplayMember = "id";
            
            //Cost Center
            cmd = new SqlCommand
                 ("select ' ' as cost_center union " +
                 "select distinct cost_center from tool_requests " +
                 "order by cost_center", cnxn);
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            cbddCostCenter.DataSource = dt;
            cbddCostCenter.DisplayMember = "cost_center";
            
            //Requested By
            cmd = new SqlCommand("select ' ' as requestor union all " + 
                "select distinct requestor from tool_requests " + 
                " order by requestor", cnxn);
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            cbddRequestedBy.DataSource = dt;
            cbddRequestedBy.DisplayMember = "requestor";

            selection = " 'one' = 'one' ";

            GridData();
        }

        private void bFilter_Click(object sender, EventArgs e)
        {
            if (cbddRequest.SelectedIndex > 0)
            {
                selection += " and id = " + cbddRequest.Text.Trim() + " ";
            }
            
            if (cbddPriority.SelectedIndex > 0)
            {
                selection += " and priority = '" + cbddPriority.Text.Trim() + "' ";
            }

            if (cbddCostCenter.SelectedIndex > 0)
            {
                selection += " and cost_center = '" + cbddCostCenter.Text.Trim() + "' ";
            }

            if (cbddRequestedBy.SelectedIndex > 0)
            {
                selection += " and requestor = '" + cbddRequestedBy.Text.Trim() + "' ";
            }

            if (cbddStatus.SelectedIndex > 0)
            {
                if (cbddStatus.SelectedIndex == 1)
                {
                    selection += " and request_completed = 1 ORDER BY Completion_Date DESC ";
                }
                else
                {
                    selection += " and request_completed = 0 " +
                        "or request_completed is null ORDER BY ID DESC ";
                }
            }
            else
            {
                selection += " ORDER BY ID DESC ";
            }

            GridData();

        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) // && e.ColumnIndex < 5)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.ID = cell.EditedFormattedValue.ToString().Trim();

                JobData j = new JobData();
                j.ShowDialog();
            }
        }

        private void GridData()
        {
            cnxn = new SqlConnection(g.db);

            BasicSelection = "Select ID, " +
                 "Request_Completed [Request Completed], " +
                 "FORMAT(Request_Date, 'MM/dd/yy') [Request Date], " +
                 "Priority, " +
                 "FORMAT(Request_Need_Date, 'MM/dd/yy') [Date Needed], " +
                 "Requestor, " +
                 "COALESCE(PROJECT,'') Project " +
                 ", CASE costcenter " +
                 "  when 1100 then CAST(CostCenter as nchar(4)) " +
                 "  when 5030 then CAST(CostCenter as nchar(4)) " +
                 "  when 7050 then '7050    Instruments' " +
                 "  when 7055 then '7055    Instruments' " +
                 "	else CAST(CostCenter as nchar(4)) + '    ' + BusinessUnit " +
                 " end as [Cost Center], " +
                 "CostCenterDescription [Description], " +
                 "Quantity, " +
                 "Request_Text, " +
                 "IIF (Uploaded_pdf is null, 'No', 'Yes') [Pdf] , " +
                 "IIF (Uploaded_dxf is null, 'No', 'Yes') [Dxf] , " +
                 "FORMAT(Completion_Date,'MM/dd/yy') [Completed Date], " +
                 "Actual_Hours [Actual Hours], " +
                 "Rework_Order_Number [Rework #], " +
                 "[Type], " +
                 "TimeSavingsEstimate [Time Savings Estimate], " +
                 "CostSavingsEstimate [Cost Savings Estimate], " +
                 "RevenueSavingsEstimate [Revenue Savings Estimate], " +
                 "Comments " +
                 ",Savings " +
                 ",Rejected " +
                 "from [tool_requests] h " +
                 "left join expensecostcenters s on " +
                 "h.cost_center = s.costcenter " +
                 "where " +
                 selection;

            cmd = new SqlCommand
                (BasicSelection, cnxn);

            try
            {
                cnxn.Open();
                DataTable table = new DataTable();
                SqlDataReader dr = cmd.ExecuteReader();

                table.Load(dr);
                
                DGV.DataSource = table;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            DGV.Columns[0].Width = 40;
            DGV.Columns[1].Width = 60;
            DGV.Columns[2].Width = 60;
            DGV.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV.Columns[3].Width = 50;
            DGV.Columns[4].Width = 60;
            DGV.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV.Columns[5].Width = 100;
            DGV.Columns[6].Width = 50;
            DGV.Columns[7].Width = 100;
            DGV.Columns[8].Width = 200;
            //DGV.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV.Columns[9].Width = 50;
            DGV.Columns[10].Width = 500;
            //DGV.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV.Columns[11].Width = 30;
            DGV.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV.Columns[12].Width = 30;
            DGV.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV.Columns[13].Width = 60;
            DGV.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV.Columns[14].Width = 50;
            DGV.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV.Columns[15].Width = 50;
            DGV.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DGV.Columns[16].Width = 80;
            DGV.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV.Columns[17].Width = 50;
            DGV.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV.Columns[18].Width = 50;
            DGV.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DGV.Columns[19].Width = 50;
            DGV.Columns[20].Width = 300;
            DGV.Columns[21].Width = 50;
            DGV.Columns[22].Width = 50;
            /*  DGV_ShortageItem.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    */

            LrecordCount.Text = "RECORD COUNT: " + (DGV.RowCount - 1).ToString();

//            g.PreviousSelection = selection;
            selection = " 'one' = 'one' ";
        }

        private void bExport_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(BasicSelection, cnxn);

            try
            {
                SqlDataAdapter da1 = new SqlDataAdapter(BasicSelection, cnxn);
                t = new DataTable();

                da1.Fill(t);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            try
            {
                string filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ToolRequests.csv");

                var lines = new List<string>();

                string[] columnNames = t.Columns
                    .Cast<DataColumn>()
                    .Select(column => column.ColumnName)
                    .ToArray();

                var header = string.Join(",", columnNames.Select(name => $"\"{name}\""));
                lines.Add(header);


                var valueLines = t.AsEnumerable()
                    .Select(row => string.Join(",", row.ItemArray.Select(val => $"\"{val}\"")));

                lines.AddRange(valueLines);

                File.WriteAllLines(filepath, lines);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }
        }
    }


    public static class g
    {
        //public static string site;
        //public static string serial;
        public static string permission;

        public static string ID;
        //public static string model;
        //public static bool RequestEntered2History;
        public static string dbDash = "server = middb01.zygo.com; password = views; " +
                                  "user = views; database = Dashboard;";
        public static string db = "server = ct-mid-sql11; password = Read+Write!; " +
                                  "user = readwrite; database = AccessFrontEnds;";
    }
}
