<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddMaintenanceEntry.aspx.vb"
    Inherits="Zygo.Maintenance.AddMaintenanceEntry" %>

<%@ Register TagPrefix="uc1" TagName="Menu" Src="~/Controls/Menu.ascx" %>
<%@ Register TagPrefix="zto" TagName="Banner" Src="~/Controls/Banner.ascx" %>
<%@ Register TagPrefix="zto" TagName="Menu" Src="~/Controls/Menu.ascx" %>
<%@ Register TagPrefix="zc" Namespace="ZygoControls" Assembly="ZygoControls" %>
<%@ Register TagPrefix="uc1" TagName="Copyright" Src="~/Controls/Copyright.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MaintenanceNav" Src="MaintenanceNav.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Dashboard - Add Maintenance Entry</title>
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
    <table class="LayoutTable" id="Table1" style="width: 100%" cellspacing="1" cellpadding="1"
        border="0">
        <tbody>
            <tr>
                <td style="width: 175px" valign="top" rowspan="2" class="sidemenu">
                    <uc1:MaintenanceNav ID="MaintenanceNav1" runat="server" />
                </td>
                <td valign="top" align="center" class="PageHeader">
                    <asp:Label ID="AddMaintenanceEntryLabel" runat="server" Font-Bold="True" Width="100%"
                        Text="Maintenance - Add New Entry" />
                </td>
                <td align="left">
                    <asp:Label ID="ResponseLabel" runat="server" Font-Bold="True" Width="100%" />
                </td>
            </tr>
            <tr align="center">
                <td valign="top" align="center">
                    <table id="Table2" style="width: 55%; text-align: left" cellspacing="1" cellpadding="1"
                        border="0">
                        <tr>
                            <td>
                                <br />
                                <asp:TextBox ID="t_Operator" runat="server" Width="59px" Font-Names="Verdana" Font-Size="XX-Small"
                                    BackColor="#E0E0E0" Visible="False" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Operator:
                            </td>
                            <td>
                                <asp:TextBox ID="t_UserName" runat="server" BackColor="#E0E0E0" Width="100%" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Date Entered:
                            </td>
                            <td>
                                <asp:TextBox ID="t_Date" runat="server" BackColor="#E0E0E0" Width="100%" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Machine:
                            </td>
                            <td>
                                <asp:DropDownList ID="t_Machine" runat="server" Width="100%" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Status:
                            </td>
                            <td>
                                <asp:DropDownList ID="t_Status" runat="server" Width="100%" />
                            </td>
                        </tr>
                        <tr valign="top">
                            <td valign="top">
                                <asp:Label ID="CommentsLabel" runat="server" Height="100%" Text="Comments:" />
                            </td>
                            <td>
                                <asp:TextBox ID="t_Comments" runat="server" TextMode="MultiLine" Rows="10" Width="100%" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="SaveAndExit" runat="server" Text="Save and Exit" CssClass="DefaultButton" />&nbsp;&nbsp;
                                <asp:Button ID="CancelAndExit" runat="server" Text="Cancel and Exit" CssClass="DefaultButton" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
        </tbody>
    </table>
    <uc1:Copyright ID="Copyright1" runat="server" />
    </form>
</body>
</html>
