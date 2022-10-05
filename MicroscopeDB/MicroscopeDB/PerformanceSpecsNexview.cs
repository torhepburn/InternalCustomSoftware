using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MicroscopeDB
{
    public partial class PerformanceSpecsNexview : Form
    {
        private string SQL;

        public PerformanceSpecsNexview()
        {
            InitializeComponent();
        }

        private void PerformanceSpecs_Load(object sender, EventArgs e)
        {
            LproductLine.Text = g.ProductLine;

            tbLimIllumLoss.Text = g.LimIllumLoss;
            tbLimCnf50.Text = g.LimCnf50;
            tbLimCnfMax.Text = g.LimCnfMax;
            tbLimScanIncrErr.Text = g.LimScanIncrErr;
            tbLimScanLinErr.Text = g.LimScanLinErr;
            tbLimTopoRepeat.Text = g.LimTopoRepeat;
            tbLimRmsRepeat.Text = g.LimRmsRepeat;
            tbLimStepRepeat.Text = g.LimStepRepeat;
            tbLimSHaccPZT.Text = g.LimStepHeightAccuracyPZT;
            tbLimSHaccZ.Text = g.LimStepHeightAccuracyZ;
            
                SQL =
                "  AVG(ATP_IllumLoss) " +
                " ,AVG(ATP_Cnf50Hz) " +
                " ,AVG(ATP_CnfMax) " +
                " ,AVG(ATP_ScanIncrErr) " +
                " ,AVG(ATP_ScanLinErr) " +
                " ,AVG(ATP_TopoRpt) " +
                " ,AVG(ATP_RmsRpt) " +
                " ,(AVG(ATP_StepRpt_1p8) + AVG(ATP_StepRpt_24))/ 2 " +
                " ,(AVG(ATP_StepAcc_1p8) + AVG(ATP_StepAcc_24))/2 " +
                " ,AVG(ATP_StepAcc_24z) " +
                " FROM MicroscopeData WHERE " +
                " ProductLine = '" + g.ProductLine + "'";
            

            SqlConnection cnxn = new SqlConnection(g.db);

            SqlDataAdapter da = new SqlDataAdapter(
                "  Select " + SQL    , cnxn);

            DataTable T2 = new DataTable();

            try
            {
                da.Fill(T2);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            
            tbMeanIllumLoss.Text = g.MeanIllumLoss;
            tbMeanCnf50.Text = g.MeanCnf50;
            tbMeanCnfMax.Text = g.MeanCnfMax;
            tbMeanScanIncrErr.Text = g.MeanScanIncrErr;
            tbMeanScanLinErr.Text = g.MeanScanLinErr;
            tbMeanTopoRepeat.Text = g.MeanTopoRpt;
            tbMeanRmsRepeat.Text = g.MeanRmsRpt;
            tbMeanStepRepeat.Text = Convert.ToDecimal(T2.Rows[0][7].ToString()).ToString("0.000");
            tbMeanSHaccPZT.Text = Convert.ToDecimal(T2.Rows[0][8].ToString()).ToString("0.000");
            tbMeanSHaccZ.Text = Convert.ToDecimal(T2.Rows[0][9].ToString()).ToString("0.000");

            limitChecker(tbMeanIllumLoss, tbLimIllumLoss);
            limitChecker(tbMeanCnf50, tbLimCnf50);
            limitChecker(tbMeanCnfMax, tbLimCnfMax);
            limitChecker(tbMeanScanIncrErr, tbLimScanIncrErr);
            limitChecker(tbMeanScanLinErr, tbLimScanLinErr);
            limitChecker(tbMeanRmsRepeat, tbLimRmsRepeat);
            limitChecker(tbMeanTopoRepeat, tbLimTopoRepeat);
            limitChecker(tbMeanStepRepeat, tbLimStepRepeat);
            limitChecker(tbMeanSHaccPZT, tbLimSHaccPZT);
            limitChecker(tbMeanSHaccZ, tbLimSHaccZ);

            da = new SqlDataAdapter(
                "  Select " +
                "  STDEV(ATP_IllumLoss) " +
                " ,STDEV(ATP_Cnf50Hz) " +
                " ,STDEV(ATP_CnfMax) " +
                " ,STDEV(ATP_ScanIncrErr) " +
                " ,STDEV(ATP_ScanLinErr) " +
                " ,STDEV(ATP_TopoRpt) " +
                " ,STDEV(ATP_RmsRpt) " +
                " ,(STDEV(ATP_StepRpt_1p8) + STDEV(ATP_StepRpt_24))/ 2 " +
                " ,(STDEV(ATP_StepAcc_1p8) + STDEV(ATP_StepAcc_24))/2 " +
                " ,STDEV(ATP_StepAcc_24z) " +
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

            tbSdevIllumLoss.Text = Convert.ToDecimal(T3.Rows[0][0].ToString()).ToString("0.000");
            tbSdevCnf50.Text = Convert.ToDecimal(T3.Rows[0][1].ToString()).ToString("0.000");
            tbSdevCnfMax.Text = Convert.ToDecimal(T3.Rows[0][2].ToString()).ToString("0.000");
            tbSdevScanIncrErr.Text = Convert.ToDecimal(T3.Rows[0][3].ToString()).ToString("0.000");
            tbSdevScanLinErr.Text = Convert.ToDecimal(T3.Rows[0][4].ToString()).ToString("0.000");
            tbSdevTopoRepeat.Text = Convert.ToDecimal(T3.Rows[0][5].ToString()).ToString("0.000");
            tbSdevRmsRepeat.Text = Convert.ToDecimal(T3.Rows[0][6].ToString()).ToString("0.000");
            tbSdevStepHeightRepeat.Text = Convert.ToDecimal(T3.Rows[0][7].ToString()).ToString("0.000");
            tbSdevSHaccPZT.Text = Convert.ToDecimal(T3.Rows[0][8].ToString()).ToString("0.000");
            tbSdevSHaccZ.Text = Convert.ToDecimal(T3.Rows[0][9].ToString()).ToString("0.000");
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
