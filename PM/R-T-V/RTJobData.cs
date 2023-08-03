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

namespace R_T_V
{
    public partial class RTJobData : Form
    {
        SqlConnection cnxn;
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dtComments;
        private string xtract = @"C:\pm\xtract.pdf";
        private string dxtract = @"C:\pm\";
        private bool requestCompleted;
        private double FabHours;
        private double DesignHours;
        private string requestor_Email;
        private string technicalContactEmail;
        private string emailBody;

        public RTJobData()
        {
            InitializeComponent();
        }

        private void RTJobData_Load(object sender, EventArgs e)
        {
            LID.Text = "Design Request ID #  " + g.ID;

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

            GetComments();

        }

        private void GetComments()
        {
            //    COMMENTS

            //dtComments = new DataTable();

            try
            {
                string SQL = " SELECT " +
                    "  RTRIM(Comment) Comment " +
                    " ,RTRIM(EnteredBy) as [by] " +
                    " ,EnteredOn AS [Date of Change] " +
                    " FROM RIC.DesignComments " +
                    " WHERE RequestID = " + g.ID +
                    " ORDER BY CommentID  DESC";

                if (cnxn.State == ConnectionState.Closed)
                {
                    cnxn.Open();
                }

                cmd = new SqlCommand(SQL, cnxn);
                cmd.CommandTimeout = 30;

                dr = cmd.ExecuteReader();

                dtComments = new DataTable();
                dtComments.Load(dr);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            DGV.DataSource = dtComments;
            DGV.Show();
            DGV.Columns[0].MinimumWidth = 400;
            DGV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DGV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

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

            SqlParameter pUser = new SqlParameter("@user", SqlDbType.VarChar, 50);

            if (tbComments.Text.Length > 500)
            {
                    MessageBox.Show("Exceeded Maximum Allowed Comment Length of 500.");
                    tbComments.Focus();
                    return;
                
            }


            SqlParameter pComments = new SqlParameter("@comments", SqlDbType.VarChar, 4000);
            
            if (tbComments.Text.Length > 0)
            {
                pUser.Value = g.user;
                pComments.Value = tbComments.Text.Trim();

                try
                {
                    SqlCommand cmd = new SqlCommand
                        ("Insert into RIC.DesignComments (" +
                            " RequestID " +
                            ",Comment " +
                            ",EnteredBy " +
                            ",EnteredOn " +
                            ") values (" +
                          g.ID.ToString().Trim() +
                          "," + pComments +
                          "," + pUser +
                          ",GETDATE() " +
                          ")", cnxn);

                    cmd.Parameters.Add(pComments);
                    cmd.Parameters.Add(pUser);

                    if (cnxn.State == ConnectionState.Closed)
                    {
                        cnxn.Open();
                    }

                    cmd.CommandTimeout = 30;
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
                    tbComments.Text = "";
                }
            }
            

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

            SqlParameter pTechnicalContact = new SqlParameter("@TechnicalContact", SqlDbType.VarChar, 50);
            pTechnicalContact.Value = tbTechnicalContactName.Text.Trim();

            SqlParameter pTechnicalContactEmail = new SqlParameter("@TechnicalContactEmail", SqlDbType.VarChar, 50);
            pTechnicalContactEmail.Value = tbTechnicalContactEmail.Text.Trim();

            SqlParameter pDesignReview1 = new SqlParameter("@DesignReview1", SqlDbType.VarChar, 50);
            pDesignReview1.Value = tbDesignReview1.Text.Trim();

            SqlParameter pDesignReview2 = new SqlParameter("@DesignReview2", SqlDbType.VarChar, 50);
            pDesignReview2.Value = tbDesignReview2.Text.Trim();

            SqlParameter pDesignReview3 = new SqlParameter("@DesignReview3", SqlDbType.VarChar, 50);
            pDesignReview3.Value = tbDesignReview3.Text.Trim();

            SqlParameter pDesignReview4 = new SqlParameter("@DesignReview4", SqlDbType.VarChar, 50);
            pDesignReview4.Value = tbDesignReview4.Text.Trim();
            
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
                    "Update Ric.designRequests SET " +
                    " request_completed = '" + requestCompleted + "'" +
                    ",completion_date = '" + dtpCompletionDate.Value + "'" +
                    ",[Estimated Fab Time (hrs)] = " + FabHours +
                    ",[Estimated Design Time (hrs)] = " + DesignHours +
                    ",[Estimated Due Date] = " + pEstimatedDueDate +
                    ",[Job] = " + pJob +
                    ",[Code] = " + pCode +
                    ",[Number] = " + pNumber +
                    ",ToolDescription = " + pToolDescription +
                    ",Designer = " + pDesigner +
                    ",Machinist = " + pMachinist +
                    ",[Status] = '" + cbddStatus.Text.Trim() + "'" +
                    ",TechnicalContactName = " + pTechnicalContact +
                    ",TechnicalContactEmail = " + pTechnicalContactEmail +
                    ",DesignReview1 = " + pDesignReview1 +
                    ",DesignReview2 = " + pDesignReview2 +
                    ",DesignReview3 = " + pDesignReview3 +
                    ",DesignReview4 = " + pDesignReview4 +
                    " WHERE ID = " + g.ID + " ", cnxn); ;

                cnxn.Open();

                cmd.Parameters.Add(pEstimatedDueDate);
                cmd.Parameters.Add(pJob);
                cmd.Parameters.Add(pCode);
                cmd.Parameters.Add(pNumber);
                cmd.Parameters.Add(pToolDescription);
                cmd.Parameters.Add(pDesigner);
                cmd.Parameters.Add(pMachinist);
                cmd.Parameters.Add(pTechnicalContact);
                cmd.Parameters.Add(pTechnicalContactEmail);
                cmd.Parameters.Add(pDesignReview1);
                cmd.Parameters.Add(pDesignReview2);
                cmd.Parameters.Add(pDesignReview3);
                cmd.Parameters.Add(pDesignReview4);

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

            GetData();
            GetComments();
        }

        private void Breject_Click(object sender, EventArgs e)
        {
            if (tbComments.Text.Length > 0)
            {
                SqlParameter pComments = new SqlParameter("@comments", SqlDbType.VarChar, 4000);
                pComments.Value = tbComments.Text.Trim();

                SqlParameter pUser = new SqlParameter("@user", SqlDbType.VarChar, 50);
                pUser.Value = g.user;

                try
                {

                    SqlCommand cmd = new SqlCommand(
                        "Update Ric.designRequest  set " +
                        "request_completed = 'true' " +
                        ",Rejected = 'true' " +
                        ", completion_date = GETDATE() " +
                        " where id = " + g.ID + " ", cnxn);

                    cnxn.Open();

                    //cmd.Parameters.Add(pComments);

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

                try
                {
                    SqlCommand cmd = new SqlCommand
                        ("Insert into DesignComments (" +
                            " RequestID " +
                            ",Comment " +
                            ",EnteredBy " +
                            ",EnteredOn " +
                            ") values (" +
                          g.ID.ToString().Trim() +
                          "," + pComments +
                          "," + pUser +
                          ",GETDATE() " +
                          ")", cnxn);

                    cmd.Parameters.Add(pComments);
                    cmd.Parameters.Add(pUser);

                    if (cnxn.State == ConnectionState.Closed)
                    {
                        cnxn.Open();
                    }

                    cmd.CommandTimeout = 30;
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
                    tbComments.Text = "";
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

        private void Bexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BOpenDxf_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand
                ("Select uploaded_dxf from ric.designrequests where id = '" + g.ID + "' and uploaded_dxf is not null", cnxn);
            cnxn.Open();
            object o = cmd.ExecuteScalar();
            cnxn.Close();
            if (o != null)
            {
                cmd = new SqlCommand
                    ("Select uploaded_dxf from ric.designrequests where id = '" + g.ID + "' and uploaded_dxf is not null", cnxn);
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

        private void bOpenPDF_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process pdfReader = new System.Diagnostics.Process();

            cmd = new SqlCommand
                ("Select uploaded_pdf from ric.designrequests where id = '" + g.ID + "' and uploaded_pdf is not null", cnxn);
            cnxn.Open();
            object o = cmd.ExecuteScalar();
            cnxn.Close();
            if (o != null)
            {
                cmd = new SqlCommand
                    ("Select uploaded_pdf from ric.designrequests where id = '" + g.ID + "' and uploaded_pdf is not null", cnxn);
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

        private void bEditRequest_Click(object sender, EventArgs e)
        {
            RTEditRequest r = new RTEditRequest();
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
          /*10*/",COALESCE([Code],'0') " +
                ",COALESCE([Number],'0') " +
                ",[ToolDescription] " +
                ",Designer " +
                ",Machinist " +
          /*15*/",TechnicalContactName " +
                ",DesignReview1 " +
                ",Comments " +
                ", CASE Request_Completed " +
                "  WHEN 1 THEN 'TRUE' " +
                "  ELSE 'FALSE' " +
                "End Request_Completed " +
               ",Completion_Date " +
               ",DesignReview2 " +
               ",DesignReview3 " +
               ",DesignReview4 " +
               ",Requestor_email " +
                "from RIC.designrequests where " +
                "id = " + g.ID + " ", cnxn);

            DataTable table = new DataTable();

            /*  leaving comments in so as not to need to renumber the columns    */

            try
            {
                

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
                    technicalContactEmail = table.Rows[0][15].ToString().Substring(10);
                }

                if (table.Rows[0][16].ToString().Length > 0)
                {
                    tbDesignReview1.Text = table.Rows[0][16].ToString();
                }

                if (table.Rows[0][17].ToString().Length > 0)
                {
                    //tbComments.Text = table.Rows[0][17].ToString();
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

                if (table.Rows[0][20].ToString().Length > 0)
                {
                    tbDesignReview2.Text = table.Rows[0][20].ToString();
                }
                if (table.Rows[0][21].ToString().Length > 0)
                {
                    tbDesignReview3.Text = table.Rows[0][21].ToString();
                }
                if (table.Rows[0][22].ToString().Length > 0)
                {
                    tbDesignReview4.Text = table.Rows[0][22].ToString();
                }
                if (table.Rows[0][23].ToString().Length > 0)
                {
                    requestor_Email = table.Rows[0][23].ToString();
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

        private void cbCompleted_CheckedChanged(object sender, EventArgs e)
        {
            cbddStatus.Text = "Completed";
        }

        private void bRequestorEmail_Click(object sender, EventArgs e)
        {
            g.emailTo = requestor_Email;
            eMail();
        }

        private void bTechnicalContactEmail_Click(object sender, EventArgs e)
        {
            g.emailTo = tbTechnicalContactEmail.Text.Trim();
            eMail();
        }

        private void bEmailBoth_Click(object sender, EventArgs e)
        {
            g.emailTo = requestor_Email + ";" + tbTechnicalContactEmail.Text.Trim();
        }

        private void eMail()
        {
            cnxn = new SqlConnection(g.db);

            string comment1 = "";
            string comment2 = "";
            string comment3 = "";
            string comment4 = "";
            string comment5 = "";

            if (dtComments.Rows.Count > 0)
            {
                comment1 = dtComments.Rows[0][2].ToString() + ":" + dtComments.Rows[0][1].ToString() + ":  " + dtComments.Rows[0][0].ToString();

                if (dtComments.Rows.Count > 1)
                {
                    comment2 = dtComments.Rows[1][2].ToString() + ":" + dtComments.Rows[1][1].ToString() + ":  " + dtComments.Rows[1][0].ToString();
                }
                else 
                {
                    comment2 = "";
                }
                if (dtComments.Rows.Count > 2)
                {
                    comment3 = dtComments.Rows[2][2].ToString() + ":" + dtComments.Rows[2][1].ToString() + ":  " + dtComments.Rows[2][0].ToString();
                }
                else
                {
                    comment3 = "";
                }
                if (dtComments.Rows.Count > 3)
                {
                    comment4 = dtComments.Rows[3][2].ToString() + ":" + dtComments.Rows[3][1].ToString() + ":  " + dtComments.Rows[3][0].ToString();
                }
                else
                {
                    comment4 = "";
                }
                if (dtComments.Rows.Count > 4)
                {
                    comment5 = dtComments.Rows[4][2].ToString() + ":" + dtComments.Rows[4][1].ToString() + ":  " + dtComments.Rows[4][0].ToString();
                }
                else
                {
                    comment5 = "";
                }
            }
            else
            {
                comment1 = "";
            }


            
            emailBody =
                    "Design Request Comments: " +
                    "\r\r" +
                    comment1 + "\r\n" +
                    comment2 + "\r\n" +
                    comment3 + "\r\n" +  
                    comment4 + "\r\n" +
                    comment5 + "\r\n" +

                    "Design Requirements:" +
                    "\r\r" +
                    tbRequest.Text.Trim() + "\r\n" +
                    tbAdditionalInformation.Text.Trim() + "\r\r" +
                    "Name...........: " + g.contact + "\n\r" +
                    "Contact eMail..: " + g.contactEmail + "\n\r" +
                    "Priority........: " + g.priority + "\r" +
                    "Need Date.......: " + g.needbyDate + "\r" +
                    "Project.........: " + g.project + "\r" +
                    "Part............: " + g.part + "\r" +
                    "Department......: " + g.department + "\r" +
                    "Date of Submission: " + g.requestDate;

            


            SqlCommand cmd = new SqlCommand("spTRmailRic", cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter to = cmd.Parameters.Add("@to", SqlDbType.NChar, 100);
            //to.Value = "tor.hepburn@ametek.com";
            to.Value = g.emailTo;//requestor_Email;
            SqlParameter etext = cmd.Parameters.Add("@etext", SqlDbType.VarChar, 4000);
            etext.Value = emailBody;
            SqlParameter subjline = cmd.Parameters.Add("@subjectline", SqlDbType.NChar, 60);
            subjline.Value = "Design Request " + g.ID + " Comment/Note ";

            cmd.Connection = cnxn;
            cnxn.Open();
            cmd.ExecuteNonQuery();
            cnxn.Close();
            cmd.Dispose();

        }
    }
}
