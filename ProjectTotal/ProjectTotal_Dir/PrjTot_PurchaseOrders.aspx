<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="PrjTot_PurchaseOrders.aspx.vb" Inherits="ProjectTotal_Dir_PrjTot_PurchaseOrders" title="Open Purchase Orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetDataBy_ProjPurchaseOrders_Project" TypeName="ProjectTotalTableAdapters.tabProjectPurchaseOrdersTableAdapter">
        <SelectParameters>
            <asp:SessionParameter Name="PROJECT" SessionField="strProject" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <h3>
        Open Purchase Orders for Project 
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </h3>     
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" Style="position: relative">
        <Columns>
            <asp:BoundField DataField="ORDER_NO" HeaderText="Order" SortExpression="ORDER_NO">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="POSITION" HeaderText="Pos" SortExpression="POSITION">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="NAME" HeaderText="Name" SortExpression="NAME">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="ITEM_CODE" HeaderText="Item Code" SortExpression="ITEM_CODE">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="QtyOrd" DataFormatString="{0:#,##0;(#,##0);0}" HeaderText="On Order"
                HtmlEncode="False" SortExpression="QtyOrd">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="QtyRecd" DataFormatString="{0:#,##0;(#,##0);0}" HeaderText="Qty Recd"
                HtmlEncode="False" SortExpression="QtyRecd">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="OrdAmt" DataFormatString="{0:#,##0.00;(#,##0.00);0}" HeaderText="Ext PO Cost"
                HtmlEncode="False" SortExpression="OrdAmt">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="Amount" DataFormatString="{0:#,##0.00;(#,##0.00);0}" HeaderText="Ext Recd"
                HtmlEncode="False" SortExpression="Amount">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="OrderDate" DataFormatString="{0:MM/dd/yy}" HeaderText="Order Date"
                SortExpression="OrderDate">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="DELIVERY_DATE_2" DataFormatString="{0:MM/dd/yy}" HeaderText="Planned Del"
                SortExpression="DELIVERY_DATE_2">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>

