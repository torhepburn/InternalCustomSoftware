<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="viewParticleCounts._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Particle Count Data !
        
    </h2>
    <p>
        <asp:GridView ID="GridView1" 
                      runat="server" 
                      AutoGenerateColumns="False" 
                      DataSourceID="SqlDataSource1" 
                      AllowSorting="True">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Location" HeaderText="Location" 
                    SortExpression="Location" />
                <asp:BoundField DataField="LogDate" HeaderText="LogDate" 
                    SortExpression="LogDate" />
                <asp:BoundField DataField="0.3" HeaderText="0.3" SortExpression="0.3" />
                <asp:BoundField DataField="0.5" HeaderText="0.5" SortExpression="0.5" />
                <asp:BoundField DataField="1.0" HeaderText="1.0" SortExpression="1.0" />
                <asp:BoundField DataField="3.0" HeaderText="3.0" SortExpression="3.0" />
                <asp:BoundField DataField="5.0" HeaderText="5.0" SortExpression="5.0" />
                <asp:BoundField DataField="10.0" HeaderText="10.0" SortExpression="10.0" />
                <asp:BoundField DataField="Volume" HeaderText="Volume" 
                    SortExpression="Volume" />
                <asp:BoundField DataField="SampleTime" HeaderText="SampleTime" 
                    SortExpression="SampleTime" />
                <asp:BoundField DataField="ReadingNumberFromCounter" 
                    HeaderText="ReadingNumberFromCounter" 
                    SortExpression="ReadingNumberFromCounter" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:TnHConnectionString %>" 
            SelectCommand="ParticleCountsgpiopticalassembly" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>
        
    </p>
</asp:Content>
