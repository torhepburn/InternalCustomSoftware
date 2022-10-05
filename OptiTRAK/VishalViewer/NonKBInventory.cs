using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace VishalViewer
{
    public partial class NonKBInventory : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        private string db = "server = midsql01; password = Read+Write!; " +
                            "user = readwrite; database = OptiTRAK;";
 
        public NonKBInventory()
        {
            InitializeComponent();
        }

        private void NonKBInventory_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(db);
            da = new SqlDataAdapter(
            "with s1 as " +
            "( " +
            "select " +
            "Item_Code, " +
            "SUM(f.ORDER_QUANTITY) - SUM(f.QUANTITY_POSTED) - " +
            "SUM(f.TOTAL_SCRAPPED) MkWIP from " +
            "AccessFrontEnds.dbo.MMX_PRODUCTION_ORDER_FILE f " +
            "where f.ORDER_STATUS < 6 " +
            "group by ITEM_CODE " +
            ") " +
            " select " +
            "[Name of the sub Component], " +
            "PartNumber, " +
            "F3, " +
            "[Finish Goods], " +
            "WiP, " +
            "STOCK_ON_HAND MkStockOH, " +
            "MkWIP " +
            "from " +
            "NonKanbanInv i left " +
            "join AccessFrontEnds.dbo.MMX_ITEM_DATA d on i.PartNumber = d.ITEM_CODE " +
            "left " +
            "join s1 on i.PartNumber = s1.ITEM_CODE " +
            "order by d.item_code ", cnxn);

            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;

            DGV.Columns[0].Width = 250;
            DGV.Columns[1].Width = 150;

        }
    }
}
