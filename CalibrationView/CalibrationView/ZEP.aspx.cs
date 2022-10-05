using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;


namespace CalibrationView
{
    public partial class ZEP : System.Web.UI.Page
    {
        private string statusFilter;
        private string locationFilter;
        private string roomFilter;
        private string snFilter;
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

        }

        protected void cbStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStatus.Checked == true)
            {
                DDLstatus.Visible = true;
                cbICC.Enabled = false;
            }
            else
            {
                DDLstatus.Visible = false;
                cbICC.Enabled = true;
            }
        }

        protected void cbLocation_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLocation.Checked == true)
            {
                DDLlocation.Visible = true;
                cbICC.Enabled = false;
            }
            else
            {
                DDLlocation.Visible = false;
                cbICC.Enabled = true;
            }
        }

        protected void cbRoom_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRoom.Checked == true)
            {
                DDLroom.Visible = true;
                cbICC.Enabled = false;
            }
            else
            {
                DDLroom.Visible = false;
                cbICC.Enabled = true;
            }
        }



        protected void cbManufacturer_CheckedChanged(object sender, EventArgs e)
        {
            if (cbManufacturer.Checked == true)
            {
                DDLmanufacturer.Visible = true;
                cbICC.Enabled = false;
            }
            else
            {
                DDLmanufacturer.Visible = false;
                cbICC.Enabled = true;
            }
        }

        protected void cbUser_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUser.Checked == true)
            {
                DDLuser.Visible = true;
                cbICC.Enabled = false;
            }
            else
            {
                DDLuser.Visible = false;
                cbICC.Enabled = true;
            }
        }

        protected void cbOwner_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOwner.Checked == true)
            {
                DDLowner.Visible = true;
                cbICC.Enabled = false;
            }
            else
            {
                DDLowner.Visible = false;
                cbICC.Enabled = true;
            }
        }

        protected void cbOwnerSupervisor_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOwnerSupervisor.Checked == true)
            {
                DDLownsup.Visible = true;
                cbICC.Enabled = false;
            }
            else
            {
                DDLownsup.Visible = false;
                cbICC.Enabled = true;
            }
        }

        protected void cbCalsource_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCalsource.Checked == true)
            {
                DDLcalsource.Visible = true;
                cbICC.Enabled = false;
            }
            else
            {
                DDLcalsource.Visible = false;
                cbICC.Enabled = true;
            }
        }

        protected void cbModel_CheckedChanged(object sender, EventArgs e)
        {
            if (cbModel.Checked == true)
            {
                DDLmodel.Visible = true;
                cbICC.Enabled = false;
            }
            else
            {
                DDLmodel.Visible = false;
                cbICC.Enabled = true;
            }
        }

        protected void cbDescription_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDescription.Checked == true)
            {
                DDLdescription.Visible = true;
                cbICC.Enabled = false;
            }
            else
            {
                DDLdescription.Visible = false;
                cbICC.Enabled = true;
            }
        }


        protected void cbID_CheckedChanged(object sender, EventArgs e)
        {
            if (cbID.Checked == true)
            {
                DDLid.Visible = true;
                cbSN.Enabled = false;
                cbICC.Enabled = false;
            }
            else
            {
                DDLid.Visible = false;
                cbSN.Enabled = true;
                cbICC.Enabled = true;
            }
        }

        protected void cbSN_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSN.Checked == true)
            {
                DDLsn.Visible = true;
                cbID.Enabled = false;
                cbICC.Enabled = false;
            }
            else
            {
                DDLsn.Visible = false;
                cbID.Enabled = true;
                cbICC.Enabled = true;
            }
        }

        protected void cbICC_CheckedChanged(object sender, EventArgs e)
        {
            if (cbICC.Checked == true)
            {
                DDLicc.Visible = true;
                cbStatus.Enabled = false;
                cbLocation.Enabled = false;
                cbRoom.Enabled = false;
                cbDescription.Enabled = false;
                cbManufacturer.Enabled = false;
                cbID.Enabled = false;
                cbSN.Enabled = false;
                cbCalendars.Enabled = false;
                cbUser.Enabled = false;
                cbOwner.Enabled = false;
                cbOwnerSupervisor.Enabled = false;
                cbCalsource.Enabled = false;
                cbModel.Enabled = false;
            }
            else
            {
                DDLicc.Visible = false;
                cbStatus.Enabled = true;
                cbLocation.Enabled = true;
                cbRoom.Enabled = true;
                cbDescription.Enabled = true;
                cbManufacturer.Enabled = true;
                cbID.Enabled = true;
                cbSN.Enabled = true;
                cbCalendars.Enabled = true;
                cbUser.Enabled = true;
                cbOwner.Enabled = true;
                cbOwnerSupervisor.Enabled = true;
                cbCalsource.Enabled = true;
                cbModel.Enabled = true;
            }
        }

        protected void cbCalendars_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCalendars.Checked == true)
            {
                monthCalendarDueAfter.Visible = true;
                LdueAfter.Visible = true;
                monthCalendarDueB4.Visible = true;
                LdueB4.Visible = true;
                cbICC.Enabled = false;
            }
            else
            {
                monthCalendarDueAfter.Visible = false;
                LdueAfter.Visible = false;
                monthCalendarDueB4.Visible = false;
                LdueB4.Visible = false;
                cbICC.Enabled = true;
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
                    cbDescription.Checked == true | cbManufacturer.Checked == true |
                    cbUser.Checked == true | cbOwner.Checked == true |
                    cbOwnerSupervisor.Checked == true |
                    cbCalsource.Checked == true | cbModel.Checked == true |
                    cbCalendars.Checked == true | cbID.Checked == true |
                    cbSN.Checked == true)
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
                    cbDescription.Checked == true | cbManufacturer.Checked == true |
                    cbUser.Checked == true | cbOwner.Checked == true |
                    cbOwnerSupervisor.Checked == true |
                    cbCalsource.Checked == true | cbModel.Checked == true |
                    cbCalendars.Checked == true | cbID.Checked == true |
                    cbSN.Checked == true)
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

                if (cbDescription.Checked == true | cbManufacturer.Checked == true |
                    cbUser.Checked == true | cbOwner.Checked == true |
                    cbOwnerSupervisor.Checked == true |
                    cbCalsource.Checked == true | cbModel.Checked == true |
                    cbCalendars.Checked == true | cbID.Checked == true |
                    cbSN.Checked == true)
                {
                    roomFilter = roomFilter + " and";
                }
            }
            else
            {
                roomFilter = "";
            }

            if (cbDescription.Checked == true)
            {
                descriptionFilter = " [description] like '%" +
                    DDLdescription.Text.Trim() + "%'";

                if (cbManufacturer.Checked == true |
                    cbUser.Checked == true | cbOwner.Checked == true |
                    cbOwnerSupervisor.Checked == true |
                    cbCalsource.Checked == true | cbModel.Checked == true |
                    cbCalendars.Checked == true | cbID.Checked == true |
                    cbSN.Checked == true)
                {
                    descriptionFilter = descriptionFilter + " and";
                }
            }
            else
            {
                descriptionFilter = "";
            }


            if (cbManufacturer.Checked == true)
            {
                manufacturerFilter = " manufacturer = '" + DDLmanufacturer.Text.Trim() + "'";

                if (cbUser.Checked == true | cbOwner.Checked == true |
                    cbOwnerSupervisor.Checked == true |
                    cbCalsource.Checked == true | cbModel.Checked == true |
                    cbCalendars.Checked == true | cbID.Checked == true |
                    cbSN.Checked == true)
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
                    cbSN.Checked == true)
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
                    cbSN.Checked == true)
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
                    cbID.Checked == true | cbSN.Checked == true)
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
                    cbSN.Checked == true)
                {
                    idFilter = idFilter + " and";
                }
            }
            else
            {
                idFilter = "";
            }

            if (cbSN.Checked == true)
            {
                snFilter = " [sn] = '" +
                    DDLsn.Text.Trim() + "'";

                if (cbUser.Checked == true | cbOwner.Checked == true |
                    cbOwnerSupervisor.Checked == true)
                {
                    snFilter = snFilter + " and";
                }
            }
            else
            {
                snFilter = "";
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
                    cbOwnerSupervisor.Checked == true)
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
                 cbDescription.Checked == true |
                 cbManufacturer.Checked == true |
                 cbUser.Checked == true |
                 cbOwner.Checked == true |
                 cbOwnerSupervisor.Checked == true |
                 cbCalsource.Checked == true |
                 cbModel.Checked == true |
                 cbCalendars.Checked == true |
                 cbID.Checked == true |
                 cbSN.Checked == true)
            {
                where = " where";
            }
            else
            {
                where = "";
            }


            SqlDataSource11.SelectCommand = "select * from webzep" + where +
                statusFilter + locationFilter + roomFilter + descriptionFilter +
                manufacturerFilter + calsourceFilter + modelFilter +
                calendarFilter + idFilter + snFilter +
                userFilter + ownerFilter + ownersupFilter;

            if (cbICC.Checked == true)
            {
                SqlDataSource11.SelectCommand = "select * from webzep where " +
                    "[internal calibrator] = '" + DDLicc.Text.Trim() + "'";
            }
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
