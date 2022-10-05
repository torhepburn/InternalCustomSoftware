<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalScan.aspx.cs" Inherits="CalibrationWeb.CalScan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calibration Data Entry</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="t1" runat="server" Width="100%">
          
          <asp:TableRow ID="tr1" runat="server" Height="50px">
            <asp:TableCell 
              ID="tr1c1" 
              runat="server" 
              ColumnSpan="3" 
              Font-Bold="true" HorizontalAlign="Center">
              Calibration Data Entry
            </asp:TableCell>
              
          </asp:TableRow>

          <asp:TableRow 
            ID="tr2" 
            runat="server" Height="50px">
             <asp:TableCell 
              ID="tr2c1" 
              runat="server" 
              BackColor="yellow">
              <asp:Label 
                ID="L3" 
                runat="server" 
                Text="Scan Location" 
                Width="150px">
              </asp:Label>
           </asp:TableCell>
           <asp:TableCell 
              ID="tr2c2" 
              runat="server" BackColor="LightBlue"> 
              <asp:TextBox 
                ID="txtLocation" 
                runat="server" 
                Width="100px" 
                TabIndex="2" >
              </asp:TextBox>
              <asp:RequiredFieldValidator 
                ID="rfvLocation" 
                runat="server" 
                ControlToValidate="txtLocation" 
                Display="Dynamic" 
                SetFocusOnError="true" 
                ErrorMessage="Location Required">
              </asp:RequiredFieldValidator>
            </asp:TableCell>
            <asp:TableCell 
              ID="tr2c3" 
              runat="server" BackColor="LightBlue"> 
              <asp:CheckBox 
                ID="cbLocation" 
                runat="server" 
                Width="200" TextAlign="Right" 
                TabIndex="-1" Text=" Keep Location" />
            </asp:TableCell>
          </asp:TableRow>
          
          <asp:TableRow 
            ID="tr3" 
            runat="server" Height="50px">
             <asp:TableCell 
              ID="tr3c1" 
              runat="server" 
              BackColor="yellow">
              <asp:Label 
                ID="Label1" 
                runat="server" 
                Text="Scan Item" 
                Width="150px">
              </asp:Label>
           </asp:TableCell>
           <asp:TableCell 
              ID="tr3c2" 
              runat="server" BackColor="LightBlue"> 
              <asp:TextBox 
                ID="txtItem" 
                runat="server" 
                Width="100px" 
                TabIndex="3">
              </asp:TextBox>
              <asp:RequiredFieldValidator 
                ID="rfvItem" 
                runat="server" 
                ControlToValidate="txtItem" 
                Display="Dynamic" 
                SetFocusOnError="true" 
                ErrorMessage="Item Required">
              </asp:RequiredFieldValidator>
            </asp:TableCell>
          </asp:TableRow>
          
            <asp:TableRow ID="tr4" runat="server" Height="50px" >
            <asp:TableCell 
              ID="tr4c1" 
              runat="server" 
              BackColor="LightBlue">
              <asp:Label 
                ID="Label2" 
                runat="server"
                Width="150px">
              </asp:Label>
           </asp:TableCell>
          </asp:TableRow>
        <asp:TableRow ID="tr5" runat="server" Height="50px">
            <asp:TableCell 
              ID="tr5c1" 
              runat="server" 
              BackColor="yellow">
              <asp:Label 
                ID="Label3" 
                runat="server"  
                Text="Temperature"
                Width="150px">
              </asp:Label>
            </asp:TableCell>
            <asp:TableCell 
              ID="tr5c2" 
              runat="server" BackColor="LightBlue"> 
              <asp:TextBox 
                ID="tbTemperature" 
                runat="server" 
                Width="100px" 
                TabIndex="4">
              </asp:TextBox>
            </asp:TableCell>
          </asp:TableRow>  
        
        <asp:TableRow ID="tr6" runat="server" Height="50px">
            <asp:TableCell 
              ID="tr6c1" 
              runat="server" 
              BackColor="yellow">
              <asp:Label 
                ID="Label4" 
                runat="server"  
                Text="Humidity"
                Width="150px">
              </asp:Label>
           </asp:TableCell>
            <asp:TableCell 
              ID="tr6c2" 
              runat="server" BackColor="LightBlue"> 
              <asp:TextBox 
                ID="tbHumidity" 
                runat="server" 
                Width="100px" 
                TabIndex="5">
              </asp:TextBox>
            </asp:TableCell>
          </asp:TableRow>
            
           <asp:TableRow ID="TableRow1" runat="server" Height="50px">
            <asp:TableCell 
              ID="TableCell1" 
              runat="server" 
              BackColor="yellow">
              <asp:Label 
                ID="Label5" 
                runat="server"  
                Text="Calibrator Initials"
                Width="150px">
              </asp:Label>
           </asp:TableCell>
            <asp:TableCell 
              ID="TableCell2" 
              runat="server" BackColor="LightBlue"> 
              <asp:TextBox 
                ID="tbInspector" 
                runat="server" 
                Width="100px" 
                TabIndex="6">
              </asp:TextBox>
            </asp:TableCell>
          </asp:TableRow>  
 
        
            <asp:TableRow ID="tr7" runat="server" Height="50px">
            <asp:TableCell 
              ID="tr7c1" 
              runat="server" ColumnSpan="3" 
              BackColor="lightblue" HorizontalAlign="Center">
              <asp:Button 
                ID="Submit" 
                runat="server" 
                Text="Submit" 
                Width="75px"
                TabIndex="4" 
                OnClick="Submit_Click"
            />
           </asp:TableCell>
          </asp:TableRow>  
        
            <asp:TableRow ID="tr8" runat="server" Height="50px">
            <asp:TableCell 
              ID="tr8c1" 
              runat="server" ColumnSpan="3" HorizontalAlign="Center"
                 
              BackColor="lightblue">
              <asp:TextBox 
          ID="txtStatus"  
          runat="server" 
          Style="left: 15px; position:relative; " 
          Width="200px" 
          Wrap="true"> 
        </asp:TextBox>
           </asp:TableCell>
          </asp:TableRow>  
        
        </asp:Table>
        
        
        
         
        
    </div>
    </form>
</body>
</html>
