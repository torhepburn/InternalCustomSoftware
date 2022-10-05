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

namespace CalibrationView
{
    public partial class KPI : System.Web.UI.Page
    {
        private string selectedMonth;
        private string year;

        protected void Page_Load(object sender, EventArgs e)
        {
            year = DateTime.Now.Year.ToString();

        }

        protected void Bjanuary_Click(object sender, EventArgs e)
        {
            selectedMonth = "01-01-" + year;
            DataSelect();
        }

        protected void Bfebruary_Click(object sender, EventArgs e)
        {
            selectedMonth = "02-01-" + year;
            DataSelect();
        }

        protected void Bmarch_Click(object sender, EventArgs e)
        {
            selectedMonth = "03-01-" + year;
            DataSelect();
        }

        protected void Bapril_Click(object sender, EventArgs e)
        {
            selectedMonth = "04-01-" + year;
            DataSelect();
        }

        protected void Bmay_Click(object sender, EventArgs e)
        {
            selectedMonth = "05-01-" + year;
            DataSelect();
        }

        protected void Bjune_Click(object sender, EventArgs e)
        {
            selectedMonth = "06-01-" + year;
            DataSelect();
        }

        protected void Bjuly_Click(object sender, EventArgs e)
        {
            selectedMonth = "07-01-" + year;
            DataSelect();
        }

        protected void Baugust_Click(object sender, EventArgs e)
        {
            selectedMonth = "08-01-" + year;
            DataSelect();
        }

        protected void Bseptember_Click(object sender, EventArgs e)
        {
            selectedMonth = "09-01-" + year;
            DataSelect();
        }

        protected void Boctober_Click(object sender, EventArgs e)
        {
            selectedMonth = "10-01-" + year;
            DataSelect();
        }

        protected void Bnovember_Click(object sender, EventArgs e)
        {
            selectedMonth = "11-01-" + year;
            DataSelect();
        }

        protected void Bdecember_Click(object sender, EventArgs e)
        {
            selectedMonth = "12-01-" + year;
            DataSelect();
        }


        protected void DataSelect()
        {
            
            SqlConnection cnxn = new SqlConnection
                ("server=middbsql; user=views; " +
                 "password=views; database=calibration;");
            SqlCommand cmd = new SqlCommand(
                "KPI", cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter month = cmd.Parameters.Add
                ("@Month", SqlDbType.DateTime);
            SqlParameter loc = cmd.Parameters.Add
                ("@loc", SqlDbType.VarChar, 20);
            loc.Value = "zams%";
            
            month.Value = selectedMonth;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable table = new DataTable();
            da.Fill(table);

            GV.DataSource = table;
            GV.DataBind();
     
        }

        
        
    
    }
}
