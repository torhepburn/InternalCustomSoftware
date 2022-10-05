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
    public partial class f30b_Edit_Calibration_Parameters : Form
    {
        SqlCommand cmd;
        SqlConnection cnxn;

        public f30b_Edit_Calibration_Parameters()
        {
            InitializeComponent();
        }

        private void f30b_Edit_Calibration_Parameters_Load(object sender, EventArgs e)
        {
            if (g.task == "Edit")
            {
                cnxn = new SqlConnection(g.db);
                cmd = new SqlCommand
                    ("select * from equipment where id = '" +
                     g.iID + "'");
                cmd.Connection = cnxn;
                cnxn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (!dr.IsDBNull(20)) { tbPar1.Text = dr.GetString(20).Trim(); }
                    if (!dr.IsDBNull(21)) { tbPar1Nom.Text = dr.GetString(21).Trim(); }
                    if (!dr.IsDBNull(22)) { tbPar1UM.Text = dr.GetString(22).Trim(); }
                    if (!dr.IsDBNull(23)) { tbPar1Criteria.Text = dr.GetString(23).Trim(); }
                    if (!dr.IsDBNull(24)) { tbPar2.Text = dr.GetString(24).Trim(); }
                    if (!dr.IsDBNull(25)) { tbPar2Nom.Text = dr.GetString(25).Trim(); }
                    if (!dr.IsDBNull(26)) { tbPar2UM.Text = dr.GetString(26).Trim(); }
                    if (!dr.IsDBNull(27)) { tbPar2Criteria.Text = dr.GetString(27).Trim(); }
                    if (!dr.IsDBNull(28)) { tbPar3.Text = dr.GetString(28).Trim(); }
                    if (!dr.IsDBNull(29)) { tbPar3Nom.Text = dr.GetString(29).Trim(); }
                    if (!dr.IsDBNull(30)) { tbPar3UM.Text = dr.GetString(30).Trim(); }
                    if (!dr.IsDBNull(31)) { tbPar3Criteria.Text = dr.GetString(31).Trim(); }
                    if (!dr.IsDBNull(32)) { tbPar4.Text = dr.GetString(32).Trim(); }
                    if (!dr.IsDBNull(33)) { tbPar4Nom.Text = dr.GetString(33).Trim(); }
                    if (!dr.IsDBNull(34)) { tbPar4UM.Text = dr.GetString(34).Trim(); }
                    if (!dr.IsDBNull(35)) { tbPar4Criteria.Text = dr.GetString(35).Trim(); }
                    if (!dr.IsDBNull(36)) { tbPar5.Text = dr.GetString(36).Trim(); }
                    if (!dr.IsDBNull(37)) { tbPar5Nom.Text = dr.GetString(37).Trim(); }
                    if (!dr.IsDBNull(38)) { tbPar5UM.Text = dr.GetString(38).Trim(); }
                    if (!dr.IsDBNull(39)) { tbPar5Criteria.Text = dr.GetString(39).Trim(); }
                    if (!dr.IsDBNull(40)) { tbPar6.Text = dr.GetString(40).Trim(); }
                    if (!dr.IsDBNull(41)) { tbPar6Nom.Text = dr.GetString(41).Trim(); }
                    if (!dr.IsDBNull(42)) { tbPar6UM.Text = dr.GetString(42).Trim(); }
                    if (!dr.IsDBNull(43)) { tbPar6Criteria.Text = dr.GetString(43).Trim(); }
                    if (!dr.IsDBNull(44)) { tbCalInterval.Text = dr.GetInt32(44).ToString().Trim(); }
                }
                cnxn.Close();
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (tbCalInterval.Text == "") { tbCalInterval.Text = "0"; }

            SqlParameter p1 = new SqlParameter("@p1", SqlDbType.NVarChar, 25);
            p1.Value = tbPar1.Text.ToString().Trim();
            SqlParameter p1n = new SqlParameter("@p1n", SqlDbType.NVarChar, 50);
            p1n.Value = tbPar1Nom.Text.ToString().Trim();
            SqlParameter p1u = new SqlParameter("@p1u", SqlDbType.NVarChar, 5);
            p1u.Value = tbPar1UM.Text.ToString().Trim();
            SqlParameter p1c = new SqlParameter("@p1c", SqlDbType.NVarChar, 2);
            p1c.Value = tbPar1Criteria.Text.ToString().Trim();

            SqlParameter p2 = new SqlParameter("@p2", SqlDbType.NVarChar, 25);
            p2.Value = tbPar2.Text.ToString().Trim();
            SqlParameter p2n = new SqlParameter("@p2n", SqlDbType.NVarChar, 50);
            p2n.Value = tbPar2Nom.Text.ToString().Trim();
            SqlParameter p2u = new SqlParameter("@p2u", SqlDbType.NVarChar, 5);
            p2u.Value = tbPar2UM.Text.ToString().Trim();
            SqlParameter p2c = new SqlParameter("@p2c", SqlDbType.NVarChar, 2);
            p2c.Value = tbPar2Criteria.Text.ToString().Trim();

            SqlParameter p3 = new SqlParameter("@p3", SqlDbType.NVarChar, 25);
            p3.Value = tbPar3.Text.ToString().Trim();
            SqlParameter p3n = new SqlParameter("@p3n", SqlDbType.NVarChar, 50);
            p3n.Value = tbPar3Nom.Text.ToString().Trim();
            SqlParameter p3u = new SqlParameter("@p3u", SqlDbType.NVarChar, 5);
            p3u.Value = tbPar3UM.Text.ToString().Trim();
            SqlParameter p3c = new SqlParameter("@p3c", SqlDbType.NVarChar, 2);
            p3c.Value = tbPar3Criteria.Text.ToString().Trim();

            SqlParameter p4 = new SqlParameter("@p4", SqlDbType.NVarChar, 25);
            p4.Value = tbPar4.Text.ToString().Trim();
            SqlParameter p4n = new SqlParameter("@p4n", SqlDbType.NVarChar, 50);
            p4n.Value = tbPar4Nom.Text.ToString().Trim();
            SqlParameter p4u = new SqlParameter("@p4u", SqlDbType.NVarChar, 5);
            p4u.Value = tbPar4UM.Text.ToString().Trim();
            SqlParameter p4c = new SqlParameter("@p4c", SqlDbType.NVarChar, 2);
            p4c.Value = tbPar4Criteria.Text.ToString().Trim();

            SqlParameter p5 = new SqlParameter("@p5", SqlDbType.NVarChar, 25);
            p5.Value = tbPar5.Text.ToString().Trim();
            SqlParameter p5n = new SqlParameter("@p5n", SqlDbType.NVarChar, 50);
            p5n.Value = tbPar5Nom.Text.ToString().Trim();
            SqlParameter p5u = new SqlParameter("@p5u", SqlDbType.NVarChar, 5);
            p5u.Value = tbPar5UM.Text.ToString().Trim();
            SqlParameter p5c = new SqlParameter("@p5c", SqlDbType.NVarChar, 2);
            p5c.Value = tbPar5Criteria.Text.ToString().Trim();

            SqlParameter p6 = new SqlParameter("@p6", SqlDbType.NVarChar, 25);
            p6.Value = tbPar6.Text.ToString().Trim();
            SqlParameter p6n = new SqlParameter("@p6n", SqlDbType.NVarChar, 50);
            p6n.Value = tbPar6Nom.Text.ToString().Trim();
            SqlParameter p6u = new SqlParameter("@p6u", SqlDbType.NVarChar, 5);
            p6u.Value = tbPar6UM.Text.ToString().Trim();
            SqlParameter p6c = new SqlParameter("@p6c", SqlDbType.NVarChar, 2);
            p6c.Value = tbPar6Criteria.Text.ToString().Trim();

            SqlParameter ci = new SqlParameter("@ci", SqlDbType.Int);
            ci.Value = tbCalInterval.Text.Trim();
            
            cnxn = new SqlConnection(g.db);
            cmd = new SqlCommand("Update equipment set " +
                " par1 = " + p1 + "," +
                " par1Nom = " + p1n + "," +
                " par1UM = " + p1u + "," +
                " par1Criteria = " + p1c + "," +
                " par2 = " + p2 + "," +
                " par2Nom = " + p2n + "," +
                " par2UM = " + p2u + "," +
                " par2Criteria = " + p2c + "," +
                " par3 = " + p3 + "," +
                " par3Nom = " + p3n + "," +
                " par3UM = " + p3u + "," +
                " par3Criteria = " + p3c + "," +
                " par4 = " + p4 + "," +
                " par4Nom = " + p4n + "," +
                " par4UM = " + p4u + "," +
                " par4Criteria = " + p4c + "," +
                " par5 = " + p5 + "," +
                " par5Nom = " + p5n + "," +
                " par5UM = " + p5u + "," +
                " par5Criteria = " + p5c + "," +
                " par6 = " + p6 + "," +
                " par6Nom = " + p6n + "," +
                " par6UM = " + p6u + "," +
                " par6Criteria = " + p6c + "," +
                " cal_interval = " + ci + 
                " where " + 
                " id = '" + g.iID + "'");

            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p1n);
            cmd.Parameters.Add(p1u);
            cmd.Parameters.Add(p1c);

            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p2n);
            cmd.Parameters.Add(p2u);
            cmd.Parameters.Add(p2c);

            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p3n);
            cmd.Parameters.Add(p3u);
            cmd.Parameters.Add(p3c);

            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p4n);
            cmd.Parameters.Add(p4u);
            cmd.Parameters.Add(p4c);

            cmd.Parameters.Add(p5);
            cmd.Parameters.Add(p5n);
            cmd.Parameters.Add(p5u);
            cmd.Parameters.Add(p5c);

            cmd.Parameters.Add(p6);
            cmd.Parameters.Add(p6n);
            cmd.Parameters.Add(p6u);
            cmd.Parameters.Add(p6c);

            cmd.Parameters.Add(ci);

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

            Close();
            if (g.task == "Add")
            { 
                f17a_Select_Bench f7 = new f17a_Select_Bench();
                f7.ShowDialog();
            }

        }

        private void bExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}