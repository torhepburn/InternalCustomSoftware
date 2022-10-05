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
    public partial class FAST_MRB : System.Web.UI.Page
    {
        private OracleConnection conn = new OracleConnection();
        private OracleCommand cmd;
        private OracleDataAdapter da;
        private OracleCommandBuilder cb;
        DataTable table;
        private string item;
        private string user;
        private string lastuser;
        private string FastResponsibleUser;
        SqlConnection cnxn;
        SqlCommand SqlCmd;
        DataTable FastTable;
        private string[] serrow;
        private string FastID;
        private string SignedOffDate;
        private string LastAction;
        DataTable EndTable;
        DataTable LastTable;
        private double total;
        private string[] totalrow;
        private string warehouse;
        private string lastwarehouse;
        private string lastitem;
        private double grandtotal;
        private string[] grandtotalrow;
        
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
                             "(w.stock_on_hand * d.standard_cost_price) as Extended_Cost, " +
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
                table.Columns.Add("Signed Off Date", typeof(string));
                table.Columns.Add("Most Recent Note", typeof(string));

                EndTable = table.Clone();
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
                lastuser = user;
                user = row[0].ToString();
                item = row[1].ToString();
                
                if (user == "Heizman, Robert")
                {
                    user = "Heizman, Bob";
                }

                cnxn = new SqlConnection
                    ("server = middbsql\\sql2000; user = views; " +
                     "password = views; database = dashboard;");
                SqlDataAdapter da = new SqlDataAdapter
                    ("select " +
                     "f.FastId, " +
                     "f.FastResponsibleUser, " +
                     "y.sdate, " +
                     "x.comments " +
                     "from view_fast f left join " +
                     "view_fast_signatures s on " +
                     "f.fastid = s.fastid " +
                     "left join " +
                     "(select fastid, " +
                     "max(dateentered) xdate, " +
                     "max(comments) Comments " +
                     "from view_fast_comments " +
                     "group by fastid) x " +
                     "on f.fastid = x.fastid " +
                     "left join " +
                     "(select fastid, max(maxdate) as sDate " +
                     "from " +
                     "(select " +
                     "fastid, QCSigndate as maxdate from view_fast_signatures " +
                     "union all " +
                     "select fastid, plannersigndate from view_fast_signatures " +
                     "union all " +
                     "select fastid,mfgsigndate from view_fast_signatures " +
                     "union all " +
                     "select fastid, supplychainsigndate from view_fast_signatures " +
                     "union all " +
                     "select fastid, engineeringsigndate from view_fast_signatures)t " +
                     "group by fastid) y "  +
                     "on f.fastid = y.fastid " +
                     "where f.partnumber = '" +
                     item + "' and f.faststatus = 'Open' " +
                     "and f.fastresponsibleuser = '" + user + "' " +
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
                        SignedOffDate = FastRow[2].ToString();
                        LastAction = FastRow[3].ToString();

                        row[0] = FastResponsibleUser;
                        row[10] = FastID;
                        row[11] = SignedOffDate;
                        row[12] = LastAction;

                        DataRow newRow = EndTable.NewRow();
                        newRow.ItemArray = row.ItemArray;
                        EndTable.Rows.Add(newRow);
                    }
                }

                if (lastuser != user)
                {
                    da = new SqlDataAdapter
                    ("select " +
                     "f.FastId, " +
                     "f.FastResponsibleUser, " +
                     "y.sdate, " +
                     "x.comments, " +
                     "f.partnumber " +
                     "from view_fast f left join " +
                     "view_fast_signatures s on " +
                     "f.fastid = s.fastid " +
                     "left join " +
                     "(select fastid, " +
                     "max(dateentered) xdate, " +
                     "max(comments) Comments " +
                     "from view_fast_comments " +
                     "group by fastid) x " +
                     "on f.fastid = x.fastid " +
                     "left join " +
                     "(select fastid, max(maxdate) as sDate " +
                     "from " +
                     "(select " +
                     "fastid, QCSigndate as maxdate from view_fast_signatures " +
                     "union all " +
                     "select fastid, plannersigndate from view_fast_signatures " +
                     "union all " +
                     "select fastid,mfgsigndate from view_fast_signatures " +
                     "union all " +
                     "select fastid, supplychainsigndate from view_fast_signatures " +
                     "union all " +
                     "select fastid, engineeringsigndate from view_fast_signatures)t " +
                     "group by fastid) y " +
                     "on f.fastid = y.fastid " +
                     "where f.faststatus = 'Open' " +
                     "and f.fastresponsibleuser = '" + lastuser + "' " +
                     "and s.qcsigndate is not null " +
                     "and s.plannersigndate is not null " +
                     "and mfgsigndate is not null " +
                     "and supplychainsigndate is not null " +
                     "and engineeringsigndate is not null " +
                     "and ascii(partnumber) > 64 " +
                     "and ascii(partnumber) < 123 "
                     , cnxn);

                    FastTable = new DataTable();
                    da.Fill(FastTable);
                    if (FastTable.Rows.Count > 0)
                    {
                        foreach (DataRow FastRow in FastTable.Rows)
                        {
                            FastID = FastRow[0].ToString();
                            FastResponsibleUser = FastRow[1].ToString();
                            SignedOffDate = FastRow[2].ToString();
                            LastAction = FastRow[3].ToString();
                            string pn = FastRow[4].ToString();

                            serrow = new string[13];
                            serrow[0] = FastResponsibleUser;
                            serrow[1] = pn;
                            serrow[10] = FastID;
                            serrow[11] = SignedOffDate;
                            serrow[12] = LastAction;

                            DataRow newRow = EndTable.NewRow();
                            newRow.ItemArray = serrow;
                            EndTable.Rows.Add(newRow);
                        }
                    }
                }
            }

            EndTable.Columns["FastID"].SetOrdinal(4);

            LastTable = EndTable.Clone();

            if (EndTable.Rows.Count > 0)
            {
                int i = 1;
                foreach (DataRow endrow in EndTable.Rows)
                {
                    lastuser = user;
                    user = endrow[0].ToString();
                    lastitem = item;
                    item = endrow[1].ToString();
                    lastwarehouse = warehouse;
                    warehouse = endrow[3].ToString();


                    if (i == 1)  //first time through
                    {
                        //add reglar row
                        DataRow newRow = LastTable.NewRow();
                        newRow.ItemArray = endrow.ItemArray;
                        LastTable.Rows.Add(newRow);
                        total = total + Convert.ToDouble(endrow[9].ToString());
                    }
                    else  //not first time through
                    {
                        if (lastuser != user)  //add total row for previous user
                        {
                            totalrow = new string[13];
                            totalrow[0] = "Total";
                            totalrow[9] = total.ToString();
                            DataRow tRow = LastTable.NewRow();
                            tRow.ItemArray = totalrow;
                            LastTable.Rows.Add(tRow);
                            grandtotal = grandtotal + total;
                            total = 0;
                        }
                        if ( user != lastuser ) //add regular row first time current user 
                        {
                            //add reglar row
                            DataRow newRow = LastTable.NewRow();
                            newRow.ItemArray = endrow.ItemArray;
                            LastTable.Rows.Add(newRow);
                            total = total + Convert.ToDouble(endrow[9].ToString());
                        }
                        else //user == lastuser - multiple items for user
                        {
                            if (item != lastitem)
                            {
                                //add reglar row
                                DataRow newRow = LastTable.NewRow();
                                newRow.ItemArray = endrow.ItemArray;
                                LastTable.Rows.Add(newRow);
                                if (endrow[9].ToString() != "")
                                {
                                    total = total + Convert.ToDouble(endrow[9].ToString());
                                }
                            }
                            else  //item == lastitem don't want dup numbers
                            {
                                DataRow newRow = LastTable.NewRow();
                                //endrow[5] = 0;
                                endrow[6] = 0;
                                endrow[7] = 0;
                                endrow[8] = 0;
                                endrow[9] = 0;
                                newRow.ItemArray = endrow.ItemArray;
                                LastTable.Rows.Add(newRow);
                                total = total + Convert.ToDouble(endrow[9].ToString());
                            }
                        }
                    }
                    i++;
                    
                }
                //add final individual total row
                totalrow = new string[13];
                totalrow[0] = "Total";
                totalrow[9] = total.ToString();
                DataRow lastRow = LastTable.NewRow();
                lastRow.ItemArray = totalrow;
                LastTable.Rows.Add(lastRow);
                grandtotal = grandtotal + total;
                total = 0;
                grandtotalrow = new string[13];
                grandtotalrow[0] = "Grand Total";
                grandtotalrow[9] = grandtotal.ToString();
                DataRow gRow = LastTable.NewRow();
                gRow.ItemArray = grandtotalrow;
                LastTable.Rows.Add(gRow);
            }
            
            GridView1.DataSource = LastTable;
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                object t = (e.Row.DataItem as DataRowView).Row.ItemArray[0];
                DataRowView drv = (DataRowView)e.Row.DataItem;

                if (drv.Row.ItemArray[0].ToString() == "Heizman, Bob")
                {
                    e.Row.BackColor = System.Drawing.Color.Salmon;
                }
                else if (drv.Row.ItemArray[0].ToString() == "Kindelan, Davey")
                {
                    e.Row.BackColor = System.Drawing.Color.SteelBlue;
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
                }
                else if (drv.Row.ItemArray[0].ToString() == "Santos, Rick")
                {
                    e.Row.BackColor = System.Drawing.Color.DarkCyan;
                }
                if (drv.Row.ItemArray[0].ToString() == "Vitali, Margaret")
                {
                    e.Row.BackColor = System.Drawing.Color.DarkKhaki;
                }
                if (drv.Row.ItemArray[0].ToString() == "Total")
                {
                    e.Row.BackColor = System.Drawing.Color.LightGreen;
                }
                if (drv.Row.ItemArray[0].ToString() == "Berchtold, Karl")
                {
                    e.Row.BackColor = System.Drawing.Color.BurlyWood;
                }
                if (drv.Row.ItemArray[0].ToString() == "Santoro, Patricia")
                {
                    e.Row.BackColor = System.Drawing.Color.DarkKhaki;
                }
                if (drv.Row.ItemArray[0].ToString() == "Grand Total")
                {
                    e.Row.BackColor = System.Drawing.Color.Yellow;
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
