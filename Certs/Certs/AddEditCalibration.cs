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

namespace Certs
{
    public partial class EditCalibrationCert : Form
    {
        SqlConnection cnxn;
        SqlConnection cnxnNAV;
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlDataReader dr;
        private string SQL = string.Empty;
        DataTable dt1;

        public EditCalibrationCert()
        {
            InitializeComponent();
        }

        private void EditCalibrationCert_Load(object sender, EventArgs e)
        {
            cnxnNAV = new SqlConnection(g.dbNAV);

            cnxn = new SqlConnection(g.db);

            string SQL = "select distinct Name from ZYGO$Customer";

            DataTable table = new DataTable();

            try
            {
                if (cnxnNAV.State == ConnectionState.Closed)
                {
                    cnxnNAV.Open();
                }

                cmd = new SqlCommand(SQL, cnxnNAV);
                cmd.CommandTimeout = 30;

                dr = cmd.ExecuteReader();

                table.Load(dr);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxnNAV.Close();
            }

            cbddCustomer.DataSource = table;
            cbddCustomer.DisplayMember = "Name";

            da = new SqlDataAdapter(
                             "select No_, Description from ZYGO$Item " +
                             " WHERE No_ LIKE '6024%' " +
                             "order by No_ ", cnxnNAV);

            dt1 = new DataTable();
            dt1.Rows.Add();
            dt1.AcceptChanges();
            da.Fill(dt1);

            cbddPartNumber.DataSource = dt1;
            cbddPartNumber.DisplayMember = "No_";


            da = new SqlDataAdapter(
                             "select TRIM(Value) [Value] " +
                             " FROM Cert_Dropdowns where displayfield = 'FoundCondition' " +
                             " order by Value ", cnxn);

            DataTable dt2 = new DataTable();
            dt2.Rows.Add();
            dt2.AcceptChanges();
            da.Fill(dt2);

            cbddAsFoundCondition.DataSource = dt2;
            cbddAsFoundCondition.DisplayMember = "Value";

            da = new SqlDataAdapter(
                             "select TRIM(Value) [Value] " +
                             " FROM Cert_Dropdowns where displayfield = 'LeftCondition' " +
                             " order by Value ", cnxn);

            dt2 = new DataTable();
            dt2.Rows.Add();
            dt2.AcceptChanges();
            da.Fill(dt2);

            cbddAsLeftCondition.DataSource = dt2;
            cbddAsLeftCondition.DisplayMember = "Value";



            da = new SqlDataAdapter(
                             "select Value " +
                             " FROM Cert_Dropdowns where displayfield = 'CalProcedure' " +
                             " order by Value ", cnxn);

            dt2 = new DataTable();
            dt2.Rows.Add();
            dt2.AcceptChanges();
            da.Fill(dt2);

            cbddCalibrationProcedure.DataSource = dt2;
            cbddCalibrationProcedure.DisplayMember = "Value";


            da = new SqlDataAdapter(
                             "select Value " +
                             " FROM Cert_Dropdowns where displayfield = 'TestType' " +
                             " order by Value ", cnxn);

            dt2 = new DataTable();
            dt2.Rows.Add();
            dt2.AcceptChanges();
            da.Fill(dt2);

            cbddTypeOfTestPerformed.DataSource = dt2;
            cbddTypeOfTestPerformed.DisplayMember = "Value";


            da = new SqlDataAdapter(
                             "select Value " +
                             " FROM Cert_Dropdowns where displayfield = 'RefStandard' " +
                             " order by Value ", cnxn);

            dt2 = new DataTable();
            dt2.Rows.Add();
            dt2.AcceptChanges();
            da.Fill(dt2);

            cbddReferenceStandards.DataSource = dt2;
            cbddReferenceStandards.DisplayMember = "Value";

            da = new SqlDataAdapter(
                             "select Value " +
                             " FROM Cert_Dropdowns where displayfield = 'Result' " +
                             " order by Value ", cnxn);

            dt2 = new DataTable();
            dt2.Rows.Add();
            dt2.AcceptChanges();
            da.Fill(dt2);

            cbddCertifiedResults.DataSource = dt2;
            cbddCertifiedResults.DisplayMember = "Value";


            //g.certificationNumber = "140692";  /*   for testing purposes    */

            if (g.task != "ADD")
            {
                LcertificationNumber.Text = "Certification Number:  " + g.certificationNumber;
            }
          
            
            if (g.task == "ADD" & g.subtask != "COPY")
            {
                
            }
            else
            {
                GetData();
            }

            if (g.task == "ADD")
            {
                g.certificationNumber = g.newCertNumber;
                LcertificationNumber.Text = "Certification Number:  " + g.certificationNumber;
                dtpTestDate.Value = DateTime.Now;
                dtpDateSigned.Value = DateTime.Now;
                dtpDateReceived.Value = DateTime.Now;
                dtpNextCalibrationDue.Value = DateTime.Now;
            }

            if (g.task == "VIEW")
            {
                bSave.Text = "EXIT";
            }

        }

        private void GetData()
        {
            SqlConnection cnxn = new SqlConnection(g.db);

            SQL =
                "SELECT " +
                " [Customer Name] " +
                ",[Customer PO #] " +
                ",DateReceived " +
                ",[P/N] " +
                ",[Desc] " +
                ",[Serial #] " +
                ",AsFoundCondition " +
                ",[Calibration Procedure] " +
                ",[Test Date] " +
                ",NextCalibrationDue " +
                ",Temperature " +
                ",RelativeHumidity " +
                ",Uncertainty " +
                ",[Certified Results] " +
                ",[Type of Test Performed] " +
                ",[Reference Standards Used] " +
                ",[Other Pertinent Information] " +
                ",[Written by] " +
                ",[Name] " +
                ",[Title] " +
                ",[Date] " +
                ",ISO17025 " +
                ",AsLeftCondition " +

                " FROM " + g.dbTable +
                " WHERE [Certification #] = '" + g.certificationNumber + "'";

            DataTable dt = new DataTable();

            try
            {
                if (cnxn.State == ConnectionState.Closed)
                {
                    cnxn.Open();
                }

                cmd = new SqlCommand(SQL, cnxn);

                dr = cmd.ExecuteReader();

                dt.Load(dr);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        cbddCustomer.Text = dr.GetString(0);
                    }
                    else
                    {
                        cbddCustomer.Text = string.Empty;
                    }

                    if (!dr.IsDBNull(1))
                    {
                        tbCustomerPO.Text = dr.GetString(1);
                    }
                    else
                    {
                        tbCustomerPO.Text = string.Empty;
                    }

                    if (!dr.IsDBNull(2))
                    {
                        dtpDateReceived.Text = dr.GetDateTime(2).ToShortDateString();
                    }
                    else
                    {
                        dtpDateReceived.Text = "01/01/1900";
                    }


                    if (!dr.IsDBNull(3))
                    {
                        cbddPartNumber.Text = dr.GetString(3);
                    }
                    else
                    {
                        cbddPartNumber.Text = string.Empty;
                    }

                    if (!dr.IsDBNull(4))
                    {
                        tbDescription.Text = dr.GetString(4);
                    }
                    else
                    {
                        tbDescription.Text = string.Empty;
                    }

                    if (!dr.IsDBNull(5))
                    {
                        tbSerialNumber.Text = dr.GetString(5);
                    }
                    else
                    {
                        tbSerialNumber.Text = string.Empty;
                    }

                    if (!dr.IsDBNull(6))
                    {
                        cbddAsFoundCondition.Text = dr.GetString(6);
                    }
                    else
                    {
                        cbddAsFoundCondition.Text = string.Empty;
                    }

                    if (!dr.IsDBNull(7))
                    {
                        cbddCalibrationProcedure.Text = dr.GetString(7);
                    }
                    else
                    {
                        cbddCalibrationProcedure.Text = string.Empty;
                    }

                    if (!dr.IsDBNull(8))
                    {
                        dtpTestDate.Text = dr.GetDateTime(8).ToString("MM/dd/yyyy");
                    }
                    else
                    {
                        dtpTestDate.Text = "01/01/1900";
                    }

                    if (!dr.IsDBNull(9))
                    {
                        dtpNextCalibrationDue.Text = dr.GetDateTime(9).ToString("MM/dd/yyyy");
                    }
                    else
                    {
                        dtpNextCalibrationDue.Text = "01/01/1900";
                    }

                    if (!dr.IsDBNull(10))
                    {
                        tbTemperature.Text = dr.GetString(10);
                    }
                    else
                    {
                        tbTemperature.Text = string.Empty;
                    }

                    if (!dr.IsDBNull(11))
                    {
                        tbHumidity.Text = dr.GetString(11);
                    }
                    else
                    {
                        tbHumidity.Text = string.Empty;
                    }

                    if (!dr.IsDBNull(12))
                    {
                        tbUncertainty.Text = dr.GetString(12);
                    }
                    else
                    {
                        tbUncertainty.Text = string.Empty;
                    }

                    if (!dr.IsDBNull(13))
                    {
                        tbCertifiedResults.Text = dr.GetString(13);
                    }
                    else
                    {
                        tbCertifiedResults.Text = string.Empty;
                    }

                    if (!dr.IsDBNull(14))
                    {
                        cbddTypeOfTestPerformed.Text = dr.GetString(14);
                    }
                    else
                    {
                        cbddTypeOfTestPerformed.Text = string.Empty;
                    }

                    if (!dr.IsDBNull(15))
                    {
                        tbReferenceStandards.Text = dr.GetString(15);
                    }
                    else
                    {
                        tbReferenceStandards.Text = string.Empty;
                    }

                    if (!dr.IsDBNull(16))
                    {
                        tbOtherPertinentInformation.Text = dr.GetString(16);
                    }
                    else
                    {
                        tbOtherPertinentInformation.Text = string.Empty;
                    }

                    if (!dr.IsDBNull(17))
                    {
                        tbTestedByInitials.Text = dr.GetString(17);
                    }
                    else
                    {
                        tbTestedByInitials.Text = string.Empty;
                    }

                    if (!dr.IsDBNull(18))
                    {
                        tbSignedByName.Text = dr.GetString(18);
                    }
                    else
                    {
                        tbSignedByName.Text = string.Empty;
                    }

                    if (!dr.IsDBNull(19))
                    {
                        tbTitle.Text = dr.GetString(19);
                    }
                    else
                    {
                        tbTitle.Text = string.Empty;
                    }

                    if (!dr.IsDBNull(20))
                    {
                        dtpDateSigned.Text = dr.GetDateTime(20).ToString("MM/dd/yyyy");
                    }
                    else
                    {
                        dtpDateSigned.Text = "01/01/1900";
                    }

                    if (!dr.IsDBNull(21))
                    {
                        cbISO17025.Checked = dr.GetBoolean(21);
                    }
                    else
                    {
                        cbISO17025.Checked = false;
                    }

                    if (!dr.IsDBNull(22))
                    {
                        cbddAsLeftCondition.Text = dr.GetString(22);
                    }
                    else
                    {
                        cbddAsLeftCondition.Text = string.Empty;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxnNAV.Close();
            }
        }


        private void bSave_Click(object sender, EventArgs e)
        {
            if (bSave.Text == "EXIT")
            {
                this.Close();
            }
            else
            {


                SqlParameter pCustomer = new SqlParameter("@customer", SqlDbType.VarChar);
                if (cbddCustomer.Text.Length > 0)
                {
                    pCustomer.Value = cbddCustomer.Text.Trim();
                }
                else
                {
                    pCustomer.Value = string.Empty;
                }

                SqlParameter pCustomerPO = new SqlParameter("@CustomerPo", SqlDbType.VarChar);
                if (tbCustomerPO.Text.Length > 0)
                {
                    pCustomerPO.Value = tbCustomerPO.Text.Trim();
                }
                else
                {
                    pCustomerPO.Value = string.Empty;
                }

                SqlParameter pDateReceived = new SqlParameter("@dateReceived", SqlDbType.Date);
                if (dtpDateReceived.Text == "01/01/1900")
                {
                    pDateReceived.Value = DBNull.Value;
                }
                else
                {
                    pDateReceived.Value = dtpDateReceived.Text;
                }

                SqlParameter pPN = new SqlParameter("@PN", SqlDbType.VarChar);
                if (cbddPartNumber.Text.Length > 0)
                {
                    pPN.Value = cbddPartNumber.Text.Trim();
                }
                else
                {
                    pPN.Value = string.Empty;
                }

                SqlParameter pDescription = new SqlParameter("@description", SqlDbType.VarChar);
                pDescription.Value = tbDescription.Text;

                SqlParameter pSN = new SqlParameter("@serialNumber", SqlDbType.VarChar);
                pSN.Value = tbSerialNumber.Text;

                SqlParameter pAsFound = new SqlParameter("@asFound", SqlDbType.VarChar);
                if (cbddAsFoundCondition.Text.Length > 0)
                {
                    pAsFound.Value = cbddAsFoundCondition.Text.Trim();
                }
                else
                {
                    pAsFound.Value = string.Empty;
                }

                SqlParameter pCalibrationProcedure = new SqlParameter("@calibrationProcedure", SqlDbType.VarChar);
                if (cbddCalibrationProcedure.Text.Length > 0)
                {
                    pCalibrationProcedure.Value = cbddCalibrationProcedure.Text.Trim();
                }
                else
                {
                    pCalibrationProcedure.Value = string.Empty;
                }

                SqlParameter pTestDate = new SqlParameter("@testDate", SqlDbType.Date);

                if (dtpTestDate.Text == "01/01/1900")
                {
                    pTestDate.Value = DBNull.Value;
                }
                else
                {
                    pTestDate.Value = dtpTestDate.Text;
                }


                SqlParameter pNextCalibrationDue = new SqlParameter("@nextCalibrationDue", SqlDbType.Date);

                if (dtpNextCalibrationDue.Text == "01/01/1900")
                {
                    pNextCalibrationDue.Value = DBNull.Value;
                }
                else
                {
                    pNextCalibrationDue.Value = dtpNextCalibrationDue.Text;
                }

                if (cbNoDate.Checked)
                {
                    pNextCalibrationDue.Value = DBNull.Value;
                }


                SqlParameter pTemperature = new SqlParameter("@temperature", SqlDbType.VarChar);
                pTemperature.Value = tbTemperature.Text;

                SqlParameter pHumidity = new SqlParameter("@humidity", SqlDbType.VarChar);
                pHumidity.Value = tbHumidity.Text;

                SqlParameter pUncertainty = new SqlParameter("@uncertainty", SqlDbType.VarChar);
                pUncertainty.Value = tbUncertainty.Text;

                SqlParameter pCertifiedResults = new SqlParameter("@certifiedResults", SqlDbType.VarChar);
                if (tbCertifiedResults.Text.Length > 0)
                {
                    if (tbCertifiedResults.Text.Length > 255)
                    {
                        MessageBox.Show("Certified Results character limit 255 exceeded.");
                        tbCertifiedResults.Focus();
                        return;
                    }
                    pCertifiedResults.Value = tbCertifiedResults.Text.Trim();
                }
                else
                {
                    pCertifiedResults.Value = string.Empty;
                }

                SqlParameter pTypeOfTestPerformed = new SqlParameter("@typeOfTestPerformed", SqlDbType.VarChar);
                if (cbddTypeOfTestPerformed.Text.Length > 0)
                {
                    pTypeOfTestPerformed.Value = cbddTypeOfTestPerformed.Text.Trim();
                }
                else
                {
                    pTypeOfTestPerformed.Value = string.Empty;
                }

                SqlParameter pReferenceStandards = new SqlParameter("@referenceStandards", SqlDbType.VarChar);
                if (tbReferenceStandards.Text.Length > 0)
                {
                    pReferenceStandards.Value = tbReferenceStandards.Text.Trim();
                }
                else
                {
                    pReferenceStandards.Value = string.Empty;
                }

                SqlParameter pOtherInformation = new SqlParameter("@otherInformation", SqlDbType.VarChar);
                pOtherInformation.Value = tbOtherPertinentInformation.Text;

                SqlParameter pInitials = new SqlParameter("@initials", SqlDbType.VarChar);
                pInitials.Value = tbTestedByInitials.Text;

                SqlParameter pSignedBy = new SqlParameter("@signedBy", SqlDbType.VarChar);
                pSignedBy.Value = tbSignedByName.Text;

                SqlParameter pTitle = new SqlParameter("@title", SqlDbType.VarChar);
                pTitle.Value = tbTitle.Text;

                SqlParameter pDateSigned = new SqlParameter("@dateSigned", SqlDbType.Date);

                if (dtpDateSigned.Text == "01/01/1900")
                {
                    pDateSigned.Value = DBNull.Value;
                }
                else
                {
                    pDateSigned.Value = dtpDateSigned.Text;
                }


                SqlParameter pISO17025 = new SqlParameter("@iSO17025", SqlDbType.Bit);
                if (cbISO17025.Checked)
                {
                    pISO17025.Value = 1;
                }
                else
                {
                    pISO17025.Value = 0;
                }

                SqlParameter pAsLeft = new SqlParameter("@asLeft", SqlDbType.VarChar);
                if (cbddAsLeftCondition.Text.Length > 0)
                {
                    pAsLeft.Value = cbddAsLeftCondition.Text.Trim();
                }
                else
                {
                    pAsLeft.Value = string.Empty;
                }

                cnxn = new SqlConnection(g.db);


                SQL =
                    "UPDATE " + g.dbTable +
                    " SET " +
                    " [Customer Name] =" + pCustomer +
                    ",[Customer PO #] =" + pCustomerPO +
                    ",DateReceived =" + pDateReceived +
                    ",[P/N] =" + pPN +
                    ",[Desc] =" + pDescription +
                    ",[Serial #] =" + pSN +
                    ",AsFoundCondition =" + pAsFound +
                    ",[Calibration Procedure] =" + pCalibrationProcedure +
                    ",[Test Date] =" + pTestDate +
                    ",NextCalibrationDue =" + pNextCalibrationDue +
                    ",Temperature =" + pTemperature +
                    ",RelativeHumidity =" + pHumidity +
                    ",Uncertainty =" + pUncertainty +
                    ",[Certified Results] =" + pCertifiedResults +
                    ",[Type of Test Performed] =" + pTypeOfTestPerformed +
                    ",[Reference Standards Used] =" + pReferenceStandards +
                    ",[Other Pertinent Information] =" + pOtherInformation +
                    ",[Written by] =" + pInitials +
                    ",[Name] =" + pSignedBy +
                    ",[Title] =" + pTitle +
                    ",[Date] =" + pDateSigned +
                    ",ISO17025 =" + pISO17025 +
                    ",AsLeftCondition =" + pAsLeft +
                    " WHERE [Certification #] = '" + g.certificationNumber + "'";

                cmd = new SqlCommand(SQL, cnxn);

                cmd.Parameters.Add(pCustomer);
                cmd.Parameters.Add(pCustomerPO);
                cmd.Parameters.Add(pDateReceived);
                cmd.Parameters.Add(pPN);
                cmd.Parameters.Add(pDescription);
                cmd.Parameters.Add(pSN);
                cmd.Parameters.Add(pAsFound);
                cmd.Parameters.Add(pCalibrationProcedure);
                cmd.Parameters.Add(pTestDate);
                cmd.Parameters.Add(pNextCalibrationDue);
                cmd.Parameters.Add(pTemperature);
                cmd.Parameters.Add(pHumidity);
                cmd.Parameters.Add(pUncertainty);
                cmd.Parameters.Add(pCertifiedResults);
                cmd.Parameters.Add(pTypeOfTestPerformed);
                cmd.Parameters.Add(pReferenceStandards);
                cmd.Parameters.Add(pOtherInformation);
                cmd.Parameters.Add(pInitials);
                cmd.Parameters.Add(pSignedBy);
                cmd.Parameters.Add(pTitle);
                cmd.Parameters.Add(pDateSigned);
                cmd.Parameters.Add(pISO17025);
                cmd.Parameters.Add(pAsLeft);

                try
                {
                    cnxn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn.Close();
                    cmd.Parameters.Clear();
                }
            }

            g.certificationNumber = string.Empty;
            g.description = string.Empty;
            g.newCertNumber = string.Empty;

            g.subtask = "RETURN";

            this.Close();
        }

        private void cbddPartNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            int n = cbddPartNumber.SelectedIndex;
            tbDescription.Text = dt1.Rows[n].ItemArray[1].ToString();
        }

        private void cbddCertifiedResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbddCertifiedResults.Text.Length > 0)
            {
                tbCertifiedResults.Text = tbCertifiedResults.Text.Trim() + " " + cbddCertifiedResults.Text.Trim();
            }
        }

        private void cbddReferenceStandards_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbddReferenceStandards.Text.Length > 0)
            {
                tbReferenceStandards.Text = tbReferenceStandards.Text.Trim() + " " + cbddReferenceStandards.Text.Trim();
            }
        }
    }
}
