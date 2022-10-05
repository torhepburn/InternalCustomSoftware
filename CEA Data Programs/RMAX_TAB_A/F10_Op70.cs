using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RMAX_TAB_A
{
    public partial class F10_Op70 : Form
    {
        SqlConnection cnxn;
        private string op70PF;

        public F10_Op70()
        {
            InitializeComponent();
        }

        private void F10_Op70_Load(object sender, EventArgs e)
        {
            LserialNumber.Text = "Part Serial Number:  " + g.serialNumber;

            cnxn = new SqlConnection(g.db);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter
                    (" select " +
                     " op70Length " +
                     ",op70lenInsp " +
                     ",convert(varchar,op70lendate, 101) " +
                     ",op70Width " +
                     ",op70widthInsp " +
                     ",convert(varchar,op70widthdate, 101) " +
                     ",op70CChamSize1 " +
                     ",op70CChamS1Insp " +
                     ",convert(varchar,op70CChamS1Date, 101) " +
                     ",op70CChamSize2 " +
                     ",op70CChamS2Insp " +
                     ",convert(varchar,op70CChamS2Date, 101) " +
                     ",op70CChamSize3 " +
                     ",op70CChamS3Insp " +
                     ",convert(varchar,op70CChamS3Date, 101) " +
                     ",op70CChamSize4 " +
                     ",op70CChamS4Insp " +
                     ",convert(varchar,op70CChamS4Date, 101) " +
                     ",op70CChamAngle1 " +
                     ",op70CChamA1Insp " +
                     ",convert(varchar,op70CChamA1Date, 101) " +
                     ",op70CChamAngle2 " +
                     ",op70CChamA2Insp " +
                     ",convert(varchar,op70CChamA2Date, 101) " +
                     ",op70CChamAngle3 " +
                     ",op70CChamA3Insp " +
                     ",convert(varchar,op70CChamA3Date, 101) " +
                     ",op70CChamAngle4 " +
                     ",op70CChamA4Insp " +
                     ",convert(varchar,op70CChamA4Date, 101) " +
                     ",op70S1BevelMin " +
                     ",op70S1BevMinInsp " +
                     ",convert(varchar,op70S1BevMinDate, 101) " +
                     ",op70S1BevelMax " +
                     ",op70S1BevMaxInsp " +
                     ",convert(varchar,op70S1BevMaxDate, 101) " +
                     ",op70S2BevelMin " +
                     ",op70S2BevMinInsp " +
                     ",convert(varchar,op70S2BevMinDate, 101) " +
                     ",op70S2BevelMax " +
                     ",op70S2BevMaxInsp " +
                     ",convert(varchar,op70S2BevMaxDate, 101) " +
                     ",op70S1BevelAngle " +
                     ",op70S1BevelAngleInsp " +
                     ",convert(varchar,op70S1BevelAngleDate, 101) " +
                     ",op70S2BevelAngle " +
                     ",op70S2BevelAngleInsp " +
                     ",convert(varchar,op70S2BevelAngleDate, 101) " +
                     ",op70PerpE2Edegrees " +
                     ",op70PerpE2Eminutes " +
                     ",op70PerpE2Eseconds " +
                     ",op70PerpEdge2Edge " +
                     ",op70PerpEdge2EdgeInsp " +
                     ",convert(varchar,op70PerpEdge2EdgeDate, 101) " +
                     ",op70PerpE2Sdegrees " +
                     ",op70PerpE2Sminutes " +
                     ",op70PerpE2Sseconds " +
                     ",op70PerpEdge2SurfA " +
                     ",op70PerpEdge2SurfAInsp " +
                     ",convert(varchar,op70PerpEdge2SurfADate, 101) " +
                     " from CEA_RMAX_MIRROR_TAB_A where [part serial number] = " + g.serialNumber + " ", cnxn);

                DataTable table = new DataTable();

                da.Fill(table);

                tbLength.Text = table.Rows[0][0].ToString();
                tbLenInsp.Text = table.Rows[0][1].ToString();

                if (table.Rows[0][2].ToString().Length > 0)
                {
                    dtpLenDate.Text = table.Rows[0][2].ToString();
                }

                tbWidth.Text = table.Rows[0][3].ToString();
                tbWidInsp.Text = table.Rows[0][4].ToString();

                if (table.Rows[0][5].ToString().Length > 0)
                {
                    dtpWidDate.Text = table.Rows[0][5].ToString();
                }

                tbCChamSize1.Text = table.Rows[0][6].ToString();
                tbCChamS1Insp.Text = table.Rows[0][7].ToString();

                if (table.Rows[0][8].ToString().Length > 0)
                {
                    dtpCChamS1Date.Text = table.Rows[0][8].ToString();
                }

                tbCChamSize2.Text = table.Rows[0][9].ToString();
                tbCChamS2Insp.Text = table.Rows[0][10].ToString();

                if (table.Rows[0][11].ToString().Length > 0)
                {
                    dtpCChamS2Date.Text = table.Rows[0][11].ToString();
                }

                tbCChamSize3.Text = table.Rows[0][12].ToString();
                tbCChamS3Insp.Text = table.Rows[0][13].ToString();

                if (table.Rows[0][14].ToString().Length > 0)
                {
                    dtpCChamS3Date.Text = table.Rows[0][14].ToString();
                }

                tbCChamSize4.Text = table.Rows[0][15].ToString();
                tbCChamS4Insp.Text = table.Rows[0][16].ToString();

                if (table.Rows[0][17].ToString().Length > 0)
                {
                    dtpCChamS4Date.Text = table.Rows[0][17].ToString();
                }

                tbCChamAngle1.Text = table.Rows[0][18].ToString();
                tbCChamA1Insp.Text = table.Rows[0][19].ToString();

                if (table.Rows[0][20].ToString().Length > 0)
                {
                    dtpCChamA1Date.Text = table.Rows[0][20].ToString();
                }

                tbCChamAngle2.Text = table.Rows[0][21].ToString();
                tbCChamA2Insp.Text = table.Rows[0][22].ToString();

                if (table.Rows[0][23].ToString().Length > 0)
                {
                    dtpCChamA2Date.Text = table.Rows[0][23].ToString();
                }

                tbCChamAngle3.Text = table.Rows[0][24].ToString();
                tbCChamA3Insp.Text = table.Rows[0][25].ToString();

                if (table.Rows[0][26].ToString().Length > 0)
                {
                    dtpCChamA3Date.Text = table.Rows[0][26].ToString();
                }

                tbCChamAngle4.Text = table.Rows[0][27].ToString();
                tbCChamA4Insp.Text = table.Rows[0][28].ToString();

                if (table.Rows[0][29].ToString().Length > 0)
                {
                    dtpCChamA4Date.Text = table.Rows[0][29].ToString();
                }

                tbS1BevMin.Text = table.Rows[0][30].ToString();
                tbS1BevMinInsp.Text = table.Rows[0][31].ToString();

                if (table.Rows[0][32].ToString().Length > 0)
                {
                    dtpS1BevMinDate.Text = table.Rows[0][32].ToString();
                }

                tbS1BevMax.Text = table.Rows[0][33].ToString();
                tbS1BevMaxInsp.Text = table.Rows[0][34].ToString();

                if (table.Rows[0][35].ToString().Length > 0)
                {
                    dtpS1BevMaxDate.Text = table.Rows[0][35].ToString();
                }

                tbS2BevMin.Text = table.Rows[0][36].ToString();
                tbS2BevMinInsp.Text = table.Rows[0][37].ToString();

                if (table.Rows[0][38].ToString().Length > 0)
                {
                    dtpS2BevMinDate.Text = table.Rows[0][38].ToString();
                }

                tbS2BevMax.Text = table.Rows[0][39].ToString();
                tbS2BevMaxInsp.Text = table.Rows[0][40].ToString();

                if (table.Rows[0][41].ToString().Length > 0)
                {
                    dtpS2BevMaxDate.Text = table.Rows[0][41].ToString();
                }

                tbS1BevelAngle.Text = table.Rows[0][42].ToString();
                tbS1BevAngleInsp.Text = table.Rows[0][43].ToString();

                if (table.Rows[0][44].ToString().Length > 0)
                {
                    dtpS1AngleDate.Text = table.Rows[0][44].ToString();
                }

                tbS2BevelAngle.Text = table.Rows[0][45].ToString();
                tbS2BevAngleInsp.Text = table.Rows[0][46].ToString();

                if (table.Rows[0][47].ToString().Length > 0)
                {
                    dtpS2AngleDate.Text = table.Rows[0][47].ToString();
                }

                tbE2EDegrees.Text = table.Rows[0][48].ToString();
                tbE2EMinutes.Text = table.Rows[0][49].ToString();
                tbE2ESeconds.Text = table.Rows[0][50].ToString();
                tbPerpE2E.Text = table.Rows[0][51].ToString();
                tbPerpE2EInsp.Text = table.Rows[0][52].ToString();

                if (table.Rows[0][53].ToString().Length > 0)
                {
                    dtpPerpE2EDate.Text = table.Rows[0][53].ToString();
                }

                tbE2SDegrees.Text = table.Rows[0][54].ToString();
                tbE2SMinutes.Text = table.Rows[0][55].ToString();
                tbE2SSeconds.Text = table.Rows[0][56].ToString();
                tbPerpE2S.Text = table.Rows[0][57].ToString();
                tbPerpE2SInsp.Text = table.Rows[0][58].ToString();

                if (table.Rows[0][59].ToString().Length > 0)
                {
                    dtpPerpE2SDate.Text = table.Rows[0][59].ToString();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
                Close();
            }
            finally
            {

            }
        }

        private void bEnterData_Click(object sender, EventArgs e)
        {
            if (tbLength.BackColor.G == 200 & 
                tbWidth.BackColor.G == 200 & 
                tbCChamSize1.BackColor.G == 200 &
                tbCChamSize2.BackColor.G == 200 &
                tbCChamSize3.BackColor.G == 200 &
                tbCChamSize4.BackColor.G == 200 &
                tbCChamAngle1.BackColor.G == 200 &
                tbCChamAngle2.BackColor.G == 200 &
                tbCChamAngle3.BackColor.G == 200 &
                tbCChamAngle4.BackColor.G == 200 &
                tbS1BevMin.BackColor.G == 200 &
                tbS1BevMax.BackColor.G == 200 &
                tbS2BevMin.BackColor.G == 200 &
                tbS2BevMax.BackColor.G == 200 &
                tbS1BevelAngle.BackColor.G == 200 &
                tbS2BevelAngle.BackColor.G == 200 &
                tbPerpE2E.BackColor.G == 200 &
                tbPerpE2S.BackColor.G ==200
                )
            {
                op70PF = "PASS";
            }
            else
            {
                op70PF = "FAIL";
                MessageBox.Show("This step does not PASS !");
            }

            try
            {
                cnxn = new SqlConnection(g.db);
                SqlCommand cmd = new SqlCommand
                ("Update CEA_RMAX_MIRROR_TAB_A " +
                 "set Op70Length = @Length " +
                 " ,Op70leninsp = @LenInsp " +
                 " ,Op70lendate = @LenDate " +
                 " ,Op70Width = @Width " +
                 " ,Op70widthinsp = @WidInsp " +
                 " ,Op70widthdate = @WidDate " +
                 " ,op70CChamSize1 = @ChamS1 " +
                  ",op70CChamS1Insp = @ChamS1Insp " +
                  ",op70CChamS1Date = @ChamS1Date " +
                  ",op70CChamSize2 = @ChamS2 " +
                  ",op70CChamS2Insp = @ChamS2Insp " +
                  ",op70CChamS2Date = @ChamS2Date " +
                  ",op70CChamSize3 = @ChamS3 " +
                  ",op70CChamS3Insp = @ChamS3Insp " +
                  ",op70CChamS3Date = @ChamS3Date " +
                  ",op70CChamSize4 = @ChamS4 " +
                  ",op70CChamS4Insp = @ChamS4Insp " +
                  ",op70CChamS4Date = @ChamS4Date " +
                  ",op70CChamAngle1 = @ChamA1 " +
                  ",op70CChamA1Insp = @ChamA1Insp " +
                  ",op70CChamA1Date = @ChamA1Date " +
                  ",op70CChamAngle2 = @ChamA2 " +
                  ",op70CChamA2Insp = @ChamA2Insp " +
                  ",op70CChamA2Date = @ChamA2Date " +
                  ",op70CChamAngle3 = @ChamA3 " +
                  ",op70CChamA3Insp = @ChamA3Insp " +
                  ",op70CChamA3Date = @ChamA3Date " +
                  ",op70CChamAngle4 = @ChamA4 " +
                  ",op70CChamA4Insp = @ChamA4Insp " +
                  ",op70CChamA4Date = @ChamA4Date " +
                  ",op70S1BevelMin = @S1BevelMin " +
                  ",op70S1BevMinInsp = @S1BevMinInsp " +
                  ",op70S1BevMinDate = @S1BevMinDate " +
                  ",op70S1BevelMax = @S1BevelMax " +
                  ",op70S1BevMaxInsp = @S1BevMaxInsp " +
                  ",op70S1BevMaxDate = @S1BevMaxDate " +
                  ",op70S2BevelMin = @S2BevelMin " +
                  ",op70S2BevMinInsp = @S2BevMinInsp " +
                  ",op70S2BevMinDate = @S2BevMinDate " +
                  ",op70S2BevelMax = @S2BevelMax" +
                  ",op70S2BevMaxInsp = @S2BevMaxInsp" +
                  ",op70S2BevMaxDate = @S2BevMaxDate " +
                  ",op70S1BevelAngle = @S1BevAngle " +
                  ",op70S1BevelAngleInsp = @S1BevAngleInsp " +
                  ",op70S1BevelAngleDate = @S1BevAngleDate " +
                  ",op70S2BevelAngle = @S2BevAngle " +
                  ",op70S2BevelAngleInsp = @S2BevAngleInsp " +
                  ",op70S2BevelAngleDate = @S2BevAngleDate " +
                  ",op70PerpE2Edegrees = @PerpE2Edegrees " +
                  ",op70PerpE2Eminutes = @PerpE2Eminutes " +
                  ",op70PerpE2Eseconds = @PerpE2Eseconds " +
                  ",op70PerpEdge2Edge = @PerpE2E " +
                  ",op70PerpEdge2EdgeInsp = @PerpE2Einsp " +
                  ",op70PerpEdge2EdgeDate = @PerpE2Edate " +
                  ",op70PerpE2Sdegrees = @PerpE2Sdegrees " +
                  ",op70PerpE2Sminutes = @PerpE2Sminutes " +
                  ",op70PerpE2Sseconds = @PerpE2Sseconds " +
                  ",op70PerpEdge2SurfA = @PerpE2S " +
                  ",op70PerpEdge2SurfAInsp = @PerpE2Sinsp " +
                  ",op70PerpEdge2SurfADate = @PerpE2Sdate " +
                " ,Op70pf = '" + op70PF + "' " +
                 "where [part serial number] = " + g.serialNumber + " ", cnxn);

                if (tbLength.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@Length", SqlDbType.NChar, 10).Value = tbLength.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@Length", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@LenInsp", SqlDbType.NChar, 10).Value = tbLenInsp.Text.Trim();
                cmd.Parameters.Add("@LenDate", SqlDbType.NChar, 10).Value = dtpLenDate.Text.Trim();

                if (tbWidth.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@Width", SqlDbType.NChar, 10).Value = tbWidth.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@Width", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@WidInsp", SqlDbType.NChar, 10).Value = tbWidInsp.Text.Trim();
                cmd.Parameters.Add("@WidDate", SqlDbType.NChar, 10).Value = dtpWidDate.Text.Trim();

                if (tbCChamSize1.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@ChamS1", SqlDbType.NChar, 10).Value = tbCChamSize1.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@ChamS1", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@ChamS1Insp", SqlDbType.NChar, 10).Value = tbCChamS1Insp.Text.Trim();
                cmd.Parameters.Add("@ChamS1Date", SqlDbType.NChar, 10).Value = dtpCChamS1Date.Text.Trim();

                if (tbCChamSize2.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@ChamS2", SqlDbType.NChar, 10).Value = tbCChamSize2.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@ChamS2", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@ChamS2Insp", SqlDbType.NChar, 10).Value = tbCChamS2Insp.Text.Trim();
                cmd.Parameters.Add("@ChamS2Date", SqlDbType.NChar, 10).Value = dtpCChamS2Date.Text.Trim();

                if (tbCChamSize3.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@ChamS3", SqlDbType.NChar, 10).Value = tbCChamSize3.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@ChamS3", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@ChamS3Insp", SqlDbType.NChar, 10).Value = tbCChamS3Insp.Text.Trim();
                cmd.Parameters.Add("@ChamS3Date", SqlDbType.NChar, 10).Value = dtpCChamS3Date.Text.Trim();

                if (tbCChamSize4.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@ChamS4", SqlDbType.NChar, 10).Value = tbCChamSize4.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@ChamS4", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@ChamS4Insp", SqlDbType.NChar, 10).Value = tbCChamS4Insp.Text.Trim();
                cmd.Parameters.Add("@ChamS4Date", SqlDbType.NChar, 10).Value = dtpCChamS4Date.Text.Trim();


                if (tbCChamAngle1.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@ChamA1", SqlDbType.NChar, 10).Value = tbCChamAngle1.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@ChamA1", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@ChamA1Insp", SqlDbType.NChar, 10).Value = tbCChamA1Insp.Text.Trim();
                cmd.Parameters.Add("@ChamA1Date", SqlDbType.NChar, 10).Value = dtpCChamA1Date.Text.Trim();

                if (tbCChamAngle2.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@ChamA2", SqlDbType.NChar, 10).Value = tbCChamAngle2.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@ChamA2", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@ChamA2Insp", SqlDbType.NChar, 10).Value = tbCChamA2Insp.Text.Trim();
                cmd.Parameters.Add("@ChamA2Date", SqlDbType.NChar, 10).Value = dtpCChamA2Date.Text.Trim();

                if (tbCChamAngle3.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@ChamA3", SqlDbType.NChar, 10).Value = tbCChamAngle3.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@ChamA3", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@ChamA3Insp", SqlDbType.NChar, 10).Value = tbCChamA3Insp.Text.Trim();
                cmd.Parameters.Add("@ChamA3Date", SqlDbType.NChar, 10).Value = dtpCChamA3Date.Text.Trim();

                if (tbCChamAngle4.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@ChamA4", SqlDbType.NChar, 10).Value = tbCChamAngle4.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@ChamA4", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@ChamA4Insp", SqlDbType.NChar, 10).Value = tbCChamA4Insp.Text.Trim();
                cmd.Parameters.Add("@ChamA4Date", SqlDbType.NChar, 10).Value = dtpCChamA4Date.Text.Trim();


                if (tbS1BevMin.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@S1BevelMin", SqlDbType.NChar, 10).Value = tbS1BevMin.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@S1BevelMin", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@S1BevMinInsp", SqlDbType.NChar, 10).Value = tbS1BevMinInsp.Text.Trim();
                cmd.Parameters.Add("@S1BevMinDate", SqlDbType.NChar, 10).Value = dtpS1BevMinDate.Text.Trim();

                if (tbS1BevMax.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@S1BevelMax", SqlDbType.NChar, 10).Value = tbS1BevMax.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@S1BevelMax", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@S1BevMaxInsp", SqlDbType.NChar, 10).Value = tbS1BevMaxInsp.Text.Trim();
                cmd.Parameters.Add("@S1BevMaxDate", SqlDbType.NChar, 10).Value = dtpS1BevMaxDate.Text.Trim();


                if (tbS2BevMin.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@S2BevelMin", SqlDbType.NChar, 10).Value = tbS2BevMin.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@S2BevelMin", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@S2BevMinInsp", SqlDbType.NChar, 10).Value = tbS2BevMinInsp.Text.Trim();
                cmd.Parameters.Add("@S2BevMinDate", SqlDbType.NChar, 10).Value = dtpS2BevMinDate.Text.Trim();

                if (tbS2BevMax.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@S2BevelMax", SqlDbType.NChar, 10).Value = tbS2BevMax.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@S2BevelMax", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@S2BevMaxInsp", SqlDbType.NChar, 10).Value = tbS2BevMaxInsp.Text.Trim();
                cmd.Parameters.Add("@S2BevMaxDate", SqlDbType.NChar, 10).Value = dtpS2BevMaxDate.Text.Trim();


                if (tbS1BevelAngle.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@S1BevAngle", SqlDbType.NChar, 10).Value = tbS1BevelAngle.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@S1BevAngle", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@S1BevAngleInsp", SqlDbType.NChar, 10).Value = tbS1BevAngleInsp.Text.Trim();
                cmd.Parameters.Add("@S1BevAngleDate", SqlDbType.NChar, 10).Value = dtpS1AngleDate.Text.Trim();

                if (tbS2BevelAngle.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@S2BevAngle", SqlDbType.NChar, 10).Value = tbS2BevelAngle.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@S2BevAngle", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@S2BevAngleInsp", SqlDbType.NChar, 10).Value = tbS2BevAngleInsp.Text.Trim();
                cmd.Parameters.Add("@S2BevAngleDate", SqlDbType.NChar, 10).Value = dtpS2AngleDate.Text.Trim();

                
                if (tbE2EDegrees.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@PerpE2Edegrees", SqlDbType.NChar, 10).Value = tbE2EDegrees.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@PerpE2Edegrees", SqlDbType.NChar, 10).Value = "0";
                }

                if (tbE2EMinutes.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@PerpE2Eminutes", SqlDbType.NChar, 10).Value = tbE2EMinutes.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@PerpE2Eminutes", SqlDbType.NChar, 10).Value = "0";
                }

                if (tbE2ESeconds.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@PerpE2Eseconds", SqlDbType.NChar, 10).Value = tbE2ESeconds.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@PerpE2Eseconds", SqlDbType.NChar, 10).Value = "0";
                }

                if (tbPerpE2E.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@PerpE2E", SqlDbType.NChar, 10).Value = tbPerpE2E.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@PerpE2E", SqlDbType.NChar, 10).Value = "0";
                }

                
                cmd.Parameters.Add("@PerpE2Einsp", SqlDbType.NChar, 10).Value = tbPerpE2EInsp.Text.Trim();
                cmd.Parameters.Add("@PerpE2EDate", SqlDbType.NChar, 10).Value = dtpPerpE2EDate.Text.Trim();



                if (tbE2SDegrees.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@PerpE2Sdegrees", SqlDbType.NChar, 10).Value = tbE2SDegrees.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@PerpE2Sdegrees", SqlDbType.NChar, 10).Value = "0";
                }

                if (tbE2SMinutes.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@PerpE2Sminutes", SqlDbType.NChar, 10).Value = tbE2SMinutes.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@PerpE2Sminutes", SqlDbType.NChar, 10).Value = "0";
                }

                if (tbE2SSeconds.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@PerpE2Sseconds", SqlDbType.NChar, 10).Value = tbE2SSeconds.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@PerpE2Sseconds", SqlDbType.NChar, 10).Value = "0";
                }

                if (tbPerpE2S.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@PerpE2S", SqlDbType.NChar, 10).Value = tbPerpE2S.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@PerpE2S", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@PerpE2Sinsp", SqlDbType.NChar, 10).Value = tbPerpE2SInsp.Text.Trim();
                cmd.Parameters.Add("@PerpE2SDate", SqlDbType.NChar, 10).Value = dtpPerpE2SDate.Text.Trim();



                cnxn.Open();
                int rowsReturned = cmd.ExecuteNonQuery();
 
        }
        catch (SqlException ex)
        {
            MessageBox.Show(ex.Message);
        }
            finally
            {
                cnxn.Close();

            }
            Close();
    }

        private void tbLength_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbLength, 609.9M, 609.6M);
        }

        private void tbWidth_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbWidth, 429.9M, 429.6M);
        }

        private void tbCChamSize1_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbCChamSize1, 8M, 6M);
        }

        private void tbCChamSize2_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbCChamSize2, 8M, 6M);
        }

        private void tbCChamSize3_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbCChamSize3, 8M, 6M);
        }

        private void tbCChamSize4_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbCChamSize4, 8M, 6M);
        }

        private void tbCChamAngle1_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbCChamAngle1, 50, 40);
        }

        private void tbCChamAngle2_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbCChamAngle2, 50, 40);
        }

        private void tbCChamAngle3_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbCChamAngle3, 50, 40);
        }

        private void tbCChamAngle4_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbCChamAngle4, 50, 40);
        }

        private void tbS1BevMin_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbS1BevMin, 1.55M, .95M);
        }

        private void tbS1BevMax_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbS1BevMax, 1.55M, .95M);
        }

        private void tbS2BevMin_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbS2BevMin, 1.55M, .95M);
        }

        private void tbS2BevMax_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbS2BevMax, 1.55M, .95M);
        }

        private void tbS1BevelAngle_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbS1BevelAngle, 50, 40);
        }

        private void tbS2BevelAngle_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbS2BevelAngle, 50, 40);
        }

        private void tbE2EDegrees_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbE2EDegrees, 90, 89);

            if (tbE2EDegrees.BackColor.G == 200 &
                tbE2EMinutes.BackColor.G == 200 & tbE2ESeconds.BackColor.G == 200)
            {
                tbPerpE2E.Text = (Math.Abs(90 - (Convert.ToDecimal(tbE2EDegrees.Text) +
                    Convert.ToDecimal(tbE2EMinutes.Text) / 60 +
                    Convert.ToDecimal(tbE2ESeconds.Text) / 3600)) * 60).ToString();
            }
        }

        private void tbE2EMinutes_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbE2EMinutes, 60, 0);

            if (tbE2EDegrees.BackColor.G == 200 &
                tbE2EMinutes.BackColor.G == 200 & tbE2ESeconds.BackColor.G == 200)
            {
                tbPerpE2E.Text = (Math.Abs(90 - (Convert.ToDecimal(tbE2EDegrees.Text) +
                    Convert.ToDecimal(tbE2EMinutes.Text) / 60 +
                    Convert.ToDecimal(tbE2ESeconds.Text) / 3600)) * 60).ToString();
            }
        }

        private void tbE2ESeconds_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbE2ESeconds, 60, 0);

            if (tbE2EDegrees.BackColor.G == 200 &
                tbE2EMinutes.BackColor.G == 200 & tbE2ESeconds.BackColor.G == 200)
            {
                tbPerpE2E.Text = (Math.Abs(90 - (Convert.ToDecimal(tbE2EDegrees.Text) +
                    Convert.ToDecimal(tbE2EMinutes.Text) / 60 +
                    Convert.ToDecimal(tbE2ESeconds.Text) / 3600)) * 60).ToString();
            }
        }

        private void tbPerpE2E_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbPerpE2E, 5, 0);
        }

        private void tbE2SDegrees_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbE2SDegrees, 90, 89);

            if (tbE2SDegrees.BackColor.G == 200 &
                tbE2SMinutes.BackColor.G == 200 & tbE2SSeconds.BackColor.G == 200)
            {
                tbPerpE2S.Text = (Math.Abs(90 - (Convert.ToDecimal(tbE2SDegrees.Text) +
                    Convert.ToDecimal(tbE2SMinutes.Text)/60 +
                    Convert.ToDecimal(tbE2SSeconds.Text)/3600)) * 60).ToString();
            }
        }

        private void tbE2SMinutes_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbE2SMinutes, 60, 0);

            if (tbE2SDegrees.BackColor.G == 200 &
                tbE2SMinutes.BackColor.G == 200 & tbE2SSeconds.BackColor.G == 200)
            {
                tbPerpE2S.Text = (Math.Abs(90 - (Convert.ToDecimal(tbE2SDegrees.Text) +
                    Convert.ToDecimal(tbE2SMinutes.Text) / 60 +
                    Convert.ToDecimal(tbE2SSeconds.Text) / 3600)) * 60).ToString();
            }
        }

        private void tbE2SSeconds_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbE2SSeconds, 60, 0);

            if (tbE2SDegrees.BackColor.G == 200 &
                tbE2SMinutes.BackColor.G == 200 & tbE2SSeconds.BackColor.G == 200)
            {
                tbPerpE2S.Text = (Math.Abs(90 - (Convert.ToDecimal(tbE2SDegrees.Text) +
                    Convert.ToDecimal(tbE2SMinutes.Text) / 60 +
                    Convert.ToDecimal(tbE2SSeconds.Text) / 3600)) * 60).ToString();
            }
        }

        private void tbPerpE2S_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbPerpE2S, 10, 0);
        }

        private void tbLenInsp_Leave(object sender, EventArgs e)
        {
            tbWidInsp.Text = tbLenInsp.Text;
            tbCChamS1Insp.Text = tbLenInsp.Text;
            tbCChamS2Insp.Text = tbLenInsp.Text;
            tbCChamS3Insp.Text = tbLenInsp.Text;
            tbCChamS4Insp.Text = tbLenInsp.Text;
            tbCChamA1Insp.Text = tbLenInsp.Text;
            tbCChamA2Insp.Text = tbLenInsp.Text;
            tbCChamA3Insp.Text = tbLenInsp.Text;
            tbCChamA4Insp.Text = tbLenInsp.Text;
            tbS1BevMinInsp.Text = tbLenInsp.Text;
            tbS1BevMaxInsp.Text = tbLenInsp.Text;
            tbS2BevMinInsp.Text = tbLenInsp.Text;
            tbS2BevMaxInsp.Text = tbLenInsp.Text;
            tbS1BevAngleInsp.Text = tbLenInsp.Text;
            tbS2BevAngleInsp.Text = tbLenInsp.Text;
            tbPerpE2EInsp.Text = tbLenInsp.Text;
            tbPerpE2SInsp.Text = tbLenInsp.Text;
        }



        private void dtpLenDate_Leave(object sender, EventArgs e)
        {
            dtpWidDate.Value = dtpLenDate.Value;
            dtpCChamS1Date.Value = dtpLenDate.Value;
            dtpCChamS2Date.Text = dtpLenDate.Text;
            dtpCChamS3Date.Text = dtpLenDate.Text;
            dtpCChamS4Date.Text = dtpLenDate.Text;
            dtpCChamA1Date.Text = dtpLenDate.Text;
            dtpCChamA2Date.Text = dtpLenDate.Text;
            dtpCChamA3Date.Text = dtpLenDate.Text;
            dtpCChamA4Date.Text = dtpLenDate.Text;
            dtpS1BevMinDate.Text = dtpLenDate.Text;
            dtpS1BevMaxDate.Text = dtpLenDate.Text;
            dtpS2BevMinDate.Text = dtpLenDate.Text;
            dtpS2BevMaxDate.Text = dtpLenDate.Text;
            dtpS1AngleDate.Text = dtpLenDate.Text;
            dtpS2AngleDate.Text = dtpLenDate.Text;
            dtpPerpE2EDate.Text = dtpLenDate.Text;
            dtpPerpE2SDate.Text = dtpLenDate.Text;
        }
    }
}
