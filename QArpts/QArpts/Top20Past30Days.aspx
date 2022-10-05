<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Top20Past30Days.aspx.cs" Inherits="QArpts.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Time Parts Spend in QC - Top 20 Most Time Spent Last 30 Days
        
    </h2>
    <p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="mkreceipttransactionid" 
                HeaderText="mkreceipttransactionid" SortExpression="mkreceipttransactionid" />
            <asp:BoundField DataField="PartNumber" HeaderText="PartNumber" 
                SortExpression="PartNumber" />
            <asp:BoundField DataField="Description" HeaderText="Description" 
                SortExpression="Description" />
            <asp:BoundField DataField="OrdNum" HeaderText="OrdNum" 
                SortExpression="OrdNum" />
            <asp:BoundField DataField="Inspector" HeaderText="Inspector" 
                SortExpression="Inspector" />
            <asp:BoundField DataField="Spplr_Commodity" HeaderText="Spplr_Commodity" 
                SortExpression="Spplr_Commodity" />
            <asp:BoundField DataField="DateApprvd" HeaderText="DateApprvd" 
                SortExpression="DateApprvd" />
            <asp:BoundField DataField="daysinqc" HeaderText="daysinqc" ReadOnly="True" 
                SortExpression="daysinqc" />
        </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:WebTablesConnectionString %>" 
            SelectCommand="Top20QCpast30days" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>
    </p>

</asp:Content>
