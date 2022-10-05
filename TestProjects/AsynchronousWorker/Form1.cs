using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace AsynchronousWorker
{
    public partial class Form1 : Form
    {
        private string xtract = @"C:\Xtracted.pdf";
                
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        private void startAsyncButton_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            
        }

        private void cancelAsyncButton_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            //for (int i = 1; i <= 10; i++)
            //{
            //    if (worker.CancellationPending == true)
            //    {
            //        e.Cancel = true;
            //        break;
            //    }
            //    else
            //    {
            //        System.Threading.Thread.Sleep(500);
            //        worker.ReportProgress(i * 10);
            //    }
            //}

            SqlConnection cnxn = new SqlConnection("server=Middbsql; password=views; " +
                " user=views; database=calibration");
            SqlCommand cmd = new SqlCommand
                (" select certpdf from calibrationdata where id = 348");
            cmd.Connection = cnxn;

            cnxn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            System.Diagnostics.Process pdfReader = new System.Diagnostics.Process();

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

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            resultLabel.Text = (e.ProgressPercentage.ToString() + "%");
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                resultLabel.Text = "Cancelled!";
            }
            else if (e.Error != null)
            {
                resultLabel.Text = "Error: " + e.Error.Message;
            }
            else
            {
                resultLabel.Text = "Done!";
            }
        }
    }
}