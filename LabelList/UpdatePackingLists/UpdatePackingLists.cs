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
using Microsoft.Office.Interop.Word;

namespace UpdatePackingLists
{
    public partial class UpdatePackingLists : Form
    {
        SqlConnection cnxn;
        SqlDataReader dr;
        SqlDataAdapter da;
        private string db = "server = CT-MID-SQL01; user = ReadWrite; password = Read+Write!; " +
                            "database = AccessFrontEnds;";
        private string item_code;
        private string description;
        private string qty;
        private string boxes;
        private string installon;
        private string kitwith;
        private string document;
        private string revision;
        private string qualifiedFile;
        private string text;
        private int BoxCount;
        private string label = @"C:\labels\generic\genericlabel.txt";
        private string[] fileList;
        private string flag;
        private string plDescription;

        public UpdatePackingLists()
        {
            InitializeComponent();
        }

        private void UpdatePackingLists_Load(object sender, EventArgs e)
        {

            //go to CT-MID_SQL01.dbo.AccessFrontEnds and get list of
            //packinglists from a view which goes out to middbweb
            //and gets the doc control packinglist list

            String Sql = "select documentnumber, activerevision, destinationfile, title from " +
            //"labels_lup_items_with_partslist order by documentnumber, activerevision";
            //"labels_lup_items_with_partslist where documentnumber = 'pl6314-0105-01'";
            //"labels_lup_items_with_partslist where documentnumber like 'pl6314-0105-01%'";
            "labels_lup_items_with_partslist where documentnumber in ( 'plch6500-0620-01') ";


            cnxn = new SqlConnection(db);

            SqlDataAdapter da = new SqlDataAdapter(Sql, cnxn);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);

            int cc = dt.Rows.Count;

            //prepare Word to be able to open the packing lists
            Microsoft.Office.Interop.Word.Application oW = new Microsoft.Office.Interop.Word.Application();

            for (int i = 0; i < (dt.Rows.Count); i++)
            {
                document = dt.Rows[i][0].ToString().Trim();
                revision = dt.Rows[i][1].ToString().Trim();
                qualifiedFile = dt.Rows[i][2].ToString().Trim();
                plDescription = dt.Rows[i][3].ToString().Trim();

                //qualifiedFile = @"\\middbweb2012\DocControl - Documents\PL6307\0100\06\A\PL6307-0100-06A.doc";
                //qualifiedFile = @"\\middbweb2012\DocControl - Documents\PLCH6500\0620\35\G\PLCH6500-0620-35G.DOC";
                //qualifiedFile = @"\\middbweb2012\DocControl - Documents\PLCH6500\0420\01\G\PLCH6500-0420-01F.DOC";
                qualifiedFile = @"C:\A:\PLCH6550-0421-01g.docx";

                //prepare Word to be able to open the packing lists

                //Microsoft.Office.Interop.Word.Application oW = new Microsoft.Office.Interop.Word.Application();


                //check to see if the packinglist for a specific revision
                //has already been put in the database

                SqlConnection cnxn2 = new SqlConnection(db);

                SqlCommand cmd3 = new SqlCommand(
                    "select distinct documentnumber from " +
                    "labels_packinglists where " +
                    "documentnumber = '" + document + "' and " +
                    "revision = '" + revision + "'", cnxn2);
                cnxn2.Open();
                object o = cmd3.ExecuteScalar();

                //if the object is null then a packing list needs to be acquired
               // o = null;

                if (o == null)
                {
                    //debug line to figure out last packing list attempted
                    File.AppendAllText(@"C:\A\PackingListUpdate.txt", document + " XX  " + revision + Environment.NewLine);

                    // could be either .doc or .docx so need to check
                    //  all files need to be docx for program to open them
                    //qualifiedFile = @"\\middbweb2012\doccontrol - documents\plch6317\0301\01\A\PLch6317-0301-01A.docx";

                    if (File.Exists(qualifiedFile.ToUpper().Replace(".DOC ", ".DOCX")) == false)
                    {
                        //pull the document through Word to the clipboard
                        //and put it in a text string

                        //object file = qualifiedFile.ToUpper().Replace(".DOC", ".DOCX");
                        object file = qualifiedFile;  /*      test    */

                        try
                        {
                            Microsoft.Office.Interop.Word.Document dc =
                                oW.Documents.Open(file);

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

                            //close the document once the data has been acquired.
                            doc.Close(ref NO, ref NO, ref NO);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        
                    }
                    else if (File.Exists(qualifiedFile) == true)
                    {
                        object file = qualifiedFile;
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

                            description = line.Substring(0, desctab);

                            line = line.Substring(desctab + 1, line.Length - (desctab + 1));

                            if (item_code != "" || description != "")
                            {
                                int qtytab = line.IndexOf('\t');

                                qty = line.Substring(0, qtytab);

                                line = line.Substring(qtytab + 1, line.Length - (qtytab + 1));

                                int boxtab = line.IndexOf('\t');

                                boxes = line.Substring(0, boxtab);

                                line = line.Substring(boxtab + 1, line.Length - (boxtab + 1));

                                int installtab = line.IndexOf('\t');

                                installon = line.Substring(0, installtab);

                                kitwith = line.Substring(installtab + 1, line.Length - (installtab + 1));

                                try
                                {
                                    cnxn = new SqlConnection(db);

                                    SqlCommand cmd2 = new SqlCommand(
                                        "Insert into Labels_PackingLists (" +
                                        "documentnumber, " +
                                        "revision, " +
                                        "item_code, " +
                                        "description, " +
                                        "quantity, " +
                                        "boxes, " +
                                        "installon, " +
                                        "kitwith, " +
                                        "pldescription) " +
                                        "values (" +
                                        "@documentnumber, " +
                                        "@revision, " +
                                        "@item_code, " +
                                        "@description, " +
                                        "@quantity, " +
                                        "@boxes, " +
                                        "@installon, " +
                                        "@kitwith, " +
                                        "@pldescription)", cnxn);

                                    cmd2.Parameters.Add("@documentnumber", SqlDbType.VarChar, 20).Value = document;
                                    cmd2.Parameters.Add("@revision", SqlDbType.NChar, 5).Value = revision;
                                    cmd2.Parameters.Add("@item_code", SqlDbType.VarChar, 20).Value = item_code;
                                    cmd2.Parameters.Add("@description", SqlDbType.VarChar, 50).Value = description;
                                    cmd2.Parameters.Add("@quantity", SqlDbType.NChar, 10).Value = qty;
                                    cmd2.Parameters.Add("@boxes", SqlDbType.NChar, 10).Value = boxes;
                                    cmd2.Parameters.Add("@installon", SqlDbType.NChar, 50).Value = installon;
                                    cmd2.Parameters.Add("@kitwith", SqlDbType.NChar, 20).Value = kitwith;
                                    cmd2.Parameters.Add("@pldescription", SqlDbType.VarChar, 50).Value = plDescription;

                                    cnxn.Open();
                                    int rowsReturned = cmd2.ExecuteNonQuery();
                                    cnxn.Close();
                                }
                                catch (SqlException ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }


                                item_code = "";
                                description = "";
                                qty = "";
                                boxes = "";
                                installon = "";
                                kitwith = "";

                            }
                        }
                    }
                    
                    cnxn = new SqlConnection(db);

                    SqlCommand cmd = new SqlCommand(
                        "update Labels_packinglists set description = replace([description], nchar(188), '1/4'); " +
                        "update Labels_packinglists set description = replace([description], nchar(189), '1/2'); " +
                        "update Labels_packinglists set description = replace([description], nchar(190), '3/4'); "
                        , cnxn);

                    cnxn.Open();
                    int result = cmd.ExecuteNonQuery();
                    cnxn.Close();
                    text = "";
                }
                
               
            }
            oW.Quit();
            //close Word and program
            Close();

        }

    }
}
