using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Get_Date_for_PCC
{
    public partial class TestBoolInsert : Form
    {
        private bool AD = true;
        private string fileName = "CE.00618041.ZMI-TEST-1.99999.xml";       
        
        public TestBoolInsert()
        {
            InitializeComponent();
        }

        private void TestBoolInsert_Load(object sender, EventArgs e)
        {

                    SqlConnection cnxn2 = new SqlConnection
                        ("server = midprj01; user = views; password = views; " +
                         "database = productioncontrol;");
                    SqlCommand cmd2 = new SqlCommand
                        ("Update [test data] " +
                        "set AD = '" + AD + "' where " +
                        "[xml file name] = '" + fileName + "'");
                    cmd2.Connection = cnxn2;
                    cnxn2.Open();
                    cmd2.ExecuteNonQuery();
                    cnxn2.Close();


            
        }
    }
}