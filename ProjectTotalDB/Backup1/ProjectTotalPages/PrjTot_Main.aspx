<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="PrjTot_Main.aspx.vb" Inherits="ProjectTotal_Dir_MainProjectTotal2" title="Project Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="tabProjectMainSummary_By_Project_GetData" TypeName="ProjectTotalTableAdapters.tabProjectMainSummaryTableAdapter" DeleteMethod="Delete" InsertMethod="Insert" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_PROJECT" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="DESCRIPTION" Type="String" />
            <asp:Parameter Name="DESCRIPTION_1" Type="String" />
            <asp:Parameter Name="DESCRIPTION_2" Type="String" />
            <asp:Parameter Name="DESCRIPTION_3" Type="String" />
            <asp:Parameter Name="FileDate" Type="String" />
            <asp:Parameter Name="StatusDesc" Type="String" />
            <asp:Parameter Name="CUSTOMER" Type="String" />
            <asp:Parameter Name="CustomerName" Type="String" />
            <asp:Parameter Name="StartDate" Type="DateTime" />
            <asp:Parameter Name="FinishDate" Type="String" />
            <asp:Parameter Name="TransferPrice" Type="Double" />
            <asp:Parameter Name="ProjectLeaderName" Type="String" />
            <asp:Parameter Name="SumOfAMOUNT" Type="Double" />
            <asp:Parameter Name="OpenAmt" Type="Double" />
            <asp:Parameter Name="TotalCost" Type="Double" />
            <asp:Parameter Name="SubContractCost" Type="Double" />
            <asp:Parameter Name="StockTransferCost" Type="Double" />
            <asp:Parameter Name="LaborCost" Type="Double" />
            <asp:Parameter Name="PurchaseCost" Type="Double" />
            <asp:Parameter Name="MaterialCost" Type="Double" />
            <asp:Parameter Name="FinCostAmount" Type="Double" />
            <asp:Parameter Name="OnOrdAmt" Type="Double" />
            <asp:Parameter Name="FinSalesAmount" Type="Double" />
            <asp:Parameter Name="Original_PROJECT" Type="String" />
        </UpdateParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="textboxProject" Name="PROJECT" PropertyName="Text"
                Type="String" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="PROJECT" Type="String" />
            <asp:Parameter Name="DESCRIPTION" Type="String" />
            <asp:Parameter Name="DESCRIPTION_1" Type="String" />
            <asp:Parameter Name="DESCRIPTION_2" Type="String" />
            <asp:Parameter Name="DESCRIPTION_3" Type="String" />
            <asp:Parameter Name="FileDate" Type="String" />
            <asp:Parameter Name="StatusDesc" Type="String" />
            <asp:Parameter Name="CUSTOMER" Type="String" />
            <asp:Parameter Name="CustomerName" Type="String" />
            <asp:Parameter Name="StartDate" Type="DateTime" />
            <asp:Parameter Name="FinishDate" Type="String" />
            <asp:Parameter Name="TransferPrice" Type="Double" />
            <asp:Parameter Name="ProjectLeaderName" Type="String" />
            <asp:Parameter Name="SumOfAMOUNT" Type="Double" />
            <asp:Parameter Name="OpenAmt" Type="Double" />
            <asp:Parameter Name="TotalCost" Type="Double" />
            <asp:Parameter Name="SubContractCost" Type="Double" />
            <asp:Parameter Name="StockTransferCost" Type="Double" />
            <asp:Parameter Name="LaborCost" Type="Double" />
            <asp:Parameter Name="PurchaseCost" Type="Double" />
            <asp:Parameter Name="MaterialCost" Type="Double" />
            <asp:Parameter Name="FinCostAmount" Type="Double" />
            <asp:Parameter Name="OnOrdAmt" Type="Double" />
            <asp:Parameter Name="FinSalesAmount" Type="Double" />
        </InsertParameters>
    </asp:ObjectDataSource>
    <asp:TextBox ID="textboxProject" runat="server" AutoPostBack="True" Style="left: 128px;
        position: relative; top: 0px; font-size: small; color: red; font-family: Verdana;"></asp:TextBox>
    <asp:Label ID="Label1" runat="server" Style="left: -160px; position: relative; top: 0px; font-size: small; color: red; font-family: Verdana;"
        Text="Enter Project #" Width="125px"></asp:Label>
    <asp:FormView ID="FormView1" runat="server" DataKeyNames="PROJECT" DataSourceID="ObjectDataSource1"
        Style="position: relative; font-family: Verdana; background-color: white;" Width="558px">
        <ItemTemplate>
         
        <hr />
        <h3>PROJECT SUMMARY <%#Eval("PROJECT")%></h3>
        <table border="0">
            <tr>
                <td class="PropertyLabel">Description:</td>
                <td class="PropertyValue">
                  <%#Eval("DESCRIPTION")%></td>
                <td class="PropertyLabel">Total Booked:</td>
                <td class="PropertyValueMoney">
                  <%#Eval("SumOfAMOUNT", "{0:c}")%></td>
                <td class="PropertyLabelCenter" colspan=2 >CONSULTING</td>
               
            </tr>
            <tr>
                <td class="PropertyLabel">:</td>
                <td class="PropertyValue">
                  <%#Eval("DESCRIPTION_1")%></td>
                <td class="PropertyLabel">Unit Transfer Price:</td>
                <td class="PropertyValueMoney">
                  <%#Eval("TransferPrice", "{0:c}")%></td> 
                <td />    
                <td />            
            </tr> 
            <tr>
                <td class="PropertyLabel">:</td>
                <td class="PropertyValue">
                  <%#Eval("DESCRIPTION_2")%></td>
                <td />    
                <td />
                    
            </tr>     
            <tr>
                <td class="PropertyLabel">:</td>
                <td class="PropertyValue">
                  <%#Eval("DESCRIPTION_3")%></td>
                <td id="cell"><a id="goog"href="PrjTot_LaborSummaryAcrossPeriods.aspx">Labor Cost:</a></td>                 
                <td class="PropertyValueMoney_Indent">
                  <%#Eval("LaborCost", "{0:c}")%></td>  
                <td class="PropertyLabel"id="Td6"><a id="A5"href="PrjTot_TransConsulting.aspx?CPC=CSL">Labor:</a></td>    
                <td class="PropertyValueMoney_Indent">
                  <%#Eval("ConsultLabor", "{0:c}")%></td>    
            </tr>  
                <!--ALTERNATIVE METHOD TO HYPERLINK
                <td class="row1" width="100%" style="cursor:hand; padding: 30px; border: 1px solid black;"  onclick="parent.MainContent2.location.href='http://www.google.com'">THIS IS CONTENT</td>
                --> 

            <tr>
                <td class="PropertyLabel">Start Date:</td>
                <td class="PropertyValue">
                  <%#Eval("StartDate","{0:d}") %></td>
                <td class="PropertyLabel"id="Td1"><a id="MaterialCosts"href="PrjTot_MaterialCostAcrossPeriods.aspx">Material Cost:</a></td>    
                <td class="PropertyValueMoney_Indent">
                  <%#Eval("MaterialCost", "{0:c}")%></td>                   
                <td class="PropertyLabel"id="Td5"><a id="A4"href="PrjTot_TransConsulting.aspx?CPC=CSM">Material:</a></td>    
                <td class="PropertyValueMoney_Indent">
                  <%#Eval("ConsultMaterial", "{0:c}")%></td>   
            </tr>   
            <tr>
                <td class="PropertyLabel">Finish Date:</td>
                <td class="PropertyValue">
                  <%#Eval("FinishDate", "{0:d}")%></td>
                <td class="PropertyLabel"id="Td3"><a id="A3"href="PrjTot_StockTransactions_ByProject.aspx">Stock Transfers:</a></td>      
                <td class="PropertyValueMoney_Indent">
                  <%#Eval("StockTransferCost", "{0:c}")%></td>
                <td class="PropertyLabel"id="Td7"><a id="A6"href="PrjTot_TransConsulting.aspx?CPC=CST">Travel:</a></td>    
                <td class="PropertyValueMoney_Indent_Underline">
                  <%#Eval("ConsultTravel", "{0:c}")%></td>                                      
            </tr>     
            <tr>
                <td class="PropertyLabel">File Date:</td>
                <td class="PropertyValue">
                  <%#Eval("FileDate", "{0:d}")%></td>
                <td class="PropertyLabel"id="Td2"><a id="A1"href="PrjTot_AllOtherCosts_Project.aspx">All Other Cost:</a></td>      
                <td class="PropertyValueMoney_Indent_Underline">
                  <%#Eval("PurchaseCost", "{0:c}")%></td>    
                <td />    
                <td />                              
            </tr>     
            <tr> 
                <td class="PropertyLabel">Status:</td>
                <td class="PropertyValue">
                  <%#Eval("StatusDesc")%></td>  
                <td class="PropertyLabel">Sub Total Cost:</td>
                <td class="PropertyValueMoney">
                  <%#Eval("TotalCost", "{0:c}")%></td>                           
                <td class="PropertyLabel"id="Td8"><a id="A7"href="PrjTot_TransConsulting.aspx?CPC=%" >Total:</a></td> 
                <td class="PropertyValueMoney">
                  <%#Eval("ConsultTotal", "{0:c}")%></td>   

            </tr>     
            <tr>     
                <td class="PropertyLabel">Customer:</td>
                <td class="PropertyValue">
                  <%#Eval("CUSTOMER")%></td>       
                <td class="PropertyLabel"id="Td4"><a id="A2"href="PrjTot_PurchaseOrders.aspx">Open PO Cost:</a></td>      
                <td class="PropertyValueMoney_Indent_Underline">
                  <%#Eval("OpenAmt", "{0:c}")%></td> 

            </tr>     
            <tr>      
                <td class="PropertyLabel">Cust Name:</td>
                <td class="PropertyValue">
                  <%#Eval("CustomerName")%></td>                        
                <td class="PropertyLabel">Grand Total Cost:</td>
                <td class="PropertyValueMoney">
                  <%#Eval("GrandTotal", "{0:c}")%></td>

            </tr>     
            <tr>        
                <td class="PropertyLabel">Proj Leader:</td>
                <td class="PropertyValue">
                  <%#Eval("ProjectLeaderName")%></td>                      
                <td />
                <td />

            </tr>     
                                                                                                                 
        </table>    
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
    <h3>FINANCIAL OVERVIEW</h3>
    <asp:TextBox ID="TextBox1" runat="server" Style="position: relative; left: 105px; top: -37px;" Visible="false"></asp:TextBox>
    <asp:ObjectDataSource ID="ObjectDataSource2"
        runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="tabProjectFinTransSumByPeriod_GetDataByProject" TypeName="ProjectTotalTableAdapters.tabProjectFinTransSumByPeriodTableAdapter">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBox1" Name="PROJECT" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <table style="left: 105px; width: 460px; position: relative; top: 0px">

        <tr>
            <td style="width: 160px" bordercolor="#000000" class="GridPropertyValue" height="20">
                Recognized Financial Data</td>
            <td  width="320" class="GridPropertyValue" height="20">
    Actual Costs</td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataSourceID="ObjectDataSource2" Style="position: relative" RowHeaderColumn="CalPeriod" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Top" Height="100px" ShowFooter="True" HorizontalAlign="Left" Width="75%" PageSize="18">
        <Columns>
            <asp:BoundField DataField="FINANCIAL_PERIOD" HeaderText="Fin Period" SortExpression="FINANCIAL_PERIOD" >
                <ItemStyle CssClass="GridPropertyValue" />
                <HeaderStyle CssClass="GridPropertyValue" />
                <FooterStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="CalPeriod" HeaderText="Cal Period" SortExpression="CalPeriod" >
                <ItemStyle CssClass="GridPropertyValue" />
                <HeaderStyle CssClass="GridPropertyValue" />
             </asp:BoundField>
            <asp:BoundField DataField="FinSalesAmount" HeaderText="Sales" SortExpression="FinSalesAmount" DataFormatString="{0:#,##0.00;(#,##0.00);0}" HtmlEncode="False" >
                <ItemStyle CssClass="GridPropertyValueMoney" />
                <HeaderStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:BoundField DataField="FinCostAmount" HeaderText="Costs" SortExpression="FinCostAmount" DataFormatString="{0:#,##0.00;(#,##0.00);0}" HtmlEncode="False" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="MaterialCost" HeaderText="Material Cost" SortExpression="MaterialCost" DataFormatString="{0:#,##0.00;(#,##0.00);0}" HtmlEncode="False" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="LaborCost" HeaderText="Labor Cost" SortExpression="LaborCost" DataFormatString="{0:#,##0.00;(#,##0.00);0}" HtmlEncode="False" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="StockTransferCost" HeaderText="Stock Transfers" SortExpression="StockTransferCost" DataFormatString="{0:#,##0.00;(#,##0.00);0}" HtmlEncode="False" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="PurchaseCost" HeaderText="Purchase Cost" SortExpression="PurchaseCost" DataFormatString="{0:#,##0.00;(#,##0.00);0}" HtmlEncode="False" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="SubContractCost" HeaderText="SubContract Cost" SortExpression="SubContractCost" DataFormatString="{0:#,##0.00;(#,##0.00);0}" HtmlEncode="False" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="TotalCost" HeaderText="Total Cost" SortExpression="TotalCost" DataFormatString="{0:#,##0.00;(#,##0.00);0}" HtmlEncode="False" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>
            <asp:BoundField DataField="PROJECT" HeaderText="PROJECT" SortExpression="PROJECT"
                Visible="False" >
                <HeaderStyle CssClass="GridPropertyValue" />
            </asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="PROJECT,FINANCIAL_PERIOD" DataNavigateUrlFormatString="PrjTot_OrderByProjPeriod.aspx?project={0}&amp;financial_period={1}"
                HeaderText="Details" Text="Orders">
                <HeaderStyle CssClass="GridPropertyValue" ForeColor="Blue" />
                <ItemStyle CssClass="GridPropertyValue" />
            </asp:HyperLinkField>
             <asp:BoundField DataField="ConsultTotal" HeaderText="Consulting Part" SortExpression="ConsultTotal" DataFormatString="{0:#,##0.00;(#,##0.00);0}" HtmlEncode="False" >
                <HeaderStyle CssClass="GridPropertyValue" />
                <ItemStyle CssClass="GridPropertyValueMoney" />
            </asp:BoundField>           
        </Columns>
        <AlternatingRowStyle BackColor="Silver" HorizontalAlign="Right" Wrap="False" />
        <FooterStyle CssClass="GridFooterStyle" />
    </asp:GridView>
</asp:Content>
