<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="PrjTot_LaborSummary.aspx.vb" Inherits="ProjectTotal_Dir_PrjTot_LaborSummary" title="Labor Hour Summary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataBy_tabProjectLaborHrsSummary_Project" TypeName="ProjectTotalTableAdapters.tabProjectLaborHrsSummaryTableAdapter">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="100000" Name="PROJECT" SessionField="strProject"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <h3>
        Labor Hour Summary for Project  
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </h3>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" Style="position: relative" DataKeyNames="PROJECT,FINANCIAL_PERIOD" PageSize="25">
        <Columns>
            <asp:BoundField DataField="PROJECT" HeaderText="PROJECT" SortExpression="PROJECT" Visible="False" />
            <asp:BoundField DataField="FINANCIAL_PERIOD" HeaderText="Fin Period" SortExpression="FINANCIAL_PERIOD" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="LaborHrs" HeaderText="Labor Hours" SortExpression="LaborHrs" DataFormatString="{0:#,##0.00;(#,##0.00);0}" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="SumOfAMOUNT" HeaderText="Amount" SortExpression="SumOfAMOUNT" DataFormatString="{0:#,##0.00;(#,##0.00);0}" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="Project,Financial_Period" DataNavigateUrlFormatString="PrjTot_LaborDetail.aspx?project={0}&amp;financial_period={1}"
                HeaderText="Details" Text="details">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:HyperLinkField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>

