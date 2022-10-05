<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Equipment.aspx.cs" Inherits="RPM._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
     <style type ="text/css">
    div
    {
       font-family: Arial; 
       font-size:12pt;
       font-weight:bold;
       width:1%;
       padding:50%;
       background-color:#5F9EA0;
    }
    .y1
    {
        background-color:#DEB887;
    }
    a 
    {
        font-family: Arial;
        font-size:14pt;
        color:#FF0000;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LFormHeading" runat="server" Font-Size="X-Large" 
            Style="z-index: 100; left: 96px; position: absolute; top: 40px" 
            Text="ZYGO PM EQUIPMENT AND TASK DATA ENTRY FORM"
            Width="744px"></asp:Label><asp:Button ID="BlotoNo" runat="server" OnClick="BlotoNo_Click" Style="z-index: 101;
            left: 408px; position: absolute; top: 368px" Text="No" Width="104px" BackColor="MediumSeaGreen" />
        <asp:Button ID="BlotoNA" runat="server" OnClick="BlotoNA_Click" Style="z-index: 102;
            left: 536px; position: absolute; top: 368px" Text="N/A" Width="104px" BackColor="MediumSeaGreen" />
        <asp:Button ID="BlotoDate" runat="server" OnClick="BlotoDate_Click" Style="z-index: 148;
            left: 664px; position: absolute; top: 368px" Text="Pick Date" Width="104px" BackColor="MediumSeaGreen" />
        &nbsp;&nbsp;
        
        
        <asp:Label ID="LentryRequired" runat="server" BorderStyle="None" Font-Names="Arial Black"
            ForeColor="Red" Visible="False" Width="208px"
            Style="z-index: 104; left: 352px; position: absolute; top: 96px"
            Text="* = Entry Required" ></asp:Label>
        
        
        <asp:Label ID="LastrixEquip" runat="server" BorderStyle="None" Font-Names="Arial Black"
            ForeColor="Red" Style="z-index: 105; left: 35px; position: absolute; top: 130px"
            Text="*"></asp:Label>
        <asp:Label ID="LequipmentID" runat="server" 
            Style="z-index: 106; left: 48px; position: absolute; top: 130px" 
            Text="Equipment ID:" Width="112px"></asp:Label>
        <asp:TextBox ID="tbEquipmentID" runat="server" 
            Style="z-index: 107; left: 170px; position: absolute; top: 130px"></asp:TextBox>
    
       
       <asp:Label ID="LastrixOwner" runat="server" BorderStyle="None" Font-Names="Arial Black"
            ForeColor="Red" 
            Style="z-index: 108; left: 672px; position: absolute; top: 130px"
            Text="*"></asp:Label>
       <asp:Label ID="Lowner" runat="server" 
            Style="z-index: 109; left: 688px; position: absolute; top: 130px" Text="Owner:"></asp:Label>
       <asp:DropDownList ID="ddLowner" runat="server" 
            Style="z-index: 110; left: 752px; position: absolute; top: 130px" Width="152px">
        </asp:DropDownList>
        
       
        <asp:Label ID="LastrixDescription" runat="server" BorderStyle="None" Font-Names="Arial Black"
            ForeColor="Red" 
            Style="z-index: 111; left: 48px; position: absolute; top: 170px"
            Text="*"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Style="z-index: 112; left: 0px; position: absolute;
            top: 0px" Width="56px"></asp:TextBox>
        &nbsp;
        <asp:Label ID="Ldescription" runat="server" 
            Style="z-index: 113; left: 64px; position: absolute; top: 170px" 
            Text="Description:"></asp:Label>
        <asp:TextBox ID="tbDescription" runat="server" 
            Style="z-index: 114; left: 170px; position: absolute; top: 170px" 
            ReadOnly="True" Width="360px"></asp:TextBox>
        
        
        <asp:Label ID="LastrixStatus" runat="server" BorderStyle="None" Font-Names="Arial Black"
            ForeColor="Red" 
            Style="z-index: 115; left: 648px; position: absolute; top: 170px"
            Text="*"></asp:Label>
        <asp:Label ID="Lstatus" runat="server" 
            Style="z-index: 116; left: 664px; position: absolute; top: 170px" 
            Text="Status:" Width="72px"></asp:Label>
        <asp:DropDownList ID="ddLStatus" runat="server" 
            Style="z-index: 117; left: 752px; position: absolute; top: 170px" Width="152px">
        </asp:DropDownList>
        
        
        <asp:Label ID="Lmanufacturer" runat="server" 
            Style="z-index: 118; left: 48px; position: absolute; top: 210px" 
            Text="Manufacturer:"></asp:Label>
        <asp:TextBox ID="tbManufacturer" runat="server" 
            Style="z-index: 119; left: 170px; position: absolute; top: 210px" 
            Width="360px"></asp:TextBox>
        
        
        <asp:Label ID="LastrixLocation" runat="server" BorderStyle="None" Font-Names="Arial Black"
            ForeColor="Red" 
            Style="z-index: 120; left: 640px; position: absolute; top: 210px"
            Text="*"></asp:Label>
        <asp:Label ID="Llocation" runat="server" 
            Style="z-index: 121; left: 664px; position: absolute; top: 210px" 
            Text="Location:"></asp:Label>
        <asp:DropDownList ID="ddLlocation" runat="server" 
            Style="z-index: 122; left: 752px; position: absolute; top: 210px" Width="152px">
        </asp:DropDownList>
        
        
        
        <asp:Label ID="Lmodel" runat="server" 
            Style="z-index: 123; left: 96px; position: absolute; top: 250px" 
            Text="Model:"></asp:Label>
        <asp:TextBox ID="tbModel" runat="server" 
            Style="z-index: 124; left: 170px; position: absolute; top: 250px"></asp:TextBox>
        
        <asp:Label ID="LastrixCostCenter" runat="server" BorderStyle="None" Font-Names="Arial Black"
            ForeColor="Red" 
            Style="z-index: 125; left: 616px; position: absolute; top: 250px"
            Text="*"></asp:Label>
        <asp:Label ID="Lcostcenter" runat="server" 
            Style="z-index: 126; left: 632px; position: absolute; top: 250px" 
            Text="Cost Center:" Width="104px"></asp:Label>
        <asp:DropDownList ID="ddLcostcenter" runat="server" 
            Style="z-index: 127; left: 752px; position: absolute; top: 250px" Width="152px">
        </asp:DropDownList>
        
        
        <asp:Label ID="Lassettag" runat="server" Style="z-index: 128; left: 64px; position: absolute;
            top: 290px" Text="Asset Tag:" Width="88px"></asp:Label>
        <asp:TextBox ID="tbAssetTag" runat="server" Style="z-index: 129; left: 170px; position: absolute;
            top: 290px"></asp:TextBox>
        
         <asp:Label ID="LstartDate" runat="server" Style="z-index: 130; left: 648px; position: absolute;
            top: 290px" Text="Start Date:" Width="88px"></asp:Label>
         <asp:TextBox ID="tbStartDate" runat="server" 
            Style="z-index: 131; left: 752px; position: absolute; top: 290px" Width="144px"></asp:TextBox>
         
        
         <asp:Label ID="Lcomments" runat="server" 
            Style="z-index: 132; left: 64px; position: absolute; top: 330px" 
            Text="Comments:" Width="88px"></asp:Label>
         <asp:TextBox ID="tbComments" runat="server" 
            Style="z-index: 133; left: 170px; position: absolute; top: 330px" 
            Width="725px"></asp:TextBox>
        
               
        <asp:Label ID="LastrixLotoVerified" runat="server" BorderStyle="None" Font-Names="Arial Black"
            ForeColor="Red" 
            Style="z-index: 134; left: 35px; position: absolute; top: 370px"
            Text="*"></asp:Label>
        <asp:Label ID="Llotoverified" runat="server" 
            Style="z-index: 135; left: 56px; position: absolute; top: 370px" 
            Text="LOTO Verified (Date):" Width="168px"></asp:Label>
        <asp:TextBox ID="tbLotoVerified" runat="server" 
            Style="z-index: 136; left: 240px; position: absolute; top: 370px"></asp:TextBox>
        
        
         <asp:Label ID="LplateVolts" runat="server" 
            Style="z-index: 137; left: 64px; position: absolute; top: 410px"
             Text="Plate Volts:" Width="88px"></asp:Label>
        <asp:TextBox ID="tbPlateVolts" runat="server" 
            Style="z-index: 138; left: 170px; position: absolute; top: 410px" 
            Width="56px"></asp:TextBox>
    
        
        <asp:Label ID="LplateAmps" runat="server" 
            Style="z-index: 139; left: 264px; position: absolute; top: 410px" 
            Text="Plate Amps:" Width="96px"></asp:Label>
        <asp:TextBox ID="tbPlateAmps" runat="server" 
            Style="z-index: 140; left: 384px; position: absolute; top: 410px" 
            Width="56px"></asp:TextBox>
        
        
                
        <asp:Label ID="LmeasAmps" runat="server" 
            Style="z-index: 141; left: 472px; position: absolute; top: 410px" 
            Text="Meas Amps:" Width="104px"></asp:Label>
        <asp:TextBox ID="tbMeasAmps" runat="server" 
            Style="z-index: 142; left: 592px; position: absolute; top: 410px" 
            Width="56px"></asp:TextBox>
        
        <asp:Label ID="LplatePhases" runat="server" 
            Style="z-index: 143; left: 680px; position: absolute; top: 410px" 
            Text="Plate Phases:" Width="112px"></asp:Label>
        <asp:DropDownList ID="ddLplatePhases" runat="server" 
            Style="z-index: 144; left: 808px; position: absolute; top: 410px" Width="64px">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>Split</asp:ListItem>
        </asp:DropDownList>
        
        <asp:Label ID="LfedfromPanel" runat="server" 
            Style="z-index: 145; left: 32px; position: absolute; top: 456px" 
            Text="Fed From Panel:" Width="128px"></asp:Label>
        <asp:TextBox ID="tbFedFromPanel" runat="server" 
            Style="z-index: 146; left: 170px; position: absolute; top: 456px" Width="688px"></asp:TextBox>
        
        
   <asp:Calendar 
                        ID="Calendar" 
                        runat="server"
                        style="z-index: 147; left: 170px; position: absolute; top: 504px; background-color:white;font-size:smaller; width:50px" 
                        BackColor="White" 
                        BorderColor="White" 
                        BorderWidth="1px" 
                        Font-Names="Verdana" 
                        Font-Size="9pt" 
                        ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Visible="False" Width="350px" OnSelectionChanged="Calendar_SelectionChanged"
                        >
                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                        <TodayDayStyle BackColor="#CCCCCC" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True"
                            Font-Size="12pt" ForeColor="#333399" />
                    </asp:Calendar>     
        
        
        
        
        
    </div>
        <asp:Button ID="BstartDateCalendar" runat="server" OnClick="Bcalendar_Click" Style="z-index: 102;
            left: 912px; position: absolute; top: 288px" Text="Pick" BackColor="MediumSeaGreen" />
    </form>
</body>
</html>
