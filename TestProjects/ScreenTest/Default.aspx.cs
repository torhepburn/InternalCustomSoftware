using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection cnxn;
    DataTable table;
    protected void Page_Load(object sender, EventArgs e)
    {
        //get data to fill equipment drop down list and text boxes.    
        //start with blank first line so ddl shows no selection

        cnxn = new SqlConnection
            ("server=CT-MID-SQL01; user=readWrite; password=Read+Write!;" +
             "database=AccessFrontEnds");


        //get data to fill employee drop down list and text boxes.    

        SqlDataAdapter da = new SqlDataAdapter
            ("select " +
             "' ' as name, " +
             "' ' as empemail " +
             "union " +
             "select " +
             "e.Name,  " +
             "e.email as empemail " +
             "from " +
             "[middb01].dashboard.dbo.view_employees e " +
             "where e.badgeid > 0 " +
             "and (e.badgeID < 2685 " +
             "or e.badgeID  > 2688) " +
             "order by  " +
             "name ", cnxn);

        table = new DataTable();
        da.Fill(table);

        //SqlCommand cmd = new SqlCommand(
        //    "select top 1 id from tool_requests order by id desc", cnxn);

        //cnxn.Open();
        //object o = cmd.ExecuteScalar();
        //cnxn.Close();

        //uid = Convert.ToInt32(o);

        //da = new SqlDataAdapter
        //    ("select " +
        //     "'' as CostCenter, " +
        //     "'Select' as CostCenterDescription, " +
        //     "'Cost' as ResponsibleOwner, " +
        //     "'Center' as BusinessUnit " +
        //     "union " +
        //     "select " +
        //     "CostCenter, " +
        //     "CostCenterDescription, " +
        //     "ResponsibleOwner, " +
        //     "BusinessUnit " +
        //     "from ExpenseCostCenters " +
        //     "where costcenter > 0 order by CostCenter", cnxn);

        //table1 = new DataTable();
        //da.Fill(table1);

        //DataColumn dc = new DataColumn("combined");
        //dc.Expression = string.Format("{0}+'----'+{1} + '----' + {2} + '----' + {3}",
        //    "CostCenter", "CostCenterDescription", "ResponsibleOwner", "BusinessUnit");
        //table1.Columns.Add(dc);

        //this keeps the selections in the boxes

        if (!IsPostBack)
        {
            ddlRequestorName.DataSource = table;
            ddlRequestorName.DataTextField = "Name";
            ddlRequestorName.DataValueField = "Name";
            ddlRequestorName.DataBind();
            ddlEmployeeName.DataSource = table;
            ddlEmployeeName.DataTextField = "Name";
            ddlEmployeeName.DataValueField = "Name";
            ddlEmployeeName.DataBind();
            /*DDLcostCenter.DataSource = table1;
            DDLcostCenter.DataTextField = "combined";
            DDLcostCenter.DataValueField = "CostCenter";
            DDLcostCenter.DataBind();*/
        }


    }

    protected void button1_Click(object sender, EventArgs e)
    {
        
    }

    protected void ddlRequestorName_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ddlEmployeeName_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}