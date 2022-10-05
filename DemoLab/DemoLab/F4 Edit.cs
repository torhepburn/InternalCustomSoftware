using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DemoLab
{
    public partial class F4_Edit : Form
    {
        public F4_Edit()
        {
            InitializeComponent();
        }

        private void bEnterData_Click(object sender, EventArgs e)
        {
            //string a;

            //SqlParameter ID = new SqlParameter("@ID", SqlDbType.NChar, 10);
            //ID.Value = tbID.Text.ToString().Trim();

            //a = tbDiameter.Text.Trim();
            //SqlParameter Diameter = new SqlParameter("@Diameter", SqlDbType.Float);
            //if (a != "0" && a != null && a != "")
            //{
            //    bool isNum;
            //    isNum = float.TryParse(tbDiameter.Text, out FloatValueTransferVariable);
            //    Diameter.Value = FloatValueTransferVariable;
            //}
            //else
            //{
            //    Diameter.Value = DBNull.Value;
            //}

            //a = tbDiameter_M.Text.Trim();
            //SqlParameter Diameter_M = new SqlParameter("@Diameter_M", SqlDbType.Float);
            //if (a != "0" && a != null && a != "")
            //{
            //    bool isNum;
            //    isNum = float.TryParse(tbDiameter_M.Text, out FloatValueTransferVariable);
            //    Diameter_M.Value = FloatValueTransferVariable;
            //}
            //else
            //{
            //    Diameter_M.Value = DBNull.Value;
            //}

            //a = tbShankDiameter.Text.Trim();
            //SqlParameter ShankDiameter = new SqlParameter("@ShankDiameter", SqlDbType.Float);
            //if (a != "0" && a != null && a != "")
            //{
            //    bool isNum;
            //    isNum = float.TryParse(tbShankDiameter.Text, out FloatValueTransferVariable);
            //    ShankDiameter.Value = FloatValueTransferVariable;
            //}
            //else
            //{
            //    ShankDiameter.Value = DBNull.Value;
            //}

            //a = tbShankDiameter_M.Text.Trim();
            //SqlParameter ShankDiameter_M = new SqlParameter("@ShankDiameter_M", SqlDbType.Float);
            //if (a != "0" && a != null && a != "")
            //{
            //    bool isNum;
            //    isNum = float.TryParse(tbShankDiameter_M.Text, out FloatValueTransferVariable);
            //    ShankDiameter_M.Value = FloatValueTransferVariable;
            //}
            //else
            //{
            //    ShankDiameter_M.Value = DBNull.Value;
            //}

            //a = tbReliefDiameter.Text.Trim();
            //SqlParameter ReliefDiameter = new SqlParameter("@ReleifDiameter", SqlDbType.Float);
            //if (a != "0" && a != null && a != "")
            //{
            //    bool isNum;
            //    isNum = float.TryParse(tbReliefDiameter.Text, out FloatValueTransferVariable);
            //    ReliefDiameter.Value = FloatValueTransferVariable;
            //}
            //else
            //{
            //    ReliefDiameter.Value = DBNull.Value;
            //}

            //a = tbReliefDiameter_M.Text.Trim();
            //SqlParameter ReliefDiameter_M = new SqlParameter("@ReleifDiameter_M", SqlDbType.Float);
            //if (a != "0" && a != null && a != "")
            //{
            //    bool isNum;
            //    isNum = float.TryParse(tbReliefDiameter_M.Text, out FloatValueTransferVariable);
            //    ReliefDiameter_M.Value = FloatValueTransferVariable;
            //}
            //else
            //{
            //    ReliefDiameter_M.Value = DBNull.Value;
            //}

            //a = tbFlatDiameter.Text.Trim();
            //SqlParameter FlatDiameter = new SqlParameter("@FlatDiameter", SqlDbType.Float);
            //if (a != "0" && a != null && a != "")
            //{
            //    bool isNum;
            //    isNum = float.TryParse(tbFlatDiameter.Text, out FloatValueTransferVariable);
            //    FlatDiameter.Value = FloatValueTransferVariable;
            //}
            //else
            //{
            //    FlatDiameter.Value = DBNull.Value;
            //}

            //a = tbFlatDiameter_M.Text.Trim();
            //SqlParameter FlatDiameter_M = new SqlParameter("@FlatDiameter_M", SqlDbType.Float);
            //if (a != "0" && a != null && a != "")
            //{
            //    bool isNum;
            //    isNum = float.TryParse(tbFlatDiameter_M.Text, out FloatValueTransferVariable);
            //    FlatDiameter_M.Value = FloatValueTransferVariable;
            //}
            //else
            //{
            //    FlatDiameter_M.Value = DBNull.Value;
            //}

            //a = tbInnerDiameter.Text.Trim();
            //SqlParameter InnerDiameter = new SqlParameter("@InnerDiameter", SqlDbType.Float);
            //if (a != "0" & a != null && a != "")
            //{
            //    bool isNum;
            //    isNum = float.TryParse(tbInnerDiameter.Text, out FloatValueTransferVariable);
            //    InnerDiameter.Value = FloatValueTransferVariable;
            //}
            //else
            //{
            //    InnerDiameter.Value = DBNull.Value;
            //}

            //a = tbInnerDiameter_M.Text.Trim();
            //SqlParameter InnerDiameter_M = new SqlParameter("@InnerDiameter_M", SqlDbType.Float);
            //if (a != "0" & a != null && a != "")
            //{
            //    bool isNum;
            //    isNum = float.TryParse(tbInnerDiameter_M.Text, out FloatValueTransferVariable);
            //    InnerDiameter_M.Value = FloatValueTransferVariable;
            //}
            //else
            //{
            //    InnerDiameter_M.Value = DBNull.Value;
            //}

            //a = tbUsableLength.Text.Trim();
            //SqlParameter UsableLength = new SqlParameter("@UsableLength", SqlDbType.Float);
            //if (a != "0" && a != null && a != "")
            //{
            //    bool isNum;
            //    isNum = float.TryParse(tbUsableLength.Text, out FloatValueTransferVariable);
            //    UsableLength.Value = FloatValueTransferVariable;
            //}
            //else
            //{
            //    UsableLength.Value = DBNull.Value;
            //}

            //a = tbUsableLength_M.Text.Trim();
            //SqlParameter UsableLength_M = new SqlParameter("@UsableLength_M", SqlDbType.Float);
            //if (a != "0" && a != null && a != "")
            //{
            //    bool isNum;
            //    isNum = float.TryParse(tbUsableLength_M.Text, out FloatValueTransferVariable);
            //    UsableLength_M.Value = FloatValueTransferVariable;
            //}
            //else
            //{
            //    UsableLength_M.Value = DBNull.Value;
            //}

            //a = tbDiamondLength.Text.Trim();
            //SqlParameter DiamondLength = new SqlParameter("@DiamondLength", SqlDbType.Float);
            //if (a != "0" && a != null && a != "")
            //{
            //    bool isNum;
            //    isNum = float.TryParse(tbDiamondLength.Text, out FloatValueTransferVariable);
            //    DiamondLength.Value = FloatValueTransferVariable;
            //}
            //else
            //{
            //    DiamondLength.Value = DBNull.Value;
            //}

            //a = tbDiamondLength_M.Text.Trim();
            //SqlParameter DiamondLength_M = new SqlParameter("@DiamondLength_M", SqlDbType.Float);
            //if (a != "0" && a != null && a != "")
            //{
            //    bool isNum;
            //    isNum = float.TryParse(tbDiamondLength_M.Text, out FloatValueTransferVariable);
            //    DiamondLength_M.Value = FloatValueTransferVariable;
            //}
            //else
            //{
            //    DiamondLength_M.Value = DBNull.Value;
            //}

            //SqlParameter Grit = new SqlParameter("@Grit", SqlDbType.NChar, 10);
            //Grit.Value = tbGrit.Text.ToString().Trim();

            //a = tbColletLength.Text.Trim();
            //SqlParameter ColletLength = new SqlParameter("@ColletLength", SqlDbType.Float);
            //if (a != "0" && a != null && a != "")
            //{
            //    bool isNum;
            //    isNum = float.TryParse(tbColletLength.Text, out FloatValueTransferVariable);
            //    ColletLength.Value = FloatValueTransferVariable;
            //}
            //else
            //{
            //    ColletLength.Value = DBNull.Value;
            //}

            //a = tbColletLength_M.Text.Trim();
            //SqlParameter ColletLength_M = new SqlParameter("@ColletLength_M", SqlDbType.Float);
            //if (a != "0" && a != null && a != "")
            //{
            //    bool isNum;
            //    isNum = float.TryParse(tbColletLength_M.Text, out FloatValueTransferVariable);
            //    ColletLength_M.Value = FloatValueTransferVariable;
            //}
            //else
            //{
            //    ColletLength_M.Value = DBNull.Value;
            //}

            //a = tbColletNutSize.Text.Trim();
            //SqlParameter ColletNutSize = new SqlParameter("@ColletNutSize", SqlDbType.Float);
            //if (a != "0" && a != null && a != "")
            //{
            //    bool isNum;
            //    isNum = float.TryParse(tbColletNutSize.Text, out FloatValueTransferVariable);
            //    ColletNutSize.Value = FloatValueTransferVariable;
            //}
            //else
            //{
            //    ColletNutSize.Value = DBNull.Value;
            //}

            //a = tbNoseRadius.Text.Trim();
            //SqlParameter NoseRadius = new SqlParameter("@NoseRadius", SqlDbType.Float);
            //if (a != "0" && a != null && a != "")
            //{
            //    bool isNum;
            //    isNum = float.TryParse(tbNoseRadius.Text, out FloatValueTransferVariable);
            //    NoseRadius.Value = FloatValueTransferVariable;
            //}
            //else
            //{
            //    NoseRadius.Value = DBNull.Value;
            //}

            //a = tbAngle.Text.Trim();
            //SqlParameter Angle = new SqlParameter("@Angle", SqlDbType.Float);
            //if (a != "0" && a != null && a != "")
            //{
            //    bool isNum;
            //    isNum = float.TryParse(tbAngle.Text, out FloatValueTransferVariable);
            //    Angle.Value = FloatValueTransferVariable;
            //}
            //else
            //{
            //    Angle.Value = DBNull.Value;
            //}

            //SqlParameter MountType = new SqlParameter("@MountType", SqlDbType.NChar, 50);
            //MountType.Value = tbMountingType.Text.ToString().Trim();
            //SqlParameter ToolHolder = new SqlParameter("@ToolHolder", SqlDbType.NChar, 50);
            //ToolHolder.Value = tbToolHolderType.Text.ToString().Trim();
            //SqlParameter ToolNumber = new SqlParameter("@ToolNumber", SqlDbType.NChar, 20);
            //ToolNumber.Value = tbToolNumber.Text.ToString().Trim();
            //SqlParameter RefReorderNumber = new SqlParameter("@RefReorderNumber", SqlDbType.NChar, 30);
            //RefReorderNumber.Value = tbReorderNumber.Text.ToString().Trim();
            //SqlParameter OldSN = new SqlParameter("@OldSN", SqlDbType.NChar, 50);
            //OldSN.Value = tbOldSN.Text.ToString().Trim();
            //SqlParameter Notes = new SqlParameter("@Notes", SqlDbType.Text);
            //Notes.Value = tbNotes.Text.ToString().Trim();
            //SqlParameter Location = new SqlParameter("@Location", SqlDbType.NChar, 20);
            //Location.Value = tbLocation.Text.ToString().Trim();
            //SqlParameter Supplier = new SqlParameter("@Supplier", SqlDbType.NChar, 50);
            //Supplier.Value = tbSupplier.Text.ToString().Trim();

            //SqlParameter Status = new SqlParameter("@Status", SqlDbType.NChar, 1);
            //if (cbActive.Checked == true)
            //{
            //    Status.Value = "A";
            //}
            //else
            //{
            //    Status.Value = "I";
            //}

            //SqlParameter PlatedBonded = new SqlParameter("@PlatedBonded", SqlDbType.NChar, 1);
            //if (rbPlated.Checked == true)
            //{
            //    PlatedBonded.Value = "P";
            //}

            //if (rbBonded.Checked == true)
            //{
            //    PlatedBonded.Value = "B";
            //}

            //if (!rbPlated.Checked && !rbBonded.Checked)
            //{
            //    PlatedBonded.Value = DBNull.Value;
            //}


            //if (g.task == "Add")
            //{
            //    DateTime date = DateTime.Now;
            //    cnxn = new SqlConnection(g.db);
            //    cmd = new SqlCommand("Insert into equipment (" +
            //        "id," +
            //        "[description]," +
            //        "desc2," +
            //        "sn," +
            //        "manuf," +
            //        "model," +
            //        "size," +
            //        "date_new," +
            //        "purchcost," +
            //        "bunitowner," +
            //        "capEquipNumber," +
            //        "outsource," +
            //        "refstd," +
            //        "type," +
            //        "status," +
            //        "tnom," +
            //        "hnom," +
            //        "pnom," +
            //        "[procedure]," +
            //        "comments, " +
            //        "internal_cal_contact)" +
            //        " values (" +
            //        "'" + g.iID +
            //        "'," + Description +
            //        "," + ExtendedDescription +
            //        "," + SN +
            //        "," + Manufacturer +
            //        "," + Model +
            //        "," + ItemSize +
            //        "," + DateNew +
            //        "," + cost +
            //        "," + buOwner +
            //        "," + capEquipNumber +
            //        "," + Outsource +
            //        "," + referenceStandardExists +
            //        "," + ItemType +
            //        "," + Status +
            //        "," + temperature +
            //        "," + humidity +
            //        "," + pressure +
            //        "," + procedure +
            //        "," + comments +
            //        "," + InternalCalContact + ") " +
            //        "Insert into Calibrationdata " +
            //        "(Item, chg_date, history1, CurrentHistory) values ('" +
            //        g.iID + "','" + date + "','Initial Entry', 'C')");
            //    cmd.Parameters.Add(ItemType);
            //    cmd.Parameters.Add(SN);
            //    cmd.Parameters.Add(Manufacturer);
            //    cmd.Parameters.Add(Description);
            //    cmd.Parameters.Add(ExtendedDescription);
            //    cmd.Parameters.Add(Model);
            //    cmd.Parameters.Add(ItemSize);
            //    cmd.Parameters.Add(DateNew);
            //    cmd.Parameters.Add(Status);
            //    cmd.Parameters.Add(Outsource);
            //    cmd.Parameters.Add(referenceStandardExists);
            //    cmd.Parameters.Add(buOwner);
            //    cmd.Parameters.Add(procedure);
            //    cmd.Parameters.Add(comments);
            //    cmd.Parameters.Add(InternalCalContact);
            //    cmd.Parameters.Add(capEquipNumber);

            //    cmd.Connection = cnxn;
            //    cnxn.Open();
            //    try
            //    {
            //        int rowsReturned = cmd.ExecuteNonQuery();
            //    }
            //    catch (SqlException ex)
            //    {
            //        MessageBox.Show(ex.ToString());
            //    }
            //    cnxn.Close();
            //    g.internalCalContact = 0;

            //    f17a_Select_Bench f7 = new f17a_Select_Bench();
            //    f7.Show();
            //}
            //else
            //{
            //cnxn = new SqlConnection(g.db);
            //cmd = new SqlCommand("Update tools set " +
            //    "tooltype = " + ToolType + ", " +
            //    "Diameter = " + Diameter + ", " +
            //    "Diameter_M = " + Diameter_M + ", " +
            //    "ShankDiameter = " + ShankDiameter + ", " +
            //    "ShankDiameter_M = " + ShankDiameter_M + ", " +
            //    "ReliefDiameter = " + ReliefDiameter + ", " +
            //    "ReliefDiameter_M = " + ReliefDiameter_M + ", " +
            //    "FlatDiameter = " + FlatDiameter + ", " +
            //    "FlatDiameter_M = " + FlatDiameter_M + ", " +
            //    "InnerDiameter = " + InnerDiameter + ", " +
            //    "InnerDiameter_M = " + InnerDiameter_M + ", " +
            //    "UsableLength = " + UsableLength + ", " +
            //    "UsableLength_M = " + UsableLength_M + ", " +
            //    "DiamondLength = " + DiamondLength + ", " +
            //    "DiamondLength_M = " + DiamondLength_M + ", " +
            //    "Grit = " + Grit + ", " +
            //    "ColletLength = " + ColletLength + ", " +
            //    "ColletLength_M = " + ColletLength_M + ", " +
            //    "ColletNutSize = " + ColletNutSize + ", " +
            //    "NoseRadius = " + NoseRadius + ", " +
            //    "Angle =" + Angle + ", " +
            //    "MountType =" + MountType + ", " +
            //    "ToolHolderType =" + ToolHolder + ", " +
            //    "PlatedBonded =" + PlatedBonded + ", " +
            //    "ToolNumber =" + ToolNumber + ", " +
            //    "RefReorderNumber = " + RefReorderNumber + ", " +
            //    "Status =" + Status + ", " +
            //    "OldSN =" + OldSN + ", " +
            //    "Notes =" + Notes + ", " +
            //    "Location =" + Location + ", " +
            //    "Supplier =" + Supplier + " " +
            //    "where " +
            //    "SN = '" + g.SN + "'");

            //cmd.Parameters.Add(ToolType);
            //cmd.Parameters.Add(Diameter);
            //cmd.Parameters.Add(ShankDiameter);
            //cmd.Parameters.Add(ReliefDiameter);
            //cmd.Parameters.Add(FlatDiameter);
            //cmd.Parameters.Add(InnerDiameter);
            //cmd.Parameters.Add(UsableLength);
            //cmd.Parameters.Add(DiamondLength);
            //cmd.Parameters.Add(Grit);
            //cmd.Parameters.Add(ColletLength);
            //cmd.Parameters.Add(ColletNutSize);
            //cmd.Parameters.Add(NoseRadius);
            //cmd.Parameters.Add(Angle);
            //cmd.Parameters.Add(MountType);
            //cmd.Parameters.Add(ToolHolder);
            //cmd.Parameters.Add(PlatedBonded);
            //cmd.Parameters.Add(ToolNumber);
            //cmd.Parameters.Add(RefReorderNumber);
            //cmd.Parameters.Add(Status);
            //cmd.Parameters.Add(OldSN);
            //cmd.Parameters.Add(Notes);
            //cmd.Parameters.Add(Location);
            //cmd.Parameters.Add(Supplier);
            //cmd.Parameters.Add(Diameter_M);
            //cmd.Parameters.Add(ShankDiameter_M);
            //cmd.Parameters.Add(ReliefDiameter_M);
            //cmd.Parameters.Add(FlatDiameter_M);
            //cmd.Parameters.Add(InnerDiameter_M);
            //cmd.Parameters.Add(UsableLength_M);
            //cmd.Parameters.Add(DiamondLength_M);
            //cmd.Parameters.Add(ColletLength_M);

            //cmd.Connection = cnxn;
            //cnxn.Open();
            //int rowsReturned = cmd.ExecuteNonQuery();
            //cnxn.Close();
            ////g.internalCalContact = 0;

            ////}
            //cmd.Parameters.Clear();

            //////f30b_Edit_Calibration_Parameters fb = new f30b_Edit_Calibration_Parameters();
            //////fb.Show();
            //Close();
         
        }
    }
}
