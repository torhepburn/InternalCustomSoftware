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
using System.Net.Mail;
using System.Data.SqlClient;

namespace ToolRoom
{
    public partial class _Default : System.Web.UI.Page
    {
        DataTable table;
        DataTable table1;
        SqlConnection cnxn;
        SqlDataReader dr;
        static string SqlTable = "Tool_Requests";
        static string filetypeSelected;
        static string filetypeLoaded;
        static bool Ftwofiles = false;
        static bool Ftwofiles2BUploaded = false;
        static string uploadedFilename;
        static string requestResponse;
        static string requestReport;
        static string calendarFlag;
        static string costcenter;
        static string Sql;
        static string db = "server=CT-MID-SQL11; user=readWrite; password=Read+Write!;" +
                           "database=AccessFrontEnds";
        static string subjectline;
        static string ename;
        static int uid;
        static string testing = "NO";

        protected void Page_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(db);

                        //get data to fill employee drop down list and text boxes.    
            //start with blank first line so ddl shows no selection

            SqlCommand cmd = new SqlCommand
                ("select " +
                 "' ' as Name " +
                 ",' ' as email " +
                 ",' ' as sn " +
                 "UNION ALL " +
                 "SELECT " +
                 "  sn + ' : ' + cn [Name] " +
                 ", mail email " +
                 ", sn " +
                 "FROM EmployeesAmetekAD " +
                 "order by  " +
                 "sn ", cnxn);

            table = new DataTable();

            cnxn.Open();

            dr = cmd.ExecuteReader();

            table.Load(dr);

            cnxn.Close();

            cnxn = new SqlConnection(db);

            cmd = new SqlCommand(
                "select top 1 id FROM " + SqlTable +  " order by id desc", cnxn);

            cnxn.Open();
            object o = cmd.ExecuteScalar();
            cnxn.Close();

            /* uid gets updated every postback with last submitted value
             * does not get current value until postback from button click
             * to upload file
             */
            uid = Convert.ToInt32(o);

            cmd = new SqlCommand
                ("select " +
                 "'' as CostCenter, " +
                 "'Select' as CostCenterDescription, " +
                 "'Cost' as ResponsibleOwner, " +
                 "'Center' as BusinessUnit " +
                 "union " +
                 "select " +
                 "CostCenter, " +
                 "CostCenterDescription, " +
                 "ResponsibleOwner, " +
                 "BusinessUnit " +
                 "from ExpenseCostCenters " +
                 "where costcenter > 0 order by CostCenter", cnxn);

            table1 = new DataTable();

            cnxn.Open();

            dr = cmd.ExecuteReader();

            table1.Load(dr);

            cnxn.Close();

            DataColumn dc = new DataColumn("combined");
            dc.Expression = string.Format("{0}+'----'+{1} + '----' + {2} + '----' + {3}",
                "CostCenter", "CostCenterDescription", "ResponsibleOwner", "BusinessUnit");
            table1.Columns.Add(dc);

            cmd = new SqlCommand(
                "SELECT FlagAnother FROM Tool_Appendix", cnxn);
            string flag = string.Empty;

            try
            {
                cnxn.Open();
                flag = (string)cmd.ExecuteScalar();
            }
            catch
            {

            }
            finally
            {
                cnxn.Close();
            }

            if (flag != "YES")
            {
                try
                {
                    cmd = new SqlCommand(
                        "DELETE FROM Tool_Appendix", cnxn);
                    cnxn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch
                {

                }
                finally
                {
                    cnxn.Close();
                }
            }
            else
            {
                try
                {
                    cmd = new SqlCommand(
                        "SELECT " +
                        "cost_center " +
                       ",project" +
                       ",request_text " +
                       ",priority " +
                       ",employeeDDL " +
                       ",requestor_phone " +
                       ",requestor_email " +
                       ",type " +
                       "FROM Tool_Appendix", cnxn);

                    cnxn.Open();

                    dr = cmd.ExecuteReader();

                    DataTable dt = new DataTable();

                    dt.Load(dr);

                    DDLcostCenter.Text = dt.Rows[0][0].ToString().Trim();
                    tbProject.Text = dt.Rows[0][1].ToString().Trim();
                    tbRequest_Text.Text = dt.Rows[0][2].ToString().Trim();
                    DDLPriority.Text = dt.Rows[0][3].ToString().Trim();
                    DDLemployee.Text = dt.Rows[0][4].ToString().Trim();
                    tbPhone.Text = dt.Rows[0][5].ToString().Trim();
                    tbContactEmail.Text = dt.Rows[0][6].ToString().Trim();
                    ddlType.Text = dt.Rows[0][7].ToString().Trim();
                }
                catch (SqlException ex)
                {
                    Lerror.Text = ex.ToString();
                }
                finally
                {
                    cnxn.Close();
                }
            }


            //this keeps the selections in the boxes

            if (!IsPostBack)
            {

                DDLemployee.DataSource = table;
                DDLemployee.DataTextField = "Name";
                DDLemployee.DataValueField = "Name";
                DDLemployee.DataBind();
                DDLcostCenter.DataSource = table1;
                DDLcostCenter.DataTextField = "combined";
                DDLcostCenter.DataValueField = "CostCenter";
                DDLcostCenter.DataBind();
            }
        }

        protected void DDLemployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lname.Visible = false;
            int nn = DDLemployee.SelectedIndex;
            tbContactEmail.Text = table.Rows[nn].ItemArray[1].ToString().Trim();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            /*
             * this is the submit button
             */

            Lerror.Text = "Button click";

            if (DDLemployee.Text.Length < 2)
            {
                Lname.Visible = true;
                return;
            }
            else
            {
                Lname.Visible = false;
            }

            if (tbTimeSavingsEstimate.Text.Length < 1)
            {
                LTimeSavingRequired.Visible = true;
                return;
            }
            else
            {
                LTimeSavingRequired.Visible = false;
            }

            if (tbCostSavingsEstimate.Text.Length < 1)
            {
                LCostSavingRequired.Visible = true;
                return;
            }
            else
            {
                LCostSavingRequired.Visible = false;
            }

            if (tbRevenueSavingsEstimate.Text.Length < 1)
            {
                LRevenueSavingRequired.Visible = true;
                return;
            }
            else
            {
                LRevenueSavingRequired.Visible = false;
            }

            if (ddlType.SelectedIndex == 0)
            {
                Lerror.Visible = true;
                Lerror.Text = "Request Type selection required.";
                return;
            }
            else
            {
                Lerror.Visible = false;
            }

            if (DDLcostCenter.SelectedIndex == 0)
            {
                Lerror.Visible = true;
                Lerror.Text = "Cost Center entry required.";
                return;
            }
            else
            {
                Lerror.Visible = false;
            }

            if (tbQuantity.Text.Length < 1)
            {
                Lerror.Text = "Quantity must be a number - no 'ea'.";
                Lerror.Visible = true;
                return;
            }
            else
            {
                Lerror.Visible = false;
            }

            if (calendar1.SelectedDate.Date.Year == 1)
            {
                Ldate.Visible = true;
                return;
            }
            else
            {
                Ldate.Visible = false;
            }


            if (tbRequest_Text.Text.Length < 1)
            {
                Ltrouble.Visible = true;
                return;
            }
            else
            {
                Ltrouble.Visible = false;
            }

            ename = DDLemployee.Text.Substring(DDLemployee.Text.IndexOf(':') + 2);

            //first send an email to requestor
            string emailto = tbContactEmail.Text;
            string submitDate = DateTime.Now.ToString();

            requestResponse =
                "Dear " + DDLemployee.Text.Substring(DDLemployee.Text.IndexOf(':') + 2) + "," +
                "\n\r" +
                "Here is the information which you submitted on your recent tool request:" +
                "\n\r" +
                "Date and Time of Submission: " +
                submitDate + "  Eastern Standard Time" +
                "\n\r" +
                "Name............: " + ename + "\n\r" +
                "Contact eMail...: " + tbContactEmail.Text + "\n\r" +
                "Ext.............: " + tbPhone.Text + "\r" +
                "Priority........: " + DDLPriority.Text + "\r" +
                "Quantity........: " + tbQuantity.Text + "\r" +
                "Need Date.......: " + calendar1.SelectedDate.ToString() + "\r" +
                "Project.........: " + tbProject.Text + "\r" +
                "Rework Number...: " + tbRework.Text + "\r" +
                "Cost Center.....: " + DDLcostCenter.Text + "\n\r" +
                "Time Savings Est: " + tbTimeSavingsEstimate.Text + "\n\r" +
                "Cost Savings Est: " + tbCostSavingsEstimate.Text + "\n\r" +
                "Revenue Savings Est: " + tbRevenueSavingsEstimate.Text + "\n\r" +
                "Tool Request Description: " +
                "\r\r" +
                tbRequest_Text.Text;

            // email to tool room to report request

            subjectline = "Tool Request: " + tbContactEmail.Text;

            requestReport =
                "Tool Request Description: " +
                "\r\r" +
                tbRequest_Text.Text +
                "\r\r" +
                "Quantity.......: " + tbQuantity.Text + "\r\r\r" +
                "Name...........: " + ename + "\n\r" +
                "Contact eMail..: " + tbContactEmail.Text + "\n\r" +
                "Ext............: " + tbPhone.Text + "\r" +
                "Project........: " + tbProject.Text + "\r" +
                "Rework Number..: " + tbRework.Text + "\r" +
                "Cost Center....: " + DDLcostCenter.Text + "\r" +
                "\r" +
                "Date of Submission: " +
                submitDate;

            cnxn = new SqlConnection(db);

            SqlParameter pSubjectLine = new SqlParameter("@subject_line", SqlDbType.VarChar, 4000);
            pSubjectLine.Value = subjectline;
            SqlParameter pName = new SqlParameter("@name", SqlDbType.VarChar, 100);
            pName.Value = ename;

            SqlParameter Request_Text = new SqlParameter("@request_text", SqlDbType.VarChar, 4000);
            Request_Text.Value = tbRequest_Text.Text.Trim();
            SqlParameter Phone = new SqlParameter("@Phone", SqlDbType.VarChar, 50);
            Phone.Value = tbPhone.Text.Trim();
            SqlParameter Quantity = new SqlParameter("@quantity", SqlDbType.Int);
            Quantity.Value = tbQuantity.Text.Trim();
            SqlParameter CostCenter = new SqlParameter("@costCenter", SqlDbType.VarChar, 6);
            CostCenter.Value = DDLcostCenter.Text.Trim();
            SqlParameter Project = new SqlParameter("@Project", SqlDbType.VarChar, 20);
            Project.Value = tbProject.Text.Trim();
            SqlParameter ContactEmail = new SqlParameter("@ContactEmail", SqlDbType.VarChar, 50);
            ContactEmail.Value = tbContactEmail.Text.Trim();
            SqlParameter Priority = new SqlParameter("@priority", SqlDbType.VarChar, 25);
            Priority.Value = DDLPriority.Text;
            SqlParameter report = new SqlParameter("@report", SqlDbType.VarChar, 5000);
            report.Value = requestReport;
            SqlParameter response = new SqlParameter("@response", SqlDbType.VarChar, 5000);
            response.Value = requestResponse;
            SqlParameter Rework = new SqlParameter("@Rework", SqlDbType.VarChar);
            if (tbRework.Text.Length > 0)
            {
                Rework.Value = tbRework.Text.Trim();
            }
            else
            {
                Rework.Value = "";
            }
            SqlParameter pType = new SqlParameter("@type", SqlDbType.VarChar, 10);
            pType.Value = ddlType.Text;
            SqlParameter pTime = new SqlParameter("@TimeSavings", SqlDbType.VarChar, 10);
            if (tbTimeSavingsEstimate.Text.Length > 0)
            {
                pTime.Value = tbTimeSavingsEstimate.Text.Trim();
            }
            else
            {
                pTime.Value = "";
            }
            SqlParameter pCost = new SqlParameter("@CostSavings", SqlDbType.VarChar, 10);
            if (tbCostSavingsEstimate.Text.Length > 0)
            {
                pCost.Value = tbCostSavingsEstimate.Text.Trim();
            }
            else
            {
                pCost.Value = "";
            }

            SqlParameter pRevenue = new SqlParameter("@RevenueSavings", SqlDbType.VarChar, 10);
            if (tbRevenueSavingsEstimate.Text.Length > 0)
            {
                pRevenue.Value = tbRevenueSavingsEstimate.Text.Trim();
            }
            else
            {
                pRevenue.Value = "";
            }

            cnxn.Open();

            SqlCommand cmd = new SqlCommand("Insert into " + SqlTable + " (" +
                    " request_date " +
                    ",request_text " +
                    ",quantity " +
                    ",cost_center " +
                    ",project" +              //5
                    ",request_need_date " +
                    ",priority " +
                    ",requestor " +                        //10
                    ",requestor_phone " +
                    ",requestor_email " +
                    ",subject_line " +
                    ",request_response_email_body " +
                    ",request_report_email_body " +
                    ",rework_order_number " +
                    ",[type] " +
                    ",TimeSavingsEstimate " +
                    ",CostSavingsEstimate " +
                    ",RevenueSavingsEstimate " +
                    ") values (" +
                    "'" + DateTime.Now.Date +        //1
                    "'," + Request_Text +
                    "," + Quantity +
                    "," + CostCenter +
                    "," + Project +
                    ",'" + calendar1.SelectedDate +
                    "','" + DDLPriority.Text +                                //10
                    "'," + pName +
                    "," + Phone +
                    "," + ContactEmail +
                    "," + pSubjectLine +
                    "," + response +
                    "," + report +
                    "," + Rework +
                    "," + pType +
                    "," + pTime +
                    "," + pCost +
                    "," + pRevenue +
                    ")", cnxn);
            cmd.Parameters.Add(Request_Text);
            cmd.Parameters.Add(Quantity);
            cmd.Parameters.Add(Phone);
            cmd.Parameters.Add(ContactEmail);
            cmd.Parameters.Add(Priority);
            cmd.Parameters.Add(response);
            cmd.Parameters.Add(pSubjectLine);
            cmd.Parameters.Add(pName);
            cmd.Parameters.Add(report);
            cmd.Parameters.Add(CostCenter);
            cmd.Parameters.Add(Project);
            cmd.Parameters.Add(Rework);
            cmd.Parameters.Add(pType);
            cmd.Parameters.Add(pTime);
            cmd.Parameters.Add(pCost);
            cmd.Parameters.Add(pRevenue);

            try
            {
                int rowsReturned = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Lerror.Visible = true;
                Lerror.Text = ex.ToString();
                return;
            }
            finally
            {
                cnxn.Close();
            }

            cmd.Dispose();

            /* if cbPersist need to save the data and reload it on next page load  */

            if (cbPersist.Checked)
            {
                cmd = new SqlCommand("Insert into Tool_Appendix (" +
                    "cost_center " +
                    ",project" +              //5
                    ",request_text " +
                    ",priority " +
                    ",employeeDDL " +                        //10
                    ",requestor_phone " +
                    ",requestor_email " +
                    ",type ) " +
                    "SELECT " +
                    "cost_center " +
                    ",project" +              //5
                    ",request_text " +
                    ",priority " +
                    ",'" + DDLemployee.Text.Trim() + "'" +                        //10
                    ",requestor_phone " +
                    ",requestor_email " +
                    ",type " +
                    "FROM TOOL_REQUESTS " +
                    "WHERE ID =" + (uid + 1)
                    , cnxn);

                try
                {
                    cnxn.Open();
                    int rowsReturned = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Lerror.Visible = true;
                    Lerror.Text = ex.ToString();
                    return;
                }
                finally
                {
                    cnxn.Close();
                }
            }
            else
            {

            }
            
            
            Ltrouble.Visible = false;

            /* need to show the Tool Request Number for the item being associated */
            Luid.Text = "Tool Request Number: " + (uid + 1).ToString();
            Luid.Visible = true;
            Lattach.Visible = true;


            if (cbPDF.Checked & cbDXF.Checked)
            {

                Email();
                uid = 0;

                Response.Redirect("trThankYou.aspx");
            }
            else if (cbPDF.Checked == false & cbDXF.Checked == true)
            {
                filetypeSelected = "pdf";
                FileUpload();
            }
            else if (cbPDF.Checked == false & cbDXF.Checked == false)
            {
                Ftwofiles = true;
                Ftwofiles2BUploaded = true;
                filetypeSelected = "pdf";
                FileUpload();
            }
            else if (cbPDF.Checked == true & cbDXF.Checked == false)
            {
                filetypeSelected = "dxf";
                FileUpload();
            }

            //Email();
        }

        protected void FileUpload()
        {
            Button2.Visible = true;
            FileUpload1.Visible = true;
            LuploadDocs.Visible = true;
            Lattach.Text = "Attach " + filetypeSelected + " doccument now.";
            Button2.Text = "Upload Selected " + filetypeSelected + " Document";
            LfileType.Text = "Must Select a " + filetypeSelected + " Document";

            if (filetypeSelected == "dxf")
            {
                LuploadDocs.Text = "DXF File Must Be Scale 1:1.  No Step Files";
            }
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            /*
             * Upload file button
             */

            if (FileUpload1.PostedFile.FileName.ToLower().Contains(".pdf"))
            {
                filetypeLoaded = "pdf";
            }

            if (FileUpload1.PostedFile.FileName.ToLower().Contains(".dxf"))
            {
                filetypeLoaded = "dxf";
                uploadedFilename = FileUpload1.PostedFile.FileName.Substring(
                    (FileUpload1.PostedFile.FileName.LastIndexOf("\\") + 1),
                    FileUpload1.PostedFile.FileName.Length - 
                    (FileUpload1.PostedFile.FileName.LastIndexOf("\\") + 1));
            }


            if (Ftwofiles2BUploaded == true & Ftwofiles == false)
            {
                filetypeSelected = "dxf";
            }

            if (filetypeLoaded != filetypeSelected)
            {
                LfileType.Visible = true;
                return;
            }

            SqlConnection cnxn = new SqlConnection(db);

            if (filetypeLoaded == "pdf")
            {

                SqlParameter prm1 = new SqlParameter
                    ("@file", SqlDbType.Image, Convert.ToInt32(FileUpload1.FileBytes.Length));
                prm1.Value = FileUpload1.FileBytes;

                SqlCommand cmd = new SqlCommand
                    ("Update " + SqlTable + " set uploaded_pdf = " + prm1 + "  " +
                     " where id = " + uid + " ", cnxn);
                cmd.Parameters.Add(prm1);

                cnxn.Open();
                cmd.ExecuteNonQuery();
                cnxn.Close();

             /*
             * If there are two files to be uploaded the first will always be the pdf
             * and the second the dxf.  The 'true' flag is used to determine if there is a dxf.
             */

                if (Ftwofiles)
                {
                    Ftwofiles = false;
                    filetypeSelected = "dxf";
                    FileUpload();
                }


                if (Ftwofiles2BUploaded == false)
                {
                    Email();
                    Response.Redirect("trThankYou.aspx");
                }
            }

            if (filetypeLoaded == "dxf")
            {

                SqlParameter prm2 = new SqlParameter
                    ("@file", SqlDbType.VarBinary, Convert.ToInt32(FileUpload1.FileBytes.Length));
                prm2.Value = FileUpload1.FileBytes;

                SqlCommand cmd = new SqlCommand
                    ("Update " + SqlTable + " set uploaded_dxf = " + prm2 + ",  " +
                     " uploaded_filename = '" + uploadedFilename + "' " +
                     " where id = " + uid + " ", cnxn);
                cmd.Parameters.Add(prm2);

                cnxn.Open();
                cmd.ExecuteNonQuery();
                cnxn.Close();

                Email();
                Response.Redirect("trThankYou.aspx");
            }

        }

        protected void Email()
        {
            if (testing != "YES")
            {
                /*    REQUEST RESPONSE    */

                SqlCommand cmd = new SqlCommand("TRmail", cnxn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter to = cmd.Parameters.Add("@to", SqlDbType.NChar, 100);
                to.Value = tbContactEmail.Text;
                SqlParameter etext = cmd.Parameters.Add("@etext", SqlDbType.VarChar, 4000);
                etext.Value = requestResponse;
                SqlParameter subjline = cmd.Parameters.Add("@subjectline", SqlDbType.NChar, 60);
                subjline.Value = subjectline;

                cmd.Connection = cnxn;
                cnxn.Open();
                cmd.ExecuteNonQuery();
                cnxn.Close();
                cmd.Dispose();

                /*    REQUEST REPORT to TOOL ROOM    */

                cmd = new SqlCommand("TRmail", cnxn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter to1 = cmd.Parameters.Add("@to", SqlDbType.NChar, 100);
                to1.Value = "jim.welsch@ametek.com; ct-mid.toolroom@ametek.com";
                SqlParameter etext1 = cmd.Parameters.Add("@etext", SqlDbType.VarChar, 4000);
                etext1.Value = requestReport;
                SqlParameter subjline1 = cmd.Parameters.Add("@subjectline", SqlDbType.NChar, 60);
                subjline1.Value = subjectline;
                cmd.Connection = cnxn;
                cnxn.Open();
                cmd.ExecuteNonQuery();
                cnxn.Close();
                cmd.Dispose();
            }
        }

        protected void calendar1_SelectionChanged(object sender, EventArgs e)
        {
            calendarFlag = "selected";
        }

        protected void calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < DateTime.Today)
            {
                e.Day.IsSelectable = false;
            }
        }
    }
}
