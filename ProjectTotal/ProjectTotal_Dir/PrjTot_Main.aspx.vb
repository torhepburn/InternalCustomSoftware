
Imports ProjectTotalTableAdapters
Imports System.Data
Partial Class ProjectTotal_Dir_MainProjectTotal2
    Inherits System.Web.UI.Page
Dim _sum_Sales As Decimal = 0       'column 2
Dim _sum_Cost As Decimal = 0         'column 3
Dim _sum_Material As Decimal = 0    'column 4
Dim _sum_Labor As Decimal = 0       'column 5
Dim _sum_StoctTrx As Decimal = 0     'column 6
Dim _sum_Purchase As Decimal = 0    'column 7
Dim _sum_SubContract As Decimal = 0 'column 8
Dim _sum_Total As Decimal = 0       'column 9
Dim _sum_Consult As Decimal = 0       'column 9
Protected Sub textboxProject_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles textboxProject.TextChanged
        TextBox1.Text = textboxProject.ToString

End Sub

   Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Request.QueryString("P_ID") Is Nothing Then
                If textboxProject.Text = "" Then
                    Session("strProject") = Request.QueryString("P_ID")
                    textboxProject.Text = Session("strProject")
                Else

                End If
            Else
                If Session("strProject") <> "" And textboxProject.Text = "" Then
                    textboxProject.Text = Session("strProject")
                Else
                    Session("strProject") = textboxProject.Text
                End If
            End If
        Catch ex As Exception
            If Session("strProject") <> "" And textboxProject.Text = "" Then
                Session("strProject") = textboxProject.Text
                textboxProject.Text = Session("strProject")
            End If
        Finally
                If Session("strProject") <> "" And textboxProject.Text = "" Then
                    textboxProject.Text = Session("strProject")
                Else
                    Session("strProject") = textboxProject.Text
                End If
        End Try



    End Sub



    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        TextBox1.Text = textboxProject.Text
        'Doesn't work here: Session("strProject") = Request("textboxProject")
        Session("strProject") = textboxProject.Text
    End Sub

Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
    If e.Row.RowType = DataControlRowType.DataRow Then

        Dim product As ProjectTotal.tabProjectFinTransSumByPeriodRow = _
            CType(e.Row.DataItem.Row, ProjectTotal.tabProjectFinTransSumByPeriodRow)

        If Not product.IsFinCostAmountNull() Then
            _sum_Sales += product.FinSalesAmount
            _sum_Cost += product.FinCostAmount
            _sum_Material += product.MaterialCost
            _sum_Labor += product.LaborCost
            _sum_StoctTrx += product.StockTransferCost
            _sum_Purchase += product.PurchaseCost
            _sum_SubContract += product.SubContractCost
            _sum_Total += product.TotalCost
            _sum_Consult += product.ConsultTotal
        End If


    ElseIf e.Row.RowType = DataControlRowType.Footer Then
        Dim tblAdapater As New tabProjectFinTransSumByPeriodTableAdapter

        Dim dt As DataTable
        Dim dr As DataRowCollection


        dt = tblAdapater.GetDataBy_ProjectTotal(Session("strProject"))
        dr = dt.Rows() 'The table's row collection

        'tblAdapater.GetData()
        ' Response.Write()

' FinSalesAmount, FinCostAmount,MaterialCost,LaborCost
'StockTransferCost,PurchaseCost,SubContractCost,TotalCost


        e.Row.Cells(0).Text = "Totals (All pages)"
        e.Row.Cells(1).Text = ""
        e.Row.Cells(2).Text = CType(dr(0)("FinSalesAmount"), Decimal).ToString("#,##0.00")
        e.Row.Cells(3).Text = CType(dr(0)("FinCostAmount"), Decimal).ToString("#,##0.00")
        e.Row.Cells(4).Text = CType(dr(0)("MaterialCost"), Decimal).ToString("#,##0.00")
        e.Row.Cells(5).Text = CType(dr(0)("LaborCost"), Decimal).ToString("#,##0.00")
        e.Row.Cells(6).Text = CType(dr(0)("StockTransferCost"), Decimal).ToString("#,##0.00")
        e.Row.Cells(7).Text = CType(dr(0)("PurchaseCost"), Decimal).ToString("#,##0.00")
        e.Row.Cells(8).Text = CType(dr(0)("SubContractCost"), Decimal).ToString("#,##0.00")
        e.Row.Cells(9).Text = CType(dr(0)("TotalCost"), Decimal).ToString("#,##0.00")
        e.Row.Cells(12).Text = CType(dr(0)("ConsultTotal"), Decimal).ToString("#,##0.00")

        'e.Row.Cells(2).Text = _sum_Sales.ToString("#,##0.00")
        'e.Row.Cells(3).Text = _sum_Cost.ToString("#,##0.00")
        'e.Row.Cells(4).Text = _sum_Material.ToString("#,##0.00")
        'e.Row.Cells(5).Text = _sum_Labor.ToString("#,##0.00")
        'e.Row.Cells(6).Text = _sum_StoctTrx.ToString("#,##0.00")
        'e.Row.Cells(7).Text = _sum_Purchase.ToString("#,##0.00")
        'e.Row.Cells(8).Text = _sum_SubContract.ToString("#,##0.00")
        'e.Row.Cells(9).Text = _sum_Total.ToString("#,##0.00")
    End If
End Sub

End Class
