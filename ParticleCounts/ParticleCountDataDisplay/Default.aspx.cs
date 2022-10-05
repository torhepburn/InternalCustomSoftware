using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;


namespace ParticleCountDataDisplay
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StripLine sl1 = new StripLine();
            sl1.Interval = 0;
            sl1.StripWidth = 2;
            sl1.BackColor = System.Drawing.Color.Red;
            sl1.IntervalOffset = 35200;
            Chart1.ChartAreas[0].AxisY.StripLines.Add(sl1);

            StripLine sl2 = new StripLine();
            sl2.Interval = 0;
            sl2.StripWidth = 2;
            sl2.BackColor = System.Drawing.Color.Red;
            sl2.IntervalOffset = 35200;
            Chart2.ChartAreas[0].AxisY.StripLines.Add(sl2);

            StripLine sl3 = new StripLine();
            sl3.Interval = 0;
            sl3.StripWidth = 2;
            sl3.BackColor = System.Drawing.Color.Red;
            sl3.IntervalOffset = 35200;
            Chart3.ChartAreas[0].AxisY.StripLines.Add(sl3);

            StripLine sl4 = new StripLine();
            sl4.Interval = 0;
            sl4.StripWidth = 2;
            sl4.BackColor = System.Drawing.Color.Red;
            sl4.IntervalOffset = 35200;
            Chart4.ChartAreas[0].AxisY.StripLines.Add(sl4);

            StripLine sl5 = new StripLine();
            sl5.Interval = 0;
            sl5.StripWidth = 2;
            sl5.BackColor = System.Drawing.Color.Red;
            sl5.IntervalOffset = 352000;
            Chart5.ChartAreas[0].AxisY.StripLines.Add(sl5);

            StripLine sl6 = new StripLine();
            sl6.Interval = 0;
            sl6.StripWidth = 2;
            sl6.BackColor = System.Drawing.Color.Red;
            sl6.IntervalOffset = 3520;
            Chart6.ChartAreas[0].AxisY.StripLines.Add(sl6);

            StripLine sl7 = new StripLine();
            sl7.Interval = 0;
            sl7.StripWidth = 2;
            sl7.BackColor = System.Drawing.Color.Red;
            sl7.IntervalOffset = 352000;
            Chart7.ChartAreas[0].AxisY.StripLines.Add(sl7);

            StripLine sl8 = new StripLine();
            sl8.Interval = 0;
            sl8.StripWidth = 2;
            sl8.BackColor = System.Drawing.Color.Red;
            sl8.IntervalOffset = 352000;
            Chart8.ChartAreas[0].AxisY.StripLines.Add(sl8);

            StripLine sl9 = new StripLine();
            sl9.Interval = 0;
            sl9.StripWidth = 2;
            sl9.BackColor = System.Drawing.Color.Red;
            sl9.IntervalOffset = 10;
            Chart9.ChartAreas[0].AxisY.StripLines.Add(sl9);

        }
    }
}