<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThankYou.aspx.cs" Inherits="PM.ThankYou" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Maintenance Thanks</title>
    <style type ="text/css">
    body
    {
       font-family: Arial; 
       font-size:12pt;
       font-weight:bold;
       width:100%;
       padding:10px;
    }
    a 
    {
        font-family: Arial;
        font-size:14pt;
        color:black;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table style="z-index:100;
                    left:0px; 
                    position:absolute;
                    width:100%; 
                    top:0px">
  <tr>
     <td style="text-align:center;
                font-family:Arial; 
                color:#003366;
                width:100%; 
                background-color:#003366;">  "  "
     </td>
   </tr>
  
   <tr>
    <td 
    style="background-color:#cccccc;"
       colspan="3">
      <b>Maintenance</b>
     </td>
   </tr>
  
   <tr>
     <td
        colspan="3" 
        style="text-align:center;"><a>Maintenance Request Form</a>
      </td>
   </tr>

    <tr >
        <td>
        <br />
        <b>Thank You!</b>
        <br />
        <br />
        Dear Requestor,&nbsp;<br />
        <br />
        Thanks for your request!
        <br />
        <br />
        Please check your email!
        <br /><br />
        Zygo's IntraComm has sent you a confirmation of your request to your email address.
        <br /><br />
        Zygo's Maintenance Department will review your request and get back to your shortly!
        <br /><br />
        </td>
        
    </tr>
     
    
    </table>
    </div>
    
    
    </form>
</body>
</html>
