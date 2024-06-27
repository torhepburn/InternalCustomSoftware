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
using System.IO;
using System.Drawing.Printing;
using System.Diagnostics;

namespace NDA
{
    public partial class DataEntryForm : Form
    {
        SqlConnection cnxn;
        SqlConnection NAVcnxn;
        SqlConnection cnxnDash;
        SqlDataAdapter da;
        /*  for switch to NAV use these two variables below:  */
        private string NAVvendor = "SELECT Name from ZYGO$Vendor " +
                    "WHERE No_ LIKE  '%";  
        
        private string NAVcustomer = "SELECT Name from ZYGO$Customer " +
                    "WHERE No_ LIKE '%";   /* Customer for MK, No_ for NAV*/
        private string SQL = "";
        private int duplicate = 0;
        private string dateRequested;
        private string dateEffective;
        private string dateEnds;
        private string dateFiled;
        private string dateDestruction;
        DataTable dtRestrictedAccess;
        DataTable dtStatusNotes;
        private bool vendor = false;
        private bool customer = false;
        private string customerNo_ = "";
        private string vendorNo_ = "";

        public DataEntryForm()
        {
            InitializeComponent();
        }

        private void DataEntryForm_Load(object sender, EventArgs e)
        {
            this.Text = "Non-Disclosure Agreement DB v" + Application.ProductVersion;

                /*
                 * 
                 * Get data for the dropdown lists first
                 * 
                 * /

                /*
                 * 
                 * Employee
                 * 
                 * */
                cnxn = new SqlConnection(g.dbAFE);

                da = new SqlDataAdapter(
                     "select CN NAME from EmployeesAmetekAD " +
                     "order by SN ", cnxn);

                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();
                dt1.Rows.Add();
                dt2.Rows.Add();
                dt3.Rows.Add();
                dt1.AcceptChanges();
                dt2.AcceptChanges();
                dt3.AcceptChanges();

                try
                {
                    da.Fill(dt1);
                    da.Fill(dt2);
                    da.Fill(dt3);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {

                }
                cbddZygoContact.DataSource = dt1;
                cbddZygoContact.DisplayMember = "Name";

                cbddZygoAdministrator.DataSource = dt2;
                cbddZygoAdministrator.DisplayMember = "Name";

                cbddZygoSigner.DataSource = dt3;
                cbddZygoSigner.DisplayMember = "Name";



                /*
                 * 
                 * Party Protected
                 * 
                 * */
                cnxn = new SqlConnection(g.db);

                da = new SqlDataAdapter(
                     "select distinct PartyProtected from NDA " +
                     "order by PartyProtected ", cnxn);

                dt1 = new DataTable();
                dt1.Rows.Add();
                dt1.AcceptChanges();

                try
                {
                    da.Fill(dt1);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {

                }

                cbddPartyProtected.DataSource = dt1;
                cbddPartyProtected.DisplayMember = "partyprotected";

                /*
                * 
                * Subject Protected
                * 
                * */
                cnxn = new SqlConnection(g.db);

                da = new SqlDataAdapter(
                     "select distinct SubjectProtected from NDA " +
                     "order by SubjectProtected ", cnxn);

                dt1 = new DataTable();
                dt1.Rows.Add();
                dt1.AcceptChanges();

                try
                {
                    da.Fill(dt1);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {

                }

                cbddSubjectProtected.DataSource = dt1;
                cbddSubjectProtected.DisplayMember = "subjectprotected";


                /*
                * 
                * Life After Termination
                * 
                * */
                cnxn = new SqlConnection(g.db);

                da = new SqlDataAdapter(
                     "select distinct LifeAfterTermination from DropDownTerms " +
                     "order by LifeAfterTermination", cnxn);

                dt1 = new DataTable();
                dt1.Rows.Add();
                dt1.AcceptChanges();

                try
                {
                    da.Fill(dt1);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {

                }

                cbddLifeAfterTermination.DataSource = dt1;
                cbddLifeAfterTermination.DisplayMember = "lifeaftertermination";

                /*
                 * 
                 * Suppliers
                 * 
                 * */
                SqlConnection NAVcnxn = new SqlConnection(g.dbNAV);

                da = new SqlDataAdapter(
                     "select RIGHT( LTRIM(RTRIM(No_)) + SPACE(15-LEN(LTRIM(RTRIM(No_)))), 15 ) No_, " +
                     "Name from [ZYGO-NAV-PROD].dbo.ZYGO$Vendor order by Name ", NAVcnxn);

            dt1 = new DataTable();
                dt1.Rows.Add();
                dt1.AcceptChanges();


                try
                {
                    da.Fill(dt1);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {

                }

                cbddVendor.DataSource = dt1;

                DataColumn dc = new DataColumn("combined");
                dc.Expression = string.Format("{0}+ '     '+ {1}", "No_", "Name");
                dt1.Columns.Add(dc);
                cbddVendor.DisplayMember = "combined";
                cbddVendor.ValueMember = "No_";


                /*
                 * 
                 * Customers
                 * 
                 * */
                NAVcnxn = new SqlConnection(g.dbNAV);

                da = new SqlDataAdapter(
                    "select No_, Name from ZYGO$Customer order by Name ", NAVcnxn);

                dt1 = new DataTable();
                dt1.Rows.Add();
                dt1.AcceptChanges();


                try
                {
                    da.Fill(dt1);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {

                }

                cbddCustomer.DataSource = dt1;

                DataColumn dc1 = new DataColumn("combined");
                dc1.Expression = string.Format("{0}+ '     '+ {1}", "No_", "Name");
                dt1.Columns.Add(dc1);
                cbddCustomer.DisplayMember = "combined";
                cbddCustomer.ValueMember = "No_";

            if (g.Task == "PDF")
            {

            }
            else
            {

                if (g.userType.ToUpper() == "PROCUREMENT" & g.Task == "ADD")
                {
                    cnxn = new SqlConnection(g.db);
                    cnxn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnxn;
                    cmd.CommandText = "spGetInsertedID";
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter NewID = new SqlParameter("@InsertID", SqlDbType.Int);
                    NewID.Direction = ParameterDirection.Output;
                    NewID.Value = 0;

                    cmd.Parameters.Add(NewID);

                    try
                    {
                        cmd.ExecuteNonQuery();

                        g.NDA_ID = NewID.Value.ToString();
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


                    LNdaID.Visible = false;
                    bPrint.Visible = false;
                    LStatusNotes.Visible = false;
                    tbStatusNotes.Visible = false;
                    DgvNotes.Visible = false;
                    DGV.Visible = false;
                    cbRestrictedAccess.Visible = false;
                    LStatusDate.Visible = false;
                    dtpStatusDate.Visible = false;
                    cbDateRequested.Checked = true;
                    dtpDateRequested.Visible = true;
                    cbDateOriginalFiled.Checked = true;
                    dtpDateOriginalFiled.Visible = true;
                    cbEffectiveDate.Checked = true;
                    dtpEffectiveDate.Visible = true;
                    cbddStatus.Text = "Filed";
                    cbddPartyProtected.Text = "Mutual (Zygo NDA-Supplier)";
                    cbddAgreementType.Text = "Mutual Zygo";
                    cbddZygoAdministrator.Text = g.user;
                    cbddZygoContact.Text = g.user;
                    cbddZygoSigner.Text = g.user;
                    cbProcurement.Checked = true;
                    Lrequested.Visible = false;
                    Leffective.Visible = false;
                    Lcontract.Visible = false;
                    Lfiled.Visible = false;
                    Ldestruction.Visible = false;
                }




                if (g.Task == "EDIT" | g.Task == "ProcurementEDIT")
                {
                    if (g.Task == "EDIT")
                    {
                        RestrictedAccess();
                        StatusNotesLoad();
                    }

                    try
                    {
                        cnxn.Open();

                        SqlCommand cmd = new SqlCommand(
                         "select " +
                         "NDA_ID," +
                         "Company," +
                         "CompanyContact," +
                         "ZygoContact," +
                         "PartyProtected," +
                         "SubjectProtected," +
                         "DateRcvd," +
                         "DateSigned," +
                         "PeriodEnds," +
                         "Administrator," +
                         "ZygoSigner," +
                         "Status," +
                         "TerminationNotice," +
                         "LifeAfterTermination," +
                         "ProdLine," +
                         "Procurement, " +
                         "City," +
                         "State," +
                         "Country," +
                         "OriginalFiled, " +
                         "DoingBusinessAs," +
                         "DestructionDate," +
                         "AgreementType," +
                         "Restricted," +
                         "Parent, " +
                         "Storedpdf, " +
                         "InactiveForProcurement " +
                         "FROM NDA where NDA_ID = " + g.NDA_ID, cnxn);

                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {

                            if (!dr.IsDBNull(0)) { LNdaID.Text = "NDA ID: " + dr.GetInt32(0).ToString().Trim(); }
                            if (!dr.IsDBNull(1)) { tbCompany.Text = dr.GetString(1).Trim(); }
                            if (!dr.IsDBNull(2)) { tbCompanyContact.Text = dr.GetString(2).Trim(); }
                            if (!dr.IsDBNull(3)) { cbddZygoContact.Text = dr.GetString(3).Trim(); }
                            if (!dr.IsDBNull(4)) { cbddPartyProtected.Text = dr.GetString(4).Trim(); }
                            if (!dr.IsDBNull(5)) { cbddSubjectProtected.Text = dr.GetString(5).Trim(); }
                            if (!dr.IsDBNull(6))
                            {
                                dtpDateRequested.Text = dr.GetDateTime(6).ToShortDateString().Trim();
                                dateRequested = dr.GetDateTime(6).ToShortDateString().Trim();
                                Lrequested.Text = dateRequested;
                            }
                            if (!dr.IsDBNull(7))
                            {
                                dtpEffectiveDate.Text = dr.GetDateTime(7).ToShortDateString().Trim();
                                dateEffective = dr.GetDateTime(7).ToShortDateString().Trim();
                                Leffective.Text = dateEffective;
                            }
                            if (!dr.IsDBNull(8))
                            {
                                dtpContractEnds.Text = dr.GetDateTime(8).ToShortDateString().Trim();
                                dateEnds = dr.GetDateTime(8).ToShortDateString().Trim();
                                Lcontract.Text = dateEnds;
                            }
                            if (!dr.IsDBNull(9)) { cbddZygoAdministrator.Text = dr.GetString(9).Trim(); }
                            if (!dr.IsDBNull(10)) { cbddZygoSigner.Text = dr.GetString(10).Trim(); }
                            if (!dr.IsDBNull(11)) { cbddStatus.Text = dr.GetString(11).Trim(); }
                            if (!dr.IsDBNull(12)) { cbddTerminationNotice.Text = dr.GetString(12).Trim(); }
                            if (!dr.IsDBNull(13)) { cbddLifeAfterTermination.Text = dr.GetString(13).Trim(); }
                            if (!dr.IsDBNull(14)) { cbddProductLine.Text = dr.GetString(14).Trim(); }
                            if (!dr.IsDBNull(15))
                            {
                                if (dr.GetBoolean(15))
                                {
                                    cbProcurement.Checked = true;
                                }
                                else
                                {
                                    cbProcurement.Checked = false;
                                }
                            }
                            if (!dr.IsDBNull(16)) { tbCity.Text = dr.GetString(16).Trim(); }
                            if (!dr.IsDBNull(17)) { tbState.Text = dr.GetString(17).Trim(); }
                            if (!dr.IsDBNull(18)) { tbCountry.Text = dr.GetString(18).Trim(); }
                            if (!dr.IsDBNull(19))
                            {
                                dtpDateOriginalFiled.Text = dr.GetDateTime(19).ToShortDateString().Trim();
                                dateFiled = dr.GetDateTime(19).ToShortDateString().Trim();
                                Lfiled.Text = dateFiled;
                            }
                            if (!dr.IsDBNull(20)) { tbDoingBusinessAs.Text = dr.GetString(20).Trim(); }
                            if (!dr.IsDBNull(21))
                            {
                                dtpDestructionDate.Text = dr.GetDateTime(21).ToShortDateString().Trim();
                                dateDestruction = dr.GetDateTime(21).ToShortDateString().Trim();
                                Ldestruction.Text = dateDestruction;
                            }
                            if (!dr.IsDBNull(22)) { cbddAgreementType.Text = dr.GetString(22).Trim(); }
                            if (!dr.IsDBNull(23))
                            {
                                if (dr.GetBoolean(23))
                                {
                                    cbRestrictedAccess.Checked = true;
                                }
                                else
                                {
                                    cbRestrictedAccess.Checked = false;
                                }
                            }
                            if (!dr.IsDBNull(24)) { tbParent.Text = dr.GetString(24).Trim(); }
                            if (!dr.IsDBNull(25))
                            {
                                if (dr.GetBoolean(25))
                                {
                                    LpdfStored.Text = "pdf Filed = Yes";
                                }
                                else
                                {
                                    LpdfStored.Text = "pdf Filed = No";
                                }
                            }
                            if (!dr.IsDBNull(26))
                            {
                                if (dr.GetBoolean(26))
                                {
                                    cbInactiveForProcurement.Checked = true;
                                }
                                else
                                {
                                    cbInactiveForProcurement.Checked = false;
                                }
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        cnxn.Close();
                    }

                    if (g.Task == "ProcurementEDIT")
                    {
                        cbInactiveForProcurement.BackColor = Color.Yellow;
                        bPrint.Visible = false;
                        Bpdf.Visible = false;
                        LStatusNotes.Visible = false;
                        tbStatusNotes.Visible = false;
                        DgvNotes.Visible = false;
                        DGV.Visible = false;
                        cbRestrictedAccess.Visible = false;
                        tbCompany.Enabled = false;
                        LStatusDate.Visible = false;
                        dtpStatusDate.Visible = false;
                        cbDateRequested.Enabled = false;

                        //cbDateRequested.Visible = false;
                        //dtpDateRequested.Enabled = false;
                        //dtpDateRequested.Visible = false;
                        //cbDateOriginalFiled.Visible = false;
                        //dtpDateOriginalFiled.Enabled = false;
                        //cbEffectiveDate.Visible = false;
                        cbEffectiveDate.Enabled = false;

                        cbContractEnds.Enabled = false;
                        cbDateOriginalFiled.Enabled = false;
                        cbDestructionDate.Enabled = false;

                        cbddStatus.Enabled = false;
                        cbddPartyProtected.Enabled = false;
                        cbddAgreementType.Enabled = false;
                        cbddZygoAdministrator.Enabled = false;
                        cbddZygoContact.Enabled = false;
                        cbddZygoSigner.Enabled = false;
                        cbddProductLine.Enabled = false;
                        cbddSubjectProtected.Enabled = false;
                        cbddTerminationNotice.Enabled = false;
                        cbddLifeAfterTermination.Enabled = false;
                        cbProcurement.Enabled = false;
                        tbCompanyContact.Enabled = false;
                        cbddVendor.Enabled = false;
                        cbddCustomer.Enabled = false;
                        tbCity.Enabled = false;
                        tbState.Enabled = false;
                        tbCountry.Enabled = false;
                        tbParent.Enabled = false;
                        tbDoingBusinessAs.Enabled = false;

                        //Lrequested.Visible = false;
                        //Leffective.Visible = false;
                        //Lcontract.Visible = false;
                        //Lfiled.Visible = false;
                        //Ldestruction.Visible = false;
                    }

                }   /* End Edit    */
            }
        }

        private void RestrictedAccess()
        {
            /*
        * 
        * Restricted UsersLife After Termination
        * 
        * */
            cnxn = new SqlConnection(g.db);

            da = new SqlDataAdapter(
                 "select EmployeeName from RestrictedAccess " +
                 "WHERE NDA_ID = " + g.NDA_ID +
                 "order by EmployeeName", cnxn);

            dtRestrictedAccess = new DataTable();


            try
            {
                da.Fill(dtRestrictedAccess);
                DGV.DataSource = dtRestrictedAccess;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

            }

            DGV.Columns[0].Width = 175;

        }

        private void StatusNotesLoad()
        {
            /*
                * 
                * Status Notes
                * 
            * */
            cnxn = new SqlConnection(g.db);

            da = new SqlDataAdapter(
                 " select CONVERT(VarChar(10),StatusDate,101) [Date], Status from NDA_Status " +
                 " WHERE NDA_ID = " + g.NDA_ID +
                 " order by StatusDate DESC", cnxn);

            dtStatusNotes = new DataTable();


            try
            {
                da.Fill(dtStatusNotes);
                DgvNotes.DataSource = dtStatusNotes;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

            }

            DgvNotes.Columns[0].Width = 90;
            DgvNotes.Columns[1].Width = 1000;
        }
                
        private void cbRestrictedAccess_MouseClick(object sender, MouseEventArgs e)
        {
            RestrictedAccessEmployees r = new RestrictedAccessEmployees();
            r.ShowDialog(this);

            RestrictedAccess();
        }


        private void Bsave_Click(object sender, EventArgs e)
        {
            SaveData();

            tbCompany.Text = string.Empty;
            tbCompanyContact.Text = string.Empty;
            tbCity.Text = string.Empty;
            tbState.Text = string.Empty;
            tbCountry.Text = string.Empty;
            tbParent.Text = string.Empty;
            tbDoingBusinessAs.Text = string.Empty;

            cbddStatus.ResetText();
            cbddProductLine.ResetText();
            cbddAgreementType.ResetText();
            cbddZygoContact.ResetText();
            cbddPartyProtected.ResetText();
            cbddZygoAdministrator.ResetText();
            cbddZygoSigner.ResetText();
            cbddSubjectProtected.ResetText();
            cbddTerminationNotice.ResetText();
            cbddLifeAfterTermination.ResetText();

            dtpDateRequested.ResetText();
            dtpEffectiveDate.ResetText();
            dtpContractEnds.ResetText();
            dtpDateOriginalFiled.ResetText();
            dtpDestructionDate.ResetText();

            DGV.DataSource = null;
            DGV.Rows.Clear();
            DgvNotes.DataSource = null;
            DgvNotes.Rows.Clear();

            this.Close();
        }

        private void SaveData()
        {
            SqlParameter pStatus = new SqlParameter
              ("@Status", SqlDbType.NChar);
            pStatus.Value = cbddStatus.Text;

            SqlParameter pCompany = new SqlParameter
             ("@Company", SqlDbType.NChar);
            if (tbCompany.Text.Length > 0)
            {
                pCompany.Value = tbCompany.Text;
            }
            else
            {
                pCompany.Value = DBNull.Value;
            }


            SqlParameter pCompanyContact = new SqlParameter
             ("@CompanyContact", SqlDbType.NChar);
            pCompanyContact.Value = tbCompanyContact.Text;

            SqlParameter pCity = new SqlParameter
             ("@City", SqlDbType.NChar);
            pCity.Value = tbCity.Text;

            SqlParameter pState = new SqlParameter
             ("@State", SqlDbType.NChar);
            pState.Value = tbState.Text;

            SqlParameter pCountry = new SqlParameter
             ("@Country", SqlDbType.NChar);
            pCountry.Value = tbCountry.Text;

            SqlParameter pParent = new SqlParameter
             ("@Parent", SqlDbType.NChar);
            pParent.Value = tbParent.Text;

            SqlParameter pDoingBusinessAs = new SqlParameter
             ("@DoingBusinessAs", SqlDbType.NChar);
            pDoingBusinessAs.Value = tbDoingBusinessAs.Text;

            SqlParameter pProductLine = new SqlParameter
             ("@ProductLine", SqlDbType.NChar);
            pProductLine.Value = cbddProductLine.Text;

            int procurement = 0;

            if (cbProcurement.Checked)
            {
                procurement = 1;
            }
            else
            {
                procurement = 0;
            }

            SqlParameter pAgreementType = new SqlParameter
             ("@AgreementType", SqlDbType.NChar);
            pAgreementType.Value = cbddAgreementType.Text;

            SqlParameter pZygoContact = new SqlParameter
             ("@ZygoContact", SqlDbType.NChar);
            pZygoContact.Value = cbddZygoContact.Text;

            SqlParameter pZygoAdministrator = new SqlParameter
             ("@ZygoAdministrator", SqlDbType.NChar);
            pZygoAdministrator.Value = cbddZygoAdministrator.Text;

            SqlParameter pZygoSigner = new SqlParameter
             ("@ZygoSigner", SqlDbType.NChar);
            pZygoSigner.Value = cbddZygoSigner.Text;

            SqlParameter pPartyProtected = new SqlParameter
             ("@PartyProtected", SqlDbType.NChar);
            pPartyProtected.Value = cbddPartyProtected.Text;

            SqlParameter pSubjectProtected = new SqlParameter
             ("@SubjectProtected", SqlDbType.NChar);
            pSubjectProtected.Value = cbddSubjectProtected.Text;

            SqlParameter pTerminationNotice = new SqlParameter
             ("@TerminationNotice", SqlDbType.NChar);
            pTerminationNotice.Value = cbddTerminationNotice.Text;

            SqlParameter pLifeAfterTermination = new SqlParameter
             ("@LifeAfterTermination", SqlDbType.NChar);
            pLifeAfterTermination.Value = cbddLifeAfterTermination.Text;

            SqlParameter pDateRequested = new SqlParameter
                ("@DateRequested", SqlDbType.Date);

            if (g.Task == "EDIT")
            {
                if (cbDateRequested.Checked)
                {
                    pDateRequested.Value = dtpDateRequested.Text;
                }
                else
                {
                    if (dateRequested is null)
                    {
                        pDateRequested.Value = DBNull.Value;
                    }
                    else
                    {
                        pDateRequested.Value = dateRequested;
                    }
                }
            }
            else
            {
                if (cbDateRequested.Checked)
                {
                    pDateRequested.Value = dtpDateRequested.Text;
                }
                else
                {
                    pDateRequested.Value = DateTime.Now;
                }
            }

            SqlParameter pEffectiveDate = new SqlParameter
                ("@EffectiveDate", SqlDbType.Date);
            if (g.Task == "EDIT")
            {
                if (cbEffectiveDate.Checked)
                {
                    pEffectiveDate.Value = dtpEffectiveDate.Text;
                }
                else
                {
                    if (dateEffective is null)
                    {
                        pEffectiveDate.Value = DBNull.Value;
                    }
                    else
                    {
                        pEffectiveDate.Value = dateEffective;
                    }
                }
            }
            else
            {
                if (cbEffectiveDate.Checked)
                {
                    pEffectiveDate.Value = dtpEffectiveDate.Text;
                }
                else
                {
                    pEffectiveDate.Value = DBNull.Value;
                }
            }

            SqlParameter pContractEnds = new SqlParameter
                ("@ContractEnds", SqlDbType.Date);
            if (g.Task == "EDIT")
            {
                if (cbContractEnds.Checked)
                {
                    pContractEnds.Value = dtpContractEnds.Text;
                }
                else
                {
                    if (dateEnds is null)
                    {
                        pContractEnds.Value = DBNull.Value;
                    }
                    else
                    {
                        pContractEnds.Value = dateEnds;
                    }
                }
            }
            else
            {
                if(cbContractEnds.Checked)
                {
                    pContractEnds.Value = dtpContractEnds.Text;
                }
                else
                {
                    pContractEnds.Value = DBNull.Value;
                }
            }

            SqlParameter pDateOriginalFiled = new SqlParameter
                ("@DateOriginalFiled", SqlDbType.Date);
            if (g.Task == "EDIT")
            {
                if (cbDateOriginalFiled.Checked)
                {
                    pDateOriginalFiled.Value = dtpDateOriginalFiled.Text;
                }
                else
                {
                    if (dateFiled is null)
                    {
                        pDateOriginalFiled.Value = DBNull.Value;
                    }
                    else
                    {
                        pDateOriginalFiled.Value = dateFiled;
                    }
                }
            }
            else
            {
                if (cbDateOriginalFiled.Checked)
                {
                    pDateOriginalFiled.Value = dtpDateOriginalFiled.Text;
                }
                else
                {
                    pDateOriginalFiled.Value = DBNull.Value;
                }
            }

            SqlParameter pDestructionDate = new SqlParameter
                            ("@DestructionDate", SqlDbType.Date);
            if (g.Task == "EDIT")
            {
                if (cbDestructionDate.Checked)
                {
                    pDestructionDate.Value = dtpDestructionDate.Text;
                }
                else
                {
                    if (dateDestruction is null)
                    {
                        pDestructionDate.Value = DBNull.Value;
                    }
                    else
                    {
                        pDestructionDate.Value = dateDestruction;
                    }
                }
            }
            else
            {
                if (cbDestructionDate.Checked)
                {
                    pDestructionDate.Value = dtpDestructionDate.Text;
                }
                else
                {
                    pDestructionDate.Value = DBNull.Value;
                }
            }
            int restricted = 0;


            if (cbRestrictedAccess.Checked)
            {
                restricted = 1;
            }
            else
            {
                restricted = 0;
            }

            if (g.Task == "ADD")
            {

                SQL = "SELECT COUNT(NDA_ID) FROM NDA " +
                    "WHERE company = " + pCompany + " " +
                    "AND companycontact = " + pCompanyContact + " " +
                    "AND datesigned = " + pEffectiveDate;

                SqlCommand cmd1 = new SqlCommand(SQL, cnxn);

                cmd1.Parameters.Add(pCompany);
                cmd1.Parameters.Add(pCompanyContact);
                cmd1.Parameters.Add(pEffectiveDate);

                object result = 0;

                try
                {
                    cnxn.Open();
                    result = cmd1.ExecuteScalar();
                    cmd1.Parameters.Clear();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn.Close();
                    cmd1.Parameters.Clear();
                }

                duplicate = Convert.ToInt32(result);
            }


            if (duplicate == 0)
            {
                SQL = "UPDATE NDA SET ";

                if (tbCompany.Text.Length > 0)
                {
                    SQL += "Company = " + pCompany;
                }
                if (tbCompanyContact.Text.Length > 0)
                {
                    SQL += " ,CompanyContact = " + pCompanyContact;
                }
                if (cbddZygoContact.Text.Length > 0)
                {
                    SQL += " ,ZygoContact = " + pZygoContact;
                }
                if (cbddPartyProtected.Text.Length > 0)
                {
                    SQL += " ,PartyProtected = " + pPartyProtected;
                }
                if (cbddSubjectProtected.Text.Length > 0)
                {
                    SQL += " ,SubjectProtected = " + pSubjectProtected;
                }
                if (cbDateRequested.Checked)
                {
                    SQL += " ,DateRcvd = " + pDateRequested;
                }
                if (cbEffectiveDate.Checked)
                {
                    SQL += " ,DateSigned = " + pEffectiveDate;
                }
                if (cbContractEnds.Checked)
                {
                    SQL += " ,PeriodEnds = " + pContractEnds;
                }
                if (cbddZygoAdministrator.Text.Length > 0)
                {
                    SQL += " ,Administrator = " + pZygoAdministrator;
                }
                if (cbddZygoSigner.Text.Length > 0)
                {
                    SQL += " ,ZygoSigner = " + pZygoSigner;
                }
                if (cbddStatus.Text.Length > 0)
                {
                    SQL += " ,Status = " + pStatus;
                }
                if (cbddTerminationNotice.Text.Length > 0)
                {
                    SQL += " ,TerminationNotice = " + pTerminationNotice;
                }
                if (cbddLifeAfterTermination.Text.Length > 0)
                {
                    SQL += " ,LifeAfterTermination = " + pLifeAfterTermination;
                }
                if (cbddProductLine.Text.Length > 0)
                {
                    SQL += " ,ProdLine = " + pProductLine;
                }

                SQL += " ,Procurement = " + procurement;

                if (tbCity.Text.Length > 0)
                {
                    SQL += " ,City = " + pCity;
                }
                if (tbState.Text.Length > 0)
                {
                    SQL += " ,State = " + pState;
                }
                if (tbCountry.Text.Length > 0)
                {
                    SQL += " ,Country = " + pCountry;
                }
                if (cbDateOriginalFiled.Checked)
                {
                    SQL += " ,OriginalFiled =  " + pDateOriginalFiled;
                }
                if (tbDoingBusinessAs.Text.Length > 0)
                {
                    SQL += " ,DoingBusinessAs = " + pDoingBusinessAs;
                }
                if (cbDestructionDate.Checked)
                {
                    SQL += " ,DestructionDate = " + pDestructionDate;
                }
                if (cbddAgreementType.Text.Length > 0)
                {
                    SQL += " ,AgreementType = " + pAgreementType;
                }

                SQL += " ,Restricted = " + restricted;

                if (tbParent.Text.Length > 0)
                {
                    SQL += " ,Parent = " + pParent;
                }

                if (customerNo_.Length > 0)
                {
                    SQL += " ,Customer_ID = '" + customerNo_ + "'";
                }

                if (vendorNo_.Length > 0)
                {
                    SQL += " ,Vendor_ID =' " + vendorNo_ + "'";
                }

                SQL += " WHERE NDA_ID = " + g.NDA_ID;
            }
            else
            {
                SQL = "DELETE FROM NDA WHERE NDA_ID = " + g.NDA_ID; 
            }

            if (g.Task == "ProcurementEDIT")
            {
                if (cbInactiveForProcurement.Checked)
                {
                    SQL = "UPDATE nda SET inactiveforprocurement = 1 " +
                        "WHERE NDA_ID = " + g.NDA_ID + "";
                }
                else
                {
                    SQL = "UPDATE nda SET inactiveforprocurement = 0 " +
                        "WHERE NDA_ID = " + g.NDA_ID + "";
                }
            }


            SqlCommand cmd = new SqlCommand(SQL, cnxn);

            cmd.Parameters.Add(pCompany);
            cmd.Parameters.Add(pCompanyContact);
            cmd.Parameters.Add(pZygoContact);
            cmd.Parameters.Add(pPartyProtected);
            cmd.Parameters.Add(pSubjectProtected);
            cmd.Parameters.Add(pDateRequested);
            cmd.Parameters.Add(pEffectiveDate);
            cmd.Parameters.Add(pContractEnds);
            cmd.Parameters.Add(pZygoAdministrator);
            cmd.Parameters.Add(pZygoSigner);
            cmd.Parameters.Add(pStatus);
            cmd.Parameters.Add(pTerminationNotice);
            cmd.Parameters.Add(pLifeAfterTermination);
            cmd.Parameters.Add(pProductLine);
            cmd.Parameters.Add(pCity);
            cmd.Parameters.Add(pState);
            cmd.Parameters.Add(pCountry);
            cmd.Parameters.Add(pDateOriginalFiled);
            cmd.Parameters.Add(pDoingBusinessAs);
            cmd.Parameters.Add(pDestructionDate);
            cmd.Parameters.Add(pAgreementType);
            cmd.Parameters.Add(pParent);


            try
            {
                cnxn.Open();
                int row = cmd.ExecuteNonQuery();

                if (row > 0)
                {
                    MessageBox.Show("Data Saved");
                }
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

            SqlParameter pStatusNotes = new SqlParameter
               ("@StatusNotes", SqlDbType.NChar);
            if (tbStatusNotes.Text.Length > 0)
            {
                pStatusNotes.Value = tbStatusNotes.Text;
            }

            SqlParameter pStatusDate = new SqlParameter
               ("@StatusDate", SqlDbType.Date);
            if (dtpStatusDate.Text.Length > 0)
            {
                pStatusDate.Value = dtpStatusDate.Text;
            }

            if (tbStatusNotes.Text.Length > 0)
            {

                SQL = "Insert into NDA_Status (" +
                    " NDA_ID " +
                    ",StatusDate " +
                    ",Status) " +
                    "values (" + g.NDA_ID + "," +
                    pStatusDate + "," +
                    pStatusNotes + ")";


                cnxn = new SqlConnection(g.db);
                cmd = new SqlCommand(SQL, cnxn);

                cmd.Parameters.Add(pStatusDate);
                cmd.Parameters.Add(pStatusNotes);

                try
                {
                    cnxn.Open();
                    int row = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn.Close();

                    tbStatusNotes.Text = string.Empty;
                    StatusNotesLoad();
                }
            }

            if (g.Task == "ADD")
            {
                cnxn.Open();
                SqlCommand cmd1 = new SqlCommand("Select top 1 NDA_ID from NDA order by NDA_ID DESC", cnxn);
                object x = cmd1.ExecuteScalar();
                cnxn.Close();

                g.NDA_ID = x.ToString();

                if (cbRestrictedAccess.Checked)
                {
                    cnxn.Open();
                    cmd1 = new SqlCommand("update restrictedaccess " +
                        "SET NDA_ID = " + g.NDA_ID + " where NDA_ID = 999", cnxn);
                    cmd1.ExecuteNonQuery();
                    cnxn.Close();
                }
            }
            
        }
        
        private void cbddStatus_MouseClick(object sender, MouseEventArgs e)
        {
            if (cbddStatus.Text == "Read and Reviewed")
            {
                dtpEffectiveDate.Enabled = false;
                dtpContractEnds.Enabled = false;
                dtpDateOriginalFiled.Enabled = false;
                dtpDestructionDate.Enabled = false;
            }
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;
            (ppd as Form).WindowState = FormWindowState.Maximized;
            ppd.ShowDialog();
            Close();
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            Pen pen = new Pen(Color.Black);
            pen.Width = 1;
            Font arial = new Font("arial", 10, FontStyle.Regular);
            Font title = new Font("arial", 14, FontStyle.Bold);
            int col1 = 40;
            int col1D = 190;
            int col2 = 515;
            int col2D = 690;

            ev.Graphics.DrawString("Non-Disclosure Agreement", title, Brushes.Black, 260, 50);

            ev.Graphics.DrawString("NDA ID: " + g.NDA_ID, title, Brushes.Black, 50, 50);
            ev.Graphics.DrawString("Status: " + cbddStatus.Text, arial, Brushes.Black, col1, 100);
            ev.Graphics.DrawString(cbddStatus.Text, arial, Brushes.Black, col1D, 100);
            ev.Graphics.DrawString("Product Line: " , arial, Brushes.Black, col2, 100);
            ev.Graphics.DrawString(cbddProductLine.Text, arial, Brushes.Black, col2D, 100);
            ev.Graphics.DrawString("Company: ", arial, Brushes.Black, col1, 125);
            ev.Graphics.DrawString(tbCompany.Text, arial, Brushes.Black, col1D, 125);
            
            ev.Graphics.DrawString("Procurement NDA: ", arial, Brushes.Black, col2, 125);

            if (cbProcurement.Checked)
            {
                ev.Graphics.DrawString("Yes", arial, Brushes.Black, col2D, 125);
                
            }
            else
            {
                ev.Graphics.DrawString("No", arial, Brushes.Black, col2D, 125);
            }

            ev.Graphics.DrawString("Agreement Type: ", arial, Brushes.Black, col2, 150);
            ev.Graphics.DrawString(cbddAgreementType.Text, arial, Brushes.Black, col2D, 150);
            ev.Graphics.DrawString("Vendor: " , arial, Brushes.Black, col1, 150);
            ev.Graphics.DrawString(cbddVendor.Text, arial, Brushes.Black, col1D, 150);
            ev.Graphics.DrawString("Customer: ", arial, Brushes.Black, col1, 175);
            ev.Graphics.DrawString(cbddCustomer.Text, arial, Brushes.Black, col1D, 175);
            ev.Graphics.DrawString("Company Contact: ", arial, Brushes.Black, col1, 200);
            ev.Graphics.DrawString(tbCompanyContact.Text, arial, Brushes.Black, col1D, 200);

            ev.Graphics.DrawString("Restricted Employees Access Only: ", arial, Brushes.Black, 450, 200);

            if (cbRestrictedAccess.Checked)
            {
                ev.Graphics.DrawString("Yes", arial, Brushes.Black, col2D, 200);

                int n = dtRestrictedAccess.Rows.Count;

                for (int i = 0; i < n; i++)
                {
                    ev.Graphics.DrawString(dtRestrictedAccess.Rows[i][0].ToString(), arial, Brushes.Black, col2D, 200 + ((i + 1) * 20));
                }
            }
            else
            { ev.Graphics.DrawString("No", arial, Brushes.Black, col2D, 200); }

            ev.Graphics.DrawString("City: ", arial, Brushes.Black, col1, 225);
            ev.Graphics.DrawString(tbCity.Text, arial, Brushes.Black, col1D, 225);
            ev.Graphics.DrawString("State: ", arial, Brushes.Black, col1, 250);
            ev.Graphics.DrawString(tbState.Text, arial, Brushes.Black, col1D, 250);
            ev.Graphics.DrawString("Country: ", arial, Brushes.Black, col1, 275);
            ev.Graphics.DrawString(tbCountry.Text, arial, Brushes.Black, col1D, 275);
            ev.Graphics.DrawString("Parent: ", arial, Brushes.Black, col1, 300);
            ev.Graphics.DrawString(tbParent.Text, arial, Brushes.Black, col1D, 300);
            ev.Graphics.DrawString("Doing Business As: ", arial, Brushes.Black, col1, 325);
            ev.Graphics.DrawString(tbDoingBusinessAs.Text, arial, Brushes.Black, col1D, 325);
            ev.Graphics.DrawString("Zygo Contact: ", arial, Brushes.Black, col1, 375);
            ev.Graphics.DrawString(cbddZygoContact.Text, arial, Brushes.Black, col1D, 375);
            ev.Graphics.DrawString("Zygo Administrator: ", arial, Brushes.Black, col2, 375);
            ev.Graphics.DrawString(cbddZygoAdministrator.Text, arial, Brushes.Black, col2D, 375);
            ev.Graphics.DrawString("Party Protected: ", arial, Brushes.Black, col1, 400);
            ev.Graphics.DrawString(cbddPartyProtected.Text, arial, Brushes.Black, col1D, 400);
            ev.Graphics.DrawString("Zygo Signer: ", arial, Brushes.Black, col2, 400);
            ev.Graphics.DrawString(cbddZygoSigner.Text, arial, Brushes.Black, col2D, 400);
            ev.Graphics.DrawString("Subject Protected: ", arial, Brushes.Black, col1, 425);
            ev.Graphics.DrawString(cbddSubjectProtected.Text, arial, Brushes.Black, col1D, 425);
            ev.Graphics.DrawString("Termination Notice: ", arial, Brushes.Black, col1, 450);
            ev.Graphics.DrawString(cbddTerminationNotice.Text, arial, Brushes.Black, col1D, 450);
            ev.Graphics.DrawString("Life After Termination: ", arial, Brushes.Black, col1, 475);
            ev.Graphics.DrawString(cbddLifeAfterTermination.Text, arial, Brushes.Black, col1D, 475);

            ev.Graphics.DrawString("Date Requested: ", arial, Brushes.Black, col1, 500);
            ev.Graphics.DrawString(dateRequested, arial, Brushes.Black, col1D, 500);
            ev.Graphics.DrawString("Effective Date: ", arial, Brushes.Black, col1, 520);
            ev.Graphics.DrawString(dateEffective, arial, Brushes.Black, col1D, 520);
            ev.Graphics.DrawString("Contract Ends: ", arial, Brushes.Black, col1, 540);
            ev.Graphics.DrawString(dateEnds, arial, Brushes.Black, col1D, 540);
            ev.Graphics.DrawString("Date Original Filed: ", arial, Brushes.Black, col1, 560);
            ev.Graphics.DrawString(dateFiled, arial, Brushes.Black, col1D, 560);
            ev.Graphics.DrawString("Destruction Date: ", arial, Brushes.Black, col1, 580);
            ev.Graphics.DrawString(dateDestruction, arial, Brushes.Black, col1D, 580);
            ev.Graphics.DrawString("Status Notes:", arial, Brushes.Black, col1, 620);
            
            
            int sn = dtStatusNotes.Rows.Count;

            for (int i = 0; (i < sn & i < 10); i++)
            {
                ev.Graphics.DrawString(dtStatusNotes.Rows[i][0].ToString(), arial, Brushes.Black, col1, 620 + ((i + 1) * 20));
                ev.Graphics.DrawString(dtStatusNotes.Rows[i][1].ToString(), arial, Brushes.Black, col1D, 620 + ((i + 1) * 20));
            }
        }

        private void cbDateRequested_MouseClick(object sender, EventArgs e)
        {
            if (cbDateRequested.Checked)
            {
                dtpDateRequested.Visible = true;
            }
            else
            {
                dtpDateRequested.Visible = false;
            }
        }

        private void cbEffectiveDate_MouseClick(object sender, EventArgs e)
        {
            if (cbEffectiveDate.Checked)
            {
                dtpEffectiveDate.Visible = true;
            }
            else
            {
                dtpEffectiveDate.Visible = false;
            }
        }

        private void cbContractEnds_MouseClick(object sender, EventArgs e)
        {
            if (cbContractEnds.Checked)
            {
                dtpContractEnds.Visible = true;
            }
            else
            {
                dtpContractEnds.Visible = false;
            }
        }

        private void cbDateOriginalFiled_MouseClick(object sender, EventArgs e)
        {
            if (cbDateOriginalFiled.Checked)
            {
                dtpDateOriginalFiled.Visible = true;
            }
            else
            {
                dtpDateOriginalFiled.Visible = false;
            }
        }

        private void cbDestructionDate_MouseClick(object sender, EventArgs e)
        {
            if (cbDestructionDate.Checked)
            {
                dtpDestructionDate.Visible = true;
            }
            else
            {
                dtpDestructionDate.Visible = false;
            }
        }

        private void Bpdf_Click(object sender, EventArgs e)
        {
            SaveData();

            openFileDialog1.ShowDialog();
            string filePath = openFileDialog1.FileName;

            FileStream fs = new FileStream
                (filePath, FileMode.Open, FileAccess.Read);

            // store the file in an array the length of the file
            byte[] fileData = new byte[fs.Length];

            // read the file stream to the array
            fs.Read(fileData, 0, Convert.ToInt32(fs.Length));

            SqlConnection cnxn = new SqlConnection(g.db);
            SqlParameter prm1 = new SqlParameter
                ("@file", SqlDbType.Image, Convert.ToInt32(fs.Length));
            prm1.Value = fileData;

            SqlCommand cmd = new SqlCommand
                ("Update NDA set pdf = " + prm1 +
                 " , Storedpdf = 1 " +
                 " where NDA_ID = '" + g.NDA_ID + "' ");
            cmd.Parameters.Add(prm1);
            cmd.Connection = cnxn;
            cnxn.Open();
            cmd.ExecuteNonQuery();
            cnxn.Close();
            fs.Close();
            // close the file stream

            cnxn = new SqlConnection(g.db);
            cmd = new SqlCommand
                ("Select pdf from NDA " +
                 " where NDA_ID = '" + g.NDA_ID + "' ", cnxn);

            cnxn.Open();
            object o = cmd.ExecuteScalar();
            if (o != null)
            {
                DialogResult result;
                result = MessageBox.Show(" PDF created.");
            }
            cnxn.Close();

            string xtract = @"C:\Zygo\Xtracted.pdf";

            
             System.Diagnostics.Process pdfReader = new System.Diagnostics.Process();

             cnxn = new SqlConnection(g.db);

            cmd = new SqlCommand
                                ("Select pdf from NDA WHERE NDA_ID = " + g.NDA_ID + "", cnxn);
                            cmd.Connection = cnxn;
                            cnxn.Open();

                            SqlDataReader dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                // read in using GetValue and cast to byte array
                                byte[] xData = (byte[])dr.GetValue(0);

                                // write bytes to disk as file
                                FileStream fs1 = new FileStream
                                    (xtract, FileMode.Create, FileAccess.ReadWrite);
                                BinaryWriter bw = new BinaryWriter(fs1);
                                bw.Write(xData);
                                bw.Close();

                                pdfReader = System.Diagnostics.Process.Start(xtract);
                            }
                            dr.Close();
                            cnxn.Close();
                        
                        //wait for the external process to complete and then 
                        //delete the file which was writen to be able to read the pdf.
                        if (pdfReader.HasExited == true)
                        {
                            File.Delete(xtract);
                        }
        }

        private void cbddVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
             * 
             * if mouse click and selected index changed then set Copmany = name from vendor
             * and insert vendor number into database
             * 
             */

            if (vendor)
            {
                NAVcnxn = new SqlConnection(g.dbNAV);

                SqlCommand cmd = new SqlCommand(NAVvendor + cbddVendor.SelectedValue.ToString().Trim() + "%'", NAVcnxn);

                cmd.Connection = NAVcnxn;
                NAVcnxn.Open();

                try
                {
                    object o = cmd.ExecuteScalar();

                    vendorNo_ = cbddVendor.SelectedValue.ToString();

                    tbCompany.Text = o.ToString().Trim();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    NAVcnxn.Close();
                }
                
                customer = false;
                cbddCustomer.Text = "";
                customerNo_ = "";
            }
        }

        private void cbddCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
             * 
             * if mouse click and selected index changed then set Copmany = name from customer
             * and insert customer number into database
             * 
             */
            if (customer)
            {
                NAVcnxn = new SqlConnection(g.dbNAV);

                SqlCommand cmd = new SqlCommand(NAVcustomer + cbddCustomer.SelectedValue.ToString() + "%'", NAVcnxn);

                cmd.Connection = NAVcnxn;
                NAVcnxn.Open();
                object o = cmd.ExecuteScalar();
                tbCompany.Text = o.ToString().Trim();
                NAVcnxn.Close();
                customerNo_ = cbddCustomer.SelectedValue.ToString();
                
                vendor = false;
                cbddVendor.Text = "";
                vendorNo_ = "";
            }
        }

        private void cbddVendor_MouseClick(object sender, MouseEventArgs e)
        {
            vendor = true;
        }

        private void cbddCustomer_MouseClick(object sender, MouseEventArgs e)
        {
            customer = true;
        }
    }
}



