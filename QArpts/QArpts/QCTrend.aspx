<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="QCTrend.aspx.cs" Inherits="QArpts._Default" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Time Parts Spend in QC - Trend
    </h2>
    <p>
        &nbsp;<asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" 
            Width="904px" Height="540px">
            <series>
                <asp:Series Name="Series1" XValueMember="TimePeriod" 
                    YValueMembers="Cables">
                </asp:Series>
                <asp:Series Name="Series2" XValueMember="TimePeriod" 
                    YValueMembers="Electronic">
                </asp:Series>
                <asp:Series Name="Series3" XValueMember="TimePeriod" 
                    YValueMembers="Mechanical">
                </asp:Series>
                <asp:Series Name="Series4" XValueMember="TimePeriod" 
                    YValueMembers="Optical">
                </asp:Series>
                <asp:Series Name="Series5" XValueMember="TimePeriod" 
                    YValueMembers="Other" color="YellowGreen">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
            <Titles>
                <asp:Title Name="Title1" Text="Cables - Light Blue">
                </asp:Title>
                <asp:Title Name="Title2" Text="Electronic - Tan">
                </asp:Title>
                <asp:Title Name="Title3" Text="Mechanical - Brown">
                </asp:Title>
                <asp:Title Name="Title4" Text="Optics - Blue">
                </asp:Title>
                <asp:Title Name="Title5" Text="Other = Green">
                </asp:Title>
            </Titles>
        </asp:Chart>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:WebTablesConnectionString %>" 
            SelectCommand="select * from timeinqctrenddata order by timeperiod">
        </asp:SqlDataSource>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
