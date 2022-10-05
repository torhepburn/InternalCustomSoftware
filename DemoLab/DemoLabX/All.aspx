<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="All.aspx.cs" Inherits="DemoLabX.All" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
            </hgroup>
            
        </div>
    </section>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" 
                        runat="server" 
                        AutoGenerateColumns="True" 
                        DataKeyNames="ID" 
                        AllowSorting="true"
                        DataSourceID="SqlDataSource1">
    </asp:GridView>
    
    <asp:SqlDataSource 
            ID="SqlDataSource1" 
            runat="server" 
            ConnectionString="<%$ ConnectionStrings:DemoLabCnxn %>" 
            SelectCommand="ItemsActive"
            SelectCommandType ="StoredProcedure">
    </asp:SqlDataSource>
</asp:Content>
