using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KanbanActiveProductionMFD
{
    public partial class ActiveKanban : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        private string db = "server = midsql01; password = Read+Write!; " +
                            "user = readwrite; database = OptiTRAK;";
        DataTable dt;

        public ActiveKanban()
        {
            InitializeComponent();
        }

        private void ActiveKanban_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(db);
            da = new SqlDataAdapter("select * from mfdkanbanproduction " +
                  "order by item_code", cnxn);

            try
            {
                dt = new DataTable();
                da.SelectCommand.CommandTimeout = 300;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("dt " + ex.ToString());
            }
            finally
            {

            }

            DGV.DataSource = dt;

            foreach (DataGridViewRow gr in DGV.Rows)
            {
                if (Convert.ToInt32(DGV.Rows[gr.Index].Cells[5].Value.ToString()) < 1)
                {
                    DGV.Rows[gr.Index].Cells[5].Style.BackColor = Color.Green;
                }
                else
                {
                    DGV.Rows[gr.Index].Cells[5].Style.BackColor = Color.Red;
                }
            }

            DGV.Show();
        }
    }
}
