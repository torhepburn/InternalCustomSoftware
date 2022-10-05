<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DTC.aspx.cs" Inherits="DTC" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>DTC</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp; &nbsp;&nbsp;
        <asp:AccessDataSource ID="AccessDataSource1" 
                              runat="server" 
                              DataFile="~/App_Data/DFT_DTC_DB.mdb" 
                              SelectCommand="SELECT * FROM [MonthlyDTC]">
        </asp:AccessDataSource>
        
        <rsweb:reportviewer 
        	id="ReportViewer1" 
        	runat="server" 
        	Font-Names="Verdana" 
        	Font-Size="8pt" Height="456px" 
        	Width="95%">
            <LocalReport 
            	ReportPath="DTC.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource 
                        DataSourceId="AccessDataSource1" 
                        Name="DTC" />
                </DataSources>
            </LocalReport>
        </rsweb:reportviewer>
        <br />
        <br />
        <a href="Default.aspx">Back to Home Page</a>
    </div>
    </form>
</body>
</html>
