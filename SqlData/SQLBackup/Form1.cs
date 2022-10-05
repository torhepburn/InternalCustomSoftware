using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Data.SqlClient;

namespace SQLBackup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ServerConnection cnxn = new ServerConnection(@"(LocalDB)\MAPToolkit");
            //Server server = new Server(cnxn);
            //Backup source = new Backup();
            //source.Action = BackupActionType.Database;
            //source.Database = "SqlCheck";
            //BackupDeviceItem destination = new BackupDeviceItem("ZygoInventory3.bak", DeviceType.File);
            //source.Devices.Add(destination);
            //source.SqlBackup(server);
            //cnxn.Disconnect();

            try
            {
                SqlConnection cnxn = new SqlConnection("server = midsql01; password = Read+Write!; " +
                                  "user = readwrite; database = ZygoInventory;");

                SqlCommand cmd = new SqlCommand(
                    "USE [master] " +
                    "RESTORE DATABASE [SqlCheck2] " +
                    @"FROM  DISK = N'E:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\Backup\ZygoInventory3.bak' " +
                    @"WITH  FILE = 1,  MOVE N'SqlCheck' TO N'E:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\SqlCheck.mdf',  " +
                    @"MOVE N'SqlCheck_log' TO N'E:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\SqlCheck_log.ldf',  NOUNLOAD,  STATS = 5 "
                    , cnxn);

                cnxn.Open();
                cmd.ExecuteNonQuery();
                //ServerConnection Rcnxn = new ServerConnection(@"MIDSQL01");
                //Server Rserver = new Server(Rcnxn);
                //Server Rserver = new Server("MIDSQL01");

                //var a = Rserver.Information.MasterDBPath;

                //Restore Rdestination = new Restore();
                //Rdestination.Action = RestoreActionType.Database;
                //Rdestination.Database = "ZygoInventory4";
                ////BackupDeviceItem Rsource = new BackupDeviceItem(@"c:\users\thepburn\ZygoInventory3.bak", DeviceType.File);
                ////BackupDeviceItem Rsource = new BackupDeviceItem(@"E:\program files\microsoft sql server\mssql11.mssqlserver\mssql\backup\ZygoInventory3.bak", DeviceType.File);
                //Rdestination.Devices.AddDevice(@"E:\program files\microsoft sql server\mssql11.mssqlserver\mssql\backup\ZygoInventory3.bak", DeviceType.File);
                ////Rdestination.ReplaceDatabase = true;
                //Rdestination.SqlRestore(Rserver);
                ////Rcnxn.Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
