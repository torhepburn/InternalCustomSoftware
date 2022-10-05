<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BrowseInitialRequests.aspx.vb" Inherits="WebTestVB.BrowseInitialRequests" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table id="ConditionTable" cellspacing="0" cellpadding="0" width="70%" align="center"
                        border="0" style="border-color: Blue">
                        <tr>
                            <td align="center">
                                <table class="RowsTable" border="0" style="border-color: Red" cellpadding="0">
                                    <tr>
                                        <th width="150" align="left">Filters
                                        </th>
                                        <th></th>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblEquipmentID" runat="server" Text="Equipment ID: "></asp:Label>
                                        </td>
                                        <td style="width: 152px">
                                            <asp:DropDownList ID="drpEquipmentID" runat="server" Font-Names="Verdana" Font-Size="XX-Small">
                                            </asp:DropDownList>
                                        </td>
                                        <td><asp:Button ID="btnFilter" runat="server" Text="Filter" ValidationGroup="VG" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblSeverity" runat="server" Text="Severity: "></asp:Label>
                                        </td>
                                        <td style="width: 152px">
                                            <asp:DropDownList ID="drpSeverity" runat="server" Font-Names="Verdana" Font-Size="XX-Small">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem>ROUTINE</asp:ListItem>
                                                <asp:ListItem>SEVERE</asp:ListItem>
                                                <asp:ListItem>URGENT</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCategory" runat="server" Text="Category: "></asp:Label>
                                        </td>
                                        <td style="width: 152px">
                                            <asp:DropDownList ID="drpCategory" runat="server" Font-Names="Verdana" Font-Size="XX-Small">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem>CONTINUOUS IMPROVEMENT</asp:ListItem>
                                                <asp:ListItem>MACHINE DOWN - PRODUCTION STOPPED</asp:ListItem>
                                                <asp:ListItem>REPAIR</asp:ListItem>
                                                <asp:ListItem>SAFETY</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td></td>
                                    </tr>
                                        <td>Cost Center:
                                        </td>
                                        <td style="width: 152px;">
                                            <asp:DropDownList ID="drpCostCenter" runat="server" AppendDataBoundItems="True"
                                                Font-Names="Verdana" Font-Size="XX-Small">
                                            </asp:DropDownList>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>Owner:
                                        </td>
                                        <td style="width: 152px;">
                                            <asp:DropDownList ID="drpOwner" runat="server" AppendDataBoundItems="True"
                                                Font-Names="Verdana" Font-Size="XX-Small">
                                            </asp:DropDownList>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>Reported By:
                                        </td>
                                        <td style="width: 152px;">
                                            <asp:DropDownList ID="drpReportedBy" runat="server" Font-Names="Verdana" Font-Size="XX-Small">
                                            </asp:DropDownList>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>Site:
                                        </td>
                                        <td style="width: 152px;">
                                            <asp:DropDownList ID="drpSite" runat="server" Font-Names="Verdana" Font-Size="XX-Small">
                                                 <asp:ListItem></asp:ListItem>
                                                <asp:ListItem>COSTA MESA</asp:ListItem>
                                                <asp:ListItem>MIDDLEFIELD</asp:ListItem>
                                                <asp:ListItem>RICHMOND</asp:ListItem>
                                                <asp:ListItem>TUSCON</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td></td>
                                    </tr>
                                        <td>
                                            
                                        </td>
                                        <td></td>
                                        <td><asp:Button ID="btnReset" runat="server" Text="Reset" /></td>
                                    </tr>
                                </table>
        <asp:GridView ID="grd" runat="server" >

        </asp:GridView>
    </div>
    </form>
</body>
</html>
