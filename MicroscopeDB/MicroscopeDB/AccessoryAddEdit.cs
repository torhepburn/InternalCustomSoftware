using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MicroscopeDB
{
    public partial class AccessoryAddEdit : Form
    {
        SqlConnection cnxn;
        private string SQL;
        private string AccType;
        private string bAction;

        public AccessoryAddEdit()
        {
            InitializeComponent();
        }

        private void AccessoryAddEdit_Load(object sender, EventArgs e)
        {
            rbObjective.Checked = true;

            LproductLine.Text = g.ProductLine;
            LDateCode.Text = g.DateCode + "-";
            Lsn.Text = g.serialNumber;

            cnxn = new SqlConnection(g.db);

            if (g.task == "Edit")
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "Select " +
                    " partnumber " +
                    ",accdescription " +
                    ",accserialnumber " +
                    ",AccessoryType " +
                    "FROM MicroscopeAccessories " +
                    "WHERE id = " + g.AccessoryDataID, cnxn );

                DataTable dt = new DataTable();

                try
                {
                    da.Fill(dt);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn.Close();

                }

                tbPartNumber.Text = dt.Rows[0][0].ToString();
                tbDescription.Text = dt.Rows[0][1].ToString();
                tbSerialNumber.Text = dt.Rows[0][2].ToString();

                if (dt.Rows[0][3].ToString().Trim() == "Objective")
                {
                    rbObjective.Checked = true;
                }

                if (dt.Rows[0][3].ToString().Trim() == "Standard")
                {
                    rbStandard.Checked = true;
                }

                if (dt.Rows[0][3].ToString().Trim() == "Other")
                {
                    rbOther.Checked = true;
                }
            }
        }

        private void Bsave_Click(object sender, EventArgs e)
        {
            accessory();

            SqlParameter pPartNumber = new SqlParameter
               ("@PartNumber", SqlDbType.NChar);
            if (tbPartNumber.Text.Length > 0)
            {
                pPartNumber.Value = tbPartNumber.Text;
            }
            else
            {
                MessageBox.Show("Must enter a part number");
                return;
            }

            SqlParameter pDescription = new SqlParameter
                ("@Description", SqlDbType.NChar);
            if (tbDescription.Text.Length > 0)
            {
                pDescription.Value = tbDescription.Text;
            }
            else
            {
                pDescription.Value = DBNull.Value;
            }

            SqlParameter pSerialNumber = new SqlParameter
                ("@SerialNumber", SqlDbType.NChar);
            if (tbSerialNumber.Text.Length > 0)
            {
                pSerialNumber.Value = tbSerialNumber.Text;
            }
            else
            {
                pSerialNumber.Value = DBNull.Value;
            }


            if (g.task == "Add")
            {
                SQL = "Insert into MicroscopeAccessories (" +
                    " AccessoryType " +
                    ",PartNumber " +
                    ",AccDescription " +
                    ",AccSerialNumber " +
                    ",MicroscopeData_ID) " +
                    "values ('" + AccType + "'," +
                    pPartNumber + "," +
                    pDescription + "," +
                    pSerialNumber + "," +
                    g.DataID + ")";
            }

            if (g.task == "Edit")
            {
                SQL = "Update MicroscopeAccessories SET " +
                    " AccessoryType  = '" + AccType + "'" +
                    ",PartNumber = " + pPartNumber +
                    ",AccDescription = " + pDescription +
                    ",AccSerialNumber = " + pSerialNumber +
                    " WHERE id = " + g.AccessoryDataID
                    ;
            }
            
            SqlCommand cmd = new SqlCommand( SQL, cnxn);

            cmd.Parameters.Add(pPartNumber);
            cmd.Parameters.Add(pDescription);
            cmd.Parameters.Add(pSerialNumber);

            try
            {
                cnxn.Open();
                int row = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                if (row > 0)
                {
                    MessageBox.Show("Data Saved");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
                tbPartNumber.Text = string.Empty;
                tbDescription.Text = string.Empty;
                tbSerialNumber.Text = string.Empty;
            }

            bAction = "IntentionalClose";

            this.Close();
        }

        private void accessory()
        {
            if (rbObjective.Checked)
            {
                AccType = "Objective";
            }
            if (rbStandard.Checked)
            {
                AccType = "Standard";
            }
            if (rbOther.Checked)
            {
                AccType = "Other";
            }
        }


        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM MicroscopeAccessories " +
                   " WHERE id = " + g.AccessoryDataID, cnxn);

            try
            {
                cnxn.Open();
                int row = cmd.ExecuteNonQuery();
                
                if (row > 0)
                {
                    MessageBox.Show("Data Deleted");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
                tbPartNumber.Text = string.Empty;
                tbDescription.Text = string.Empty;
                tbSerialNumber.Text = string.Empty;
            }

            bAction = "IntentionalClose";

            this.Close();
        }

        private void AccessoryAddEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bAction != "IntentionalClose")
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    DialogResult result = MessageBox.Show("Do you want to exit without saving data ?", "",
                        MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        return;
                    }
                    else
                    {
                        e.Cancel = true;
                    }

                }
                else
                {
                    e.Cancel = true;
                }
            }
            
        }
    }
}
