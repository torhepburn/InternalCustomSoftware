using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DemoLabScan
{
    public partial class Demo : System.Web.UI.Page
    {
        private string feedback;

        protected void Page_Load(object sender, EventArgs e)
        {
            txtEmployee.Focus();
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
            SqlParameter inout = new SqlParameter("@Inout", SqlDbType.NChar, 255);
            if (cbInOut.Checked == true)
            {
                inout.Value = "IN";
            }
            else
            {
                inout.Value = "OUT";
            }

            SqlParameter status = new SqlParameter("@Status", SqlDbType.NChar, 200);
            status.Direction = ParameterDirection.Output;
            status.Value = "Init";

            cmd.Parameters.Add(item);
            cmd.Parameters.Add(employee);
            cmd.Parameters.Add(inout);
            cmd.Parameters.Add(comments);
            cmd.Parameters.Add(status);

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
                cbInOut.Checked = true;
            }
            
            
            

            
            if (feedback == "OK")
            {
                txtItem.Text = "";
                txtEmployee.Text = "";
            }
            txtEmployee.Focus();

        }

        protected void cbInOut_CheckedChanged(object sender, EventArgs e)
        {
            if (cbInOut.Checked == false)
            {
                cbInOut.Text = "Checking Out";
            }
            else
            {
                cbInOut.Text = "Checking In";
            }
        }

       
        
        
    }
}