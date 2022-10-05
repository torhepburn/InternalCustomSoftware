<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LogEquipmentData.aspx.vb" Inherits="Zygo.Production.LogEquipmentData" %>

<%@ Register TagPrefix="uc1" TagName="ProcessNotesMenu" Src="~/app/Production/ProcessNotesMenu.ascx" %>
<%@ Register TagPrefix="zc" Namespace="ZygoControls" Assembly="ZygoControls" %>
<%@ Register TagPrefix="zto" TagName="Menu" Src="~/Controls/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Banner" Src="~/Controls/Banner.ascx" %>
<%@ Register TagPrefix="zto" TagName="Copyright" Src="~/Controls/Copyright.ascx" %>
<%@ Register TagPrefix="ucSmartControls" Namespace="SmartControls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="rce" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>Log Equipment Data</title>
    <meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR" />
    <meta content="Visual Basic 7.0" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />

    <link href="../../css/stylesie9.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .gridcells {
            VERTICAL-ALIGN: top;
        }
    </style>
</head>
<body>
    <form id="form1" method="post" runat="server">

            <%--<telerik:RadScriptManager runat="server" ID="RadScriptManager1" />--%>

    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">

        <AjaxSettings>

            <telerik:AjaxSetting AjaxControlID="grd">

                <UpdatedControls>

                    <telerik:AjaxUpdatedControl ControlID="grd"></telerik:AjaxUpdatedControl>

                </UpdatedControls>

            </telerik:AjaxSetting>

        </AjaxSettings>

    </telerik:RadAjaxManager>


        <uc1:Banner ID="Banner1" runat="server" />
        <zto:Menu ID="Menu1" runat="server" />
        <table class="LayoutTable" id="Table11" cellspacing="1" cellpadding="1" border="0" width="100%">
            <tr>
                <td width="152px" valign="top" rowspan="2" class="sidemenu">
                    <table border="0">
                        <tr>
                            <td>
                                <uc1:ProcessNotesMenu ID="ProcessNotesMenu1" runat="server"></uc1:ProcessNotesMenu>
                            </td>
                        </tr>
                    </table>
                </td>
                <td align="center">
                    <div class="TopPage">
                        <asp:Label ID="HeaderLabel" runat="server" Font-Bold="True">Log Equipment Data</asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td valign="top" align="center">
                    <asp:Label ID="lblMsg" runat="server" Font-Names="Verdana" Font-Size="X-Small" ForeColor="Maroon" EnableViewState="False"></asp:Label>

                    <%--<div style="text-align: center;">
                        <asp:ValidationSummary ID="ValidationSummary" HeaderText="You must enter a correct values in the following fields:"
                            ShowSummary="true" ValidationGroup="VG" DisplayMode="List"
                            EnableClientScript="true" runat="server" />
                    </div>--%>

                    <br />
                    <table id="ConditionTable" cellspacing="0" cellpadding="0" width="70%" align="center"
                        border="0" style="border-color: Blue">
                        <tr>
                            <td align="center">
                                <table class="RowsTable" border="0" style="border-color: Red" cellpadding="0">
                                    <tr>
                                        <th width="152" align="left">Filters
                                        </th>
                                        <th></th>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblSite" runat="server" Text="Equipment: "></asp:Label>
                                        </td>
                                        <td style="width: 152px">
                                            <asp:DropDownList ID="ddlEquipment" runat="server" Font-Names="Verdana" Font-Size="XX-Small">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnFilter" runat="server" Text="Filter" ValidationGroup="VG" /></td>
                                    </tr>
                                   
                                    <%--
                                    <tr>
                                        <td style="vertical-align: text-top;">Status:
                                        </td>
                                        <td>
                                            <asp:CheckBoxList ID="ddlbStatus" AutoPostBack="false" CellPadding="0" CellSpacing="0"
                                                RepeatColumns="2" RepeatDirection="Horizontal" TextAlign="Right" runat="server"
                                                EnableViewState="true" DataTextField="Name" DataValueField="ID" AppendDataBoundItems="true"
                                                Font-Names="Verdana" Font-Size="XX-Small">
                                            </asp:CheckBoxList>
                                        </td>
                                        <td></td>
                                    </tr>
--%>
                                </table>
                            </td>
                        </tr>
                    </table>

                    <ucsmartcontrols:smartradgrid id="grd" runat="server" onneeddatasource="grd_needdatasource"
                        OnItemCommand="grd_ItemCommand">
                        
                        <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">

                            <Selecting AllowRowSelect="true"></Selecting>

                        </ClientSettings>

                        <mastertableview DataKeyNames="LPID" AutoGenerateColumns="false" Width="100%">
                            <columns>
                                <telerik:gridboundcolumn datafield="serial" uniquename="serial" headertext="Equipment ID" sortexpression="serial" />
                                <telerik:gridboundcolumn datafield="description" headertext="Description" sortexpression="description" />
                                <telerik:gridboundcolumn datafield="reading" headertext="Last Reading" sortexpression="reading" />
                                <telerik:gridboundcolumn datafield="reading_date" dataformatstring="{0:d}" headertext="date created" htmlencode="false" sortexpression="datecreated" />
                                <telerik:gridboundcolumn datafield="lastupdated" dataformatstring="{0:d}" headertext="last updated" htmlencode="false" sortexpression="lastupdated" />
                            </columns>
                        </mastertableview>
                    </ucsmartcontrols:smartradgrid>
                                <%--<asp:BoundField DataField="Signed" HeaderText="Signed" SortExpression="Signed"
                                    DataFormatString="{0:MM/dd/yyyy}"
                                    HeaderStyle-HorizontalAlign="center">
                                    <HeaderStyle HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:BoundField>

                            </Columns>
                            <EmptyDataTemplate>
                                No data found
                            </EmptyDataTemplate>

                            <HeaderStyle CssClass="FormatDataGridHeaderFooter" />
                        </asp:GridView>--%>

                </td>
            </tr>
        </table>

        


        <%--<table id="entryTable" class="RowsTable" border="0"  width="50%" align="center" cellpadding="0">
            <tr>
                <td>
                    <br />
                    <asp:Label ID="Label2" runat="server" ></asp:Label>
                    <br />
                </td>
                
            </tr>
            
            <tr>
               <td align="center">
                   <br />Enter Data:
                                            <asp:TextBox ID="txtFastID" runat="server"></asp:TextBox>
                                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtFastID" ValidationGroup="VG"
                                                Display="None" ErrorMessage="Data must be numeric" MaximumValue="1000000000" MinimumValue="0"
                                                Type="Integer"></asp:RangeValidator>
                   <br />
                   <br />
                                        </td>
                                        
                                    </tr>
                                    <tr align="center">
                                        <td>
                                            <br />
                                            <asp:Button ID="Button2" runat="server" Text="Submit Data" ValidationGroup="VG" />

                                        </td>
                                    </tr>
                                    

        </table>--%>
        <p>
            <zto:Copyright ID="Copyright1" runat="server"></zto:Copyright>
        </p>
    </form>
</body>
</html>
