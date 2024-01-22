using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace LabelPrint
{
    public partial class F2_GPI_Details : Form
    {
        public F2_GPI_Details()
        {
            InitializeComponent();
        }

        private void F2_GPI_Details_Load(object sender, EventArgs e)
        {
            Litem.Text = gpi.item;
            Ldescription.Text = gpi.iDescription;
        }

        private void bPrint_Click(object sender, EventArgs e)
        {            
            //EPL
            string str = "\nN\nq812Q609,203\n";
            
            str += "B20,10,0,1,2,4,32,B,\"" + gpi.item + "\"\n";
            str += "A20,80,0,4,1,1,N,\"" + gpi.iDescription + "\"\n";
            str += "A20,110,0,4,1,1,N,\"Bin # :\"\n";
            str += "A120,110,0,4,1,1,N,\"" + tbBinNumber.Text.ToString() + "\"\n";
            str += "A300,110,0,4,1,1,N,\"FULL BIN: \"\n";
            str += "A500,110,0,4,1,1,N,\"" + tbFullBin.Text.ToString() + "\"\n";
            str += "A200,150,0,4,1,1,N,\"WAREHOUSE: 26\"\n";
            
            str += "P1\n";
            RawPrinterHelper.SendStringToPrinter(gpi.printer, str);
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
