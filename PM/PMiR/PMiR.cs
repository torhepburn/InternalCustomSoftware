using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PMiR
{
    public partial class PMinitialRequests : Form
    {
        SqlDataAdapter da;
        SqlConnection cnxn;
        private string db = "server = midsql01; password = Read+Write!; " +
                    "user = readwrite; database = PM_2015_A;";
        private string selection;
        private string BasicSelection;
        private string yesTickets;
        private object o;
        private string WorkReferenceNumber;
        private string email;
        private bool SiteAllchangedFlag;

        public PMinitialRequests()
        {
            InitializeComponent();
        }

        private void PMinitialRequests_Load(object sender, EventArgs e)
        {
            System.Security.Principal.WindowsIdentity user;
            user = System.Security.Principal.WindowsIdentity.GetCurrent();

            string logdOn = user.Name.Replace("ZYGOMIS\\", "");

            logdOn = "jhelmus";

            cnxn = new SqlConnection(db);

            SqlCommand cmd = new SqlCommand("select RTRIM(site) from tbl_employees " +
                "where networklogin = '" + logdOn + "'", cnxn);

            cnxn.Open();
            o = cmd.ExecuteScalar();
            cnxn.Close();
            g.site = o.ToString();

            SiteSelection();

            cmd = new SqlCommand("select email from tbl_employees " +
                "where networklogin = '" + logdOn + "'", cnxn);

            cnxn.Open();
            o = cmd.ExecuteScalar();
            cnxn.Close();
            email = o.ToString();
            
            cmd = new SqlCommand("select count(owner_email) from repair_requests " +
                "where owner_email like '%" + email + "%'", cnxn);

            cnxn.Open();
            o = cmd.ExecuteScalar();
            cnxn.Close();
            yesTickets = o.ToString();

            if (yesTickets != "0" )
            {
                selection = "owner_email like '%" + logdOn + "%' ";

                GridData();
            }
            else
            {
                selection = BasicSelection;
                GridData();
            }

            //Equipment ID
            SqlDataAdapter da = new SqlDataAdapter
                ("select ' ' as serial union " +
                "select distinct serial from repair_requests " +
                 "where " + BasicSelection + " order by serial", cnxn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbddEquipment.DataSource = dt;
            cbddEquipment.DisplayMember = "serial";

            //Cost Center
            da = new SqlDataAdapter
                ("select ' ' as cost_center union " +
                "select distinct cost_center from repair_requests " +
                 "where " + BasicSelection + " order by cost_center", cnxn);
            dt = new DataTable();
            da.Fill(dt);
            cbddCostCenter.DataSource = dt;
            cbddCostCenter.DisplayMember = "cost_center";

            //Owner
            da = new SqlDataAdapter
                ("select ' ' as owner_email union " +
                "select distinct owner_email from repair_requests " +
                 "where " + BasicSelection + " order by owner_email", cnxn);
            dt = new DataTable();
            da.Fill(dt);
            cbddOwner.DataSource = dt;
            cbddOwner.DisplayMember = "owner_email";

            //Reported By
            da = new SqlDataAdapter
                ("select ' ' as requestor union " +
                "select distinct requestor from repair_requests " +
                 "where " + BasicSelection + " order by requestor", cnxn);
            dt = new DataTable();
            da.Fill(dt);
            cbddReportedBy.DataSource = dt;
            cbddReportedBy.DisplayMember = "requestor";
        }

        


        private void bFilter_Click(object sender, EventArgs e)
        {
            selection = BasicSelection;

            if (g.site == "ALL" | SiteAllchangedFlag == true)
            {
                if (cbddSite.SelectedIndex > 0)
                {
                    if (cbddSite.Text.Trim() == "Costa Mesa")
                    {
                        g.site = "ZEOS";
                    }
                    else if (cbddSite.Text.Trim() == "Middlefield")
                    {
                        g.site = "ZAMS";
                    }
                    else if (cbddSite.Text.Trim() == "Richmond")
                    {
                        g.site = "ZEP";
                    }
                    else if (cbddSite.Text.Trim() == "Tucson")
                    {
                        g.site = "AZT";
                    }

                    SiteAllchangedFlag = true;
                    SiteSelection();
                    selection = BasicSelection;
                }
                else if (cbddSite.SelectedIndex == 0 & SiteAllchangedFlag == true)
                {
                    SiteAllchangedFlag = false;
                    g.site = "ALL";
                    SiteSelection();
                    selection = BasicSelection;
                }
            }

            
            if (cbddEquipment.SelectedIndex > 0)
            {
                selection += " and serial = '" + cbddEquipment.Text.Trim() + "' ";
            }

            if (cbddSeverity.SelectedIndex > 0)
            {
                selection += " and severity = '" + cbddSeverity.Text.Trim() + "' ";
            }

            if (cbddCategory.SelectedIndex > 0)
            {
                selection += " and category = '" + cbddCategory.Text.Trim() + "' ";
            }

            if (cbddCostCenter.SelectedIndex > 0)
            {
                selection += " and cost_center = '" + cbddCostCenter.Text.Trim() + "' ";
            }

            if (cbddOwner.SelectedIndex > 0)
            {
                selection += " and owner_email like '%" + cbddOwner.Text.Trim() + "%' ";
            }

            
            if (cbddReportedBy.SelectedIndex > 0)
            {
                selection += " and requestor = '" + cbddReportedBy.Text.Trim() + "' ";
            }
            
            GridData();
         }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 5)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.ID = cell.EditedFormattedValue.ToString().Trim();

               //**1) Add to REPAIR HISTORY

                cnxn = new SqlConnection(g.db);
                SqlCommand cmd = new SqlCommand
                ("select CONVERT(nvarchar(4), GetDate(), 12) + '0' + " +
                 "CONVERT(nvarchar(3),(select count(serial) from [REPAIR HISTORY] " + 
                 "where TROUBLE_work_reference_number like " +
                 "CONVERT(nvarchar(4), GetDate(), 12) + '%' ) + 1)", cnxn);
                cnxn.Open();
                object a = cmd.ExecuteScalar();
                WorkReferenceNumber = a.ToString().Trim();
                cnxn.Close();
               
                cmd = new SqlCommand(
                    "INSERT INTO [REPAIR HISTORY] ( " +
                    "[SERIAL], " +
                    "[ITEM], " +
                    "[TROUBLE_REPAIR_CATEGORY], " +
                    "[TROUBLE_COST_CENTER], " +
                    "[TROUBLE_PROJECT], " +
                    "Serial_Web_Entered, " +
                    "[TROUBLE_RPTD_SUBJECT], " +
                    "[TROUBLE_RPTD_PHONE], " +
                    "[TROUBLE_RPTD_BY], " +
                    "[PlannedHours], " +
                    "[TROUBLE_RPTD_EMAIL], " +
                    "[TROUBLE_RPTD_DATE], " +
                    "TROUBLE, " +
                    "TROUBLE_SEVERITY," +
                    "[TROUBLE_work_reference_number], " +
                    "TROUBLE_SUPERVISOR_SUBMITTER," +
                    "[TROUBLE_SUPERVISOR_SUBMITTER_EMAIL], " +
                    "[TROUBLE_unique_reference_number], " +
                    "RequestUID ) " +
                    " SELECT " +
                    "[SERIAL], " +
                    "[PM_ITEM], " +
                    "[CATEGORY], " +
                    "[COST_CENTER], " +
                    "[PROJECT], " +
                    "Serial, " +
                    "[SUBJECT_LINE], " +
                    "[REQUESTOR_PHONE], " +
                    "[REQUESTOR], " +
                    "[PlannedHours], " +
                    "[REQUESTOR_EMAIL], " +
                    "[REQUEST_DATE], " +
                    "TROUBLE, " +
                    "[SEVERITY], " +
                    "'" + WorkReferenceNumber + "'," +
                    "REQUESTOR_SUPERVISOR, " +
                    "[REQUESTOR_SUPERVISOR_EMAIL], " +
                    "[UID]," +
                    "ID " +
                    " FROM [REPAIR_REQUESTS]" +
                    " WHERE [ID]='" + g.ID + "'", cnxn);

                cnxn.Open();
                try
                {
                    int rowsReturned = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                cnxn.Close();
    
                //**2) DELETE from REPAIR_REQUESTS
                cmd = new SqlCommand("DELETE " +
                    "FROM REPAIR_REQUESTS " +
                    "WHERE ID='" + g.ID + "'", cnxn);

                cnxn.Open();
                try
                {
                    int rowsReturned = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                cnxn.Close();

                DialogResult dResult = MessageBox.Show("Record added to Repair History \n\n " +
                    "Open Trouble Ticket ?", "Open Trouble Ticket", MessageBoxButtons.YesNo);
                if (dResult == DialogResult.Yes)
                {
                    WorkRequestForm w = new WorkRequestForm();
                    w.ShowDialog();
                }
                
                selection = g.PreviousSelection;
                GridData();
            }
        }

        private void GridData()
        {
            cnxn = new SqlConnection(db);

            da = new SqlDataAdapter
                ("Select id, " +
                 "category Category, " +
                 "severity Severity, " +
                 "request_date [Date Reported], " +
                 "serial 'Equipment ID', " +
                 "trouble Task, " +
                 "requestor [Reported By] " +
                 "from [repair_requests] h " +
                 "where " +
                 selection +
                 " order by serial", cnxn);

            try
            {
                DataTable table = new DataTable();
                da.Fill(table);
                DGV.DataSource = table;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            DGV.Columns[0].Visible = false;
            DGV.Columns[1].Width = 125;
            DGV.Columns[2].Width = 50;
            DGV.Columns[3].Width = 110;
            DGV.Columns[4].Width = 250;
            DGV.Columns[5].Width = 350;
            DGV.Columns[6].Width = 150;

            LrecordCount.Text = "RECORD COUNT: " + (DGV.RowCount -1).ToString();

            g.PreviousSelection = selection;
            selection = "";
        }

        private void SiteSelection()
        {
            if (g.site == "ZEOS")
            {
                BasicSelection = "serial like 'CM%' ";
            }
            else if (g.site == "AZT")
            {
                BasicSelection = "serial like 'TU%' ";
            }
            else if (g.site == "ZEP")
            {
                BasicSelection = "serial like 'RI%' ";
            }
            else if (g.site == "ALL")
            {
                Lsite.Visible = true;
                cbddSite.Visible = true;
                BasicSelection = " 'one' = 'one' ";
            }
            else
            {
                BasicSelection = "serial not like 'CM%' and " +
                                 "serial not like 'TU%' and " +
                                 "serial not like 'RI%'  ";
            }

        }
    }
    
    public static class g
    {
        public static string site;
        public static string serial;
        public static string taskgroup;

        public static string ID;
        public static string model;
        public static bool RequestEntered2History; 
        public static string PreviousSelection;
        public static string db = "server = midsql01; password = Read+Write!; " +
                                  "user = readwrite; database = PM_2015_A;";
    }
}
