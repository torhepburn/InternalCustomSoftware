<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="PrjTot_StockTransactions_ByProject.aspx.vb" Inherits="ProjectTotal_Dir_PrjTot_StockTransactions_ByProject" title="Stock Transfers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetDataBy_StockTransactions_ToProject" TypeName="ProjectTotalTableAdapters.tabProjectStockTransactionsTableAdapter">
        <SelectParameters>
            <asp:SessionParameter Name="TARGET_PROJECT" SessionField="strProject" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <h3>
        Stock Transfers Into Project  
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <table  border=1 style="position: relative;left: 273px; top: -18px;" >
            <tr>
                <td class="tableSmall" align="right">
                    $XFer To Project:
                </td>
                <td style="height: 18px">
                    <asp:Label ID="TotalIntoProject" runat="server" Style="position: relative" Text="Label"
                    Width="92px" BorderStyle="None" CssClass="GridPropertyValueMoney"></asp:Label>                  
                </td>
            </tr>
            <tr>
                <td class="tableSmall" align="right">
                    $XFer From Project:
                </td>
                <td>
                    <asp:Label ID="TotalFromProject" runat="server" Style="position: relative" Text="Label"
                    Width="92px" BorderStyle="None" CssClass="GridPropertyValueMoney"></asp:Label>                  
                </td>
           </tr>
           <tr>
                <td class="tableSmall" align="right">
                    NET $XFer:
                </td>
                <td>
                    <asp:Label ID="TotalAmount" runat="server" Style="position: relative" Text="Label"
                    Width="92px" BorderStyle="None" CssClass="GridPropertyValueMoney"></asp:Label>                  
                </td>                
            </tr>
        </table>     


    </h3>  
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" PageSize="15" Style="position: relative">
        <Columns>
            <asp:BoundField DataField="PROJECT" HeaderText="From Proj" SortExpression="PROJECT">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="WAREHOUSE_ORDER" HeaderText="Order" SortExpression="WAREHOUSE_ORDER">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="CUSTOM_ITEM" HeaderText="Item" SortExpression="CUSTOM_ITEM">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="CUSTOM_ITEM_DESCRIPTION" HeaderText="Description" SortExpression="CUSTOM_ITEM_DESCRIPTION">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="LinkProject" HeaderText="To Project" SortExpression="LinkProject">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="DELIVERED_QTY" DataFormatString="{0:#,##0;(#,##0);0}"
                HeaderText="Qty" HtmlEncode="False" SortExpression="DELIVERED_QTY">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="USER_TRANS_ENTERED" HeaderText="User" SortExpression="USER_TRANS_ENTERED">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="Stock_Transer_Cost" DataFormatString="{0:#,##0.00;(#,##0.00);0}"
                HeaderText="Amount" HtmlEncode="False" SortExpression="Stock_Transer_Cost">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="TRANS_DATE" DataFormatString="{0:MM/dd/yy}" HeaderText="Trans Date"
                SortExpression="TRANS_DATE">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetDataBy_StockTransactions_From_Project" TypeName="ProjectTotalTableAdapters.tabProjectStockTransactionsTableAdapter">
        <SelectParameters>
            <asp:SessionParameter Name="PROJECT" SessionField="strProject" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <h3>
        Stock Transfers Out of Project  
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    </h3>       
    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataSourceID="ObjectDataSource2" Style="position: relative">
        <Columns>
            <asp:BoundField DataField="PROJECT" HeaderText="From Proj" SortExpression="PROJECT">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="WAREHOUSE_ORDER" HeaderText="Order" SortExpression="WAREHOUSE_ORDER">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="CUSTOM_ITEM" HeaderText="Item" SortExpression="CUSTOM_ITEM">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="CUSTOM_ITEM_DESCRIPTION" HeaderText="Description" SortExpression="CUSTOM_ITEM_DESCRIPTION">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="LinkProject" HeaderText="To Project" SortExpression="LinkProject">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="DELIVERED_QTY" HeaderText="Qty" SortExpression="DELIVERED_QTY">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="USER_TRANS_ENTERED" HeaderText="User" SortExpression="USER_TRANS_ENTERED">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="Stock_Transer_Cost" HeaderText="Amount" SortExpression="Stock_Transer_Cost">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="TRANS_DATE" DataFormatString="{0:MM/dd/yy}" HeaderText="Trans Date"
                SortExpression="TRANS_DATE">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>

