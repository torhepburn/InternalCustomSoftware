using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CalibrationManager
{
    public partial class LogOn : Form
    {
        public LogOn()
        {
            InitializeComponent();
        }

        private void LogOn_Load(object sender, EventArgs e)
        {
            
        }

        private void bLogIn_Click(object sender, EventArgs e)
        {
            
            
            if ((tbUserName.Text.ToUpper() == "ZMEARES")
                && ( tbPassword.Text.ToUpper() == "AZT QUALITY"))
            {
                g.facility = "AZT";
                g.emailFrom = "zmeares@zygo.com";
                f00_Start fs = new f00_Start();
                fs.Show();
                tbPassword.Clear();
                tbUserName.Clear();
            }

            if ((tbUserName.Text.ToUpper() == "SECRET")
                && (tbPassword.Text.ToUpper() == "LIMITED"))
            {
                g.facility = "ZAMS";
                g.userType = "limited";
                f00_Start fs = new f00_Start();
                fs.Show();
                tbPassword.Clear();
                tbUserName.Clear();
            }

            if ((tbUserName.Text.ToUpper() == "VIEW")
                && (tbPassword.Text.ToUpper() == "VIEW"))
            {
                g.facility = "ZAMS";
                g.userType = "view";
                f00_Start fs = new f00_Start();
                fs.Show();
                tbPassword.Clear();
                tbUserName.Clear();
            }

            if ((tbUserName.Text.ToUpper() == "BBACON")
                && (tbPassword.Text.ToUpper() == "OPEN"))
            {
                Entrance tran = new Entrance();
            }
        }
    }
}