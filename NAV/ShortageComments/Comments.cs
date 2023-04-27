using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ShortageComments
{
    public partial class Comments : Form
    {
        private string ShortageID;
        SqlConnection cnxn;
        SqlDataAdapter da;
        private string db = "server = CT-MID-SQL01; password = Read+Write!; " +
                            "user = readwrite; database = AccessFrontEnds;";
        private int fontSize = 7;
        private string UserName;


        public Comments()
        {
            InitializeComponent();
        }

        private void Comments_Load(object sender, EventArgs e)
        {
            System.Security.Principal.WindowsIdentity user;
            user = System.Security.Principal.WindowsIdentity.GetCurrent();

            UserName = user.Name.Substring(8, user.Name.Length - 8);

            DGV.RowsDefaultCellStyle.Font = new Font("Tahoma", fontSize);

            foreach (string arg in Environment.GetCommandLineArgs())
            {
                ShortageID = arg;
            }

            //ShortageID = "28997";

            cnxn = new SqlConnection(db);

            try
            {
                da = new SqlDataAdapter(
                    "select " +
                    "comment, " +
                    "enteredby, " + 
                    "enteredon " +
                    "from ShortageListComments  " +
                    "WHERE ShortageID = " + ShortageID + 
                    "ORDER BY COMMENTID DESC"
                    , cnxn);

                DataTable table = new DataTable();
                da.Fill(table);

                DGV.DataSource = table;
                DGV.Show();
                DGV.Columns[0].Width = 300;
                DGV.Columns[1].Width = 100;
                DGV.Columns[2].Width = 100;

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

        private void bAdd_Click(object sender, EventArgs e)
        {

            cnxn.Open();

            SqlParameter sComment = new SqlParameter("@comment", SqlDbType.VarChar);
            sComment.Value = tbComment.Text.Trim();

            SqlCommand cmd = new SqlCommand(
                "Insert into ShortageListComments (" +
                "ShortageID " +
                ",Comment " +
                ",EnteredBy " +
                ") values (" +
                ShortageID + "," +
                sComment + ",'" +
                UserName + "'" +
                ")", cnxn);

            cmd.Parameters.Add(sComment);

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
                cnxn.Close();
                cmd.Parameters.Clear();
            }

        }
    }
}
