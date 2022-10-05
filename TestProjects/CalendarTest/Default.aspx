<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CalendarTest._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Calendar 
            ID="Calendar1" 
            runat="server" 
            Style="z-index: 100; left: 0px; position: absolute;
            top: 0px" 
            Height="312px" 
            OnDayRender="Calendar1_DayRender" 
            OnVisibleMonthChanged="Calendar1_VisibleMonthChanged" 
            Width="744px">
        </asp:Calendar>
    
    </div>
    </form>
</body>
</html>
