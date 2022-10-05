<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridTableR00.aspx.cs" Inherits="MRBweb.GridTable" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>MRB MRW FAST</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView 
            ID="GridView1" 
            runat="server" 
            Style="z-index: 100; left: 16px; position: absolute;
            top: 32px" 
            OnRowDataBound="GridView1_RowDataBound"
            Width="808px"> 
            <Columns>
               <asp:TemplateField HeaderText="FAST">
                <ItemTemplate>
                
                    <asp:HyperLink 
                        runat="server" 
                        ID="HL_FastID" 
                        Target="_blank"
                         
                         />

                    <asp:Label 
                        runat="server" 
                        Visible="false" 
                        ID="lbl_FastID" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "FastID") %>' 
                    />
                    
                </ItemTemplate>
               </asp:TemplateField> 
            </Columns>
            
            
        </asp:GridView>
        
    
    </div>
    </form>
</body>
</html>
