using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PMclose
{
    public partial class PMClose : Form
    {
        SqlConnection cnxn;

        public PMClose()
        {
            InitializeComponent();
        }

        private void PMClose_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection("server = midprj01; password = views; " +
                                  "user = views; database = logsheetsdb;");
            
            SqlDataAdapter da = new SqlDataAdapter(
                "select " +
                "serial, " +
                "manufacturer, " +
                "trouble_repair_category, " +
                "trouble_project, " +
                "trouble_cost_Center, " +
                "trouble, " +
                "location, " +
                "trouble_severity, " +
                "trouble_rptd_date, " +
                "trouble_rptd_by, " +
                "trouble_rptd_email, " +
                "trouble_rptd_phone, " +
                "trouble_work_reference_number " +
                "from [repair history] H inner join " +
                "pmequip E on H.serial = E.serial " +
                "where trouble_work_reference_number = '" +
                "  repair_date is null and " +
                "H.serial = '", cnxn);
        }
    }
}
