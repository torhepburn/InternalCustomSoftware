<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rooms.aspx.cs" Inherits="CalibrationView.Room" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:left; 
                           font-family:Arial; 
                           color:black; 
                           font-size:large; 
                           "
                           >
        <asp:GridView 
            ID="GridView1" 
            runat="server" 
            AllowSorting="True" 
            AutoGenerateColumns="False"
            BackColor="#C0FFC0" 
            DataSourceID="SqlDataSource1" 
            Style="z-index: 100;
            left: 0px; position: absolute; top: 0px">
            <Columns>
                <asp:BoundField DataField="r_roomnumber" HeaderText="Room Number" SortExpression="r_roomnumber" />
                <asp:BoundField DataField="r_description" HeaderText="Description" SortExpression="r_description" />
            </Columns>
            <AlternatingRowStyle BackColor="#FFC080" />
        </asp:GridView>
        <asp:SqlDataSource 
            ID="SqlDataSource1" 
            runat="server" 
            ConnectionString="<%$ ConnectionStrings:CalibrationConnectionString %>" 
            SelectCommand="select r_roomnumber, r_description from room where r_roomnumber like 'zams%' order by r_roomnumber">
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
