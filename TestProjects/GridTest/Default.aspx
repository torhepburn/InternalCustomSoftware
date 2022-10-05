<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GridTest._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%--<asp:GridView 
            ID="GridView1" 
            runat="server" 
            style="z-index: 100; left: 136px; position: absolute; top: 96px">
            <Columns>
             <asp:TemplateField HeaderText="Click">
              <ItemTemplate>
               <asp:HyperLink 
                    runat="server" 
                    ID="HL_record" 
                    Target="_blank"
               />
               <asp:Label
                runat="server"
                Visible="true"
                ID="LBL_record"
                Text='<%# DataBinder.Eval(Container.DataItem, "MKReceipttransactionID") %>'
               />
              </ItemTemplate>
             </asp:TemplateField>
            </Columns>
        </asp:GridView>
    --%>
    </div>
    </form>
</body>
</html>
