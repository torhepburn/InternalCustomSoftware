
Partial Class ProjectTotal_Dir_PrjTot_LaborSummary
    Inherits System.Web.UI.Page
Public Sub ASPNET_MsgBox(ByVal Message As String)

        System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=""JavaScript"">" & vbCrLf)

        System.Web.HttpContext.Current.Response.Write("alert(""" & Message & """)" & vbCrLf)

        System.Web.HttpContext.Current.Response.Write("</SCRIPT>")

End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Text = Session("strProject")
        'Label1.Text = "test"
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
    ' Determine the index of the selected row.
    Dim index As Integer = GridView1.SelectedIndex

    ' Display the primary key value of the selected row.
    'ASPNET_MsgBox("The index is " & index & "  The primary key value of the selected row is " & _
    '    GridView1.DataKeys(index).Value.ToString() & ".")

    Dim instance As GridView = GridView1

    Dim value As String()

    value = instance.DataKeyNames

    'ASPNET_MsgBox("The datakeynames(0) is  " & value(0) & "." & _
    '    "The datakeynames(1) is  " & value(1) & ".")
    'Message.Text = "The primary key value of the selected row is " & _
    '    GridView1.DataKeys(index).Value.ToString() & "."

    'ASPNET_MsgBox("The content(0) is  " & GridView1.DataKeys(0).Value & "." & _
    '    "The content(1) is  " & GridView1.DataKeys(1).Value & ".")

        ASPNET_MsgBox("Project: " & GridView1.DataKeys(0).Value)
        ASPNET_MsgBox("Period: " & instance.SelectedRow.Cells(1).Text())
    End Sub
End Class
