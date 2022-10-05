<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RicToolRoomDefault.aspx.cs" Inherits="ToolRoom._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Richmond Tool Room Requests</title>
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
             width: 348px;
         }
    
         .auto-style3 {
             width: 445px;
         }
    
         .auto-style4 {
             width: 174px;
         }
         .auto-style5 {
             width: 348px;
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
      <b><c>Richmond Tool Room Requests</c></b>
     </td>
   </tr>
  
   <tr>
     <td
        colspan="6" 
        ><b></b>
      </td>
   </tr>


     <tr>
         <td
        colspan="6" 
        style="text-align:center;"><b>Items marked with an asterisk <a>*</a> require an entry.<br />
            <asp:CheckBox ID="cbPersist" Text="Check this box if you want to make multiple entries and have some selections remain.   " runat="server" AutoPostBack="true" />
            Submit Tool Room request prior to attaching support document (pdf format required). </b>
      </td>
     </tr>

 
    <tr> 
      <td align="right">
        <a>*</a> Name :: 
      </td>
      
      <td class="auto-style5">
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
      < <td align="right" class="auto-style4"> <a>*</a>Priority::</td>

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
            Does part need to be anodized::</td>
        <td class="auto-style1">
            <asp:CheckBox ID="cbAnodized" Text=" Check for YES" runat="server" AutoPostBack="true" Checked="false" /></td>
        
    </tr>
    <tr> 
      <td align="right"><a>*</a>
        Contact Email :: 
      </td>
      <td class="auto-style5">
          <asp:TextBox 
            ID="tbContactEmail" 
            runat="server" 
            Width="236px"></asp:TextBox>
          
        </td>

        <td align="right" class="auto-style4"> 
	    

	        <a>*</a>Quantity :: 
          
      
	    </td>
        <td class="auto-style3">
            <asp:TextBox 
            ID="tbQuantity" 
            runat="server">
            </asp:TextBox>
             Numeric digits only - no &quot;EA&quot;.</td>
        <td align="right">
            Contact for Technical Information::</td>
        <td class="auto-style1">
          <asp:TextBox 
            ID="tbTechnicalContactName" 
            runat="server" 
            Width="236px"></asp:TextBox>
        </td>

    </tr>
     <tr>
        <td align="right">Department ::</td>
         <td class="auto-style5"> 
               <asp:DropDownList 
            ID="ddlDepartment" 
            runat="server" 
            AutoPostBack="true"
            Width="240px">
                   <asp:ListItem>Selection Required</asp:ListItem>
                   <asp:ListItem>CCOS</asp:ListItem>
                   <asp:ListItem>IBF</asp:ListItem>
                   <asp:ListItem>Metrology</asp:ListItem>
                   <asp:ListItem>CNC</asp:ListItem>
                   <asp:ListItem>Work Cell</asp:ListItem>
                   <asp:ListItem>QC</asp:ListItem>
                   <asp:ListItem>Assembly</asp:ListItem>
                   <asp:ListItem>Engineering</asp:ListItem>
                   <asp:ListItem>Small Optics</asp:ListItem>
                   <asp:ListItem>Other</asp:ListItem>
          </asp:DropDownList></td>
         <td align="right">Charge Type::</td>
         <td class="auto-style5"> 
             <asp:CheckBox ID="cbProjectcharge" Text="  Project Charge #" runat="server" AutoPostBack="true" Checked="false" OnCheckedChanged="cbProjectcharge_CheckedChanged" />
             &nbsp;
             <asp:CheckBox ID="cbCostCenter" Text="  Cost Center" runat="server" AutoPostBack="true" Checked="false" OnCheckedChanged="cbCostCenter_CheckedChanged" />
             </td>
         <td align="right"></td>
         <td>List Participants for Design Review::
          <asp:TextBox 
            ID="tbDesignReviewParticipants" 
            runat="server" 
            Width="311px"></asp:TextBox>

         </td>
        
     </tr>
        <tr>
        <td align="right">Customer::</td>
         <td class="auto-style5"> 
               <asp:DropDownList 
            ID="ddlCustomer" 
            runat="server" 
            AutoPostBack="true"
            Width="240px">
               
          </asp:DropDownList></td>
         <td align="right">
             <asp:Label
                 ID="LChargeType"
                 Runat="server"
                 AutoPostBack="true"
                 Visible="false"
                 ></asp:Label>
             </td>
            <td>
             <asp:DropDownList 
            ID="ddlChargeNumber" 
            runat="server" 
            AutoPostBack="true"
            Visible="false"
            Width="240px"> 
          </asp:DropDownList>

            </td>
            <td></td>
            <td>Deliver completed tooling to::
          <asp:TextBox 
            ID="tbDeliverTo" 
            runat="server" 
            Width="308px"></asp:TextBox>

            </td>
            
     </tr>
        <tr>
        <td align="right">Project::</td>
         <td class="auto-style5"> 
               <asp:DropDownList 
            ID="ddlProject" 
            runat="server" 
            AutoPostBack="true"
            Width="240px">
                 <asp:ListItem>Selection Required</asp:ListItem>
                   <asp:ListItem>OP-COST-BIG</asp:ListItem>  
          </asp:DropDownList></td>
         <td align="right">Optics drawing # and path::</td>
            <td>
            <asp:TextBox 
            ID="tbOpticDrawing_Path" 
            runat="server" Width="376px"></asp:TextBox>
            </td>
            <td align="right"></td>
            <td>Surface of optic that will be focused on with this tool::
            <asp:TextBox 
            ID="tbFocalSurface" 
            runat="server" Width="300px"></asp:TextBox>
            </td>
            
     </tr>
    <tr> 

      <td align="right">Part :: </td>
      <td class="auto-style5"> 
               <asp:DropDownList 
            ID="ddlPart" 
            runat="server" 
            AutoPostBack="true"
            Width="240px">
                   <asp:ListItem>Selection Required</asp:ListItem>
                   <asp:ListItem>Wedge</asp:ListItem>
          </asp:DropDownList></td>
         <td align="right" class="auto-style4">If modification of exsting tool, list tool number::</td>
        

        <td>
	    

            <asp:TextBox 
            ID="tbExistingTool" 
            runat="server">
            </asp:TextBox>
	    

	        </td>
        <td>

        </td>
        <td class="auto-style1">Machine # ::<br />
            <asp:TextBox 
            ID="tbMachineNumber" 
            runat="server">
            </asp:TextBox>
        </td>
    </tr>

     <tr>
         <td> 
             <br />
         </td>
         <td> 
             
         </td>
         <td align="right" class="auto-style4">Tool Description ::</td>
         <td class="auto-style3">
            <asp:TextBox 
            ID="tbToolDescription" 
            runat="server" Width="371px"></asp:TextBox>
           </td>

     </tr>

       <tr>
           <td align="right"><a>*</a>Requested Need Date :: 
          <br/>
           <asp:Label 
            ID="Ldate" 
            runat="server"
            Text="Must Select Date" 
            Visible="false" 
            BackColor="red"
            >
          </asp:Label>
           </td>
           <td class="auto-style5">
          <asp:Calendar ID="calendar1" runat="server" Width="150px" OnDayRender="calendar1_DayRender"></asp:Calendar></td>
           <td align="right" class="auto-style4"><a>*</a>Describe Request/List Requirements ::
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

           <td align="right">Any additional information (e.g., combine tooling with ID xxx)::</td>
           <td>
          <asp:TextBox 
            ID="tbAdditionalInformation" 
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
      <td align="right">&nbsp;</td>
	  <td class="auto-style5">
          &nbsp;</td>
	  <td align="right" class="auto-style4">
	    

	        &nbsp;</td>
        <td class="auto-style3">
            &nbsp;</td>
    </tr>
    
    
    
    <tr align="left"> 
      <td></td>
        <td class="auto-style5">
            <asp:Label ID="Lattach" runat="server" BackColor="Yellow" Text="Attach pdf document now." Visible="False"></asp:Label></td>
        <td class="auto-style4">
            <asp:Label ID="Luid" runat="server" BackColor="yellow"></asp:Label>
          </td>
        <td class="auto-style3">
            User will be prompted to attach file after request is submitted unless checked:<br />
        </td>
    </tr>
     <tr>
         <td></td>
         <td class="auto-style5">
             <br />
             <br />
             <br />
             <br />
             <br />
             <asp:Label ID="LuploadDocs" runat="server" Visible="false" Text="Find Documents to Upload"></asp:Label>
             </td>
         <td class="auto-style4"></td>
         <td class="auto-style3">
          <asp:CheckBox ID="cbPDF" Text="Attach pdf" runat="server" AutoPostBack="true" Checked="false" />
          
             <br />
             <br />
          
          <asp:CheckBox ID="cbDXF" Text="Attach dxf" runat="server" AutoPostBack="true" Checked="false" />
             
             <br />
             <br />
             DXF must be 1:1 or request will be rejected by tool room.<br />
&nbsp;</td>
     </tr>
     <tr>
         <td></td>
         <td class="auto-style5">
             <br />
             <asp:FileUpload ID="FileUpload1" runat="server" Width="368px" Visible="false" />
         </td>
         <td class="auto-style4">
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
         <td class="auto-style5">
             <br />
             <br />
             <asp:Button ID="Button2" 
                         runat="server" 
                         Text="Upload Selected pdf Document" 
                         OnClick="Button2_Click" 
                         Visible="false" />
             </td>
         <td class="auto-style4"><asp:Label 
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
	 <td class="auto-style4">&nbsp;</td>
        <td class="auto-style3"><p>&copy; All Rights reserved.<br/>
      Zygo Corporation</p></td>
	</tr>
</table> 
        

        
    
    </div>
    </form>
</body>
</html>
