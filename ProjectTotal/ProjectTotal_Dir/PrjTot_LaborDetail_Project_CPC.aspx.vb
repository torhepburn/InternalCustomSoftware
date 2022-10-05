
Partial Class ProjectTotal_Dir_PrjTot_LaborDetail_Project_CPC
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Text = Session("strProject") & " --- Cost Price Component: " & Request.QueryString("CPC")
    End Sub
End Class
