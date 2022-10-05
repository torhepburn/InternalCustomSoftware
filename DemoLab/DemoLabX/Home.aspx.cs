using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace DemoLabX
{
    public partial class _Default : Page
    {
        private string feedback;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            txtEmployee.Focus();
            Title = SiteMaster.LocationX;
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            ConnectionStringSettings css = ConfigurationManager.ConnectionStrings["DemoLabCnxn"];
            SqlConnection cnxn = new SqlConnection(css.ConnectionString);
            cnxn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnxn;
            cmd.CommandText = "DemoLab_scan";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter item = new SqlParameter("@Item", SqlDbType.NChar, 200);
            item.Value = txtItem.Text.ToString().Trim().ToUpper();
            SqlParameter employee = new SqlParameter("@Employee", SqlDbType.Int);
            employee.Value = Convert.ToInt32(txtEmployee.Text.ToString().Trim());
            SqlParameter comments = new SqlParameter("@Comments", SqlDbType.NChar, 255);
            comments.Value = txtComments.Text.ToString().Trim();
            SqlParameter location = new SqlParameter("@Location", SqlDbType.NChar, 20);
            location.Value = SiteMaster.LocationX;

            SqlParameter inout = new SqlParameter("@Inout", SqlDbType.NChar, 255);
            if (rbIn.Checked == true)
            {
                inout.Value = "IN";
            }
            
            if (rbOut.Checked == true)
            {
                inout.Value = "OUT";
            }

            if (rbSold.Checked == true)
            {
                inout.Value = "SOLD";
            }
            SqlParameter newItem = new SqlParameter("@NewItem", SqlDbType.Int);
            if (cbAdd.Checked == true)
            {
                newItem.Value = 1;
            }
            else
            {
                newItem.Value = 0;
            }
            
            SqlParameter status = new SqlParameter("@Status", SqlDbType.NChar, 200);
            status.Direction = ParameterDirection.Output;
            status.Value = "Init";

            cmd.Parameters.Add(item);
            cmd.Parameters.Add(employee);
            cmd.Parameters.Add(inout);
            cmd.Parameters.Add(comments);
            cmd.Parameters.Add(status);
            cmd.Parameters.Add(newItem);
            cmd.Parameters.Add(location);

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                feedback = "";
                if (dr.Read())
                {
                    feedback = dr.GetString(0);
                }
                dr.Close();
                cnxn.Close();

                txtStatus.Text = feedback;

            }
            catch (SqlException ex)
            {
                txtStatus.Text = ex.ToString();
                txtItem.Text = "";
                txtEmployee.Text = "";
                txtComments.Text = "";
                rbIn.Checked = true;
                cbAdd.Checked = false;
            }

            if (feedback == "OK")
            {
                txtItem.Text = "";
                cbAdd.Checked = false;
            }

            if (cbEmployee.Checked == false)
            {
                txtEmployee.Text = "";
                txtEmployee.Focus();
            }
            else
            {
                txtItem.Focus();
            }
            

        }

    }
}