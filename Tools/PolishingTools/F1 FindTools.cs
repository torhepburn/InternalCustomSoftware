using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PolishingTools
{
    public partial class Form1 : Form
    {
        private string shape;
        private string sn;
        private string min;
        private string max;
        private string radius;
        private string diameter;
        private string db = "server = MIDSQL01; password = views; " +
                            "user = views; database = OPTICs;";
        SqlConnection cnxn;
        SqlDataAdapter da;
        SqlDataAdapter da2;

        public Form1()
        {
            InitializeComponent();
            this.Text = g.ToolType;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(db);
             
            if (g.ToolType == "Carrier")
            {
                da = new SqlDataAdapter
                    ("select o.SerialNumber, " +
                     "c.Dim1, " +
                     "c.Dim2, " +
                     "o.OpeningQuantity, " +
                     "o.OpeningUtilization, " +
                     "c.Comments, " +
                     "c.Shape from CarrierOpeningType c inner join CarrierOpening o " +
                     "on c.openingID = o.openingID order by c.dim1", cnxn);
            }

            if (g.ToolType == "Floater")
            {
                cbR144.Visible = false;
                cbR96.Visible = false;
                cbR48.Visible = false;

                da = new SqlDataAdapter
                    ("select o.serialNumber, " +
                     "t.Shape, " +
                     "o.OpeningQuantity, " +
                     "t.Dim1, " +
                     "t.Dim2, " +
                     "t.Comments, " +
                     "t.shape from FLOpeningType t inner join FLOpening o " +
                     "on t.openingID = o.openingID order by t.dim1, t.dim2", cnxn);
            }

            if (g.ToolType == "TestPlate")
            {
                cbR144.Visible = false;
                cbR96.Visible = false;
                cbR48.Visible = false;
                cbddShape.Visible = false;
                Ldim1.Text = "Radius";
                Ldim2.Text = "Diameter";
                Lshape.Visible = false;

                da = new SqlDataAdapter
                    ("select  " +
                     "Radius, " +
                     "RadTol, " +
                     "CC, " +
                     "CX, " +
                     "Diameter, " +
                     "Figure, " +
                     "DateCalibrated, " +
                     "CalibratedBy " +
                     "from TestPlates " +
                     "order by Radius", cnxn);
            }

            DataTable dt = new DataTable();
            da.Fill(dt);

            DGV.DataSource = dt;
            DGV.Show();

        }

        private void bFind_Click(object sender, EventArgs e)
        {
            if (g.ToolType != "TestPlate")
            {
                if (cbddShape.Text.Length < 1)
                {
                    MessageBox.Show("A Shape must be selected.");
                    return;
                }
                else
                {
                    shape = " shape = '" +
                    cbddShape.Text + "' ";
                }
            }
            
            if (tbDim1.Text.Length < 1)
            {
                tbDim1.Text = "0";
            }

            if (tbDim2.Text.Length < 1)
            {
                tbDim2.Text = "0";
            }

            if (cbR144.Checked == true)
            {
                if (cbR96.Checked == true | cbR48.Checked == true)
                {
                    sn = " and (serialnumber like '144%' ";
                }
                else
                {
                    sn = " and serialnumber like '144%' ";
                }
            }

            if (g.ToolType == "Carrier")
            {
                if (cbR96.Checked == true)
                {
                    if (sn == null & cbR48.Checked == false)
                    {
                        sn = " and serialnumber like '096%' ";
                    }
                    else if (sn == null & cbR48.Checked == true)
                    {
                        sn = " and (serialnumber like '096%' or serialnumber like '048%') ";
                    }
                    else if (sn != null & cbR48.Checked == false)
                    {
                        sn = sn + " or serialnumber like '096%') ";
                    }
                    else if (sn != null & cbR48.Checked == true)
                    {
                        sn = sn + " or serialnumber like '096%' or serialnumber like '048%') ";
                    }
                }

                if (cbR48.Checked == true)
                {
                    if (sn == null)
                    {
                        sn = " and serialnumber like '048%' ";
                    }
                    else if (sn != null & cbR96.Checked == false)
                    {
                        sn = sn + " or serialnumber like '048%') ";
                    }
                }
            }

            if (g.ToolType != "TestPlate")
            {

                int compare = tbDim1.Text.CompareTo(tbDim2.Text);

                if (compare == 0)
                {
                    max = "0";
                    min = "0";
                }
                else if (compare > 0)
                {
                    max = tbDim1.Text;
                    min = tbDim2.Text;
                }
                else
                {
                    max = tbDim2.Text;
                    min = tbDim1.Text;
                }
            }
            else
            {
                radius = tbDim1.Text;
                diameter = tbDim2.Text;
            }
      
            cnxn = new SqlConnection(db);

            if (g.ToolType == "Carrier")
            {
                da2 = new SqlDataAdapter
                    ("select o.serialNumber, " +
                     "c.dim1, " +
                     "c.dim2, " +
                     "o.openingQuantity, " +
                     "o.openingUtilization, " +
                     "c.comments, " +
                     "c.shape from CarrierOpeningType c inner join CarrierOpening o " +
                     "on c.openingID = o.openingID " +
                     "where " + shape + sn + " and dim1 >= " + max +
                     " and dim2 >= " + min + " " +
                     "order by c.dim1", cnxn);
            }

            if (g.ToolType == "Floater")
            {
                da2 = new SqlDataAdapter
                    ("select o.serialNumber, " +
                     "t.Shape, " +
                     "o.OpeningQuantity, " +
                     "t.Dim1, " +
                     "t.Dim2, " +
                     "t.Comments, " +
                     "t.shape from FLOpeningType t inner join FLOpening o " +
                     "on t.openingID = o.openingID " +
                     "where " + shape + " and dim1 >= " + max +
                     " and dim2 >= " + min + " " +
                     "order by t.dim1, t.dim2", cnxn);
            }

            if (g.ToolType == "TestPlate")
            {
                da2 = new SqlDataAdapter
                    ("select  " +
                     "Radius, " +
                     "RadTol, " +
                     "CC, " +
                     "CX, " +
                     "Diameter, " +
                     "Figure, " +
                     "DateCalibrated, " +
                     "CalibratedBy " +
                     "from TestPlates " +
                     "where radius >= " + radius +
                     " and diameter >= " + diameter + " " +
                     "order by Radius", cnxn);
            }
            DataTable dt2 = new DataTable();
            
            
            da2.Fill(dt2);

            DGV.DataSource = dt2;

            shape = null;
            sn = null;
            radius = null;
            diameter = null;
            min = null;
            max = null;

        }

        private void bExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbddShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbddShape.Text == "Circle" | cbddShape.Text == "Square")
            {
                tbDim2.Visible = false;
                Ldim2.Visible = false;
            }
            else
            {
                tbDim2.Visible = true;
                Ldim2.Visible = true;
            }
        }


    }
}
