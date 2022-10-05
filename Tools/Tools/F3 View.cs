using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Tools
{
    public partial class F3_View : Form
    {
        SqlDataAdapter da;
        SqlConnection cnxn;
        private string SQL;

        public F3_View()
        {
            InitializeComponent();
        }

        private void F3_View_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);

            if (g.program == "CNC" | g.program == "LFO" )
            {
                SQL = "Select * FROM viewtools v ";
                    
                    /*from viewtools v " +
                 "inner join toollocation l on v.SN = l.lsn " +
                 "where program = '" + g.program + "' " +
                 "and Lfacility = '" + g.facility + "' " +
                 "and status is not null  and status != 'I' " +
                 "order by sn";
                 */

                //da = new SqlDataAdapter
                //     ("select " + 
                //     "tooltype, " +
                //     "SN, " +
                //     "Diameter, " +
                //     "Diameter_M , " +
                //     "Grit, " +
                //     "NoseRadius , " +
                //     "Location as [Home Location], " +
                //     "Angle , " +
                //     "UsableLength , " +
                //     "UsableLength_M , " +
                //     "DiamondLength , " +
                //     "DiamondLength_M , " +
                //     "PlatedBonded , " +
                //     "MountType , " +
                //     "ShankDiameter , " +
                //     "ShankDiameter_M , " +
                //     "ReliefDiameter, " +
                //     "ReliefDiameter_M, " +
                //     "FlatDiameter , " +
                //     "FlatDiameter_M , " +
                //     "InnerDiameter, " +
                //     "InnerDiameter_M, " +
                //     "ColletLength, " +
                //     "ColletLength_M, " +
                //     "ColletNutSize , " +
                //     "ToolHolderType , " +
                //     "ToolNumber , " +
                //     "RefReorderNumber , " +
                //     "Status , " +
                //     "OldSN , " +
                //     "Notes , " +
                //     "Supplier, " +
                //     "Thickness " +
                //     "from tools " +
                //     "where machinetype = '" + g.program + "' " +
                //     "order by sn", cnxn);

            }
            else
            {
                SQL = "SELECT " +
                      "sn, " +
                      "Diameter_M [Diameter mm], " +
                      "UsableLength_M [Length mm], " +
                      "Width_M [Width mm], " +
                      "RTRIM(ItemDescription) [Description], " +
                      "RTrim(LLocation) Location, " +
                      "Status " +
                      "FROM tools v ";
            }

            try
            {
                da = new SqlDataAdapter
                    (SQL + 
                     "inner join toollocation l on v.SN = l.lsn " +
                     "where lprogram = '" + g.program + "' " +
                     "and Lfacility = '" + g.facility + "' " +
                     "and status is not null  and status != 'I' " +
                     "order by sn", cnxn);

                DataTable table = new DataTable();
                da.Fill(table);

                DGV.DataSource = table;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

            }

            if (g.program == "CNC" | g.program == "LFO")
            {
                DGV.Columns[21].Visible = false;

                DGV.Columns[0].Width = 140;
                DGV.Columns[1].Width = 60;
                DGV.Columns[1].DividerWidth = 6;
                DGV.Columns[2].Width = 145;
                DGV.Columns[3].Width = 75;
                DGV.Columns[4].Width = 60;
                DGV.Columns[5].Width = 90;
                DGV.Columns[6].Width = 60;
                DGV.Columns[7].Width = 140;
                DGV.Columns[8].Width = 140;
                DGV.Columns[9].Width = 70;
                DGV.Columns[10].Width = 140;
                DGV.Columns[11].Width = 140;
                DGV.Columns[12].Width = 140;
                DGV.Columns[13].Width = 140;
                DGV.Columns[14].Width = 140;
                DGV.Columns[15].Width = 70;
                DGV.Columns[16].Width = 70;
                DGV.Columns[17].Width = 60;
                DGV.Columns[18].Width = 60;
                DGV.Columns[19].Width = 140;
                DGV.Columns[20].Width = 140;
            }
            else
            {
                DGV.Columns[0].Width = 140;
                DGV.Columns[1].Width = 70;
                DGV.Columns[2].Width = 70;
                DGV.Columns[3].Width = 70;
                DGV.Columns[4].Width = 250;
                DGV.Columns[5].Width = 90;
                DGV.Columns[6].Width = 60;
            }

        }
    }
}