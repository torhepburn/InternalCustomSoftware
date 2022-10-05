<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="C.aspx.cs" Inherits="AJAXEnabledWebApplication1.C" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        &nbsp;<div>
            &nbsp; &nbsp;</div>
    
        <div>        
            
        <asp:Panel 
            ID="Panel1" 
            runat="server" 
            Height="50px" 
            Style="border-right: black 1px solid;
                   border-top: black 1px solid; 
                   z-index: 105; 
                   left: -6px; 
                   border-left: black 1px solid;
                   border-bottom: black 1px solid; 
                   position: relative; 
                   top: 160px; 
                   background-color: yellow"
            Width="1000px" >
            <asp:Label ID="Label1" runat="server" Style="z-index: 100; left: 16px; position: absolute;
                top: 8px; font-weight: bold; font-size: 24pt; font-family: Arial;" Text="Info:" Width="96px"></asp:Label>
            
        </asp:Panel>
           
         <asp:ScriptManager ID="ScriptManager1" runat="server" />
    </div> 
        <asp:UpdatePanel 
            ID="UpdatePanel1" 
            runat="server"
            updatemode="Conditional">
          <ContentTemplate>
             <asp:Button 
                ID="Bscheduling" 
                runat="server" 
                Style="z-index: 104; 
                   left: 0px; 
                   position: relative;
                   top: -126px; 
                   font-weight: bold; 
                   font-family: Arial; 
                   background-color: aqua; 
                   border-right: black 1px solid; 
                   border-top: black 1px solid; 
                   border-left: black 1px solid; 
                   border-bottom: black 1px solid;" 
                Text="Sign Out Scheduling" 
                Height="35px" 
                Width="150px" 
                OnClick="Bscheduling_Click" />
             
             <asp:Button ID="Bquick" runat="server" Style="z-index: 100; left: 184px; position: absolute;
                    top: 40px" Text="Quick Sign Out" Height="35px" Width="150px" />
           </ContentTemplate>
        </asp:UpdatePanel>
        
        
   
    </form>
</body>
</html>
