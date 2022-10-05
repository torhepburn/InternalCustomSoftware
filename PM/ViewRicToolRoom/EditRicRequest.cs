using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ViewRicToolRoom
{
    public partial class EditRequest : Form
    {
        SqlConnection cnxn;
        SqlConnection cNAV;
        SqlCommand cmd;
        DataTable dtCustomer;
        DataTable dtProject;
        DataTable dtProjectChargeNumber;
        
        public EditRequest()
        {
            InitializeComponent();
        }

        private void EditRequest_Load(object sender, EventArgs e)
        {
            LID.Text = "Tool Room Request ID #  " + g.ID;

            dtpDateNeeded.Checked = false;
            dtpDateNeeded.ShowCheckBox = true;

            cNAV = new SqlConnection(g.dbNAV);
            SqlDataReader dr;
            
            /* Customer dropdown data */

            try
            {
                cmd = new SqlCommand("SELECT ' ' AS Name UNION ALL select DISTINCT Name from ZYGO$Customer  where len(Name) > 0 order by Name", cNAV);
                dtCustomer = new DataTable();
                cNAV.Open();
                dr = cmd.ExecuteReader();
                dtCustomer.Load(dr);
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                cNAV.Close();
            }

            /* project dropdown data */

            try
            {
                cmd = new SqlCommand("SELECT ' ' AS Name UNION select COALESCE(Description,'') Name from ZYGO$Job where [Global Dimension 2 Code] in ('EUV','CRYSTALLINE OPTICS','GLASS OPTICS','MACHINED STRUCTURES') ORDER BY Name", cNAV);
                dtProject = new DataTable();
                cNAV.Open();
                dr = cmd.ExecuteReader();
                dtProject.Load(dr);
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                cNAV.Close();
            }

            /* project charge number dropdown data */

            try
            {
                cmd = new SqlCommand("SELECT ' ' AS Number UNION select COALESCE(No_,'') Number  from ZYGO$Job where [Global Dimension 2 Code] in ('EUV','CRYSTALLINE OPTICS','GLASS OPTICS','MACHINED STRUCTURES') ORDER BY Number", cNAV);
                dtProjectChargeNumber = new DataTable();
                cNAV.Open();
                dr = cmd.ExecuteReader();
                dtProjectChargeNumber.Load(dr);
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                cNAV.Close();
            }

            cbddCustomer.DataSource = dtCustomer;
            cbddCustomer.DisplayMember = "Name";

            cbddProject.DataSource = dtProject;
            cbddProject.DisplayMember = "Name";

            cbddProjectChargeNumber.DataSource = dtProjectChargeNumber;
            cbddProjectChargeNumber.DisplayMember = "Number";

            

            cnxn = new SqlConnection(g.db);

            cmd = new SqlCommand(
                "Select " +
                "Customer" +
                ",Project" +
                ",Project_Charge_Number " +
                ",priority " +
                ",request_need_date " +
                ",ExistingTool4Modification" +
                ",MachineNumber " +
                ",Quantity " +
                ",request_text " +
                ",AdditionalInformation " +
                ",CASE Anodized " +
                "  WHEN 1 THEN 'TRUE' " +
                "  ELSE 'FALSE' " +    
                "End Anodized " +
                ",FocalSurface " +
                ",OpticDrawing_path " +
                "from RICHMOND_tool_requests where " +
                "id = " + g.ID + " ", cnxn);

            try
            {
                cnxn.Open();
                dr = cmd.ExecuteReader();

                DataTable table = new DataTable();
                table.Load(dr);
                {
                    cbddCustomer.Text = table.Rows[0][0].ToString();
                    cbddProject.Text = table.Rows[0][1].ToString();
                    cbddProjectChargeNumber.Text = table.Rows[0][2].ToString();
                    cbddPriority.Text = table.Rows[0][3].ToString();
                    dtpDateNeeded.Text = table.Rows[0][4].ToString();
                    tbToolToModify.Text = table.Rows[0][5].ToString();
                    tbMachineNumber.Text = table.Rows[0][6].ToString();
                    tbQuantity.Text = table.Rows[0][7].ToString();
                    tbToolRequirements.Text = table.Rows[0][8].ToString();
                    tbAdditionalInformation.Text = table.Rows[0][9].ToString();
                    if (table.Rows[0][10].ToString() == "TRUE")
                    {
                        cbAnodized.Checked = true;
                    }
                    else
                    {
                        cbAnodized.Checked = false;
                    }
                    
                    tbFocalSurface.Text = table.Rows[0][11].ToString();
                    tbOpticDrawing_Path.Text = table.Rows[0][12].ToString();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }
        }

        private void Benter_Click(object sender, EventArgs e)
        {   
            SqlParameter pCustomer = new SqlParameter("@Customer", SqlDbType.VarChar, 50);
            pCustomer.Value = cbddCustomer.Text.Trim();

            SqlParameter pProject = new SqlParameter("@Project", SqlDbType.VarChar, 20);
            pProject.Value = cbddProject.Text.Trim(); ;

            SqlParameter pProjectChargeNumber = new SqlParameter("@ProjectChargeNumber", SqlDbType.VarChar, 50);
            pProjectChargeNumber.Value = cbddProjectChargeNumber.Text.Trim();

            SqlParameter pPriority = new SqlParameter("@priority", SqlDbType.VarChar, 25);
            pPriority.Value = cbddPriority.Text.Trim();;

            SqlParameter pExistingTool = new SqlParameter("@ExistingTool", SqlDbType.VarChar, 50);
            pExistingTool.Value = tbToolToModify.Text.Trim();

            SqlParameter pMachineNumber = new SqlParameter("@MachineNumber", SqlDbType.VarChar, 50);
            pMachineNumber.Value = tbMachineNumber.Text.Trim();

            SqlParameter pQuantity = new SqlParameter("@quantity", SqlDbType.Int);
            pQuantity.Value = tbQuantity.Text.Trim();

            SqlParameter pRequest_Text = new SqlParameter("@request_text", SqlDbType.VarChar, 4000);
            pRequest_Text.Value = tbToolRequirements.Text.Trim();

            SqlParameter pAdditionalInformation = new SqlParameter("@AdditionalInformation", SqlDbType.VarChar, 1000);
            pAdditionalInformation.Value = tbAdditionalInformation.Text.Trim();

            SqlParameter pAnodized = new SqlParameter("@Anodized", SqlDbType.Bit);
            if (cbAnodized.Checked == true)
            {
                pAnodized.Value = 1;
            }
            else
            {
                pAnodized.Value = 0;
            }

            SqlParameter pFocalSurface = new SqlParameter("@FocalSurface", SqlDbType.VarChar, 50);
            pFocalSurface.Value = tbFocalSurface.Text.Trim();

            SqlParameter pOpticDrawingPath = new SqlParameter("@OpticDrawingPath", SqlDbType.VarChar, 200);
            pOpticDrawingPath.Value = tbOpticDrawing_Path.Text.Trim();


            SqlParameter pRequiredDate = new SqlParameter("@requiredDate", SqlDbType.Date);

            if (dtpDateNeeded.Checked)
            {
                pRequiredDate.Value = dtpDateNeeded.Text.Trim();
            }
            else
            {
                pRequiredDate.Value = "01-01-1900";
            }


            cnxn.Open();

            SqlCommand cmd = new SqlCommand("Update Richmond_Tool_Requests SET " +
                    " Customer = " + pCustomer +
                    ",project = " + pProject +
                    ",project_charge_number = " + pProjectChargeNumber +
                    ",priority = " + pPriority +
                    ",request_need_date = " + pRequiredDate +
                    ",ExistingTool4Modification = " + pExistingTool +
                    ",MachineNumber = " + pMachineNumber +
                    ",Quantity = " + pQuantity +
                    ",request_text = " + pRequest_Text +
                    ",AdditionalInformation = " + pAdditionalInformation +
                    ",Anodized = " + pAnodized +
                    ",FocalSurface = " + pFocalSurface +
                    ",OpticDrawing_Path = " + pOpticDrawingPath +
                    " WHERE ID = " + g.ID, cnxn);

            cmd.Parameters.Add(pCustomer);
            cmd.Parameters.Add(pProject);
            cmd.Parameters.Add(pProjectChargeNumber);
            cmd.Parameters.Add(pPriority);
            cmd.Parameters.Add(pExistingTool);
            cmd.Parameters.Add(pMachineNumber);
            cmd.Parameters.Add(pQuantity);
            cmd.Parameters.Add(pRequest_Text);
            cmd.Parameters.Add(pAdditionalInformation);
            cmd.Parameters.Add(pAnodized);
            cmd.Parameters.Add(pFocalSurface);
            cmd.Parameters.Add(pOpticDrawingPath);
            cmd.Parameters.Add(pRequiredDate);


            try
            {
                int rowsReturned = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            cmd.Dispose();

           

            

            this.Close();
        }

        private void Bexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
