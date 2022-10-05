using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace QuoteWerksExport
{
    public partial class QW28Sept21 : Form
    {
        private string txtLine;
        private string txtDate;
        private string itemclass;
        private string salesText;
        private string basicSelection =
            "SELECT " +
            "[Sales Code] " +
            ", [Folder] " +
            ", [Item Number] " +
            ", [Price List Code] " +
            ", [Price List Description] " +
            ", COALESCE([Text],'') [Text] " +
            ",[COST] " +
            ",[Price] " +
            "FROM [FullPriceList] ";


        public QW28Sept21()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            File.Delete(Path.Combine(directory, "DOM_Export.txt"));
            File.Delete(Path.Combine(directory, "EXP_Export.txt"));
            File.Delete(Path.Combine(directory, "INT_Export.txt"));
            File.Delete(Path.Combine(directory, "ServiceContracts_Export.txt"));
            File.Delete(Path.Combine(directory, "ServiceItems_Export.txt"));

            DateTime tDate = DateTime.Now;
            txtDate = tDate.Date.ToString(@"yyyy-MM-dd");
            
            SqlConnection cnxn = new SqlConnection(
                "server = CT-MID-SQL11; user = readwrite; " +
                "password = Read+Write!; database = pricelists;");
            cnxn.Open();
            SqlCommand cmd = new SqlCommand(
                basicSelection + "WHERE [sales code] = 'dom'", cnxn);
            
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr[4].ToString().IndexOf("\"") != -1)
                {
                    itemclass = dr[4].ToString().Trim().Replace("\"", " IN");
                }
                else
                {
                    itemclass = dr[4].ToString().Trim();
                }

                if (dr[5].ToString().IndexOf("\"") != -1)
                {
                    salesText = dr[5].ToString().Trim().Replace("\"", " IN");
                }
                else
                {
                    salesText = dr[5].ToString().Trim();
                }



                txtLine = "\"" + dr[1].ToString().Trim() + "\"|\"" +
                    dr[2].ToString().Trim() + "\"|\"" +
                    dr[3].ToString().Trim() + "\"|\"" +
                    itemclass + "\"|\"" +
                    salesText + "\"|\"" +
                    dr[6].ToString().Trim() + "\"|\"" +
                    dr[7].ToString().Trim() + "\"" + Environment.NewLine;

                File.AppendAllText(Path.Combine(directory, "DOM_Export.txt"), txtLine);
            }
            cnxn.Close();

            cmd = new SqlCommand(
                basicSelection + "where [sales code] = 'EXP'", cnxn);
            cnxn.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr[4].ToString().IndexOf("\"") != -1)
                {
                    itemclass = dr[4].ToString().Trim().Replace("\"", " IN");
                }
                else
                {
                    itemclass = dr[4].ToString().Trim();
                }

                if (dr[5].ToString().IndexOf("\"") != -1)
                {
                    salesText = dr[5].ToString().Trim().Replace("\"", " IN");
                }
                else
                {
                    salesText = dr[5].ToString().Trim();
                }

                txtLine = "\"" + dr[1].ToString().Trim() + "\"|\"" +
                    dr[2].ToString().Trim() + "\"|\"" +
                    dr[3].ToString().Trim() + "\"|\"" +
                    itemclass + "\"|\"" +
                    salesText + "\"|\"" +
                    dr[6].ToString().Trim() + "\"|\"" +
                    dr[7].ToString().Trim() + "\"" + Environment.NewLine;
                File.AppendAllText(Path.Combine(directory, "EXP_Export.txt"), txtLine);

            }
            cnxn.Close();

            cmd = new SqlCommand(
                basicSelection + "where [sales code] = 'int'", cnxn);
            cnxn.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr[4].ToString().IndexOf("\"") != -1)
                {
                    itemclass = dr[4].ToString().Trim().Replace("\"", " IN");
                }
                else
                {
                    itemclass = dr[4].ToString().Trim();
                }

                if (dr[5].ToString().IndexOf("\"") != -1)
                {
                    salesText = dr[5].ToString().Trim().Replace("\"", " IN");
                }
                else
                {
                    salesText = dr[5].ToString().Trim();
                }

                txtLine = "\"" + dr[1].ToString().Trim() + "\"|\"" +
                    dr[2].ToString().Trim() + "\"|\"" +
                    dr[3].ToString().Trim() + "\"|\"" +
                    itemclass + "\"|\"" +
                    salesText + "\"|\"" +
                    dr[6].ToString().Trim() + "\"|\"" +
                    dr[7].ToString().Trim() + "\"" + Environment.NewLine;
                File.AppendAllText(Path.Combine(directory, "INT_Export.txt"), txtLine);

            }
            cnxn.Close();

            cmd = new SqlCommand(
                basicSelection + "where [sales code] = 'ServiceContract'", cnxn);
            cnxn.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr[4].ToString().IndexOf("\"") != -1)
                {
                    itemclass = dr[4].ToString().Trim().Replace("\"", " IN");
                }
                else
                {
                    itemclass = dr[4].ToString().Trim();
                }

                if (dr[5].ToString().IndexOf("\"") != -1)
                {
                    salesText = dr[5].ToString().Trim().Replace("\"", " IN");
                }
                else
                {
                    salesText = dr[5].ToString().Trim();
                }

                txtLine = "\"" + dr[1].ToString().Trim() + "\"|\"" +
                    dr[2].ToString().Trim() + "\"|\"" +
                    dr[3].ToString().Trim() + "\"|\"" +
                    itemclass + "\"|\"" +
                    salesText + "\"|\"" +
                    dr[6].ToString().Trim() + "\"|\"" +
                    dr[7].ToString().Trim() + "\"" + Environment.NewLine;
                File.AppendAllText(Path.Combine(directory, "ServiceContracts_Export.txt"), txtLine);

            }
            cnxn.Close();

            cmd = new SqlCommand(
                basicSelection + "where [sales code] = 'ServiceItems'", cnxn);
            cnxn.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr[4].ToString().IndexOf("\"") != -1)
                {
                    itemclass = dr[4].ToString().Trim().Replace("\"", " IN");
                }
                else
                {
                    itemclass = dr[4].ToString().Trim();
                }

                if (dr[5].ToString().IndexOf("\"") != -1)
                {
                    salesText = dr[5].ToString().Trim().Replace("\"", " IN");
                }
                else
                {
                    salesText = dr[5].ToString().Trim();
                }

                txtLine = "\"" + dr[1].ToString().Trim() + "\"|\"" +
                    dr[2].ToString().Trim() + "\"|\"" +
                    dr[3].ToString().Trim() + "\"|\"" +
                    itemclass + "\"|\"" +
                    salesText + "\"|\"" +
                    dr[6].ToString().Trim() + "\"|\"" +
                    dr[7].ToString().Trim() + "\"" + Environment.NewLine;
                File.AppendAllText(Path.Combine(directory, "ServiceItems_Export.txt"), txtLine);

            }
            cnxn.Close();
            
            Close();
        }

    }
}
