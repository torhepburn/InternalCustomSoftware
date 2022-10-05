using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MinitabTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Mtb.Application Mtbapp;
            Mtbapp = new Mtb.Application();
            Mtbapp.UserInterface.Visible = true;
            Mtbapp.UserInterface.UserControl = true;
            Mtbapp.ActiveProject.ExecuteCommand("rand 20 c1", Type.Missing); // generates 20 random data points in C1
            Mtbapp.ActiveProject.ExecuteCommand("date c1 c1", Type.Missing); // creates random date column
            //Mtbapp.ActiveProject.ExecuteCommand("text c1 c1", Type.Missing); // converts data in C1 to text and stores in C1
            object test = Mtbapp.ActiveProject.ActiveWorksheet.Columns.Item(1).GetData(1,20);


        }
    }
}