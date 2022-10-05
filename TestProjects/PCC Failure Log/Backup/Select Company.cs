using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PCC_Failure_Log
{
    public partial class Select_Company : Form
    {
        public Select_Company()
        {
            InitializeComponent();
        }

        private void Select_Company_Load(object sender, EventArgs e)
        {
            Ltask.Text = pV.task;
        }

        private void bZygo_Click(object sender, EventArgs e)
        {
            pV.location = "Zygo";
            pV.task = pV.task + "\nZygo";
            Select_Board bd = new Select_Board();
            bd.Show();
            Close();
        }

        private void bCEI_Click(object sender, EventArgs e)
        {
            pV.location = "CEI";
            pV.task = pV.task + "\nCEI";
            Select_Board bd = new Select_Board();
            bd.Show();
            Close();
        }

    }
}