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

namespace ViewRicToolRoom
{
    public partial class JobData : Form
    {
        SqlConnection cnxn;
        SqlCommand cmd;
        SqlDataReader dr;
        private string xtract = @"C:\pm\xtract.pdf";
        private string dxtract = @"C:\pm\";
        private bool requestCompleted;
        private double FabHours;
        private double DesignHours;

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

            dtpEstimatedDueDate.ShowCheckBox = true;
            dtpEstimatedDueDate.Checked = false;
            dtpCompletionDate.ShowCheckBox = true;
            dtpCompletionDate.Checked = false;

            GetData();
        }

        private void bOpenPDF_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process pdfReader = new System.Diagnostics.Process();

            cmd = new SqlCommand
                ("Select uploaded_pdf from richmond_tool_requests where id = '" + g.ID + "' and uploaded_pdf is not null", cnxn);
            cnxn.Open();
            object o = cmd.ExecuteScalar();
            cnxn.Close();
            if (o != null)
            {
                cmd = new SqlCommand
                    ("Select uploaded_pdf from richmond_tool_requests where id = '" + g.ID + "' and uploaded_pdf is not null", cnxn);
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

                    pdfReader.StartInfo.UseShellExecute = false;
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

                if (tbComments.Text.Length < 1)
                {
                    MessageBox.Show("Must enter a Comment when completing job.");
                    tbComments.Focus();
                    return;
                }
            }
            else
            {
                requestCompleted = false;
                dtpCompletionDate.Value = DateTime.Now;
                dtpCompletionDate.Checked = false;
            }

            if (Double.TryParse(tbFabTime.Text, out FabHours))
            {

            }
            else
            {
                tbFabTime.Text = "";
                MessageBox.Show("Must enter a number for Fab Time.");
                tbFabTime.Focus();
                return;
            }

            if (Double.TryParse(tbDesignTime.Text, out DesignHours))
            {

            }
            else
            {
                tbDesignTime.Text = "";
                MessageBox.Show("Must enter a number for Design Time.");
                tbDesignTime.Focus();
                return;
            }

            
            SqlParameter pComments = new SqlParameter("@comments", SqlDbType.VarChar, 4000);
            pComments.Value = tbComments.Text.Trim();

            SqlParameter pEstimatedDueDate = new SqlParameter("@estimatedDueDate", SqlDbType.Date);
            if (dtpEstimatedDueDate.Checked)
            {
                pEstimatedDueDate.Value = dtpEstimatedDueDate.Text.Trim();
            }
            else
            {
                pEstimatedDueDate.Value = "01-01-1900";
            }

            SqlParameter pJob = new SqlParameter("@job", SqlDbType.VarChar, 30);
            pJob.Value = tbJob.Text.Trim();

            SqlParameter pCode = new SqlParameter("@code", SqlDbType.VarChar, 30);
            pCode.Value = tbCode.Text.Trim();

            SqlParameter pNumber = new SqlParameter("@number", SqlDbType.VarChar, 30);
            pNumber.Value = tbNumber.Text.Trim();

            SqlParameter pToolDescription = new SqlParameter("@toolDescription", SqlDbType.VarChar, 50);
            pToolDescription.Value = tbToolDescription.Text.Trim();

            SqlParameter pDesigner = new SqlParameter("@designer", SqlDbType.VarChar, 30);
            pDesigner.Value = tbDesigner.Text.Trim();

            SqlParameter pMachinist = new SqlParameter("@machinist", SqlDbType.VarChar, 50);
            pMachinist.Value = tbMachinist.Text.Trim();

            SqlParameter pDesignReviewParticipants = new SqlParameter("@designReviewParticipants", SqlDbType.VarChar, 500);
            pDesignReviewParticipants.Value = tbDesignReviewParticipants.Text.Trim();


            SqlParameter pCompletiondDate = new SqlParameter("@completionDate", SqlDbType.Date);
            if (dtpCompletionDate.Checked)
            {
                pCompletiondDate.Value = dtpCompletionDate.Text.Trim();
            }
            else
            {
                pCompletiondDate.Value = "01-01-1900";
            }


            try
            {

                SqlCommand cmd = new SqlCommand(
                    "Update Richmond_Tool_Requests SET " +
                    " request_completed = '" + requestCompleted + "'" +
                    ",completion_date = '" + dtpCompletionDate.Value + "'" +
                    ",comments = " + pComments +
                    ",[Estimated Fab Time (hrs)] = " + FabHours +
                    ",[Estimated Design Time (hrs)] = " + DesignHours +
                    ",[Estimated Due Date] = " + pEstimatedDueDate +
                    ",[Job] = " + pJob +
                    ",[Code] = " + pCode +
                    ",[Number] = " + pNumber +
                    ",ToolDescription = " + pToolDescription +
                    ",Designer = " + pDesigner +
                    ",Machinist = " + pMachinist +
                    ",DesignReviewParticipants = " + pDesignReviewParticipants +
                    ",[Status] = '" + cbddStatus.Text.Trim() + "'" +
                    " WHERE ID = " + g.ID + " ", cnxn); ;

                cnxn.Open();

                cmd.Parameters.Add(pComments);
                cmd.Parameters.Add(pEstimatedDueDate);
                cmd.Parameters.Add(pJob);
                cmd.Parameters.Add(pCode);
                cmd.Parameters.Add(pNumber);
                cmd.Parameters.Add(pToolDescription);
                cmd.Parameters.Add(pDesigner);
                cmd.Parameters.Add(pMachinist);
                cmd.Parameters.Add(pDesignReviewParticipants);

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
                ("Select uploaded_dxf from richmond_tool_requests where id = '" + g.ID + "' and uploaded_dxf is not null", cnxn);
            cnxn.Open();
            object o = cmd.ExecuteScalar();
            cnxn.Close();
            if (o != null)
            {
                cmd = new SqlCommand
                    ("Select uploaded_dxf from richmond_tool_requests where id = '" + g.ID + "' and uploaded_dxf is not null", cnxn);
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
                       
            cmd = new SqlCommand(
                "Select " + 
          /*0*/ " request_text " + 
                ",AdditionalInformation " + 
                ",uploaded_pdf" + 
                ",uploaded_dxf" + 
                ",uploaded_filename" + 
          /*5*/ ",[Status] " + 
                ",[Estimated Fab Time (hrs)] " + 
                ",[Estimated Design Time (hrs)] " +
                ",[Estimated Due Date] " +
                ",[Job] " +
          /*10*/",[Code] " +
                ",[Number] " +
                ",[ToolDescription] " +
                ",Designer " +
                ",Machinist " +
          /*15*/",TechnicalContactName " +
                ",DesignReviewParticipants " +
                ",Comments " +
                ", CASE Request_Completed " +
                "  WHEN 1 THEN 'TRUE' " +
                "  ELSE 'FALSE' " +
                "End Request_Completed " +
               ",Completion_Date " +
                "from RICHMOND_tool_requests where " +
                "id = " + g.ID + " ", cnxn);

            try
            {
                DataTable table = new DataTable();

                cnxn.Open();
                dr = cmd.ExecuteReader();

                table.Load(dr);
                                
                    tbRequest.Text = table.Rows[0][0].ToString();
                
                if (table.Rows[0][1].ToString().Length > 0)
                {
                    tbAdditionalInformation.Text = table.Rows[0][1].ToString();
                }

                if (table.Rows[0][2].ToString().Length > 0)
                {
                    bOpenPDF.Visible = true;
                }

                if (table.Rows[0][3].ToString().Length > 0)
                {
                    BOpenDxf.Visible = true;
                }

                if (table.Rows[0][4].ToString().Length > 0)
                {
                    dxtract = dxtract + table.Rows[0][4].ToString();
                }

                if (table.Rows[0][5].ToString().Length > 0)
                {
                    cbddStatus.Text = table.Rows[0][5].ToString();
                }

                if (table.Rows[0][6].ToString().Length > 0)
                {
                    tbFabTime.Text = table.Rows[0][6].ToString();
                }

                if (table.Rows[0][7].ToString().Length > 0)
                {
                    tbDesignTime.Text = table.Rows[0][7].ToString();
                }

                if (table.Rows[0][8].ToString().Length > 0)
                {
                    dtpEstimatedDueDate.Text = table.Rows[0][8].ToString();
                }

                if (table.Rows[0][9].ToString().Length > 0)
                {
                    tbJob.Text = table.Rows[0][9].ToString();
                }

                if (table.Rows[0][10].ToString().Length > 0)
                {
                    tbCode.Text = table.Rows[0][10].ToString();
                }

                if (table.Rows[0][11].ToString().Length > 0)
                {
                    tbNumber.Text = table.Rows[0][11].ToString();
                }


                if (table.Rows[0][12].ToString().Length > 0)
                {
                    tbToolDescription.Text = table.Rows[0][12].ToString();
                }

                if (table.Rows[0][13].ToString().Length > 0)
                {
                    tbDesigner.Text = table.Rows[0][13].ToString();
                }

                if (table.Rows[0][14].ToString().Length > 0)
                {
                    tbMachinist.Text = table.Rows[0][14].ToString();
                }

                if (table.Rows[0][15].ToString().Length > 0)
                {
                    tbTechnicalContactName.Text = table.Rows[0][15].ToString();
                }

                if (table.Rows[0][16].ToString().Length > 0)
                {
                    tbDesignReviewParticipants.Text = table.Rows[0][16].ToString();
                }

                if (table.Rows[0][17].ToString().Length > 0)
                {
                    tbComments.Text = table.Rows[0][17].ToString();
                }

                if (table.Rows[0][18].ToString() == "TRUE")
                {
                    cbCompleted.Checked = true;
                }
                else
                {
                    cbCompleted.Checked = false;
                }

                if (table.Rows[0][19].ToString().Length > 0)
                {
                    dtpCompletionDate.Text = table.Rows[0][19].ToString();
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
            if (tbComments.Text.Length > 0)
            {
                SqlParameter pComments = new SqlParameter("@comments", SqlDbType.VarChar, 4000);
                pComments.Value = tbComments.Text.Trim();

                try
                {

                    SqlCommand cmd = new SqlCommand(
                        "Update Richmond_Tool_Requests  set " +
                        "request_completed = 'true' " +
                        ",Rejected = 'true' " +
                        ", completion_date = GETDATE() " +
                        ", comments = " + pComments +
                        " where id = " + g.ID + " ", cnxn);

                    cnxn.Open();

                    cmd.Parameters.Add(pComments);

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
            }
            else
            {
                MessageBox.Show("Must have an explanation in the comments box");
                tbComments.Focus();
                return;
            }

            this.Close();
        }
    }
}
