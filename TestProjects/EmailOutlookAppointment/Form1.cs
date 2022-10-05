using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;

namespace EmailOutlookAppointment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Outlook.Application app = null;
                Microsoft.Office.Interop.Outlook.AppointmentItem appt = null;

                app = new Microsoft.Office.Interop.Outlook.Application();

                appt = (Microsoft.Office.Interop.Outlook.AppointmentItem)app
                    .CreateItem(OlItemType.olAppointmentItem);
                appt.Subject = "Test";
                appt.Body = "Test Body";
                appt.Location = "TBD";
                appt.Start = Convert.ToDateTime("05/31/2012 5:00:00 PM");
                appt.Recipients.Add("thepburn@zygo.com");
                appt.End = Convert.ToDateTime("05/31/2012 6:00:00 PM");
                appt.ReminderSet = true;
                appt.ReminderMinutesBeforeStart = 15;
                //appt.MeetingStatus = OlMeetingStatus.olMeeting;
                appt.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh;
                appt.BusyStatus = Microsoft.Office.Interop.Outlook.OlBusyStatus.olBusy;
                appt.Save();
                appt.Send();
                //Microsoft.Office.Interop.Outlook.MailItem mailItem = appt.ForwardAsVcal();
                //mailItem.To = "thepburn@zygo.com";
                //mailItem.Send();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
 
    }
}