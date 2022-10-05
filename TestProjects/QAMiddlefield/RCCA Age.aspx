<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RCCA Age.aspx.cs" Inherits="RCCA_Age" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Days Overdue</title>
</head>
<body>
    <form id="form1" runat="server">
        <rsweb:reportviewer 
            id="ReportViewer1" 
            runat="server" 
            font-names="Verdana" 
            font-size="8pt"
            height="400px" 
            width="95%">
<LocalReport ReportPath="RCCA Age.rdlc" EnableHyperlinks="true">
    <DataSources>
        <rsweb:ReportDataSource 
            DataSourceId="AccessDataSource1" 
            Name="DataSet1" />
    </DataSources>
</LocalReport>
</rsweb:reportviewer>
        <asp:AccessDataSource 
            ID="AccessDataSource1" 
            runat="server" 
            DataFile="~/App_Data/FAST_Analysis.mdb"
            SelectCommand="Select *, (Now() - DateDue) As DaysOpen&#13;&#10;From dbo_VIEW_FAST_RCCArqd_Query&#13;&#10;Where MK_Company_ID = 200 And Status = 'Open'&#13;&#10;">
        </asp:AccessDataSource>
        <br />
        <br />
        <a href="Default.aspx">Back to Home Page</a>
    </form>
</body>
</html>
