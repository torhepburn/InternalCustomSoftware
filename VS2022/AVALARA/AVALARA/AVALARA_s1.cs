using System.Data.SqlClient;
using System.Data;

namespace AVALARA
{
    public partial class AVALARA_s1 : Form
    {
        private string dataMonth = string.Empty;
        private string dataYear = string.Empty;

        public AVALARA_s1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Program Running";

            SqlConnection cnxn = new SqlConnection("server = CT-MID-SQL11; Database = AccessFrontEnds; " +
                            "user = readWrite; password = Read+Write!;");
            SqlConnection cnxnNAV = new SqlConnection("server = PA-HOR-AS408; Database = ZYGO-NAV-PROD; " +
                            "user = navdb_read; password = 2018#ameteK;");

            SqlCommand cmd = new SqlCommand("TRUNCATE TABLE AVALARA_match", cnxn);

            try
            {
                cnxn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            Directory.CreateDirectory(@"C:\A");

            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\A\\";
                openFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx|xlsx files (*.xlsx)|*.xlsx";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    Microsoft.Office.Interop.Excel.Application xlapp;
                    Microsoft.Office.Interop.Excel.Workbook wbook;
                    Microsoft.Office.Interop.Excel.Worksheet wsheet;

                    xlapp = new Microsoft.Office.Interop.Excel.Application();
                    xlapp.Visible = false;
                    xlapp.DisplayAlerts = false;
                    wbook = xlapp.Workbooks.Open(filePath);
                    wbook = xlapp.ActiveWorkbook;
                    wsheet = (Microsoft.Office.Interop.Excel.Worksheet)xlapp.ActiveSheet;
                    wsheet.UsedRange.Copy();

                    string text = Clipboard.GetText();

                    Clipboard.Clear();

                    wbook.Close(true);
                    xlapp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlapp);

                    File.Copy(filePath, filePath.Replace(".xlsx", " mod.xlsx"));

                    filePath = filePath.Replace(".xlsx", " mod.xlsx");

                    string[] lines = text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

                    int w = lines.Count();
                    //Read the contents of the file into a stream

                    for (int ii = 14; ii < (lines.Length - 5); ii++)
                    {
                        int numbertab = lines[ii].IndexOf('\t');

                        string DocumentNumber = lines[ii].Substring(0, numbertab);

                        string line = lines[ii].Substring(numbertab + 1, lines[ii].Length - (numbertab + 1));

                        int ictab = line.IndexOf('\t');

                        string CustomerNumber = line.Substring(0, ictab);

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

                        TaxAmount = TaxAmount.Replace("$", "");
                        TaxAmount = TaxAmount.Replace(",", "");

                        cmd = new SqlCommand(
                            "INSERT INTO AVALARA_match (" +
                            " DocumentCode " +
                            ",DocumentDate " +
                            ",TotalSales " +
                            ",TaxAmount" +
                            ",[AVALARA Line No] " +
                            ",CustomerNo) " +
                            "values (" +
                            "'" + DocumentNumber + "'" +
                            ",'" + PostingDate + "'" +
                            "," + TotalAmount +
                            "," + TaxAmount +
                            "," + ii +
                            ",'" + CustomerNumber + "')", cnxn);

                        try
                        {
                            cnxn.Open();
                            cmd.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {

                            MessageBox.Show(ex.ToString());
                        }
                        finally
                        {
                            cnxn.Close();
                        }
                    }
                }
            }

            cmd = new SqlCommand("TRUNCATE TABLE AVALARA_s1_NAVinvoiceData", cnxn);

            try
            {
                cnxn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            cmd = new SqlCommand("SELECT TOP 1 " +
                "YEAR(DocumentDate) " +
                ",MONTH(DocumentDate) " +
                "FROM AVALARA_match", cnxn);

            SqlDataReader dr;

            try
            {
                cnxn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dataYear = dr.GetInt32(0).ToString();
                    dataMonth = dr.GetInt32(1).ToString();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            cmd = new SqlCommand(
            "WITH s1 AS" +
                "(" +
                " SELECT " +
                "  vih.[Location Code]" +
                ", vih.[Ship-to Name]" +
                ", vih.[Customer No_][Customer No] " +
                ", vih.[Your Reference] " +
                ", vih.[No_] " +
                ", vih.[Posting Date] " +
                ", SUM([Line Amount]) Amount " +
                ", SUM([Amount Including VAT]) [Amount Including VAT] " +
                ", SUM([Amount Including VAT]) -SUM([Line Amount]) [Sales Tax] " +
                ", [Ship-to City] " +
                ", [Ship-to County] " +
                ", [Ship-to Country_Region Code] " +
                " FROM[ZYGO$Service Invoice Header] vih " +
                "LEFT JOIN[ZYGO$Service Invoice Line] vil on vih.No_ = vil.[Document No_] " +
                "WHERE YEAR(vih.[Posting Date]) = " + dataYear + " " +
                "AND MONTH(vih.[Posting Date]) = " + dataMonth + " " +
                "AND[Ship-to Country_Region Code] IN ('USA', 'PRI') " +
                "GROUP BY " +
                "  vih.[Location Code] " +
                ", vih.[Ship-to Name] " +
                ", vih.[Customer No_] " +
                ", vih.[Your Reference] " +
                ", vih.[No_] " +
                ", vih.[Posting Date] " +
                ", [Ship-to City] " +
                ", [Ship-to County] " +
                ", [Ship-to Country_Region Code] " +
                " UNION " +
                "  SELECT " +
                "  sih.[Location Code] " +
                ", sih.[Ship-to Name] " +
                ", sih.[Sell-to Customer No_][Customer No] " +
                ", sih.[Your Reference] " +
                ", sih.[No_] " +
                ", sih.[Posting Date] " +
                ", SUM([Amount]) Amount " +
                ", SUM([Amount Including VAT]) [Amount Including VAT] " +
                ", SUM([Amount Including VAT]) -SUM([Amount]) [Sales Tax] " +
                ", [Ship-to City] " +
                ", [Ship-to County] " +
                ", [Ship-to Country_Region Code] " +
                " FROM[ZYGO$Sales Invoice Header] sih " +
                "LEFT JOIN[ZYGO$Sales Invoice Line] sil on sil.[Document No_] = sih.[No_] " +
                "WHERE YEAR(sih.[Posting Date]) = " + dataYear + " " +
                "AND MONTH(sih.[Posting Date]) = " + dataMonth + " " +
                " AND[Ship-to Country_Region Code]  IN('USA', 'PRI') " +
                " GROUP BY " +
                "  sih.[Location Code] " +
                ", sih.[Ship-to Name] " +
                ", sih.[Sell-to Customer No_] " +
                ", sih.[Your Reference] " +
                ", sih.[No_] " +
                ", sih.[Posting Date] " +
                ", [Ship-to City] " +
                ", [Ship-to County] " +
                ", [Ship-to Country_Region Code] " +
                "UNION " +
                "SELECT " +
                "  sch.[Location Code] " +
                ", sch.[Ship-to Name] " +
                ", sch.[Bill-to Customer No_][Customer No] " +
                ", sch.[Your Reference] " +
                ", sch.[No_] " +
                ", sch.[Posting Date] " +
                ", SUM([Amount]) Amount " +
                ", SUM([Amount Including VAT]) [Amount Including VAT] " +
                ", SUM([Amount Including VAT]) -SUM([Amount]) [Sales Tax] " +
                ", [Ship-to City] " +
                ", [Ship-to County] " +
                ", [Ship-to Country_Region Code] " +
                " FROM[ZYGO$Sales Cr_Memo Header] sch " +
                "LEFT JOIN[ZYGO$Sales Cr_Memo Line] scl on scl.[Document No_] = sch.[No_] " +
                "WHERE YEAR(sch.[Posting Date]) = " + dataYear + " " +
                "AND MONTH(sch.[Posting Date]) = " + dataMonth + " " +
                " AND[Ship-to Country_Region Code]  IN('USA', 'PRI') " +
                " GROUP BY " +
                "  sch.[Location Code] " +
                ", sch.[Ship-to Name] " +
                ", sch.[Bill-to Customer No_] " +
                ", sch.[Your Reference] " +
                ", sch.[No_] " +
                ", sch.[Posting Date] " +
                ", [Ship-to City] " +
                ", [Ship-to County] " +
                ", [Ship-to Country_Region Code] " +
                "UNION " +
                "SELECT " +
                "  vch.[Location Code] " +
                ", vch.[Ship-to Name] " +
                ", vch.[Bill-to Customer No_][Customer No] " +
                ", vch.[Your Reference] " +
                ", vch.[No_] " +
                ", vch.[Posting Date] " +
                ", SUM([Amount]) Amount " +
                ", SUM([Amount Including VAT]) [Amount Including VAT] " +
                ", (SUM([Amount Including VAT]) - SUM([Amount])) [Sales Tax] " +
                ", vch.[Ship-to City] " +
                ", vch.[Ship-to County] " +
                ", vch.[Ship-to Country_Region Code] " +
                " FROM[ZYGO$Service Cr_Memo Header] vch " +
                "LEFT JOIN[ZYGO$Service Cr_Memo Line] vcl on vcl.[Document No_] = vch.[No_] " +
                 "WHERE YEAR(vch.[Posting Date]) = " + dataYear + " " +
                "AND MONTH(vch.[Posting Date]) = " + dataMonth + " " +
                " AND[Ship-to Country_Region Code] IN('USA', 'PRI') " +
                " GROUP BY " +
                "  vch.[Location Code] " +
                ", vch.[Ship-to Name] " +
                ", vch.[Bill-to Customer No_] " +
                ", vch.[Your Reference] " +
                ", vch.[No_] " +
                ", vch.[Posting Date] " +
                ", vch.[Ship-to City] " +
                ", vch.[Ship-to County] " +
                 ", [Ship-to Country_Region Code] " +
                ") " +
                "select* from s1 " +
                "order by[Posting Date]", cnxnNAV);

            try
            {
                cnxnNAV.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    SqlCommand cmd1 = new SqlCommand(
                        "INSERT INTO [AVALARA_s1_NAVinvoiceData] " +
                        "(" +
                        " [Location Code] " +
                        ",[Ship-to Name] " +
                        ",[Customer No] " +
                        ",[Your Reference] " +
                        ",[No_] " +
                        ",[Posting Date] " +
                        ",[Amount] " +
                        ",[Amount Including VAT] " +
                        ",[Sales Tax] " +
                        ",[Ship-to City] " +
                        ",[Ship-to County] " +
                        ",[Ship-to Country_Region Code] " +
                        ") VALUES (" +
                        "'" + dr.GetString(0) +
                        "','" + dr.GetString(1) +
                        "','" + dr.GetString(2) +
                        "','" + dr.GetString(3) +
                        "','" + dr.GetString(4) +
                        "','" + dr.GetDateTime(5) +
                        "'," + dr.GetDecimal(6) +
                        "," + dr.GetDecimal(7) +
                        "," + dr.GetDecimal(8) +
                        ",'" + dr.GetString(9) +
                        "','" + dr.GetString(10) +
                        "','" + dr.GetString(11) + "')", cnxn);

                    try
                    {
                        cnxn.Open();
                        cmd1.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        cnxn.Close();
                    }
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }


            string[] aCustomer = new string[500];
            string[] aCity = new string[500];
            string[] aState = new string[500];
            string[] aLocation = new string[500];
            int i = 0;

            cmd = new SqlCommand(
                "SELECT " +
                " COALESCE([Ship-to Name],'') " +
                ",COALESCE([Ship-to City],'') " +
                ",COALESCE([Ship-to County],'') " +
                ",COALESCE([Location Code],'') " +
                "FROM AVALARA_match a " +
                "LEFT JOIN AVALARA_s1_NAVinvoiceData t ON a.CustomerNo = t.[Customer No] " +
                "AND a.DocumentCode = t.No_ " +
                "ORDER BY [AVALARA Line No] ", cnxn);

            try
            {
                cnxn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    aCustomer[i] = dr.GetString(0);
                    aCity[i] = dr.GetString(1);
                    if (dr.GetString(2).Length > 0)
                    {
                        aState[i] = dr.GetString(2);
                    }
                    else
                    {
                        aState[i] = "NoState";
                    }
                    aLocation[i] = dr.GetString(3);
                    i++;
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            Microsoft.Office.Interop.Excel.Application xlappM;
            Microsoft.Office.Interop.Excel.Workbook wbookM;
            Microsoft.Office.Interop.Excel.Worksheet wsheetM;

            xlappM = new Microsoft.Office.Interop.Excel.Application();
            xlappM.Visible = false;
            xlappM.DisplayAlerts = false;
            wbookM = xlappM.Workbooks.Open(filePath);
            wbookM = xlappM.ActiveWorkbook;
            wsheetM = (Microsoft.Office.Interop.Excel.Worksheet)xlappM.ActiveSheet;

            wsheetM.Cells[14, 9] = "Customer Name";
            wsheetM.Cells[14, 10] = "Ship to City";
            wsheetM.Cells[14, 11] = "Ship to State";
            wsheetM.Cells[14, 12] = "Ship from Location";

            for (int n = 0; n < i; n++)
            {
                wsheetM.Cells[(15 + n), 9] = aCustomer[n];
                wsheetM.Cells[(15 + n), 10] = aCity[n];
                wsheetM.Cells[(15 + n), 11] = aState[n];
                wsheetM.Cells[(15 + n), 12] = aLocation[n];
            }

            wsheetM.Columns.AutoFit();

            wbookM.Save();
            

            /*  Mismatch Report  */


            string[] aMatch = new string[500];
            string[] aAVDocCode = new string[500];
            DateTime[] aDocDate = new DateTime[500];
            decimal[] aTotalSales = new decimal[500];
            decimal[] aTaxAmount = new decimal[500];
            int[] aAVALineNo = new int[500];
            string[] aAVCustomerNo = new string[500];
            string[] aLoc = new string[500];
            string[] aCusName = new string[500];
            string[] aCusNo = new string[500];
            string[] aRef = new string[500];
            string[] aDocNo = new string[500];
            DateTime[] aPostDate = new DateTime[500];
            decimal[] aAmount = new decimal[500];
            decimal[] aAplusVAT = new decimal[500];
            decimal[] aSalesTax = new decimal[500];
            string[] aNCity = new string[500];
            string[] aNState = new string[500];

            int j = 0;

            try
            {
                cnxn.Open();
                cmd = new SqlCommand("spAVALARAmismatch", cnxn);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    aMatch[j] = dr.GetString(0);
                    aAVDocCode[j] = dr.GetString(1);
                    aDocDate[j] = dr.GetDateTime(2);
                    aTotalSales[j] = dr.GetDecimal(3);
                    aTaxAmount[j] = dr.GetDecimal(4);
                    aAVALineNo[j] = dr.GetInt32(5);
                    aAVCustomerNo[j] = dr.GetString(6);
                    aLoc[j] = dr.GetString(7);
                    aCusName[j] = dr.GetString(8);
                    aCusNo[j] = dr.GetString(9);
                    aRef[j] = dr.GetString(10);
                    aDocNo[j] = dr.GetString(11);
                    aPostDate[j] = dr.GetDateTime(12);
                    aAmount[j] = dr.GetDecimal(13);
                    aAplusVAT[j] = dr.GetDecimal(14);
                    aSalesTax[j] = dr.GetDecimal(15);
                    aNCity[j] = dr.GetString(16);
                    aNState[j] = dr.GetString(17);
                    j++;
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)wbookM.Worksheets.Add();
            worksheet.Name = "Mismatches";

            wsheetM = (Microsoft.Office.Interop.Excel.Worksheet)xlappM.ActiveSheet;

            wsheetM.Cells[1, 1] = "Mismatch";
            wsheetM.Cells[1, 2] = "DocumentCode";
            wsheetM.Cells[1, 3] = "DocumentDate";
            wsheetM.Cells[1, 4] = "TotalSales";
            wsheetM.Cells[1, 5] = "TaxAmount";
            wsheetM.Cells[1, 6] = "AVALARA Line No";
            wsheetM.Cells[1, 7] = "CustomerNo";
            wsheetM.Cells[1, 8] = "Location Code";
            wsheetM.Cells[1, 9] = "Ship-to Name";
            wsheetM.Cells[1, 10] = "NAV Customer No";
            wsheetM.Cells[1, 11] = "Your Reference";
            wsheetM.Cells[1, 12] = "Document No";
            wsheetM.Cells[1, 13] = "Posting Date";
            wsheetM.Cells[1, 14] = "Amount";
            wsheetM.Cells[1, 15] = "Amount Including VAT";
            wsheetM.Cells[1, 16] = "Sales Tax";
            wsheetM.Cells[1, 17] = "Ship-to City";
            wsheetM.Cells[1, 18] = "Ship-to State";

            for (int n = 0; n < j; n++)
            {
                wsheetM.Cells[(2 + n), 1] = aMatch[n];
                wsheetM.Cells[(2 + n), 2] = aAVDocCode[n];
                wsheetM.Cells[(2 + n), 3] = aDocDate[n];
                wsheetM.Cells[(2 + n), 4] = aTotalSales[n];
                wsheetM.Cells[(2 + n), 5] = aTaxAmount[n];
                wsheetM.Cells[(2 + n), 6] = aAVALineNo[n];
                wsheetM.Cells[(2 + n), 7] = aAVCustomerNo[n];
                wsheetM.Cells[(2 + n), 8] = aLoc[n];
                wsheetM.Cells[(2 + n), 9] = aCusName[n];
                wsheetM.Cells[(2 + n), 10] = aCusNo[n];
                wsheetM.Cells[(2 + n), 11] = aRef[n];
                wsheetM.Cells[(2 + n), 12] = aDocNo[n];
                wsheetM.Cells[(2 + n), 13] = aPostDate[n];
                wsheetM.Cells[(2 + n), 14] = aAmount[n];
                wsheetM.Cells[(2 + n), 15] = aAplusVAT[n];
                wsheetM.Cells[(2 + n), 16] = aSalesTax[n];
                wsheetM.Cells[(2 + n), 17] = aNCity[n];
                wsheetM.Cells[(2 + n), 18] = aNState[n];
            }

            wsheetM.Columns.AutoFit();

            wbookM.Save();
            wbookM.Close(null, null, null);
            xlappM.Quit();

            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlappM);

            System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("Excel");
            foreach (System.Diagnostics.Process p in process)
            {
                if (!string.IsNullOrEmpty(p.ProcessName))
                {
                    try
                    {
                        p.Kill();
                    }
                    catch { }
                }
            }

            /*      State Section       */

            SqlConnection cnxn2 = new SqlConnection("server = CT-MID-SQL11; Database = AccessFrontEnds; " +
                            "user = readWrite; password = Read+Write!;");

            cmd = new SqlCommand("SELECT DISTINCT [Ship-to County] FROM AVALARA_s1_NAVinvoiceData", cnxn);

            try
            {
                cnxn.Open();
                dr = cmd.ExecuteReader();

                DataTable t = new DataTable();
                t.Load(dr);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var filePath1 = filePath;
                    var state = string.Empty;
                    //filePath1 = @"c:\A\US DocumentSummaryReport - 2023.01 mod.xlsx";
                    if (dr.GetString(0).Length > 0)
                    {
                        state = dr.GetString(0);
                    }
                    else
                    {
                        state = "NoState";
                    }

                    filePath1 = filePath1.Replace("US",state + " US" );
                    filePath1 = filePath1.Replace("mod.xlsx", ".xlsx");
                    File.Copy(filePath, filePath1);

                    Microsoft.Office.Interop.Excel.Application xlappM1;
                    Microsoft.Office.Interop.Excel.Workbook wbookM1;
                    Microsoft.Office.Interop.Excel.Worksheet wsheetM1;

                    xlappM1 = new Microsoft.Office.Interop.Excel.Application();
                    xlappM1.Visible = false;
                    /* could set to false but then wouldn't know if program was working ? */
                    xlappM1.DisplayAlerts = false;
                    wbookM1 = xlappM1.Workbooks.Open(filePath1);
                    wbookM1 = xlappM1.ActiveWorkbook;
                    wsheetM1 = (Microsoft.Office.Interop.Excel.Worksheet)xlappM1.ActiveSheet;
                    wsheetM1.Delete();
                    wsheetM1 = (Microsoft.Office.Interop.Excel.Worksheet)xlappM1.ActiveSheet;

                    wsheetM1.Cells[9, 2] = dr.GetString(0).Trim();

                    Microsoft.Office.Interop.Excel.Range range = wsheetM1.Range["A15", "A500"];
                    Microsoft.Office.Interop.Excel.Range entireRow = range.EntireRow;

                    entireRow.Delete();

                    SqlCommand cmd1 = new SqlCommand(
                       " SELECT " +
                       "  DocumentCode " +
                       ", CustomerNo " +
                       ", DocumentDate " +
                       ", TotalSales " +
                       ", 0.0 " +
                       ",CASE " +
                       "    WHEN [Sales Tax] = 0 THEN Amount" +
                       "    ELSE 0" +
                       "  END " +
                       ", CASE WHEN [Sales Tax] > 0 THEN Amount" +
                       "    ELSE 0" +
                       "  END " +
                       ", [Sales Tax] " +
                       ", [Ship-to Name] " +
                       ", [Ship-to City] " +
                       ", [Ship-to County] " +
                       ", [Location Code] " +
                       " FROM AVALARA_match a " +
                       " LEFT JOIN AVALARA_s1_NAVinvoiceData t ON a.CustomerNo = t.[Customer No] " +
                       " AND a.DocumentCode = t.No_ " +
                       " WHERE[Ship-to County] = '" + dr.GetString(0) + "' " +
                       " ORDER BY[AVALARA Line No] ", cnxn2);

                    string[] aDoc = new string[500];
                    string[] aCust = new string[500];
                    string[] aDate = new string[500];
                    decimal[] aTot = new decimal[500];
                    decimal[] aDisc = new decimal[500];
                    decimal[] aAmountNT = new decimal[500];
                    decimal[] aAmountT = new decimal[500];
                    decimal[] aTax = new decimal[500];
                    string[] aName = new string[500];
                    string[] aCity1 = new string[500];
                    string[] aState1 = new string[500];
                    string[] aLoc1 = new string[500];

                    int i1 = 0;

                    try
                    {
                        cnxn2.Open();
                        SqlDataReader dr2 = cmd1.ExecuteReader();

                        while (dr2.Read())
                        {


                            aDoc[i1] = dr2.GetString(0).Trim();
                            aCust[i1] = dr2.GetString(1).Trim();
                            aDate[i1] = dr2.GetDateTime(2).ToShortDateString().Trim();
                            aTot[i1] = dr2.GetDecimal(3);
                            aDisc[i1] = dr2.GetDecimal(4);
                            aAmountNT[i1] = dr2.GetDecimal(5);
                            aAmountT[i1] = dr2.GetDecimal(6);
                            aTax[i1] = dr2.GetDecimal(7);
                            aName[i1] = dr2.GetString(8).Trim();
                            aCity1[i1] = dr2.GetString(9).Trim();
                            aState1[i1] = dr2.GetString(10).Trim();
                            aLoc1[i1] = dr2.GetString(11).Trim();
                            i1++;
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        cnxn2.Close();
                    }

                    for (int n = 0; n < i1; n++)
                    {
                        wsheetM1.Cells[(15 + n), 1] = aDoc[n];
                        wsheetM1.Cells[(15 + n), 2] = aCust[n];
                        wsheetM1.Cells[(15 + n), 3] = aDate[n];
                        wsheetM1.Cells[(15 + n), 4] = aTot[n];
                        wsheetM1.Cells[(15 + n), 5] = aDisc[n];
                        wsheetM1.Cells[(15 + n), 6] = aAmountNT[n];
                        wsheetM1.Cells[(15 + n), 7] = aAmountT[n];
                        wsheetM1.Cells[(15 + n), 8] = aTax[n];
                        wsheetM1.Cells[(15 + n), 9] = aName[n];
                        wsheetM1.Cells[(15 + n), 10] = aCity1[n];
                        wsheetM1.Cells[(15 + n), 11] = aState1[n];
                        wsheetM1.Cells[(15 + n), 12] = aLoc1[n];
                    }

                    wsheetM1.Cells[(15 + i1), 1] = "";

                    cmd1 = new SqlCommand("SELECT " +
                        "SUM(TotalSales) " +
                        ",SUM(CASE " +
                        "    WHEN [Sales Tax] = 0 THEN Amount" +
                        "    ELSE 0 " +
                        "END) " +
                       ",SUM(CASE WHEN [Sales Tax] > 0 THEN Amount" +
                       "    ELSE 0 " +
                       "    END)" +
                        ",SUM([Sales Tax]) " +
                        "FROM AVALARA_match a " +
                        " LEFT JOIN AVALARA_s1_NAVinvoiceData t ON a.CustomerNo = t.[Customer No] " +
                        " AND a.DocumentCode = t.No_ " +
                        " WHERE[Ship-to County] = '" + dr.GetString(0) + "' ", cnxn2);

                    DataTable dt = new DataTable();

                    try
                    {
                        cnxn2.Open();
                        SqlDataReader dr2 = cmd1.ExecuteReader();

                        dt.Load(dr2);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        cnxn2.Close();
                    }

                    wsheetM1.Cells[(15 + i1 + 2), 1] = "Company Total";
                    wsheetM1.Cells[(15 + i1 + 2), 4] = dt.Rows[0][0].ToString();
                    wsheetM1.Cells[(15 + i1 + 2), 5] = "0.00";
                    wsheetM1.Cells[(15 + i1 + 2), 6] = dt.Rows[0][1].ToString();
                    wsheetM1.Cells[(15 + i1 + 2), 7] = dt.Rows[0][2].ToString();
                    wsheetM1.Cells[(15 + i1 + 2), 8] = dt.Rows[0][3].ToString();

                    wsheetM1.Cells[(15 + i1 + 4), 1] = "Grand Total";
                    wsheetM1.Cells[(15 + i1 + 4), 4] = dt.Rows[0][0].ToString();
                    wsheetM1.Cells[(15 + i1 + 4), 5] = "0.00";
                    wsheetM1.Cells[(15 + i1 + 4), 6] = dt.Rows[0][1].ToString();
                    wsheetM1.Cells[(15 + i1 + 4), 7] = dt.Rows[0][2].ToString();
                    wsheetM1.Cells[(15 + i1 + 4), 8] = dt.Rows[0][3].ToString();

                    wbookM1.Save();

                    wbookM1.Close(null, null, null);
                    xlappM1.Quit();
                    //Microsoft.Office.Interop.Excel = null;
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlappM1);

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            System.Diagnostics.Process[] process1 = System.Diagnostics.Process.GetProcessesByName("Excel");
            foreach (System.Diagnostics.Process p in process1)
            {
                if (!string.IsNullOrEmpty(p.ProcessName))
                {
                    try
                    {
                        p.Kill();
                    }
                    catch { }
                }
            }

            this.Close();
        }
    }
}
