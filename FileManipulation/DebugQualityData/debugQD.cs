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


namespace DebugQualityData
{
    public partial class debugQD : Form
    {
        public debugQD()
        {
            InitializeComponent();
        }

        private void debugQD_Load(object sender, EventArgs e)
        {
            //prepare Word to be able to open the packing lists
            Word.Application oW = new Word.Application();


            object file = @"\\midfile01\Departments\Quality\Optics Inspection Team\Archive\Quality Data Requirements\Quality Assurance (118).docx";
            object NO = System.Reflection.Missing.Value;

            Word.Document doc =
                            oW.Documents.Open(ref file, ref NO, ref NO,
                            ref NO, ref NO, ref NO,
                            ref NO, ref NO, ref NO,
                            ref NO, ref NO, ref NO);

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
            oW.Quit();
            //close Word

        }
    }
}
