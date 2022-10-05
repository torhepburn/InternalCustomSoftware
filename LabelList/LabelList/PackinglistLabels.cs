using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Data.SqlClient;
using System.IO;


namespace LabelList
{
    public partial class PackinglistLabels : Form
    {
        SqlConnection cnxn;
        SqlDataReader dr;
        SqlDataAdapter da;
        private string db = "server = MIDSQL01; user = ReadWrite; password = Read+Write!; " +
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
        
        public PackinglistLabels()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bPrint.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            bBack.Visible = false;
            //fileList = Directory.GetFiles(@"C:\labels\generic", "zebrageneric1text*.btw");
            //int qtyFiles = fileList.Length;

            //for (int i = 0; i < qtyFiles; i++)
            //{
            //    LBox.Items.Add(fileList[i].Substring(fileList[i].LastIndexOf(@"\") + 1));
            //}

            //if (qtyFiles < 1)
            //{
            //    LBox.Items.Add("Printer Setup Required.");
            //}
            
            
            //go to MIDSQL01.dbo.AccessFrontEnds and get list of
            //packinglists from a view which goes out to middbweb
            //and gets the doc control packinglist list

            //cnxn = new SqlConnection(db);
            //SqlCommand cmd = new SqlCommand(
            //    "select documentnumber, revision, destinationfile from " +
            //    "labels_lup_items_with_partslist ", cnxn); // + 
            //    //"where documentnumber = 'pl6090-0232-10' and revision = 'C'", cnxn);
            //cnxn.Open();

            //try
            //{
            //    dr = cmd.ExecuteReader();
            //}
            //catch (SqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            ////prepare Word to be able to open the packing lists
            
            //Microsoft.Office.Interop.Word.Application oW;
            //oW = new Microsoft.Office.Interop.Word.Application();
            
            ////put the list of packinglists in a data reader to be able
            ////to go through one by one

            //while (dr.Read())
            //{
            //    document = dr.GetString(0).Trim();
            //    revision = dr.GetString(1).Trim();
            //    qualifiedFile = dr.GetString(2).Trim();

            //    //check to see if the packinglist for a specific revision
            //    //has already been put in the database
                
            //    SqlConnection cnxn2 = new SqlConnection(db);

            //    SqlCommand cmd3 = new SqlCommand(
            //        "select distinct documentnumber from " +
            //        "labels_packinglists where " +
            //        "documentnumber = '" + document + "' and " +
            //        "revision = '" + revision + "'", cnxn2);
            //    cnxn2.Open();
            //    object o = cmd3.ExecuteScalar();

            //    //if the object is null then a packing list needs to be acquired

            //    if ( o == null )
            //    {

            //        if (File.Exists(qualifiedFile) == true)
            //        {
            //            //pull the document through Word to the clipboard
            //            //and put it in a text string
                       
            //            object file = qualifiedFile;
            //            object NO = System.Reflection.Missing.Value;
            //            Microsoft.Office.Interop.Word.Document doc =
            //                oW.Documents.Open(ref file, ref NO, ref NO,
            //                ref NO, ref NO, ref NO,
            //                ref NO, ref NO, ref NO,
            //                ref NO, ref NO, ref NO);
            //            doc.ActiveWindow.Selection.WholeStory();
            //            doc.ActiveWindow.Selection.Copy();
            //            IDataObject data = Clipboard.GetDataObject();
            //            text = data.GetData(DataFormats.Text).ToString();
                        
            //            //close the document once the data has been acquired.
            //            doc.Close(ref NO, ref NO, ref NO);
                        
            //        }
            //        else
            //        {
            //            text = "";
            //        }

            //        //the packing lists with the correct format have KIT WITH in the headers

            //        int start = text.IndexOf("KIT WITH") + 12;
            //        if (start < 12)
            //        {
            //            text = "";
            //        }
            //        else
            //        {
            //            text = text.Substring(start, text.Length - start);
            //        }

            //        //take the text and break it by carriage returns and 
            //        //process it

            //        while (text.Length > 0)
            //        {

            //            int end = text.Substring(0, text.Length).IndexOf('\r');

            //            string line = text.Substring(0, end);

            //            int ictab = line.IndexOf('\t');

            //            item_code = line.Substring(0, ictab);

            //            line = line.Substring(ictab + 1, line.Length - (ictab + 1));

            //            int desctab = line.IndexOf('\t');

            //            description = line.Substring(0, desctab);

            //            line = line.Substring(desctab + 1, line.Length - (desctab + 1));

            //            if (item_code != "" || description != "")
            //            {
            //                int qtytab = line.IndexOf('\t');

            //                qty = line.Substring(0, qtytab);

            //                line = line.Substring(qtytab + 1, line.Length - (qtytab + 1));

            //                int boxtab = line.IndexOf('\t');

            //                boxes = line.Substring(0, boxtab);

            //                line = line.Substring(boxtab + 1, line.Length - (boxtab + 1));

            //                int installtab = line.IndexOf('\t');

            //                installon = line.Substring(0, installtab);

            //                kitwith = line.Substring(installtab + 1, line.Length - (installtab + 1));


            //                try
            //                {
            //                    cnxn = new SqlConnection(db);

            //                    SqlCommand cmd2 = new SqlCommand(
            //                        "Insert into Labels_PackingLists (" +
            //                        "documentnumber, " +
            //                        "revision, " +
            //                        "item_code, " +
            //                        "description, " +
            //                        "quantity, " +
            //                        "boxes, " +
            //                        "installon, " +
            //                        "kitwith) " +
            //                        "values (" +
            //                        "@documentnumber, " +
            //                        "@revision, " +
            //                        "@item_code, " +
            //                        "@description, " +
            //                        "@quantity, " +
            //                        "@boxes, " +
            //                        "@installon, " +
            //                        "@kitwith)", cnxn);

            //                    cmd2.Parameters.Add("@documentnumber", SqlDbType.VarChar, 20).Value = document;
            //                    cmd2.Parameters.Add("@revision", SqlDbType.NChar, 5).Value = revision;
            //                    cmd2.Parameters.Add("@item_code", SqlDbType.VarChar, 20).Value = item_code;
            //                    cmd2.Parameters.Add("@description", SqlDbType.VarChar, 50).Value = description;
            //                    cmd2.Parameters.Add("@quantity", SqlDbType.NChar, 10).Value = qty;
            //                    cmd2.Parameters.Add("@boxes", SqlDbType.NChar, 10).Value = boxes;
            //                    cmd2.Parameters.Add("@installon", SqlDbType.NChar, 50).Value = installon;
            //                    cmd2.Parameters.Add("@kitwith", SqlDbType.NChar, 20).Value = kitwith;

            //                    cnxn.Open();
            //                    int rowsReturned = cmd2.ExecuteNonQuery();
            //                    cnxn.Close();
            //                }
            //                catch (SqlException ex)
            //                {
            //                    MessageBox.Show(ex.Message);
            //                }

            //                //NOTES appears at the end of the packing list after all the lines of data
            //                //
            //                //Issues with tabs and two digit numbers so +3 or +4

            //                if (text.Length > (end + 4) && (text.IndexOf("Notes") > (end + 4)))
            //                {
            //                    if (text.Substring(end + 3, 1) == "\t")
            //                    {
            //                        text = text.Substring((end + 3), text.Length - (end + 3));
            //                    }
            //                    else
            //                    {
            //                        text = text.Substring((end + 4), text.Length - (end + 4));
            //                    }
            //                }
            //                else
            //                {
            //                    text = "";
            //                }

            //                if (text.IndexOf('\t') == 0)
            //                {
            //                    text = text.Substring((1), text.Length - 1);
            //                }

            //            }
            //            else
            //            {
            //                text = "";
            //            }

            //            item_code = "";
            //            description = "";
            //            qty = "";
            //            boxes = "";
            //            installon = "";
            //            kitwith = "";
            //        }
            //        text = "";

                    
            //    }
            //}
            ////close Word and program
            //oW.Quit();

            ////Replace troublesome fraction characters with written out fractions

            //cnxn = new SqlConnection(db);

            //cmd = new SqlCommand(
            //    "update Labels_packinglists set description = replace([description], nchar(188), '1/4'); " +
            //    "update Labels_packinglists set description = replace([description], nchar(189), '1/2'); " +
            //    "update Labels_packinglists set description = replace([description], nchar(190), '3/4'); "
            //    , cnxn);

            //cnxn.Open();
            //int result = cmd.ExecuteNonQuery();
            //cnxn.Close();

            cnxn = new SqlConnection(db);
            da = new SqlDataAdapter(
                "Select distinct documentnumber [Packing List], pldescription [Description], Revision " +
                "from labels_packinglists", cnxn);
            System.Data.DataTable table = new System.Data.DataTable();
            da.Fill(table);
            DGV.DataSource = table;
            DGV.Show();

            DGV.Columns[0].Width = 110;
            DGV.Columns[1].Width = 280;
            DGV.Columns[2].Width = 70;

        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (flag != "selected")
            {
                if (e.RowIndex == -1 && e.ColumnIndex == 1)
                {
                    return;
                }
                else
                {
                    label4.Visible = false;

                    DataGridViewTextBoxCell cell = 
                        (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                    document = cell.EditedFormattedValue.ToString().Trim();

                    cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                    description = cell.EditedFormattedValue.ToString().Trim();

                    cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                    revision = cell.EditedFormattedValue.ToString().Trim();

                    bBack.Visible = true;
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;

                    label1.Text = document;
                    label2.Text = description;
                    label3.Text = revision;

                    da = new SqlDataAdapter(
                        "Select " +
                        "item_code, " +
                        "description, " +
                        "quantity, " +
                        "boxes "+
                        "from labels_packinglists " +
                        "where documentnumber = '" + document + "' " +
                        "and revision = '" + revision + "'", cnxn);

                    System.Data.DataTable table2 = new System.Data.DataTable();
                    da.Fill(table2);

                    DGV.DataSource = table2;
                    DGV.Show();

                    DGV.Columns[0].Width = 100;
                    DGV.Columns[1].Width = 200;
                    DGV.Columns[2].Width = 50;
                    DGV.Columns[3].Width = 50;

                    bPrint.Visible = true;
                    flag = "selected";

                }

            }

        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(db);
            cnxn.Open();
            SqlCommand cmd = new SqlCommand(
                "Select " +
                "item_code, " +
                "description, " +
                "quantity, " +
                "boxes " +
                "from labels_packinglists " +
                "where documentnumber = '" + document + "' " +
                "and revision = '" + revision + "'", cnxn);

            dr = cmd.ExecuteReader();

            File.WriteAllText(label,
                    "Copies \t PartNo \t Description \t SN \t QTY \t REV \t PartXofY" + Environment.NewLine);

            while (dr.Read())
            {
                BoxCount = dr.GetInt32(3);
                if (BoxCount == 0)
                {
                    BoxCount = 1;
                }

                for (int i = 1; i <= BoxCount; i++ )
                {
                    File.AppendAllText(label, "1 \t " + dr.GetString(0).Trim() +
                        "\t" + dr.GetString(1) + "\t\t Qty: " + dr.GetString(2).Trim() +
                        "\t # of Boxes: " + BoxCount.ToString() + Environment.NewLine);
                }

            }

           ////System.Diagnostics.Process.Start("C:\\Program Files (x86)\\Seagull" +
           //     "\\Bartender Suite\\bartend.exe",
           //     "/P /X /F=\\\\zygocorp\\departments\\shiprcvg\\labels\\labelformats\\zebrageneric1text_sn19.btw/d=" +
           //     "c:\\labels\\generic\\genericlabel.txt");

            
            this.Close();
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(db);
            da = new SqlDataAdapter(
                "Select distinct documentnumber [Packing List], pldescription [Description], Revision " +
                "from labels_packinglists", cnxn);
            System.Data.DataTable table = new System.Data.DataTable();
            da.Fill(table);
            DGV.DataSource = table;
            DGV.Show();

            DGV.Columns[0].Width = 110;
            DGV.Columns[1].Width = 280;
            DGV.Columns[2].Width = 70;

            bPrint.Visible = false;
            flag = "";
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = true;
            bBack.Visible = false;
        }
        
           
    }

    public static class g
    {
        public static string printer;
        public static string printertype;
        //public static string taskhistory;
        //public static string userType;

        //public static string facility;
        //public static string emailFrom;

        //public static string location;
        //public static string Ldescription;
        //public static string room;
        //public static string Rdescription;
        //public static string Rnotes;
        //public static int rID;
        //public static string eBadgeID;
        //public static string iID;
        //public static string iDescription;
        //public static int internalCalContact;
        //public static int cdID;                 //calibration data id
        //public static string rpt_status;
        //public static string rpt_CalSource;
        //public static string rpt_earliestDueDate;
        //public static string rpt_latestDueDate;
        //public static string rpt_room;
        //public static string rpt_type;
        //public static string pdf;
        public static string db = "server = midsql01; password = Read+Write!; " +
                                  "user = readwrite; database = AccessFrontEnds;";

    }
    
}
