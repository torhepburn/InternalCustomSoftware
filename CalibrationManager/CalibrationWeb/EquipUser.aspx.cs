using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace CalibrationWeb
{
    public partial class EquipUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            ConnectionStringSettings css = ConfigurationManager.ConnectionStrings["CalibrationCnxn"];
            SqlConnection cnxn = new SqlConnection(css.ConnectionString);
            cnxn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnxn;
            cmd.CommandText = "Calibration_scans";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter item = new SqlParameter("@Item", SqlDbType.NChar, 15);
            item.Value = txtItem.Text.ToString().Trim().ToUpper();
            SqlParameter employee = new SqlParameter("@Employee", SqlDbType.Int);
            employee.Value = Convert.ToInt32(txtEmployee.Text.ToString().Trim().ToUpper());
            SqlParameter location = new SqlParameter("@Location", SqlDbType.NChar, 20);
            location.Value = "No Change";
            SqlParameter status = new SqlParameter("@Status", SqlDbType.NChar, 200);
            status.Direction = ParameterDirection.Output;
            status.Value = "Init";

            cmd.Parameters.Add(item);
            cmd.Parameters.Add(employee);
            cmd.Parameters.Add(location);
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

            if (cbEmployee.Checked == false)
            {
                txtEmployee.Text = "";
            }

            if (feedback == "OK")
            {
                txtItem.Text = "";
            }
            txtEmployee.Focus();

        }
    }
}
