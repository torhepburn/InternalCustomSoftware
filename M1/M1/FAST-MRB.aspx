<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FAST-MRB.aspx.cs" Inherits="M1.FASTinv" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FAST-MRB</title>
</head>
<body>
    <form id="form1" runat="server">
      <div>
        
        <table>
            <tr>
                <td>
                    <asp:Button ID="BbExcel" runat="server" Text="Export to Excel" OnClick="BbExcel_Click" />                
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView 
            ID="GridView1" 
            runat="server" 
            OnRowDataBound="GridView1_RowDataBound"
            Style="z-index: 100; left: 0px; position: relative; top: 0px" Width="100pc">
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
        

                </td>

            </tr>
        </table>
        
      </div>
    </form>
</body>
</html>
