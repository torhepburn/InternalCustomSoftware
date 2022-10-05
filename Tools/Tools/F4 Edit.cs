using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Tools
{
    public partial class F4_Edit : Form
    {
        SqlConnection cnxn;
        SqlCommand cmd;
        private float FloatValueTransferVariable;
        private int inserted;
        
        public F4_Edit()
        {
            InitializeComponent();
        }

        private void F4_Edit_Load(object sender, EventArgs e)
        {
            
                tbSN.Text = g.SN;

                cnxn = new SqlConnection(g.db);
                SqlDataAdapter da = new SqlDataAdapter
                    ("select distinct tooltype from tools " +
                     //"where program = '" + g.program + "' " +
                     "order by tooltype", cnxn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbddType.DataSource = dt;
                cbddType.DisplayMember = "ToolType";

                if (g.task == "Edit" | g.task == "View")
                {
                    cnxn = new SqlConnection(g.db);
                    SqlCommand cmd = new SqlCommand
                   ("Select * from tools where sn = '" +
                    g.SN + "'");
                    cmd.Connection = cnxn;
                    cnxn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {
                        //need to leave spaces on string to match cbdd.text plus
                        //can only put in text which is in dd list
                        if (!dr.IsDBNull(1)) { cbddType.Text = dr.GetString(1); }
                        if (!dr.IsDBNull(2)) { tbSN.Text = dr.GetString(2); }
                        if (!dr.IsDBNull(3)) { tbDiameter.Text = dr.GetDecimal(3).ToString(); }
                        if (!dr.IsDBNull(4)) { tbDiameter_M.Text = dr.GetDecimal(4).ToString(); }
                        if (!dr.IsDBNull(5)) { tbShankDiameter.Text = dr.GetDecimal(5).ToString(); }
                        if (!dr.IsDBNull(6)) { tbShankDiameter_M.Text = dr.GetDecimal(6).ToString(); }
                        if (!dr.IsDBNull(7)) { tbReliefDiameter.Text = dr.GetDecimal(7).ToString(); }
                        if (!dr.IsDBNull(8)) { tbReliefDiameter_M.Text = dr.GetDecimal(8).ToString(); }
                        if (!dr.IsDBNull(9)) { tbFlatDiameter.Text = dr.GetDecimal(9).ToString(); }
                        if (!dr.IsDBNull(10)) { tbFlatDiameter_M.Text = dr.GetDecimal(10).ToString(); }
                        if (!dr.IsDBNull(11)) { tbInnerDiameter.Text = dr.GetDecimal(11).ToString(); }
                        if (!dr.IsDBNull(12)) { tbInnerDiameter_M.Text = dr.GetDecimal(12).ToString(); }
                        if (!dr.IsDBNull(13)) { tbUsableLength.Text = dr.GetDecimal(13).ToString(); }
                        if (!dr.IsDBNull(14)) { tbUsableLength_M.Text = dr.GetDecimal(14).ToString(); }
                        if (!dr.IsDBNull(15)) { tbDiamondLength.Text = dr.GetDecimal(15).ToString(); }
                        if (!dr.IsDBNull(16)) { tbDiamondLength_M.Text = dr.GetDecimal(16).ToString(); }
                        if (!dr.IsDBNull(17)) { tbGrit.Text = dr.GetString(17).ToString(); }
                        if (!dr.IsDBNull(18)) { tbColletLength.Text = dr.GetDecimal(18).ToString(); }
                        if (!dr.IsDBNull(19)) { tbColletLength_M.Text = dr.GetDecimal(19).ToString(); }
                        if (!dr.IsDBNull(20)) { tbColletNutSize.Text = dr.GetDecimal(20).ToString(); }
                        if (!dr.IsDBNull(21)) { tbNoseRadius.Text = dr.GetDecimal(21).ToString(); }
                        if (!dr.IsDBNull(22)) { tbAngle.Text = dr.GetDecimal(22).ToString(); }
                        if (!dr.IsDBNull(23)) { tbMountingType.Text = dr.GetString(23).Trim(); }
                        if (!dr.IsDBNull(24)) { tbToolHolderType.Text = dr.GetString(24).Trim(); }
                        if (!dr.IsDBNull(25))
                        {
                            string pb = dr.GetString(25).Trim();
                            if (pb == "P")
                            {
                                rbPlated.Checked = true;
                            }
                            if (pb == "B")
                            {
                                rbBonded.Checked = true;
                            }
                        }
                        if (!dr.IsDBNull(26)) { tbToolNumber.Text = dr.GetString(26).Trim(); }
                        if (!dr.IsDBNull(27)) { tbReorderNumber.Text = dr.GetString(27).Trim(); }
                        if (!dr.IsDBNull(28))
                        {
                            string status = dr.GetString(28).Trim();
                            if (status == "A")
                            {
                                cbActive.Checked = true;
                            }
                        }
                        if (!dr.IsDBNull(29)) { tbOldSN.Text = dr.GetString(29).Trim(); }
                        if (!dr.IsDBNull(30)) { tbNotes.Text = dr.GetString(30).Trim(); }
                        if (!dr.IsDBNull(31)) { tbLocation.Text = dr.GetString(31).Trim(); }
                        if (!dr.IsDBNull(32)) { tbSupplier.Text = dr.GetString(32).Trim(); }
                    }

                    if (g.task == "View")
                    {
                        bSave.Visible = false;

                    }
                
            }
            //else    //Add
            //{
            //    tbSN.ReadOnly = false;
            //    LtbSN.Text = "Enter item SN:";
            //    tbSN.Location = new Point(259, 40);

            //    if (g.program == "FX" | g.program == "VC")
            //    {
            //        cbddType.Visible = false;
            //        tbMountingType.Visible = false;
            //    }

                

            //}
        
        }

        private void cbddType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bSave_Click(object sender, EventArgs e)
        {
            string a;

            SqlParameter ToolType = new SqlParameter("@ToolType", SqlDbType.NVarChar, 20);
            ToolType.Value = cbddType.Text.ToString().Trim();
            
            a = tbDiameter.Text.Trim();
            SqlParameter Diameter = new SqlParameter("@Diameter", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbDiameter.Text, out FloatValueTransferVariable);
                Diameter.Value = FloatValueTransferVariable;
            }
            else
            {
                Diameter.Value = DBNull.Value;
            }

            a = tbDiameter_M.Text.Trim();
            SqlParameter Diameter_M = new SqlParameter("@Diameter_M", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbDiameter_M.Text, out FloatValueTransferVariable);
                Diameter_M.Value = FloatValueTransferVariable;
            }
            else
            {
                Diameter_M.Value = DBNull.Value;
            }

            a = tbShankDiameter.Text.Trim();
            SqlParameter ShankDiameter = new SqlParameter("@ShankDiameter", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbShankDiameter.Text, out FloatValueTransferVariable);
                ShankDiameter.Value = FloatValueTransferVariable;
            }
            else
            {
                ShankDiameter.Value = DBNull.Value;
            }

            a = tbShankDiameter_M.Text.Trim();
            SqlParameter ShankDiameter_M = new SqlParameter("@ShankDiameter_M", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbShankDiameter_M.Text, out FloatValueTransferVariable);
                ShankDiameter_M.Value = FloatValueTransferVariable;
            }
            else
            {
                ShankDiameter_M.Value = DBNull.Value;
            }

            a = tbReliefDiameter.Text.Trim();
            SqlParameter ReliefDiameter = new SqlParameter("@ReleifDiameter", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbReliefDiameter.Text, out FloatValueTransferVariable);
                ReliefDiameter.Value = FloatValueTransferVariable;
            }
            else
            {
                ReliefDiameter.Value = DBNull.Value;
            }

            a = tbReliefDiameter_M.Text.Trim();
            SqlParameter ReliefDiameter_M = new SqlParameter("@ReleifDiameter_M", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbReliefDiameter_M.Text, out FloatValueTransferVariable);
                ReliefDiameter_M.Value = FloatValueTransferVariable;
            }
            else
            {
                ReliefDiameter_M.Value = DBNull.Value;
            }

            a = tbFlatDiameter.Text.Trim();
            SqlParameter FlatDiameter = new SqlParameter("@FlatDiameter", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbFlatDiameter.Text, out FloatValueTransferVariable);
                FlatDiameter.Value = FloatValueTransferVariable;
            }
            else
            {
                FlatDiameter.Value = DBNull.Value;
            }

            a = tbFlatDiameter_M.Text.Trim();
            SqlParameter FlatDiameter_M = new SqlParameter("@FlatDiameter_M", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbFlatDiameter_M.Text, out FloatValueTransferVariable);
                FlatDiameter_M.Value = FloatValueTransferVariable;
            }
            else
            {
                FlatDiameter_M.Value = DBNull.Value;
            }

            a = tbInnerDiameter.Text.Trim();
            SqlParameter InnerDiameter = new SqlParameter("@InnerDiameter", SqlDbType.Float);
            if (a != "0" & a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbInnerDiameter.Text, out FloatValueTransferVariable);
                InnerDiameter.Value = FloatValueTransferVariable;
            }
            else
            {
                InnerDiameter.Value = DBNull.Value;
            }

            a = tbInnerDiameter_M.Text.Trim();
            SqlParameter InnerDiameter_M = new SqlParameter("@InnerDiameter_M", SqlDbType.Float);
            if (a != "0" & a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbInnerDiameter_M.Text, out FloatValueTransferVariable);
                InnerDiameter_M.Value = FloatValueTransferVariable;
            }
            else
            {
                InnerDiameter_M.Value = DBNull.Value;
            }

            a = tbUsableLength.Text.Trim();
            SqlParameter UsableLength = new SqlParameter("@UsableLength", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbUsableLength.Text, out FloatValueTransferVariable);
                UsableLength.Value = FloatValueTransferVariable;
            }
            else
            {
                UsableLength.Value = DBNull.Value;
            }

            a = tbUsableLength_M.Text.Trim();
            SqlParameter UsableLength_M = new SqlParameter("@UsableLength_M", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbUsableLength_M.Text, out FloatValueTransferVariable);
                UsableLength_M.Value = FloatValueTransferVariable;
            }
            else
            {
                UsableLength_M.Value = DBNull.Value;
            }

            a = tbDiamondLength.Text.Trim();
            SqlParameter DiamondLength = new SqlParameter("@DiamondLength", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbDiamondLength.Text, out FloatValueTransferVariable);
                DiamondLength.Value = FloatValueTransferVariable;
            }
            else
            {
                DiamondLength.Value = DBNull.Value;
            }

            a = tbDiamondLength_M.Text.Trim();
            SqlParameter DiamondLength_M = new SqlParameter("@DiamondLength_M", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbDiamondLength_M.Text, out FloatValueTransferVariable);
                DiamondLength_M.Value = FloatValueTransferVariable;
            }
            else
            {
                DiamondLength_M.Value = DBNull.Value;
            }

            SqlParameter Grit = new SqlParameter("@Grit", SqlDbType.NChar, 10);
            Grit.Value = tbGrit.Text.ToString().Trim();

            a = tbColletLength.Text.Trim();
            SqlParameter ColletLength = new SqlParameter("@ColletLength", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbColletLength.Text, out FloatValueTransferVariable);
                ColletLength.Value = FloatValueTransferVariable;
            }
            else
            {
                ColletLength.Value = DBNull.Value;
            }

            a = tbColletLength_M.Text.Trim();
            SqlParameter ColletLength_M = new SqlParameter("@ColletLength_M", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbColletLength_M.Text, out FloatValueTransferVariable);
                ColletLength_M.Value = FloatValueTransferVariable;
            }
            else
            {
                ColletLength_M.Value = DBNull.Value;
            }

            a = tbColletNutSize.Text.Trim();
            SqlParameter ColletNutSize = new SqlParameter("@ColletNutSize", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbColletNutSize.Text, out FloatValueTransferVariable);
                ColletNutSize.Value = FloatValueTransferVariable;
            }
            else
            {
                ColletNutSize.Value = DBNull.Value;
            }

            a = tbNoseRadius.Text.Trim();
            SqlParameter NoseRadius = new SqlParameter("@NoseRadius", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbNoseRadius.Text, out FloatValueTransferVariable);
                NoseRadius.Value = FloatValueTransferVariable;
            }
            else
            {
                NoseRadius.Value = DBNull.Value;
            }

            a = tbAngle.Text.Trim();
            SqlParameter Angle = new SqlParameter("@Angle", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbAngle.Text, out FloatValueTransferVariable);
                Angle.Value = FloatValueTransferVariable;
            }
            else
            {
                Angle.Value = DBNull.Value;
            }

            SqlParameter MountType = new SqlParameter("@MountType", SqlDbType.NChar, 50);
            MountType.Value = tbMountingType.Text.ToString().Trim();
            SqlParameter ToolHolder = new SqlParameter("@ToolHolder", SqlDbType.NChar, 50);
            ToolHolder.Value = tbToolHolderType.Text.ToString().Trim();
            SqlParameter ToolNumber = new SqlParameter("@ToolNumber", SqlDbType.NChar, 20);
            ToolNumber.Value = tbToolNumber.Text.ToString().Trim();
            SqlParameter RefReorderNumber = new SqlParameter("@RefReorderNumber", SqlDbType.NChar, 30);
            RefReorderNumber.Value = tbReorderNumber.Text.ToString().Trim();
            SqlParameter OldSN = new SqlParameter("@OldSN", SqlDbType.NChar, 50);
            OldSN.Value = tbOldSN.Text.ToString().Trim();
            SqlParameter Notes = new SqlParameter("@Notes", SqlDbType.Text);
            Notes.Value = tbNotes.Text.ToString().Trim();
            SqlParameter Location = new SqlParameter("@Location", SqlDbType.NChar, 20);
            Location.Value = tbLocation.Text.ToString().Trim();
            SqlParameter Supplier = new SqlParameter("@Supplier", SqlDbType.NChar, 50);
            Supplier.Value = tbSupplier.Text.ToString().Trim();

            SqlParameter Status = new SqlParameter("@Status", SqlDbType.NChar, 1);
            if (cbActive.Checked == true)
            {
                Status.Value = "A";
            }
            else
            {
                Status.Value = "I";
            }

            SqlParameter PlatedBonded = new SqlParameter("@PlatedBonded", SqlDbType.NChar, 1);
            if (rbPlated.Checked == true)
            {
                PlatedBonded.Value = "P";
            }
            
            if (rbBonded.Checked == true)
            {
                PlatedBonded.Value = "B";
            }
            
            if (!rbPlated.Checked  && !rbBonded.Checked)
            {
                PlatedBonded.Value = DBNull.Value; 
            }
            

            if (g.task == "Add")
            {
                cnxn = new SqlConnection(g.db);
                cmd = new SqlCommand("Insert into tools (" +
                "tooltype, " +
                "sn, " +
                "Diameter, " +
                "Diameter_M, " +
                "ShankDiameter, " +
                "ShankDiameter_M, " +
                "ReliefDiameter, " +
                "ReliefDiameter_M, " +
                "FlatDiameter, " +
                "FlatDiameter_M, " +
                "InnerDiameter, " +
                "InnerDiameter_M, " +
                "UsableLength, " +
                "UsableLength_M, " +
                "DiamondLength, " +
                "DiamondLength_M, " +
                "Grit, " +
                "ColletLength, " +
                "ColletLength_M, " +
                "ColletNutSize, " +
                "NoseRadius, " +
                "Angle, " +
                "MountType, " +
                "ToolHolderType, " +
                "PlatedBonded, " +
                "ToolNumber, " +
                "RefReorderNumber, " +
                "Status, " +
                "OldSN, " +
                "Notes, " +
                "Location, " +
                "Supplier, " +
                "Program) " +
                "values ( " +
                ToolType + ", '" +
                g.SN + "', " +
                Diameter + ", " +
                Diameter_M + ", " +
                ShankDiameter + ", " +
                ShankDiameter_M + ", " +
                ReliefDiameter + ", " +
                ReliefDiameter_M + ", " +
                FlatDiameter + ", " +
                FlatDiameter_M + ", " +
                InnerDiameter + ", " +
                InnerDiameter_M + ", " +
                UsableLength + ", " +
                UsableLength_M + ", " +
                DiamondLength + ", " +
                DiamondLength_M + ", " +
                Grit + ", " +
                ColletLength + ", " +
                ColletLength_M + ", " +
                ColletNutSize + ", " +
                NoseRadius + ", " +
                Angle + ", " +
                MountType + ", " +
                ToolHolder + ", " +
                PlatedBonded + ", " +
                ToolNumber + ", " +
                RefReorderNumber + ", " +
                Status + ", " +
                OldSN + ", " +
                Notes + ", " +
                Location + ", " +
                Supplier + ",'" +
                g.program + "' )"); 
                
            cmd.Parameters.Add(ToolType);
            cmd.Parameters.Add(Diameter);
            cmd.Parameters.Add(ShankDiameter);
            cmd.Parameters.Add(ReliefDiameter);
            cmd.Parameters.Add(FlatDiameter);
            cmd.Parameters.Add(InnerDiameter);
            cmd.Parameters.Add(UsableLength);
            cmd.Parameters.Add(DiamondLength);
            cmd.Parameters.Add(Grit);
            cmd.Parameters.Add(ColletLength);
            cmd.Parameters.Add(ColletNutSize);
            cmd.Parameters.Add(NoseRadius);
            cmd.Parameters.Add(Angle);
            cmd.Parameters.Add(MountType);
            cmd.Parameters.Add(ToolHolder);
            cmd.Parameters.Add(PlatedBonded);
            cmd.Parameters.Add(ToolNumber);
            cmd.Parameters.Add(RefReorderNumber);
            cmd.Parameters.Add(Status);
            cmd.Parameters.Add(OldSN);
            cmd.Parameters.Add(Notes);
            cmd.Parameters.Add(Location);
            cmd.Parameters.Add(Supplier);
            cmd.Parameters.Add(Diameter_M);
            cmd.Parameters.Add(ShankDiameter_M);
            cmd.Parameters.Add(ReliefDiameter_M);
            cmd.Parameters.Add(FlatDiameter_M);
            cmd.Parameters.Add(InnerDiameter_M);
            cmd.Parameters.Add(UsableLength_M);
            cmd.Parameters.Add(DiamondLength_M);
            cmd.Parameters.Add(ColletLength_M);

            cmd.Connection = cnxn;
            cnxn.Open();
            try
            {
                inserted = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            if (inserted == 1)
            {
                cmd = new SqlCommand
                    ("Insert into toollocation (" +
                     "lsn, " +
                     "llocation, " +
                     "lprogram, " +
                     "lfacility) " +
                     "values ('" +
                      g.SN + "', " +
                     "'default', '" +
                      g.program + "', '" +
                      g.facility + "')");
                cmd.Connection = cnxn;

                //cnxn.Open();
                try
                {
                    inserted = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }


            }
            //    cnxn.Close();
            //    g.internalCalContact = 0;

            //    f17a_Select_Bench f7 = new f17a_Select_Bench();
            //    f7.Show();
            }
            else
            {
            cnxn = new SqlConnection(g.db);
            cmd = new SqlCommand("Update tools set " +
                "tooltype = " + ToolType + ", " +
                "Diameter = " + Diameter + ", " +
                "Diameter_M = " + Diameter_M + ", " +
                "ShankDiameter = " + ShankDiameter + ", " +
                "ShankDiameter_M = " + ShankDiameter_M + ", " +
                "ReliefDiameter = " + ReliefDiameter + ", " +
                "ReliefDiameter_M = " + ReliefDiameter_M + ", " +
                "FlatDiameter = " + FlatDiameter + ", " +
                "FlatDiameter_M = " + FlatDiameter_M + ", " +
                "InnerDiameter = " + InnerDiameter + ", " +
                "InnerDiameter_M = " + InnerDiameter_M + ", " +
                "UsableLength = " + UsableLength + ", " +
                "UsableLength_M = " + UsableLength_M + ", " +
                "DiamondLength = " + DiamondLength + ", " +
                "DiamondLength_M = " + DiamondLength_M + ", " +
                "Grit = " + Grit + ", " +
                "ColletLength = " + ColletLength + ", " +
                "ColletLength_M = " + ColletLength_M + ", " +
                "ColletNutSize = " + ColletNutSize + ", " +
                "NoseRadius = " + NoseRadius + ", " +
                "Angle =" + Angle + ", " +
                "MountType =" + MountType + ", " +
                "ToolHolderType =" + ToolHolder + ", " +
                "PlatedBonded =" + PlatedBonded + ", " +
                "ToolNumber =" + ToolNumber + ", " +
                "RefReorderNumber = " + RefReorderNumber + ", " +
                "Status =" + Status + ", " +
                "OldSN =" + OldSN + ", " +
                "Notes =" + Notes + ", " +
                "Location =" + Location + ", " +
                "Supplier =" + Supplier + " " +
                "where " +
                "SN = '" + g.SN + "'");

            cmd.Parameters.Add(ToolType);
            cmd.Parameters.Add(Diameter);
            cmd.Parameters.Add(ShankDiameter);
            cmd.Parameters.Add(ReliefDiameter);
            cmd.Parameters.Add(FlatDiameter);
            cmd.Parameters.Add(InnerDiameter);
            cmd.Parameters.Add(UsableLength);
            cmd.Parameters.Add(DiamondLength);
            cmd.Parameters.Add(Grit);
            cmd.Parameters.Add(ColletLength);
            cmd.Parameters.Add(ColletNutSize);
            cmd.Parameters.Add(NoseRadius);
            cmd.Parameters.Add(Angle);
            cmd.Parameters.Add(MountType);
            cmd.Parameters.Add(ToolHolder);
            cmd.Parameters.Add(PlatedBonded);
            cmd.Parameters.Add(ToolNumber);
            cmd.Parameters.Add(RefReorderNumber);
            cmd.Parameters.Add(Status);
            cmd.Parameters.Add(OldSN);
            cmd.Parameters.Add(Notes);
            cmd.Parameters.Add(Location);
            cmd.Parameters.Add(Supplier);
            cmd.Parameters.Add(Diameter_M);
            cmd.Parameters.Add(ShankDiameter_M);
            cmd.Parameters.Add(ReliefDiameter_M);
            cmd.Parameters.Add(FlatDiameter_M);
            cmd.Parameters.Add(InnerDiameter_M);
            cmd.Parameters.Add(UsableLength_M);
            cmd.Parameters.Add(DiamondLength_M);
            cmd.Parameters.Add(ColletLength_M);
    
            cmd.Connection = cnxn;
            cnxn.Open();
            int rowsReturned = cmd.ExecuteNonQuery();
            cnxn.Close();
            //g.internalCalContact = 0;

            }
            cmd.Parameters.Clear();

            ////f30b_Edit_Calibration_Parameters fb = new f30b_Edit_Calibration_Parameters();
            ////fb.Show();
            Close();
           
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            Close(); ;
        }


        private void check4numbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            //only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void tbUsableLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            check4numbers(sender, e);
        }

        private void tbUsableLength_M_KeyPress(object sender, KeyPressEventArgs e)
        {
            check4numbers(sender, e);
        }

        private void tbDiameter_KeyPress(object sender, KeyPressEventArgs e)
        {
            check4numbers(sender, e);
        }

        private void tbDiameter_M_KeyPress(object sender, KeyPressEventArgs e)
        {
            check4numbers(sender, e);
        }

        private void tbShankDiameter_KeyPress(object sender, KeyPressEventArgs e)
        {
            check4numbers(sender, e);
        }

        private void tbShankDiameter_M_KeyPress(object sender, KeyPressEventArgs e)
        {
            check4numbers(sender, e);
        }

        private void tbReliefDiameter_KeyPress(object sender, KeyPressEventArgs e)
        {
            check4numbers(sender, e);
        }

        private void tbReliefDiameter_M_KeyPress(object sender, KeyPressEventArgs e)
        {
            check4numbers(sender, e);
        }

        private void tbFlatDiameter_KeyPress(object sender, KeyPressEventArgs e)
        {
            check4numbers(sender, e);
        }

        private void tbFlatDiameter_M_KeyPress(object sender, KeyPressEventArgs e)
        {
            check4numbers(sender, e);
        }

        private void tbInnerDiameter_KeyPress(object sender, KeyPressEventArgs e)
        {
            check4numbers(sender, e);
        }

        private void tbInnerDiameter_M_KeyPress(object sender, KeyPressEventArgs e)
        {
            check4numbers(sender, e);
        }

        private void tbDiamondLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            check4numbers(sender, e);
        }

        private void tbDiamondLength_M_KeyPress(object sender, KeyPressEventArgs e)
        {
            check4numbers(sender, e);
        }

        private void tbColletLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            check4numbers(sender, e);
        }

        private void tbColletLength_M_KeyPress(object sender, KeyPressEventArgs e)
        {
            check4numbers(sender, e);
        }


        private void tbUsableLength_TextChanged(object sender, EventArgs e)
        {
            multiplyNumbers(tbUsableLength, tbUsableLength_M);
        }

        private void tbUsableLength_M_TextChanged(object sender, EventArgs e)
        {
            divideNumbers(tbUsableLength, tbUsableLength_M);
        }

        
        private void tbDiameter_TextChanged(object sender, EventArgs e)
        {
            multiplyNumbers(tbDiameter, tbDiameter_M);
        }

        private void tbDiameter_M_TextChanged(object sender, EventArgs e)
        {
            divideNumbers(tbDiameter, tbDiameter_M);
        }

        private void tbShankDiameter_TextChanged(object sender, EventArgs e)
        {
            multiplyNumbers(tbShankDiameter, tbShankDiameter_M);
        }

        private void tbShankDiameter_M_TextChanged(object sender, EventArgs e)
        {
            divideNumbers(tbShankDiameter, tbShankDiameter_M);
        }

        private void tbReliefDiameter_TextChanged(object sender, EventArgs e)
        {
            multiplyNumbers(tbReliefDiameter, tbReliefDiameter_M);
        }

        private void tbReliefDiameter_M_TextChanged(object sender, EventArgs e)
        {
            divideNumbers(tbReliefDiameter, tbReliefDiameter_M);
        }

        private void tbFlatDiameter_TextChanged(object sender, EventArgs e)
        {
            multiplyNumbers(tbFlatDiameter, tbFlatDiameter_M);
        }

        private void tbFlatDiameter_M_TextChanged(object sender, EventArgs e)
        {
            divideNumbers(tbFlatDiameter, tbFlatDiameter_M);

        }
        private void tbInnerDiameter_TextChanged(object sender, EventArgs e)
        {
            multiplyNumbers(tbInnerDiameter, tbInnerDiameter_M);
        }

        private void tbInnerDiameter_M_TextChanged(object sender, EventArgs e)
        {
            divideNumbers(tbInnerDiameter, tbInnerDiameter_M);
        }

        private void tbDiamondLength_TextChanged(object sender, EventArgs e)
        {
            multiplyNumbers(tbDiamondLength, tbDiamondLength_M);
        }

        private void tbDiamondLength_M_TextChanged(object sender, EventArgs e)
        {
            divideNumbers(tbDiamondLength, tbDiamondLength_M);
        }

        private void tbColletLength_TextChanged(object sender, EventArgs e)
        {
            multiplyNumbers(tbColletLength, tbColletLength_M);
        }

        private void tbColletLength_M_TextChanged(object sender, EventArgs e)
        {
            divideNumbers(tbColletLength, tbColletLength_M);
        }

        private void multiplyNumbers(TextBox inches, TextBox mm)
        {
            if (inches.Focused)
            {
                if (inches.Text.Length > 0)
                {
                    if (inches.Text.Length == 1 && inches.Text == ".")
                    {
                        return;
                    }
                    else
                    {
                        mm.Text =
                            Decimal.Multiply(
                            Convert.ToDecimal(inches.Text),
                            Convert.ToDecimal(25.4)).ToString();
                    }
                }

                if (inches.Text.Length == 0)
                {
                    mm.Text = null;
                }
            }
        }

        private void divideNumbers(TextBox inches, TextBox mm)
        {
            if (mm.Focused)
            {
                if (mm.Text.Length > 0)
                {
                    if (mm.Text.Length == 1 && mm.Text == ".")
                    {
                        return;
                    }
                    else
                    {
                        inches.Text =
                           Decimal.Divide(
                           Convert.ToDecimal(mm.Text),
                           Convert.ToDecimal(25.4)).ToString();
                    }
                }

                if (mm.Text.Length == 0)
                {
                    inches.Text = null;
                }
            }
        }

        private void bCopy_Click(object sender, EventArgs e)
        {
            string a;

            SqlParameter ToolType = new SqlParameter("@ToolType", SqlDbType.NVarChar, 20);
            ToolType.Value = cbddType.Text.ToString().Trim();

            a = tbDiameter.Text.Trim();
            SqlParameter Diameter = new SqlParameter("@Diameter", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbDiameter.Text, out FloatValueTransferVariable);
                Diameter.Value = FloatValueTransferVariable;
            }
            else
            {
                Diameter.Value = DBNull.Value;
            }

            a = tbDiameter_M.Text.Trim();
            SqlParameter Diameter_M = new SqlParameter("@Diameter_M", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbDiameter_M.Text, out FloatValueTransferVariable);
                Diameter_M.Value = FloatValueTransferVariable;
            }
            else
            {
                Diameter_M.Value = DBNull.Value;
            }

            a = tbShankDiameter.Text.Trim();
            SqlParameter ShankDiameter = new SqlParameter("@ShankDiameter", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbShankDiameter.Text, out FloatValueTransferVariable);
                ShankDiameter.Value = FloatValueTransferVariable;
            }
            else
            {
                ShankDiameter.Value = DBNull.Value;
            }

            a = tbShankDiameter_M.Text.Trim();
            SqlParameter ShankDiameter_M = new SqlParameter("@ShankDiameter_M", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbShankDiameter_M.Text, out FloatValueTransferVariable);
                ShankDiameter_M.Value = FloatValueTransferVariable;
            }
            else
            {
                ShankDiameter_M.Value = DBNull.Value;
            }

            a = tbReliefDiameter.Text.Trim();
            SqlParameter ReliefDiameter = new SqlParameter("@ReleifDiameter", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbReliefDiameter.Text, out FloatValueTransferVariable);
                ReliefDiameter.Value = FloatValueTransferVariable;
            }
            else
            {
                ReliefDiameter.Value = DBNull.Value;
            }

            a = tbReliefDiameter_M.Text.Trim();
            SqlParameter ReliefDiameter_M = new SqlParameter("@ReleifDiameter_M", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbReliefDiameter_M.Text, out FloatValueTransferVariable);
                ReliefDiameter_M.Value = FloatValueTransferVariable;
            }
            else
            {
                ReliefDiameter_M.Value = DBNull.Value;
            }

            a = tbFlatDiameter.Text.Trim();
            SqlParameter FlatDiameter = new SqlParameter("@FlatDiameter", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbFlatDiameter.Text, out FloatValueTransferVariable);
                FlatDiameter.Value = FloatValueTransferVariable;
            }
            else
            {
                FlatDiameter.Value = DBNull.Value;
            }

            a = tbFlatDiameter_M.Text.Trim();
            SqlParameter FlatDiameter_M = new SqlParameter("@FlatDiameter_M", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbFlatDiameter_M.Text, out FloatValueTransferVariable);
                FlatDiameter_M.Value = FloatValueTransferVariable;
            }
            else
            {
                FlatDiameter_M.Value = DBNull.Value;
            }

            a = tbInnerDiameter.Text.Trim();
            SqlParameter InnerDiameter = new SqlParameter("@InnerDiameter", SqlDbType.Float);
            if (a != "0" & a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbInnerDiameter.Text, out FloatValueTransferVariable);
                InnerDiameter.Value = FloatValueTransferVariable;
            }
            else
            {
                InnerDiameter.Value = DBNull.Value;
            }

            a = tbInnerDiameter_M.Text.Trim();
            SqlParameter InnerDiameter_M = new SqlParameter("@InnerDiameter_M", SqlDbType.Float);
            if (a != "0" & a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbInnerDiameter_M.Text, out FloatValueTransferVariable);
                InnerDiameter_M.Value = FloatValueTransferVariable;
            }
            else
            {
                InnerDiameter_M.Value = DBNull.Value;
            }

            a = tbUsableLength.Text.Trim();
            SqlParameter UsableLength = new SqlParameter("@UsableLength", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbUsableLength.Text, out FloatValueTransferVariable);
                UsableLength.Value = FloatValueTransferVariable;
            }
            else
            {
                UsableLength.Value = DBNull.Value;
            }

            a = tbUsableLength_M.Text.Trim();
            SqlParameter UsableLength_M = new SqlParameter("@UsableLength_M", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbUsableLength_M.Text, out FloatValueTransferVariable);
                UsableLength_M.Value = FloatValueTransferVariable;
            }
            else
            {
                UsableLength_M.Value = DBNull.Value;
            }

            a = tbDiamondLength.Text.Trim();
            SqlParameter DiamondLength = new SqlParameter("@DiamondLength", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbDiamondLength.Text, out FloatValueTransferVariable);
                DiamondLength.Value = FloatValueTransferVariable;
            }
            else
            {
                DiamondLength.Value = DBNull.Value;
            }

            a = tbDiamondLength_M.Text.Trim();
            SqlParameter DiamondLength_M = new SqlParameter("@DiamondLength_M", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbDiamondLength_M.Text, out FloatValueTransferVariable);
                DiamondLength_M.Value = FloatValueTransferVariable;
            }
            else
            {
                DiamondLength_M.Value = DBNull.Value;
            }

            SqlParameter Grit = new SqlParameter("@Grit", SqlDbType.NChar, 10);
            Grit.Value = tbGrit.Text.ToString().Trim();

            a = tbColletLength.Text.Trim();
            SqlParameter ColletLength = new SqlParameter("@ColletLength", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbColletLength.Text, out FloatValueTransferVariable);
                ColletLength.Value = FloatValueTransferVariable;
            }
            else
            {
                ColletLength.Value = DBNull.Value;
            }

            a = tbColletLength_M.Text.Trim();
            SqlParameter ColletLength_M = new SqlParameter("@ColletLength_M", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbColletLength_M.Text, out FloatValueTransferVariable);
                ColletLength_M.Value = FloatValueTransferVariable;
            }
            else
            {
                ColletLength_M.Value = DBNull.Value;
            }

            a = tbColletNutSize.Text.Trim();
            SqlParameter ColletNutSize = new SqlParameter("@ColletNutSize", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbColletNutSize.Text, out FloatValueTransferVariable);
                ColletNutSize.Value = FloatValueTransferVariable;
            }
            else
            {
                ColletNutSize.Value = DBNull.Value;
            }

            a = tbNoseRadius.Text.Trim();
            SqlParameter NoseRadius = new SqlParameter("@NoseRadius", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbNoseRadius.Text, out FloatValueTransferVariable);
                NoseRadius.Value = FloatValueTransferVariable;
            }
            else
            {
                NoseRadius.Value = DBNull.Value;
            }

            a = tbAngle.Text.Trim();
            SqlParameter Angle = new SqlParameter("@Angle", SqlDbType.Float);
            if (a != "0" && a != null && a != "")
            {
                bool isNum;
                isNum = float.TryParse(tbAngle.Text, out FloatValueTransferVariable);
                Angle.Value = FloatValueTransferVariable;
            }
            else
            {
                Angle.Value = DBNull.Value;
            }

            SqlParameter MountType = new SqlParameter("@MountType", SqlDbType.NChar, 50);
            MountType.Value = tbMountingType.Text.ToString().Trim();
            SqlParameter ToolHolder = new SqlParameter("@ToolHolder", SqlDbType.NChar, 50);
            ToolHolder.Value = tbToolHolderType.Text.ToString().Trim();
            SqlParameter ToolNumber = new SqlParameter("@ToolNumber", SqlDbType.NChar, 20);
            ToolNumber.Value = tbToolNumber.Text.ToString().Trim();
            SqlParameter RefReorderNumber = new SqlParameter("@RefReorderNumber", SqlDbType.NChar, 30);
            RefReorderNumber.Value = tbReorderNumber.Text.ToString().Trim();
            SqlParameter OldSN = new SqlParameter("@OldSN", SqlDbType.NChar, 50);
            OldSN.Value = tbOldSN.Text.ToString().Trim();
            SqlParameter Notes = new SqlParameter("@Notes", SqlDbType.Text);
            Notes.Value = tbNotes.Text.ToString().Trim();
            SqlParameter Location = new SqlParameter("@Location", SqlDbType.NChar, 20);
            Location.Value = tbLocation.Text.ToString().Trim();
            SqlParameter Supplier = new SqlParameter("@Supplier", SqlDbType.NChar, 50);
            Supplier.Value = tbSupplier.Text.ToString().Trim();

            SqlParameter Status = new SqlParameter("@Status", SqlDbType.NChar, 1);
            if (cbActive.Checked == true)
            {
                Status.Value = "A";
            }
            else
            {
                Status.Value = "I";
            }

            SqlParameter PlatedBonded = new SqlParameter("@PlatedBonded", SqlDbType.NChar, 1);
            if (rbPlated.Checked == true)
            {
                PlatedBonded.Value = "P";
            }

            if (rbBonded.Checked == true)
            {
                PlatedBonded.Value = "B";
            }

            if (!rbPlated.Checked && !rbBonded.Checked)
            {
                PlatedBonded.Value = DBNull.Value;
            }

            cnxn = new SqlConnection(g.db);
 
            cmd = new SqlCommand("Insert into tools ( " +
                "tooltype, " +
                "Diameter, " +
                "Diameter_M, " +
                "ShankDiameter, " +
                "ShankDiameter_M, " +
                "ReliefDiameter, " +
                "ReliefDiameter_M, " +
                "FlatDiameter, " +
                "FlatDiameter_M, " +
                "InnerDiameter, " +
                "InnerDiameter_M, " +
                "UsableLength, " +
                "UsableLength_M, " +
                "DiamondLength, " +
                "DiamondLength_M, " +
                "Grit, " +
                "ColletLength, " +
                "ColletLength_M, " +
                "ColletNutSize, " +
                "NoseRadius, " +
                "Angle, " +
                "MountType, " +
                "ToolHolderType, " +
                "PlatedBonded, " +
                "ToolNumber, " +
                "RefReorderNumber, " +
                "Status, " +
                "OldSN, " +
                "Notes, " +
                "Location, " +
                "Supplier, " +
                "SN) values (" +
                ToolType + ", " +
                Diameter + ", " +
                Diameter_M + ", " +
                ShankDiameter + ", " +
                ShankDiameter_M + ", " +
                ReliefDiameter + ", " +
                ReliefDiameter_M + ", " +
                FlatDiameter + ", " +
                FlatDiameter_M + ", " +
                InnerDiameter + ", " +
                InnerDiameter_M + ", " +
                UsableLength + ", " +
                UsableLength_M + ", " +
                DiamondLength + ", " +
                DiamondLength_M + ", " +
                Grit + ", " +
                ColletLength + ", " +
                ColletLength_M + ", " +
                ColletNutSize + ", " +
                NoseRadius + ", " +
                Angle + ", " +
                MountType + ", " +
                ToolHolder + ", " +
                PlatedBonded + ", " +
                ToolNumber + ", " +
                RefReorderNumber + ", " +
                Status + ", " +
                OldSN + ", " +
                Notes + ", " +
                Location + ", " +
                Supplier + ", " +
                "0)");

            cmd.Parameters.Add(ToolType);
            cmd.Parameters.Add(Diameter);
            cmd.Parameters.Add(ShankDiameter);
            cmd.Parameters.Add(ReliefDiameter);
            cmd.Parameters.Add(FlatDiameter);
            cmd.Parameters.Add(InnerDiameter);
            cmd.Parameters.Add(UsableLength);
            cmd.Parameters.Add(DiamondLength);
            cmd.Parameters.Add(Grit);
            cmd.Parameters.Add(ColletLength);
            cmd.Parameters.Add(ColletNutSize);
            cmd.Parameters.Add(NoseRadius);
            cmd.Parameters.Add(Angle);
            cmd.Parameters.Add(MountType);
            cmd.Parameters.Add(ToolHolder);
            cmd.Parameters.Add(PlatedBonded);
            cmd.Parameters.Add(ToolNumber);
            cmd.Parameters.Add(RefReorderNumber);
            cmd.Parameters.Add(Status);
            cmd.Parameters.Add(OldSN);
            cmd.Parameters.Add(Notes);
            cmd.Parameters.Add(Location);
            cmd.Parameters.Add(Supplier);
            cmd.Parameters.Add(Diameter_M);
            cmd.Parameters.Add(ShankDiameter_M);
            cmd.Parameters.Add(ReliefDiameter_M);
            cmd.Parameters.Add(FlatDiameter_M);
            cmd.Parameters.Add(InnerDiameter_M);
            cmd.Parameters.Add(UsableLength_M);
            cmd.Parameters.Add(DiamondLength_M);
            cmd.Parameters.Add(ColletLength_M);

            cmd.Connection = cnxn;
            cnxn.Open();
            int rowsReturned = cmd.ExecuteNonQuery();
            cnxn.Close();
            //g.internalCalContact = 0;

            //}
            cmd.Parameters.Clear();

            ////f30b_Edit_Calibration_Parameters fb = new f30b_Edit_Calibration_Parameters();
            ////fb.Show();
            Close();
           

        }
       
    }
}