using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AccessMacro
{
    public partial class Form1 : Form
    {
        object oMissing = System.Reflection.Missing.Value;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Access.Application oAccess = new Access.Application();
            oAccess.Visible = true;
            oAccess.OpenCurrentDatabase("c:\\a\\mkbookingssalesanalysis.mdb", true);
            //oAccess.CurrentDb = "c:\\a\\mkbookingssalesanalysis.mdb";
            oAccess.DoCmd.RunMacro("Update_LookUp_SS_Tables_From_Mk_Macro", 1);
            oAccess.CloseCurrentDatabase();
        }
    }
}
