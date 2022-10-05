using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data.SqlClient;
using System.Data;

namespace MKimport
{
    class ImportMK
    {
        static OracleConnection oCnxn = new OracleConnection();
        static OracleCommand oCmd;
        static OracleDataAdapter oDa;
        static OracleCommandBuilder oCb;
        static DataTable mkTable;
        static SqlConnection sCnxn = new SqlConnection
            ("server = midsql01; user=ReadWrite; " +
             "password=Read+Write!; database=AccessFrontEnds;");
        static SqlBulkCopy copy = new SqlBulkCopy(sCnxn);
        static SqlCommand sCmd;

        static void Main(string[] args)
        {
            oCnxn.ConnectionString = "user id=views; " +
                "password=views; data source=//dbserver:1521/mkpd;";

            sCnxn.Open();

            try
            {
                oCnxn.Open();

                string sql = "select " +
                             "* " +
                             "from views200.titles";

                oCmd = new OracleCommand(sql, oCnxn);
                oCmd.CommandType = CommandType.Text;
                oDa = new OracleDataAdapter(oCmd);
                oCb = new OracleCommandBuilder(oDa);
                mkTable = new DataTable();
                oDa.Fill(mkTable);
                oCnxn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                sCmd = new SqlCommand
                ("delete from mk_Titles", sCnxn);
                sCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            copy = new SqlBulkCopy(sCnxn);
            copy.DestinationTableName = "MK_Titles";
            try
            {
                copy.WriteToServer(mkTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
