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
        DataTable dtCustomer;
        DataTable dtProject;
        DataTable dtProjectChargeNumber;
        DataTable dtPart; 
        DataTable dtCostCenter;
        SqlConnection cnxn;
        SqlConnection cNAV;
        SqlDataReader dr;
        static string SqlTable = "Richmond_Tool_Requests";
        static string filetypeSelected;
        static string filetypeLoaded;
        static bool Ftwofiles = false;
        static bool Ftwofiles2BUploaded = false;
        static string uploadedFilename;
        static string requestResponse;
        static string requestReport;
        static string calendarFlag;
        //static string costcenter;
        static string Sql;
        static string db = "server=CT-MID-SQL11; user=readWrite; password=Read+Write!;" +
                           "database=AccessFrontEnds";
        static string dbNAV = "server=PA-HOR-AS408; user=navdb_read; password=2018#ameteK;" +
                           "database=ZYGO-NAV-PROD";
        static string subjectline;
        static string ename;
        static int uid;
        //static string testing = "YES";
        static string testing = "NO";

        protected void Page_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(db);
            cNAV = new SqlConnection(dbNAV);

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

            /* Customer dropdown data */

            try
            {
                cmd = new SqlCommand("SELECT ' ' AS Name UNION ALL select DISTINCT Name from ZYGO$Customer  where len(Name) > 0 order by Name",cNAV);
                dtCustomer = new DataTable();
                cNAV.Open();
                dr = cmd.ExecuteReader();
                dtCustomer.Load(dr);
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                cNAV.Close();
            }

            /* project dropdown data */

            try
            {
                cmd = new SqlCommand("SELECT ' ' AS Name UNION select COALESCE(Description,'') Name from ZYGO$Job where [Global Dimension 2 Code] in ('EUV','CRYSTALLINE OPTICS','GLASS OPTICS','MACHINED STRUCTURES') ORDER BY Name", cNAV);
                dtProject = new DataTable();
                cNAV.Open();
                dr = cmd.ExecuteReader();
                dtProject.Load(dr);
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                cNAV.Close();
            }

            /* project charge number dropdown data */

            try
            {
                cmd = new SqlCommand("SELECT ' ' AS Number UNION select COALESCE(No_,'') Number  from ZYGO$Job where [Global Dimension 2 Code] in ('EUV','CRYSTALLINE OPTICS','GLASS OPTICS','MACHINED STRUCTURES') ORDER BY Number", cNAV);
                dtProjectChargeNumber = new DataTable();
                cNAV.Open();
                dr = cmd.ExecuteReader();
                dtProjectChargeNumber.Load(dr);
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                cNAV.Close();
            }


            /* cost center dropdown data */

            try
            {
                cmd = new SqlCommand("SELECT ' ' AS Number UNION select Code + '  ' + Name As Number from [ZYGO$Dimension Value] WHERE [Dimension Code] = 'COSTCENTER' AND Blocked = 0 ORDER BY Number", cNAV);
                dtCostCenter = new DataTable();
                cNAV.Open();
                dr = cmd.ExecuteReader();
                dtCostCenter.Load(dr);
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                cNAV.Close();
            }


            /* part dropdown data */

            try
            {
                cmd = new SqlCommand("SELECT ' ' AS Part UNION ALL select No_ Part from ZYGO$Item where [Global Dimension 2 Code] in ('EUV','CRYSTALLINE OPTICS','GLASS OPTICS','MACHINED STRUCTURES') ORDER BY Part", cNAV);
                dtPart = new DataTable();
                cNAV.Open();
                dr = cmd.ExecuteReader();
                dtPart.Load(dr);
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                cNAV.Close();
            }

            /*      */

            cnxn = new SqlConnection(db);

            cmd = new SqlCommand(
                "select top 1 id FROM " + SqlTable + " order by id desc", cnxn);

            cnxn.Open();
            object o = cmd.ExecuteScalar();
            cnxn.Close();

            /* uid gets updated every postback with last submitted value
             * does not get current value until postback from button click
             * to upload file
             */
            uid = Convert.ToInt32(o);
                        
            cmd = new SqlCommand(
                "SELECT FlagAnother FROM Richmond_Tool_Appendix", cnxn);
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
                        "DELETE FROM Richmond_Tool_Appendix", cnxn);
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
                        "employeeDDL " +                      
                        ",requestor_email " +
                        ",customer " +            
                        ",project" +              
                        ",part" +              
                        ",project_charge_number " +              
                        ",quantity " +
                       "FROM Richmond_Tool_Appendix", cnxn);

                    cnxn.Open();

                    dr = cmd.ExecuteReader();

                    DataTable dt = new DataTable();

                    dt.Load(dr);

                    DDLemployee.Text = dt.Rows[0][0].ToString().Trim();
                    tbContactEmail.Text = dt.Rows[0][1].ToString().Trim();
                    ddlCustomer.Text = dt.Rows[0][2].ToString().Trim();
                    ddlProject.Text = dt.Rows[0][3].ToString().Trim();
                    ddlPart.Text = dt.Rows[0][4].ToString().Trim();
                    ddlChargeNumber.Text = dt.Rows[0][5].ToString().Trim();
                    tbQuantity.Text = dt.Rows[0][6].ToString().Trim();
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
                ddlCustomer.DataSource = dtCustomer;
                ddlCustomer.DataTextField = "Name";
                ddlCustomer.DataValueField = "Name";
                ddlCustomer.DataBind();
                ddlProject.DataSource = dtProject;
                ddlProject.DataTextField = "Name";
                ddlProject.DataValueField = "Name";
                ddlProject.DataBind();
                if (cbProjectcharge.Checked)
                {
                    ddlChargeNumber.DataSource = dtProjectChargeNumber;
                }
                if (cbCostCenter.Checked)
                {
                    ddlChargeNumber.DataSource = dtCostCenter;
                }
                ddlChargeNumber.DataTextField = "Number";
                ddlChargeNumber.DataValueField = "Number";
                ddlChargeNumber.DataBind();
                ddlPart.DataSource = dtPart;
                ddlPart.DataTextField = "Part";
                ddlPart.DataValueField = "Part";
                ddlPart.DataBind();
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
                "Priority........: " + DDLPriority.Text + "\r" +
                "Quantity........: " + tbQuantity.Text + "\r" +
                "Need Date.......: " + calendar1.SelectedDate.ToString() + "\r" +
                "Customer Name...: " + ddlCustomer.Text + "\r" +
                "Project.........: " + ddlProject.Text + "\r" +
                "Part............: " + ddlPart.Text + "\r" +
                "Department......: " + ddlDepartment.Text + "\r" +
                "Tool Request Description: " +
                "\r\r" +
                tbRequest_Text.Text +
                "\r\r" +
                "Link to View Request Status:" + "\r" +
                "If you have any questions, please visit us as out Tooling Office Hours on XXXX";

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
                "Priority........: " + DDLPriority.Text + "\r" +
                "Quantity........: " + tbQuantity.Text + "\r" +
                "Need Date.......: " + calendar1.SelectedDate.ToString() + "\r" +
                "Customer Name...: " + ddlCustomer.Text + "\r" +
                "Project.........: " + ddlProject.Text + "\r" +
                "Part............: " + ddlPart.Text + "\r" +
                "Department......: " + ddlDepartment.Text + "\r" +
                "Date of Submission: " +
                submitDate;

            cnxn = new SqlConnection(db);

            SqlParameter pSubjectLine = new SqlParameter("@subject_line", SqlDbType.VarChar, 4000);
            pSubjectLine.Value = subjectline;
            SqlParameter pName = new SqlParameter("@name", SqlDbType.VarChar, 100);
            pName.Value = ename;

            SqlParameter Request_Text = new SqlParameter("@request_text", SqlDbType.VarChar, 4000);
            Request_Text.Value = tbRequest_Text.Text.Trim();
            
            SqlParameter pDepartment = new SqlParameter("@department", SqlDbType.VarChar, 50);
            ddlEntry(ddlDepartment, pDepartment);

            SqlParameter pCustomer = new SqlParameter("@Customer", SqlDbType.VarChar, 50);
            ddlEntry(ddlCustomer,pCustomer);

            SqlParameter pProject = new SqlParameter("@Project", SqlDbType.VarChar, 20);
            ddlEntry(ddlProject,pProject);
            
            SqlParameter pPart = new SqlParameter("@Part", SqlDbType.VarChar, 50);
            ddlEntry(ddlPart, pPart);

            SqlParameter pQuantity = new SqlParameter("@quantity", SqlDbType.Int);
            pQuantity.Value = tbQuantity.Text.Trim();
            SqlParameter ContactEmail = new SqlParameter("@ContactEmail", SqlDbType.VarChar, 50);
            ContactEmail.Value = tbContactEmail.Text.Trim();
            SqlParameter Priority = new SqlParameter("@priority", SqlDbType.VarChar, 25);
            Priority.Value = DDLPriority.Text;
            SqlParameter report = new SqlParameter("@report", SqlDbType.VarChar, 5000);
            report.Value = requestReport;
            SqlParameter response = new SqlParameter("@response", SqlDbType.VarChar, 5000);
            response.Value = requestResponse;

            SqlParameter pProjectChargeNumber = new SqlParameter("@ProjectChargeNumber", SqlDbType.VarChar, 50);
            ddlEntry(ddlChargeNumber, pProjectChargeNumber);
                        
            SqlParameter pOpticDrawingPath = new SqlParameter("@OpticDrawingPath", SqlDbType.VarChar, 200);
            tbEntry(tbOpticDrawing_Path, pOpticDrawingPath);
            
            SqlParameter pExistingTool = new SqlParameter("@ExistingTool", SqlDbType.VarChar, 50);
            tbEntry(tbExistingTool,pExistingTool);

            SqlParameter pToolDescription = new SqlParameter("@ToolDescription", SqlDbType.VarChar, 50);
            tbEntry(tbToolDescription, pToolDescription);

            SqlParameter pMachineNumber = new SqlParameter("@MachineNumber", SqlDbType.VarChar, 50);
            pMachineNumber.Value = tbMachineNumber.Text.Trim();

            SqlParameter pFocalSurface = new SqlParameter("@FocalSurface", SqlDbType.VarChar, 50);
            pFocalSurface.Value = tbFocalSurface.Text.Trim();


            SqlParameter pAnodized = new SqlParameter("@Anodized", SqlDbType.Bit);
            if (cbAnodized.Checked == true)
            {
                pAnodized.Value = 1;
            }
            else
            {
                pAnodized.Value = 0;
            }

            SqlParameter pTechnicalContactName = new SqlParameter("@TechnicalContactName", SqlDbType.VarChar, 50);
            pTechnicalContactName.Value = tbTechnicalContactName.Text.Trim();

            SqlParameter pDesignReviewParticipants = new SqlParameter("@DesignReviewParticipants", SqlDbType.VarChar, 2000);
            pDesignReviewParticipants.Value = tbDesignReviewParticipants.Text.Trim();

            SqlParameter pDeliverTo = new SqlParameter("@DeliverTo", SqlDbType.VarChar, 50);
            pDeliverTo.Value = tbDeliverTo.Text.Trim();

            SqlParameter pAdditionalInformation = new SqlParameter("@AdditionalInformation", SqlDbType.VarChar, 1000);
            pAdditionalInformation.Value = tbAdditionalInformation.Text.Trim();
                       

            cnxn.Open();

            SqlCommand cmd = new SqlCommand("Insert into " + SqlTable + " (" +
                    " request_date " +
                    ",request_text " +
                    ",quantity " +
                    ",request_need_date " +
                    ",priority " +
                    ",requestor " +                        //10
                    ",requestor_email " +
                    ",subject_line " +
                    ",request_response_email_body " +
                    ",request_report_email_body " +
                    ",[Department] " +
                    ",OpticDrawing_Path " +
                    ",ExistingTool4Modification " +
                    ",ToolDescription " +
                    ",Customer" +
                    ",project" +
                    ",project_charge_number " +
                    ",Part" +
                    ",AdditionalInformation" +
                    ",Anodized " +
                    ",TechnicalContactName " +
                    ",DesignReviewParticipants " +
                    ",FocalSurface " +
                    ") values (" +
                    "'" + DateTime.Now.Date +        //1
                    "'," + Request_Text +
                    "," + pQuantity +
                    ",'" + calendar1.SelectedDate +
                    "','" + DDLPriority.Text +                                //10
                    "'," + pName +
                    "," + ContactEmail +
                    "," + pSubjectLine +
                    "," + response +
                    "," + report +
                    "," + pDepartment +
                    "," + pOpticDrawingPath +
                    "," + pExistingTool +
                    "," + pToolDescription +
                    "," + pCustomer +
                    "," + pProject +
                    "," + pProjectChargeNumber +
                    "," + pPart +
                    "," + pAdditionalInformation +
                    "," + pAnodized +
                    "," + pTechnicalContactName +
                    "," + pDesignReviewParticipants +
                    "," + pFocalSurface +
                    ")", cnxn);
            cmd.Parameters.Add(Request_Text);
            cmd.Parameters.Add(pQuantity);
            cmd.Parameters.Add(ContactEmail);
            cmd.Parameters.Add(Priority);
            cmd.Parameters.Add(response);
            cmd.Parameters.Add(pSubjectLine);
            cmd.Parameters.Add(pName);
            cmd.Parameters.Add(report);
            cmd.Parameters.Add(pDepartment);
            cmd.Parameters.Add(pOpticDrawingPath);
            cmd.Parameters.Add(pExistingTool);
            cmd.Parameters.Add(pToolDescription);
            cmd.Parameters.Add(pCustomer);
            cmd.Parameters.Add(pProject);
            cmd.Parameters.Add(pProjectChargeNumber);
            cmd.Parameters.Add(pPart);
            cmd.Parameters.Add(pAdditionalInformation);
            cmd.Parameters.Add(pAnodized);
            cmd.Parameters.Add(pTechnicalContactName);
            cmd.Parameters.Add(pDesignReviewParticipants);
            cmd.Parameters.Add(pFocalSurface);

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
                cmd = new SqlCommand("Insert into RICHMOND_Tool_Appendix (" +
                    " employeeDDL " +                        //10
                    ",requestor_email " +
                    ",customer " +              //5
                    ",project" +              //5
                    ",part" +              //5
                    ",project_charge_number " +              //5
                    ",quantity ) " +
                    "SELECT " +
                    "'" + DDLemployee.Text.Trim() + "'" +
                    ",requestor_email " +
                    ",customer " +
                    ",project" +              //5
                    ",part " +
                    ",project_charge_number " +
                    ",quantity " +
                    "FROM RICHMOND_TOOL_REQUESTS " +
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
            Luid.Text = "Richmond Tool Request Number: " + (uid + 1).ToString();
            Luid.Visible = true;
            Lattach.Visible = true;


            if (cbPDF.Checked == false & cbDXF.Checked == false)
            {

                Email();
                uid = 0;

                Response.Redirect("trThankYou.aspx");
            }
            else if (cbPDF.Checked == true & cbDXF.Checked == false)
            {
                filetypeSelected = "pdf";
                FileUpload();
            }
            else if (cbPDF.Checked == true & cbDXF.Checked == true)
            {
                Ftwofiles = true;
                Ftwofiles2BUploaded = true;
                filetypeSelected = "pdf";
                FileUpload();
            }
            else if (cbPDF.Checked == false & cbDXF.Checked == true)
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

                SqlCommand cmd = new SqlCommand("spTRmailRic", cnxn);
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

                cmd = new SqlCommand("spTRmailRic", cnxn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter to1 = cmd.Parameters.Add("@to", SqlDbType.NChar, 100);
                //to1.Value = "tor.hepburn@ametek.com";
                to1.Value = "sabrina.ng@ametek.com; ca-ric.ToolRoom@ametek.com";
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

        protected void tbEntry(TextBox box, SqlParameter p)
        {
            if (box.Text.Length > 0)
            {
                p.Value = box.Text.Trim();
            }
            else
            {
                p.Value = "";
            }
        }

        protected void ddlEntry(DropDownList ddl, SqlParameter p)
        {
            if (ddl.Text.Trim() !=  "Selection Required")
            {
                p.Value = ddl.Text.Trim();
            }
            else
            {
                p.Value = "";
            }
        }

        protected void cbProjectcharge_CheckedChanged(object sender, EventArgs e)
        {
            if (cbProjectcharge.Checked)
            {
                LChargeType.Text = "Project Charge # ::";
                LChargeType.Visible = true;
                ddlChargeNumber.DataSource = dtProjectChargeNumber;
                ddlChargeNumber.DataTextField = "Number";
                ddlChargeNumber.DataValueField = "Number";
                ddlChargeNumber.DataBind();
                ddlChargeNumber.Visible = true;
            }
            else
            {
                LChargeType.Text = string.Empty;
                LChargeType.Visible = false;
                ddlChargeNumber.Visible = false;
            }
        }

        protected void cbCostCenter_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCostCenter.Checked)
            {
                LChargeType.Text = "Cost Center ::";
                LChargeType.Visible = true;
                ddlChargeNumber.DataSource = dtCostCenter;
                ddlChargeNumber.DataTextField = "Number";
                ddlChargeNumber.DataValueField = "Number";
                ddlChargeNumber.DataBind();
                ddlChargeNumber.Visible = true;
            }
            else
            {
                LChargeType.Text = string.Empty;
                LChargeType.Visible = false;
                ddlChargeNumber.Visible = false;
            }
        }
    }
}
