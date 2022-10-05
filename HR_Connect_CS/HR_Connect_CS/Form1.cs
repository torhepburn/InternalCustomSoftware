using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace HR_Connect_CS
{
    public partial class Form1 : Form
    {
        private OracleConnection conn = new OracleConnection();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bConnect_Click(object sender, EventArgs e)
        {
            conn.ConnectionString = "user id=" + tbUserID.Text + ";" +
                "Password=" + tbPassword.Text + ";Data Source=" +
                tbDataSource.Text + ";";
            try
            {
                conn.Open();
                bConnect.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                conn.Dispose();
            }

        }
    }
}