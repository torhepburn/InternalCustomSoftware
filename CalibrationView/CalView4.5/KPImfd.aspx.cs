using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.DataVisualization;

namespace CalView4._5
{
    public partial class KPImfd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (Series series in Chart1.Series)
            {
                series.ChartType = SeriesChartType.Line;
                series.BorderWidth = 5;
            }

            Chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 1;
        }
    }
}