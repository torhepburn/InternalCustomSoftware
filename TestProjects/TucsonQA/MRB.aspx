<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MRB.aspx.cs" Inherits="TucsonQA.MRB" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>MRB Page</title>
    <style type="text/css" >
    h2
    {
        position:relative;
        left:50px;
        top:900px;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1><span style="color: #cc0099">ZOS MRB</span></h1>
            
                <rsweb:ReportViewer 
                    ID="ReportViewer1" 
                    runat="server" 
                    Style="z-index: 100; left: 16px;
                    position: absolute; top: 96px" 
                    Font-Names="Verdana" 
                    Font-Size="8pt" 
                    Height="280px" 
                    Width="100%">
                    <LocalReport ReportPath="DispositionAge Table.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="AccessDataSource1" Name="FAST_Analysis_mdb" />
                        </DataSources>
                    </LocalReport>
            </rsweb:ReportViewer>
        <asp:AccessDataSource 
            ID="AccessDataSource1" 
            runat="server"
            DataFile="~/App_Data/FAST_Analysis.mdb"
            SelectCommand="SELECT *, MONTH(DateCreated) AS MTH, YEAR(DateCreated) AS YR FROM FAST_Disposition_Open_Aging_Query_ZOS WHERE (DateCreated> Now() -183)"
            ></asp:AccessDataSource>
        <rsweb:ReportViewer 
            ID="ReportViewer2" 
            runat="server" 
            Style="z-index: 102; left: 16px;
            position: absolute; top: 408px" 
            Font-Names="Verdana" 
            Font-Size="8pt" 
            Height="400px" 
            Width="100%">
            <LocalReport ReportPath="DispositionAge.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="AccessDataSource1" Name="FAST_Analysis_mdb" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
      <h2><a href="Default.aspx">Back to Home Page</a></h2>  
                

    </div>
    </form>
</body>
</html>
