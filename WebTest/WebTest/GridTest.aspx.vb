Public Class GridTest
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub RadGrid1_ItemCommand(ByVal sender As Object, ByVal e As EventArgs) Handles RadGrid1.ItemCommand

        Dim tvalue As String = RadGrid1.SelectedValue
        ModalPopupExtender1.Show()

        'RadGrid2.SelectedIndexes.Clear()

    End Sub

End Class