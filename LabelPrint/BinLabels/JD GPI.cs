using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace BinLabels
{
    public partial class JD_GPI : Form
    {
        SqlDataReader dr;

        public JD_GPI()
        {
            InitializeComponent();
        }

        private void JD_GPI_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection(
                "server = ct-mid-sql11; password = views; user = views; database = accessfrontends;");

            SqlCommand cmd = new SqlCommand(
            "SELECT TOP 100 " +
            " [Component] " +
            ",[Description] " +
            ",COALESCE([Bin Num#],'0.0') " +
            ", COALESCE(CAST([Full Bin Quant#] as varchar (3)),'') " +
            ",CAST([Warehouse] as varchar(3)) " +
            "  FROM[AccessFrontEnds].[dbo].[JD_GPI_Labels] " +
            "WHERE [Component] > '8070-1355-01' " +
            "ORDER BY [Component] ", cnxn);

            cnxn.Open();
                        
            dr = cmd.ExecuteReader();

            DataTable table = new DataTable();

            table.Load(dr);

            dr = cmd.ExecuteReader();

            string printer = "ZDesigner ZD421-203dpi ZPL";

            while (dr.Read())
            {
                //EPL
                string str = "\nN\nq812Q609,203\n";
                //str += "A30,20,0,4,1,1,N,\"SFO#\"\n";
                //str += "B100,20,0,1,2,4,32,B,\"" + dr.GetString(2) + "\"\n";
                //str += "A30,10,0,4,1,1,N,\"PN#\"\n";
                str += "B200,10,0,1,2,4,32,B,\"" + dr.GetString(0) + "\"\n";

                //str += "A300,80,0,3,1,1,N,\"DESC:\"\n";
                str += "A200,80,0,4,1,1,N,\"" + dr.GetString(1) + "\"\n";
                str += "A200,110,0,4,1,1,N,\"Bin # :\"\n";
                str += "A300,110,0,4,1,1,N,\"" + dr.GetDouble(2).ToString() + "\"\n";
                str += "A400,110,0,4,1,1,N,\"FULL BIN: \"\n";
                str += "A500,110,0,4,1,1,N,\"" + dr.GetString(3) + "\"\n";
                str += "A200,150,0,4,1,1,N,\"WAREHOUSE: \"\n";
                str += "A370,150,0,4,1,1,N,\"" + dr.GetString(4) + "\"\n";
                //str += "A350,500,0,4,1,1,N,\"Pulled on:\"\n";
                //str += "LO30,550,800,2\n";
                //str += "LO30,700,800,2\n";
                str += "P1\n";
                RawPrinterHelper.SendStringToPrinter(printer, str);

                ////ZPL
                //StringBuilder ZplBuilder = new StringBuilder();

                //ZplBuilder.Append("^XA");   //Start ZPL

                ////barcode
                //ZplBuilder.Append("^FO50,40");
                //ZplBuilder.Append("^BXN,8,200");
                //ZplBuilder.Append("^FD%B%").Append("6550-1074-01");


                //ZplBuilder.Append("^FS");
                //ZplBuilder.Append("^FS^FO300,140^A0N,40,40^FDBin Code^FS");
                //// the box
                ////ZplBuilder.Append("^FO0,30^GB450,150,10^FS");


                ////ZplBuilder.Append("^FS^FO" + r + ",75^A0N,40,40^FD").Append(label).Append("^FS");

                //ZplBuilder.Append("^XZ");
                //// End ZPL

                //string ZplString = ZplBuilder.ToString();

                //MemoryStream lmemStream = new MemoryStream();

                //StreamWriter lstreamWriter = new StreamWriter(lmemStream);
                //lstreamWriter.Write(ZplString);
                //lstreamWriter.Flush();
                //lmemStream.Position = 0;

                //byte[] byteArray = lmemStream.ToArray();

                //IntPtr cpUnmanagedBytes = new IntPtr(0);
                //int cnLength = byteArray.Length;
                //cpUnmanagedBytes = Marshal.AllocCoTaskMem(cnLength);
                //Marshal.Copy(byteArray, 0, cpUnmanagedBytes, cnLength);

                //RawPrinterHelper.SendBytesToPrinter("ZDesigner ZD421-203dpi ZPL", cpUnmanagedBytes, cnLength);
                ////RawPrinterHelper.SendBytesToPrinter(g.printer, cpUnmanagedBytes, cnLength);
                //Marshal.FreeCoTaskMem(cpUnmanagedBytes);
            }

        }

        private void send2Printer()
        {
            /*
             * This code is for EPL print language
              * 
              * q = set label width in dots (width = Y dimension)
              * Q = set form length in dots (for us 203 dpi and length = X dimension)
              * the 20 is the gap between the labels
              * LO draws a line
              * all the lines need \n at the end to print
              * 
              * */
            //string str = "\nN\nq812Q609,203\n";
            //str += "A30,20,0,4,1,1,N,\"SFO#\"\n";
            //str += "B100,20,0,1,2,4,32,B,\"" + dr.GetString(2) + "\"\n";
            //str += "A30,120,0,4,1,1,N,\"PN#\"\n";
            //str += "B100,120,0,1,2,4,32,B,\"" + dr.GetString(0) + "\"\n";
            
            //str += "A30,280,0,3,1,1,N,\"DESC:\"\n";
            //str += "A110,280,0,4,1,1,N,\"" + dr.GetString(1) + "\"\n";
            //str += "A30,350,0,4,1,1,N,\"BIN: 1 of 1\"\n";
            //str += "A350,385,0,4,1,1,N,\"QTY :\"\n";
            //str += "A450,385,0,4,1,1,N,\"" + dr.GetString(3) + "\"\n";
            //str += "A350,420,0,4,1,1,N,\"START:\"\n";
            //str += "A450,420,0,4,1,1,N,\"" + dr.GetDateTime(4).ToShortDateString() + "\"\n";
            //str += "A30,500,0,4,1,1,N,\"Pulled by:\"\n";
            //str += "A350,500,0,4,1,1,N,\"Pulled on:\"\n";
            //str += "LO30,550,800,2\n";
            //str += "LO30,700,800,2\n";
            //str += "P" + tbLabelQuantity.Text + "\n";
            //RawPrinterHelper.SendStringToPrinter(printer, str);
        }
    }


}
