using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NAV_MRP
{
    public partial class F0_SelectSource : Form
    {
        public F0_SelectSource()
        {
            InitializeComponent();
        }

        private void F0_SelectCategory_Load(object sender, EventArgs e)
        {
            this.Text = "MRP Reports v" + Application.ProductVersion;
        }

        private void BProd_Click(object sender, EventArgs e)
        {
            g.server = "server=PA-HOR-AS408.ametek.com; password=2018#ameteK; " +
                            "user=navdb_read; database=ZYGO-NAV-PROD;";
            g.rptName = "PROD ";
            Nexxt();
        }

        private void BTest_Click(object sender, EventArgs e)
        {
            g.server = "server=PA-HOR-AS406.ametek.com; password=2018#ameteK; " +
                            "user=navdb_read; database=ZYGO-NAV-TEST;";
            g.rptName = "TEST ";
            Nexxt();
        }

        private void BRefresh_Click(object sender, EventArgs e)
        {
            g.server = "server=PA-HOR-AS406.ametek.com; password=2018#ameteK; " +
                            "user=navdb_read; database=ZYGO-NAV-REFRESH;";
            g.rptName = "REFRESH ";
            Nexxt();
        }

        private void BCopy_Click(object sender, EventArgs e)
        {
            g.server = "server=PA-HOR-AS406.ametek.com; password=2018#ameteK; " +
                            "user=navdb_read; database=ZYGO-NAV-COPY;";
            g.rptName = "COPY ";
            Nexxt();
        }

        private void Nexxt()
        {
            F1_MessageType n = new F1_MessageType();
            n.ShowDialog();

            this.Close();
        }

    }
}
