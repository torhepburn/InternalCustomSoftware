using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Tools
{
    public partial class F4a_AddEditFxVc : Form
    {
        SqlConnection cnxn;
        SqlCommand cmd;
        private float FloatValueTransferVariable;
        private int inserted;

        public F4a_AddEditFxVc()
        {
            InitializeComponent();
        }

        private void F4a_AddEditFxVc_Load(object sender, EventArgs e)
        {
            this.Text = g.task;

            if (g.task == "Add")
            {
                tbSN.Focus();
            }
            else
            {
                tbSN.Text = g.SN;

                cnxn = new SqlConnection(g.db);
                SqlCommand cmd = new SqlCommand
               ("Select  " +
                "Diameter_M, " +
                "UsableLength_M, " +
                "Width_M, " +
                "ItemDescription, " +
                "Llocation, " + 
                "notes " +
                "from tools v " +
                "inner join toollocation l on v.sn = l.lsn " +
                "where sn = '" +
                g.SN + "'  ");
                cmd.Connection = cnxn;
                cnxn.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    if (!dr.IsDBNull(0)) { tbDiameter.Text = dr.GetDecimal(0).ToString(); }
                    if (!dr.IsDBNull(1)) { tbUsableLength_M.Text = dr.GetDecimal(1).ToString(); }
                    if (!dr.IsDBNull(2)) { tbWidth_M.Text = dr.GetDecimal(2).ToString(); }
                    if (!dr.IsDBNull(3)) { tbItemDescription.Text = dr.GetString(3).Trim(); }
                    if(!dr.IsDBNull(4)) { tbLocation.Text = dr.GetString(4).Trim(); }
                    if (!dr.IsDBNull(5)) { tbNotes.Text = dr.GetString(5).Trim(); }
                }
            }
        }


        private void bSave_Click(object sender, EventArgs e)
        {
            if (g.task != "View")
            {
                string a;

                SqlParameter pSN = new SqlParameter("@sn", SqlDbType.VarChar);
                if (g.task == "Add")
                {
                    a = tbSN.Text.ToUpper().Trim();

                    if (a != null && a != "")
                    {
                        pSN.Value = a;
                    }
                }
                else
                {
                    pSN.Value = g.SN;
                }


                a = tbUsableLength_M.Text.Trim();
                SqlParameter pUsableLength_M = new SqlParameter("@UsableLength_M", SqlDbType.Float);
                if (a != "0" && a != null && a != "")
                {
                    bool isNum;
                    isNum = float.TryParse(tbUsableLength_M.Text, out FloatValueTransferVariable);
                    pUsableLength_M.Value = FloatValueTransferVariable;
                }
                else
                {
                    pUsableLength_M.Value = DBNull.Value;
                }

                a = tbWidth_M.Text.Trim();
                SqlParameter pWidth_M = new SqlParameter("@width_m", SqlDbType.Float);
                if (a != "0" && a != null && a != "")
                {
                    bool isNum;
                    isNum = float.TryParse(tbWidth_M.Text, out FloatValueTransferVariable);
                    pWidth_M.Value = FloatValueTransferVariable;
                }
                else
                {
                    pWidth_M.Value = DBNull.Value;
                }

                a = tbDiameter.Text.Trim();
                SqlParameter pDiameter_M = new SqlParameter("@Diameter_M", SqlDbType.Decimal);
                if (a != "0" && a != null && a != "")
                {
                    bool isNum;
                    isNum = float.TryParse(tbDiameter.Text, out FloatValueTransferVariable);
                    pDiameter_M.Value = FloatValueTransferVariable;
                }
                else
                {
                    pDiameter_M.Value = DBNull.Value;
                }


                a = tbItemDescription.Text.ToUpper().Trim();
                SqlParameter pItemDescription = new SqlParameter("@ItemDescription", SqlDbType.VarChar);
                if (a != null && a != "")
                {
                    pItemDescription.Value = a;
                }
                else
                {
                    pItemDescription.Value = DBNull.Value;
                }

                a = tbLocation.Text.ToUpper().Trim();
                SqlParameter pLocation = new SqlParameter("@Location", SqlDbType.VarChar);
                if (a != null && a != "")
                {
                    pLocation.Value = a;
                }
                else
                {
                    pLocation.Value = "default";
                }

                SqlParameter pStatus = new SqlParameter("@Status", SqlDbType.NChar, 1);
                if (cbActive.Checked == true)
                {
                    pStatus.Value = "A";
                }
                else
                {
                    pStatus.Value = "I";
                }

                a = tbNotes.Text.ToUpper().Trim();
                SqlParameter pNotes = new SqlParameter("@Notes", SqlDbType.VarChar);
                if (a != null && a != "")
                {
                    pNotes.Value = a;
                }
                else
                {
                    pNotes.Value = DBNull.Value;
                }


                if (g.task == "Add")
                {
                    cnxn = new SqlConnection(g.db);
                    cmd = new SqlCommand("Insert into tools (" +
                    "sn, " +
                    "Diameter_M, " +
                    "UsableLength_M, " +
                    "Width_M, " +
                    "ItemDescription, " +
                    "Status, " +
                    "Notes, " +
                    "Program) " +
                    "values ( " +
                    pSN + ", " +
                    pDiameter_M + ", " +
                    pUsableLength_M + ", " +
                    pWidth_M + ", " +
                    pItemDescription + "," +
                    pStatus + "," +
                    pNotes + ", '" +
                    g.program + "' )");

                    cmd.Parameters.Add(pDiameter_M);
                    cmd.Parameters.Add(pUsableLength_M);
                    cmd.Parameters.Add(pSN);
                    cmd.Parameters.Add(pWidth_M);
                    cmd.Parameters.Add(pItemDescription);
                    cmd.Parameters.Add(pStatus);
                    cmd.Parameters.Add(pNotes);

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
                    finally
                    {
                        cmd.Parameters.Clear();
                    }

                    if (inserted == 1)
                    {
                        cmd = new SqlCommand
                            ("Insert into toollocation (" +
                             "lsn, " +
                             "llocation, " +
                             "lprogram, " +
                             "lfacility) " +
                             "values (" +
                              pSN + ", " +
                              pLocation + ",'" +
                              g.program + "', '" +
                              g.facility + "')");
                        cmd.Connection = cnxn;

                        cmd.Parameters.Add(pSN);
                        cmd.Parameters.Add(pLocation);

                        //cnxn.Open();
                        try
                        {
                            inserted = cmd.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        finally
                        {
                            cmd.Parameters.Clear();

                        }
                    }
                }
                else
                {
                    cnxn = new SqlConnection(g.db);

                    try
                    {
                        cmd = new SqlCommand("Update tools set " +
                            "Diameter_M = " + pDiameter_M + ", " +
                            "UsableLength_M = " + pUsableLength_M + ", " +
                            "Width_M = " + pWidth_M + ", " +
                            "ItemDescription = " + pItemDescription + ", " +
                            "Notes = " + pNotes + ", " +
                            "Status = " + pStatus +
                            " where " +
                            " SN = '" + g.SN + "'");

                        cmd.Parameters.Add(pDiameter_M);
                        cmd.Parameters.Add(pUsableLength_M);
                        cmd.Parameters.Add(pSN);
                        cmd.Parameters.Add(pWidth_M);
                        cmd.Parameters.Add(pItemDescription);
                        cmd.Parameters.Add(pStatus);
                        cmd.Parameters.Add(pNotes);

                        cmd.Connection = cnxn;
                        cnxn.Open();
                        int rowsReturned = cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        cnxn.Close();
                        cmd.Parameters.Clear();
                    }

                    cmd = new SqlCommand
                            ("Update toollocation " +
                             "set llocation = " + pLocation +
                              " where " +
                            " LSN = '" + g.SN + "'");

                    cmd.Connection = cnxn;

                    cmd.Parameters.Add(pLocation);

                    cnxn.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        cmd.Parameters.Clear();
                        cnxn.Close();
                    }
                }
            }
            Close();
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
