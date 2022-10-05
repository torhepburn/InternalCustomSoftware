using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ListBoxSelect
{
    public partial class LBSelect : Form
    {
        private string[] fileList;
        
        public LBSelect()
        {
            InitializeComponent();
        }

        private void LBSelect_Load(object sender, EventArgs e)
        {
            fileList = Directory.GetFiles(@"\\midws0102\data");
            int qtyFiles = fileList.Length;

            for (int i = 0; i < qtyFiles; i++)
            {
                LBox.Items.Add(fileList[i].Substring(fileList[i].LastIndexOf(@"\")+1));
            }
        }

        private void LBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int chosen = LBox.SelectedIndex;
            string textRead = File.ReadAllText(fileList[chosen]);
            int locate = textRead.IndexOf("#DATA");
            string data = textRead.Substring(locate + 7, textRead.Length - (locate + 7));
            data = data.Replace("\t", ",");
            File.AppendAllText(@"c:\a\" + 
                fileList[chosen].Substring(fileList[chosen].LastIndexOf(@"\") + 1) + ".csv", data);
            this.Close();
        }
    }
}
