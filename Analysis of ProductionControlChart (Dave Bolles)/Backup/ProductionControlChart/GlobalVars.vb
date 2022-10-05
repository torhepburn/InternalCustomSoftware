Module GlobalVars
    Public gFoundRow As Int16       'reset for each worksheet brought in to 0, found on first search
    Public gArrEmail(,) As String
    Public gSN As String
    Public gSetSettingsFileName As String = ""
    Public gSetSettingsDirName As String = ""
    Public gSet_XMLInputDir As String = ""
    Public gSet_ExcelOutputFile As String = ""
    Public gSet_StoreDir As String = ""
    Public gSet_ValidationsFile As String = ""
    Public gSet_XMLMappingsFile As String = ""
    Public gSet_XMLVariablesFile As String = ""
    Public gSet_EmailFile As String = ""
    Public gSet_MinitabRootDir As String = ""       ' "\\zygocorp\Departments\PPS\Manuf_Test\Minitab-MC4004"
    Public gSet_MinitabExe As String = ""
    Public gSet_MinitabTemplateFileSpec As String = ""
    Public gSet_MinitabRun As Boolean = True        'from settings file, if FALSE, don't run Minitab, if TRUE, run minitab graphs
    Public gSetFolderImport As Boolean = False            'from user: importing a whole directory?
    Public gSetFileImport As Boolean = False              'from user: importing one file?
    Public Function zGetDirFromFileName(ByVal pFileName As String) As String
        Dim strRet As String
        Dim i As Integer
        For i = Len(pFileName) To 1 Step -1
            If Mid(pFileName, i, 1) = "\" Then
                Exit For
            End If

        Next i
        strRet = Left(pFileName, i - 1)
        zGetDirFromFileName = strRet
    End Function

End Module
