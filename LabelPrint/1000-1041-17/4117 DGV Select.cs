using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _1000_1041_17
{
    public partial class Form1 : Form
    {
        SqlDataAdapter da;
        SqlConnection cnxn;
        DataTable table;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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

            string computername = Environment.MachineName;

            SqlConnection cnxn = new SqlConnection(g.db);

            try
            {
                SqlCommand cmd = new SqlCommand(
                 " Select permission, permissionvalue from applicationsetup " +
                 " where application = '1000-1041-17' and " +
                 " pcid = '" + computername + "' " +
                 " order by permission desc ", cnxn);
                DataTable table = new DataTable();

                cnxn.Open();

                SqlDataReader dr;

                dr = cmd.ExecuteReader();
                table.Load(dr);


                if (table.Rows.Count > 0)
                {
                    g.printer = table.Rows[0][1].ToString().Trim();
                }
                else
                {
                    MessageBox.Show("Either this user " + user + " or this computer (" + computername + ") does not have permission to use this program.");
                    this.Close();
                }

                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

            }

            this.Text = "Product ID and Serial Number Label 1000-1041-17 rev C";

            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter
              ("Select parent_item_code [Part Number], " +
               "IIF(Model is null, '-', model) Model, " +
               "IIF(Volts is null, '-', volts) Rev " +
               "from labels.IDsnLabels " +
               "where begin_item_code = '1000-1041-17' " +
               "order by parent_item_code", cnxn);

            GetData();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter
              ("Select parent_item_code [Part Number]," +
               "IIF(Model is null, '-', model) Model, " +
               "IIF(Volts is null, '-', volts) Rev " +
               "from labels.IDsnLabels " +
               "where begin_item_code = '1000-1041-17' " +
               " and (parent_item_code like '%" + tbSearchEquipment.Text + "%' " +
               "order by parent_item_code", cnxn);

            GetData();
        }

        private void bItem_Click(object sender, EventArgs e)
        {
            g.item = tbSearchEquipment.Text.ToString().Trim().ToUpper();
            tbSearchEquipment.Text = "";
            SqlCommand cmd = new SqlCommand
                ("Select parent_item_code from labels.IDsnLabels " +
                " where parent_item_code = '" + g.item + "' ", cnxn);
            cnxn = new SqlConnection(g.db);
            cmd.Connection = cnxn;
            cnxn.Open();
            object o = cmd.ExecuteScalar();

            if (o == null)
            {
                MessageBox.Show("This item does not exist.");
                tbSearchEquipment.Focus();
            }
            else
            {
                cnxn = new SqlConnection(g.db);
                da = new SqlDataAdapter
                  ("Select parent_item_code [Part Number], Parent_item_desc [Description], " +
                   "IIF(Model is null, '-', model) Model, " +
                   "IIF(Hertz is null, '-', hertz) Hertz, " +
                   "IIF(Volts is null, '-', volts) Volts, " +
                   "IIF(Amps is null, '-', amps) Amps " +
                   "from labels.IDsnLabels " +
                   "where begin_item_code = '1000-1041-17' " +
                   " and (parent_item_code = '" + g.item + "' )" +
                   "order by parent_item_code", cnxn);

                table = new DataTable();
                da.Fill(table);

                g.item = table.Rows[0][0].ToString();

                //g.description = table.Rows[0][1].ToString();

                g.model = table.Rows[0][2].ToString();

                //g.hertz = table.Rows[0][3].ToString();

                g.volts = table.Rows[0][4].ToString();

                //g.amps = table.Rows[0][5].ToString();


                _4117_SelectedLabel sl = new _4117_SelectedLabel();
                sl.ShowDialog();
            }

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
                g.item = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                g.model = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                g.volts = cell.EditedFormattedValue.ToString().Trim();

                _4117_SelectedLabel sl = new _4117_SelectedLabel();
                sl.ShowDialog();
            }

        }

        private void bFreeText_Click(object sender, EventArgs e)
        {
            g.freeText = true;
            g.item = "";
            g.description = "";
            g.model = "";
            g.hertz = "";
            g.volts = "";
            g.amps = "";
            _4117_SelectedLabel sl = new _4117_SelectedLabel();
            sl.ShowDialog();
        }

        private void GetData()
        {
            table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;
            DGV.Columns[0].Width = 120;
            DGV.Columns[1].Width = 250;

            DGV.Show();
        }

    }

    public static class g
    {
        public static string item;
        public static string description;
        public static string hertz;
        public static string volts;

        public static string amps;
        public static string model;
        public static bool freeText; 
        public static string printer;
        public static string db = "server = CT-MID-SQL11; password = Read+Write!; " +
                                  "user = readwrite; database = AccessFrontEnds;";
    }
}
