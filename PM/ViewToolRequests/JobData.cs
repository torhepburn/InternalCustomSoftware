using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace ViewToolRequests
{
    public partial class JobData : Form
    {
        SqlConnection cnxn;
        private string xtract = @"C:\pm\xtract.pdf";
        private string dxtract = @"C:\pm\";
        private bool requestCompleted;
        private double hours;

        public JobData()
        {
            InitializeComponent();
        }

        private void JobData_Load(object sender, EventArgs e)
        {
            LID.Text = "Tool Room Request ID #  " + g.ID;

            if (g.permission == "VIEW")
            {
                bEditRequest.Visible = false;
                Benter.Visible = false;
                Breject.Visible = false;
            }

            GetData();
        }

        private void bOpenPDF_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process pdfReader = new System.Diagnostics.Process();

            SqlCommand cmd = new SqlCommand
                ("Select uploaded_pdf from tool_requests where id = '" + g.ID + "' and uploaded_pdf is not null", cnxn);
            cnxn.Open();
            object o = cmd.ExecuteScalar();
            cnxn.Close();
            if (o != null)
            {
                cmd = new SqlCommand
                    ("Select uploaded_pdf from tool_requests where id = '" + g.ID + "' and uploaded_pdf is not null", cnxn);
                cnxn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    // read in using GetValue and cast to byte array
                    byte[] xData = (byte[])dr.GetValue(0);

                    // write bytes to disk as file
                    FileStream fs1 = new FileStream
                        (xtract, FileMode.Create, FileAccess.ReadWrite);
                    BinaryWriter bw = new BinaryWriter(fs1);
                    bw.Write(xData);
                    bw.Close();

                    pdfReader = System.Diagnostics.Process.Start(xtract);
                }
                dr.Close();
                cnxn.Close();

            }
            else
            {
                MessageBox.Show("No pdf documents were attached.");
            }
        }

        private void Benter_Click(object sender, EventArgs e)
        {
            if (cbCompleted.Checked)
            {
                requestCompleted = true;
            }
            else
            {
                requestCompleted = false;
            }

            if (tbHours.Text.Length < 1)
            {
                MessageBox.Show("Must enter hours worked.");
                tbHours.Focus();
                return;
            }
            else
            {
                if (Double.TryParse(tbHours.Text, out hours))
                {
                    
                }
                else
                {
                    tbHours.Text = "";
                    MessageBox.Show("Must enter a number.");
                    tbHours.Focus();
                    return;
                }
            }

            try
            {

                SqlCommand cmd = new SqlCommand(
                    "Update Tool_Requests  set " +
                    "request_completed = '" + requestCompleted +
                    "', completion_date = '" + dtpCompletionDate.Value +
                    "', actual_hours = " + hours +
                    ", comments = '" + tbComments.Text.Trim() +
                    "', Savings = '" + cbSavings.Checked + 
                    "', [type] = '" + cbddType.Text.Trim() + 
                    "' where id = " + g.ID + " ", cnxn);

                cnxn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            this.Close();

        }

        private void Bexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BOpenDxf_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand
                ("Select uploaded_dxf from tool_requests where id = '" + g.ID + "' and uploaded_dxf is not null", cnxn);
            cnxn.Open();
            object o = cmd.ExecuteScalar();
            cnxn.Close();
            if (o != null)
            {
                cmd = new SqlCommand
                    ("Select uploaded_dxf from tool_requests where id = '" + g.ID + "' and uploaded_dxf is not null", cnxn);
                cnxn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    // read in using GetValue and cast to byte array
                    byte[] xData = (byte[])dr.GetValue(0);

                    // write bytes to disk as file
                    FileStream fs1 = new FileStream
                        (dxtract, FileMode.Create, FileAccess.ReadWrite);
                    BinaryWriter bw = new BinaryWriter(fs1);
                    bw.Write(xData);
                    bw.Close();
                }
                dr.Close();
                cnxn.Close();

                System.Diagnostics.Process openDXF = new System.Diagnostics.Process();

                openDXF = System.Diagnostics.Process.Start(dxtract);
                //OpenFileDialog ofd = new OpenFileDialog();
                //ofd.InitialDirectory = "C:\\PM\\";
                //ofd.ShowDialog();
            }
            else
            {
                MessageBox.Show("No dxf documents were attached.");
            }
        }

        private void bEditRequest_Click(object sender, EventArgs e)
        {
            EditRequest r = new EditRequest();
            r.ShowDialog();
            GetData();
        }

        private void GetData()
        {
            cnxn = new SqlConnection(g.db);

            SqlDataAdapter da = new SqlDataAdapter(
                "Select " +
                "request_text " +
                ",actual_hours " +
                ",savings" +
                ",uploaded_pdf" +
                ",uploaded_dxf" +
                ",uploaded_filename" +
                ",[type]" +
                ",comments from tool_requests where " +
                "id = " + g.ID + " ", cnxn);

            try
            {
                DataTable table = new DataTable();
                da.Fill(table);
                {
                    tbRequest.Text = table.Rows[0][0].ToString();
                    tbHours.Text = table.Rows[0][1].ToString();

                    if (table.Rows[0][2].ToString() == "True")
                    {
                        cbSavings.Checked = true;
                    }
                    else
                    {
                        cbSavings.Checked = false;
                    }

                    if (table.Rows[0][3].ToString().Length > 0)
                    {
                        bOpenPDF.Visible = true;
                    }

                    if (table.Rows[0][4].ToString().Length > 0)
                    {
                        BOpenDxf.Visible = true;
                    }

                    if (table.Rows[0][5].ToString().Length > 0)
                    {
                        dxtract = dxtract + table.Rows[0][5].ToString();
                    }

                    if (table.Rows[0][6].ToString().Length > 0)
                    {
                        cbddType.Text = table.Rows[0][6].ToString();
                    }

                    if (table.Rows[0][7].ToString().Length > 0)
                    {
                        tbComments.Text = table.Rows[0][7].ToString();
                    }

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
        }

        private void Breject_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(
                    "Update Tool_Requests  set " +
                    "request_completed = 'true' " +
                    ",Rejected = 'true' " +
                    ", completion_date = GETDATE() " +
                    ", [type] = '" + cbddType.Text.Trim() +
                    "', comments = '" + tbComments.Text.Trim() +
                    "' where id = " + g.ID + " ", cnxn);

                cnxn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            this.Close();
        }
    }
}
