<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="PrjTot_BOMDetail.aspx.vb" Inherits="ProjectTotal_Dir_PrjTot_BOMDetail" title="BOM Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetDataBy_DetailedBOM_Proj_Parent" TypeName="ProjectTotalTableAdapters.tabCustomizedBillDetailTableAdapter">
        <SelectParameters>
            <asp:SessionParameter Name="PROJECT" SessionField="strProject" Type="String" />
            <asp:QueryStringParameter Name="ParentPart" QueryStringField="ParentPart" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <h3>
        BOM Detail for Project 
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <font color=blue> Blue rows indicate where Actual Cost&nbsp; for Custom Type varies between projects.</font>
        
    </h3>      
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
        Style="position: relative" AllowPaging="True" AllowSorting="True" PageSize="25">
        <Columns>
            <asp:BoundField DataField="POSITION" HeaderText="Pos" SortExpression="POSITION" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="ITEM_CODE" HeaderText="Item" SortExpression="ITEM_CODE" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="ITEM_DESCRIPTION" HeaderText="Description" SortExpression="ITEM_DESCRIPTION" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="TypeDesc" HeaderText="Type" SortExpression="TypeDesc" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="ItemNetQty" HeaderText="Qty" SortExpression="ItemNetQty" DataFormatString="{0:#,##0;(#,##0);0}" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="TotalCost" HeaderText="Cost" SortExpression="TotalCost" DataFormatString="{0:#,##0.00;(#,##0.00);0}" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="FinActOrEst" HeaderText="Act. or Est." SortExpression="FinActOrEst">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="MinActCost_Project" HeaderText="Min Proj" SortExpression="MinActCost_Project" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" BackColor="#C0FFC0" />
            </asp:BoundField>
            <asp:BoundField DataField="MinActCost" HeaderText="Min Cost" SortExpression="MinActCost" DataFormatString="{0:#,##0.00;(#,##0.00);0}" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" BackColor="#C0FFC0" />
            </asp:BoundField>
            <asp:BoundField DataField="MaxActCost_Project" HeaderText="Max Proj" SortExpression="MaxActCost_Project" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" BackColor="#FFC0C0" />
            </asp:BoundField>
            <asp:BoundField DataField="MaxActCost" HeaderText="Max Act" SortExpression="MaxActCost" DataFormatString="{0:#,##0.00;(#,##0.00);0}" HtmlEncode="False" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" BackColor="#FFC0C0" />
            </asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="ITEM_CODE" DataNavigateUrlFormatString="PrjTot_BOMDetail_AcrossProj.aspx?ITEM_CODE={0}" Text="All">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:HyperLinkField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>

