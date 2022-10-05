
Partial Class ProjectTotal_Dir_PrjTot_LaborDetail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Text = Session("strProject") & " --- Period: " & Request.QueryString("Financial_Period")

    End Sub
End Class
