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
        protected void Page_Load(object sender, EventArgs e)
        {

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
            employee.Value = Convert.ToInt32(txtEmployee.Text.ToString().Trim().ToUpper());
            //SqlParameter location = new SqlParameter("@Location", SqlDbType.NChar, 20);
            //location.Value = "No Change";
            SqlParameter status = new SqlParameter("@Status", SqlDbType.NChar, 200);
            status.Direction = ParameterDirection.Output;
            status.Value = "Init";

            cmd.Parameters.Add(item);
            cmd.Parameters.Add(employee);
            //cmd.Parameters.Add(location);
            cmd.Parameters.Add(status);

            SqlDataReader dr = cmd.ExecuteReader();

            string feedback = "";
            if (dr.Read())
            {
                feedback = dr.GetString(0);
            }
            dr.Close();
            cnxn.Close();

            txtStatus.Text = feedback;

            
            if (feedback == "OK")
            {
                txtItem.Text = "";
            }
            txtEmployee.Focus();

        }
    }
}