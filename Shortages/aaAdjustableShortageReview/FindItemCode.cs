using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace aaAdjustableShortageReview
{
    public partial class FindItemCode : Form
    {
        SqlConnection cnxn;
        SqlCommand cmd;
        SqlDataReader dr;
        private string UserName;
        private int LogID;

        public FindItemCode()
        {
            InitializeComponent();
        }

        private void FindItemCode_Load(object sender, EventArgs e)
        {
            this.Text = "Select Task - Shortage Manager v" + Application.ProductVersion;

            cnxn = new SqlConnection(g.db);
            cnxn.Open();

            System.Security.Principal.WindowsIdentity userBase;
            userBase = System.Security.Principal.WindowsIdentity.GetCurrent();

            if (userBase.Name.IndexOf("Z") == 0)
            {
                UserName = userBase.Name.Replace("ZYGOMIS\\", "");
            }
            else
            {
                UserName = userBase.Name.Replace("AMETEK-AD\\", "");
            }
            string computername = Environment.MachineName;

            SqlParameter pUserName = new SqlParameter("@pUserName", SqlDbType.VarChar);
            pUserName.Value = UserName;

            SqlParameter pLogID = new SqlParameter("@LogID", SqlDbType.Int);
            pLogID.Direction = ParameterDirection.Output;

            cmd = new SqlCommand(
                "Insert into ApplicationUseLog (" +
                " PCID " +
                ",UserName " +
                ",Application " +
                ",LogON " +
                ",Location " +
                ")values('" +
                computername + "', " +
                pUserName + ", " +
                "'ShortageManager','" +
                DateTime.Now + "'," +
                "'ZAMS') SET @LogID = SCOPE_IDENTITY() ", cnxn);

            cmd.Parameters.Add(pUserName);
            cmd.Parameters.Add(pLogID);
                        
            try
            {
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();
                LogID = (int)cmd.Parameters["@LogID"].Value;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cmd.Parameters.Clear();
                cnxn.Close();
            }

            cmd = new SqlCommand
            (" Select ItemCode [Item Code], ProductLine Line, PlannerRequiredDate [Required Date],  ID " +
             " FROM shortage_list " +
             " WHERE DateArchived IS NULL " +
             " ORDER BY ItemCode, ID ", cnxn);

            DataTable table = new DataTable();

            try
            {
                cnxn.Open();
                cmd.CommandTimeout = 300;
                dr = cmd.ExecuteReader();
                table.Load(dr);
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

            DGV.Columns[0].Width = 120;
            DGV.Columns[1].Width = 50;
            DGV.Columns[2].Width = 90;
            DGV.Columns[3].Width = 50;

            DGV.Show();

            //this works better than focus()
            tbSearch.Select();
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 4)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[3];
                g.ShortageID = cell.EditedFormattedValue.ToString().Trim();

                cmd = new SqlCommand
                ("Select productline from Shortage_List  " +
                "where id = " + g.ShortageID + " ", cnxn);
                try
                {
                    cnxn.Open();
                    cmd.CommandTimeout = 300;
                    object o = cmd.ExecuteScalar();

                    if (o == null)
                    {
                        MessageBox.Show("This ID does not exist.");
                        tbSearch.Focus();
                    }
                    else
                    {
                        g.ProductLine = o.ToString();
                        g.task = "EDIT";
                        AdjustableReview r = new AdjustableReview();
                        r.ShowDialog();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn.Close();
                }
            }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            cmd = new SqlCommand
            (" Select ItemCode [Item Code], ProductLine Line, PlannerRequiredDate,  ID " +
             " FROM shortage_list " +
             " WHERE DateArchived IS NULL AND ItemCode like '%" + tbSearch.Text + "%' " +
             " ORDER BY ItemCode, ID ", cnxn);

            DataTable table = new DataTable();

            try
            {
                cnxn.Open();
                cmd.CommandTimeout = 300;
                dr = cmd.ExecuteReader();
                table.Load(dr);
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
            tbSearch.Text = "";
        }

        private void bItem_Click(object sender, EventArgs e)
        {
            g.ShortageID = tbSearch.Text.ToString().Trim().ToUpper();
            tbSearch.Text = "";

            cmd = new SqlCommand
                ("Select productline from Shortage_List  " +
                "where id = " + g.ShortageID + " ", cnxn);
 
            try
            {
                cnxn.Open();
                cmd.CommandTimeout = 300;
                object o = cmd.ExecuteScalar();

                if (o == null)
                {
                    MessageBox.Show("This ID does not exist.");
                    tbSearch.Focus();
                }
                else
                {
                    g.ProductLine = o.ToString();
                    g.task = "EDIT";
                    AdjustableReview r = new AdjustableReview();
                    r.Show();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }
        }

        private void bINST_Click(object sender, EventArgs e)
        {
            g.task = "REVIEW";
            g.ProductLine = "INST";
            AdjustableReview r = new AdjustableReview();
            r.Show();
        }

        private void bPPS_Click(object sender, EventArgs e)
        {
            g.task = "REVIEW";
            g.ProductLine = "PPS";
            AdjustableReview r = new AdjustableReview();
            r.Show();
        }

        private void bOPTICS_Click(object sender, EventArgs e)
        {
            g.task = "REVIEW";
            g.ProductLine = "OPT";
            AdjustableReview r = new AdjustableReview();
            r.Show();
        }


        private void bZEOS_Click(object sender, EventArgs e)
        {
            g.task = "REVIEW";
            g.ProductLine = "ZEOS";
            AdjustableReview r = new AdjustableReview();
            r.Show();
        }

        private void bWarRoom_Click(object sender, EventArgs e)
        {
            g.task = "REVIEW";
            g.ProductLine = "SERrpt";
            AdjustableReview r = new AdjustableReview();
            r.Show();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            Add a = new Add();
            a.Show();
        }

        private void FindItemCode_FormClosed(object sender, FormClosedEventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            cnxn.Open();

            System.Security.Principal.WindowsIdentity userBase;
            userBase = System.Security.Principal.WindowsIdentity.GetCurrent();

            UserName = userBase.Name.Replace("ZYGOMIS\\", "");
            string computername = Environment.MachineName;

            SqlParameter pUserName = new SqlParameter("@pUserName", SqlDbType.VarChar);
            pUserName.Value = UserName;

           

            SqlCommand cmd = new SqlCommand(
                "Update ApplicationUseLog set" +
                " LogOFF = '" +
                DateTime.Now +  
                "' WHERE ID = " + LogID + "", cnxn);

            try
            {
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();
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
        }

        private void Binstreport_Click(object sender, EventArgs e)
        {
            g.ProductLine = "INST";
            PrintedReport r = new PrintedReport();
            r.ShowDialog();
        }

        private void Bppsreport_Click(object sender, EventArgs e)
        {
            g.ProductLine = "PPS";
            PrintedReport r = new PrintedReport();
            r.ShowDialog();
        }

        private void Bopticsreport_Click(object sender, EventArgs e)
        {
            g.ProductLine = "OPT";
            PrintedReport r = new PrintedReport();
            r.ShowDialog();
        }

        private void Bzeosreport_Click(object sender, EventArgs e)
        {
            g.ProductLine = "ZEOS";
            PrintedReport r = new PrintedReport();
            r.ShowDialog();
        }

        private void bSERreport_Click(object sender, EventArgs e)
        {
            //SERreport r = new SERreport();
            //r.ShowDialog();
            g.ProductLine = "SERrpt";
            PrintedReport r = new PrintedReport();
            r.ShowDialog();
        }

        private void bEPO_Click(object sender, EventArgs e)
        {
            g.task = "REVIEW";
            g.ProductLine = "EPO";
            AdjustableReview r = new AdjustableReview();
            r.Show();
        }

        private void bEPOreport_Click(object sender, EventArgs e)
        {
            g.ProductLine = "EPO";
            PrintedReport r = new PrintedReport();
            r.ShowDialog();
        }
    }

}
 