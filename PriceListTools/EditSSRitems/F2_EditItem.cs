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


namespace EditSSRitems
{
    public partial class F2_EditItem : Form
    {
        SqlConnection cnxn;
        SqlCommand cmd;
        private string SQL;
        
        public F2_EditItem()
        {
            InitializeComponent();
        }

        private void F2_EditItem_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.dbNAV);

            SqlCommand cmd = new SqlCommand(
                " select [Price List Code] + '  ' + [Price List Description] as prodGroup, [Price List Code], [Price List Description] from [ZYGO$Price List Data] " +
                " order by [Price List Code] ", cnxn);

            DataTable dt = new DataTable();
            SqlDataReader dr;


            try
            {
                cnxn.Open();
                cmd.CommandTimeout = 300;
                dr = cmd.ExecuteReader();
                dt.Load(dr);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            cbddPriceListCode.DataSource = dt;
            cbddPriceListCode.DisplayMember = "prodGroup";


            if (g.task != "ADD")
            {
                tbItemCode.Enabled = false;
                getData();   
            }
        }

        private void getData()
        {
            tbItemCode.Text = g.itemCode;
            tbSalesText.Text = g.salestext;
            cbddSalesPriceGroup.Text = g.salespricegroup;
            cbddPriceListCode.Text = g.pricelistcode;

            try
            {
                cnxn = new SqlConnection(g.db);
                cmd = new SqlCommand("SELECT sales_price_list, price FROM " +
                    "SSR_Product_List WHERE item_code = '" + g.itemCode + "'", cnxn);
                SqlDataReader dr;

                cnxn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    try
                    {
                        priceListChecker("tb" + dr.GetString(0).ToUpper().Trim(), "b" +
                            dr.GetString(0).ToUpper().Trim(), dr.GetInt32(1).ToString());

                    }
                    catch (Exception ex)
                    {
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
        }

        private void priceListChecker(string tBox, string btn, string price)
        {
            TextBox tb = this.Controls.Find(tBox, true).FirstOrDefault() as TextBox;
            if (tb != null)
            { tb.Text = price; }

            Button b = this.Controls.Find(btn, true).FirstOrDefault() as Button;
            if (b != null)
            {
                b.BackColor = Color.FromArgb(100, 180, 50);
            }
        }

        private void addPriceList(TextBox tbox)
        {
            bool on = false;

            if (g.task != "REMOVEITEM")
            {

                if (tbox.Text.Length < 1 && tbox.BackColor != Color.FromArgb(0, 250, 250))
                {
                    tbox.BackColor = Color.FromArgb(0, 250, 250);
                    tbox.Focus();
                    on = true;
                }

                if (tbox.BackColor == Color.FromArgb(0, 250, 250) && on == false)
                {
                    tbox.BackColor = Color.FromArgb(255, 255, 255);
                }
            }
            else
            {
                if (tbox.BackColor != Color.FromArgb(250, 250, 0))
                {
                    tbox.BackColor = Color.FromArgb(250, 250, 0);
                    tbox.Focus();
                    on = true;
                }

                if (tbox.BackColor == Color.FromArgb(250, 250, 0) && on == false)
                {
                    tbox.BackColor = Color.FromArgb(255, 255, 255);
                }
            }
        }

        private void listTextBoxes()
        {
            var t = this.Controls.OfType<TextBox>().AsEnumerable<TextBox>();
            foreach (TextBox item in t)
            {

                if (item.Text.Length < 1)
                {
                    if (item.BackColor == Color.FromArgb(0, 250, 250))
                    {
                        MessageBox.Show("Text box " + item.Name + " has no entry. \n\nEither enter data or unselect.");
                        item.Focus();
                        return;
                    }
                }
                else if (item.Name.Length < 6)
                {
                    SqlParameter pSalesPriceList = new SqlParameter
                                    ("@SalesPriceList", SqlDbType.NChar);
                    pSalesPriceList.Value = item.Name.Substring(2, 3);

                    SqlParameter pItemCode = new SqlParameter
                                ("@ItemCode", SqlDbType.NChar);
                    pItemCode.Value = tbItemCode.Text.Trim();

                    SqlParameter pSalesText = new SqlParameter
                                ("@SalesText", SqlDbType.NChar);
                    pSalesText.Value = tbSalesText.Text.Trim();

                    SqlParameter pSalesPriceGroup = new SqlParameter
                                ("@SalesPriceGroup", SqlDbType.NChar);
                    pSalesPriceGroup.Value = cbddSalesPriceGroup.Text;

                    SqlParameter pPrice = new SqlParameter
                                ("@Price", SqlDbType.NChar);
                    pPrice.Value = item.Text;

                    SqlParameter pPriceListCode = new SqlParameter("@PriceListCode", SqlDbType.NChar);
                    SqlParameter pPriceListDescription = new SqlParameter("@PriceListDescription", SqlDbType.NChar);

                    if (cbddPriceListCode.Text.IndexOf(" ") > -1)
                    {
                        pPriceListCode.Value = cbddPriceListCode.Text.Substring(0, cbddPriceListCode.Text.IndexOf(" "));
                        pPriceListDescription.Value = cbddPriceListCode.Text.Substring(cbddPriceListCode.Text.IndexOf(" ") + 2, cbddPriceListCode.Text.Length - (cbddPriceListCode.Text.IndexOf(" ") + 2));
                    }
                    else
                    {
                        pPriceListCode.Value = g.pricelistcode;
                        pPriceListDescription.Value = g.pricelistdescription;
                    }
                    
                    if (item.BackColor == Color.FromArgb(0, 250, 250))
                    {
                        SQL = "Insert into SSR_Product_List (" +
                                " [sales_price_list] " +
                                ",[item_code] " +
                                ",[sales_text] " +
                                ",[sales_price_group] " +
                                ",[price] " +
                                ",[Price List Code] " +
                                ",[Price List Description] " +
                                ",expiry_date " +
                                ") values (" +
                                pSalesPriceList + "," +
                                pItemCode + "," +
                                pSalesText + "," +
                                pSalesPriceGroup + "," +
                                pPrice + "," +
                                pPriceListCode + "," +
                                pPriceListDescription +
                                ",'2049-12-31' )";


                        
                    }     /* end new entry  */
                    else if (g.task =="EDIT")  /* edit existing  */
                    {
                            SQL = "UPDATE SSR_Product_List SET " +
                                    "[sales_text] =" + pSalesText +
                                    ",[sales_price_group] =" + pSalesPriceGroup +
                                    ",[price] =" + pPrice +
                                    ",[Price List Code] =" + pPriceListCode +
                                    ",[Price List Description] =" + pPriceListDescription +
                                    " WHERE item_code = '" + g.itemCode + "' " +
                                    "AND sales_price_List = " + pSalesPriceList;
                    }
                    else if (item.BackColor == Color.FromArgb(250, 250, 0))
                    {   /*  remove price list from item    */

                        SQL = "DELETE FROM SSR_Product_List  " +
                              " WHERE item_code = '" + g.itemCode + "' " +
                              "AND sales_price_List = " + pSalesPriceList;
                    }


                    if (string.IsNullOrEmpty(SQL))
                    {

                    }
                    else
                    {
                        cnxn = new SqlConnection(g.db);
                        cmd = new SqlCommand();
                        cmd.CommandText = SQL;
                        cmd.Connection = cnxn;

                        cmd.Parameters.Add(pSalesPriceList);
                        cmd.Parameters.Add(pItemCode);
                        cmd.Parameters.Add(pSalesText);
                        cmd.Parameters.Add(pSalesPriceGroup);
                        cmd.Parameters.Add(pPrice);
                        cmd.Parameters.Add(pPriceListCode);
                        cmd.Parameters.Add(pPriceListDescription);
                    }


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
                            item.BackColor = Color.FromArgb(255, 255, 255);
                            SQL = string.Empty;

                            if (g.task == "ADD")
                            {
                                /* loop though text boxes and empty   */
                                var tb = this.Controls.OfType<TextBox>().AsEnumerable<TextBox>();
                                foreach (TextBox bx in tb)
                                {

                                    if (bx.Text.Length > 0)
                                    {
                                        bx.Text = string.Empty;
                                        cbddSalesPriceGroup.Text = string.Empty;
                                        cbddPriceListCode.Text = string.Empty;
                                    }
                                }
                            }
                        }
                    }

                }   /*  text box length    */






               /*  for each text box loop    */

            if (g.task == "EDIT" | g.task == "REMOVEITEM")
            {
                this.Close();
            }
        }

        private void bCAN_Click(object sender, EventArgs e)
        {
            addPriceList(tbCAN);
        }

        private void bCFQ_Click(object sender, EventArgs e)
        {
            addPriceList(tbCFQ);
        }

        private void bCOE_Click(object sender, EventArgs e)
        {
            addPriceList(tbCOE);
        }

        private void bDIS_Click(object sender, EventArgs e)
        {
            addPriceList(tbDIS);
        }

        private void bDOM_Click(object sender, EventArgs e)
        {
            addPriceList(tbDOM);
        }

        private void bEUR_Click(object sender, EventArgs e)
        {
            addPriceList(tbEUR);
        }

        private void bEXP_Click(object sender, EventArgs e)
        {
            addPriceList(tbEXP);
        }

        private void bINT_Click(object sender, EventArgs e)
        {
            addPriceList(tbINT);
        }

        private void bZAF_Click(object sender, EventArgs e)
        {
            addPriceList(tbZAF);
        }

        private void bZCV_Click(object sender, EventArgs e)
        {
            addPriceList(tbZCV);
        }

        private void bZJV_Click(object sender, EventArgs e)
        {
            addPriceList(tbZJV);
        }

        private void bZKK_Click(object sender, EventArgs e)
        {
            addPriceList(tbZKK);
        }

        private void bZKO_Click(object sender, EventArgs e)
        {
            addPriceList(tbZKO);
        }

        private void bEnterData_Click(object sender, EventArgs e)
        {
            if (g.task == "ADD")
            {
                if (tbItemCode.Text.Length < 1)
                {
                    MessageBox.Show("Text box Item Code has no entry. \n\nMust enter data.");
                    tbItemCode.Focus();
                    return;
                }

                if (tbSalesText.Text.Length < 1)
                {
                    MessageBox.Show("Text box Sales Text has no entry. \n\nMust enter data.");
                    tbSalesText.Focus();
                    return;
                }

                if (cbddSalesPriceGroup.Text.Length < 1)
                {
                    MessageBox.Show("Text box Sales Price Group has no entry. \n\nMust select data.");
                    cbddSalesPriceGroup.Focus();
                    return;
                }

                if (cbddPriceListCode.Text.Length < 1)
                {
                    MessageBox.Show("Text box Price List Code has no entry. \n\nMust select data.");
                    cbddPriceListCode.Focus();
                    return;
                }

                tbDOM.BackColor = Color.FromArgb(0, 250, 250);

                listTextBoxes();
            }
            else if (g.task == "REMOVEITEM")
            {
                listTextBoxes();
            }
            else
            {
                listTextBoxes();
            }

            //this.Close();
        }

        private void bRemoveItemFromPriceList_Click(object sender, EventArgs e)
        {
            g.task = "REMOVEITEM";
            this.BackColor = Color.FromArgb(0, 180, 180);
            bEnterData.Text = "REMOVE DATA";
        }

    }
}
