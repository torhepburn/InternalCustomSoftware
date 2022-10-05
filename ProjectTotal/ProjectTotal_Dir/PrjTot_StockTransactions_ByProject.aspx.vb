
Partial Class ProjectTotal_Dir_PrjTot_StockTransactions_ByProject
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Text = Session("strProject")
        Label2.Text = Session("strProject")
        Dim StockTrxAdapter As New ProjectTotalTableAdapters.tabProjectStockTransactionsTableAdapter
        Dim totalToAmount As Double, totalFromAmount As Double
            If StockTrxAdapter.Scalar_StockTransfers_FromProj(Session("strProject")).HasValue Then
                totalToAmount = StockTrxAdapter.Scalar_StockTransfers_FromProj(Session("strProject"))
            Else
                totalToAmount = 0
            End If
            TotalIntoProject.Text = Format(totalToAmount, "currency")

            If StockTrxAdapter.Scalar_StockTransfers_ToProj(Session("strProject")).HasValue Then
                totalFromAmount = StockTrxAdapter.Scalar_StockTransfers_ToProj(Session("strProject"))
            Else
                totalFromAmount = 0
            End If
            TotalFromProject.Text = Format(totalFromAmount, "currency")

            TotalAmount.Text = Format((totalToAmount - totalFromAmount), "currency")
        End Sub
End Class
