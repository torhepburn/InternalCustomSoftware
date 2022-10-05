<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FAST-MRB.aspx.cs" Inherits="MRBweb.FAST_MRB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>MRB-MRW-FAST</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView 
            ID="GridView1" 
            runat="server" 
            OnRowDataBound="GridView1_RowDataBound"
            Style="z-index: 100; left: 0px; position: absolute; top: 0px" Width="100pc">
            <Columns>
                <asp:TemplateField HeaderText="FAST">
                    <ItemTemplate>
                        <asp:HyperLink ID="HL_FastID" runat="server" Target="_blank"></asp:HyperLink>
                        <asp:Label ID="lbl_FastID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FastID") %>'
                            Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        &nbsp;
        </div>
    </form>
</body>
</html>
