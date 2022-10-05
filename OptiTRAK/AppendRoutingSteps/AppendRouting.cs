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
using Microsoft.Office.Interop.Word;

namespace AppendRoutingSteps
{
    public partial class AppendRouting : Form
    {
        SqlCommand cmd;
        SqlConnection cnxn;
        private string text;
        private string opNumber;
        private int opcountMK;
        private int opcountNEW;
        private int OTstepMax;

        public AppendRouting()
        {
            InitializeComponent();
        }

        private void AppendRouting_Load(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory =
                @"\\usrics01\gen_tl\departments\pc\travelers\";
            openFileDialog1.ShowDialog();
            string here = openFileDialog1.FileName.ToUpper();

            if( here.LastIndexOf(g.customer.ToUpper()) < 0)
            {
                MessageBox.Show("Are you sure you have the right traveler?" +
                    "\n\n Customer does not appear in title.");
                g.StepFlag = false;
                return;
            }
            else
            {
                g.StepFlag = true;
            }

            cnxn = new SqlConnection(g.db);
            
            Microsoft.Office.Interop.Word.Application w = new Microsoft.Office.Interop.Word.Application();
            w.Visible = true;
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
            ((_Application)w).Quit(Type.Missing, Type.Missing, Type.Missing);


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

            try
            {
                SqlCommand cmd = new SqlCommand(
                        "insert into optemp (opnum, description, cycledays) values (" + opNumber + ",'" + opDescription +
                        "'," + cycleTime + ")", cnxn);
                cnxn.Open();
                cmd.ExecuteNonQuery();
                cnxn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

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
                return;
            }

            //check number of operations in MK and proposed new are the same

            try
            {
                cmd = new SqlCommand("select count(opnum) from optemp ", cnxn);

                cnxn.Open();
                opcountNEW = (int)cmd.ExecuteScalar();
                cnxn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }

            try
            {
                cmd = new SqlCommand(
                    "select count(operation) from " +
                    "AccessFrontEnds.dbo.MMX_PRODUCTION_PLANNING_BY_ORDER o " +
                    "where order_no = " + g.SFO + " ", cnxn);

                cnxn.Open();
                opcountMK = (int)cmd.ExecuteScalar();
                cnxn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }

            if (opcountNEW != opcountMK)
            {
                MessageBox.Show("Must enter steps in MK before importing traveller." +
                    "\n\r\n\rTraveller and MK must have same number of steps.");
                return;
            }
            else
            {
                //find max step in OptiTRAK
                try
                {
                    cmd = new SqlCommand(
                        "select opnum from tblWorkIns " +
                        "where JobID = " + g.job.ToString() + " " +
                        "order by opnum desc ", cnxn);

                    cnxn.Open();
                    OTstepMax = (int)cmd.ExecuteScalar();
                    cnxn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
                //add steps from MK greater than OptiTRAK max step

                cmd = new SqlCommand(
                        "insert into tblWorkIns (jobid,deptid, opnum, description, CycleDays) " +
                        //"insert into WItemp (jobid,deptid, opnum, description, CycleDays) " +
                        "select 999999, deptid, operation, t.description, 0 from " +
                        "AccessFrontEnds.dbo.MMX_PRODUCTION_PLANNING_BY_ORDER o " +
                        "left join tblDept d " +
                        "on o.Work_Center = d.deptcode " +
                        "left join accessfrontends.dbo.mmx_tasks t " +
                        "on o.task = t.TASK " +
                        "where ORDER_NO =  " + g.SFO + " " +
                        "and operation > " + OTstepMax + " " +
                        "order by operation", cnxn);

                try
                {
                    cnxn.Open();
                    cmd.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }

                try
                {
                    cmd = new SqlCommand(
                        "update tblWorkIns set jobid = " + g.job.ToString() + " where jobid = 999999", cnxn);
                        //"update WItemp set jobid = " + g.job.ToString() + " where jobid = 999999", cnxn);
                    cmd.ExecuteNonQuery();
                    cnxn.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
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
                    return;
                }

                //add new steps to schedule
                try
                {
                    cmd = new SqlCommand();
                    cmd.CommandText = "spAppendStepsToScheduleStatus";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = cnxn;
                    cnxn.Open();
                    cmd.ExecuteNonQuery();
                    cnxn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }

                //end of else loop where mk and new have same number of steps
            }

            Close();
        }
    }
}
