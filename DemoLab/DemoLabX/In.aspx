<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="In.aspx.cs" Inherits="DemoLabX.Contact" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
            </hgroup>
            
        </div>
    </section>
</asp:Content>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    <asp:GridView ID="GridView1" 
                  runat="server"
                  AutoGenerateColumns="True" 
                  DataKeyNames="ID" 
                  AllowSorting="True"
                  OnSorting="GridView1_Sorting"
        >
    </asp:GridView>

    
</asp:Content>