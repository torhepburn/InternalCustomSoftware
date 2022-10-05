using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace PMdeleteTempEmail
{
    class Program
    {
        static void Main(string[] args)
        {

            SqlConnection cnxn = new SqlConnection("server = midprj01; " +
                       "user = views; password = views; database = LogSheetsDB;");
            SqlCommand cmd = new SqlCommand(
                "Delete from temp_emailoverdue", cnxn);
            cnxn.Open();
            cmd.ExecuteNonQuery();
            cnxn.Close();
        }
    }
}
