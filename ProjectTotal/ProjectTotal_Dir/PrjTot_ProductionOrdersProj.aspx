<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="PrjTot_ProductionOrdersProj.aspx.vb" Inherits="ProjectTotal_Dir_PrjTot_ProductionOrdersProj" title="Production Orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetDataBy_ProjProductionOrderSum_Project" TypeName="ProjectTotalTableAdapters.tabProjectProductionOrderSumTableAdapter">
        <SelectParameters>
            <asp:SessionParameter Name="PROJECT" SessionField="strProject" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <h3>
        Production Orders for Project 
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </h3>       
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" PageSize="20" Style="position: relative">
        <Columns>
            <asp:BoundField DataField="ORDER_NUMBER" HeaderText="Order" SortExpression="ORDER_NUMBER">
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
            <asp:BoundField DataField="SumOfAMOUNT" DataFormatString="{0:#,##0.00;(#,##0.00);0}"
                HeaderText="Total Cost" SortExpression="SumOfAMOUNT">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="MaterialCost" DataFormatString="{0:#,##0.00;(#,##0.00);0}"
                HeaderText="Material Cost" SortExpression="MaterialCost">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:HyperLinkField Text="Material" DataNavigateUrlFields="PROJECT,ORDER_NUMBER" DataNavigateUrlFormatString="PrjTot_ProductionOrdersProj_Material.aspx?PROJECT={0}&amp;ORDER_NUMBER={1}">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:HyperLinkField>
            <asp:HyperLinkField Text="Operations" DataNavigateUrlFields="PROJECT,ORDER_NUMBER" DataNavigateUrlFormatString="PrjTot_ProductionOrdersProj_Operations.aspx?PROJECT={0}&amp;ORDER_NO={1}">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:HyperLinkField>
            <asp:BoundField DataField="PROJECT" HeaderText="PROJECT" SortExpression="PROJECT"
                Visible="False" />
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>

