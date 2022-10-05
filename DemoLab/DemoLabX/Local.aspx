<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Local.aspx.cs" Inherits="DemoLabX.Local" %>

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
                  DataKeyNames="ID" 
                  AllowSorting="True" 
                  OnSorting="GridView1_Sorting"
                  >
    </asp:GridView>
    
    
</asp:Content>
