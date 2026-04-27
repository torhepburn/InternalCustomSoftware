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

namespace MicroscopeDB
{
    public partial class PerformanceSpecificationsZeFlat : Form
    {
        private string SQL;

        public PerformanceSpecificationsZeFlat()
        {
            InitializeComponent();
        }

        private void PerformanceSpecificationsZeFlat_Load(object sender, EventArgs e)
        {
            LproductLine.Text = g.ProductLine;

            tbLimStepAcc1p8.Text = g.Lim1p8StepHeightAccuracy;
            tbLimStepAcc24.Text = g.Lim24StepHeightAccuracy;
            tbLimTopoRepeat.Text = g.LimTopoRepeat;
            tbLimRmsRepeat.Text = g.LimRmsRepeat;
            tbLimStepRepeat.Text = g.LimStepRepeat;
            tbLimFlatRes.Text = g.LimFlatResidual;
            tbLimFlatRpt.Text = g.LimFlatRepeat;

            /* 
              
             * ZeFlat does not have a field for RMS repeat in the log 
             * we are leaving the field here for future use
            
             */

            SQL =
            "  AVG(TopoRepeat) " +
            " ,AVG(SHRepeat) " +
            " ,AVG([1p8umSHSacc]) " +
            " ,AVG([24umSHSAcc]) " +
            " ,AVG([FlatRes]) " +
            " ,AVG([FlatRpt]) " +
            " FROM MicroscopeData WHERE " +
            " ProductLine = '" + g.ProductLine + "'";


            SqlConnection cnxn = new SqlConnection(g.db);

            SqlDataAdapter da = new SqlDataAdapter(
                "  Select " + SQL, cnxn);

            DataTable T2 = new DataTable();

            try
            {
                da.Fill(T2);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            tbMeanTopoRepeat.Text = Convert.ToDecimal(T2.Rows[0][0].ToString()).ToString("0.000");
            tbMeanStepRepeat.Text = Convert.ToDecimal(T2.Rows[0][1].ToString()).ToString("0.000");
            tbMeanStepAcc1p8.Text = Convert.ToDecimal(T2.Rows[0][2].ToString()).ToString("0.000");
            tbMeanStepAcc24.Text = Convert.ToDecimal(T2.Rows[0][3].ToString()).ToString("0.000");
            tbMeanFlatRes.Text = Convert.ToDecimal(T2.Rows[0][4].ToString()).ToString("0.000");
            tbMeanFlatRpt.Text = Convert.ToDecimal(T2.Rows[0][5].ToString()).ToString("0.000");


            limitChecker(tbMeanTopoRepeat, tbLimTopoRepeat);
            limitChecker(tbMeanStepRepeat, tbLimStepRepeat);
            limitChecker(tbMeanStepAcc1p8, tbLimStepAcc1p8);
            limitChecker(tbMeanStepAcc24, tbLimStepAcc24);
            limitChecker(tbMeanFlatRes, tbLimFlatRes);
            limitChecker(tbMeanFlatRpt, tbLimFlatRpt);

            da = new SqlDataAdapter(
                "  Select " +
                "  STDEV(TopoRepeat) " +
                " ,STDEV(SHRepeat) " +
                " ,STDEV([1p8umSHSacc]) " +
                " ,STDEV([24umSHSAcc]) " +
                " ,STDEV([FlatRes]) " +
                " ,STDEV([FlatRpt]) " +
                " FROM MicroscopeData WHERE " +
                " ProductLine = '" + g.ProductLine + "'", cnxn);

            DataTable T3 = new DataTable();

            try
            {
                da.Fill(T3);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            tbSdevTopoRepeat.Text = Convert.ToDecimal(T3.Rows[0][0].ToString()).ToString("0.000");
            tbSdevStepRepeat.Text = Convert.ToDecimal(T3.Rows[0][1].ToString()).ToString("0.000");
            tbSdevStepAcc1p8.Text = Convert.ToDecimal(T3.Rows[0][2].ToString()).ToString("0.000");
            tbSdevStepAcc24.Text = Convert.ToDecimal(T3.Rows[0][3].ToString()).ToString("0.000");
            tbStdFlatRes.Text = Convert.ToDecimal(T3.Rows[0][4].ToString()).ToString("0.000");
            tbStdFlatRpt.Text = Convert.ToDecimal(T3.Rows[0][5].ToString()).ToString("0.000");
        }

        private void limitChecker(TextBox box, TextBox limit)
        {
            if ((Convert.ToDecimal(limit.Text)) >= Convert.ToDecimal(box.Text))
            {
                box.BackColor = Color.FromArgb(150, 230, 180);
            }
            else
            {
                box.BackColor = Color.FromArgb(230, 150, 180);
            }
        }


        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
