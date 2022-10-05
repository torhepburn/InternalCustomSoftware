using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Tools
{
    public partial class F40_Add_Tool_SN : Form
    {
        SqlConnection cnxn = new SqlConnection(g.db);
        
        public F40_Add_Tool_SN()
        {
            InitializeComponent();
        }

        private void F40_Add_Tool_SN_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand
                        ("Select top 1 [tool number] from customtooling " +
                        "order by [tool number] desc", cnxn);
            cnxn.Open();
            object o = cmd.ExecuteScalar();
            cnxn.Close();

            int next = 0;
            bool result = int.TryParse(o.ToString().Remove(0,1), out next);
            next = next + 1;
            g.toolNumber = "T" + next.ToString();

            cmd = new SqlCommand
                       ("Select top 1 [sn] from tools where sn like '" + g.toolNumber + "' " +
                       "order by [sn] desc", cnxn);
            cnxn.Open();
            o = cmd.ExecuteScalar();
            cnxn.Close();
            
            if (o == null)
            {
                Lsn.Text = g.toolNumber + "01" + "+GRIT";
            }
            else
            {

            }

            //Lsn.Text =   "+GRIT";
            
        }

        private void bEnter_Click(object sender, EventArgs e)
        {
            int i = 0;
            bool result = int.TryParse(tbGrit.Text, out i);
            if (result == true)
            {
                g.grit = i.ToString();
                //insert tool number into customtooling
                SqlCommand cmd = new SqlCommand("insert into customtooling " + 
                    "([tool number]) values ('" + g.toolNumber + "' )", cnxn);
                cnxn.Open();
            }
            else
            {
                MessageBox.Show("Grit must be a three digit number.");
                tbGrit.Text = "";
                tbGrit.Focus();
                return;
            }
            
        }
    }
}
