<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="PrjTot_TransConsultingWithLeftOuter.aspx.vb" Inherits="ProjectTotal_Dir_PrjTot_TransConsultingNEW" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    &nbsp;<asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetData_Proj_CPC_IncludePurchaseOrder" TypeName="ProjectTotalTableAdapters.tabFinProjTransactionsTableAdapter">
        <SelectParameters>
            <asp:SessionParameter Name="PROJECT" SessionField="strProject" Type="String" />
            <asp:QueryStringParameter DefaultValue="%" Name="COST_PRICE_COMPONENT" QueryStringField="CPC"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataSourceID="ObjectDataSource2" Style="position: relative">
        <Columns>
            <asp:BoundField DataField="PROJECT" HeaderText="PROJECT" SortExpression="PROJECT" />
            <asp:BoundField DataField="COST_PRICE_COMPONENT" HeaderText="COST_PRICE_COMPONENT"
                SortExpression="COST_PRICE_COMPONENT" />
            <asp:BoundField DataField="FINANCIAL_PERIOD" HeaderText="FINANCIAL_PERIOD" SortExpression="FINANCIAL_PERIOD" />
            <asp:BoundField DataField="ORDER_NUMBER" HeaderText="ORDER_NUMBER" SortExpression="ORDER_NUMBER" />
            <asp:BoundField DataField="POSITION" HeaderText="POSITION" SortExpression="POSITION" />
            <asp:BoundField DataField="TRANSACTION_TYPE" HeaderText="TRANSACTION_TYPE" SortExpression="TRANSACTION_TYPE" />
            <asp:BoundField DataField="TRANSACTION_DATE" HeaderText="TRANSACTION_DATE" SortExpression="TRANSACTION_DATE" />
            <asp:BoundField DataField="AMOUNT" HeaderText="AMOUNT" SortExpression="AMOUNT" />
            <asp:BoundField DataField="SupplierName" HeaderText="SupplierName" ReadOnly="True"
                SortExpression="SupplierName" />
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>

