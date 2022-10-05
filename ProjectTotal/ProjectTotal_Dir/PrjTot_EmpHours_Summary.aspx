<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="PrjTot_EmpHours_Summary.aspx.vb" Inherits="ProjectTotal_Dir_PrjTot_EmpHours_Summary" title="Summary Employee Hours" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetDataBy_ProjectHrsEmpSum_Proj_Grouped" TypeName="ProjectTotalTableAdapters.tabProjectHrsEmpSumTableAdapter">
        <SelectParameters>
            <asp:SessionParameter Name="PROJECT" SessionField="strProject" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <h3>
        Hours By Employee for Project 
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </h3>     
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" Style="position: relative" PageSize="25">
        <Columns>
            <asp:BoundField DataField="NAME" HeaderText="Name" SortExpression="NAME">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="DESCRIPTION" HeaderText="Description" SortExpression="DESCRIPTION">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="SumOfMAN_TIME" HeaderText="Hours" SortExpression="SumOfMAN_TIME" DataFormatString="{0:#,##0.00;(#,##0.00);0}">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="LaborCost" HeaderText="Est. Labor" SortExpression="LaborCost" DataFormatString="{0:#,##0.00;(#,##0.00);0}" HtmlEncode="False">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="WORK_CENTER" HeaderText="W/C" SortExpression="WORK_CENTER">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="Developement" HeaderText="Dev ?" SortExpression="Developement">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="EMPLOYEE" HeaderText="EMPLOYEE" SortExpression="EMPLOYEE" Visible="False">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="PROJECT,EMPLOYEE" DataNavigateUrlFormatString="PrjTot_EmpHours_Detail.aspx?project={0}&amp;EMPLOYEE={1}"
                Text="Details">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:HyperLinkField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>

