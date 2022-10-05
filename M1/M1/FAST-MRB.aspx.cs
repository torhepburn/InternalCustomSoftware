using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data;


namespace M1
{
    public partial class FASTinv : System.Web.UI.Page
    {
        SqlConnection cnxn;
        SqlCommand SqlCmd;
        DataTable table;

        protected void Page_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection
                    ("server = midsql01; user = ReadWrite; " +
                     "password = Read+Write!; database = AccessFrontEnds;");
            SqlDataAdapter da = new SqlDataAdapter
                    ("select * from Fast_MRB_Z " +
                        "order by [FAST Responsible User],  " +
                        "[Part Number]", cnxn);
            table = new DataTable();
            da.Fill(table);



            GridView1.DataSource = table;
            GridView1.DataBind();
            //GridView1.Columns[5].Visible = false;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                object t = (e.Row.DataItem as DataRowView).Row.ItemArray[0];
                DataRowView drv = (DataRowView)e.Row.DataItem;

                if (drv.Row.ItemArray[1].ToString() == "Heizman, Bob")
                {
                    e.Row.BackColor = System.Drawing.Color.Salmon;
                }
                else if (drv.Row.ItemArray[1].ToString() == "Kindelan, Davey")
                {
                    e.Row.BackColor = System.Drawing.Color.SteelBlue;
                }
                else if (drv.Row.ItemArray[1].ToString() == "Lamarr, Amanda")
                {
                    e.Row.BackColor = System.Drawing.Color.Turquoise;
                }
                else if (drv.Row.ItemArray[1].ToString() == "Lawrence, Mark")
                {
                    e.Row.BackColor = System.Drawing.Color.MediumPurple;
                }
                else if (drv.Row.ItemArray[1].ToString() == "Morenz, Mark")
                {
                    e.Row.BackColor = System.Drawing.Color.Goldenrod;
                }
                else if (drv.Row.ItemArray[1].ToString() == "Santos, Rick")
                {
                    e.Row.BackColor = System.Drawing.Color.DarkCyan;
                }
                if (drv.Row.ItemArray[1].ToString() == "Vitali, Margaret")
                {
                    e.Row.BackColor = System.Drawing.Color.DarkKhaki;
                }
                if (drv.Row.ItemArray[1].ToString() == "Total")
                {
                    e.Row.BackColor = System.Drawing.Color.LightGreen;
                }
                if (drv.Row.ItemArray[1].ToString() == "Berchtold, Karl")
                {
                    e.Row.BackColor = System.Drawing.Color.BurlyWood;
                }
                if (drv.Row.ItemArray[1].ToString() == "Santoro, Patricia")
                {
                    e.Row.BackColor = System.Drawing.Color.Aquamarine;
                }
                if (drv.Row.ItemArray[1].ToString() == "Grand Total")
                {
                    e.Row.BackColor = System.Drawing.Color.Yellow;
                }
                if (drv.Row.ItemArray[1].ToString() == "McClard, Robert")
                {
                    e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                }
                if (drv.Row.ItemArray[1].ToString() == "Raygoza, Carlos")
                {
                    e.Row.BackColor = System.Drawing.Color.MediumOrchid;
                }

                Label l_lbl_fastid = (Label)e.Row.FindControl("lbl_FastID");
                HyperLink l_HL_fastid = (HyperLink)e.Row.FindControl("HL_FastID");
                l_HL_fastid.NavigateUrl = "//dashboard-ct/zto/app/fast/fastedit.aspx?id=" +
                    l_lbl_fastid.Text;
                l_HL_fastid.Text = "Click";
            }

        }

        protected void ExportToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("content-disposition", "attachment;filename=MyFiles.xls");
            Response.Charset = "";
            this.EnableViewState = false;

            System.IO.StringWriter sw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htw = new HtmlTextWriter(sw);

            GridView1.RenderControl(htw);

            Response.Write(sw.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void BbExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

    }

}
    
