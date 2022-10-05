<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="DemoLabX._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
            </hgroup>
            
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Demo Lab Equipment</h3>
            <asp:Table
            ID="t1"
            runat="server" 
            Width="870px">
          
          <asp:TableRow 
            ID="tr1" 
            runat="server">
            <asp:TableCell 
              ID="tr1c1" 
              runat="server" 
              >
              
            </asp:TableCell>
          </asp:TableRow>

          <asp:TableRow 
            ID="tr2" 
            runat="server">
             <asp:TableCell 
              ID="tr2c1" 
              runat="server" 
              HorizontalAlign="Right" 
              BackColor="yellow">
              <asp:Label 
                ID="L2" 
                runat="server" 
                Text="Scan or Enter Badge Number" 
                Font-Bold="true" 
                Width="200px">
              </asp:Label>
           </asp:TableCell>
           <asp:TableCell 
              ID="tr2c2" 
              runat="server"> 
              <asp:TextBox 
                ID="txtEmployee" 
                runat="server" 
                Width="100px" 
                BackColor="#ffff99" 
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
            
            <asp:TableCell>
              <asp:CheckBox 
                  ID="cbEmployee" 
                  runat ="server" 
                  Text="One Employee/Many Items" ToolTip="Check this box if you want your badge number to persist between submissions." 
                   />
            </asp:TableCell> 
          </asp:TableRow>
          
          
          <asp:TableRow 
            ID="tr3" 
            runat="server">
             <asp:TableCell 
              ID="tr3c1" 
              runat="server" 
              HorizontalAlign="Right"
              BackColor="yellow">
              <asp:Label 
                ID="Label1" 
                runat="server" 
                Text="Scan or Enter Item Number" 
                Font-Bold="true" 
                Width="200px">
              </asp:Label>
           </asp:TableCell>
           <asp:TableCell 
              ID="tr3c2" 
              runat="server"> 
              <asp:TextBox 
                ID="txtItem" 
                runat="server" 
                Width="400px" 
                BackColor="#ffff99" 
                TabIndex="2"
                  >
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
              HorizontalAlign="Right" 
              BackColor="yellow">
              <asp:Label 
                ID="Label2" 
                runat="server" 
                Text="Enter Comments" 
                Font-Bold="true"
                Width="200px">
              </asp:Label>
           </asp:TableCell>
           <asp:TableCell 
              ID="tr4c2" 
              runat="server">
               
              <asp:TextBox 
                ID="txtComments" 
                runat="server" 
                Width="400px"
                BackColor="#ffff99"  
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
              Text="Checking In" 
              Font-Bold="true"  
              HorizontalAlign="Right" 
              BackColor="yellow">
             
             </asp:TableCell>
           
              <asp:TableCell 
                ID="tr5c2" 
                runat ="server"
                HorizontalAlign="Left">
               <asp:RadioButton 
                   ID="rbIn" 
                   GroupName="action"
                   runat="server" BorderColor="Green" BorderStyle="Solid"
                   TabIndex="4" ToolTip="Click on this button when checking in." 
                   AutoPostBack="true"
                   Checked="true" 
                   />
              </asp:TableCell>
              <asp:TableCell>
                  The tabs at the top will take you to different pages.

              </asp:TableCell>
            
          </asp:TableRow>
          
          <asp:TableRow>
              <asp:TableCell 
                  ID ="tr6c1" 
                  runat="server" 
                  Text="Checking Out"
                  HorizontalAlign="Right" 
                  Font-Bold="true" 
                  BackColor="yellow">
                  

              </asp:TableCell>
              <asp:TableCell ID ="tr6c2" runat="server">
                   <asp:RadioButton 
                   ID="rbOut" 
                   GroupName="action" ToolTip="Click on this button when checking out." 
                   runat="server" BorderColor="Blue" BorderStyle="Solid"
                   AutoPostBack="true"
                   />

              </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell 
                    ID ="tr7c1" 
                    runat="server" 
                    Text ="Sold"
                    Font-Bold="true"
                    HorizontalAlign="Right"   
                    BackColor="yellow">
                 
                </asp:TableCell>
                <asp:TableCell>
                     <asp:RadioButton 
                   ID="rbSold" 
                   GroupName="action" ToolTip="Click this button when marking item as sold." 
                   runat="server" BorderColor="Red" BorderStyle="Solid"
                   AutoPostBack="true"
                   />

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
                        Text="Submit" ToolTip="Click on this button after badge number and item number have been enterred." 
                        Width="75px"
                        Style="left:45px; 
                        position:relative;  
                        z-index: 101;" 
                        TabIndex="5" 
                        OnClick="Submit_Click"
                    />

                
                </asp:TableCell>
                <asp:TableCell>
                    <asp:CheckBox
                     ID="cbAdd" 
                     runat="server" ToolTip="" 
                     TextAlign="Right"  
                     Text="Add Item" 
                     Font-Bold="true"
                 />


                </asp:TableCell>
            </asp:TableRow>

          <asp:TableRow>
              <asp:TableCell>
                 <asp:TextBox 
                    ID="txtStatus"  
                    runat="server" 
                    Style="left: 18px;  
                    z-index: 100;" 
                    Width="200px"
                    BackColor="#ffff99"  
                    Wrap="true"> 
                 </asp:TextBox>
              </asp:TableCell>

              <asp:TableCell>
                 
              </asp:TableCell>
          </asp:TableRow>              

        </asp:Table>

</asp:Content>
