using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace CalibrationManager
{
    public partial class f61_Review_Data : Form
    {
        SqlDataAdapter da;
        private string xtract = @"C:\calibration\Xtracted.pdf";
        
        public f61_Review_Data()
        {
            InitializeComponent();
        }

        private void f61_Review_Data_Load(object sender, EventArgs e)
        {
            this.Text = "f61 Review " + g.item;
            

            //if (g.task == "Review")
            //{
            //    bBack.Hide();
            //    this.ControlBox = false;
            //    this.WindowState = FormWindowState.Maximized;
            //}

            //if (g.task == "View" | g.item == "Cert" | 
            //    g.item == "Risk" | g.item == "Docs" | g.item == "Repair")
            //{
            //    bRejected.Hide();
            //    bDataAccepted.Hide();
            //    //this.Text = "View Data";
            //}
            
            SqlConnection cnxn = new SqlConnection(g.db);

            if (g.item != "Cert")
            {
                da = new SqlDataAdapter(
                    "Select " +
                    "ID as [Data Number], " +
                    "chg_date as [Log Date], " +
                    "currenthistory as [C=Current], " +
                    "Item as ID, " +
                    "Cal_Date, " +
                    "Cal_Int, " +
                    "Cal_Next, " +
                    "CalSource, " +
                    "calfee, " +
                    "pfbeforecal, " +
                    "pfaftercal, " +
                    "history1, " +
                    "history2, " +
                    "history3, " +
                    "Temp, " +
                    "Hum, " +
                    "Press, " +
                    "par1b4, " +
                    "par1pf, " +
                    "par1aft, " +
                    "par1cond, " +
                    "par2b4, " +
                    "par2pf, " +
                    "par2aft, " +
                    "par2cond, " +
                    "par3b4, " +
                    "par3pf, " +
                    "par3aft, " +
                    "par3cond, " +
                    "par4b4, " +
                    "par4pf, " +
                    "par4aft, " +
                    "par4cond, " +
                    "par5b4, " +
                    "par5pf, " +
                    "par5aft, " +
                    "par5cond, " +
                    "par6b4, " +
                    "par6pf, " +
                    "par6aft, " +
                    "par6cond, " +
                    "coract, " +
                    "RefStd1, " +
                    "RefStd1Date, " +
                    "RefStd2, " +
                    "RefStd2Date, " +
                    "CertNum, " +
                    "Measuncert, " +
                    "Limitations, " +
                    "Inspector, " +
                    "CalDate_Out, " +
                    "CalDate_In, " +
                    "CalTime_Days " +
                    "from calibrationdata where item = '" +
                    g.iID + "' order by currenthistory, [data number] desc", cnxn);
            }

            if (g.item == "Cert" | g.item == "Risk" | g.item == "Docs" | g.item == "Repair")
            {
                da = new SqlDataAdapter(
                    "Select " +
                    "ID as [Data Number], " +
                    "chg_date as [Log Date], " +
                    "currenthistory as [C=Current], " +
                    "Item " +
                    ",Cal_Date " +
                    ",CalSource " +
                    ",CertNum " +
                    ",Inspector " +
                    "from calibrationdata where " +
                    " yes" + g.item + "pdf = 'Y' and item = '" +
                    g.iID + "' order by currenthistory, [data number] desc", cnxn);
            }

            DataTable table = new DataTable();
            da.Fill(table);
            BindingSource bs = new BindingSource();
            bs.DataSource = table;
            DGV.DataSource = bs;
            DGV.Show();

            //if (g.task == "Review")
            //{
            //    foreach (DataGridViewColumn col in this.DGV.Columns)
            //    {
            //        col.SortMode = DataGridViewColumnSortMode.NotSortable;
            //    }
            //}

            BindingSource bs1 = new BindingSource();
            SqlConnection cnxn1 = new SqlConnection(g.db);
            SqlDataAdapter da1 = new SqlDataAdapter
                ("Select par1 as Parameter1,par1nom as [Parameter1 Nominal], " +
                 " par1um as [Parameter1 Unit of Measure], " +
                 " par1criteria as [Parameter1 Criteria], " +
                 " par2 as Parameter2,par2nom as [Parameter2 Nominal], " +
                 " par2um as [Parameter2 Unit of Measure], " +
                 " par2criteria as [Parameter2 Criteria], " +
                 " par3 as Parameter3,par3nom as [Parameter3 Nominal], " +
                 " par3um as [Parameter3 Unit of Measure], " +
                 " par3criteria as [Parameter3 Criteria], " +
                 " par4 as Parameter4,par4nom as [Parameter4 Nominal], " +
                 " par4um as [Parameter4 Unit of Measure], " +
                 " par4criteria as [Parameter4 Criteria], " +
                 " par5 as Parameter5,par5nom as [Parameter5 Nominal], " +
                 " par5um as [Parameter5 Unit of Measure], " +
                 " par5criteria as [Parameter5 Criteria] " +
                 " from equipment e" +
                 " where e.id = '" + g.iID + "'", cnxn1);
            DataTable table1 = new DataTable();
            da1.Fill(table1);
            bs1.DataSource = table1;
            dgv2.DataSource = bs1;
            dgv2.Show();
            
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 56)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.cdID = Convert.ToInt32(cell.EditedFormattedValue.ToString().Trim());

                if (g.item == "Cert" | g.item == "Risk" | g.item == "Docs" | g.item == "Repair")
                {
                    System.Diagnostics.Process pdfReader = new System.Diagnostics.Process();
                    SqlConnection cnxn = new SqlConnection(g.db);
                    SqlCommand cmd = new SqlCommand
                        ("Select " + g.item + "pdf from calibrationdata where id = " + g.cdID + "", cnxn);
                    cnxn.Open();
                    object o = cmd.ExecuteScalar();
                    cnxn.Close();
                    if (o != null)
                    {
                        cnxn = new SqlConnection(g.db);
                        cmd = new SqlCommand
                            (" select " + g.item + "pdf from calibrationdata where id = " + g.cdID + "");
                        cmd.Connection = cnxn;
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

                            pdfReader = System.Diagnostics.Process.Start(xtract);
                        }
                        dr.Close();
                        cnxn.Close();
                    }
                    //wait for the external process to complete and then 
                    //delete the file which was writen to be able to read the pdf.
                    if (pdfReader.HasExited == true)
                    {
                        File.Delete(xtract);
                    }
                }

                if (g.userType == "limited" | g.userType == "view")
                {
                    return;
                }
                
                if (g.item == "Data" & g.task != "Review")
                {
                    g.task = "Edit";
                    f60_Calibration_Data f6 = new f60_Calibration_Data();
                    f6.Show();
                    Close();
                }
            }
        }

        private void bDataAccepted_Click(object sender, EventArgs e)
        {
            g.task = g.taskhistory;
            Close();
        }

         private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bRejected_Click(object sender, EventArgs e)
        {
            DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[0].Cells[0];
            g.cdID = Convert.ToInt32(cell.EditedFormattedValue.ToString().Trim());
            g.task = "Edit";
            f60_Calibration_Data f60 = new f60_Calibration_Data();
            f60.Show();
            Close();
        }
    }
}