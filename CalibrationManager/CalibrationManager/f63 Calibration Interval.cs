using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CalibrationManager
{
    public partial class f63_Calibration_Interval : Form
    {
        public f63_Calibration_Interval()
        {
            InitializeComponent();
        }

        private void f63_Calibration_Interval_Load(object sender, EventArgs e)
        {
            

            SqlConnection cnxn = new SqlConnection(g.db);
            
            string select = "select distinct type from equipment " +
                "where type != ''  order by type asc";

            cnxn.Open();
            SqlDataAdapter da = new SqlDataAdapter(select, cnxn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnxn.Close();
            comBoxType.DataSource = dt;
            comBoxType.DisplayMember = "Type";

        }

        private void bSetCalbyType_Click(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection(g.db);
            SqlCommand  cmd = new SqlCommand("Update equipment set " +
                "cal_interval = " + Convert.ToInt32(mtbMonths.Text.ToString()) + 
                "from equipment e " +
                " inner join itemlocation l on e.id = l.il_item " +
                " where l.il_location like '" + g.facility + "%' and " +
                " e.Type = '" + comBoxType.Text.ToString().Trim() + "' ");

            cmd.Connection = cnxn;
            cnxn.Open();
            int rowsReturned = cmd.ExecuteNonQuery();
            cnxn.Close();
            Close();
        }
    }
}