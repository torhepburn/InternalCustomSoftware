<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="PrjTot_ProductionOrdersProj_Material.aspx.vb" Inherits="ProjectTotal_Dir_PrjTot_ProductionOrdersProj_Material" title="Material Cost Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetDataBy_ActualMaterialCosts_Proj" TypeName="ProjectTotalTableAdapters.tabActualMaterialCostsTableAdapter">
        <SelectParameters>
            <asp:SessionParameter Name="PROJECT" SessionField="strProject" Type="String" />
            <asp:QueryStringParameter Name="ORDER_NO" QueryStringField="ORDER_NUMBER" Type="Single" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <h3>
        Material Cost Details for Project 
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </h3>  
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" Style="position: relative">
        <Columns>
            <asp:BoundField DataField="ITEM_CODE" HeaderText="Item Code" SortExpression="ITEM_CODE">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="ITEM_DESCRIPTION" HeaderText="Description" SortExpression="ITEM_DESCRIPTION">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="ACTUAL_QUANTITY" HeaderText="Qty" SortExpression="ACTUAL_QUANTITY" DataFormatString="{0:#,##0.0;(#,##0.0);0}">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="ItemType" HeaderText="Type" SortExpression="ItemType">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="TotalCost" HeaderText="Cost" SortExpression="TotalCost" DataFormatString="{0:#,##0.00;(#,##0.00);0}">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>

