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
    public partial class F45_Select_Sheet : Form
    {
        SqlConnection cnxn;

        public F45_Select_Sheet()
        {
            InitializeComponent();
        }

        private void F45_Select_Sheet_Load(object sender, EventArgs e)
        {
            //            if (g.item == "Cert")
            //{
            //    this.Text = "Select item with Cert";
            //}
            //else if (g.item == "Risk")
            //{
            //    this.Text = "Select item with Risk Assessment Documents";
            //}
            //else if (g.item == "Docs")
            //{
            //    this.Text = "Select item with Calibration Documents";
            //}
            //else if (g.item == "Repair")
            //{
            //    this.Text = "Select item with Repair Documents";
            //}
            //else
            //{
            //    this.Text = g.task + " " + g.item;
            //}


            cnxn = new SqlConnection(g.db);

            //if (g.item == "Reports")
            //{
            //    da = new SqlDataAdapter
            //    ("Select e.* from equipment e" +
            //     " inner join itemlocation l on e.id = l.il_item " +
            //     " where l.il_location like '" + g.facility + "%' " +
            //     " and status != 'ARCHIVE' " +
            //     " order by id asc", cnxn);
            //}
            //else
            //{
            SqlDataAdapter da = new SqlDataAdapter
                ("Select distinct machine, part_name from partsetup" +
                 " order by machine, part_name", cnxn);
            //}
            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;

            DGV.Columns[0].Width = 80;
            DGV.Columns[1].Width = 500;
            //    DGV.Columns[2].Width = 100;
            //    DGV.Columns[3].Width = 150;
            //    DGV.Columns[4].Width = 150;
            //    DGV.Columns[5].Width = 140;
            //    DGV.Columns[6].Width = 60;
            //    DGV.Columns[7].Width = 100;
            //    DGV.Columns[8].Width = 100;
            //    DGV.Columns[9].Width = 150;
            //    DGV.Columns[10].Width = 140;
            //    DGV.Columns[11].Width = 100;
            //    DGV.Columns[12].Width = 100;
            //    DGV.Columns[13].Width = 140;
            //    DGV.Columns[14].Width = 100;
            //    DGV.Columns[15].Width = 60;
            //    DGV.Columns[16].Width = 60;
            //    DGV.Columns[17].Width = 60;
            //    DGV.Columns[18].Width = 150;
            //    DGV.Columns[19].Width = 200;
            //    DGV.Columns[20].Width = 60;
            //    DGV.Columns[21].Width = 60;
            //    DGV.Columns[22].Width = 40;
            //    DGV.Columns[23].Width = 40;
            //    DGV.Columns[24].Width = 40;
            //}
            //else
            //{
            //    DGV.Columns[0].Width = 120;
            //    DGV.Columns[1].Width = 250;
            // }
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 2)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.SSmachine = cell.EditedFormattedValue.ToString().Trim();
                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                g.SSpartname = cell.EditedFormattedValue.ToString().Trim();

                selectionChoice();
            }
        }

        
        private void bSearch_Click(object sender, EventArgs e)
        {
            //cnxn = new SqlConnection(g.db);
            //da = new SqlDataAdapter
            //    ("Select ID, [Description] from equipment e" +
            //     " inner join itemlocation l on e.id = l.il_item " +
            //     " where l.il_location like '" + g.facility + "%' " +
            //     " and (e.id like '%" + tbSearchEquipment.Text + "%' " +
            //     "or e.[description] like '%" + tbSearchEquipment.Text + "%' )" +
            //     " and status != 'Archive' " +
            //     " order by id asc", cnxn);
            //DataTable table = new DataTable();
            //da.Fill(table);
            //bs.DataSource = table;
            //DGV.DataSource = bs;
        }

        private void selectionChoice()
        {
        //    if (g.item == "Cert" | g.item == "Risk" | g.item == "Docs" | g.item == "Repair")
        //    {
        //        f61_Review_Data f6 = new f61_Review_Data();
        //        f6.Show();
        //    }

            if (g.task == "view")
            {
                
            }

        //    if (g.item == "Equipment")
        //    {
        //        if (g.task == "Edit")
        //        {
        //            f30_Edit_Items f3 = new f30_Edit_Items();
        //            f3.Show();
        //        }

        //        if (g.task == "Delete")
        //        {
        //            string message = "Confirm Item Deletion.";
        //            string caption = "";
        //            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
        //            DialogResult result;
        //            result = MessageBox.Show(message, caption, buttons);

        //            if (result == System.Windows.Forms.DialogResult.No)
        //            {
        //                return;
        //            }

        //            cnxn = new SqlConnection(g.db);

        //            SqlCommand cmd = new SqlCommand
        //                ("delete from equipment " +
        //                "where id = '" + g.iID + "'", cnxn);

        //            cnxn.Open();
        //            int rowsReturned = cmd.ExecuteNonQuery();
        //            cnxn.Close();

        //            cnxn = new SqlConnection(g.db);

        //            cmd = new SqlCommand
        //                ("delete from itemuser " +
        //                "where i_item = '" + g.iID + "'", cnxn);

        //            cnxn.Open();
        //            rowsReturned = cmd.ExecuteNonQuery();
        //            cnxn.Close();

        //            cnxn = new SqlConnection(g.db);

        //            cmd = new SqlCommand
        //                ("delete from itemlocation " +
        //                "where il_item = '" + g.iID + "'", cnxn);

        //            cnxn.Open();
        //            rowsReturned = cmd.ExecuteNonQuery();
        //            cnxn.Close();

        //            cnxn = new SqlConnection(g.db);

        //            cmd = new SqlCommand
        //                ("delete from calibrationdata " +
        //                "where item = '" + g.iID + "'", cnxn);

        //            cnxn.Open();
        //            rowsReturned = cmd.ExecuteNonQuery();
        //            cnxn.Close();
        //            this.Close();
        //        }
        //    }

        //    if (g.item == "Reports")
        //    {
        //        f52_Equipment_Report f2 = new f52_Equipment_Report();
        //        f2.Show();
        //    }

        //    if (g.item == "Serial Number Label")
        //    {
        //        bpac.Document BroDoc = new Document();
        //        BroDoc.Open("c:\\calibration\\SN.lbl");
        //        int index = BroDoc.GetTextIndex("SN");
        //        BroDoc.SetText(index, g.iID);
        //        BroDoc.Export(ExportType.bexBmp, "c:\\calibration\\SNtest.bmp",0);
        //        BroDoc.DoPrint(0, "0");
        //        BroDoc.Close();
        //    }

        //    if (g.item == "Bar Code Label")
        //    {
        //        bpac.Document BroDoc = new Document();
        //        BroDoc.Open("c:\\calibration\\Barcode.lbl");
        //        int index = BroDoc.GetTextIndex("Barcode");
        //        BroDoc.SetBarcodeData(0, g.iID);
        //        BroDoc.SetText(index, g.iID);
        //        BroDoc.DoPrint(0, "0");
        //        BroDoc.Close();
        //    }
        }
    }
}
