using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;


namespace TaiwanPackingListPrinter
{
    public partial class TwPrintList : Form
    {
        DataTable dt;
        private string document;
        private string documentDescription;
        private string revision;
        private string flag = "";

        private string itemCode;
        private string iDescription;
        private string iQty;
        private string boxes;
        private int BoxCount;

        private string Part;
        private string line1;
        private string line2;
        private string line3;
        private string labelQuantity;
        private int firstLastIndex;
        private int secondLastIndex;

        private string printer = "zebra3x1";
        //private string printer = "ZDesigner GX430t";
        public TwPrintList()
        {
            InitializeComponent();

            this.Text = "Packing List Label Printer  v" + Application.ProductVersion;
        }

        private void B01_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add("Item_Code");
            dt.Columns.Add("Description");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Boxes");

            DataRow newRow;

            newRow = dt.NewRow();
            newRow[0] = "6311-0200-01";
            newRow[1] = "NV9000 BASE WITH ISOLATION";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6311-0104-01";
            newRow[1] = "PROFILER HEAD, NV9000";
            newRow[2] = "1";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6300-0817-04";
            newRow[1] = "FILTER TRAY ASSY";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6301-0167-01";
            newRow[1] = "SINGLE MNT DOVETAIL ASSY 38.9";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6450-8504-04";
            newRow[1] = "CoMOTION PENDANT PRGM";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6300-0239-11";
            newRow[1] = "SYSTEM CONTROLLER";
            newRow[2] = "1";
            newRow[3] = "2";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-341";
            newRow[1] = "CABLE ASSY RJ45 X-OVER 10ft.";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-259";
            newRow[1] = "CABLE 9D M to 9D F 6ft.";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-043";
            newRow[1] = "CABLE ASSY DOM 15ft.";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-042";
            newRow[1] = "CABLE ASSY EUROPEAN";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-224";
            newRow[1] = "CABLE ASSY UK";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-070";
            newRow[1] = "CABLE DISPLAYPORT M/M 10'";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1011-000-001";
            newRow[1] = "ADAPTER";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-010";
            newRow[1] = "CABLE PWR CRD C13 TO C14 1M";
            newRow[2] = "2";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-008";
            newRow[1] = "CABLE PWR CRD C13 TO C14 3M";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-217";
            newRow[1] = "CABLE ASSY 4 OUTLET STRIP";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-415";
            newRow[1] = "CAT 6 PATCH CBL, RJ45, 14FT";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1343-000-030";
            newRow[1] = "FUSE 3A 250V SLO BLO";
            newRow[2] = "2";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-392";
            newRow[1] = "M12 X 4 SHUNT PLUG, JUMP 2,3,4";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "";
            newRow[1] = "OPTIONAL ACCESSORIES";
            newRow[2] = "";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6450-0815-___";
            newRow[1] = "   ___  AXIS MOTION OPTION";
            newRow[2] = "1";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6450-0911-___";
            newRow[1] = "   ___  AXIS DRIVER BOX";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "9000-2000-01";
            newRow[1] = "Mx SOFTWARE BUNDLE";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "9000-2001-03";
            newRow[1] = "METROPRO X INSTRUMENT LICENSE";
            newRow[2] = "1";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "9000-2001-09";
            newRow[1] = "METROPRO X ADVANCED ACQUISITION OPTIONS LICENSE";
            newRow[2] = "1";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1332-700-009";
            newRow[1] = @"FITTING REDUCER 1/4"" TO 6mm";
            newRow[2] = "2";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1924-600-097";
            newRow[1] = "TUBING POLYURE BLUE 6MM OD";
            newRow[2] = "6 in";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1924-600-098";
            newRow[1] = "TUBING POLYURE BLACK 6MM OD";
            newRow[2] = "6 in";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "";
            newRow[1] = "Miscellaneous Documents";
            newRow[2] = "";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            if (cbSingle.Checked)
            {
                Grid();
            }
            else
            {
                printLabels();
            }


        }

        private void B11_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add("Item_Code");
            dt.Columns.Add("Description");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Boxes");

            DataRow newRow;

            newRow = dt.NewRow();
            newRow[0] = "6311-0200-11";
            newRow[1] = "NV9000 BASE W/O ISOLATION";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6311-0104-01";
            newRow[1] = "PROFILER HEAD, NV9000";
            newRow[2] = "1";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6300-0817-04";
            newRow[1] = "FILTER TRAY ASSY";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6301-0167-01";
            newRow[1] = "SINGLE MNT DOVETAIL ASSY 38.9";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6450-8504-04";
            newRow[1] = "CoMOTION PENDANT PRGM";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6300-0239-11";
            newRow[1] = "SYSTEM CONTROLLER";
            newRow[2] = "1";
            newRow[3] = "2";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-341";
            newRow[1] = "CABLE ASSY RJ45 X-OVER 10ft.";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-259";
            newRow[1] = "CABLE 9D M to 9D F 6ft.";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-415";
            newRow[1] = "CAT 6 PATCH CABLE RJ45 14ft";
            newRow[2] = "1";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-043";
            newRow[1] = "CABLE ASSY DOM 15ft.";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-042";
            newRow[1] = "CABLE ASSY EUROPEAN";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-224";
            newRow[1] = "CABLE ASSY UK";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-070";
            newRow[1] = "CABLE DISPLAYPORT M/M 10'";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1011-000-001";
            newRow[1] = "ADAPTER";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-010";
            newRow[1] = "CABLE PWR CRD C13 TO C14 1M";
            newRow[2] = "2";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-008";
            newRow[1] = "CABLE PWR CRD C13 TO C14 3M";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-217";
            newRow[1] = "CABLE ASSY 4 OUTLET STRIP";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1343-000-030";
            newRow[1] = "FUSE 3A 250V SLO BLO";
            newRow[2] = "2";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "";
            newRow[1] = "Miscellaneous Documents";
            newRow[2] = "";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-392";
            newRow[1] = "M12 X 4 SHUNT PLUG, JUMP 2,3,4";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "";
            newRow[1] = "OPTIONAL ACCESSORIES";
            newRow[2] = "";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6450-0815-___";
            newRow[1] = "   ___  AXIS MOTION OPTION";
            newRow[2] = "1";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6450-0911-___";
            newRow[1] = "   ___  AXIS DRIVER BOX";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "9000-2000-01";
            newRow[1] = "Mx SOFTWARE BUNDLE";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "9000-2001-03";
            newRow[1] = "METROPRO X INSTRUMENT LICENSE";
            newRow[2] = "1";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "9000-2001-09";
            newRow[1] = "METROPRO X ADVANCED ACQUISITION OPTIONS LICENSE";
            newRow[2] = "1";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1332-700-009";
            newRow[1] = @"FITTING REDUCER 1/4"" TO 6mm";
            newRow[2] = "2";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1924-600-097";
            newRow[1] = "TUBING POLYURE BLUE 6MM OD";
            newRow[2] = "6 in";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1924-600-098";
            newRow[1] = "TUBING POLYURE BLACK 6MM OD";
            newRow[2] = "6 in";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            if (cbSingle.Checked)
            {
                Grid();
            }
            else
            {
                printLabels();
            }
        }

        private void B6314o100o01_Click(object sender, EventArgs e)
        {
            dt = new DataTable();

            dt.Columns.Add("Item_Code");
            dt.Columns.Add("Description");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Boxes");

            DataRow newRow;

            newRow = dt.NewRow();
            newRow[0] = "6314-0283-01";
            newRow[1] = "BASE AND HEAD ASSY, ZEGAGE PRO";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6300-0239-07";
            newRow[1] = "SYSTEM W7/64 CONTROLLER";
            newRow[2] = "1";
            newRow[3] = "2";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6450-8509-01";
            newRow[1] = "NX2 PENDANT PRGM";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6301-0167-01";
            newRow[1] = "SINGLE MNT DOVETAIL ASSY, 38.9";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6300-3039-01";
            newRow[1] = "OBJECTIVE ADAPTER RING";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1125-663-239";
            newRow[1] = "NOSEPIECE DUST PLUG RMS Ø20.32";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-328";
            newRow[1] = "CABLE ASSY RJ45 X-OVER 15FT";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-489";
            newRow[1] = "USB3 TYPE A TO TYPE A 3M";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-259";
            newRow[1] = "CABLE 9D M TO 9D F 6FT.";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "9000-2000-01";
            newRow[1] = "MX SOFTWARE BUNDLE";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "9000-2001-03";
            newRow[1] = "METROPRO X INSTRUMENT LICENSE";
            newRow[2] = "1";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "9000-2001-09";
            newRow[1] = "METROPRO X ADV ACQ LICENSE";
            newRow[2] = "1";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1618-600-001";
            newRow[1] = "PROTECTOR STATIC WRIST STRAP";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6314-0815-___";
            newRow[1] = "ZEGAGE PRO, ___________ XY MOTION";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            if (cbSingle.Checked)
            {
                Grid();
            }
            else
            {
                printLabels();
            }
        }

        private void B6314o0105o01_Click(object sender, EventArgs e)
        {
            dt = new DataTable();

            dt.Columns.Add("Item_Code");
            dt.Columns.Add("Description");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Boxes");

            DataRow newRow;

            newRow = dt.NewRow();
            newRow[0] = "6314-0283-01";
            newRow[1] = "BASE AND HEAD ASSY, ZEGAGE PRO";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6300-0239-07";
            newRow[1] = "SYSTEM W7/64 CONTROLLER";
            newRow[2] = "1";
            newRow[3] = "2";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6450-8509-01";
            newRow[1] = "NX2 PENDANT PRGM";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6301-0167-01";
            newRow[1] = "SINGLE MNT DOVETAIL ASSY, 38.9";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6300-3039-01";
            newRow[1] = "OBJECTIVE ADAPTER RING";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1125-663-239";
            newRow[1] = "NOSEPIECE DUST PLUG RMS Ø20.32";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-328";
            newRow[1] = "CABLE ASSY RJ45 X-OVER 15FT";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-489";
            newRow[1] = "USB3 TYPE A TO TYPE A 3M";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-259";
            newRow[1] = "CABLE 9D M TO 9D F 6FT.";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "9000-2000-01";
            newRow[1] = "MX SOFTWARE BUNDLE";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "9000-2001-03";
            newRow[1] = "MX INSTRUMENT LICENSE";
            newRow[2] = "1";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "9000-2001-09";
            newRow[1] = "MX ADV ACQ LICENSE";
            newRow[2] = "1";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "9000-2001-15";
            newRow[1] = "MX PRECISION STAGE SCAN LICENSE";
            newRow[2] = "1";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1618-600-001";
            newRow[1] = "PROTECTOR STATIC WRIST STRAP";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6314-0815-___";
            newRow[1] = "ZEGAGE PRO, ___________ XY MOTION";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            if (cbSingle.Checked)
            {
                Grid();
            }
            else
            {
                printLabels();
            }
        }

        private void Grid()
        {
            DGV.DataSource = dt;
            DGV.Show();
            DGV.Columns[0].Width = 120;
            DGV.Columns[1].Width = 270;
            DGV.Columns[2].Width = 80;
            DGV.Columns[3].Width = 80;
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 1)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                itemCode = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                iDescription = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                iQty = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[3];
                iQty = cell.EditedFormattedValue.ToString().Trim();

                printLabel();
            }
        }



        private void printLabels()
        {
            DataTableReader dr = new DataTableReader(dt);
            while (dr.Read())
            {
                itemCode = dr.GetString(0).Trim();
                iDescription = dr.GetString(1).Trim();
                iQty = "Qty: " + dr.GetString(2).Trim();
                BoxCount = Convert.ToInt32(dr.GetString(3));


                if (BoxCount == 1)
                {
                    Part = "Box/Bag: 1 of 1";
                    printLabel();
                }

                if (BoxCount == 2)
                {
                    Part = "Box/Bag: 1 of 2";
                    printLabel();
                    Part = "Box/Bag: 2 of 2"; ;
                    printLabel();
                }

                if (BoxCount == 3)
                {
                    Part = "Box/Bag: 1 of 3";
                    printLabel();
                    Part = "Box/Bag: 2 of 3";
                    printLabel();
                    Part = "Box/Bag: 3 of 3";
                    printLabel();
                }

                if (BoxCount == 4)
                {
                    Part = "Box/Bag: 1 of 4";
                    printLabel();
                    Part = "Box/Bag: 2 of 4";
                    printLabel();
                    Part = "Box/Bag: 3 of 4";
                    printLabel();
                    Part = "Box/Bag: 4 of 4";
                    printLabel();
                }

            }

            this.Close();
        }

        private void printLabel()
        {
            //Qty = "Qty: " + tbQty.Text.ToString().Trim();
            //SN = tbSN.Text.ToString().Trim();

            int descriptionLength = iDescription.Length;

            if (descriptionLength < 15)
            {
                line1 = iDescription.Trim();
                line2 = "";
                line3 = "";
            }
            else   /*   description length is greater than 14   */
            {
                //if (g.iDescription.IndexOf(" ") != -1)
                //{
                //if (descriptionLength > 14)
                //{
                string a = iDescription.Substring(0, 14);

                if (a.LastIndexOf(",") != -1)
                {
                    firstLastIndex = a.LastIndexOf(",");
                    line1 = iDescription.Substring(0, firstLastIndex + 1);
                }
                else if (a.LastIndexOf(" ") != -1)
                {
                    firstLastIndex = a.LastIndexOf(" ");
                    line1 = iDescription.Substring(0, firstLastIndex);
                }
                else
                {
                    line1 = iDescription.Substring(0, 14);
                    firstLastIndex = 13;
                }
                //}

                if (iDescription.Substring(firstLastIndex + 1, descriptionLength - (firstLastIndex + 1)).Length > 14)
                {
                    string b = iDescription.Substring(firstLastIndex + 1, 14);

                    if (b.LastIndexOf(",") != -1)
                    {
                        secondLastIndex = b.LastIndexOf(",");
                        line2 = iDescription.Substring(firstLastIndex + 1, secondLastIndex + 1);
                    }
                    else if (b.LastIndexOf(" ") != -1)
                    {
                        secondLastIndex = b.LastIndexOf(" ");
                        line2 = iDescription.Substring(firstLastIndex + 1, secondLastIndex);
                    }
                    else if (b.ToUpper().LastIndexOf("X") != -1)
                    {
                        secondLastIndex = b.ToUpper().LastIndexOf("X");
                        line2 = iDescription.Substring(firstLastIndex + 1, secondLastIndex);
                    }
                    else
                    {
                        secondLastIndex = 13;
                        line2 = b;
                    }

                    if (line2.Substring(0, 1) == " ")
                    {
                        line2 = line2.Trim();
                    }
                }
                else
                {
                    line2 = iDescription.Substring(firstLastIndex + 1, descriptionLength - (firstLastIndex + 1));
                    secondLastIndex = -1;
                }

                if (secondLastIndex != -1)
                {
                    line3 = iDescription.Substring(firstLastIndex + secondLastIndex + 2, descriptionLength -
                            (firstLastIndex + secondLastIndex + 2));

                    if (line3.Substring(0, 1) == " ")
                    {
                        line3 = line3.Trim();
                    }
                }
                else
                {
                    line3 = "";
                }

                if (line1.Length > 14 | line2.Length > 14 | line3.Length > 14)
                {
                    line1 = iDescription.Substring(0, 14);

                    if (descriptionLength > 28)
                    {
                        line2 = iDescription.Substring(14, 14);
                    }
                    else  //( descriptionLength <= 28 )
                    {
                        line2 = iDescription.Substring(14, descriptionLength - 14);
                    }

                    if (descriptionLength > 28)
                    {
                        line3 = iDescription.Substring(28, descriptionLength - 28);
                    }
                }

                if (line1.Length > 0)
                {
                    line1 = line1.Replace("\"", "\\\"");
                }

                if (line2.Length > 0)
                {
                    line2 = line2.Replace("\"", "\\\"");
                }

                if (line3.Length > 0)
                {
                    line3 = line3.Replace("\"", "\\\"");
                }

            }

            labelQuantity = "1";

            //Bitmap bzp = Properties.Resources.zygo_blk_noR_132;
            //Bitmap bxp = Properties.Resources.ametek_blk_noR_132;

            ///*
            // *  Add the image to the resources folder or elsewhere, then add the file to the
            // *  resourses.resx file and it will take in the file and reclassify it as an image.
            // *  It should then be available under properties.resources - the case does matter for 
            // *  the image name.
            // */

            ////Bitmap bzp = new Bitmap(@"c:\a\zygo_blk_noR_132.bmp");
            ////Bitmap bxp = new Bitmap(@"c:\a\AMETEK_blk_noR_132.bmp");
            ////line1 = "4\\\" Colimeter";

            //string str = "\nN\nq609Q203,20\n";
            //str += SendImageToPrinter(20, 10, bzp);
            //str += SendImageToPrinter(700, 10, bxp);
            //str += "A200,10,0,2,1,1,N,\"1F, No.26, Chuangye Road\"\n";
            //str += "A200,40,0,2,1,1,N,\"Tainan City 74144 Taiwan\"\n";
            ////str += "A20,80,0,2,1,1,N,\"PN#\"\n";
            ////str += "B90,80,0,1,2,4,32,B,\"" + itemCode + "\"\n";
            //str += "A600,75,0,2,1,1,N,\"" + line1 + "\"\n";
            //str += "A600,105,0,2,1,1,N,\"" + line2 + "\"\n";
            //str += "A600,135,0,2,1,1,N,\"" + line3 + "\"\n";
            //str += "A20,160,0,2,1,1,N,\"SN#\"\n";
            ////str += "B70,16,0,1,2,4,32,B,\"" +  + "\"\n";
            //str += "A600,170,0,2,1,1,N,\"REV: \"\n";
            //str += "A600,200,0,2,1,1,N,\"" + iQty + "\"\n";
            //str += "A600,230,0,2,1,1,N,\"" + Part + "\"\n";
            //str += "P" + labelQuantity + "\n";
            //RawPrinterHelper.SendStringToPrinter(printer, str);

            StringBuilder ZplBuilder = new StringBuilder();

            // Exemple ZPL String
            //ZplBuilder.Append("~WC");   //prints configuration label

            //ZplBuilder.Append("~JC");   //set mdeia sensor calibration
            //ZplBuilder.Append("~WC");

            ZplBuilder.Append("^XA");   //Start ZPL

            /*  shipping label logo size    */
            ZplBuilder.Append("^FO20, 50 ^GFA, 578, 578, 17, 3KFE01FE3F1FE03FC, 7LF01FEFFDFE1IF, 7LF03LFE3IFC, 7LF03LFEJFE, 7LF83LFEKF, 7LF87RF, 007FF7F87IFC7JF1FF8, 00FFE3FC7IF83IFE0FF8, 01FFC3FC7IF83IFC07F8, 03FF83FCJF83IFC07F8, 03FF01FEFEFF83IFC07FC, 07FE01FEFEFF83IFC07F8, 0FFC00IFEFF83IFC07F8, 1FF800IFC7F83IFC07F8, 3FFI07FFC7LFE0FF8, 7JF87FFC7MF1FF, KF87FF83PF, KF83FF81JFEJFE, KF83FF80JFE7IFC, KF81FF007F3FE3IF8, 7JF81FFJ03FE0FFE, L01FEJ03FE01F, L01FE0FF83FE, K07FFE07FC7FC, K07FFC07JFC, K07FFC07JF8, K07FF803JF8, K07FF001IFE, K07FCI07FFC,,::gSF,:^FS");
            ZplBuilder.Append("^FO740,50^GFA,357,357,17,,001,003801FF807FCJFDJFEJFDFE1FC,003801FF80FFCJFDJFEJFDFE3F8,007C01FFC0FFCJFDJFEJFDFE7F,007E01FFC1FFCJFDJFEJFDFEFE,00FE01FFE1FFCJFDJFEJFDIFE,00FF01FFE3FFCFEJ03F80FE001IFC,00FF01IF3FFCJFC03F80JFDIF8,007F81IF7FFCJFC03F80JFDIF,007F81LFCJFC03F80JFDIF8,003FC1LFCJFC03F80JFDIF8,003FC1LFCJFC03F80JFDIFC,001FE1JFEFCFEJ03F80FE001IFE,0FEFF1FDFFCFCFEJ03F80FE001IFE,1FCFF1FDFFCFCJF803F80JF9FEFF,1FC7F9FCFFCFCJFC03F80JFDFE7F8,3F87F9FCFF8FCJFC03F80JFDFE7FC,3F83FDFC7F8FCJFC03F80JFDFE3FC,7F03FDFC7F0FCJFC03F80JFDFE3FE,7E01IFC3F0FC7IF803F007IF8FC1FE,^FS");

            /*  text ^A font, orientation, height, width(dots)
             *  barcode = code 128
             */
            ZplBuilder.Append("^FO170,60^A0N,30,25^FD1F, No.26, Chuangye Road, Tainan City 74144 Taiwan^FS");
            ZplBuilder.Append("^FO20,120^A0N,35,35^FDPN#^FS");
            ZplBuilder.Append("^FO90,170^A0N,35,50^FD").Append(itemCode).Append("^FS");
            ZplBuilder.Append("^FO90,110^BCN,50,N^FD").Append(itemCode).Append("^FS");

            ZplBuilder.Append("^FO20,220^A0N,35,35^FDSN#^FS");
            //ZplBuilder.Append("^FO90,270^A0N,35,50^FD").Append(tbSN.Text.Trim()).Append("^FS");
            //ZplBuilder.Append("^FO90,210^BCN,50,N^FD").Append(tbSN.Text.Trim()).Append("^FS");

            ZplBuilder.Append("^FO650,110^A0N,30,30^FD").Append(line1).Append("^FS");
            ZplBuilder.Append("^FO650,142^A0N,30,30^FD").Append(line2).Append("^FS");
            ZplBuilder.Append("^FO650,174^A0N,30,30^FD").Append(line3).Append("^FS");
            ZplBuilder.Append("^FO650,206^A0N,30,30^FDRev:^FS");
            ZplBuilder.Append("^FO650,238^A0N,30,30^FD").Append(iQty).Append("^FS");
            ZplBuilder.Append("^FO650,270^A0N,30,30^FD").Append(Part).Append("^FS");


            ZplBuilder.Append("^XZ");

            string ZplString = ZplBuilder.ToString();

            MemoryStream lmemStream = new MemoryStream();

            StreamWriter lstreamWriter = new StreamWriter(lmemStream);
            lstreamWriter.Write(ZplString);
            lstreamWriter.Flush();
            lmemStream.Position = 0;

            byte[] byteArray = lmemStream.ToArray();

            IntPtr cpUnmanagedBytes = new IntPtr(0);
            int cnLength = byteArray.Length;
            cpUnmanagedBytes = Marshal.AllocCoTaskMem(cnLength);
            Marshal.Copy(byteArray, 0, cpUnmanagedBytes, cnLength);

            RawPrinterHelper.SendBytesToPrinter("ZDesigner GX430t", cpUnmanagedBytes, cnLength);
            Marshal.FreeCoTaskMem(cpUnmanagedBytes);




            //tbSerialNumber.Text = "";
            //tbSerialNumber.Focus();

        }


        private static string SendImageToPrinter(int top, int left, System.Drawing.Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            using (BinaryWriter bw = new BinaryWriter(ms, Encoding.ASCII))
            {
                //we set p3 parameter, remember it is Width of Graphic in bytes,
                //so we divive the width of image and round up of it
                int P3 = (int)Math.Ceiling((double)bitmap.Width / 8);
                bw.Write(Encoding.ASCII.GetBytes(string.Format
                ("GW{0},{1},{2},{3},", top, left, P3, bitmap.Height)));
                //the width of matrix is rounded up multi of 8
                int canvasWidth = P3 * 8;
                //Now we convert image into 2 dimension binary matrix by 2 for loops below,
                //in the range of image, we get colour of pixel of image,
                //calculate the luminance in order to set value of 1 or 0
                //otherwise we set value to 1
                //Because P3 is set to byte (8 bits), so we gather 8 dots of this matrix,
                //convert into a byte then write it to memory by using shift left operator <<
                //e,g 1 << 7  ---> 10000000
                //    1 << 6  ---> 01000000
                //    1 << 3  ---> 00001000
                for (int y = 0; y < bitmap.Height; ++y)     //loop from top to bottom
                {
                    for (int x = 0; x < canvasWidth;)       //from left to right
                    {
                        byte abyte = 0;
                        for (int b = 0; b < 8; ++b, ++x)     //get 8 bits together and write to memory
                        {
                            int dot = 1;                     //set 1 for white,0 for black
                            //pixel still in width of bitmap,
                            //check luminance for white or black, out of bitmap set to white
                            if (x < bitmap.Width)
                            {
                                System.Drawing.Color color = bitmap.GetPixel(x, y);
                                int luminance = (int)((color.R * 0.3) + (color.G * 0.59) + (color.B * 0.11));
                                dot = luminance > 127 ? 1 : 0;
                            }
                            abyte |= (byte)(dot << (7 - b)); //shift left,
                            //then OR together to get 8 bits into a byte
                        }
                        bw.Write(abyte);
                    }
                }
                bw.Write("\n");
                bw.Flush();
                //reset memory
                ms.Position = 0;
                //get encoding, I have no idea why encode page of 1252 works and fails for others
                return Encoding.GetEncoding(1252).GetString(ms.ToArray());
            }
        }

        private void bBack_Click(object sender, EventArgs e)
        {

        }


        public class RawPrinterHelper
        {
            // Structure and API declarions:
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
            public class DOCINFOA
            {
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDocName;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pOutputFile;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDataType;
            }
            [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

            [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool ClosePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

            [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndDocPrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

            // SendBytesToPrinter()
            // When the function is given a printer name and an unmanaged array
            // of bytes, the function sends those bytes to the print queue.
            // Returns true on success, false on failure.
            public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
            {
                Int32 dwError = 0, dwWritten = 0;
                IntPtr hPrinter = new IntPtr(0);
                DOCINFOA di = new DOCINFOA();
                bool bSuccess = false; // Assume failure unless you specifically succeed.

                di.pDocName = "My C#.NET RAW Document";
                di.pDataType = "RAW";

                // Open the printer.
                if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
                {
                    // Start a document.
                    if (StartDocPrinter(hPrinter, 1, di))
                    {
                        // Start a page.
                        if (StartPagePrinter(hPrinter))
                        {
                            // Write your bytes.
                            bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                            EndPagePrinter(hPrinter);
                        }
                        EndDocPrinter(hPrinter);
                    }
                    ClosePrinter(hPrinter);
                }
                // If you did not succeed, GetLastError may give more information
                // about why not.
                if (bSuccess == false)
                {
                    dwError = Marshal.GetLastWin32Error();
                }
                return bSuccess;
            }

            public static bool SendFileToPrinter(string szPrinterName, string szFileName)
            {
                // Open the file.
                FileStream fs = new FileStream(szFileName, FileMode.Open);
                // Create a BinaryReader on the file.
                BinaryReader br = new BinaryReader(fs);
                // Dim an array of bytes big enough to hold the file's contents.
                Byte[] bytes = new Byte[fs.Length];
                bool bSuccess = false;
                // Your unmanaged pointer.
                IntPtr pUnmanagedBytes = new IntPtr(0);
                int nLength;

                nLength = Convert.ToInt32(fs.Length);
                // Read the contents of the file into the array.
                bytes = br.ReadBytes(nLength);
                // Allocate some unmanaged memory for those bytes.
                pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
                // Copy the managed byte array into the unmanaged array.
                Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
                // Send the unmanaged bytes to the printer.
                bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
                // Free the unmanaged memory that you allocated earlier.
                Marshal.FreeCoTaskMem(pUnmanagedBytes);
                return bSuccess;
            }
            public static bool SendStringToPrinter(string szPrinterName, string szString)
            {
                IntPtr pBytes;
                Int32 dwCount;
                // How many characters are in the string?
                dwCount = (szString.Length + 1) * Marshal.SystemMaxDBCSCharSize;
                // Assume that the printer is expecting ANSI text, and then convert
                // the string to ANSI text.
                pBytes = Marshal.StringToCoTaskMemAnsi(szString);
                // Send the converted ANSI string to the printer.
                SendBytesToPrinter(szPrinterName, pBytes, dwCount);
                Marshal.FreeCoTaskMem(pBytes);
                return true;
            }


        }

        private void headings()
        {
            dt = new DataTable();

            dt.Columns.Add("Item_Code");
            dt.Columns.Add("Description");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Boxes");


        }

        private void b6312o100o1_Click(object sender, EventArgs e)
        {
            headings();

            DataRow newRow;

            newRow = dt.NewRow();
            newRow[0] = "6312-0120-01";
            newRow[1] = "NEXVIEW 2 PROFILER MECH STRUCT";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6312-0104-01";
            newRow[1] = "PROFILER HEAD, NEXVIEW 2";
            newRow[2] = "1";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6301-0167-01";
            newRow[1] = "SINGLE MNT DOVETAIL ASSY 38.9";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6450-8509-01";
            newRow[1] = "NX2 PENDANT PRGM";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6300-0239-10";
            newRow[1] = "SYSTEM CONTROLLER";
            newRow[2] = "1";
            newRow[3] = "2";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-341";
            newRow[1] = "CABLE ASSY RJ45 X-OVER 10ft.";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-259";
            newRow[1] = "CABLE 9D M to 9D F 6ft.";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-043";
            newRow[1] = "CABLE ASSY DOM 15ft.";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-042";
            newRow[1] = "CABLE ASSY EUROPEAN";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-224";
            newRow[1] = "CABLE ASSY UK";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-070";
            newRow[1] = "CABLE DISPLAYPORT M/M 10'";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1011-000-001";
            newRow[1] = "ADAPTER";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1343-000-026";
            newRow[1] = "FUSE 2A 250V SLO BLO";
            newRow[2] = "2";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-010";
            newRow[1] = "CABLE PWR CRD C13 TO C14 1M";
            newRow[2] = "2";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-008";
            newRow[1] = "CABLE PWR CRD C13 TO C14 3M";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "";
            newRow[1] = "MISCELLANEOUS DOCUMENTS";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1898-400-011";
            newRow[1] = @"TIE CABLE 1"" X 48"" HOOK/LOOP";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "9000-2000-01";
            newRow[1] = "METROPRO X SOFTWARE BUNDLE";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "9000-2001-03";
            newRow[1] = "METROPRO X INSTRUMENT LICENSE";
            newRow[2] = "1";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "9000-2001-09";
            newRow[1] = "METROPRO X ADV ACQ LICENSE";
            newRow[2] = "1";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1332-700-009";
            newRow[1] = @"FITTING REDUCER 1/4"" TO 6mm";
            newRow[2] = "2";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1924-600-097";
            newRow[1] = "TUBING POLYURE BLUE 6MMOD";
            newRow[2] = "6";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1924-600-098";
            newRow[1] = "TUBING POLYURE BLACK 6MM OD";
            newRow[2] = "6 in";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1520-500-186";
            newRow[1] = "MNT OPT XY MTR STAGE 200MM";
            newRow[2] = "1";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1520-500-155";
            newRow[1] = "100MM Z-STAGE W/BRAKE";
            newRow[2] = "1";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-489";
            newRow[1] = "USB3 Type A to Type A 3m";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            if (cbSingle.Checked)
            {
                Grid();
            }
            else
            {
                printLabels();
            }
        }

        private void b6312o100o3_Click(object sender, EventArgs e)
        {
            headings();

            DataRow newRow;

            newRow = dt.NewRow();
            newRow[0] = "6312-0120-01";
            newRow[1] = "NEXVIEW 2 PROFILER MECH STRUCT";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6312-0104-01";
            newRow[1] = "PROFILER HEAD, NEXVIEW 2";
            newRow[2] = "1";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6301-0167-01";
            newRow[1] = "SINGLE MNT DOVETAIL ASSY 38.9";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6450-8509-01";
            newRow[1] = "NX2 PENDANT PRGM";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6300-0239-10 ";
            newRow[1] = "SYSTEM CONTROLLER";
            newRow[2] = "1";
            newRow[3] = "2";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-341";
            newRow[1] = "CABLE ASSY RJ45 X-OVER 10ft.";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-259";
            newRow[1] = "CABLE 9D M to 9D F 6ft.";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-043";
            newRow[1] = "CABLE ASSY DOM 15ft.";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-042";
            newRow[1] = "CABLE ASSY EUROPEAN";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-224";
            newRow[1] = "CABLE ASSY UK";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-070";
            newRow[1] = "CABLE DISPLAYPORT M/M 10'";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1011-000-001";
            newRow[1] = "ADAPTER";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1343-000-026";
            newRow[1] = "FUSE 2A 250V SLO BLO";
            newRow[2] = "2";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-010";
            newRow[1] = "CABLE PWR CRD C13 TO C14 1M";
            newRow[2] = "2";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-008";
            newRow[1] = "CABLE PWR CRD C13 TO C14 3M";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "";
            newRow[1] = "MISCELLANEOUS DOCUMENTS";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1898-400-011";
            newRow[1] = @"TIE CABLE 1"" X 48"" HOOK/LOOP";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "9000-2000-01";
            newRow[1] = "METROPRO X SOFTWARE BUNDLE";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "9000-2001-03";
            newRow[1] = "METROPRO X INSTRUMENT LICENSE";
            newRow[2] = "1";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "9000-2001-09";
            newRow[1] = "METROPRO X ADV ACQ LICENSE";
            newRow[2] = "1";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1332-700-009";
            newRow[1] = @"FITTING REDUCER 1/4"" TO 6mm";
            newRow[2] = "2";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1924-600-097";
            newRow[1] = "TUBING POLYURE BLUE 6MMOD";
            newRow[2] = "6 in";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1924-600-098";
            newRow[1] = "TUBING POLYURE BLACK 6MM OD";
            newRow[2] = "6 in";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1520-500-188";
            newRow[1] = "200x325mm MOTOR XY-STAGE (UNC)";
            newRow[2] = "1";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1520-500-155";
            newRow[1] = "100MM Z-STAGE W/BRAKE";
            newRow[2] = "1";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-489";
            newRow[1] = "USB3 Type A to Type A 3m";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);



            if (cbSingle.Checked)
            {
                Grid();
            }
            else
            {
                printLabels();
            }
        }

        private void b6312o10011_Click(object sender, EventArgs e)
        {
            headings();

            DataRow newRow;

            newRow = dt.NewRow();
            newRow[0] = "6312-0120-01";
            newRow[1] = "NEXVIEW 2 PROFILER MECH STRUCT";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6312-0104-01";
            newRow[1] = "PROFILER HEAD, NEXVIEW 2";
            newRow[2] = "1";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6301-0167-01";
            newRow[1] = "SINGLE MNT DOVETAIL ASSY 38.9";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6450-8509-01";
            newRow[1] = "NX2 PENDANT PRGM";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "6300-0239-10 ";
            newRow[1] = "SYSTEM CONTROLLER";
            newRow[2] = "1";
            newRow[3] = "2";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-341";
            newRow[1] = "CABLE ASSY RJ45 X-OVER 10ft.";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-259";
            newRow[1] = "CABLE 9D M to 9D F 6ft.";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-043";
            newRow[1] = "CABLE ASSY DOM 15ft.";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-042";
            newRow[1] = "CABLE ASSY EUROPEAN";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-224";
            newRow[1] = "CABLE ASSY UK";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-070";
            newRow[1] = "CABLE DISPLAYPORT M/M 10'";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1011-000-001";
            newRow[1] = "ADAPTER";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1343-000-026";
            newRow[1] = "FUSE 2A 250V SLO BLO";
            newRow[2] = "2";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-010";
            newRow[1] = "CABLE PWR CRD C13 TO C14 1M";
            newRow[2] = "2";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-008";
            newRow[1] = "CABLE PWR CRD C13 TO C14 3M";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "";
            newRow[1] = "MISCELLANEOUS DOCUMENTS";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1898-400-011";
            newRow[1] = @"TIE CABLE 1"" X 48"" HOOK/LOOP";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "9000-2000-01";
            newRow[1] = "METROPRO X SOFTWARE BUNDLE";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "9000-2001-03";
            newRow[1] = "METROPRO X INSTRUMENT LICENSE";
            newRow[2] = "1";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "9000-2001-09";
            newRow[1] = "METROPRO X ADV ACQ LICENSE";
            newRow[2] = "1";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1332-700-009";
            newRow[1] = @"FITTING REDUCER 1/4"" TO 6mm";
            newRow[2] = "2";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1924-600-097";
            newRow[1] = "TUBING POLYURE BLUE 6MMOD";
            newRow[2] = "6 in";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1924-600-098";
            newRow[1] = "TUBING POLYURE BLACK 6MM OD";
            newRow[2] = "6 in";
            newRow[3] = "1";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1520-500-187";
            newRow[1] = "MNT OPT XY MTR STAGE 200MM ENC";
            newRow[2] = "1";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1520-500-160";
            newRow[1] = "100MM Z-STAGE W/BRAKE & ENC";
            newRow[2] = "1";
            newRow[3] = "0";
            dt.Rows.Add(newRow);

            newRow = dt.NewRow();
            newRow[0] = "1115-800-489";
            newRow[1] = "USB3 Type A to Type A 3m";
            newRow[2] = "1";
            newRow[3] = "1";
            dt.Rows.Add(newRow);


            if (cbSingle.Checked)
            {
                Grid();
            }
            else
            {
                printLabels();
            }
        }
    }
}
