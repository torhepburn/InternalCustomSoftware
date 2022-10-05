using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace CalibrationView
{
    public partial class _Default : System.Web.UI.Page
    {
        private string statusFilter;
        private string locationFilter;
        private string roomFilter;
        private string typeFilter;
        private string manufacturerFilter;
        private string userFilter;
        private string ownerFilter;
        private string ownersupFilter;
        private string calsourceFilter;
        private string modelFilter;
        private string where;
        private string calendarFilter;
        private string idFilter;
        private string descriptionFilter;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //BindFiles(); 
        }
    
        protected void cbStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStatus.Checked == true)
            {
                DDLstatus.Visible = true;
            }
            else
            {
                DDLstatus.Visible = false;
            }
        }

        protected void cbLocation_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLocation.Checked == true)
            {
                DDLlocation.Visible = true;
            }
            else
            {
                DDLlocation.Visible = false;
            }
        }

        protected void cbRoom_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRoom.Checked == true)
            {
                DDLroom.Visible = true;
            }
            else
            {
                DDLroom.Visible = false;
            }
        }

        protected void cbType_CheckedChanged(object sender, EventArgs e)
        {
            if (cbType.Checked == true)
            {
                DDLtype.Visible = true;
            }
            else
            {
                DDLtype.Visible = false;
            }
        }

        protected void cbManufacturer_CheckedChanged(object sender, EventArgs e)
        {
            if (cbManufacturer.Checked == true)
            {
                DDLmanufacturer.Visible = true;
            }
            else
            {
                DDLmanufacturer.Visible = false;
            }
        }

        protected void cbUser_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUser.Checked == true)
            {
                DDLuser.Visible = true;
            }
            else
            {
                DDLuser.Visible = false;
            }
        }

        protected void cbOwner_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOwner.Checked == true)
            {
                DDLowner.Visible = true;
            }
            else
            {
                DDLowner.Visible = false;
            }
        }

        protected void cbOwnerSupervisor_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOwnerSupervisor.Checked == true)
            {
                DDLownsup.Visible = true;
            }
            else
            {
                DDLownsup.Visible = false;
            }
        }

        protected void cbCalsource_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCalsource.Checked == true)
            {
                DDLcalsource.Visible = true;
            }
            else
            {
                DDLcalsource.Visible = false;
            }
        }

        protected void cbModel_CheckedChanged(object sender, EventArgs e)
        {
            if (cbModel.Checked == true)
            {
                DDLmodel.Visible = true;
            }
            else
            {
                DDLmodel.Visible = false;
            }
        }

        protected void cbDescription_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDescription.Checked == true)
            {
                DDLdescription.Visible = true;
            }
            else
            {
                DDLdescription.Visible = false;
            }
        }

        
        protected void cbID_CheckedChanged(object sender, EventArgs e)
        {
            if (cbID.Checked == true)
            {
                DDLid.Visible = true;
            }
            else
            {
                DDLid.Visible = false;
            }
        }

        protected void cbSN_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSN.Checked == true)
            {
                DDLsn.Visible = true;
            }
            else
            {
                DDLsn.Visible = false;
            }
        }

        protected void cbICC_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void cbCalendars_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCalendars.Checked == true)
            {
                monthCalendarDueAfter.Visible = true;
                LdueAfter.Visible = true;
                monthCalendarDueB4.Visible = true;
                LdueB4.Visible = true;
            }
            else
            {
                monthCalendarDueAfter.Visible = false;
                LdueAfter.Visible = false;
                monthCalendarDueB4.Visible = false;
                LdueB4.Visible = false;
            }
        }

        protected void GridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataSelect();
        }

        protected void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSelect();
        }
        
        protected void BgetGrid_Click(object sender, EventArgs e)
        {
            DataSelect();
            label1.Text = "Number of Rows Returned = " + GetTotalRows().ToString();
        }

        protected void DataSelect()
        {
            if (cbStatus.Checked == true)
            {
                statusFilter = " status = '" + DDLstatus.Text.Trim() + "'";

                if (cbLocation.Checked == true | cbRoom.Checked == true |
                    cbType.Checked == true | cbManufacturer.Checked == true |
                    cbUser.Checked == true | cbOwner.Checked == true |
                    cbOwnerSupervisor.Checked == true |
                    cbCalsource.Checked == true | cbModel.Checked == true |
                    cbCalendars.Checked == true | cbID.Checked == true |
                    cbDescription.Checked == true)
                {
                    statusFilter = statusFilter + " and";
                }
            }
            else
            {
                statusFilter = "";
            }

            if (cbLocation.Checked == true)
            {
                locationFilter = " location = '" + DDLlocation.Text.Trim() + "'";

                if (cbRoom.Checked == true |
                    cbType.Checked == true | cbManufacturer.Checked == true |
                    cbUser.Checked == true | cbOwner.Checked == true |
                    cbOwnerSupervisor.Checked == true |
                    cbCalsource.Checked == true | cbModel.Checked == true |
                    cbCalendars.Checked == true | cbID.Checked == true |
                    cbDescription.Checked == true)
                {
                    locationFilter = locationFilter + " and";
                }
            }
            else
            {
                locationFilter = "";
            }

            if (cbRoom.Checked == true)
            {
                roomFilter = " location like '" + DDLroom.Text.Trim() + "%'";
                
                if (cbType.Checked == true | cbManufacturer.Checked == true |
                    cbUser.Checked == true | cbOwner.Checked == true |
                    cbOwnerSupervisor.Checked == true |
                    cbCalsource.Checked == true | cbModel.Checked == true |
                    cbCalendars.Checked == true | cbID.Checked == true |
                    cbDescription.Checked == true)
                {
                    roomFilter = roomFilter + " and";
                }
            }
            else
            {
                roomFilter = "";
            }

            if (cbType.Checked == true)
            {
                typeFilter = " type = '" + DDLtype.Text.Trim() + "'";

                if (cbManufacturer.Checked == true |
                    cbUser.Checked == true | cbOwner.Checked == true |
                    cbOwnerSupervisor.Checked == true |
                    cbCalsource.Checked == true | cbModel.Checked == true |
                    cbCalendars.Checked == true | cbID.Checked == true |
                    cbDescription.Checked == true)
                {
                    typeFilter = typeFilter + " and";
                }
            }
            else
            {
                typeFilter = "";
            }

            if (cbManufacturer.Checked == true)
            {
                manufacturerFilter = " manufacturer = '" + DDLmanufacturer.Text.Trim() + "'";

                if (cbUser.Checked == true | cbOwner.Checked == true |
                    cbOwnerSupervisor.Checked == true |
                    cbCalsource.Checked == true | cbModel.Checked == true |
                    cbCalendars.Checked == true | cbID.Checked == true |
                    cbDescription.Checked == true)
                {
                    manufacturerFilter = manufacturerFilter + " and";
                }
            }
            else
            {
                manufacturerFilter = "";
            }

            
            if (cbCalsource.Checked == true)
            {
                calsourceFilter = " [calibration source] = '" + DDLcalsource.Text.Trim() + "'";

                if (cbUser.Checked == true | cbOwner.Checked == true |
                    cbOwnerSupervisor.Checked == true |
                    cbModel.Checked == true |
                    cbCalendars.Checked == true | cbID.Checked == true |
                    cbDescription.Checked == true)
                {
                    calsourceFilter = calsourceFilter + " and";
                }
            }
            else
            {
                calsourceFilter = "";
            }

            if (cbModel.Checked == true)
            {
                modelFilter = " model = '" + DDLmodel.Text.Trim() + "'";

                if (cbUser.Checked == true | cbOwner.Checked == true |
                    cbOwnerSupervisor.Checked == true |
                    cbCalendars.Checked == true | cbID.Checked == true |
                    cbDescription.Checked == true)
                {
                    modelFilter = modelFilter + " and";
                }
            }
            else
            {
                modelFilter = "";
            }

            if (cbCalendars.Checked == true)
            {
                calendarFilter = " [due date] < '" +
                    monthCalendarDueB4.SelectedDate.ToShortDateString() + "' and '" +
                    monthCalendarDueAfter.SelectedDate.ToShortDateString() +
                    "' < [due date]";

                if (cbUser.Checked == true | cbOwner.Checked == true |
                    cbOwnerSupervisor.Checked == true |
                    cbID.Checked == true | cbDescription.Checked == true)
                {
                    calendarFilter = calendarFilter + " and";
                }
            }
            else
            {
                calendarFilter = "";
            }

            if (cbID.Checked == true)
            {
                idFilter = " id = '" + DDLid.Text.Trim() + "'";

                if (cbUser.Checked == true | cbOwner.Checked == true |
                    cbOwnerSupervisor.Checked == true |
                    cbDescription.Checked == true)
                {
                    idFilter = idFilter + " and";
                }
            }
            else
            {
                idFilter = "";
            }

            if (cbDescription.Checked == true)
            {
                descriptionFilter = " [description] like '%" +
                    DDLdescription.Text.Trim() + "%'";

                if (cbUser.Checked == true | cbOwner.Checked == true |
                    cbOwnerSupervisor.Checked == true)
                {
                    descriptionFilter = descriptionFilter + " and";
                }
            }
            else
            {
                descriptionFilter = "";
            }

            if (cbUser.Checked == true)
            {
                userFilter = " [user] = '" + DDLuser.Text.Trim() + "'";

                if (cbOwner.Checked == true |
                    cbOwnerSupervisor.Checked == true)
                {
                    userFilter = "(" + userFilter + " or";
                }
            }
            else
            {
                userFilter = "";
            }

            if (cbOwner.Checked == true)
            {
                ownerFilter = " [owner] = '" + DDLowner.Text.Trim() + "'";

                if (cbUser.Checked == true & 
                    cbOwnerSupervisor.Checked == true )
                {
                    ownerFilter = ownerFilter + " or";
                }

                if (cbUser.Checked == true &
                    cbOwnerSupervisor.Checked == false)
                {
                    ownerFilter = ownerFilter + ")";
                }

                if (cbUser.Checked == false &
                    cbOwnerSupervisor.Checked == true)
                {
                    ownerFilter = "(" + ownerFilter + " or";
                }
            }
            else
            {
                ownerFilter = "";
            }

            if (cbOwnerSupervisor.Checked == true)
            {
                ownersupFilter = " [owner supervisor] = '" + DDLownsup.Text.Trim() + "'";

                if (cbUser.Checked == true & cbOwner.Checked == true)
                {
                    ownersupFilter = ownersupFilter + ")";
                }

                if (cbUser.Checked == true & cbOwner.Checked == false)
                {
                    ownersupFilter = ownersupFilter + ")";
                }

                if (cbUser.Checked == false & cbOwner.Checked == true)
                {
                    ownersupFilter = ownersupFilter + ")";
                }
            }
            else
            {
                ownersupFilter = "";
            }


            if (cbStatus.Checked == true |
                 cbLocation.Checked == true |
                 cbRoom.Checked == true |
                 cbType.Checked == true |
                 cbManufacturer.Checked == true |
                 cbUser.Checked == true |
                 cbOwner.Checked == true |
                 cbOwnerSupervisor.Checked == true |
                 cbCalsource.Checked == true |
                 cbModel.Checked == true |
                 cbCalendars.Checked == true |
                 cbID.Checked == true |
                 cbDescription.Checked == true)
            {
                where = " where";
            }
            else
            {
                where = "";
            }

            
            SqlDataSource11.SelectCommand = "select * from webzams" + where + 
                statusFilter + locationFilter + roomFilter + typeFilter +
                manufacturerFilter + calsourceFilter + modelFilter + 
                calendarFilter + idFilter + descriptionFilter + 
                userFilter + ownerFilter + ownersupFilter;
        }

        protected int GetTotalRows()
        {
            DataView dv = (DataView)SqlDataSource11.Select(DataSourceSelectArguments.Empty);
            return dv.Count;
        }

        protected void ExportToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("content-disposition", "attachment;filename=MyFiles.xls");
            Response.Charset = "";
            this.EnableViewState = false;

            System.IO.StringWriter sw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htw = new HtmlTextWriter(sw);

            GridView.RenderControl(htw);

            Response.Write(sw.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        

 
        //private void BindFiles()
        //{
        //    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo("c:\\a");
        //    GridView.DataSource = di.GetFiles();
        //    GridView.DataBind();
        //}
    }
}
