using System;

namespace FileMove
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            string sourcePath = @"\\MIDFILE01\Departments\Procurement\Purchasing\SQL Reports";

            string FolderName = DateTime.Now.ToShortDateString().Replace("/", "-");

            string targetPath = sourcePath + @"\" + FolderName;

            System.IO.Directory.CreateDirectory(targetPath);

            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    string fileName = System.IO.Path.GetFileName(s);
                    string destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Move(s, destFile);
                }
            }
            else
            {

            }

            this.Close();
        }
    }
}
