<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TIQCnumbers30days.aspx.cs" Inherits="QArpts.TIQCnumbers30days" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Time Parts Spend in QC - Gross Breakdown Past 30 Days
        
    </h2>
    <p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
            HorizontalAlign="Center" 
            DataSourceID="SqlDataSource1">
            <RowStyle HorizontalAlign="Center" />
        <Columns>
            <asp:BoundField DataField="< 5 days old" 
                HeaderText="< 5 days old" SortExpression="< 5 days old" >
                <HeaderStyle Width="10em" />
            </asp:BoundField>
            <asp:BoundField DataField="Between 5 and 30 days old"
                 
                HeaderText="Between 5 and 30 days old"
                SortExpression="Between 5 and 30 days old" >
                <HeaderStyle Width="20em" />
            </asp:BoundField>
            <asp:BoundField DataField="> 30 days old"
                 
                HeaderText="> 30 days old"
                SortExpression="> 30 days old" >
            
            <HeaderStyle Width="10em" />
            </asp:BoundField>
            
        </Columns>
        
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:WebTablesConnectionString %>" 
            SelectCommand="TIQCgrossnumberspast30days" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>
    </p>

</asp:Content>
