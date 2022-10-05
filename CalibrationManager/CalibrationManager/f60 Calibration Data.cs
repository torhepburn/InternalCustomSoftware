using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using bpac;
using System.IO;
using System.Drawing.Printing;

namespace CalibrationManager
{
    public partial class f60_Calibration_Data : Form
    {
        SqlConnection cnxn;
        SqlCommand cmd;

        private int interval;
        private float fee;
        private float temperature;
        private float humidity;
        private float pressure;
        private string caldate;
        private string nextdate;
        private string ref1date;
        private string ref2date;
        private string datein;
        private string dateout;
        private int daysout;
        private string pfb4;
        private string pfaft;
        private string pfp1;
        private string pfp2;
        private string pfp3;
        private string pfp4;
        private string pfp5;
        private string pfp6;
        private string DataGood4Entry;
        DateTime dayFactor;
        
        public f60_Calibration_Data()
        {
            InitializeComponent();
        }

        private void f60_Calibration_Data_Load(object sender, EventArgs e)
        {
            
            // if Editing want to force the user to save the changes and 
            // not leave the record open
            if (g.task == "Edit")
            {
                this.ControlBox = false;
                this.WindowState = FormWindowState.Maximized;
            }

            if (g.task == "Add")
            {
                // cert button invisible as can't add a cert
                // until the record has been created.
                bCertPDF.Visible = false;
            }
            
            // identify the item
            Litem.Text = g.iID;
            Ldescription.Text = g.iDescription;

            // add the non-changing info from the item definition in 
            // the equipment table to the form
            cnxn = new SqlConnection(g.db);
            cmd = new SqlCommand
                ("Select * from equipment where id = '" +
                 g.iID + "'");
            cmd.Connection = cnxn;
            cnxn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (!dr.IsDBNull(14))
                {
                    if (dr.GetString(14).Trim().ToUpper() == "ACTIVE")
                    {
                        rbStatus.Checked = true;
                    }
                }
                if (!dr.IsDBNull(20)) { Lpar1.Text = dr.GetString(20).Trim(); }
                if (!dr.IsDBNull(21)) { Lpar1Nom.Text = dr.GetString(21).Trim(); }
                if (!dr.IsDBNull(22)) { Lpar1UM.Text = dr.GetString(22).Trim(); }
                if (!dr.IsDBNull(23)) { Lpar1Criteria.Text = dr.GetString(23).Trim(); }
                if (!dr.IsDBNull(24)) { Lpar2.Text = dr.GetString(24).Trim(); }
                if (!dr.IsDBNull(25)) { Lpar2Nom.Text = dr.GetString(25).Trim(); }
                if (!dr.IsDBNull(26)) { Lpar2UM.Text = dr.GetString(26).Trim(); }
                if (!dr.IsDBNull(27)) { Lpar2Criteria.Text = dr.GetString(27).Trim(); }
                if (!dr.IsDBNull(28)) { Lpar3.Text = dr.GetString(28).Trim(); }
                if (!dr.IsDBNull(29)) { Lpar3Nom.Text = dr.GetString(29).Trim(); }
                if (!dr.IsDBNull(30)) { Lpar3UM.Text = dr.GetString(30).Trim(); }
                if (!dr.IsDBNull(31)) { Lpar3Criteria.Text = dr.GetString(31).Trim(); }
                if (!dr.IsDBNull(32)) { Lpar4.Text = dr.GetString(32).Trim(); }
                if (!dr.IsDBNull(33)) { Lpar4Nom.Text = dr.GetString(33).Trim(); }
                if (!dr.IsDBNull(34)) { Lpar4UM.Text = dr.GetString(34).Trim(); }
                if (!dr.IsDBNull(35)) { Lpar4Criteria.Text = dr.GetString(35).Trim(); }
                if (!dr.IsDBNull(36)) { Lpar5.Text = dr.GetString(36).Trim(); }
                if (!dr.IsDBNull(37)) { Lpar5Nom.Text = dr.GetString(37).Trim(); }
                if (!dr.IsDBNull(38)) { Lpar5UM.Text = dr.GetString(38).Trim(); }
                if (!dr.IsDBNull(39)) { Lpar5Criteria.Text = dr.GetString(39).Trim(); }
                if (!dr.IsDBNull(40)) { Lpar6.Text = dr.GetString(40).Trim(); }
                if (!dr.IsDBNull(41)) { Lpar6Nom.Text = dr.GetString(41).Trim(); }
                if (!dr.IsDBNull(42)) { Lpar6UM.Text = dr.GetString(42).Trim(); }
                if (!dr.IsDBNull(43)) { Lpar6Criteria.Text = dr.GetString(43).Trim(); }
                if (!dr.IsDBNull(44))
                {
                    interval = dr.GetInt32(44);
                    LcalInterval.Text = "Calibration Interval (Months): " +
                        interval.ToString().Trim();
                }
            }
            cnxn.Close();
            
            //cal source drop down box
            string select = "select distinct d.calsource from calibrationdata d " +
                "inner join equipment e on e.id = d.item  " +
                " inner join status s on e.status = s.statuscode " +
                " where s.statuslive = 'y' and d.calsourcediscontinue = 'N' " +
                " order by d.calsource";

            cnxn.Open();
            SqlDataAdapter da = new SqlDataAdapter(select, cnxn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnxn.Close();
            comBoxCSource.DataSource = dt;
            comBoxCSource.DisplayMember = "CalSource";


            if (g.task == "Edit")
            {
                cmd = new SqlCommand
                    ("Select * " +
                     "from calibrationData where id = " +
                     g.cdID + " ");
                cmd.Connection = cnxn;
                cnxn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (!dr.IsDBNull(3))
                    { dtpCalDate.Text = dr.GetDateTime(3).ToString(); }
                    if (!dr.IsDBNull(4))
                    {
                        LcalInterval.Text = "Calibration Interval (Months): " +
                          dr.GetInt32(4).ToString();
                    }
                    if (!dr.IsDBNull(5))
                    {
                        dtpNextCalDate.Text = dr.GetDateTime(5).ToString();
                    }
                    if (!dr.IsDBNull(6))
                    { comBoxCSource.Text = dr.GetString(6).Trim(); }
                    if (!dr.IsDBNull(7))
                    { tbCalCost.Text = dr.GetDouble(7).ToString(); }
                    if (!dr.IsDBNull(8))
                    { comboxHistory1.Text = dr.GetString(8).Trim(); }
                    if (!dr.IsDBNull(9))
                    { tbHistory2.Text = dr.GetString(9).Trim(); }
                    if (!dr.IsDBNull(10))
                    { tbHistory3.Text = dr.GetString(10).Trim(); }
                    if (!dr.IsDBNull(11))
                    { tbTemp.Text = dr.GetDouble(11).ToString(); }
                    if (!dr.IsDBNull(12))
                    { tbHumidity.Text = dr.GetDouble(12).ToString(); }
                    if (!dr.IsDBNull(13))
                    { tbPressure.Text = dr.GetDouble(13).ToString(); }
                    if (!dr.IsDBNull(14))
                    { tbPar1B4.Text = dr.GetString(14).Trim(); }
                    if (!dr.IsDBNull(15))
                    { comBoxPFpar1.Text = dr.GetString(15).Trim(); }
                    if (!dr.IsDBNull(16))
                    { tbPar1Result.Text = dr.GetString(16).Trim(); }
                    if (!dr.IsDBNull(17))
                    { tbPar1Conditions.Text = dr.GetString(17).Trim(); }
                    if (!dr.IsDBNull(18))
                    { tbPar2B4.Text = dr.GetString(18).Trim(); }
                    if (!dr.IsDBNull(19))
                    { comBoxPFpar2.Text = dr.GetString(19).Trim(); }
                    if (!dr.IsDBNull(20))
                    { tbPar2Result.Text = dr.GetString(20).Trim(); }
                    if (!dr.IsDBNull(21))
                    { tbPar2Conditions.Text = dr.GetString(21).Trim(); }
                    if (!dr.IsDBNull(22))
                    { tbPar3B4.Text = dr.GetString(22).Trim(); }
                    if (!dr.IsDBNull(23))
                    { comBoxPFpar3.Text = dr.GetString(23).Trim(); }
                    if (!dr.IsDBNull(24))
                    { tbPar3Result.Text = dr.GetString(24).Trim(); }
                    if (!dr.IsDBNull(25))
                    { tbPar3Conditions.Text = dr.GetString(25).Trim(); }
                    if (!dr.IsDBNull(26))
                    { tbPar4B4.Text = dr.GetString(26).Trim(); }
                    if (!dr.IsDBNull(27))
                    { comBoxPFpar4.Text = dr.GetString(27).Trim(); }
                    if (!dr.IsDBNull(28))
                    { tbPar4Result.Text = dr.GetString(28).Trim(); }
                    if (!dr.IsDBNull(29))
                    { tbPar4Conditions.Text = dr.GetString(29).Trim(); }
                    if (!dr.IsDBNull(30))
                    { tbPar5B4.Text = dr.GetString(30).Trim(); }
                    if (!dr.IsDBNull(31))
                    { comBoxPFpar5.Text = dr.GetString(31).Trim(); }
                    if (!dr.IsDBNull(32))
                    { tbPar5Result.Text = dr.GetString(32).Trim(); }
                    if (!dr.IsDBNull(33))
                    { tbPar5Conditions.Text = dr.GetString(33).Trim(); }
                    if (!dr.IsDBNull(34))
                    { tbPar6B4.Text = dr.GetString(34).Trim(); }
                    if (!dr.IsDBNull(35))
                    { comBoxPFpar6.Text = dr.GetString(35).Trim(); }
                    if (!dr.IsDBNull(36))
                    { tbPar6Result.Text = dr.GetString(36).Trim(); }
                    if (!dr.IsDBNull(37))
                    { tbPar6Conditions.Text = dr.GetString(37).Trim(); }
                    if (!dr.IsDBNull(38))
                    { comboxPFb4.Text = dr.GetString(38).Trim(); }
                    if (!dr.IsDBNull(39))
                    { comboxPFaft.Text = dr.GetString(39).Trim(); }
                    if (!dr.IsDBNull(40))
                    { tbCorAct.Text = dr.GetString(40).Trim(); }
                    if (!dr.IsDBNull(41))
                    { comboxRefStd1.Text = dr.GetString(41).Trim(); }
                    if (!dr.IsDBNull(42))
                    { dtpRefStd1Date.Text = dr.GetDateTime(42).ToString(); }
                    if (!dr.IsDBNull(43))
                    { tbRefStd2.Text = dr.GetString(43).Trim(); }
                    if (!dr.IsDBNull(44))
                    { dtpRefStd2Date.Text = dr.GetDateTime(44).ToString(); }
                    if (!dr.IsDBNull(45))
                    { tbCertNumber.Text = dr.GetString(45).Trim(); }
                    if (!dr.IsDBNull(46))
                    { tbMuncertainty.Text = dr.GetString(46).Trim(); }
                    if (!dr.IsDBNull(47))
                    { tbLimitations.Text = dr.GetString(47).Trim(); }
                    if (!dr.IsDBNull(48))
                    { dtpDateOut.Text = dr.GetDateTime(48).ToString(); }
                    if (!dr.IsDBNull(49))
                    { dtpDateIn.Text = dr.GetDateTime(49).ToString(); }
                    if (!dr.IsDBNull(50))
                    { LcalDaysOut.Text = dr.GetInt32(50).ToString(); }
                    if (!dr.IsDBNull(51))
                    { tbInspector.Text = dr.GetString(51); }
                }
                cnxn.Close();
            }
            caldate = dtpCalDate.Text;
        }

        private void dtpCalDate_ValueChanged(object sender, EventArgs e)
        {
            dayFactor = new DateTime();
            dayFactor = Convert.ToDateTime(dtpCalDate.Text);
            dayFactor = dayFactor.AddMonths(interval);
            dtpNextCalDate.Value = dayFactor;
            caldate = dtpCalDate.Text;
            nextdate = dtpNextCalDate.Text;
        }

        private void rbStatus_MouseClick(object sender, MouseEventArgs e)
        {
            if (rbStatus.Checked == true)
            {
                cmd = new SqlCommand
                    ("Update equipment set status = 'ACTIVE' where " +
                      "id = '" + g.iID + "'");
                cmd.Connection = cnxn;
                cnxn.Open();
                int rowsReturned = cmd.ExecuteNonQuery();
                cnxn.Close();
            }
        }


        private void bEnterData_Click(object sender, EventArgs e)
        {
            action();
            
            if (DataGood4Entry == "Yes")
            {
                Close();
            }
        }

        private void bPrintLabelEnterData_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand
                ("Select status from equipment where id = '" + g.iID + "'");
            cmd.Connection = cnxn;
            cnxn.Open();
            object o = cmd.ExecuteScalar();
            cnxn.Close();
            if (o.ToString().ToUpper() != "ACTIVE")
            {
                MessageBox.Show("Must have an 'Active' status to print label.",
                    "Status");
                rbStatus.Focus();
                rbStatus.Checked = false;
                return;
            }

            if (Convert.ToInt32(LcalInterval.Text.Substring(31, (LcalInterval.Text.Length - 31))) <= 0)
            {
                MessageBox.Show("A Calibration Interval is required to print label.");
                return;
            }

            if (tbInspector.Text == "")
            {
                MessageBox.Show("Must have Inspector initials to print label.",
                    "Inspector Initials");
                tbInspector.Focus();
                return;
            }

            if (tbCertNumber.Text == "")
            {
                DialogResult result = new DialogResult();
                result = MessageBox.Show("Must have a Certification Number to print label, " +
                    " \n\runless this is the initial calibration.\n\r\n\rContinue ?",
                    "Certification Number", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    tbCertNumber.Focus();
                    return;
                }
            }

            if (caldate == "01/01/1900")
            {
                MessageBox.Show("Must have a Calibration Date to print label.",
                    "Calibration Date");
                dtpCalDate.Focus();
                return;
            }

            if (Convert.ToDateTime(caldate) > DateTime.Now)
            {
                MessageBox.Show("Calibration date must not be in the future.");
                dtpCalDate.Focus();
                return;
            }

            cnxn = new SqlConnection(g.db);
            cmd = new SqlCommand
                ("SELECT COALESCE(yesCertPDF, 'N') FROM CalibrationData WHERE " +
                 "CurrentHistory = 'C' and item = '" + g.iID + "'", cnxn);

            cnxn.Open();
            try
            {
                object oo = cmd.ExecuteScalar();

                if (oo.ToString() != "Y")
                {
                    MessageBox.Show("Calibration Certificate must be loaded in database.");
                    bCertPDF.Focus();
                    return;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            action();

            bpac.Document BroDoc = new Document();
            BroDoc.Open("c:\\calibration\\calibration.lbl");
            int index = BroDoc.GetTextIndex("ID");
            BroDoc.SetText(index, g.iID);
            index = BroDoc.GetTextIndex("strInspectedBy");
            BroDoc.SetText(index, tbInspector.Text.Trim());
            index = BroDoc.GetTextIndex("DESC");
            BroDoc.SetText(index, g.iDescription);
            index = BroDoc.GetTextIndex("CertNum");
            BroDoc.SetText(index, tbCertNumber.Text.Trim());
            index = BroDoc.GetTextIndex("LAST_CAL");
            BroDoc.SetText(index, caldate);
            index = BroDoc.GetTextIndex("CAL_NEXT");
            BroDoc.SetText(index, nextdate);
            BroDoc.DoPrint(0, "0");
            BroDoc.Close();

            if (DataGood4Entry == "Yes")
            {
                Close();
            }
        }

        private void dtpDateIn_ValueChanged(object sender, EventArgs e)
        {
            DateTime start = dtpDateOut.Value;
            DateTime stop = dtpDateIn.Value;
            TimeSpan elapsed = stop.Subtract(start);
            LcalDaysOut.Text = elapsed.TotalDays.ToString();
            daysout = Convert.ToInt32(elapsed.TotalDays);
            datein = dtpDateIn.Text;
        }

        private void dtpNextCalDate_ValueChanged(object sender, EventArgs e)
        {
            nextdate = dtpNextCalDate.Text;
        }

        private void dtpDateOut_ValueChanged(object sender, EventArgs e)
        {
            dateout = dtpDateOut.Text;
        }

        private void dtpRefStd1Date_ValueChanged(object sender, EventArgs e)
        {
            ref1date = dtpRefStd1Date.Text;
        }

        private void dtpRefStd2Date_ValueChanged(object sender, EventArgs e)
        {
            ref2date = dtpRefStd2Date.Text;
        }

        private void action()
        {
            DataGood4Entry = "Yes";
            string a;

            a = tbCalCost.Text.Trim();
            if (a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbCalCost.Text, out fee);
                if (isNum == false)
                {
                    MessageBox.Show("Invalid Number");
                    tbCalCost.Text = "";
                    tbCalCost.Focus();
                    DataGood4Entry = "No";
                    return;
                }
                else
                {
                    DataGood4Entry = "Yes";
                }
            }

            a = tbTemp.Text.Trim();
            if (a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbTemp.Text, out temperature);
                if (isNum == false)
                {
                    MessageBox.Show("Invalid Number");
                    tbTemp.Text = "";
                    tbTemp.Focus();
                    DataGood4Entry = "No";
                    return;
                }
                else
                {
                    DataGood4Entry = "Yes";
                }
            }

            a = tbHumidity.Text.Trim();
            if (a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbHumidity.Text, out humidity);
                if (isNum == false)
                {
                    MessageBox.Show("Invalid Number");
                    tbHumidity.Text = "";
                    tbHumidity.Focus();
                    DataGood4Entry = "No";
                    return;
                }
                else
                {
                    DataGood4Entry = "Yes";
                }
            }

            a = tbPressure.Text.Trim();
            if (a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbPressure.Text, out pressure);
                if (isNum == false)
                {
                    MessageBox.Show("Invalid Number");
                    tbPressure.Text = "";
                    tbPressure.Focus();
                    DataGood4Entry = "No";
                    return;
                }
                else
                {
                    DataGood4Entry = "Yes";
                }
            }

            pfb4 = comboxPFb4.Text.Trim();
            pfaft = comboxPFaft.Text.Trim();
            pfp1 = comBoxPFpar1.Text.Trim();
            pfp2 = comBoxPFpar2.Text.Trim();
            pfp3 = comBoxPFpar3.Text.Trim();
            pfp4 = comBoxPFpar4.Text.Trim();
            pfp5 = comBoxPFpar5.Text.Trim();
            pfp6 = comBoxPFpar6.Text.Trim();
            

            SqlParameter calsource = new SqlParameter("@calsource",
                    SqlDbType.NVarChar, 20);
            calsource.Value = comBoxCSource.Text.Trim();

            SqlParameter history1 = new SqlParameter("@history1",
                SqlDbType.NVarChar, 255);
            history1.Value = comboxHistory1.Text.Trim();

            SqlParameter history2 = new SqlParameter("@history2",
                SqlDbType.NVarChar, 255);
            history2.Value = tbHistory2.Text.Trim();

            SqlParameter history3 = new SqlParameter("@history3",
                SqlDbType.NVarChar, 255);
            history3.Value = tbHistory3.Text.Trim();

            //1
            SqlParameter par1b4 = new SqlParameter("@par1b4",
                SqlDbType.NVarChar, 50);
            par1b4.Value = tbPar1B4.Text.Trim();

            SqlParameter par1aft = new SqlParameter("@par1aft",
                SqlDbType.NVarChar, 50);
            par1aft.Value = tbPar1Result.Text.Trim();

            SqlParameter par1cond = new SqlParameter("@par1cond",
                SqlDbType.NVarChar, 20);
            par1cond.Value = tbPar1Conditions.Text.Trim();

            //2
            SqlParameter par2b4 = new SqlParameter("@par2b4",
                SqlDbType.NVarChar, 50);
            par2b4.Value = tbPar2B4.Text.Trim();

            SqlParameter par2aft = new SqlParameter("@par2aft",
                SqlDbType.NVarChar, 50);
            par2aft.Value = tbPar2Result.Text.Trim();

            SqlParameter par2cond = new SqlParameter("@par2cond",
                SqlDbType.NVarChar, 20);
            par2cond.Value = tbPar2Conditions.Text.Trim();

            //3
            SqlParameter par3b4 = new SqlParameter("@par3b4",
                SqlDbType.NVarChar, 50);
            par3b4.Value = tbPar3B4.Text.Trim();

            SqlParameter par3aft = new SqlParameter("@par3aft",
                SqlDbType.NVarChar, 50);
            par3aft.Value = tbPar3Result.Text.Trim();

            SqlParameter par3cond = new SqlParameter("@par3cond",
                SqlDbType.NVarChar, 20);
            par3cond.Value = tbPar3Conditions.Text.Trim();

            //4
            SqlParameter par4b4 = new SqlParameter("@par4b4",
                SqlDbType.NVarChar, 50);
            par4b4.Value = tbPar4B4.Text.Trim();

            SqlParameter par4aft = new SqlParameter("@par4aft",
                SqlDbType.NVarChar, 50);
            par4aft.Value = tbPar4Result.Text.Trim();

            SqlParameter par4cond = new SqlParameter("@par4cond",
                SqlDbType.NVarChar, 20);
            par4cond.Value = tbPar4Conditions.Text.Trim();

            //5
            SqlParameter par5b4 = new SqlParameter("@par5b4",
                SqlDbType.NVarChar, 50);
            par5b4.Value = tbPar5B4.Text.Trim();

            SqlParameter par5aft = new SqlParameter("@par5aft",
                SqlDbType.NVarChar, 50);
            par5aft.Value = tbPar5Result.Text.Trim();

            SqlParameter par5cond = new SqlParameter("@par5cond",
                SqlDbType.NVarChar, 20);
            par5cond.Value = tbPar5Conditions.Text.Trim();

            //6
            SqlParameter par6b4 = new SqlParameter("@par6b4",
                SqlDbType.NVarChar, 50);
            par6b4.Value = tbPar6B4.Text.Trim();

            SqlParameter par6aft = new SqlParameter("@par6aft",
                SqlDbType.NVarChar, 50);
            par6aft.Value = tbPar6Result.Text.Trim();

            SqlParameter par6cond = new SqlParameter("@par6cond",
                SqlDbType.NVarChar, 20);
            par6cond.Value = tbPar6Conditions.Text.Trim();

            SqlParameter coract = new SqlParameter("@coract",
               SqlDbType.NVarChar, 65);
            coract.Value = tbCorAct.Text.Trim();

            SqlParameter rfst1 = new SqlParameter("@rfst1",
               SqlDbType.NVarChar, 30);
            rfst1.Value = comboxRefStd1.Text.Trim();

            SqlParameter rfst2 = new SqlParameter("@rfst2",
               SqlDbType.NVarChar, 30);
            rfst2.Value = tbRefStd2.Text.Trim();

            SqlParameter certnum = new SqlParameter("@certnum",
               SqlDbType.NVarChar, 50);
            certnum.Value = tbCertNumber.Text.Trim();

            SqlParameter muncert = new SqlParameter("@muncert",
               SqlDbType.NVarChar, 50);
            muncert.Value = tbMuncertainty.Text.Trim();

            SqlParameter lims = new SqlParameter("@lims",
              SqlDbType.NVarChar, 255);
            lims.Value = tbLimitations.Text.Trim();

            SqlParameter nspectr = new SqlParameter("@nspectr",
              SqlDbType.NVarChar, 50);
            nspectr.Value = tbInspector.Text.Trim();


            if (g.task == "Add")
            {
                cmd = new SqlCommand(" update calibrationdata " +
                    " set currenthistory = 'H' where currenthistory " +
                    " = 'C' and item = '" + g.iID + "'");
                cmd.Connection = cnxn;
                cnxn.Open();
                cmd.ExecuteNonQuery();
                cnxn.Close();

                DateTime now = DateTime.Now;

                
                cmd = new SqlCommand("insert into CalibrationData (" +
                    "item, " +
                    "chg_date, " +
                    "cal_date, " +
                    "cal_int, " +
                    "cal_next, " +
                    "calsource, " +
                    "calfee, " +
                    "pfbeforecal, " +
                    "pfaftercal, " +
                    "history1, " +
                    "history2, " +
                    "history3, " +
                    "temp, " +
                    "hum, " +
                    "press, " +
                    "par1b4, " +
                    "par1pf, " +
                    "par1aft, " +
                    "par1cond, " +
                    "par2b4, " +
                    "par2pf, " +
                    "par2aft, " +
                    "par2cond, " +
                    "par3b4, " +
                    "par3pf, " +
                    "par3aft, " +
                    "par3cond, " +
                    "par4b4, " +
                    "par4pf, " +
                    "par4aft, " +
                    "par4cond, " +
                    "par5b4, " +
                    "par5pf, " +
                    "par5aft, " +
                    "par5cond, " +
                    "par6b4, " +
                    "par6pf, " +
                    "par6aft, " +
                    "par6cond, " +
                    "coract, " +
                    "refstd1, " +
                    "refstd1date, " +
                    "refstd2, " +
                    "refstd2date, " +
                    "certnum, " +
                    "measuncert, " +
                    "limitations, " +
                    "inspector, " +
                    "caldate_out, " +
                    "caldate_in, " +
                    "caltime_days, " +
                    "currenthistory, " +
                    "calsourcediscontinue) " +
                    " values (" +
                    "'" + g.iID +
                    "','" + now.ToShortDateString() + 
                    "','" + Convert.ToDateTime(dtpCalDate.Text) +
                    "'," + interval +
                    ",'" + Convert.ToDateTime(dtpNextCalDate.Text) +
                    "'," + calsource +
                    "," + fee +
                    ",'" + pfb4 +
                    "','" + pfaft +
                    "'," + history1 +
                    "," + history2 +
                    "," + history3 +
                    "," + temperature +
                    "," + humidity +
                    "," + pressure +
                    "," + par1b4 +
                    ",'" + pfp1 +
                    "'," + par1aft +
                    "," + par1cond +
                    "," + par2b4 +
                    ",'" + pfp2 +
                    "'," + par2aft +
                    "," + par2cond +
                    "," + par3b4 +
                    ",'" + pfp3 +
                    "'," + par3aft +
                    "," + par3cond +
                    "," + par4b4 +
                    ",'" + pfp4 +
                    "'," + par4aft +
                    "," + par4cond +
                    "," + par5b4 +
                    ",'" + pfp5 +
                    "'," + par5aft +
                    "," + par5cond +
                    "," + par6b4 +
                    ",'" + pfp6 +
                    "'," + par6aft +
                    "," + par6cond +
                    "," + coract +
                    "," + rfst1 +
                    ",'" + Convert.ToDateTime(dtpRefStd1Date.Text) +
                    "'," + rfst2 +
                    ",'" + Convert.ToDateTime(dtpRefStd2Date.Text) +
                    "'," + certnum +
                    "," + muncert +
                    "," + lims +
                    "," + nspectr +
                    ",'" + Convert.ToDateTime(dtpDateOut.Text) +
                    "','" + Convert.ToDateTime(dtpDateIn.Text) +
                    "'," + daysout +
                    ",'C' " +
                    ", 'N')");

                cmd.Parameters.Add(calsource);
                cmd.Parameters.Add(history1);
                cmd.Parameters.Add(history2);
                cmd.Parameters.Add(history3);
                cmd.Parameters.Add(par1b4);
                cmd.Parameters.Add(par2b4);
                cmd.Parameters.Add(par3b4);
                cmd.Parameters.Add(par4b4);
                cmd.Parameters.Add(par5b4);
                cmd.Parameters.Add(par6b4);
                cmd.Parameters.Add(par1aft);
                cmd.Parameters.Add(par2aft);
                cmd.Parameters.Add(par3aft);
                cmd.Parameters.Add(par4aft);
                cmd.Parameters.Add(par5aft);
                cmd.Parameters.Add(par6aft);
                cmd.Parameters.Add(par1cond);
                cmd.Parameters.Add(par2cond);
                cmd.Parameters.Add(par3cond);
                cmd.Parameters.Add(par4cond);
                cmd.Parameters.Add(par5cond);
                cmd.Parameters.Add(par6cond);
                cmd.Parameters.Add(coract);
                cmd.Parameters.Add(rfst1);
                cmd.Parameters.Add(rfst2);
                cmd.Parameters.Add(certnum);
                cmd.Parameters.Add(muncert);
                cmd.Parameters.Add(lims);
                cmd.Parameters.Add(nspectr);
                
                cmd.Connection = cnxn;
                cnxn.Open();
                try
                {
                    int rowsReturned = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                cnxn.Close();
                cmd.Parameters.Clear();
            }

            if (g.task == "Edit")
            {
                cmd = new SqlCommand("Update CalibrationData set " +
                    "cal_date = '" + dtpCalDate.Value + "', " +
                    "cal_int = " + interval + ", " +
                    "cal_next = '" + dtpNextCalDate.Value + "'," +
                    "calsource = " + calsource + ", " +
                    "calfee = " + fee + ", " +
                    "pfbeforecal = '" + pfb4 + "', " +
                    "pfaftercal ='" + pfaft + "', " +
                    "history1 =" + history1 + ", " +
                    "history2 =" + history2 + ", " +
                    "history3 =" + history3 + ", " +
                    "temp = " + temperature + ", " +
                    "hum = " + humidity + ", " +
                    "press = " + pressure + ", " +
                    "par1b4 = " + par1b4 + ", " +
                    "par1pf = '" + pfp1 + "', " +
                    "par1aft = " + par1aft + ", " +
                    "par1cond = " + par1cond + ", " +
                    "par2b4 = " + par2b4 + ", " +
                    "par2pf = '" + pfp2 + "', " +
                    "par2aft = " + par2aft + ", " +
                    "par2cond = " + par2cond + ", " +
                    "par3b4 = " + par3b4 + ", " +
                    "par3pf = '" + pfp3 + "', " +
                    "par3aft = " + par3aft + ", " +
                    "par3cond = " + par3cond + ", " +
                    "par4b4 = " + par4b4+ ", " +
                    "par4pf = '" + pfp4 + "', " +
                    "par4aft = " + par4aft + ", " +
                    "par4cond = " + par4cond + ", " +
                    "par5b4 = " + par5b4 + ", " +
                    "par5pf = '" + pfp5 + "', " +
                    "par5aft = " + par5aft + ", " +
                    "par5cond = " + par5cond + ", " +
                    "par6b4 = " + par6b4 + ", " +
                    "par6pf = '" + pfp6 + "', " +
                    "par6aft = " + par6aft + ", " +
                    "par6cond = " + par6cond + ", " +
                    "coract = " + coract + ", " +
                    "refstd1 = " + rfst1 + ", " +
                    "refstd1date = '" + dtpRefStd1Date.Value + "', " +
                    "refstd2 = " + rfst2 + ", " +
                    "refstd2date = '" + dtpRefStd2Date.Value + "', " +
                    "certnum = " + certnum + ", " +
                    "measuncert = " + muncert + ", " +
                    "limitations = " + lims + ", " +
                    "inspector = " + nspectr + ", " +
                    "caldate_out = '" + dtpDateOut.Value + "', " +
                    "caldate_in = '" + dtpDateIn.Value + "', " +
                    "caltime_days =" + daysout + " " +
                    " where id = " +
                    "" + g.cdID +
                    " ");

                cmd.Parameters.Add(calsource);
                cmd.Parameters.Add(history1);
                cmd.Parameters.Add(history2);
                cmd.Parameters.Add(history3);
                cmd.Parameters.Add(par1b4);
                cmd.Parameters.Add(par2b4);
                cmd.Parameters.Add(par3b4);
                cmd.Parameters.Add(par4b4);
                cmd.Parameters.Add(par5b4);
                cmd.Parameters.Add(par6b4);
                cmd.Parameters.Add(par1aft);
                cmd.Parameters.Add(par2aft);
                cmd.Parameters.Add(par3aft);
                cmd.Parameters.Add(par4aft);
                cmd.Parameters.Add(par5aft);
                cmd.Parameters.Add(par6aft);
                cmd.Parameters.Add(par1cond);
                cmd.Parameters.Add(par2cond);
                cmd.Parameters.Add(par3cond);
                cmd.Parameters.Add(par4cond);
                cmd.Parameters.Add(par5cond);
                cmd.Parameters.Add(par6cond);
                cmd.Parameters.Add(coract);
                cmd.Parameters.Add(rfst1);
                cmd.Parameters.Add(rfst2);
                cmd.Parameters.Add(certnum);
                cmd.Parameters.Add(muncert);
                cmd.Parameters.Add(lims);
                cmd.Parameters.Add(nspectr);
                
                cmd.Connection = cnxn;
                cnxn.Open();
                try
                {
                    int rowsReturned = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                cnxn.Close();
                cmd.Parameters.Clear();
            }
        }

        private void bCertPDF_Click(object sender, EventArgs e)
        {
            f66_Attach_PDF pdf = new f66_Attach_PDF();
            pdf.Show();
        }

        //private void enterData()
        //{
        //    g.task = "Review";
        //    f61_Review_Data f61 = new f61_Review_Data();
        //    f61.Show();
        //    Close();
        //}

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bForm_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage +=new PrintPageEventHandler(pd_PrintPage);
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;
            (ppd as Form).WindowState = FormWindowState.Maximized;
            ppd.ShowDialog();
            Close();
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            Pen pen = new Pen(Color.Black);
            pen.Width = 1;
            Font arial = new Font("arial", 10, FontStyle.Regular);
            Font title = new Font("arial", 14, FontStyle.Bold);
            int col1 = 50;
            int col1D = 160;
            int col2 = 450;
            int col2D = 550;

            ev.Graphics.DrawString("ZYGO Calibration Certificate", title, Brushes.Black, 260, 50);

            ev.Graphics.DrawString("ID: " + g.iID, title, Brushes.Black, col1, 100);
            ev.Graphics.DrawString(g.iDescription, title, Brushes.Black, 200, 100);
            ev.Graphics.DrawString("Calibration Date: ____________________ ", arial, Brushes.Black, col1, 140);
            ev.Graphics.DrawString(LcalInterval.Text, arial, Brushes.Black, 500, 140);
            ev.Graphics.DrawString("Status Before Calibration: Pass Fail ", arial, Brushes.Black, col1, 175);
            ev.Graphics.DrawString("Status After Calibration: Pass Fail ", arial, Brushes.Black, col2, 175);
            ev.Graphics.DrawString("History1:______________________________________________________________________ ", arial, Brushes.Black, col1, 200);
            ev.Graphics.DrawString("History2:______________________________________________________________________ ", arial, Brushes.Black, col1, 225);
            ev.Graphics.DrawString("History3:______________________________________________________________________ ", arial, Brushes.Black, col1, 250);
            ev.Graphics.DrawString("Test Parameter     Criteria     Nominal     UM     Value Before Cal     P/F     Value After Cal     Condition", arial, Brushes.Black, col1, 300);
            ev.Graphics.DrawString("____________________________________________________________________________________", arial, Brushes.Black, col1, 325);
            ev.Graphics.DrawString("____________________________________________________________________________________", arial, Brushes.Black, col1, 350);
            ev.Graphics.DrawString("____________________________________________________________________________________", arial, Brushes.Black, col1, 375);
            ev.Graphics.DrawString("____________________________________________________________________________________", arial, Brushes.Black, col1, 400);
            ev.Graphics.DrawString("____________________________________________________________________________________", arial, Brushes.Black, col1, 425);
            ev.Graphics.DrawString("____________________________________________________________________________________", arial, Brushes.Black, col1, 450);
            
            
            ev.Graphics.DrawString("Corrective Action:______________________________________________________________________", arial, Brushes.Black, col1, 500);
            ev.Graphics.DrawString("Limitations:___________________________________________________________________________", arial, Brushes.Black, col1, 525);
            ev.Graphics.DrawString("Reference Standard 1:__________________________________________________________________", arial, Brushes.Black, col1, 550);
            ev.Graphics.DrawString("Reference Standard 1 Date:______________________________________________________________", arial, Brushes.Black, col1, 575);
            ev.Graphics.DrawString("Applicable Calibration Procedure:__________________________________________________________", arial, Brushes.Black, col1, 600);
            ev.Graphics.DrawString("Procedure Date and Revsion:_____________________________________________________________", arial, Brushes.Black, col1, 625);
            
            ev.Graphics.DrawString("Temperature:__________ ", arial, Brushes.Black, col1, 650);
            ev.Graphics.DrawString("Humidity:__________ ", arial, Brushes.Black, col1, 675);
            ev.Graphics.DrawString("Pressure:__________ ", arial, Brushes.Black, col1, 700);
            ev.Graphics.DrawString("Measurement Uncertainty:______________________________ ", arial, Brushes.Black, col1, 725);
            ev.Graphics.DrawString("Certificate Number:_________________________ ", arial, Brushes.Black, col1, 775);
            ev.Graphics.DrawString("Inspected by:_________________________________________________ Date: ___________________", arial, Brushes.Black, col1, 850);
            
            
        }



    }
}
