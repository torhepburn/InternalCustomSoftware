<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inspection Backlog.aspx.cs" Inherits="Backlog" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Quality Backlog</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>
            <span style="color: #ff00ff">Quality Backlog A3 Charts</span></h1>
        <rsweb:reportviewer id="ReportViewer1" 
                            runat="server" 
                            font-names="Verdana" 
                            font-size="8pt"
                            height="300px" 
                            width="95%" 
                            DocumentMapCollapsed="True" 
                            ShowDocumentMapButton="False" 
                            ShowFindControls="False" 
                            ShowPageNavigationControls="False" 
                            ZoomPercent="60">
            <LocalReport ReportPath="Backlog Trend2.rdlc"><DataSources>
                <rsweb:ReportDataSource DataSourceId="AccessDataSource1" Name="ReceiptsAwaitingApproval" />
                </DataSources>
            </LocalReport>
        </rsweb:reportviewer>
        
        <asp:AccessDataSource 
            ID="AccessDataSource1" 
            runat="server" 
            DataFile="~/App_Data/ReceiptsAwaitingApproval.mdb"
            SelectCommand="SELECT BacklogMonth, [AvgOf>29], [AvgOf<5], [AvgOf5>x>29]&#13;&#10;FROM  Backlog_by_Month_Query&#13;&#10;GROUP BY BacklogMonth, [AvgOf>29], [AvgOf<5], [AvgOf5>x>29]">
        </asp:AccessDataSource>
    
        <br />
        <br />
        <rsweb:reportviewer id="ReportViewer2" 
                            runat="server" 
                            font-names="Verdana"
                            font-size="8pt"
                            position="relative"
                            top="10px" 
                            height="300px" 
                            width="95%" 
                            ShowFindControls="False"
                            ShowPageNavigationControls="False">
<LocalReport ReportPath="Backlog by Days Mdfld.rdlc">
    <DataSources>
        <rsweb:ReportDataSource DataSourceId="AccessDataSource2" Name="ReceiptsAwaitingApproval" />
    </DataSources>
    
</LocalReport>
</rsweb:reportviewer>
        &nbsp;
        <asp:AccessDataSource 
            ID="AccessDataSource2" 
            runat="server" 
            DataFile="~/App_Data/ReceiptsAwaitingApproval.mdb"
            SelectCommand="SELECT * from webpagequery">
        </asp:AccessDataSource>
        <br />
        <br />
        <a href="Default.aspx">Back to Home Page</a>
    </form>
</body>
</html>
