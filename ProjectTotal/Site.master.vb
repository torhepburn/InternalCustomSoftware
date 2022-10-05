
Partial Class Site
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.LastUpdate.Text = "Last Updated: " & Application("LastUpdateDate")
    End Sub
End Class

