using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Certs
{
    public partial class AddNewCopy : Form
    {
        public AddNewCopy()
        {
            InitializeComponent();
        }

        private void AddNewCopy_Load(object sender, EventArgs e)
        {

        }

        private void bNew_Click(object sender, EventArgs e)
        {
            newNumber();

            if (g.rpt_type == "CAL")
            {
                EditCalibrationCert b = new EditCalibrationCert();
                b.ShowDialog();
            }

            if (g.rpt_type == "COM")
            {
                AddEditCompliance b = new AddEditCompliance();
                b.ShowDialog();
            }

        }

        private void bCopy_Click(object sender, EventArgs e)
        {
            newNumber();
            g.subtask = "COPY";
            SelectCert b = new SelectCert();
            b.ShowDialog();

        }

        private void newNumber()
        {
            SqlConnection cnxn = new SqlConnection(g.db);

            string SQL = "INSERT INTO " + g.dbTable +
                            "([Type]) VALUES ('" +
                            g.rpt_type + "')" +
                            " SET @ID = SCOPE_IDENTITY() ";

            SqlParameter pInsertID = new SqlParameter("@ID", SqlDbType.Int);
            pInsertID.Direction = ParameterDirection.Output;

            SqlCommand cmd = new SqlCommand(SQL, cnxn);

            cmd.Parameters.Add(pInsertID);

            try
            {
                cnxn.Open();
                cmd.ExecuteNonQuery();
                g.newCertNumber = pInsertID.Value.ToString();
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
        }
    }
}
