<%@ Control Language="vb" AutoEventWireup="false" Codebehind="MaintenanceNav.ascx.vb" Inherits="MaintenanceNav" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table id="Table1" style="WIDTH: 158px; HEIGHT: 100%" cellspacing="0" cellpadding="0" align="left"
	border="0">
	<tbody>
		<tr>
			<td valign="top" align="left">
			    <div class="heading">Maintenance Menu</div>
					<hr style="WIDTH: 100%; color:#54754a" align="left" size="2" />
					<a class="navbar" href="EquipmentStatus.aspx">View Equipment Status</a><br />
					<a class="navbar" href="AddMaintenanceEntry.aspx">Add Maintenance Entry</a><br />
					
					<% if _user.CheckRole(DashWeb.Core.Authentication.FacilitiesAdmin) then %>
					<a class="navbar" href="AddEquipment.aspx">Add New Equipment</a><br />
					<a class="navbar" href="AdministerEquipment.aspx">Administer Equipment</a><br />
					<% end if %>
					<a class="navbar" onmouseover="this.style.textDecoration='underline'" onmouseout="this.style.textDecoration='none'" onclick="window.open('EquipmentStatusDefinitions.htm','popuppage','toolbar=yes,menubar=no,location=no,scrollbars=yes,resizable=yes,width=500,height=800,top=0,left=0');" >View 
								Status Definitions</a><br />
				</td>
		</tr>
	</tbody>
</table>
