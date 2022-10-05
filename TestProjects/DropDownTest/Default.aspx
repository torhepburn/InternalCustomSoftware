<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DropDownTest._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div>
        <asp:DropDownList 
            ID="DropDownList1" 
            runat="server" 
            AutoPostBack="true"
            OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
            Style="z-index: 100; left: 88px; position: absolute; top: 136px" Visible="False">
            <asp:ListItem>Status</asp:ListItem>
            <asp:ListItem>Location</asp:ListItem>
            <asp:ListItem>Room</asp:ListItem>
            <asp:ListItem>Type</asp:ListItem>
            <asp:ListItem>Manufacturer</asp:ListItem>
            <asp:ListItem>User</asp:ListItem>
            <asp:ListItem>Owner</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox 
            ID="TextBox1" 
            runat="server" 
            AutoPostBack="true"
            Style="z-index: 101; left: 56px; position: absolute;
            top: 240px"></asp:TextBox>
        &nbsp; &nbsp;&nbsp;
        <asp:CheckBox 
            ID="CheckBox1" runat="server" AutoPostBack="true"
            OnCheckedChanged="CheckBox1_CheckedChanged"
            Style="z-index: 105; left: 216px; position: absolute; top: 136px" />
    
    </div>
    </form>
</body>
</html>
