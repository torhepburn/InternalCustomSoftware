using System;
using System.Windows.Forms;

namespace DebugSQL
{
    public partial class DebugSQL : Form
    {
        public DebugSQL()
        {
            InitializeComponent();
        }

        private void DebugSQL_Load(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlConnection cnxnAFE = new SqlConnection("server=CT-MID-SQL01; password=views; " +
                          "user=views; database=AccessFrontEnds;");

            string KB1contract = "KB-1042";
            string KB1contractNote;
            int KB1calculated = 4;
            int KB2calculated = 56;
            int order = 0;
            int rownumber = 1;
            int MRProws = 9;

            


            if (KB1contract.Length == 0)
            {
                item = "yers";
            }
            else
            {
                if (MRProws == 0)
                {
                    KB1contractNote = "No MRP Activity";
                }
                else
                {


                }
            }


                /*
,@leadtime int
, @qualifiedleadtime int
 , @DueDate date
,@KBorders int
, @KB1contract varchar(20)
,@KB1quantity int
, @KB1start date
,@KB1end date
, @KB1contractNote varchar(100)
,@KB2contract varchar(20)
,@KB2quantity int
, @KB2start date
,@KB2end date
, @KB2contractNote varchar(100)

,@KBopen int
, @KB1calculated int
 , @KB2calculated int
  , @buyerPlannerCode varchar(50)
,@vendorNo varchar(30)
,@reOrderDate date
, @order bit

,@MRPpoQuantity int
, @MRPorderDate date
,@MRPdueDate date
, @MRProws int
 , @MRProwCount int
  , @poLineCount int
   , @rowNumber int*/
        }
    }
}
