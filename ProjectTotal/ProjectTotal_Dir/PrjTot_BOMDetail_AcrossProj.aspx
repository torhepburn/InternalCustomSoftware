<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="PrjTot_BOMDetail_AcrossProj.aspx.vb" Inherits="ProjectTotal_Dir_PrjTot_BOMDetail_AcrossProj" title="Item Code across Projects" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetDataBy_CustomizedBill_ItemCode" TypeName="ProjectTotalTableAdapters.tabCustomizedBillDetailTableAdapter">
        <SelectParameters>
            <asp:QueryStringParameter Name="ITEM_CODE" QueryStringField="ITEM_CODE" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <h3>
        ITEM <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        Across all Projects - Min and Max Actual Cost only reflects
                                     Ty=CU and Cost Type=ACT 
        
    </h3>     
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" Style="position: relative">
        <Columns>
            <asp:BoundField DataField="PROJECT" HeaderText="Project" SortExpression="PROJECT">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="POSITION" HeaderText="POS" SortExpression="POSITION">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="ITEM_CODE" HeaderText="Part Number" SortExpression="ITEM_CODE">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="ITEM_DESCRIPTION" HeaderText="Description" SortExpression="ITEM_DESCRIPTION">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="TypeDesc" HeaderText="Only CU Type" SortExpression="TypeDesc">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="ItemNetQty" DataFormatString="{0:#,##0;(#,##0);0}" HeaderText="Qty"
                HtmlEncode="False" SortExpression="ItemNetQty">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="TotalCost" DataFormatString="{0:#,##0.00;(#,##0.00);0}"
                HeaderText="Cost" HtmlEncode="False" SortExpression="TotalCost">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="FinActOrEst" HeaderText="Act. Or Est." ReadOnly="True"
                SortExpression="FinActOrEst">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>

