using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Labels
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Process p = new Process();
            //p.StartInfo.FileName = @"C:\Program Files\Seagull\BarTender 6.20\" +
            //    @"Professional\bartend.exe";
            //p.StartInfo.Arguments = @"/P /X /F=c:\labels\zebrageneric1text_prric718.btw " +
            //    @" /D=c:\labels\generic\genericlabel.txt";
            //p.Start();

            Bitmap bm = new Bitmap("c:\\A\\labelnew.bmp");
            //Bitmap bm = new Bitmap(typeof(Button), "Button.bmp");
            
            
            try
            {
                bm.Save("C:\\a\\aaa.gif", System.Drawing.Imaging.ImageFormat.Gif);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}