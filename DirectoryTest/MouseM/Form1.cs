using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MouseM
{
    public partial class Form1 : Form
    {
        private bool Flag;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
            timer1.Interval = (1000) * (60) * 4 ;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if 
            //{
                button1.PerformClick();
                //Cursor.Position = new Point(Cursor.Position.X + 10, Cursor.Position.Y + 500);
              //  Flag = false;
           // }
           // else
           // {
           //     button1
                //Cursor.Position = new Point(Cursor.Position.X - 10, Cursor.Position.Y - 500);
           //     Flag = true;
           // }
        }
    }
}
