using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.IO;


namespace QualityData
{
    public partial class QualityData : Form
    {
        private string text;
        //private string[] checkboxes;

        public QualityData()
        {
            InitializeComponent();
        }

        private void QualityData_Load(object sender, EventArgs e)
        {
            
            string[] fileEntries = Directory.GetFiles(@"\\midfile01\Departments\Quality\Optics Inspection Team\Archive\Quality Data Requirements\");
            int i = fileEntries.Count();
            //array is zero based

            //prepare Word to be able to open the packing lists
            Word.Application oW = new Word.Application();

            //foreach (string fileName in fileEntries)
            for ( int n = 393; n < i; n++)
            {




                object file = fileEntries[n];
                //object file = fileName;
                //object file = @"\\midfile01\Departments\Quality\Optics Inspection Team\Archive\Quality Data Requirements\Quality Assurance (3).docx";
                object NO = System.Reflection.Missing.Value;

                Word.Document doc =
                                oW.Documents.Open(ref file, ref NO, ref NO,
                                ref NO, ref NO, ref NO,
                                ref NO, ref NO, ref NO,
                                ref NO, ref NO, ref NO);

                //int i = 0;

                //  string[] boxes = new string[90];
                // for ease of debugging

                /*
                 * 
                 * Content controls are used on forms
                 * this is a method for pulling the value of the content controls
                 * and not the form text.
                 * Perhaps I should have bypassed the test entries in the click here to enter boxes as well
                 * as it messes up the columns of data.
                 * 
                 */

                foreach (Word.ContentControl cc in doc.ContentControls)
                {
                    //i++;

                    if (cc.Type.ToString() == "wdContentControlText")
                    {
                        //boxes[i] = cc.ID.ToString() + "  " + cc.Range.Text.ToString();
                        if (cc.Range.Text.ToString() != "Click here to enter text.")
                            {
                            File.AppendAllText(@"C:\A\QualityData.csv", cc.Range.Text.ToString() + ",");
                        }
                    }

                    if (cc.Type.ToString() == "wdContentControlCheckBox")
                    {
                        //boxes[i] = cc.ID.ToString() + "  " + cc.Checked.ToString();
                        File.AppendAllText(@"C:\A\QualityData.csv", cc.Checked.ToString() + ",");
                    }
                }

                File.AppendAllText(@"C:\A\QualityData.csv", Environment.NewLine);
                doc.Close();
            }
            oW.Quit();
            //close Word
        }
    }
}
