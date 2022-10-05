using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using bpac;

namespace CalibrationManager
{
    public partial class f51_Equipment : Form
    {
        SqlDataAdapter da;
        BindingSource bs = new BindingSource();
        SqlConnection cnxn;
        
        public f51_Equipment()
        {
            InitializeComponent();
        }

        private void f51_Equipment_Load(object sender, EventArgs e)
        {
            if (g.item == "Cert")
            {
                this.Text = "Select item with Cert";
            }
            else if (g.item == "Risk")
            {
                this.Text = "Select item with Risk Assessment Documents";
            }
            else if (g.item == "Docs")
            {
                this.Text = "Select item with Calibration Documents";
            }
            else if (g.item == "Repair")
            {
                this.Text = "Select item with Repair Documents";
            }
            else
            {
                this.Text = g.task + " " + g.item;
            }
            
            
            cnxn = new SqlConnection(g.db);

            if (g.item == "Reports")
            {
                da = new SqlDataAdapter
                ("Select e.* from equipment e" +
                 " inner join itemlocation l on e.id = l.il_item " +
                 " where l.il_location like '" + g.facility + "%' " +
                 " and status != 'ARCHIVE' " +
                 " order by id asc", cnxn);
            }
            else
            {
                da = new SqlDataAdapter
                ("Select ID, [Description] from equipment e" +
                 " inner join itemlocation l on e.id = l.il_item " +
                 " where l.il_location like '" + g.facility + "%' " +
                 " and status != 'ARCHIVE' " +
                 " order by id asc", cnxn);
            }
            DataTable table = new DataTable();
            da.Fill(table);
            bs.DataSource = table;
            DGV.DataSource = bs;
            if (g.item == "Reports")
            {
                DGV.Columns[0].Width = 120;
                DGV.Columns[1].Width = 250;
                DGV.Columns[2].Width = 100;
                DGV.Columns[3].Width = 150;
                DGV.Columns[4].Width = 150;
                DGV.Columns[5].Width = 140;
                DGV.Columns[6].Width = 60;
                DGV.Columns[7].Width = 100;
                DGV.Columns[8].Width = 100;
                DGV.Columns[9].Width = 150;
                DGV.Columns[10].Width = 140;
                DGV.Columns[11].Width = 100;
                DGV.Columns[12].Width = 100;
                DGV.Columns[13].Width = 140;
                DGV.Columns[14].Width = 100;
                DGV.Columns[15].Width = 60;
                DGV.Columns[16].Width = 60;
                DGV.Columns[17].Width = 60;
                DGV.Columns[18].Width = 150;
                DGV.Columns[19].Width = 200;
                DGV.Columns[20].Width = 60;
                DGV.Columns[21].Width = 60;
                DGV.Columns[22].Width = 40;
                DGV.Columns[23].Width = 40;
                DGV.Columns[24].Width = 40;
            }
            else
            {
                DGV.Columns[0].Width = 120;
                DGV.Columns[1].Width = 250;
            }
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex <2)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.iID = cell.EditedFormattedValue.ToString().Trim();
                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                g.iDescription = cell.EditedFormattedValue.ToString().Trim();

                selectionChoice();
            }
        }
        
        private void bItem_Click(object sender, EventArgs e)
        {
            g.iID = tbSearchEquipment.Text.ToString().Trim().ToUpper();
            tbSearchEquipment.Text = "";
            SqlCommand cmd = new SqlCommand
                ("Select id from equipment e " +
                " inner join itemlocation l on e.id = l.il_item " +
                "where e.id = '" + g.iID + "'" +
                 " and l.il_location like '" + g.facility + "%'" +
                 "and Status != 'Archive' ");
            cnxn = new SqlConnection(g.db);
            cmd.Connection = cnxn;
            cnxn.Open();
            object o = cmd.ExecuteScalar();

            if (o == null)
            {
                MessageBox.Show("This item does not exist.");
                tbSearchEquipment.Focus();
            }
            else
            {
                //looks like I'm getting the description if the item 
                //exists, but I don't remember why I take two steps
                cnxn = new SqlConnection(g.db);
                cmd = new SqlCommand
                ("Select [description] from equipment e" +
                " inner join itemlocation l on e.id = l.il_item " +
                "where id = '" + g.iID + "'" +
                 "and l.il_location like '" + g.facility + "%'" +
                 "and Status != 'Archive'", cnxn);
                cnxn.Open();
                object a = cmd.ExecuteScalar();
                g.iDescription = a.ToString().Trim();

                selectionChoice();
            }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter
                ("Select ID, [Description] from equipment e" +
                 " inner join itemlocation l on e.id = l.il_item " +
                 " where l.il_location like '" + g.facility + "%' " +
                 " and (e.id like '%" + tbSearchEquipment.Text + "%' " +
                 "or e.[description] like '%" + tbSearchEquipment.Text + "%' )" +
                 " and status != 'Archive' " +
                 " order by id asc", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            bs.DataSource = table;
            DGV.DataSource = bs;
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void selectionChoice()
        {
            if (g.item == "Cert" | g.item == "Risk" | g.item == "Docs" | g.item == "Repair")
            {
                f61_Review_Data f6 = new f61_Review_Data();
                f6.Show();
            }
            
            if (g.item == "Data")
            {
                if (g.task == "Add")
                {
                    f60_Calibration_Data f60 = new f60_Calibration_Data();
                    f60.Show();
                }
                if (g.task == "Review" | g.task == "Edit" | g.task == "View")
                {
                    f61_Review_Data f61 = new f61_Review_Data();
                    f61.Show();
                }
            }
            
            if (g.item == "Equipment")
            {
                if (g.task == "Edit")
                {
                    f30_Edit_Items f3 = new f30_Edit_Items();
                    f3.Show();
                }

                if (g.task == "Delete")
                {
                    string message = "Confirm Item Deletion.";
                    string caption = "";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }

                    cnxn = new SqlConnection(g.db);

                    SqlCommand cmd = new SqlCommand
                        ("delete from equipment " +
                        "where id = '" + g.iID + "'", cnxn);

                    cnxn.Open();
                    int rowsReturned = cmd.ExecuteNonQuery();
                    cnxn.Close();

                    cnxn = new SqlConnection(g.db);

                    cmd = new SqlCommand
                        ("delete from itemuser " +
                        "where i_item = '" + g.iID + "'", cnxn);

                    cnxn.Open();
                    rowsReturned = cmd.ExecuteNonQuery();
                    cnxn.Close();

                    cnxn = new SqlConnection(g.db);

                    cmd = new SqlCommand
                        ("delete from itemlocation " +
                        "where il_item = '" + g.iID + "'", cnxn);

                    cnxn.Open();
                    rowsReturned = cmd.ExecuteNonQuery();
                    cnxn.Close();

                    cnxn = new SqlConnection(g.db);

                    cmd = new SqlCommand
                        ("delete from calibrationdata " +
                        "where item = '" + g.iID + "'", cnxn);

                    cnxn.Open();
                    rowsReturned = cmd.ExecuteNonQuery();
                    cnxn.Close();
                    this.Close();
                }
            }

            if (g.item == "Reports")
            {
                f52_Equipment_Report f2 = new f52_Equipment_Report();
                f2.Show();
            }

            if (g.item == "Serial Number Label")
            {
                bpac.Document BroDoc = new Document();
                BroDoc.Open("c:\\calibration\\SN.lbl");
                int index = BroDoc.GetTextIndex("SN");
                BroDoc.SetText(index, g.iID);
                BroDoc.Export(ExportType.bexBmp, "c:\\calibration\\SNtest.bmp",0);
                BroDoc.DoPrint(0, "0");
                BroDoc.Close();
            }
            
            if (g.item == "Bar Code Label")
            {
                //cnxn = new SqlConnection(g.db);
                //SqlCommand cmd = new SqlCommand
                //    ("SELECT COALESCE(yesCertPDF, 'N') FROM CalibrationData WHERE " +
                //     "CurrentHistory = 'C' and item = '" + g.iID + "'", cnxn);
                
                //cnxn.Open();
                //try
                //{
                //    object o = cmd.ExecuteScalar();

                //    if (o.ToString() == "Y")
                //    {
                        bpac.Document BroDoc = new Document();
                        BroDoc.Open("c:\\calibration\\Barcode.lbl");
                        int index = BroDoc.GetTextIndex("Barcode");
                        BroDoc.SetBarcodeData(0, g.iID);
                        BroDoc.SetText(index, g.iID);
                        BroDoc.DoPrint(0, "0");
                        BroDoc.Close();
                //    }
                //}
                //catch (SqlException ex)
                //{
                //    MessageBox.Show(ex.ToString());
                //}
                //finally
                //{
                //    cnxn.Close();
                //}
            }
        }
    }
}