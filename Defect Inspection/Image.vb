Public Class Image

    Public im As Bitmap
    Public filename As String
    Public Grid As Object

    Private Sub Image_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not im Is Nothing Then
            im.Dispose()
        End If
        im = Nothing

    End Sub

    Private Sub Image_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    'Public Sub New(ByRef myown As Form, Optional ByRef fname As String = "", Optional ByRef DGrid As Object = Nothing)
    Public Sub New(ByRef DGrid As Object, ByRef fname As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        '        Me.Owner = myowner
        Grid = DGrid
        ' Add any initialization after the InitializeComponent() call.


 
        If fname <> "" Then
            Try
                im = New Bitmap(fname)
                PictureBox1.Image = im
            Catch

            End Try
        End If

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        Me.Dispose()
        If Not im Is Nothing Then
            im.Dispose()
        End If
        im = Nothing


    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Dim od As OpenFileDialog
        
        od = New OpenFileDialog
        od.InitialDirectory = System.Windows.Forms.Application.StartupPath & "\Images\"

        od.Filter = "(*.bmp)|*.bmp|(*.jpg)|*.jpg|(*.*)|*.*"

        If od.CheckFileExists And Not (od.ShowDialog = Windows.Forms.DialogResult.Cancel) Then
            im = New Bitmap(od.FileName)
            PictureBox1.Image = im
            filename = od.FileName
            filename = My.Computer.FileSystem.GetName(filename)
            Grid.CurrentCell.Value = filename
        End If

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub
End Class