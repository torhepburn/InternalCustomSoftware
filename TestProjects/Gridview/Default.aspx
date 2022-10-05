<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Gridview._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div>
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
            DataSourceID="SqlDataSource1" Style="z-index: 100; left: 152px; position: absolute;
            top: 144px">
            <Columns>
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="SN" HeaderText="SN" SortExpression="SN" />
                <asp:BoundField DataField="MANUF" HeaderText="MANUF" SortExpression="MANUF" />
                <asp:BoundField DataField="SIZE" HeaderText="SIZE" SortExpression="SIZE" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CalibrationConnectionString %>"
            SelectCommand="SELECT [Description], [SN], [MANUF], [SIZE] FROM [Equipment]"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
