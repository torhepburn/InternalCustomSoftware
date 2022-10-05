<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="z-index: 100; left: 0px; width: 968px; position: absolute; top: 0px;
            height: 576px">
            <tr>
                <td>
                </td>
                <td style="width: 259px">
                    <asp:DropDownList ID="DropDownList1" 
                                      runat="server" 
                                      DataSourceID="SqlDataSource1"
                                      DataTextField="StatusCode" 
                                      DataValueField="StatusCode" 
                                      Style="z-index: 100; left: 320px;
                                        position: absolute; top: 8px">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" 
                                       runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:CalibrationConnectionString %>"
                                       SelectCommand="SELECT [StatusCode] FROM [status] ORDER BY [StatusCode]">
                    </asp:SqlDataSource>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="height: 197px">
                </td>
                <td style="width: 250px; height: 200px">
                    <asp:Calendar ID="Calendar1" 
                                  runat="server" 
                                  Style="z-index: 100; left: 240px; position: absolute;
                                        top: 48px">
                    </asp:Calendar>
                </td>
                <td style="height: 197px">
                </td>
                <td style="height: 197px">
                </td>
            </tr>
            <tr>
                <td style="height: 151px">
                </td>
                <td style="width: 259px; height: 151px">
                </td>
                <td style="height: 151px">
                </td>
                <td style="height: 151px">
                </td>
            </tr>
                       <tr>
                <td>
                </td>
                <td style="width: 259px">
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
                       <tr>
                <td>
                </td>
                <td style="width: 259px">
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>


        </table>
    
    </div>
    
    </form>
</body>
</html>
