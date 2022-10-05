using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;

namespace PMpdfDLL
{
    public class pdfView
    {
        //private string xtract = @"C:\pm\xtract.pdf";

        public static string Input(string pdf)
        {
            System.Diagnostics.Process pdfReader = new System.Diagnostics.Process();
            SqlConnection cnxn = new SqlConnection("server = CT-MID-SQL11; user = views; password = views;" +
                "database= Maintenance;");
            SqlCommand cmd = new SqlCommand
                ("Select LOTO from pmequip where serial = '" + pdf + "'", cnxn);
            cnxn.Open();
            object o = cmd.ExecuteScalar();
            cnxn.Close();
            
            if (o != null)
            {
                cmd = new SqlCommand
                    ("select LOTO from pmequip where serial = '" + pdf + "'");
                cmd.Connection = cnxn;
                cnxn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    // read in using GetValue and cast to byte array
                    byte[] xData = (byte[])dr.GetValue(0);

                    // write bytes to disk as file
                    string xtract = @"C:\pm\xtract.pdf";
                    FileStream fs1 = new FileStream
                        (xtract, FileMode.Create, FileAccess.ReadWrite);
                    BinaryWriter bw = new BinaryWriter(fs1);
                    bw.Write(xData);
                    bw.Close();

                    pdfReader = System.Diagnostics.Process.Start(xtract);
                }
                dr.Close();
                cnxn.Close();

                
            }
            return "done";

        }

    }
}
