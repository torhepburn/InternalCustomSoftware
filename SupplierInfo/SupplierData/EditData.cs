using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SupplierData
{
    public partial class EditData : Form
    {
        SqlDataReader dr;
        SqlConnection cnxn;
        SqlCommand cmd;

        DataTable dt;

        public EditData()
        {
            InitializeComponent();
        }

        private void EditData_Load(object sender, EventArgs e)
        {   
            WindowState = FormWindowState.Maximized;

            dt = new DataTable();

            cnxn = new SqlConnection(g.db);

            cmd = new SqlCommand(
                "SELECT " +
                " CAST(DateEntered as varchar(10))" +   /*     0     */
                ",TRIM(Name) " +
                ",[Overall Supplier Rating] " +
                ",[Quality Rating] " +
                ",[OTD Rating] " +
                ",[Payment Terms] " +               /*  5   */
                ",[Annual Spend Actual] " +
                ",[Annual Spend Projected] " +
                ",[Location/Region] " +
                ",COALESCE([Commodity 1],' ') " +
                ",COALESCE([Commodity 2],' ') " +   /*  10  */
                ",TRIM([Vendor Title])  " +
                ",CAST(SupplierNo as nchar(30)) " + /*  12  */
                ",TRIM([Purchaser Code])  " +
                ",[NDA Expiration Date] " +
                ",[ISO 9001 Exp Date] " +           /*  15  */
                ",[ISO 13485 Exp Date] " +
                ",[AS9100 Exp Date] " +
                ",[Alternate Suppliers] " +
                ",[Parent Company Name] " +
                ",[Parent Company Location] " +     /*  20  */
                ",[Headquarters Location] " +
                ",[Factory Locations] " +
                ",[Technology (Expertise)] " +
                ",[Number of Critical Parts] " +
                ",[Strategy] " +                        /*  25  */
                ",[Key Actions/Current Issues] " +
                ",[Cost Savings Plan] " +
                ",[Cost Savings Status] " +
                ",[Business Alignment] " +
                ",[Contracts Type] " +                  /*  30  */
                ",[Per Cent of Coverage] " +
                ",[Type Status] " +
                ",[Line of Business] " +
                ",[Payment Terms Plan] " +
                ",[Lead Time Plan] " +                  /*  35  */
                ",[Lead Time Range] " +
                ",[Notes] " +
                " from [SupplierData] " +
                 "where " +
                 "supplierNo = '" + g.supplierNo + "' ", cnxn);


            try
            {
                cnxn.Open();
                dr = cmd.ExecuteReader();

                dt.Load(dr);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    try
                    {
                        ////g.enteredOn = dr.GetString(0);
                        g.supplierName = dr.GetString(1);
                        g.supplierRating = dr.GetString(2).Trim();
                        g.qualityRating = dr.GetString(3).Trim();
                        g.otdRating = dr.GetString(4).Trim();
                        g.paymentTerms = dr.GetString(5).Trim();
                        //g.annualspendActual = dr.GetInt32(6).ToString().Trim();
                        //g.annualspendProjected = dr.GetInt32(7).ToString().Trim();
                        g.locationRegion = dr.GetString(8).Trim();
                        g.commodity1 = dr.GetString(9).Trim();
                        g.commodity2 = dr.GetString(10).Trim();
                        g.vendorTitle = dr.GetString(11).Trim();
                        g.supplierNo = dr.GetString(12).Trim();
                        if (!dr.IsDBNull(13))
                        {
                            g.buyer = dr.GetString(13).Trim();
                        }
                        if (!dr.IsDBNull(14))
                        {
                            g.ndaExpirationDate = dr.GetFieldValue<DateOnly>(14);
                        }
                        if (!dr.IsDBNull(15))
                        {
                            g.ISO9001ExpirationDate = dr.GetFieldValue<DateOnly>(15);
                        }
                        if (!dr.IsDBNull(16))
                        {
                            g.ISO13485ExpirationDate = dr.GetFieldValue<DateOnly>(16);
                        }
                        if (!dr.IsDBNull(17))
                        {
                            g.AS9100ExpirationDate = dr.GetFieldValue<DateOnly>(17);
                        }
                        if (!dr.IsDBNull(18))
                        {
                            g.alternateSuppliers = dr.GetString(18).Trim();
                        }
                        if (!dr.IsDBNull(19))
                        {
                            g.parentCompanyName = dr.GetString(19).Trim();
                        }
                        if (!dr.IsDBNull(20))
                        {
                            g.parentCompanyLocation = dr.GetString(20).Trim();
                        }
                        if (!dr.IsDBNull(21))
                        {
                            g.headquartersLocation = dr.GetString(21).Trim();
                        }
                        if (!dr.IsDBNull(22))
                        {
                            g.factoryLocations = dr.GetString(22).Trim();
                        }
                        if (!dr.IsDBNull(23))
                        {
                            g.technology = dr.GetString(23).Trim();
                        }
                        if (!dr.IsDBNull(24))
                        {
                            g.numberCriticalParts = dr.GetInt32(24).ToString().Trim();
                        }
                        if (!dr.IsDBNull(25))
                        {
                            g.strategy = dr.GetString(25).Trim();
                        }
                        if (!dr.IsDBNull(26))
                        {
                            g.issues = dr.GetString(26).Trim();
                        }
                        if (!dr.IsDBNull(27))
                        {
                            g.costSavingsPlan = dr.GetString(27).Trim();
                        }
                        if (!dr.IsDBNull(28))
                        {
                            g.costSavingsStatus = dr.GetString(28).Trim();
                        }
                        if (!dr.IsDBNull(29))
                        {
                            g.businessAlignment = dr.GetString(29).Trim();
                        }
                        if (!dr.IsDBNull(30))
                        {
                            g.contractsType = dr.GetString(30).Trim();
                        }
                        if (!dr.IsDBNull(31))
                        {
                            g.percentOfCoverage = dr.GetDecimal(31).ToString().Trim();
                        }
                        if (!dr.IsDBNull(32))
                        {
                            g.typeStatus = dr.GetString(32).Trim();
                        }
                        if (!dr.IsDBNull(33))
                        {
                            g.lineofBusiness = dr.GetString(33).Trim();
                        }
                        if (!dr.IsDBNull(34))
                        {
                            g.paymentTermsPlan = dr.GetString(34).Trim();
                        }
                        if (!dr.IsDBNull(35))
                        {
                            g.leadTimePlan = dr.GetString(35).Trim();
                        }
                        if (!dr.IsDBNull(36))
                        {
                            g.leadTimeRange = dr.GetString(36).Trim();
                        }
                        if (!dr.IsDBNull(37))
                        {
                            g.notes = dr.GetString(37).Trim();
                        }
                    }
                    catch (Exception ex)
                    {
                        //        //pop.Title = "Error";
                        //        //pop.Message = ex.ToString();
                        //        //pop.ShowPopup();
                        MessageBox.Show(ex.ToString());

                    }
                    finally
                    {

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



            lSupplier.Text = "Supplier Name: " + g.supplierName;
            lSupplierNo.Text = "Supplier Number:  " + g.supplierNo;
            lBuyer.Text = "Buyer:  " + g.buyer;
            lCommodity1.Text = "Commodity 1:  " + g.commodity1;
            lCommodity2.Text = "Commodity 2: " + g.commodity2;
            lVendorTitle.Text = "Vendor Title" + g.vendorTitle;


            tbParentCompanyName.Text = g.parentCompanyName;
            tbParentCompanyLocation.Text = g.parentCompanyLocation;
            tbHedquartersLocation.Text = g.headquartersLocation;
            tbFactoryLocations.Text = g.factoryLocations;
            tbTechnology.Text = g.technology;
            tbPaymentTermsPlan.Text = g.paymentTermsPlan;
            tbCostSavingsPlan.Text = g.costSavingsPlan;
            tbNotes.Text = g.notes;
            tbStrategy.Text = g.strategy;
            tbIssues.Text = g.issues;
            tbPercentOfCoverage.Text = g.percentOfCoverage;
            tbLeadTimePlan.Text = g.leadTimePlan;

            tbSupplierRating.Text = g.supplierRating;
            tbQualityRating.Text = g.qualityRating;
            tbOTDRating.Text = g.otdRating;
            tbPaymentTerms.Text = g.paymentTerms;

            tbZM0027Expiration.Text = g.ZM0027ExpirationDate.ToShortDateString();
            tbNDAExpiration.Text = g.ndaExpirationDate.ToShortDateString();
            tbISO9001Expiration.Text = g.ISO9001ExpirationDate.ToShortDateString();
            tbISO13485Expiration.Text = g.ISO13485ExpirationDate.ToShortDateString();
        }

        private void bSave_Click_1(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);

            cmd = new SqlCommand("UPDATE SupplierDataBank " +
                    "SET " +
                    " [Parent Company Name] = '" + tbParentCompanyName.Text.Trim() + "'" +
                    ",[Parent Company Location] = '" + tbParentCompanyLocation.Text.Trim() + "'" +
                    ",[Headquarters Location] = '" + tbHedquartersLocation.Text.Trim() + "'" +
                    ",[Factory Locations] = '" + tbFactoryLocations.Text.Trim() + "'" +
                    ",[Technology (Expertise)] = '" + tbTechnology.Text.Trim() + "'" +
                    ",[Payment Terms Plan] = '" + tbPaymentTermsPlan.Text.Trim() + "'" +
                    ",[Cost Savings Plan] = '" + tbCostSavingsPlan.Text.Trim() + "'" +
                    ",[Notes] = '" + tbNotes.Text.Trim() + "'" +
                    ",[Strategy] = '" + tbStrategy.Text.Trim() + "'" +                       
                    ",[Key Actions/Current Issues] = '" + tbIssues.Text.Trim() + "'" +
                    ",[Per Cent of Coverage] = '" + tbPercentOfCoverage.Text.Trim() + "'" +
                    ",[Lead Time Plan] = '" + tbLeadTimePlan.Text.Trim() + "'" +                  
        
            ////",[Cost Savings Status] " +
            ////",[Business Alignment] " +
            ////",[Contracts Type] " +                  /*  30  */
            ////",[Type Status] " +
            ////",[Line of Business] " +

            ////",[Lead Time Range] " +


            " where SupplierNo = '" + g.supplierNo + "'", cnxn);

            try
            {
                cnxn.Open();

                int success = cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
               ClearVariables();
                cnxn.Close();
            }

            this.Close();
        }

        private void ClearVariables()
        {
            g.supplierName = string.Empty;

            g.parentCompanyName = string.Empty;
            g.parentCompanyLocation = string.Empty;
            g.headquartersLocation = string.Empty;
            g.factoryLocations = string.Empty;
            g.technology = string.Empty;
            g.paymentTermsPlan = string.Empty;
            g.costSavingsPlan = string.Empty;
            g.notes = string.Empty;
            g.strategy = string.Empty;
            g.issues = string.Empty;
            g.percentOfCoverage = string.Empty;
            g.leadTimePlan = string.Empty;


            g.supplierRating = string.Empty;
            g.qualityRating = string.Empty;
            g.otdRating = string.Empty;
            g.paymentTerms = string.Empty;
            //g.annualspendActual = dr.GetInt32(6).ToString().Trim();
            //g.annualspendProjected = dr.GetInt32(7).ToString().Trim();
            g.locationRegion = string.Empty;
            g.commodity1 = string.Empty;
            g.commodity2 = string.Empty;
            g.vendorTitle = string.Empty;
            g.supplierNo = string.Empty;
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            ClearVariables();
            this.Close();
        }
    }
}
