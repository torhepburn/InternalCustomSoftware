<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToolRoomDefault.aspx.cs" Inherits="ToolRoom._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Tool Room Requests</title>
     <style type ="text/css">
         table
    {
       font-family: Arial; 
       font-size:12pt;
       font-weight:bold;
       width:92%;
       padding:10px;
       background-color:wheat;
    }
    c
    {
        font-family: Arial; 
        font-size:20pt;
        font-weight:bold;
        width:100%;
        padding:10px;
        text-align:center
    }
    a 
    {
        font-family: Arial;
        font-size:14pt;
        color:#FF0000;
    }
         .auto-style1 {
             width: 349px;
         }
         .auto-style2 {
             height: 102px;
             width: 349px;
         }
    
         .auto-style3 {
             width: 445px;
         }
    
    </style>
    <script type="text/javascript">
        var wasSubmitted = false;
        function checkBeforeSubmit() {
            if (!wasSubmitted) {
                wasSubmitted = true;
                return wasSubmitted;
            }
            return false;
        }

    </script>
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
     <td colspan="6"
        style="text-align:center;
               font-family:Arial; 
               color:#003366; 
               background-color:#003366;">  "  "
     </td>
   </tr>
  
   <tr>
    <td style="background-color:#cccccc;"
       colspan="6" style="text-align:center;">
      <b><c>Tool Room Requests</c></b>
     </td>
   </tr>
  
   <tr>
     <td
        colspan="4" 
        ><b></b>
      </td>
   </tr>
     <tr>
         <td
        colspan="6" 
        style="text-align:center;"><b>Items marked with an asterisk <a>*</a> require an entry.</b>
          <br />
              <br />
      </td>
     </tr>

     <tr>
         <td
        colspan="6" 
        style="text-align:center;">
             <asp:CheckBox ID="cbPersist" Text="Check this box if you want to make multiple entries and have some selections remain." runat="server" AutoPostBack="true" />
                <br /> <br />
             </td>
     </tr>

     <tr>
         <td
        colspan="6" 
        style="text-align:center;">Submit Tool Room request prior to attaching support document (pdf format required).
              <br />
              <br />
         </td>

     </tr>

    <tr> 
      <td align="right">
        <a>*</a> Name :: 
      </td>
      
      <td class="auto-style1">
          <asp:DropDownList 
            ID="DDLemployee" 
            runat="server" 
            AutoPostBack="true"
            Width="240px" 
            OnSelectedIndexChanged="DDLemployee_SelectedIndexChanged">
          </asp:DropDownList>
          <br />
           <asp:Label 
            ID="Lname" 
            runat="server" 
            Text="Must Select an Employee" 
            Visible="false" 
            BackColor="red"
            >
          </asp:Label>
      </td>
      < <td align="right"> <a>*</a>Priority::</td>

        <td class="auto-style3">
            <asp:DropDownList 
            ID="DDLPriority" 
            runat="server" 
            AutoPostBack="True" 
            >
            <asp:ListItem>Routine</asp:ListItem>
            <asp:ListItem>Urgent</asp:ListItem>
            <asp:ListItem>Production Down</asp:ListItem>
        </asp:DropDownList>
        </td>
        <td align="right">
            <a>*</a>Time Savings Estimate (work days: whole numbers only: no decimals) ::
        </td>
        <td class="auto-style1">
          <asp:TextBox 
            ID="tbTimeSavingsEstimate" 
            runat="server" 
            Width="60px">
          </asp:TextBox>
               <asp:Label ID="LTimeSavingRequired" runat="server" BackColor="red" Text="An Entry is Required" Visible="false">
          </asp:Label>
         
        </td>
        
    </tr>
    <tr> 
      <td align="right"><a>*</a>
        Contact Email :: 
      </td>
      <td class="auto-style1">
          <asp:TextBox 
            ID="tbContactEmail" 
            runat="server" 
            Width="290px">
          </asp:TextBox>
          
        </td>

        <td align="right"> <a>*</a>Cost Center ::</td>
        <td class="auto-style3">
          <asp:DropDownList 
            ID="DDLcostCenter" 
            runat="server" 
            AutoPostBack="true"
            Width="240px">
          </asp:DropDownList>
          </td>
        <td align="right">
            <a>*</a>Cost Savings Estimate (whole numbers only; no decimals: no $ sign: 0 for n/a) ::
        </td>
        <td class="auto-style1">
          <asp:TextBox 
            ID="tbCostSavingsEstimate" 
            runat="server" 
            Width="60px">
          </asp:TextBox>
            <asp:Label ID="LCostSavingRequired" runat="server" BackColor="red" Text="An Entry is Required" Visible="false">
          </asp:Label>
        </td>

    </tr>
    <tr> 
      <td align="right">Ext :: </td>
      <td class="auto-style1"> 
        <asp:TextBox 
         ID="tbPhone" 
         runat="server" 
         Width="290px">
        </asp:TextBox></td>
         <td align="right">Project ::</td>
        <td class="auto-style3">
            <asp:TextBox 
            ID="tbProject" 
            runat="server">
            </asp:TextBox>
           </td>

        <td align="right">
            <a>*</a>Revenue Savings Estimate (whole numbers only: no decials: no $ sign: per year: 0 for n/a)::
        </td>
        <td class="auto-style1">
          <asp:TextBox 
            ID="tbRevenueSavingsEstimate" 
            runat="server" 
            Width="60px">
          </asp:TextBox>
            <asp:Label 
            ID="LRevenueSavingRequired" 
            runat="server"
            Text="An Entry is Required" 
            Visible="false" 
            BackColor="red"
            >
          </asp:Label>

        </td>
    </tr>

       <tr>
           <td align="right"><a>*</a>Type::</td>
           <td class="auto-style1">
               <asp:DropDownList 
            ID="ddlType" 
            runat="server" 
            AutoPostBack="true"
            Width="240px">
                   <asp:ListItem>Selection Required</asp:ListItem>
                   <asp:ListItem>Production</asp:ListItem>
                   <asp:ListItem>Prototype</asp:ListItem>
                   <asp:ListItem>Tooling</asp:ListItem>
          </asp:DropDownList></td>
           <td align="right">Rework # ::</td>
           <td class="auto-style3">
            <asp:TextBox 
            ID="tbRework" 
            runat="server">
            </asp:TextBox>Limit: one number per ticket.
           </td>
       </tr>
  	
 
    
    <tr>
      <td align="right"><a>*</a>Requested Need Date :: 
          <br />
           <asp:Label 
            ID="Ldate" 
            runat="server"
            Text="Must Select Date" 
            Visible="false" 
            BackColor="red"
            >
          </asp:Label>
      </td>
	  <td class="auto-style1">
          <asp:Calendar ID="calendar1" runat="server" Width="150px" OnDayRender="calendar1_DayRender"></asp:Calendar></td>
	  <td align="right"><a>*</a>Describe Request ::
          <br />
          <asp:Label 
            ID="Ltrouble" 
            runat="server"
            Text="An Entry is Required" 
            Visible="false" 
            BackColor="red"
            >
          </asp:Label>
        </td>
        <td class="auto-style3">
          <asp:TextBox 
            ID="tbRequest_Text" 
            runat="server" 
            Height="120px"
            Width="280px" 
            TextMode="MultiLine" 
            Font-Names="Arial"
            >
          </asp:TextBox>
        </td>
    </tr>
    
    <tr> 
      	
	<td>
        

	</td>

    
      <td class="auto-style1">
          <br />
            <asp:Label ID="Luid" runat="server" BackColor="yellow"></asp:Label>
          <br />
          <br />
          
        </td>
        <td align="right">
	    

	        <a>*</a>Quantity :: 
          
      
	    </td>
         <td class="auto-style3">
            <asp:TextBox 
            ID="tbQuantity" 
            runat="server">
            </asp:TextBox>
          &nbsp;&nbsp;&nbsp; Numeric digits only - no &quot;EA&quot;.</td>
    </tr>
    
    <tr align="left"> 
      <td></td>
        <td class="auto-style1">
            <asp:Label ID="Lattach" runat="server" BackColor="Yellow" Text="Attach pdf document now." Visible="False"></asp:Label></td>
        <td>
            &nbsp;</td>
        <td class="auto-style3">
            User will be prompted to attach file after request is submitted unless checked:<br />
        </td>
    </tr>
     <tr>
         <td></td>
         <td class="auto-style1">
             <br />
             <br />
             <br />
             <br />
             <br />
             <asp:Label ID="LuploadDocs" runat="server" Visible="false" Text="Find Documents to Upload"></asp:Label>
             </td>
         <td></td>
         <td class="auto-style3">
          <asp:CheckBox ID="cbPDF" Text="NO pdf REQUIRED" runat="server" AutoPostBack="true" Checked="true" />
          
             <br />
             <br />
          
          <asp:CheckBox ID="cbDXF" Text="NO dxf REQUIRED" runat="server" AutoPostBack="true" Checked="true" />
             
             <br />
             <br />
             DXF must be 1:1 or request will be rejected by tool room.<br />
&nbsp;</td>
     </tr>
     <tr>
         <td></td>
         <td class="auto-style1">
             <br />
             <asp:FileUpload ID="FileUpload1" runat="server" Width="368px" Visible="false" />
         </td>
         <td>
            <asp:Label 
	        ID="Lerror" 
	        runat="server" 
	        BackColor="red" 
	        Visible="false">
          </asp:Label>
           </td>
         <td class="auto-style3">
            <asp:Button ID="Button1" 
                        runat="server"  
                        OnClientClick="return checkBeforeSubmit()"
                        OnClick="Button1_Click" Font-Size="Large"  
                        Text="SUBMIT TOOL REQUEST" BorderWidth="20" BorderColor="Blue"/></td>
     </tr>
     <tr>
        <td></td>
         <td class="auto-style1">
             <br />
             <br />
             <asp:Button ID="Button2" 
                         runat="server" 
                         Text="Upload Selected pdf Document" 
                         OnClick="Button2_Click" 
                         Visible="false" />
             </td>
         <td><asp:Label 
            ID="LfileType" 
            runat="server" 
            Text="Must Select a pdf Document" 
            Visible="False" 
            BackColor="Red"
            ></asp:Label></td>
         <td class="auto-style3" bgcolor="#CC99FF">This program has been modified.&nbsp; If anything does not function the way you think it should email tor.hepburn@ametek.com.</td>

     </tr>

    <tr>
	 <td style="height: 102px">
         
     </td>
	 <td class="auto-style2">
         &nbsp;</td>
	 <td>&nbsp;</td>
        <td class="auto-style3"><p>&copy; All Rights reserved.<br/>
      Zygo Corporation</p></td>
	</tr>
</table> 
        

        
    
    </div>
    </form>
</body>
</html>
