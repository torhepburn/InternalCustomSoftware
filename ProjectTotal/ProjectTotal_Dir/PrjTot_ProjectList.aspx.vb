Imports System.Data.SqlClient

Partial Class ProjectTotal_Dir_PrjTot_ProjectList
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Me.textboxProjectLeader.Text <> "" Then
        '    Me.textboxProjectLeader.Text = "All"

        'End If
 '       Try
 '       Dim connectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("Projects_Info_TotalSQLConnection").ToString
 '       Dim connection As SqlConnection = New SqlConnection(connectionString)
 '       Dim cmd As New SqlCommand()
 '       cmd.Connection = connection
 '       cmd.CommandText = "usr_ProjectListing"
 '       cmd.CommandType = Data.CommandType.StoredProcedure
 '       cmd.Parameters.Add(New SqlParameter("Project_Status", Data.SqlDbType.Int))
 '       cmd.Parameters(0).Value = 0
 '       cmd.Parameters.Add(New SqlParameter("ProjectLeaderName", Data.SqlDbType.NVarChar, 35))
 '       cmd.Parameters(1).Value = ""

 '       'cmd.Parameters.AddWithValue("Project_Status", 0)
 '       'cmd.Parameters.AddWithValue("ProjectLeaderName", "")

 '       cmd.Connection.Open()

        'Dim myReader As SqlDataReader
        'myReader = cmd.ExecuteReader
        'While myReader.Read()
        '    Console.WriteLine(myReader.GetString(0))
        'End While
        'myReader.Close()

  '      GridView1.DataSource = cmd.ExecuteReader
  '      GridView1.DataBind()

  '     cmd.Connection.Close()
  '      cmd.Connection.Dispose()
  '      Catch ex As Exception
        'lblStatus.Text = ex.Message
  '  End Try
    End Sub
End Class
