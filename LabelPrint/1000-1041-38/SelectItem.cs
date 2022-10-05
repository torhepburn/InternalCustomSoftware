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


namespace _1000_1041_38
{
    public partial class SelectItem : Form
    {
        SqlDataAdapter da;
        SqlConnection cnxn;
        DataTable table;

        public SelectItem()
        {
            InitializeComponent();
        }

        private void SelectItem_Load(object sender, EventArgs e)
        {
            this.Text = "1000-1041-38 Product ID and Serial Number Label v." + Application.ProductVersion;

            /*  commented out for testing    */
            //Lprinter.Text = "Printing on: " + g.printer.Substring(17, (g.printer.Length - (17)));

            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter
              ("Select parent_item_code [Part Number], Parent_item_desc [Description], " +
               "IIF(Model is null, '-', model) Model, " +
               "IIF(Hertz is null, '-', hertz) Hertz, " +
               "IIF(Volts is null, '-', volts) Volts, " +
               "IIF(Amps is null, '-', amps) Amps " +
               "from labels.IDsnLabels " +
               "where begin_item_code = '1000-1041-38' " +
               "order by parent_item_code", cnxn);

            GetData();
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
                g.description = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                g.model = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[3];
                g.hertz = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[4];
                g.volts = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[5];
                g.amps = cell.EditedFormattedValue.ToString().Trim();

                SelectedLabel sl = new SelectedLabel();
                sl.ShowDialog();
            }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter
              ("Select parent_item_code [Part Number], Parent_item_desc [Description], " +
               "IIF(Model is null, '-', model) Model, " +
               "IIF(Hertz is null, '-', hertz) Hertz, " +
               "IIF(Volts is null, '-', volts) Volts, " +
               "IIF(Amps is null, '-', amps) Amps " +
               "from labels.IDsnLabels " +
               "where begin_item_code = '1000-1041-38' " +
               " and (parent_item_code like '%" + tbSearchEquipment.Text + "%' " +
               "or parent_item_desc like '%" + tbSearchEquipment.Text + "%' )" +
               "order by parent_item_code", cnxn);

            GetData();
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
            SelectedLabel sl = new SelectedLabel();
            sl.ShowDialog();
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
                   "where begin_item_code = '1000-1041-38' " +
                   " and (parent_item_code = '" + g.item + "' )" +
                   "order by parent_item_code", cnxn);

                table = new DataTable();
                da.Fill(table);

                g.item = table.Rows[0][0].ToString();

                g.description = table.Rows[0][1].ToString();

                //g.description = g.description.Replace("""", """"");

                g.model = table.Rows[0][2].ToString();

                g.hertz = table.Rows[0][3].ToString();

                g.volts = table.Rows[0][4].ToString();

                g.amps = table.Rows[0][5].ToString();


                SelectedLabel sl = new SelectedLabel();
                sl.ShowDialog();
            }
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
        /*  for Taiwan using local printer  */
        //public static string printer = "zebra2.25x1.25";
        //public static string printer = "\\\\midprtsrv\\zebrasn20";
        //public static string printer = "\\\\midprtsrv\\zebrasn37";
        //public static string printer = "ZDesigner GX430t";
        public static string printer = "ZDesigner GX420t";
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
        public static string db = "server = CT-MID-SQL01; password = Read+Write!; " +
                                  "user = readwrite; database = AccessFrontEnds;";
        //public static string dbDash = "[middb01].dashboard.dbo.view_employees";
        //public static string dbDashserver = "server = middb01; password = views; " +
        //                          "user = views; database = dashboard;";
    }
}
