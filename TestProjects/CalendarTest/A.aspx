<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="A.aspx.cs" Inherits="CalendarTest.A" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body style="font-family: Arial">
    <form id="form1" runat="server">
        <table style="z-index: 100; left: 0px; width: 1000px; position: relative; top: 0px;
            height: 1500px">
            <tr>
                <td style="width: 327px; height: 27px">
                   <asp:Button 
                        ID="Bscheduleing" 
                        runat="server" 
                        Style="z-index: 100; left: 40px; position: relative;
                        top: 0px"
                        Height = "35px"
                        Width = "150px"
                        BorderStyle="Solid"
                        BorderWidth="1px" 
                        Text="Sign Out Scheduling" BackColor="Aqua" Font-Bold="True" OnClick="Bscheduleing_Click" />
                   <asp:Button 
                        ID="Bquick" 
                        runat="server" 
                        Style="z-index: 101; left: 104px; position: relative;
                        top: 0px" 
                        Text="Quick Check Out"
                        Height = "35px"
                        Width = "150px"
                        BorderStyle="Solid"
                        BorderWidth="1px" BackColor="DarkSeaGreen" Font-Bold="True" OnClick="Bquick_Click"  
                        />
                   
                </td>
                <td style="height: 27px">
                
                    <asp:Button 
                        ID="Bday" 
                        runat="server" 
                        Style="z-index: 102; left: 50px; position: relative;
                        top: 0px" 
                        Text="Day" 
                        BackColor="Peru" 
                        BorderStyle="Solid" 
                        BorderWidth="1px" 
                        Font-Bold="True" 
                        Height="35px" 
                        Width="70px" />
                    <asp:Button 
                        ID="Bweek" 
                        runat="server" 
                        Style="z-index: 103; left: 100px; position: relative;
                        top: 0px" 
                        Text="Week" 
                        BackColor="Salmon" 
                        Font-Bold="True" 
                        Height="35px" 
                        Width="70px" />
                   <asp:Button 
                        ID="Bmonth" 
                        runat="server" 
                        Style="z-index: 104; left: 150px; position: relative;
                        top: 0px" 
                        Text="Month" 
                        BackColor="OrangeRed" 
                        Font-Bold="True" 
                        Height="35px" 
                        Width="70px" />
                   
                
                </td>
               
            </tr>
            
            <tr>
                
                <td colspan ="2" style="height: 50px">
                    <asp:Panel 
                        ID="Panel1" 
                        runat="server"
                         
                        Height="50px" 
                        Style="z-index: 100; left: 0px;
                        position: relative; top: -78px" 
                        Width="1000px"
                        BackColor="Yellow" 
                        BorderStyle="Solid"
                        BorderColor="Black"
                        BorderWidth="1px"
                        Text= "Info"
                        >
                    </asp:Panel>
                
                </td>
                
                
            </tr>
            <tr>
                <td style="width: 327px">
                </td>
                <td>
                </td>
               
            </tr>
            <tr>
                <td style="width: 327px">
                </td>
                <td>
                </td>
               
            </tr>
            <tr>
                <td style="width: 327px">
                </td>
                <td>
                </td>
               
            </tr>
            <tr>
                <td style="width: 327px">
                </td>
                <td>
                </td>
               
            </tr><tr>
                <td style="width: 327px">
                </td>
                <td>
                </td>
               
            </tr><tr>
                <td style="width: 327px">
                </td>
                <td>
                </td>
               
            </tr><tr>
                <td style="width: 327px">
                </td>
                <td>
                </td>
               
            </tr>
            <tr>
                <td style="width: 327px">
                </td>
                <td>
                </td>
               
            </tr>
            <tr>
                <td style="width: 327px">
                </td>
                <td>
                </td>
               
            </tr>
            <tr>
                <td style="width: 327px">
                </td>
                <td>
                </td>
               
            </tr>
            <tr>
                <td style="width: 327px">
                </td>
                <td>
                </td>
               
            </tr>
            <tr>
                <td style="width: 327px">
                </td>
                <td>
                </td>
               
            </tr>
                       <tr>
                <td style="width: 327px">
                </td>
                <td>
                </td>
               
            </tr>
            <tr>
                <td style="width: 327px">
                </td>
                <td>
                </td>
               
            </tr>
            <tr>
                <td style="width: 327px">
                </td>
                <td>
                </td>
               
            </tr>
            <tr>
                <td style="width: 327px">
                </td>
                <td>
                </td>
               
            </tr>
 
 
            
        </table>
    

    </form>
</body>
</html>
