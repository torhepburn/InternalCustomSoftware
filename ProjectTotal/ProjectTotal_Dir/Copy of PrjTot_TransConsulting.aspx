<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Copy of PrjTot_TransConsulting.aspx.vb" Inherits="ProjectTotal_Dir_PrjTot_TransConsulting" title="Consulting Charges" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetDataBy_Proj_CPC"  TypeName="ProjectTotalTableAdapters.tabFinProjTransactionsTableAdapter">
        <SelectParameters>
            <asp:SessionParameter Name="PROJECT" SessionField="strProject" Type="String" />
            <asp:QueryStringParameter DefaultValue="%" Name="COST_PRICE_COMPONENT" QueryStringField="CPC"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
     <h3>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </h3>      
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" PageSize="25" Style="position: relative; left: 37px; top: 5px;">
        <Columns>
            <asp:BoundField DataField="PROJECT" HeaderText="PROJECT" SortExpression="PROJECT"
                Visible="False">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="FINANCIAL_PERIOD" HeaderText="Fin Period" SortExpression="FINANCIAL_PERIOD">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="COST_PRICE_COMPONENT" HeaderText="CPC" SortExpression="COST_PRICE_COMPONENT">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="ORDER_NUMBER" HeaderText="Order" SortExpression="ORDER_NUMBER">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="POSITION" HeaderText="POS" SortExpression="POSITION">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="TRANSACTION_TYPE" HeaderText="TRANSACTION_TYPE" SortExpression="TRANSACTION_TYPE"
                Visible="False">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="TRANSACTION_DATE" DataFormatString="{0:MM/dd/yy}" HeaderText="Trans Date"
                SortExpression="TRANSACTION_DATE">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="AMOUNT" DataFormatString="{0:#,##0.00;(#,##0.00);0}" HeaderText="Amount"
                SortExpression="AMOUNT">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="SupplierName" HeaderText="Supplier" SortExpression="SupplierName" ReadOnly="True">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>

