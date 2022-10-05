<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectTotalDB.aspx.cs" Inherits="ProjectTotalDB._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Project Total Database</title>
     <style type ="text/css">
    div
    {
       font-family: Arial; 
       font-size:12pt;
       font-weight:bold;
       
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <Table ID="Table1" runat="server" Height="32px" Style="z-index: 107; left: 0px;
            position: absolute; top: 0px" Width="968px">
             <tr>
        <td colspan="3"
            style="text-align:center;
               font-family:Arial; 
               color:#003366; 
               background-color:#003366;">  "  "
        </td>
   </tr>
 
            
        </Table>
    
        
        <asp:TextBox ID="tbUserName" 
                     runat="server"
                     Style="z-index: 100; left: 376px; position: absolute;
            top: 144px">
            </asp:TextBox>
        <asp:TextBox ID="tbPassword" runat="server" Style="z-index: 101; left: 376px; position: absolute;
            top: 200px" TextMode="Password"></asp:TextBox>
        <asp:Button ID="bSubmit" runat="server" Style="z-index: 102; left: 384px; position: absolute;
            top: 280px" Text="Submit" Width="136px" OnClick="bSubmit_Click" />
        <asp:Label ID="LuserName" runat="server" Style="z-index: 103; left: 280px; position: absolute;
            top: 144px" Text="User Name"></asp:Label>
        <asp:Label ID="Lpassword" runat="server" Style="z-index: 104; left: 280px; position: absolute;
            top: 200px" Text="Password"></asp:Label>
        <asp:Label ID="LpageDirections" runat="server" Style="z-index: 105; left: 48px; position: absolute;
            top: 72px" Text="Please logon to enter the Project Total Database site."></asp:Label>
        <asp:Label ID="Lerror" runat="server" BackColor="Transparent" Style="z-index: 108; left: 304px;
            position: absolute; top: 352px" Text="Incorrect User Name or Password !!!!" Visible="False"
            Width="280px" ForeColor="Red"></asp:Label>
        
    </div>
    </form>
</body>
</html>
