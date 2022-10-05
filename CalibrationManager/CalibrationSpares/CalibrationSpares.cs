using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CalibrationSpares
{
    public partial class CalibrationSpares : Form
    {
        DataTable table;
        SqlDataAdapter da;

        public CalibrationSpares()
        {
            InitializeComponent();
        }

        private void CalibrationSpares_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection
                ("server = MIDSQL01; user = views; password = views; database = calibration;");

            try
            {
                da = new SqlDataAdapter(
                    "select " +
                    "l.il_item as Item, " +
                    "e.Description, " +
                    "e.MANUF as Manufacturer, " +
                    "e.MODEL as Model " +
                    "from Itemlocation l left join equipment e " +
                    "on l.il_item = e.ID " +
                    "where il_location = 'zams-73-03' " +
                    "or il_location = 'zams-73-07' order by description", cnxn);
                table = new DataTable();
                da.Fill(table);
                DGV.DataSource = table;
                DGV.Show();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            DGV.Columns[0].Width = 120;
            DGV.Columns[1].Width = 250;
            DGV.Columns[2].Width = 150;
            DGV.Columns[3].Width = 150;
            
        }
    }
}
