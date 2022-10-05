
Partial Class ProjectTotal_Dir_PrjTot_TransConsulting
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("CPC") = "CSL" Then
            Label1.Text = "Consulting Labor for " & Session("strProject")
        ElseIf Request.QueryString("CPC") = "CSM" Then
            Label1.Text = "Consulting Material for " & Session("strProject")
        ElseIf Request.QueryString("CPC") = "CST" Then
            Label1.Text = "Consulting Travel for " & Session("strProject")
        Else : Label1.Text = "Consulting Total for " & Session("strProject")
        End If
    End Sub
End Class
