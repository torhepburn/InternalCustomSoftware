Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Configuration
Imports System.IO

'Imports ADODB


Public Class Main
    Dim bolContinue As Boolean = True
    Dim TNHconnect As String = "Server=MIDPRJ01;Database=TandH;User ID=views;" & _
           "Password=views;Trusted_Connection=False;"

    Private WithEvents dataGridView1 As New DataGridView()
    Private bindingSource1 As New BindingSource()

    'Public Sub New()

    '    Me.dataGridView1.Dock = DockStyle.Fill
    '    Me.Controls.Add(Me.dataGridView1)
    '    InitializeDataGridView()

    'End Sub
    Private Sub InitializeDataGridView()
        Dim tsql As String
        Try
            ' Set up the DataGridView.
            tsql = "Select IP," & _
                        "Location," & _
                        "Read_Location as WhereRead," & _
                        "Read_Interval_Mins," & _
                        "Last_Read_Time," & _
                        "Temp_CorF," & _
                        "Active," & _
                        "Temp_HI_Limit," & _
                        "Temp_LOW_Limit," & _
                        "RH_HI_Limit," & _
                        "RH_HI_Limit," & _
                        "Email_Alert_Address1," & _
                        "Email_Alert_Address2," & _
                        "Email_Alert_Address3," & _
                        "Email_Alert_Address4," & _
                        "Email_Alert_Address5," & _
                        "Email_Alert_Address6," & _
                        "Email_Alert_Address7," & _
                        "MonitorType" & _
                        " from lup_Readings ORDER BY IP DESC;"
            'tsql = "Select * from lup_Readings;"
            With Me.DataGridView2
                ' Automatically generate the DataGridView columns.
                .AutoGenerateColumns = True

                ' Set up the data source.
                bindingSource1.DataSource = GetControlData(tsql)
                .DataSource = bindingSource1

                ' Automatically resize the visible rows.
                .AutoSizeRowsMode = _
                    DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

                ' Set the DataGridView control's border.
                .BorderStyle = BorderStyle.Fixed3D

                ' Put the cells in edit mode when user enters them.
                .EditMode = DataGridViewEditMode.EditOnEnter
            End With
        Catch ex As SqlException
            'MessageBox.Show("To run this sample replace " _
            '    & "connection.ConnectionString with a valid connection string" _
            '    & "  to a Northwind database accessible to your system.", _
            '    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'System.Threading.Thread.CurrentThread.Abort()
        End Try
    End Sub
    Private Sub WriteData(ByVal p_IP As String, ByVal p_Temp As String, ByVal p_Hum As String, _
                                                ByVal p_Error As String, ByVal p_Attempts As Int16, _
                                                ByVal p_monitorType As String, _
                                                ByVal p_ThermoWorksTime As String)

        'pmonitorType is either ThermoWorks or Newport
        '   need this because for ThermoWorks there is a time of reading that needs to be picked up
        '   from a file that could be an old file
        'Dim cn As New ADODB.Connection
        'Dim sqlcommand As New ADODB.Command
        Dim sqlString As String
        Dim strDate As String
        ''Update the dataTable here by putting the new reading in
        ''Write an Update Trigger to update lup_Readings.Last_Read_Time

        'With cn
        '    .ConnectionString = "Provider=SQLOLEDB;" & _
        '            "Data Source=" & "MIDPRJ01" & "; " & _
        '            "Initial Catalog=TandH;" & _
        '            "User ID=views; Password=views;"
        '    ' Trusted_Connection=yes
        '    .Open()
        If p_monitorType = "Newport" Then
            strDate = Now()
        ElseIf p_monitorType = "ThermoWorks" Then
            strDate = p_ThermoWorksTime
        Else
            strDate = Now()
        End If
        sqlString = "INSERT INTO tbl_Readings_" & Replace(p_IP, ".", "_") & " ( " & _
                                                        "DteTime, " & _
                                                        "TempF, " & _
                                                        "RH, " & _
                                                        "WriteTry, " & _
                                                        "Error" & _
                                                        ") " & _
                                            "VALUES (" & _
                                                         "CONVERT(DATETIME, '" & strDate & "', 102)," & _
                                                         p_Temp & "," & _
                                                         p_Hum & "," & _
                                                         p_Attempts & "," & _
                                                         p_Error & _
                                            ")"


        If p_IP = "128.1.9.223" Then
            sqlString = "INSERT INTO tbl_Readings_" & Replace(p_IP, ".", "_") & " ( " & _
                                                            "DteTime, " & _
                                                            "Temp1F, " & _
                                                            "Temp2F, " & _
                                                            "WriteTry, " & _
                                                            "Error" & _
                                                            ") " & _
                                                "VALUES (" & _
                                                             "CONVERT(DATETIME, '" & strDate & "', 102)," & _
                                                             p_Temp & "," & _
                                                             p_Hum & "," & _
                                                             p_Attempts & "," & _
                                                             p_Error & _
                                                ")"
        End If

        If p_IP = "128.1.9.224" Then
            sqlString = "INSERT INTO tbl_Readings_" & Replace(p_IP, ".", "_") & " ( " & _
                                                            "DteTime, " & _
                                                            "Temp1F, " & _
                                                            "Temp2F, " & _
                                                            "WriteTry, " & _
                                                            "Error" & _
                                                            ") " & _
                                                "VALUES (" & _
                                                             "CONVERT(DATETIME, '" & strDate & "', 102)," & _
                                                             p_Temp & "," & _
                                                             p_Hum & "," & _
                                                             p_Attempts & "," & _
                                                             p_Error & _
                                                ")"
        End If


        Dim connectionString As String = "Data Source=MIDPRJ01;Initial Catalog=TandH;Uid=views;Pwd=views"
        Dim connection As SqlConnection = New SqlConnection(connectionString)
        connection.Open()

        Dim command As New SqlCommand()
        command.Connection = connection

        command.CommandText = sqlString
        command.CommandType = Data.CommandType.Text
        Dim retValue As Object = command.ExecuteScalar()


    End Sub

    Private Shared Function GetControlData(ByVal sqlCommand As String) _
        As DataTable

        'Dim connectionString As String = _
        '"Server=MIDPRJ01;Database=TandH;User ID=views;" & _
        '   "Password=views;Trusted_Connection=False;"

        Dim TandHConnection As SqlConnection = _
            New SqlConnection(TnHMonitor.Main.TNHconnect)

        Dim command As New SqlCommand(sqlCommand, TandHConnection)
        Dim adapter As SqlDataAdapter = New SqlDataAdapter()
        adapter.SelectCommand = command

        Dim table As New DataTable
        table.Locale = System.Globalization.CultureInfo.InvariantCulture
        adapter.Fill(table)

        Return table

    End Function
    Private Sub TimedProcess()
        Dim i As Integer
        Dim IP As String, Temp_CorF As String, bolActive As Boolean, Read_Location As String
        Dim dteLastRead As DateTime, dblReadInterval As Double
        Dim monitorType As String
        Dim P As New Process
        Dim strOutput_Temp As String, intAttemptsTemp As Integer
        Dim strOutput_Hum As String, intAttemptsHum As Integer
        Dim intMaxAttempts As Integer = 3
        Dim strError As String
        Dim bolFirst As Boolean = True
        Dim strThermoWorksFileName As String
        Dim strThermoWorksTime As String
        Try
            Me.txtTime.Text = Now()
            For i = 0 To (DataGridView2.Rows.Count - 1)
                IP = DataGridView2.Item(0, i).Value
                Read_Location = DataGridView2.Item(2, i).Value
                Temp_CorF = DataGridView2.Item(5, i).Value
                bolActive = DataGridView2.Item(6, i).Value
                'Last Read time on this monitor
                dteLastRead = DataGridView2.Item(4, i).Value
                'Minute interval for this monitor
                dblReadInterval = DataGridView2.Item(3, i).Value
                monitorType = DataGridView2.Item(18, i).Value
                'If (IP <> "" And bolActive And Read_Location = Me.cbRead_Location.SelectedValue And 1 = 2) Or monitorType = "ThermoWorks" Then
                If (IP <> "" And bolActive And Read_Location = Me.cbRead_Location.SelectedValue) Then


                    intAttemptsTemp = 0
                    intAttemptsHum = 0
                    strOutput_Hum = ""
                    strOutput_Temp = ""
                    strThermoWorksTime = ""
                    strThermoWorksFileName = "c:\TnH\" & Replace(IP, ".", "-") & ".txt"

                    'ONLY READ if is time
                    'Prev way: MINUTES, doesn't seem to get parts of minute
                    'If DateAdd(DateInterval.Minute, dblReadInterval, dteLastRead) < Now() Then
                    If DateAdd(DateInterval.Second, dblReadInterval * 60, dteLastRead) < Now() Then
                        'MsgBox(IP)
                        ' Start the child process. 
                        'Process(p = New Process())
                        ' Redirect the output stream of the child process. 
                        If bolFirst Then
                            bolFirst = False
                            P.StartInfo.UseShellExecute = False
                            P.StartInfo.RedirectStandardOutput = True
                            If monitorType = "Newport" Then
                                P.StartInfo.FileName = "C:\Program Files\Newport\iLOG\httpget.exe"
                            ElseIf monitorType = "ThermoWorks" Then
                                P.StartInfo.FileName = "ftp"
                            End If
                            P.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                            'P.StartInfo.CreateNoWindow = True
                        End If

                        'p.Arguments = "a -tgzip """ & targetName & """ """ & sourceName & """ -mx=9"
                        'httpget -r -S “*SRT\r” 128.7.0.21:1000
                        'httpget -r -S “*SRH\r” 128.7.0.21:1000

                        'prev way: takes default network timeout, which seems to be pretty long
                        'P.StartInfo.Arguments = "-r -S  """ & "*SRTF\r" & """ """ & IP & ":1000"
                        '-t3 should be 3 secs, or should it be -t 3?

                        If monitorType = "Newport" Then
                            If Temp_CorF = "F" Then
                                P.StartInfo.Arguments = "-r -t3 -S  """ & "*SRTF\r" & """ """ & IP & ":1000"
                            Else
                                P.StartInfo.Arguments = "-r -t3 -S  """ & "*SRTC\r" & """ """ & IP & ":1000"
                            End If
                        ElseIf monitorType = "ThermoWorks" Then
                            'P.StartInfo.Arguments = "-v -s:\\zygocorp\Departments\Information_Technology\Ben\TnH\ThermoRecorder\" & IP & ".txt"
                            'NO MESSAGES in ftp screen: P.StartInfo.Arguments = "-v -s:c:\TnH\" & IP.Replace(".", "_") & "_FTP_Script.txt"
                            'DEBUG MODE:
                            P.StartInfo.Arguments = "-d -s:c:\TnH\" & IP.Replace(".", "_") & "_FTP_Script.txt"
                        End If
tryAgainTEMP:
                        P.Start()
                        ' Do not wait for the child process to exit before 
                        ' reading to the end of its redirected stream. 
                        ' p.WaitForExit(); 
                        ' Read the output stream first and then wait. 
                        'the idea here is to stop the process if it hasn't responded quick enough
                        'will call the process again (3 times)
                        strOutput_Temp = P.StandardOutput.ReadToEnd()
                        P.WaitForExit(100)           'new 09/27/2010 because ftp hung twice used to be (50)
                        If Not P.HasExited Then
                            P.CloseMainWindow()
                            P.WaitForExit(500)      'new 09/27/2010 because ftp hung twice used to be ()
                            If Not P.HasExited Then
                                P.Kill()
                                P.WaitForExit(500)  'new 09/27/2010 because ftp hung twice used to be ()
                            End If
                        End If
                        'MsgBox(IP & "Temp:   " & strOutput_Temp)

                        'if THERMOWORKS, the READ a file and get the humidity and temperature from there
                        If monitorType = "ThermoWorks" Then
                            If Not readThermoWorksFile(strThermoWorksFileName, strOutput_Temp, strOutput_Hum, strThermoWorksTime) Then
                                strOutput_Temp = ""
                            End If
                        End If


                        If strOutput_Temp = "" And intAttemptsTemp < intMaxAttempts Then
                            intAttemptsTemp = intAttemptsTemp + 1
                            'System.Threading.Thread.Sleep(100) '30 seconds, 30 * 1000 milliseconds
                            GoTo tryAgainTEMP
                        End If

                        'ONLY get the HUMIDITY in a separate call for NEWPORT, not THERMOWORKS
                        'prev way: takes default network timeout, which seems to be pretty long
                        'P.StartInfo.Arguments = "-r -S  """ & "*SRH\r" & """ """ & IP & ":1000"
                        '-t3 should be 3 secs, or should it be -t 3?
                        If monitorType = "Newport" Then
                            P.StartInfo.Arguments = "-r -t3 -S  """ & "*SRH\r" & """ """ & IP & ":1000"
tryAgainHUM:
                            P.Start()
                            ' Do not wait for the child process to exit before 
                            ' reading to the end of its redirected stream. 
                            ' p.WaitForExit(); 
                            ' Read the output stream first and then wait. 
                            strOutput_Hum = P.StandardOutput.ReadToEnd()
                            P.WaitForExit(50)
                            If Not P.HasExited Then
                                P.CloseMainWindow()
                                P.WaitForExit()
                                If Not P.HasExited Then
                                    P.Kill()
                                    P.WaitForExit()
                                End If
                            End If
                            'MsgBox(IP & "Hum:   " & strOutput_Hum)
                            If strOutput_Hum = "" And intAttemptsHum < intMaxAttempts Then
                                intAttemptsHum = intAttemptsHum + 1
                                'System.Threading.Thread.Sleep(100) '30 seconds, 30 * 1000 milliseconds
                                GoTo tryAgainHUM
                            End If
                        End If


                        strError = "0"
                        'IF temp not numeric or =32, or 0C, then there was an error
                        'THIS IS ONLY FOR NEWPORT monitors, THERMOWORKS does not fudge 32 and 0
                        If monitorType = "Newport" Then
                            If IsNumeric(strOutput_Temp) Then
                                If CInt(strOutput_Temp) = 32 Or CInt(strOutput_Temp) = 0 Then
                                    strError = "-1"
                                End If
                            Else
                                strError = "-1"
                            End If
                        ElseIf strOutput_Temp = "" Then
                            'THERMOWORKS will not give a value if it failed to read
                            strError = "-1"
                        End If

                        'IF temp not numeric or =32, or 0C, then there was an error
                        If IsNumeric(strOutput_Hum) Then
                            If CInt(strOutput_Hum) = 0 Then
                                strError = "-1"
                            End If
                        Else
                            strError = "-1"
                        End If

                        WriteData(IP, strOutput_Temp, strOutput_Hum, strError, intAttemptsHum + intAttemptsTemp, _
                            monitorType, strThermoWorksTime)
                        Me.txtLastIP.Text = IP
                        Me.txtTemp.Text = strOutput_Temp
                        Me.txtHum.Text = strOutput_Hum

                    End If
                End If
                'Moved from outside the IP loop to inside, going to reinit the Process for each IP to read
                If Not bolFirst Then
                    'or should this be p.dispose?
                    P.Close()
                    bolFirst = True
                End If
            Next i

            'If Not bolFirst Then
            '    'or should this be p.dispose?
            '    P.Close()
            'End If

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click
        'Get data into grid

        If Me.cbRead_Location.SelectedValue = "" Then
            MsgBox("Must choose a location to read.", MsgBoxStyle.Critical, "Application Stopped.")
            Exit Sub
        End If

        If MsgBox("Read monitors in " & Me.cbRead_Location.SelectedValue & "?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Continue?") <> MsgBoxResult.Ok Then
            Exit Sub
        End If
        InitializeDataGridView()
        bolContinue = True
        While bolContinue
            Application.DoEvents()
            TimedProcess()
            InitializeDataGridView()

            'just continue if can't refresh
            Try
                Me.DataGridView2.Refresh()
                Me.Refresh()
            Catch ex As Exception
            End Try

            'Me.dataGridView1.Refresh()
            Application.DoEvents()
            System.Threading.Thread.Sleep(20000) '20 seconds, 30 * 1000 milliseconds
            Application.DoEvents()
            'MsgBox("Next")
            If Not bolContinue Then
                MsgBox("Data collection has terminated.")
            End If
        End While
    End Sub

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TandHDataSet.lup_Read_Locations' table. You can move, or remove it, as needed.
        Me.Lup_Read_LocationsTableAdapter.Fill(Me.TandHDataSet.lup_Read_Locations)

    End Sub

    Private Sub StopButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopButton.Click
        bolContinue = False
    End Sub
    Private Function readThermoWorksFile(ByVal pFileName As String, ByRef pTemp As String, ByRef pHum As String, ByRef pstrThermoWorksTime As String) As Boolean
        'Have to trx file from device to file because MS FTP does not have a way to print it to screen, we'd
        '   get that in the Process output.

        'read the file pFileName (like 128-1-9-219.txt 
        '   contents look like:
        '#1
        'MachineCode = 2            Irrelevant:Model type TR72, TR71 
        'Name=----                  Irrelevant
        'Time=08/11/2010 15:36'20   Need this, note the ' in the time before the seconds
        'Unit = 1                   Need this, 1 means Fahrenheit is what the user wants, 0 is Centigrade
        'cTemperature1 = 25.2       Need this, temp always given in centigrade
        'cHumidity = 47             Need this, hum
        'wState = 0                 Don't need this, 0=not out of spec, 1=temp out, 2=hum, 3=both out

        'Plan
        'see if file exists
        'if YES, open
        '   if NO, fail
        'LOOP:
        '   read a line
        '   split on = and trim
        '   if 1st part = TIME get time
        '   if 1st part = Unit then set C_or_F
        '   if 1st part = cTemperature1 then set pTemp, adjust if C_or_F='F'
        '   if 1st part = cHumidity then set pHum
        'END LOOP
        'CLOSE FILE
        'EXIT
        Dim bolRet As Boolean = True
        Dim strTEMP As String
        Dim strArray As String()
        Dim strLine As String
        Dim strParts As String()
        'Dim strPart As String
        Dim strC_or_F As String = "F"
        Try



            If System.IO.File.Exists(pFileName) = True Then

                '8/12/2010 NOTE: the time from the file is 1 hour behind actual time,
                '   even when I set it correctly the next day it returns to an hour late

                'NOTE THE CHANGE HERE, IF EVER FIX THE TIME IN THE FILE, THEN CHANGE THIS BACK
                Dim objFileInfo As New FileInfo(pFileName)
                pstrThermoWorksTime = objFileInfo.LastWriteTime

                Dim objReader As New System.IO.StreamReader(pFileName)
                strTEMP = objReader.ReadToEnd
                objReader.Close()
                strArray = Split(strTEMP, Chr(13) & Chr(10))
                For Each strLine In strArray
                    strParts = Split(strLine, "=")
                    'TRIM the parts - ALREADY DONE
                    'For Each strPart In strParts
                    '    strPart = strPart.Trim
                    'Next
                    If strParts.Length > 0 Then
                        Select Case strParts(0)
                            Case "Time"
                                'If can't get time, then fail and let another reading happen
                                '8/12/2010 NOTE: the time from the file is 1 hour behind actual time,
                                '   even when I set it correctly the next day it returns to an hour late
                                'pstrThermoWorksTime = strParts(1).Replace("'", ":")
                                If Not IsDate(pstrThermoWorksTime) Then

                                    bolRet = False
                                    GoTo exitFunction
                                End If
                            Case "Unit"
                                If strParts(1) = "0" Then
                                    strC_or_F = "C"
                                Else
                                    strC_or_F = "F"
                                End If
                            Case "cTemperature1"
                                pTemp = strParts(1)
                                'If can't get TEMP, then fail and let another reading happen
                                If Not IsNumeric(pTemp) Then
                                    bolRet = False
                                    GoTo exitFunction
                                End If
                                If strC_or_F = "F" Then
                                    pTemp = (pTemp * 1.8) + 32
                                End If
                            Case "cTemperature2"
                                'using humidity variable as it is not used when 2 temperatures
                                pHum = strParts(1)
                                'If can't get TEMP, then fail and let another reading happen
                                If Not IsNumeric(pHum) Then
                                    bolRet = False
                                    GoTo exitFunction
                                End If
                                If strC_or_F = "F" Then
                                    pHum = (pHum * 1.8) + 32
                                End If

                            Case "cHumidity"
                                pHum = strParts(1)
                                'If can't get HUM, then fail and let another reading happen
                                If Not IsNumeric(pHum) Then
                                    bolRet = False
                                    GoTo exitFunction
                                End If
                        End Select
                    End If
                Next

            Else
                'MsgBox("File Does Not Exist")
            End If
        Catch ex As Exception
            bolRet = False
        End Try
exitFunction:
        readThermoWorksFile = bolRet
    End Function
End Class
