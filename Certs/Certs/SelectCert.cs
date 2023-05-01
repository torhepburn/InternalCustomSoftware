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
using System.Drawing.Printing;

namespace Certs
{
    public partial class SelectCert : Form
    {
        SqlDataReader dr;
        SqlConnection cnxn;
        DataTable table;
        SqlCommand cmd;
        private string imageSQL;
        private int linedrop = 130;
        private int lineNo = 0;

        public SelectCert()
        {
            InitializeComponent();
        }

        private void SelectCert_Load(object sender, EventArgs e)
        {
            if (g.task == "VIEW")
            {
                gbType.Visible = true;
                BPrint.Visible = true;
            }

            if (g.rpt_type == "COM")
            {
                cbISO17025.Visible = false;
            }

            if (g.rpt_type == "CAL")
            {
                cbISO17025.Visible = true;
            }


            if (g.ISO.Length > 0)
            {
                cbISO17025.Checked = true;
            }

            cnxn = new SqlConnection(g.db);

            GetData();
        }

        private void GetData()
        {
            string SQL =
                "SELECT " +
                " [Certification #] " +
                ",[Customer Name] " +
                ",[P/N] " +
                ",FORMAT([Test Date],'MM/dd/yyyy') " +
                ",[Type] " +
                ",[Serial #] " +
                " FROM " + g.dbTable +
                " WHERE 1=1 ";

            if ((g.rpt_type.Length) > 0)
            {
                SQL += "AND [Type] = '" + g.rpt_type + "'";
            }

            if ((g.ISO.Length) > 0)
            {
                SQL += g.ISO;
            }

            if (g.search.Length > 0)
            {
                SQL += g.search;
            }

            SQL += " ORDER BY [Certification #] ";

            cmd = new SqlCommand(SQL, cnxn);
            table = new DataTable();

            try
            {
                cnxn.Open();
                dr = cmd.ExecuteReader();

                table.Load(dr);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            DGV.DataSource = table;
            DGV.Columns[0].Width = 70;
            DGV.Columns[1].Width = 220;
            DGV.Columns[2].Width = 120;
            DGV.Columns[3].Width = 85;
            DGV.Columns[4].Width = 40;
            DGV.Columns[5].Width = 120;
            DGV.Show();
        }


        private void bSearch_Click(object sender, EventArgs e)
        {
            g.search = " and ([certification #] like '%" + tbSearch.Text + "%' " +
               "OR [Customer Name] like '%" + tbSearch.Text + "%' " +
               "OR [P/N] like '%" + tbSearch.Text + "%' " +
               "OR [Serial #] like '%" + tbSearch.Text + "%' )";

            GetData();
        }

        private void bItem_Click(object sender, EventArgs e)
        {

            if (System.Text.RegularExpressions.Regex.IsMatch(tbSearch.Text.ToString().Trim().ToUpper(), @"^\d+$"))
            {
                g.certificationNumber = tbSearch.Text.ToString().Trim().ToUpper();
                tbSearch.Text = "";

                action();
            }
            else
            {
                MessageBox.Show("Must enter a numnber");

                tbSearch.Text = string.Empty;
                tbSearch.Focus();
            }
        }

        private void action()
        {
            if (g.rpt_type.Length < 1)
            {
                MessageBox.Show("Must select Type of Certification ");
                gbType.Focus();
                return;
            }

            cmd = new SqlCommand("SELECT [type] " +
                         " FROM " + g.dbTable +
                         " WHERE [Certification #] = '" + g.certificationNumber + "'", cnxn);

            try
            {
                cnxn.Open();
                object t = cmd.ExecuteScalar();
                if (g.rpt_type != t.ToString().ToUpper())
                {
                    MessageBox.Show("Form and Type mismatch");
                    return;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            if (g.task == "PRINT")
            {
                if (g.rpt_type == "CAL")
                {   
                    if (g.form == "281-02")
                    {
                        F0281_02B f = new F0281_02B();
                        f.ShowDialog();
                        bSaveToFolder.Visible = true;
                    }

                    if (g.form == "281-03")     /*  Step Height  */
                    {
                        F281data();
                    }

                    if (g.form == "281-04")     /*  Reference Surface  */
                    {
                        F281data();
                    }
                }

                if (g.rpt_type == "COM")
                {
                    if (g.form == "325pdf")
                    {
                        FORM_325B2 b = new FORM_325B2();
                        b.ShowDialog();
                        bSaveToFolder.Visible = true;
                    }
                    else
                    {
                        FORM_325B1 f = new FORM_325B1();
                        f.ShowDialog();
                    }
                }
            }

            if (g.task == "EDIT" | g.task == "VIEW" | (g.task == "ADD" & g.subtask == "COPY"))
            {
                if (g.rpt_type == "CAL")
                {
                    EditCalibrationCert cl = new EditCalibrationCert();
                    cl.ShowDialog();
                }

                if (g.rpt_type == "COM")
                {
                    AddEditCompliance a = new AddEditCompliance();
                    a.ShowDialog();
                }
            }
        }



        private void F281data()
        {
            string select = "Select [Certification #] from " + g.dbTable +
                " where [Certification #] = '" + g.certificationNumber + "' ";
            SqlCommand cmd = new SqlCommand(select, cnxn);
            cnxn = new SqlConnection(g.db);
            cmd.Connection = cnxn;
            cnxn.Open();
            object o = cmd.ExecuteScalar();

            if (o == null)
            {
                MessageBox.Show("This item does not exist.");
                tbSearch.Focus();
            }
            else
            {
                cnxn = new SqlConnection(g.db);
                cmd = new SqlCommand(select, cnxn);

                table = new DataTable();

                try
                {
                    cnxn.Open();
                    dr = cmd.ExecuteReader();

                    table.Load(dr);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn.Close();
                }

                g.certificationNumber = table.Rows[0][0].ToString();


                select = "Select TestImage FROM " + g.dbImage +
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
                        specialCals();
                    }
                    else if (result == DialogResult.Yes)
                    {
                        imageSQL = "reload";
                        upLoadFile();

                        specialCals();
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

                    specialCals();
                }

            }

            //Form_325B s = new Form_325B();
            //F0281_03_Step_Height s = new F0281_03_Step_Height();
            //F0281_03C s = new F0281_03C();
            //s.ShowDialog();

            //this.Close();

        }
        
        private void specialCals()
        {
            
            if (g.form == "281-03")
            {
                F0281_03C s = new F0281_03C();
                s.ShowDialog();
                bSaveToFolder.Visible = true;
            }

            if (g.form == "281-04")
            {
                F0281_04A s = new F0281_04A();
                s.ShowDialog();
                bSaveToFolder.Visible = true;
            }
        }


        private void upLoadFile()
        {
            if (g.form == "281-03" )
            {
                openFileDialog1.InitialDirectory = @"\\zygocorp\departments\quality\" +
                            @"ISO_17025\Records\Technical_Records\Saved Certifications\";
            }

            if (g.form == "281-04")
            {
                openFileDialog1.InitialDirectory = @"C:\A\";
                //openFileDialog1.InitialDirectory = @"\\zygocorp\departments\quality\" +
                //            @"ISO_17025\Records\Technical_Records\Saved Certifications\";
            }
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
                    imageSQL = "INSERT INTO " + g.dbImage + " (TestImage, CertificationNumber) " +
                                             "values (" + prm1 + "," + g.certificationNumber + ") ";
                }
                else if (imageSQL == "reload")
                {
                    imageSQL = "UPDATE " + g.dbImage + " SET TestImage = " + prm1 + " WHERE " +
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

        private void rbValues()
        {
            if (rbCalibration.Checked)
            {
                g.rpt_type = "CAL";
            }


            if (rbCompliance.Checked)
            {
                g.rpt_type = "COM";
            }

            if (cbISO17025.Checked)
            {
                g.ISO = " AND iso17025 = 1 ";
            }
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rbValues();

            if (e.RowIndex == -1 && e.ColumnIndex < 2)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.certificationNumber = cell.EditedFormattedValue.ToString().Trim();
                                
                action();
            }


        }

        private void cbISO17025_CheckedChanged(object sender, EventArgs e)
        {
            if (cbISO17025.Checked)
            {
                g.ISO = g.ISO = " AND iso17025 = 1 ";
            }
            else
            {
                g.ISO = string.Empty;
            }
        }

        private void rbCalibration_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCalibration.Checked)
            {
                g.rpt_type = "CAL";
            }
        }

        private void rbCompliance_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCompliance.Checked)
            {
                g.rpt_type = "COM";
            }
        }

        private void BPrint_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.Landscape = false;
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;
            (ppd as Form).WindowState = FormWindowState.Maximized;
            ppd.ShowDialog();

            
            // try
            //{

            //    PrintDialog pDlg = new PrintDialog();
            //    // dialog box won't show without this line below.
            //    pDlg.UseEXDialog = true;
            //    pDlg.Document = pd;

            //    //pd.PrinterSettings.Collate = true;
            //    //pd.PrinterSettings.PrinterName = @"\\midprtsrv\inst_iR3235PS";
            //    //pd.PrinterSettings.PrinterName = @"\\midprtsrv\mktg_iRC3220PS";
            //    //pd.PrinterSettings.Copies = 2;
            //    if (pDlg.ShowDialog() == DialogResult.OK)
            //    {
            //        pd.Print();
            //    }
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            //finally
            //{

            //}
            

        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            /*
             * 
             *  PrintPage runs all the way to the bottom bracket "}"
             *  before evaluating if there is another page and
             *  then runs through again.
             * 
             */

            Font arial = new Font("arial", 10, FontStyle.Regular);
            Font smallarial = new Font("arial", 8, FontStyle.Regular);
            Font title = new Font("arial", 24, FontStyle.Bold);
            Font heading = new Font("arial", 10, FontStyle.Bold);
            Font topheading = new Font("arial", 12, FontStyle.Bold);
            Font leaders = new Font("arial", 9, FontStyle.Regular);
            Pen pen = new Pen(Color.Black);
            StringFormat alignR = new StringFormat();
            alignR.Alignment = StringAlignment.Far;

            if (table.Rows.Count > lineNo)
            {

                ev.Graphics.DrawString("Cert #", heading, Brushes.Black, 20, 100);
                ev.Graphics.DrawString("Customer Name", heading, Brushes.Black, 100, 100);
                ev.Graphics.DrawString("P/N", heading, Brushes.Black, 350, 100);
                ev.Graphics.DrawString("S/N", heading, Brushes.Black, 500, 100);
                ev.Graphics.DrawString("Test Date", heading, Brushes.Black, 650, 100);
                ev.Graphics.DrawString("Type", heading, Brushes.Black, 800, 100);

                for (int i = 0; i < 46 & lineNo < table.Rows.Count; i++)
                {
                    ev.Graphics.DrawString(table.Rows[lineNo][0].ToString(), arial, Brushes.Black, 20, linedrop);
                    ev.Graphics.DrawString(table.Rows[lineNo][1].ToString(), arial, Brushes.Black, 100, linedrop);
                    ev.Graphics.DrawString(table.Rows[lineNo][2].ToString(), arial, Brushes.Black, 350, linedrop);
                    ev.Graphics.DrawString(table.Rows[lineNo][5].ToString(), arial, Brushes.Black, 500, linedrop);
                    ev.Graphics.DrawString(table.Rows[lineNo][3].ToString(), arial, Brushes.Black, 650, linedrop);
                    ev.Graphics.DrawString(table.Rows[lineNo][4].ToString(), arial, Brushes.Black, 800, linedrop);
                    lineNo++;
                    lines();
                }

                if (table.Rows.Count > lineNo)
                {
                    ev.HasMorePages = true;
                    linedrop = 130;
                }
                else
                {
                    ev.HasMorePages = false;
                    lineNo = 0;
                    linedrop = 130;
                }
            }
        }

        private void lines()
        {
            linedrop = linedrop + 20;
        }

        private void SelectCert_Activated(object sender, EventArgs e)
        {
            if (g.subtask == "RETURN")
            {
                g.subtask = string.Empty;
                this.Close();
            }
            else
            {

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (g.form == "281-02")
            {
                System.Diagnostics.Process.Start("C:\\A\\Calibration " + g.certificationNumber + ".pdf");
                this.Visible = false;
            }

            if (g.form == "281-03")
            {
                System.Diagnostics.Process.Start("C:\\A\\StepHeight " + g.certificationNumber + ".pdf");
                this.Visible = false;
            }

            if (g.form == "281-04")
            {
                System.Diagnostics.Process.Start("C:\\A\\ReferenceSurface " + g.certificationNumber + ".pdf");
                this.Visible = false;
            }

            if (g.form == "325pdf")
            {
                System.Diagnostics.Process.Start("C:\\A\\Compliance " + g.certificationNumber + ".pdf");
                this.Visible = false;
            }
        }

        private void SelectCert_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                g.certificationNumber = string.Empty;
                g.search = string.Empty;
                g.subtask = string.Empty;
            }
        }
    }
}
