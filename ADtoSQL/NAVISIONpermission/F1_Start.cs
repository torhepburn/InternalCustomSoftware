using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Management.Automation;

namespace NAVISIONpermission
{
    public partial class F1_Start : Form
    {
        public string selectedRole = "";
        public string selectedUserName = "";
        public string selectedADGroup = "";
        public string selectedObjectType = "";
        public string selection = "";


        SqlDataReader dr;
        SqlConnection cnxn;
        SqlConnection cnxnNAV;
        DataTable table;
        DataTable dtRole;
        DataTable dtUserName;
        DataTable dtADGroup;
        SqlCommand cmd;


        public F1_Start()
        {
            InitializeComponent();
        }

        private void F1_Start_Load(object sender, EventArgs e)
        {
            this.Text = "NAVISION Permission Audit v" + Application.ProductVersion;
            WindowState = FormWindowState.Maximized;

            cnxn = new SqlConnection(g.db);

            // Role ID

            cmd = new SqlCommand("SELECT '' [RoleID] UNION ALL " +
                                 "select DISTINCT [Role ID] RoleID from [NAV AD Group to Permission] " +
                                 "order by [RoleID]", cnxn);

            dtRole = new DataTable();

            try
            {
                cnxn.Open();
                dr = cmd.ExecuteReader();

                dtRole.Load(dr);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            cbddRole.DataSource = dtRole;
            cbddRole.DisplayMember = "RoleID";
            cbddRole.ValueMember = "RoleID";

            // AD Group

            cmd = new SqlCommand("SELECT '' [AD Group] UNION ALL " +
                                 "select DISTINCT [GroupName] [AD Group] from NAV_User_Group_Mapping " +
                                 "order by [AD Group]", cnxn);

            dtADGroup = new DataTable();

            try
            {
                cnxn.Open();
                dr = cmd.ExecuteReader();

                dtADGroup.Load(dr);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            cbddADGroup.DataSource = dtADGroup;
            cbddADGroup.DisplayMember = "AD Group";
            cbddADGroup.ValueMember = "AD Group";

            // User

            cmd = new SqlCommand("SELECT '' [User] UNION ALL " +
                                 "select DISTINCT [UserName] [User] from NAV_User_Group_Mapping " +
                                 "order by [User]", cnxn);

            dtUserName = new DataTable();

            try
            {
                cnxn.Open();
                dr = cmd.ExecuteReader();

                dtUserName.Load(dr);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            cbddUser.DataSource = dtUserName;
            cbddUser.DisplayMember = "User";
            cbddUser.ValueMember = "User";

            GetData();

        }
        private void GetData()
        {
            string SQL =
                "SELECT " +
                " * " +

                ////",[DateEntered] [DateEntered] " +
                " FROM [NAV_User_Permissions]";




            if (selection.Length > 0)
            {
                SQL += selection + " ORDER BY UserName";
            }
            else
            {
                SQL += " ORDER BY [Role ID]";
            }

            cmd = new SqlCommand(SQL, cnxn);
            table = new DataTable();

            try
            {
                cnxn.Open();
                dr = cmd.ExecuteReader();

                table.Load(dr);
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
            DGV.Columns[0].Width = 250;
            DGV.Columns[1].Width = 300;
            DGV.Columns[2].Width = 150;
            //DGV.Columns[3].Width = 60;
            //DGV.Columns[4].Width = 60;
            DGV.Columns[5].Width = 200;
            //DGV.Columns[6].Width = 80;
            //DGV.Columns[7].Width = 80;
            //DGV.Columns[8].Width = 150;
            //DGV.Columns[9].Width = 350;
            //DGV.Columns[10].Width = 250;
            //DGV.Columns[11].Width = 200;

            DGV.Show();


        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            selection = "WHERE 1=1 ";
            selectFilter();
            GetData();
        }

        private void selectFilter()
        {
            if (selectedRole.Length > 0)
            {
                selection += " and [Role ID] = '" + selectedRole + "' ";
            }

            if (selectedADGroup.Length > 0)
            {
                selection += " and [AD Group Name] = '" + selectedADGroup + "' ";
            }

            if (selectedUserName.Length > 0)
            {
                selection += " and [UserName] = '" + selectedUserName + "' ";
            }

            if (selectedObjectType.Length > 0)
            {
                selection += " and [Object Type] = '" + selectedObjectType + "' ";
            }
        }


        private void bUpdate_Click(object sender, EventArgs e)
        {
            string groupUserName;
            string groupFullName;

            cnxn = new SqlConnection(g.db);

            try
            {
                cnxn.Open();

                cmd = new SqlCommand("TRUNCATE TABLE [AccessFrontEnds].[dbo].[NAV_User_Group_Mapping] ", cnxn);

                int nn = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            finally
            {
                cnxn.Close();
            }


            try
            {
                /* first get the active AD groups from the NAV tables */

                cnxnNAV = new SqlConnection(g.dbNAV);

                cnxnNAV.Open();

                cmd = new SqlCommand(
                    "select " +
                    "REPLACE([User Name], 'AMETEK-AD\\','') UserName " +
                    ", [Full Name] " +
                    "from[User] " +
                    "WHERE[User Name] like '%-GG-%' " +
                    "AND[User Name] NOT LIKE '%BROOK%' " +
                    "AND[User Name] NOT LIKE '%RICH%' " +
                    "AND [State] = 0", cnxnNAV);

                dr = cmd.ExecuteReader();

                /*  then use power shell to get the member names of the AD groups    */

                while (dr.Read())
                {
                    groupUserName = dr.GetString(0).Trim();
                    groupFullName = dr.GetString(1).Trim();

                    using (PowerShell ps = PowerShell.Create())
                    {
                        ps.AddCommand("Get-ADGroupMember");
                        ps.AddParameter("-Identity", groupUserName);

                        var results = ps.Invoke();

                        foreach (var result in results)
                        {
                            string user;
                            string name = result.BaseObject.ToString();

                            /*  some employees stay in the table for a period of time labeled as Disabled even if they have left the company   */

                            if (name.IndexOf("Disabled") == -1)
                            {
                                user = name.Substring(3, (name.IndexOf(",") - 3));
                            }
                            else
                            {
                                user = name.Substring(3, (name.IndexOf(",") - 3)) + " : Disabled";
                            }

                            /*  put the user data into a table where it can be worked on   */

                            cnxn = new SqlConnection(g.db);

                            try
                            {
                                cnxn.Open();

                                cmd = new SqlCommand("Insert into [AccessFrontEnds].[dbo].[NAV_User_Group_Mapping] " +
                                                     "(" +
                                                     " GroupName " +
                                                     ",GroupFullName " +
                                                     ",UserName" +
                                                     ",[DataDate]" +
                                                     ") values ('" +
                                                       groupUserName +
                                                     "','" + groupFullName +
                                                     "','" + user + "' " +
                                                     ",GETDATE())", cnxn);


                                int nn = cmd.ExecuteNonQuery();
                            }
                            catch (SqlException ex)
                            {
                                Console.Error.WriteLine(ex.Message);
                            }
                            finally
                            {
                                cnxn.Close();
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            finally
            {
                cnxnNAV.Close();
            }

        }

        private void cbddRole_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedRole = cbddRole.SelectedValue.ToString().Trim();
        }

        private void cbddADGroup_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedADGroup = cbddADGroup.SelectedValue.ToString().Trim();
        }

        private void cbddUser_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedUserName = cbddUser.SelectedValue.ToString().Trim();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedObjectType = comboBox1.SelectedValue.ToString().Trim();
        }

        private void bClearFilters_Click(object sender, EventArgs e)
        {
            cbddRole.SelectedIndex = -1;
            selectedRole = string.Empty;

            cbddADGroup.SelectedIndex = -1;
            selectedADGroup = string.Empty;

            cbddUser.SelectedIndex = -1;
            selectedUserName = string.Empty;

            comboBox1.SelectedIndex = -1;
            selectedObjectType = string.Empty;

            selection = string.Empty;
            GetData();
        }

        private void bExport_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            // 1. Write the Column Headers
            string[] headers = DGV.Columns.Cast<DataGridViewColumn>()
                                          .Select(col => $"\"{col.HeaderText.Replace("\"", "\"\"")}\"")
                                          .ToArray();
            sb.AppendLine(string.Join(",", headers));

            // 2. Write the Data Rows
            // Note: If AllowUserToAddRows is true, skip the last blank row using dgv.NewRowIndex
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (row.IsNewRow) continue;

                string[] cells = row.Cells.Cast<DataGridViewCell>()
                                          .Select(cell => {
                                              string val = cell.Value?.ToString() ?? "";
                                              // Escape quotes by doubling them up, then wrap the field in quotes
                                              return $"\"{val.Replace("\"", "\"\"")}\"";
                                          })
                                          .ToArray();

                sb.AppendLine(string.Join(",", cells));
            }

            // 3. Save the file
            if (Directory.Exists(@"C:\A"))
            {
                
            }
            else
            {
                DirectoryInfo di = Directory.CreateDirectory(@"C:\A");
            }

            File.WriteAllText(@"C:\A\NAVaudit" + DateTime.Now.ToLongDateString() + ".csv", sb.ToString(), Encoding.UTF8);

            //Close();
        }
    }

    public static class g
    {
        public static int ID;
        public static string description;
        public static string task;
        public static string dbTable = "CERT_Data";
        public static string ISO = string.Empty;
        public static string search = string.Empty;
        public static string form = string.Empty;
        public static string dbImage = "CERT_Image";
        public static string subtask;
        public static string newCertNumber;
        public static string adminTask;
        public static string permission;
        public static string permissionValue;
        public static string loginname;
        public static string employeeName;
        public static string supplierNo;
        public static string vendorTitle;
        public static string supplierName;
        public static string supplierRating;
        public static string qualityRating;
        public static string otdRating;
        public static string paymentTerms;
        public static string paymentTermsPlan;
        //public string? annualspendActual ;
        //public string? annualspendProjected ;
        public static string locationRegion;
        public static string commodity1;
        public static string commodity2;
        public static string buyer;

        public static string parentCompanyLocation;
        public static string parentCompanyName;
        public static string headquartersLocation;
        public static string factoryLocations;
        public static string technology;
        public static string costSavingsPlan;
        public static string costSavingsStatus;
        public static string strategy;
        public static string issues;
        public static string leadTimePlan;
        public static string leadTimeRange;
        public static string businessAlignment;
        public static string notes;
        //public static string permission ;
        public static string permissionvalue;
        public static DateOnly ndaExpirationDate;
        public static DateOnly ISO9001ExpirationDate;
        public static DateOnly ISO13485ExpirationDate;
        public static DateOnly AS9100ExpirationDate;
        public static DateOnly ZM0027ExpirationDate;
        public static string alternateSuppliers;
        public static string numberCriticalParts;
        public static string contractsType;
        public static string percentOfCoverage;
        public static string typeStatus;
        public static string lineofBusiness;


        //public static string rpt_CalSource;
        //public static string rpt_earliestDueDate;
        //public static string rpt_latestDueDate;
        //public static string rpt_room;
        public static string rpt_type = string.Empty;
        //public static string pdf;
        public static string db = "server = CT-MID-SQL11; password = Read+Write!; " +
                                  "user = readwrite; database = AccessFrontEnds; encrypt=false;";
        public static string dbNAV = "server = pa-hor-as408.ametek.com; user = navdb_read; password = 2018#ameteK; database = ZYGO-NAV-PROD";
        //public static string dbDashserver = "server = middb01; password = views; " +
        //                          "user = views; database = dashboard;";
    }
}
