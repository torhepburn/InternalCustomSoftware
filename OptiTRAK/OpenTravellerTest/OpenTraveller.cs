using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenTravellerTest
{
    public partial class OpenTraveller : Form
    {
        public OpenTraveller()
        {
            InitializeComponent();
        }

        private void OpenTraveller_Load(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.InitialDirectory =
                   @"\\usrics01\gen_tl\departments\pc\travelers\";

                openFileDialog1.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            string here = openFileDialog1.FileName;

        }
    }
}
