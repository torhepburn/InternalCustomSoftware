<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="GridTest.aspx.vb" Inherits=".GridTest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="rce" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TEST</title>
</head>
<body>
    <form id="form1" runat="server">
    
    <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />

    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">

        <AjaxSettings>

            <telerik:AjaxSetting AjaxControlID="RadGrid1">

                <UpdatedControls>

                    <telerik:AjaxUpdatedControl ControlID="RadGrid1"></telerik:AjaxUpdatedControl>

                </UpdatedControls>

            </telerik:AjaxSetting>

        </AjaxSettings>

    </telerik:RadAjaxManager>

    <div class="demo-container no-bg">

        <h3>Customers:</h3>

        <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" PageSize="20" DataSourceID="SqlDataSource1"

            OnItemCommand="RadGrid1_ItemCommand" CellSpacing="-1" GridLines="Both" GroupPanelPosition="Top">

            <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">

                <Selecting AllowRowSelect="true"></Selecting>

            </ClientSettings>

            <MasterTableView DataKeyNames="serial" AutoGenerateColumns="False">

                <Columns>
                    <telerik:GridBoundColumn DataField="serial" FilterControlAltText="Filter serial column" HeaderText="serial" ReadOnly="True" SortExpression="serial" UniqueName="serial">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="description" FilterControlAltText="Filter description column" HeaderText="Description" ReadOnly="True" SortExpression="description" UniqueName="description">
                    </telerik:GridBoundColumn>
                </Columns>

            </MasterTableView>

        </telerik:RadGrid>
    </div>
        <asp:SqlDataSource ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:AccessFrontEndsConnectionString %>" SelectCommand="SELECT serial, description, manufacturer from MIDSQL01.PM_2015_A.dbo.PMequip where description like 'green spot%'"

        runat="server"></asp:SqlDataSource>

        <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
        <asp:Button ID="button1" runat="server" Text="Button" />

        <rce:modalpopupextender id="ModalPopupExtender1" runat="server" 
	        cancelcontrolid="btnCancel" okcontrolid="btnOkay" 
	        targetcontrolid="button1" 
            popupcontrolid="Panel1" 
	        popupdraghandlecontrolid="PopupHeader" drag="true" 
	        backgroundcssclass="ModalPopupBG">
        </rce:modalpopupextender>

    <asp:panel id="Panel1" style="display: none" runat="server">
	        <div class="HellowWorldPopup">
                <div class="PopupHeader" id="PopupHeader">Header</div>
                <div class="PopupBody">
                    <p>This is a simple modal dialog</p>
                </div>
                <div class="Controls">
                    <input id="btnOkay" type="button" value="Done" />
                    <input id="btnCancel" type="button" value="Cancel" />
		    </div>
            </div>
    </asp:panel>

    </form>
</body>
</html>
