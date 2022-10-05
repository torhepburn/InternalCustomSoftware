using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EnterStatus
{
    public partial class StatusData : Form
    {
        SqlConnection cnxn;
        
        public StatusData()
        {
            InitializeComponent();
        }

        private void StatusData_Load(object sender, EventArgs e)
        {
            Lcustomer.Text = "Customer:  " + g.customer;
            Lproject.Text = "Project:    " + g.project;
            LpartName.Text = "Part Name: " + g.element;
            LtravelerRev.Text = "Traveler Rev: " + g.travelerRev;

            cbPartSN.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPstatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTravelerStep.DropDownStyle = ComboBoxStyle.DropDownList;

            cnxn = new SqlConnection(g.db);
            
            SqlDataAdapter da = new SqlDataAdapter(
                "Select partsn, partid  from tblPartSN p " +
                "inner join tblJobInfo j on p.jobid = j.jobid " +
                "where p.jobid = " + g.jobID + "", cnxn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cbPartSN.DataSource = dt;
            cbPartSN.DisplayMember = "PartSN";
            cbPartSN.ValueMember = "PartID";
            
            SqlDataAdapter da2 = new SqlDataAdapter(
                 "Select opnum, IIF([Description] is null, 'Operational Step', [Description]) as Description from tblWorkIns " +
                 "where jobid = " + g.jobID + " order by opnum", cnxn);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            DataColumn dc = new DataColumn("combined");
            dc.Expression = string.Format("{0}+ ' ' + {1}", "opnum", "description");
            dt2.Columns.Add(dc);

            cbTravelerStep.DataSource = dt2;
            cbTravelerStep.DisplayMember = "combined";
            cbTravelerStep.ValueMember = "opnum";

        }

        private void bEnter_Click(object sender, EventArgs e)
        {
            g.partID = cbPartSN.SelectedValue.ToString();
            
            if (g.partID == null)
            {
                MessageBox.Show("Must select a Part ID.");
                cbPartSN.Focus();
                return;
            }

            if (cbPstatus.SelectedIndex == -1)
            {
                MessageBox.Show("Must select a Status.");
                cbPstatus.Focus();
                return;
            }
            else
            {
                g.PStatus = cbPstatus.SelectedItem.ToString();
            }

            cnxn.Open();
            SqlCommand cmd = new SqlCommand
                ("Insert into uScheduleStatus " +
                         "( PartID, WorkID ) " +
                         "Select partid, " +
                         "workid " +
                         "from tblPartSN p " +
                         "inner join tblWorkIns w " +
                         "on p.jobID = w.jobID " +
                         "where partid = " + g.partID + " ", cnxn);
            
            cmd.ExecuteNonQuery();


            
        }


    }
}
