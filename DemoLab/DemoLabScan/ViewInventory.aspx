<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewInventory.aspx.cs" Inherits="DemoLabScan.ViewInventory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <style type ="text/css">
    table
    {
       font-family: Arial; 
       font-size:14pt;
       font-weight:bold;
       width:100%;
       padding:10px;
       background-color:bisque;
    }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td><a href="http://midprj01/demolab/demo.aspx">Link to Scanning Page</a></td>

            </tr>

        </table>
    
    </div>
        <asp:GridView ID="GridView1" 
                        runat="server" 
                        AutoGenerateColumns="True" 
                        DataKeyNames="ID" 
                        AllowSorting="true"
                        DataSourceID="SqlDataSource1">
            <%--<Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="SN" HeaderText="SN" SortExpression="SN" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="WhenTaken" HeaderText="WhenTaken" SortExpression="CapAssetNumber" />
                <asp:BoundField DataField="WorkCenter" HeaderText="WorkCenter" SortExpression="WorkCenter" />--%>
        </asp:GridView>
        <asp:SqlDataSource 
            ID="SqlDataSource1" 
            runat="server" 
            ConnectionString="<%$ ConnectionStrings:DemoLabConnectionString %>" 
            SelectCommand="ItemStatus"
            SelectCommandType ="StoredProcedure">

        </asp:SqlDataSource>
    </form>
</body>
</html>
