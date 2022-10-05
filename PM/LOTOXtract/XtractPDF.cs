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

namespace LOTOXtract
{
    public partial class XtractPDF : Form
    {
        SqlConnection cnxn;
        private string xtract = @"C:\pm\xtract.pdf";
        

        public XtractPDF()
        {
            InitializeComponent();
        }

        private void XtractPDF_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Process pdfReader = new System.Diagnostics.Process();

            cnxn = new SqlConnection("server = MIDSQL01; password = Read+Write!; " +
                                  "user = readWrite; database = PM_2015_A;");


            SqlCommand cmd = new SqlCommand
                    ("select p.loto, e.id,  e.EquipmentID from pmequip p  inner join equipment e " +
                    " on p.serial = e.EquipmentID where p.loto is not null  order by e.ID ");
            cmd.Connection = cnxn;
            cnxn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                // read in using GetValue and cast to byte array
                byte[] xData = (byte[])dr.GetValue(0);

                // develop path and title from database
                string id = dr.GetInt32(1).ToString();
                string title = dr.GetString(2).Trim();
                string rFile = "c:\\inetpub\\wwwroot\\zto\\app\\maintenance\\documents\\loto\\";

                rFile = rFile + id + "\\" + title + ".pdf";

                // write bytes to disk as file
                FileStream fs1 = new FileStream
                    (rFile, FileMode.Create, FileAccess.ReadWrite);
                BinaryWriter bw = new BinaryWriter(fs1);
                bw.Write(xData);
                bw.Close();
            }
            dr.Close();
            cnxn.Close();
        }
    }
}
