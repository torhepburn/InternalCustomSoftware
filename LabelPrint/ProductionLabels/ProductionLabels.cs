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
using System.Runtime.InteropServices;

namespace ProductionLabels
{
    public partial class ProductionLabels : Form
    {
        private string line1;
        private string line2;
        private string line3;
        private string labelQuantity;
        private string quantityPerLabel;
        private int firstLastIndex;
        private int secondLastIndex;
        private bool standard = false;
        private bool custom = false;
        private bool printCheckQty = false;
        private bool multiLevel = false;
        private string iDescription;
        private string dbMID = "user=readWrite; password=Read+Write!; " +
                    "server=CT-MID-SQL11; database=AccessFrontEnds;";
        public static string dbNAV = "server = pa-hor-as408.ametek.com; password = 2018#ameteK; " +
                            "user = navdb_read; database = ZYGO-NAV-PROD;";
        private string NAVprefix = "ZYGO$";
        private string query = string.Empty;
        private string parent = string.Empty;
        private string printer = string.Empty;
        private string lineNo;
        private string reference;

        SqlConnection cnxn;
        SqlConnection cnxnInsideLoop;
        SqlDataReader dr;
        SqlDataReader drMulti;
        DataTable dtLines;
        SqlCommand cmd;

        public ProductionLabels()
        {
            InitializeComponent();
        }

        private void ProductionLabels_Load(object sender, EventArgs e)
        {
            System.Security.Principal.WindowsIdentity userBase;
            userBase = System.Security.Principal.WindowsIdentity.GetCurrent();

            string user = userBase.Name.ToUpper(); ;

            if (userBase.Name.IndexOf("Z") == 0)
            {
                user = userBase.Name.Replace("ZYGOMIS\\", "");
            }
            else
            {
                user = userBase.Name.Replace("AMETEK-AD\\", "");
            }

            string computername = Environment.MachineName;

            SqlConnection cnxn = new SqlConnection(dbMID);

            try
            {
                cmd = new SqlCommand(
                 " Select permission, permissionvalue from applicationsetup " +
                 " where application = 'PRODUCTION LABELS' and " +
                 " pcid = '" + computername + "' " +
                 " order by permission desc ", cnxn);
                DataTable table = new DataTable();

                cnxn.Open();
                                
                dr = cmd.ExecuteReader();
                table.Load(dr);


                if (table.Rows.Count > 0)
                {
                    printer = table.Rows[0][1].ToString().Trim();
                }
                else
                {
                    MessageBox.Show("Either this user " + user + " or this computer (" + computername + ") does not have permission to use this program: PRODUCTION LABELS.");
                    this.Close();
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


            this.Text = "Production Order Labels for " + NAVprefix + "  v" + Application.ProductVersion;

            tbProductionOrder.AppendText("PD");

            /*
            this.BackColor = Color.FromArgb(80, 100, 220); /*       MK      *//*
            label2.Visible = false; 
            */
            //this.BackColor = Color.FromArgb(220, 100, 80);  //NAV
        }

        private void button1_Click(object sender, EventArgs e)  //Print button
        {
            tbProductionOrder.Text = tbProductionOrder.Text.ToUpper().ToString();

            if (cbAll.Checked == false)
            {
                Bprint.Visible = false;
            }

            if (cbReference.Checked == false)
            {
                reference = "WHERE (Substring(c.[Description],1, 1) != '#' AND Substring(c.[Description],1, 1) != '&') ";
            }
            else
            {
                reference = "WHERE (Substring(c.[Description],1, 1) != '&') ";
            }

            /*  This is the selection query for the label 
             *  
             *  It is defined here but not used until the 300s 
             *  where there is a lot of conditional coding going on
             *
             */

            query = "SELECT " +
                    " c.[Item No_] " +
                    ",c.[Description] " +
                    ",c.[Prod_ Order No_] " +
                    ",c.[Position] " +
                    ",c.[Bin Code] " +
                    ",cast(c.[Expected Quantity] as decimal(11,2)) " +
                    ",c.[Routing Link Code] " +
                    ",CAST(COALESCE(c.[Prod_ Order Line No_],0) as varchar(6)) " +
                    "FROM " +
                    "[ZYGO$Prod_ Order Component] c " +
                    "INNER JOIN [ZYGO$Item] i " + 
                    "ON c.[Item No_] = i.No_ " +
                    reference +
                    "AND [Prod_ Order No_] = '" + tbProductionOrder.Text + "' ";

            prodorderChoices(); 

            //tbProductionOrder.Text = string.Empty;
            tbProductionOrder.Focus();
            //this.Close();
        }

        private void prodorderChoices()
        {
            cnxn = new SqlConnection(dbNAV);

            if (tbProductionOrder.Text.Length > 8)
            {
                /*  if the number is no good then display a message to that effect  */

                MessageBox.Show("Must enter a valid production order number.");
                tbProductionOrder.Focus();
                return;
            }
            else
            {
                /*  execute scalar will return one field with one value   */

                SqlCommand cmd = new SqlCommand("SELECT [Prod_ Order No_] FROM [ZYGO$Prod_ Order Component] " +
                        "WHERE [Prod_ Order No_] = '" + tbProductionOrder.Text + "'", cnxn);
                cnxn.Open();
                object o = cmd.ExecuteScalar();
                cnxn.Close();

                if (o == null)
                {
                    MessageBox.Show("Order Number not available or mistyped");
                }
                else    //order number is valid
                {
                    /* check to see if multi-line  */
                    
                    cmd = new SqlCommand("SELECT " +
                        "[Prod_ Order Line No_] [Line] " +
                        "FROM [ZYGO$Prod_ Order Component] " +
                        "WHERE [Prod_ Order No_] = '" + tbProductionOrder.Text + "' " +
                        "GROUP BY [Prod_ Order Line No_] " +
                        "ORDER BY [Prod_ Order Line No_]"
                        , cnxn);

                    try
                    {
                        cnxn.Open();
                        dr = cmd.ExecuteReader();
                        dtLines = new DataTable();
                        dtLines.Load(dr);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        cnxn.Close();
                    }

                    if (dtLines.Rows.Count > 1)
                    {
                        multiLevel = true;
                    }

                    /*  if print all lines not checked and multi-line bom then allow choice of lines. 
                     *  dtLines will always have at least one line
                     */

                    if (cbAll.Checked == false & multiLevel)
                    {
                        DGV.DataSource = dtLines;
                        DGV.Visible = true;
                        DGV.Focus();
                        return;
                    }
                    else
                    {
                        commonLabelProcessing();
                    }
                }
            }
        }


        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 )
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                lineNo = cell.EditedFormattedValue.ToString().Trim();

                if (cbAll.Checked)
                {
                    
                }
                else
                {
                    query = query + " AND [Prod_ Order Line No_] = " + lineNo + " ";
                }
                
                bPrintSelectedLine.Visible = true;
            }
        }

        private void commonLabelProcessing()
        {
            /*
                     *      Determine if standard and custom items are present
                     *      standard = vetted = 0
                     *      custom = vetted = 1
                     *
                     */

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                 " SELECT DISTINCT Vetted FROM " +
                 " [ZYGO$Item] i " +
                 "INNER JOIN [ZYGO$Prod_ Order Component] c " +
                 "ON i.No_ = c.[Item No_] " +
                 " WHERE [Prod_ Order No_] = '" +
                   tbProductionOrder.Text + "' ORDER BY " +
                 " Vetted", cnxn);
                DataTable table = new DataTable();
                da.Fill(table);

                /*  NAV vetted and non-vetted    */

                if (table.Rows.Count > 0)
                {
                    if (table.Rows.Count > 1)
                    {
                        if (table.Rows[1][0].ToString().Trim() == "0")
                        {
                            standard = true;
                        }

                        if (table.Rows[1][0].ToString().Trim() == "1")
                        {
                            custom = true;
                        }
                    }
                    if (table.Rows[0][0].ToString().Trim() == "0")
                    {
                        standard = true;
                    }

                    if (table.Rows[0][0].ToString().Trim() == "1")
                    {
                        custom = true;
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

            if (standard & custom)
            {
                DialogResult result1 = MessageBox.Show("Do you want to print the STANDARD labels ?", "",
                    MessageBoxButtons.YesNo);

                if (result1 == DialogResult.Yes)
                {
                    standard = true;
                }
                else
                {
                    standard = false;
                }

                DialogResult result2 = MessageBox.Show("Do you want to print the CUSTOM labels ?", "",
                    MessageBoxButtons.YesNo);

                if (result2 == DialogResult.Yes)
                {
                    custom = true;
                }
                else
                {
                    custom = false;
                }
            }

            /*  check to see if multilevel BOM */

            /*  need parent first from Production Order just in case    */

            cmd = new SqlCommand("SELECT [Source No_] FROM " +
                    "[ZYGO$Production Order] where No_ = '" + tbProductionOrder.Text + "'", cnxn);
            try
            {
                cnxn.Open();
                parent = (string)cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            /*  the parent item will have components with
             *  a Prod_ Order Line No_ of 10000 - always
             *  so to get it into the table we just add
             *  it at the end.
             *  
             *  The Item Low-Level Code > 0 will give the
             *  sub-assembies
             *  
             *  Looking to get the item number and description to
             *  print on the header labels for the work order
             *  
             *  */

            if (cbAll.Checked)
            {
                cmd = new SqlCommand("SELECT  " +
                 "[Item No_]" +
                 ",[Supplied-by Line No_] " +
                ",CAST([Supplied-by Line No_] as varchar(10)) " +
                "FROM [ZYGO$Prod_ Order Component] " +
                "WHERE [Prod_ Order No_] = '" +
                  tbProductionOrder.Text + "' " +
                "AND [Item Low-Level Code] > 0 " +
                "UNION " +
                "SELECT " +
                "'" + parent + "', 10000, '' " +
                "ORDER BY [Supplied-by Line No_]", cnxn);
            }
            else
            {
                if (lineNo == "10000")
                {
                    cmd = new SqlCommand("SELECT  " +
                     "[Source No_]" +
                     ",10000 " +
                    ",'10000' " +
                    "FROM [ZYGO$Production Order] " +
                    "WHERE [No_] = '" +
                      tbProductionOrder.Text + "' "
                    , cnxn);
                }
                else
                {
                    cmd = new SqlCommand("SELECT  " +
                     "[Item No_]" +
                     ",[Supplied-by Line No_] " +
                    ",CAST([Supplied-by Line No_] as varchar(10)) " +
                    "FROM [ZYGO$Prod_ Order Component] " +
                    "WHERE [Prod_ Order No_] = '" +
                      tbProductionOrder.Text + "' " +
                    "AND [Supplied-by Line No_] = " + lineNo + " " +
                    "AND [Item Low-Level Code] > 0 " +
                    "ORDER BY [Supplied-by Line No_]", cnxn);
                }
            }

            

            try
            {   
                if (multiLevel)
                {
                    DataTable test = new DataTable();
                    cnxn.Open();
                    drMulti = cmd.ExecuteReader();
                    test.Load(drMulti);

                    drMulti = cmd.ExecuteReader();

                    while (drMulti.Read())
                    {
                        //MLprinted = false;

                        string str = string.Empty;
                        str = "\nN\nq609Q203,20\n";
                        str += "A50,20,0,3,1,1,N,\"** SUB ASSEMBLY **\"\n";
                        str += "A50,80,0,3,1,1,N,\"SUB:" + drMulti.GetString(0).ToString() + "\"\n";
                        str += "A50,140,0,3,1,1,N,\"Line No:" + drMulti.GetString(2).ToString() + "\"\n";
                        str += "P" + labelQuantity + "\n";
                        //RawPrinterHelper.SendStringToPrinter(printer, str);

                        cnxnInsideLoop = new SqlConnection(dbNAV);

                        /*  the inside loop gets the components of the sub-assemblies as
                         *  well as the top level non-sub-assembly components
                         */

                        cmd = new SqlCommand(
                            "SELECT  " +
                             " [Item No_] " +
                            ",[Description] " +
                            ",[Prod_ Order No_] " +
                            ",[Position] " +
                            ",[Bin Code] " +
                            ",cast([Expected Quantity] as decimal(11,2)) " +
                            ",[Routing Link Code] " +
                            ",CAST([Prod_ Order Line No_] as varchar(6)) " +
                            "FROM " +
                            "[ZYGO$Prod_ Order Component] " +
                            "WHERE (Substring([Description],1, 1) != '#' AND Substring([Description],1, 1) != '&') " +
                            "AND [Prod_ Order No_] = '" + tbProductionOrder.Text + "' " +
                            "AND [Prod_ Order Line No_] = " +
                            drMulti.GetInt32(1) + " " +

                            "ORDER BY [Bin Code], [Item No_]", cnxnInsideLoop);

                        try
                        {
                            cnxnInsideLoop.Open();
                            dr = cmd.ExecuteReader();
                            DataTable tst = new DataTable();
                            tst.Load(dr);
                            dr = cmd.ExecuteReader();
                            QtyGreaterThan1();

                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        finally
                        {
                            cnxnInsideLoop.Close();
                        }
                    }
                }
                else
                {
                    if (standard)
                    {
                        try
                        {
                            cmd = new SqlCommand(query + "AND i.Vetted = 0 " +
                                  "ORDER BY [Bin Code], [Item No_]", cnxn);

                            cmd.Connection = cnxn;
                            if (cnxn.State == ConnectionState.Closed)
                            {
                                cnxn.Open();
                            }

                            dr = cmd.ExecuteReader();

                            DataTable t = new DataTable();
                            t.Load(dr);

                            dr = cmd.ExecuteReader();

                            QtyGreaterThan1();
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


                    if (custom)
                    {
                        try
                        {
                            cmd = new SqlCommand(query + "AND i.Vetted = 1 " +
                               "ORDER BY [Bin Code], [Item No_]", cnxn);

                            cmd.Connection = cnxn;

                            if (cnxn.State == ConnectionState.Closed)
                            {
                                cnxn.Open();
                            }

                            dr = cmd.ExecuteReader();

                            DataTable t = new DataTable();
                            t.Load(dr);

                            dr = cmd.ExecuteReader();

                            QtyGreaterThan1();
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

            Bprint.Visible = true;
            DGV.Visible = false;
            bPrintSelectedLine.Visible = false;
            cbAll.Checked = true;
            tbProductionOrder.Text = "";
            tbProductionOrder.AppendText("PD");
        }


        private void QtyGreaterThan1()
        {
            while (dr.Read())
            {
                iDescription = dr.GetString(1).ToString();

                parseDescription();

                printCheckQty = false;

                if (dr.GetDecimal(5) > 1)
                {
                    printCheckQty = true;
                    //check bulk pack
                    BulkPack(dr.GetString(0), dr.GetString(1), dr.GetDecimal(5));
                }
                else if (dr.GetDecimal(5) < 0 )
                {
                    labelQuantity = "1";
                    quantityPerLabel = dr.GetDecimal(5).ToString(); 
                }
                else
                {
                    labelQuantity = "1";
                    quantityPerLabel = "1";
                }

                printLabels();
            }
        }

        
        private void printLabels()
        {
            /*  fordebugging write the data to the hard drive   */
            //if (multiLevel & !(MLprinted))
            //{
            //    File.AppendAllText(auditFile, "SUB" + Environment.NewLine);
            //    File.AppendAllText(auditFile, drMulti.GetString(0).ToString() + Environment.NewLine);
            //    File.AppendAllText(auditFile, "++++++++++" + Environment.NewLine);
            //    MLprinted = true;
            //    /* reset the audit count to 1 as it counts the items per each sub assembly
            //     * see the two lines below
            //     * */
            //    auditCount = 1;
            //}

            //File.AppendAllText(auditFile, auditCount.ToString() + "   ");
            //File.AppendAllText(auditFile, dr.GetString(0).ToString() + Environment.NewLine);


            //File.AppendAllText(@"C:\a\prodord.txt", line1 + Environment.NewLine);
            //File.AppendAllText(@"C:\a\prodord.txt", line2 + Environment.NewLine);
            //File.AppendAllText(@"C:\a\prodord.txt", line3 + Environment.NewLine);
            //File.AppendAllText(@"C:\a\prodord.txt", dr.GetString(2).ToString() + Environment.NewLine);
            //File.AppendAllText(@"C:\a\prodord.txt", dr.GetString(3).ToString() + Environment.NewLine);
            //File.AppendAllText(@"C:\a\prodord.txt", dr.GetString(4) + Environment.NewLine);
            //File.AppendAllText(@"C:\a\prodord.txt", dr.GetString(6).ToString() + Environment.NewLine);
            //File.AppendAllText(@"C:\a\prodord.txt", "labelQuantity:  ");
            //File.AppendAllText(@"C:\a\prodord.txt", labelQuantity + Environment.NewLine);
            //File.AppendAllText(@"C:\a\prodord.txt", "Quantity per Label:  ");
            //File.AppendAllText(@"C:\a\prodord.txt", quantityPerLabel + Environment.NewLine);
            //auditCount++;

            string str = string.Empty;
            
            Bitmap bzp = Properties.Resources.zygo_blk_noR_132;
            Bitmap bxp = Properties.Resources.ametek_blk_noR_132;
            str = string.Empty;
           
           
            //string printer = "ZDesigner GK420d";

            str = "\nN\nq609Q203,20\n";
            str += SendImageToPrinter(20, 10, bzp);
            str += SendImageToPrinter(450, 10, bxp);

            if (printCheckQty)
            {
                str += "A150,20,0,3,1,1,N,\"** CHECK QUANTITY **\"\n";
            }

            str += "A10,60,0,2,1,1,N,\"PN#\"\n";
            str += "B50,55,0,1,2,4,32,B,\"" + dr.GetString(0).ToString() + "\"\n";
            str += "A400,60,0,2,1,1,N,\"" + line1 + "\"\n";
            str += "A400,80,0,2,1,1,N,\"" + line2 + "\"\n";
            str += "A400,100,0,2,1,1,N,\"" + line3 + "\"\n";

            str += "A10,130,0,2,1,1,N,\"OR#\"\n";

            string dropPD = dr.GetString(2).Replace("PD", "");
            str += "B50,125,0,1,2,4,32,B,\"" + dropPD + "\"\n";

            str += "A220,125,0,2,1,1,N,\"POS:" + dr.GetString(3) + "\"\n";


            str += "A350,125,0,2,1,1,N,\"LINE NO:" + dr.GetString(7) +"\"\n";
            
            str += "A350,145,0,2,1,1,N,\"BIN: " + dr.GetString(4) + "\"\n";
            str += "A220,165,0,2,1,1,N,\"" + DateTime.Now.Date.ToString("MM/dd/yy") + "\"\n";
            str += "A350,165,0,2,1,1,N,\"QTY: " + quantityPerLabel + "\"\n";
            str += "P" + labelQuantity + "\n";

            //RawPrinterHelper.SendStringToPrinter(printer, str);

            quantityPerLabel = string.Empty;
            labelQuantity = string.Empty;
        }

        private void parseDescription()
        {
            int descriptionLength = iDescription.Length;

            if (descriptionLength < 15)
            {
                line1 = iDescription.Trim();
                line2 = "";
                line3 = "";
            }
            else   /*   description length is greater than 14   */
            {
                string a = iDescription.Substring(0, 14);

                if (a.LastIndexOf(",") != -1)
                {
                    firstLastIndex = a.LastIndexOf(",");
                    line1 = iDescription.Substring(0, firstLastIndex + 1);
                }
                else if (a.LastIndexOf(" ") != -1)
                {
                    firstLastIndex = a.LastIndexOf(" ");
                    line1 = iDescription.Substring(0, firstLastIndex);
                }
                else
                {
                    line1 = iDescription.Substring(0, 14);
                    firstLastIndex = 13;
                }

                /* if the first character of the second line is a space 
                 * then start at the next character
                 */

                if (iDescription.Length > 15)
                {
                    if (iDescription.Substring(firstLastIndex + 1, 1) == " ")
                        firstLastIndex += 1;
                }


                    if (iDescription.Substring(firstLastIndex + 1, descriptionLength - (firstLastIndex + 1)).Length > 14)
                {
                    string b = iDescription.Substring(firstLastIndex + 1, 14);

                    if (b.LastIndexOf(",") != -1)
                    {
                        secondLastIndex = b.LastIndexOf(",");
                        line2 = iDescription.Substring(firstLastIndex + 1, secondLastIndex + 1);
                    }
                    else if (b.LastIndexOf(" ") != -1)
                    {
                        secondLastIndex = b.LastIndexOf(" ");
                        line2 = iDescription.Substring(firstLastIndex + 1, secondLastIndex);
                    }
                    else if (b.ToUpper().LastIndexOf("X") != -1)
                    {
                        secondLastIndex = b.ToUpper().LastIndexOf("X");
                        line2 = iDescription.Substring(firstLastIndex + 1, secondLastIndex);
                    }
                    else
                    {
                        secondLastIndex = 13;
                        line2 = b;
                    }

                    if (line2.Substring(0, 1) == " ")
                    {
                        line2 = line2.Trim();
                    }
                }
                else
                {
                    line2 = iDescription.Substring(firstLastIndex + 1, descriptionLength - (firstLastIndex + 1));
                    secondLastIndex = -1;
                }

                if (secondLastIndex != -1)
                {
                    line3 = iDescription.Substring(firstLastIndex + secondLastIndex + 2, descriptionLength -
                            (firstLastIndex + secondLastIndex + 2));

                    if (line3.Substring(0, 1) == " ")
                    {
                        line3 = line3.Trim();
                    }
                }
                else
                {
                    line3 = "";
                }

                if (line1.Length > 14 | line2.Length > 14 | line3.Length > 14)
                {
                    line1 = iDescription.Substring(0, 14);

                    if (descriptionLength > 28)
                    {
                        line2 = iDescription.Substring(14, 14);
                    }
                    else  //( descriptionLength <= 28 )
                    {
                        line2 = iDescription.Substring(14, descriptionLength - 14);
                    }

                    if (descriptionLength > 28)
                    {
                        line3 = iDescription.Substring(28, descriptionLength - 28);
                    }
                }

                if (line1.Length > 0)
                {
                    line1 = line1.Replace("\"", "\\\"");
                }

                if (line2.Length > 0)
                {
                    line2 = line2.Replace("\"", "\\\"");
                }
                
                if (line3.Length > 0)
                {
                    line3 = line3.Replace("\"", "\\\"");
                }
            }
        }


        private void BulkPack(string item_code, string description, decimal quantity)
        {
            string intQuantity = Math.Round(quantity, 0).ToString();

            SqlConnection cnxn1 = new SqlConnection(dbMID);
            
            SqlCommand cmd3 = new SqlCommand("SELECT bulk_pack FROM Labels.ITEMS_BULK_PACKED " +
                "WHERE item_code = '" + item_code + "'", cnxn1);
            cnxn1.Open();
            object bulkpack = cmd3.ExecuteScalar();
            cnxn1.Close();
            if (bulkpack == null)
            {
                DialogResult result1 = MessageBox.Show("Do you want to bulk pack this item ?  "+ item_code + "", "",
                       MessageBoxButtons.YesNo);

                if (result1 == DialogResult.Yes)
                {
                    bulkpack = true;
                }
                else
                {
                    bulkpack = false;
                }

                SqlParameter pDescription = new SqlParameter("@description", SqlDbType.VarChar);
                pDescription.Value = description;

                cmd3 = new SqlCommand("INSERT INTO Labels.Items_Bulk_Packed " +
                    "(item_code, item_description, bulk_pack) VALUES ('" +
                    item_code + "'," + pDescription + ",'" + bulkpack + "')", cnxn1);
                cnxn1.Open();

                cmd3.Parameters.Add(pDescription);
                cmd3.ExecuteNonQuery();
                cnxn1.Close();
                cmd3.Parameters.Clear();
            }
            else 
            {
                DialogResult result1 = MessageBox.Show("Do you want to bulk pack this item ?  " + item_code + "", "",
                       MessageBoxButtons.YesNo);

                if (result1 == DialogResult.Yes)
                {
                    bulkpack = true;
                }
                else
                {
                    bulkpack = false;
                }

                SqlParameter pDescription = new SqlParameter("@description", SqlDbType.VarChar);
                pDescription.Value = description;

                cmd3 = new SqlCommand("UPDATE Labels.Items_Bulk_Packed " +
                    "SET BULK_PACK = '" + bulkpack + "' WHERE item_code = '" +
                    item_code + "'", cnxn1);
                cnxn1.Open();

                
                cmd3.ExecuteNonQuery();
                cnxn1.Close();
            }

            if (bulkpack is true)
            {
                labelQuantity = "1";
                quantityPerLabel = intQuantity;
            }
            else if (bulkpack is false & intQuantity == "1")
            {
                quantityPerLabel = intQuantity;
                labelQuantity = "1";
            }
            else if (bulkpack is false & quantity > 1)
            {
                quantityPerLabel = "1";
                labelQuantity = intQuantity;
            }
            quantity = 0;
            intQuantity = string.Empty;
            item_code = string.Empty;
            description = string.Empty;
        }

        private static string SendImageToPrinter(int top, int left, System.Drawing.Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            using (BinaryWriter bw = new BinaryWriter(ms, Encoding.ASCII))
            {
                //we set p3 parameter, remember it is Width of Graphic in bytes,
                //so we divive the width of image and round up of it
                int P3 = (int)Math.Ceiling((double)bitmap.Width / 8);
                bw.Write(Encoding.ASCII.GetBytes(string.Format
                ("GW{0},{1},{2},{3},", top, left, P3, bitmap.Height)));
                //the width of matrix is rounded up multi of 8
                int canvasWidth = P3 * 8;
                //Now we convert image into 2 dimension binary matrix by 2 for loops below,
                //in the range of image, we get colour of pixel of image,
                //calculate the luminance in order to set value of 1 or 0
                //otherwise we set value to 1
                //Because P3 is set to byte (8 bits), so we gather 8 dots of this matrix,
                //convert into a byte then write it to memory by using shift left operator <<
                //e,g 1 << 7  ---> 10000000
                //    1 << 6  ---> 01000000
                //    1 << 3  ---> 00001000
                for (int y = 0; y < bitmap.Height; ++y)     //loop from top to bottom
                {
                    for (int x = 0; x < canvasWidth;)       //from left to right
                    {
                        byte abyte = 0;
                        for (int b = 0; b < 8; ++b, ++x)     //get 8 bits together and write to memory
                        {
                            int dot = 1;                     //set 1 for white,0 for black
                                                             //pixel still in width of bitmap,
                                                             //check luminance for white or black, out of bitmap set to white
                            if (x < bitmap.Width)
                            {
                                System.Drawing.Color color = bitmap.GetPixel(x, y);
                                int luminance = (int)((color.R * 0.3) + (color.G * 0.59) + (color.B * 0.11));
                                dot = luminance > 127 ? 1 : 0;
                            }
                            abyte |= (byte)(dot << (7 - b)); //shift left,
                                                             //then OR together to get 8 bits into a byte
                        }
                        bw.Write(abyte);
                    }
                }
                bw.Write("\n");
                bw.Flush();
                //reset memory
                ms.Position = 0;
                //get encoding, I have no idea why encode page of 1252 works and fails for others
                return Encoding.GetEncoding(1252).GetString(ms.ToArray());
            }
        }

        private void bPrintSelectedLine_Click(object sender, EventArgs e)
        {
            commonLabelProcessing();
        }
    }

    public class RawPrinterHelper
    {
        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "My C#.NET RAW Document";
            di.pDataType = "RAW";

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        public static bool SendFileToPrinter(string szPrinterName, string szFileName)
        {
            // Open the file.
            FileStream fs = new FileStream(szFileName, FileMode.Open);
            // Create a BinaryReader on the file.
            BinaryReader br = new BinaryReader(fs);
            // Dim an array of bytes big enough to hold the file's contents.
            Byte[] bytes = new Byte[fs.Length];
            bool bSuccess = false;
            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = Convert.ToInt32(fs.Length);
            // Read the contents of the file into the array.
            bytes = br.ReadBytes(nLength);
            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);
            return bSuccess;
        }
        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = (szString.Length + 1) * Marshal.SystemMaxDBCSCharSize;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }
    }
}

