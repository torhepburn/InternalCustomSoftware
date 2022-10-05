using System;
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

namespace Test2
{
    public partial class A1_SelectList : Form
    {
        SqlConnection cnxn;
        SqlDataReader dr;
        SqlDataAdapter da;
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

        private string printer;

        public A1_SelectList()
        {
            InitializeComponent();
        }

        private void A1_SelectList_Load(object sender, EventArgs e)
        {
            this.Text = "Label Packing List Editor  v" + Application.ProductVersion;

            cnxn = new SqlConnection(g.db);

            SelectionList();
        }

        private void SelectionList()
        {
            da = new SqlDataAdapter(
                "Select distinct documentnumber [Packing List], pldescription [Description], Revision " +
                "from labels_packinglists order by documentnumber, revision ", cnxn);
            System.Data.DataTable table = new System.Data.DataTable();
            da.Fill(table);
            DGV.DataSource = table;
            DGV.Show();

            DGV.Columns[0].Width = 150;
            DGV.Columns[1].Width = 320;
            DGV.Columns[2].Width = 70;
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
                g.document = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                g.plDescription = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                g.revision = cell.EditedFormattedValue.ToString().Trim();
            }

            if (rbCopy.Checked == true)
            {
                if (tbNewRev.Text.Length == 0)
                {
                    MessageBox.Show("Must enter a revision letter.");
                    tbNewRev.Focus();
                    return;
                }

                g.RevToEdit = tbNewRev.Text.Trim().ToUpper();


                if (g.RevToEdit == g.revision.Trim().ToUpper())
                {
                    MessageBox.Show("Must enter a revision letter greater than the current revision.");
                    tbNewRev.Clear();
                    tbNewRev.Focus();
                    return;
                }

                SqlCommand cmd = new SqlCommand("SELECT revision " +
                                                "FROM labels_packinglists " +
                                                "where documentnumber = '" + g.document + "' " +
                                                "and revision = '" + g.RevToEdit + "'", cnxn);

                try
                {
                    cnxn.Open();
                    object o = cmd.ExecuteScalar();

                    if (o != null)
                    {
                        MessageBox.Show("This revision already exists.");
                        tbNewRev.Clear();
                        tbNewRev.Focus();
                        return;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("122  " + ex.ToString());
                    tbNewRev.Clear();
                    tbNewRev.Focus();
                    return;
                }
                finally
                {
                    cnxn.Close();
                }

                cmd = new SqlCommand("INSERT INTO Labels_PackingLists " +
                                    "([documentnumber] " +
                                    ",[revision] " +
                                    ",[item_code] " +
                                    ",[description] " +
                                    ",[quantity] " +
                                    ",[boxes] " +
                                    ",[installon] " +
                                    ",[kitwith] " +
                                    ",[pldescription]) " +
                                    "SELECT " +
                                    "[documentnumber] " +
                                    ",'" + g.RevToEdit + "' " +
                                    ",[item_code] " +
                                    ",[description] " +
                                    ",[quantity] " +
                                    ",[boxes] " +
                                    ",[installon] " +
                                    ",[kitwith] " +
                                    ",[pldescription] " +
                                    "FROM Labels_PackingLists " +
                                    "WHERE documentnumber = '" + g.document + "' " +
                                    "AND revision = '" + g.revision + "'", cnxn);

                try
                {
                    cnxn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("163  " + ex.ToString());
                    return;
                }
                finally
                {
                    cnxn.Close();
                }

                SelectionList();

                EditData d = new EditData();
                d.ShowDialog();
                
            }

            if (rbCopyNew.Checked == true)
            {
                if (tbNewRev.Text.Length == 0)
                {
                    MessageBox.Show("Must enter a revision letter.");
                    tbNewRev.Focus();
                    return;
                }

                if (tbNewNumber.Text.Length == 0)
                {
                    MessageBox.Show("Must enter a document number.");
                    tbNewNumber.Focus();
                    return;
                }

                g.RevToEdit = tbNewRev.Text.Trim().ToUpper();
                g.NewDocumentNumber = tbNewNumber.Text.Trim().ToUpper();

                if (g.RevToEdit == g.revision.Trim().ToUpper())
                {
                    MessageBox.Show("Must enter a revision letter greater than the current revision.");
                    tbNewRev.Clear();
                    tbNewRev.Focus();
                    return;
                }

                SqlCommand cmd = new SqlCommand("SELECT revision " +
                                                "FROM labels_packinglists " +
                                                "where documentnumber = '" + g.NewDocumentNumber + "' " +
                                                "and revision = '" + g.RevToEdit + "'", cnxn);

                try
                {
                    cnxn.Open();
                    object o = cmd.ExecuteScalar();

                    if (o != null)
                    {
                        MessageBox.Show("This revision already exists.");
                        tbNewRev.Clear();
                        tbNewRev.Focus();
                        return;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("122  " + ex.ToString());
                    tbNewRev.Clear();
                    tbNewRev.Focus();
                    return;
                }
                finally
                {
                    cnxn.Close();
                }

                cmd = new SqlCommand("INSERT INTO Labels_PackingLists " +
                                    "([documentnumber] " +
                                    ",[revision] " +
                                    ",[item_code] " +
                                    ",[description] " +
                                    ",[quantity] " +
                                    ",[boxes] " +
                                    ",[installon] " +
                                    ",[kitwith] " +
                                    ",[pldescription]) " +
                                    "SELECT " +
                                    "'" + g.NewDocumentNumber + "'" +
                                    ",'" + g.RevToEdit + "' " +
                                    ",[item_code] " +
                                    ",[description] " +
                                    ",[quantity] " +
                                    ",[boxes] " +
                                    ",[installon] " +
                                    ",[kitwith] " +
                                    ",[pldescription] " +
                                    "FROM Labels_PackingLists " +
                                    "WHERE documentnumber = '" + g.document + "' " +
                                    "AND revision = '" + g.revision + "'", cnxn);

                try
                {
                    cnxn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("163  " + ex.ToString());
                    return;
                }
                finally
                {
                    cnxn.Close();
                }

                SelectionList();

                g.document = g.NewDocumentNumber;

                EditData d = new EditData();
                d.ShowDialog();

            }

            if (rbEdit.Checked)
            {
                g.RevToEdit = g.revision;

                EditData d = new EditData();
                d.ShowDialog();
            }

            if (rbEditByLine.Checked)
            {
                g.RevToEdit = g.revision;

                SelectedPackingList p = new SelectedPackingList();
                p.ShowDialog();
            }

            if (rbDelete.Checked == true)
            {
                

                DialogResult dialog = MessageBox.Show("Are you sure you want to delete this packing list ?","Delete ?" , MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand(
                        "DELETE  " +
                        "FROM labels_packinglists " +
                        "where documentnumber = '" + g.document + "' " +
                        "and revision = '" + g.revision + "'", cnxn);

                    try
                    {
                        cnxn.Open();
                        cmd.ExecuteScalar();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("253  " + ex.ToString());
                        return;
                    }
                    finally
                    {
                        cnxn.Close();
                    }
                }
                else if (dialog == DialogResult.No)
                {
                    
                }

                SelectionList();
            }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter
                ("Select distinct documentnumber [Packing List], pldescription [Description], Revision " +
                "from labels_packinglists WHERE " +
            "Documentnumber LIKE '%" + tbSearchPartNumber.Text + "%' " +
                   " order by documentnumber, revision", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;
        }

        private void rbCopy_CheckedChanged(object sender, EventArgs e)
        {
            LNewRev.Visible = true;
            tbNewRev.Visible = true;
            tbNewRev.Focus();
            LNewNumber.Visible = false;
            tbNewNumber.Visible = false;
        }

        private void rbCopyNew_CheckedChanged(object sender, EventArgs e)
        {
            LNewRev.Visible = true;
            tbNewRev.Visible = true;
            tbNewRev.Focus();
            LNewNumber.Visible = true;
            tbNewNumber.Visible = true;
        }

        private void rbDelete_CheckedChanged(object sender, EventArgs e)
        {
            LNewRev.Visible = false;
            tbNewRev.Visible = false;
            LNewNumber.Visible = false;
            tbNewNumber.Visible = false;
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bADDfromWord_Click(object sender, EventArgs e)
        {
            GetWordDocumemt d = new GetWordDocumemt();
            d.ShowDialog();
        }
    }

    public static class g
    {
        public static string document;
        public static string revision;
        public static string plDescription;
        public static string NewDocumentNumber;
        public static string RevToEdit;
        public static bool alreadyUsed;
        public static string task;
        public static string itemCode;
        public static string itemDescription;
        public static string iQuantity;
        public static string numberofBoxes;
        public static string installOn;
        public static string kitWith;
        public static string UID;
        //public static string dbNAV = "server = pa-hor-as408.ametek.com; password = 2018#ameteK; " +
        //                   "user = navdb_read; database = ZYGO-NAV-PROD;";
        //public static string NAVprefix = "ZYGO$";
        public static string db = "server = CT-MID-SQL11; password = Read+Write!; " +
                                  "user = readwrite; database = AccessFrontEnds;";
    }
}
