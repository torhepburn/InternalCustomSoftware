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

namespace MasterScheduleCalcium
{
    public partial class Stock : Form
    {
        SqlConnection cnxn;
        DataTable dt = null;

        public Stock()
        {
            InitializeComponent();
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            //  set up the connection

            cnxn = new SqlConnection(g.db);

            //  get the details for the top grid

            SqlDataAdapter da = new SqlDataAdapter(
                 "with s1 as " +
                "( select * from OptiTrakMkProductionOrderFile " +
                "where ITEM_CODE in (select " +
                "PartDrawingNumber + PartDrawingRev item_code " +
                "from MasterScheduleSetup m inner join tblJobInfo j on m.JobID = j.JobID " +
                "inner join AccessFrontEnds.dbo.MMX_ITEM_DATA_BY_WAREHOUSE w " +
                "on (j.PartDrawingNumber + j.PartDrawingRev) = w.ITEM_CODE " +
                "where m.PlannerID = 10 and WAREHOUSE like '%48%') " +
                ") " +
                ", s2 as " +
                "( " +
                "select " +
                "item_code " +
                ", SUM(ORDER_QUANTITY) OpenSFOs " +
                "from s1 where ORDER_STATUS < 7 " +
                "group by item_code " +
                ") " +
                ", s3 as " +
                "( " +
                "select " +
                "ParentItemCode " +
                ", ITEM_CODE " +
                ", STOCK_ON_HAND BlanksInStock " +
                ", STOCK_ON_ORDER BlanksOnOrder " +
                ", ALLOCATED_STOCK " +
                "from " +
                "mfgmatrix m inner join AccessFrontEnds.dbo.MMX_ITEM_DATA_BY_WAREHOUSE w " +
                "on m.blankitemcode = w.ITEM_CODE " +
                "where WAREHOUSE like '%46%' " +
                ") " +
                "select " +
                "Project " +
                ", ElementName Part " +
                ",PartDrawingNumber + PartDrawingRev item_code " +
                ",w.STOCK_ON_HAND On_Hand" +
                ",w.allocated_stock Sales" +
                ",OpenSFOs " +
                ",s3.item_code " +
                ", BlanksInStock " +
                ", BlanksOnOrder " +
                ",w.Allocated_stock - (OpenSFOs + BlanksInStock + BlanksOnOrder) BlanksNeeded " +
                "from " +
                "MasterScheduleSetup m inner join tblJobInfo j on m.JobID = j.JobID " +
                "inner join AccessFrontEnds.dbo.MMX_ITEM_DATA_BY_WAREHOUSE w on(j.PartDrawingNumber + j.PartDrawingRev) = w.ITEM_CODE "+
                "inner join s2 on s2.ITEM_CODE = (j.PartDrawingNumber + j.PartDrawingRev) " +
                "left join s3 on s2.ITEM_CODE = s3.parentitemcode " +
                "where m.PlannerID = 10 and LTRIM(WAREHOUSE) = '48' order by project, elementname", cnxn);

            try
            {
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            DGV.DataSource = dt;

            DGV.Columns[2].Width = 120;
            DGV.Columns[6].Width = 120;
            DGV.Columns[8].Width = 120;

        }
    }
}
