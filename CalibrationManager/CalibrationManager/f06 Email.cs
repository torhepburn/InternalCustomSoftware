using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;
using System.IO;
using System.Threading;

namespace CalibrationManager
{
    public partial class f06_Email : Form
    {
        SqlConnection cnxn1;
        SqlConnection cnxn2;
        SqlConnection cnxn3;
        SqlCommand cmd1;
        SqlCommand cmd2;
        SqlCommand cmd3;
        SqlCommand cmd4;
        SqlDataReader dr1;
        SqlDataReader dr2;
        SqlParameter user;
        SqlParameter emailName;
        SqlParameter owner;
        SqlParameter supervisor;
        SqlParameter supersupervisor;
        private string emailBody;
        private string emailBodySub1;
        private string emailto;
        private string emailcopyto;
        private string lastOFmonth;
        private string text;
        private string distinct;
        private string locationSearch;
        private string emailType = "";
        private int calcontact;
        DataTable table;

        public f06_Email()
        {
            InitializeComponent();
        }

        private void f06_Email_Load(object sender, EventArgs e)
        {

            if (g.task == "overdue")
            {
                this.Text = "f06 Email Overdue Items";
                lastOFmonth = DateTime.Now.ToShortDateString();
            }

            if (g.task == "thismonth")
            {
                this.Text = "f06 Email Items Due This Month";
                int month = DateTime.Now.Month;
                int year = DateTime.Now.Year;
                string daysINmonth = DateTime.DaysInMonth(year, month).ToString();

                lastOFmonth = year.ToString() + "-" + month.ToString() + "-" +
                    daysINmonth;
            }

            if (g.task == "nextmonth")
            {
                this.Text = "f06 Email Items Due Next Month";
                int month = DateTime.Now.Month + 1;
                int year = DateTime.Now.Year;
                if (month == 13)
                {
                    month = 1;
                    year = year + 1;
                }

                string daysINmonth = DateTime.DaysInMonth(year, month).ToString();

                lastOFmonth = year.ToString() + "-" + month.ToString() + "-" +
                    daysINmonth;
            }

            cnxn1 = new SqlConnection(g.db);
            cmd1 = new SqlCommand
                    ("Select em_" + g.task + "_Subject, " +
                     " em_" + g.task + "_message from emailtext " +
                     " where em_facility = '" + g.facility + "'", cnxn1);
            cnxn1.Open();
            dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                if (!dr1.IsDBNull(0)) { tbSubject.Text = dr1.GetString(0).Trim(); }
                if (!dr1.IsDBNull(1)) { tbMessage.Text = dr1.GetString(1).Trim(); }
            }
            cnxn1.Close();
        }

        private void bSend_Click(object sender, EventArgs e)
        {
            cnxn1.Open();
            cmd1 = new SqlCommand("select emailFrom from AccessRights where " +
                "emailFrom is not null and facility = '" + g.facility + "'", cnxn1);
            g.emailFrom = cmd1.ExecuteScalar().ToString();
            cnxn1.Close();

            cnxn1.Open();
            SqlDataAdapter da = new SqlDataAdapter(
                "Select emailcopyto from accessrights where emailcopyto is not null " +
                "and facility = '" + g.facility + "'", cnxn1);
            table = new DataTable();
            da.Fill(table);
            cnxn1.Close();

            cnxn2 = new SqlConnection(g.db);

            // using SQL parameters to encapsulate the text so that it is compiled
            // as text and no funny business can take place.

            // taking the text, processing it so that it will print as html in the
            // email and saving it to the SQL table

            string param0 = "@subject" + g.item;
            string param1 = "@" + g.item;
            SqlParameter subject = new SqlParameter
                (param0, SqlDbType.VarChar, 100);
            subject.Value = tbSubject.Text.Trim();
            SqlParameter message = new SqlParameter
                (param1, SqlDbType.VarChar, 1500);
            message.Value = tbMessage.Text.Trim();
            cmd1 = new SqlCommand
                ("update emailtext " +
                " set em_" + g.task + "_Subject = " + subject + "," +
                " em_" + g.task + "_message = " + message +
                " where em_facility = '" + g.facility + "'", cnxn1);
            cmd1.Parameters.Add(subject);
            cmd1.Parameters.Add(message);
            cnxn1.Open();
            int rowsReturned = cmd1.ExecuteNonQuery();
            cnxn1.Close();

            if (tbMessage.Text.Length > 0)
            {
                text = tbMessage.Text;
                int paragraphEnd = tbMessage.Text.IndexOf("\r\n");
                if (paragraphEnd != -1)
                {
                    emailBodySub1 = "<p>" +
                        tbMessage.Text.Substring(0, paragraphEnd) + "</p>";
                    paragraphEnd = paragraphEnd + 2;
                    text = tbMessage.Text.Substring(paragraphEnd);
                }
                while (paragraphEnd != -1 && text.Length > 0)
                {
                    paragraphEnd = text.IndexOf("\r\n");
                    if (paragraphEnd != -1)
                    {
                        emailBodySub1 = emailBodySub1 + "<p>" +
                            text.Substring(0, paragraphEnd) + "</p>";
                        paragraphEnd = paragraphEnd + 2;
                        text = text.Substring(paragraphEnd);
                    }
                }

                if (paragraphEnd == -1)
                {
                    emailBodySub1 = emailBodySub1 + "<p>" + text + "</p>";
                }


            }
            else
            {
                emailBodySub1 = "<p> </p>";
            }

            emailBodySub1 = emailBodySub1 +
            "<html><body><table border='1' cellpadding='1'>" +
            "<tr>" +
            "<th>" + "Location" + "</th>" +
            "<th>" + "ID" + "</th>" +
            "<th>" + "Description" + "</th>" +     
            "<th>" + "Manufacturer" + "</th>" +
            "<th>" + "Model" + "</th>" +
            "<th>" + "Size" + "</th>" +
            "<th>" + "Owner" + "</th>" +
            "<th>" + "User" + "</th>" +
            "<th>" + "Due Date" + "</th>" +
            "</tr>";

            emailBody = emailBodySub1;


            // selecting the users for the calibration due

            recipientSelection("user");

            cnxn1.Open();
            dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                if (!dr1.IsDBNull(0))
                {
                    user = new SqlParameter
                        ("@user", SqlDbType.VarChar, 30);
                    user.Value = dr1.GetString(0).Trim();

                    // Selecting the equipment for each user

                    equipmentSelection("user");

                    cmd2.Parameters.Add(user);
                    cnxn2.Open();
                    dr2 = cmd2.ExecuteReader();

                    //  putting the data in a grid on the user email

                    while (dr2.Read())
                    {
                        grid();
                    }

                    // end of while (dr2.Read()) equipment per user

                    cnxn2.Close();
                    cmd2.Parameters.Remove(user);
                    cmd2.Dispose();

                    // get the email address for the user

                    emailAddress("Equipment User");

                }
            }   // end of while (dr1.Read()) User

            cnxn1.Close();


            // selecting the Owners for the calibration due

            recipientSelection("owner");

            cnxn1.Open();
            dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                if (!dr1.IsDBNull(0))
                {
                    owner = new SqlParameter
                        ("@owner", SqlDbType.VarChar, 30);
                    owner.Value = dr1.GetString(0).Trim();

                    // Selecting the equipment for each owner


                    equipmentSelection("owner");

                    cmd2.Parameters.Add(owner);
                    cnxn2.Open();
                    dr2 = cmd2.ExecuteReader();

                    //  putting the data in a grid on the email

                    while (dr2.Read())
                    {
                        grid();
                    }   // end of while (dr2.Read()) equipment per owner

                    cnxn2.Close();

                    // get the email address for the owner

                    emailAddress("Equipment Owner");

                }
            }   // end of while (dr1.Read()) Owner

            cnxn1.Close();

            if (owner != null)
            {
                cmd2.Parameters.Remove(owner);
            }
            //cmd2.Dispose();
            //cmd3.Dispose();

            // selecting the Supervisors

            if (g.item == "EmailAll")
            {

                recipientSelection("supervisor");

                cnxn1.Open();
                dr1 = cmd1.ExecuteReader();

                while (dr1.Read())
                {
                    if (!dr1.IsDBNull(0))
                    {
                        supervisor = new SqlParameter
                            ("@supervisor", SqlDbType.VarChar, 30);
                        supervisor.Value = dr1.GetString(0).Trim();

                        // Selecting the equipment for each supervisor


                        equipmentSelection("supervisor");

                        cmd2.Parameters.Add(supervisor);
                        cnxn2.Open();
                        dr2 = cmd2.ExecuteReader();

                        //  putting the data in a grid on the email

                        while (dr2.Read())
                        {
                            grid();
                        }
                        // end of while (dr2.Read()) equipment per supervisor

                        cnxn2.Close();

                        // get the email address for the supervisorowner

                        emailAddress("Owner Supervisor");
                    }
                }   // end of while (dr1.Read()) Supervisor


                cnxn1.Close();

                // selecting the SupervisorsSupervisors



                recipientSelection("SuperSupervisor");

                cnxn1.Open();
                dr1 = cmd1.ExecuteReader();

                while (dr1.Read())
                {
                    if (!dr1.IsDBNull(0) &&
                        (dr1.GetString(0) != "Rojas, Barbara" &
                         dr1.GetString(0) != "Wilson, Bruce" &
                         dr1.GetString(0) != "Morgan, Nancy" &
                         dr1.GetString(0) != "Beeson, Rob" &
                         dr1.GetString(0) != "Battistoni, Don"))
                    {
                        supersupervisor = new SqlParameter
                            ("@supersupervisor", SqlDbType.VarChar, 30);
                        supersupervisor.Value = dr1.GetString(0).Trim();

                        // Selecting the equipment for each supersupervisor


                        equipmentSelection("supersupervisor");

                        cmd2.Parameters.Add(supersupervisor);
                        cnxn2.Open();
                        dr2 = cmd2.ExecuteReader();

                        //  putting the data in a grid on the email

                        while (dr2.Read())
                        {
                            grid();
                        }
                        // end of while (dr2.Read()) equipment per supersupervisor

                        cnxn2.Close();

                        // get the email address for the supersupervisor

                        emailAddress("Owner Supervisor Supervisor");
                    }
                }   // end of while (dr1.Read()) Supervisor


                cnxn1.Close();

                // selecting internal calibration contact

                cmd1 = new SqlCommand(
                    "InternalCalibrationContacts", cnxn1);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlParameter loc = cmd1.Parameters.Add
                    ("@loc", SqlDbType.VarChar, 20);
                loc.Value = g.facility;
                SqlParameter lastofMonth = cmd1.Parameters.Add
                    ("@lastofMonth", SqlDbType.DateTime);

                lastofMonth.Value = lastOFmonth;

                cnxn1.Open();

                dr1 = cmd1.ExecuteReader();

                while (dr1.Read())
                {
                    if (!dr1.IsDBNull(0))
                    {
                        calcontact = dr1.GetInt32(0);

                        equipmentSelection("internal contact");

                        cnxn2.Open();
                        dr2 = cmd2.ExecuteReader();

                        //  putting the data in a grid on the email

                        while (dr2.Read())
                        {
                            grid();
                        }   // end of while (dr2.Read()) equipment per owner

                        cnxn2.Close();

                        // get the email address for the owner

                        emailAddress("Internal Calibration Contact");

                    }
                }   // end of while (dr1.Read()) Owner

                cnxn1.Close();

            }
            tbMessage.Clear();
            tbSubject.Clear();

            Close();
        }
        //end of B_send

        private void grid()
        {
            emailBody = emailBody + "<tr><font face='arial' size='1'>";

            if (!dr2.IsDBNull(0))
            { emailBody = emailBody + "<td>" + dr2.GetString(0) + "</td>"; }
            else
            { emailBody = emailBody + "<td></td>"; }

            if (!dr2.IsDBNull(1))
            { emailBody = emailBody + "<td>" + dr2.GetString(1) + "</td>"; }
            else
            { emailBody = emailBody + "<td></td>"; }

            if (!dr2.IsDBNull(2))
            { emailBody = emailBody + "<td>" + dr2.GetString(2) + "</td>"; }
            else
            { emailBody = emailBody + "<td></td>"; }

            if (!dr2.IsDBNull(3))
            { emailBody = emailBody + "<td>" + dr2.GetString(3) + "</td>"; }
            else
            { emailBody = emailBody + "<td></td>"; }

            if (!dr2.IsDBNull(4))
            { emailBody = emailBody + "<td>" + dr2.GetString(4) + "</td>"; }
            else
            { emailBody = emailBody + "<td></td>"; }

            if (!dr2.IsDBNull(5))
            { emailBody = emailBody + "<td>" + dr2.GetString(5) + "</td>"; }
            else
            { emailBody = emailBody + "<td></td>"; }

            if (!dr2.IsDBNull(6))
            { emailBody = emailBody + "<td>" + dr2.GetString(6) + "</td>"; }
            else
            { emailBody = emailBody + "<td></td>"; }

            if (!dr2.IsDBNull(7))
            { emailBody = emailBody + "<td>" + dr2.GetString(7) + "</td>"; }
            else
            { emailBody = emailBody + "<td></td>"; }

            if (!dr2.IsDBNull(8))
            { emailBody = emailBody + "<td>" + dr2.GetDateTime(8).ToShortDateString() + "</td>"; }
            else
            { emailBody = emailBody + "<td></td>"; }
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void recipientSelection(string category)
        {
            if (category == "user")
            {
                distinct = "e.name ";

                if (g.item == "EmailOne")
                {
                    emailType = "and e.badgeid = " + g.eBadgeID + " ";
                }
            }
            if (category == "owner")
            {
                distinct = "ee.name ";

                if (g.item == "EmailOne")
                {
                    emailType = "and ee.badgeid = " + g.eBadgeID + " ";
                }
            }
            if (category == "supervisor")
            {
                distinct = "eee.name ";
                emailType = "";
            }
            if (category == "SuperSupervisor")
            {
                distinct = "s.name ";
                emailType = "";
            }

            cmd1 = new SqlCommand
                       ("select distinct " +
                        distinct +
                        "from calibration.dbo.calibrationdata d " +
                        "left join calibration.dbo.equipment q on " +
                        "d.item = q.id " +
                        "left join calibration.dbo.itemuser u on " +
                        "q.id = u.i_item " +
                        "left join calibration.dbo.itemlocation l on " +
                        "q.id = l.il_item " +
                        "left join " + g.dbDash + " e on " +
                        "u.i_user = e.badgeid " +
                        "left join calibration.dbo.location c on " +
                        "c.l_id = l.il_location " +
                        "left join " + g.dbDash + " ee on " +
                        "c.l_owner = ee.badgeid " +
                        "left join " + g.dbDash + " eee on " +
                        "ee.mysupervisorname = eee.name " +
                        "left join " + g.dbDash + " s on " +
                        "eee.mysupervisorname = s.name " +
                        "where d.currenthistory = 'c' " +
                        "and (q.status = 'active' or q.status = 'spare') " +
                        "and e.badgeID <> 0 " +
                        "and l.il_location like '%" + g.facility + "%' " +
                        " and d.cal_next <= '" + lastOFmonth + "' " + emailType
                        , cnxn1);
        }

        private void equipmentSelection(string category)
        {
            if (category == "user")
            {
                locationSearch = "and e.name = @user ";
            }
            if (category == "owner")
            {
                locationSearch = "and ee.name = @owner ";
            }
            if (category == "supervisor")
            {
                locationSearch = "and eee.name = @supervisor ";
            }
            if (category == "supersupervisor")
            {
                locationSearch = "and s.name = @supersupervisor ";
            }
            if (category == "internal contact")
            {
                locationSearch = "and internal_cal_contact = " +
                calcontact + " and outsource = 'n'";
            }

            cmd2 = new SqlCommand
                   (" select " +
                    "l.il_location as [Location], " +
                    "q.ID, " +
                    "q.[Description], " +
                    "q.manuf, " +
                    "q.Model, " +
                    "q.size, " +
                    "ee.name as [Owner], " +
                    "e.name as [User], " +
                    "d.cal_next " +
                    "from calibration.dbo.calibrationdata d " +
                    "left join calibration.dbo.equipment q on " +
                    "d.item = q.id " +
                    "left join calibration.dbo.itemuser u on " +
                    "q.id = u.i_item " +
                    "left join calibration.dbo.itemlocation l on " +
                    "q.id = l.il_item " +
                    "left join " + g.dbDash + " e on " +
                    "u.i_user = e.badgeid " +
                    "left join calibration.dbo.location c on " +
                    "c.l_id = l.il_location " +
                    "left join " + g.dbDash + " ee on " +
                    "c.l_owner = ee.badgeid " +
                    "left join " + g.dbDash + " eee on " +
                    "ee.mysupervisorname = eee.name " +
                    "left join " + g.dbDash + " s on " +
                    "eee.mysupervisorname = s.name " +
                    "where d.currenthistory = 'c' " +
                    "and (q.status = 'active' or q.status = 'spare') " +
                    "and e.badgeID <> 0 " +
                    "and l.il_location like '%" + g.facility + "%' " +
                    " and d.cal_next <= '" + lastOFmonth + "'  " +
                     locationSearch +
                    " order by d.cal_next", cnxn2);
        }

        private void emailAddress(string emSubject)
        {
            if (emSubject != "Internal Calibration Contact")
            {
                emailName = new SqlParameter
                             ("@Xname", SqlDbType.VarChar, 30);
                emailName.Value = dr1.GetString(0).Trim();

                cmd3 = new SqlCommand("Select email from " +
                    g.dbDash +
                    " where name = @Xname", cnxn2);

                cmd3.Parameters.Add(emailName);
            }

            if (emSubject == "Internal Calibration Contact")
            {
                cmd3 = new SqlCommand("Select email from " +
                    g.dbDash +
                    " where badgeid = " + calcontact + "", cnxn2);
            }

            cnxn2.Open();
            object m = cmd3.ExecuteScalar();
            emailto = m.ToString().Trim();

            cnxn2.Close();

            if (emSubject == "Owner Supervisor" | emSubject == "Owner Supervisor Supervisor")
            {
                emailBody = "<p> The users and owners listed below have " +
                    "received email notification of the equipment due for " +
                    "calibration for which they are responsible. </p>" +
                    emailBody;
            }

            for (int i = 0; i < table.Rows.Count; i++)
            {
                emailcopyto += ";" + table.Rows[i].ItemArray[0].ToString().Trim();
            }

            if (g.item == "EmailOne")
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                string MBmessage = "Send email to " + emSubject + " " + emailto + " ? ";
                DialogResult result;
                result = MessageBox.Show(MBmessage, "", buttons);
                if (result == DialogResult.Yes)
                {
                    //File.AppendAllText(@"c:\a\emailtest1201A.txt", emSubject + Environment.NewLine + DateTime.Now.ToString() + 
                    //    emailto + Environment.NewLine + email.CC.ToString() + Environment.NewLine +
                    //    email.Body +
                    //    Environment.NewLine);
                    SqlParameter pEmailTo = new SqlParameter("@pEmailTo", SqlDbType.NVarChar);
                    pEmailTo.Value = emailto;
                    SqlParameter pEmailCopyTo = new SqlParameter("@pEmailCopyTo", SqlDbType.NVarChar);
                    pEmailCopyTo.Value = emailcopyto;
                    SqlParameter pEmailSubject = new SqlParameter("@pEmailSubject", SqlDbType.NVarChar);
                    pEmailSubject.Value = emSubject + " Email " + tbSubject.Text.Trim();
                    SqlParameter pEmailBody = new SqlParameter("@pEmailBody", SqlDbType.NVarChar);
                    pEmailBody.Value = emailBody;


                    cnxn3 = new SqlConnection(g.db);
                    cmd4 = new SqlCommand("Insert into Email " +
                         " (EmailTo " +
                         " ,EmailCopyto " +
                         " ,EmailSubject " +
                         " ,EmailBody) " +
                         " values " +
                         " ( " + pEmailTo +
                         " , " + pEmailCopyTo +
                         " , " + pEmailSubject +
                         " , " + pEmailBody +
                         " )", cnxn3);
                    cmd4.Parameters.Add(pEmailTo);
                    cmd4.Parameters.Add(pEmailCopyTo);
                    cmd4.Parameters.Add(pEmailSubject);
                    cmd4.Parameters.Add(pEmailBody);

                    cnxn3.Open();
                    try
                    {
                        int rowsReturned = cmd4.ExecuteNonQuery();
                        //File.AppendAllText(@"c:\a\emailSQLtest.txt", emSubject + Environment.NewLine + DateTime.Now.ToString() +
                        //    emailto + Environment.NewLine);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        cnxn3.Close();
                        cmd4.Parameters.Clear();
                    }
                }
            }
            else
            {
                SqlParameter pEmailTo = new SqlParameter("@pEmailTo", SqlDbType.NVarChar);
                pEmailTo.Value = emailto;
                SqlParameter pEmailCopyTo = new SqlParameter("@pEmailCopyTo", SqlDbType.NVarChar);
                pEmailCopyTo.Value = emailcopyto;
                SqlParameter pEmailSubject = new SqlParameter("@pEmailSubject", SqlDbType.NVarChar);
                pEmailSubject.Value = emSubject + " Email " + tbSubject.Text.Trim();
                SqlParameter pEmailBody = new SqlParameter("@pEmailBody", SqlDbType.NVarChar);
                pEmailBody.Value = emailBody;

                cnxn3 = new SqlConnection(g.db);
                cmd4 = new SqlCommand("Insert into Email " +
                     " (EmailTo " +
                     " ,EmailCopyto " +
                     " ,EmailSubject " +
                     " ,EmailBody) " +
                     " values " +
                     " ( " + pEmailTo +
                     " , " + pEmailCopyTo +
                     " , " + pEmailSubject +
                     " , " + pEmailBody +
                     " )", cnxn3);
                cmd4.Parameters.Add(pEmailTo);
                cmd4.Parameters.Add(pEmailCopyTo);
                cmd4.Parameters.Add(pEmailSubject);
                cmd4.Parameters.Add(pEmailBody);

                cnxn3.Open();
                try
                {
                    int rowsReturned = cmd4.ExecuteNonQuery();
                    //File.AppendAllText(@"c:\a\emailSQLtest1201B.txt", emSubject + Environment.NewLine + DateTime.Now.ToString() +
                    //    "  " + emailto + Environment.NewLine);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn3.Close();
                    cmd4.Parameters.Clear();
                }
            }
            emailBody = emailBodySub1;
            emailcopyto = string.Empty;
        }
    }
}