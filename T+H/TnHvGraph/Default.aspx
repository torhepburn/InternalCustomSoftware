<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TnHvGraph.Default" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Chart 
        ID="Chart1" Width="800" 
        runat="server" 
        DataSourceID="SqlDataSource1">
        <series>
            <asp:Series 
                Name="Series1" 
                XValueMember="LogDate" 
                YValueMembers="Particles" 
                ChartType="Line" BorderWidth="2" Color="Sienna">
            </asp:Series>
        </series>
        <chartareas>
            <asp:ChartArea Name="ChartArea1">
                <AxisX Title="Time Period" ></AxisX>
                <AxisY Title="Number of 0.5 size particles"></AxisY>
            </asp:ChartArea>
        </chartareas>
        <Titles>
            <asp:Title Name="title1" Text="M1-1: Cleanroom 1 Front Room: Max 1000"></asp:Title>

        </Titles>
    </asp:Chart>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TnHConnectionString %>" SelectCommand="SELECT [LogDate], [0.5] AS Particles FROM [ParticleCountData] where location = 'm1-1' and logdate > DateAdd(mm, -6, getdate()) ORDER BY [LogDate] DESC"></asp:SqlDataSource>

    </div>
    </form>
</body>
</html>
