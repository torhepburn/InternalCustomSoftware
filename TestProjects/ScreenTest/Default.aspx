<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .newStyle1 {
            font-family: Arial, Helvetica, sans-serif;
            font-size: large;
        }
        .newStyle2 {
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
        }
        .auto-style1 {
            color: #FF0000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
         <Table ID="Table1" 
             runat="server" 
             Height="100%" 
             Width="100%">
             <tr>
                 <td align="center">
                     <span class="newStyle1">Dashboard Account Request Form</span>
                     <br />
                 </td>
            </tr>

             <tr>
                 <td align="center">
                     <span class="newStyle2">Attention:&nbsp; Please use your valid email address.&nbsp; This script will send the results of the processing ot the entered email.<br />
                     <br />
                     <span class="auto-style1">*</span> - Required Fields<br />
                     </span>
                 </td>
            </tr>
             <tr>
                 <td align="center">
                     <table><span class="newStyle2">
                         <tr><td><span class="newStyle2">Requestor's Name:&nbsp; </span></td>
                             <td><asp:DropDownList
                                            ID="ddlRequestorName"
                                            runat="server"
                                            AutoPostBack="true"
                                            Width="240px"
                                            OnSelectedIndexChanged="ddlRequestorName_SelectedIndexChanged"
                                            Font-Names="Verdana"
                                            Font-Size="Small">
                                        </asp:DropDownList></td></tr>
                         <tr>text<td><span class="newStyle2">Requestor&#39;s Email:&nbsp; </span></td><td><asp:TextBox ID="tbRequestorEmail" runat="server" Width="240px"></asp:TextBox></td></tr>
                         <tr><td></td><td><span class="newStyle2">
                             <br />
                             An entry needs to be made either from the drop<br />
                             down list below or in the New Employee box<br />
                             if the new employee&#39;s name can not be found<br />
                             in the drop down list.&nbsp; If the New Employee box<br />
                             is filled in, hten an email address does not<br />
                             need to be filled in.<br />
                             </span></td></tr>
                         
                         <tr>text<td><span class="newStyle2">Employee&#39;s Name:&nbsp; </span></td>
                             <td><asp:DropDownList
                                            ID="ddlEmployeeName"
                                            runat="server"
                                            AutoPostBack="true"
                                            Width="240px"
                                            OnSelectedIndexChanged="ddlEmployeeName_SelectedIndexChanged"
                                            Font-Names="Verdana"
                                            Font-Size="XX-Small">
                                        </asp:DropDownList></td></tr>
                         <tr>text<td><span class="newStyle2"></span></td><td><asp:TextBox ID="Textbox1" runat="server" Width="240px"></asp:TextBox></td></tr>
                         <tr>text<td><span class="newStyle2">Employee&#39;s Email:</span></td><td><asp:TextBox ID="Textbox5" runat="server" Width="200px"></asp:TextBox></td></tr>
                         </span>
                     </table>
                 </td>
            </tr>
             <tr>
                 <td align="center">
                     test
                 </td>
            </tr>
             <tr>
                 <td align="center">
                     test
                 </td>
            </tr>
             <tr>
                 <td align="center">
                     test
                 </td>
            </tr>
             <tr>
                 <td align="center">
                     test
                 </td>
            </tr>
             <tr>
                 <td align="center">
                     test
                 </td>
            </tr>
             <tr>
                 <td align="center">
                     test
                 </td>
            </tr>
             <tr>
                 <td align="center">
                     test
                 </td>
            </tr>
             <tr>
                 <td align="center">
                     test
                 </td>
            </tr>
             <tr>
                 <td align="center">
                     test
                 </td>
            </tr>
             <tr>
                 <td align="center">
                     test
                 </td>
            </tr>
             <tr>
                 <td align="center">
                     test
                 </td>
            </tr>
             <tr>
                 <td align="center">
                     test
                 </td>
            </tr>



        </Table>

        </div>
        
    </form>
</body>
</html>
