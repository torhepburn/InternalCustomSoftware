<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MRBweb._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>MRB-MRW Viewer</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div>
        <asp:GridView 
            ID="GridView1" 
            runat="server" 
            AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource1"
            Style="z-index: 100; left: 0px; position: absolute; top: 72px; font-size: 10pt; font-family: Arial;" 
            AllowSorting="True" 
            Width="808px" OnRowDataBound="GridView1_RowDataBound" 
            >
            <Columns>
                <asp:BoundField DataField="NAME" HeaderText="NAME" SortExpression="NAME" />
                <asp:BoundField DataField="ITEM_CODE" HeaderText="ITEM_CODE" SortExpression="ITEM_CODE" />
                <asp:BoundField DataField="ITEM_DESCRIPTION" HeaderText="ITEM_DESCRIPTION" SortExpression="ITEM_DESCRIPTION" />
                <asp:BoundField DataField="WAREHOUSE" HeaderText="WAREHOUSE" SortExpression="WAREHOUSE" />
                <asp:BoundField DataField="LAST_TRN_DATE_STK_OM_HAND" HeaderText="LAST TXN STK OH"
                    SortExpression="LAST_TRN_DATE_STK_OM_HAND" />
                <asp:BoundField DataField="STOCK_ON_HAND" HeaderText="OH" SortExpression="STOCK_ON_HAND" />
                <asp:BoundField DataField="ALLOCATED_STOCK" HeaderText="ALC" SortExpression="ALLOCATED_STOCK" />
                <asp:BoundField DataField="BLOCKED_STOCK" HeaderText="BLK" SortExpression="BLOCKED_STOCK" />
                <asp:BoundField DataField="NON_NETTABLE_STOCK_QUANTITY" HeaderText="N_NET"
                    SortExpression="NON_NETTABLE_STOCK_QUANTITY" />
                <asp:BoundField DataField="VALUE" HeaderText="VALUE" SortExpression="VALUE" />
                <asp:BoundField DataField="STANDARD_COST_PRICE" HeaderText="UNIT COST"
                    SortExpression="STANDARD_COST_PRICE" />
            </Columns>
            <AlternatingRowStyle BackColor="#FFFF80" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="select e.name,w.item_code, w.item_description, w.warehouse, w.last_trn_date_stk_om_hand, w.stock_on_hand, w.allocated_stock, w.blocked_stock, w.non_nettable_stock_quantity,(w.stock_on_hand * d.standard_cost_price) as Value, d.standard_cost_price from views200.item_data_by_warehouse w left join views200.item_data d on w.item_code = d.item_code left join views200.employees e on d.planner_code = e.employee where (w.warehouse like '%MR%' or w.warehouse like '%45') and w.stock_on_hand !=0 order by e.name">
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
