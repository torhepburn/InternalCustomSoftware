using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using System.Data.SqlClient;


namespace CalibrationManager
{
    public partial class f52_Equipment_Report : Form
    {
        private string sn;
        private string manuf;
        private string desc;
        private string desc2;
        private string model;
        private string size;
        private string date_new;
        private string procedure;
        private string status;
        private string type;
        private string include;
        private string purchcost;
        private string tnom;
        private string hnom;
        private string pnom;
        private string location;
        private string room;
        private string facility;
        private string last_change_date;
        private string refStandard;
        private string businessUnitOwner;
        private string comment;
        private string capitalEquipmentNumber;
        private string[] chg_date = new string[25];
        private string[] cal_date = new string[25];
        private string[] cal_int = new string[25];
        private string cal_Due;
        private string[] cal_source = new string[25];
        private string[] certnum = new string[25];
        private string[] inspector = new string[25];
        private string[] history1 = new string[25];
        private string[] history2 = new string[25];
        private string[] history3 = new string[25];
        private int i = 0;
        private string user;
        private string owner;
        SqlDataAdapter da;
        BindingSource bs = new BindingSource();
        BindingSource bs3 = new BindingSource();
        DataTable table;

        public f52_Equipment_Report()
        {
            InitializeComponent();
        }

        private void f52_Equipment_Report_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection(g.db);
            SqlCommand cmd = new SqlCommand
                ("Select * from equipment where id = '" +
                 g.iID + "' and status != 'Archive'");
            cmd.Connection = cnxn;
            cnxn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (!dr.IsDBNull(3)) { sn = dr.GetString(3).Trim(); }
                if (!dr.IsDBNull(4)) { manuf = dr.GetString(4).Trim(); }
                if (!dr.IsDBNull(1)) { desc = dr.GetString(1).Trim(); }
                if (!dr.IsDBNull(2)) { desc2 = dr.GetString(2).Trim(); }
                if (!dr.IsDBNull(5)) { model = dr.GetString(5).Trim(); }
                if (!dr.IsDBNull(6)) { size = dr.GetString(6).Trim(); }
                if (!dr.IsDBNull(7)) { date_new = dr.GetDateTime(7).ToShortDateString(); }
                if (!dr.IsDBNull(8)) { purchcost = dr.GetDouble(8).ToString(); }
                if (!dr.IsDBNull(9)) { businessUnitOwner = dr.GetString(9).Trim(); }
                if (!dr.IsDBNull(10)) { capitalEquipmentNumber = dr.GetString(10).Trim(); }
                if (!dr.IsDBNull(15)) { tnom = dr.GetDouble(15).ToString(); }
                if (!dr.IsDBNull(16)) { hnom = dr.GetDouble(16).ToString(); }
                if (!dr.IsDBNull(17)) { pnom = dr.GetDouble(17).ToString(); }
                if (!dr.IsDBNull(11)) { include = dr.GetString(11).Trim(); }
                if (include == "Y") { include = "Yes"; } else { include = "No"; }
                if (!dr.IsDBNull(12)) { refStandard = dr.GetString(12).Trim(); }
                if (refStandard == "Y") { refStandard = "Yes"; } else { refStandard = "No"; }
                if (!dr.IsDBNull(13)) { type = dr.GetString(13).Trim(); }
                if (!dr.IsDBNull(14)) { status = dr.GetString(14).Trim(); }
                if (!dr.IsDBNull(18)) { procedure = dr.GetString(18).Trim(); }
                if (!dr.IsDBNull(19)) { comment = dr.GetString(19).Trim(); }
                if (!dr.IsDBNull(45) && dr.GetInt32(45) != 0) 
                {
                    SqlConnection cnxn2 = new SqlConnection(g.dbDashserver);
                    SqlCommand cmd2 = new SqlCommand
                     (" select name from view_employees where " +
                    " badgeid = " + dr.GetInt32(45) + " ", cnxn2);
                    cnxn2.Open();
                    object o = cmd2.ExecuteScalar();
                    tbInternalContact.Text = o.ToString().Trim();
                    cnxn2.Close();
                }
            }
            cnxn.Close();

            tbID.Text = g.iID;
            tbDesc.Text = desc;
            tbExtDesc.Text = desc2;
            tbSN.Text = sn;
            tbManufacturer.Text = manuf;
            tbModel.Text = model;
            tbSize.Text = size;
            tbDateNew.Text = date_new;
            tbPurchCost.Text = purchcost;
            tbBUOwner.Text = businessUnitOwner;
            tbCapEquipNumber.Text = capitalEquipmentNumber;
            tbType.Text = type;
            tbStatus.Text = status;
            tbTemperature.Text = tnom;
            tbHumidity.Text = hnom;
            tbPressure.Text = pnom;
            tbProcedure.Text = procedure;
            tbNotes.Text = comment;
            tbRefStandard.Text = refStandard;
            tbOutsource.Text = include;

            da = new SqlDataAdapter("Select " +
                    "left(chg_date, 12) as Date, " +
                    "left(cal_date, 12) as [Date Calibrated], " +
                    "cal_int as Interval, " +
                    "left(cal_next, 12) as [Calibration Due], " +
                    "calsource as Source, " +
                    "certnum as [Certificate Number], " +
                    "Inspector, " +
                    "History1, " +
                    "History2, " +
                    "History3 " +
                    "from calibrationdata where item = '" +
                g.iID + "' order by currenthistory, chg_date desc", cnxn);
            table = new DataTable();
            da.Fill(table);
            bs.DataSource = table;
            DGV1.DataSource = bs;

            
            cal_Due = table.Rows[0][3].ToString().Trim();


            // location,user, owner
            da = new SqlDataAdapter("select i.il_location as Location, l.l_description as " +
                "[Description], e.Name as [User], ee.name as Owner " +
                " from itemlocation i inner join location l " +
                "on i.il_location = l.L_id " +
                "left join itemuser u on u.i_item = i.il_item " +
                "left join " + g.dbDash + " e on " +
                "u.i_user = e.badgeid " +
                "left join " + g.dbDash + " ee on " +
                "l.l_owner = ee.badgeid " +
                "where i.il_item = '" + g.iID + "' and u.i_user != 0", cnxn);
            DataTable table2 = new DataTable();
            da.Fill(table2);
            location = table2.Rows[0][0].ToString().Trim();
            LcurrentLocation.Text = "Current Location: " + location;
                
            LLocationDescription.Text = table2.Rows[0][1].ToString().Trim();
            user = table2.Rows[0][2].ToString().Trim();
            LcurrentUser.Text = "Current User: " + user;
            owner = table2.Rows[0][3].ToString().Trim();
            LcurrentOwner.Text = "Current Owner: " + owner;
            
            da = new SqlDataAdapter("select s.Location, e.name as [User], s.Date from scandata s " +
                " left join " + g.dbDash + " e on " +
                "s.employee = e.badgeid " +
                "where " +
                "item = '" + g.iID + "'  order by " +
                "s.date desc", cnxn);
            DataTable table3 = new DataTable();
            da.Fill(table3);
            bs3.DataSource = table3;
            DGV3.DataSource = bs3;

            cnxn.Close();
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            Pen pen = new Pen (Color.Black);
            pen.Width = 1;
            Font arial = new Font ("arial", 10, FontStyle.Regular );
            Font title = new Font ("arial", 14, FontStyle.Bold  );
            int col1 = 50;
            int col1D = 160;
            int col2 = 450;
            int col2D = 550;

            ev.Graphics.DrawString("Measurement Tool & Equipment",title , Brushes.Black, 260, 50);

            ev.Graphics.DrawString("ID: " + g.iID, title, Brushes.Black, 650, 50);
            ev.Graphics.DrawString("Description: ", arial , Brushes.Black, col1, 100);
            ev.Graphics.DrawString(desc, arial, Brushes.Black, 150, 100);
            ev.Graphics.DrawString(desc2, arial, Brushes.Black, 150, 125);
            ev.Graphics.DrawString("SN: " + sn, arial, Brushes.Black, col1, 150);
            ev.Graphics.DrawString("Type: ", arial, Brushes.Black, col2, 150);
            ev.Graphics.DrawString(type, arial, Brushes.Black, col2D, 150);
            ev.Graphics.DrawString("Manufacturer: ", arial, Brushes.Black, col1, 175);
            ev.Graphics.DrawString(manuf, arial, Brushes.Black, col1D, 175);
            ev.Graphics.DrawString("Status: ", arial, Brushes.Black, col2, 175);
            ev.Graphics.DrawString(status, arial, Brushes.Black, col2D, 175);
            ev.Graphics.DrawString("Model: ", arial, Brushes.Black, col1, 200);
            ev.Graphics.DrawString(model, arial, Brushes.Black, col1D, 200);
            ev.Graphics.DrawString("Temperature: ", arial, Brushes.Black, col2, 200);
            ev.Graphics.DrawString(tnom, arial, Brushes.Black, col2D, 200);
            ev.Graphics.DrawString("Size: ", arial, Brushes.Black, col1, 225);
            ev.Graphics.DrawString(size, arial, Brushes.Black, col1D, 225);
            ev.Graphics.DrawString("Humidity: ", arial, Brushes.Black, col2, 225);
            ev.Graphics.DrawString(hnom, arial, Brushes.Black, col2D, 225);
            ev.Graphics.DrawString("Purchase Date: ", arial, Brushes.Black, col1, 250);
            ev.Graphics.DrawString(date_new , arial, Brushes.Black, col1D, 250);
            ev.Graphics.DrawString("Pressure: ", arial, Brushes.Black, col2, 250);
            ev.Graphics.DrawString(pnom, arial, Brushes.Black, col2D, 250);
            ev.Graphics.DrawString("Purchase Cost: ", arial, Brushes.Black, col1, 275);
            ev.Graphics.DrawString(purchcost , arial, Brushes.Black, col1D, 275);
            ev.Graphics.DrawString("Procedure: ", arial, Brushes.Black, col2, 275);
            ev.Graphics.DrawString(procedure, arial, Brushes.Black, col2D, 275);
            ev.Graphics.DrawString("Business Unit Owner: ", arial, Brushes.Black, col1, 300);
            ev.Graphics.DrawString(tbBUOwner.Text, arial, Brushes.Black, 200, 300);
            ev.Graphics.DrawString("Capital Equipment Number: ", arial, Brushes.Black, col1, 325);
            ev.Graphics.DrawString(tbCapEquipNumber.Text, arial, Brushes.Black, 250, 325);
            ev.Graphics.DrawString("Comments: ", arial, Brushes.Black, col1, 350);
            ev.Graphics.DrawString(tbNotes.Text, arial, Brushes.Black, 250, 350);
            ev.Graphics.DrawString("Outsource Calibration: ", arial, Brushes.Black, col1, 375);
            ev.Graphics.DrawString(include, arial, Brushes.Black, 200, 375);
            ev.Graphics.DrawString("Reference Standard: ", arial, Brushes.Black, col1, 400);
            ev.Graphics.DrawString(tbRefStandard.Text, arial, Brushes.Black, 200, 400);
            
            ev.Graphics.DrawString("Calibration Due: ", arial, Brushes.Black, col1, 460);
            ev.Graphics.DrawString(cal_Due, arial, Brushes.Black, col1D, 460);
            ev.Graphics.DrawString("Location: ", arial, Brushes.Black, 400, 460);
            ev.Graphics.DrawString(location, arial, Brushes.Black, 500, 460);
            ev.Graphics.DrawString("User: ", arial, Brushes.Black, 50, 490);
            ev.Graphics.DrawString(user, arial, Brushes.Black, 150, 490);
            ev.Graphics.DrawString("Owner:", arial, Brushes.Black, 50, 520);
            ev.Graphics.DrawString(owner, arial, Brushes.Black, 150, 520);
            ev.Graphics.DrawString("Internal Calibration Contact:", arial, Brushes.Black, 50, 550);
            ev.Graphics.DrawString(tbInternalContact.Text, arial, Brushes.Black, 250, 550);


            ev.Graphics.DrawString("Record Date", arial, Brushes.Black, 50, 600);
            ev.Graphics.DrawString("Cal Date", arial, Brushes.Black, 150, 600);
            ev.Graphics.DrawString("Interval", arial, Brushes.Black, 250, 600);
            ev.Graphics.DrawString("Next Due", arial, Brushes.Black, 300, 600);
            ev.Graphics.DrawString("Cal Source", arial, Brushes.Black, 400, 600);
            ev.Graphics.DrawString("Cert", arial, Brushes.Black, 650, 600);
            ev.Graphics.DrawString("Inspector", arial, Brushes.Black, 750, 600);
            
            int lineDrop = 650;
            if (table.Rows.Count > 0 )
            {
                foreach (DataRow row in table.Rows)
                {
                    ev.Graphics.DrawString(row[0].ToString().Trim(), arial, Brushes.Black, 50, lineDrop);
                    ev.Graphics.DrawString(row[1].ToString().Trim(), arial, Brushes.Black, 150, lineDrop);
                    ev.Graphics.DrawString(row[2].ToString().Trim(), arial, Brushes.Black, 250, lineDrop);
                    ev.Graphics.DrawString(row[3].ToString().Trim(), arial, Brushes.Black, 300, lineDrop);
                    ev.Graphics.DrawString(row[4].ToString().Trim(), arial, Brushes.Black, 400, lineDrop);
                    ev.Graphics.DrawString(row[5].ToString().Trim(), arial, Brushes.Black, 650, lineDrop);
                    ev.Graphics.DrawString(row[6].ToString().Trim(), arial, Brushes.Black, 750, lineDrop);
                    lineDrop = lineDrop + 25;
                }
            }
            
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;
            (ppd as Form).WindowState = FormWindowState.Maximized;
            ppd.ShowDialog();
            Close();
        }
    }
}