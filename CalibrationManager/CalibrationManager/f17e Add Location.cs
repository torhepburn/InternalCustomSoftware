using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace CalibrationManager
{
    public partial class f17e_Add_Bench : Form
    {
        SqlCommand cmd;
        SqlConnection cnxn;

        SqlParameter LID = new SqlParameter("@LID", SqlDbType.VarChar, 20);
        SqlParameter Ldescrip = new SqlParameter("@Ldescrip", SqlDbType.VarChar, 50);
        
        public f17e_Add_Bench()
        {
            InitializeComponent();
        }

        private void f17e_Add_Bench_Load(object sender, EventArgs e)
        {
            tbName.Text = g.location;
            tbDescription.Text = g.Ldescription;

            ToolTip tt = new ToolTip();
            
            tt.ShowAlways = true;
            tt.SetToolTip(tbName, "Location ID is made up of site + room + what is entered in this box.  Try to limit entry to 3 characters.");
            tt.SetToolTip(tbDescription, "Limit of 50 characters.");

            if (g.task == "Edit")
            {
                tbName.Enabled = false;
            }
        }
        private void bEnterSave_Click_1(object sender, EventArgs e)
        {
            if (g.task == "Add")
            {
                if (tbName.Text == "")
                {
                    MessageBox.Show("An Entry is Required for Location Number or Name.");
                    tbName.Focus();
                    return;
                }
                else
                {
                    string name = tbName.Text.ToString().Trim();
                    LID.Value  = g.room + "-" + name;

                    if (LID.Value.ToString().Trim().Length > 20)
                    {
                        MessageBox.Show("Location ID too long.");
                        tbName.Text = "";
                        tbName.Focus();
                        return;
                    }

                    cnxn = new SqlConnection(g.db);
                    cmd = new SqlCommand
                        ("Select l_id from location where " +
                         "l_id = " + LID + "", cnxn);

                    cmd.Parameters.Add(LID);
                    
                    cnxn.Open();
                    object o = cmd.ExecuteScalar();
                    if (o != null)
                    {
                        string test = o.ToString().Trim();
                        if (test == LID.Value.ToString())
                        {
                            DialogResult result;
                            result = MessageBox.Show(name + " has already been issued for another location.");
                            cmd.Parameters.Clear();
                            tbName.Text = "";
                            tbName.Focus();
                            return;
                        }
                    }
                    g.location = LID.Value.ToString();
                    cmd.Parameters.Clear();
                    cnxn.Close();
                }

                if (tbDescription.Text == "")
                {
                    MessageBox.Show("An entry is required for Description.");
                    tbDescription.Focus();
                    return;
                }
                else
                {
                    if (tbDescription.Text.Length > 50)
                    {
                        MessageBox.Show("Location description too long.");
                        tbDescription.Text = "";
                        tbDescription.Focus();
                        return;
                    }
                    else
                    {
                        Ldescrip.Value = tbDescription.Text.ToString().Trim();
                    }
                }
                cnxn = new SqlConnection(g.db);
                cmd = new SqlCommand("Insert into location " +
                "(l_id, l_Description) values (" + LID + "," +
                 Ldescrip + ")", cnxn);
                cmd.Parameters.Add(LID);
                cmd.Parameters.Add(Ldescrip);
            }

            if (g.task == "Edit")
            {
                Ldescrip.Value = tbDescription.Text.ToString().Trim();

                if (Ldescrip.Value.ToString().Trim().Length > 50)
                {
                    MessageBox.Show("Location description too long.");
                    tbDescription.Text = "";
                    tbDescription.Focus();
                    return;
                }
                cnxn = new SqlConnection(g.db);
                cmd = new SqlCommand("Update location " +
                " set l_Description = " + Ldescrip + " where " +
                " l_id = '" + g.location + "' ", cnxn);
                cmd.Parameters.Add(Ldescrip);
            }

            cnxn.Open();
            int rowsReturned = cmd.ExecuteNonQuery();
            cnxn.Close();
            cmd.Parameters.Clear();

            if (g.task == "Add")
            {
                f21_Select_Employees f2 = new f21_Select_Employees();
                f2.Show();
            }
            tbName.Text = "";
            tbDescription.Text = "";
            this.Close();
        }

    }
}