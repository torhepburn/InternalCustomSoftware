using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CopyReplaceFiles
{
    public partial class CopyReplace : Form
    {
        public CopyReplace()
        {
            InitializeComponent();
        }

        private void CopyReplace_Load(object sender, EventArgs e)
        {
            string test = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //string originalFile = @"c:\users\thepburn\desktop\labelprintsn12-btw 10.exe";
                string originalFile = @"c:\users\public\desktop\shippinglabel.exe";
                string filetoReplace = @"\\zygocorp\manufacturing\softwaredistribution\shippinglabel.exe";
                //File.Replace(originalFile, filetoReplace,null, false);
                //File.SetAttributes(originalFile, FileAttributes.Normal);
                //File.SetAttributes(filetoReplace, FileAttributes.Normal);
                File.Copy(filetoReplace, originalFile, true);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            
            }
            finally
            {

            }
        }
    }
}
