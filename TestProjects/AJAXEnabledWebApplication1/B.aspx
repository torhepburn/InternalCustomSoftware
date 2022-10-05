<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B.aspx.cs" Inherits="AJAXEnabledWebApplication1.D" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager 
            ID="ScriptManager1" 
            runat="server"
            EnablePartialRendering="true">
        </asp:ScriptManager> 
    <div>
        &nbsp;
        
        <asp:UpdatePanel runat="server" ID = "up2" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Button ID="Bquick" runat="server" Style="z-index: 100; left: 264px; position: absolute;
                    top: 0px" Text="Quick Sign Out" Height="35px" Width="150px" />
            </ContentTemplate>
        </asp:UpdatePanel>
            
        <    
        <asp:Button ID="Bday" runat="server" Style="z-index: 101; left: 496px; position: absolute;
            top: 0px" Text="Day" Height="35px" Width="70px" />
        <asp:Button ID="Bweek" runat="server" Style="z-index: 102; left: 608px; position: absolute;
            top: 0px" Text="Week" Height="35px" Width="70px" />
        <asp:Button ID="Bmonth" runat="server" Style="z-index: 103; left: 728px; position: absolute;
            top: 0px" Text="Month" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" Height="35px" Width="70px" />
        <asp:Button 
            ID="Bscheduling" 
            runat="server" 
            Style="z-index: 104; 
                   left: 24px; 
                   position: relative;
                   top: 10px; 
                   font-weight: bold; 
                   font-family: Arial; 
                   background-color: aqua; 
                   border-right: black 1px solid; 
                   border-top: black 1px solid; 
                   border-left: black 1px solid; 
                   border-bottom: black 1px solid;" 
            Text="Sign Out Scheduling" 
            Height="35px" 
            Width="150px" OnClick="Bscheduling_Click" />
    </div>        
    <div>        
            
        <asp:Panel 
            ID="Panel1" 
            runat="server" 
            Height="50px" 
            Style="border-right: black 1px solid;
                   border-top: black 1px solid; 
                   z-index: 105; 
                   left: 0px; 
                   border-left: black 1px solid;
                   border-bottom: black 1px solid; 
                   position: relative; 
                   top: 24px; 
                   background-color: yellow"
            Width="1000px" >
            <asp:Label ID="Label1" runat="server" Style="z-index: 100; left: 16px; position: absolute;
                top: 8px; font-weight: bold; font-size: 24pt; font-family: Arial;" Text="Info:" Width="96px"></asp:Label>
            
        </asp:Panel>
    </div>        
    <div>  
        <asp:Panel 
            ID="Panel2" 
            runat="server" 
            Height="50px" 
            Style="z-index: 106; 
                   left: 0px;
                   position: relative; 
                   top: 32px; 
                   font-family: Arial; 
                   background-color: #96fa96; border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid;" 
            Width="1000px">
            <asp:Label 
                ID="Label2" 
                runat="server" 
                Font-Bold="True" 
                Style="z-index: 100; 
                       left: 10px;
                       position: relative; 
                       top: 20px"
                Text="Event">
            </asp:Label>
            <asp:TextBox 
                ID="TextBox1" 
                runat="server" 
                Style="z-index: 101; 
                       left: 88px; 
                       position: absolute;
                       top: 16px; 
                       background-color: #ccffff" 
                Width="300px">
            </asp:TextBox>
            
            
        </asp:Panel>
        <asp:Panel 
            ID="Panel3" 
            runat="server" 
            Height="50px" 
            Style="z-index: 107; 
                   left: 0px;
                   position: relative; 
                   top: 44px; 
                   border-right: 1px solid; 
                   border-top: 1px solid; 
                   font-weight: bold; 
                   border-left: 1px solid; 
                   border-bottom: 1px solid; 
                   font-family: Arial; 
                   background-color: #96fa96;" 
            Width="500px">
            <asp:Label ID="Label3" runat="server" Style="z-index: 100; left: 16px; position: absolute;
                top: 16px" Text="User"></asp:Label>
            
                
            <asp:TextBox ID="TextBox2" runat="server" Style="z-index: 102; left: 88px; position: absolute;
                top: 16px; background-color: #ccffff" Width="300px">
            </asp:TextBox>
            
        </asp:Panel>
        
        
        <asp:Panel 
            ID="Panel4" 
            runat="server" 
            Height="48px" 
            Style="z-index: 108; 
                   left: 512px;
                   position: relative; 
                   top: -6px; 
                   border-right: 1px solid; 
                   border-top: 1px solid; 
                   border-left: 1px solid; 
                   border-bottom: 1px solid; 
                   font-family: Arial; 
                   background-color: #96fa96;" 
            Width="488px">
            <asp:RadioButton ID="RadioButton1" runat="server" 
                Style="z-index: 100; left: 8px; font-family: Arial; position: absolute; top: 16px"
                Text="Bay 1" 
                GroupName="bays"/>
            &nbsp;
            <asp:RadioButton ID="RadioButton6" runat="server" 
                Style="z-index: 102; left: 408px; font-family: Arial; position: absolute; top: 16px"
                Text="N/A" 
                GroupName="bays"/>
            <asp:RadioButton ID="RadioButton5" runat="server" 
                Style="z-index: 103; left: 304px; font-family: Arial; position: absolute; top: 16px"
                Text="Bay 5" 
                GroupName="bays"/>
            <asp:RadioButton ID="RadioButton4" runat="server" 
                Style="z-index: 104; left: 224px; font-family: Arial; position: absolute; top: 16px"
                Text="Bay 4" 
                GroupName="bays"/>
            <asp:RadioButton ID="RadioButton3" runat="server" 
                Style="z-index: 105; left: 152px; font-family: Arial; position: absolute; top: 16px"
                Text="Bay 3" 
                GroupName="bays"/>
            <asp:RadioButton ID="RadioButton2" runat="server" 
                Style="z-index: 107; left: 80px; font-family: Arial; position: absolute; top: 16px"
                Text="Bay 2"
                GroupName="bays" />
        </asp:Panel>
    
    </div>
    <div>
        <asp:Panel 
            ID="Panel5" 
            runat="server" 
            Height="50px" 
            Style="border-right: black 1px solid;
                   border-top: black 1px solid; 
                   z-index: 109; 
                   left: 0px; 
                   border-left: black 1px solid;
                   border-bottom: black 1px solid; 
                   position: relative; 
                   top: 0px; 
                   background-color: yellow"
            Width="1000px" >
            <asp:Label ID="Label4" runat="server" Style="z-index: 100; left: 16px; position: relative;
                top: 8px; font-weight: bold; font-size: 24pt; font-family: Arial;" Text="Schedule:" Width="96px"></asp:Label>
            
        </asp:Panel>
     </div>
       
    <div>
        <asp:Panel 
            ID="Panel6" 
            runat="server" 
            Height="320px" 
            Style="border-right: black 1px solid;
                   border-top: black 1px solid; 
                   z-index: 110; 
                   left: 0px; 
                   border-left: black 1px solid;
                   border-bottom: black 1px solid; 
                   position: relative; 
                   top: 8px; 
                   background-color: #ee82ee; font-weight: bold; font-family: Arial;"
            Width="496px" Font-Size="12pt" >
          <asp:Label 
            ID="Label5" 
            runat="server" 
            Style="z-index: 100; 
                   left: 16px; 
                   position: relative;
                   top: -38px" 
            Text="From"></asp:Label>
            
            &nbsp;&nbsp;
            <asp:Calendar ID="Calendar1" runat="server" Height="216px" ShowGridLines="True" Style="z-index: 101;
                left: 8px; position: absolute; top: 56px; background-color: #6699ff">
                <TitleStyle BackColor="Blue" />
            </asp:Calendar>
            
            <asp:ListBox
                      ID ="Lb2"
                      rows="4"
                      width="80px"
                      backcolor="250,150,0"
                      Selectionmode="single"
                      Style="left: 288px; position: relative; top: 136px; z-index: 102;" 
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
                              
        </asp:Panel>
        
        <asp:Panel 
            ID="Panel7" 
            runat="server" 
            Height="320px" 
            Style="border-right: black 1px solid;
                   border-top: black 1px solid; 
                   z-index: 112; 
                   left: 504px; 
                   border-left: black 1px solid;
                   border-bottom: black 1px solid; 
                   position: relative; 
                   top: -310px; 
                   background-color: #ee82ee; font-weight: bold; font-family: Arial;"
            Width="496px" Font-Size="12pt" >
          <asp:Label 
            ID="Label6" 
            runat="server" 
            Style="z-index: 100; left: 8px; position: relative;
                top: 16px" 
            Text="To"></asp:Label>
            
            &nbsp;&nbsp;
            <asp:Calendar ID="Calendar2" runat="server" Height="216px" ShowGridLines="True" Style="z-index: 101;
                left: 24px; position: absolute; top: 64px; background-color: #6699ff">
                <TitleStyle BackColor="Blue" />
            </asp:Calendar>
            &nbsp;
            
            <asp:ListBox
                      ID ="ListBox1"
                      rows="4"
                      width="80px"
                      backcolor="250,150,0"
                      Selectionmode="single"
                      Style="left: 352px; position: absolute; top: 136px; z-index: 103;" 
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
 
        </asp:Panel>
    
    </div>
    
    <div>
        <asp:Panel 
            ID="Panel8" 
            runat="server" 
            Height="50px" 
            Style="border-right: black 1px solid;
                   border-top: black 1px solid; 
                   z-index: 113; 
                   left: 0px; 
                   border-left: black 1px solid;
                   border-bottom: black 1px solid; 
                   position: relative; 
                   top: -302px; 
                   background-color: yellow"
            Width="1000px" >
            <asp:Label ID="Label7" runat="server" Style="z-index: 100; left: 16px; position: relative;
                top: 8px; font-weight: bold; font-size: 24pt; font-family: Arial;" Text="Equipment:" Width="96px"></asp:Label>
        </asp:Panel>
    </div>
    
    <div>
        <asp:UpdatePanel 
            ID="UpdatePanel1" 
            runat="server">
        <ContentTemplate>
        <asp:Panel 
            ID="Panel9" 
            runat="server" 
            Height="300px" 
            Width="485px"
            Style="z-index: 114;
                   border-right: 1px solid;
                   border-top: 1px solid;  
                   border-left: 1px solid; 
                   border-bottom: 1px solid;
                   position: relative;
                   left: 10px;
                   top: -300px;
                   font-family: Arial;   
                   background-color: #66ccff"
            >
            &nbsp;
            <asp:SqlDataSource 
                ID="SqlDataSource1" 
                runat="server" 
                ConnectionString="<%$ ConnectionStrings:DemoLabConnectionString %>"
                SelectCommand="SELECT Name, SN FROM Inventory WHERE (Category = 'System')">
            </asp:SqlDataSource>
            <asp:SqlDataSource 
                ID="SqlDataSource2" 
                runat="server" 
                ConnectionString="<%$ ConnectionStrings:DemoLabConnectionString %>"
                SelectCommand="SELECT Name, SN FROM Inventory WHERE (Category = 'Objective')">
            </asp:SqlDataSource>
            <asp:SqlDataSource 
                ID="SqlDataSource3" 
                runat="server" 
                ConnectionString="<%$ ConnectionStrings:DemoLabConnectionString %>"
                SelectCommand="SELECT Name, SN FROM Inventory WHERE (Category = 'Flat/sphere')">
            </asp:SqlDataSource>
            <asp:SqlDataSource 
                ID="SqlDataSource4" 
                runat="server" 
                ConnectionString="<%$ ConnectionStrings:DemoLabConnectionString %>"
                SelectCommand="SELECT Name, SN FROM Inventory WHERE (Category = 'accessory')">
            </asp:SqlDataSource>
            &nbsp;
            <asp:Button ID="Bflats" runat="server" Height="40px" Style="border-right: black 1pt solid;
                border-top: black 1pt solid; z-index: 100; left: 256px; border-left: black 1pt solid;
                border-bottom: black 1pt solid; font-family: Arial; position: absolute; top: 16px;
                background-color: #ffff00; font-weight: bold;" Text="Flats/Spheres" Width="96px" OnClick="Bflats_Click" />
            <asp:Button ID="Baccessories" runat="server" Height="40px" Style="border-right: black 1pt solid;
                border-top: black 1pt solid; z-index: 101; left: 376px; border-left: black 1pt solid;
                border-bottom: black 1pt solid; font-family: Arial; position: absolute; top: 16px;
                background-color: #ffff00; font-weight: bold;" Text="Accessories" Width="96px" OnClick="Baccessories_Click" />
            <asp:Button ID="Bsystems" runat="server" Height="40px" Style="border-right: black 1pt solid;
                border-top: black 1pt solid; z-index: 102; left: 24px; border-left: black 1pt solid;
                border-bottom: black 1pt solid; font-family: Arial; position: absolute; top: 16px;
                background-color: #ffff00; font-weight: bold;" Text="Systems" Width="96px" OnClick="Bsystems_Click" />
            <asp:Button ID="Bobjectives" runat="server" Height="40px" Style="border-right: black 1pt solid;
                border-top: black 1pt solid; z-index: 103; left: 144px; border-left: black 1pt solid;
                border-bottom: black 1pt solid; font-family: Arial; position: absolute; top: 16px;
                background-color: #ffff00; font-weight: bold;" Text="Objectives" Width="96px" OnClick="Bobjectives_Click" />
            <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" Style="z-index: 105;
                left: 40px; position: absolute; top: 104px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid; background-color: #cc9966;" ForeColor="Black" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <SelectedRowStyle BackColor="Red" />
            </asp:GridView>
        </asp:Panel>
        <asp:Panel 
            ID="Panel10" 
            runat="server" 
            Height="300px" 
            Width="385px"
            Style="z-index: 113; 
                   border-right: black 1px solid;
                   border-top: black 1px solid; 
                   border-left: black 1px solid;
                   border-bottom: black 1px solid; 
                   position: relative; 
                   left: 500px; 
                   top: -600px; 
                   background-color: #66ccff"
             >
            <asp:Label ID="Label8" runat="server" Style="z-index: 100; left: 16px; position: relative;
                top: 8px; font-weight: bold; font-size: 12pt; font-family: Arial;" Text="Currently Selected:" Width="168px"></asp:Label>
            
        </asp:Panel>
        
        </ContentTemplate>
    </asp:UpdatePanel>

    </div>
    

    <div>
    
    </div>
    </form>
</body>
</html>
