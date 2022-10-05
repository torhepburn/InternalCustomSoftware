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
using System.IO;

namespace CertsRevC
{
    public partial class Form1 : Form
    {
        SqlDataAdapter da;
        SqlConnection cnxn;
        DataTable table;
        SqlCommand cmd;
        private string imageSQL;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
       

       this.Text = "Step Height Certs v" + Application.ProductVersion;

            //cnxn = new SqlConnection(g.db);
            //da = new SqlDataAdapter
            //  ("Select parent_item_code [Part Number], Parent_item_desc [Description], " +
            //   "IIF(Model is null, '-', model) Model, " +
            //   "IIF(Hertz is null, '-', hertz) Hertz, " +
            //   "IIF(Volts is null, '-', volts) Volts, " +
            //   "IIF(Amps is null, '-', amps) Amps " +
            //   "from labels.IDsnLabels " +
            //   "where begin_item_code = '1000-1041-05' " +
            //   "and parent_item_code = '6311-0100-11' " +
            //   "order by parent_item_code", cnxn);

            //GetData();
        }

        private void GetData()
        {
            //table = new DataTable();
            //da.Fill(table);
            //DGV.DataSource = table;
            //DGV.Columns[0].Width = 120;
            //DGV.Columns[1].Width = 250;

            //DGV.Show();
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex == -1 && e.ColumnIndex < 2)
            //{
            //    return;
            //}
            //else
            //{
            //    DataGridViewTextBoxCell cell =
            //        (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
            //    g.certificationNumber = cell.EditedFormattedValue.ToString().Trim();


            //    F0281_03_Step_Height s = new F0281_03_Step_Height();
            //    s.ShowDialog();
            //}
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            //cnxn = new SqlConnection(g.db);
            //da = new SqlDataAdapter
            //  ("Select parent_item_code [Part Number], Parent_item_desc [Description], " +
            //   "IIF(Model is null, '-', model) Model, " +
            //   "IIF(Hertz is null, '-', hertz) Hertz, " +
            //   "IIF(Volts is null, '-', volts) Volts, " +
            //   "IIF(Amps is null, '-', amps) Amps " +
            //   "from labels.IDsnLabels " +
            //   "where begin_item_code = '1000-1041-05' " +
            //   " and (parent_item_code like '%" + tbSearchEquipment.Text + "%' " +
            //   "or parent_item_desc like '%" + tbSearchEquipment.Text + "%' )" +
            //   "order by parent_item_code", cnxn);

            //GetData();
        }

        private void bItem_Click(object sender, EventArgs e)
        {
            g.certificationNumber = tbSearchEquipment.Text.ToString().Trim().ToUpper();
            tbSearchEquipment.Text = "";

            string select = "Select [Certification #] from cc_cofc " +
                " where [Certification #] = '" + g.certificationNumber + "' ";
            SqlCommand cmd = new SqlCommand(select, cnxn);
            cnxn = new SqlConnection(g.db);
            cmd.Connection = cnxn;
            cnxn.Open();
            object o = cmd.ExecuteScalar();

            if (o == null)
            {
                MessageBox.Show("This item does not exist.");
                tbSearchEquipment.Focus();
            }
            else
            {
                cnxn = new SqlConnection(g.db);
                da = new SqlDataAdapter
                  (select, cnxn);

                table = new DataTable();
                da.Fill(table);

                g.certificationNumber = table.Rows[0][0].ToString();


                select = "Select TestImage FROM cc_Image " +
                " where [CertificationNumber] = '" + g.certificationNumber + "'";
                cmd = new SqlCommand(select, cnxn);
                cnxn.Open();
                object oo = cmd.ExecuteScalar();

                if (oo != null)
                {
                    var result = MessageBox.Show("Previously loaded file will be used. " +
                    "\n\n             Reload file ?", "Choices", MessageBoxButtons.YesNoCancel);

                    if (result == DialogResult.No)
                    {
                        F0281_03C s = new F0281_03C();
                        s.ShowDialog();
                    }
                    else if (result == DialogResult.Yes)
                    {
                        imageSQL = "reload";
                        upLoadFile();

                        F0281_03C s = new F0281_03C();
                        s.ShowDialog();

                    }
                    else if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Need to upload image file.");

                    imageSQL = "upload";
                    upLoadFile();

                    F0281_03C s = new F0281_03C();
                    s.ShowDialog();

                    /*
                    cnxn = new SqlConnection(g.db);
                    cmd = new SqlCommand
                        ("Select " + pdf + "pdf from calibrationdata " +
                         " where id = '" + g.cdID + "' ", cnxn);

                    cnxn.Open();
                    object o = cmd.ExecuteScalar();
                    if (o != null)
                    {
                        DialogResult result;
                        result = MessageBox.Show(" PDF created.");
                    }
                    cnxn.Close();
                    */

                }

            }



            //g.description = table.Rows[0][1].ToString();

            //g.model = table.Rows[0][2].ToString();

            //g.hertz = table.Rows[0][3].ToString();

            //g.volts = table.Rows[0][4].ToString();

            //g.amps = table.Rows[0][5].ToString();

            //Form_325B s = new Form_325B();
            //F0281_03_Step_Height s = new F0281_03_Step_Height();
            //F0281_03C s = new F0281_03C();
            //s.ShowDialog();

            this.Close();
        }

        private void upLoadFile()
        {
            openFileDialog1.InitialDirectory = @"\\zygocorp\departments\quality\" +
                        @"ISO_17025\Records\Technical_Records\Saved Certifications\";
            openFileDialog1.Filter = ("png files only (*.png)|*.png");
            openFileDialog1.ShowDialog();
            string filepath = openFileDialog1.FileName;

            if (filepath == "openFileDialog1")
            {
                return;
            }
            else
            {
                FileStream fs = new FileStream
                    (filepath, FileMode.Open, FileAccess.Read);

                // store the file in an array the lenght of the file
                byte[] fileData = new byte[fs.Length];

                // read the file stream to the array
                fs.Read(fileData, 0, Convert.ToInt32(fs.Length));

                SqlConnection cnxn = new SqlConnection(g.db);
                SqlParameter prm1 = new SqlParameter
                    ("@file", SqlDbType.Image, Convert.ToInt32(fs.Length));
                prm1.Value = fileData;

                if (imageSQL == "upload")
                {
                    imageSQL = "INSERT INTO CC_Image (TestImage, CertificationNumber) " +
                     "values (" + prm1 + "," + g.certificationNumber + ") ";
                }
                else if (imageSQL == "reload")
                {
                    imageSQL = "UPDATE CC_Image SET TestImage = " + prm1 + " WHERE " +
                    " certificationNumber = " + g.certificationNumber + " ";
                }



                cmd = new SqlCommand
                    (imageSQL
                     , cnxn);
                cmd.Parameters.Add(prm1);
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
                    cnxn.Close();
                    fs.Close();
                    // close the file stream
                }
            }

        }

       
    }

    public static class g
    {
        public static string certificationNumber;
        public static string description;
        public static string hertz;
        public static string volts;

        public static string amps;
        public static string model;
        public static bool freeText;
        /*  for Taiwan using local printer  */
        //public static string printer = "zebra2.25x1.25";
        //public static string printer = "\\\\midprtsrv\\zebrasn20";
        //public static string Ldescription;
        //public static string room;
        //public static string Rdescription;
        //public static string Rnotes;
        //public static int rID;
        //public static string eBadgeID;
        //public static string iID;
        //public static string iDescription;
        //public static int internalCalContact;
        //public static int cdID;                 //calibration data id
        //public static string rpt_status;
        //public static string rpt_CalSource;
        //public static string rpt_earliestDueDate;
        //public static string rpt_latestDueDate;
        //public static string rpt_room;
        //public static string rpt_type;
        //public static string pdf;
        public static string db = "server = CT-MID-SQL11; password = Read+Write!; " +
                                  "user = readwrite; database = AccessFrontEnds;";
        //public static string dbDash = "[middb01].dashboard.dbo.view_employees";
        //public static string dbDashserver = "server = middb01; password = views; " +
        //                          "user = views; database = dashboard;";
    }
}
