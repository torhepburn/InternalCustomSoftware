<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EquipLocation.aspx.cs" Inherits="CalibrationWeb.EquipLocation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calibration Admin</title>
</head>
<body>
    <form id="form1" runat="server" defaultfocus="txtLocation">
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
            ID="tr3" 
            runat="server">
             <asp:TableCell 
              ID="tr3c1" 
              runat="server" 
              BackColor="yellow">
              <asp:Label 
                ID="L3" 
                runat="server" 
                Text="Scan Location" 
                Width="50px">
              </asp:Label>
           </asp:TableCell>
           <asp:TableCell 
              ID="tr3c2" 
              runat="server"> 
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
              ID="tr3c3" 
              runat="server"> 
              <asp:CheckBox 
                ID="cbLocation" 
                runat="server" 
                Width="30" 
                TabIndex="-1" Text="Keep Location" />
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
