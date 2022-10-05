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

namespace PMLoto
{
    public partial class F1_Select_Equipment : Form
    {
        SqlDataAdapter da;
        SqlConnection cnxn;
        
        public F1_Select_Equipment()
        {
            InitializeComponent();
        }

        private void F1_Select_Equipment_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);

            da = new SqlDataAdapter
                ("Select serial, [Description] from pmequip " +
                 " order by serial asc", cnxn);
            
            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;
        
            DGV.Columns[0].Width = 200;
            DGV.Columns[1].Width = 500;

        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 2)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.serial = cell.EditedFormattedValue.ToString().Trim();
                //cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                //g.description = cell.EditedFormattedValue.ToString().Trim();

                selectionChoice();
            }

        }


        private void bItem_Click(object sender, EventArgs e)
        {
            g.serial = tbSearchEquipment.Text.ToString().Trim().ToUpper();
            tbSearchEquipment.Text = "";
            cnxn = new SqlConnection(g.db);
            SqlCommand cmd = new SqlCommand
                ("Select serial from pmequip " +
                "where serial = '" + g.serial + "'", cnxn);
            cnxn.Open();
            object o = cmd.ExecuteScalar();

            if (o == null)
            {
                MessageBox.Show("This item does not exist.");
                tbSearchEquipment.Focus();
            }
            else
            {
                selectionChoice();
            }
        }



        private void bSearch_Click_1(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter
                ("Select serial, [Description] from pmequip" +
                 " where (serial like '%" + tbSearchEquipment.Text + "%' " +
                 "or [description] like '%" + tbSearchEquipment.Text + "%' )" +
                 " order by serial", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;
        }

        private void selectionChoice()
        {
            openFileDialog1.ShowDialog();
            string filePath = openFileDialog1.FileName;

            FileStream fs = new FileStream
                (filePath, FileMode.Open, FileAccess.Read);

            // store the file in an array the length of the file
            byte[] fileData = new byte[fs.Length];

            // read the file stream to the array
            fs.Read(fileData, 0, Convert.ToInt32(fs.Length));

            SqlConnection cnxn = new SqlConnection(g.db);
            SqlParameter prm1 = new SqlParameter
                ("@file", SqlDbType.Image, Convert.ToInt32(fs.Length));
            prm1.Value = fileData;

            SqlCommand cmd = new SqlCommand
                ("Update PMEquip set LOTO = " + prm1 +
                 " where serial = '" + g.serial + "' ");
            cmd.Parameters.Add(prm1);
            cmd.Connection = cnxn;
            cnxn.Open();
            cmd.ExecuteNonQuery();
            cnxn.Close();
            fs.Close();
            // close the file stream

            cnxn = new SqlConnection(g.db);
            cmd = new SqlCommand
                ("Select LOTO from PMEquip " +
                 " where serial = '" + g.serial + "' ", cnxn);

            cnxn.Open();
            object o = cmd.ExecuteScalar();
            if (o != null)
            {
                DialogResult result;
                result = MessageBox.Show(" PDF created.");
            }
            cnxn.Close();

        }

 
               
            
        
    }

    public static class g
    {
        public static string serial;
        public static string description;
        //public static string taskhistory;
        //public static string userType;

        //public static string facility;
        //public static string emailFrom;
        ////public static DataTable table;
        //public static string location;
        //public static string Ldescription;
        //public static string room;
        //public static string Rdescription;
        //public static string Rnotes;
        //public static int rID;
        //public static string eBadgeID;
        //public static string iID;
        //public static string iDescription;
        //public static int internalCalContact;
        //public static int cdID;                 //calibration data id
        //public static string rpt_status;
        //public static string rpt_CalSource;
        //public static string rpt_earliestDueDate;
        //public static string rpt_latestDueDate;
        //public static string rpt_room;
        //public static string rpt_type;
        //public static string pdf;
        public static string db = "server = MIDSQL01; password = Read+Write!; " +
                                  "user = readWrite; database = PM_2015_A;";
        //public static string dbDash = "[middb01].dashboard.dbo.view_employees";
        //public static string dbDashserver = "server = middb01; password = views; " +
        //                          "user = views; database = dashboard;";
    }
}
