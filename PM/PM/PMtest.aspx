<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PMtest.aspx.cs" Inherits="PM.PMtest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Maintenance</title>
     <style type ="text/css">
    table
    {
       font-family: Arial; 
       font-size:12pt;
       font-weight:bold;
       width:60%;
       padding:10px;
       background-color:wheat;
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
    <form id="form1" 
          runat="server">
    <div>
 <table style="z-index:100;
                    left:0px; 
                    position:absolute; 
                    top:0px">
  <tr>
     <td colspan="3"
        style="text-align:center;
               font-family:Arial; 
               color:#003366; 
               background-color:#003366;">  "  "
     </td>
   </tr>
  
   <tr>
    <td style="background-color:#cccccc;"
       colspan="3">
      <b>Maintenance</b>
     </td>
   </tr>
  
   <tr>
     <td
        colspan="3" 
        style="text-align:center;"><b>Maintenance Request</b>
      </td>
   </tr>

    <tr> 
      <td align="right">
        <a>*</a> Name :: 
      </td>
      
      <td style="width: 390px">
          <asp:DropDownList 
            ID="DDLemployee" 
            runat="server" 
            AutoPostBack="true"
            Width="240px" 
            OnSelectedIndexChanged="DDLemployee_SelectedIndexChanged">
          </asp:DropDownList>
      </td>
      <td> 
          <asp:Label 
            ID="Lname" 
            runat="server" 
            Text="Must Select an Employee" 
            Visible="false" 
            BackColor="red"
            >
          </asp:Label>
          
      </td>
    </tr>
    <tr> 
      <td align="right"><a>*</a>
        Contact Email :: 
      </td>
      <td style="width: 390px">
          <asp:TextBox 
            ID="tbContactEmail" 
            runat="server" 
            Width="290px">
          </asp:TextBox>
          
        </td>
    </tr>
    <tr> 
      <td align="right">Ext :: </td>
      <td style="width: 390px"> 
        <asp:TextBox 
         ID="tbPhone" 
         runat="server" 
         Width="290px">
        </asp:TextBox></td>
    </tr>

    <tr>
	<td><a>*</a>Equip ID::</td>
	<td style="width: 390px">Cost Center</td>
	<td style="width: 411px">Location (read only)</td>
    </tr>	
    <tr> 

	<td> 
        <asp:DropDownList 
            ID="DDequipID"
            AutoPostBack="True" 
            runat="server" 
            OnSelectedIndexChanged="DDequipID_SelectedIndexChanged">
        </asp:DropDownList>
  	</td>
 
      <td style="width: 390px">
        <asp:TextBox 
            ID="tbCostCenter" 
            runat="server" 
            >
        </asp:TextBox>
      </td>

      <td style="width: 411px"> 
        <asp:TextBox 
            ID="tbLocation" 
            runat="server" 
            Width="304px" 
            ReadOnly="True" 
            ></asp:TextBox>
      </td>

    </tr>
    <tr>
      <td>
        <asp:Label 
            ID="Lequipment" 
            runat="server" 
            Text="Must Make a Selection" 
            Visible="false" 
            BackColor="red"
            >
          </asp:Label>
      </td>
	  <td style="width: 390px">Manufacturer (read only)</td>
	  <td style="width: 411px">Description (read only)</td>
    </tr>
    
    <tr>
      <td></td>
      <td style="width: 390px"> 
      	<asp:TextBox 
            ID="tbManufacturer" 
            runat="server" 
            Width="250px" 
            ReadOnly="True" 
            ></asp:TextBox>
      </td>

      <td style="width: 411px">
        <asp:TextBox 
            ID="tbDescription" 
            runat="server" 
            Width="300px"
            ReadOnly="True"  
            ></asp:TextBox>
      </td>
      
    </tr>
    
    <tr>
        <td>
        
        </td>
    </tr>
    
    <tr> 
      <td align="right"><a>*</a>Category ::
      
      </td>
		<td> 
        <asp:DropDownList 
            ID="DDLCategory" 
            runat="server" 
            AutoPostBack="True" 
            >
            <asp:ListItem>Continuous Improvement</asp:ListItem>
            <asp:ListItem>Machine Down - Production Stopped</asp:ListItem>
            <asp:ListItem>Repair</asp:ListItem>
            <asp:ListItem>Safety</asp:ListItem>
        </asp:DropDownList>
        
		</td>
    </tr>
    
    <tr> 
      	<td align="right"> <a>*</a>Severity::</td>
	<td>
        <asp:DropDownList 
            ID="DDLSeverity" 
            runat="server" 
            AutoPostBack="True" 
            >
            <asp:ListItem>Routine</asp:ListItem>
            <asp:ListItem>Severe</asp:ListItem>
            <asp:ListItem>Urgent</asp:ListItem>
        </asp:DropDownList>

	</td>

      <td>Project :: 
          <asp:TextBox 
            ID="tbProject" 
            runat="server">
            </asp:TextBox>
      </td>
      <td></td>
    </tr>
    
    <tr align="right"> 
      <td><a>*</a>Describe Issue
        ::</td>
    </tr>
    <tr align="right"> 
      <td style="height: 127px"></td>
        <td>
          <asp:TextBox 
            ID="tbTrouble" 
            runat="server" 
            Height="120px"
            Width="280px" 
            TextMode="MultiLine" 
            Font-Names="Arial"
            >
          </asp:TextBox>
        </td>
        <td align="left">
           <asp:Label 
            ID="Ltrouble" 
            runat="server"
            Text="An Entry is Required" 
            Visible="false" 
            BackColor="red"
            >
          </asp:Label>
        </td>
    </tr>
    <tr>
	 <td style="height: 102px">
         
     </td>
	 <td style="height: 102px">
  <div> 
      <asp:Button ID="Button1" runat="server" OnClick="Button1_Click"  Text="..:: SUBMIT ::.." />
        
    <p>&copy; All Rights reserved.<br/>
      Zygo Corporation</p>
    </div>
	 </td>
	 <td>
	    <asp:Label 
	        ID="Lerror" 
	        runat="server" 
	        BackColor="red" 
	        Visible="false">
          </asp:Label>

	 </td>
	</tr>
</table> 
        

        
    
    </div>
    </form>
</body>
</html>
