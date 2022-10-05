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
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data.SqlClient;


namespace MRBweb
{
    public partial class GridTable : System.Web.UI.Page
    {
        private OracleConnection conn = new OracleConnection();
        private OracleCommand cmd;
        private OracleDataAdapter da;
        private OracleCommandBuilder cb;
        //private DataSet ds;
        DataTable table;
        private string item;
        SqlConnection cnxn;
        SqlCommand SqlCmd;
        DataTable FastTable;
        private string FastID;
        private string FastResponsibleUser;
        DataTable EndTable;

        
        protected void Page_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = "user id=views;" +
            "Password=views;Data Source=//dbserver:1521/mkpd;";

            try
            {
                conn.Open();

                string sql = "select  " +
                             "e.name as Name, " +
                             "w.item_code, " +
                             "w.item_description, " +
                             "w.warehouse, " +
                             "w.stock_on_hand as OH, " +
                             "w.allocated_stock as Allo, " +
                             "w.blocked_stock as Blkd, " +
                             "w.non_nettable_stock_quantity as NNet, " +
                             "(w.stock_on_hand * d.standard_cost_price) as Value, " +
                             "d.standard_cost_price as Cost " +
                             "from views200.item_data_by_warehouse w " +
                             "left join views200.item_data d on " +
                             "w.item_code = d.item_code " +
                             "left join views200.employees e on " +
                             "d.planner_code = e.employee " +
                             "where (w.warehouse like '%MR%' or " +
                             "w.warehouse like '%45') and " +
                             "w.stock_on_hand != 0 " +
                             " order by e.name   ";

                cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;

                da = new OracleDataAdapter(cmd);
                cb = new OracleCommandBuilder(da);
                //ds = new DataSet();
                table = new DataTable();

                //da.Fill(ds);
                da.Fill(table);

                table.Columns.Add("FastID", typeof(int));
                table.Columns.Add("FastResponsibleUser", typeof(string));

                EndTable = table.Clone();

                //DGV.DataSource = ds.Tables[0];
                //DGV.DataSource = table;

            }
            catch (Exception ex)
            {
                //                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                conn.Dispose();
            }

            foreach (DataRow row in table.Rows)
            {
                item = row[1].ToString();

                cnxn = new SqlConnection
                    ("server = middbsql\\sql2000; user = views; " +
                     "password = views; database = dashboard;");
                SqlDataAdapter da = new SqlDataAdapter
                    ("select f.FastId, f.FastResponsibleUser " +
                     "from view_fast f left join " +
                     "view_fast_signatures s " +
                     "on f.fastid = s.fastid " +
                     "where f.partnumber = '" +
                    item + "' and f.faststatus = 'Open' " +
                    "and s.qcsigndate is not null " +
                    "and s.plannersigndate is not null " +
                    "and mfgsigndate is not null " +
                    "and supplychainsigndate is not null " +
                    "and engineeringsigndate is not null "
                    , cnxn);
                FastTable = new DataTable();
                da.Fill(FastTable);
                if (FastTable.Rows.Count > 0)
                {
                    foreach (DataRow FastRow in FastTable.Rows)
                    {
                        FastID = FastRow[0].ToString();
                        FastResponsibleUser = FastRow[1].ToString();

                        row[10] = FastID;
                        row[11] = FastResponsibleUser;

                        DataRow newRow = EndTable.NewRow();
                        newRow.ItemArray = row.ItemArray;
                        EndTable.Rows.Add(newRow);
                    }
                }
                else
                {
                    DataRow newRow = EndTable.NewRow();
                    newRow.ItemArray = row.ItemArray;
                    EndTable.Rows.Add(newRow);
                }
                
            }
            EndTable.Columns["FastID"].SetOrdinal(4);
            EndTable.Columns["FastResponsibleUser"].SetOrdinal(1);
            GridView1.DataSource = EndTable;
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                object t = (e.Row.DataItem as DataRowView).Row.ItemArray[0];
                DataRowView drv = (DataRowView)e.Row.DataItem;
                
                if (drv.Row.ItemArray[0].ToString() == "Heizman, Robert")
                {
                    e.Row.BackColor = System.Drawing.Color.DarkSalmon;

                    if (drv.Row.ItemArray[1].ToString() == "Heizman, Bob")
                    {
                        e.Row.BackColor = System.Drawing.Color.Firebrick;
                    }
                }
                else if (drv.Row.ItemArray[0].ToString() == "Kindelan, Davey")
                {
                    e.Row.BackColor = System.Drawing.Color.SteelBlue;

                    if (drv.Row.ItemArray[1].ToString() == "Kindelan, Davey")
                    {
                        e.Row.BackColor = System.Drawing.Color.RoyalBlue;
                    }
                }
                else if (drv.Row.ItemArray[0].ToString() == "Lamarr, Amanda")
                {
                    e.Row.BackColor = System.Drawing.Color.LightGreen;
                }
                else if (drv.Row.ItemArray[0].ToString() == "Lawrence, Mark")
                {
                    e.Row.BackColor = System.Drawing.Color.MediumPurple;
                }
                else if (drv.Row.ItemArray[0].ToString() == "Morenz, Mark")
                {
                    e.Row.BackColor = System.Drawing.Color.Goldenrod;

                    if (drv.Row.ItemArray[1].ToString() == "Morenz, Mark")
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleGoldenrod;
                    }
                }
                else if (drv.Row.ItemArray[0].ToString() == "Santos, Rick")
                {
                    e.Row.BackColor = System.Drawing.Color.PaleTurquoise;

                    if (drv.Row.ItemArray[1].ToString() == "Santos, Rick")
                    {
                        e.Row.BackColor = System.Drawing.Color.DarkTurquoise;
                    }
                }
                if (drv.Row.ItemArray[0].ToString() == "Vitali, Margaret")
                {
                    e.Row.BackColor = System.Drawing.Color.DarkKhaki;

                    if (drv.Row.ItemArray[1].ToString() == "Vitali, Margaret")
                    {
                        e.Row.BackColor = System.Drawing.Color.Khaki;
                    }
                }

                Label l_lbl_fastid = (Label)e.Row.FindControl("lbl_FastID");
                HyperLink l_HL_fastid = (HyperLink)e.Row.FindControl("HL_FastID");
                l_HL_fastid.NavigateUrl = "//dashboard-ct/zto/app/fast/fastedit.aspx?id=" +
                    l_lbl_fastid.Text;
                l_HL_fastid.Text = "Click";
            }
        }

        
 
    }
}
