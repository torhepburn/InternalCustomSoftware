
Partial Class ProjectTotal_Dir_PrjTot_Hour_Cost_by_Month
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Text = Session("strProject")
    End Sub
End Class
