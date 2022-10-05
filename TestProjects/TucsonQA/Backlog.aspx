<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Backlog.aspx.cs" Inherits="Backlog" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Quality Backlog</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            <span style="color: #ff00ff">ZOS Quality Backlog A3 Charts</span>
        </h1>
        &nbsp;
        
    
    </div>
        &nbsp;
        <asp:GridView ID="GridView1" runat="server" Style="z-index: 100; left: 40px; position: absolute;
            top: 104px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        </asp:GridView>
        <br />
        <br />
        <br />
        <h2>
        &nbsp;</h2>
        <rsweb:reportviewer id="ReportViewer2" 
                            runat="server" 
                            font-names="Verdana"
                            font-size="8pt" 
                            height="400px" 
                            width="859px" 
                            ShowFindControls="False" 
                            ShowPageNavigationControls="False">
            <LocalReport ReportPath="Backlog Pareto.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource2" Name="BackLogData" />
                </DataSources>
            </LocalReport>
        </rsweb:reportviewer>
        
        <asp:SqlDataSource ID="SqlDataSource2" 
                           runat="server" 
                           ConnectionString="<%$ ConnectionStrings:DashboardConnectionString %>"
                           SelectCommand="SELECT MKReceiptTransactionID, DockDate, DaysToClose, ApprovedDate, OperatorName, month(DockDate) as Month, year(DockDate) as Year, 10 AS target FROM Dashboard.dbo.Tracker_ExcelDump WHERE ((OperatorName = 'Randall, Robin') OR (OperatorName = 'Hakey, Jeanne')) and (month(ApprovedDate) = month(getdate()-28)) and (year(ApprovedDate) > 2008) and (DaysToClose>14)&#13;&#10;ORDER BY Month&#13;&#10;" >
        </asp:SqlDataSource>
        
        <a href="Default.aspx">Back to Home Page</a>
    </form>
</body>
</html>
