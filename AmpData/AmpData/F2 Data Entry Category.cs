using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AmpData
{
    public partial class F2_Data_Entry_Category : Form
    {
        
        
        public F2_Data_Entry_Category()
        {
            InitializeComponent();
        }

        private void F2_Data_Entry_Category_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection(g.db);
            SqlDataAdapter da = new SqlDataAdapter
                ("select " +
                 "p1PF , " +
                 "CLp1PF, " +
                 "p2PF, " +
                 "CLp2PF, " +
                 "p3PF " +
                 "from nif_amp_data where [part serial number] = " + g.serialNumber + " ", cnxn);

            DataTable table = new DataTable();

            da.Fill(table);

            //if (table.Rows[0].ItemArray[0].ToString().Trim() == "PASS")
            //{
                bPhaseICladding.Visible = true;
            //}

            //if (table.Rows[0].ItemArray[1].ToString().Trim() == "PASS")
            //{
                bPhaseIIMech.Visible = true;
            //}

            //if (table.Rows[0].ItemArray[2].ToString().Trim() == "PASS")
            //{
                bPhaseIICladding.Visible = true;
            //}


            //if (table.Rows[0].ItemArray[3].ToString().Trim() == "PASS")
            //{
                bPhaseIIIMech.Visible = true;
            //}

            //if (table.Rows[0].ItemArray[4].ToString().Trim() == "PASS")
            //{
                bSurfaces.Visible = true;
            //}

                bFinalInspection.Visible = true;
                bParallelism.Visible = true;
        }

        private void bPhaseIMech_Click(object sender, EventArgs e)
        {
            F3_MSI_Phase_I f3 = new F3_MSI_Phase_I();
            f3.ShowDialog();
        }

        private void bPhaseICladding_Click(object sender, EventArgs e)
        {
            F4_Clad_Phase_I f4 = new F4_Clad_Phase_I();
            f4.ShowDialog();
        }

        private void bPhaseIICladding_Click(object sender, EventArgs e)
        {
            F6_Clad_Phase_II f6 = new F6_Clad_Phase_II();
            f6.ShowDialog();
        }

        private void bPhaseIIMech_Click(object sender, EventArgs e)
        {
            F5_MSI_Phase_II f5 = new F5_MSI_Phase_II();
            f5.ShowDialog();
        }

        private void bPhaseIIIMech_Click(object sender, EventArgs e)
        {
            F7_MSI_Phase_III f7 = new F7_MSI_Phase_III();
            f7.ShowDialog();
        }

        private void bSurfaces_Click(object sender, EventArgs e)
        {
            F8_Surfaces f8 = new F8_Surfaces();
            f8.ShowDialog();
        }

        private void bFinalInspection_Click(object sender, EventArgs e)
        {
            F9_Final_Inspection f9 = new F9_Final_Inspection();
            f9.ShowDialog();
        }

        private void bParallelism_Click(object sender, EventArgs e)
        {
            F91_Paralellism f91 = new F91_Paralellism();
            f91.ShowDialog();
        }

    }
}
