<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="PrjTot_ProductionOrdersProj_Operations.aspx.vb" Inherits="ProjectTotal_Dir_PrjTot_ProductionOrdersProj_Operations" title="Operations Cost Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetDataBy_ProductionHoursNormalized_Proj" TypeName="ProjectTotalTableAdapters.tabActualProdHours_NormalizedTableAdapter">
        <SelectParameters>
            <asp:SessionParameter Name="PROJECT" SessionField="strProject" Type="String" />
            <asp:QueryStringParameter Name="ORDER_NO" QueryStringField="ORDER_NO" Type="Single" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <h3>
        Operations Cost Details for Project 
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </h3>     
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" PageSize="25" Style="position: relative">
        <Columns>
            <asp:BoundField DataField="OPERATION" HeaderText="Oper." SortExpression="OPERATION">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="TASK" HeaderText="Task" SortExpression="TASK">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="WORK_CENTER" HeaderText="Wrk Ctr." SortExpression="WORK_CENTER">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="Total_Hours_E" DataFormatString="{0:#,##0.00;(#,##0.00);0}"
                HeaderText="Est. Hours" SortExpression="Total_Hours_E">
                <HeaderStyle BackColor="#C0FFC0" CssClass="GridPropertyValue" />
                <ItemStyle BackColor="#C0FFC0" CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="Total_Costs_E" DataFormatString="{0:#,##0.00;(#,##0.00);0}"
                HeaderText="Est. Amount" SortExpression="Total_Costs_E">
                <HeaderStyle BackColor="#C0FFC0" CssClass="GridPropertyValue" />
                <ItemStyle BackColor="#C0FFC0" CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="Total_Hours_A" DataFormatString="{0:#,##0.00;(#,##0.00);0}"
                HeaderText="Act. Hours" SortExpression="Total_Hours_A">
                <HeaderStyle BackColor="#FFC0FF" CssClass="GridPropertyValue" />
                <ItemStyle BackColor="#FFC0FF" CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="Total_Costs_A" DataFormatString="{0:#,##0.00;(#,##0.00);0}"
                HeaderText="Act. Amount" SortExpression="Total_Costs_A">
                <HeaderStyle BackColor="#FFC0FF" CssClass="GridPropertyValue" />
                <ItemStyle BackColor="#FFC0FF" CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="Result_Hours" DataFormatString="{0:#,##0.00;(#,##0.00);0}"
                HeaderText="Result Hours" SortExpression="Result_Hours">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="Result_Amount" DataFormatString="{0:#,##0.00;(#,##0.00);0}"
                HeaderText="Result Amount" SortExpression="Result_Amount">
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>

