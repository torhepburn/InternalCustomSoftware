Imports ProjectTotalTableAdapters
Imports System.Data
Partial Class ProjectTotal_Dir_PrjTot_LaborSummary
    Inherits System.Web.UI.Page

    Dim _sum_Hours As Decimal = 0           'column 2
    Dim _sum_Amount As Decimal = 0          'column 3
Public Sub ASPNET_MsgBox(ByVal Message As String)

        System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=""JavaScript"">" & vbCrLf)
        System.Web.HttpContext.Current.Response.Write("alert(""" & Message & """)" & vbCrLf)
        System.Web.HttpContext.Current.Response.Write("</SCRIPT>")

End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Text = Session("strProject")
        'Label1.Text = "test"
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
    If e.Row.RowType = DataControlRowType.DataRow Then

        Dim product As ProjectTotal.tabProjectLaborHrsSummaryRow = _
            CType(e.Row.DataItem.Row, ProjectTotal.tabProjectLaborHrsSummaryRow)

        'If Not product.IsFinCostAmountNull() Then
            _sum_Hours += product.LaborHrs
            _sum_Amount += product.SumOfAMOUNT
        'End If



    ElseIf e.Row.RowType = DataControlRowType.Footer Then
        'Dim tblAdapater As New tabProjectLaborHrsSummaryTableAdapter

        'Dim dt As DataTable
        'Dim dr As DataRowCollection
        e.Row.Cells(1).Text = "Totals (All pages)"
        e.Row.Cells(2).Text = _sum_Hours.ToString("#,##0.00")
        e.Row.Cells(3).Text = _sum_Amount.ToString("#,##0.00")

        'dt = tblAdapater.GetDataBy_tabProjectLaborHrsSummary_Project(Session("strProject"))
        'dr = dt.Rows() 'The table's row collection

        'e.Row.Cells(0).Text = "Totals (All pages)"
        'e.Row.Cells(1).Text = CType(dr(0)("LaborHrs"), Decimal).ToString("#,##0.00")
        'e.Row.Cells(2).Text = CType(dr(0)("SumOfAmount"), Decimal).ToString("#,##0.00")
        'e.Row.Cells(3).Text = ""
    End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
    ' Determine the index of the selected row.
    Dim index As Integer = GridView1.SelectedIndex

    ' Display the primary key value of the selected row.
    'ASPNET_MsgBox("The index is " & index & "  The primary key value of the selected row is " & _
    '    GridView1.DataKeys(index).Value.ToString() & ".")

    Dim instance As GridView = GridView1

    Dim value As String()

    value = instance.DataKeyNames

    'ASPNET_MsgBox("The datakeynames(0) is  " & value(0) & "." & _
    '    "The datakeynames(1) is  " & value(1) & ".")
    'Message.Text = "The primary key value of the selected row is " & _
    '    GridView1.DataKeys(index).Value.ToString() & "."

    'ASPNET_MsgBox("The content(0) is  " & GridView1.DataKeys(0).Value & "." & _
    '    "The content(1) is  " & GridView1.DataKeys(1).Value & ".")

        ASPNET_MsgBox("Project: " & GridView1.DataKeys(0).Value)
        ASPNET_MsgBox("Period: " & instance.SelectedRow.Cells(1).Text())
    End Sub
End Class
