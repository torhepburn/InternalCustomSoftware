<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="QAMiddlefield._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>QualityStoryboard</title>
    <style type ="text/css">
    table
    {
       font-family: Arial; 
       font-size:16pt;
       font-weight:bold;
       width:30%;
       padding:10px;
       text-align:center;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1 style="text-align:center">
            <span style="color: #ff00ff">Quality Storyboard Middlefield</span></h1>
            <br />

    </div>
    <div>
          <table
        border="3" 
        bordercolor="blue"
        style="z-index: 100;
               width: 95%; 
               height: 600px">
            <tr>
                <td><a href="TimePartsSpentinQC.aspx">Time Parts spent in QC</a>
                </td>
                <td><a href="Lean Education.aspx">About Lean</a>
                </td>
                <td><a href="Inspection Backlog.aspx">Inspection Backlog</a>
                </td>
            </tr>
            <tr>
                <td><a href="FQCTurnbacks.aspx">FQC Turnbacks</a>
                </td>
                <td><a href="DTC.aspx">DTC</a>
                </td>
                <td><a href="Escapes.aspx">Quality Escapes</a>
                </td>
            </tr>
            <tr>
                <td><a href="MRB.aspx">MRB A3 Charts</a>
                </td>
                <td><a href="Cost of Quality.aspx">Cost of Quality</a>
                </td>
                <td><a href="Customer Feedback.aspx">Customer Feedback</a>
                </td>
            </tr>
            <tr>
                <td><a href="Calibration.aspx">Calibration</a>
                </td>
                <td><a href="RCCA Age.aspx">RCCA Age</a>
                </td>
                <td><a href="Incident Info.aspx">Incident Info</a>
                </td>
            </tr>
        </table>

     </div>
    </form>
</body>
</html>
