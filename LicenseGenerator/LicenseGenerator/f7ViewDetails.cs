using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LicenseGenerator
{
    public partial class f7ViewDetails : Form
    {
        SqlConnection cnxn;
        SqlDataReader dr;
        SqlCommand cmd;
        
        public f7ViewDetails()
        {
            InitializeComponent();
        }

        private void f7ViewDetails_Load(object sender, EventArgs e)
        {
            ToolTip tt2 = new ToolTip();
            tt2.SetToolTip(bSearch, "Can search for DongleID, Sales Order, or Owner");
            
            cnxn = new SqlConnection(g.db);
            cnxn.Open();
            if (g.task == "Show All")
            {
                tbSearch.Visible = false;
                bSearch.Visible = false;
                bGoTo.Visible = false;
                this.WindowState = FormWindowState.Maximized;
                this.Text = "F7 All Licenses";
                
                cmd = new SqlCommand(
                "select " +
                "id " +
                ",[Dongle ID] " +
                ",[Sales Order] " +
                ",[Owner] " +
                ",[Start Date] " +
                ",[Expiration Date] " +
                ",Application " +
                ",License " +
                ",ExpirationDate [Sortable Exp Date]" +
                "from DongleFullDetails where " +
                "productline = '" + g.productLine + "' and " +
                "activedemo = '" + g.activeDemo + "' " +
                "order by ExpirationDate", cnxn);
            }

            if (g.task == "Less Than Five")
            {
                tbSearch.Visible = false;
                bSearch.Visible = false;
                bGoTo.Visible = false;
                this.WindowState = FormWindowState.Maximized;
                this.Text = "F7 EXPIRATION LESS THAN FIVE YEARS";
                
                cmd= new SqlCommand(
                "select " +
                "id, " +
                "[Dongle ID], " +
                "[Sales Order], " +
                "[Owner], " +
                "[Start Date], " +
                "[Expiration Date], " +
                "Application, " +
                "License " +
                ",ExpirationDate [Sortable Exp Date]" +
                "from DongleFullDetails where " +
                "productline = '" + g.productLine + "' and " +
                "activedemo = '" + g.activeDemo + "' and " +
                "expirationdate < dateadd(year, 5, getdate()) and " +
                "expirationdate > getdate() " + 
                "order by expirationdate ", cnxn);
            }

            if (g.task == "Dongle Details" || 
                g.task == "Change SO" || 
                g.task == "Delete" || 
                g.task == "Sales Order Details")
            {
                cmd = new SqlCommand(   
               "select " +
               "id, " +
               "[Dongle ID], " +
               "[Sales Order], " +
               "Owner, " +
               "[Start Date], " +
               "[Expiration Date], " +
               "Application, " +
               "License, " +
               "[Customer Number] " +
               ",ExpirationDate [Sortable Exp Date]" +
               "from DongleFullDetails where " +
               "productline = '" + g.productLine + "' and " +
               "activedemo = '" + g.activeDemo + "' " +
               "order by [Dongle ID], ExpirationDate", cnxn);

                this.WindowState = FormWindowState.Maximized;
            }

            if (g.task == "Delete")
            {
                this.WindowState = FormWindowState.Maximized;
                this.Text = "F7 DELETE LICENSE LINE";
                L2Bdeleted.Visible = true;
                bGoTo.Visible = false;
            }

            if (g.task == "Change SO")
            {
                this.Text = "F7 CHANGE SALES ORDER";
                bGoTo.Visible = false;
            }

            if (g.task == "Dongle Details")
            {
                this.Text = "F7 DONGLE ID DETAILS";
                L2Bdeleted.Text = "Must enter Dongle Id for GO TO button.";
                L2Bdeleted.Location = new Point(130, 10);
                L2Bdeleted.Visible = true;
                ToolTip tt1 = new ToolTip();
                tt1.SetToolTip(this.bGoTo, "For Dongle ID ONLY");
            }

            if (g.task == "Sales Order Details")
            {
                this.Text = "F7 SALES ORDER DETAILS";
                L2Bdeleted.Visible = false;
                ToolTip tt1 = new ToolTip();
                tt1.SetToolTip(this.bGoTo, "For Sales Order Number ONLY");
            }

            DataTable dt = new DataTable();

            dr = cmd.ExecuteReader();

            dt.Load(dr);
            cnxn.Close();
            DGV.DataSource = dt;
            DGV.Columns[0].Visible = false;
            SetColumns();
            DGV.Show();
        }

        private void SetColumns()
        {
            DGV.Columns[1].Width = 130;
            DGV.Columns[2].Width = 120;
            DGV.Columns[3].Width = 240;
            DGV.Columns[4].Width = 120;
            DGV.Columns[5].Width = 120;
            DGV.Columns[6].Width = 150;
            DGV.Columns[7].Width = 200;
            DGV.Columns[8].Width = 120;
            
        }

        
        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 10)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                g.DongleID = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.uid = cell.EditedFormattedValue.ToString().Trim();

                if (g.task == "Dongle Details")
                {
                    f71DetailReport f71 = new f71DetailReport();
                    f71.Show();
                    this.Close();
                }

                if (g.task == "Sales Order Details")
                {
                    cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                    g.salesorder = cell.EditedFormattedValue.ToString().Trim(); 
                    f71DetailReport f71 = new f71DetailReport();
                    f71.Show();
                    this.Close();
                }

                if (g.task == "Change SO")
                {
                    f8ChangeSalesOrder f8 = new f8ChangeSalesOrder();
                    f8.Show();
                    this.Close();
                }

                if (g.task == "Delete")
                {
                    LDelete.Text = g.DongleID;
                    DGV.Columns[0].Visible = true;
                    bDelete.Visible = true;
                    SetColumns();
                }
            }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand(
                
                    "select " +
                    "id, " +
                    "[Dongle ID], " +
                    "[Serial Number] " +
                    "[Sales Order], " +
                    "Owner, " +
                    "[Start Date], " +
                    "[Expiration Date], " +
                    "Application, " +
                    "License, " +
                    "[Customer Number] " +
                    "from DongleFullDetails where " +
                    "productline = '" + g.productLine + "' and " +
                    "activedemo = '" + g.activeDemo + "' and " +
                    "([Sales Order] like '%" + tbSearch.Text.Trim() + "%' or " +
                    "Owner like '%" + tbSearch.Text.Trim() + "%'  or" +
                    "[Dongle ID] like '%" + tbSearch.Text.Trim() + "%'" +
                    " or " +
                    "[Serial Number] like '%" + tbSearch.Text.Trim() + "%') " +
                    "order by [Dongle ID], ExpirationDate", cnxn);
            

            DataTable dt = new DataTable();
            cnxn.Open();
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            cnxn.Close();
            DGV.DataSource = dt;
            DGV.Columns[0].Visible = false;
            SetColumns();
            DGV.Show();
        }

        private void bGoTo_Click(object sender, EventArgs e)
        {
            if (g.task == "Dongle Details")
            {
                g.DongleID = tbSearch.Text.Trim();
                f71DetailReport f71 = new f71DetailReport();
                f71.Show();
                this.Close();
            }

            if (g.task == "Sales Order Details")
            {
                g.salesorder = tbSearch.Text.Trim();
                f71DetailReport f71 = new f71DetailReport();
                f71.Show();
                this.Close();
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (g.task == "Delete")
            {
                SqlCommand cmd = new SqlCommand("Delete from LicenseData " +
                    "where id = '" + g.uid + "' ", cnxn);
                
                cnxn.Open();
                
                int rowsReturned = cmd.ExecuteNonQuery();
                                
                LDelete.Text = "";
                
                cmd = new SqlCommand(
                    "select " +
                    "id, " +
                    "[Dongle ID], " +
                    "[Sales Order], " +
                    "Owner, " +
                    "[Start Date], " +
                    "[Expiration Date], " +
                    "Application, " +
                    "License, " +
                    "[Customer Number] " +
                    "from DongleFullDetails where " +
                    "productline = '" + g.productLine + "' and " +
                    "activedemo = '" + g.activeDemo + "' and " +
                    "([Sales Order] like '%" + tbSearch.Text.Trim() + "%' or " +
                    "Owner like '%" + tbSearch.Text.Trim() + "%'  or" +
                    "[Dongle ID] like '%" + tbSearch.Text.Trim() + "%') " +
                    "order by [Dongle ID], ExpirationDate", cnxn);

                DataTable dt = new DataTable();
                                
                dr = cmd.ExecuteReader();
                
                dt.Load(dr);
                
                cnxn.Close();
                DGV.DataSource = dt;
                SetColumns();
                DGV.Show();
            }
        }
    }
}
