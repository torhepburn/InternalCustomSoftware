<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalibrationTest.aspx.cs" Inherits="TucsonQA.CalibrationTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style type ="text/css">
    table
    {
       font-family: Arial; 
       font-size:14pt;
       font-weight:bold;
       width:100%;
       padding:10px;
       background-color:darkseagreen;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
            DataSourceID="SqlDataSource1" Style="z-index: 100; left: 0px; position: absolute;
            top: 100px">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="TYPE" HeaderText="TYPE" SortExpression="TYPE" />
                <asp:BoundField DataField="SN" HeaderText="SN" SortExpression="SN" />
                <asp:BoundField DataField="MANUF" HeaderText="MANUF" SortExpression="MANUF" />
                <asp:BoundField DataField="Desc" HeaderText="Desc" SortExpression="Desc" />
                <asp:BoundField DataField="MODEL" HeaderText="MODEL" SortExpression="MODEL" />
                <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
                <asp:BoundField DataField="Owner" HeaderText="Owner" SortExpression="Owner" />
                <asp:BoundField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS" />
                <asp:BoundField 
                    DataField="CAL_DATE" 
                    DataFormatString="{0:MM-dd-yyyy}"
                    HeaderText="CAL DATE" 
                    SortExpression="CAL_DATE">
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField 
                    DataField="CAL_NEXT" 
                    DataFormatString="{0:MM-dd-yyyy}"
                    HeaderText="Cal Due" 
                    SortExpression="CAL_NEXT">
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CalibrationConnectionString %>"
            SelectCommand="SELECT * FROM [ArizonaOverdue]"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
