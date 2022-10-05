<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="PrjTot_LaborDetail.aspx.vb" Inherits="ProjectTotal_Dir_PrjTot_LaborDetail" title="Labor Hour Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetDataBy_tabProjectLaborHrsSummary_ProjectPeriod" TypeName="ProjectTotalTableAdapters.tabProjectLaborHrsSummaryTableAdapter">
        <SelectParameters>
            <asp:QueryStringParameter Name="PROJECT" QueryStringField="Project" Type="String" />
            <asp:QueryStringParameter Name="FINANCIAL_PERIOD" QueryStringField="Financial_Period"
                Type="Decimal" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <h3>
        Labor Hour Details for Project 
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </h3>    
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" Style="position: relative" PageSize="40">
        <Columns>
            <asp:BoundField DataField="PROJECT" HeaderText="PROJECT" SortExpression="PROJECT" Visible="False" />
            <asp:BoundField DataField="FINANCIAL_PERIOD" HeaderText="FINANCIAL_PERIOD" SortExpression="FINANCIAL_PERIOD" Visible="False" />
            <asp:BoundField DataField="ORDER_TYPE" HeaderText="ORDER_TYPE" SortExpression="ORDER_TYPE" Visible="False" />
            <asp:BoundField DataField="COST_TYPE" HeaderText="COST_TYPE" SortExpression="COST_TYPE" Visible="False" />
            <asp:BoundField DataField="COST_PRICE_COMPONENT" HeaderText="Cost Price Component"
                SortExpression="COST_PRICE_COMPONENT" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="CostPriceDesc" HeaderText="CPC Description" SortExpression="CostPriceDesc" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="LaborHrs" HeaderText="Labor Hours" SortExpression="LaborHrs" DataFormatString="{0:#,##0.00;(#,##0.00);0}" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="SumOfAMOUNT" HeaderText="Amount" SortExpression="SumOfAMOUNT" DataFormatString="{0:#,##0.00;(#,##0.00);0}" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>

