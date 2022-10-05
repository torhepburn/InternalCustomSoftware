using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace PhoneList
{
    public partial class F2EditEmployee : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;

        public F2EditEmployee()
        {
            InitializeComponent();
        }

        private void F2EditEmployee_Load(object sender, EventArgs e)
        {
            if (g.task == "add")
            {
                tbLast.Text = g.name.Substring(0, g.name.IndexOf(',')).ToUpper();
                tbFirst.Text = g.name.Substring(g.name.IndexOf(',') + 2, g.name.Length - (g.name.IndexOf(',') + 2)).ToUpper();
                tbDept.Text = g.Dept;
                
                this.Text = "F2 Add";
            }
            else
            {
                tbLast.Text = g.last;
                tbFirst.Text = g.first;
                tbExt.Text = g.extension;
                tbDept.Text = g.Dept;
                cbLocation.Text = g.loc;
            }

           
            if (g.task == "find")
            {
                bEnterData.Visible = false;
                this.Text = "F2 Find";
            }
        }

        private void bEnterData_Click(object sender, EventArgs e)
        {
            if (g.task == "add")
            {
                try
                {
                    cnxn = new SqlConnection(g.db);
                    SqlCommand cmd = new SqlCommand
                        ("Insert into empTQPROSDB2 " +
                         "(Last, First, Dept, Loc, Extension) values " +
                         "(@last, " +
                         "@first, " +
                         "@dept, " +
                         "@loc, " +
                         "@extension, " +
                         " )", cnxn);


                    cmd.Parameters.Add("@last", SqlDbType.NVarChar, 30).Value = tbLast.Text.Trim();
                    cmd.Parameters.Add("@first", SqlDbType.NVarChar, 30).Value = tbFirst.Text.Trim();
                    cmd.Parameters.Add("@dept", SqlDbType.NVarChar, 8).Value = tbDept.Text.Trim();
                    cmd.Parameters.Add("@loc", SqlDbType.NVarChar, 10).Value = cbLocation.Text.Trim().
                        Substring(0, (cbLocation.Text.Trim().Length - (cbLocation.Text.IndexOf(':') - 1)));
                    cmd.Parameters.Add("@extension", SqlDbType.NVarChar, 50).Value = tbExt.Text.Trim();

                    cnxn.Open();
                    int rowsReturned = cmd.ExecuteNonQuery();
                    cnxn.Close();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Close();
            }

            if (g.task == "edit")
            {
                try
                {
                    cnxn = new SqlConnection(g.db);
                    SqlCommand cmd = new SqlCommand
                        ("Update empTQPROSDB2 " +
                         "set " +
                         "last = @last, " +
                         "first = @first, " +
                         "dept = @dept, " +
                         "loc = @loc, " +
                         "extension =  @extension " +
                         "where UID = '" + g.UID + "' ", cnxn);


                    cmd.Parameters.Add("@last", SqlDbType.NVarChar, 30).Value = tbLast.Text.Trim();
                    cmd.Parameters.Add("@first", SqlDbType.NVarChar, 30).Value = tbFirst.Text.Trim();
                    cmd.Parameters.Add("@dept", SqlDbType.NVarChar, 8).Value = tbDept.Text.Trim();
                    if (cbLocation.Text.IndexOf(':') > -1)
                    {
                        cmd.Parameters.Add("@loc", SqlDbType.NVarChar, 10).Value = cbLocation.Text.Trim().
                            Substring(0, (cbLocation.Text.IndexOf(':') - 1));
                    }
                    else
                    {
                        cmd.Parameters.Add("@loc", SqlDbType.NVarChar, 10).Value = cbLocation.Text.Trim();
                    }
                    cmd.Parameters.Add("@extension", SqlDbType.NVarChar, 50).Value = tbExt.Text.Trim();
                    
                    cnxn.Open();
                    int rowsReturned = cmd.ExecuteNonQuery();
                    cnxn.Close();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Close();
            }
        }

        private void cbLocation_Enter(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter("select LocationCode + ' : ' + Location as Display " +
                "from emplocationcodes order by locationcode", cnxn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cbLocation.DataSource = dt;
            cbLocation.DisplayMember = "Display";

            cnxn.Close();
        }
    }
}
