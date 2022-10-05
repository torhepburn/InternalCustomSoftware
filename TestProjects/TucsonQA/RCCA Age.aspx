<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RCCA Age.aspx.cs" Inherits="TucsonQA.RCCA_Age" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <rsweb:ReportViewer 
            ID="ReportViewer1" 
            runat="server" 
            Style="z-index: 100; left: 0px;
            position: relative; top: 0px" 
            Font-Names="Verdana" 
            Font-Size="8pt" 
            Height="400px" 
            Width="100%">
            <LocalReport ReportPath="RCCA Age.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource 
                        DataSourceId="AccessDataSource1" 
                        Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:AccessDataSource 
            ID="AccessDataSource1" 
            runat="server" 
            DataFile="~/App_Data/FAST_Analysis.mdb" 
            SelectCommand="SELECT *,(Now() - DateCreated) as DaysOpen FROM [dbo_VIEW_FAST_RCCArqd_Query] where MK_COmpany_ID=600 and Status='Open'">
        </asp:AccessDataSource>
    
    </div>
    
     &nbsp;
    <p>
    <a href="Default.aspx">Back to Home Page</a>
    </p>
    </form>
</body>
</html>
