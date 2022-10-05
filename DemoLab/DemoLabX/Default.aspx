<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DemoLabX.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Zygo Demo Inventory</title>
    <style type ="text/css">
    table
    {
       font-family: Arial; 
       font-size:14pt;
       font-weight:bold;
       padding:20px;
       
       
    }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
    <table>
        <tr>
            <td>
                
            </td>
            <td>
                Choose Location

            </td>
            <td>


            </td>
            <td>


            </td>

        </tr>
        <tr>
            <td>


            </td>
            <td>
                <asp:Button 
                    ID="bDallas" 
                    runat="server" 
                    Text="Dallas" 
                    Font-Size="Large"
                    OnClick="bDallas_Click" 
                    Width="150" Height="150" 
                    BackColor="#3399ff"
                     />


            </td>
            <td>


            </td>
            <td>
                <asp:Button 
                    ID="bTucson" 
                    runat="server" 
                    Text="Tucson" Font-Size="Large"
                    OnClick="bTucson_Click"
                    Width="150" Height="150" BackColor="#33cc33"
                    />

            </td>

        </tr>
        <tr>
            <td>
                
            </td>
            <td>
                

            </td>
            <td>
                <asp:Button 
                    ID ="bMiddlefield" 
                    runat="server" Text="Middlefield" Font-Size="Large"
                    OnClick="bMiddlefield_Click" 
                    Width="150" Height="150" BackColor="Yellow"
                    />

            </td>
            <td>


            </td>

        </tr>
        <tr>
            <td>
                

            </td>
            <td>
                <asp:Button 
                    ID="bSantaClara" 
                    runat="server" 
                    OnClick="bSantaClara_Click" 
                    Text="Santa Clara" 
                    Font-Size="Large" 
                    Width="150" Height="150" BackColor="#ff3300"
                    
                    />


            </td>
            <td>
                
            </td>
            <td>
                 <asp:Button 
                    ID="Button1" 
                    runat="server" 
                    OnClick="bCostaMesa_Click" 
                    Text="Costa Mesa" 
                    Font-Size="Large" 
                    Width="150" Height="150"  BackColor="#cc33ff"
                    />

            </td>

        </tr>


    </table>
    </div>
    </form>
</body>
</html>
