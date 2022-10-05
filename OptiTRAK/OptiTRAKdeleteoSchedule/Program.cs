using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace OptiTRAKdeleteoSchedule
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection cnxn = new SqlConnection
                ("server = midsql01; password = Read+Write!; " +
                    "user = readwrite; database = OptiTRAK;");
            SqlCommand cmd = new SqlCommand
                ("delete from oDept; delete from oJobInfo; delete from oPartSN; " +
                 "delete from oResources; delete from oSchedule; delete from oStatus; " +
                 "delete from oWIResDetail; delete from oWorkIns; " , cnxn);
            cnxn.Open();
            cmd.ExecuteNonQuery();
            cnxn.Close();
        }
    }
}
