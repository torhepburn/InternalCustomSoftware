<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer Complaints.aspx.cs" Inherits="TucsonQA.Customer_Complaints" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Customer Complaints</title>
       <style type="text/css" >
    h2
    {
        position:relative;
        left:50px;
        top:150px;
    }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
      <h1>
            <span style="color: #ff00ff">ZOS Customer Complaints A3 Charts</span>
      </h1>
        <p>
            &nbsp;</p>
        <p>
            <rsweb:reportviewer 
                id="ReportViewer1" 
                runat="server" 
                style="z-index: 100; left: 40px;
                position: relative; top: 50px" 
                Font-Names="Verdana" 
                Font-Size="8pt" Height="400px" 
                Width="80%">
                <LocalReport ReportPath="CustomerComplaints.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource 
                            DataSourceId="SqlDataSource1" 
                            Name="Dashboard" />
                    </DataSources>
                </LocalReport>
            </rsweb:reportviewer>
            
            <asp:SqlDataSource 
                ID="SqlDataSource1" 
                runat="server" 
                ConnectionString="<%$ ConnectionStrings:DashboardConnectionString %>"
                SelectCommand="SELECT * FROM [VIEW_Incidents] WHERE (DaysSinceOpened < 180) AND (IncidentType LIKE 'complaint') AND (MK_Company_ID = 600)"></asp:SqlDataSource>
            
            <rsweb:ReportViewer ID="ReportViewer2" runat="server" Font-Names="Verdana" Font-Size="8pt"
                Height="400px" Style="z-index: 102; left: 40px; position: relative; top: 100px"
                Width="100%">
                <LocalReport ReportPath="Customer Complaints.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="Dashboard" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
    </div>
    <h2><a href="Default.aspx">Back to Home Page</a></h2>   
    </form>
</body>
</html>
