<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AdministerEquipment.aspx.vb"
    Inherits="Zygo.Maintenance.AdministerEquipment" %>

<%@ Register TagPrefix="zto" TagName="Copyright" Src="~/Controls/Copyright.ascx" %>
<%@ Register TagPrefix="zto" TagName="Menu" Src="~/Controls/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MaintenanceNav" Src="MaintenanceNav.ascx" %>
<%@ Register TagPrefix="zc" Namespace="ZygoControls" Assembly="ZygoControls" %>
<%@ Register TagPrefix="zto" TagName="Banner" Src="~/Controls/Banner.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Dashboard - Maintenance - Administer Equipment</title>
    <meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR" />
    <meta content="Visual Basic 7.0" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
    <link href="../../css/stylesie9.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <zto:Banner ID="Banner1" runat="server" />
    <zto:Menu ID="Menu1" runat="server" />
    <table id="Table1" style="width: 100%" cellspacing="1" cellpadding="1" border="0">
        <tr valign="top">
            <td style="width: 128px" valign="top" rowspan="3" class="sidemenu">
                <uc1:MaintenanceNav ID="Maintenancenav2" runat="server" />
            </td>
            <td valign="top" align="center" class="PageHeader">
                <asp:Label ID="AdministerEquipmentLabel" runat="server" Font-Bold="True" /><br />
                <asp:Label ID="ResponseLabel" runat="server" CssClass="" />
            </td>
        </tr>
        <tr valign="top">
            <td valign="top" align="center">
                <table id="Table8" style="width: 40%;" cellspacing="0" cellpadding="0" border="0"
                    class="RowsTable">
                    <tr>
                        <td>
                            <div style="display: inline; font-weight: bold; width: 94px; height: 13px">
                                Filters:</div>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="display: inline; font-weight: normal; width: 100%">
                                Machine:</div>
                        </td>
                        <td>
                            <asp:TextBox ID="FilterMachine" runat="server" Width="98%" />
                        </td>
                        <td align="center">
                            <asp:Button ID="Filter" runat="server" Font-Bold="True" Text="Filter" CssClass="DefaultButton" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="display: inline; font-weight: normal; width: 100%;">
                                Responsible User:</div>
                        </td>
                        <td>
                            <asp:TextBox ID="FilterEngineer" runat="server" Width="98%" />
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="display: inline; font-weight: normal; width: 100%;">
                                Responsible R&amp;M:</div>
                        </td>
                        <td>
                            <asp:TextBox ID="FilterRandM" runat="server" Width="98%" />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
                <zc:DataViewDataGrid ID="AdministerMachinesDataGrid" OnPageIndexChanged="PageList"
                    OnSortCommand="SortList" runat="server" CellPadding="1" CssClass="FormatDataGrid"
                    AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" PageSize="25"
                    EditItemStyle-BackColor="antiquewhite" OnCancelCommand="EquipmentStatusDataGrid_Cancel"
                    OnUpdateCommand="EquipmentStatusDataGrid_Update" OnEditCommand="EquipmentStatusDataGrid_Edit"
                    Width="100%">
                    <SelectedItemStyle VerticalAlign="Top" />
                    <EditItemStyle CssClass="FormatDataGridEdit" VerticalAlign="Top" />
                    <AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    <ItemStyle HorizontalAlign="Left" CssClass="FormatDataGrid" VerticalAlign="Top" />
                    <HeaderStyle Font-Bold="True" Wrap="False" HorizontalAlign="Left" CssClass="FormatDataGridHeaderFooter" />
                    <PagerStyle HorizontalAlign="Center" CssClass="FormatDataGridPaging" Mode="NumericPages" />
                    <Columns>
                        <asp:TemplateColumn>
                            <ItemStyle Wrap="False" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:LinkButton runat="server" Text="Edit" CommandName="Edit" CausesValidation="false" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton Font-Names='verdana' Font-Size="7" Height="100%" runat="server" Text="Update"
                                    CommandName="Update" />&nbsp;
                                <asp:LinkButton Height="100%" runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false"></asp:LinkButton>
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn SortExpression="Machine" HeaderText="Machine">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Machine", "{0:D}") %>'
                                    Height="100%" Width="100%">
                                </asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID='e_Machine' Font-Names='verdana' Font-Size="7" runat="server" Text='<%# DataBinder.Eval(Container.dataitem, "Machine") %>'
                                    Width="100%" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn SortExpression="EngineerName" HeaderText="Responsible User">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.dataitem, "EngineerName") %>'
                                    Height="100%" Width="100%">
                                </asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID='e_EngineerName' Font-Names='verdana' DataValueField="ID" DataTextField="Name"
                                    Font-Size="7" runat="server" DataSource="<%# GetEngineerName() %>" SelectedIndex='<%# GetEngineerNameIndex(Container.DataItem("Engineer")) %>'
                                    Height="100%" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn SortExpression="RandMName" HeaderText="Responsible R and M">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.dataitem, "RandMName") %>'
                                    Height="100%" Width="100%">
                                </asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="e_RandMName" Font-Names='verdana' Font-Size="7" DataValueField="id"
                                    DataTextField="Name" DataSource="<%# GetRandMName() %>" SelectedIndex='<%# GetRandMNameIndex(Container.DataItem("RandM")) %>'
                                    runat="server" Height="100%" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn SortExpression="SimpleStatus" HeaderText="Status">
                            <ItemStyle VerticalAlign="Top" />
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "SimpleStatus") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList Font-Names='verdana' Font-Size="7" runat="server" ID="e_StatusList"
                                    DataValueField="StatusIndex" DataTextField="Status" DataSource="<%# GetStatus() %>"
                                    SelectedIndex='<%# GetStatusIndex(Container.DataItem("Status")) %>' Height="100%"
                                    Width="100%" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn SortExpression="Department" HeaderText="Department">
                            <ItemStyle VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "Department") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID='e_Department' Font-Names='verdana' Font-Size="7" DataValueField="id"
                                    DataTextField="Department" DataSource="<%# GetDepartment() %>" EnableViewState="True"
                                    SelectedIndex='<%# GetDepartmentIndex(Container.DataItem("MaintenanceMachineDepartment")) %>'
                                    runat="server" Height="100%" Width="100%" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn Visible="False" DataField="MachineIndex" ReadOnly="True" HeaderText="MachineIndex">
                        </asp:BoundColumn>
                        <asp:BoundColumn Visible="False" DataField="RandM" ReadOnly="True" HeaderText="RandM">
                        </asp:BoundColumn>
                        <asp:BoundColumn Visible="False" DataField="Engineer" ReadOnly="True" HeaderText="Engineer">
                        </asp:BoundColumn>
                        <asp:BoundColumn Visible="False" DataField="Status" ReadOnly="True" HeaderText="Status">
                        </asp:BoundColumn>
                    </Columns>
                </zc:DataViewDataGrid>
                <div style="display: inline; width: 199px;">
                    Number of rows to view:</div>
                <asp:TextBox ID="NumRows" runat="server" Width="57px">25</asp:TextBox><asp:Button
                    ID="UpdateRows" runat="server" Width="100px" Text="Update Rows" CssClass="DefaultButton" />
                <br />
            </td>
        </tr>
    </table>
    <zto:Copyright ID="Copyright2" runat="server" />
    </form>
</body>
</html>
