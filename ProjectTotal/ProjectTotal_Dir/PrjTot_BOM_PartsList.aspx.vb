
Partial Class ProjectTotal_Dir_PrjTot_BOM_PartsList
    Inherits System.Web.UI.Page

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            If e.Row.DataItem("MinActCost").ToString <> e.Row.DataItem("MaxActCost").ToString Then
                e.Row.BackColor = Drawing.Color.LightBlue
            End If
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       Label1.Text = Session("strProject")

    End Sub
End Class
