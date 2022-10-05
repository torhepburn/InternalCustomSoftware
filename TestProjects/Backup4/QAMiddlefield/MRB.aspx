<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MRB.aspx.cs" Inherits="MRB" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>MRB</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1 style="text-align: center">
            <span style="color: #ff00ff">MRB A3 Charts</span></h1>
        <p>
            <span style="color: #ff00ff"></span>&nbsp;</p>
        <p>
            <span style="color: #ff00ff">
                <rsweb:reportviewer 
                    id="ReportViewer1" 
                    runat="server" 
                    font-names="Verdana" 
                    font-size="8pt"
                    height="473px" 
                    width="95%" 
                    ZoomPercent="75" 
                    ShowFindControls="False" 
                    ShowPageNavigationControls="False">
<LocalReport ReportPath="MRB Value.rdlc"><DataSources>
    <rsweb:ReportDataSource DataSourceId="AccessDataSource1" Name="FastDataset" />
</DataSources>
</LocalReport>
</rsweb:reportviewer>
                <asp:AccessDataSource ID="AccessDataSource1" 
                                      runat="server" 
                                      OnSelecting="AccessDataSource1_Selecting" 
                                      DataFile="~/App_Data/FAST_Analysis.mdb" 
                                      SelectCommand="SELECT FastID, PartNumber, STANDARD_COST_PRICE, Value, DateCreated, Qty, FastOrigin&#13;&#10;FROM FAST_MRB_VALUE_Query&#13;&#10;WHERE (DateCreated < Now()) AND DateCreated > (Now()-365)&#13;&#10;">
                </asp:AccessDataSource>
            </span>
        </p>
        <p>
            <span style="color: #ff00ff"></span>&nbsp;</p>
        <h2>
            <span style="color: #ff00ff">Pareto </span>
        </h2>
        <p>
            <span style="color: #ff00ff">
                <rsweb:ReportViewer ID="ReportViewer2" 
                                    runat="server" 
                                    Font-Names="Verdana" 
                                    Font-Size="8pt"
                                    Height="473px" 
                                    Width="95%" 
                                    ZoomPercent="75" 
                                    ShowFindControls="False" 
                                    ShowPageNavigationControls="False">
                    <LocalReport ReportPath="PN Pareto.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource 
                                DataSourceId="AccessDataSource2" 
                                Name="FAST_Analysis_mdb" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                &nbsp; &nbsp;
                <asp:AccessDataSource ID="AccessDataSource2" 
                                      runat="server" 
                                      DataFile="~/App_Data/FAST_Analysis.mdb"
                    SelectCommand="SELECT DESCRIPTION, TotalPartValue, FastOrigin FROM (SELECT DESCRIPTION, SUM([Value]) AS TotalPartValue, FastOrigin FROM (SELECT DateCreated, DESCRIPTION, [Value], FastOrigin FROM FAST_MRB_VALUE_Query) WHERE (DateCreated < NOW()) AND (DateCreated > NOW() - 365) GROUP BY DESCRIPTION, FastOrigin) WHERE (TotalPartValue > 25000) ORDER BY TotalPartValue, FastOrigin">
                </asp:AccessDataSource>
            </span>
        </p>
        <br />
        <p>
            <span style="color: #ff00ff">&nbsp;<rsweb:ReportViewer ID="ReportViewer3" runat="server" Font-Names="Verdana" Font-Size="8pt"
                    Height="473px" Width="926px" ZoomPercent="75" ShowFindControls="False" ShowPageNavigationControls="False">
                <LocalReport ReportPath="PN Pareto2.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource 
                            DataSourceId="AccessDataSource3" 
                            Name="FAST_Analysis_mdb" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
                &nbsp;
                <asp:AccessDataSource 
                    ID="AccessDataSource3" 
                	runat="server" 
                	DataFile="~/App_Data/FAST_Analysis.mdb"
                    SelectCommand="SELECT DESCRIPTION, TotalPartValue, FastOrigin FROM (SELECT DESCRIPTION, SUM([Value]) AS TotalPartValue, FastOrigin FROM (SELECT DateCreated, DESCRIPTION, [Value], FastOrigin FROM FAST_MRB_VALUE_Query) WHERE  (Month(DateCreated) = Month(now()-28) ) AND (Year(DateCreated) = 2011 OR Year(DateCreated)=2010)  GROUP BY DESCRIPTION, FastOrigin) WHERE (TotalPartValue > 2500) ORDER BY TotalPartValue, FastOrigin">
                </asp:AccessDataSource>
            </span>
        </p>
        <p>
            <span style="color: #ff00ff"><a href="Default.aspx">Back to Home Page</a> </span>
        </p>
    
    </div>
    </form>
</body>
</html>
