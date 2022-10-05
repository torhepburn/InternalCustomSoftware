<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AverageQCpast30.aspx.cs" Inherits="QArpts.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Average Time Parts Spend in QC - Past 30 Days
    </h2>
    <p>
        &nbsp;<asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" 
            Width="856px" Height="540px">
            <series>
                <asp:Series Name="Series1" XValueMember="Spplr_commodity" 
                    YValueMembers="AvgDays">
                    
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
            
        </asp:Chart>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:WebTablesConnectionString %>" 
            SelectCommand="AvgQCpast30days" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>
    </p>
</asp:Content>
