using System.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection cnxn;
        SqlCommand cmd;
        SqlDataReader dr;
        private string xtract = @"C:\pm\xtract.pdf";
        private string dxtract = @"C:\pm\";
        private bool requestCompleted;
        private double FabHours;
        private double DesignHours;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process pdfReader = new System.Diagnostics.Process();

            cnxn = new SqlConnection("server = ct-mid-sql11; password = Read+Write!; " +
                                  "user = readwrite; database = AccessFrontEnds;");

            cmd = new SqlCommand
                ("Select uploaded_pdf from richmond_tool_requests where id = '28' and uploaded_pdf is not null", cnxn);
            cnxn.Open();
            object o = cmd.ExecuteScalar();
            cnxn.Close();
            if (o != null)
            {
                cmd = new SqlCommand
                    ("Select uploaded_pdf from richmond_tool_requests where id = '28' and uploaded_pdf is not null", cnxn);
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