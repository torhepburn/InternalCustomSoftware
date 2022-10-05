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
    public partial class ATP : Form
    {
        SqlConnection cnxn = new SqlConnection(g.db);

        DataTable T1 = new DataTable();
        DataTable T2 = new DataTable();
        DataTable T3 = new DataTable();
        SqlDataAdapter da;

        private string SQL;

        public ATP()
        {
            InitializeComponent();
        }

        private void ATP_Load(object sender, EventArgs e)
        {
            LproductLine.Text = g.ProductLine;

            if (g.ProductLine.Substring(0,6) != "ZeGage" ) //& g.ProductLine != "ZeGagePlus" )
            {
                SQL =
                    " ,ATP_Operator " +
                    " ,NexViewATP " +
                    " ,ATP_IllumCntr " +
                    " ,ATP_IllumLoss " +
                    " ,ATP_Cnf50Hz " +
                    " ,ATP_CnfMax " +
                    " ,ATP_ScanIncrErr " +
                    " ,ATP_ScanLinErr " +
                    " ,ATP_TopoRpt " +
                    " ,ATP_RmsRpt " +
                    " ,ATP_CertStep_1p8 " +
                    " ,ATP_MeanStep_1p8 " +
                    " ,ATP_StepAcc_1p8 " +
                    " ,ATP_StepRpt_1p8 " +
                    " ,ATP_CertStep_24 " +
                    " ,ATP_MeanStep_24 " +
                    " ,ATP_StepAcc_24 " +
                    " ,ATP_StepRpt_24 " +
                    " ,ATP_MeanStep_24z " +
                    " ,ATP_StepAcc_24z " +
                    " ,ATP_StepRpt_24z ";

                getT1();
                
                tbATPversion.Text = T1.Rows[0][6].ToString();


                tbATPillumCntr.Text = Convert.ToDecimal(T1.Rows[0][7].ToString()).ToString("0.0");
                tbATPillumLoss.Text = Convert.ToDecimal(T1.Rows[0][8].ToString()).ToString("0.0");
                tbATPcnf50hz.Text = Convert.ToDecimal(T1.Rows[0][9].ToString()).ToString("0.00");
                tbATPcnfMax.Text = Convert.ToDecimal(T1.Rows[0][10].ToString()).ToString("0.00");
                tbATPscanIncrErr.Text = Convert.ToDecimal(T1.Rows[0][11].ToString()).ToString("0.000");
                tbATPscanLinErr.Text = Convert.ToDecimal(T1.Rows[0][12].ToString()).ToString("0.0");
                tbATPTopoRpt.Text = Convert.ToDecimal(T1.Rows[0][13].ToString()).ToString("0.000");
                tbATPremRpt.Text = Convert.ToDecimal(T1.Rows[0][14].ToString()).ToString("0.0000");


                tbATPcertStep1p8.Text = Convert.ToDecimal(T1.Rows[0][15].ToString()).ToString("0.000");
                tbATPmeanStep1p8.Text = Convert.ToDecimal(T1.Rows[0][16].ToString()).ToString("0.000");
                tbATPstepAcc1p8.Text = Convert.ToDecimal(T1.Rows[0][17].ToString()).ToString("0.000");
                tbATPstepRpt1p8.Text = Convert.ToDecimal(T1.Rows[0][18].ToString()).ToString("0.000");

                tbATPcertStep24.Text = Convert.ToDecimal(T1.Rows[0][19].ToString()).ToString("0.000");
                tbATPmeanStep24.Text = Convert.ToDecimal(T1.Rows[0][20].ToString()).ToString("0.000");
                tbATPstepAcc24.Text = Convert.ToDecimal(T1.Rows[0][21].ToString()).ToString("0.000");
                tbATPstepRpt24.Text = Convert.ToDecimal(T1.Rows[0][22].ToString()).ToString("0.000");

                // the database has eight rows of data where these fields are null for nexview
                if (T1.Rows[0][23].ToString().Length > 0)
                {
                    tbATPmeanStep24z.Text = Convert.ToDecimal(T1.Rows[0][23].ToString()).ToString("0.000");
                }
                if (T1.Rows[0][24].ToString().Length > 0)
                {
                    tbATPstepAcc24z.Text = Convert.ToDecimal(T1.Rows[0][24].ToString()).ToString("0.000");
                }
                if (T1.Rows[0][25].ToString().Length > 0)
                {
                    tbATPstepRpt24z.Text = Convert.ToDecimal(T1.Rows[0][25].ToString()).ToString("0.000");
                }

                da = new SqlDataAdapter(
                    "  Select " +
                    "  AVG(ATP_IllumCntr) " +
                    " ,AVG(ATP_IllumLoss) " +
                    " ,AVG(ATP_Cnf50Hz) " +
                    " ,AVG(ATP_CnfMax) " +
                    " ,AVG(ATP_ScanIncrErr) " +
                    " ,AVG(ATP_ScanLinErr) " +
                    " ,AVG(ATP_TopoRpt) " +
                    " ,AVG(ATP_RmsRpt) " +
                    " ,AVG(ATP_StepAcc_1p8) " +
                    " ,AVG(ATP_StepRpt_1p8) " +
                    " ,AVG(ATP_StepAcc_24) " +
                    " ,AVG(ATP_StepRpt_24) " +
                    " ,AVG(ATP_StepAcc_24z) " +
                    " ,AVG(ATP_StepRpt_24z) " +
                    " FROM MicroscopeData WHERE " +
                    " ProductLine = '" + g.ProductLine + "'", cnxn);

 
                try
                {
                    da.Fill(T2);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                tbMeanIllumCntr.Text = Convert.ToDecimal(T2.Rows[0][0].ToString()).ToString("0.0");

                g.MeanIllumLoss = Convert.ToDecimal(T2.Rows[0][1].ToString()).ToString("0.0");
                tbMeanIllumLoss.Text = g.MeanIllumLoss;
                g.MeanCnf50 = Convert.ToDecimal(T2.Rows[0][2].ToString()).ToString("0.00");
                tbMeanCnf50hz.Text = g.MeanCnf50;
                g.MeanCnfMax = Convert.ToDecimal(T2.Rows[0][3].ToString()).ToString("0.00");
                tbMeanCnfMax.Text = g.MeanCnfMax;
                g.MeanScanIncrErr = Convert.ToDecimal(T2.Rows[0][4].ToString()).ToString("0.000");
                tbMeanScanIncrErr.Text = g.MeanScanIncrErr;
                g.MeanScanLinErr = Convert.ToDecimal(T2.Rows[0][5].ToString()).ToString("0.0");
                tbMeanScanLinErr.Text = g.MeanScanLinErr;
                g.MeanTopoRpt = Convert.ToDecimal(T2.Rows[0][6].ToString()).ToString("0.000");
                tbMeanTopoRpt.Text = g.MeanTopoRpt;
                g.MeanRmsRpt = Convert.ToDecimal(T2.Rows[0][7].ToString()).ToString("0.0000");
                tbMeanRmsRpt.Text = g.MeanRmsRpt;
                
                tbMeanStepAcc1p8.Text = Convert.ToDecimal(T2.Rows[0][8].ToString()).ToString("0.000");
                tbMeanStepRpt1p8.Text = Convert.ToDecimal(T2.Rows[0][9].ToString()).ToString("0.000");
                tbMeanStepAcc24.Text = Convert.ToDecimal(T2.Rows[0][10].ToString()).ToString("0.000");
                tbMeanStepRpt24.Text = Convert.ToDecimal(T2.Rows[0][11].ToString()).ToString("0.000");
                tbMeanStepAcc24z.Text = Convert.ToDecimal(T2.Rows[0][12].ToString()).ToString("0.000");
                tbMeanStepRpt24z.Text = Convert.ToDecimal(T2.Rows[0][13].ToString()).ToString("0.000");


            }
            else    /*(g.ProductLine.Substring(0,6) == "ZeGage" ) */
            {
                SQL =
                    " ,ATPoperator " +  //5
                    
                    " ,[1p8umSHSAcc] " +
                    " ,[24umSHSAcc] " +
                    " ,SHRepeat " +         
                    " ,TopoRepeat " +   //9

                    " ,[1p8umCertSH] " +
                    " ,[24umCertSH] " +

                    " ,SH1p8Mean " +
                    " ,SH24Mean " +

                    " ,SH1p8SDev " +
                    " ,SH24SDev " +

                    " ,SH1p8upMean " +
                    " ,SH24upMean " +

                    " ,SH1p8upSDev " +
                    " ,SH24upSDev " +
                    
                    " ,ZeGageAtpVer ";

                getT1();

                label7.Text = "1.8 μm SH Accuracy:";
                label7.Location = new Point(39, 56);
                
                if (T1.Rows[0][6].ToString().Length > 0)
                {
                    tbATPillumCntr.Text = Convert.ToDecimal(T1.Rows[0][6].ToString()).ToString("0.000");
                }

                label6.Visible = false;
                tbATPillumLoss.Visible = false;
                tbMeanIllumLoss.Visible = false;
                label9.Visible = false;

                label13.Text = "24 μm SH Accuracy:";
                label13.Location = new Point(41, 108);
                label11.Text = "%";
                if (T1.Rows[0][7].ToString().Length > 0)
                {
                    tbATPcnf50hz.Text = Convert.ToDecimal(T1.Rows[0][7].ToString()).ToString("0.000");
                }

                
                label12.Visible = false;
                tbATPcnfMax.Visible = false;
                tbMeanCnfMax.Visible = false;
                label10.Visible = false;

                label17.Text = "SH Repeatability:";
                label17.Location = new Point(57, 160);
                if (T1.Rows[0][8].ToString().Length > 0)
                {
                    tbATPscanIncrErr.Text = Convert.ToDecimal(T1.Rows[0][8].ToString()).ToString("0.000");
                }

                label16.Visible = false;
                tbATPscanLinErr.Visible = false;
                tbMeanScanLinErr.Visible = false;
                label14.Visible = false;

                if (T1.Rows[0][9].ToString().Length > 0)
                {
                    tbATPTopoRpt.Text = Convert.ToDecimal(T1.Rows[0][9].ToString()).ToString("0.000");
                }

                label20.Visible = false;
                tbATPremRpt.Visible = false;
                tbMeanRmsRpt.Visible = false;
                label18.Visible = false;

                label5.Text = "ZeGageAtpVer";
                label5.Location = new Point(65, 354);
                tbATPversion.Text = T1.Rows[0][20].ToString();

                


                //step height performance details
                //row 1
                if (T1.Rows[0][10].ToString().Length > 0)
                {
                    tbATPcertStep1p8.Text = Convert.ToDecimal(T1.Rows[0][10].ToString()).ToString("0.0000");
                }

                if (T1.Rows[0][11].ToString().Length > 0)
                {
                    tbATPcertStep24.Text = Convert.ToDecimal(T1.Rows[0][11].ToString()).ToString("0.0000");
                }

                //row 2
                label27.Text = "Mean Measured Value - Z Down:";
                label27.Location = new Point(33, 87);
                if (T1.Rows[0][12].ToString().Length > 0)
                {
                    tbATPmeanStep1p8.Text = Convert.ToDecimal(T1.Rows[0][12].ToString()).ToString("0.0000");
                }

                if (T1.Rows[0][13].ToString().Length > 0)
                {
                    tbATPmeanStep24.Text = Convert.ToDecimal(T1.Rows[0][13].ToString()).ToString("0.0000");
                }

                //row 3
                label30.Text = "Std Dev Measured Value - Z Down:";
                label30.Location = new Point(21, 113);
                if (T1.Rows[0][14].ToString().Length > 0)
                {
                    tbATPstepAcc1p8.Text = Convert.ToDecimal(T1.Rows[0][14].ToString()).ToString("0.000000");
                }
                label32.Text = "μm";

                if (T1.Rows[0][15].ToString().Length > 0)
                {
                    tbATPstepAcc24.Text = Convert.ToDecimal(T1.Rows[0][15].ToString()).ToString("0.000000");
                }

                //row 4
                label31.Text = "Mean Measured Value - Z Up:";
                label31.Location = new Point(46, 139);
                if (T1.Rows[0][16].ToString().Length > 0)
                {
                    tbATPstepRpt1p8.Text = Convert.ToDecimal(T1.Rows[0][16].ToString()).ToString("0.0000");
                }

                if (T1.Rows[0][17].ToString().Length > 0)
                {
                    tbATPstepRpt24.Text = Convert.ToDecimal(T1.Rows[0][17].ToString()).ToString("0.0000");
                }
                label33.Text = "μm";
                tbMeanStepRpt1p8.Visible = false;
                tbMeanStepRpt24.Visible = false;

                //row 5
                label35.Text = "Std Dev Measured Value - Z Up:";
                label35.Location = new Point(36, 165);
                if (T1.Rows[0][18].ToString().Length > 0)
                {
                    tbSH1p8upSdev.Text = Convert.ToDecimal(T1.Rows[0][18].ToString()).ToString("0.000000");
                }
                tbSH1p8upSdev.Visible = true;

                if (T1.Rows[0][19].ToString().Length > 0)
                {
                    tbATPmeanStep24z.Text = Convert.ToDecimal(T1.Rows[0][19].ToString()).ToString("0.0000000");
                }
                tbMeanSH1p8upSDev.Visible = true;
                tbMeanATPmeanStep24z.Visible = true;


                //row 6
                label37.Visible = false;
                tbATPstepAcc24z.Visible = false;
                tbMeanStepAcc24z.Visible = false;
                label36.Visible = false;

                //row 7
                label40.Visible = false;
                tbATPstepRpt24z.Visible = false;
                tbMeanStepRpt24z.Visible = false;
                label41.Visible = false;


                da = new SqlDataAdapter(
                    "  Select " +
                    "  AVG([1p8umSHSAcc]) " +
                    " ,AVG([24umSHSAcc]) " +
                    " ,AVG(SHRepeat) " +
                    " ,AVG(TopoRepeat) " +


                    " ,CAST(AVG(SH1p8SDev) AS DECIMAL(18,7)) " +
                    " ,CAST(AVG(SH24SDev) AS DECIMAL(18,7)) " +
                    " ,CAST(AVG(SH1p8upSDev) AS DECIMAL(18,7)) " +
                    " ,CAST(AVG(SH24upSDev) AS DECIMAL(18,7)) " +

                    " FROM MicroscopeData WHERE " +
                    " ProductLine = '" + g.ProductLine + "'", cnxn);


                try
                {
                    da.Fill(T2);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                if (T2.Rows[0][0].ToString().Length > 0)
                {
                    tbMeanIllumCntr.Text = Convert.ToDecimal(T2.Rows[0][0].ToString()).ToString("0.000");
                }

                if (T2.Rows[0][1].ToString().Length > 0)
                {
                    tbMeanCnf50hz.Text = Convert.ToDecimal(T2.Rows[0][1].ToString()).ToString("0.000");
                }
                
                if (T2.Rows[0][2].ToString().Length > 0)
                {

                    tbMeanScanIncrErr.Text = Convert.ToDecimal(T2.Rows[0][2].ToString()).ToString("0.000");
                }
                
                if (T2.Rows[0][3].ToString().Length > 0)
                {

                    tbMeanTopoRpt.Text = Convert.ToDecimal(T2.Rows[0][3].ToString()).ToString("0.000");
                }


                if (T2.Rows[0][4].ToString().Length > 0)
                {

                    tbMeanStepAcc1p8.Text = Convert.ToDecimal(T2.Rows[0][4].ToString()).ToString("0.000000");
                }
                if (T2.Rows[0][5].ToString().Length > 0)
                {

                    tbMeanStepAcc24.Text = Convert.ToDecimal(T2.Rows[0][5].ToString()).ToString("0.000000");
                }
                if (T2.Rows[0][6].ToString().Length > 0)
                {
                    //int n = T2.Rows[0][6].ToString().Length;
                    //string j = T2.Rows[0][6].ToString();
                    tbMeanSH1p8upSDev.Text = Convert.ToDecimal(T2.Rows[0][6].ToString()).ToString("0.000000");
                }
                if (T2.Rows[0][7].ToString().Length > 0)
                {

                    tbMeanATPmeanStep24z.Text = Convert.ToDecimal(T2.Rows[0][7].ToString()).ToString("0.000000");
                }
            }


            Lsn2.Text = T1.Rows[0][1].ToString();
            Lsn3.Text = T1.Rows[0][1].ToString();
            Lsn4.Text = T1.Rows[0][1].ToString();

            LDateCode.Text = T1.Rows[0][0].ToString() + "-";
            Lsn.Text = T1.Rows[0][1].ToString();
            tbATPDate.Text = T1.Rows[0][2].ToString();
            tbTemperature.Text = T1.Rows[0][3].ToString();
            tbHumidity.Text = T1.Rows[0][4].ToString();
            tbATPoperator.Text = T1.Rows[0][5].ToString();

            da = new SqlDataAdapter(
           "  Select " +
           "  limIllumLoss " +      //0
           " ,limCnf50 " +
           " ,limCnfMax " +
           " ,limScanIncrErr " +
           " ,limScanLinErr " +
           " ,limTopoRepeat " +     //5
           " ,limRmsRepeat " +
           " ,limStepRepeat " +
           " ,limStepHeightAccuracyPZT " +
           " ,limStepHeightAccuracyZ " +    //9
           " ,lim1p8StepHeightAccuracy " +
           " ,lim24StepHeightAccuracy " +

           " FROM MicroscopeSpecs WHERE " +
           " ProductLine = '" + g.ProductLine + "'", cnxn);



            try
            {
                da.Fill(T3);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            if (T3.Rows[0][0].ToString().Length > 0)
            {
                g.LimIllumLoss = Convert.ToDecimal(T3.Rows[0][0].ToString()).ToString("0");
                limitChecker(tbATPillumLoss, g.LimIllumLoss);
            }
            if (T3.Rows[0][1].ToString().Length > 0)
            {
                g.LimCnf50 = Convert.ToDecimal(T3.Rows[0][1].ToString()).ToString("0.0");
                limitChecker(tbATPcnf50hz, g.LimCnf50);
            }
            if (T3.Rows[0][2].ToString().Length > 0)
            {
                g.LimCnfMax = Convert.ToDecimal(T3.Rows[0][2].ToString()).ToString("0.0");
                limitChecker(tbATPcnfMax, g.LimCnfMax);
            }
            if (T3.Rows[0][3].ToString().Length > 0)
            {
                g.LimScanIncrErr = Convert.ToDecimal(T3.Rows[0][3].ToString()).ToString("0.0");
                limitChecker(tbATPscanIncrErr, g.LimScanIncrErr);
            }
            if (T3.Rows[0][4].ToString().Length > 0)
            {
                g.LimScanLinErr = Convert.ToDecimal(T3.Rows[0][4].ToString()).ToString("0");
                limitChecker(tbATPscanLinErr, g.LimScanLinErr);
            }
            if (T3.Rows[0][5].ToString().Length > 0)
            {
                g.LimTopoRepeat = Convert.ToDecimal(T3.Rows[0][5].ToString()).ToString("0.000");
                limitChecker(tbATPTopoRpt, g.LimTopoRepeat);
            }
            if (T3.Rows[0][6].ToString().Length > 0)
            {
                g.LimRmsRepeat = Convert.ToDecimal(T3.Rows[0][6].ToString()).ToString("0.000");

                if (g.ProductLine.Substring(0,6) != "ZeGage")
                {
                    limitChecker(tbATPremRpt, g.LimRmsRepeat);
                }
            }
            if (T3.Rows[0][7].ToString().Length > 0)
            {
                g.LimStepRepeat = Convert.ToDecimal(T3.Rows[0][7].ToString()).ToString("0.000");

                if (g.ProductLine.Substring(0, 6) != "ZeGage")
                {
                    limitChecker(tbATPstepRpt1p8, g.LimStepRepeat);
                    limitChecker(tbATPstepRpt24, g.LimStepRepeat);
                }
                else
                {
                    limitChecker(tbATPscanIncrErr, g.LimStepRepeat);
                }
            }
            if (T3.Rows[0][8].ToString().Length > 0)
            {
                //  all but ZeGages
                g.LimStepHeightAccuracyPZT = Convert.ToDecimal(T3.Rows[0][8].ToString()).ToString("0.000");
                limitChecker(tbATPstepAcc1p8, g.LimStepHeightAccuracyPZT);
                limitChecker(tbATPstepAcc24, g.LimStepHeightAccuracyPZT);
            }
            if (T3.Rows[0][9].ToString().Length > 0 & tbATPstepAcc24z.Text.Length > 0)
            {
                //  all but Zegages
                g.LimStepHeightAccuracyZ = Convert.ToDecimal(T3.Rows[0][9].ToString()).ToString("0.000");
                limitChecker(tbATPstepAcc24z, g.LimStepHeightAccuracyZ);
            }
            if (T3.Rows[0][10].ToString().Length > 0)
            {
                //  ZeGages only
                g.Lim1p8StepHeightAccuracy = Convert.ToDecimal(T3.Rows[0][10].ToString()).ToString("0.000");
                limitChecker(tbATPillumCntr, g.Lim1p8StepHeightAccuracy);
            }
            if (T3.Rows[0][11].ToString().Length > 0)
            {
                //  ZeGages only
                g.Lim24StepHeightAccuracy = Convert.ToDecimal(T3.Rows[0][11].ToString()).ToString("0.000");
                limitChecker(tbATPcnf50hz, g.Lim24StepHeightAccuracy);
            }
         }

        private void limitChecker(TextBox box, string limit)
        {
            if ((Convert.ToDecimal(limit)) >= Convert.ToDecimal(box.Text))
            {
                box.BackColor = Color.FromArgb(150, 230, 180);
            }
            else
            {
                box.BackColor = Color.FromArgb(230, 150, 180);
            }

        }

        private void getT1()
        {
            da = new SqlDataAdapter(
                    "  Select " +
                    "  DateCode " +
                    " ,SN " +
                    " ,AtpDate " +
                    " ,Temp " +
                    " ,Humidity " +
                    
                      SQL +
                    " FROM MicroscopeData WHERE " +
                    " SN = '" + g.serialNumber + "'", cnxn);

            try
            {
                da.Fill(T1);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BviewLimits_Click(object sender, EventArgs e)
        {
            if (g.ProductLine == "Nexview")
            {
                PerformanceSpecsNexview p = new PerformanceSpecsNexview();
                p.ShowDialog();
            }

            if (g.ProductLine == "Nexview2")
            {
                PerformanceSpecsNexview2 p = new PerformanceSpecsNexview2();
                p.ShowDialog();
            }

            if (g.ProductLine == "NV8000")
            {
                PerformanceSpecsNV8000 p = new PerformanceSpecsNV8000();
                p.ShowDialog();
            }

            if (g.ProductLine == "NV9000")
            {
                PerformanceSpecsNV9000 p = new PerformanceSpecsNV9000();
                p.ShowDialog();
            }

            if (g.ProductLine == "ZeGage" | g.ProductLine.Substring(0, 10) == "ZeGage Pro")
            {
                PerformanceSpecsZeGage p = new PerformanceSpecsZeGage();
                p.ShowDialog();
            }

            if (g.ProductLine == "ZeGagePlus")
            {
                PerformanceSpecsZeGagePlus p = new PerformanceSpecsZeGagePlus();
                p.ShowDialog();
            }
        }

    }
}
