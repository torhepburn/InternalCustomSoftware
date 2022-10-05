
Partial Class ProjectTotal_Dir_PrjTot_BOMDetail_AcrossProj
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Text = Request.QueryString("ITEM_CODE")
    End Sub


End Class
