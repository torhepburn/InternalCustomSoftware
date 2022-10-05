<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KPImfd.aspx.cs" Inherits="CalView4._5.KPImfd" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calibration Key Performance Indicators - Middlefield</title>
     <style type ="text/css">
    table
    {
       font-family: Arial; 
       font-size:14pt;
       font-weight:bold;
       width:100%;
       padding:10px;
       background-color:darkseagreen;
    }
    body
    {
        text-align:center;
    }
    </style>
</head>

<body>
    <form id="form1" runat="server">
    <div>
          <table>
            <tr>
                <td align="center">
                    CALIBRATION DATA
                </td>
            </tr>
        </table>

    <table>
        <tr>
            <td>
                
              <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" Width="1000px">
                <series>
                    <asp:Series ChartType="Line" Name="Done" XValueMember="Period" 
                            YValueMembers="Done" BorderWidth="5" Legend="Legend1">
                        </asp:Series>
                    <asp:Series ChartType="Line" Name="Not Completed - Goal 0" XValueMember="Period" 
                            YValueMembers="Not Completed" BorderWidth="5" Legend="Legend1">
                        </asp:Series>
                    <asp:Series ChartType="Line" Name="Overdue - Goal 0" XValueMember="Period" 
                            YValueMembers="Overdue" BorderWidth="5" Legend="Legend1">
                        </asp:Series>    
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                     
                </chartareas>
              <Legends><asp:Legend Name="Legend1"></asp:Legend></Legends></asp:Chart>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:CalibrationConnectionString %>" 
                    SelectCommand="SELECT id, datename(mm,[time period]) + ' ' +  datename(yyyy, [time period]) as [Period], Done, [Not completed], Overdue from kpidata where [time period] > (select dateadd(month, -14, getdate())) and location = 'ZAMS' order by [time period] asc"></asp:SqlDataSource>
            
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
            
                
            
                <asp:GridView ID="GV" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="ID" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="Period"  HeaderText="Period" 
                            SortExpression="Period"  />
                        <asp:BoundField DataField="Done" HeaderText="Done" SortExpression="Done" />
                        <asp:BoundField DataField="Not Completed" HeaderText="Not Completed" 
                            SortExpression="Not Completed" />
                        <asp:BoundField DataField="Overdue" HeaderText="Overdue" 
                            SortExpression="Overdue" />
                    </Columns>
                </asp:GridView>
            
                
            
            </td>
        </tr>
    </table>
    </div>
        </form>
</body>
</html>
