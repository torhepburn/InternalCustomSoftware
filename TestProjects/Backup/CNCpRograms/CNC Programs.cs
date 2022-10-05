using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CNCpRograms
{
    public partial class CNC_Programs : Form
    {
        private string[] Companies;
        private string path = @"\\zygocorp\departments\optics\opt_cnc\" +
            @"cnc programs";
        //private string path = @"c:\a\";
        private int selected;
        private string part;
        private string company;
        
        public CNC_Programs()
        {
            InitializeComponent();
        }

        private void CNC_Programs_Load(object sender, EventArgs e)
        {
            Companies = Directory.GetDirectories(path);

            int qtyCompanies = Companies.Length;

            for (int i = 0; i < qtyCompanies; i++)
            {
                LB1.Items.Add(Companies[i].Substring(Companies[i].LastIndexOf(@"\") + 1));
            }
        }

        private void LB1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = LB1.SelectedIndex;
            label1.Text = Companies[selected].Substring(Companies[selected].LastIndexOf(@"\") + 1);
            tbPart.Focus();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            part = tbPart.Text.Trim();
            //create the new folders for the part
            Directory.CreateDirectory(Companies[selected].ToString() + @"\" + part);
            Directory.CreateDirectory(Companies[selected].ToString() + @"\" + part + @"\Process Data Sheets");
            Directory.CreateDirectory(Companies[selected].ToString() + @"\" + part + @"\NC");
            Directory.CreateDirectory(Companies[selected].ToString() + @"\" + part + @"\CAM Programs");
            Directory.CreateDirectory(Companies[selected].ToString() + @"\" + part + @"\Setup Docs");
            Directory.CreateDirectory(Companies[selected].ToString() + @"\" + part + @"\Misc");
            Directory.CreateDirectory(Companies[selected].ToString() + @"\" + part + @"\Inspection");
            Directory.CreateDirectory(Companies[selected].ToString() + @"\" + part + @"\Vericut");
            part = "";
            tbPart.Text = "";
            selected = 0;
            label1.Text = "No Company Selected";
            this.Close();
        }

        private void bCompany_Click(object sender, EventArgs e)
        {
            // add a new company
            company = tbCompany.Text.Trim();
            Directory.CreateDirectory(path + @"\" + company);
            //refresh the list box
            Companies = Directory.GetDirectories(path);
            
            LB1.Items.Clear();

            int qtyCompanies = Companies.Length;

            for (int i = 0; i < qtyCompanies; i++)
            {
                LB1.Items.Add(Companies[i].Substring(Companies[i].LastIndexOf(@"\") + 1));
            }
            company = "";
            tbCompany.Text = "";
            
            
        }
    }
}