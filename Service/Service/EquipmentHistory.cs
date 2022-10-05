using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Service
{
    public partial class EquipmentHistory : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        SqlCommand cmd;

        public EquipmentHistory()
        {
            InitializeComponent();
        }

        private void EquipmentHistory_Load(object sender, EventArgs e)
        {
            Lmodel.Text = g.model;
            Lsn.Text = "SN " + g.sn;

            cnxn = new SqlConnection(g.db);

            try
            {
                da = new SqlDataAdapter("select * from ServiceHistory " +
                    "where serialnumber = '" + g.sn + "' " +
                    "order by id desc", cnxn);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            DataTable table = new DataTable();
            da.Fill(table);

            DGV.DataSource = table;
            DGV.Show();

            DGV.Columns[0].Visible = false;
            DGV.Columns[1].Width = 75;
            DGV.Columns[2].Width = 300;
            DGV.Columns[3].Width = 100;
            DGV.Columns[4].Width = 100;
            DGV.Columns[5].Width = 70;

        }

        private void bSave_Click(object sender, EventArgs e)
        {
            SqlParameter tNotes = new SqlParameter("@tNotes", SqlDbType.NChar, 2000);
            tNotes.Value = tbNotes.Text.ToString().Trim();
            
            SqlParameter tPN = new SqlParameter("@tPN", SqlDbType.NChar, 30);
            tPN.Value = tbAccessoryPartNumber.Text.ToString().Trim();
            
            SqlParameter tSN = new SqlParameter("@tSN", SqlDbType.NChar, 30);
            tSN.Value = tbAccessorySerialNumber.Text.ToString().Trim();
            
            cnxn = new SqlConnection(g.db);

            if (cbPMDue.Checked)
            {
                cmd = new SqlCommand(
                    "Insert into ServiceHistory (" +
                    "LogDate, " +
                    "Notes, " +
                    "AccessoryPartNumber, " +
                    "AccessorySerialNumber, " +
                    "PMDue, " +
                    "SerialNumber) " +
                    "values ('" +
                    DateTime.Now + "'," +
                    tNotes + "," +
                    tPN + "," +
                    tSN + ",'" +
                    dtpPmDue.Value + "','" +
                    g.sn + "') ", cnxn);
            }
            else
            {
                cmd = new SqlCommand(
                    "Insert into ServiceHistory (" +
                    "LogDate, " +
                    "Notes, " +
                    "AccessoryPartNumber, " +
                    "AccessorySerialNumber, " +
                    "SerialNumber) " +
                    "values ('" +
                    DateTime.Now + "'," +
                    tNotes + "," +
                    tPN + "," +
                    tSN + ",'" +
                    g.sn + "') ", cnxn);
            }
            cmd.Parameters.Add(tNotes);
            cmd.Parameters.Add(tPN);
            cmd.Parameters.Add(tSN);
            cnxn.Open();
            cmd.ExecuteNonQuery();
            cnxn.Close();

            this.Close();
        }

        private void cbPMDue_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPMDue.Checked)
            {
                dtpPmDue.Visible = true;
            }
            else
            {
                dtpPmDue.Visible = false;
            }
        }
    }
}
