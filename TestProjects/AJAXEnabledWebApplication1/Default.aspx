<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AJAXEnabledWebApplication1._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>UpdatePanel</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        
    <div>
        <asp:UpdatePanel 
            ID="UpdatePanel1" 
            runat="server"
            updatemode="Conditional">
          <ContentTemplate>
            <asp:Label runat="server" ID="DateTimeLabel2" />
            <asp:Button 
                runat="server" 
                ID = "UpdateButton2" 
                OnClick="UpdateButton_Click"
                text="Update" />
          </ContentTemplate>
        
        
        
        </asp:UpdatePanel>
    
    </div>
    </form>
</body>
</html>
