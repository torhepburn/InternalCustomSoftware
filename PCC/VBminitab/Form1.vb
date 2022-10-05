Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim MtbApp As New Mtb.Application

        MtbApp.UserInterface.Visible = True

        Dim MtbProj As Mtb.Project = MtbApp.ActiveProject
        MtbProj.ExecuteCommand("RANDOM 10 C1 - C2")
        'MtbProj.ExecuteCommand("REGRESS C1 1 C2")


        'MtbApp.[New]()
        Dim x As String = "ccc"

        MtbApp.Quit()

    End Sub
End Class
