
Partial Class ProjectTotal_Dir_PrjTot_ProductionOrdersProj_Operations
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Text = Session("strProject") & " --- Order Number: " & Request.QueryString("Order_Number")
    End Sub
End Class
