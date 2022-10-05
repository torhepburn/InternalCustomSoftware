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
    public partial class SystemInfo : Form
    {
        private string SQL;
        private string bAction;

        public SystemInfo()
        {
            InitializeComponent();
        }

        private void SystemInfo_Load(object sender, EventArgs e)
        {
            if (g.task == "View")
            {
                Bsave.Visible = false;
                this.Text = "View System Info";
                this.BackColor = Color.FromArgb(255, 255, 154);
            }
            else
            {
                this.Text = "Edit System Info";
            }

            LproductLine.Text = g.ProductLine;

            if (g.ProductLine == "Nexview" | g.ProductLine == "Nexview2")
            {
                LnexRLED.Text = "6450-8187-01:";
                Lx.Text = "iPOS3602(X):";
                Ly.Text = "iPOS3602(Y):";
                Lp.Text = "iPOS3602(P):";
                Lr.Text = "iPOS3602(R):";
                Lrpstage.Text = "PR-Stage:";

                SQL =
                    "  DateCode " +
                    " ,SN " +
                    " ,PN " +
                    " ,Customer " +
                    " ,EndCustomer " +
                    " ,OrderNum " +
                    " ,WaiverNum " +
                    " ,ShipDate " +
                    " ,Destination " +
                    " ,QcEmployeeID " +
                    " ,QcName " +
                    " ,InstallProblems " +
                    " ,InstallReport " +
                    " ,MacAddress " +       
                    " ,[6450-8101-01] " +     //14
                    " ,[6450-8185-01] " +
                    " ,[6450-8187-01] " +
                    " ,[6450-8109-01] " +
                    " ,[6450-8504-04] " +
                    " ,[iPOS3602(X)] " +
                    " ,[iPOS3602(Y)] " +
                    " ,[800-1621(Z)] " +
                    " ,[iPOS3602(P)] " +
                    " ,[iPOS3602(R)] " +
                    " ,Scanner " +
                    " ,Camera " +
                    " ,ZStage " +
                    " ,[XY-Stage] " +
                    " ,[PR-Stage] " +
                    " ,SystemCtrl " +
                    " ,MxVer " +
                    " ,LicenseHwId " +
                    " ,Comments";
            }

            //if (g.ProductLine == "Nexview2")
            //{
            //    LnexRLED.Text = "6450-8187-01";
            //    Lx.Text = "800-1621(X)";
            //    Ly.Text = "800-1621(Y)";
            //    Lp.Text = "800-1621(P)";
            //    Lr.Text = "800-1621(R)";
            //    Lrpstage.Text = "RP-Stage";

            //    SQL =
            //       "  DateCode " +
            //       " ,SN " +
            //       " ,PN " +
            //       " ,Customer " +
            //       " ,EndCustomer " +
            //       " ,OrderNum " +
            //       " ,WaiverNum " +
            //       " ,ShipDate " +
            //       " ,Destination " +
            //       " ,QcEmployeeID " +
            //       " ,QcName " +
            //       " ,InstallProblems " +
            //       " ,InstallReport " +
            //       " ,MacAddress " +
            //       " ,6450-8101-01 " +
            //       " ,6450-8185-01 " +
            //       " ,6450-8187-01 " +
            //       " ,6450-8109-01 " +
            //       " ,6450-8504-04 " +
            //       " ,[800-1621(X)] " +
            //       " ,[800-1621(Y)] " +
            //       " ,[800-1621(Z)] " +
            //       " ,[800-1621(P)] " +
            //       " ,[800-1621(R)] " +
            //       " ,ZStage " +
            //       " ,[XY-Stage] " +
            //       " ,[PR-Stage] " +
            //       " ,Scanner " +
            //       " ,Camera " +
            //       " ,SystemCtrl " +
            //       " ,MxVer " +
            //       " ,LicenseHwId " +
            //       " ,Comments";
            //}

            if (g.ProductLine == "NV8000" | g.ProductLine == "NV9000")
            {
                LnexRLED.Visible = false;
                tbNexRLED.Visible = false;
                Lx.Text = "800-1621(X):";
                Lx.Location = new Point(93, 209);
                Ly.Text = "800-1621(Y):";
                Ly.Location = new Point(93, 235);
                Lp.Text = "800-1621(P):";
                Lp.Location = new Point(93, 285);
                Lr.Text = "800-1621(R):";
                Lr.Location = new Point(92, 312);
                Lrpstage.Text = "PR-Stage:";

                SQL =
                   "  DateCode " +
                   " ,SN " +
                   " ,PN " +
                   " ,Customer " +
                   " ,EndCustomer " +
                   " ,OrderNum " +
                   " ,WaiverNum " +
                   " ,ShipDate " +
                   " ,Destination " +
                   " ,QcEmployeeID " +
                   " ,QcName " +
                   " ,InstallProblems " +
                   " ,InstallReport " +
                   " ,MacAddress " +
                   " ,[6450-8101-01] " +
                   " ,[6450-8185-01] " +
                   " ,[6450-8187-01] " +      //16
                   " ,[6450-8109-01] " +
                   " ,[6450-8504-04] " +
                   " ,[800-1621(X)] " +     //19
                   " ,[800-1621(Y)] " +     //20
                   " ,[800-1621(Z)] " +
                   " ,[800-1621(P)] " +     //22
                   " ,[800-1621(R)] " +     //23
                   " ,Scanner " +
                   " ,Camera " +
                   " ,ZStage " +
                   " ,[XY-Stage] " +
                   " ,[PR-Stage] " +
                   " ,SystemCtrl " +
                   " ,MxVer " +
                   " ,LicenseHwId " + 
                   " ,Comments";
            }


            if (g.ProductLine == "ZeGage" | g.ProductLine == "ZeGagePlus")
            {
                Lbridge.Text = "Bridge:";
                Lbridge.Location = new Point(119, 70);
                LLED.Text = "CANdelier / CANdelabra III:";
                LLED.Location = new Point(23, 96);
                LnexRLED.Text = "CANdelabra:";
                LnexRLED.Location = new Point(92, 122);
                Ldual.Text = "Dual Motor Ctrl:";
                Ldual.Location = new Point(80, 148);
                Lmotion.Text = "Motion Ctrl:";
                Lmotion.Location = new Point(98, 174);
                Lx.Text = "Stepper Ctrl X:";
                Lx.Location = new Point(84, 209);
                Ly.Text = "Stepper Ctrl Y:";
                Ly.Location = new Point(84, 235);
                Lz.Text = "Stepper Ctrl Z:";
                Lz.Location = new Point(84, 261);
                Lp.Visible= false;
                tbP.Visible = false;
                Lr.Visible = false;
                tbR.Visible = false;
                Lscanner.Visible = false;
                tbScanner.Visible = false;
                Lrpstage.Text = "PR-Stage:";
                Lrpstage.Location = new Point(105, 463);
                LmxVersion.Text = "Mx / ZeMaps Version:";
                LmxVersion.Location = new Point(49, 524);

                SQL =
                   "  DateCode " +
                   " ,SN " +
                   " ,PN " +
                   " ,Customer " +
                   " ,EndCustomer " +
                   " ,OrderNum " +
                   " ,WaiverNum " +
                   " ,ShipDate " +
                   " ,Destination " +
                   " ,QcEmployeeID " +
                   " ,QcName " +
                   " ,InstallProblems " +
                   " ,InstallReport " +
                   " ,MacAddress " +
                   " ,Bridge " +
                   " ,CANdelabraIII " +
                   " ,CANdelabra " +
                   " ,DualMotorCtrl " +
                   " ,MotionCtrl " +
                   " ,StepperCtrlX " +
                   " ,StepperCtrlY " +
                   " ,StepperCtrlZ " +
                   " ,ZStage " +
                   " ,[XY-Stage] " +
                   " ,[PR-Stage] " +
                   " ,Camera " +
                   " ,SystemCtrl " +
                   " ,ZeMapsVer " +
                   " ,LicenseHwId " +
                   " ,Comments"; 
            }


            if (g.ProductLine == "ZeGage Pro" | g.ProductLine == "ZeGage Pro HR")
            {
                Lbridge.Text = "Bridge:";
                Lbridge.Location = new Point(119, 70);
                LLED.Text = "CANdelier:";
                LLED.Location = new Point(100, 96);
                LnexRLED.Visible = false;
                tbNexRLED.Visible = false;
                Ldual.Text = "Dual Motor Ctrl:";
                Ldual.Location = new Point(80, 148);
                Lmotion.Text = "Motion Ctrl:";
                Lmotion.Location = new Point(98, 174);
                Lx.Text = "Stepper Ctrl X:";
                Lx.Location = new Point(84, 209);
                Ly.Text = "Stepper Ctrl Y:";
                Ly.Location = new Point(84, 235);
                Lz.Text = "Stepper Ctrl Z:";
                Lz.Location = new Point(84, 261);
                Lp.Visible = false;
                tbP.Visible = false;
                Lr.Visible = false;
                tbR.Visible = false;
                Lscanner.Visible = false;
                tbScanner.Visible = false;
                Lrpstage.Text = "PR-Stage:";
                Lrpstage.Location = new Point(105, 463);
                //LmxVersion.Text = "Mx Version:";
                //LmxVersion.Location = new Point(49, 524);

                SQL =
                   "  DateCode " +
                   " ,SN " +
                   " ,PN " +
                   " ,Customer " +
                   " ,EndCustomer " +
                   " ,OrderNum " +
                   " ,WaiverNum " +
                   " ,ShipDate " +
                   " ,Destination " +
                   " ,QcEmployeeID " +
                   " ,QcName " +
                   " ,InstallProblems " +
                   " ,InstallReport " +
                   " ,MacAddress " +
                   " ,Bridge " +
                   " ,CANdelabraIII " +
                   " ,CANdelabra " +
                   " ,DualMotorCtrl " +
                   " ,MotionCtrl " +
                   " ,StepperCtrlX " +
                   " ,StepperCtrlY " +
                   " ,StepperCtrlZ " +
                   " ,ZStage " +
                   " ,[XY-Stage] " +
                   " ,[PR-Stage] " +
                   " ,Camera " +
                   " ,SystemCtrl " +
                   " ,MxVer " +
                   " ,LicenseHwId " +
                   " ,Comments";
            }


            SqlConnection cnxn = new SqlConnection(g.db);

            SqlDataAdapter da = new SqlDataAdapter(
                " Select " +
                  SQL +
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



            if (g.ProductLine.Substring(0,6) != "ZeGage" ) //& g.ProductLine != "ZeGagePlus")
            {
                LDateCode.Text = T1.Rows[0][0].ToString() + "-";
                Lsn.Text = T1.Rows[0][1].ToString();
                cbddPartNumber.Text = T1.Rows[0][2].ToString();
                tbCustomer.Text = T1.Rows[0][3].ToString();
                tbEndCustomer.Text = T1.Rows[0][4].ToString();
                tbOrderNumber.Text = T1.Rows[0][5].ToString();
                tbWaiverNumber.Text = T1.Rows[0][6].ToString();
                dtpShipDate.Text = T1.Rows[0][7].ToString();
                tbDestination.Text = T1.Rows[0][8].ToString();
                tbQCID.Text = T1.Rows[0][9].ToString();
                tbInspector.Text = T1.Rows[0][10].ToString();
                cbddReport.Text = T1.Rows[0][11].ToString();
                cbddProblem.Text = T1.Rows[0][12].ToString();
                tbMacAddress.Text = T1.Rows[0][13].ToString();
                tbBridge.Text = T1.Rows[0][14].ToString();
                tbLED.Text = T1.Rows[0][15].ToString();
                tbNexRLED.Text = T1.Rows[0][16].ToString();
                tbDual.Text = T1.Rows[0][17].ToString();
                tbMotion.Text = T1.Rows[0][18].ToString();
                tbX.Text = T1.Rows[0][19].ToString();
                tbY.Text = T1.Rows[0][20].ToString();
                tbZ.Text = T1.Rows[0][21].ToString();
                tbP.Text = T1.Rows[0][22].ToString();
                tbR.Text = T1.Rows[0][23].ToString();
                tbScanner.Text = T1.Rows[0][24].ToString();
                tbCamera.Text = T1.Rows[0][25].ToString();
                tbZstage.Text = T1.Rows[0][26].ToString();
                tbXYstage.Text = T1.Rows[0][27].ToString();
                tbRPstage.Text = T1.Rows[0][28].ToString();
                tbSystemController.Text = T1.Rows[0][29].ToString();
                tbMxVersion.Text = T1.Rows[0][30].ToString();
                tbLicense.Text = T1.Rows[0][31].ToString();
                tbComments.Text = T1.Rows[0][32].ToString();
            }
            else
            {
                LDateCode.Text = T1.Rows[0][0].ToString() + "-";
                Lsn.Text = T1.Rows[0][1].ToString();
                cbddPartNumber.Text = T1.Rows[0][2].ToString();
                tbCustomer.Text = T1.Rows[0][3].ToString();
                tbEndCustomer.Text = T1.Rows[0][4].ToString();
                tbOrderNumber.Text = T1.Rows[0][5].ToString();
                tbWaiverNumber.Text = T1.Rows[0][6].ToString();
                dtpShipDate.Text = T1.Rows[0][7].ToString();
                tbDestination.Text = T1.Rows[0][8].ToString();
                tbQCID.Text = T1.Rows[0][9].ToString();
                tbInspector.Text = T1.Rows[0][10].ToString();
                cbddReport.Text = T1.Rows[0][11].ToString();
                cbddProblem.Text = T1.Rows[0][12].ToString();
                tbMacAddress.Text = T1.Rows[0][13].ToString();
                tbBridge.Text = T1.Rows[0][14].ToString();
                tbLED.Text = T1.Rows[0][15].ToString();
                tbNexRLED.Text = T1.Rows[0][16].ToString();
                tbDual.Text = T1.Rows[0][17].ToString();
                tbMotion.Text = T1.Rows[0][18].ToString();
                tbX.Text = T1.Rows[0][19].ToString();
                tbY.Text = T1.Rows[0][20].ToString();
                tbZ.Text = T1.Rows[0][21].ToString();

                tbCamera.Text = T1.Rows[0][25].ToString();
                tbZstage.Text = T1.Rows[0][22].ToString();
                tbXYstage.Text = T1.Rows[0][23].ToString();
                tbRPstage.Text = T1.Rows[0][24].ToString();
                tbSystemController.Text = T1.Rows[0][26].ToString();
                tbMxVersion.Text = T1.Rows[0][27].ToString();
                tbLicense.Text = T1.Rows[0][28].ToString();
                tbComments.Text = T1.Rows[0][29].ToString();
            }

            if (g.task == "View")
            {
                cbddPartNumber.Enabled = false;
                tbCustomer.ReadOnly = true; 
                tbEndCustomer.ReadOnly = true;
                tbOrderNumber.ReadOnly = true;
                tbWaiverNumber.ReadOnly = true;
                dtpShipDate.Enabled = false;
                tbDestination.ReadOnly = true;
                tbInspector.ReadOnly = true;
                tbQCID.ReadOnly = true;
                cbddReport.Enabled = false;
                cbddProblem.Enabled = false;
                tbMacAddress.ReadOnly = true;
                tbBridge.ReadOnly = true;
                tbLED.ReadOnly = true;
                tbNexRLED.ReadOnly = true;
                tbDual.ReadOnly = true;
                tbMotion.ReadOnly = true;
                tbX.ReadOnly = true;
                tbY.ReadOnly = true;
                tbZ.ReadOnly = true;
                tbP.ReadOnly = true;
                tbR.ReadOnly = true;
                tbScanner.ReadOnly = true;
                tbCamera.ReadOnly = true;
                tbZstage.ReadOnly = true;
                tbXYstage.ReadOnly = true;
                tbRPstage.ReadOnly = true;
                tbSystemController.ReadOnly = true;
                tbMxVersion.ReadOnly = true;
                tbLicense.ReadOnly = true;
                tbComments.ReadOnly = true;

                Bsave.Visible = false;
            }
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Bsave_Click(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection(g.db);

            SqlParameter pConfigurationPN = new SqlParameter
                ("@ConfigurationPN", SqlDbType.NChar);
            if (cbddPartNumber.Text.Length > 0)
            {
                pConfigurationPN.Value = cbddPartNumber.Text;
            }
            else
            {
                pConfigurationPN.Value = DBNull.Value;
            }

            SqlParameter pCustomer = new SqlParameter
                ("@Customer", SqlDbType.NChar);
            if (tbCustomer.Text.Length > 0)
            {
                pCustomer.Value = tbCustomer.Text;
            }
            else
            {
                pCustomer.Value = DBNull.Value;
            }

            SqlParameter pEndCustomer = new SqlParameter
                ("@EndCustomer", SqlDbType.NChar);
            if (tbEndCustomer.Text.Length > 0)
            {
                pEndCustomer.Value = tbEndCustomer.Text;
            }
            else
            {
                pEndCustomer.Value = DBNull.Value;
            }

            SqlParameter pOrderNum = new SqlParameter
                ("@OrderNum", SqlDbType.NChar);
            if (tbOrderNumber.Text.Length > 0)
            {
                pOrderNum.Value = tbOrderNumber.Text;
            }
            else
            {
                pOrderNum.Value = DBNull.Value;
            }

            SqlParameter pWaiverNum = new SqlParameter
                ("@WaiverNum", SqlDbType.NChar);
            if (tbWaiverNumber.Text.Length > 0)
            {
                pWaiverNum.Value = tbWaiverNumber.Text;
            }
            else
            {
                pWaiverNum.Value = DBNull.Value;
            }

            SqlParameter pShipDate = new SqlParameter
                ("@ShipDate", SqlDbType.Date);
            if (dtpShipDate.Text.Length > 0)
            {
                pShipDate.Value = dtpShipDate.Text;
            }
            else
            {
                pShipDate.Value = DBNull.Value;
            }

            SqlParameter pDestination = new SqlParameter
                ("@Destination", SqlDbType.NChar);
            if (tbDestination.Text.Length > 0)
            {
                pDestination.Value = tbDestination.Text;
            }
            else
            {
                pDestination.Value = DBNull.Value;
            }

            SqlParameter pQcName = new SqlParameter
                ("@QcName", SqlDbType.NChar);
            if (tbInspector.Text.Length > 0)
            {
                pQcName.Value = tbInspector.Text;
            }
            else
            {
                pQcName.Value = DBNull.Value;
            }

            SqlParameter pQcEmployeeID = new SqlParameter
                ("@QcEmployeeID", SqlDbType.NChar);
            if (tbQCID.Text.Length > 0)
            {
                pQcEmployeeID.Value = tbQCID.Text;
            }
            else
            {
                pQcEmployeeID.Value = DBNull.Value;
            }

            SqlParameter pInstallReport = new SqlParameter
                ("@InstallReport", SqlDbType.NChar);
            if (cbddReport.Text.Length > 0)
            {
                pInstallReport.Value = cbddReport.Text;
            }
            else
            {
                pInstallReport.Value = DBNull.Value;
            }

            SqlParameter pInstallProblems = new SqlParameter
                ("@InstallProblems", SqlDbType.NChar);
            if (cbddProblem.Text.Length > 0)
            {
                pInstallProblems.Value = cbddProblem.Text;
            }
            else
            {
                pInstallProblems.Value = DBNull.Value;
            }

            SqlParameter pComments = new SqlParameter
                ("@Comments", SqlDbType.NChar);
            if (tbComments.Text.Length > 0)
            {
                pComments.Value = tbComments.Text;
            }
            else
            {
                pComments.Value = DBNull.Value;
            }


            SqlParameter pMACaddress = new SqlParameter
                ("@MACaddress", SqlDbType.NChar);
            if (tbMacAddress.Text.Length > 0)
            {
                pMACaddress.Value = tbMacAddress.Text;
            }
            else
            {
                pMACaddress.Value = DBNull.Value;
            }

            SqlParameter pBridge = new SqlParameter
                ("@Bridge", SqlDbType.NChar);
            if (tbBridge.Text.Length > 0)
            {
                pBridge.Value = tbBridge.Text;
            }
            else
            {
                pBridge.Value = DBNull.Value;
            }

            SqlParameter pLED = new SqlParameter
                ("@LED", SqlDbType.NChar);
            if (tbLED.Text.Length > 0)
            {
                pLED.Value = tbLED.Text;
            }
            else
            {
                pLED.Value = DBNull.Value;
            }

            SqlParameter pNexRLED = new SqlParameter
                ("@NexRLED", SqlDbType.NChar);
            if (tbNexRLED.Text.Length > 0)
            {
                pNexRLED.Value = tbNexRLED.Text;
            }
            else
            {
                pNexRLED.Value = DBNull.Value;
            }

            SqlParameter pDual = new SqlParameter
                ("@Dual", SqlDbType.NChar);
            if (tbDual.Text.Length > 0)
            {
                pDual.Value = tbDual.Text;
            }
            else
            {
                pDual.Value = DBNull.Value;
            }

            SqlParameter pMotion = new SqlParameter
                ("@Motion", SqlDbType.NChar);
            if (tbMotion.Text.Length > 0)
            {
                pMotion.Value = tbMotion.Text;
            }
            else
            {
                pMotion.Value = DBNull.Value;
            }

            SqlParameter pX = new SqlParameter
                ("@X", SqlDbType.NChar);
            if (tbX.Text.Length > 0)
            {
                pX.Value = tbX.Text;
            }
            else
            {
                pX.Value = DBNull.Value;
            }

            SqlParameter pY = new SqlParameter
                ("@Y", SqlDbType.NChar);
            if (tbY.Text.Length > 0)
            {
                pY.Value = tbY.Text;
            }
            else
            {
                pY.Value = DBNull.Value;
            }

            SqlParameter pZ = new SqlParameter
                ("@Z", SqlDbType.NChar);
            if (tbZ.Text.Length > 0)
            {
                pZ.Value = tbZ.Text;
            }
            else
            {
                pZ.Value = DBNull.Value;
            }

            SqlParameter pP = new SqlParameter
                ("@P", SqlDbType.NChar);
            if (tbP.Text.Length > 0)
            {
                pP.Value = tbP.Text;
            }
            else
            {
                pP.Value = DBNull.Value;
            }

            SqlParameter pR = new SqlParameter
                ("@R", SqlDbType.NChar);
            if (tbR.Text.Length > 0)
            {
                pR.Value = tbR.Text;
            }
            else
            {
                pR.Value = DBNull.Value;
            }

            SqlParameter pScanner = new SqlParameter
                ("@Scanner", SqlDbType.NChar);
            if (tbScanner.Text.Length > 0)
            {
                pScanner.Value = tbScanner.Text;
            }
            else
            {
                pScanner.Value = DBNull.Value;
            }

            SqlParameter pCamera = new SqlParameter
                ("@Camera", SqlDbType.NChar);
            if (tbCamera.Text.Length > 0)
            {
                pCamera.Value = tbCamera.Text;
            }
            else
            {
                pCamera.Value = DBNull.Value;
            }

            SqlParameter pZstage = new SqlParameter
                ("@ZstageX", SqlDbType.NChar);
            if (tbZstage.Text.Length > 0)
            {
                pZstage.Value = tbZstage.Text;
            }
            else
            {
                pZstage.Value = DBNull.Value;
            }

            SqlParameter pXYstage = new SqlParameter
                ("@XYstageX", SqlDbType.NChar);
            if (tbXYstage.Text.Length > 0)
            {
                pXYstage.Value = tbXYstage.Text;
            }
            else
            {
                pXYstage.Value = DBNull.Value;
            }

            SqlParameter pPRstage = new SqlParameter
                ("@PRstageX", SqlDbType.NChar);
            if (tbRPstage.Text.Length > 0)
            {
                pPRstage.Value = tbRPstage.Text;
            }
            else
            {
                pPRstage.Value = DBNull.Value;
            }

            SqlParameter pSystemController = new SqlParameter
                ("@SystemController", SqlDbType.NChar);
            if (tbSystemController.Text.Length > 0)
            {
                pSystemController.Value = tbSystemController.Text;
            }
            else
            {
                pSystemController.Value = DBNull.Value;
            }

            SqlParameter pMXversion = new SqlParameter
                ("@MXversion", SqlDbType.NChar);
            if (tbMxVersion.Text.Length > 0)
            {
                pMXversion.Value = tbMxVersion.Text;
            }
            else
            {
                pMXversion.Value = DBNull.Value;
            }

            SqlParameter pLicense = new SqlParameter
                ("@License", SqlDbType.NChar);
            if (tbLicense.Text.Length > 0)
            {
                pLicense.Value = tbLicense.Text;
            }
            else
            {
                pLicense.Value = DBNull.Value;
            }


            if (g.ProductLine == "Nexview" | g.ProductLine == "Nexview2")
            {
                SQL =
                    "  PN = " + pConfigurationPN +
                    " ,Customer =" + pCustomer +
                    " ,EndCustomer =" + pEndCustomer +
                    " ,OrderNum =" + pOrderNum +
                    " ,WaiverNum =" + pWaiverNum +
                    " ,ShipDate =" + pShipDate +
                    " ,Destination =" + pDestination +
                    " ,QcEmployeeID =" + pQcEmployeeID +
                    " ,QcName =" + pQcName +
                    " ,InstallProblems =" + pInstallProblems +
                    " ,InstallReport =" + pInstallReport +
                    " ,MacAddress =" + pMACaddress +
                    " ,[6450-8101-01] =" + pBridge +
                    " ,[6450-8185-01] =" + pLED +
                    " ,[6450-8187-01] =" + pNexRLED +
                    " ,[6450-8109-01] =" + pDual +
                    " ,[6450-8504-04] =" + pMotion +
                    " ,[iPOS3602(X)] =" + pX +
                    " ,[iPOS3602(Y)] =" + pY +
                    " ,[800-1621(Z)] =" + pZ +
                    " ,[iPOS3602(P)] =" + pP +
                    " ,[iPOS3602(R)] =" + pR +
                    " ,ZStage =" + pZstage +
                    " ,[XY-Stage] =" + pXYstage +
                    " ,[PR-Stage] =" + pPRstage +
                    " ,Scanner =" + pScanner +
                    " ,Camera =" + pCamera +
                    " ,SystemCtrl =" + pSystemController +
                    " ,MxVer =" + pMXversion +
                    " ,LicenseHwId =" + pLicense +
                    " ,Comments =" + pComments;
            }

            if (g.ProductLine == "NV8000" | g.ProductLine == "NV9000")
            {
                SQL =
                    "  PN = " + pConfigurationPN +
                    " ,Customer =" + pCustomer +
                    " ,EndCustomer =" + pEndCustomer +
                    " ,OrderNum =" + pOrderNum +
                    " ,WaiverNum =" + pWaiverNum +
                    " ,ShipDate =" + pShipDate +
                    " ,Destination =" + pDestination +
                    " ,QcEmployeeID =" + pQcEmployeeID +
                    " ,QcName =" + pQcName +
                    " ,InstallProblems =" + pInstallProblems +
                    " ,InstallReport =" + pInstallReport +
                    " ,MacAddress =" + pMACaddress +
                    " ,[6450-8101-01] =" + pBridge +
                    " ,[6450-8185-01] =" + pLED +
                    " ,[6450-8187-01] =" + pNexRLED +
                    " ,[6450-8109-01] =" + pDual +
                    " ,[6450-8504-04] =" + pMotion +
                    " ,[800-1621(X)] =" + pX +
                    " ,[800-1621(Y)] =" + pY +
                    " ,[800-1621(Z)] =" + pZ +
                    " ,[800-1621(P)] =" + pP +
                    " ,[800-1621(R)] =" + pR +
                    " ,ZStage =" + pZstage +
                    " ,[XY-Stage] =" + pXYstage +
                    " ,[PR-Stage] =" + pPRstage +
                    " ,Scanner =" + pScanner +
                    " ,Camera =" + pCamera +
                    " ,SystemCtrl =" + pSystemController +
                    " ,MxVer =" + pMXversion +
                    " ,LicenseHwId =" + pLicense +
                    " ,Comments =" + pComments;
            }

            if (g.ProductLine == "ZeGage" | g.ProductLine == "ZeGagePlus")
            {
                SQL =
                    "  Customer =" + pCustomer +
                    " ,EndCustomer =" + pEndCustomer +
                    " ,OrderNum =" + pOrderNum +
                    " ,WaiverNum =" + pWaiverNum +
                    " ,ShipDate =" + pShipDate +
                    " ,Destination =" + pDestination +
                    " ,QcEmployeeID =" + pQcEmployeeID +
                    " ,QcName =" + pQcName +
                    " ,InstallProblems =" + pInstallProblems +
                    " ,InstallReport =" + pInstallReport +
                    " ,MacAddress =" + pMACaddress +
                    " ,CANdelabraIII =" + pBridge +
                    " ,CANdelabra =" + pLED +
                    " ,DualMotorCtrl =" + pDual +
                    " ,MotionCtrl =" + pMotion +
                    " ,StepperCtrlX =" + pX +
                    " ,StepperCtrlY =" + pY +
                    " ,StepperCtrlZ =" + pZ +
                    " ,ZStage =" + pZstage +
                    " ,[XY-Stage] =" + pXYstage +
                    " ,[PR-Stage] =" + pPRstage +
                    " ,Camera =" + pCamera +
                    " ,SystemCtrl =" + pSystemController +
                    " ,ZeMapsVer =" + pMXversion +
                    " ,LicenseHwId =" + pLicense +
                    " ,Comments =" + pComments;
            }

            if (g.ProductLine == "ZeGage Pro" | g.ProductLine == "ZeGage Pro HR")
            {
                SQL =
                    "  Customer =" + pCustomer +
                    " ,EndCustomer =" + pEndCustomer +
                    " ,OrderNum =" + pOrderNum +
                    " ,WaiverNum =" + pWaiverNum +
                    " ,ShipDate =" + pShipDate +
                    " ,Destination =" + pDestination +
                    " ,QcEmployeeID =" + pQcEmployeeID +
                    " ,QcName =" + pQcName +
                    " ,InstallProblems =" + pInstallProblems +
                    " ,InstallReport =" + pInstallReport +
                    " ,MacAddress =" + pMACaddress +
                    " ,CANdelabraIII =" + pBridge +
                    " ,CANdelabra =" + pLED +
                    " ,DualMotorCtrl =" + pDual +
                    " ,MotionCtrl =" + pMotion +
                    " ,StepperCtrlX =" + pX +
                    " ,StepperCtrlY =" + pY +
                    " ,StepperCtrlZ =" + pZ +
                    " ,ZStage =" + pZstage +
                    " ,[XY-Stage] =" + pXYstage +
                    " ,[PR-Stage] =" + pPRstage +
                    " ,Camera =" + pCamera +
                    " ,SystemCtrl =" + pSystemController +
                    " ,ZeMapsVer =" + pMXversion +
                    " ,LicenseHwId =" + pLicense +
                    " ,Comments =" + pComments;
            }



            try
            {

                SqlCommand cmd = new SqlCommand
                    ("Update MicroscopeData SET " +
                      SQL +
                     " WHERE SN = '" + g.serialNumber + "'", cnxn);

                cmd.Parameters.Add(pConfigurationPN);
                cmd.Parameters.Add(pCustomer);
                cmd.Parameters.Add(pEndCustomer);
                cmd.Parameters.Add(pOrderNum);
                cmd.Parameters.Add(pWaiverNum);
                cmd.Parameters.Add(pShipDate);
                cmd.Parameters.Add(pDestination);
                cmd.Parameters.Add(pQcEmployeeID);
                cmd.Parameters.Add(pQcName);
                cmd.Parameters.Add(pInstallProblems);
                cmd.Parameters.Add(pInstallReport);
                cmd.Parameters.Add(pMACaddress);
                cmd.Parameters.Add(pBridge);
                cmd.Parameters.Add(pLED);
                cmd.Parameters.Add(pNexRLED);
                cmd.Parameters.Add(pDual);
                cmd.Parameters.Add(pMotion);
                cmd.Parameters.Add(pX);
                cmd.Parameters.Add(pY);
                cmd.Parameters.Add(pZ);
                cmd.Parameters.Add(pP);
                cmd.Parameters.Add(pR);
                cmd.Parameters.Add(pZstage);
                cmd.Parameters.Add(pXYstage);
                cmd.Parameters.Add(pPRstage);
                cmd.Parameters.Add(pScanner);
                cmd.Parameters.Add(pCamera);
                cmd.Parameters.Add(pSystemController);
                cmd.Parameters.Add(pMXversion);
                cmd.Parameters.Add(pLicense);
                cmd.Parameters.Add(pComments);

                cmd.Connection = cnxn;
                if (cnxn.State == ConnectionState.Closed)
                {
                    cnxn.Open();
                }
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            bAction = "IntentionalClose";

            this.Close();
        }

        private void SystemInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (g.task == "Edit" & bAction != "IntentionalClose")
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    DialogResult result = MessageBox.Show("Do you want to exit without saving data ?", "",
                        MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        return;
                    }
                    else
                    {
                        e.Cancel = true;
                    }

                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
