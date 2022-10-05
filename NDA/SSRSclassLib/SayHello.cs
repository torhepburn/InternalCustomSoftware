using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;



namespace SSRSclassLib
{
    public class SayHello
    {
        static string a;
        static string b;
        static string c;

        public static string Hello(string id)
        {
            SqlConnection cnxn = new SqlConnection("server = CT-MID-SQL01; Database = ZygoNonDisclosureAgreements; " +
                            "user = NdaAdmin; password = $ecur1Ty;");
            
            SqlCommand cmd = new SqlCommand("Select pdf from NDA WHERE NDA_ID = " + id + "", cnxn);
            
            try
            {
                cnxn.Open();
            }
            catch (SqlException ex)
            {
                a = "a " + ex.ToString();
                File.WriteAllText(@"C:\A\zz.txt", "Cnxn.Open problem  " + ex.ToString() + Environment.NewLine);
            }
            
            string xtract = @"C:\A\xtracted.pdf";

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    // read in using GetValue and cast to byte array
                    byte[] xData = (byte[])dr.GetValue(0);

                    File.AppendAllText(@"C:\A\zz.txt", "  " + xData.Length.ToString());

                    b = xData.Length.ToString();
                    //string xtract = @"\\midiis\intetpub\wwwroot\xtracted.pdf";
                    //string xtract = @"C:\A\xtracted.pdf";


                    // write bytes to disk as file
                    FileStream fs1 = new FileStream
                        (xtract, FileMode.Create, FileAccess.ReadWrite);
                    BinaryWriter bw = new BinaryWriter(fs1);
                    bw.Write(xData);
                    bw.Close();
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                File.AppendAllText(@"C:\A\zz.txt", ex.ToString());
                c = "c" + ex.ToString();
            }
            finally
            {
                cnxn.Close();
            }


            //try
            //{
            //    System.Diagnostics.Process pdfReader = new System.Diagnostics.Process();
            //    pdfReader = System.Diagnostics.Process.Start(xtract);
            //}
            //catch (Exception e)
            //{
            //    File.AppendAllText(@"C:\A\zz.txt", "pdf " + e.ToString());
            //}
            //wait for the external process to complete and then 
            //delete the file which was writen to be able to read the pdf.

            //if (pdfReader.HasExited == true)
            //{
            //    File.Delete(xtract);
            //    File.AppendAllText(@"C:\A\zz.txt", "Tried to Delete");
            //}

            return "";
        }
    }
}
