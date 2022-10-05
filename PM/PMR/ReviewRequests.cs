using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace PMR
{
    public partial class ReviewRequests : Form
    {
        SqlDataAdapter da;
        SqlConnection cnxn;
        private string db = "server = midsql01; password = Read+Write!; " +
                    "user = readwrite; database = PM_2015_A;";
        private string selection;
        private string BasicSelection;
        private object o;
        private bool firstLoad;

        public ReviewRequests()
        {
            InitializeComponent();
        }

        private void ReviewRequests_Load(object sender, EventArgs e)
        {
            System.Security.Principal.WindowsIdentity user;
            user = System.Security.Principal.WindowsIdentity.GetCurrent();

            string logdOn = user.Name.Replace("ZYGOMIS\\", "");

            cnxn = new SqlConnection(db);

            SqlCommand cmd = new SqlCommand("select RTRIM(site) from tbl_employees " +
                "where networklogin = '" + logdOn + "'", cnxn);

            cnxn.Open();
            o = cmd.ExecuteScalar();
            cnxn.Close();
            g.site = o.ToString();
                        
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
            else if (g.site == "ZAMS")
            {
                BasicSelection = "serial not like 'CM%' and " +
                            "serial not like 'TU%' and " +
                            "serial not like 'RI%'  ";
            }
            else
            {
                BasicSelection = "serial like '%'";
            }

            rbOpen.Checked = true;

            SqlDataAdapter da = new SqlDataAdapter
                ("select ' ' as trouble_AssignedTo union " +
                 "select distinct trouble_AssignedTo from [repair history] " +
                 "where " + BasicSelection + " order by trouble_assignedto", cnxn);
            DataTable dt2 = new DataTable();
            da.Fill(dt2);
            cbDDassignedto.DataSource = dt2;
            cbDDassignedto.DisplayMember = "trouble_AssignedTo";
            
            da = new SqlDataAdapter
                ("select ' ' as serial union " +
                "select serial from pmequip " +
                 "where " + BasicSelection + " order by serial", cnxn);
            dt2 = new DataTable();
            da.Fill(dt2);
            cbDDEquipment.DataSource = dt2;
            cbDDEquipment.DisplayMember = "serial";
            
            da = new SqlDataAdapter
                ("select ' ' as trouble_work_reference_number union " +
                "select trouble_work_reference_number from [repair history] " +
                 "where " + BasicSelection + " order by trouble_work_reference_number", cnxn);
            dt2 = new DataTable();
            da.Fill(dt2);
            cbDDworkRequestNo.DataSource = dt2;
            cbDDworkRequestNo.DisplayMember = "trouble_work_reference_number";

            tablesetup();
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 20)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.ID = Convert.ToInt32(cell.EditedFormattedValue.ToString().Trim());

                //SqlCommand cmd = new SqlCommand("Update ticketholder set id = " + ID + " ", cnxn);
                //cnxn.Open();
                //cmd.ExecuteNonQuery();
                //cnxn.Close();

                ProcessWorkRequest w = new ProcessWorkRequest();
                w.ShowDialog();
                tablesetup();
                
                //Process.Start(@"\\zygocorp\departments\facilities\prevmain\pmw.exe");
                //this.Close();
            }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            tablesetup();
        }

        private void bItem_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand(
                "select id from [repair history] where " +
                "trouble_work_reference_number = '" + tbSearchEquipment.Text.Trim() + "' ", cnxn);
            cnxn.Open();
            object o = cmd.ExecuteScalar();
            cnxn.Close();
            if (o == null)
            {
                MessageBox.Show("This item does not exist.");
                tbSearchEquipment.Focus();
            }
            else
            {
                //cmd = new SqlCommand("Update ticketholder set id = " + o + " ", cnxn);
                //cmd.ExecuteNonQuery();
                //cnxn.Close();

                //Process.Start(@"\\zygocorp\departments\facilities\prevmain\pmw.exe");
                g.ID = (int)o;

                ProcessWorkRequest w = new ProcessWorkRequest();
                w.ShowDialog();
                
                tbSearchEquipment.Text = "";
                tbSearchEquipment.Focus();
            }
            
        }

        private void tablesetup()
        {
            if (rbOpen.Checked)
            {
                selection = BasicSelection + "and trouble_status != 'closed' ";
            }

            if (rbClosed.Checked)
            {
                selection = BasicSelection + "and trouble_status = 'closed' ";
            }

            if (rbAll.Checked)
            {
                selection = BasicSelection + " ";
            }
            
            if (cbDDassignedto.SelectedIndex > 0)
            {
                selection += " and trouble_assignedto = '" + cbDDassignedto.Text.Trim() + "' ";
            }

            if (cbDDEquipment.SelectedIndex > 0)
            {
                selection += " and serial = '" + cbDDEquipment.Text.Trim() + "' ";
            }

            if (cbDDworkRequestNo.SelectedIndex > 0)
            {
                selection += " and trouble_work_reference_number = '" + cbDDworkRequestNo.Text.Trim() + "' ";
            }

            if (tbSearchEquipment.Text.Length > 0)
            {
                selection += " and serial like '%" + tbSearchEquipment.Text.Trim() + "' " +
                    "or trouble_work_reference_number like '%" + tbSearchEquipment.Text.Trim() + "' ";
            }
            
            
            cnxn = new SqlConnection(db);

            da = new SqlDataAdapter
                ("Select id, " +
                 "trouble_severity Priority, " +
                 "trouble_repair_category Category, " +
                 "trouble_rptd_date [Date Reported], " +
                 "trouble_work_reference_number " +
                 "[Work Request Number], " +
                 "serial [Equip ID], " +
                 "TaskGroup [Task Group], " +
                 "trouble Task, " +
                 "trouble_status Status, " +
                 "trouble_assignedto [Assigned To], " +
                 "repair_date [Repair Date], " +
                 "repair_symptom [Supervisor Comments], " +
                 "repair_desc Repair, " +
                 "Repair_Root_Cause [Root Cause], " +
                 "Repair_Downtime, " +
                 "repair_downtime [Ticket Open Time], " +
                 "Equip_Downtime [Equipment Downtime], " +
                 "Repair_Time [Repair Time] " +
                 "from [repair history] h " +
                 "where " +
                 selection +
                 " order by h.id asc", cnxn);

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
            DGV.Columns[1].Width = 60;
            DGV.Columns[2].Width = 150;
            DGV.Columns[3].Width = 80;
            DGV.Columns[4].Width = 75;
            DGV.Columns[5].Width = 150;
            DGV.Columns[6].Width = 50;
            DGV.Columns[7].Width = 260;
            DGV.Columns[8].Width = 80;
            DGV.Columns[9].Width = 75;
            DGV.Columns[10].Width = 80;
            DGV.Columns[11].Width = 150;
            DGV.Columns[12].Width = 150;
            DGV.Columns[13].Width = 150;
            DGV.Columns[14].Width = 50;
            DGV.Columns[15].Width = 50;
            DGV.Columns[16].Width = 50;

            selection = "";

            LrecordCount.Text = "RECORD COUNT: " + (DGV.RowCount - 1).ToString();
        }

    }

    public static class g
    {
        public static string site;
        public static string serial;
        public static string taskgroup;

        public static int ID;
        public static string model;
        public static bool freeText; 
        public static string printer;
        public static string db = "server = midsql01; password = Read+Write!; " +
                                  "user = readwrite; database = AccessFrontEnds;";
    }
}
