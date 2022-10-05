using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Seagull.BarTender.Print;

namespace BTprinter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            


            



            //doc.PrintSetup.PrinterName

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Engine eng = new Engine(true);

                eng.Start();
                eng.Window.VisibleWindows = VisibleWindows.All;

                LabelFormatDocument doc = eng.Documents.Open(@"c:\a\1000-1042-79C_SN20_Win7.btw");

                doc.PrintPreview.ShowDialog();
                doc.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
