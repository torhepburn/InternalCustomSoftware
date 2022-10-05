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

namespace LongStringParse
{
    public partial class StringParse : Form
    {
        private int[] MicroscopeID = new int[1000];
        private string[] Objectives = new string[1000];
        private string[] Standards = new string[1000];
        private string[] Others = new string[1000];
        private string[] micSN = new string[1000];
        private string pn;
        private string idesc;
        private string sn;
        private string AccType;
        private string text;
        private int lineBreak;
        SqlConnection cnxn;
        SqlCommand cmd;
        SqlConnection xn;
        private string db = "Server = CT-MID-SQL01; user = readWrite; password = Read+Write!; " +
                "database = productioncontrol;";

        private int i = 0;

        public StringParse()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            cnxn = new SqlConnection(db);
            
            SqlCommand cmd = new SqlCommand(
              //  "SELECT SN, ACCObjectives, ACCStandards, ACCOther from MicroscopeData where sn = '80115'", cnxn);
            "SELECT id, ACCObjectives, ACCStandards, ACCOther from MicroscopeData where (AccObjectives is not null " +
                " or accstandards is not null or accother is not null)", cnxn);
                


            cnxn.Open();
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            /*  this way of closing the connection causes trouble with my insert statement later on
             * */
            
            DataTable dt = new DataTable();
            dt.Load(dr);
            //put data in table for debugging
            
            cnxn.Open();

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            { 
                i++;
                if (!dr.IsDBNull(0)) { MicroscopeID[i] = dr.GetInt32(0); }
                if (!dr.IsDBNull(1)) { Objectives[i] = dr.GetString(1).Trim(); }
                if (!dr.IsDBNull(2)) { Standards[i] = dr.GetString(2).Trim(); }
                if (!dr.IsDBNull(3)) { Others[i] = dr.GetString(3).Trim(); }

                                
                text = Objectives[i];

                AccType = "Objective";

                while (text != null && text.Length > 0)
                {

                    lineBreak = text.IndexOf("\r\n");

                    if (lineBreak > 0)
                    {
                        processLine();

                        InsertData();

                        text = text.Substring(lineBreak + 2, text.Length - (lineBreak + 2));

                    }
                    else
                    {
                        lineBreak = text.Length;

                        processLine();

                        InsertData();

                        text = string.Empty;
                    }
                }
              
                text = Standards[i];

                AccType = "Standard";
                
                while (text != null && text.Length > 0)
                {

                    lineBreak = text.IndexOf("\r\n");

                    if (lineBreak > 0)
                    {
                        processLine();
                        
                        InsertData();
                        
                        text = text.Substring(lineBreak + 2, text.Length - (lineBreak + 2));

                    }
                    else
                    {
                        lineBreak = text.Length;

                        processLine();

                        InsertData();

                        text = string.Empty;
                    }
                }
              
                text = Others[i];

                AccType = "Other";

                while (text != null && text.Length > 0)
                {

                    lineBreak = text.IndexOf("\r\n");

                    if (lineBreak > 0)
                    {
                        processLine();

                        InsertData();

                        text = text.Substring(lineBreak + 2, text.Length - (lineBreak + 2));

                    }
                    else
                    {
                        lineBreak = text.Length;

                        processLine();

                        InsertData();

                        text = string.Empty;
                    }
                }

            }
        }

        private void processLine()
        {
            string first = text.Substring(0, lineBreak);
            pn = string.Empty;
            
            /* spaces finds three blanks in a row after the first space*/
            if (gaptest(first.Trim()) > 0)
            {
                pn = first.Substring(0, gaptest(first.Trim()));
            }
            else
            {
                pn = first.Trim();
                idesc = string.Empty;
                sn = string.Empty;
            }

            if (pn != first.Trim())
            {

                string second = first.Substring(gaptest(first.Trim()), first.Length - gaptest(first.Trim())).Trim();
                sn = string.Empty;

                int descriptend = gaptest(second);

                idesc = string.Empty;

                if (descriptend > 0)
                {
                    idesc = second.Substring(0, descriptend);
                    sn = second.Substring(descriptend, second.Length - descriptend).Trim();
                }
                else
                {
                    idesc = second;
                }

            }
        }

        private void InsertData()
        {
            try
            {
                xn = new SqlConnection(db);

                xn.Open();

                cmd = new SqlCommand(
                   "Insert into MicroscopeAccessories " +
                   "(MicroscopeData_ID, AccessoryType, PartNumber, accDescription, accSerialNumber) values (" +
                   " " + MicroscopeID[i] + " " +
                   ", '" + AccType + "' " +
                   ",'" + pn + "'" +
                   ",'" + idesc + "'" +
                   ",'" + sn + "')", xn);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
                File.AppendAllText(@"C:\A\MicErrors.txt", MicroscopeID[i].ToString() + Environment.NewLine);

            }
            finally
            {
                xn.Close();
            }


        }

        static int gaptest(string newline)
        {
            int L = newline.Length;

            byte[] bytes = Encoding.ASCII.GetBytes(newline);

            for (int i = 0; i < L - 2; i++)
            {
                if (bytes[i] == 32 &
                    bytes[i+1] == 32 &
                    bytes[i + 2] == 32)
                {
                    return i;
                }
            }


            return 0;
        }
    }
}
