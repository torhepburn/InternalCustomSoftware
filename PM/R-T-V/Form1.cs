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

namespace R_T_V
{
    public partial class Form1 : Form
    {
        private string xtract = @"C:\pm\xtract.pdf";
        private string dxtract = @"C:\pm\";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Process pdfReader = new System.Diagnostics.Process();

            SqlConnection cnxn = new SqlConnection("server = ct-mid-sql11; password = Read+Write!; " +
                                  "user = readwrite; database = AccessFrontEnds;");
            
            SqlCommand cmd = new SqlCommand
                ("Select uploaded_pdf from Richmond_tool_requests where id = '30' and uploaded_pdf is not null", cnxn);
            cnxn.Open();
            object o = cmd.ExecuteScalar();
            cnxn.Close();
            if (o != null)
            {
                cmd = new SqlCommand
                    ("Select uploaded_pdf from Richmond_tool_requests where id = '30' and uploaded_pdf is not null", cnxn);
                cnxn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    // read in using GetValue and cast to byte array
                    byte[] xData = (byte[])dr.GetValue(0);

                    // write bytes to disk as file
                    FileStream fs1 = new FileStream
                        (xtract, FileMode.Create, FileAccess.ReadWrite);
                    BinaryWriter bw = new BinaryWriter(fs1);
                    bw.Write(xData);
                    bw.Close();
                    /*
                     *  P.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            P.StartInfo.UseShellExecute = false;
            P.StartInfo.RedirectStandardOutput = true;
            P.StartInfo.CreateNoWindow = true;
            P.StartInfo.RedirectStandardError = true;
                     * */
                    pdfReader.StartInfo.UseShellExecute = false;
                    pdfReader = System.Diagnostics.Process.Start(xtract);
                }
                dr.Close();
                cnxn.Close();

            }
            else
            {
                MessageBox.Show("No pdf documents were attached.");
            }
        }
    }
}
