<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="PrjTot_AllOtherCosts_Project.aspx.vb" Inherits="ProjectTotal_Dir_PrjTot_AllOtherCosts_Project" title="Other Costs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetDataBy_AllOtherCosts_Project" TypeName="ProjectTotalTableAdapters.tabProjectAllOtherCostsTableAdapter">
        <SelectParameters>
            <asp:SessionParameter Name="PROJECT" SessionField="strProject" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <h3>
        All Other Costs for Project 
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </h3>       
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" PageSize="30" Style="position: relative">
        <Columns>
            <asp:BoundField DataField="COST_PRICE_COMPONENT" HeaderText="Cost Price Comp." SortExpression="COST_PRICE_COMPONENT">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="CostPriceDesc" HeaderText="CPC Description" SortExpression="CostPriceDesc">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="SumOfAMOUNT" DataFormatString="{0:#,##0.00;(#,##0.00);0}"
                HeaderText="Amount" SortExpression="SumOfAMOUNT">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>

