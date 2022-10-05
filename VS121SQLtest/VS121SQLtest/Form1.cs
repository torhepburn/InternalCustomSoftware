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

namespace VS121SQLtest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection(
                "server=midsql01; user = readwrite; " +
                "password = Read+Write!; database = calibration;");
            SqlDataAdapter da = new SqlDataAdapter(
                    "Select " +
                    "ID as [Data Number], " +
                    "chg_date as [Log Date], " +
                    "currenthistory as [C=Current], " +
                    "Item " +
                    ",Cal_Date " +
                    ",CalSource " +
                    ",CertNum " +
                    ",Inspector " +
                    "from calibrationdata", cnxn);

            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;
            DGV.Show();

            

           

        }
    }
}
