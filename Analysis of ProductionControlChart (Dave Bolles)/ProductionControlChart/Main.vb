Imports System.Xml
Imports Microsoft.Office.Interop.Excel
Imports System.IO


Public Class Main

    Private myExcel As Microsoft.Office.Interop.Excel.Application
    Private myExcelPID As Integer
    Private myDataSet As DataSet
    Private strInputSN As String = "n/a"
    Private strTextMessage As String = ""
    Private bolGlobalError As Boolean = False
    Private gstrImportFileName As String = ""

    'MINITAB variables

    Private gArrMinitabTemplateFile(,) As String
    '   array of template files
    Private gArrXML_Variables(,) As String
    '   array of XML_Variables entries - (6,x) - FIRST LINE IS JUST HEADER INFO
    '   sample : Variable_Name|Type|XML_NODE|XML_ATTRIBUTE|
    '   Regex_Match|Regex_Replace|Value

    Private gArrXML_Mappings(,) As String
    '   array of XML_Mappings entries - (10,x) - FIRST LINE IS JUST HEADER INFO
    '   sample :XML_NODE|XML_ATTRIBUTE|TARGET_SHEET|TARGET_CELL|TARGET_COLKey1|
    '   TARGET_COLKey1_Value|TARGET_COLKey2|TARGET_COLKey2_Value|Value|Moved|
    '   DisplayToUser (TRUE)

    Private gArrValidations(,) As String
    'array of validation entries - (3,x) sample : String|SN|=|7151655

    Private gstrMinitabTemplateFile As String = ""
    '   gSet_MinitabRootDir & "\MTBTemplate.mtb"

    Private gstrImportFileNamePiece As String = ""
    '   actual file name, stripped of .xml and .'s

    Private gstrMintabWorkingDir As String = ""
    '   the actual directory for the minitab graphs of specific file
    '   set when file is picked to import

    Private gBolMintabWorkingDirExists As Boolean = False
    '   whether current working directory exists

    Private files() As FileInfo
    '   list of xml files in directory, if want to import a directory

    Const strXMLFail As String = "~Not in XML File~"


    Public Class clsCompareFileInfo

        Implements IComparer


        Public Function Compare(ByVal x As Object, ByVal y As Object) _
            As Integer Implements IComparer.Compare

            Dim File1 As FileInfo
            Dim File2 As FileInfo

            File1 = DirectCast(x, FileInfo)
            File2 = DirectCast(y, FileInfo)

            Compare = String.Compare(File1.Name, File2.Name)

        End Function

    End Class


    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
           Handles MyBase.Load


        Dim j As Integer = 0
        Dim i As Integer = 0
        Dim btn As System.Windows.Forms.Button
        For j = 1 To 3
            For i = 1 To 15
                btn = Me.Controls("TabControl1").Controls("Set" & Format(j, "0")) _
                    .Controls("cmdMinitabGraphS" & Format(j, "0") & Format(i, "00"))
                AddHandler btn.Click, AddressOf DisplayJPG
            Next i
        Next j

        'If IO.File.Exists(My.Settings.ControlFile) Then
        '    Me.txtControlDirName.Text = My.Settings.ControlFile
        'Else
        Me.cmdOpenChart.Enabled = False
        Me.cmdMiniTab_Admin.Enabled = False
        Me.txtFileName.Enabled = False
        Me.txtDirName.Enabled = False

        'End If

        '    End Sub
        '   Private Sub Button1_Click_1(ByVal sender As System.Object, _
        'ByVal e As System.EventArgs) _
        '     Handles cmdGetControl.Click

        'Specify Settings button

        'gives values to the global settings file name and the
        'global settings directory name

        Me.txtFileName.Text = ""
        Me.txtControlDirName.Text = ""

        With OpenFileDialog1

            ''With statement is used to execute statements using a particular object _
            ''rather than saying OpenFileDialog1.Reset() or OpenFileDialog1.Filter

            '.Reset()

            ''Initial Directory will not work for UNC paths.
            ''Could set the registry before .showdialog, but don't want to
            ''The open dialog will remember the last file you opened anyway, so only out
            ''the initial set

            '.RestoreDirectory = False
            '.InitialDirectory = "\\zygocorp\departments\PPS\Manuf_Test\" & _
            '                    "Minitab-ControlFiles"
            '.Title = "Choose Settings File"
            '.Filter = "Settings File (Settings.txt)|Settings.txt"

            ''set filter so that only settings.txt files will show up in the dialog box

            'If .ShowDialog() = DialogResult.OK Then

            '    'showDialog method makes the dialog box visible at run time
            '    'OpenFileDialog1.FileName returns the selected file

            '    .InitialDirectory = "\\zygocorp\departments\PPS\Manuf_Test\" & _
            '                        "Minitab-ControlFiles"
            'Me.txtControlDirName.Text = .FileName
            'My.Settings.ControlFile = .FileName
            'tmh temp gSetSettingsFileName = .FileName
            gSetSettingsFileName = "\\zygocorp\departments\PPS\Manuf_Test\" & _
                                "Minitab-ControlFiles\mc4104\settings.txt"
            gSetSettingsDirName = zGetDirFromFileName(gSetSettingsFileName)

            If Not processTxtControlFile(gSetSettingsFileName) Then
                'If Not processTxtControlFile(Me.txtControlDirName.Text.ToString) Then

                'send txtControlDirName to be processed - if not available then
                'buttons are not enabled

                Me.cmdGetFile.Enabled = False
                Me.cmdGetDir.Enabled = False
            Else
                Me.cmdGetFile.Enabled = True
                Me.cmdGetFile.ForeColor = Color.Red
                Me.cmdGetDir.Enabled = True
                Me.cmdGetDir.ForeColor = Color.Red
                Me.cmdGetControl.Enabled = False

            End If
            ' Else
            'Me.cmdOpenChart.Enabled = False
            'Me.cmdChartFile.Enabled = False
            'Me.cmdGetFile.Enabled = False
            'Me.cmdGetDir.Enabled = False
            'End If
        End With
    End Sub

    ''Private Sub Button1_Click(ByVal sender As System.Object, _
    ''    ByVal e As System.EventArgs) Handles cmdGetFile.Click

    ''Specify Test File button

    ''get the validations - putting here so can refresh if people have problems 
    ''without having to tell them to close
    ''validations are in minitab root 

    ''Me.txtDirName.Text = ""

    '    Call get_ValidationFile()
    '    Call get_EmailFile()

    ''If either of these 2 fail, then we have major problems and should quit

    '    If Not get_XML_Variables() Then 'XML_Variables.txt
    '        MsgBox("Failed to bring in Variables file.")
    '        Exit Sub
    '    End If

    '    If Not get_XML_Mappings() Then 'XML_Mappings.txt
    '        MsgBox("Failed to bring in Mappings file.")
    '        Exit Sub
    '    End If


    '    With OpenFileDialog1

    ''With statement is used to execute statements using a particular object, here,
    ''OpenFileDialog1

    '        .Reset()
    '        .RestoreDirectory = False
    '        .InitialDirectory = gSet_XMLInputDir
    '        .Title = "Choose XML File to Import"
    '        .Filter = "XML files (*.xml)|*.xml|" & "All files|*.*"

    ''If .ShowDialog() = DialogResult.OK Then

    ''showDialog method makes the dialog box visible at run time
    ''OpenFileDialog1.FileName returns the selected file

    '        gSetFolderImport = False
    '        gSetFileImport = True
    ''Me.txtFileName.Text = .FileName
    ''gstrImportFileName = .FileName
    '        gstrImportFileName = "\\ZMI-Test-2\ITS Data\Test Results\ZMI 4104\ " & _
    '            "07382437\CE.07382437.ZMI-test-2.00134.xml"
    '        Me.txtFileName.Text = gstrImportFileName
    ''New for Directory processor - put the 1 file into same array as dir 
    ''processor()

    '        ReDim files(0)
    '        files(0) = New FileInfo(gstrImportFileName)
    ''files(0) = New FileInfo(.FileName)
    '        Me.cmdChartFile.Enabled = True
    '        Me.txtOutput.Text = ""
    '        Me.txtResults.Text = ""
    '        gSN = Me.txtFileName.Text.Replace(".xml", "")

    '        Call setGraphButtons()

    ''End If
    '    End With

    'End Sub



    ''tmh copied to places where it was used and commented out 5-18-11

    ''Private Sub CallProcess_with_Parms(ByVal path As String, ByVal parms As String,_
    '' ByVal pBolWait As Boolean)
    ''    Dim psInfo As New System.Diagnostics.ProcessStartInfo(path)
    ''    Dim p As New System.Diagnostics.Process
    ''    p.StartInfo.FileName = path
    ''    p.StartInfo.WindowStyle = ProcessWindowStyle.Minimized
    ''    p.StartInfo.Arguments = parms
    ''    p.Start()

    ''    'Wait until the process passes back an exit code 
    ''    If pBolWait Then
    ''        p.WaitForExit()
    ''    End If

    ''    'Free resources associated with this process
    ''    p.Close()
    ''End Sub
    Private Function pokeExcelData(ByVal aWorkSheet As Microsoft.Office.Interop.Excel.Worksheet, _
                                ByVal strInputSN As String, ByVal strSNKEY_ExcelCol As String, _
                                ByVal strStartDate As String, ByVal strDateKEY_ExcelCol As String, _
                                ByVal strActualValue As String, ByVal strValue_ExcelCol As String) As String


        'NOTE: if strValueNode = "Keys" then only put in the Key fields, SN and Date, NO value to put in
        Dim txt As String = ""
        Dim aRange As Microsoft.Office.Interop.Excel.Range
        Dim aDateRange As Microsoft.Office.Interop.Excel.Range


        Dim i As Int16 = 1

        Dim strRangeString As String = "A1"
        Dim strRangeDate As String = "A1"

        If strActualValue <> strXMLFail Then
            '********************************************
            '*********   4 -- Poke in data   ************
            '********************************************
            '   find first open row in column A, put SN into it, strInputSN
            'BBS: change this to put data in sorted
            '   by Test Date - this is hard-coded for now
            '   If hit a blank row, put data in there
            '   if hit a row where xls.testdate > input.test, insert row and put in keys 
            While i < 65000

                strRangeDate = strDateKEY_ExcelCol & i.ToString.Trim
                aDateRange = aWorkSheet.Range(strRangeDate)
                strRangeString = strSNKEY_ExcelCol & i.ToString.Trim
                aRange = aWorkSheet.Range(strRangeString)

                If IsNothing(aRange.Value) Then
                    aRange.Value = strInputSN

                    'StartDate goes here
                    strRangeString = strDateKEY_ExcelCol & i.ToString.Trim
                    aRange = aWorkSheet.Range(strRangeString)
                    aRange.ClearContents()
                    aRange.Value = strStartDate

                    'Channel 08 goes here - ActualValue
                    If strActualValue <> "Keys" Then
                        strRangeString = strValue_ExcelCol & i.ToString.Trim
                        aRange = aWorkSheet.Range(strRangeString)
                        aRange.ClearContents()
                        aRange.Value = strActualValue
                    End If
                    Exit While

                    'Check to see if this entry has already been processed
                    'SN (col A) at "//Tests/BoardInfo" attribute SN
                    'Test Date (col G) at "//Tests/Test[@name='AD'] attribute Start
                ElseIf strInputSN = aRange.Value Then

                    'strRangeString = "G" & i.ToString.Trim
                    strRangeString = strDateKEY_ExcelCol & i.ToString.Trim
                    aRange = aWorkSheet.Range(strRangeString)
                    If strStartDate = aRange.Value Then
                        If strActualValue <> "Keys" Then
                            'Row already added, so just update the row and quit
                            'Channel 08 goes here - ActualValue
                            strRangeString = strValue_ExcelCol & i.ToString.Trim
                            aRange = aWorkSheet.Range(strRangeString)
                            aRange.ClearContents()
                            aRange.Value = strActualValue.Trim
                        End If
                        GoTo alreadyDone
                    End If
                ElseIf IsDate(aDateRange.Value) Then
                    'Gone too far into the spreadsheet, 
                    '   insert a row and start inputting data
                    If aDateRange.Value > CDate(strStartDate) Then
                        aDateRange.EntireRow.Insert()

                        strRangeString = strSNKEY_ExcelCol & i.ToString.Trim
                        aRange = aWorkSheet.Range(strRangeString)
                        aRange.Value = strInputSN

                        'StartDate goes here
                        strRangeString = strDateKEY_ExcelCol & i.ToString.Trim
                        aRange = aWorkSheet.Range(strRangeString)
                        aRange.Value = strStartDate

                        'Channel 08 goes here - ActualValue
                        If strActualValue <> "Keys" Then
                            strRangeString = strValue_ExcelCol & i.ToString.Trim
                            aRange = aWorkSheet.Range(strRangeString)
                            aRange.ClearContents()
                            aRange.Value = strActualValue
                        End If
                        Exit While

                    End If
                End If
                i = i + 1
            End While
        Else

        End If

alreadyDone:
        strTextMessage = strTextMessage & vbCrLf & "To Excel: " & strActualValue ' & ": " & strActualValue
        strTextMessage = strTextMessage & vbCrLf & "----------------------"
        pokeExcelData = txt
    End Function

    Private Function getXmlData(ByVal xml_doc As Xml.XmlDocument, _
                                ByVal strValueNode As String, _
                                ByVal strValueAttribute As String) As String

        Dim txt As String = ""
        Dim oxmlnode As XmlNode
        Dim i As Int16 = 1

        'Value
        Dim strActualValue As String = ""

        Try
            'oxmlnode = xml_doc.SelectSingleNode("//Tests/Test[@name='AD']/ADCChannel[@channel='08']")
            oxmlnode = xml_doc.SelectSingleNode(strValueNode)
            'txt = txt & vbCrLf & "description: " & oxmlnode.Attributes.GetNamedItem("description").Value
            'strActualValue = oxmlnode.Attributes.GetNamedItem("value").Value
            If strValueAttribute = "" Then
                strActualValue = oxmlnode.InnerText
            Else
                strActualValue = oxmlnode.Attributes.GetNamedItem(strValueAttribute).Value
            End If
        Catch ex As Exception
            txt = "XML Node not found: " & strValueNode
            strActualValue = strXMLFail
            bolGlobalError = True
            'MsgBox(ex.Message)
        End Try

        strTextMessage = strTextMessage & vbCrLf & "From XML: " & strValueNode & ": " & strValueAttribute & ": Value--> " & strActualValue ' & ": " & strActualValue
        txt = strValueNode & ": " & strActualValue

        getXmlData = strActualValue
    End Function

    Private Function miniTab_MakeGraphs()

        Dim pstrExcelFile As String
        pstrExcelFile = "C:\ITS Data\Test Results\Export\4104 Daily Charts.xls"

        'RETURNS TRUE if minitab should be run to make the graphs

        'pstrMintabDir is the minitab  directory for the graphs
        'pstrExcelFile is the excel file to read

        'RETURNS THE NAME OF THE MTB file to execute, or blank --> strMTBFileName

        'NEWDIR = 
        '   PARTIAL DIRECTORY: in global variable
        '       UNDER 
        '       \\zygocorp\Departments\PPS\Manuf_Test\New_4000_Test_Station...
        '                               \Control Charts\MCerts\MiniTab\
        '1) See if directory for minitab graphs is there, if so, then quit, DO NOT OVERWRITE
        '2)     if NOT, then MAKE directory

        '3) Make a file called OUTPUT MTB_global variable.mtb
        '       from the INPUT file \\zygocorp\Departments\PPS\Manuf_Test\New_4000_Test_Station...
        '                               \Control Charts\MCerts\MiniTab\MTBTemplate.mtb
        '   HOW: read in each line from INPUT file WRITING the OUTPUT file CHANGING:
        '       a) FIRST LINE:
        '           FROM:   WOpen "c:\Minitab\4004 Daily Charts.xls";
        '           TO  :   WOpen & chr(34) & Me.txtFileName.Text & chr(34) & ";"   
        '       b) EVERY OTHER LINE (THAN FIRST)
        '           FROM:   GSAVE "C:\Minitab\IChartSetPower_1_Ax1";
        '           TO  :   GSAVE NEWDIR & "\IChartSetPower_1_Ax1";
        '4) EXECUTE THE mtb
        'Dim strMTBFileName As String = ""
        Dim bolRet As Boolean = False
        Dim strActualValue As String = ""
        Dim txt As String = ""
        Dim i As Integer
        Dim strInputFile As String = ""
        Dim strOututFile As String = ""
        Dim inputLine As String

        '****1) See if directory for minitab graphs is there, if so, then quit, DO NOT OVERWRITE
        '****2)     if NOT, then MAKE directory

        Try
            ReDim gArrMinitabTemplateFile(3, 0)
        Catch ex As Exception
            bolRet = False
            GoTo exitFunction
        End Try

        gstrMintabWorkingDir = "C:\ITS Data\Test Results\Export\Test"

        Try
            If Not IO.Directory.Exists(gstrMintabWorkingDir) Then
                IO.Directory.CreateDirectory(gstrMintabWorkingDir)
            Else
                'if directory is there then quit, assume graphs have been made
                txt = "MINITAB WORKING DIRECTORY ALREADY EXISTS, cannot overwrite: " & gstrMintabWorkingDir
                strActualValue = txt
                'bolGlobalError = True
                strTextMessage = vbCrLf & vbCrLf & strTextMessage & vbCrLf & txt
                txt = ""
                GoTo exitFunction
            End If
        Catch ex As Exception
            txt = "Minitab directory could not be made: " & gstrMintabWorkingDir
            strActualValue = txt
            bolGlobalError = True
            strTextMessage = vbCrLf & strTextMessage & vbCrLf & txt
            txt = ""
            bolRet = False
            GoTo exitFunction
        End Try

        '***3A) OPEN TEMPLATE FILES for reading
        Dim dirinfo As DirectoryInfo
        Dim allFiles() As FileInfo
        Dim iFileCounter As Integer = 0

        If IO.Directory.Exists(gSet_MinitabRootDir) Then

            dirinfo = New DirectoryInfo(gSet_MinitabRootDir)
            allFiles = dirinfo.GetFiles(gSet_MinitabTemplateFileSpec)
            Array.Sort(allFiles, New clsCompareFileInfo)
            For Each fl As FileInfo In allFiles
                iFileCounter = iFileCounter + 1
                If iFileCounter > 3 Then
                    MsgBox("Application can only handle 3 MTB files." & vbCrLf & vbCrLf & "Skipping the rest.", MsgBoxStyle.Critical, "Application Message")
                    GoTo tooManyMTBs
                End If
                ReDim Preserve gArrMinitabTemplateFile(3, iFileCounter - 1)

                gArrMinitabTemplateFile(0, iFileCounter - 1) = fl.Name.Replace("MTBTemplate", "").Replace(".mtb", "")
                gArrMinitabTemplateFile(1, iFileCounter - 1) = fl.FullName
                gArrMinitabTemplateFile(2, iFileCounter - 1) = gstrMintabWorkingDir & "\" & gArrMinitabTemplateFile(0, iFileCounter - 1)
                If Not IO.Directory.Exists(gArrMinitabTemplateFile(2, iFileCounter - 1)) Then
                    IO.Directory.CreateDirectory(gArrMinitabTemplateFile(2, iFileCounter - 1))
                    bolRet = True
                End If
                gArrMinitabTemplateFile(3, iFileCounter - 1) = gArrMinitabTemplateFile(2, iFileCounter - 1) & "\" & gstrImportFileNamePiece & "_" & gArrMinitabTemplateFile(0, iFileCounter - 1) & ".mtb"
                'myPic(iFileCounter).Image = System.Drawing.Bitmap.FromFile(fl.FullName)

            Next
        End If
tooManyMTBs:


        For i = 0 To UBound(gArrMinitabTemplateFile, 2)
            strInputFile = gArrMinitabTemplateFile(1, i)
            strOututFile = gArrMinitabTemplateFile(3, i)

            If Not IO.File.Exists(strInputFile) Then
                txt = "Minitab template file could not found: " & strInputFile
                strActualValue = txt
                bolGlobalError = True
                strTextMessage = vbCrLf & strTextMessage & vbCrLf & txt
                txt = ""
                bolRet = False
                GoTo exitFunction
            End If

            Dim inputFile As New System.IO.StreamReader(strInputFile)
            Try
                inputLine = inputFile.ReadLine()
            Catch ex As Exception
                txt = "Minitab template file could not be read: " & strInputFile
                strActualValue = txt
                bolGlobalError = True
                strTextMessage = vbCrLf & strTextMessage & vbCrLf & txt
                txt = ""
                bolRet = False
                GoTo exitFunction
            End Try

            '***3B) OPEN OUTP_UT FILE for writing
            strOututFile = strOututFile
            'strMTBFileName = gstrMintabWorkingDir & "\" & gstrImportFileNamePiece & ".mtb"
            Dim writerFile As New System.IO.StreamWriter(strOututFile)
            Try
                '1st line has to be disposed of anyway, it is the target spreadsheet
                writerFile.WriteLine("WOpen " & Chr(34) & pstrExcelFile & Chr(34) & ";")
            Catch ex As Exception
                txt = "Minitab template file could not find or write to: " & strOututFile
                strActualValue = txt
                bolGlobalError = True
                strTextMessage = vbCrLf & strTextMessage & vbCrLf & txt
                txt = ""
                strOututFile = ""
                bolRet = False
                GoTo exitFunction
            End Try

            '***3C read & write new file
            Do
                inputLine = inputFile.ReadLine()
                inputLine = Replace(inputLine, "C:\Minitab", gArrMinitabTemplateFile(2, i))
                writerFile.WriteLine(inputLine)

            Loop Until inputFile.Peek = -1

            inputFile.Close()
            writerFile.Close()
        Next
exitFunction:
        miniTab_MakeGraphs = bolRet
    End Function


    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles cmdGetFile.Click

        'Specify Test File button

        'get the validations - putting here so can refresh if people have problems 
        'without having to tell them to close
        'validations are in minitab root 

        Me.txtDirName.Text = ""

        Call get_ValidationFile()
        Call get_EmailFile()

        'If either of these 2 fail, then we have major problems and should quit

        If Not get_XML_Variables() Then 'XML_Variables.txt
            MsgBox("Failed to bring in Variables file.")
            Exit Sub
        End If

        If Not get_XML_Mappings() Then 'XML_Mappings.txt
            MsgBox("Failed to bring in Mappings file.")
            Exit Sub
        End If


        With OpenFileDialog1

            'With statement is used to execute statements using a particular object, here,
            'OpenFileDialog1

            .Reset()
            .RestoreDirectory = False
            .InitialDirectory = gSet_XMLInputDir
            .Title = "Choose XML File to Import"
            .Filter = "XML files (*.xml)|*.xml|" & "All files|*.*"

            If .ShowDialog() = DialogResult.OK Then

                'showDialog method makes the dialog box visible at run time
                'OpenFileDialog1.FileName returns the selected file

                gSetFolderImport = False
                gSetFileImport = True
                Me.txtFileName.Text = .FileName
                gstrImportFileName = .FileName

                'New for Directory processor - put the 1 file into same array as dir 
                'processor()

                ReDim files(0)
                files(0) = New FileInfo(.FileName)
                Me.cmdChartFile.Enabled = True
                Me.txtOutput.Text = ""
                Me.txtResults.Text = ""
                gSN = Me.txtFileName.Text.Replace(".xml", "")

                Call setGraphButtons()

            End If
        End With

    End Sub


    Private Function n_GetVariable(ByVal strVarName As String) As String
        Dim j As Integer = 0
        Dim strRet As String = ""
        For j = 1 To UBound(gArrXML_Variables, 2)

            If gArrXML_Variables(0, j) = strVarName Then
                strRet = gArrXML_Variables(6, j)
                GoTo exitFunction
            End If

        Next j
exitFunction:
        n_GetVariable = strRet
    End Function


    Private Sub cmdChartFile_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles cmdChartFile.Click

        '        'import to excel button

        '        'put in if fileexists 
        '        'Have no idea what this comment is referring to.

        Dim bolErrorMessage As Boolean

        '        'this comment is unclear as well:
        '        'If they just typed into the directory, take this into account
        '        '   the directory text will be not "", and the file text will be ""
        '        'THIS CODE is from the Get Dir button

        bolErrorMessage = True

        '        If Me.txtDirName.Text <> "" Then

        '            Me.txtFileName.Text = ""

        '            'if the text box Dir Name has some content then the text box File Name 
        '            'becomes blank.
        '            'looks like you specify either a file or a directory.

        '            Call get_ValidationFile()

        '            'doesn't seem to do anything if it is not a cert board as the 
        '            'validations.txt file is blank for production.

        '            Call get_EmailFile()

        '            'If either of these 2 fail, then we have major problems and should quit

        '            If Not get_XML_Variables() Then 'XML_Variables.txt
        '                MsgBox("Failed to bring in Variables file.")
        '                Exit Sub
        '            End If

        '            If Not get_XML_Mappings() Then 'XML_Mappings.txt
        '                MsgBox("Failed to bring in Mappings file.")
        '                Exit Sub
        '            End If
        '            Me.cmdChartFile.Enabled = True
        '            Me.txtOutput.Text = ""
        '            Me.txtResults.Text = ""
        '            gSetFolderImport = True
        '            gSetFileImport = False
        '            gSet_MinitabRun = False 'if folder import, no minitabs.
        '            'FIND OUT IF THEY WANT ERROR TRAP MESSAGE
        '            If MsgBox("Stop for errors?", MsgBoxStyle.YesNo, "User Entry") = _
        '                MsgBoxResult.No Then

        '                bolErrorMessage = False

        '            Else

        '                bolErrorMessage = True

        '            End If

        '            Dim extensions() As String = {"*.xml"}

        '            files = GetFilesByExtensions(Me.txtDirName.Text, extensions)

        '        End If

        '        tbStatus.Text = "Initializing..."
        '        Me.Refresh()

        '        ' Load the XML file.

        Dim xml_doc As New Xml.XmlDocument
        Dim bolWorkSheetOpen As Boolean = False
        Dim myExcel As Object = Nothing
        Dim aWorkbook As Microsoft.Office.Interop.Excel.Workbook
        Dim aWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim txt As String = ""
        Dim strExcelFile As String = ""
        Dim strWorkSheetName As String = ""
        Dim strTestResult As String = ""
        Dim bolTestResult As Boolean = True


        '        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor



        '        '********************************************
        '        '********* 1 -- Try to open excel ***********
        '        '********************************************
        '        Try
        '            myExcel = CreateObject("Excel.Application")
        '        Catch trouble As Exception
        '            strTextMessage = _
        '                "Could not open Excel application." & vbCrLf & vbCrLf & "Quitting."
        '            strTextMessage = _
        '                "FAILED TO MOVE ALL DATA FROM XML TO EXCEL." & vbCrLf & strTextMessage
        '            Me.txtOutput.Text = strTextMessage.Trim
        '            bolGlobalError = True
        '            Exit Sub
        '        End Try

        '        '********************************************
        '        '********* 2 -- See if workbook file exists *
        '        '********************************************


        '        'tmh 5-19-11 writing output to my machine
        '        strExcelFile = gSet_ExcelOutputFile
        '        'strExcelFile = "C:\a\Chart.xls"

        '        If Not IO.File.Exists(strExcelFile) Then
        '            'MsgBox("Cannot find excel file: " & strExcelFile, 
        '            '   MsgBoxStyle.Critical, "Application Message")
        '            strTextMessage = strTextMessage & vbCrLf & "Cannot find excel file: " _
        '                & strExcelFile & vbCrLf & vbCrLf & "Quitting."
        '            strTextMessage = "FAILED TO MOVE ANY DATA FROM XML TO EXCEL." _
        '                & vbCrLf & vbCrLf & strTextMessage
        '            Me.txtOutput.Text = strTextMessage.Trim
        '            bolGlobalError = True
        '            GoTo quitExcel
        '        End If

        '        '********************************************
        '        '********************************************
        '        '**********NEW METHOD FOLLOWS****************
        '        '********************************************
        '        '********************************************

        '        '********************************************
        '        '** 1) POPULATE VARIABLES IN  last column of
        '        '********************************************

        Dim i As Integer
        '        Dim iFileCounter As Integer


        '        For Each file As FileInfo In files
        '            iFileCounter = iFileCounter + 1
        '            Me.txtFileName.Text = file.FullName
        '            Me.tbFileStatus.Text = "#" & iFileCounter.ToString & " of " & _
        '                UBound(files) + 1 & ": " & file.FullName

        '            '*******Inits**********
        '            txt = ""

        '            strTestResult = ""
        '            bolTestResult = True
        '            strTextMessage = ""
        '            bolGlobalError = False

        '            xml_doc.Load(Me.txtFileName.Text)

        '            'RESET MAPPING AND VARIABLE ARRAYS - IN CASE DO MULTIPLE IMPORTS
        '            If Not get_XML_Variables() Then 'XML_Variables.txt
        '                MsgBox("Failed to bring in Variables file.")
        '            End If

        '            If Not get_XML_Mappings() Then 'XML_Mappings.txt
        '                MsgBox("Failed to bring in Mappings file.")
        '            End If

        '            For i = 1 To UBound(gArrXML_Variables, 2)
        '                gArrXML_Variables(6, i) = getXmlData(xml_doc, gArrXML_Variables(2, i), gArrXML_Variables(3, i))
        '                If gArrXML_Variables(4, i) <> "" Then
        '                    gArrXML_Variables(6, i) = System.Text.RegularExpressions.Regex.Match(gArrXML_Variables(6, i), gArrXML_Variables(4, i)).Value
        '                    If gArrXML_Variables(5, i) <> "" Then
        '                        gArrXML_Variables(6, i) = System.Text.RegularExpressions.Regex.Replace(gArrXML_Variables(6, i), gArrXML_Variables(5, i), "").ToString
        '                    End If
        '                    'This is only used now for ITERATION, change 0075 to 75 - VERY SLOPPY!
        '                    If IsNumeric(gArrXML_Variables(6, i)) Then
        '                        gArrXML_Variables(6, i) = CDbl(gArrXML_Variables(6, i))
        '                    End If
        '                End If
        '                'IF COULD NOT FIND ANY VARIABLE VALUE, THEN QUIT
        '                If gArrXML_Variables(6, i) = strXMLFail Then
        '                    MsgBox("XML Key field '" & gArrXML_Variables(0, i) & "' value (" & gArrXML_Variables(6, i) & ") could not be found. Quitting.", MsgBoxStyle.Critical)
        '                    bolGlobalError = True
        '                    GoTo cleanUp
        '                End If
        '            Next

        '            '********************************************
        '            '** 2) PERFORM VALIDATIONS
        '            '********************************************
        '            For i = 1 To UBound(gArrXML_Variables, 2)

        '                If Not set_Validate(gArrXML_Variables(0, i), gArrXML_Variables(6, i)) Then
        '                    MsgBox("XML Key field '" & gArrXML_Variables(0, i) & "' value (" & gArrXML_Variables(6, i) & ") did not validate. Quitting.", MsgBoxStyle.Critical)
        '                    strTextMessage = strTextMessage & vbCrLf & vbCrLf & vbCrLf & "XML Key field '" & gArrXML_Variables(0, i) & "' value (" & gArrXML_Variables(6, i) & ") did not validate." & vbCrLf & vbCrLf & "Quitting."

        '                    bolGlobalError = True
        '                    GoTo cleanUp
        '                End If
        '            Next

        '            '********************************************
        '            '** 3) UPDATE THE MAPPINGS FILE - sample is below
        '            '******* a) match & replace TARGET_COLKey1_Value against VARIABLE array
        '            '******* b) match & replace TARGET_COLKey2_Value against VARIABLE array
        '            '******* c) match & replace XML_NODE against VARIABLE array and put in VALUE column
        '            '********************************************

        '            '*************** MAPPINGS ARRAY*****************
        '            'XML_NODE                                          |XML_ATTRIBUTE|TARGET_SHEET|TARGET_CELL|TARGET_COLKey1|TARGET_COLKey1_Value|TARGET_COLKey2|TARGET_COLKey2_Value|Value|Moved|DisplayToUser
        '            '~KEYS~                                            |             |AD-4004     |A          |A             |~SN~                |G             |~START_AD~          |     |     |
        '            '~Rev~                                             |             |AD-4004     |B          |A             |~SN~                |G             |~START_AD~          |     |     |
        '            '~BoardType~                                       |             |AD-4004     |C          |A             |~SN~                |G             |~START_AD~          |     |     |
        '            '~Build~                                           |             |AD-4004     |D          |A             |~SN~                |G             |~START_AD~          |     |     |
        '            '~TestStation~                                     |             |AD-4004     |E          |A             |~SN~                |G             |~START_AD~          |     |     |
        '            '~Iteration~                                       |             |AD-4004     |F          |A             |~SN~                |G             |~START_AD~          |     |     |
        '            '//Tests/Test[@name='AD']/ADCChannel[@channel='08']|value        |AD-4004     |Q          |A             |~SN~                |G             |~START_AD~          |     |     |TRUE

        '            '**************** VARIABLE ARRAY ******************
        '            ' Variable_Name|Type |XML_NODE                      |XML_ATTRIBUTE  |Regex_Match     |Regex_Replace|Value
        '            '~START_AD~   |XML  |//Tests/Test[@name='AD']/Start|               |                |             |	
        '            '~SN~         |XML  |//Tests/BoardInfo             |SN             |                |             |
        '            '~Rev~        |XML  |//Tests/BoardInfo             |BoardAssyRev   |                |             |
        '            '~BoardType~  |XML  |//Tests/BoardInfo             |Type           |                |             |
        '            '~Build~      |XML  |//Tests/BoardInfo             |AppBuild       |                |             |
        '            '~TestStation~|XML  |//Tests/BoardInfo             |Machine        |                |             |
        '            '~Iteration~  |XML  |//Tests/BoardInfo             |ResultsFile    |\d\d\d\d\d\.xml |\.xml        |

        '            '********************************************
        '            '** 4) OPEN WORKBOOK
        '            '********************************************
        '            'ONLY OPEN EXCEL ON THE FIRST ONE
        '            If file.FullName = files(0).FullName Then

        '                Try
        '                    'strExcelFile = "c:\a\chart.xls"
        '                    aWorkbook = myExcel.Workbooks.Open(strExcelFile)
        '                    'worksheet opened, so can save (in cleanup) if there is a failure
        '                    bolWorkSheetOpen = True
        '                Catch ex As Exception
        '                    'MsgBox("Cannot find excel worksheet: " & strWorkSheetName, MsgBoxStyle.Critical, "Application Message")
        '                    strTextMessage = strTextMessage & vbCrLf & "Cannot find excel file: " & strExcelFile & vbCrLf & vbCrLf & "Quitting."
        '                    strTextMessage = "FAILED TO MOVE ALL DATA FROM XML TO EXCEL." & vbCrLf & strTextMessage

        '                    bolGlobalError = True
        '                    GoTo cleanUp
        '                End Try
        '            End If

        '            Dim j As Integer = 0
        '            For i = 1 To UBound(gArrXML_Mappings, 2)
        '                'EITHER mapping is a variable field (starts with '~') 
        '                '    or is an xml get which starts with '/' or '\'
        '                '   or is a hardcoded value which is anything else
        '                If gArrXML_Mappings(0, i).StartsWith("~") Then
        '                    gArrXML_Mappings(8, i) = n_GetVariable(gArrXML_Mappings(0, i))
        '                ElseIf gArrXML_Mappings(0, i).StartsWith("\") Or gArrXML_Mappings(0, i).StartsWith("/") Then
        '                    gArrXML_Mappings(8, i) = getXmlData(xml_doc, gArrXML_Mappings(0, i), gArrXML_Mappings(1, i))
        '                Else
        '                    gArrXML_Mappings(8, i) = gArrXML_Mappings(0, i).Trim
        '                End If
        '                If gArrXML_Mappings(10, i).ToUpper = "TRUE" Then
        '                    strTestResult = strTestResult & gArrXML_Mappings(0, i) & ": " & gArrXML_Mappings(8, i) & vbCrLf
        '                End If
        '            Next i



        '            '********************************************
        '            '** 5) POPULATE WORKBOOK
        '            '       a) loop through mappings
        '            '       b)      See if SheetName exists
        '            '       c) get the ~KEYS~ record for that SHEET
        '            '       d)      mark as moved=TRUE
        '            '********************************************


        '            For i = 1 To UBound(gArrXML_Mappings, 2)
        '                If gArrXML_Mappings(9, i) <> "TRUE" Then
        '                    strWorkSheetName = Trim$(Replace(gArrXML_Mappings(2, i), Chr(9), ""))
        '                    gFoundRow = 0
        '                    Try
        '                        'aWorkbook = myExcel.Workbooks.Open(strExcelFile)
        '                        aWorkSheet = CType(aWorkbook.Sheets(strWorkSheetName), Microsoft.Office.Interop.Excel.Worksheet)
        '                        aWorkSheet.Activate()
        '                    Catch ex As Exception
        '                        strTextMessage = strTextMessage & vbCrLf & "Cannot find excel worksheet: " & strWorkSheetName & vbCrLf & vbCrLf & "Quitting."
        '                        strTextMessage = "FAILED TO MOVE ALL DATA FROM XML TO EXCEL." & vbCrLf & strTextMessage

        '                        bolGlobalError = True
        '                        GoTo cleanUp
        '                    End Try

        '                    Dim strKey1Value As String = ""
        '                    Dim strKey2Value As String = ""
        '                    '1) GET THE gArrXML_Mappings row for that SHEETNAME with ~KEYS~
        '                    '   populate the KEY fields in the SPREADSHEET, or FIND THE ROW that has it
        '                    For j = 1 To UBound(gArrXML_Mappings, 2)
        '                        If strWorkSheetName = gArrXML_Mappings(2, j) And "~KEYS~" = gArrXML_Mappings(0, j) Then
        '                            'mark as moved
        '                            '*** POKE KEYS INTO SHEET *******
        '                            strKey1Value = n_GetVariable(gArrXML_Mappings(5, j))
        '                            strKey2Value = n_GetVariable(gArrXML_Mappings(7, j))
        '                            txt = pokeExcelData(aWorkSheet, _
        '                                        strKey1Value, gArrXML_Mappings(4, j), _
        '                                        strKey2Value, gArrXML_Mappings(6, j), _
        '                                        "Keys", "")
        '                            gArrXML_Mappings(9, j) = "TRUE"
        '                        End If
        '                    Next j

        '                    'Process every NON-KEY line for this WORKSHEET, marking Moved='TRUE'line if not already moved

        '                    For j = 1 To UBound(gArrXML_Mappings, 2)
        '                        If strWorkSheetName = gArrXML_Mappings(2, j) And "~KEYS~" <> gArrXML_Mappings(0, j) Then
        '                            'mark as moved
        '                            '*** ALREADY HAVE KEYS

        '                            tbStatus.Text = "Poking " & strWorkSheetName & " #" & i.ToString & " #" & j.ToString
        '                            Me.Refresh()
        '                            txt = pokeExcelData(aWorkSheet, _
        '                                        strKey1Value, gArrXML_Mappings(4, j), _
        '                                        strKey2Value, gArrXML_Mappings(6, j), _
        '                                        gArrXML_Mappings(8, j), gArrXML_Mappings(3, j))

        '                            gArrXML_Mappings(9, j) = "TRUE"
        '                        End If
        '                    Next j
        '                End If
        '            Next i

        'Cleanup:
        '            '********************************************
        '            '*********   5 -- Save workbook  ************
        '            '********************************************
        '            tbStatus.Text = "Saving excel..."
        '            Me.Refresh()
        '            Dim strDestDir As String = ""
        '            If bolGlobalError Then
        '                strTextMessage = "FAILED TO MOVE ALL DATA FROM XML TO EXCEL." _
        '                    & vbCrLf & "LOOK BELOW TO SEE WHAT FAILED." & vbCrLf & "   Look for " _
        '                    & strXMLFail & vbCrLf & vbCrLf & strTextMessage
        '            Else
        '                strTextMessage = "SUCCESS: MOVED ALL DATA FROM XML TO EXCEL." _
        '                    & vbCrLf & vbCrLf & strTextMessage
        '                'Copy the file to the "processed" directory:  
        '                'Zygo_4004_StoreDir replace ~SN with full sn
        '                strDestDir = Replace(gSet_StoreDir, "~SN", n_GetVariable("~SN~").Trim) & "\"

        '                If Not IO.Directory.Exists(strDestDir) Then
        '                    If Not IO.Directory.Exists(strDestDir) Then
        '                        IO.Directory.CreateDirectory(strDestDir)
        '                    Else
        '                        strTextMessage = "FAILED to copy file from source (" _
        '                        & Me.txtFileName.Text & ")" & vbCrLf & "to " & strDestDir & _
        '                        ": destination directory not found." & vbCrLf & vbCrLf & strTextMessage
        '                    End If
        '                End If
        '                If IO.Directory.Exists(strDestDir) Then
        '                    'TAKE OUT THESE COPIES - EITHER WILL BE ON DASHBOARD or ZMI-TEST-2
        '                    zCopyProtectedFile(strDestDir, Me.txtFileName.Text)
        '                    zCopyProtectedFile(strDestDir, Replace(Me.txtFileName.Text, ".xml", ".log"))

        '                End If
        '            End If

        '            'ONLY try to save workbook if one was changed, strKey_Start is the last field that was 
        '            'read before workbook opened
        '            'only try to close if in FILE mode
        '            If bolWorkSheetOpen And gSetFileImport Then
        '                Try
        '                    aWorkbook.Save()
        '                Catch ex As Exception
        '                    MsgBox("Error in saving workbook. " & ex.Message)
        '                Finally

        '                End Try
        '            End If
        '            '********************************************
        '            '*********   6 -- MINITAB GRAPHS  ***********
        '            '********************************************
        '            '\\Zmi-test-2\ITS Data\Test Results\ZMI 4004\07151655\CE.07151655.ZMI-TEST-2.00026.xml
        '            'COMMENT OUT TO SUPPRESS GRAPHS
        '            'only make graphs if there was not a fatal error bringing in the data

        '            'ONLY allow graphs if doing a FILE, not a DIRECTORY
        '            If Not bolGlobalError And gSetFileImport Then
        '                Dim strShell = Chr(34) & gSet_MinitabExe & Chr(34)

        '                'Returns TRUE if should make the graphs via minitab
        '                If gSet_MinitabRun Then                    'if importing folder then can't run Minitab

        gSet_MinitabExe = "C:\program files\minitab 15\mtb.exe"
        Dim strShell = Chr(34) & gSet_MinitabExe & Chr(34)


        If miniTab_MakeGraphs() Then
            'ONLY run import if the minitab directory is not ALREADY made
            '   We don't run more than once
            For i = 0 To UBound(gArrMinitabTemplateFile, 2)

                Dim psInfo As New System.Diagnostics.ProcessStartInfo(strShell)
                Dim p As New System.Diagnostics.Process
                p.StartInfo.FileName = strShell
                p.StartInfo.WindowStyle = ProcessWindowStyle.Minimized
                p.StartInfo.Arguments = gArrMinitabTemplateFile(3, i)
                p.Start()

                'Wait until the process passes back an exit code 

                p.WaitForExit()


                'Free resources associated with this process
                p.Close()
                'End Sub

            Next i
            Call setGraphButtons()
        End If
        'End If
        'End If
        '********************************************
        '*********   7 -- Quit excel     ************
        '********************************************
        tbStatus.Text = "Done!"
        Me.Refresh()
        Me.txtOutput.Text = strTextMessage.Trim
        Me.txtResults.Text = strTestResult.Trim
        If bolGlobalError And bolErrorMessage Then
            MsgBox("An error occurred in getting readings from test file," & vbCrLf & "see 'Detailed Import Results'", MsgBoxStyle.Critical, "Application Message")
        ElseIf Not bolTestResult Then
            MsgBox("Some test(s) did not pass, see 'Test Summary'", MsgBoxStyle.Critical, "Application Message")
        End If
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        'Next    'Loop of files
        'if FOLDER option, then save andclose excel ( if file already closed it above)
        If bolWorkSheetOpen And gSetFolderImport Then
            Try
                aWorkbook.Save()
                MsgBox("Done.")
            Catch ex As Exception
                MsgBox("Error in saving workbook. " & ex.Message)
            Finally

            End Try
        End If
quitExcel:
        Try
            myExcel.Quit()
            System.Runtime.InteropServices.Marshal.ReleaseComObject(myExcel)
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(myExcel)
        Catch ex As Exception
        Finally
            myExcel = Nothing
        End Try



    End Sub


    Private Sub cmdOpenChart_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles cmdOpenChart.Click

        'view excel button

        Try

            '********************************************
            '********* 1 -- See if workbook file exists *
            '********************************************

            Dim strExcelFile = gSet_ExcelOutputFile

            If IO.File.Exists(strExcelFile) Then

                Me.Text = "Close Excel to Continue"

                Dim p As New System.Diagnostics.Process
                p.StartInfo.FileName = strExcelFile
                p.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                p.Start()

                'Wait until the process passes back an exit code 

                p.WaitForExit()

                'Free resources associated with this process
                p.Close()

            Else
                MsgBox("Could not find xls chart file: " & strExcelFile)
            End If

        Catch ex As Exception

        Finally

            Me.Text = "Main"

        End Try

    End Sub


    Private Sub setGraphButtons()

        'called when picking file
        'sets global variables for 
        '   1) the name of the executable minitab .mtb
        '   2) name of the directory for the graphs and 1)
        '   3) populates list box with any graphs that are availble
        '   4) sets variable to say if should run the exectuable


        'take the selected long file name.
        'split it into an array based on "\"
        'take the XML file name and change it so that it can be a folder name
        'give the folder the correct storage path

        Dim arr As Array
        arr = Split(gstrImportFileName, "\")
        gstrImportFileNamePiece = arr(UBound(arr))
        gstrImportFileNamePiece = Replace(gstrImportFileNamePiece, ".xml", "")
        gstrImportFileNamePiece = Replace(gstrImportFileNamePiece, ".", "_")
        gstrMintabWorkingDir = gSet_MinitabRootDir & "\" & gstrImportFileNamePiece

        'check to see if the folder has been previously created

        'If IO.Directory.Exists(gstrMintabWorkingDir) Then
        '    gBolMintabWorkingDirExists = True

        'Else
        '    gBolMintabWorkingDirExists = False
        'End If

        '      setMinitabControls()
        '   Private Sub setMinitabControls()

        'if working directory exists, then
        '   the import will not redo the graphs and
        '   we need to paint the minitab graphs available on the main form for the user to
        '   open()

        'NOTE:
        '   thisFileRoot=first chars of the file up to the first "_"
        '       if there is no "_", then is the whole filename without the .jpg at end
        '   thisFileRoot is used when the button is clicked:
        '       1) Open up form to show jpgs:
        '       2) have the number of jpgs in the directory on the text of the button 
        '          (xxx/3, where 3 is the matching number of jpg files to open

        Dim dirinfo As DirectoryInfo
        Dim dirinfo2 As DirectoryInfo
        Dim allFiles() As FileInfo
        Dim allDirs() As DirectoryInfo
        Dim prevFileRoot As String = ""
        Dim thisFileRoot As String = ""
        Dim intMinitabCount As Integer = 0
        Dim intFileCount As Integer = 0
        Dim intDirCount As Integer = 0
        Dim i As Integer
        Dim j As Integer
        Dim strButtonLabel As String = ""
        Dim intFileGroupCount As Integer = 0

        'For j = 1 To 3
        '    For i = 1 To 15
        '        Me.Controls("TabControl1").Controls("Set" & Format(j, "0")).Controls _
        '        ("cmdMinitabGraphS" & Format(j, "0") & Format(i, "00")).Visible = False
        '    Next i
        'Next j

        'FIXING THE REST BBS:
        'have to loop through directories under gstrMintabWorkingDir, each one that has 
        'jpg files list, up to 3

        If IO.Directory.Exists(gstrMintabWorkingDir) Then
            dirinfo = New DirectoryInfo(gstrMintabWorkingDir)
            allDirs = dirinfo.GetDirectories()

            For Each dr As DirectoryInfo In allDirs
                intDirCount = intDirCount + 1
                If intDirCount > 3 Then
                    MsgBox("Can only handle 3 subdirectories.", MsgBoxStyle.Critical, _
                           "Application Message")
                    GoTo quitNow
                End If
                'Name the tab
                Me.Controls("TabControl1").Controls("Set" & Format(intDirCount, "0")) _
                    .Text = dr.Name

                dirinfo2 = New DirectoryInfo(dr.FullName)
                allFiles = dirinfo2.GetFiles("*.jpg")
                Array.Sort(allFiles, New clsCompareFileInfo)
                'INITIALIZE
                intFileCount = 0
                prevFileRoot = ""
                thisFileRoot = ""
                intFileGroupCount = 0
                intMinitabCount = 0
                For Each fl As FileInfo In allFiles
                    intFileCount = intFileCount + 1
                    thisFileRoot = xReadToChar(fl.Name.ToString(), "_")
                    thisFileRoot = xReadToChar(thisFileRoot, ".")

                    'if first file, then set prevFileRoot to this one:
                    If intFileCount = 1 Then
                        prevFileRoot = thisFileRoot
                    End If
                    If prevFileRoot <> thisFileRoot Then
                        'Me.ListBox1.Items.Add(prevFileRoot)
                        intMinitabCount = intMinitabCount + 1
                        strButtonLabel = Trim(Replace(prevFileRoot, "IChart", ""))

                        Me.Controls("TabControl1").Controls("Set" & Format(intDirCount, _
                            "0")).Controls("cmdMinitabGraphS" & Format(intDirCount, "0") _
                            & Format(intMinitabCount, "00")).Visible = True
                        Me.Controls("TabControl1").Controls("Set" & Format(intDirCount, _
                            "0")).Controls("cmdMinitabGraphS" & Format(intDirCount, "0") _
                            & Format(intMinitabCount, "00")).Text = strButtonLabel & "/" _
                            & intFileGroupCount
                        Me.Controls("TabControl1").Controls("Set" & Format(intDirCount, _
                            "0")).Controls("cmdMinitabGraphS" & Format(intDirCount, "0") _
                            & Format(intMinitabCount, "00")).Tag = dr.FullName & "|" _
                            & prevFileRoot

                        prevFileRoot = thisFileRoot
                        intFileGroupCount = 0
                    End If
                    intFileGroupCount = intFileGroupCount + 1
                Next

            Next

        End If

quitNow:

        Exit Sub

        'this may be old listbox which was subsequently deleted.
        'If IO.Directory.Exists(gstrMintabWorkingDir) Then
        '    Dim file As String
        '    Me.ListBox1.Items.Clear()
        '    Dim files() As String = System.IO.Directory.GetFiles(gstrMintabWorkingDir)
        '    For Each file In files
        '        Me.ListBox1.Items.Add(file)
        '        intMinitabCount = intMinitabCount + 1
        '        Me.Controls("cmdMinitabGraph" & Format(intMinitabCount, "00")) _
        '            .Visible = True
        '        Me.Controls("cmdMinitabGraph" & Format(intMinitabCount, "00")) _
        '            .Text = file
        '    Next
        'End If

        '    End Sub


    End Sub


    Private Sub DisplayJPG(ByVal sender As Object, ByVal e As System.EventArgs)

        'MsgBox(Me.ActiveControl.Tag)
        'note: the tag of the control has the start of the file up to the _ in the name
        'must prefix with gstrMintabWorkingDir & "\"

        Dim _frmJPGViewer1 As New frmJPGViewer

        Dim myPic() As System.Windows.Forms.PictureBox
        Dim myTxt() As System.Windows.Forms.TextBox

        Dim dirinfo As DirectoryInfo
        Dim allFiles() As FileInfo
        Dim iFileCounter As Integer = 0
        Dim sFileCounter As String = ""
        Dim iHeightPic As Integer = 500
        Dim iWidthPic As Integer = 720
        Dim arrTag() As String

        'NOTE: Tag will come in as a unc directory and a "|" and a filename piece like
        '       \\zygocorp\hi|IChart-SSI
        'so need to look in \\zygocorp\hi for all files like IChart-SSI*.jpg

        arrTag = Split(Me.ActiveControl.Tag, "|")

        If IO.Directory.Exists(arrTag(0)) Then

            dirinfo = New DirectoryInfo(arrTag(0))
            allFiles = dirinfo.GetFiles(arrTag(1) & "*.jpg")
            Array.Sort(allFiles, New clsCompareFileInfo)
            For Each fl As FileInfo In allFiles
                iFileCounter = iFileCounter + 1
                ReDim Preserve myPic(iFileCounter)
                myPic(iFileCounter) = New System.Windows.Forms.PictureBox
                sFileCounter = Format(iFileCounter, "00").ToString.Trim
                myPic(iFileCounter).Text = "Pic" & sFileCounter
                myPic(iFileCounter).Name = "Pic" & sFileCounter
                myPic(iFileCounter).Image = System.Drawing.Bitmap.FromFile(fl.FullName)
                myPic(iFileCounter).Size = New System.Drawing.Size(iWidthPic, iHeightPic)
                myPic(iFileCounter).Location = New System.Drawing.Point(10, 10 + _
                    ((iFileCounter - 1) * iHeightPic))
                _frmJPGViewer1.Controls.Add(myPic(iFileCounter))

                ReDim Preserve myTxt(iFileCounter)
                myTxt(iFileCounter) = New System.Windows.Forms.TextBox

                myTxt(iFileCounter).Text = fl.FullName
                myTxt(iFileCounter).Name = "Txt" & sFileCounter
                myTxt(iFileCounter).Location = New System.Drawing.Point(10, 0)
                myTxt(iFileCounter).Size = New System.Drawing.Size(iWidthPic, 15)
                myTxt(iFileCounter).Visible = False
                myTxt(iFileCounter).Enabled = False
                _frmJPGViewer1.Controls.Add(myTxt(iFileCounter))
            Next
        End If

        _frmJPGViewer1.Show()
        _frmJPGViewer1.Text = Me.ActiveControl.Text
    End Sub




    Private Function xReadToChar(ByVal pstrIn As String, ByVal pstrDelimiter As String) _
    As String

        Dim strRet As String = ""
        Dim arr() As String
        arr = Split(pstrIn, pstrDelimiter)
        xReadToChar = arr(0)

    End Function


    Private Sub processControlFile(ByVal strExcelFile As String)
        Dim bolExcelOpen As Boolean = False
        Dim bolAdminProcessed = False
        'Open filename and look at MAIN sheet for all the Active ones
        Dim myExcel As Object = Nothing
        Dim aWorkbook As Microsoft.Office.Interop.Excel.Workbook
        Dim aWorkSheet As Microsoft.Office.Interop.Excel.Worksheet

        '********************************************
        '********* 1 -- Try to open excel ***********
        '********************************************
        Try
            myExcel = CreateObject("Excel.Application")
            bolExcelOpen = True
        Catch trouble As Exception
            MsgBox("Error opening excel")
            Exit Sub
        End Try

        '********************************************
        '********* 2 -- Try to open workbook ********
        '********************************************
        Try
            aWorkbook = myExcel.Workbooks.Open(strExcelFile)
        Catch ex As Exception
            MsgBox("Error opening workbook")
            GoTo quitExcel
        End Try

        '********************************************
        '********* 3 -- Try to open worksheet MAIN ********
        '********************************************
        Try
            aWorkSheet = CType(aWorkbook.Sheets("Main"), Microsoft.Office.Interop.Excel.Worksheet)
            aWorkSheet.Activate()
        Catch ex As Exception
            MsgBox("Cannot find excel worksheet: MAIN")
            GoTo quitExcel
        End Try

        Dim strRangeCol As String = "A"
        Dim intRangeRow As String = 2
        Dim strRangeCell As String = ""
        Dim strSheetName As String = ""
        Dim aRange As Microsoft.Office.Interop.Excel.Range
        Dim aXLSControlFile As New XLSControlFile
        '********************************************
        '*********   4 -- Read MAIN   ************
        '********************************************
        strRangeCell = strRangeCol & intRangeRow.ToString.Trim
        aRange = aWorkSheet.Range(strRangeCell)
        While Not IsNothing(aRange.Value)

            strRangeCell = strRangeCol & intRangeRow.ToString.Trim
            aRange = aWorkSheet.Range(strRangeCell)

            If Not IsNothing(aRange.Value) Then
                strSheetName = aRange.Value
                strRangeCell = "D" & intRangeRow.ToString.Trim
                aRange = aWorkSheet.Range(strRangeCell)
                If aRange.Value = "Yes" Then
                    aXLSControlFile.SheetCount = aXLSControlFile.SheetCount + 1
                    strRangeCell = "B" & intRangeRow.ToString.Trim
                    strRangeCell = "c" & intRangeRow.ToString.Trim
                End If
            End If

            intRangeRow = intRangeRow + 1
            strRangeCell = strRangeCol & intRangeRow.ToString.Trim
            aRange = aWorkSheet.Range(strRangeCell)
        End While





        bolAdminProcessed = True
        '********************************************
        '*********   6 -- Quit excel     ************
        '********************************************
quitExcel:
        If bolExcelOpen Then
            Try
                myExcel.Quit()
                System.Runtime.InteropServices.Marshal.ReleaseComObject(myExcel)
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(myExcel)
            Catch ex As Exception
            Finally
                myExcel = Nothing
            End Try
        End If
        'mainClass

        If bolAdminProcessed Then
            Me.cmdOpenChart.Enabled = True
            Me.cmdGetFile.Enabled = True
            Me.cmdGetDir.Enabled = True
            Me.cmdChartFile.Enabled = True
        Else
            MsgBox("Could not process control file.")
            Me.cmdOpenChart.Enabled = False
            Me.cmdGetFile.Enabled = False
            Me.cmdGetDir.Enabled = False
            Me.cmdChartFile.Enabled = False
        End If
    End Sub
    Private Sub zMoveProtectedFile(ByVal strDestDir As String, ByVal strFileName As String)
        Dim fXML_File As New IO.FileInfo(strFileName)
        Dim aa As New AliasAccount("ZYGOMIS\ITSData", "y2yBUCAK")
        If Not IO.File.Exists(strDestDir & fXML_File.Name) Then
            Try
                aa.BeginImpersonation()
                fXML_File.MoveTo(strDestDir & fXML_File.Name)
                strTextMessage = "MOVED file from source (" & strFileName & ")" & vbCrLf & "to " & strDestDir & "." & vbCrLf & vbCrLf & strTextMessage
            Catch ex As Exception
                strTextMessage = "FAILED TO MOVED file from source (" & strFileName & ")" & vbCrLf & "to " & strDestDir & "." & vbCrLf & vbCrLf & strTextMessage

            Finally
                aa.EndImpersonation()
            End Try
        Else
            Try
                aa.BeginImpersonation()
                fXML_File.Delete()
                strTextMessage = "MOVED file from source (" & strFileName & ")" & vbCrLf & "to " & strDestDir & "." & vbCrLf & vbCrLf & strTextMessage
            Catch ex As Exception
                strTextMessage = "FAILED TO MOVED file from source (" & strFileName & ")" & vbCrLf & "to " & strDestDir & "." & vbCrLf & vbCrLf & strTextMessage
            Finally
                aa.EndImpersonation()
            End Try
        End If
    End Sub
    Private Sub zCopyProtectedFile(ByVal strDestDir As String, ByVal strFileName As String)
        Dim fXML_File As New IO.FileInfo(strFileName)
        Dim aa As New AliasAccount("ZYGOMIS\ITSData", "y2yBUCAK")
        If Not IO.File.Exists(strDestDir & fXML_File.Name) Then
            Try
                aa.BeginImpersonation()
                fXML_File.CopyTo(strDestDir & fXML_File.Name)
                strTextMessage = "MOVED file from source (" & strFileName & ")" & vbCrLf & "to " & strDestDir & "." & vbCrLf & vbCrLf & strTextMessage
            Catch ex As Exception
                strTextMessage = "FAILED TO MOVED file from source (" & strFileName & ")" & vbCrLf & "to " & strDestDir & "." & vbCrLf & vbCrLf & strTextMessage

            Finally
                aa.EndImpersonation()
            End Try
        Else
            'DO NOT DELETE FROM SOURCE; THEIR SOFTWARE NEEDS THE FILE TO INCREMENT THE COUNTER

            'Try
            '    aa.BeginImpersonation()
            '    fXML_File.Delete()
            '    strTextMessage = "MOVED file from source (" & strFileName & ")" & vbCrLf & "to " & strDestDir & "." & vbCrLf & vbCrLf & strTextMessage
            'Catch ex As Exception
            '    strTextMessage = "FAILED TO MOVED file from source (" & strFileName & ")" & vbCrLf & "to " & strDestDir & "." & vbCrLf & vbCrLf & strTextMessage
            'Finally
            '    aa.EndImpersonation()
            'End Try
        End If
    End Sub




    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        For i As Integer = My.Application.OpenForms.Count - 1 To 0 Step -1
            If My.Application.OpenForms.Item(i) IsNot Me Then
                My.Application.OpenForms.Item(i).Close()
            End If
        Next i

    End Sub


    Private Function set_Validate(ByVal pStrType As String, ByVal pValue As String) As Boolean
        'looks through array EXAMPLE:  String|SN|=|7151655
        '                           array: 0 | 1|2|3   
        'DEFAULT to NOT valid: must pass validation to get into spreadsheet
        Dim bolAreValidations As Boolean = False    'Are there any validations for this pStrType?
        Dim bolReturn As Boolean = False            'if so, then return bolReturn, otherwise TRUE
        Dim i As Integer = 0

        For i = 0 To UBound(gArrValidations, 2)
            'for example: SN = SN
            If gArrValidations(1, i) = pStrType Then
                bolAreValidations = True
                Select Case gArrValidations(0, i)
                    Case "STRING"
                        Select Case gArrValidations(2, i)
                            Case "LIKE"
                                If gArrValidations(3, i) = "*" Then
                                    bolReturn = True
                                End If
                            Case "="
                                If pValue = gArrValidations(3, i) Then
                                    bolReturn = True
                                End If
                            Case "<"
                                If pValue < gArrValidations(3, i) Then
                                    bolReturn = True
                                End If
                            Case ">"
                                If pValue > gArrValidations(3, i) Then
                                    bolReturn = True
                                End If
                            Case "<="
                                If pValue <= gArrValidations(3, i) Then
                                    bolReturn = True
                                End If
                            Case ">="
                                If pValue >= gArrValidations(3, i) Then
                                    bolReturn = True
                                End If

                            Case "!="
                                'if there is a not = , and they are =, the FAILS
                                If pValue = gArrValidations(3, i) Then
                                    bolReturn = False
                                    GoTo exitFunction
                                End If
                        End Select

                    Case "NUMERIC"
                        Select Case gArrValidations(2, i)
                            Case "LIKE"
                                If gArrValidations(3, i) = "*" Then
                                    bolReturn = True
                                End If
                            Case "="
                                If CDbl(pValue) = CDbl(gArrValidations(3, i)) Then
                                    bolReturn = True
                                End If
                            Case "<"
                                If CDbl(pValue) < CDbl(gArrValidations(3, i)) Then
                                    bolReturn = True
                                End If
                            Case ">"
                                If CDbl(pValue) > CDbl(gArrValidations(3, i)) Then
                                    bolReturn = True
                                End If
                            Case "<="
                                If CDbl(pValue) <= CDbl(gArrValidations(3, i)) Then
                                    bolReturn = True
                                End If
                            Case ">="
                                If CDbl(pValue) >= CDbl(gArrValidations(3, i)) Then
                                    bolReturn = True
                                End If
                            Case "!="
                                'if there is a not = , and they are =, the FAILS
                                If CDbl(pValue) = CDbl(gArrValidations(3, i)) Then
                                    bolReturn = False
                                    GoTo exitFunction
                                End If
                        End Select
                End Select
            End If

        Next i
exitFunction:
        'if there weren't any validations, then return PASSED
        If Not bolAreValidations Then
            bolReturn = True
        End If
        set_Validate = bolReturn
    End Function


    Private Function processTxtControlFile(ByVal strSettingsFile As String) As Boolean

        Dim bolReturn As Boolean = True
        Dim strInputFile As String = ""
        Dim inputLine As String = ""
        Dim arrInputLine() As String
        Dim strErrMsg As String = ""

        strInputFile = strSettingsFile

        If IO.File.Exists(strInputFile) Then
            Dim inputFile As New System.IO.StreamReader(strInputFile)

            'Because the open dialog box allows the user to search for
            'a settings file anywhere on the network, the program then
            'tests to see if the file has been formatted correctly with
            'the "|".

            Try
                inputLine = inputFile.ReadLine()

                'the first line of the input file is read in

                arrInputLine = Split(inputLine, "|")

                'take the settings.txt file and split it into an array
                'with two fields: 
                '(0) = the varialble name
                '(1) = the value

                'the first variable will be read in

                If UBound(arrInputLine) = 1 Then
                    Select Case arrInputLine(0).ToUpper
                        Case "GSET_XMLINPUTDIR" _
                            : gSet_XMLInputDir = arrInputLine(1)
                        Case "GSET_EXCELOUTPUTFILE" _
                            : gSet_ExcelOutputFile = arrInputLine(1)
                        Case "GSET_STOREDIR" _
                            : gSet_StoreDir = arrInputLine(1)
                        Case "GSET_VALIDATIONSFILE" _
                            : gSet_ValidationsFile = arrInputLine(1)
                        Case "GSET_XMLMAPPINGSFILE" _
                            : gSet_XMLMappingsFile = arrInputLine(1)
                        Case "GSET_XMLVARIABLESFILE" _
                            : gSet_XMLVariablesFile = arrInputLine(1)
                        Case "GSET_EMAILFILE" _
                            : gSet_EmailFile = arrInputLine(1)
                        Case "GSET_MINITABROOTDIR"
                            gSet_MinitabRootDir = arrInputLine(1)
                            gstrMinitabTemplateFile = _
                            gSet_MinitabRootDir & "\MTBTemplate.mtb"
                        Case "GSET_MINITABEXE" _
                            : gSet_MinitabExe = arrInputLine(1)
                        Case "GSET_MINITABTEMPLATEFILESPEC" _
                            : gSet_MinitabTemplateFileSpec = arrInputLine(1)
                        Case "GSET_MINITABRUN" _
                            : gSet_MinitabRun = arrInputLine(1)

                        Case Else _
                        : MsgBox("Unknown/Ignored Setting entry:" & _
                            arrInputLine(0), MsgBoxStyle.Exclamation, _
                            "Application Message")
                    End Select
                Else
                    MsgBox("Could not parse line: " & _
                    inputLine & vbCrLf & "in file: " & strInputFile)
                End If
            Catch ex As Exception
                strErrMsg = "Could not read settings file: " & strInputFile
                bolReturn = False
                GoTo exitFunction
            End Try

            'ben's comment *** read in settings

            'the second and subsequent lines of the input file are read in 
            'until the end of the file is encountered

            Do
                inputLine = inputFile.ReadLine()
                arrInputLine = Split(inputLine, "|")
                'only take the lines that are formatted with "|"
                If UBound(arrInputLine) = 1 Then
                    Select Case arrInputLine(0).ToUpper
                        Case "GSET_XMLINPUTDIR" _
                            : gSet_XMLInputDir = arrInputLine(1)
                        Case "GSET_EXCELOUTPUTFILE" _
                            : gSet_ExcelOutputFile = arrInputLine(1)
                        Case "GSET_STOREDIR" _
                            : gSet_StoreDir = arrInputLine(1)
                        Case "GSET_VALIDATIONSFILE" _
                            : gSet_ValidationsFile = arrInputLine(1)
                        Case "GSET_XMLMAPPINGSFILE" _
                            : gSet_XMLMappingsFile = arrInputLine(1)
                        Case "GSET_XMLVARIABLESFILE" _
                            : gSet_XMLVariablesFile = arrInputLine(1)
                        Case "GSET_EMAILFILE" _
                            : gSet_EmailFile = arrInputLine(1)
                        Case "GSET_MINITABROOTDIR"
                            gSet_MinitabRootDir = arrInputLine(1)

                        Case "GSET_MINITABEXE" _
                            : gSet_MinitabExe = arrInputLine(1)
                        Case "GSET_MINITABTEMPLATEFILESPEC" _
                            : gSet_MinitabTemplateFileSpec = arrInputLine(1)
                        Case "GSET_MINITABRUN" _
                            : gSet_MinitabRun = arrInputLine(1)
                        Case Else _
                        : MsgBox("Unknown/Ignored Setting entry:" & _
                            arrInputLine(0), MsgBoxStyle.Exclamation, _
                            "Application Message")
                    End Select
                Else
                    MsgBox("Could not parse line: " & _
                        inputLine & vbCrLf & "in file: " & strInputFile)
                End If

            Loop Until inputFile.Peek = -1

            inputFile.Close()
        End If

        'Dependent variables created from the variables above:
        'the replace function replaces "~Settings" with the
        'path to the directory

        gstrMinitabTemplateFile = _
            gSet_MinitabRootDir & "\MTBTemplate.mtb"
        gSet_ValidationsFile = _
            Replace(gSet_ValidationsFile, "~Settings", gSetSettingsDirName)
        gSet_EmailFile = _
            Replace(gSet_EmailFile, "~Settings", gSetSettingsDirName)
        gSet_XMLMappingsFile = _
            Replace(gSet_XMLMappingsFile, "~Settings", gSetSettingsDirName)
        gSet_XMLVariablesFile = _
            Replace(gSet_XMLVariablesFile, "~Settings", gSetSettingsDirName)

        'Check to see if the necessary files exist

        If Not IO.File.Exists(gSet_ExcelOutputFile) Then
            bolReturn = False
            MsgBox("Could not find key file:" & _
                gSet_ExcelOutputFile, MsgBoxStyle.Critical, _
                "Application Message")
        Else
            Me.cmdOpenChart.Enabled = True
        End If


        If Not IO.File.Exists(gSet_XMLMappingsFile) Then
            bolReturn = False
            MsgBox("Could not find key file:" & _
                gSet_XMLMappingsFile, MsgBoxStyle.Critical, _
                "Application Message")
        End If
        If Not IO.File.Exists(gSet_XMLVariablesFile) Then
            bolReturn = False
            MsgBox("Could not find key file:" & _
                gSet_XMLMappingsFile, MsgBoxStyle.Critical, _
                "Application Message")
        End If

exitFunction:
        processTxtControlFile = bolReturn

    End Function
    Private Function get_XML_Variables() As Boolean
        'FILE: \\zygocorp\Departments\PPS\Manuf_Test\Minitab-MC4004\XML_Variables.txt

        'reset the array each time
        Dim bolRet As Boolean = True

        Dim strInputFile As String
        Dim inputLine As String
        Dim arrInputLine() As String
        Dim strErrMsg As String
        Dim intArrCounter As Integer = 0
        Dim i As Integer = 0

        Dim intArrCol As Integer
        intArrCol = 6

        Erase gArrXML_Variables
        ReDim gArrXML_Variables(intArrCol, 0)
        strInputFile = gSet_XMLVariablesFile
        If IO.File.Exists(strInputFile) Then
            Dim inputFile As New System.IO.StreamReader(strInputFile)
            Try
                inputLine = inputFile.ReadLine()
                arrInputLine = Split(inputLine, "|")
                'only take the lines that are formed right
                If UBound(arrInputLine) = intArrCol Then
                    intArrCounter = 0
                    For i = 0 To intArrCol
                        gArrXML_Variables(i, intArrCounter) = Trim$(arrInputLine(i))
                    Next i
                Else
                    MsgBox("Could not parse line: " & inputLine & vbCrLf & "in file: " & strInputFile)
                End If
            Catch ex As Exception
                strErrMsg = "Could not read validation file: " & strInputFile
                GoTo exitFunction
            End Try

            '*** read in vallidations

            Do
                inputLine = inputFile.ReadLine()
                arrInputLine = Split(inputLine, "|")
                'only take the lines that are formed right
                If UBound(arrInputLine) = intArrCol Then
                    intArrCounter = intArrCounter + 1
                    ReDim Preserve gArrXML_Variables(intArrCol, intArrCounter)
                    For i = 0 To intArrCol
                        gArrXML_Variables(i, intArrCounter) = Trim$(arrInputLine(i))
                    Next i
                Else
                    MsgBox("Could not parse line: " & inputLine & vbCrLf & "in file: " & strInputFile, MsgBoxStyle.Critical, "Quitting.")
                    bolRet = False
                End If

            Loop Until inputFile.Peek = -1

            inputFile.Close()

        End If
exitFunction:
        get_XML_Variables = bolRet
    End Function
    Private Function get_XML_Mappings() As Boolean
        'FILE: stored in gXML_MappingsFile of settings.txt
        'FILE: \\zygocorp\Departments\PPS\Manuf_Test\Minitab-MC4004\XML_Mappings.txt 

        'reset the array each time
        Dim bolRet As Boolean = True

        Dim strInputFile As String
        Dim inputLine As String
        Dim arrInputLine() As String
        Dim strErrMsg As String
        Dim intArrCounter As Integer = 0
        Dim i As Integer = 0

        Dim intArrCol As Integer
        intArrCol = 10

        Erase gArrXML_Mappings
        ReDim gArrXML_Mappings(intArrCol, 0)
        strInputFile = gSet_XMLMappingsFile
        If IO.File.Exists(strInputFile) Then
            Dim inputFile As New System.IO.StreamReader(strInputFile)
            Try
                inputLine = inputFile.ReadLine()
                If inputLine.Trim <> "" And Not inputLine.StartsWith("'") Then
                    arrInputLine = Split(inputLine, "|")
                    'only take the lines that are formed right
                    If UBound(arrInputLine) = intArrCol Then
                        intArrCounter = 0
                        For i = 0 To intArrCol
                            'take out TAB chars
                            gArrXML_Mappings(i, intArrCounter) = Trim$(arrInputLine(i))
                        Next i
                    Else
                        MsgBox("Could not parse line: " & inputLine & vbCrLf & "in file: " & strInputFile)
                    End If
                End If
            Catch ex As Exception
                strErrMsg = "Could not read validation file: " & strInputFile
                GoTo exitFunction
            End Try

            '*** read in vallidations

            Do
                inputLine = inputFile.ReadLine()
                If inputLine.Trim <> "" And Not inputLine.StartsWith("'") Then
                    arrInputLine = Split(inputLine, "|")
                    'only take the lines that are formed right
                    If UBound(arrInputLine) = intArrCol Then
                        intArrCounter = intArrCounter + 1
                        ReDim Preserve gArrXML_Mappings(intArrCol, intArrCounter)
                        For i = 0 To intArrCol
                            'take out TAB chars
                            gArrXML_Mappings(i, intArrCounter) = Trim$(arrInputLine(i))
                        Next i
                    Else
                        MsgBox("Could not parse line: " & inputLine & vbCrLf & "in file: " & strInputFile, MsgBoxStyle.Critical, "Quitting.")
                        bolRet = False
                    End If
                End If
            Loop Until inputFile.Peek = -1

            inputFile.Close()

        End If
exitFunction:
        get_XML_Mappings = bolRet
    End Function

    Private Sub get_ValidationFile()

        'called by cmdGetDir, button1(closeGraphs), cmdChartFile

        'FILE: stored in gSet_ValidationsFile of settings.txt
        'gSet_ValidationsFile of settings.txt = 
        'gSet_ValidationsFile|~Settings\Validations.txt

        'looks like using the settings file to say where the validations file is located.

        'FILE: \\zygocorp\Departments\PPS\Manuf_Test\Minitab-ControlFiles\MC4004\validations.txt 

        'sample line: NUMERIC|SN|=|7151655
        'data array: 
        'reset the array each time

        'Don't know what he's talking about here.  The validation file for mc4004 has three serial
        'numbers.  Can easily be put in a table and extracted.

        Dim strInputFile As String
        Dim inputLine As String
        Dim arrInputLine() As String
        Dim strErrMsg As String
        Dim intArrCounter As Integer = 0
        Dim i As Integer = 0

        Erase gArrValidations
        ReDim gArrValidations(3, 0)

        strInputFile = gSet_ValidationsFile
        'the input file will now be the validation file with the path for the board
        'i.e. "~Settings" is replaced by the path.

        If IO.File.Exists(strInputFile) Then

            Dim inputFile As New System.IO.StreamReader(strInputFile)

            Try
                inputLine = inputFile.ReadLine()
                arrInputLine = Split(inputLine, "|")
                'only take the lines that are formed right

                'ubound determines the size of the array - largest available subscript.
                If UBound(arrInputLine) = 3 Then
                    intArrCounter = 0
                    For i = 0 To 3
                        gArrValidations(i, intArrCounter) = arrInputLine(i)
                    Next i
                Else
                    MsgBox("Could not parse line: " & inputLine & vbCrLf & "in file: " & strInputFile)
                End If
            Catch ex As Exception
                strErrMsg = "Could not read validation file: " & strInputFile
                GoTo exitFunction
            End Try

            '*** read in vallidations
            If inputFile.Peek <> -1 Then
                Do
                    inputLine = inputFile.ReadLine()
                    If Len(inputLine) > 0 Then
                        arrInputLine = Split(inputLine, "|")
                        'only take the lines that are formed right
                        If UBound(arrInputLine) = 3 Then
                            intArrCounter = intArrCounter + 1
                            ReDim Preserve gArrValidations(3, intArrCounter)
                            For i = 0 To 3
                                gArrValidations(i, intArrCounter) = arrInputLine(i)
                            Next i
                        Else
                            MsgBox("Could not parse line: " & inputLine & vbCrLf & "in file: " & strInputFile)
                        End If
                    End If

                Loop Until inputFile.Peek = -1
            End If
            inputFile.Close()

        End If
exitFunction:
    End Sub

    Private Sub get_EmailFile()

        'there are seven identical email.txt files
        'this routine puts them into an array.
        'at some point the array is processed and "~SN" is replaced by the 
        'file being processed.

        'FILE: \\zygocorp\Departments\PPS\Manuf_Test\Minitab-MC4004\Email.txt 
        '       also known as gSet_MinitabRootDir & \Email.txt
        'sample file:
        '           TO|ijacob@zygo.com
        '           SUBJECT|MCert Procedure Status: ~SN
        'data array: 

        'reset the array each time

        Dim strInputFile As String
        Dim inputLine As String
        Dim arrInputLine() As String
        Dim strErrMsg As String
        Dim intArrCounter As Integer = 0
        Dim i As Integer = 0

        Erase gArrEmail
        ReDim gArrEmail(1, 0)
        strInputFile = gSet_EmailFile
        If IO.File.Exists(strInputFile) Then
            Dim inputFile As New System.IO.StreamReader(strInputFile)
            Try
                inputLine = inputFile.ReadLine()
                arrInputLine = Split(inputLine, "|")
                'only take the lines that are formatted with "|"
                If UBound(arrInputLine) = 1 Then
                    intArrCounter = 0
                    For i = 0 To 1
                        gArrEmail(i, intArrCounter) = arrInputLine(i)
                    Next i
                Else
                    MsgBox("Could not parse line: " & inputLine & vbCrLf & _
                        "in file: " & strInputFile)
                End If
            Catch ex As Exception
                strErrMsg = "Could not read email  file: " & strInputFile
                GoTo exitFunction
            End Try

            '*** read in the email message

            Do
                inputLine = inputFile.ReadLine()
                arrInputLine = Split(inputLine, "|")

                'only take the lines that are formatted with "|"

                If UBound(arrInputLine) = 1 Then
                    intArrCounter = intArrCounter + 1
                    ReDim Preserve gArrEmail(1, intArrCounter)
                    For i = 0 To 1
                        gArrEmail(i, intArrCounter) = arrInputLine(i)
                    Next i
                Else
                    MsgBox("Could not parse line: " & inputLine & vbCrLf & _
                        "in file: " & strInputFile)
                End If

            Loop Until inputFile.Peek = -1

            inputFile.Close()

        End If

exitFunction:

    End Sub


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.cmdGetControl.ForeColor = Color.Red
        Me.cmdGetControl.Focus()
        Me.cmdGetFile.Enabled = False
        Me.cmdGetDir.Enabled = False
        Me.cmdChartFile.Enabled = False
        Me.cmdOpenChart.Enabled = False
        Me.txtResults.Enabled = False
        Me.txtOutput.Enabled = False

    End Sub


    'tmh commented out 5-18-11 button already covers this.
    '
    'Private Sub txtFileName_Leave(ByVal sender As Object, ByVal e As 
    '   System.EventArgs) Handles txtFileName.Leave
    '    Me.txtFileName.Text = txtFileName.Text
    '    gstrImportFileName = txtFileName.Text
    '    Me.cmdChartFile.Enabled = True
    '    Me.txtOutput.Text = ""
    '    Me.txtResults.Text = ""
    '    gSN = Me.txtFileName.Text.Replace(".xml", "")
    '    Call setMinitab()
    'End Sub


    'Private Sub txtFileName_LostFocus(ByVal sender As Object, 
    'ByVal e As System.EventArgs) Handles txtFileName.LostFocus

    'End Sub

    'Private Sub txtFileName_TextChanged(ByVal sender As System.Object, 
    'ByVal e As System.EventArgs) Handles txtFileName.TextChanged

    'End Sub


    Private Sub cmdGetDir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles cmdGetDir.Click

        'specify directory button

        'get the validations - putting here so can refresh if people have problems without 
        '   having to tell them to close
        'validations are in minitab root 
        Me.txtFileName.Text = ""
        Call get_ValidationFile()
        Call get_EmailFile()
        'If either of these 2 fail, then we have major problems and should quit
        If Not get_XML_Variables() Then 'XML_Variables.txt
            MsgBox("Failed to bring in Variables file.")
            Exit Sub
        End If

        If Not get_XML_Mappings() Then 'XML_Mappings.txt
            MsgBox("Failed to bring in Mappings file.")
            Exit Sub
        End If


        With FolderBrowserDialog1
            'With statement is used to execute statements using a particular object, here,_
            'OpenFileDialog1 which is the Open File Dialog box provided by Microsoft to 
            'open files.

            .Reset()

            'Initial Directory will not work for UNC paths.
            'Could set the registry before .showdialog, but don't want to
            'The open dialog will remember the last file you opened anyway, so only out the
            'initial set

            '.InitialDirectory = "G:\"
            '.t = "Choose XML DIR to Import"
            '.RestoreDirectory = True
            'setting filters so that Text files and All Files choice appears in the Files of 
            'Type box in the dialog

            If .ShowDialog() = DialogResult.OK Then

                'showDialog method makes the dialog box visible at run time
                'OpenFileDialog1.FileName returns the selected file

                Me.txtDirName.Text = .SelectedPath
                Me.cmdChartFile.Enabled = True
                Me.txtOutput.Text = ""
                Me.txtResults.Text = ""
                gSetFolderImport = True
                gSetFileImport = False
                gSet_MinitabRun = False 'if folder import, no minitabs.
                Dim extensions() As String = {"*.xml"}

                files = GetFilesByExtensions(Me.txtDirName.Text, extensions)

            End If
        End With
    End Sub
    Public Function GetFilesByExtensions(ByVal strPath As String, ByVal colExtensions() _
        As String) As FileInfo()

        ' The collection we will be using to store the file information in
        Dim tmpCollection As New Collection

        ' Loop through all the extensions and files, and add them to the collection.
        For Each strExtension As String In colExtensions
            For Each aFile As FileInfo In New DirectoryInfo(strPath).GetFiles(strExtension)
                tmpCollection.Add(aFile)
            Next
        Next

        ' Variables to convert the collection to type FileInfo 
        '(more convenient to the programmer)

        Dim tmpFiles(tmpCollection.Count - 1) As FileInfo
        Dim i As Integer = 0

        ' Loop through the collection and convert it into FileInfo

        For Each aFile As FileInfo In tmpCollection
            tmpFiles(i) = aFile
            i += 1
        Next

        ' Return the files

        Return tmpFiles

    End Function

End Class
