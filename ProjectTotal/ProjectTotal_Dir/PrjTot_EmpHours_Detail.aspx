<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="PrjTot_EmpHours_Detail.aspx.vb" Inherits="ProjectTotal_Dir_PrjTot_EmpHours_Detail" title="Employee Hour Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetDataBy_ProjectHoursDetail_Proj_Employee" TypeName="ProjectTotalTableAdapters.tabProjectHrsDetailTableAdapter">
        <SelectParameters>
            <asp:SessionParameter Name="PROJECT" SessionField="strProject" Type="String" />
            <asp:QueryStringParameter Name="EMPLOYEE" QueryStringField="EMPLOYEE" Type="Single" />
        </SelectParameters>
    </asp:ObjectDataSource>
     <h3>
        Employee Hour Detail for Project 
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </h3>    
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        OnPageIndexChanging="gridView1_PageIndexChanging" OnSorting="gridView1_Sorting"
        AutoGenerateColumns="False" Style="position: relative" PageSize="25">
        <Columns>
            <asp:BoundField DataField="NAME" HeaderText="Name" SortExpression="NAME">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="DESCRIPTION" HeaderText="Description" SortExpression="DESCRIPTION">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="LAST_TRANSACTION_DATE" DataFormatString="{0:MM/dd/yyyy}"
                HeaderText="Date" SortExpression="LAST_TRANSACTION_DATE">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="MAN_TIME" DataFormatString="{0:#,##0.0;(#,##0.0);0}" HeaderText="Hours"
                SortExpression="MAN_TIME">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="LaborCost" DataFormatString="{0:#,##0.00;(#,##0.00);0}"
                HeaderText="Est. Labor" ReadOnly="True" SortExpression="LaborCost" Visible="False">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="WORK_CENTER" HeaderText="W/C" SortExpression="WORK_CENTER">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>

