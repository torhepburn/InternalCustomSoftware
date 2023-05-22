using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Test2
{
    public partial class GetWordDocumemt : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        private string db = "server = CT-MID-SQL11; user = ReadWrite; password = Read+Write!; " +
                            "database = AccessFrontEnds;";
        private string item_code;
        private string description;
        private string qty;
        private string boxes;
        private string installon;
        private string kitwith;
        private string document;
        private string revision;
        private string text;
        private string[] fileList;

        public GetWordDocumemt()
        {
            InitializeComponent();
        }

        private void GetWordDocumemt_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(db);

            SqlCommand cmd = new SqlCommand("Delete from Labels.PackingListTest", cnxn);

            cnxn.Open();
            int rowsReturned = cmd.ExecuteNonQuery();
            cnxn.Close();

            string directory = @"C:\A\PackingListTest";

            if (Directory.Exists(directory))
            {

            }
            else
            {
                MessageBox.Show("Need to add folder 'C:\\A\\PackingListTest'");
                this.Close();
                return;
            }

            fileList = Directory.GetFiles(@"C:\A\PackingListTest");

            if (fileList.Length < 1)
            {
                MessageBox.Show(@"No files have been loaded in C:\A\PackingListTest folder for uploading.");
                this.Close();
                return;
            }

            //prepare Word to be able to open the packing lists
            Microsoft.Office.Interop.Word.Application oW = new Microsoft.Office.Interop.Word.Application();


            for (int i = 0; i < fileList.Length; i++)
            {

                //debug line to figure out last packing list attempted
                File.AppendAllText(@"C:\A\PackingListUpdate.txt", fileList[i] + "  " + i.ToString() + Environment.NewLine);

                document = fileList[i].ToString().Substring(fileList[i].ToString().LastIndexOf("\\") + 1, fileList[i].ToString().Length - 27);
                revision = fileList[i].ToString().Substring(fileList[i].ToString().LastIndexOf(".") - 1, 1).ToUpper();

                // could be either .doc or .docx so need to check
                //  all files need to be docx for program to open them

                //doesn't seem to be true - works for .doc

                
                if (File.Exists(fileList[i].Replace(".DOC ", ".DOCX")) == true)
                {
                    //pull the document through Word to the clipboard
                    //and put it in a text string

                    object file = fileList[i].ToUpper().Replace(".DOC ", ".DOCX");

                    object NO = System.Reflection.Missing.Value;
                    Microsoft.Office.Interop.Word.Document doc =
                        oW.Documents.Open(ref file, ref NO, ref NO,
                        ref NO, ref NO, ref NO,
                        ref NO, ref NO, ref NO,
                        ref NO, ref NO, ref NO);
                    doc.ActiveWindow.Selection.WholeStory();
                    doc.ActiveWindow.Selection.Copy();
                    IDataObject data = Clipboard.GetDataObject();
                    text = data.GetData(DataFormats.Text).ToString();
                    text = text + Environment.NewLine + "Notes:";

                    //close the document once the data has been acquired.
                    doc.Close(ref NO, ref NO, ref NO);
                }
                else
                {
                    text = "";
                }

                //take the text and break it into lines and 
                //process it

                string[] lines = text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

                //start at 19 to debug #3
                for (int ii = 0; ii < (lines.Length); ii++)
                {
                    if (lines[ii].Length > 0 && Char.IsNumber(Convert.ToChar(lines[ii].Substring(0, 1))))
                    {
                        int numbertab = lines[ii].IndexOf('\t') + 1;

                        string line = lines[ii].Substring(numbertab, lines[ii].Length - numbertab);

                        int ictab = line.IndexOf('\t');

                        item_code = line.Substring(0, ictab);

                        line = line.Substring(ictab + 1, line.Length - (ictab + 1));

                        int desctab = line.IndexOf('\t');

                        description = line.Substring(0, desctab).Trim();

                        line = line.Substring(desctab + 1, line.Length - (desctab + 1));

                        if (item_code != "" || description != "")
                        {
                            int qtytab = line.IndexOf('\t');

                            qty = line.Substring(0, qtytab);

                            line = line.Substring(qtytab + 1, line.Length - (qtytab + 1));

                            int boxtab = line.IndexOf('\t');

                            boxes = line.Substring(0, boxtab);

                            line = line.Substring(boxtab + 1, line.Length - (boxtab + 1));

                            if (line == "" & (line.IndexOf('\t') == -1))  //if the document is messed up and the field is not there
                            {
                                installon = "";
                                kitwith = "";
                            }
                            else
                            {
                                int installtab = line.IndexOf('\t');

                                if (installtab > -1)
                                {

                                    installon = line.Substring(0, installtab);

                                    kitwith = line.Substring(installtab + 1, line.Length - (installtab + 1));
                                }
                            }

                            try
                            {
                                cnxn = new SqlConnection(db);

                                SqlCommand cmd2 = new SqlCommand(
                                    "Insert into Labels.PackingListTest (" +
                                    "documentnumber, " +
                                    "revision, " +
                                    "item_code, " +
                                    "description, " +
                                    "quantity, " +
                                    "boxes, " +
                                    "installon, " +
                                    "kitwith) " +
                                    "values (" +
                                    "@documentnumber, " +
                                    "@revision, " +
                                    "@item_code, " +
                                    "@description, " +
                                    "@quantity, " +
                                    "@boxes, " +
                                    "@installon, " +
                                    "@kitwith )", cnxn);

                                cmd2.Parameters.Add("@documentnumber", SqlDbType.VarChar, 20).Value = document;
                                cmd2.Parameters.Add("@revision", SqlDbType.NChar, 5).Value = revision;
                                cmd2.Parameters.Add("@item_code", SqlDbType.VarChar, 20).Value = item_code;
                                cmd2.Parameters.Add("@description", SqlDbType.VarChar, 50).Value = description;
                                cmd2.Parameters.Add("@quantity", SqlDbType.NChar, 10).Value = qty;
                                cmd2.Parameters.Add("@boxes", SqlDbType.NChar, 10).Value = boxes;
                                cmd2.Parameters.Add("@installon", SqlDbType.NChar, 50).Value = installon;
                                cmd2.Parameters.Add("@kitwith", SqlDbType.NChar, 20).Value = kitwith;


                                cnxn.Open();
                                rowsReturned = cmd2.ExecuteNonQuery();
                                cnxn.Close();
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                cnxn.Close();
                            }


                            item_code = "";
                            description = "";
                            qty = "";
                            boxes = "";
                            installon = "";
                            kitwith = "";

                        }
                    }

                    if (lines[ii].Length > 4 && lines[ii].Substring(0, 5).ToUpper() == "NOTES")
                    {
                        break;
                    }
                }
            }
            text = "";

            da = new SqlDataAdapter("Select " +
                                    "documentnumber, " +
                                    "revision, " +
                                    "item_code, " +
                                    "description, " +
                                    "quantity, " +
                                    "boxes, " +
                                    "RTRIM(installon) InstallOn, " +
                                    "kitwith" +
                                    " from Labels.PackingListTest order by uid", cnxn);

            System.Data.DataTable dt = new System.Data.DataTable();

            da.Fill(dt);

            DGV.DataSource = dt;
            DGV.Show();

            DGV.Columns[0].Width = 110;
            DGV.Columns[1].Width = 50;
            DGV.Columns[3].Width = 250;
            DGV.Columns[4].Width = 50;
            DGV.Columns[5].Width = 50;
            //DGV.Columns[7].Width = 50;

            oW.Quit();
            //close Word
        }

        private void bADD_Click(object sender, EventArgs e)
        {
            if (tbTitle.Text.Trim().Length < 1)
            {
                MessageBox.Show("Must enter a packing list description.");
                tbTitle.Focus();
                return;
            }
            else
            {

                cnxn = new SqlConnection(db);

                int fileTest = 0;

                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(documentnumber) FROM Labels_PackingLists " +
                    "WHERE documentnumber = '" + document + "' " +
                    "AND revision = '" + revision + "' ", cnxn);
                try
                {
                    cnxn.Open();

                    fileTest = (Int32)cmd.ExecuteScalar();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    cnxn.Close();
                }

                if (fileTest < 1)
                {

                    try
                    {
                        cnxn = new SqlConnection(db);

                        cnxn.Open();

                        cmd = new SqlCommand("INSERT INTO Labels_PackingLists " +
                                             "([documentnumber] " +
                                             ",[revision] " +
                                             ",[item_code] " +
                                             ",[description] " +
                                             ",[quantity] " +
                                             ",[boxes] " +
                                             ",[installon] " +
                                             ",[kitwith]) " +
                                             "SELECT " +
                                             "documentnumber " +
                                             ",revision " +
                                             ",[item_code] " +
                                             ",[description] " +
                                             ",[quantity] " +
                                             ",[boxes] " +
                                             ",[installon] " +
                                             ",[kitwith] " +
                                             "FROM Labels.PackingListTest "
                                             , cnxn);

                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("UPDATE labels_packinglists " +
                            "SET pldescription = @description " +
                            "WHERE documentnumber = '" + document + "' AND " +
                            "revision = '" + revision + "'", cnxn);

                        cmd.Parameters.Add("@description", SqlDbType.VarChar, 50).Value = tbTitle.Text.Trim();

                        cmd.ExecuteNonQuery();

                        cmd.Parameters.Clear();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        cnxn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("This list is already in the database.");
                }

                this.Close();
            }
        }
    }
}



