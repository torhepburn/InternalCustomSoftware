<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimePartsSpentinQC.aspx.cs" Inherits="QAMiddlefield.TimePartsSpentinQC" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Time Parts Spend in QC</title>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
            <span style="color: #ff00ff">Time Parts Spent in QC</span></h1>
                <rsweb:ReportViewer ID="ReportViewer1" 
                                    runat="server" 
                                    Font-Names="Verdana" 
                                    Font-Size="8pt"
                                    Height="400px" 
                                    Style="z-index: 100; left: 8px; position: absolute; top: 80px"
                                    Width="95%">
                <LocalReport ReportPath="Backlog_200.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="MaintainApprovalHistory" Name="DataSet1" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
        <asp:SqlDataSource ID="MaintainApprovalHistory" runat="server" ConnectionString="<%$ ConnectionStrings:WebTablesConnectionString %>"
            SelectCommand="select * from backlogweb200"></asp:SqlDataSource>
                
                <rsweb:ReportViewer ID="ReportViewer2" runat="server" Font-Names="Verdana" Font-Size="8pt"
                    Height="400px" Style="z-index: 102; left: 40px; position: absolute; top: 512px"
                    Width="872px">
                    <LocalReport ReportPath="Backlog_200 pareto.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="DataSource1" Name="DataSet1" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
        <asp:SqlDataSource ID="DataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:WebTablesConnectionString %>"
            SelectCommand="Backlog200Pareto" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            
    
    </form>
</body>
</html>
