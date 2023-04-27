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

namespace Kanban_Bin_Report
{
    public partial class KanbanBinReport : Form
    {
        SqlConnection cnxnNAV;
        SqlConnection cnxnDash;

        public KanbanBinReport()
        {
            InitializeComponent();
        }

        private void KanbanBinReport_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter
            ("SELECT " +
                "COALESCE(FORMAT(SUM(L.[Quantity]),'N0'), '0') " +
                "FROM [ZYGO$Purchase Line] L " +
                "INNER JOIN [ZYGO$Item] I ON L.No_ = I.No_ " +
                "WHERE ([Replenishment System] = 0 " +
                "and [Outstanding Quantity] > 0) AND L.No_ = '" + POitem + "' "
                , cnxnNAV);

        }
    }
}
