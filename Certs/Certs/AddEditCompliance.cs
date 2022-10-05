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
    public partial class AddEditCompliance : Form
    {
        SqlConnection cnxn;
        SqlConnection cnxnNAV;
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlDataReader dr;
        private string SQL = string.Empty;
        DataTable dt1;


        public AddEditCompliance()
        {
            InitializeComponent();
        }

        private void AddEditCompliance_Load(object sender, EventArgs e)
        {
            if (g.task == "EDIT")
            {
                this.Text = "Edit Compliance";
            }

            if (g.task == "ADD")
            {
                this.Text = "Add Compliance";
            }

            if (g.task == "VIEW")
            {
                this.Text = "View Compliance";
            }

            cnxnNAV = new SqlConnection(g.dbNAV);

            cnxn = new SqlConnection(g.db);

            SqlCommand cmd = new SqlCommand(
                "select distinct name from ZYGO$Customer", cnxnNAV);

            DataTable table = new DataTable();

            try
            {
                string SQL = "select distinct Name from ZYGO$Customer";

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


            //DataTable dt = new DataTable();
            //dt.Rows.Add();
            //dt.AcceptChanges();
            //dt.Load(dr);

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

            if (g.task == "ADD" & g.subtask == "COPY")
            {

            }
            else
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
                dtpThroughTestDate.Value = DateTime.Now;
                dtpThroughTestDate.Checked = false;
                dtpDateSigned.Value = DateTime.Now;
                dtpShippedDate.Value = DateTime.Now;
            }

            dtpThroughTestDate.ShowCheckBox = true;
            

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
                ",[OrderNumberZygo] " +
                ",[P/N] " +
                ",[Desc] " +
                ",CustomerPN " +
                ",CustomerPNDescription " +
                ",CustomerRev " +
                ",[Test Date] " +
                ",ThroughTestDate " +
                ",Quantity " +
                ",[Serial #] " +
                ",CASE " +
                "   WHEN LEN(COALESCE(Quanity2,'')) > 0 THEN Quanity2 " +
                "    ELSE Notes " +
                "END Notes " +
                ",[Certified Results] " +
                ",Temperature " +
                ",RelativeHumidity " +
                ",[Other Pertinent Information] " +
                ",[Written by] " +
                ",[Name] " +
                ",[Title] " +
                ",[Date] " +
                ",[Shipped Date] " +
                ", ZygoSite " +
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
                        tbZygoSO.Text = dr.GetString(2);
                    }
                    else
                    {
                        tbZygoSO.Text = string.Empty;
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
                        tbCustomerPN.Text = dr.GetString(5);
                    }
                    else
                    {
                        tbCustomerPN.Text = string.Empty;
                    }

                    if (!dr.IsDBNull(6))
                    {
                        tbCustomerPNDescription.Text = dr.GetString(6);
                    }
                    else
                    {
                        tbCustomerPNDescription.Text = string.Empty;
                    }

                    if (!dr.IsDBNull(7))
                    {
                        tbCustomerRev.Text = dr.GetString(7);
                    }
                    else
                    {
                        tbCustomerRev.Text = string.Empty;
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
                        dtpThroughTestDate.Text = dr.GetDateTime(9).ToString("MM/dd/yyyy");
                        dtpThroughTestDate.Checked = true;
                    }
                    else
                    {
                        dtpThroughTestDate.Checked = false;
                    }

                    if (!dr.IsDBNull(10))
                    {
                        tbQuantity.Text = dr.GetInt32(10).ToString();
                    }
                    else
                    {
                        tbQuantity.Text = string.Empty;
                    }


                    if (!dr.IsDBNull(11))
                    {
                        tbSerialNumber.Text = dr.GetString(11);
                    }
                    else
                    {
                        tbSerialNumber.Text = string.Empty;
                    }

                    if (!dr.IsDBNull(12))
                    {
                        tbNotes.Text = dr.GetString(12);
                    }
                    else
                    {
                        tbNotes.Text = string.Empty;
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
                        tbTemperature.Text = dr.GetString(14);
                    }
                    else
                    {
                        tbTemperature.Text = string.Empty;
                    }

                    if (!dr.IsDBNull(15))
                    {
                        tbHumidity.Text = dr.GetString(15);
                    }
                    else
                    {
                        tbHumidity.Text = string.Empty;
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
                        dtpShippedDate.Text = dr.GetDateTime(21).ToString("MM/dd/yyyy");
                    }
                    else
                    {
                        dtpShippedDate.Text = "01/01/1900";
                    }

                    if (!dr.IsDBNull(22))
                    {
                        cbddZygoSite.Text = dr.GetString(22).ToString();
                    }
                    else
                    {
                        cbddZygoSite.Text = string.Empty;
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

            SqlParameter pOrderNumberZygo = new SqlParameter("@orderNumberZygo", SqlDbType.VarChar);
            pOrderNumberZygo.Value = tbZygoSO.Text;

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


            SqlParameter pCustomerPN = new SqlParameter("@customerPN", SqlDbType.VarChar);
            if (tbCustomerPN.Text.Length > 0)
            {
                pCustomerPN.Value = tbCustomerPN.Text.Trim();
            }
            else
            {
                pCustomerPN.Value = string.Empty;
            }

            SqlParameter pCustomerPNDescription = new SqlParameter("@customerPNDescription", SqlDbType.VarChar);
            if (tbCustomerPNDescription.Text.Length > 0)
            {
                pCustomerPNDescription.Value = tbCustomerPNDescription.Text.Trim();
            }
            else
            {
                pCustomerPNDescription.Value = string.Empty;
            }

            SqlParameter pCustomerRev = new SqlParameter("@customerRev", SqlDbType.VarChar);
            if (tbCustomerRev.Text.Length > 0)
            {
                pCustomerRev.Value = tbCustomerRev.Text.Trim();
            }
            else
            {
                pCustomerRev.Value = string.Empty;
            }

                        
            SqlParameter pQuantity = new SqlParameter("@quantity", SqlDbType.VarChar);
            pQuantity.Value = tbQuantity.Text;


            SqlParameter pSN = new SqlParameter("@serialNumber", SqlDbType.VarChar);

            if (tbSerialNumber.Text.Length > 200)
            {
                MessageBox.Show("Serial Number box 200 character limit. \n\n Use Other Pertinent Information box below.");
                return;
                tbSerialNumber.Focus();
            }
            else
            {
                pSN.Value = tbSerialNumber.Text;
            }


            SqlParameter pTemperature = new SqlParameter("@temperature", SqlDbType.VarChar);
            pTemperature.Value = tbTemperature.Text;

            SqlParameter pHumidity = new SqlParameter("@humidity", SqlDbType.VarChar);
            pHumidity.Value = tbHumidity.Text;

            SqlParameter pNotes = new SqlParameter("@notes", SqlDbType.VarChar);
            if (tbNotes.Text.Length > 0)
            {
                pNotes.Value = tbNotes.Text.Trim();
            }
            else
            {
                pNotes.Value = string.Empty;
            }

            SqlParameter pCertifiedResults = new SqlParameter("@certifiedResults", SqlDbType.VarChar);
            if (tbCertifiedResults.Text.Length > 0)
            {
                pCertifiedResults.Value = tbCertifiedResults.Text.Trim();
            }
            else
            {
                pCertifiedResults.Value = string.Empty;
            }

            SqlParameter pOtherInformation = new SqlParameter("@otherInformation", SqlDbType.VarChar);
            pOtherInformation.Value = tbOtherPertinentInformation.Text;

            SqlParameter pInitials = new SqlParameter("@initials", SqlDbType.VarChar);
            pInitials.Value = tbTestedByInitials.Text;

            SqlParameter pSignedBy = new SqlParameter("@signedBy", SqlDbType.VarChar);
            pSignedBy.Value = tbSignedByName.Text;

            SqlParameter pTitle = new SqlParameter("@title", SqlDbType.VarChar);
            pTitle.Value = tbTitle.Text;

            SqlParameter pTestDate = new SqlParameter("@testDate", SqlDbType.Date);
            pTestDate.Value = dtpTestDate.Text;

            SqlParameter pThroughTestDate = new SqlParameter("@throughTestDate", SqlDbType.Date);

            
                    if (dtpThroughTestDate.Checked == false)
                    {
                        /* no selection has been made  */
                        pThroughTestDate.Value = DBNull.Value;
                    }
                    else
                    {
                        pThroughTestDate.Value = dtpThroughTestDate.Text;
                    }
            
            

            
            


            SqlParameter pDateSigned = new SqlParameter("@dateSigned", SqlDbType.Date);

            if (dtpDateSigned.Text == "01/01/1900")
            {
                pDateSigned.Value = DBNull.Value;
            }
            else
            {
                pDateSigned.Value = dtpDateSigned.Text;
            }

            SqlParameter pShippedDate = new SqlParameter("@shippedDate", SqlDbType.Date);

            if (dtpShippedDate.Text == "01/01/1900")
            {
                pShippedDate.Value = DBNull.Value;
            }
            else
            {
                pShippedDate.Value = dtpShippedDate.Text;
            }
            

            SqlParameter pZygoSite = new SqlParameter("@zygoSite", SqlDbType.VarChar);
            pZygoSite.Value = cbddZygoSite.Text;


            cnxn = new SqlConnection(g.db);

            SQL =
                "UPDATE " + g.dbTable +
                " SET " +
                " [Customer Name] =" + pCustomer +
                ",[Customer PO #] =" + pCustomerPO +
                ",OrderNumberZygo =" + pOrderNumberZygo +
                ",[P/N] =" + pPN +
                ",[Desc] =" + pDescription +
                ",CustomerPN = " + pCustomerPN +
                ",CustomerPNDescription =" + pCustomerPNDescription +
                ",CustomerRev =" + pCustomerRev +
                ",[Test Date] =" + pTestDate +
                ",[ThroughTestDate] =" + pThroughTestDate +
                ",Quantity =" + pQuantity +
                ",[Serial #] =" + pSN +
                ",Notes =" + pNotes +
                ",[Certified Results] =" + pCertifiedResults +
                ",Temperature =" + pTemperature +
                ",RelativeHumidity =" + pHumidity +
                ",[Other Pertinent Information] =" + pOtherInformation +
                ",[Written by] =" + pInitials +
                ",[Name] =" + pSignedBy +
                ",[Title] =" + pTitle +
                ",[Date] =" + pDateSigned +
                ",[Shipped Date] =" + pShippedDate +
                ",[ZygoSite] =" + pZygoSite +
                " WHERE [Certification #] = '" + g.certificationNumber + "'";

            cmd = new SqlCommand(SQL, cnxn);

            cmd.Parameters.Add(pCustomer);
            cmd.Parameters.Add(pCustomerPO);
            cmd.Parameters.Add(pOrderNumberZygo);
            cmd.Parameters.Add(pPN);
            cmd.Parameters.Add(pDescription);
            cmd.Parameters.Add(pCustomerPN);
            cmd.Parameters.Add(pCustomerPNDescription);
            cmd.Parameters.Add(pCustomerRev);
            cmd.Parameters.Add(pTestDate);
            cmd.Parameters.Add(pThroughTestDate);
            cmd.Parameters.Add(pQuantity);
            cmd.Parameters.Add(pSN);
            cmd.Parameters.Add(pNotes);
            cmd.Parameters.Add(pCertifiedResults);
            cmd.Parameters.Add(pTemperature);
            cmd.Parameters.Add(pHumidity);
            cmd.Parameters.Add(pOtherInformation);
            cmd.Parameters.Add(pInitials);
            cmd.Parameters.Add(pSignedBy);
            cmd.Parameters.Add(pTitle);
            cmd.Parameters.Add(pDateSigned);
            cmd.Parameters.Add(pShippedDate);
            cmd.Parameters.Add(pZygoSite);

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
                tbCertifiedResults.Text = cbddCertifiedResults.Text + "\n\n" + tbCertifiedResults.Text;
            }
        }
    }
}
