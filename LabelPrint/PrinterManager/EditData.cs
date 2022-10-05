using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;


namespace PrinterManager
{
    public partial class EditData : Form
    {
        SqlConnection cnxn;
        private string SQL;
    
        public EditData()
        {
            InitializeComponent();
        }

        private void EditData_Load(object sender, EventArgs e)
        {
            tbComputer.Text = g.computer;
            tbLogin.Text = g.login;
            tbApplication.Text = g.application;
            tbPrinter.Text = g.printer;
            tbLocation.Text = g.location;
            cbZPL.Checked = g.ZPL;
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);

            SqlCommand cmd = new SqlCommand();

            SqlParameter pPCID = new SqlParameter
               ("@PCID", SqlDbType.NChar);
            if (tbComputer.Text.Length > 0)
            {
                pPCID.Value = tbComputer.Text.Trim();
            }

            SqlParameter pUserName = new SqlParameter
               ("@userName", SqlDbType.NChar);
            if (tbLogin.Text.Length > 0)
            {
                pUserName.Value = tbLogin.Text.Trim();
            }
            else
            {
                pUserName.Value = "";
            }

            SqlParameter pApplication = new SqlParameter
               ("@application", SqlDbType.NChar);
            if (tbApplication.Text.Length > 0)
            {
                pApplication.Value = tbApplication.Text.Trim();
            }
            else
            {
                MessageBox.Show("Must have an application");
                return;
            }

            SqlParameter pPermissionValue = new SqlParameter
               ("@permissionValue", SqlDbType.NChar);
            if (tbPrinter.Text.Length > 0)
            {
                pPermissionValue.Value = tbPrinter.Text.Trim();
            }

            SqlParameter pLocation = new SqlParameter
               ("@location", SqlDbType.NChar);
            if (tbLocation.Text.Length > 0)
            {
                pLocation.Value = tbLocation.Text.Trim();
            }
            else
            {
                pLocation.Value = "";
            }

            if (g.task == "EDIT")
            {
                SQL = "UPDATE ApplicationSetup SET " +
                    "PCID = " + pPCID +
                    " ,UserName = " + pUserName +
                    " ,Application = " + pApplication +
                    " ,PermissionValue = " + pPermissionValue +
                    " ,Location = " + pLocation +
                    " ,ZPL = '" + g.ZPL + "'" +
                    " WHERE ID = " + g.ID;
            }

            if (g.task == "ADD")
            {
                SQL = "INSERT INTO ApplicationSetup " +
                    "( " +
                    "  PCID " +
                    " ,UserName " +
                    " ,Application " +
                    " ,PermissionValue " +
                    " ,Location " +
                    ",Permission " +
                    ",ZPL " +
                    ") values (" +
                    pPCID +
                    "," + pUserName +
                    " ," + pApplication +
                    " ," + pPermissionValue +
                    " ," + pLocation + 
                    ", 'PRINTER'" +
                    ",'" + g.ZPL + "' )";
                    
            }
            cmd = new SqlCommand(SQL, cnxn);
            
            cmd.Parameters.Add(pPCID);
            cmd.Parameters.Add(pUserName);
            cmd.Parameters.Add(pApplication);
            cmd.Parameters.Add(pPermissionValue);
            cmd.Parameters.Add(pLocation);

            try
            {
                cnxn.Open();
                int row = cmd.ExecuteNonQuery();

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
                cmd.Parameters.Clear();
            }

            g.computer = string.Empty;
            g.login = string.Empty;
            g.application = string.Empty;
            g.printer = string.Empty;
            g.location = string.Empty;
            g.ZPL = false;
            this.Close();
        }

        private void cbZLP_CheckedChanged(object sender, EventArgs e)
        {
            if(cbZPL.Checked)
            {
                g.ZPL = true;
            }
            else
            {
                g.ZPL= false;
            }
        }
    }
}
