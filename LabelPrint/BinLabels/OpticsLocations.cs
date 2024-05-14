using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection.Emit;
using System.Runtime.InteropServices;


namespace BinLabels
{
    public partial class OpticsLocations : Form
    {
        SqlDataReader dr;

        public OpticsLocations()
        {
            InitializeComponent();
        }

        private void OpticsLocations_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection(
                "server = ct-mid-sql11; password = Read+Write!; user = readWrite; database = Optics;");
                        
            SqlCommand cmd = new SqlCommand(
           "SELECT top 2 " +
           " [Location] " +
           " FROM[Optics].[dbo].[OpticTrackLocations] " +
           " ORDER BY [Location]  ", cnxn);



            cnxn.Open();

            dr = cmd.ExecuteReader();

            DataTable table = new DataTable();

            table.Load(dr);

            dr = cmd.ExecuteReader();

            string printer = "ZDesigner ZD421-203dpi ZPL";

            while (dr.Read())
            {
                //EPL
                //string str = "\nN\nq812Q609,203\n";
                ////str += "A30,20,0,4,1,1,N,\"SFO#\"\n";
                ////str += "B100,20,0,1,2,4,32,B,\"" + dr.GetString(2) + "\"\n";
                ////str += "A30,10,0,4,1,1,N,\"PN#\"\n";
                //str += "B100,10,0,1,2,4,32,B,\"" + dr.GetString(0) + "\"\n";

                ////str += "A300,80,0,3,1,1,N,\"DESC:\"\n";
                //str += "A100,80,0,5,1,1,N,\"" + dr.GetString(0) + "\"\n";
                ////str += "A100,110,0,4,1,1,N,\"Bin # :\"\n";
                ////str += "A200,110,0,4,1,1,N,\"" + dr.GetDouble(2).ToString() + "\"\n";
                ////str += "A300,110,0,4,1,1,N,\"FULL BIN: \"\n";
                ////str += "A450,110,0,4,1,1,N,\"" + dr.GetString(3) + "\"\n";
                ////str += "A100,150,0,4,1,1,N,\"WAREHOUSE: \"\n";
                ////str += "A270,150,0,4,1,1,N,\"" + dr.GetString(4) + "\"\n";
                ////str += "A350,500,0,4,1,1,N,\"Pulled on:\"\n";
                ////str += "LO30,550,800,2\n";
                ////str += "LO30,700,800,2\n";
                //str += "P1\n";
                //RawPrinterHelper.SendStringToPrinter(printer, str);

                ////ZPL
                StringBuilder ZplBuilder = new StringBuilder();

                ZplBuilder.Append("^XA");   //Start ZPL

                //barcode
                //ZplBuilder.Append("^FO50,40");
                //ZplBuilder.Append("^B3N,100,Y");
                //ZplBuilder.Append("^FD%B%").Append(dr.GetString(0));

                /* ^FO = field origin  see oneNote for explanations     */

                ZplBuilder.Append("^FO10,30^BY1");
                ZplBuilder.Append("^B3N,N, 50,N,N");
                //ZplBuilder.Append("^FD").Append(dr.GetString(0));
                ZplBuilder.Append("^FD").Append("PD510236");
                ZplBuilder.Append("^FS");


                ZplBuilder.Append("^FO10,130^A0N,40,40");
                ZplBuilder.Append("^FD").Append(dr.GetString(0));
                ZplBuilder.Append("^FS");
                
                
                // the box
                //ZplBuilder.Append("^FO0,30^GB450,150,10^FS");


                //ZplBuilder.Append("^FS^FO" + r + ",75^A0N,40,40^FD").Append(label).Append("^FS");

                ZplBuilder.Append("^XZ");
                // End ZPL

                string ZplString = ZplBuilder.ToString();

                MemoryStream lmemStream = new MemoryStream();

                StreamWriter lstreamWriter = new StreamWriter(lmemStream);
                lstreamWriter.Write(ZplString);
                lstreamWriter.Flush();
                lmemStream.Position = 0;

                byte[] byteArray = lmemStream.ToArray();

                IntPtr cpUnmanagedBytes = new IntPtr(0);
                int cnLength = byteArray.Length;
                cpUnmanagedBytes = Marshal.AllocCoTaskMem(cnLength);
                Marshal.Copy(byteArray, 0, cpUnmanagedBytes, cnLength);

                RawPrinterHelper.SendBytesToPrinter("ZDesigner ZD421-203dpi ZPL", cpUnmanagedBytes, cnLength);
                //RawPrinterHelper.SendBytesToPrinter(g.printer, cpUnmanagedBytes, cnLength);
                Marshal.FreeCoTaskMem(cpUnmanagedBytes);
            }

        }
    }
}
