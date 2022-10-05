<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InspectionMetrics.aspx.cs" Inherits="TucsonQA.QualityBacklog" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Inspection Metrics</title>
    <style type ="text/css">
    table
    {
       font-family: Arial; 
       font-size:12pt;
       font-weight:bold;
       width:100%;
       padding:10px;
       background-color:khaki;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            <span style="color: #ff00ff">&nbsp;Inspection Metrics</span>
        </h1>
        
        <asp:GridView 
            ID="GridView1" 
            runat="server" 
            Style="z-index: 100; left: 8px; position: absolute;
            top: 120px" 
            OnRowDataBound="GridView1_RowDataBound">
            <%--<Columns>
                <asp:TemplateField HeaderText="Get Record">
                  <ItemTemplate>
                    <asp:HyperLink
                        runat="server" 
                        ID="HL_record" 
                        Target="_blank"
                    />
                    <asp:Label
                        runat="server" 
                        Visible="false" 
                        ID="lbl_record" 
                        Text='<% DataBinder.Eval(Container.DataItem, "mklink")%>' 
                    />
                  </ItemTemplate>
                </asp:TemplateField>
            </Columns>--%>
        </asp:GridView>
        <asp:Label ID="Label1" runat="server" BackColor="#8080FF" Font-Names="Arial" Font-Size="X-Large"
            Style="z-index: 101; left: 136px; position: absolute; top: 72px" Text="Items in QC over 30 workdays before being inspected (Trailing 6 Months)"></asp:Label>
        <asp:GridView ID="GridView2" runat="server" Style="z-index: 102; left: 8px; position: absolute;
            top: 376px">
        </asp:GridView>
        <asp:Label ID="Label2" runat="server" BackColor="DarkKhaki" Font-Names="Arial" Font-Size="X-Large"
            Style="z-index: 104; left: 120px; position: absolute; top: 328px" Text="Average Number of Days Items Spent in QC being Inspected"></asp:Label>
    
    </div>
    </form>
</body>
</html>
