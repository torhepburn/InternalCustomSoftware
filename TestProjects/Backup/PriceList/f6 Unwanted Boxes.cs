using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace PriceList
{
    public partial class f6_Unwanted_Boxes : Form
    {
        private string db = "server = middbsql; password = views; user = views; " +
                  "database = pricelists;";
        SqlConnection SqlCnxn1;
        SqlConnection SQLcnxn2;
        SqlParameter stxt;
        private string itemcode;
        private string Stext;
        private string flag;
        
        public f6_Unwanted_Boxes()
        {
            InitializeComponent();
        }

        private void f6_Unwanted_Boxes_Load(object sender, EventArgs e)
        {
            SqlCnxn1 = new SqlConnection(db);
            SqlCnxn1.Open();
            SqlCommand cmd = new SqlCommand("select item_code, sales_text from " +
                "itemtext", SqlCnxn1);

            SqlDataReader dr;

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                itemcode = dr.GetString(0).Trim();
                Stext = dr.GetString(1);

                while (Stext.IndexOf("\n")> 0)
                {
                    flag = "yes";
                    string nText = Stext.Replace("\n", " ");
                    stxt = new SqlParameter("@Sales_Text", SqlDbType.NVarChar, 500);
                    stxt.Value = nText;
                    Stext = nText;
                }

                if (flag == "yes")
                {
                    SQLcnxn2 = new SqlConnection(db);
                    SQLcnxn2.Open();
                    SqlCommand cmd2 = new SqlCommand (
                        "update itemtext set Sales_text " +
                        "= " + stxt + " where item_code = '" + 
                        itemcode + "'", SQLcnxn2);
                    cmd2.Parameters.Add(stxt);
                    int rows = cmd2.ExecuteNonQuery();
                    SQLcnxn2.Close();
                    cmd2.Dispose();
                    flag = "no";
                }
            }
        }
    }
}