<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TV.aspx.cs" Inherits="ToolView.TV" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView 
            ID="GridView" 
            runat="server" PageSize="15" 
            AutoGenerateColumns="False"
            DataSourceID="SqlDataSource1"
            Style="z-index: 101; position: absolute; top:700px" 
            AllowSorting="True" 
            AllowPaging="false" 
            OnPageIndexChanging="GridView_PageIndexChanging" 
            OnSorting="GridView_Sorting">
            <Columns>
                <asp:BoundField 
                    DataField="Due Date"
                    DataFormatString="{0:MM-dd-yyyy}"
                    HeaderText="Due Date" 
                    SortExpression="Due Date" >
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="Manufacturer" HeaderText="Manufacturer" SortExpression="Manufacturer" />
                <asp:BoundField DataField="SN" HeaderText="SN" SortExpression="SN" />
                <asp:BoundField DataField="MODEL" HeaderText="MODEL" SortExpression="MODEL" />
                <asp:BoundField DataField="SIZE" HeaderText="SIZE" SortExpression="SIZE" />
                <asp:BoundField DataField="TYPE" HeaderText="TYPE" SortExpression="TYPE" />
                <asp:BoundField DataField="Calibration Source" HeaderText="Calibration Source" SortExpression="Calibration Source" />
                <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:BoundField DataField="User" HeaderText="User" SortExpression="User" />
                <asp:BoundField DataField="Owner" HeaderText="Owner" SortExpression="Owner" />
                <asp:BoundField DataField="Owner Supervisor" HeaderText="Owner Supervisor" SortExpression="Owner Supervisor" />
            </Columns>
            <AlternatingRowStyle BackColor="#80FF80" />
        </asp:GridView>
        <asp:SqlDataSource 
            ID="SqlDataSource1" 
            runat="server" 
            ConnectionString="<%$ ConnectionStrings:ToolConnectionString %>">
            
        </asp:SqlDataSource>

    </div>
    </form>
</body>
</html>
