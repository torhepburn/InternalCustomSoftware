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
    public partial class ProductionLabelsMK : Form
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
        private string iDescription;
        private string dbMID = "user=readWrite; password=Read+Write!; " +
                    "server=CT-MID-SQL01; database=AccessFrontEnds;";
        /*private string db = "server = MIDNAV01; password = views; " +
                            "user = views; database = ZYGO-NAV-TEST;";*/
        public static string dbNAV = "server = pa-hor-as408.ametek.com; password = 2018#ameteK; " +
                            "user = navdb_read; database = ZYGO-NAV-TEST;";
        //private string NAVprefix = "ZYGO_TEST4$";
        private string querySTD = string.Empty;
        private string queryCSTM = string.Empty;
        private string query = string.Empty;
        private string mk1S = " AND ITEM_TYPE_STAND_CUST = 1 ";
        private string mk2S = " ORDER BY STOCK_LOCATION, Item_CODE ";
        private string mk1C = " AND ITEM_TYPE_STAND_CUST = 2 ";
        private string mk2C = " ORDER BY WAREHOUSE, Item_CODE ";

        SqlConnection cnxn;
        SqlDataReader dr;
        public ProductionLabelsMK()
        {
            InitializeComponent();
        }

        private void ProductionLabelsMK_Load(object sender, EventArgs e)
        {
            this.Text = "Production Order Labels for MK  v" + Application.ProductVersion;
                        
            this.BackColor = Color.FromArgb(80, 100, 220); /*       MK      */
            
        }

        private void Bprint_Click(object sender, EventArgs e)
        {
            tbProductionOrder.Text = tbProductionOrder.Text.ToUpper().ToString();

            

            /*      MK       */
            
            querySTD = "SELECT " +
                                " c.[Item_CODE] " +
                                ",c.[ITEM_Description] " +
                                ",CAST(c.Order_No as varchar(15)) " +
                                ",CAST(c.Position_NUMBER as varchar(5)) " +
                                ",c.[WAREHOUSE] " +
                                ",cast(NET_Quantity as decimal(11,2)) " +
                                ",w.[Stock_location] " +
                                ",CAST(c.Operation as varchar(15)) " +
                                "FROM " +
                                "MMX_ACTUAL_MATERIAL_COSTS c " +
                                "LEFT JOIN MMX_ITEM_DATA_BY_WAREHOUSE w " +
                                "ON c.warehouse = w.warehouse and c.item_code = w.item_code " +
                                " WHERE ITEM_TYPE_STAND_CUST = 1 AND NET_QUANTITY <> 0 " +
                                "AND [Order_No] = '" +
                                tbProductionOrder.Text + "' ";

            queryCSTM = "SELECT " +
                                " c.[Item_CODE] " +
                                ",c.[ITEM_Description] " +
                                ",CAST(c.Order_No as varchar(15)) " +
                                ",CAST(c.Position_NUMBER as varchar(5)) " +
                                ",c.[WAREHOUSE] " +
                                ",cast(NET_Quantity as decimal(11,2)) " +
                                ",'N/A' " +
                                ",CAST(c.Operation as varchar(15)) " +
                                "FROM " +
                                "MMX_ACTUAL_MATERIAL_COSTS c " +
                                "INNER JOIN MMX_CUSTOMIZED_ITEMS i " +
                                "ON c.PROJECT = i.PROJECT " +
                                "AND c.MANUFACTURED_ITEM_CODE = i.ITEM_CODE " +
                                "LEFT JOIN MMX_CUSTOM_ITEM_DATA_BY_WHSE w " +
                                "ON c.warehouse = w.warehouse and c.item_code = w.item_code " +
                                "AND c.PROJECT = w.PROJECT and c.item_code = w.item_code " +
                                " WHERE ITEM_TYPE_STAND_CUST = 2 AND NET_QUANTITY <> 0 " +
                                "AND [Order_No] = '" +
                                tbProductionOrder.Text + "' ";

            
            cnxn = new SqlConnection(dbMID);

            if (tbProductionOrder.Text.Length != 6)
            {
                MessageBox.Show("Must enter a 6 digit production order number.");
                tbProductionOrder.Focus();
                return;
            }
            else
            {
                SqlCommand cmd = new SqlCommand("SELECT order_no FROM MMX_ACTUAL_MATERIAL_COSTS " +
                    "WHERE ORDER_NO = '" + tbProductionOrder.Text.ToString() + "'", cnxn);
                                
                cnxn.Open();
                object o = cmd.ExecuteScalar();
                cnxn.Close();

                if (o == null)
                {
                    MessageBox.Show("Order Number not available or mistyped");
                }
                else
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
                         " SELECT DISTINCT item_type_stand_cust FROM " +
                         " MMX_ACTUAL_MATERIAL_COSTS WHERE order_no = '" +
                           tbProductionOrder.Text.ToString() + "' ORDER BY " +
                         " item_type_stand_cust", cnxn);


                        
                        DataTable table = new DataTable();
                        da.Fill(table);


                        /*  MK    */
                        if (table.Rows.Count > 0)
                        {
                            if (table.Rows.Count > 1)
                            {
                                if (table.Rows[1][0].ToString().Trim() == "1")
                                {
                                    standard = true;
                                }

                                if (table.Rows[1][0].ToString().Trim() == "2")
                                {
                                    custom = true;
                                }
                            }
                            if (table.Rows[0][0].ToString().Trim() == "1")
                            {
                                standard = true;
                            }

                            if (table.Rows[0][0].ToString().Trim() == "2")
                            {
                                custom = true;
                            }
                            
                                    /*  NAV vetted and non-vetted    */


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

                    if (standard)
                    {
                        try
                        {

                            //Debug table  
                            /* MK     */
                            SqlDataAdapter da = new SqlDataAdapter(
                                 querySTD + mk1S  + mk2S
                                   , cnxn);

                           
                            DataTable t = new DataTable();
                            da.Fill(t);
                            string test = "for testing purposes";
                            /*  */

                            /*      mk     */
                            cmd = new SqlCommand(querySTD + mk1S + mk2S, cnxn);


                            cmd.Connection = cnxn;
                            cnxn.Open();
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
                            //Debug table  
                            /* MK     */
                            SqlDataAdapter da = new SqlDataAdapter(
                                 queryCSTM + mk1C + mk2C
                                   , cnxn);

                           

                            DataTable t = new DataTable();
                            da.Fill(t);
                            string test = "for testing purposes";
                            /*  */

                            /*      MK     */
                            cmd = new SqlCommand(queryCSTM + mk1C + mk2C, cnxn);

                          
                            cmd.Connection = cnxn;
                            cnxn.Open();
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

            standard = false;
            custom = false;
            tbProductionOrder.Text = string.Empty;
            tbProductionOrder.Focus();
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
            /*
            File.AppendAllText(@"C:\a\prodord.txt", dr.GetString(0).ToString()  + Environment.NewLine);
            File.AppendAllText(@"C:\a\prodord.txt", line1 + Environment.NewLine);
            File.AppendAllText(@"C:\a\prodord.txt", line2 + Environment.NewLine);
            File.AppendAllText(@"C:\a\prodord.txt", line3 + Environment.NewLine);
            File.AppendAllText(@"C:\a\prodord.txt", dr.GetString(2).ToString() + Environment.NewLine);
            File.AppendAllText(@"C:\a\prodord.txt", dr.GetString(3).ToString() + Environment.NewLine);
            File.AppendAllText(@"C:\a\prodord.txt", dr.GetString(4) + Environment.NewLine);
            File.AppendAllText(@"C:\a\prodord.txt", dr.GetString(6).ToString() + Environment.NewLine);
            File.AppendAllText(@"C:\a\prodord.txt", "labelQuantity:  ");
            File.AppendAllText(@"C:\a\prodord.txt", labelQuantity + Environment.NewLine);
            File.AppendAllText(@"C:\a\prodord.txt", "Quantity per Label:  ");
            File.AppendAllText(@"C:\a\prodord.txt", quantityPerLabel + Environment.NewLine);
            /*  */

            Bitmap bzp = Properties.Resources.zygo_blk_noR_132;
            Bitmap bxp = Properties.Resources.ametek_blk_noR_132;
            string str = string.Empty;
            string printer = @"\\midprtsrv\zebrasn17";
            //string printer = @"\\midprtsrv\zebrasn7";
            //string printer = @"\\midprtsrv\zebrasn12";

            str = "\nN\nq609Q203,20\n";
            str += SendImageToPrinter(10, 10, bzp);
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
            str += "B50,125,0,1,2,4,32,B,\"" + dr.GetString(2) + "\"\n";
            str += "A220,125,0,2,1,1,N,\"POS: " + dr.GetString(3) + "\"\n";
            str += "A400,125,0,2,1,1,N,\"WHS: " + dr.GetString(4) + "\"\n";
            str += "A220,145,0,2,1,1,N,\"OPR: " + dr.GetString(7) + "\"\n";
            str += "A350,145,0,2,1,1,N,\"BIN: " + dr.GetString(6) + "\"\n";
            str += "A220,165,0,2,1,1,N,\"" + DateTime.Now.Date.ToString("MM/dd/yy") + "\"\n";
            str += "A350,165,0,2,1,1,N,\"QTY: " + quantityPerLabel + "\"\n";
            str += "P" + labelQuantity + "\n";
            RawPrinterHelper.SendStringToPrinter(printer, str);

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

                cmd3 = new SqlCommand("INSERT INTO Labels.Items_Bulk_Packed " +
                    "(item_code, item_description, bulk_pack) VALUES ('" +
                    item_code + "','" + description + "','" + bulkpack + "')", cnxn1);
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
    }

    
}

