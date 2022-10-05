<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EquipmentStatus.aspx.vb"
    Inherits="Zygo.Maintenance.EquipmentStatus" %>

<%@ Register TagPrefix="uc1" TagName="Menu" Src="~/Controls/Menu.ascx" %>
<%@ Register TagPrefix="zto" TagName="Banner" Src="~/Controls/Banner.ascx" %>
<%@ Register TagPrefix="zto" TagName="Menu" Src="~/Controls/Menu.ascx" %>
<%@ Register TagPrefix="zc" Namespace="ZygoControls" Assembly="ZygoControls" %>
<%@ Register TagPrefix="uc1" TagName="Copyright" Src="~/Controls/Copyright.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MaintenanceNav" Src="MaintenanceNav.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Dashboard - Current Equipment Status</title>
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
    <table class="LayoutTable" id="Table1" style="width: 100%" cellspacing="1" cellpadding="1"
        border="0">
        <tbody>
            <tr>
                <td style="width: 175px" valign="top" rowspan="2" class="sidemenu">
                    <uc1:MaintenanceNav ID="MaintenanceNav1" runat="server" />
                </td>
                <td valign="top" align="center" class="PageHeader">
                    <asp:Label ID="EquipmentStatusLabel" runat="server" Font-Bold="True" Font-Names="Verdana"
                        Font-Size="X-Small"></asp:Label><br />
                    <asp:Label ID="CurrentCommentssize" runat="server" Visible="False">Label</asp:Label><asp:Button
                        ID="CommentssizeToggle" runat="server" Font-Names="verdana" Font-Size="XX-Small"
                        CssClass="DefaultButton"></asp:Button>
                </td>
            </tr>
            <tr>
                <td valign="top" align="left">
                    <zc:DataViewDataGrid ID="EquipmentStatusDataGrid" runat="server" PageSize="25" AutoGenerateColumns="False"
                        AllowSorting="True" AllowPaging="True" CssClass="FormatDataGrid" Width="100%"
                        CellPadding="0">
                        <EditItemStyle CssClass="FormatDataGridEdit" />
                        <AlternatingItemStyle Wrap="False" HorizontalAlign="Left" />
                        <ItemStyle Wrap="False" HorizontalAlign="Left" CssClass="FormatDataGrid" />
                        <HeaderStyle Font-Bold="True" Wrap="False" HorizontalAlign="Left" CssClass="FormatDataGridHeaderFooter">
                        </HeaderStyle>
                        <Columns>
                            <asp:TemplateColumn>
                                <HeaderStyle Font-Size="X-Small" Font-Names="verdana" Font-Bold="True" />
                                <ItemStyle Wrap="False" />
                                <ItemTemplate>
                                    <a href='/zto/app/maintenance/equipmenthistory.aspx?id=<%# DataBinder.Eval(Container.DataItem, "MachineID")%>' />
                                    View History
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="Machine" SortExpression="Machine" ReadOnly="True" HeaderText="Machine"
                                DataFormatString="{0:D}">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:TemplateColumn SortExpression="Status" HeaderText="Up/Down/Other">
                                <HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Center" />
                                <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <table border="0" width="90%" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <%# getquickstatus(DataBinder.Eval(Container.DataItem, "MachineStatus"))%>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="Status" SortExpression="Status" ReadOnly="True" HeaderText="Status">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Date" SortExpression="Date" ReadOnly="True" HeaderText="Date"
                                DataFormatString="{0:f}">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Name" SortExpression="Name" ReadOnly="True" HeaderText="Name">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:TemplateColumn>
                                <HeaderTemplate>
                                    Comments
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label Text='<%# Dashweb.Core.Maintenance.Common.FixReturns(DataBinder.Eval(Container.DataItem, "Comments")) %>'
                                        runat="server" ID="Label1" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox Width="100%" runat="server" ID="Textbox1" />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                        <PagerStyle HorizontalAlign="Center" CssClass="FormatDataGridHeaderFooter" Mode="NumericPages">
                        </PagerStyle>
                    </zc:DataViewDataGrid>
                    <div style="display: inline; font-size: xx-small; width: 199px; font-family: verdana">
                        Number of rows to view:</div>
                    <asp:TextBox ID="NumRows" runat="server" Font-Names="Verdana" Font-Size="XX-Small"
                        Width="57px">25</asp:TextBox><asp:Button ID="UpdateRows" runat="server" Font-Names="Verdana"
                            Font-Size="XX-Small" Width="100px" Text="Update Rows" CssClass="DefaultButton">
                    </asp:Button>
                </td>
            </tr>
        </tbody>
    </table>
    <uc1:Copyright ID="Copyright1" runat="server" />
    </form>
</body>
</html>
