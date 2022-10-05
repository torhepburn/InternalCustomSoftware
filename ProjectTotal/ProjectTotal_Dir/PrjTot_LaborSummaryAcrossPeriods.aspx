<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="PrjTot_LaborSummaryAcrossPeriods.aspx.vb" Inherits="ProjectTotal_Dir_PrjTot_LaborSummaryAcrossPeriods" title="Labor Summary Across Periods" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetDataBy_tabProjectLaborHrsSummary_Project_NoFinPeriod" TypeName="ProjectTotalTableAdapters.tabProjectLaborHrsSummaryTableAdapter">
        <SelectParameters>
            <asp:SessionParameter Name="PROJECT" SessionField="strPROJECT" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <h3>
        Labor Hour Summary Across Periods for PROJECT  
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </h3>    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
        Style="position: relative" AllowPaging="True" AllowSorting="True" PageSize="25">
        <Columns>
            <asp:BoundField DataField="COST_PRICE_COMPONENT" HeaderText="Cost Price Component"
                SortExpression="COST_PRICE_COMPONENT" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="CostPriceDesc" HeaderText="CPC Description" SortExpression="CostPriceDesc" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="LaborHrs" HeaderText="Labor Hours" SortExpression="LaborHrs" DataFormatString="{0:#,##0.00;(#,##0.00);0}" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="SumOfAMOUNT" HeaderText="Amount" SortExpression="SumOfAMOUNT" DataFormatString="{0:#,##0.00;(#,##0.00);0}" HtmlEncode="False" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="PROJECT,COST_PRICE_COMPONENT" DataNavigateUrlFormatString="PrjTot_LaborDetail_Project_CPC.aspx?project={0}&amp;CPC={1}"
                Text="Details">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:HyperLinkField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>

