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

namespace R_T_V
{
    public partial class RTView : Form
    {
        SqlDataAdapter da;
        SqlConnection cnxn;
        SqlCommand cmd;
        SqlDataReader dr;
        private string selection;
        private string BasicSelection;
        DataTable t;


        public RTView()
        {
            InitializeComponent();
        }

        private void RTView_Load(object sender, EventArgs e)
        {
            this.Text = "View Richmond Tool Requests v" + Application.ProductVersion;

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
                //cmd = new SqlCommand(
                // " Select permission, permissionvalue from applicationsetup " +
                // " where application = 'ViewRicToolRequests' and " +
                // " username = '" + user + "' " +
                // " order by permission desc ", cnxn);
                //DataTable table1 = new DataTable();

                //cnxn.Open();

                //dr = cmd.ExecuteReader();
                //table1.Load(dr);


                //if (table1.Rows.Count > 0)
                //{
                //    g.permission = "EDIT";
                //}
                //else
                //{
                //    MessageBox.Show("This user " + user + " has read only permission to use this program: ViewRicToolRequests.exe");
                //    g.permission = "VIEW";
                //}


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
                 "select distinct id from Ric.tool_requests " +
                 "order by id", cnxn);

            cnxn.Open();

            dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(dr);
            cbddRequest.DataSource = dt;
            cbddRequest.DisplayMember = "id";


            //Project
            cmd = new SqlCommand
                ("select ' ' as Project union " +
                 "select distinct project from Ric.tool_requests " +
                 "order by Project", cnxn);

            dr = cmd.ExecuteReader();

            dt = new DataTable();
            dt.Load(dr);
            cbddProject.DataSource = dt;
            cbddProject.DisplayMember = "project";

            //Part
            cmd = new SqlCommand
                ("select ' ' as part union " +
                 "select distinct part from Ric.tool_requests " +
                 "order by part", cnxn);

            dr = cmd.ExecuteReader();

            dt = new DataTable();
            dt.Load(dr);
            cbddPart.DataSource = dt;
            cbddPart.DisplayMember = "part";

            //Customer
            cmd = new SqlCommand
                ("select ' ' as customer union " +
                 "select distinct customer from Ric.tool_requests " +
                 "order by customer", cnxn);

            dr = cmd.ExecuteReader();

            dt = new DataTable();
            dt.Load(dr);
            cbddCustomer.DataSource = dt;
            cbddCustomer.DisplayMember = "customer";

            //Requested By
            cmd = new SqlCommand("select ' ' as requestor union all " +
                "select distinct requestor from Ric.tool_requests " +
                " order by requestor", cnxn);
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            cbddRequestedBy.DataSource = dt;
            cbddRequestedBy.DisplayMember = "requestor";

            selection = " 'one' = 'one' ";

            GridData();

            LrecordCount.Text = "RECORD COUNT: " + (DGV.RowCount - 1).ToString();

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

            if (cbddProject.SelectedIndex > 0)
            {
                selection += " and project = '" + cbddProject.Text.Trim() + "' ";
            }

            if (cbddPart.SelectedIndex > 0)
            {
                selection += " and part = '" + cbddPart.Text.Trim() + "' ";
            }

            if (cbddCustomer.SelectedIndex > 0)
            {
                selection += " and Customer = '" + cbddCustomer.Text.Trim() + "' ";
            }

            if (cbddDepartment.SelectedIndex > 0)
            {
                selection += " and Department = '" + cbddDepartment.Text.Trim() + "' ";
            }


            if (cbddRequestedBy.SelectedIndex > 0)
            {
                selection += " and requestor = '" + cbddRequestedBy.Text.Trim() + "' ";
            }

            if (cbddStatus.SelectedIndex > 0)
            {
                if (cbddStatus.SelectedIndex == 1)
                {
                    selection += " and request_completed = 1 ORDER BY REQUEST_NEED_DATE DESC ";
                }
                else
                {
                    selection += " and request_completed = 0 " +
                        "or request_completed is null ORDER BY REQUEST_NEED_DATE DESC ";
                }
            }
            else
            {
                selection += " ORDER BY REQUEST_NEED_DATE DESC ";
            }

            GridData();
        }

        private void GridData()
        {
            cnxn = new SqlConnection(g.db);

            BasicSelection = "Select " +
                " ID " +
                ",Customer " +
                ",COALESCE(PROJECT,'') Project " +
                ",Part " +
                ",TRIM(Project_Charge_Number) [Project Charge Number]" +
                ",Department " +
                ",Requestor " +
                ",TRIM([Status]) [Status] " +
                ",[Estimated Fab Time (hrs)] " +
                ",Priority " +
                ",FORMAT([Estimated Due Date], 'MM/dd/yy') [Estimated Due Date] " +
                ",[Estimated Design Time (hrs)] " +
                ",TRIM(Job) Job " +
                ",[Code] " +
                ",[Number] " +
                ",ToolDescription [Tool Description] " +
                ",Quantity " +
                ",FORMAT(Request_Date, 'MM/dd/yy') [Request Date] " +
                ",FORMAT(Request_Need_Date, 'MM/dd/yy') [Need by Date] " +
                ",Designer [Dsnr] " +
                ",Machinist [Mach] " +
                ",FORMAT(Completion_Date, 'MM/dd/yy') [Cmpltd Date] " +
                ",ExistingTool4Modification [Drawing # or path of tool to modify] " +
                ",MachineNumber [Machine #] " +
                ",Request_Text [Tool Requirements] " +
                ",TechnicalContactName [Contact for technical info] " +
                ",AdditionalInformation [Additional Info] " +
                ",Anodized [Part need to be anodized ?] " +
                ",OpticDrawing_Path [Optic Drawing number and path] " +
                ",FocalSurface [surface of optic that will be focused on with this tool] " +
                ",DesignReviewParticipants [list of people for design review] " +
                ",IIF (Uploaded_pdf is null, 'No', 'Yes') [Pdf]  " +
                ",IIF (Uploaded_dxf is null, 'No', 'Yes') [Dxf]  " +
                ",Actual_Hours [Actual Hours] " +
                ",Rejected " +
                "FROM ric.Tool_Requests " +
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

            DGV.Columns[0].Width = 30;
            DGV.Columns[1].Width = 200;
            DGV.Columns[2].Width = 150;
            DGV.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV.Columns[3].Width = 100;
            DGV.Columns[4].Width = 80;
            DGV.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV.Columns[5].Width = 100;
            DGV.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV.Columns[6].Width = 100;
            DGV.Columns[7].Width = 100;
            DGV.Columns[8].Width = 70;
            DGV.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV.Columns[9].Width = 110;
            DGV.Columns[10].Width = 70;
            DGV.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV.Columns[11].Width = 60;
            DGV.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //DGV.Columns[12].Width = 30;
            //DGV.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //DGV.Columns[13].Width = 60;
            //DGV.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //DGV.Columns[14].Width = 50;
            //DGV.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //DGV.Columns[15].Width = 50;
            //DGV.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //DGV.Columns[16].Width = 80;
            //DGV.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //DGV.Columns[17].Width = 50;
            //DGV.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //DGV.Columns[18].Width = 50;
            //DGV.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //DGV.Columns[19].Width = 50;
            //DGV.Columns[20].Width = 300;
            //DGV.Columns[21].Width = 50;
            //DGV.Columns[22].Width = 50;
            /*  DGV_ShortageItem.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    */

            /*  LrecordCount.Text = "RECORD COUNT: " + (DGV.RowCount - 1).ToString();  */

            //            g.PreviousSelection = selection;
            selection = " 'one' = 'one' ";
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

                RTJobData j = new RTJobData();
                j.ShowDialog();

            }
            GridData();
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


                //System.Collections.IEnumerable valueLines;
                //valueLines = t.AsEnumerable()
                //    .Select(row => string.Join(",", row.ItemArray.Select(val => $"\"{val}\"")));

                //lines.AddRange(valueLines);

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
        public static string dbNAV = "server=PA-HOR-AS408; user=navdb_read; password=2018#ameteK;" +
                           "database=ZYGO-NAV-PROD";
        public static string db = "server = ct-mid-sql11; password = Read+Write!; " +
                                  "user = readwrite; database = AccessFrontEnds;";
    }
}
