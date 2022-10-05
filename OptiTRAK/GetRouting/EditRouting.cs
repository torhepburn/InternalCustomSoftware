using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Interop.Word;
using System.Data.SqlClient;

namespace GetRouting
{
    /*  General outline 02/25/2016:
     
        1.	Select SFO in first window.
        2.	Insert into tblWorkIns 
               DeptID, OpNum from MMX_Production_Planning_By_Order, 
               Description from MMX_Tasks, 
               JobID from tblPartSn 
               based on SFO.
        3.	Select Traveler from file window
        4.	Extract OpNum, Description, CycleDays from traveler.
        5.	Update tblWorkIns with Description and CycleDays 
            when OpNumber is equal in both files.
    */

    public partial class EditRouting : Form
    {
        SqlConnection cnxn;
        private string text;
        private string opNumber;

        public EditRouting()
        {
            InitializeComponent();
        }

        private void EditRouting_Load(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory =
                @"\\usrics01\gen_tl\departments\pc\travelers\";
            openFileDialog1.ShowDialog();
            string here = openFileDialog1.FileName.ToUpper();
            /* SafeFileName does not include the path, FileName includes the path */
            string justname = openFileDialog1.SafeFileName.ToUpper();

            if ( justname.LastIndexOf(g.customer.ToUpper()) < 0)
            {
                MessageBox.Show("Are you sure you have the right traveler?" +
                    "\n\n Customer does not appear in title");
                g.StepFlag = false;
                return;
            }
            else
            {
                g.StepFlag = true;
            }

            cnxn = new SqlConnection(g.db);
            
            Microsoft.Office.Interop.Word.Application w = new Microsoft.Office.Interop.Word.Application();
            w.Visible = false;
            Document d = w.Documents.Open(here);

            int count = d.Words.Count;
            for (int i = 1; i <= count; i++)
            {
                text += d.Words[i].Text;
            }

            object SaveOption = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
            object originalFormat = Microsoft.Office.Interop.Word.WdOriginalFormat.wdOriginalDocumentFormat;
            object routeDocument = false;


            w.Documents.Close(ref SaveOption, ref originalFormat, ref routeDocument);
            w.Quit(Type.Missing, Type.Missing, Type.Missing);


            text = text.Substring(0, text.Length - (text.Length - (text.LastIndexOf("TOTALS"))));
            int a = (text.IndexOf("\r\a")+2);
            if ( text.Substring(0,1) == " ")
            {
                opNumber = text.Substring(1, (text.IndexOf("\r\a") - 1));
            }
            else
            {
                opNumber = text.Substring(0, text.IndexOf("\r\a") );
            }
            
            string c = text.Substring(a, 5);
            text = text.Substring((text.IndexOf("\r\a") + 2), text.Length - (text.IndexOf("\r\a") + 2));
            text = text.Substring((text.IndexOf("\r\a") + 2), text.Length - (text.IndexOf("\r\a") + 2));
            string opDescription = text.Substring(0, text.IndexOf("\r\a"));
            for (int n = 1; n < 6; n++)
            {
                text = text.Substring((text.IndexOf("\r\a") + 2), text.Length - (text.IndexOf("\r\a") + 2));
            }
            string cycleTime = text.Substring(0, text.IndexOf("\r\a"));

            SqlCommand cmd = new SqlCommand(
                    "insert into optemp (opnum, description, cycledays) values (" + opNumber + ",'" + opDescription + 
                    "'," + cycleTime + ")", cnxn);
            cnxn.Open();
            cmd.ExecuteNonQuery();
            cnxn.Close();

            try
            {
                while (text.Length > 50)
                {
                    for (int n = 1; n < 3; n++)
                    {
                        text = text.Substring((text.IndexOf("\r\a") + 2), text.Length - (text.IndexOf("\r\a") + 2));
                    }

                    string opNumber2 = text.Substring(0, text.IndexOf("\r\a"));
                    text = text.Substring((text.IndexOf("\r\a") + 2), text.Length - (text.IndexOf("\r\a") + 2));
                    text = text.Substring((text.IndexOf("\r\a") + 2), text.Length - (text.IndexOf("\r\a") + 2));
                    string opDescription2 = text.Substring(0, text.IndexOf("\r\a"));

                    for (int n = 1; n < 6; n++)
                    {
                        text = text.Substring((text.IndexOf("\r\a") + 2), text.Length - (text.IndexOf("\r\a") + 2));
                    }
                    string cycleTime2 = text.Substring(0, text.IndexOf("\r\a"));


                    cmd = new SqlCommand(
                        "insert into optemp (opnum, description, cycledays) values (" + opNumber2 + ",'" + 
                        opDescription2 + "'," + cycleTime2 + ")", cnxn);
                    cnxn.Open();
                    cmd.ExecuteNonQuery();
                    cnxn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            try 
            {
                cmd = new SqlCommand(
                "Update tblWorkIns " +
                //"Update WItemp " +
                "set Description = o.Description, " +
                "CycleDays = o.CycleDays " +
                "from tblWorkIns w " +
                //"from WItemp w " +
                "inner join optemp o on " +
                "w.opnum = o.opnum " +
                "where w.jobid = " + g.job.ToString() + " ", cnxn);

                cnxn.Open();
                cmd.ExecuteNonQuery();
                cnxn.Close();

                cmd = new SqlCommand(
                        "delete from optemp", cnxn);
                cnxn.Open();
                cmd.ExecuteNonQuery();
                cnxn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            
            Close();
        }
    }
}
