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
    public partial class WorkRequestForm : Form
    {
        SqlConnection cnxn;
        private string db = "server=MIDSQL01; user=readWrite; password=Read+Write!; database=PM_2015_A;";
        SqlDataAdapter da;
        DataTable table;
        SqlCommand cmd;
        private bool repairDateEntered;
        private string taskGroup;
        private string SendToEmail;
        private string model;
        private string owner;
        private string itemDescription;
        private string site;
        //private decimal frequency;
        
        public WorkRequestForm()
        {
            InitializeComponent();
        }

        private void WorkRequestForm_Load(object sender, EventArgs e)
        {
            bTask.Visible = false;

            cnxn = new SqlConnection(db);

            if (g.site == "ALL")
            {
                da = new SqlDataAdapter("select networklogin " +
                 "from assignedto order by lastname", cnxn);
            }
            else
            {
                da = new SqlDataAdapter("select networklogin " +
                    "from assignedto where site = '" + g.site + "' order by lastname", cnxn);
            }
            table = new DataTable();
            da.Fill(table);
            cnxn.Close();
            cbAssigned.DataSource = table;
            cbAssigned.DisplayMember = "networklogin";

            cmd = new SqlCommand
                ("select top 1" +
                 "h.SERIAL, " +
                 "MANUFACTURER, " +
                 "LOCATION, " +
                 "TROUBLE_REPAIR_CATEGORY, " +
                 "TROUBLE_SEVERITY, " +
                 "TROUBLE_PROJECT, " +
                 "TROUBLE_RPTD_DATE, " +
                 "TROUBLE_COST_CENTER, " +
                 "TROUBLE, " +
                 "TROUBLE_RPTD_BY, " +
                 "TROUBLE_RPTD_EMAIL, " +
                 "TROUBLE_RPTD_PHONE, " +
                 "TROUBLE_work_reference_number, " +
                 "Trouble_AssignedTo, " +
                 "TROUBLE_Status, " +
                 "PlannedHours, " +
                 "REPAIR_DATE, " +
                 "REPAIR_SYMPTOM, " +
                 "REPAIR_DESC, " +
                 "REPAIR_ROOT_CAUSE, " +
                 "REPAIR_TIME, " +
                 "EQUIP_DOWNTIME, " +
                 "ITEM, " +
                 "IIF(trouble_status = 'closed', repair_downtime, DATEDIFF(n, trouble_rptd_date, GETDATE())/60) DowntimeClock, " +
                 "MODEL, " +
                 "OWNER, " +
                 "DESCRIPTION " +
                 "from [REPAIR HISTORY] h " +
                 "inner join PMEQUIP e on h.serial = e.SERIAL " +
                 "where " +
                 "h.RequestUID = " + g.ID + " " +
                 "order by trouble_work_reference_number desc", cnxn);

            cmd.Connection = cnxn;
            cnxn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (!dr.IsDBNull(0)) { tbSerial.Text = dr.GetString(0).Trim(); }
                if (!dr.IsDBNull(1)) { tbManufact.Text = dr.GetString(1).Trim(); }
                if (!dr.IsDBNull(2)) { tbLocation.Text = dr.GetString(2).Trim(); }
                if (!dr.IsDBNull(3)) { tbCategory.Text = dr.GetString(3).Trim(); }
                if (!dr.IsDBNull(4)) { tbSeverity.Text = dr.GetString(4).Trim(); }
                if (!dr.IsDBNull(5)) { tbProject.Text = dr.GetString(5).Trim(); }
                if (!dr.IsDBNull(6)) { tbReportedDate.Text = dr.GetDateTime(6).ToShortDateString(); }
                if (!dr.IsDBNull(7)) { tbCostCenter.Text = dr.GetString(7).Trim(); }
                if (!dr.IsDBNull(8)) { tbTrouble.Text = dr.GetString(8).Trim(); }
                if (!dr.IsDBNull(9)) { tbReportedBy.Text = dr.GetString(9).Trim(); }
                if (!dr.IsDBNull(10)) { tbEmail.Text = dr.GetString(10).Trim(); }
                if (!dr.IsDBNull(11)) { tbPhone.Text = dr.GetString(11).Trim(); }
                if (!dr.IsDBNull(12)) { tbWorkRequestNumber.Text = dr.GetString(12).Trim(); }
                if (!dr.IsDBNull(13)) { cbAssigned.Text = dr.GetString(13).Trim(); }
                if (!dr.IsDBNull(14)) { cbStatus.Text = dr.GetString(14).Trim(); }
                if (!dr.IsDBNull(15)) { tbPlannedHours.Text = dr.GetDouble(15).ToString(); }
                if (!dr.IsDBNull(16)) { dtpRepairDate.Text = dr.GetDateTime(16).ToShortDateString(); }
                if (!dr.IsDBNull(17)) { tbSuperComment.Text = dr.GetString(17).Trim(); }
                if (!dr.IsDBNull(18)) { tbRepairMade.Text = dr.GetString(18).Trim(); }
                if (!dr.IsDBNull(19)) { tbRootCause.Text = dr.GetString(19).Trim(); }
                if (!dr.IsDBNull(20)) { tbLaborTime.Text = dr.GetDouble(20).ToString(); }
                if (!dr.IsDBNull(21)) { tbDownTime.Text = dr.GetDouble(21).ToString(); }
                
                if (!dr.IsDBNull(22)) 
                { 
                    taskGroup = dr.GetString(22).ToString(); 
                }
                else
                {
                    taskGroup = "";
                }

                if (!dr.IsDBNull(23)) 
                { 
                    LTimeOpen.Text = "TIME OPEN (HRS): " + dr.GetDouble(23).ToString();
                    int nn = Convert.ToInt32(dr.GetDouble(23));
                    LDaysHours.Text = (nn/24).ToString() + " day(s) " + (dr.GetDouble(23)%24).ToString() + " hour(s)";
                }

                if (!dr.IsDBNull(24)) { model = dr.GetString(24).Trim(); }
                if (!dr.IsDBNull(25)) { owner = dr.GetString(25).Trim(); }
                if (!dr.IsDBNull(26)) { itemDescription = dr.GetString(26).Trim(); }


            }
            cnxn.Close();

            cmd = new SqlCommand("select CAST(AVG(REPAIR_TIME) as float) from [REPAIR HISTORY] " +
                "where serial = '" + tbSerial.Text.Trim() + "'  and TaskGroup = '" + taskGroup + "' ", cnxn);

            cnxn.Open();
            try
            {
                object o = cmd.ExecuteScalar();
                if (o.ToString() == "0" | o.ToString() == "")
                {
                    LaverageHours.Text = "PAST AVERAGE: Not available";
                }
                else
                {
                    LaverageHours.Text = "PAST AVERAGE: " + o.ToString().Substring(0, 6);
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
            


        }

        private void bSaveData_Click(object sender, EventArgs e)
        {
            if (tbPlannedHours.Text.Trim().Length < 1 )
            {
                MessageBox.Show("Must provide an entry for planned hours.");
                tbPlannedHours.Focus();
                return;
            }

            if (cbStatus.Text == "Closed" && repairDateEntered == false)
            {
                MessageBox.Show("Must click on Repair Date to enter selection.");
                dtpRepairDate.Focus();
                return;
            }
            
            SqlParameter tAssigned = new SqlParameter("@tAssigned", SqlDbType.VarChar, 50);
            tAssigned.Value = cbAssigned.Text.ToString().Trim();
            SqlParameter tStatus = new SqlParameter("@tStatus", SqlDbType.VarChar, 50);
            tStatus.Value = cbStatus.Text.ToString().Trim();
            SqlParameter tPlannedHours = new SqlParameter("@tPlannedHours", SqlDbType.Float);
            tPlannedHours.Value = tbPlannedHours.Text.ToString().Trim();
            SqlParameter tSuperComment = new SqlParameter("@tSupercomment", SqlDbType.VarChar, 255);
            tSuperComment.Value = tbSuperComment.Text.ToString().Trim();
            SqlParameter tRepair = new SqlParameter("@tRepair", SqlDbType.VarChar,4000);
            tRepair.Value = tbRepairMade.Text.ToString().Trim();
            SqlParameter tRootCause = new SqlParameter("@tRootCause", SqlDbType.VarChar, 255);
            tRootCause.Value = tbRootCause.Text.ToString().Trim();
            SqlParameter tLaborTime = new SqlParameter("@tLaborTime", SqlDbType.Float);
            tLaborTime.Value = tbLaborTime.Text.ToString().Trim();
            SqlParameter tDownTime = new SqlParameter("@tDownTime", SqlDbType.Float);
            tDownTime.Value = tbDownTime.Text.ToString().Trim();
            SqlParameter tRepairDate = new SqlParameter("@tRepairDate", SqlDbType.Date);
            if ( repairDateEntered )
            {
                tRepairDate.Value = dtpRepairDate.Text;
            }
            else
            {
                tRepairDate.Value = "01-01-1900";
            }
            
            cnxn = new SqlConnection(db);
            cmd = new SqlCommand("Update [Repair History] set " +
                "Trouble_AssignedTo = " + tAssigned +
                 ",TROUBLE_Status = " + tStatus +
                 ",PlannedHours = " + tPlannedHours +
                 ",REPAIR_DATE = " + tRepairDate +
                 ",REPAIR_SYMPTOM = " + tSuperComment +
                 ",REPAIR_DESC = " + tRepair +
                 ",REPAIR_ROOT_CAUSE = " + tRootCause +
                 ",REPAIR_TIME = " + tLaborTime +
                 ",EQUIP_DOWNTIME = " + tDownTime +
                 " where RequestUid = " + g.ID + " " , cnxn);
                cmd.Parameters.Add(tAssigned);
                cmd.Parameters.Add(tStatus);
                cmd.Parameters.Add(tPlannedHours);
                cmd.Parameters.Add(tSuperComment);
                cmd.Parameters.Add(tRepair);
                cmd.Parameters.Add(tRootCause);
                cmd.Parameters.Add(tLaborTime);
                cmd.Parameters.Add(tDownTime);
                cmd.Parameters.Add(tRepairDate);
                
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

                if ((cbStatus.Text == "Closed" & tbReportedBy.Text == "Prev Maint" & dtpRepairDate.Text != "1900-01-01"))
                {
                SqlCommand cmd1 = new SqlCommand("UpdateTaskDates", cnxn);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlParameter serial = cmd1.Parameters.Add
                    ("@s", SqlDbType.VarChar, 255);
                serial.Value = tbSerial.Text.Trim();
                SqlParameter taskgroup = cmd1.Parameters.Add
                    ("@g", SqlDbType.NVarChar, 4);
                taskgroup.Value = taskGroup;
                cnxn.Open();
                try
                {
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Task Rolled");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                cnxn.Close();
            }

            if (cbStatus.Text == "Closed" & tbReportedBy.Text != "Prev Maint" & dtpRepairDate.Text != "1900-01-01")
            {
                string strBody = "Your " + tbSeverity.Text + " work request for " +
                    tbCategory.Text + " on equipment id " + tbSerial.Text + " dated " +
                    tbReportedDate.Text + " has been completed by " + cbAssigned.Text + "." + Environment.NewLine +
                    Environment.NewLine +
                    "Work Req # : " + tbWorkRequestNumber.Text + Environment.NewLine +
                    "Description:----" + Environment.NewLine +
                    tbTrouble.Text + Environment.NewLine +
                    Environment.NewLine +
                    "Repair(s) Made:----" + Environment.NewLine +
                    tbRepairMade.Text;
                
                cmd = new SqlCommand(
                        "insert into email (emailto, emailsubject, emailbody) " +
                        "values ('" + tbEmail.Text.Trim() + "','Auto-Generated Work " +  
                        "Request Completed' ,'" + strBody + "')", cnxn);
                    cnxn.Open();
                    cmd.ExecuteNonQuery();
                    cnxn.Close();
            }

            this.Close();
        }

        private void dtpRepairDate_Enter(object sender, EventArgs e)
        {
            repairDateEntered = true;
        }

        private void cbAssigned_MouseDown(object sender, MouseEventArgs e)
        {
            if (cbStatus.Text != "Assigned")
            {
                MessageBox.Show("Must change status to Assigned prior to assigning tickets.");
                return;
            }
        }

        private void cbAssigned_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAssigned.Text != "Initial" & cbStatus.Text == "Assigned")
            {
                SqlParameter tAssigned = new SqlParameter("@tAssigned", SqlDbType.VarChar, 50);
                tAssigned.Value = cbAssigned.Text.ToString().Trim();
            
                cmd = new SqlCommand("Update [Repair History] set " +
                "Trouble_AssignedTo = " + tAssigned +
                 " where id = (select id from ticketholder)", cnxn);
                cmd.Parameters.Add(tAssigned);
                
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

                
                cmd = new SqlCommand
                    ("select email from tbl_employees where " +
                     "networklogin = '" + cbAssigned.Text + "' ", cnxn);
                cnxn.Open();
                object o = cmd.ExecuteScalar();
                cnxn.Close();
                SendToEmail = o.ToString();
                DialogResult dialogResult = MessageBox.Show("Send email to " + 
                    SendToEmail + ".", "Notify ?" , MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    string strBody = "You have been assigned a work request reported on " + tbReportedDate.Text + "." +
                    Environment.NewLine + Environment.NewLine +
                    "  Reported by.. : " + tbReportedBy.Text + Environment.NewLine +
                    "  Equip ID..... : " + tbSerial.Text + Environment.NewLine +
                    "  Work Req #... : " + tbWorkRequestNumber.Text + Environment.NewLine +
                    "  Category..... : " + tbCategory.Text + Environment.NewLine +
                    "  Severity..... : " + tbSeverity.Text + Environment.NewLine +
                    "  Manufacturer. : " + tbManufact.Text + Environment.NewLine +
                    "  Model........ : " + model + Environment.NewLine +
                    "  Location..... : " + tbLocation.Text + Environment.NewLine +
                    "  Owner........ : " + owner + Environment.NewLine +
                    "  Description.. : " + itemDescription + Environment.NewLine + Environment.NewLine +
                    "NOTATION:-----------------------------------------------------------" + Environment.NewLine +
                       tbTrouble.Text + Environment.NewLine +
                    "--------------------------------------------------------------------";

                    cmd = new SqlCommand(
                        "insert into email (emailto, emailsubject, emailbody) " +
                        "values ('" + SendToEmail + "','" + tbCategory.Text +
                        " Work Request Notification','" + strBody + "')", cnxn);
                    cnxn.Open();
                    cmd.ExecuteNonQuery();
                    cnxn.Close();
                }
                else
                {
                    return;
                }
            }
        }
       
    }
}
