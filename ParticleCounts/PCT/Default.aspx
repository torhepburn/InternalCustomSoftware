<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PCT.Default" %>

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
            <asp:Title Name="title1" Text="M1-1: Cleanroom 1 Front Room: Class 6, Max 35200 particles/m^3"></asp:Title>

        </Titles>
    </asp:Chart>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TnHConnectionString %>" SelectCommand="SELECT [LogDate], [0.5] AS Particles FROM [ParticleCountData] where location = 'm1-1' and logdate > DateAdd(mm, -6, getdate()) ORDER BY [LogDate] DESC"></asp:SqlDataSource>

            <asp:Chart 
        ID="Chart2" Width="800" 
        runat="server" 
        DataSourceID="SqlDataSource2">
        <series>
            <asp:Series 
                Name="Series1" 
                XValueMember="LogDate" 
                YValueMembers="Particles" 
                ChartType="Line" BorderWidth="2" Color="Teal">
            </asp:Series>
        </series>
        <chartareas>
            <asp:ChartArea Name="ChartArea1">
                <AxisX Title="Time Period" ></AxisX>
                <AxisY Title="Number of 0.5 size particles"></AxisY>
            </asp:ChartArea>
        </chartareas>
        <Titles>
            <asp:Title Name="title1" Text="M1-2: Cleanroom 1 Dark Room: Class 6, Max 35200 particles/m^3"></asp:Title>

        </Titles>
    </asp:Chart>

<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TnHConnectionString %>" SelectCommand="SELECT [LogDate], [0.5] AS Particles FROM [ParticleCountData] where location = 'm1-2' and logdate > DateAdd(mm, -6, getdate()) ORDER BY [LogDate] DESC"></asp:SqlDataSource>
    

    <asp:Chart 
        ID="Chart3" Width="800" 
        runat="server" 
        DataSourceID="SqlDataSource3">
        <series>
            <asp:Series 
                Name="Series1" 
                XValueMember="LogDate" 
                YValueMembers="Particles" 
                ChartType="Line" BorderWidth="2" Color="Green">
            </asp:Series>
        </series>
        <chartareas>
            <asp:ChartArea Name="ChartArea1">
                <AxisX Title="Time Period" ></AxisX>
                <AxisY Title="Number of 0.5 size particles"></AxisY>
            </asp:ChartArea>
        </chartareas>
        <Titles>
            <asp:Title Name="title1" Text="M1-3: Cleanroom 1 General Room Center: Class 6, Max 35200 particles/m^3"></asp:Title>

        </Titles>
    </asp:Chart>

<asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:TnHConnectionString %>" SelectCommand="SELECT [LogDate], [0.5] AS Particles FROM [ParticleCountData] where location = 'm1-3' and logdate > DateAdd(mm, -6, getdate()) ORDER BY [LogDate] DESC"></asp:SqlDataSource>
    
    <asp:Chart 
        ID="Chart4" Width="800" 
        runat="server" 
        DataSourceID="SqlDataSource4">
        <series>
            <asp:Series 
                Name="Series1" 
                XValueMember="LogDate" 
                YValueMembers="Particles" 
                ChartType="Line" BorderWidth="2" Color="Blue">
            </asp:Series>
        </series>
        <chartareas>
            <asp:ChartArea Name="ChartArea1">
                <AxisX Title="Time Period" ></AxisX>
                <AxisY Title="Number of 0.5 size particles"></AxisY>
            </asp:ChartArea>
        </chartareas>
        <Titles>
            <asp:Title Name="title1" Text="M1-4: Cleanroom 1 General Room Back: Class 6, Max 35200 particles/m^3"></asp:Title>

        </Titles>
    </asp:Chart>

<asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:TnHConnectionString %>" SelectCommand="SELECT [LogDate], [0.5] AS Particles FROM [ParticleCountData] where location = 'm1-4' and logdate > DateAdd(mm, -6, getdate()) ORDER BY [LogDate] DESC"></asp:SqlDataSource>
    
    <asp:Chart 
        ID="Chart5" Width="800" 
        runat="server" 
        DataSourceID="SqlDataSource5">
        <series>
            <asp:Series 
                Name="Series1" 
                XValueMember="LogDate" 
                YValueMembers="Particles" 
                ChartType="Line" BorderWidth="2" Color="SteelBlue">
            </asp:Series>
        </series>
        <chartareas>
            <asp:ChartArea Name="ChartArea1">
                <AxisX Title="Time Period" ></AxisX>
                <AxisY Title="Number of 0.5 size particles"></AxisY>
            </asp:ChartArea>
        </chartareas>
        <Titles>
            <asp:Title Name="title1" Text="M2-1: Cleanroom 2 General Room Center: Class 7, Max 352000 particles/m^3"></asp:Title>

        </Titles>
    </asp:Chart>

<asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:TnHConnectionString %>" SelectCommand="SELECT [LogDate], [0.5] AS Particles FROM [ParticleCountData] where location = 'm2-1' and logdate > DateAdd(mm, -6, getdate()) ORDER BY [LogDate] DESC"></asp:SqlDataSource>
    
    <asp:Chart 
        ID="Chart6" Width="800" 
        runat="server" 
        DataSourceID="SqlDataSource6">
        <series>
            <asp:Series 
                Name="Series1" 
                XValueMember="LogDate" 
                YValueMembers="Particles" 
                ChartType="Line" BorderWidth="2" Color="DarkGoldenrod">
            </asp:Series>
        </series>
        <chartareas>
            <asp:ChartArea Name="ChartArea1">
                <AxisX Title="Time Period" ></AxisX>
                <AxisY Title="Number of 0.5 size particles"></AxisY>
            </asp:ChartArea>
        </chartareas>
        <Titles>
            <asp:Title Name="title1" Text="M3-1: Cleanroom 3: Class 5, Max 3520 particles/m^3"></asp:Title>

        </Titles>
    </asp:Chart>

<asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:TnHConnectionString %>" SelectCommand="SELECT [LogDate], [0.5] AS Particles FROM [ParticleCountData] where location = 'm3-1' and logdate > DateAdd(mm, -6, getdate()) ORDER BY [LogDate] DESC"></asp:SqlDataSource>
    
    <asp:Chart 
        ID="Chart7" Width="800" 
        runat="server" 
        DataSourceID="SqlDataSource7">
        <series>
            <asp:Series 
                Name="Series1" 
                XValueMember="LogDate" 
                YValueMembers="Particles" 
                ChartType="Line" BorderWidth="2" Color="DarkMagenta">
            </asp:Series>
        </series>
        <chartareas>
            <asp:ChartArea Name="ChartArea1">
                <AxisX Title="Time Period" ></AxisX>
                <AxisY Title="Number of 0.5 size particles"></AxisY>
            </asp:ChartArea>
        </chartareas>
        <Titles>
            <asp:Title Name="title1" Text="IQC-1: Optical IQC: Class 7, Max 352000 particles/m^3"></asp:Title>

        </Titles>
    </asp:Chart>

<asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:TnHConnectionString %>" SelectCommand="SELECT [LogDate], [0.5] AS Particles FROM [ParticleCountData] where location = 'IQC-1' and logdate > DateAdd(mm, -6, getdate()) ORDER BY [LogDate] DESC"></asp:SqlDataSource>
    
    <asp:Chart 
        ID="Chart8" Width="800" 
        runat="server" 
        DataSourceID="SqlDataSource8">
        <series>
            <asp:Series 
                Name="Series1" 
                XValueMember="LogDate" 
                YValueMembers="Particles" 
                ChartType="Line" BorderWidth="2" Color="Tomato">
            </asp:Series>
        </series>
        <chartareas>
            <asp:ChartArea Name="ChartArea1">
                <AxisX Title="Time Period" ></AxisX>
                <AxisY Title="Number of 0.5 size particles"></AxisY>
            </asp:ChartArea>
        </chartareas>
        <Titles>
            <asp:Title Name="title1" Text="IQC-2: Mechanical IQC: Class 7, Max 352000 particles/m^3"></asp:Title>

        </Titles>
    </asp:Chart>

<asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:TnHConnectionString %>" SelectCommand="SELECT [LogDate], [0.5] AS Particles FROM [ParticleCountData] where location = 'IQC-2' and logdate > DateAdd(mm, -6, getdate()) ORDER BY [LogDate] DESC"></asp:SqlDataSource>
    
    <asp:Chart 
        ID="Chart9" Width="800" 
        runat="server" 
        DataSourceID="SqlDataSource9">
        <series>
            <asp:Series 
                Name="Series1" 
                XValueMember="LogDate" 
                YValueMembers="Particles" 
                ChartType="Line" BorderWidth="2" Color="DarkRed">
            </asp:Series>
        </series>
        <chartareas>
            <asp:ChartArea Name="ChartArea1">
                <AxisX Title="Time Period" ></AxisX>
                <AxisY Title="Number of 0.5 size particles"></AxisY>
            </asp:ChartArea>
        </chartareas>
        <Titles>
            <asp:Title Name="title1" Text="CL-1: Cleaning Line: Class 5, Max 3520 particles/m^3"></asp:Title>

        </Titles>
    </asp:Chart>

<asp:SqlDataSource ID="SqlDataSource9" 
                    runat="server" 
                    ConnectionString="<%$ ConnectionStrings:TnHConnectionString %>" 
                    SelectCommand="SELECT [LogDate], [0.5] AS Particles FROM [ParticleCountData] where location = 'CL-1' and logdate > DateAdd(mm, -6, getdate()) ORDER BY [LogDate] DESC"></asp:SqlDataSource>
    

    </div>
    </form>
</body>
</html>
