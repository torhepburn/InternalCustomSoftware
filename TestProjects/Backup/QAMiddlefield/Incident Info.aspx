<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Incident Info.aspx.cs" Inherits="Incident_Info" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Incident and Service Log</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-weight: bold; font-size: 18pt; color: blue; font-family: Tahoma">
        Open Incidents Ready to Close<br />
        <br />
        <rsweb:reportviewer 
            id="ReportViewer1" 
            runat="server" 
            font-names="Verdana" 
            font-size="8pt"
            height="400px" 
            width="1000px">
          <LocalReport ReportPath="Incidents Ready for Signature.rdlc" EnableHyperlinks="true">
            <DataSources>
	          <rsweb:ReportDataSource 
	            Name="DataSet1" 
	            DataSourceId="SqlDataSource1">
	          </rsweb:ReportDataSource>
	          <rsweb:ReportDataSource 
	            Name="DataSet3" 
	            DataSourceId="SqlDataSource1">
	          </rsweb:ReportDataSource>
            </DataSources>
          </LocalReport>
        </rsweb:reportviewer>
    
    </div>
        <asp:SqlDataSource 
            ID="SqlDataSource1" 
            runat="server" 
            ConnectionString="<%$ ConnectionStrings:DashboardConnectionString %>"
            SelectCommand="SELECT dbo.VIEW_Incidents.IncidentID, dbo.VIEW_Incidents.ProductLineName, dbo.VIEW_Incidents.Status, dbo.VIEW_Incidents.ResponsibleSupportName, dbo.VIEW_Incidents.CustomerName, dbo.VIEW_Incidents.TotalOpenRMAs, &#13;&#10;        dbo.VIEW_Incidents.TotalOpenServices, dbo.VIEW_Incidents.IncidentStatus, dbo.VIEW_Services.IncidentID AS Expr1, dbo.VIEW_Services.ServiceLogID, dbo.VIEW_Services.ServiceLogStatus&#13;&#10;FROM dbo.VIEW_Incidents, dbo.VIEW_Services&#13;&#10;WHERE dbo.VIEW_Incidents.IncidentID = dbo.VIEW_Services.IncidentID AND (dbo.VIEW_Incidents.IncidentStatus = 'open') AND (dbo.VIEW_Incidents.TotalOpenRMAs IS NULL) AND (dbo.VIEW_Incidents.TotalOpenServices IS NULL) AND &#13;&#10;        (NOT (dbo.VIEW_Services.ServiceLogStatus = 'Cancelled'))&#13;&#10;ORDER BY dbo.VIEW_Incidents.TotalOpenServices, dbo.VIEW_Incidents.TotalOpenRMAs">
        </asp:SqlDataSource>
        <br />
        <rsweb:reportviewer id="ReportViewer2" runat="server" font-names="Verdana" font-size="8pt"
            height="400px" width="1200px">
<LocalReport ReportPath="Services Ready for Signature.rdlc" EnableHyperlinks="true"><DataSources>
<rsweb:ReportDataSource Name="DataSet1" DataSourceId="SqlDataSource2"></rsweb:ReportDataSource>
<rsweb:ReportDataSource Name="DataSet3" DataSourceId="SqlDataSource2"></rsweb:ReportDataSource>
</DataSources>
</LocalReport>
</rsweb:reportviewer>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DashboardConnectionString %>"
            SelectCommand="SELECT dbo.VIEW_Incidents.IncidentID, dbo.VIEW_Services.IncidentID AS Expr1, dbo.VIEW_Incidents.ProductLineName, dbo.VIEW_Services.PermanentSolution, dbo.VIEW_Services.RootCauseFound, dbo.VIEW_Services.MKDateInvoiced, dbo.VIEW_Services.BillingCode, &#13;&#10;        dbo.VIEW_Incidents.Status, dbo.VIEW_Incidents.ResponsibleSupportName, dbo.VIEW_Services.ServiceLogID, dbo.VIEW_Services.ServiceLogStatus, dbo.VIEW_Services.RepairOwnerName, dbo.VIEW_Services_Signoffs.ServiceLogID AS Expr2, &#13;&#10;        dbo.VIEW_Services_Signoffs.MFGRep, dbo.VIEW_Services_Signoffs.MfgRepName, dbo.VIEW_Services_Signoffs.ProductRep, dbo.VIEW_Services_Signoffs.ProducRepName, dbo.VIEW_Services_Signoffs.ProductRepDate, dbo.VIEW_Services_Signoffs.QualityRep, &#13;&#10;        dbo.VIEW_Services_Signoffs.QualityRepName, dbo.VIEW_Incidents.CustomerName, dbo.VIEW_Services.PartDescription&#13;&#10;FROM dbo.VIEW_Services_Signoffs, { oj dbo.VIEW_Services FULL OUTER JOIN&#13;&#10;        dbo.VIEW_Incidents ON dbo.VIEW_Services.IncidentID = dbo.VIEW_Incidents.IncidentID }&#13;&#10;WHERE dbo.VIEW_Services_Signoffs.ServiceLogID = dbo.VIEW_Services.ServiceLogID AND (dbo.VIEW_Incidents.ProductLineName = 'ZMI') AND (dbo.VIEW_Services.PermanentSolution IS NOT NULL) AND (dbo.VIEW_Services.RootCauseFound IS NOT NULL) AND &#13;&#10;        (dbo.VIEW_Services.MKDateInvoiced IS NOT NULL) AND (dbo.VIEW_Services.BillingCode <> 'Charge') AND (dbo.VIEW_Incidents.Status = 1) AND (dbo.VIEW_Services.ServiceLogStatus <> 'closed')&#13;&#10;">
        </asp:SqlDataSource>
        <br />
        <br />
        <a href="Default.aspx">Back to Home Page</a>
        
    </form>
</body>
</html>
