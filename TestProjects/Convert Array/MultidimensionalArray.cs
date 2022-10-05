using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Convert_Array
{
    public partial class MultidimensionalArray : Form
    {
        public MultidimensionalArray()
        {
            InitializeComponent();
        }

        private void MultidimensionalArray_Load(object sender, EventArgs e)
        {
            string[,] siblings = new string[,]{{ "Tom", "Mike" } ,{ "Will", "Gil"} };
            string[,] marray = new string[ 2, 3];
            marray[0,0] = "Tom";
            marray[0,1] = "Mike";
            marray[0,2] =  "Will";
        }
    }
}