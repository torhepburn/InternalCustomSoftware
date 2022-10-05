using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
using System.Data.OleDb;
using Microsoft.Office.Interop.Access;

namespace GeetOptiTRAKdata
{
    public partial class Form1 : Form
    {
        object misValue = System.Reflection.Missing.Value;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void bAccess_Click(object sender, EventArgs e)
        {
            //OleDbConnection con = new OleDbConnection();

            //con.ConnectionString = "provider=microsoft.ace.oledb.14.0;Data Source= " +
            //    "\\\\usrics01\\gen_tl\\shared\\optitrak\\data\\Optitrak2_BE.mdb; " +
            //    "Mode=ReadWrite; Persist Security Info=False";

            //con.Open();

            //OleDbCommand cmd = new OleDbCommand("select * from tblPartSN");

            //cmd.Connection = con;

            //OleDbDataReader dr = cmd.ExecuteReader();

            //if (dr.HasRows)
            //{
            //    while (dr.Read())
            //    {
            //        if (!dr.IsDBNull(0))
            //        { int a = dr.GetInt32(0); }
                    
            //        if (!dr.IsDBNull(1))
            //        { int a = dr.GetInt32(1); }


                    //else { Shipping_Date_To_Cesta = ""; }
                    //if (!dr.IsDBNull(4))
                    //{ Frame_Serial_Number = dr.GetString(4).Trim(); }
                    //else { Frame_Serial_Number = ""; }
                    //if (!dr.IsDBNull(12))
                    //{
                    //    Container_Serial_Number = dr.GetString(12).Trim();
                    //    Container_Serial_Number = Container_Serial_Number.Substring(0, 2) +
                    //        "-" + Container_Serial_Number.Substring(2, 4);
                    //}
                    //else { Container_Serial_Number = ""; }
                    //if (!dr.IsDBNull(13))
                    //{ NCMR_Serial_Number = dr.GetString(13).Trim(); }
                    //else { NCMR_Serial_Number = ""; }

               // }
            //}
            return;
        }

        private void bExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel.Workbook oWB;
            Microsoft.Office.Interop.Excel.Worksheet oWS;
            Microsoft.Office.Interop.Excel.Range oRng;

            oXL = new Microsoft.Office.Interop.Excel.Application();
            oXL.DisplayAlerts = false;
            oWB = oXL.Workbooks.Open(@"\\usrics01\gen_tl\shared\optitrak\internal_sales_orders.xls",
                     Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                     Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                     Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                     Missing.Value, Missing.Value);


            oWS = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Worksheets.get_Item("Sheet1");
            oRng = oWS.get_Range("A1", "J408");
            object[,] xlData;
            xlData = (System.Object[,])oRng.get_Value(misValue);
            //CEA_Serial_Number = xlData[1, 1].ToString().Trim();
            //Order_Number = xlData[10, 1].ToString().Trim();
            oXL.Quit();
                    
        }
    }
}
