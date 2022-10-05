<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZEP.aspx.cs" Inherits="CalibrationView.ZEP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Calibration Data Viewer - Richmond</title>
    <style type ="text/css">
    table
    {
       font-family: Arial; 
       font-size:14pt;
       font-weight:bold;
       width:100%;
       padding:10px;
       background-color:darkseagreen;
    }
    </style>

</head>
<body>
     <form id="form1" 
          runat="server">
        <asp:ScriptManager ID="ScriptManager1" 
                           runat="server" />
                           
    <table style="z-index: 100; left: 0px; position: absolute; top: 0px">
            <tr>
                <td colspan="7"
                    style="text-align:center; 
                           font-family:Arial; 
                           color:black; 
                           font-size:larger; 
                           background-color:#33FF66;
                           height: 80px">
                           Calibration Data Viewer&nbsp;
                        
                </td>
            </tr>
            <tr>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
              <td> KPI</td>
              <td colspan="3">Scan to User
                </td>   
            </tr>
            
            <tr>
                <td colspan="3">Check box to filter results.
                    
                </td>
                
                <td style="width: 191px">
                    
                </td>
                <td colspan="3">
                    <asp:Label 
                        ID="label1" 
                        runat="server"> 
                    </asp:Label>
                </td>
            </tr>
           
           <tr>
                <td style="width: 5%; 
                           height:40px">
                    <asp:CheckBox 
                        ID="cbStatus" 
                        runat="server"  
                        AutoPostBack="true"
                        OnCheckedChanged="cbStatus_CheckedChanged"
                     />
                </td>
                <td style="width: 10%">
                        Status:
                </td>
                <td style="width: 25%" >
                    
                    <asp:DropDownList ID="DDLstatus"
                          AutoPostBack ="True"
                          runat="server" 
                          DataSourceID="SqlDataSource1"
                          DataTextField="StatusCode" 
                          DataValueField="StatusCode" 
                          Visible="False" 
                          >
                    </asp:DropDownList>
                    
                    <asp:SqlDataSource ID="SqlDataSource1" 
                           runat="server" 
                           ConnectionString="<%$ ConnectionStrings:CalibrationConnectionString %>"
                           SelectCommand="SELECT statuscode FROM [status] order by statuscode">
                    </asp:SqlDataSource>
                </td>
                
                <td style="width:191px">
                    <asp:CheckBox 
                        ID="cbUser" 
                        runat="server"  
                        AutoPostBack="true" 
                        OnCheckedChanged="cbUser_CheckedChanged"
                     />
                 </td>
                <td style="width:10%">
                    User:
                </td>
                <td style="width:25%">
                    <asp:DropDownList ID="DDLuser"
                          AutoPostBack ="true"
                          runat="server" 
                          DataSourceID="SqlDataSource2"
                          DataTextField="User" 
                          DataValueField="User" 
                          Visible="False" >
                    </asp:DropDownList>
                    
                    <asp:SqlDataSource ID="SqlDataSource2" 
                           runat="server" 
                           ConnectionString="<%$ ConnectionStrings:CalibrationConnectionString %>"
                           SelectCommand="SELECT distinct [User] FROM [webzep] ORDER BY [user]">
                    </asp:SqlDataSource>
                </td>
                
            </tr>
            <tr style="height:40px">
                <td>
                    <asp:CheckBox 
                        ID="cbLocation" 
                        runat="server"  
                        AutoPostBack="true"
                        OnCheckedChanged="cbLocation_CheckedChanged"
                     />
                </td>
                <td>
                    Location:
                </td>
                <td>
                    <asp:DropDownList 
                        ID="DDLlocation"
                        AutoPostBack ="True"
                        runat="server" 
                        DataSourceID="SqlDataSource3"
                        DataTextField="L_id" 
                        DataValueField="L_id"
                        Visible="False"> 
                    </asp:DropDownList>
                                        
                    <asp:SqlDataSource 
                        ID="SqlDataSource3" 
                        runat="server" 
                        ConnectionString="<%$ ConnectionStrings:CalibrationConnectionString %>"
                        SelectCommand=
                        "SELECT [l_id] FROM [location] where [l_id] like 'zep%' ORDER BY [l_id]">
                    </asp:SqlDataSource>
                </td>
                <td style="width: 191px">
                    <asp:CheckBox 
                        ID="cbOwner" 
                        runat="server"  
                        AutoPostBack="true" 
                        OnCheckedChanged="cbOwner_CheckedChanged"
                     />
                 </td>
                <td style="width:15%">Owner:
                </td>
                <td style="width:15%">
                    <asp:DropDownList ID="DDLowner"
                          AutoPostBack ="true"
                          runat="server" 
                          DataSourceID="SqlDataSource4"
                          DataTextField="Owner" 
                          DataValueField="Owner"
                          Visible="False">
                    </asp:DropDownList>
                    
                    <asp:SqlDataSource ID="SqlDataSource4" 
                           runat="server" 
                           ConnectionString="<%$ ConnectionStrings:CalibrationConnectionString %>"
                           SelectCommand="SELECT distinct [owner] FROM [webzep] ORDER BY [owner]">
                    </asp:SqlDataSource>
                </td>
                
            </tr>
            <tr style="height:40px">
                <td>
                    <asp:CheckBox 
                        ID="cbRoom" 
                        runat="server"  
                        AutoPostBack="true"
                        OnCheckedChanged="cbRoom_CheckedChanged"
                     />
                </td>
                <td>
                    Room:
                </td>
                <td>
                    <asp:DropDownList ID="DDLroom"
                          AutoPostBack ="True"
                          runat="server" 
                          DataSourceID="SqlDataSource5"
                          DataTextField="Room" 
                          DataValueField="r_RoomNumber"
                          Visible="False"> 
                    </asp:DropDownList>
                    
                    <asp:SqlDataSource ID="SqlDataSource5" 
                           runat="server" 
                           ConnectionString="<%$ ConnectionStrings:CalibrationConnectionString %>"
                           SelectCommand="SELECT [r_roomnumber], [r_roomnumber] + '  ' + [r_description] as Room FROM [room] where r_roomnumber like 'zep%'
                           ORDER BY [r_roomnumber]">
                    </asp:SqlDataSource>
                </td>
                <td style="width: 191px">
                    <asp:CheckBox 
                        ID="cbOwnerSupervisor" 
                        runat="server"  
                        AutoPostBack="true" 
                        OnCheckedChanged="cbOwnerSupervisor_CheckedChanged"
                     />
                 </td>
                <td style="width:15%">
                    Owner Supervisor:
                </td>
                <td style="width:15%">
                    <asp:DropDownList ID="DDLownsup"
                          AutoPostBack ="true"
                          runat="server" 
                          DataSourceID="SqlDataSource6"
                          DataTextField="Owner Supervisor" 
                          DataValueField="Owner Supervisor"
                          Visible="False" >
                    </asp:DropDownList>
                    
                    <asp:SqlDataSource ID="SqlDataSource6" 
                           runat="server" 
                           ConnectionString="<%$ ConnectionStrings:CalibrationConnectionString %>"
                           SelectCommand="SELECT distinct [owner supervisor] FROM [webzep] ORDER BY [owner supervisor]">
                    </asp:SqlDataSource>
                </td>
                            </tr>
            <tr style="height:40px">
                <td>
                    <asp:CheckBox 
                        ID="cbDescription" 
                        runat="server"  
                        AutoPostBack="true" 
                        OnCheckedChanged="cbDescription_CheckedChanged" 
                     />
                </td>
                <td>
                    Description:  
                </td>
                <td><asp:DropDownList ID="DDLdescription"
                          AutoPostBack ="true"
                          runat="server" 
                          DataSourceID="SqlDataSource7"
                          DataTextField="Description" 
                          DataValueField="Description" 
                          Visible="False" 
                          >
                    </asp:DropDownList>
                    
                    <asp:SqlDataSource ID="SqlDataSource7" 
                           runat="server" 
                           ConnectionString="<%$ ConnectionStrings:CalibrationConnectionString %>"
                           SelectCommand="SELECT distinct [description] FROM [webzep] ORDER BY [description]">
                    </asp:SqlDataSource></td>
                <td style="width: 191px">
                    <asp:CheckBox 
                        ID="cbCalsource" 
                        runat="server"  
                        AutoPostBack="true" 
                        OnCheckedChanged="cbCalsource_CheckedChanged"
                     />
                 </td>
                <td style="width:15%">
                    Calibration Source:
                </td>
                <td style="width:15%">
                    <asp:DropDownList ID="DDLcalsource"
                          AutoPostBack ="true"
                          runat="server" 
                          DataSourceID="SqlDataSource8"
                          DataTextField="Calibration Source" 
                          DataValueField="Calibration Source"
                          Visible="False" >
                    </asp:DropDownList>
                    
                    <asp:SqlDataSource ID="SqlDataSource8" 
                           runat="server" 
                           ConnectionString="<%$ ConnectionStrings:CalibrationConnectionString %>"
                           SelectCommand="SELECT distinct [calibration source] FROM [webzep] ORDER BY [calibration source]">
                    </asp:SqlDataSource>
                </td>
                
            </tr>
            <tr style="height:40px">
               <td>
                <asp:CheckBox 
                        ID="cbManufacturer" 
                        runat="server"  
                        AutoPostBack="true"
                        OnCheckedChanged="cbManufacturer_CheckedChanged"
                     />
               </td>
               <td>
                    Manufacturer:
                </td>
                <td>
                    <asp:DropDownList ID="DDLmanufacturer"
                          AutoPostBack ="True"
                          runat="server" 
                          DataSourceID="SqlDataSource9"
                          DataTextField="Manufacturer" 
                          DataValueField="Manufacturer"
                          Visible="False"> 
                    </asp:DropDownList>
                    
                    <asp:SqlDataSource ID="SqlDataSource9" 
                           runat="server" 
                           ConnectionString="<%$ ConnectionStrings:CalibrationConnectionString %>"
                           SelectCommand="SELECT DISTINCT manufacturer FROM WebZep ORDER BY manufacturer">
                    </asp:SqlDataSource>
                </td>
                
                <td style="width: 191px">
                    <asp:CheckBox 
                        ID="cbModel" 
                        runat="server"  
                        AutoPostBack="true" 
                        OnCheckedChanged="cbModel_CheckedChanged"
                     />
                </td>
                <td style="width:15%">
                    Model:
                </td>
                <td style="width:15%">
                    <asp:DropDownList ID="DDLmodel"
                          AutoPostBack ="true"
                          runat="server" 
                          DataSourceID="SqlDataSource10"
                          DataTextField="Model" 
                          DataValueField="Model" 
                          Visible="False" >
                    </asp:DropDownList>
                    
                    <asp:SqlDataSource ID="SqlDataSource10" 
                           runat="server" 
                           ConnectionString="<%$ ConnectionStrings:CalibrationConnectionString %>"
                           SelectCommand="SELECT distinct [model] FROM [webzep] ORDER BY [model]">
                    </asp:SqlDataSource>
                </td>
                
            </tr>
            <tr style="height:40px">
                
                <td style="width: 191px"><asp:CheckBox 
                        ID="cbID" 
                        runat="server"  
                        AutoPostBack="true" OnCheckedChanged="cbID_CheckedChanged" 
                        
                     /></td>
                <td>ID:</td>
                <td><asp:DropDownList ID="DDLid"
                          AutoPostBack ="true"
                          runat="server" 
                          DataSourceID="SqlDataSource12"
                          DataTextField="ID" 
                          DataValueField="ID" 
                          Visible="False" 
                          >
                    </asp:DropDownList>
                    
                    <asp:SqlDataSource ID="SqlDataSource12" 
                           runat="server" 
                           ConnectionString="<%$ ConnectionStrings:CalibrationConnectionString %>"
                           SelectCommand="SELECT [id] FROM [webzep] ORDER BY [id]">
                    </asp:SqlDataSource></td>
                    <td></td>
                    <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            
            <tr style="height:40px">
                <td>
                    <asp:CheckBox 
                        ID="cbSN" 
                        runat="server"  
                        AutoPostBack="true" 
                        OnCheckedChanged="cbSN_CheckedChanged" 
                     />
                </td>
                <td>
                    SN:  
                </td>
                <td><asp:DropDownList ID="DDLsn"
                          AutoPostBack ="true"
                          runat="server" 
                          DataSourceID="SqlDataSource14"
                          DataTextField="SN" 
                          DataValueField="SN" 
                          Visible="False" 
                          >
                    </asp:DropDownList>
                    
                    <asp:SqlDataSource ID="SqlDataSource14" 
                           runat="server" 
                           ConnectionString="<%$ ConnectionStrings:CalibrationConnectionString %>"
                           SelectCommand="SELECT distinct [sn] FROM [webzep] ORDER BY [sn]">
                    </asp:SqlDataSource></td>
                    
                <td style="width: 191px"><asp:CheckBox 
                        ID="cbICC" 
                        runat="server"  
                        AutoPostBack="true" OnCheckedChanged="cbICC_CheckedChanged" 
                        
                     /></td>
                <td>ONLY Internal Calibration Contact:</td>
                <td><asp:DropDownList ID="DDLicc"
                          AutoPostBack ="true"
                          runat="server" 
                          DataSourceID="SqlDataSource15"
                          DataTextField="Internal Calibrator" 
                          DataValueField="Internal Calibrator" 
                          Visible="False" 
                          >
                    </asp:DropDownList>
                    
                    <asp:SqlDataSource ID="SqlDataSource15" 
                           runat="server" 
                           ConnectionString="<%$ ConnectionStrings:CalibrationConnectionString %>"
                           SelectCommand="SELECT distinct [Internal Calibrator] FROM [webzep] ORDER BY [internal calibrator]">
                    </asp:SqlDataSource></td>
                
            </tr>
            
            <tr style="height:40px">
                <td>
                    <asp:CheckBox 
                        ID="cbCalendars" 
                        runat="server"  
                        AutoPostBack="true" 
                        OnCheckedChanged="cbCalendars_CheckedChanged" 
                     />
                </td>
                <td>
                    Calibration Due Date  
                </td>
                <td></td>
                
            </tr>
            <tr >
                <td style="height: 80px; text-align:right">
                    <asp:Label 
                        ID="LdueAfter" 
                        runat="server" 
                        Text="Due After:" 
                        Visible="False">
                    </asp:Label>
                    
                </td>
                <td 
                    colspan="2"
                    style="height: 24px">
                    <asp:Calendar 
                        ID="monthCalendarDueAfter" 
                        runat="server"
                        style="background-color:white;font-size:smaller; width:50px 
                                " 
                        BackColor="White" 
                        BorderColor="White" 
                        BorderWidth="1px" 
                        Font-Names="Verdana" 
                        Font-Size="9pt" 
                        ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Visible="False" Width="350px"
                        >
                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                        <TodayDayStyle BackColor="#CCCCCC" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True"
                            Font-Size="12pt" ForeColor="#333399" />
                    </asp:Calendar>
                </td>
                <td style="height: 24px; text-align:right; width: 191px;">
                    <asp:Label ID="LdueB4" runat="server" EnableTheming="False"
                        Text="Due Before:" Visible="False"
                        Width="120px"></asp:Label>
                </td>
                <td colspan="2"
                    style="height: 24px">
                    <asp:Calendar 
                        ID="monthCalendarDueB4" 
                        runat="server"
                        style="background-color:white;font-size:smaller;width:50px  
                                " BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Visible="False" Width="350px"
                        >
                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                        <TodayDayStyle BackColor="#CCCCCC" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True"
                            Font-Size="12pt" ForeColor="#333399" />
                    </asp:Calendar></td>
                
            </tr>
            <tr>
                <td><br /></td>
                <td></td>
                
            </tr>
            <tr>
                <td><br /></td>
                <td colspan="2">
                    <asp:Button 
                        ID="BgetGrid"
                        runat="server"
                        width="100%"
                        height="40px"
                        text="Get Data"
                        style="background-color:Teal; font-size:larger; position:relative" OnClick="BgetGrid_Click"
                        />
                    
                </td>
                <td>
                    <asp:Button 
                        ID="Bexcel" 
                        runat="server" 
                        OnClick="Button1_Click" 
                        height="40px"
                        Style="z-index: 100;
                        left: 20px; position: relative; top: 0px;
                        background-color:DarkOliveGreen; font-size:larger"
                         
                        Text="Export to Excel" 
                        Width="200px" />
                </td>
                
            </tr>
            
            <tr>
              <td colspan="7">
                <asp:GridView 
            ID="GridView" 
            runat="server" PageSize="15" 
            AutoGenerateColumns="False"
            DataSourceID="SqlDataSource11"
            Style="z-index: 101; position: relative; " 
            AllowSorting="True" 
            AllowPaging="false" 
            OnPageIndexChanging="GridView_PageIndexChanging" 
            OnSorting="GridView_Sorting">
            <Columns>
                <asp:BoundField 
                    DataField="Due Date"
                    DataFormatString="{0:MM-dd-yyyy}"
                    HeaderText="Due Date" 
                    SortExpression="Due Date" >
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="Manufacturer" HeaderText="Manufacturer" SortExpression="Manufacturer" />
                <asp:BoundField DataField="SN" HeaderText="SN" SortExpression="SN" />
                <asp:BoundField DataField="MODEL" HeaderText="MODEL" SortExpression="MODEL" />
                <asp:BoundField DataField="SIZE" HeaderText="SIZE" SortExpression="SIZE" />
                <asp:BoundField DataField="TYPE" HeaderText="TYPE" SortExpression="TYPE" />
                <asp:BoundField DataField="Calibration Source" HeaderText="Calibration Source" SortExpression="Calibration Source" />
                <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:BoundField DataField="User" HeaderText="User" SortExpression="User" />
                <asp:BoundField DataField="Owner" HeaderText="Owner" SortExpression="Owner" />
                <asp:BoundField DataField="Owner Supervisor" HeaderText="Owner Supervisor" SortExpression="Owner Supervisor" />
                <asp:BoundField DataField="Internal Calibrator" HeaderText="Internal Calibrator" SortExpression="Internal Calibrator" />
            </Columns>
            <AlternatingRowStyle BackColor="#80FF80" />
        </asp:GridView>
        <asp:SqlDataSource 
            ID="SqlDataSource11" 
            runat="server" 
            ConnectionString="<%$ ConnectionStrings:CalibrationConnectionString %>">
            
        </asp:SqlDataSource>
              </td>
            
            </tr>
            
        </table>
        
    </form>
</body>
</html>
