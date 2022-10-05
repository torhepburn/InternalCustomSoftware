<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="PrjTot_GeneralCosts.aspx.vb" Inherits="ProjectTotal_Dir_PrjTot_GeneralCosts" title="General Costs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetDataBy_tabGeneralProjectCosts_Proj" TypeName="ProjectTotalTableAdapters.tabGeneralProjectCostsTableAdapter">
        <SelectParameters>
            <asp:SessionParameter Name="PROJECT" SessionField="strProject" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <h3>
        General Costs for Project 
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </h3>       
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" PageSize="25" Style="position: relative">
        <Columns>
            <asp:BoundField DataField="SRNO" HeaderText="SRNO" SortExpression="SRNO">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="DESCRIPTION" HeaderText="Description" SortExpression="DESCRIPTION">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="DOCUMENT_NUMBER" HeaderText="Doc No" SortExpression="DOCUMENT_NUMBER">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="TRANSACTION_DATE" DataFormatString="{0:MM/dd/yy}" HeaderText="Trans Date"
                SortExpression="TRANSACTION_DATE">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="COST_PRICE_COMPONENT" HeaderText="CPC" SortExpression="COST_PRICE_COMPONENT">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="CostPriceDesc" HeaderText="Cost Price Component" SortExpression="CostPriceDesc">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="NUMBER_OF_UNITS" DataFormatString="{0:#,##0.0;(#,##0.0);0}"
                HeaderText="Units" SortExpression="NUMBER_OF_UNITS">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="AMOUNT" DataFormatString="{0:#,##0.00;(#,##0.00);0}" HeaderText="Amount"
                SortExpression="AMOUNT">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>

