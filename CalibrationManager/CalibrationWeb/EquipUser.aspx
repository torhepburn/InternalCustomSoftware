<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EquipUser.aspx.cs" Inherits="CalibrationWeb.EquipUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Calibration - Change User</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table
          ID="t1"
          runat="server">
          
          <asp:TableRow 
            ID="tr1" 
            runat="server">
            <asp:TableCell 
              ID="tr1c1" 
              runat="server" 
              ColumnSpan="3" 
              Font-Bold="true">
              <asp:Label 
                ID="L1" 
                runat="server" 
                Style="left: 25px; position: relative; top: 0px" 
                Text="Calibrated Equipment" 
                Width="200px">
              </asp:Label>
            </asp:TableCell>
          </asp:TableRow>

          <asp:TableRow 
            ID="tr2" 
            runat="server">
             <asp:TableCell 
              ID="tr2c1" 
              runat="server" 
              BackColor="yellow">
              <asp:Label 
                ID="L2" 
                runat="server" 
                Text="Scan Badge" 
                Width="50px">
              </asp:Label>
           </asp:TableCell>
           <asp:TableCell 
              ID="tr2c2" 
              runat="server"> 
              <asp:TextBox 
                ID="txtEmployee" 
                runat="server" 
                Width="100px" 
                TabIndex="1" 
                AutoPostBack="true" 
                >
              </asp:TextBox>
              <asp:RequiredFieldValidator 
                ID="rfvEmplyee" 
                runat="server" 
                ControlToValidate="txtEmployee" 
                Display="Dynamic" 
                SetFocusOnError="true" 
                ErrorMessage="Badge Required">
              </asp:RequiredFieldValidator>
              
             
              
            </asp:TableCell>
            <asp:TableCell 
              ID="tr2c3" 
              runat="server"> 
              <asp:CheckBox 
                ID="cbEmployee" 
                runat="server" 
                Width="30" 
                TabIndex="-1" />
            </asp:TableCell>
          </asp:TableRow>
          
          
          <asp:TableRow 
            ID="tr4" 
            runat="server">
             <asp:TableCell 
              ID="tr4c1" 
              runat="server" 
              BackColor="yellow">
              <asp:Label 
                ID="Label1" 
                runat="server" 
                Text="Scan Item" 
                Width="50px">
              </asp:Label>
           </asp:TableCell>
           <asp:TableCell 
              ID="tr4c2" 
              runat="server"> 
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
        </asp:Table>
        
        <asp:Button 
          ID="Submit" 
          runat="server" 
          Text="Submit" 
          Width="75px"
          Style="left:64px; position: relative; top: 8px; z-index: 101;" 
          TabIndex="4" 
          OnClick="Submit_Click"
        />
        &nbsp;&nbsp;&nbsp;
        
         <asp:TextBox 
          ID="txtStatus"  
          runat="server" 
          Style="left: 15px; position:absolute; top: 215px; z-index: 100;" 
          Width="200px" 
          Wrap="true"> 
        </asp:TextBox>
        
        <a style="left:48px; position:absolute; top: 272px;"
        href="Http://dashboard-ct/mobiledashweb/">
        Back to Stock Scanner
        </a>
    </div>
    </form>
</body>
</html>
