using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace MicroscopeDB
{
    public partial class MicroSelect : Form
    {
        private string initialDirectory;
        private string SQL;
        SqlConnection cnxn;
        SqlCommand cmd;
        private string[] data;
        private int dataID;
        SqlParameter pData3;
        SqlParameter pData4;
        SqlParameter pData5;

        public MicroSelect()
        {
            InitializeComponent();
        }

        private void MicroSelect_Load(object sender, EventArgs e)
        {
            this.Text = "Microscope Database v" + Application.ProductVersion;
        }

        private void productline()
        {
            if (rbNexView.Checked)
            {
                g.ProductLine = "Nexview";
            
            }
            else if (rbNexView2.Checked)
            {
                g.ProductLine = "Nexview2";
            }
            else if (rbNV8000.Checked)
            {
                g.ProductLine = "NV8000";
            }
            else if (rbNV9000.Checked)
            {
                g.ProductLine = "NV9000";
            }
            else if (rbZeGage.Checked)
            {
                g.ProductLine = "ZeGage";
                initialDirectory = g.initialPath + g.ProductLine + @"\system data\";
            }
            else if (rbZeGagePlus.Checked)
            {
                g.ProductLine = "ZeGagePlus";
                initialDirectory = g.initialPath + @"ZeGage\system data\";
            }
            else if (rbZeGagePro.Checked)
            {
                g.ProductLine = "ZeGage Pro";
            }
            else if (rbZeGageProHR.Checked)
            {
                g.ProductLine = "ZeGage Pro HR";
            }

            if (g.ProductLine != "ZeGage" & g.ProductLine != "ZeGagePlus")
            {
                initialDirectory = g.initialMIDpath + @"micscope\" + g.ProductLine + @"\system data\";
            }
        }

        private void bImport_Click(object sender, EventArgs e)
        {
            productline();

            OpenFileDialog ofd = new OpenFileDialog();
            
            ofd.Title = "Select System Log to Import...";
            ofd.Multiselect = false;
            ofd.InitialDirectory = initialDirectory;
            ofd.Filter = "CSV Files|*_Log.csv";
            //ofd.ShowDialog(); don't need to show it

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(ofd.FileName);

                //first line has headers, second line has data

                //string h = System.Text.RegularExpressions.Regex.Escape(lines[1].ToString());

                //int count = lines[1].Count(f => f == ',');  /* this is LINQ */

                //if (g.ProductLine.Substring(0,1) =="N" & count > 78)
                //{
                //    /*Do substring based on \, - fourth then next , and check for \ if not then next ,\ replace , in group */
                //    string stop;
                //}
                
                data = lines[1].Split(',' );

                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = data[i].Replace("\"", string.Empty);

                    if (String.IsNullOrEmpty(data[i]))
                    {
                        data[i] = "NULL";
                    }
                    else if (data[i] == "NaN")
                    {
                        data[i] = "NULL";
                    }
                }

                int next = data.Length;

                /*
                 * 
                 * need to prevent double entry
                 * 
                 * */

                cnxn = new SqlConnection(g.db);

                /*
                 * the file structures of ZeGage and non-Zegage are different
                 * the serial number is in data[1] for ZeGage but in data[2] for the rest
                 * 
                 */

                if (g.ProductLine.Substring(0,6) == "ZeGage")
                {
                    SQL = " and sn = '" + data[1] + " '";
                }
                else
                {
                    SQL = " and sn = '" + data[2] + " '";
                }

                cmd = new SqlCommand
                ("Select id from microscopedata " + 
                "where productline = '" + g.ProductLine + "'" +
                SQL );

                cmd.Connection = cnxn;
                cnxn.Open();
                object o = cmd.ExecuteScalar();
                cnxn.Close();

                if (o != null)
                {
                    /* IF o is not null then the log has already been imported and this will write over the data
                     * by updating it.
                     */

                    DialogResult dialogResult = MessageBox.Show("This log has already been imported into the database.  " +
                        "This action will overwrite the existing data.  Do you want to continue ? ", "Import Box", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        dataID = Convert.ToInt32(o.ToString());

                        if (g.ProductLine.Substring(0, 1) == "N" & data.Length == 79)
                        {

                            if (g.ProductLine == "Nexview2" | g.ProductLine == "Nexview")
                            {
                                SQL =
                                " ,[6450-8101-01] = '" + data[9] + "'" +
                                " ,[6450-8185-01] = '" + data[10] + "'" +

                                " ,[6450-8109-01] = '" + data[11] + "'" +
                                " ,[6450-8187-01] = '" + data[12] + "'" +
                                " ,[6450-8504-04] = '" + data[13] + "'" +
                                " ,[iPOS3602(X)] = '" + data[14] + "'" +
                                " ,[iPOS3602(Y)] = '" + data[15] + "'" +

                                " ,[800-1621(Z)] = '" + data[16] + "'" +
                                " ,[iPOS3602(P)] = '" + data[17] + "'" +
                                " ,[iPOS3602(R)] = '" + data[18] + "'" +
                                " ,ZStage = '" + data[19] + "'" +
                                " ,Scanner = '" + data[20] + "'" +

                                " ,Camera = '" + data[21] + "'" +
                                " ,[XY-Stage] = '" + data[22] + "'" +
                                " ,[PR-Stage] = '" + data[23] + "'" +
                                " ,SystemCtrl = '" + data[24] + "'" +
                                " ,MxVer = '" + data[25] + "'" +

                                " ,CAL_HgPk = " + data[26] +
                                " ,CAL_Obliq = " + data[27] +
                                " ,CAL_EWL = " + data[28] +
                                " ,CAL_ScanIncr = " + data[29] +
                                " ,CAL_ScanCal = " + data[30] +

                                " ,AtpDate = '" + data[31] + "'" +
                                " ,Temp = " + data[32] +
                                " ,Humidity = " + data[33] +
                                " ,ATP_IllumCntr = " + data[34] +
                                " ,ATP_IllumLoss = " + data[35] +

                                " ,ATP_Cnf50Hz = " + data[36] +
                                " ,ATP_CnfMax = " + data[37] +
                                " ,ATP_ScanIncrErr = " + data[38] +
                                " ,ATP_ScanLinErr = " + data[39] +
                                " ,ATP_TopoRpt = " + data[40] +

                                " ,ATP_RmsRpt = " + data[41] +
                                " ,ATP_CertStep_1p8 = " + data[42] +
                                " ,ATP_MeanStep_1p8 = " + data[43] +
                                " ,ATP_StepAcc_1p8 = " + data[44] +
                                " ,ATP_StepRpt_1p8 = " + data[45] +

                                " ,ATP_CertStep_24 = " + data[49] +
                                " ,ATP_MeanStep_24 = " + data[50] +
                                " ,ATP_StepAcc_24 = " + data[51] +
                                " ,ATP_StepRpt_24 = " + data[52] +
                                " ,ATP_MeanStep_24z = " + data[53] +

                                " ,ATP_StepAcc_24z = " + data[54] +
                                " ,ATP_StepRpt_24z = " + data[55] +
                                " ,ATP_Operator = '" + data[56] + "'" +
                                " ,NexViewATP = '" + data[57] + "'" +

                                " ,AP_camCtrX = " + data[58] +
                                " ,AP_camCtrY = " + data[59] +
                                " ,AP_camFoc = " + data[60] +
                                " ,AP_camGrTilt = " + data[61] +
                                " ,AP_camRot = " + data[62] +
                                " ,AP_pupCtrX = " + data[63] +
                                " ,AP_pupCtrY = " + data[64] +

                                " ,AP_zmFoc0p5x = " + data[65] +
                                " ,AP_zmGrTilt0p5x = " + data[66] +
                                " ,AP_zmFoc1x = " + data[66] +
                                " ,AP_zmGrTilt1x = " + data[70] +
                                " ,AP_zmFoc2x = " + data[73] +
                                " ,AP_zmGrTilt2x = " + data[74] +
                                " ,AP_dztRpt = " + data[75] +
                                " ,AP_fsRpt = " + data[76] +
                                " ,AP_asRpt = " + data[77] +
                                " ,LicenseHwId = " + data[78] +
                                " WHERE ID = " + dataID;

                            }

                            if (g.ProductLine == "NV8000" | g.ProductLine == "NV9000")
                            {
                                SQL =
                                " ,[6450-8101-01] = '" + data[9] + "'" +
                                " ,[6450-8185-01] = '" + data[10] + "'" +

                                " ,[6450-8109-01] = '" + data[11] + "'" +
                                " ,[6450-8187-01] = '" + data[12] + "'" +
                                " ,[6450-8504-04] = '" + data[13] + "'" +
                                " ,[800-1621(X)] = '" + data[14] + "'" +
                                " ,[800-1621(Y)] = '" + data[15] + "'" +

                                " ,[800-1621(Z)] = '" + data[16] + "'" +
                                " ,[800-1621(P)] = '" + data[17] + "'" +
                                " ,[800-1621(R)] = '" + data[18] + "'" +
                                " ,ZStage = '" + data[19] + "'" +
                                " ,Scanner = '" + data[20] + "'" +

                                " ,Camera = '" + data[21] + "'" +
                                " ,[XY-Stage] = '" + data[22] + "'" +
                                " ,[PR-Stage] = '" + data[23] + "'" +
                                " ,SystemCtrl = '" + data[24] + "'" +
                                " ,MxVer = '" + data[25] + "'" +

                                " ,CAL_HgPk = " + data[26] +
                                " ,CAL_Obliq = " + data[27] +
                                " ,CAL_EWL = " + data[28] +
                                " ,CAL_ScanIncr = " + data[29] +
                                " ,CAL_ScanCal = " + data[30] +

                                " ,AtpDate = '" + data[31] + "'" +
                                " ,Temp = " + data[32] +
                                " ,Humidity = " + data[33] +
                                " ,ATP_IllumCntr = " + data[34] +
                                " ,ATP_IllumLoss = " + data[35] +

                                " ,ATP_Cnf50Hz = " + data[36] +
                                " ,ATP_CnfMax = " + data[37] +
                                " ,ATP_ScanIncrErr = " + data[38] +
                                " ,ATP_ScanLinErr = " + data[39] +
                                " ,ATP_TopoRpt = " + data[40] +

                                " ,ATP_RmsRpt = " + data[41] +
                                " ,ATP_CertStep_1p8 = " + data[42] +
                                " ,ATP_MeanStep_1p8 = " + data[43] +
                                " ,ATP_StepAcc_1p8 = " + data[44] +
                                " ,ATP_StepRpt_1p8 = " + data[45] +

                                " ,ATP_CertStep_24 = " + data[49] +
                                " ,ATP_MeanStep_24 = " + data[50] +
                                " ,ATP_StepAcc_24 = " + data[51] +
                                " ,ATP_StepRpt_24 = " + data[52] +
                                " ,ATP_MeanStep_24z = " + data[53] +

                                " ,ATP_StepAcc_24z = " + data[54] +
                                " ,ATP_StepRpt_24z = " + data[55] +
                                " ,ATP_Operator = '" + data[56] + "'" +
                                " ,NexViewATP = '" + data[57] + "'" +

                                " ,AP_camCtrX = " + data[58] +
                                " ,AP_camCtrY = " + data[59] +
                                " ,AP_camFoc = " + data[60] +
                                " ,AP_camGrTilt = " + data[61] +
                                " ,AP_camRot = " + data[62] +
                                " ,AP_pupCtrX = " + data[63] +
                                " ,AP_pupCtrY = " + data[64] +

                                " ,AP_zmFoc0p5x = " + data[65] +
                                " ,AP_zmGrTilt0p5x = " + data[66] +
                                " ,AP_zmFoc1x = " + data[66] +
                                " ,AP_zmGrTilt1x = " + data[70] +
                                " ,AP_zmFoc2x = " + data[73] +
                                " ,AP_zmGrTilt2x = " + data[74] +
                                " ,AP_dztRpt = " + data[75] +
                                " ,AP_fsRpt = " + data[76] +
                                " ,AP_asRpt = " + data[77] +
                                " ,LicenseHwId = " + data[78] +
                                " WHERE ID = " + dataID;
                            }
                        }
                        else if (g.ProductLine.Substring(0, 1) == "N" & data.Length != 79)
                        {
                            MessageBox.Show("Data log can not be imported.  Log field count wrong. \n \n" +
                                "Could be comma in company name");
                            return;
                        }

                        if (g.ProductLine == "ZeGage" | g.ProductLine == "ZeGagePlus")
                        {
                            SQL =
                            " ,Bridge = '" + data[8] + "'" +
                            " ,CANdelabraIII = '" + data[9] + "'" +
                            " ,CANdelabra = '" + data[10] + "'" +
                            " ,DualMotorCtrl = '" + data[11] + "'" +

                            " ,MotionCtrl = '" + data[12] + "'" +
                            " ,StepperCtrlX = '" + data[13] + "'" +
                            " ,StepperCtrlY = '" + data[14] + "'" +
                            " ,StepperCtrlZ = '" + data[15] + "'" +
                            " ,ZStage = '" + data[16] + "'" +

                            " ,Camera = '" + data[17] + "'" +
                            " ,SystemCtrl = '" + data[18] + "'" +
                            " ,ZeMapsVer = '" + data[19] + "'" +
                            " ,AtpDate = '" + data[20] + "'" +
                            " ,Temp = '" + data[21] + "'" +

                            " ,Humidity = '" + data[22] + "'" +
                            " ,Defocus = " + data[23] +
                            " ,TopoRepeat = " + data[24] +
                            " ,PkScanIncrSD = " + data[25] +
                            " ,MeanScanIncrSD = " + data[26] +

                            " ,[1p8umSHSAcc] = " + data[27] +
                            " ,[24umSHSAcc] = " + data[28] +
                            " ,SHRepeat = " + data[29] +
                            " ,[1p8umCertSH] = " + data[30] +
                            " ,[24umCertSH] = " + data[31] +

                            " ,SH1p8Mean = " + data[32] +
                            " ,SH1p8SDev = " + data[33] +
                            " ,SH1p8upMean = " + data[34] +
                            " ,SH1p8upSDev = " + data[35] +
                            " ,SH24Mean = " + data[36] +

                            " ,SH24SDev = " + data[37] +
                            " ,SH24upMean = " + data[38] +
                            " ,SH24upSDev = " + data[39] +
                            " ,AtpOperator = '" + data[40] + "'" +
                            " ,ZeGageAtpVer = '" + data[41] + "'" +
                            " ,LicenseHwId = '" + data[42] + "'" +
                            " WHERE ID = " + dataID;
                        }

                        if (g.ProductLine.Length > 9)
                        {
                            if (g.ProductLine.Substring(0, 10) == "ZeGage Pro")
                            {
                                SQL =
                                " ,Bridge = '" + data[8] + "'" +
                                " ,CANdelabraIII = '" + data[9] + "'" +
                                " ,CANdelabra = '" + data[10] + "'" +
                                " ,DualMotorCtrl = '" + data[11] + "'" +

                                " ,MotionCtrl = '" + data[12] + "'" +
                                " ,StepperCtrlX = '" + data[13] + "'" +
                                " ,StepperCtrlY = '" + data[14] + "'" +
                                " ,StepperCtrlZ = '" + data[15] + "'" +
                                " ,ZStage = '" + data[16] + "'" +

                                " ,Camera = '" + data[17] + "'" +
                                " ,[xy-stage] = '" + data[18] + "'" +
                                " ,[pr-stage] = '" + data[19] + "'" +
                                " ,SystemCtrl = '" + data[20] + "'" +
                                " ,MxVer = '" + data[21] + "'" +
                                " ,AtpDate = '" + data[22] + "'" +
                                " ,Temp = '" + data[23] + "'" +

                                " ,Humidity = '" + data[24] + "'" +
                                " ,Defocus = " + data[25] +
                                " ,TopoRepeat = " + data[26] +
                                " ,PkScanIncrSD = " + data[27] +
                                " ,MeanScanIncrSD = " + data[28] +

                                " ,[1p8umSHSAcc] = " + data[29] +
                                " ,[24umSHSAcc] = " + data[30] +
                                " ,SHRepeat = " + data[31] +
                                " ,[1p8umCertSH] = " + data[32] +
                                " ,[24umCertSH] = " + data[33] +

                                " ,SH1p8Mean = " + data[34] +
                                " ,SH1p8SDev = " + data[35] +
                                " ,SH1p8upMean = " + data[36] +
                                " ,SH1p8upSDev = " + data[37] +
                                " ,SH24Mean = " + data[38] +

                                " ,SH24SDev = " + data[39] +
                                " ,SH24upMean = " + data[40] +
                                " ,SH24upSDev = " + data[41] +
                                " ,AtpOperator = '" + data[42] + "'" +
                                " ,ZeGageAtpVer = '" + data[43] + "'" +
                                " ,LicenseHwId = '" + data[44] + "'" +
                                " WHERE ID = " + dataID;
                            }
                        }

                        pData3 = new SqlParameter("@customer", SqlDbType.NChar);
                        pData3.Value = data[3];

                        pData4 = new SqlParameter("@endcustomer", SqlDbType.NChar);
                        pData4.Value = data[4];

                        pData5 = new SqlParameter("@pendcustomer", SqlDbType.NChar);
                        pData5.Value = data[5];


                        if (g.ProductLine.Substring(0,6) == "ZeGage")
                        {
                            //pData3 = new SqlParameter("@customer", SqlDbType.NChar);
                            //pData3.Value = data[3];

                            //pData4 = new SqlParameter("@endcustomer", SqlDbType.NChar);
                            //pData4.Value = data[4];

                            //pData5 = new SqlParameter("@pendcustomer", SqlDbType.NChar);
                            //pData5.Value = data[5];


                            cmd = new SqlCommand("Update MicroscopeData SET" +
                        "  ProductLine ='" + g.ProductLine + "'" +

                        " ,DateCode = '" + data[0] + "'" +
                        " ,SN = '" + data[1] + "'" +
                        " ,PN = '" + data[2] + "'" +
                        " ,Customer = " + pData3 + 
                        " ,EndCustomer = " + pData4 + 
                        " ,OrderNum = " + pData5 + 
                        " ,WaiverNum = '" + data[6] + "'" +
                        " ,MacAddress = '" + data[7] + "'" +
                        SQL
                        , cnxn);
                        }
                        else
                        {
                            //pData3 = new SqlParameter("@customer", SqlDbType.NChar);
                            //pData3.Value = data[3];

                            //pData4 = new SqlParameter("@endcustomer", SqlDbType.NChar);
                            //pData4.Value = data[4];

                            //pData5 = new SqlParameter("@pendcustomer", SqlDbType.NChar);
                            //pData5.Value = data[5];

                            cmd = new SqlCommand("Update MicroscopeData SET" +
                        "  ProductLine ='" + g.ProductLine + "'" +

                        " ,DateCode = '" + data[1] + "'" +
                        " ,SN = '" + data[2] + "'" +
                        
                        " ,PN = " + pData3 +
                        " ,Customer = " + pData4 + 
                        " ,EndCustomer = " + pData5 +
                        
                        " ,OrderNum = '" + data[6] + "'" +
                        " ,WaiverNum = '" + data[7] + "'" +
                        " ,MacAddress = '" + data[8] + "'" +
                        SQL
                        , cnxn);
                        }

                        try
                        {
                            cnxn.Open();

                            cmd.Parameters.Add(pData3);
                            cmd.Parameters.Add(pData4);
                            cmd.Parameters.Add(pData5);


                            int row = cmd.ExecuteNonQuery();

                            if (row > 0)
                            {
                                MessageBox.Show("Log Imported");
                            }
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        finally
                        {
                            cmd.Parameters.Clear();
                            cnxn.Close();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
                else    /*  if the log has not been imported before it will now be inserted into the database  */
                {
                    if (g.ProductLine.Substring(0, 1) == "N" & data.Length == 79)
                    {
                        pData3 = new SqlParameter("@customer", SqlDbType.NChar);
                        pData3.Value = data[3];

                        pData4 = new SqlParameter("@endcustomer", SqlDbType.NChar);
                        pData4.Value = data[4];

                        pData5 = new SqlParameter("@pendcustomer", SqlDbType.NChar);
                        pData5.Value = data[5];

                        if (g.ProductLine == "Nexview2" | g.ProductLine == "Nexview")
                        {
                            SQL =
                            " ,[6450-8101-01] " +
                            " ,[6450-8185-01] " +

                            " ,[6450-8109-01] " +
                            " ,[6450-8187-01] " +
                            " ,[6450-8504-04] " +
                            " ,[iPOS3602(X)] " +
                            " ,[iPOS3602(Y)] " +

                            " ,[800-1621(Z)] " +
                            " ,[iPOS3602(P)] " +
                            " ,[iPOS3602(R)] " +
                            " ,ZStage " +
                            " ,Scanner " +

                            " ,Camera " +
                            " ,[XY-Stage] " +
                            " ,[PR-Stage] " +
                            " ,SystemCtrl " +
                            " ,MxVer " +

                            " ,CAL_HgPk " +
                            " ,CAL_Obliq " +
                            " ,CAL_EWL " +
                            " ,CAL_ScanIncr " +
                            " ,CAL_ScanCal " +      //30

                            " ,AtpDate " +
                            " ,Temp " +
                            " ,Humidity " +
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
                            " ,ATP_StepRpt_24z " +
                            " ,ATP_Operator " +
                            " ,NexViewATP " +


                            " ,AP_camCtrX " +
                            " ,AP_camCtrY " +
                            " ,AP_camFoc " +
                            " ,AP_camGrTilt " +
                            " ,AP_camRot " +
                            " ,AP_pupCtrX " +
                            " ,AP_pupCtrY " +

                            " ,AP_zmFoc0p5x " +
                            " ,AP_zmGrTilt0p5x " +
                            " ,AP_zmFoc1x " +
                            " ,AP_zmGrTilt1x " +
                            " ,AP_zmFoc2x " +
                            " ,AP_zmGrTilt2x " +
                            " ,AP_dztRpt " +
                            " ,AP_fsRpt " +
                            " ,AP_asRpt " +
                            " ,LicenseHwId " +
                            ") values ('" +
                            g.ProductLine +
                            "','" + data[1] +
                            "','" + data[2] +
                            "'," + pData3 +
                            "," + pData4 +
                            "," + pData5 +
                            ",'" + data[6] +
                            "','" + data[7] +
                            "','" + data[8] +
                            "','" + data[9] +
                            "','" + data[10] +
                            "','" + data[11] +
                            "','" + data[12] +
                            "','" + data[13] +
                            "','" + data[14] +
                            "','" + data[15] +
                            "','" + data[16] +
                            "','" + data[17] +
                            "','" + data[18] +
                            "','" + data[19] +
                            "','" + data[20] +
                            "','" + data[21] +
                            "','" + data[22] +
                            "','" + data[23] +
                            "','" + data[24] +
                            "','" + data[25] +
                            "'," + data[26] +
                            "," + data[27] +
                            "," + data[28] +
                            "," + data[29] +
                            "," + data[30] +
                            ",'" + data[31] +
                            "'," + data[32] +
                            "," + data[33] +
                            "," + data[34] +
                            "," + data[35] +
                            "," + data[36] +
                            "," + data[37] +
                            "," + data[38] +
                            "," + data[39] +
                            "," + data[40] +
                            "," + data[41] +
                            "," + data[42] +
                            "," + data[43] +
                            "," + data[44] +
                            "," + data[45] +
                            "," + data[49] +
                            "," + data[50] +
                            "," + data[51] +
                            "," + data[52] +
                            "," + data[53] +
                            "," + data[54] +
                            "," + data[55] +
                            ",'" + data[56] +
                            "','" + data[57] +
                            "'," + data[58] +
                            "," + data[59] +
                            "," + data[60] +
                            "," + data[61] +
                            "," + data[62] +
                            "," + data[63] +
                            "," + data[64] +
                            "," + data[65] +
                            "," + data[66] +
                            "," + data[69] +
                            "," + data[70] +
                            "," + data[73] +
                            "," + data[74] +
                            "," + data[75] +
                            "," + data[76] +
                            "," + data[77] +
                            "," + data[78] +
                            ")";
                        }

                        if (g.ProductLine == "NV8000" | g.ProductLine == "NV9000")
                        {
                            SQL =
                            " ,[6450-8101-01] " +
                            " ,[6450-8185-01] " +

                            " ,[6450-8109-01] " +
                            " ,[6450-8187-01] " +
                            " ,[6450-8504-04] " +
                            " ,[800-1621(X)] " +
                            " ,[800-1621(Y)] " +

                            " ,[800-1621(Z)] " +
                            " ,[800-1621(P)] " +
                            " ,[800-1621(R)] " +
                            " ,ZStage " +
                            " ,Scanner " +

                            " ,Camera " +
                            " ,[XY-Stage] " +
                            " ,[PR-Stage] " +
                            " ,SystemCtrl " +
                            " ,MxVer " +

                            " ,CAL_HgPk " +
                            " ,CAL_Obliq " +
                            " ,CAL_EWL " +
                            " ,CAL_ScanIncr " +
                            " ,CAL_ScanCal " +      //30

                            " ,AtpDate " +
                            " ,Temp " +
                            " ,Humidity " +
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
                            " ,ATP_StepRpt_24z " +
                            " ,ATP_Operator " +
                            " ,NexViewATP " +


                            " ,AP_camCtrX " +
                            " ,AP_camCtrY " +
                            " ,AP_camFoc " +
                            " ,AP_camGrTilt " +
                            " ,AP_camRot " +
                            " ,AP_pupCtrX " +
                            " ,AP_pupCtrY " +

                            " ,AP_zmFoc0p5x " +
                            " ,AP_zmGrTilt0p5x " +
                            " ,AP_zmFoc1x " +
                            " ,AP_zmGrTilt1x " +
                            " ,AP_zmFoc2x " +
                            " ,AP_zmGrTilt2x " +
                            " ,AP_dztRpt " +
                            " ,AP_fsRpt " +
                            " ,AP_asRpt " +
                            " ,LicenseHwId " +
                            ") values ('" +
                            g.ProductLine +
                            "','" + data[1] +
                            "','" + data[2] +
                            "'," + pData3 +
                            "," + pData4 +
                            "," + pData5 +
                            ",'" + data[6] +
                            "','" + data[7] +
                            "','" + data[8] +
                            "','" + data[9] +
                            "','" + data[10] +
                            "','" + data[11] +
                            "','" + data[12] +
                            "','" + data[13] +
                            "','" + data[14] +
                            "','" + data[15] +
                            "','" + data[16] +
                            "','" + data[17] +
                            "','" + data[18] +
                            "','" + data[19] +
                            "','" + data[20] +
                            "','" + data[21] +
                            "','" + data[22] +
                            "','" + data[23] +
                            "','" + data[24] +
                            "','" + data[25] +
                            "'," + data[26] +
                            "," + data[27] +
                            "," + data[28] +
                            "," + data[29] +
                            "," + data[30] +
                            ",'" + data[31] +
                            "'," + data[32] +
                            "," + data[33] +
                            "," + data[34] +
                            "," + data[35] +
                            "," + data[36] +
                            "," + data[37] +
                            "," + data[38] +
                            "," + data[39] +
                            "," + data[40] +
                            "," + data[41] +
                            "," + data[42] +
                            "," + data[43] +
                            "," + data[44] +
                            "," + data[45] +
                            "," + data[49] +
                            "," + data[50] +
                            "," + data[51] +
                            "," + data[52] +
                            "," + data[53] +
                            "," + data[54] +
                            "," + data[55] +
                            ",'" + data[56] +
                            "','" + data[57] +
                            "'," + data[58] +
                            "," + data[59] +
                            "," + data[60] +
                            "," + data[61] +
                            "," + data[62] +
                            "," + data[63] +
                            "," + data[64] +
                            "," + data[65] +
                            "," + data[66] +
                            "," + data[69] +
                            "," + data[70] +
                            "," + data[73] +
                            "," + data[74] +
                            "," + data[75] +
                            "," + data[76] +
                            "," + data[77] +
                            "," + data[78] +
                            ")";
                        }
                    }
                    else if (g.ProductLine.Substring(0, 1) == "N" & data.Length != 79)
                    {
                        MessageBox.Show("Data log can not be imported.  Log field count wrong. \n \n" +
                                "Could be comma in company name");
                        return;
                    }

                    if (g.ProductLine == "ZeGage" | g.ProductLine == "ZeGagePlus")
                    {
                        if (data.Length < 42)
                        {
                            MessageBox.Show("Data log can not be imported.  Log field count wrong.");
                            return;
                        }
                        else
                        {
                            pData3 = new SqlParameter("@customer", SqlDbType.NChar);
                            pData3.Value = data[3];

                            pData4 = new SqlParameter("@endcustomer", SqlDbType.NChar);
                            pData4.Value = data[4];

                            pData5 = new SqlParameter("@pendcustomer", SqlDbType.NChar);
                            pData5.Value = data[5];

                            SQL =
                            " ,Bridge " +
                            " ,CANdelabraIII " +
                            " ,CANdelabra " +
                            " ,DualMotorCtrl " +

                            " ,MotionCtrl " +
                            " ,StepperCtrlX " +
                            " ,StepperCtrlY " +
                            " ,StepperCtrlZ " +
                            " ,ZStage " +

                            " ,Camera " +
                            " ,SystemCtrl " +
                            " ,ZeMapsVer " +
                            " ,AtpDate " +
                            " ,Temp " +

                            " ,Humidity " +
                            " ,Defocus " +
                            " ,TopoRepeat " +
                            " ,PkScanIncrSD " +
                            " ,MeanScanIncrSD " +

                            " ,[1p8umSHSAcc] " +
                            " ,[24umSHSAcc] " +
                            " ,SHRepeat " +
                            " ,[1p8umCertSH] " +
                            " ,[24umCertSH] " +

                            " ,SH1p8Mean " +
                            " ,SH1p8SDev " +
                            " ,SH1p8upMean " +
                            " ,SH1p8upSDev " +
                            " ,SH24Mean " +

                            " ,SH24SDev " +
                            " ,SH24upMean " +
                            " ,SH24upSDev " +
                            " ,AtpOperator " +
                            " ,ZeGageAtpVer " +
                            " ,LicenseHwId  " +

                            " ) values ('" + g.ProductLine + "','" +
                            data[0] +
                            "','" + data[1] +
                            "','" + data[2] +
                            "'," + pData3 +
                            "," + pData4 +
                            "," + pData5 +
                            ",'" + data[6] +
                            "','" + data[7] +
                            "','" + data[8] +
                            "','" + data[9] +
                            "','" + data[10] +
                            "','" + data[11] +
                            "','" + data[12] +
                            "','" + data[13] +
                            "','" + data[14] +
                            "','" + data[15] +
                            "','" + data[16] +
                            "','" + data[17] +
                            "','" + data[18] +
                            "','" + data[19] +
                            "','" + data[20] +
                            "','" + data[21] +
                            "','" + data[22] +
                            "'," + data[23] +
                            "," + data[24] +
                            "," + data[25] +
                            "," + data[26] +
                            "," + data[27] +
                            "," + data[28] +
                            "," + data[29] +
                            "," + data[30] +
                            "," + data[31] +
                            "," + data[32] +
                            "," + data[33] +
                            "," + data[34] +
                            "," + data[35] +
                            "," + data[36] +
                            "," + data[37] +
                            "," + data[38] +
                            "," + data[39] +
                            ",'" + data[40] +
                            "','" + data[41] +
                            "','" + data[42] +

                            "')";
                        }
                    }

                    if (g.ProductLine.Length > 9 && g.ProductLine.Substring(0, 10) == "ZeGage Pro")
                    {
                        if (data.Length < 42)
                        {
                            MessageBox.Show("Data log can not be imported.  Log field count wrong.");
                            return;
                        }
                        else
                        {
                            pData3 = new SqlParameter("@customer", SqlDbType.NChar);
                            pData3.Value = data[3];

                            pData4 = new SqlParameter("@endcustomer", SqlDbType.NChar);
                            pData4.Value = data[4];

                            pData5 = new SqlParameter("@pendcustomer", SqlDbType.NChar);
                            pData5.Value = data[5];

                            SQL =
                            " ,Bridge " +
                            " ,CANdelabraIII " +
                            " ,CANdelabra " +
                            " ,DualMotorCtrl " +

                            " ,MotionCtrl " +
                            " ,StepperCtrlX " +
                            " ,StepperCtrlY " +
                            " ,StepperCtrlZ " +
                            " ,ZStage " +

                            " ,Camera " +
                            " ,[XY-Stage] " +
                            " ,[PR-Stage] " +
                            " ,SystemCtrl " +
                            " ,MxVer " +
                            " ,AtpDate " +
                            " ,Temp " +

                            " ,Humidity " +
                            " ,Defocus " +
                            " ,TopoRepeat " +
                            " ,PkScanIncrSD " +
                            " ,MeanScanIncrSD " +

                            " ,[1p8umSHSAcc] " +
                            " ,[24umSHSAcc] " +
                            " ,SHRepeat " +
                            " ,[1p8umCertSH] " +
                            " ,[24umCertSH] " +

                            " ,SH1p8Mean " +
                            " ,SH1p8SDev " +
                            " ,SH1p8upMean " +
                            " ,SH1p8upSDev " +
                            " ,SH24Mean " +

                            " ,SH24SDev " +
                            " ,SH24upMean " +
                            " ,SH24upSDev " +
                            " ,AtpOperator " +
                            " ,ZeGageAtpVer " +
                            " ,LicenseHwId  " +

                            " ) values ('" + g.ProductLine + "','" +
                            data[0] +
                            "','" + data[1] +
                            "','" + data[2] +
                            "'," + pData3 +
                            "," + pData4 +
                            "," + pData5 +
                            ",'" + data[6] +
                            "','" + data[7] +
                            "','" + data[8] +
                            "','" + data[9] +
                            "','" + data[10] +
                            "','" + data[11] +
                            "','" + data[12] +
                            "','" + data[13] +
                            "','" + data[14] +
                            "','" + data[15] +
                            "','" + data[16] +
                            "','" + data[17] +
                            "','" + data[18] +
                            "','" + data[19] +
                            "','" + data[20] +
                            "','" + data[21] +
                            "','" + data[22] +
                            "','" + data[23] +
                            "','" + data[24] +
                            "'," + data[25] +
                            "," + data[26] +
                            "," + data[27] +
                            "," + data[28] +
                            "," + data[29] +
                            "," + data[30] +
                            "," + data[31] +
                            "," + data[32] +
                            "," + data[33] +
                            "," + data[34] +
                            "," + data[35] +
                            "," + data[36] +
                            "," + data[37] +
                            "," + data[38] +
                            "," + data[39] +
                            "," + data[40] +
                            "," + data[41] +
                            ",'" + data[42] +
                            "','" + data[43] +
                            "','" + data[44] +

                            "')";
                        }
                    }


                    if (SQL.Length > 30)
                    {
                        cmd = new SqlCommand("Insert into MicroscopeData (" +
                            "  ProductLine " +

                            " ,DateCode " +
                            " ,SN " +
                            " ,PN " +
                            " ,Customer " +
                            " ,EndCustomer " +

                            " ,OrderNum " +
                            " ,WaiverNum " +
                            " ,MacAddress " +
                            SQL
                            , cnxn);

                        try
                        {
                            cnxn.Open();

                            cmd.Parameters.Add(pData3);
                            cmd.Parameters.Add(pData4);
                            cmd.Parameters.Add(pData5);

                            int row = cmd.ExecuteNonQuery();

                            if (row > 0)
                            {
                                MessageBox.Show("Log Imported");
                            }


                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        finally
                        {
                            cmd.Parameters.Clear();
                            cnxn.Close();
                        }
                    }
                }
            }
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            g.task = "Edit";
            productline();
            SelectSN s = new SelectSN();
            s.ShowDialog();
        }

        private void bView_Click(object sender, EventArgs e)
        {
            g.task = "View";
            productline();
            SelectSN s = new SelectSN();
            s.ShowDialog();
        }

        private void BaddAccessory_Click(object sender, EventArgs e)
        {
            g.task = "Add";
            productline();
            SelectSN s = new SelectSN();
            s.ShowDialog();
        }

        private void bViewSpreadsheet_Click(object sender, EventArgs e)
        {
            productline();
            SpreadsheetView s = new SpreadsheetView();
            s.ShowDialog();
        }
    }

    public static class g
    {
        public static string serialNumber;
        public static string ProductLine;
        public static string task;
        public static string LimIllumLoss;
        public static string LimCnf50;
        public static string LimCnfMax;
        public static string LimScanIncrErr;
        public static string LimScanLinErr;
        public static string LimTopoRepeat;
        public static string LimRmsRepeat;
        public static string LimStepRepeat;
        public static string LimStepHeightAccuracyPZT;
        public static string LimStepHeightAccuracyZ;
        public static string Lim1p8StepHeightAccuracy;
        public static string Lim24StepHeightAccuracy;
        public static string MeanIllumLoss;
        public static string MeanCnf50;
        public static string MeanCnfMax;
        public static string MeanScanLinErr;
        public static string MeanStepRpt;
        public static string MeanTopoRpt;
        public static string MeanRmsRpt;
        public static string MeanScanIncrErr;
        public static string MeanSHaccPZT;
        public static string MeanSHaccZ;
        public static int DataID;
        public static int AccessoryDataID;
        public static string DateCode;
        public static string initialPath = @"\\zygocorp.zygo.com\departments\archives\";
        public static string initialMIDpath = @"\\midfile01.zygo.com\departments\archives\";

        public static string db = "server = CT-MID-SQL11; password = Read+Write!; " +
                            "user = readwrite; database = ProductionControl;";       
    }
}
