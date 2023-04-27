using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AddShortage
{
    public partial class AddShortage : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        //private string db = "server = MIDSQL01; password = Read+Write!; " +
        private string db = "server = CT-MID-SQL01; password = Read+Write!; " +
                            "user = readwrite; database = AccessFrontEnds;";
        private string UserName;
        DataTable dt1;

        public AddShortage()
        {
            InitializeComponent();
        }

        private void AddShortage_Load(object sender, EventArgs e)
        {
            System.Security.Principal.WindowsIdentity user;
            user = System.Security.Principal.WindowsIdentity.GetCurrent();

            UserName = user.Name.Substring(8, user.Name.Length - 8);

            cnxn = new SqlConnection(db);

            cnxn.Open();
            SqlDataAdapter da = new SqlDataAdapter(
                "select distinct [group] as prodGroup from shortage_list " +
               " order by [group] ", cnxn);
            //  "order by dbo.sc_sortableversionstring(productline) desc ", cnxn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            cbddGroup.DataSource = dt;
            cbddGroup.DisplayMember = "prodGroup";

            da = new SqlDataAdapter(
                 "select item_code, description from mmx_item_data " +
                 "order by item_code ", cnxn);

            dt1 = new DataTable();
            dt1.Rows.Add();
            dt1.AcceptChanges();
            da.Fill(dt1);

            cbddItemCode.DataSource = dt1;
            cbddItemCode.DisplayMember = "item_code";


            /*
             * 
             * Planner Buyer
             * 
             * */

            da = new SqlDataAdapter(
                 "select distinct e.NAME from pm_2015_a.dbo.view_employees_all_local l " +
                 "inner join AccessFrontEnds.dbo.MMX_EMPLOYEES e on l.name = e.name " +
                 "inner join AccessFrontEnds.dbo.MMX_ITEM_DATA d on d.PLANNER_CODE = e.employee " +
                 "where status = 1 " +
                 "order by name ", cnxn);

            DataTable dt2 = new DataTable();
            dt2.Rows.Add();
            dt2.AcceptChanges();
            da.Fill(dt2);

            cbddPlannerBuyer.DataSource = dt2;
            cbddPlannerBuyer.DisplayMember = "Name";

            cnxn.Close();
        }

        private void Badd_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(db);
            cnxn.Open();

            SqlParameter pComments = new SqlParameter("@comments", SqlDbType.VarChar);
            if (tbComments.Text.Length > 0)
            {
                pComments.Value = tbComments.Text.Trim();
                tbComments.Text = "";
            }
            else
            {
                pComments.Value = DBNull.Value;
            }


            SqlParameter pProductLine = new SqlParameter("@productLine", SqlDbType.VarChar);
            if (cbddProductLine.Text.Length > 0)
            {
                pProductLine.Value = cbddProductLine.Text.Trim();
                cbddProductLine.Text = "";
            }
            else
            {
                pProductLine.Value = DBNull.Value;
            }

            SqlParameter pGroup = new SqlParameter("@pGroup", SqlDbType.VarChar);
            if (cbddGroup.Text.Length > 0)
            {
                pGroup.Value = cbddGroup.Text.Trim();
                cbddGroup.Text = "";
            }
            else
            {
                pGroup.Value = DBNull.Value;
            }

            SqlParameter pQuantity = new SqlParameter("@quantity", SqlDbType.VarChar);
            if (tbQuantityRequired.Text.Length > 0)
            {
                pQuantity.Value = tbQuantityRequired.Text.Trim();
                tbQuantityRequired.Text = "";
            }
            else
            {
                pQuantity.Value = DBNull.Value;
            }

            SqlParameter pItemCode = new SqlParameter("@itemCode", SqlDbType.VarChar);
            if (cbddItemCode.Text.Length > 0)
            {
                pItemCode.Value = cbddItemCode.Text.Trim();
            }
            else
            {
                pItemCode.Value = DBNull.Value;
            }

            SqlParameter pDescription = new SqlParameter("@pDescription", SqlDbType.VarChar);
            if (tbDescription.Text.Length > 0)
            {
                pDescription.Value = tbDescription.Text.Trim();
                tbDescription.Text = "";
                cbddItemCode.Text = "";
            }
            else
            {
                pDescription.Value = DBNull.Value;
            }

            SqlParameter pProject = new SqlParameter("@pProject", SqlDbType.VarChar);

            if (tbProject.Text.Length > 0)
            {
                pProject.Value = tbProject.Text.Trim();
                tbProject.Text = "";
            }
            else
            {
                pProject.Value = DBNull.Value;
            }

            SqlParameter pProjectDescription = new SqlParameter("@projectDescription", SqlDbType.VarChar);

            if (tbProjectDescription.Text.Length > 0)
            {
                pProjectDescription.Value = tbProjectDescription.Text.Trim();
                tbProjectDescription.Text = "";
            }
            else
            {
                pProjectDescription.Value = DBNull.Value;
            }

            SqlParameter pPurchaseOrder = new SqlParameter("@purchaseOrder", SqlDbType.VarChar);
            if (tbPoWo.Text.Length > 0)
            {
                pPurchaseOrder.Value = tbPoWo.Text.Trim();
                tbPoWo.Text = "";
            }
            else
            {
                pPurchaseOrder.Value = DBNull.Value;
            }

            SqlParameter pRequiredDate = new SqlParameter("@requiredDate", SqlDbType.Date);

            if (dtpRequiredDate.Text.Length > 0)
            {
                pRequiredDate.Value = dtpRequiredDate.Text.Trim();
            }
            else
            {
                pRequiredDate.Value = DBNull.Value;
            }

            SqlParameter pPlannerBuyer = new SqlParameter("@plannerBuyer", SqlDbType.VarChar);
            if (cbddPlannerBuyer.Text.Length > 0)
            {
                pPlannerBuyer.Value = cbddPlannerBuyer.Text.Trim();
                cbddPlannerBuyer.Text = "";
            }
            else
            {
                pPlannerBuyer.Value = DBNull.Value;
            }

            SqlParameter pWhoEntered = new SqlParameter("@whoEntered", SqlDbType.VarChar);
            pWhoEntered.Value = UserName;

            SqlParameter pStockOut = new SqlParameter("@stockOut", SqlDbType.VarChar);
            if (cbStockOut.Checked)
            {
                pStockOut.Value = 'Y';
            }
            else
            {
                pStockOut.Value = DBNull.Value;
            }

            SqlParameter pCustomItem = new SqlParameter("@customItem", SqlDbType.VarChar);
            if (cbCustomItem.Checked)
            {
                pCustomItem.Value = 'Y';
                pItemCode.Value = tbCustomItem.Text.Trim();
            }
            else
            {
                pCustomItem.Value = DBNull.Value;
            }


            /*
             * 
             *  use output parameter to get ShortageID for comment tracking
             * 
             * */

            SqlParameter pShortageID = new SqlParameter("@ID", SqlDbType.Int);
            pShortageID.Direction = ParameterDirection.Output;

            SqlCommand cmd = new SqlCommand(
                "Insert into Shortage_List (" +
                " ProductLine " +
                ",[Group] " +
                ",StkOut " +
                ",Qty " +
                ",[Custom Item] " +
                ",ItemCode " +
                ",[Description] " +
                ",[Project] " +
                ",[ProjectDesc] " +
                ",PO " +
                ",[Req Date] " +
                ",Buyer " +
                ",WhoAdded " +
                ",DateAddedToList " +
                ") values (" +
                pProductLine + "," +
                pGroup + "," +
                pStockOut + "," +
                pQuantity + "," +
                pCustomItem + "," +
                pItemCode + "," +
                pDescription + "," +
                pProject + "," +
                pProjectDescription + "," +
                pPurchaseOrder + "," +
                pRequiredDate + "," +
                pPlannerBuyer + "," +
                pWhoEntered + "," +
                "GETDATE() " +
                ") SET @ID = SCOPE_IDENTITY() " , cnxn);

            cmd.Parameters.Add(pProductLine);
            cmd.Parameters.Add(pGroup);
            cmd.Parameters.Add(pStockOut);
            cmd.Parameters.Add(pQuantity);
            cmd.Parameters.Add(pCustomItem);
            cmd.Parameters.Add(pItemCode);
            cmd.Parameters.Add(pDescription);
            cmd.Parameters.Add(pProject);
            cmd.Parameters.Add(pProjectDescription);
            cmd.Parameters.Add(pPurchaseOrder);
            cmd.Parameters.Add(pRequiredDate);
            cmd.Parameters.Add(pPlannerBuyer);
            cmd.Parameters.Add(pWhoEntered);
            cmd.Parameters.Add(pShortageID);

            try
            {
                cmd.ExecuteNonQuery();
                
                int id = (int)cmd.Parameters["@ID"].Value;
                                
                if (id > 0 & pComments.Value.ToString().Length > 0)
                {
                    cmd.Parameters.Clear();

                    cmd = new SqlCommand(
                    "Insert into ShortageListComments (" +
                    " ShortageID " +
                    ",Comment " +
                    ",EnteredBy " +
                    ",EnteredOn " +
                    ") values (" +
                    id + "," +
                    pComments + "," +
                    pWhoEntered + "," +
                    "GETDATE() " +
                    ")", cnxn);

                    cmd.Parameters.Add(pComments);
                    cmd.Parameters.Add(pWhoEntered);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
                cmd.Parameters.Clear();
            }



            cbStockOut.Checked = false;
            cbCustomItem.Checked = false;

        }

        private void cbCustomItem_CheckedChanged(object sender, EventArgs e)
        {
            tbCustomItem.Visible = true;
            cbddItemCode.Visible = false;
        }

        private void cbddItemCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            int n = cbddItemCode.SelectedIndex;
            tbDescription.Text = dt1.Rows[n].ItemArray[1].ToString();
        }
    }
}
