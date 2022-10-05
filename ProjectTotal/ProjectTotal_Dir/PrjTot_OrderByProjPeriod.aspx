<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="PrjTot_OrderByProjPeriod.aspx.vb" Inherits="ProjectTotal_Dir_PrjTot_OrderByProjPeriod" title="Orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetDataBy_tabProjectFinTransOrdSum_By_Project_Period" TypeName="ProjectTotalTableAdapters.tabProjectFinTransOrdSumByPeriodTableAdapter">
        <FilterParameters>
            <asp:SessionParameter Name="project" SessionField="strProject" />
        </FilterParameters>
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="272864" Name="PROJECT" QueryStringField="Project"
                Type="String" />
            <asp:QueryStringParameter DefaultValue="200712" Name="FINANCIAL_PERIOD" QueryStringField="FINANCIAL_PERIOD"
                Type="Decimal" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <h3>
        Orders for Project 
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </h3>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
        Style="position: relative" AllowPaging="True" AllowSorting="True" PageSize="30">
        
        <Columns>
            <asp:BoundField DataField="PROJECT" HeaderText="Project" SortExpression="PROJECT" Visible="False" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="FINANCIAL_PERIOD" HeaderText="Fin Period" SortExpression="FINANCIAL_PERIOD" Visible="False" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="CalPeriod" HeaderText="Cal Period" SortExpression="CalPeriod" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="PeriodDate" HeaderText="PeriodDate" SortExpression="PeriodDate" Visible="False" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="CalYearMonth" HeaderText="CalYearMonth" SortExpression="CalYearMonth" Visible="False" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="ORDER_NUMBER" HeaderText="Order" SortExpression="Order" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="FinSalesAmount" HeaderText="Sales" SortExpression="FinSalesAmount" DataFormatString="{0:#,##0.00;(#,##0.00);0}" HtmlEncode="False" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="FinCostAmount" HeaderText="Cost" SortExpression="FinCostAmount" DataFormatString="{0:#,##0.00;(#,##0.00);0}" HtmlEncode="False" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="MaterialCost" HeaderText="Material Cost" SortExpression="MaterialCost" DataFormatString="{0:#,##0.00;(#,##0.00);0}" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="PurchaseCost" HeaderText="Purchase Cost" SortExpression="PurchaseCost" DataFormatString="{0:#,##0.00;(#,##0.00);0}" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="LaborCost" HeaderText="Labor Cost" SortExpression="LaborCost" DataFormatString="{0:#,##0.00;(#,##0.00);0}" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="SubContractCost" HeaderText="SubContract Cost" SortExpression="SubContractCost" DataFormatString="{0:#,##0.00;(#,##0.00);0}" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="TotalCost" HeaderText="Total Cost" SortExpression="TotalCost" DataFormatString="{0:#,##0.00;(#,##0.00);0}" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="StockTransferCost" HeaderText="Stock Transfer" SortExpression="StockTransferCost" DataFormatString="{0:#,##0.00;(#,##0.00);0}" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>

