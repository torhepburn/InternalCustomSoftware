<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="PrjTot_LaborDetail_Project_CPC.aspx.vb" Inherits="ProjectTotal_Dir_PrjTot_LaborDetail_Project_CPC" title="Labor Details/Cost Price Component" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetDataBy_LaborSummary_Project_CPL" TypeName="ProjectTotalTableAdapters.tabProjectLaborHrsSummaryTableAdapter">
        <SelectParameters>
            <asp:SessionParameter Name="PROJECT" SessionField="strProject" Type="String" />
            <asp:QueryStringParameter Name="COST_PRICE_COMPONENT" QueryStringField="CPC" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <h3>
        Labor Hour Details by Cost Price Component for Project 
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </h3>       
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" PageSize="40" Style="position: relative">
        <Columns>
            <asp:BoundField DataField="PROJECT" HeaderText="PROJECT" SortExpression="PROJECT"
                Visible="False" />
            <asp:BoundField DataField="FINANCIAL_PERIOD" HeaderText="Financial Period" SortExpression="FINANCIAL_PERIOD">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="COST_PRICE_COMPONENT" HeaderText="Cost Price Component"
                SortExpression="COST_PRICE_COMPONENT">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="CostPriceDesc" HeaderText="CPC Description" SortExpression="CostPriceDesc">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="LaborHrs" DataFormatString="{0:#,##0.00;(#,##0.00);0}"
                HeaderText="Labor Hours" HtmlEncode="False" SortExpression="LaborHrs">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="SumOfAMOUNT" DataFormatString="{0:#,##0.00;(#,##0.00);0}"
                HeaderText="Amount" HtmlEncode="False" SortExpression="SumOfAMOUNT">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>

