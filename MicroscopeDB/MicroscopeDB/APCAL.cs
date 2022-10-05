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
    public partial class APCAL : Form
    {
        public APCAL()
        {
            InitializeComponent();
        }

        private void APCAL_Load(object sender, EventArgs e)
        {
            LproductLine.Text = g.ProductLine;

            SqlConnection cnxn = new SqlConnection(g.db);

            SqlDataAdapter da = new SqlDataAdapter(
                "  Select " +
                "  DateCode " +
                " ,SN " +
                " ,CAL_Obliq " +
                " ,CAL_EWL " +
                " ,CAL_ScanIncr " +
                " ,CAL_ScanCal " +
                " ,AP_camCtrX " +
                " ,AP_camCtrY " +
                " ,AP_camFoc " +
                " ,AP_camGrTilt " +
                " ,AP_camRot " +
                " ,AP_pupCtrX " +
                " ,AP_pupCtrY " +
                " ,AP_fsRpt " +
                " ,AP_asRpt " +
                " ,AP_zmFoc0p5x " +
                " ,AP_zmGrTilt0p5x " +
                " ,AP_zmFoc1x " +
                " ,AP_zmGrTilt1x " +
                " ,AP_zmFoc2x " +
                " ,AP_zmGrTilt2x " +
                " ,AP_dztRpt " +
                " FROM MicroscopeData WHERE " +
                " SN = '" + g.serialNumber + "'", cnxn);

            DataTable T1 = new DataTable();

            try
            {
                da.Fill(T1);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            LDateCode.Text = T1.Rows[0][0].ToString() + "-";
            Lsn.Text =  T1.Rows[0][1].ToString();

            // would like to just scan through first but too hard to figure out now
            //for (int i = 0; i < T1.Rows.Count; i++)
            //{
            //    if (String.IsNullOrEmpty(data[i]))
            //    {
            //        data[i] = "";
            //    }
            //}

            if (T1.Rows[0][2] == DBNull.Value)
            {
                tbCalObliq.Text = "";
            }
            else
            {
                tbCalObliq.Text = Convert.ToDecimal(T1.Rows[0][2].ToString()).ToString("0.0000");
            }

            if (T1.Rows[0][3] == DBNull.Value)
            {
                tbCalEWL.Text = "";
            }
            else
            {
                tbCalEWL.Text = Convert.ToDecimal(T1.Rows[0][3].ToString()).ToString("0.0000");
            }

            if (T1.Rows[0][4] == DBNull.Value)
            {
                tbCalScanIncr.Text = "";
            }
            else
            {
                tbCalScanIncr.Text = Convert.ToDecimal(T1.Rows[0][4].ToString()).ToString("0.0000");
            }

            if (T1.Rows[0][5] == DBNull.Value)
            {
                tbCalScanCal.Text = "";
            }
            else
            {
                tbCalScanCal.Text = Convert.ToDecimal(T1.Rows[0][5].ToString()).ToString("0.0000");
            }

            if (T1.Rows[0][6] == DBNull.Value)
            {
                tbAPcamCtrX.Text = "";
            }
            else
            {
                tbAPcamCtrX.Text = Convert.ToDecimal(T1.Rows[0][6].ToString()).ToString("0.0000");
            }

            if (T1.Rows[0][7] == DBNull.Value)
            {
                tbAPcamCtrY.Text = "";
            }
            else
            {
                tbAPcamCtrY.Text = Convert.ToDecimal(T1.Rows[0][7].ToString()).ToString("0.0000");
            }

            if (T1.Rows[0][8] == DBNull.Value)
            {
                tbAPcamFoc.Text = "";
            }
            else
            {
                tbAPcamFoc.Text = Convert.ToDecimal(T1.Rows[0][8].ToString()).ToString("0.0000");
            }

            if (T1.Rows[0][9] == DBNull.Value)
            {
                tbAPcamGrTilt.Text = "";
            }
            else
            {
                tbAPcamGrTilt.Text = Convert.ToDecimal(T1.Rows[0][9].ToString()).ToString("0.0000");
            }

            if (T1.Rows[0][10] == DBNull.Value)
            {
                tbAPcamRot.Text = "";
            }
            else
            {
                tbAPcamRot.Text = Convert.ToDecimal(T1.Rows[0][10].ToString()).ToString("0.0000");
            }

            if (T1.Rows[0][11] == DBNull.Value)
            {
                tbAPpupCtrX.Text = "";
            }
            else
            {
                tbAPpupCtrX.Text = Convert.ToDecimal(T1.Rows[0][11].ToString()).ToString("0.0000");
            }

            if (T1.Rows[0][12] == DBNull.Value)
            {
                tbAPpupCtrY.Text = "";
            }
            else
            {
                tbAPpupCtrY.Text = Convert.ToDecimal(T1.Rows[0][12].ToString()).ToString("0.0000");
            }

            if (T1.Rows[0][13] == DBNull.Value)
            {
                tbAPfsRpt.Text = "";
            }
            else
            {
                tbAPfsRpt.Text = Convert.ToDecimal(T1.Rows[0][13].ToString()).ToString("0.0000");
            }

            if (T1.Rows[0][14] == DBNull.Value)
            {
                tbAPasRpt.Text = "";
            }
            else
            {
                tbAPasRpt.Text = Convert.ToDecimal(T1.Rows[0][14].ToString()).ToString("0.0000");
            }

            if (T1.Rows[0][15] == DBNull.Value)
            {
                tbAPzmFoc0p5x.Text = "";
            }
            else
            {
                tbAPzmFoc0p5x.Text = Convert.ToDecimal(T1.Rows[0][15].ToString()).ToString("0.0000");
            }

            if (T1.Rows[0][16] == DBNull.Value)
            {
                tbAPzmGrTilt0p5x.Text = "";
            }
            else
            {
                tbAPzmGrTilt0p5x.Text = Convert.ToDecimal(T1.Rows[0][16].ToString()).ToString("0.0000");
            }

            if (T1.Rows[0][17] == DBNull.Value)
            {
                tbAPzmFoc1x.Text = "";
            }
            else
            {
                tbAPzmFoc1x.Text = Convert.ToDecimal(T1.Rows[0][17].ToString()).ToString("0.0000");
            }

            if (T1.Rows[0][18] == DBNull.Value)
            {
                tbAPzmGrTilt1X.Text = "";
            }
            else
            {
                tbAPzmGrTilt1X.Text = Convert.ToDecimal(T1.Rows[0][18].ToString()).ToString("0.0000");
            }

            if (T1.Rows[0][19] == DBNull.Value)
            {
                tbAPzmFoc2x.Text = "";
            }
            else
            {
                tbAPzmFoc2x.Text = Convert.ToDecimal(T1.Rows[0][19].ToString()).ToString("0.0000");
            }

            if (T1.Rows[0][20] == DBNull.Value)
            {
                tbAPzmGrTilt2x.Text = "";
            }
            else
            {
                tbAPzmGrTilt2x.Text = Convert.ToDecimal(T1.Rows[0][20].ToString()).ToString("0.0000");
            }

            if (T1.Rows[0][21] == DBNull.Value)
            {
                tbAPdztRpt.Text = "";
            }
            else
            {
                tbAPdztRpt.Text = Convert.ToDecimal(T1.Rows[0][21].ToString()).ToString("0.0000");
            }


            da = new SqlDataAdapter(
                "  Select " +
                "  AVG(CAL_ScanIncr) " +
                " ,AVG(CAL_ScanCal) " +
                " ,AVG(AP_camCtrX) " +
                " ,AVG(AP_camCtrY) " +
                " ,AVG(AP_camFoc) " +
                " ,AVG(AP_camGrTilt) " +
                " ,AVG(AP_camRot) " +
                " ,AVG(AP_pupCtrX) " +
                " ,AVG(AP_pupCtrY) " +
                " ,AVG(AP_fsRpt) " +
                " ,AVG(AP_asRpt) " +
                " ,AVG(AP_zmFoc0p5x) " +
                " ,AVG(AP_zmGrTilt0p5x) " +
                " ,AVG(AP_zmFoc1x) " +
                " ,AVG(AP_zmGrTilt1x) " +
                " ,AVG(AP_zmFoc2x) " +
                " ,AVG(AP_zmGrTilt2x) " +
                " ,AVG(AP_dztRpt) " +
                " FROM MicroscopeData", cnxn);

            DataTable T2 = new DataTable();

            try
            {
                da.Fill(T2);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            tbMeanCalScanIncr.Text = Convert.ToDecimal(T2.Rows[0][0].ToString()).ToString("0.000");
            tbMeanCalScanCal.Text = Convert.ToDecimal(T2.Rows[0][1].ToString()).ToString("0.000");
            tbMeanAPcamCtrX.Text = Convert.ToDecimal(T2.Rows[0][2].ToString()).ToString("0.000");
            tbMeanAPcamCtrY.Text = Convert.ToDecimal(T2.Rows[0][3].ToString()).ToString("0.000");
            tbMeanAPcamFoc.Text = Convert.ToDecimal(T2.Rows[0][4].ToString()).ToString("0.000");
            tbMeanAPcamGrTilt.Text = Convert.ToDecimal(T2.Rows[0][5].ToString()).ToString("0.000");
            tbMeanAPcamRot.Text = Convert.ToDecimal(T2.Rows[0][6].ToString()).ToString("0.000");
            tbMeanAPpupCtrX.Text = Convert.ToDecimal(T2.Rows[0][7].ToString()).ToString("0.000");
            tbMeanAPpupCtrY.Text = Convert.ToDecimal(T2.Rows[0][8].ToString()).ToString("0.000");
            tbMeanAPfsRpt.Text = Convert.ToDecimal(T2.Rows[0][9].ToString()).ToString("0.000");
            tbMeanAPasRpt.Text = Convert.ToDecimal(T2.Rows[0][10].ToString()).ToString("0.000");
            tbMeanAPzmFoc0p5x.Text = Convert.ToDecimal(T2.Rows[0][11].ToString()).ToString("0.000");
            tbMeanAPzmGrTilt0p5x.Text = Convert.ToDecimal(T2.Rows[0][12].ToString()).ToString("0.000");
            tbMeanAPzmFoc1x.Text = Convert.ToDecimal(T2.Rows[0][13].ToString()).ToString("0.000");
            tbMeanAPzmGrTilt1x.Text = Convert.ToDecimal(T2.Rows[0][14].ToString()).ToString("0.000");
            tbMeanAPzmFoc2x.Text = Convert.ToDecimal(T2.Rows[0][15].ToString()).ToString("0.000");
            tbMeanAPzmGrTilt2x.Text = Convert.ToDecimal(T2.Rows[0][16].ToString()).ToString("0.000");
            tbMeanAPdztRpt.Text = Convert.ToDecimal(T2.Rows[0][17].ToString()).ToString("0.000");

            if (g.ProductLine == "NV8000" | g.ProductLine == "NV9000")
            {
                label20.Visible = false;
                tbAPfsRpt.Visible = false;
                tbMeanAPfsRpt.Visible = false;
                label18.Visible = false;

                label1.Visible = false;
                tbAPasRpt.Visible = false;
                tbMeanAPasRpt.Visible = false;
                label5.Visible = false;
            }
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
