using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace KanbanSFOLocation
{
    public partial class KBsfoLocation : Form
    {
        SqlConnection cnxn;
        private string db = "server = midsql01; password = Read+Write!; " +
                            "user = readwrite; database = OptiTRAK;";
        DataTable dt;

        public KBsfoLocation()
        {
            InitializeComponent();
        }

        private void KBsfoLocation_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(db);


            SqlDataAdapter da = new SqlDataAdapter(
                "select * from kanbansfolocation " +
                "order by item_code, kbsequence", cnxn);

            try
            {
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            DGV.DataSource = dt;
            DGV.Show();

        }
    }
}
