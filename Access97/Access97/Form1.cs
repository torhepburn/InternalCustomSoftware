using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Access97
{
    public partial class Form1 : Form
    {
        OleDbConnection cxn;
        OleDbDataAdapter da;
        BindingSource bs = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string db = "provider=microsoft.jet.oledb.4.0;  " +
                         "data source=C:\\Documents and " +
                         "Settings\\bsilvert\\Desktop\\TOOLING\\CNCTOOLS97.MDB;";

            //string db2 = "provider=microsoft.jet.oledb.4.0;  " +
            //             "data source=C:\\Documents and " +
                         //"Settings\\bsilvert\\Desktop\\TOOLING\\test TOOLING.mdb;";
            string db2 = "provider=microsoft.jet.oledb.4.0;  " +
                         "data source=C:\\Users\\thepburn\\Desktop\\Emplrost.accdb;";

            cxn = new OleDbConnection(db);
            dgv.Show();
            dgv.DataSource = bs;

            try
            {
                string select = ("Select * from cnc_bevl  where [serial number] > 5055 order by [serial #] asc");

                DataSet ds = new DataSet();

                da = new OleDbDataAdapter(select, cxn);

                DataTable table = new DataTable();

                da.Fill(table);
                bs.DataSource = table;

            }

            catch(OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }

            cxn.Open();

            OleDbCommand cmd = new OleDbCommand("Select * from cnc_bevl " +
                "where [serial number] > 5055 order by [serial number] asc", cxn);



            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Int16 sn = dr.GetInt16(0);
                    //object a = dr.GetFieldType(1);
                    //object b = dr.GetFieldType(2);
                    //object c = dr.GetFieldType(3);
                    //object d = dr.GetFieldType(4);
                    Single dia = dr.GetFloat(1);
                    Single len = dr.GetFloat(2);
                    Single angle = dr.GetFloat(3);
                    //Single nose = dr.GetFloat(4);
                    Int16 grit = dr.GetInt16(4);

                    cxn = new OleDbConnection(db2);

                    cmd = new OleDbCommand("Insert into [cnc_bevl 5,000 - 5,999] " +
                        "([s/n],dia, [usable length], flat, grit) " +
                        "values ( " +
                        sn + "," +
                        dia + "," +
                        len + "," +
                      //  angle + "," +
                        angle + "," +
                        grit + ")");

                    cmd.Connection = cxn;
                    cxn.Open();
                    int rowsReturned = cmd.ExecuteNonQuery();
                    cxn.Close();
                }
            }
            


            ////int temp = cmd.ExecuteNonQuery();
            cxn.Close();


        }
    }
}