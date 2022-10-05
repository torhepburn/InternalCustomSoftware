using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.Reflection;
using System.IO;

namespace ToolRoomCostSavings
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Excel.Application oXL = new Excel.Application();
            oXL.Visible = true;
            Excel.Workbook oWB = oXL.Workbooks.Add(Missing.Value);

            Excel.Worksheet oWS;

            
        }
    }
}
