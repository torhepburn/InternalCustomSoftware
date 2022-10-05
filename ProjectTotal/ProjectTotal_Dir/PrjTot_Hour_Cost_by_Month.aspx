<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="PrjTot_Hour_Cost_by_Month.aspx.vb" Inherits="ProjectTotal_Dir_PrjTot_Hour_Cost_by_Month" title="Hour Cost by Month" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetDataBy_HourCostByMonth_Project" TypeName="ProjectTotalTableAdapters.qryHourCostByMonthTableAdapter">
        <SelectParameters>
            <asp:SessionParameter Name="PROJECT" SessionField="strProject" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <h3>
        Hour Cost by Month for Project 
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </h3>       
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" PageSize="20" Style="position: relative">
        <Columns>
            <asp:BoundField DataField="FINANCIAL_PERIOD" HeaderText="Fin. Period" SortExpression="FINANCIAL_PERIOD" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="EngHours" HeaderText="Eng Hrs" ReadOnly="True" SortExpression="EngHours" DataFormatString="{0:#,##0.00;(#,##0.00);0}" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="DDHours" HeaderText="DD Hrs" ReadOnly="True" SortExpression="DDHours" DataFormatString="{0:#,##0.00;(#,##0.00);0}" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="OtherHours" HeaderText="Other Hrs" ReadOnly="True" SortExpression="OtherHours" DataFormatString="{0:#,##0.00;(#,##0.00);0}" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="LaborCost" HeaderText="Labor Cost" SortExpression="LaborCost" DataFormatString="{0:#,##0.00;(#,##0.00);0}" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="MatAndPur" HeaderText="Mat. / Purch." SortExpression="MatAndPur" DataFormatString="{0:#,##0.00;(#,##0.00);0}" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="SubContractCost" HeaderText="Sub Contract Cost" SortExpression="SubContractCost" DataFormatString="{0:#,##0.00;(#,##0.00);0}" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="TotalCost" HeaderText="Total Cost" SortExpression="TotalCost" DataFormatString="{0:#,##0.00;(#,##0.00);0}" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="PROJECT,FINANCIAL_PERIOD" DataNavigateUrlFormatString="PrjTot_EmpHours_Detail.aspx?project={0}&amp;FINANCIAL_PERIOD={1}"
                Text="Details" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:HyperLinkField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>

