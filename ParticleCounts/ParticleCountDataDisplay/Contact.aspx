<%@ Page Title="Raw Data" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ParticleCountDataDisplay.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3></h3>
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
    <Columns>
        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
        <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
        <asp:BoundField DataField="LogDate" HeaderText="LogDate" SortExpression="LogDate" />
        <asp:BoundField DataField="column1" HeaderText="0.5" SortExpression="column1" />
        <asp:BoundField DataField="ReadingNumberFromCounter" HeaderText="ReadingNumberFromCounter" SortExpression="ReadingNumberFromCounter" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource 
    ID="SqlDataSource1" 
    runat="server" 
    ConnectionString="<%$ ConnectionStrings:TnHConnectionString %>" 
    SelectCommand="SELECT [ID], [Location], [LogDate], [0.5] AS column1, [ReadingNumberFromCounter] FROM [ParticleCountData] WHERE logDate > '2017-08-01' ORDER BY [ID] DESC"></asp:SqlDataSource>

    

</asp:Content>
