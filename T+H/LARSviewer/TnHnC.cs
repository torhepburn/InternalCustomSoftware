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

namespace LARSviewer
{
    public partial class TnHnC : Form
    {
        SqlDataAdapter da;
        DateTime searchStart;
        DateTime searchEnd;
        DataTable table;
        private string FlagStartSelected = "F";
        private string FlagEndSelected = "F";

        public TnHnC()
        {
            InitializeComponent();
        }

        private void TnHnC_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection(
               "server = CT-MID-SQL11; user = views; " +
               "password = views; database = TnH;");
            SqlDataAdapter da = new SqlDataAdapter
                ("select distinct address, location from unitSetup " +
                 "where address = '10.213.71.89' order by location", cnxn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            comboBox1.DataSource = dt;

            DataColumn dc = new DataColumn("combined");
            dc.Expression = string.Format("{0}+ '    '+ {1}", "address", "Location");
            dt.Columns.Add(dc);
            comboBox1.DisplayMember = "combined";
            comboBox1.ValueMember = "address";

            dtpStart.Value = DateTime.Now.AddDays(-1);
        }


        private void bGetData_Click(object sender, EventArgs e)
        {
            if (FlagEndSelected != "T")
            {
                searchEnd = DateTime.Now;
            }

            if (FlagStartSelected != "T")
            {
                searchStart = searchEnd.AddDays(-1);
            }

            SqlConnection cnxn = new SqlConnection
                   ("server = CT-MID-SQL11; user = views; " +
                    "password = views; database = TnH;");

            if (comboBox1.SelectedValue.ToString() == "10.213.71.89" )
            {
                da = new SqlDataAdapter
                    ("select CONVERT(varchar(16),[Log], 121) DateTime, CAST(((TempF-32)/1.8) as decimal (3,1)) as Temp, RH from " +
                     "tnhdata where address = '" +
                     comboBox1.SelectedValue.ToString() +
                     "' and log >= '" + searchStart + "' " +
                     " and log <= '" + searchEnd + "' " +
                     " order by log desc", cnxn);

            }

            //if (comboBox1.SelectedValue.ToString() == "10.213.131.1" |
            //    comboBox1.SelectedValue.ToString() == "10.213.131.2")
            //{
            //    da = new SqlDataAdapter
            //        ("select [Log], TempF, RH from " +
            //         "tnhdata where address = '" +
            //         comboBox1.SelectedValue.ToString() +
            //         "' and log >= '" + searchStart + "' " +
            //         " and log <= '" + searchEnd + "' " +
            //         " order by log desc", cnxn);

            //}

            //if (comboBox1.SelectedValue.ToString() == "10.213.131.8")
            //{
            //    da = new SqlDataAdapter
            //        ("select Log, CAST(((TempF-32)/1.8) as decimal (3,1))  as [Chilled Water], " +
            //         "CAST(((rh-32)/1.8) as decimal (3,1)) as [AHU 3 Water] from " +
            //         "tnhdata where address = '" +
            //         comboBox1.SelectedValue.ToString() +
            //         "' and log >= '" + searchStart + "' " +
            //         " and log <= '" + searchEnd + "' " +
            //         " order by log desc", cnxn);

            //}

            table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;
            DGV.Show();
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            searchStart = dtpStart.Value;
            FlagStartSelected = "T";
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            searchEnd = dtpEnd.Value;
            FlagEndSelected = "T";
        }

        private void bExport_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\TnH\TnHdata.csv"))
            {
                File.Delete(@"C:\TnH\TnHdata.csv");
            }


            for (int i = 0; i < table.Rows.Count; i++)
            {
                
                File.AppendAllText(@"C:\TnH\TnHdata.csv", 
                    table.Rows[i][0].ToString() + "," +
                    table.Rows[i][1].ToString() + "," +
                    table.Rows[i][2].ToString() + Environment.NewLine);
            }
            this.Close();

        }
    }
}
