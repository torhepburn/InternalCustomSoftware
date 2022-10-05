<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demo.aspx.cs" Inherits="DemoLabScan.Demo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Demo Lab Equipment</title>
</head>
<body style="height: 277px">
    <form id="form1" runat="server">
    <div>
         
        <asp:Table
            ID="t1"
            runat="server" 
            Width="750px">
          
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
                Text="Demo Lab Equipment" 
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
                AutoPostBack="false" 
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
           
          </asp:TableRow>
          
          
          <asp:TableRow 
            ID="tr3" 
            runat="server">
             <asp:TableCell 
              ID="tr3c1" 
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
              ID="tr3c2" 
              runat="server"> 
              <asp:TextBox 
                ID="txtItem" 
                runat="server" 
                Width="400px" 
                TabIndex="2">
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

          <asp:TableRow 
            ID="tr4" 
            runat="server">
             <asp:TableCell 
              ID="Ttr4c1" 
              runat="server" 
              BackColor="yellow">
              <asp:Label 
                ID="Label2" 
                runat="server" 
                Text="Comments" 
                Width="50px">
              </asp:Label>
           </asp:TableCell>
           <asp:TableCell 
              ID="tr4c2" 
              runat="server">
               
              <asp:TextBox 
                ID="txtComments" 
                runat="server" 
                Width="400px" 
                TabIndex="3">
              </asp:TextBox>
              
            </asp:TableCell>
            
          </asp:TableRow>

          <asp:TableRow 
            ID="tr5" 
            runat="server">
             
             <asp:TableCell 
              ID="tr5c1" 
              runat="server" 
              BackColor="yellow">
              <asp:Label 
                ID="Label3" 
                runat="server" 
                Text="Action" 
                Width="50px">
              </asp:Label>
             </asp:TableCell>
           
              <asp:TableCell 
                ID="tr5c2" 
                runat ="server"> 
               <asp:CheckBox 
            ID="cbInOut" 
            runat="server" TabIndex="4"
                    
            Text="Checking In " 
            AutoPostBack="true" 
            Checked="true" BackColor="Orange" 
            OnCheckedChanged="cbInOut_CheckedChanged" />
              
              </asp:TableCell>
            
          </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>


                </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button 
          ID="Submit" 
          runat="server" 
          Text="Submit" 
          Width="75px"
          Style="left:45px; position:relative;  z-index: 101;" 
          TabIndex="5" 
          OnClick="Submit_Click"
        />

                </asp:TableCell>

            </asp:TableRow>

          <asp:TableRow>
              <asp:TableCell>
                 <asp:TextBox 
                    ID="txtStatus"  
                    runat="server" 
                    Style="left: 18px;  z-index: 100;" 
                    Width="200px" 
                    Wrap="true"> 
        </asp:TextBox>


              </asp:TableCell>
              <asp:TableCell>
                   <a href="http://midprj01/demolab/viewinventory.aspx">Link to Inventory View</a> </td>

              </asp:TableCell>


          </asp:TableRow>              

        </asp:Table>
   
    </div>
       
    </form>
</body>
</html>
