using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Threading;

namespace BarTenderPrinter
{
    public partial class BarTenderPrinter : Form
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

        public BarTenderPrinter()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "SER Packing List Excel Files|*packing*.xls*";
            openFileDialog1.Title = "Select SER Packing List";
            openFileDialog1.InitialDirectory = 
                @"\\zygocorp\departments\engineering\sers\2 - active projects\";
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
                    if(itemCountList[i,1] != null)
                    {
                    //itemCount = Convert.ToInt32(itemCountList[i, 1].ToString());
                        itemCount = i;
                    }
                }
                catch(Exception ex)
                {
                    string news = ex.Message.ToString();
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
                    labelFactor = numberOfLabels/qty ;

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

        private void rb1Label_CheckedChanged(object sender, EventArgs e)
        {

            if (rb1Label.Checked == true)
            {
                labelSets = 1;
            }
        }

        private void rb3Labels_CheckedChanged(object sender, EventArgs e)
        {
            if (rb3Labels.Checked == true)
            {
                labelSets = 3;
            }
        }

        private void rb4Labels_CheckedChanged(object sender, EventArgs e)
        {
            if(rb4Labels.Checked == true)
            {
                labelSets = 4;
            }
        }

        private void printLabel(int n)
        {
            string labelData = labelSets + " \t" + xlData[n, 1].ToString() + "\t" + xlData[n, 2] + "\t" +
                    xlData[n, 5] + "\t QTY: " + xlData[n, 3] + "\t" + xlData[n, 4] + "\t Part:" + pageof +
                    " of " + numberOfLabels;

            File.WriteAllText(@"C:\labels\generic\genericlabel.txt", "Copies \t PartNo \t " +
                "Description \t SN \t QTY \t Project \t PartXofY" + Environment.NewLine);
            File.AppendAllText(@"C:\labels\generic\genericlabel.txt", labelData);

            string label = @"C:\labels\generic\genericlabel.txt";

            //string format = @"C:\\labels\\Generic\\zebrageneric1text_sn35.btw";
            //string format = @"C:\\labels\\Generic\\zebrageneric1text_sn12.btw";
            string format = @"C:\\labels\\Generic\\zebrageneric1text_sn7.btw";

            //System.Diagnostics.Process.Start("C:\\Program Files\\Seagull" +
            //    "\\BarTender 6.20\\Professional\\bartend.exe",
            //     "/P /X /F=" + format + "/d=" + label);


            System.Diagnostics.Process.Start("C:\\Program Files (x86)\\Seagull" +
               "\\Bartender Suite\\bartend.exe",
                 "/P /X /F=" + format + "/d=" + label);

            Thread.Sleep(5 * 1000);
        }

       
    }
}
