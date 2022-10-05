<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KPIm.aspx.cs" Inherits="CalibrationView.KPIm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
          <td style="width: 5%;">
            <asp:Button 
            ID="Bjanuary" 
            runat="server" 
            Style="font-size:large;
                   font-weight:bold;
                   background-color: aqua; 
                   border-right: black 1px solid; 
                   border-top: black 1px solid; 
                   border-left: black 1px solid; 
                   border-bottom: black 1px solid;" 
            Text="January" 
            Height="35px" 
            Width="150px" 
            OnClick="Bjanuary_Click" />

          </td>
          <td style="width: 5%;">
                        <asp:Button 
            ID="Bfebruary" 
            runat="server" 
            Style="font-size:large;
                   font-weight:bold;
                   background-color: aqua; 
                   border-right: black 1px solid; 
                   border-top: black 1px solid; 
                   border-left: black 1px solid; 
                   border-bottom: black 1px solid;" 
            Text="February" 
            Height="35px" 
            Width="150px" OnClick="Bfebruary_Click" 
            />

          </td>
          <td style="width: 5%;">
                        <asp:Button 
            ID="Bmarch" 
            runat="server" 
            Style="font-size:large;
                   font-weight:bold;
                   background-color: aqua; 
                   border-right: black 1px solid; 
                   border-top: black 1px solid; 
                   border-left: black 1px solid; 
                   border-bottom: black 1px solid;" 
            Text="March" 
            Height="35px" 
            Width="150px" OnClick="Bmarch_Click" 
            />

          </td>
          <td style="width: 5%;">
                        <asp:Button 
            ID="Bapril" 
            runat="server" 
            Style="font-size:large;
                   font-weight:bold;
                   background-color: aqua; 
                   border-right: black 1px solid; 
                   border-top: black 1px solid; 
                   border-left: black 1px solid; 
                   border-bottom: black 1px solid;" 
            Text="April" 
            Height="35px" 
            Width="150px" OnClick="Bapril_Click" 
            />

          </td>
          <td style="width: 5%;">
                        <asp:Button 
            ID="Bmay" 
            runat="server" 
            Style="font-size:large;
                   font-weight:bold;
                   background-color: aqua; 
                   border-right: black 1px solid; 
                   border-top: black 1px solid; 
                   border-left: black 1px solid; 
                   border-bottom: black 1px solid;" 
            Text="May" 
            Height="35px" 
            Width="150px" OnClick="Bmay_Click" 
            />

          </td>
          <td style="width: 5%;">
                        <asp:Button 
            ID="Bjune" 
            runat="server" 
            Style="font-size:large;
                   font-weight:bold;
                   background-color: aqua; 
                   border-right: black 1px solid; 
                   border-top: black 1px solid; 
                   border-left: black 1px solid; 
                   border-bottom: black 1px solid;" 
            Text="June" 
            Height="35px" 
            Width="150px" OnClick="Bjune_Click" 
            />

          </td>
        </tr>
        
                <tr>
          <td style="width: 5%;">
            <asp:Button 
            ID="Bjuly" 
            runat="server" 
            Style="font-size:large;
                   font-weight:bold;
                   background-color: aqua; 
                   border-right: black 1px solid; 
                   border-top: black 1px solid; 
                   border-left: black 1px solid; 
                   border-bottom: black 1px solid;" 
            Text="July" 
            Height="35px" 
            Width="150px" OnClick="Bjuly_Click" 
            />

          </td>
          <td style="width: 5%;">
                        <asp:Button 
            ID="Baugust" 
            runat="server" 
            Style="font-size:large;
                   font-weight:bold;
                   background-color: aqua; 
                   border-right: black 1px solid; 
                   border-top: black 1px solid; 
                   border-left: black 1px solid; 
                   border-bottom: black 1px solid;" 
            Text="August" 
            Height="35px" 
            Width="150px" OnClick="Baugust_Click" 
            />

          </td>
          <td style="width: 5%;">
                        <asp:Button 
            ID="Bseptember" 
            runat="server" 
            Style="font-size:large;
                   font-weight:bold;
                   background-color: aqua; 
                   border-right: black 1px solid; 
                   border-top: black 1px solid; 
                   border-left: black 1px solid; 
                   border-bottom: black 1px solid;" 
            Text="September" 
            Height="35px" 
            Width="150px" OnClick="Bseptember_Click" 
            />

          </td>
          <td style="width: 5%;">
                        <asp:Button 
            ID="Boctober" 
            runat="server" 
            Style="font-size:large;
                   font-weight:bold;
                   background-color: aqua; 
                   border-right: black 1px solid; 
                   border-top: black 1px solid; 
                   border-left: black 1px solid; 
                   border-bottom: black 1px solid;" 
            Text="October" 
            Height="35px" 
            Width="150px" OnClick="Boctober_Click" 
            />

          </td>
          <td style="width: 5%;">
                        <asp:Button 
            ID="Bnovember" 
            runat="server" 
            Style="font-size:large;
                   font-weight:bold;
                   background-color: aqua; 
                   border-right: black 1px solid; 
                   border-top: black 1px solid; 
                   border-left: black 1px solid; 
                   border-bottom: black 1px solid;" 
            Text="November" 
            Height="35px" 
            Width="150px" OnClick="Bnovember_Click" 
            />

          </td>
          <td style="width: 5%;">
                        <asp:Button 
            ID="Bdecember" 
            runat="server" 
            Style="font-size:large;
                   font-weight:bold;
                   background-color: aqua; 
                   border-right: black 1px solid; 
                   border-top: black 1px solid; 
                   border-left: black 1px solid; 
                   border-bottom: black 1px solid;" 
            Text="December" 
            Height="35px" 
            Width="150px" OnClick="Bdecember_Click" 
            />

          </td>
        </tr>

    </table>
    <table>
        <tr>
            <td align="center">
                <asp:Chart
                    ID="Chart1" 
                    runat="server" 
                    Palette="SeaGreen"  
                    Width="900px">
                 <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                 </ChartAreas>
                </asp:Chart>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView 
                    ID="GV" 
                    runat="server"
                    Style="width: 800px">
                </asp:GridView>
            </td>
        </tr>
    </table>
    
    
    </div>
    
    </form>
</body>
</html>
