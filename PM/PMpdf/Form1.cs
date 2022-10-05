using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using PMpdfDLL;

namespace PMpdf
{
    public partial class Form1 : Form
    {
        //SqlDataAdapter da;
        //private string xtract = @"C:\pm\Xtracted.pdf";
        //private string pdf;

        public Form1()
        {
            InitializeComponent();
            //pdf = Pdf;
        }

        //public Form1(string PDF)
        //{
        //    InitializeComponent();
        //    pdf = PDF;
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            string test = PMpdfDLL.pdfView.Input("NC005");
            
            //System.Diagnostics.Process pdfReader = new System.Diagnostics.Process();
            //SqlConnection cnxn = new SqlConnection("server = midprj01; user = views; password = views;" +
            //    "database= logsheetsdb;");
            //SqlCommand cmd = new SqlCommand
            //    ("Select LOTO from pmequip where serial = '" + pdf + "'", cnxn);
            //cnxn.Open();
            //object o = cmd.ExecuteScalar();
            //cnxn.Close();
            //if (o != null)
            //{
            //    cnxn = new SqlConnection("server = midprj01; user = views; password = views;" +
            //                             "database= logsheetsdb;");
            //    cmd = new SqlCommand
            //        ("select LOTO from pmequip where serial = '" + pdf + "'");
            //    cmd.Connection = cnxn;
            //    cnxn.Open();

            //    SqlDataReader dr = cmd.ExecuteReader();

            //    while (dr.Read())
            //    {
            //        // read in using GetValue and cast to byte array
            //        byte[] xData = (byte[])dr.GetValue(0);

            //        // write bytes to disk as file
            //        FileStream fs1 = new FileStream
            //            (xtract, FileMode.Create, FileAccess.ReadWrite);
            //        BinaryWriter bw = new BinaryWriter(fs1);
            //        bw.Write(xData);
            //        bw.Close();

            //        pdfReader = System.Diagnostics.Process.Start(xtract);
            //    }
            //    dr.Close();
            //    cnxn.Close();
            //    this.Close();
            //}
        }
    }
}
