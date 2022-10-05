using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Drawing.Imaging;
using System.Collections;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace SERlabelListGK420
{
    public partial class SERLabelListGK : Form
    {
        Microsoft.Office.Interop.Excel.Application oXL;
        Microsoft.Office.Interop.Excel.Workbook oWB;
        Microsoft.Office.Interop.Excel.Worksheet oWS;
        Microsoft.Office.Interop.Excel.Range oRng;
        private int itemCount;
        private int labelSets;
        private string packingList;
        private int pageof;
        private int numberOfLabels;
        private int qty;
        private int labelFactor;
        object[,] xlData;
        object[,] itemCountList;

        private string itemCode;
        private string iDescription;

        private string Project;
        private string Qty;
        private string Part;
        private string SN;
        private string line1;
        private string line2;
        private string line3;
        private string labelQuantity;
        private int firstLastIndex;
        private int secondLastIndex;

        private string printer;
        DataTable pTable;

        SqlConnection cnxn;
        SqlDataReader dr;
        SqlDataAdapter da;
        private string db = "server = CT-MID-SQL11; user = ReadWrite; password = Read+Write!; " +
                            "database = AccessFrontEnds;";

        public SERLabelListGK()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Security.Principal.WindowsIdentity userBase;
            userBase = System.Security.Principal.WindowsIdentity.GetCurrent();

            string user = userBase.Name.Replace("ZYGOMIS\\", "");
            string computername = Environment.MachineName;

            string[] iPrinter = new string[10];
            int i = 0;
            int iprCount = 0;

            foreach (string psprinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                if (psprinter.ToUpper().Contains("ZEBRA"))
                {
                    iPrinter[i] = psprinter;
                    i++;
                }
            }

            iprCount = i - 1;

            string[] uPrinter = new string[10];
            int j = 0;
            int ukprCount = 0;

            Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Printers\\Connections");

            foreach (string ukprinter in registryKey.GetSubKeyNames())
            {
                if (ukprinter.ToUpper().Contains("ZEBRA"))
                {
                    uPrinter[j] = ukprinter;
                    j++;
                }
            }

            ukprCount = j - 1;

            DataTable table = new DataTable();
            cnxn = new SqlConnection(db);
            DataTable dtp = new DataTable();

            DGV.Columns.Add("Index", "Index");
            DGV.Columns.Add("Value", "Printer");


            try
            {
                //looking for printers which are formatted for the correct label size and material
                SqlDataAdapter dap = new SqlDataAdapter
                    ("select distinct permissionvalue from applicationsetup " +
                     "where application = 'serlabellist' and permission = 'printer'", cnxn);
                dap.Fill(dtp);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

            }

            for (int n = 0; n < i; n++)
            {
                for (int m = 0; m < dtp.Rows.Count; m++)
                {
                    if (iPrinter[n].ToUpper().Contains(dtp.Rows[m][0].ToString().ToUpper().Trim()))
                    {
                        DGV.Rows.Add(new object[] { n, iPrinter[n] });
                    }
                }
            }

            DGV.Columns[0].Visible = false;
            DGV.Columns[1].Width = 190;
            DGV.Visible = true;


            openFileDialog1.Filter = "SER Packing List Excel Files|*packing*.xls*";
            openFileDialog1.Title = "Select SER Packing List";
            openFileDialog1.InitialDirectory =
                @"\\zygocorp\projects\";
            openFileDialog1.ShowDialog();
            rb3Labels.Checked = true;
            packingList = openFileDialog1.FileName;

        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            oXL = new Microsoft.Office.Interop.Excel.Application();
            oXL.Visible = false;

            //oXL.Visible = true;
            //oXL.DisplayAlerts = false;

            oWB = oXL.Workbooks.Open(packingList,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value);
            oWS = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Worksheets.get_Item("Sheet1");
            oRng = oWS.Range["D6:I407"];

            xlData = oRng.get_Value(Missing.Value);
            oRng = oWS.Range["C7:C407"];

            itemCountList = oRng.get_Value(Missing.Value);

            oXL.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oXL);


            //take array and determine how many items in list
            for (int i = 1; i <= 400; i++)
            {
                try
                {
                    if (itemCountList[i, 1] != null)
                    {
                        //itemCount = Convert.ToInt32(itemCountList[i, 1].ToString());
                        itemCount = i;
                    }
                }
                catch (Exception ex)
                {
                    string news = ex.Message.ToString() + "\n\n Item Number column error";
                    return;
                }
            }

            for (int n = 1; n <= (itemCount + 1); n++)
            {

                if (xlData[1, 1] == null)
                {
                    MessageBox.Show("Either this is not a SER packing list or it " +
                        "is incorrectly formatted. An entry is required in D6.");
                    return;
                }

                if (xlData[1, 1].ToString().Length > 2)
                {
                    //if this is not a ser packing list exit the routine
                    if (xlData[1, 1].ToString().Substring(0, 3) != "SER")
                    {
                        MessageBox.Show("Either this is not a SER packing list or it " +
                            "is incorrectly formatted. D6 requires 'SER' + the SER number.");
                        return;
                    }
                }
                //first label should be the SER number and won't have the
                //same columns of data that the items will have
                if (n == 1)
                {
                    printLabel(n);
                }

                if (n >= 2)
                {
                    pageof = 1;

                    //calculate number of labels needed
                    qty = Convert.ToInt32(xlData[n, 3].ToString());
                    numberOfLabels = Convert.ToInt32(xlData[n, 6].ToString());
                    labelFactor = numberOfLabels / qty;

                    for (int ii = 1; ii <= numberOfLabels; ii++)
                    {
                        if (qty >= numberOfLabels)
                        {
                            printLabel(n);
                            pageof++;
                        }

                        if (qty < numberOfLabels)
                        {
                            if (labelFactor == 1)
                            {
                                pageof = 1;
                                printLabel(n);
                            }

                            if (labelFactor == 2)
                            {
                                pageof = 1;
                                printLabel(n);
                                pageof = 2;
                                printLabel(n);
                                numberOfLabels = numberOfLabels - 2;
                            }

                            if (labelFactor == 3)
                            {
                                pageof = 1;
                                printLabel(n);
                                pageof = 2;
                                printLabel(n);
                                pageof = 3;
                                printLabel(n);
                                numberOfLabels = numberOfLabels - 3;
                            }

                            if (labelFactor == 4)
                            {
                                pageof = 1;
                                printLabel(n);
                                pageof = 2;
                                printLabel(n);
                                pageof = 3;
                                printLabel(n);
                                pageof = 4;
                                printLabel(n);
                                numberOfLabels = numberOfLabels - 4;
                            }

                            if (labelFactor == 5)
                            {
                                pageof = 1;
                                printLabel(n);
                                pageof = 2;
                                printLabel(n);
                                pageof = 3;
                                printLabel(n);
                                pageof = 4;
                                printLabel(n);
                                pageof = 5;
                                printLabel(n);
                                numberOfLabels = numberOfLabels - 5;
                            }

                        }
                    }

                }


            }
            this.BackColor = System.Drawing.Color.Gray;
            this.Close();
        }

        private void printLabel(int n)
        {
            itemCode = "";
            iDescription = "";
            Qty = "";
            Project = "";
            SN = "";

            if (xlData[n, 1] != null)
            { itemCode = xlData[n, 1].ToString().Trim(); }
            if (xlData[n, 2] != null)
            { iDescription = xlData[n, 2].ToString().Trim(); }
            if (xlData[n, 3] != null)
            { Qty = "Qty: " + xlData[n, 3].ToString().Trim(); }
            else
            { Qty = "Qty: "; }
            if (xlData[n, 4] != null)
            { Project = xlData[n, 4].ToString().Trim(); }
            if (xlData[n, 5] != null)
            { SN = xlData[n, 5].ToString().Trim(); }


            int descriptionLength = iDescription.Length;

            if (descriptionLength < 15)
            {
                line1 = iDescription.Trim();
                line2 = "";
                line3 = "";
            }
            else   /*   description length is greater than 14   */
            {
                //if (g.iDescription.IndexOf(" ") != -1)
                //{
                //if (descriptionLength > 14)
                //{
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
                //}

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

            labelQuantity = labelSets.ToString();

            Bitmap bzp = Properties.Resources.zygo_blk_noR_132;
            Bitmap bxp = Properties.Resources.ametek_blk_noR_132;

            /*
             *  Add the image to the resources folder or elsewhere, then add the file to the
             *  resourses.resx file and it will take in the file and reclassify it as an image.
             *  It should then be available under properties.resources - the case does matter for 
             *  the image name.
             */

            if (itemCode.ToUpper().Substring(0, 3) == "SER")
            {
                string str = "\nN\nq609Q203,20\n";
                str += SendImageToPrinter(10, 10, bzp);
                str += SendImageToPrinter(450, 10, bxp);
                str += "A144,10,0,2,1,1,N,\"21 Laurel Brook Road\"\n";
                str += "A144,35,0,2,1,1,N,\"Middlefield, CT 06455 USA\"\n";
                str += "B50,70,0,1,2,4,32,B,\"" + itemCode + "\"\n";
                str += "P" + labelQuantity + "\n";
                RawPrinterHelper.SendStringToPrinter(printer, str);
                //File.AppendAllText(@"C:\A\sertest.txt", itemCode + Environment.NewLine);

            }
            else
            {
                Part = "Part: " + pageof + " of " + numberOfLabels;

                string str = "\nN\nq609Q203,20\n";
                str += SendImageToPrinter(10, 10, bzp);
                str += SendImageToPrinter(450, 10, bxp);
                str += "A144,10,0,2,1,1,N,\"21 Laurel Brook Road\"\n";
                str += "A144,35,0,2,1,1,N,\"Middlefield, CT 06455 USA\"\n";
                str += "A10,70,0,2,1,1,N,\"PN#\"\n";
                str += "B50,65,0,1,2,4,32,B,\"" + itemCode + "\"\n";
                str += "A420,60,0,2,1,1,N,\"" + line1 + "\"\n";
                str += "A420,80,0,2,1,1,N,\"" + line2 + "\"\n";
                str += "A420,100,0,2,1,1,N,\"" + line3 + "\"\n";
                str += "A10,140,0,2,1,1,N,\"SN#\"\n";
                str += "B50,135,0,1,2,4,32,B,\"" + SN + "\"\n";
                str += "A420,125,0,2,1,1,N,\"" + Project + "\"\n";
                str += "A420,150,0,2,1,1,N,\"" + Qty + "\"\n";
                str += "A420,175,0,2,1,1,N,\"" + Part + "\"\n";
                str += "P" + labelQuantity + "\n";
                RawPrinterHelper.SendStringToPrinter(printer, str);
                //File.AppendAllText(@"C:\A\sertest.txt", itemCode + Environment.NewLine);
            }
        }


    }
}
