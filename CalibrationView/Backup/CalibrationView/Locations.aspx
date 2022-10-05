<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Locations.aspx.cs" Inherits="CalibrationView.Locations" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Locations</title>
    <script>
        function changeScreenSize(w,h)
        {
            window.resizeTo(w,h)
        }
    </script>
</head>
<body onload="changeScreenSize(475, 500)">
    <form id="form1" runat="server">
    <div style="text-align:left; 
                           font-family:Arial; 
                           color:black; 
                           font-size:large; 
                           "
                           >
        
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
            DataKeyNames="l_id" DataSourceID="SqlDataSource1" Style="z-index: 100; left: 0px;
            position: absolute; top: 0px" BackColor="#FFFF80">
            <Columns>
                <asp:BoundField DataField="l_id" HeaderText="ID" ReadOnly="True" SortExpression="l_id" />
                <asp:BoundField DataField="l_description" HeaderText="Description" SortExpression="l_description" />
            </Columns>
            <AlternatingRowStyle BackColor="#FFC080" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CalibrationConnectionString %>"
            SelectCommand="Select l_id , l_description from location where l_id like 'zams%'">
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
