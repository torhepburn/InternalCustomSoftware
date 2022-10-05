Imports Microsoft.Office.Interop

Module ExcelModule

    Sub InsertPictureInRange(ByRef Location As Microsoft.Office.Interop.Excel.ApplicationClass, ByVal PictureFileName As String, ByVal TargetCells As Microsoft.Office.Interop.Excel.Range)
        ' inserts a picture and resizes it to fit the TargetCells range
        Dim p As Object, t As Double, l As Double, w As Double, h As Double
        If TypeName(Location.ActiveSheet) <> "Worksheet" Then Exit Sub
        If Dir(PictureFileName) = "" Then Exit Sub
        ' import picture
        p = Location.ActiveSheet.Pictures.Insert(PictureFileName)
        ' determine positions


        With TargetCells
            t = .Top
            l = .Left
            w = .Offset(0, .Columns.Count).Left - .Left
            h = .Offset(.Rows.Count, 0).Top - .Top
        End With
        ' position picture
        With p
            .Top = t
            .Left = l
            .Width = w
            .Height = h
        End With
        p = Nothing
    End Sub

    Sub InsertPicture(ByRef Location As Microsoft.Office.Interop.Excel.ApplicationClass, ByVal PictureFileName As String, ByRef Loc As System.Drawing.Rectangle)
        ' inserts a picture and resizes it to fit the TargetCells range
        Dim p As Object, t As Double, l As Double, w As Double, h As Double

    
        If TypeName(Location.ActiveSheet) <> "Worksheet" Then Exit Sub
        If Dir(PictureFileName) = "" Then Exit Sub
        ' import picture
        p = Location.ActiveSheet.Pictures.Insert(PictureFileName)
        ' determine positions




        t = Loc.Top
        l = Loc.Left
        w = Loc.Width
        h = Loc.Height
        ' position picture
        With p
            .Top = t
            .Left = l
            .Width = w
            .Height = h
        End With
        p = Nothing
    End Sub

    Public Sub copypic(ByRef img As Image)

        'Dim xlSheet1 As Excel.Worksheet
        'Dim xlRange As Excel.Range
        'Try
        '    Dim ms As New System.IO.MemoryStream
        '    Dim oIMage As Image = Image.FromFile("c:\Integral logo.bmp")
        '    oIMage.Save(ms, oIMage.RawFormat)
        '    Dim arrImage() As Byte = ms.GetBuffer
        '    Dim integralLogo As Bitmap = CType(Image.FromStream(ms), Bitmap)

        '    Clipboard.SetDataObject(integralLogo)
        '    xlRange = xlSheet1.Range(xlSheet1.Cells(1, 1), xlSheet1.Cells(1, 1))
        '    xlRange.Select()
        '    xlSheet1.Paste()
        'Catch ex As Exception
        'End Try


    End Sub

End Module
