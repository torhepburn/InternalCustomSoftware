<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Graph.aspx.cs" Inherits="viewParticleCounts.About" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Particle Count Graphs by Size
    </h2>
    <p>

    <asp:Chart ID="Chart1" 
                   runat="server" 
                   DataSourceID="SqlDataSource1" 
                   Width="692px">
            <series>
                <asp:Series Name="Series1" ChartType="Line" XValueMember="LogDate" 
                    YValueMembers="10.0" BorderWidth="3" Color="Red">
                </asp:Series>
                <asp:Series Name="Series2" ChartType="Line" XValueMember="LogDate" 
                    YValueMembers="5.0" BorderWidth="3" Color="Orange">
                </asp:Series>
                <asp:Series Name="Series3" ChartType="Line" XValueMember="LogDate" 
                    YValueMembers="3.0" BorderWidth="3" Color="Blue">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                    <AxisX Title="Time Period">
                    </AxisX>
                </asp:ChartArea>
            </chartareas>
            <Titles>
                <asp:Title Name="Title1" Text="10.0 = Red, 5.0 = Orange, 3.0 = Blue">
                </asp:Title>
            </Titles>
        </asp:Chart>

        <asp:Chart ID="Chart2" 
                   runat="server" 
                   DataSourceID="SqlDataSource1" 
                   Width="692px">
            <series>
                <asp:Series Name="Series1" ChartType="Line" XValueMember="LogDate" 
                    YValueMembers="1.0" BorderWidth="3" Color="Green" >
                </asp:Series>
                
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                <AxisX Title="Time Period">
                    </AxisX>
                </asp:ChartArea>
            </chartareas>
            <Titles>
                <asp:Title Name="Title1" Text="1.0 Size Particles">
                </asp:Title>
            </Titles>
        </asp:Chart>

        <asp:Chart ID="Chart3" 
                   runat="server" 
                   DataSourceID="SqlDataSource1" 
                   Width="692px">
            <series>
                <asp:Series Name="Series1" ChartType="Line" XValueMember="LogDate" 
                    YValueMembers="0.5" BorderWidth="3" Color="Brown" >
                </asp:Series>
                
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                <AxisX Title="Time Period">
                    </AxisX>
                </asp:ChartArea>
                
            </chartareas>
            <Titles>
                <asp:Title Name="Title1" Text="0.5 Size Particles">
                </asp:Title>
            </Titles>
        </asp:Chart>

        <asp:Chart ID="Chart4" 
                   runat="server" 
                   DataSourceID="SqlDataSource1" 
                   Width="692px">
            <series>
                <asp:Series Name="Series1" ChartType="Line" XValueMember="LogDate" 
                    YValueMembers="0.3" BorderWidth="3" Color="Violet" >
                </asp:Series>
                
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                <AxisX Title="Time Period">
                    </AxisX>
                </asp:ChartArea>
            </chartareas>
            <Titles>
                <asp:Title Name="Title1" Text="0.3 Size Particles">
                </asp:Title>
            </Titles>
        </asp:Chart>


        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:TnHConnectionString %>" 
            SelectCommand="ParticleCounts" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>
    </p>
</asp:Content>
