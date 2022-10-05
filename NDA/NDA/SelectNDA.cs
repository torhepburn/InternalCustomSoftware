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

namespace NDA
{
    public partial class SelectNDA : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        DataTable table;
        private string rootSql = " SELECT " +
                                 " NDA_ID " +
                                 ",Company " +
                                 ",CompanyContact " +
                                 ",DateRcvd " +
                                 ",Status " +
                                 ", CASE " +
                                    "WHEN STOREDpdf = 1 THEN 'YES' " +
                                    "ELSE 'NO' " +
                                " END AS [PDF Filed] " +
                                 "FROM NDA WHERE 1=1 ";
        private string xtract = @"C:\Zygo\Xtracted.pdf";

        public SelectNDA()
        {
            InitializeComponent();
        }

        private void SelectNDA_Load(object sender, EventArgs e)
        {
            if (g.Task == "ProcurementEDIT")
            {
                rootSql = rootSql + "AND procurement = 1 ";
                Badd.Visible = false;
                BviewPDF.Visible = false;
                BDelete.Visible = false;
            }
            GridData();
        }

        private void GridData()
        {
            cnxn = new SqlConnection(g.db);

            try
            {
                cnxn.Open();
                da = new SqlDataAdapter(
                    rootSql + "order by NDA_ID "
                    , cnxn);
                table = new DataTable();
                da.Fill(table);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            DGV.DataSource = table;
            DGV.Show();
            DGV.Columns[0].Width = 50;
            DGV.Columns[1].Width = 250;
            DGV.Columns[2].Width = 150;
            DGV.Columns[2].Width = 150;

            ColorCoding();
        }

        private void ColorCoding()
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (row.Cells[4].Value.ToString().Trim() == "Expired")
                {
                    row.DefaultCellStyle.BackColor = Color.LightSalmon;
                }

                if (row.Cells[4].Value.ToString().Trim() == "Filed")
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }

                if (row.Cells[4].Value.ToString().Trim() == "Dead Issue")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(180, 180, 180);
                }
            }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            string search = tbSearchPartNumber.Text.Replace("'", "''");
            da = new SqlDataAdapter
                (rootSql +
                 " AND Company like '%" + search + "%' " +
                 "or CompanyContact like '%" + search + "%' " +
                 "or ZygoContact like '%" + search + "%' " +
                 " order by NDA_ID", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;

            ColorCoding();
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 5)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.NDA_ID = cell.EditedFormattedValue.ToString().Trim();

                if (g.Task == "DELETE")
                {

                    DialogResult result = MessageBox.Show("Are you sure you want to delete NDA " + g.NDA_ID + " ?", "",
                        MessageBoxButtons.YesNo);

                    if (result == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        try
                        {
                            cnxn.Open();
                            SqlCommand cmd = new SqlCommand(
                                "DELETE FROM NDA where NDA_ID = " + g.NDA_ID
                                , cnxn);
                            cmd.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        finally
                        {
                            cnxn.Close();
                        }

                        GridData();
                    }
                }
                else if (g.Task == "PDF")
                {
                    {
                        System.Diagnostics.Process pdfReader = new System.Diagnostics.Process();
                        SqlConnection cnxn = new SqlConnection(g.db);
                        SqlCommand cmd = new SqlCommand
                            ("Select pdf from NDA WHERE NDA_ID = " + g.NDA_ID + "", cnxn);
                        cnxn.Open();
                        object o = cmd.ExecuteScalar();
                        cnxn.Close();
                        if (o != null)
                        {
                            cnxn = new SqlConnection(g.db);
                            cmd = new SqlCommand
                                ("Select pdf from NDA WHERE NDA_ID = " + g.NDA_ID + "", cnxn);
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

                        BviewPDF.BackColor = Color.FromArgb(160, 140, 205);
                        BviewPDF.ForeColor = Color.FromArgb(0, 0, 0);
                        g.Task = string.Empty;
                    }
                }

                else
                {
                    if (g.Task != "ProcurementEDIT")
                    {
                        g.Task = "EDIT";
                    }
                    
                    DataEntryForm d = new DataEntryForm();
                    d.ShowDialog(this);
                }
            }
        }

        private void Badd_Click(object sender, EventArgs e)
        {
            g.Task = "ADD";

            cnxn = new SqlConnection(g.db);
            cnxn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnxn;
            cmd.CommandText = "spGetInsertedID";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter NewID = new SqlParameter("@InsertID", SqlDbType.Int);
            NewID.Direction = ParameterDirection.Output;
            NewID.Value = 0;

            cmd.Parameters.Add(NewID);

            try
            {
                cmd.ExecuteNonQuery();

                g.NDA_ID = NewID.Value.ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
                cmd.Parameters.Clear();
            }

            DataEntryForm d = new DataEntryForm();
            d.ShowDialog(this);
        }

        private void BDelete_Click(object sender, EventArgs e)
        {
            g.Task = "DELETE";
            BDelete.BackColor = Color.FromArgb(200, 200, 200);
            BDelete.ForeColor = Color.FromArgb(0, 0, 0);
        }

        private void DGV_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ColorCoding();
        }

        private void BviewPDF_Click(object sender, EventArgs e)
        {
            g.Task = "PDF";
            BviewPDF.BackColor = Color.FromArgb(150, 50, 150);
            BviewPDF.ForeColor = Color.FromArgb(250, 250, 250);
        }
    }

    public static class g
    {
        public static string user;
        public static string NDA_ID;
        public static string Task;
        public static string userType;
        public static string dbNAV = "server = PA-HOR-AS408; Database = ZYGO-NAV-PROD; " +
                            "user = navdb_read; password = 2018#ameteK;";
                public static string dbDash = "server = MIDDB01.zygo.com; Database = Dashboard; " +
                            "user = views; password = views;";
        public static string db = "server = CT-MID-SQL11; Database = ZygoNonDisclosureAgreements; " +
                            "user = NdaAdmin; password = $ecur1Ty;";
    }
}
