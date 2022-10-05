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

namespace AVALARA_NAV_Merge
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\A\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;


                    Microsoft.Office.Interop.Excel.Application xlapp;
                    Microsoft.Office.Interop.Excel.Workbook wbook;
                    Microsoft.Office.Interop.Excel.Worksheet wsheet;
                    Microsoft.Office.Interop.Excel.Range oRng;

                    xlapp = new Microsoft.Office.Interop.Excel.Application();
                    xlapp.Visible = false;
                    xlapp.DisplayAlerts = false;
                    wbook = xlapp.Workbooks.Open(filePath);
                    wbook = xlapp.ActiveWorkbook;
                    wsheet = xlapp.ActiveSheet;
                    wsheet.UsedRange.Copy();

                    string text = Clipboard.GetText();

                    Clipboard.Clear();
                    //xlapp.Application.CutCopyMode = false;  
                    
                    wbook.Close();
                    xlapp.Quit();

                    //string[] stringArray = System.IO.File.ReadAllLines(@"C:\A\new.txt");

                    string[] lines = text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

                    int w = lines.Count();
                    //Read the contents of the file into a stream

                    for (int ii = 14; ii < (lines.Length - 5); ii++)
                    {
                        //if (lines[ii].Length > 0 && Char.IsNumber(Convert.ToChar(lines[ii].Substring(0, 1))))
                        //{
                            int numbertab = lines[ii].IndexOf('\t');

                        string DocumentNumber = lines[ii].Substring(0, numbertab);

                        string line = lines[ii].Substring(numbertab + 1, lines[ii].Length - (numbertab + 1));

                            int ictab = line.IndexOf('\t');

                        line = line.Substring(ictab + 1, line.Length - (ictab + 1));

                            int desctab = line.IndexOf('\t');

                        string PostingDate = line.Substring(0, desctab);

                        line = line.Substring(desctab + 1, line.Length - (desctab + 1));

                            desctab = line.IndexOf('\t');

                        string TotalAmount = line.Substring(0, desctab);

                        TotalAmount = TotalAmount.Replace("$", "");
                        TotalAmount = TotalAmount.Replace(",", "");

                        line = line.Substring(desctab + 1, line.Length - (desctab + 1));

                        desctab = line.IndexOf('\t');

                        line = line.Substring(desctab + 1, line.Length - (desctab + 1));

                        desctab = line.IndexOf('\t');

                        line = line.Substring(desctab + 1, line.Length - (desctab + 1));

                        desctab = line.IndexOf('\t');

                        string TaxAmount = line.Substring(desctab + 1, line.Length - (desctab + 1));


                        string stop = "here";
                        //if (item_code != "" || description != "")
                        //{
                        //    int qtytab = line.IndexOf('\t');

                        //    qty = line.Substring(0, qtytab);

                        //    line = line.Substring(qtytab + 1, line.Length - (qtytab + 1));

                        //    int boxtab = line.IndexOf('\t');

                        //    boxes = line.Substring(0, boxtab);

                        //    line = line.Substring(boxtab + 1, line.Length - (boxtab + 1));

                        //    int installtab = line.IndexOf('\t');

                        //    installon = line.Substring(0, installtab);

                        //    kitwith = line.Substring(installtab + 1, line.Length - (installtab + 1));

                        //    try
                        //    {
                        //        cnxn = new SqlConnection(db);

                        //        SqlCommand cmd2 = new SqlCommand(
                        //            "Insert into Labels.PackingListTest (" +
                        //            "documentnumber, " +
                        //            "revision, " +
                        //            "item_code, " +
                        //            "description, " +
                        //            "quantity, " +
                        //            "boxes, " +
                        //            "installon, " +
                        //            "kitwith) " +
                        //            "values (" +
                        //            "@documentnumber, " +
                        //            "@revision, " +
                        //            "@item_code, " +
                        //            "@description, " +
                        //            "@quantity, " +
                        //            "@boxes, " +
                        //            "@installon, " +
                        //            "@kitwith )", cnxn);

                        //        cmd2.Parameters.Add("@documentnumber", SqlDbType.VarChar, 20).Value = document;
                        //        cmd2.Parameters.Add("@revision", SqlDbType.NChar, 5).Value = revision;
                        //        cmd2.Parameters.Add("@item_code", SqlDbType.VarChar, 20).Value = item_code;
                        //        cmd2.Parameters.Add("@description", SqlDbType.VarChar, 50).Value = description;
                        //        cmd2.Parameters.Add("@quantity", SqlDbType.NChar, 10).Value = qty;
                        //        cmd2.Parameters.Add("@boxes", SqlDbType.NChar, 10).Value = boxes;
                        //        cmd2.Parameters.Add("@installon", SqlDbType.NChar, 50).Value = installon;
                        //        cmd2.Parameters.Add("@kitwith", SqlDbType.NChar, 20).Value = kitwith;


                        //        cnxn.Open();
                        //        rowsReturned = cmd2.ExecuteNonQuery();
                        //        cnxn.Close();
                        //    }
                        //    catch (SqlException ex)
                        //    {
                        //        MessageBox.Show(ex.Message);
                        //    }
                        //    finally
                        //    {
                        //        cnxn.Close();
                        //    }


                        //    item_code = "";
                        //    description = "";
                        //    qty = "";
                        //    boxes = "";
                        //    installon = "";
                        //    kitwith = "";

                        //}
                        //}

                        //var fileStream = openFileDialog.OpenFile();

                        //using (StreamReader reader = new StreamReader(fileStream))
                    }
                    // {
                        //    fileContent = reader.ReadToEnd();
                        // }
                    }
                }

            //MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
        }
    }
}
