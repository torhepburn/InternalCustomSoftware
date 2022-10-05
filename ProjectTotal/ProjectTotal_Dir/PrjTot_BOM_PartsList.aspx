<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="PrjTot_BOM_PartsList.aspx.vb" Inherits="ProjectTotal_Dir_PrjTot_BOM_PartsList" title="Detailed Parts List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetDataBy_DetailedPartsList_Proj" TypeName="ProjectTotalTableAdapters.tabCustomizedBillDetailTableAdapter">
        <SelectParameters>
            <asp:SessionParameter Name="PROJECT" SessionField="strProject" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <h3>
        Detailed Parts List for Project 
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <font color=blue> Blue rows indicate where Actual Cost for Custom Type varies between projects.</font>
    </h3> 
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" PageSize="25" Style="position: relative">
        <Columns>
            <asp:BoundField DataField="ITEM_CODE" HeaderText="Item" SortExpression="ITEM_CODE">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="ItemNetQty" DataFormatString="{0:#,##0;(#,##0);0}" HeaderText="Qty"
                SortExpression="ItemNetQty">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="ITEM_DESCRIPTION" HeaderText="Description" SortExpression="ITEM_DESCRIPTION">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="TypeDesc" HeaderText="Type" SortExpression="TypeDesc">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="TotalCost" DataFormatString="{0:#,##0.00;(#,##0.00);0}"
                HeaderText="Total" HtmlEncode="False" SortExpression="TotalCost">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="FinActOrEst" HeaderText="Act. Or Est." ReadOnly="True"
                SortExpression="FinActOrEst">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="MinActCost_Project" HeaderText="Min Proj" SortExpression="MinActCost_Project">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle BackColor="#C0FFC0" CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="MinActCost" DataFormatString="{0:#,##0.00;(#,##0.00);0}"
                HeaderText="Min Cost" SortExpression="MinActCost">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle BackColor="#C0FFC0" CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="MaxActCost_Project" HeaderText="Max Proj" SortExpression="MaxActCost_Project">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle BackColor="#FFC0C0" CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="MaxActCost" DataFormatString="{0:#,##0.00;(#,##0.00);0}"
                HeaderText="Max Cost" SortExpression="MaxActCost">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle BackColor="#FFC0C0" CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="ITEM_CODE" DataNavigateUrlFormatString="PrjTot_BOMDetail_AcrossProj.aspx?ITEM_CODE={0}"
                Text="All">
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:HyperLinkField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>

