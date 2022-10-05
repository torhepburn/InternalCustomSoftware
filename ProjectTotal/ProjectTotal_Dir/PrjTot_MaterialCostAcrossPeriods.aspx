<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="PrjTot_MaterialCostAcrossPeriods.aspx.vb" Inherits="ProjectTotal_Dir_PrjTot_MaterialCostAcrossPeriods" title="Material Costs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetDataBy_MaterialCosts_Project" TypeName="ProjectTotalTableAdapters.tabProjectProductionOrderSumTableAdapter">
        <SelectParameters>
            <asp:SessionParameter Name="PROJECT" SessionField="strProject" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <h3>
        Material Costs for Project 
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </h3>     
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" Style="position: relative" PageSize="20">
        <Columns>
            <asp:BoundField DataField="ORDER_NUMBER" HeaderText="Order Number" SortExpression="ORDER_NUMBER">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="ITEM_CODE" HeaderText="Item Code" SortExpression="ITEM_CODE">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="ITEM_DESCRIPTION" HeaderText="Description" SortExpression="ITEM_DESCRIPTION">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="SumOfAMOUNT" HeaderText="Total Cost" SortExpression="SumOfAMOUNT" DataFormatString="{0:#,##0.00;(#,##0.00);0}" HtmlEncode="False">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="MaterialCost" HeaderText="Material Cost" SortExpression="MaterialCost" DataFormatString="{0:#,##0.00;(#,##0.00);0}" HtmlEncode="False">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="PROJECT,ORDER_NUMBER" DataNavigateUrlFormatString="PrjTot_MaterialCost_Project_OrderNumber.aspx?project={0}&amp;order_number={1}"
                Text="Details">
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:HyperLinkField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>

