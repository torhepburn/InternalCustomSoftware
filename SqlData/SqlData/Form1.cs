using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using Microsoft.Win32;
using System.IO;
using System.Data.SqlClient;


namespace SqlData
{
    public partial class Form1 : Form
    {
        private string[] baseSubkeyNames;
        RegistryKey softwareKey;
        private string[] softwareSubkeyNames;
        RegistryKey microsoftKey;
        private string[] microsoftSubkeyNames;
        RegistryKey mssqlKey;
        private string[] mssqlSubkeyNames;
        SqlConnection cnxn;
        SqlCommand cmd;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int nu = Environment.ProcessorCount;
            long po = Environment.WorkingSet;
            
            SqlDataSourceEnumerator instance1 =
              SqlDataSourceEnumerator.Instance;
            System.Data.DataTable table = instance1.GetDataSources();

            DGV.DataSource = table;
            DGV.Show();

            label1.Text = table.Rows.Count.ToString();

            cnxn = new SqlConnection("server = midsql01; password = Read+Write!; " +
                                  "user = readwrite; database = accessfrontends;");
            //cnxn.Open();

            //DataTableReader dtr = new DataTableReader(table);

            //while (dtr.Read())
            //{
                //cmd = new SqlCommand(
                //    "Insert into zygoSQLinventory (servername, instancename, version) " +
                //    "values ('" +
                //    dtr.GetString(0).Trim() + "','" +
                //    dtr.GetString(1).Trim() + "','" +
                //    dtr.GetString(3).Trim() + "') ", cnxn);
                //try
                //{
                //    cmd.ExecuteNonQuery();
                //}
                //catch (SqlException ex)
                //{
                //    MessageBox.Show(ex.ToString());
                //}
            //}

           /* 

            for (int i = 0; i < table.Rows.Count; i++)
            {
                cmd = new SqlCommand(
                    "Insert into zygoSQLinventory (servername, instancename, version) " +
                    "values ('" +
                    table.Rows[i][0].ToString().Trim() + "','" +
                    table.Rows[i][1].ToString().Trim() + "','" +
                    table.Rows[i][3].ToString().Trim() + "') ", cnxn);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            cnxn.Close();
*/
/*
            SqlDataSourceEnumerator instance2 =
              SqlDataSourceEnumerator.Instance;
            System.Data.DataTable table2 = instance2.GetDataSources();


            SqlDataSourceEnumerator instance3 =
              SqlDataSourceEnumerator.Instance;
            System.Data.DataTable table3 = instance3.GetDataSources();

            string cc = "this";
            
    */        /*
            object value = Registry.GetValue(@"hkey_local_machine\software\microsoft\microsoft sql server\" +
                @"110\tools\setup", "edition", null);
            //try
            //{
            //    string[] dirs = Directory.GetDirectories(@"hkey_local_machine\software\microsoft\microsoft sql server\");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}

           

            Microsoft.Win32.RegistryKey key = Microsoft.Win32.RegistryKey.
                OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine,
                Microsoft.Win32.RegistryView.Default);
            a = key.GetSubKeyNames();
                
            for (int i = 0; i < a.Length; i++ )
            {
                if (a[i] == "SOFTWARE")
                {
                    b = key.OpenSubKey(a[i]);
                    c = b.GetSubKeyNames();
                    break;
                }
            }

            for (int i = 0; i < c.Length; i++)
            {
                if (c[i].ToUpper() == "MICROSOFT")
                {
                    var d = b.OpenSubKey(c[i]);
                    f = d.GetSubKeyNames();
                    break;
                }
            }

            for (int i = 0; i < f.Length; i++)
            {
                if (f[i].Length > 19)
                {
                    if (f[i].ToUpper().Substring(0, 20) == "MICROSOFT SQL SERVER") 
                    {
                        File.AppendAllText(@"C:\A\SQLTEST.txt", f[i] + Environment.NewLine);
                    }
                }
                else if ((f[i].Length < 19) & (f[i].Length > 4))
                {
                    if (f[i].ToUpper().Substring(0, 5) == "MSSQL")
                    {
                        File.AppendAllText(@"C:\A\SQLTEST.txt", f[i] + Environment.NewLine);
                    }
                }

                
            }
            
            SqlDataAdapter da = new SqlDataAdapter(
                "select servername from zygosqlinventory order by servername", cnxn);
            DataTable dt = new DataTable();
                
            da.Fill(dt);

            Microsoft.Win32.RegistryKey key;

            for (int i = 22; i < dt.Rows.Count; i++)
            {
                try
                {
                    key = Microsoft.Win32.RegistryKey.
                            OpenRemoteBaseKey(RegistryHive.CurrentUser, dt.Rows[i][0].ToString().Trim());
                }
                catch 
                {
                    goto nextstep;
                }
                
                baseSubkeyNames = key.GetSubKeyNames();

                //softwareKey = key.OpenSubKey(@"SOFTWARE\MICROSOFT\MICROSOFT SQL SERVER");
                //softwareSubkeyNames = softwareKey.GetSubKeyNames();

                for (int ii = 0; ii < baseSubkeyNames.Length; ii++)
                {
                    if (baseSubkeyNames[ii].ToUpper() == "SOFTWARE")
                    {
                        softwareKey = key.OpenSubKey(baseSubkeyNames[ii]);
                        softwareSubkeyNames = softwareKey.GetSubKeyNames();
                        break;
                    }
                }

                for (int ii = 0; ii < softwareSubkeyNames.Length; ii++)
                {
                    if (softwareSubkeyNames[ii].ToUpper() == "MICROSOFT")
                    {
                        microsoftKey = softwareKey.OpenSubKey(softwareSubkeyNames[ii]);
                        microsoftSubkeyNames = microsoftKey.GetSubKeyNames();
                        break;
                    }
                }

                for (int ii = 0; ii < microsoftSubkeyNames.Length; ii++)
                {
                    if (microsoftSubkeyNames[ii].Length > 19)
                    {
                        if (microsoftSubkeyNames[ii].ToUpper().Substring(0, 20) == "MICROSOFT SQL SERVER")
                        {
                            mssqlKey = microsoftKey.OpenSubKey(microsoftSubkeyNames[ii]);
                            mssqlSubkeyNames = mssqlKey.GetSubKeyNames();
                            break;
                            //File.AppendAllText(@"C:\A\SQLTEST.txt", dt.Rows[i][0].ToString().Trim() + 
                            //    " X "+ microsoftSubkeyNames[ii] + Environment.NewLine);
                        }
                    }
                    else if ((microsoftSubkeyNames[ii].Length < 19) & (microsoftSubkeyNames[ii].Length > 4))
                    {
                        if (microsoftSubkeyNames[ii].ToUpper().Substring(0, 5) == "MSSQL")
                        {
                            mssqlKey = microsoftKey.OpenSubKey(microsoftSubkeyNames[ii]);
                            mssqlSubkeyNames = mssqlKey.GetSubKeyNames();
                            break;
                            
                            //File.AppendAllText(@"C:\A\SQLTEST.txt", dt.Rows[i][0].ToString().Trim() +
                            //    " X " + microsoftSubkeyNames[ii] + Environment.NewLine);
                        }
                    }


                }

            nextstep:
                i = i;
            }
            */



                //var b = key.OpenSubKey(a[5]);
                //var c = b.GetSubKeyNames();
                //var d = b.OpenSubKey(c[13]);
                //var f = d.GetSubKeyNames();
                //label1.Text = baseSubkeyNames[5].ToString();

            //try
            //{
            //    string remotename = "midws0352.zygo.com";
            //    Microsoft.Win32.RegistryKey rkey = Microsoft.Win32.RegistryKey.
            //        OpenRemoteBaseKey(RegistryHive.CurrentUser, remotename);
            //    var g = rkey.GetSubKeyNames();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            
        }
    }
}
