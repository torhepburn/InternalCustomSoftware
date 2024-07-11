using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;



namespace StockroomShorts.Data
{
    public class Group
    {
        //public Global? global;

        Global g = new ();

        public int gID { get; set; }

        public List<int> ID = new List<int>();
        public string? Name { get; set; }

        public DataTable? Table()
        {
            DataTable dt = new DataTable();

            StringBuilder table = new StringBuilder();
            table.Append("(");
            for (int i = 0; i < ID.Count; i++)
            {
                if (i == (ID.Count - 1))
                {
                    table.Append(ID[i].ToString() + ") ");
                }
                else
                {
                    table.Append(ID[i].ToString() + ", ");
                }

            }

            SqlConnection cnxn = new SqlConnection(g.db);

            //SqlConnection cnxn = new SqlConnection("server = CT-MID-SQL11; password = Read+Write!; " +
            //                            "user = readWrite; database = AccessFrontEnds; encrypt=false;");

            SqlCommand cmd = new(
                                g.SQLs1 +
                                "WHERE ID IN " + table.ToString() +
                                "ORDER BY s.[EnteredOn], [WO], [WOline], ComponentLine", cnxn);

            SqlDataReader dr;
            try
            {
                cnxn.Open();
                dr = cmd.ExecuteReader();
                dt.Load(dr);
            }
            catch (SqlException ex)
            {
                ex.ToString();
            }
            finally
            {
                cnxn.Close();
            }
            return dt;
        }
    }
}
