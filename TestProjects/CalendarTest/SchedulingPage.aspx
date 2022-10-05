<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchedulingPage.aspx.cs" Inherits="CalendarTest.SchedulingPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body style="font-family: Arial">
    <form id="form1" runat="server">
    <div>
        </div>
        <asp:MultiView 
          ID="MultiView1" 
          ActiveViewIndex="0"
          runat="server">
            <asp:View ID="Page1" runat="server" >
                
                <asp:Table
                    Id="t1"
                    runat="server">
                  <asp:TableRow
                    ID="tr1"
                    runat="server">
                    <asp:TableCell
                      ID ="tr1c1"
                      ColumnSpan="2"
                      runat="server">
                      
                      <asp:Button 
                        ID ="Button1"
                        Text="Sign Out"
                        OnClick="BackButton_Command"
                        Height = "35"
                        Width = "70"
                        BorderStyle="Solid"
                        BorderWidth="1px"
                        runat="server" 
                        BackColor="#FAFA64" 
                        style="z-index: 100; left: 20px; position: relative; top: 0px" >
                      </asp:Button>
                
                      <asp:Button 
                        ID ="Button6"
                        Text="Quick Out"
                        OnClick="BackButton_Command"
                        Height = "35"
                        Width = "70"
                        BorderStyle="Solid"
                        BorderWidth="1px"
                        runat="server" 
                        BackColor="#FAFA64" 
                        style="z-index: 100; left: 115px; position: relative; top: 0px" >
                      </asp:Button>
                
                      <asp:Button 
                        ID ="page1Next"
                        Text="Day"
                        OnClick="NextButton_Command"
                        Height = "35"
                        Width = "70"
                        BorderStyle="Solid"
                        BorderWidth="1px"
                        runat="server" 
                        style="z-index: 104; left: 220px; position: relative; top: 0px" >
                      </asp:Button>
                
                      <asp:Button 
                        ID ="Button4"
                        Text="Week"
                        OnClick="NextButton_Command"
                        Height = "35"
                        Width = "70"
                        BorderStyle="Solid"
                        BorderWidth="1px"
                        runat="server" 
                        style="z-index: 104; left: 315px; position: relative; top: 0px" >
                      </asp:Button>
                
                      <asp:Button 
                        ID ="Button5"
                        Text="Month"
                        OnClick="NextButton_Command"
                        Height = "35"
                        Width = "70"
                        BorderStyle="Solid"
                        BorderWidth="1px"
                        runat="server" 
                        style="z-index: 104; left: 410px; position: relative; top: 0px" >
                      </asp:Button>
                    </asp:TableCell>  
                  </asp:TableRow>
                
                  <asp:TableRow
                    ID="tr2"
                    runat="server">
                    <asp:TableCell
                      ID ="tr2c1"
                      ColumnSpan="2"
                      runat="server"
                      BorderStyle="Solid"
                      BorderColor="Black"
                      BorderWidth="1px"
                      BackColor="#FAFA00" 
                      Height="50px" 
                      >
                        <asp:Label 
                            ID="Label1"
                            Font-size="30pt"
                            Text="Info:"
                            Style="left: 10px; position: relative; top: 5px" 
                            runat="server">
                         </asp:Label>
                    </asp:TableCell>
                  </asp:TableRow>
                  
                  <asp:TableRow
                    ID="tr3"
                    runat="server">
                   <asp:TableCell
                      ID="tr3c1"
                      ColumnSpan="2"
                      BackColor="#96FA96" 
                      BorderStyle="Solid"
                      BorderColor="Black"
                      BorderWidth="1px"
                      Height="50px"
                      runat="server">
                     <asp:Label
                       ID="Label2"
                       runat="server"
                       Text="Event"
                       Font-Bold="True"
                       Style="left: 10px; position: relative; top: -5px">
                     </asp:Label>
                     
                     <asp:TextBox
                        ID="tb1"
                        Style="left: 50px; position: relative; top: 0px"
                        width="500px"
                        height="25px"
                        BackColor="#C0FFFF"
                        runat="server">
                     </asp:TextBox>    
                   </asp:TableCell>
                  </asp:TableRow>
                  
                  <asp:TableRow
                    ID="tr4"
                    runat="server">
                   <asp:TableCell
                     ID="tr4c1"
                     BackColor="#96FA96" 
                     BorderStyle="Solid"
                     BorderColor="Black"
                     BorderWidth="1px"
                     Height="50px"
                     Width="500px"
                     runat="server">
                    <asp:Label
                       ID="Label6"
                       runat="server"
                       Text="User"
                       Font-Bold="True"
                       Style="left: 10px; position: relative; top: -5px">
                    </asp:Label>
                    
                    <asp:TextBox
                        ID="tb2"
                        Style="left: 50px; position: relative; top: 0px"
                        BackColor="#C0FFFF"
                        width="200px"
                        height="25px"
                        runat="server">
                     </asp:TextBox>    
                    
                   </asp:TableCell> 
                   
                   <asp:TableCell
                     ID="tr4c2"
                     BackColor="#96FA96" 
                     BorderStyle="Solid"
                     BorderColor="Black"
                     BorderWidth="1px"
                     Height="50px"
                     Width="500px"
                     runat="server">
                    <asp:Label
                       ID="Label3"
                       runat="server"
                       Text="Bay"
                       Font-Bold="True"
                       Style="left: 10px; position: relative; top: 0px">
                    </asp:Label>
                    
                    <asp:CheckBox
                      ID = "cb1"
                      Text= "Bay 1"
                      Style="left: 20px; position: relative; top: 0px"
                      runat="server" />
                    <asp:CheckBox
                      ID = "cb2"
                      Text= "Bay 2"
                      Style="left: 35px; position: relative; top: 0px"
                      runat="server" />
                    <asp:CheckBox
                      ID = "cb3"
                      Text= "Bay 3"
                      Style="left: 55px; position: relative; top: 0px"
                      runat="server" />
                    <asp:CheckBox
                      ID = "cb4"
                      Text= "Bay 4"
                      Style="left: 75px; position: relative; top: 0px"
                      runat="server" />
                    <asp:CheckBox
                      ID = "cb5"
                      Text= "Bay 5"
                      Style="left: 95px; position: relative; top: 0px"
                      runat="server" />
                    <asp:CheckBox
                      ID = "cb6"
                      Text= "N/A"
                      Style="left: 115px; position: relative; top: 0px"
                      runat="server" />
                      
                   </asp:TableCell> 
                  </asp:TableRow>
                   
                  <asp:TableRow
                     ID="tr5"
                     runat="server">
                   <asp:TableCell
                     ID="tr5c1"
                     ColumnSpan="2"
                     runat="server"
                     BorderStyle="Solid"
                     BorderColor="Black"
                     BorderWidth="1px"
                     BackColor="#FAFA00" 
                     Height="50px">
                    <asp:Label 
                        ID="Label5"
                        Font-size="30pt"
                        Text="Schedule:"
                        Style="left: 10px; position: relative; top: 5px" 
                        runat="server">
                    </asp:Label>
                   </asp:TableCell>
                  </asp:TableRow>
                  
                  <asp:TableRow
                    ID ="tr6"
                    runat="server"
                    Height="250px">
                   <asp:TableCell
                     ID ="tr6c1"
                     runat="server"
                     BorderStyle="Solid"
                     BorderColor="Black"
                     BorderWidth="1px"
                     BackColor="#FF80FF" 
                     Height="200px"
                     >
                    <asp:Label 
                       ID="Label7"
                       Font-size="12pt"
                       Text="From"
                       Font-bold="true"
                       Style="left: 10px; position: relative; top: 10px" 
                       runat="server">
                    </asp:Label>
                    
                    <asp:Calendar
                      ID ="CalFrom"
                      runat="server"
                      showgridlines="true" 
                      backcolor ="#7896C8"
                      Style="z-index: 105; left: 10px; position: relative; top: 20px"
                      >
                      <TitleStyle 
                        BackColor="Blue"
                        forecolor="yellow" />
                    </asp:Calendar>
                    
                    <asp:ListBox
                      ID ="Lb1"
                      rows="4"
                      width="80px"
                      backcolor="250,150,0"
                      Selectionmode="single"
                      Style="left: 300px; position: relative; top: -170px" 
                      runat="server">
                     <asp:ListItem>8:00 AM</asp:ListItem>
                     <asp:ListItem>8:30 AM</asp:ListItem>
                     <asp:ListItem>9:00 AM</asp:ListItem>
                     <asp:ListItem>9:30 AM</asp:ListItem>
                     <asp:ListItem>10:00 AM</asp:ListItem>
                     <asp:ListItem>10:30 AM</asp:ListItem>
                     <asp:ListItem>11:00 AM</asp:ListItem>
                     <asp:ListItem>11:30 AM</asp:ListItem>
                     <asp:ListItem>12:00 PM</asp:ListItem>
                     <asp:ListItem>1:00 PM</asp:ListItem>
                     <asp:ListItem>1:30 PM</asp:ListItem>
                     <asp:ListItem>2:00 PM</asp:ListItem>
                     <asp:ListItem>2:30 PM</asp:ListItem>
                     <asp:ListItem>30:00 PM</asp:ListItem>
                     <asp:ListItem>30:30 PM</asp:ListItem>
                     <asp:ListItem>4:00 PM</asp:ListItem>
                     <asp:ListItem>4:30 PM</asp:ListItem>
                     <asp:ListItem>5:00 PM</asp:ListItem>
                      
                    </asp:ListBox>
                    
                   
                   </asp:TableCell> 
                   
                   <asp:TableCell
                     ID ="tr6c2"
                     runat="server"
                     BorderStyle="Solid"
                     BorderColor="Black"
                     BorderWidth="1px"
                     BackColor="#FF80FF" 
                     >
                    <asp:Label 
                       ID="Label8"
                       Font-size="12pt"
                       Text="To"
                       Font-bold="true"
                       Style="left: 10px; position: relative; top: 10px" 
                       runat="server">
                    </asp:Label>
                    
                    <asp:Calendar
                      ID ="CalTo"
                      runat="server"
                      showgridlines="true" 
                      backcolor ="#7896C8"
                      Style="z-index: 105; left: 10px; position: relative; top: 20px"
                      >
                      <TitleStyle 
                        BackColor="Blue"
                        forecolor="yellow" />
                    </asp:Calendar>
                    
                    <asp:ListBox
                      ID ="Lb2"
                      rows="4"
                      width="80px"
                      backcolor="250,150,0"
                      Selectionmode="single"
                      Style="left: 300px; position: relative; top: -170px" 
                      runat="server">
                     <asp:ListItem>8:00 AM</asp:ListItem>
                     <asp:ListItem>8:30 AM</asp:ListItem>
                     <asp:ListItem>9:00 AM</asp:ListItem>
                     <asp:ListItem>9:30 AM</asp:ListItem>
                     <asp:ListItem>10:00 AM</asp:ListItem>
                     <asp:ListItem>10:30 AM</asp:ListItem>
                     <asp:ListItem>11:00 AM</asp:ListItem>
                     <asp:ListItem>11:30 AM</asp:ListItem>
                     <asp:ListItem>12:00 PM</asp:ListItem>
                     <asp:ListItem>1:00 PM</asp:ListItem>
                     <asp:ListItem>1:30 PM</asp:ListItem>
                     <asp:ListItem>2:00 PM</asp:ListItem>
                     <asp:ListItem>2:30 PM</asp:ListItem>
                     <asp:ListItem>30:00 PM</asp:ListItem>
                     <asp:ListItem>30:30 PM</asp:ListItem>
                     <asp:ListItem>4:00 PM</asp:ListItem>
                     <asp:ListItem>4:30 PM</asp:ListItem>
                     <asp:ListItem>5:00 PM</asp:ListItem>
                      
                    </asp:ListBox>
                   
                   </asp:TableCell> 
                   
                    
                  </asp:TableRow>
                  
                  <asp:TableRow
                     ID="tr8"
                     runat="server">
                   <asp:TableCell
                     ID="tr8c1"
                     ColumnSpan="2"
                     runat="server"
                     BorderStyle="Solid"
                     BorderColor="Black"
                     BorderWidth="1px"
                     BackColor="#FAFA00" 
                     Height="60px">
                    <asp:Label 
                        ID="Label9"
                        Font-size="30pt"
                        Text="Equipment:"
                        Style="left: 10px; position: relative; top: 5px" 
                        runat="server">
                    </asp:Label>
                   </asp:TableCell>
                  </asp:TableRow>
                  <asp:TableRow
                    ID="tr9"
                    runat="server"
                    height="400px">
                   <asp:TableCell
                     ID="tr9c1"
                     runat="server"
                     BorderStyle="Solid"
                     BorderColor="Black"
                     BorderWidth="1px"
                     BackColor="100,200,250" >
                    <asp:Button
                      ID="gridtab1"
                      Height = "35"
                      Width = "100"
                      BorderStyle="Solid"
                      BorderWidth="1px"
                      Text="Systems"
                      Font-bold="true"
                      runat="server" 
                      BackColor="250,250,0" 
                      style="z-index: 100; left: 30px; position: relative; top: -30px" />
                    <asp:Button
                      ID="gridtab2"
                      Height = "35"
                      Width = "100"
                      BorderStyle="Solid"
                      BorderWidth="1px"
                      Text="Objectives"
                      Font-bold="true"
                      runat="server" 
                      BackColor="250,250,0" 
                      style="z-index: 100; left: 40px; position: relative; top: -30px" />
                    <asp:Button
                      ID="gridtab3"
                      Height = "35"
                      Width = "100"
                      BorderStyle="Solid"
                      BorderWidth="1px"
                      Text="Flats/Spheres"
                      Font-bold="true"
                      runat="server" 
                      BackColor="250,250,0" 
                      style="z-index: 200; left: 50px; position: relative; top: -30px" />
                    <asp:Button
                      ID="gridtab4"
                      Height = "35"
                      Width = "100"
                      BorderStyle="Solid"
                      BorderWidth="1px"
                      Text="Accessories"
                      Font-bold="true"
                      runat="server" 
                      BackColor="250,250,0" 
                      style="z-index: 100; left: 60px; position: relative; top: -30px" />
                    <asp:GridView
                        id="GV1"
                        runat="server"
                        AutoGenerateColumns="False" 
                        DataSourceID="SqlDataSource2"
                        Style="z-index: 102; left: 10px; position: relative; top: 0px">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="SN" HeaderText="SN" SortExpression="SN" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DemoLabConnectionString %>"
                    SelectCommand="SELECT [Name], [SN] FROM [Inventory] ORDER BY [Name]">
                </asp:SqlDataSource>
                    
                      
                     
                     
                   </asp:TableCell>
                    
                    
                  </asp:TableRow>
                  
                
                </asp:Table>
                
                
                
                
           
                
                 
          
                  
                  
                    
            </asp:View>
            
            <asp:View ID="Page2" runat="server">
              <asp:Button 
                    ID ="Button2"
                    Text="Sign Out"
                    OnClick="BackButton_Command"
                    Height = "25"
                    Width = "70"
                    runat="server" Font-Bold="True" BackColor="#FAAFAF" >
                  </asp:Button>
                <asp:Button ID="Button3" runat="server" Height="25" OnClick="NextButton_Command"
                    Style="z-index: 100; left: 96px; position: absolute; top: 200px" Text="Day" Width="70" />
                  
              <br />
                
                    <asp:Label 
                        ID="Label4"
                        Font-bold="true"
                        Text="Sign Out"
                        runat="server"
                        AssociatedControlID="Page1" style="z-index: 103; left: 0px; position: absolute; top: 0px">
                    </asp:Label>
                &nbsp;<br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1"
                    Style="z-index: 102; left: 168px; position: absolute; top: 224px">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="SN" HeaderText="SN" SortExpression="SN" />
                        <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DemoLabConnectionString %>"
                    SelectCommand="SELECT [Name], [SN], [Category] FROM [Inventory] ORDER BY [Name], [Category]">
                </asp:SqlDataSource>
                  
                  
            
            
            </asp:View>
        
        </asp:MultiView>
    </form>
</body>
</html>
