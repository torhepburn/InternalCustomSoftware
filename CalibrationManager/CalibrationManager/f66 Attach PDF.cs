using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace CalibrationManager
{
    public partial class f66_Attach_PDF : Form
    {
        private string pdf;
        
        public f66_Attach_PDF()
        {
            InitializeComponent();
        }

        private void f66_Attach_PDF_Load(object sender, EventArgs e)
        {
           
        }

        private void bCert_Click(object sender, EventArgs e)
        {
            pdf = "Cert";
            processPDF();
        }

        private void bRisk_Click(object sender, EventArgs e)
        {
            pdf = "Risk";
            processPDF();
        }

        private void bDocs_Click(object sender, EventArgs e)
        {
            pdf = "Docs";
            processPDF();
        }

        private void bRepair_Click(object sender, EventArgs e)
        {
            pdf = "Repair";
            processPDF();
        }

        private void processPDF()
        {
            openFileDialog1.ShowDialog();
            string filePath = openFileDialog1.FileName;

            FileStream fs = new FileStream
                (filePath, FileMode.Open, FileAccess.Read);

            // store the file in an array the length of the file
            byte[] fileData = new byte[fs.Length];

            // read the file stream to the array
            fs.Read(fileData, 0, Convert.ToInt32(fs.Length));
            
            SqlConnection cnxn = new SqlConnection(g.db);
            SqlParameter prm1 = new SqlParameter
                ("@file", SqlDbType.Image, Convert.ToInt32(fs.Length));
            prm1.Value = fileData;

            SqlCommand cmd = new SqlCommand
                ("Update Calibrationdata set " + pdf + "pdf = " + prm1 +
                 " , yes" + pdf + "pdf = 'Y' " +
                 " where id = '" + g.cdID + "' ");
            cmd.Parameters.Add(prm1);
            cmd.Connection = cnxn;
            cnxn.Open();
            cmd.ExecuteNonQuery();
            cnxn.Close();
            fs.Close();
            // close the file stream

            cnxn = new SqlConnection(g.db);
            cmd = new SqlCommand
                ("Select " + pdf + "pdf from calibrationdata " +
                 " where id = '" + g.cdID + "' ", cnxn);

            cnxn.Open();
            object o = cmd.ExecuteScalar();
            if (o != null)
            {
                DialogResult result;
                result = MessageBox.Show(" PDF created.");
            }
            cnxn.Close();

            Close();
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}