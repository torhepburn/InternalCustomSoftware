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

namespace PM
{
    public partial class PMtest : System.Web.UI.Page
    {
        DataTable table;
        DataTable table1;
        SqlConnection cnxn;
        private string submitDate;
        static string supervisor;
        static string superemail;
        static string owneremail;

        protected void Page_Load(object sender, EventArgs e)
        {
            //get data to fill equipment drop down list and text boxes.    
            //start with blank first line so ddl shows no selection

            cnxn = new SqlConnection
                ("server=midsql01; user=views; password=views;" +
                 "database=PM");

            //SqlDataAdapter da = new SqlDataAdapter
            //    ("select " +
            //     "' '  as serial,  " +
            //     "' '  as c, " +
            //     "' '  as l, " +
            //     "' '  as m,  " +
            //     "' '  as d,  " +
            //     "' '  as e " +
            //     "union " +
            //     "Select " +
            //     "e.serial,  " +
            //     "e.cost_center,  " +
            //     "e.location, " +
            //     "e.manufacturer, " +
            //     "e.description, " +
            //     "\"e\" = o.email + " +
            //     "case " +
            //     "when o.sms_phone <> '' then  + ',' " +
            //     "+ o.sms_phone + '@' + p.ph_domain " +
            //     "else '' " +
            //     "end + " +
            //     "case " +
            //     "when o.email1_cc <> '' then + ',' + o.email1_cc " +
            //     "else '' " +
            //     "end " +
            //     "from  " +
            //     "phonesms p  " +
            //     "right join  " +
            //     "(owners o  " +
            //     "inner join " +
            //     "equipment e on o.owner = e.owner) " +
            //     "on p.ph_carriername = o.sms_carrier " +
            //     "where " +
            //     "(e.status <> 'inactive') and " +
            //     "(o.donotpostonweb <> 1) " +
            //     "order by e.serial", cnxn);

            //table = new DataTable();
            //da.Fill(table);

            //get data to fill employee drop down list and text boxes.    

            SqlDataAdapter da1 = new SqlDataAdapter
                ("select " +
                 "' ' as name, " +
                 "' ' as empemail, " +
                 "' ' as supername, " +
                 "' ' as superemail, " +
                 "' ' as empname " +
                 "union " +
                 "select " +
                 "substring( " +
                 "name,  " +
                 "(charindex(',', name)+ 1), " +
                 "(len(name))-charindex(',', name)) + ' ' + " +
                 "substring(name, 0,charindex(',', name)) " +
                 "as Name,  " +
                 "empemail, supername, superemail, empname " +
                 "from externalnames " +
                 "union " +
                 "select " +
                 "substring( " +
                 "e.name,  " +
                 "(charindex(',', e.name)+ 1), " +
                 "(len(e.name))-charindex(',', e.name)) + ' ' + " +
                 "substring(e.name, 0,charindex(',', e.name)) " +
                 "as Name,  " +
                 "e.email as empemail, " +
                 "substring(e.mysupervisorname, " +
                 "(charindex(',', e.mysupervisorname)+ 1), " +
                 "(len(e.mysupervisorname))-charindex(',', e.mysupervisorname)) " +
                 " + ' ' + " +
                 "substring( " +
                 "e.mysupervisorname,  " +
                 "0, " +
                 "charindex(',', e.mysupervisorname))  " +
                 "as Supername, " +
                 "ee.email as Superemail, " +
                 "e.name " +
                 "from " +
                 "[middb01].dashboard.dbo.view_employees e " +
                 "left join " +
                 "[middb01].dashboard.dbo.view_employees ee " +
                 "on e.mysupervisorname = ee.name " +
                 "order by  " +
                 "empname ", cnxn);

            table1 = new DataTable();
            da1.Fill(table1);

            //this keeps the selections in the boxes

            if (!IsPostBack)
            {
                DDequipID.DataSource = table;
                DDequipID.DataTextField = "Serial";
                DDequipID.DataValueField = "Serial";
                DDequipID.DataBind();
                DDLemployee.DataSource = table1;
                DDLemployee.DataTextField = "Name";
                DDLemployee.DataValueField = "Name";
                DDLemployee.DataBind();
            }


        }

        protected void DDequipID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int n = DDequipID.SelectedIndex;
            tbCostCenter.Text = table.Rows[n].ItemArray[1].ToString().Trim();
            tbLocation.Text = table.Rows[n].ItemArray[2].ToString().Trim();
            tbManufacturer.Text = table.Rows[n].ItemArray[3].ToString().Trim();
            tbDescription.Text = table.Rows[n].ItemArray[4].ToString().Trim();
            owneremail = table.Rows[n].ItemArray[5].ToString().Trim();
            Lequipment.Visible = false;
        }

        protected void DDLemployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lname.Visible = false;
            int nn = DDLemployee.SelectedIndex;
            tbContactEmail.Text = table1.Rows[nn].ItemArray[1].ToString().Trim();

            supervisor = table1.Rows[nn].ItemArray[2].ToString().Trim();
            superemail = table1.Rows[nn].ItemArray[3].ToString().Trim();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Lerror.Visible = true;
            Lerror.Text = "Button click";

            if (DDLemployee.Text.Length < 2)
            {
                Lname.Visible = true;
                return;
            }

            if (DDequipID.Text.Length < 2)
            {
                Lequipment.Visible = true;
                return;
            }


            if (tbTrouble.Text.Length < 1)
            {
                Ltrouble.Visible = true;
                return;
            }



            Lerror.Text = "3 box checks";

            //first send an email to requestor

            string from = "maintrequest@zygo.com";
            string emailto = tbContactEmail.Text;
            submitDate = DateTime.Now.ToString();
            MailMessage email = new MailMessage(from, emailto);
            email.Subject = "Maintenance Request";
            email.Body =
                "Dear " + DDLemployee.Text + "," +
                "\n\r" +
                "Here is the information which you submitted on your recent request for maintenance:" +
                "\n\r" +
                "Date and Time of Submission: " +
                submitDate + "  Eastern Standard Time" +
                "\n\r" +
                "Name...........: " + DDLemployee.Text + "\r" +
                "Contact eMail..: " + tbContactEmail.Text + "\r" +
                "Ext............: " + tbPhone.Text + "\r" +
                "Category.......: " + DDLCategory.Text + "\r" +
                "Equip ID.......: " + DDequipID.Text + "\r" +
                "Location.......: " + tbLocation.Text + "\r" +
                "Description....: " + tbDescription.Text + "\r" +
                "Project........: " + tbProject.Text + "\r" +
                "Cost Center....: " + tbCostCenter.Text + "\r" +
                "\r" +
                "Message: " +
                "\r" +
                tbTrouble.Text;

            SmtpClient client = new SmtpClient("128.1.9.20", 25);
            client.UseDefaultCredentials = true;
            client.Send(email);

            Lerror.Text = "sent first email";

            //emails to bill bacon and owner of equipment

            from = tbContactEmail.Text;
            emailto = owneremail;
            email = new MailMessage(from, emailto);
            MailAddress copy = new MailAddress("bbacon@zygo.com");
            email.CC.Add(copy);
            copy = new MailAddress("thepburn@zygo.com");
            email.CC.Add(copy);

            email.Subject = "Maint Req: " + tbContactEmail.Text;

            email.Body =
                "Category.......: " + DDLCategory.Text + "\r" +
                "Equip ID.......: " + DDequipID.Text + "\r" +
                "Location.......: " + tbLocation.Text + "\r" +
                "Message: " +
                "\r" +
                tbTrouble.Text +
                "\r" +
                "Name...........: " + DDLemployee.Text + "\r" +
                "Description....: " + tbDescription.Text + "\r" +
                "Contact eMail..: " + tbContactEmail.Text + "\r" +
                "Ext............: " + tbPhone.Text + "\r" +
                "Project........: " + tbProject.Text + "\r" +
                "Cost Center....: " + tbCostCenter.Text + "\r" +
                "\r" +
                "Date and Time of Submission: " +
                submitDate + "  Eastern Standard Time";

            client = new SmtpClient("128.1.9.20", 25);
            client.UseDefaultCredentials = true;
            client.Send(email);

            Lerror.Text = "sent second email";

            //create unique identifier in format xxxxxxxx-xxxx-xxxx

            Random r = new Random();
            string r1 = r.Next(0, 10000).ToString();
            while (r1.Length < 4)
            { r1 = "0" + r1; }
            string r2 = r.Next(0, 10000).ToString();
            while (r2.Length < 4)
            { r2 = "0" + r2; }
            string y = DateTime.Now.Year.ToString();
            string m = DateTime.Now.Month.ToString();
            while (m.Length < 2)
            { m = "0" + m; }
            string d = DateTime.Now.Day.ToString();
            while (d.Length < 2)
            { d = "0" + d; }
            string uid = y + m + d + "-" + r1 + "-" + r2;

            if (owneremail.ToString().Length > 0)
            {
                if (owneremail.IndexOf(",") > -1)
                {
                    owneremail = owneremail.Substring(0, owneremail.IndexOf(",") - 1);
                }
            }

            cnxn = new SqlConnection
                ("server=midsql01; user=readwrite; password=Read+Write!;" +
                 "database=PM");

            SqlParameter Trouble = new SqlParameter("@Trouble", SqlDbType.VarChar, 4000);
            Trouble.Value = tbTrouble.Text.Trim();
            SqlParameter Phone = new SqlParameter("@Phone", SqlDbType.VarChar, 50);
            Phone.Value = tbPhone.Text.Trim();
            SqlParameter CostCenter = new SqlParameter("@CostCenter", SqlDbType.VarChar, 4);
            CostCenter.Value = tbCostCenter.Text.Trim();
            SqlParameter Project = new SqlParameter("@Project", SqlDbType.VarChar, 6);
            Project.Value = tbProject.Text.Trim();
            SqlParameter ContactEmail = new SqlParameter("@ContactEmail", SqlDbType.VarChar, 50);
            ContactEmail.Value = tbContactEmail.Text.Trim();


            SqlCommand cmd = new SqlCommand("Insert into maintenancerequests (" +
                    "serial," +               //1
                    "Serial_Web_Entered," +
                    "category," +
                    "cost_center," +
                    "project," +              //5
                    "phone," +
                    "rptd_by," +
                    "rptd_by_email," +
                    "rptd_date]," +
                    "trouble," +                        //10
                    "severity," +
                    "unique_reference_number," +
                    "owner_email," +
                    "submitter_supervisor," +
                    "submitter_supervisor_email" +     //15
                    ") values (" +
                    "'" + DDequipID.Text.ToString().Trim() +        //1
                    "','" + DDequipID.Text.ToString().Trim() +
                    "','" + DDLCategory.Text +
                    "'," + CostCenter +
                    "," + Project +                        //5
                    "," + Phone +
                    ",'" + DDLemployee.Text +
                    "'," + ContactEmail +
                    ",'" + submitDate +
                    "'," + Trouble +                                //10
                    ",'" + DDLSeverity.Text +
                    "','" + uid +
                    "','" + owneremail +
                    "','" + supervisor +
                    "','" + superemail + "') ");                    //15
            cmd.Parameters.Add(Trouble);
            cmd.Parameters.Add(Phone);
            cmd.Parameters.Add(CostCenter);
            cmd.Parameters.Add(Project);
            cmd.Parameters.Add(ContactEmail);

            cmd.Connection = cnxn;
            cnxn.Open();
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
            cnxn.Close();

            Response.Redirect("thankyou.aspx?field1=DDLemployee.Text");

            tbLocation.Text = "";
            tbTrouble.Text = "";
            tbManufacturer.Text = "";
            tbDescription.Text = "";
            tbCostCenter.Text = "";
            tbPhone.Text = "";
            tbContactEmail.Text = "";
            tbProject.Text = "";
            DDequipID.SelectedIndex = -1;
            DDLemployee.SelectedIndex = -1;
            DDLCategory.SelectedIndex = -1;
            DDLSeverity.SelectedIndex = -1;
            owneremail = "";
            superemail = "";
            supervisor = "";
            cmd.Dispose();
            Ltrouble.Visible = false;


        }


    }
}
