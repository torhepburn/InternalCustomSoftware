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
    public partial class F63_ChooseSetupSheet : Form
    {
        SqlConnection cnxn;
        DataTable table;

        public F63_ChooseSetupSheet()
        {
            InitializeComponent();
        }

        private void F63_ChooseSetupSheet_Load(object sender, EventArgs e)
        {
            rbToSheet.Checked = true;

            ToolTip TTrbToSheet = new ToolTip();
            TTrbToSheet.SetToolTip(rbToSheet, "Select this button, then click on the " +
                "Setup Sheet below to move the tools from inventory to the setup sheet");

            ToolTip TTrbFromSheet = new ToolTip();
            TTrbFromSheet.SetToolTip(rbFromSheet, "Select this button, then click on the " +
                "Setup Sheet below to move the tools from the setup sheet to inventory");

            cnxn = new SqlConnection(g.db);
            
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select distinct " +
                    "part_name as [Setup Sheet], Machine  from partsetup p left join toollocation l on " +
                    "p.machine = l.lsn where l.lprogram = '" + g.program +
                    "' and l.lfacility = '" + g.facility +
                    "' order by part_name", cnxn);
                table = new DataTable();
                da.Fill(table);
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            cnxn.Close();

            DGV.Show();
            DGV.DataSource = table;

        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 1)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                   (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                g.SetUp = cell.EditedFormattedValue.ToString().Trim();

                if (rbToSheet.Checked == true)
                {
                    SqlConnection cnxn2 = new SqlConnection(g.db);
                    cnxn2.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnxn2;
                    cmd.CommandText = "FromInventory2Setup";
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    SqlParameter machine = new SqlParameter("@machine", SqlDbType.NChar, 10);
                    machine.Value = g.SetUp;

                    cmd.Parameters.Add(machine);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    cnxn.Close();
                }
                else
                {
                    SqlConnection cnxn2 = new SqlConnection(g.db);
                    cnxn2.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnxn2;
                    cmd.CommandText = "FromSetup2Inventory";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter machine = new SqlParameter("@machine", SqlDbType.NChar, 10);
                    machine.Value = g.SetUp;

                    cmd.Parameters.Add(machine);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    cnxn.Close();
                }
                Close();
            }
        }
    }
}
