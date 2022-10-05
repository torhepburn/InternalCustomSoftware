using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CumulativeCapacityChart
{
    public partial class CumulativeCC : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        DataTable dt;

        public CumulativeCC()
        {
            InitializeComponent();
        }

        private void CumulativeCC_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection("server = midsql01; password = Read+Write!; " +
                            "user = readwrite; database = OptiTRAK;");

            SqlCommand cmd = new SqlCommand
            
                ("declare @cols varchar(max) " +
                 "declare @query varchar(max) " +
                 "with s1 as " +
                 "( " +
                 "select distinct CONVERT(varchar(10), runningdate, 1) RD " +
                 "from CumulativeCapacity " +
                 ") " +
                 "Select @cols = COALESCE( + @cols + '], [', '[') + RD from s1 " +
                 "order by RD " +
                 "drop table cc1; " +
                 "drop table cc2; " +
                 "drop table cc3; " +
                 "drop table cc4; " +
                 "set @query = N' " +
                 "select * into cc1 from " +
                 "( " +
                 "select " +
                 "WorkCenter, " +
                 "RunningDate, " +
                 "rd.RunTime " +
                 "from CumulativeCapacity rd " +
                 @"where WorkCenter in (" +
                 @" ''104'', ''531'', ''532'', ''556'', ''558'', " +
                 @" ''R00'', ''R01'', ''R02'', ''R03'', ''R04'',  ''R05'', ''R06'', ''R07'', ''R08'', ''R09'', " +
                 @" ''R10'', ''R11'', ''R20'', ''R21'', ''R22'', ''R23'', ''R24'', " +
                 @" ''R30'',''R31'', ''R32'', ''R33'', ''R34'', ''R35'', ''R36'', " +
                 @" ''R40'', ''R41'', ''R42'', ''R43'', ''R44'',  " +
                 @" ''R50'', ''R51'', ''R52'', ''R53'', ''R54'', ''R55'', ''R56'', " +
                 @" ''R60'', ''R61'', ''R62'', " +
                 @" ''R80'', ''R81'', ''R85'', ''R88'', ''R90'', ''R91'', ''R99'' )" +
                 ") as s " +
                 "PIVOT " +
                 "( " +
                 "SUM(RunTime) " +
                 "for RunningDate in (' + @cols + ']) " +
                 ") as PVT order by WorkCenter' " +
                 "execute(@query)" +
                 "set @query = N' " +
                 "select * into cc2 from " +
                 "( " +
                 "select " +
                 "WorkCenter, " +
                 "RunningDate, " +
                 "capacity " +
                 "from CumulativeCapacity rd " +
                 @"where WorkCenter in (" +
                 @" ''104'', ''531'', ''532'', ''556'', ''558'', " +
                 @" ''R00'', ''R01'', ''R02'', ''R03'', ''R04'',  ''R05'', ''R06'', ''R07'', ''R08'', ''R09'', " +
                 @" ''R10'', ''R11'', ''R20'', ''R21'', ''R22'', ''R23'', ''R24'', " +
                 @" ''R30'',''R31'', ''R32'', ''R33'', ''R34'', ''R35'', ''R36'', " +
                 @" ''R40'', ''R41'', ''R42'', ''R43'', ''R44'',  " +
                 @" ''R50'', ''R51'', ''R52'', ''R53'', ''R54'', ''R55'', ''R56'', " +
                 @" ''R60'', ''R61'', ''R62'', " +
                 @" ''R80'', ''R81'', ''R85'', ''R88'', ''R90'', ''R91'', ''R99'' )" +
                 ") as s " +
                 "PIVOT " +
                 "( " +
                 "SUM(capacity) " +
                 "for RunningDate in (' + @cols + ']) " +
                 ") as PVT order by WorkCenter' " +
                 "execute(@query) " +
                 "set @query = N' " +
                 "select * into cc3 from " +
                 "( " +
                 "select " +
                 "WorkCenter, " +
                 "RunningDate, " +
                 "DayDifference " +
                 "from CumulativeCapacity rd " +
                 @"where WorkCenter in (" +
                 @" ''104'', ''531'', ''532'', ''556'', ''558'', " +
                 @" ''R00'', ''R01'', ''R02'', ''R03'', ''R04'',  ''R05'', ''R06'', ''R07'', ''R08'', ''R09'', " +
                 @" ''R10'', ''R11'', ''R20'', ''R21'', ''R22'', ''R23'', ''R24'', " +
                 @" ''R30'',''R31'', ''R32'', ''R33'', ''R34'', ''R35'', ''R36'', " +
                 @" ''R40'', ''R41'', ''R42'', ''R43'', ''R44'',  " +
                 @" ''R50'', ''R51'', ''R52'', ''R53'', ''R54'', ''R55'', ''R56'', " +
                 @" ''R60'', ''R61'', ''R62'', " +
                 @" ''R80'', ''R81'', ''R85'', ''R88'', ''R90'', ''R91'', ''R99'' )" +
                 ") as s " +
                 "PIVOT " +
                 "( " +
                 "SUM(daydifference) " +
                 "for RunningDate in (' + @cols + ']) " +
                 ") as PVT order by WorkCenter' " +
                 "execute(@query) " +
                 "set @query = N' " +
                 "select * into cc4 from " +
                 "( " +
                 "select " +
                 "WorkCenter, " +
                 "RunningDate, " +
                 "CumulativeDifference " +
                 "from CumulativeCapacity rd " +
                 @"where WorkCenter in (" +
                 @" ''104'', ''531'', ''532'', ''556'', ''558'', " +
                 @" ''R00'', ''R01'', ''R02'', ''R03'', ''R04'',  ''R05'', ''R06'', ''R07'', ''R08'', ''R09'', " +
                 @" ''R10'', ''R11'', ''R20'', ''R21'', ''R22'', ''R23'', ''R24'', " +
                 @" ''R30'',''R31'', ''R32'', ''R33'', ''R34'', ''R35'', ''R36'', " +
                 @" ''R40'', ''R41'', ''R42'', ''R43'', ''R44'',  " +
                 @" ''R50'', ''R51'', ''R52'', ''R53'', ''R54'', ''R55'', ''R56'', " +
                 @" ''R60'', ''R61'', ''R62'', " +
                 @" ''R80'', ''R81'', ''R85'', ''R88'', ''R90'', ''R91'', ''R99'' )" +
                 ") as s " +
                 "PIVOT " +
                 "( " +
                 "SUM(cumulativedifference) " +
                 "for RunningDate in (' + @cols + ']) " +
                 ") as PVT order by WorkCenter' " +
                 "execute(@query)"

                 ,cnxn);

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
            da = new SqlDataAdapter(
                "select '1 Scheduled' 'tt', * from cc1 " +
                "union all " +
                "select '2 Capacity' 'tt', * from cc2 " +
                "union all " +
                "select '3 DayDifference' 'tt', * from cc3 " +
                "union all " +
                "select '4 CumulativeDifference' 'tt', * from cc4 " +
                "order by workcenter, tt", cnxn);

            try
            {
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //  replace all nulls with zeros so that comparisons can be made
            //  to calculate cell color when overcapacity
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    if (column.Ordinal > 1)
                    {
                        if (DBNull.Value.Equals(dt.Rows[i][column.Ordinal]))
                        {
                            dt.Rows[i][column.Ordinal] = 0;
                        }
                        else
                        {
                            //g.dt.Rows[i][column.Ordinal] = Convert.ToDouble(g.dt.Rows[i][column.Ordinal].ToString()) / 60;
                        }
                    }
                }
            }

            if (DGV.Columns.Count > 0)
            {
                DGV.Columns[0].Frozen = false;
                DGV.Columns[1].Frozen = false;
            }

            DGV.DataSource = null;
            DGV.DataSource = dt;

            foreach (DataGridViewRow gr in DGV.Rows)
            {
                foreach (DataGridViewCell sell in gr.Cells)
                {
                    //if (gr.Index == 54)
                    if (sell.ColumnIndex > 1 & gr.Index < dt.Rows.Count)
                    {
                        if(sell.ColumnIndex == 4 & gr.Index == 54)
                        { 
                            double test = Convert.ToDouble(DGV.Rows[gr.Index].Cells[sell.ColumnIndex].Value.ToString());
                        }
                        
                        if (Convert.ToDouble(DGV.Rows[gr.Index].Cells[sell.ColumnIndex].Value.ToString()) < 0)
                        {
                            DGV.Rows[gr.Index].Cells[sell.ColumnIndex].Style.BackColor = Color.Red;

                        }
                    }
                }
            }

            DGV.Show();

            for (int i = 1; i < DGV.Columns.Count; i++)
            {
                DGV.Columns[i].Width = 60;
            }

            DGV.Columns[0].Width = 120;
            
            DGV.Columns[0].Frozen = true;
            DGV.Columns[1].Frozen = true;
        }
    }
}
