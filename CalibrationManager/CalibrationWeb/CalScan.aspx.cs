using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace CalibrationWeb
{
    public partial class CalScan : System.Web.UI.Page
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
            cmd.CommandText = "calibration_data_scan";
            //cmd.CommandText = "calibration_data_TEST";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter item = new SqlParameter("@Item", SqlDbType.NChar, 15);
            item.Value = txtItem.Text.ToString().Trim().ToUpper();
            SqlParameter temperature = new SqlParameter("@temperature", SqlDbType.Int);
            temperature.Value = tbTemperature.Text;
            SqlParameter humidity = new SqlParameter("@humidity", SqlDbType.Int);
            humidity.Value = tbHumidity.Text;
            SqlParameter inspector = new SqlParameter("@inspector", SqlDbType.NChar, 20);
            inspector.Value = tbInspector.Text.ToString().Trim().ToUpper();


            SqlParameter location = new SqlParameter("@Location", SqlDbType.NChar, 20);
            location.Value = txtLocation.Text.ToString().Trim().ToUpper();
            SqlParameter status = new SqlParameter("@Status", SqlDbType.NChar, 200);
            status.Direction = ParameterDirection.Output;
            status.Value = "Init";

            cmd.Parameters.Add(item);
            cmd.Parameters.Add(temperature);
            cmd.Parameters.Add(humidity);
            cmd.Parameters.Add(inspector);
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

            if (cbLocation.Checked == false)
            {
                txtLocation.Text = "";
            }
            if (feedback == "OK")
            {
                txtItem.Text = "";
            }

        }
    }
}