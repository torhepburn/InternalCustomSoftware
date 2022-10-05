<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="PrjTot_BookedOrders.aspx.vb" Inherits="ProjectTotal_Dir_PrjTot_BookedOrders" title="Booked Orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetDataBy_BookedOrders" TypeName="ProjectTotalTableAdapters.tabProjectSalesOrderMasterTableAdapter">
        <SelectParameters>
            <asp:SessionParameter Name="PROJECT" SessionField="strProject" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <h3>
        Booked Orders for Project 
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </h3>     
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" PageSize="20" Style="position: relative">
        <Columns>
            <asp:BoundField DataField="NAME" HeaderText="Customer" SortExpression="NAME">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="ITEM_CODE" HeaderText="Item Code" SortExpression="ITEM_CODE">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="ORDER_NO" HeaderText="Order" SortExpression="ORDER_NO">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="POSITION" HeaderText="Pos" SortExpression="POSITION">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="ORDERED_QUANTITY" DataFormatString="{0:#,##0;(#,##0);0}"
                HeaderText="Qty Ord" SortExpression="ORDERED_QUANTITY">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="DELIVERED_QUANTITY" DataFormatString="{0:#,##0;(#,##0);0}"
                HeaderText="Qty Shp" SortExpression="DELIVERED_QUANTITY">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="ORDER_DATE" DataFormatString="{0:MM/dd/yy}" HeaderText="Order Date"
                SortExpression="ORDER_DATE">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="DELIVERY_DATE" DataFormatString="{0:MM/dd/yy}" HeaderText="Del. Date"
                SortExpression="DELIVERY_DATE">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="AMOUNT" DataFormatString="{0:#,##0.00;(#,##0.00);0}" HeaderText="Amount"
                HtmlEncode="False" SortExpression="AMOUNT">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>

