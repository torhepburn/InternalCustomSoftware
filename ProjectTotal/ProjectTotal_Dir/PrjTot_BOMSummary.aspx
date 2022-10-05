<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="PrjTot_BOMSummary.aspx.vb" Inherits="ProjectTotal_Dir_PrjTot_BOMSummary" title="BOM Summary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetDataBy_CustomizedBill_Project" TypeName="ProjectTotalTableAdapters.tabCustomizedBillProjectSummaryTableAdapter">
        <SelectParameters>
            <asp:SessionParameter Name="PROJECT" SessionField="strProject" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <h3>
        BOM Summary for Project 
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </h3>      
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" Style="position: relative">
        <Columns>
            <asp:BoundField DataField="ParentPart" HeaderText="Assemblies" SortExpression="ParentPart">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="ParentDesc" HeaderText="Description" SortExpression="ParentDesc">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="ParentQty" DataFormatString="{0:#,##0;(#,##0);0}" HeaderText="Qty"
                HtmlEncode="False" SortExpression="ParentQty">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="CustomCost" DataFormatString="{0:#,##0.00;(#,##0.00);0}"
                HeaderText="Custom Cost" HtmlEncode="False" SortExpression="CustomCost">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="StdCost" DataFormatString="{0:#,##0.00;(#,##0.00);0}"
                HeaderText="Standard Cost" HtmlEncode="False" SortExpression="StdCost">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="TotalCost" DataFormatString="{0:#,##0.00;(#,##0.00);0}"
                HeaderText="Total Cost" HtmlEncode="False" SortExpression="TotalCost">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:HyperLinkField Text="BOM" DataNavigateUrlFields="PROJECT,PARENTPART" DataNavigateUrlFormatString="PrjTot_BOMDetail.aspx?project={0}&amp;PARENTPART={1}" >
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:HyperLinkField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>

