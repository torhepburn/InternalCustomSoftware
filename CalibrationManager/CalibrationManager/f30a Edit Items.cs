using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CalibrationManager
{
    public partial class f30_Edit_Items : Form
    {
        private double cost;
        private float temperature;
        private float humidity;
        private float pressure;

        SqlConnection cnxn;
        SqlCommand cmd;
        BindingSource bs = new BindingSource();
        SqlParameter Outsource = new SqlParameter("@Outsource", SqlDbType.NVarChar, 1);
        SqlParameter referenceStandardExists = new SqlParameter("@referenceStandardExists", SqlDbType.NVarChar, 1);
        SqlParameter DateNew = new SqlParameter("@DateNew", SqlDbType.DateTime);

        public f30_Edit_Items()
        {
            InitializeComponent();
        }

        private void f30_Edit_Items_Load(object sender, EventArgs e)
        {
            tbID.Text = g.iID;

            dtpDateNew.CustomFormat = "MM/dd/yyyy";
            dtpDateNew.Text = "01/01/1900";

            cnxn = new SqlConnection(g.db);
            SqlDataAdapter da = new SqlDataAdapter
                ("select * from status order by statuscode", cnxn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cbddStatus.DataSource = dt;
            cbddStatus.DisplayMember = "StatusCode";

            SqlDataAdapter da1 = new SqlDataAdapter
                ("select distinct type  from equipment order by type", cnxn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            cbddType.DataSource = dt1;
            cbddType.DisplayMember = "type";

            if (g.task == "Edit")
            {
                cnxn = new SqlConnection(g.db);
                SqlCommand cmd = new SqlCommand
               ("Select * from equipment where id = '" +
                g.iID + "'");
                cmd.Connection = cnxn;
                cnxn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (!dr.IsDBNull(1)) { tbDesc.Text = dr.GetString(1).Trim(); }
                    if (!dr.IsDBNull(2)) { tbExtDesc.Text = dr.GetString(2).Trim(); }
                    if (!dr.IsDBNull(3)) { tbSN.Text = dr.GetString(3).Trim(); }
                    if (!dr.IsDBNull(4)) { tbManufacturer.Text = dr.GetString(4).Trim(); }
                    if (!dr.IsDBNull(5)) { tbModel.Text = dr.GetString(5).Trim(); }
                    if (!dr.IsDBNull(6)) { tbSize.Text = dr.GetString(6).Trim(); }
                    if (!dr.IsDBNull(7)) { dtpDateNew.Text = dr.GetDateTime(7).ToShortDateString(); }
                    if (!dr.IsDBNull(8)) { tbPurchCost.Text = dr.GetDouble(8).ToString(); }
                    if (!dr.IsDBNull(9)) { tbBUOwner.Text = dr.GetString(9).Trim(); }
                    if (!dr.IsDBNull(10)) { tbCapEquipNumber.Text = dr.GetString(10).Trim(); }

                    if (!dr.IsDBNull(12)) { referenceStandardExists.Value = dr.GetString(12); }
                    if (referenceStandardExists.Value.ToString() == "Y")
                    { cbRefStandard.Checked = true; cbRefStandard.Text = "Yes"; }
                    else { cbRefStandard.Checked = false; cbRefStandard.Text = "No"; }

                    if (!dr.IsDBNull(13)) { cbddType.Text = dr.GetString(13).Trim(); }
                    if (!dr.IsDBNull(14)) { cbddStatus.Text = dr.GetString(14).Trim(); }
                    if (!dr.IsDBNull(15)) { tbTemperature.Text = dr.GetDouble(15).ToString(); }
                    if (!dr.IsDBNull(16)) { tbHumidity.Text = dr.GetDouble(16).ToString(); }
                    if (!dr.IsDBNull(17)) { tbPressure.Text = dr.GetDouble(17).ToString(); }
                    if (!dr.IsDBNull(18)) { tbProcedure.Text = dr.GetString(18).Trim(); }
                    if (!dr.IsDBNull(19)) { tbNotes.Text = dr.GetString(19); }
                    if (!dr.IsDBNull(45))
                    {
                        if (dr.GetInt32(45) > 0)
                        {
                            SqlConnection cnxn2 = new SqlConnection
                            (g.dbDashserver);
                            SqlCommand cmd2 = new SqlCommand
                             (" select name from view_employees where " +
                            " badgeid = " + dr.GetInt32(45) + " ", cnxn2);
                            cnxn2.Open();
                            object o = cmd2.ExecuteScalar();
                            tbInternalContact.Text = o.ToString().Trim();
                            cnxn2.Close();
                            g.internalCalContact = dr.GetInt32(45);
                        }
                    }
                    if (!dr.IsDBNull(11)) { Outsource.Value = dr.GetString(11).Trim(); }
                    if (Outsource.Value.ToString() == "Y")
                    {
                        cbInclude.Checked = true;
                        cbInclude.Text = "Yes";
                        tbInternalContact.Text = "";
                        g.internalCalContact = 0;
                    }
                    else
                    {
                        cbInclude.Checked = false; cbInclude.Text = "No";
                    }
                }
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            string a;

            SqlParameter ItemType = new SqlParameter("@ItemType", SqlDbType.NVarChar, 25);
            ItemType.Value = cbddType.Text.ToString().Trim();
            SqlParameter SN = new SqlParameter("@SN", SqlDbType.NVarChar, 25);
            SN.Value = tbSN.Text.ToString().Trim();
            SqlParameter Manufacturer = new SqlParameter("@Manufacturer", SqlDbType.NVarChar, 25);
            Manufacturer.Value = tbManufacturer.Text.ToString().Trim();
            SqlParameter Description = new SqlParameter("@Description", SqlDbType.NVarChar, 65);
            Description.Value = tbDesc.Text.ToString().Trim();
            SqlParameter ExtendedDescription = new SqlParameter("@ExtendedDescription", SqlDbType.NVarChar, 65);
            ExtendedDescription.Value = tbExtDesc.Text.ToString().Trim();
            SqlParameter Model = new SqlParameter("@Model", SqlDbType.NVarChar, 15);
            Model.Value = tbModel.Text.ToString().Trim();
            SqlParameter ItemSize = new SqlParameter("@ItemSize", SqlDbType.NVarChar, 25);
            ItemSize.Value = tbSize.Text.ToString().Trim();
            DateNew.Value = dtpDateNew.Text.ToString();
            SqlParameter Status = new SqlParameter("@Status", SqlDbType.NVarChar, 25);
            Status.Value = cbddStatus.Text.ToString().Trim();

            if (cbInclude.Checked == true)
            {
                Outsource.Value = "Y";
                tbInternalContact.Text = "";
                g.internalCalContact = 0;
            }
            else
            {
                Outsource.Value = "N";
            }

            a = tbPurchCost.Text.Trim();
            if (a != "")
            {
                bool isNum;
                isNum = double.TryParse(tbPurchCost.Text, out cost);
                if (isNum == false)
                {
                    MessageBox.Show("Invalid Number");
                    tbPurchCost.Text = "";
                    tbPurchCost.Focus();
                    return;
                }
            }

            a = tbTemperature.Text.Trim();
            if (a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbTemperature.Text, out temperature);
                if (isNum == false)
                {
                    MessageBox.Show("Invalid Number");
                    tbTemperature.Text = "";
                    tbTemperature.Focus();
                    return;
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
                    return;
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
                    return;
                }
            }


            a = tbInternalContact.Text.Trim();
            if (a != "" & g.internalCalContact == 0)
            {
                MessageBox.Show("Must Use Button to Select Contact");
                tbInternalContact.Text = "";
                tbInternalContact.Focus();
                return;
            }

            if (cbRefStandard.Checked == true)
            {
                referenceStandardExists.Value = "Y";
            }
            else
            {
                referenceStandardExists.Value = "N";
            }

            SqlParameter buOwner = new SqlParameter("@buOwner", SqlDbType.NVarChar, 30);
            buOwner.Value = tbBUOwner.Text.ToString().Trim();
            SqlParameter capEquipNumber = new SqlParameter("@capEquipNumber", SqlDbType.NVarChar, 10);
            capEquipNumber.Value = tbCapEquipNumber.Text.ToString().Trim();
            SqlParameter procedure = new SqlParameter("@procedure", SqlDbType.NVarChar, 25);
            procedure.Value = tbProcedure.Text.ToString().Trim();
            SqlParameter comments = new SqlParameter("@comments", SqlDbType.NVarChar, 40);
            comments.Value = tbNotes.Text.ToString().Trim();
            SqlParameter InternalCalContact = new SqlParameter("@InternalCalContact", SqlDbType.Int);
            InternalCalContact.Value = g.internalCalContact;


            if (g.task == "Add")
            {
                DateTime date = DateTime.Now;
                cnxn = new SqlConnection(g.db);
                cmd = new SqlCommand("Insert into equipment (" +
                    "id," +
                    "[description]," +
                    "desc2," +
                    "sn," +
                    "manuf," +
                    "model," +
                    "size," +
                    "date_new," +
                    "purchcost," +
                    "bunitowner," +
                    "capEquipNumber," +
                    "outsource," +
                    "refstd," +
                    "type," +
                    "status," +
                    "tnom," +
                    "hnom," +
                    "pnom," +
                    "[procedure]," +
                    "comments, " +
                    "internal_cal_contact)" +
                    " values (" +
                    "'" + g.iID +
                    "'," + Description +
                    "," + ExtendedDescription +
                    "," + SN +
                    "," + Manufacturer +
                    "," + Model +
                    "," + ItemSize +
                    "," + DateNew +
                    "," + cost +
                    "," + buOwner +
                    "," + capEquipNumber +
                    "," + Outsource +
                    "," + referenceStandardExists +
                    "," + ItemType +
                    "," + Status +
                    "," + temperature +
                    "," + humidity +
                    "," + pressure +
                    "," + procedure +
                    "," + comments +
                    "," + InternalCalContact + ") " +
                    "Insert into Calibrationdata " +
                    "(Item, chg_date, history1, CurrentHistory) values ('" +
                    g.iID + "','" + date + "','Initial Entry', 'C')");
                cmd.Parameters.Add(ItemType);
                cmd.Parameters.Add(SN);
                cmd.Parameters.Add(Manufacturer);
                cmd.Parameters.Add(Description);
                cmd.Parameters.Add(ExtendedDescription);
                cmd.Parameters.Add(Model);
                cmd.Parameters.Add(ItemSize);
                cmd.Parameters.Add(DateNew);
                cmd.Parameters.Add(Status);
                cmd.Parameters.Add(Outsource);
                cmd.Parameters.Add(referenceStandardExists);
                cmd.Parameters.Add(buOwner);
                cmd.Parameters.Add(procedure);
                cmd.Parameters.Add(comments);
                cmd.Parameters.Add(InternalCalContact);
                cmd.Parameters.Add(capEquipNumber);

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
                g.internalCalContact = 0;
            }
            else
            {
                cnxn = new SqlConnection(g.db);
                cmd = new SqlCommand("Update equipment set " +
                    "type = " + ItemType + ", " +
                    "sn = " + SN + ", " +
                    "manuf = " + Manufacturer + ", " +
                    "[description] = " + Description + ", " +
                    "desc2 = " + ExtendedDescription + ", " +
                    "model = " + Model + ", " +
                    "size = " + ItemSize + ", " +
                    "date_new = " + DateNew + ", " +
                    "status = " + Status + ", " +
                    "outsource = " + Outsource + ", " +
                    "purchcost = '" + cost + "', " +
                    "tnom = '" + temperature + "', " +
                    "hnom = '" + humidity + "', " +
                    "pnom ='" + pressure + "', " +
                    "refstd =" + referenceStandardExists + ", " +
                    "[procedure] =" + procedure + ", " +
                    "comments =" + comments + ", " +
                    "capEquipNumber =" + capEquipNumber + ", " +
                    "bunitowner = " + buOwner + ", " +
                    "internal_cal_contact = " + InternalCalContact + " " +
                    "where " +
                    "ID = '" + g.iID + "'");

                cmd.Parameters.Add(ItemType);
                cmd.Parameters.Add(SN);
                cmd.Parameters.Add(Manufacturer);
                cmd.Parameters.Add(Description);
                cmd.Parameters.Add(ExtendedDescription);
                cmd.Parameters.Add(Model);
                cmd.Parameters.Add(ItemSize);
                cmd.Parameters.Add(DateNew);
                cmd.Parameters.Add(Status);
                cmd.Parameters.Add(Outsource);
                cmd.Parameters.Add(referenceStandardExists);
                cmd.Parameters.Add(buOwner);
                cmd.Parameters.Add(procedure);
                cmd.Parameters.Add(comments);
                cmd.Parameters.Add(InternalCalContact);
                cmd.Parameters.Add(capEquipNumber);

                cmd.Connection = cnxn;
                cnxn.Open();
                int rowsReturned = cmd.ExecuteNonQuery();
                cnxn.Close();
                g.internalCalContact = 0;

            }
            cmd.Parameters.Clear();

            f30b_Edit_Calibration_Parameters fb = new f30b_Edit_Calibration_Parameters();
            fb.ShowDialog();
            Close();

        }

        private void bExit_Click(object sender, EventArgs e)
        {
            f30b_Edit_Calibration_Parameters fb = new f30b_Edit_Calibration_Parameters();
            fb.ShowDialog();
            Close();
        }


        private void cbInclude_CheckedChanged(object sender, EventArgs e)
        {
            if (cbInclude.Checked == true)
            {
                cbInclude.Text = "Yes";
            }
            else
            {
                cbInclude.Text = "No";
            }
        }

        private void cbRefStandard_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRefStandard.Checked == true)
            {
                cbRefStandard.Text = "Yes";
            }
            else
            {
                cbRefStandard.Text = "No";
            }
        }

        private void dtpDateNew_ValueChanged(object sender, EventArgs e)
        {
            DateNew.Value = dtpDateNew.Text;
        }

        private void bSelectICC_Click(object sender, EventArgs e)
        {
            f21_Select_Employees F21 = new f21_Select_Employees();
            F21.ShowDialog();
        }

        private void f30_Edit_Items_Activated(object sender, EventArgs e)
        {
            SqlConnection cnxn2 = new SqlConnection
                           (g.dbDashserver);
            SqlCommand cmd2 = new SqlCommand
             (" select name from view_employees where " +
            " badgeid = " + g.internalCalContact + " ", cnxn2);
            cnxn2.Open();
            object o = cmd2.ExecuteScalar();
            if (g.internalCalContact == 0)
            {
                tbInternalContact.Text = "";
            }
            else
            {
                tbInternalContact.Text = o.ToString().Trim();
            }
            cnxn2.Close();
        }

        private void cbddStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbddStatus.Text == "ARCHIVE")
            {
                cnxn = new SqlConnection(g.db);

                cmd = new SqlCommand
                    ("delete from itemuser " +
                    "where i_item = '" + g.iID + "'", cnxn);

                cnxn.Open();
                int rowsReturned = cmd.ExecuteNonQuery();
                cnxn.Close();

                cnxn = new SqlConnection(g.db);

                cmd = new SqlCommand
                    ("delete from itemlocation " +
                    "where il_item = '" + g.iID + "'", cnxn);

                cnxn.Open();
                rowsReturned = cmd.ExecuteNonQuery();
                cnxn.Close();
            }
        }

    }
}