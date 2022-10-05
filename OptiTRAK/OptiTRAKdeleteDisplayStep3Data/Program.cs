using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace OptiTRAKdeleteDisplayStep3Data
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection cnxn = new SqlConnection
               ("server = midsql01; password = Read+Write!; " +
                   "user = readwrite; database = OptiTRAK;");
            SqlCommand cmd = new SqlCommand
                ("delete from OptiTRAKdisplayStep3 ", cnxn);
            cnxn.Open();
            cmd.ExecuteNonQuery();
            cnxn.Close();
        }
    }
}
