using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MethodSheet1
{
    public partial class F2_EnterReleaseData : Form
    {
        SqlConnection cnxn;
        SqlCommand cmd;
        private string dbLotSize;
        private string dbRev;
        private string dbNewMS;

        public F2_EnterReleaseData()
        {
            InitializeComponent();
        }

        private void F2_EnterReleaseData_Load(object sender, EventArgs e)
        {
            tbPartNumber.Text = g.partnumber;
        }

        private void bEnterData_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);

            cmd = new SqlCommand(
                "select lotsize from OpticsMethodSheetData " +
                "where partnumber = '" + tbPartNumber.Text.Trim() + "' " +
                "and lotsize is not null ", cnxn);

            cnxn.Open();
            object n = cmd.ExecuteScalar();
            cnxn.Close();

            if (n != null)
            {
                dbNewMS = n.ToString();
            }
            else
            {
                MessageBox.Show("Not Approved for Quick Release.");
                this.Close();
            }

            cmd = new SqlCommand(
                "select lotsize from OpticsMethodSheetData " +
                "where partnumber = '" + tbPartNumber.Text.Trim() + "' " +
                "and lotsize is not null " , cnxn);

            cnxn.Open();
            object o =  cmd.ExecuteScalar();
            cnxn.Close();

            if (o != null)
            { 
                dbLotSize = o.ToString(); 
            }
            else
            {
                MessageBox.Show("No Lot Size specified in database.");
                this.Close();
            }

            if (dbLotSize != tbLotSize.Text)
            {
                MessageBox.Show("Incorrect Lot Size.");
                tbLotSize.Text = "";
                tbLotSize.Focus();
                return;
            }

            cmd = new SqlCommand(
                "select Rev from OpticsMethodSheetData " +
                "where partnumber = '" + tbPartNumber.Text.Trim() + "' " +
                "and Rev is not null ", cnxn);

            cnxn.Open();
            object p = cmd.ExecuteScalar();
            cnxn.Close();

            if (p != null)
            {
                dbRev = p.ToString().Trim().ToUpper();
            }
            else
            {
                MessageBox.Show("No Rev specified in database.");
                this.Close();
            }

            if (dbRev != tbRevision.Text.ToString().Trim().ToUpper())
            {
                MessageBox.Show("Revison level does not agree with database.");
                tbRevision.Text = "";
                tbRevision.Focus();
                return;
            }

            if (tbWOnumber.Text.Length < 1)
            {
                MessageBox.Show("Must enter a Work Order Number.");
                tbWOnumber.Focus();
                return;
            }

            
            try
            {
                cmd = new SqlCommand(
                     "Update OpticsMethodSheetData " +
                     "set " +
                     "lastworeleased = " + tbWOnumber.Text.Trim() +
                     ", lastreleasedate = '" + DateTime.Now + "' " +
                     ", initials = '" + tbInitials.Text.Trim() + "' " +
                     ", serial = '" + tbSerialNumber.Text.Trim() + "' " +
                     "where partnumber = '" + tbPartNumber.Text.Trim() + "' "
                     , cnxn);
                cnxn.Open();
                cmd.ExecuteNonQuery();
                
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            this.Close();

        }
    }
}
