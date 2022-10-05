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


namespace PMtableSpeed
{
    public partial class Form1 : Form
    {
        SqlDataAdapter da;
        SqlConnection cnxn;
        private string db = "server = midsql01; password = Read+Write!; " +
                    "user = readwrite; database = PM_2015_A;";
        private string selection;
        private string BasicSelection;
        private object o;
        private bool firstLoad;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //System.Security.Principal.WindowsIdentity user;
            //user = System.Security.Principal.WindowsIdentity.GetCurrent();

            //string logdOn = user.Name.Replace("ZYGOMIS\\", "");

            //cnxn = new SqlConnection(db);

            //SqlCommand cmd = new SqlCommand("select RTRIM(site) from tbl_employees " +
            //    "where networklogin = '" + logdOn + "'", cnxn);

            //cnxn.Open();
            //o = cmd.ExecuteScalar();
            //cnxn.Close();
            //g.site = o.ToString();

            //if (g.site == "ZEOS")
            //{
            //    BasicSelection = "serial like 'CM%' ";
            //}
            //else if (g.site == "AZT")
            //{
            //    BasicSelection = "serial like 'TU%' ";
            //}
            //else if (g.site == "ZEP")
            //{
            //    BasicSelection = "serial like 'RI%' ";
            //}
            //else if (g.site == "ZAMS")
            //{
            //    BasicSelection = "serial not like 'CM%' and " +
            //                "serial not like 'TU%' and " +
            //                "serial not like 'RI%'  ";
            //}
            //else
            //{
            //    BasicSelection = "serial like '%'";
            //}

            //rbOpen.Checked = true;

            //SqlDataAdapter da = new SqlDataAdapter
            //    ("select ' ' as trouble_AssignedTo union " +
            //     "select distinct trouble_AssignedTo from [repair history] " +
            //     "where " + BasicSelection + " order by trouble_assignedto", cnxn);
            //DataTable dt2 = new DataTable();
            //da.Fill(dt2);
            //cbDDassignedto.DataSource = dt2;
            //cbDDassignedto.DisplayMember = "trouble_AssignedTo";

            //da = new SqlDataAdapter
            //    ("select ' ' as serial union " +
            //    "select serial from pmequip " +
            //     "where " + BasicSelection + " order by serial", cnxn);
            //dt2 = new DataTable();
            //da.Fill(dt2);
            //cbDDEquipment.DataSource = dt2;
            //cbDDEquipment.DisplayMember = "serial";

            //da = new SqlDataAdapter
            //    ("select ' ' as trouble_work_reference_number union " +
            //    "select trouble_work_reference_number from [repair history] " +
            //     "where " + BasicSelection + " order by trouble_work_reference_number", cnxn);
            //dt2 = new DataTable();
            //da.Fill(dt2);
            //cbDDworkRequestNo.DataSource = dt2;
            //cbDDworkRequestNo.DisplayMember = "trouble_work_reference_number";

            tablesetup();
        }

        private void tablesetup()
        {
            //if (rbOpen.Checked)
            //{
            //    selection = BasicSelection + "and trouble_status != 'closed' ";
            //}

            //if (rbClosed.Checked)
            //{
            //    selection = BasicSelection + "and trouble_status = 'closed' ";
            //}

            //if (rbAll.Checked)
            //{
            //    selection = BasicSelection + " ";
            //}

            //if (cbDDassignedto.SelectedIndex > 0)
            //{
            //    selection += " and trouble_assignedto = '" + cbDDassignedto.Text.Trim() + "' ";
            //}

            //if (cbDDEquipment.SelectedIndex > 0)
            //{
            //    selection += " and serial = '" + cbDDEquipment.Text.Trim() + "' ";
            //}

            //if (cbDDworkRequestNo.SelectedIndex > 0)
            //{
            //    selection += " and trouble_work_reference_number = '" + cbDDworkRequestNo.Text.Trim() + "' ";
            //}

            //if (tbSearchEquipment.Text.Length > 0)
            //{
            //    selection += " and serial like '%" + tbSearchEquipment.Text.Trim() + "' " +
            //        "or trouble_work_reference_number like '%" + tbSearchEquipment.Text.Trim() + "' ";
            //}

            selection = "1=1";

            cnxn = new SqlConnection(db);

            da = new SqlDataAdapter
                ("With s1 As " +
                " ( " +
                "  Select " +
                "  equipmentID " +
                "  , TaskGroup " +
                "  , RTrim(taskgroup) + '-' + CAST(COUNT(taskgroup) AS VARCHAR) TaskGroupCount " +
                "  FROM Tasks " +
                "  GROUP BY EquipmentID, TaskGroup " +
                "  ) " +
                "  SELECT h.id work_request_number " +
                "  , h.severity Priority " +
                "  , h.repaircategory category " +
                "  , h.reporteddate " +
                "  , h.equipmentID " +
                "  , o.owner " +
                "  , s1.taskgroupcount " +
                "  , h.issue task " +
                "  , h.status " +
                "  , v.name AssignedTo " +
                "  , IIF(ReportedBy = 4, 'Preventive Maintenance', vv.name) ReportedBy " +
                "  FROM repair_history h " +
                "  INNER JOIN equipment q ON " +
                "  h.EquipmentID = q.EquipmentID " +
                "  INNER JOIN locations l on q.locationid = l.id " +
                "  LEFT JOIN view_employees_all_local v " +
                "  ON h.AssignedTo = v.id " +
                "  LEFT JOIN view_employees_all_local vV " +
                "  ON h.ReportedBy = vv.id " +
                "  LEFT JOIN s1 ON h.equipmentID = s1.equipmentID and h.taskgroup = s1.taskgroup " +
                "  INNER JOIN owners o on q.ownerid = o.id " +
                "  WHERE 1 = 1 " +
                "  ORDER BY h.id DESC", cnxn);

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

            //DGV.Columns[0].Visible = false;
            //DGV.Columns[1].Width = 60;
            //DGV.Columns[2].Width = 150;
            //DGV.Columns[3].Width = 80;
            //DGV.Columns[4].Width = 75;
            //DGV.Columns[5].Width = 150;
            //DGV.Columns[6].Width = 50;
            //DGV.Columns[7].Width = 260;
            //DGV.Columns[8].Width = 80;
            //DGV.Columns[9].Width = 75;
            //DGV.Columns[10].Width = 80;
            //DGV.Columns[11].Width = 150;
            //DGV.Columns[12].Width = 150;
            //DGV.Columns[13].Width = 150;
            //DGV.Columns[14].Width = 50;
            //DGV.Columns[15].Width = 50;
            //DGV.Columns[16].Width = 50;

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
