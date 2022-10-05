<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Escapes.aspx.cs" Inherits="Default2" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Quality Escapes</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1 style="text-align: center">
            ZOS
            Escapes A3 Charts</h1>
        <h2>
            Escapes - Items Inspected by IQC &amp; Found Defective in Workcell</h2>
        <p>
            &nbsp;
        </p>
        <h2>
            <rsweb:ReportViewer ID="ReportViewer1" 
                                runat="server" 
                                Font-Names="Verdana" 
                                Font-Size="8pt"
                                Height="400px" 
                                ShowDocumentMapButton="False" 
                                ShowFindControls="False" 
                                Width="754px"
                                ZoomPercent="75">
                <LocalReport ReportPath="Escapes.rdlc">
                  <DataSources>
                        <rsweb:ReportDataSource DataSourceId="AccessDataSource1" 
                                                Name="FAST_Analysis_mdb" />
                    </DataSources>
                 </LocalReport>
               
            </rsweb:ReportViewer>
            <asp:AccessDataSource ID="AccessDataSource1" 
                                  runat="server" 
                                  DataFile="~/App_Data/FAST_Analysis.mdb"
                SelectCommand="SELECT *&#13;&#10;FROM dbo_VIEW_FAST_Escape_Query_IQC_ZOS&#13;&#10;WHERE (DateCreated < Now()) AND DateCreated > (Now()-183) AND (FASTDEFECTBDESC <> 'Performance') AND (FASTDEFECTBDESC <> 'Functional Failure') AND (FASTDEFECTBDESC <> 'Failed Component') AND (FASTDEFECTBDESC <> 'Performance/Function') ">
            </asp:AccessDataSource>
        </h2>
        <h2>
            Pareto</h2>
       <p>
            <rsweb:ReportViewer ID="ReportViewer2" runat="server" Font-Names="Verdana" Font-Size="8pt"
                Height="507px" Width="874px" ZoomPercent="75">
                <LocalReport ReportPath="Escapes Pareto.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="AccessDataSource2" 
                                                Name="FAST_Analysis_mdb" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:AccessDataSource ID="AccessDataSource2" 
                                  runat="server" 
                                  DataFile="~/App_Data/FAST_Analysis.mdb"
                SelectCommand="SELECT FASTDEFECTBDESC, TotalQuantity, FASTDEFECTADESC, MAX(FASTDEFECTBDESC) AS F_ID FROM (SELECT FASTDEFECTBDESC, SUM(Qty) AS TotalQuantity, FASTDEFECTADESC, Qty FROM (SELECT FASTDEFECTADESC, FASTDEFECTBDESC, DateCreated, Qty FROM dbo_VIEW_FAST_Escape_Query_IQC_ZOS) derivedtbl_2 WHERE (DateCreated < NOW()) AND (DateCreated > NOW() - 183) GROUP BY FASTDEFECTBDESC, FASTDEFECTADESC, Qty) derivedtbl_1 GROUP BY FASTDEFECTBDESC, TotalQuantity, FASTDEFECTADESC HAVING (TotalQuantity >= 1) AND (FASTDEFECTBDESC <> 'Performance') AND (FASTDEFECTBDESC <> 'Functional Failure') AND (FASTDEFECTBDESC <> 'Failed Component') AND (FASTDEFECTBDESC <> 'Performance/Function') ORDER BY TotalQuantity DESC, FASTDEFECTADESC" OnSelecting="AccessDataSource2_Selecting">
            </asp:AccessDataSource>
        </p>
        <h2>
            Action Items</h2>
        <p>
            &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:GridView ID="GridView1" 
                      runat="server" 
                      AutoGenerateColumns="False" 
                      DataSourceID="AccessDataSource3"
                      OnSelectedIndexChanged="GridView1_SelectedIndexChanged2" 
                      Width="500px" 
                      AllowSorting="True" 
                      BackColor="White" 
                      BorderColor="#CCCCCC" 
                      BorderStyle="None" 
                      BorderWidth="1px" 
                      CellPadding="3">
            <Columns>
                <asp:BoundField DataField="FastID" HeaderText="FastID" SortExpression="FastID" />
                <asp:BoundField DataField="PartNumber" HeaderText="PartNumber" SortExpression="PartNumber" />
                <asp:BoundField DataField="FastDefectPathName" HeaderText="FastDefectPathName" SortExpression="FastDefectPathName" />
                <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" />
                <asp:BoundField DataField="MonthDue" HeaderText="Month Defect Found" ReadOnly="True" SortExpression="MonthDue" />
            </Columns>
            <RowStyle ForeColor="#000066" />
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
            &nbsp;
        <asp:AccessDataSource ID="AccessDataSource3" 
                              runat="server" 
                              DataFile="~/App_Data/FAST_Analysis.mdb"
            SelectCommand="SELECT FastID, PartNumber, FastDefectPathName, Sum(Qty) AS Total, Month(DateCreated) AS MonthDue FROM dbo_VIEW_FAST_Escape_Query_IQC_ZOS WHERE (DateCreated < NOW()) AND (DateCreated > NOW() - 60) AND (FASTDEFECTBDESC <> 'Performance') AND (FASTDEFECTBDESC <> 'Functional Failure') AND (FASTDEFECTBDESC <> 'Failed Component') AND (FASTDEFECTBDESC <> 'Performance/Function') GROUP BY FastID, PartNumber, FastDefectPathName, DateCreated" OnSelecting="AccessDataSource3_Selecting">
        </asp:AccessDataSource>
        &nbsp;&nbsp;&nbsp;<br />
        <br />
        <a href="Default.aspx">Back to Home Page</a>
    </p>
    
    </div>
    </form>
</body>
</html>
