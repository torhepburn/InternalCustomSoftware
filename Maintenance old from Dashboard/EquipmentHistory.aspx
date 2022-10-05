<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EquipmentHistory.aspx.vb"
    Inherits="Zygo.Maintenance.EquipmentHistory" %>

<%@ Register TagPrefix="uc1" TagName="Menu" Src="~/Controls/Menu.ascx" %>
<%@ Register TagPrefix="zto" TagName="Banner" Src="~/Controls/Banner.ascx" %>
<%@ Register TagPrefix="zto" TagName="Menu" Src="~/Controls/Menu.ascx" %>
<%@ Register TagPrefix="zc" Namespace="ZygoControls" Assembly="ZygoControls" %>
<%@ Register TagPrefix="uc1" TagName="MaintenanceNav" Src="MaintenanceNav.ascx" %>
<%@ Register TagPrefix="zto" TagName="Copyright" Src="~/Controls/Copyright.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>Dashboard - Maintenance Equipment History</title>
    <meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR" />
    <meta content="Visual Basic 7.0" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
    <link href="/zto/css/styles.css" type="text/css" rel="stylesheet" />
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
                <p>
                    <asp:Label ID="EquipmentHistoryLabel" runat="server" /><br />
                    <asp:Label ID="ResponseLabel" runat="server" /><br />
                    <asp:Label ID="MachineIndex" runat="server" Visible="False" /></p>
            </td>
        </tr>
        <tr valign="top">
            <td valign="top" align="left">
                <zc:DataViewDataGrid ID="EquipmentHistoryDataGrid" OnPageIndexChanged="PageList"
                    OnSortCommand="SortList" runat="server" CssClass="FormatDataGrid" AllowSorting="True"
                    AutoGenerateColumns="False" PageSize="25" EditItemStyle-BackColor="antiquewhite"
                    OnCancelCommand="EquipmentHistoryDataGrid_Cancel" OnUpdateCommand="EquipmentHistoryDataGrid_Update"
                    OnEditCommand="EquipmentHistoryDataGrid_Edit" Width="100%" AllowPaging="True">
                    <SelectedItemStyle VerticalAlign="Top" />
                    <EditItemStyle CssClass="FormatDataGridEdit" VerticalAlign="Top" />
                    <AlternatingItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Top" />
                    <ItemStyle Wrap="False" HorizontalAlign="Left" CssClass="FormatDataGrid" VerticalAlign="Top" />
                    <HeaderStyle Font-Bold="True" Wrap="False" HorizontalAlign="Left" CssClass="FormatDataGridHeaderFooter" />
                    <PagerStyle HorizontalAlign="Center" CssClass="FormatDataGridPaging" Mode="NumericPages" />
                    <Columns>
                        <asp:TemplateColumn>
                            <ItemStyle Wrap="False" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:LinkButton runat="server" Text="Edit" CommandName="Edit" CausesValidation="false" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton Height="100%" runat="server" Text="Update" CommandName="Update" Font-Names='verdana'
                                    Font-Size="7" />&nbsp;
                                <asp:LinkButton Height="100%" runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false"
                                    Font-Names='verdana' Font-Size="7" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn SortExpression="Date" HeaderText="Date">
                            <ItemStyle Wrap="False" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Date", "{0:f}")%>'
                                    Height="100%">
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn SortExpression="UserName" HeaderText="Operator">
                            <ItemTemplate>
                                <asp:Label runat="server" ID='UserName' Text='<%# DataBinder.Eval(Container.dataitem, "UserName") %>'
                                    Height="100%">
                                </asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label Font-Names='verdana' Font-Size="7" runat="server" Text='<%# DataBinder.Eval(Container.dataitem, "UserName") %>'
                                    Height="100%" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn SortExpression="Status" HeaderText="Status">
                            <ItemStyle VerticalAlign="Top"></ItemStyle>
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Status") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList Font-Names='verdana' Font-Size="7" runat="server" ID="StatusList"
                                    DataValueField="StatusIndex" DataTextField="Status" DataSource="<%# GetStatus() %>"
                                    SelectedIndex='<%# GetSelIndex(Container.DataItem("MaintenanceStatus")) %>' Height="100%" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <ItemStyle VerticalAlign="Top" />
                            <HeaderTemplate>
                                Comments
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label Text='<%# Dashweb.Core.Maintenance.Common.FixReturns(DataBinder.Eval(Container.DataItem, "Comments")) %>'
                                    runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID='Comments' Font-Names='verdana' Font-Size="7" Text='<%# Dashweb.Core.Maintenance.Common.FixReturns(DataBinder.Eval(Container.DataItem, "Comments")) %>'
                                    EnableViewState="true" Width="100%" TextMode="MultiLine" Rows="5" runat="server" />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn Visible="False" DataField="MaintenanceNumber" ReadOnly="True" HeaderText="MaintenanceNumber">
                        </asp:BoundColumn>
                    </Columns>
                    <PagerStyle HorizontalAlign="Center" CssClass="FormatDataGridHeaderFooter" Mode="NumericPages">
                    </PagerStyle>
                </zc:DataViewDataGrid><div style="display: inline; font-size: xx-small; width: 199px;
                    font-family: verdana">
                    Number of rows to view:</div>
                <asp:TextBox ID="NumRows" runat="server" Font-Names="Verdana" Font-Size="XX-Small"
                    Width="57px">25</asp:TextBox><asp:Button ID="UpdateRows" runat="server" Font-Names="Verdana"
                        Font-Size="XX-Small" Width="100px" Text="Update Rows" CssClass="DefaultButton">
                </asp:Button>
            </td>
        </tr>
    </table>
    <zto:Copyright ID="Copyright2" runat="server" />
    </form>
</body>
</html>
