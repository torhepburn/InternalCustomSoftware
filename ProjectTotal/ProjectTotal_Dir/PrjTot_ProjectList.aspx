<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="PrjTot_ProjectList.aspx.vb" Inherits="ProjectTotal_Dir_PrjTot_ProjectList" title="Project Listing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:Label ID="Label1" runat="server" Style="font-size: small; color:Red;  font-family: Verdana;"
        Text="Enter Project Leader:" Width="168px" Height="19px"></asp:Label> 
    <asp:TextBox  ID="textboxProjectLeader" runat="server" AutoPostBack="True" Style="
         font-size: small;  font-family: Verdana;"></asp:TextBox>
    <asp:Label ID="Label2" runat="server" Height="19px" Style="font-size: small;  color:Red; font-family: Verdana; 
        " Text="Enter Project Status:"
        Width="168px"></asp:Label>
    <asp:DropDownList ID="cmbProjectStatus" runat="server" AutoPostBack="True" Style="font-size: small; font-family: Verdana;" Width="157px">
        <asp:ListItem Value="0">All</asp:ListItem>
        <asp:ListItem Value="1">Free</asp:ListItem>
        <asp:ListItem Value="2">Other</asp:ListItem>
        <asp:ListItem  Selected=true Value="3">Active</asp:ListItem>
        <asp:ListItem Value="4">Canceled</asp:ListItem>
        <asp:ListItem Value="5">Finished</asp:ListItem>
        <asp:ListItem Value="6">Closed</asp:ListItem>
        <asp:ListItem Value="7">Another</asp:ListItem>
        <asp:ListItem Value="9">Archived</asp:ListItem>
    </asp:DropDownList>
  
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Projects_Info_TotalConnectionString %>"
        ProviderName="<%$ ConnectionStrings:Projects_Info_TotalConnectionString.ProviderName %>"
        SelectCommand="usr_ProjectListing;1" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="cmbProjectStatus" Name="PROJECT_STATUS" PropertyName="SelectedValue"
                Type="Int32" DefaultValue="0" />
            <asp:ControlParameter ControlID="textboxProjectLeader" Name="ProjectLeaderName" PropertyName="Text"
                Type="String" DefaultValue="All" />
        </SelectParameters>
    </asp:SqlDataSource>
   

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
        Style="position: relative; left: 6px; top: 29px;" Width="800px" AllowPaging="True" AllowSorting="True" PageSize="25" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="PROJECT" DataNavigateUrlFormatString="PrjTot_Main.aspx?P_ID={0}"
                Text="View">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:HyperLinkField>
            <asp:BoundField DataField="PROJECT" HeaderText="Project" SortExpression="PROJECT" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle Wrap="True" CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="DESCRIPTION" HeaderText="Description" SortExpression="DESCRIPTION" >
                <HeaderStyle  CssClass="GridPropertyValue" />
                <ItemStyle  Wrap="True" CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="DESCRIPTION_1" HeaderText="Description 2" SortExpression="DESCRIPTION_1">
                <HeaderStyle  CssClass="GridPropertyValue" />
                <ItemStyle  Wrap="True"  CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="DESCRIPTION_2" HeaderText="DESCRIPTION_2" SortExpression="DESCRIPTION_2"
                Visible="False">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle  Wrap="True" CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="PROJECT_STATUS" HeaderText="PROJECT_STATUS" SortExpression="PROJECT_STATUS"
                Visible="False">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle  Wrap="True" CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="ProjectLeaderName" HeaderText="Project Leader" SortExpression="ProjectLeaderName">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle  Wrap="False" CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="StatusDesc" HeaderText="Status" SortExpression="StatusDesc">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" SortExpression="CustomerName">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="StartDate" HeaderText="Start Date" SortExpression="StartDate" DataFormatString="{0:d}">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="DelivereryDate" HeaderText="Delivery Dt" SortExpression="DelivereryDate" DataFormatString="{0:d}">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>

