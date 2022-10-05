using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Tools
{
    public partial class F2_Tools : Form
    {
        SqlDataAdapter da;
        SqlConnection cnxn;
        private string SQL;
        
        
        public F2_Tools()
        {
            InitializeComponent();
        }

        private void F2_Tools_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            

            if ( g.program == "LFO" | g.program == "CNC")
            {
                SQL = " Select SN, tooltype, diameter, usablelength, grit from tools t "; 
                
            }
            else
            {
                SQL = " Select SN, usablelength_M Length_M, Width_M, ItemDescription FROM tools t ";
            }

            try
            {
                da = new SqlDataAdapter
                   (SQL + " inner join toollocation l on t.sn = l.lsn " +
                    " where program = '" + g.program + "' " +
                    " and lfacility = '" + g.facility + "' " +
                    " order by sn asc", cnxn);
                DataTable table = new DataTable();
                da.Fill(table);
                DGV.DataSource = table;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex <2)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.SN = cell.EditedFormattedValue.ToString().Trim();
                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                g.ToolType = cell.EditedFormattedValue.ToString().Trim();

                selectionChoice();
            }
        }
         
        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void selectionChoice()
        {
            if (g.task == "Edit")
            {
                if (g.program == "CNC" | g.program == "LFO")
                {
                    F4_Edit f4 = new F4_Edit();
                    f4.Show();
                }
                else
                {
                    F4a_AddEditFxVc f = new F4a_AddEditFxVc();
                    f.ShowDialog();
                }
            }
        //        if (g.task == "Delete")
        //        {
        //            string message = "Confirm Item Deletion.";
        //            string caption = "";
        //            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
        //            DialogResult result;
        //            result = MessageBox.Show(message, caption, buttons);

        //            if (result == System.Windows.Forms.DialogResult.No)
        //            {
        //                return;
        //            }

        //            cnxn = new SqlConnection(g.db);

        //            SqlCommand cmd = new SqlCommand
        //                ("delete from equipment " +
        //                "where id = '" + g.iID + "'", cnxn);

        //            cnxn.Open();
        //            int rowsReturned = cmd.ExecuteNonQuery();
        //            cnxn.Close();

        //            cnxn = new SqlConnection(g.db);

        //            cmd = new SqlCommand
        //                ("delete from itemuser " +
        //                "where i_item = '" + g.iID + "'", cnxn);

        //            cnxn.Open();
        //            rowsReturned = cmd.ExecuteNonQuery();
        //            cnxn.Close();

        //            cnxn = new SqlConnection(g.db);

        //            cmd = new SqlCommand
        //                ("delete from itemlocation " +
        //                "where il_item = '" + g.iID + "'", cnxn);

        //            cnxn.Open();
        //            rowsReturned = cmd.ExecuteNonQuery();
        //            cnxn.Close();
        //            this.Close();
        //        }
        //    }

        //    if (g.item == "Reports")
        //    {
        //        f52_Equipment_Report f2 = new f52_Equipment_Report();
        //        f2.Show();
            }

        private void bSearch_Click(object sender, EventArgs e)
        {
                cnxn = new SqlConnection(g.db);
                da = new SqlDataAdapter
                    (" Select SN, tooltype, diameter, usablelength, grit from tools t " +
                     " inner join toollocation l on t.sn = l.lsn " +
                     " where (SN like '" + tbSearchEquipment.Text + "%'" +
                     " or ToolType like '%" + tbSearchEquipment.Text + "%'" +
                     " and program = '" + g.program + "') " +
                     " and Lfacility = '" + g.facility + "' " +
                     " order by sn asc", cnxn);
                DataTable table = new DataTable();
                da.Fill(table);
                DGV.DataSource = table;
        
        }

        private void bItem_Click(object sender, EventArgs e)
        {
            g.SN = tbSearchEquipment.Text.ToString().Trim().ToUpper();
            tbSearchEquipment.Text = "";
            SqlCommand cmd = new SqlCommand
                ("Select sn from tools where sn = '" + g.SN + "' " );
            cnxn = new SqlConnection(g.db);
            cmd.Connection = cnxn;
            cnxn.Open();
            object o = cmd.ExecuteScalar();

            if (o == null)
            {
                MessageBox.Show("This item does not exist.");
                tbSearchEquipment.Focus();
            }
            else
            {
                selectionChoice();
            }
       
        }
    }
}