<%@ Application Language="VB" %>

<script runat="server">

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup
        'WriteFile("Application Starting")
        Dim conn As New System.Data.SqlClient.SqlConnection
        Dim connectionString = System.Configuration.ConfigurationManager.ConnectionStrings("Projects_Info_TotalSQLConnection").ToString
        conn = New System.Data.SqlClient.SqlConnection(connectionString)
        conn.Open()
        
        Dim LastUpdateDate As Date
        Dim sqlComm As New System.Data.SqlClient.SqlCommand("SELECT LastUpdateDate FROM tabLastUpdate", conn)
        Dim r As System.Data.SqlClient.SqlDataReader = sqlComm.ExecuteReader()
        While r.Read()
            LastUpdateDate = r("LastUpdateDate")
        End While 
        r.Close()
        Application("LastUpdateDate") = LastUpdateDate
    End Sub
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
        'WriteFile("Application Ending")
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
        Dim conn As New System.Data.SqlClient.SqlConnection
        Dim connectionString = System.Configuration.ConfigurationManager.ConnectionStrings("Projects_Info_TotalSQLConnection").ToString
        conn = New System.Data.SqlClient.SqlConnection(connectionString)
        conn.Open()
        
        Dim LastUpdateDate As Date
        Dim sqlComm As New System.Data.SqlClient.SqlCommand("SELECT LastUpdateDate FROM tabLastUpdate", conn)
        Dim r As System.Data.SqlClient.SqlDataReader = sqlComm.ExecuteReader()
        While r.Read()
            LastUpdateDate = r("LastUpdateDate")
        End While
        r.Close()
        Application("LastUpdateDate") = LastUpdateDate
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
    End Sub
    Sub WriteFile(ByVal strText As String)
        Dim writer As System.IO.StreamWriter = New System.IO.StreamWriter("C:\\ProjectTotal\\test.txt", True)
        Dim str As String
        str = DateTime.Now.ToString() & " " & strText
        writer.WriteLine(str)
        writer.Close()
    End Sub
       
</script>