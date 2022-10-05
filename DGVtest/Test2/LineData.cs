using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Test2
{
    public partial class LineData : Form
    {
        SqlConnection cnxn;
        public LineData()
        {
            InitializeComponent();
        }

        private void LineData_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);

            if (g.task == "EDIT" | g.task == "COPY")
            {
                tbItemCode.Text = g.itemCode;
                tbDescription.Text = g.itemDescription;
                tbQuantity.Text = g.iQuantity;
                tbBoxes.Text = g.numberofBoxes;
                tbInstallOn.Text = g.installOn;
                tbKitWith.Text = g.kitWith;
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            SqlParameter pItemCode = new SqlParameter
               ("@itemCode", SqlDbType.NChar);
            SqlParameter pDescription = new SqlParameter
                ("@description", SqlDbType.NChar);
            SqlParameter pQuantity = new SqlParameter
                ("@quantity", SqlDbType.NChar);
            SqlParameter pBoxes = new SqlParameter
                ("@boxes", SqlDbType.NChar);
            SqlParameter pInstallOn = new SqlParameter
                ("@installOn", SqlDbType.NChar);
            SqlParameter pKitWith = new SqlParameter
                ("@kitWith", SqlDbType.NChar);

            
            SqlParameter pPLDescription = new SqlParameter
                ("@plDescription", SqlDbType.NChar);
            pPLDescription.Value = g.plDescription;

            if (tbItemCode.Text.Length < 1)
            {
                MessageBox.Show("Must enter an item code.");
                tbItemCode.Focus();
                return;
            }
            else
            {
                pItemCode.Value = tbItemCode.Text.Trim();
            }

            if (tbDescription.Text.Length < 1)
            {
                MessageBox.Show("Must enter an item description.");
                tbDescription.Focus();
                return;
            }
            else
            {
                pDescription.Value = tbDescription.Text.Trim();
            }

            if (tbQuantity.Text.Length < 1)
            {
                MessageBox.Show("Must enter a quantity.");
                tbQuantity.Focus();
                return;
            }
            else
            {
                pQuantity.Value = tbQuantity.Text.Trim();
            }

            if (tbBoxes.Text.Length < 1)
            {
                MessageBox.Show("Must enter a number of boxes.");
                tbBoxes.Focus();
                return;
            }
            else
            {
                pBoxes.Value = tbBoxes.Text.Trim();
            }

            if (tbInstallOn.Text.Length < 1)
            {
                pInstallOn.Value = DBNull.Value;
            }
            else
            {
                pInstallOn.Value = tbInstallOn.Text.Trim();
            }

            if (tbKitWith.Text.Length < 1)
            {
                pKitWith.Value = DBNull.Value;
            }
            else
            {
                pKitWith.Value = tbKitWith.Text.Trim();
            }


            if (g.task == "EDIT")
            {
                
                SqlCommand cmd = new SqlCommand(
                    "UPDATE labels_packinglists " +
                    "SET " +
                    "item_code = " + pItemCode +
                    ", description = " + pDescription +
                    ", quantity = " +pQuantity +
                    ", boxes = " + pBoxes +
                    ", installon = " + pInstallOn +
                    ", kitwith = " + pKitWith +
                    " WHERE UID = " + g.UID, cnxn);

                try
                {
                    cmd.Parameters.Add(pItemCode);
                    cmd.Parameters.Add(pDescription);
                    cmd.Parameters.Add(pQuantity);
                    cmd.Parameters.Add(pBoxes);
                    cmd.Parameters.Add(pInstallOn);
                    cmd.Parameters.Add(pKitWith);

                    if (cnxn.State == ConnectionState.Closed)
                    {
                        cnxn.Open();
                    }
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn.Close();
                }
            }

            if (g.task == "ADD")
            {

                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO labels_packinglists " +
                    "(documentnumber " +
                    ",pldescription " +
                    ",revision " +
                    ",item_code " +
                    ", description " +
                    ", quantity " +
                    ", boxes " +
                    ", installon " +
                    ", kitwith ) " +
                    " values " +
                    "('" + g.document +
                    "'," + pPLDescription +
                    ",'" + g.revision +
                    "'," + pItemCode +
                    "," + pDescription +
                    "," + pQuantity +
                    "," + pBoxes +
                    "," + pInstallOn +
                    "," + pKitWith + ")"
                    , cnxn);

                try
                {
                    cmd.Parameters.Add(pPLDescription);
                    cmd.Parameters.Add(pItemCode);
                    cmd.Parameters.Add(pDescription);
                    cmd.Parameters.Add(pQuantity);
                    cmd.Parameters.Add(pBoxes);
                    cmd.Parameters.Add(pInstallOn);
                    cmd.Parameters.Add(pKitWith);

                    if (cnxn.State == ConnectionState.Closed)
                    {
                        cnxn.Open();
                    }
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn.Close();
                }
            }

            this.Close();
        }
    }
}
