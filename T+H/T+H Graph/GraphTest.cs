using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace T_H_Graph
{
    public partial class GraphTest : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        DataTable dt;
        SqlDataReader dr;
        private string db = "server = CT-MID-SQL01; password = views; " +
                            "user = views; database = TnH;";
        //private string db = "server = ct-mid-temp1; password = views; " +
          //                   "user = views; database = TnH;";


        public GraphTest()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisY.Maximum = 75;
            chart1.ChartAreas[0].AxisY.Minimum = 65;
            
            cnxn = new SqlConnection(db);

            SqlCommand cmd = new SqlCommand(
            //da = new SqlDataAdapter(
                //"select " + 
                //"logDate ReadingDate, " +
                //"[0.3] tempF " +
                //"from particlecountdata " +
                //"where location = 'center' " +
                //"order by [logdate] ",cnxn);

                "select " +
                "[log] ReadingDate, " +
                "RH, " +
                "tempF " +
                "from tnhdata " +
                "where address = '10.213.71.93' " +
                "and [log] >  DateAdd(d, -10,GetDate()) " + //and [log] <  DateAdd(d, -200,GetDate())" +
                "order by [log] ", cnxn);

            cnxn.Open();
            
            try
            {
                dr = cmd.ExecuteReader();

                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart1.Series[0].Points.DataBind(dr, "ReadingDate", "tempF", "Tooltip=tempF");
                //chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                //chart1.Series[0].Points.DataBind(dr, "ReadingDate", "RH", "Tooltip=ReadingDate");
                //dt = new DataTable();
                //da.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cnxn.Close();
            
            //chart1.DataSource = new 
            //chart1.Series[0].Points.DataBind(dt, "[log]", "tempF", "ToolTip=[log]" );
        }
    }
}
