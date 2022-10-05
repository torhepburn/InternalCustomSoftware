Public Class Form1

    Const mapsize = 1024

    'Public imap As New Bitmap(mapsize, mapsize)
    'Public map As New Bitmap(mapsize, mapsize)

    Public Structure infostruct
        Public inspector As String
        Public workorder As String
        Public serialnumber As String
        Public snloc As String
        Public side As String
        Public optictype As String
        Public datestamp As String
        Public Operation As String
        Public totaldefectlength As String
        Public totaldefectarea As String

        Public totaldefects As String
        Public totalscratchlength As String
        Public totalscratches As String
        Public totalpits As String
        Public totalpitarea As String

        Public totaldefectlengthncmr As Boolean
        Public totalareancmr As Boolean
        Public totaldefectncmr As Boolean

        Public scratchlengthncmr As Boolean
        Public totalscratchlengthncmr As Boolean

        Public totalscratchesncmr As Boolean
        Public totalpitsncmr As Boolean


    End Structure

    Public Structure defectstruct
        Public number As Integer
        Public width As Double
        Public length As Double
        Public area As Double
        Public x As Double
        Public y As Double
        Public angle As Double
        Public x0, y0 As Double
        Public x1, y1 As Double
        Public x2, y2 As Double
        Public description As String
        Public comment As String
        Public image1 As String
        Public image2 As String
        Public arcsf As Single
        Public exclude As Boolean
        Public ncmr As Boolean
        Public nearbydefects As Collection

    End Structure

    Public Structure opticstruct
        Public width As Double
        Public height As Double
        Public cawidth As Double
        Public caheight As Double
        Public shape As String
        Public cashape As String
        Public cacenterx As Double
        Public cacentery As Double
        Public cax0, cax1, cay0, cay1 As Double
    End Structure

    Public Structure specstruct

 
        Public maxdefects As Single
        Public maxdefectwidth As Single
        Public maxdefectlength As Single
        Public maxtotaldefectlength As Single

        Public maxscratches As Single
        Public maxscratchlength As Single
        Public maxscratchwidth As Single
        Public maxtotalscratchlength As Single

        Public maxpits As Single
        Public maxpitsize As Single
        Public maxtotalpitlength As Single

        Public maxarea As Single

        Public subapsize As Single
        Public subapqty As Single

        Public totalcount As Integer
        Public optictype As String

        Public minscratchsize As Single
        Public mindefectsize As Single


    End Structure

    Public Structure opticspecs
        Public dimensions As opticstruct
        Public surface As specstruct
        Public name As String
    End Structure

    Public defects() As defectstruct

    Public defectcount As Integer
    Public Filename As String
    Public optic As opticstruct
    Public specs As specstruct
    Public info As infostruct
    Public speclist() As opticspecs
    Public Iform As Image
    Public cell As DataGridViewCell
    Public xres, yres As Double
    Public map As Graphics
    Public nullimage As Bitmap

    Public mappath As String
    Public imagepath As String

    Public px, py As Integer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim bmap As Bitmap
        Dim fname As String
        Dim sr As System.IO.StreamReader
        Dim sw As System.IO.StreamWriter
        Dim n As Integer = -1
        Dim nlist As Object
        Dim plist As Object


        bmap = New Bitmap(mapsize, mapsize)
        Part.Image = bmap

        map = Graphics.FromImage(Part.Image)


        plist = My.Computer.FileSystem.GetFiles(Application.StartupPath, FileIO.SearchOption.SearchAllSubDirectories, "*.pth")

        If plist.count = 0 Then
            sw = New System.IO.StreamWriter(Application.StartupPath & "\paths.pth")
            sw.WriteLine(Application.StartupPath & "\Maps\")
            sw.WriteLine(Application.StartupPath & "\Images\")
            sw.Close()
        Else
            fname = plist(0)
            sr = New System.IO.StreamReader(fname)
            mappath = sr.ReadLine
            imagepath = sr.ReadLine
        End If

        nlist = My.Computer.FileSystem.GetFiles(Application.StartupPath, FileIO.SearchOption.SearchAllSubDirectories, "*.spec")

        ComboBox1.Items.Clear()


        For Each item In nlist
            fname = item.ToString
            sr = New System.IO.StreamReader(fname)
            n += 1
            ReDim Preserve speclist(n)
            speclist(n).name = sr.ReadLine
            speclist(n).dimensions.width = sr.ReadLine
            speclist(n).dimensions.height = sr.ReadLine
            speclist(n).dimensions.shape = sr.ReadLine
            speclist(n).dimensions.cawidth = sr.ReadLine
            speclist(n).dimensions.caheight = sr.ReadLine
            speclist(n).dimensions.cacenterx = sr.ReadLine
            speclist(n).dimensions.cacentery = sr.ReadLine
            speclist(n).dimensions.cashape = sr.ReadLine

            speclist(n).surface.maxdefects = sr.ReadLine
            speclist(n).surface.maxdefectlength = sr.ReadLine
            speclist(n).surface.maxtotaldefectlength = sr.ReadLine
            speclist(n).surface.maxdefectwidth = sr.ReadLine


            speclist(n).surface.maxscratches = sr.ReadLine
            speclist(n).surface.maxscratchlength = sr.ReadLine
            speclist(n).surface.maxtotalscratchlength = sr.ReadLine
            speclist(n).surface.maxscratchwidth = sr.ReadLine

            speclist(n).surface.maxpits = sr.ReadLine
            speclist(n).surface.maxpitsize = sr.ReadLine
            'speclist(n).surface.maxtotalpitlength = sr.ReadLine

            speclist(n).surface.maxarea = sr.ReadLine

            speclist(n).surface.subapqty = sr.ReadLine
            speclist(n).surface.subapsize = sr.ReadLine
            speclist(n).surface.mindefectsize = sr.ReadLine
            speclist(n).surface.minscratchsize = sr.ReadLine

            ComboBox1.Items.Add(speclist(n).name)
            sr.Close()
        Next

        fname = Application.StartupPath & "\inspectors.ini"

        sr = New System.IO.StreamReader(fname)

        ComboBox2.Items.Clear()

        While Chr(sr.Peek) <> "%"
            ComboBox2.Items.Add(sr.ReadLine)
        End While

        ComboBox2.Sorted = True
        sr.Close()

        nullimage = DefectGrid.Item(8, 0).Value

        Dim extypes As Object
        Dim nm As String
        extypes = My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Templates\", FileIO.SearchOption.SearchTopLevelOnly, "*.xlsm")

        excelbox.Items.Clear()
        For Each item In extypes
            nm = My.Computer.FileSystem.GetName(item.ToString)
            excelbox.Items.Add(nm)
        Next

        initspecs()
        Filenamebox.Text = ""
        DefectGrid.SelectAll()
        DefectGrid.Rows.Clear()
        DefectGrid.ClearSelection()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
        ComboBox5.Text = ""
        TextBox7.Text = ""
        TextBox13.Text = ""

        For i = 0 To SpecGrid.RowCount - 1
            SpecGrid.Item(1, i).Value = ""
            SpecGrid.Item(2, i).Value = ""
        Next

        UpdateMap()


    End Sub


    Public Sub SaveSpecTemplate()

        Dim fname As String
        Dim pname As String
        Dim i As Integer
        Dim v As String

        fname = Application.StartupPath

        pname = InputBox("Optic Type Name:")

        fname = fname & "\" & pname

        If Not pname = "" Then

            Dim sr As New System.IO.StreamWriter(fname & ".spec")

            sr.WriteLine(My.Computer.FileSystem.GetName(fname))

            For i = 0 To SpecGrid.RowCount - 1
                v = SpecGrid.Item(1, i).Value
                If v = "N/A" Then v = -1
                sr.WriteLine(v)
            Next

            sr.Close()

        End If
    End Sub
    Public Sub initspecs()



        's.Format = CheckBox

        SpecGrid.Columns.Add("Specification", "Specification")
        SpecGrid.Columns.Add("Target", "Target")
        SpecGrid.Columns.Add("Actual", "Actual")

        SpecGrid.Rows.Add("Width")
        SpecGrid.Rows.Add("Length")
        SpecGrid.Rows.Add("Aperture")
        SpecGrid.Rows.Add("C.A. Width")
        SpecGrid.Rows.Add("C.A. Length")
        SpecGrid.Rows.Add("C.A. Center(X)")
        SpecGrid.Rows.Add("C.A. Center(Y)")
        SpecGrid.Rows.Add("C.A. Aperture")


        SpecGrid.Rows.Add("Max. # of Defects")
        SpecGrid.Rows.Add("Max. Defect Length")
        SpecGrid.Rows.Add("Max. Combined Defect Length")
        SpecGrid.Rows.Add("Max. Defect Width")

        SpecGrid.Rows.Add("Max. # of Scratches")
        SpecGrid.Rows.Add("Max. Scratch Length")
        SpecGrid.Rows.Add("Max. Combined Scratch Length")
        SpecGrid.Rows.Add("Max. Scratch Width")

        SpecGrid.Rows.Add("Max. #Digs/Pits")
        SpecGrid.Rows.Add("Max. Digs/Pits Area")

        SpecGrid.Rows.Add("Max. Total Defect Area")

        SpecGrid.Rows.Add("Max. Defects / Sub-Ap")
        SpecGrid.Rows.Add("Sub-Ap Diameter")

        SpecGrid.Rows.Add("Min. Defect Width")
        SpecGrid.Rows.Add("Min. Scratch Width")

        For i = 0 To SpecGrid.RowCount - 2
            SpecGrid.Item(1, i).Value = ""
            SpecGrid.Item(2, i).Value = ""
        Next


        SpecGrid.Columns(0).Width = 200


    End Sub

    Public Sub GroupCheck()

        Dim i, j As Integer
        Dim p1, p2, v As PointF
        Dim res As String = ""
        Dim maxwidth As Single = 0
        Dim maxlength As Single = 0
        Dim maxscratchlength As Single = 0
        Dim maxscratchwidth As Single = 0
        Dim totaldefectlength As Single = 0
        Dim totaldefectarea As Single = 0
        Dim fail As Boolean = False
        Dim defcount As Integer = 0
        Dim maxcount As Integer = 1
        Dim ncmrcount As Integer = -1
        Dim totaldefects As Integer = 0
        Dim deftype As String
        Dim dlist As String



        For i = 8 To 22
            If Not (SpecGrid.Item(1, i).Value Is Nothing) Then
                If SpecGrid.Item(1, i).Value.ToString = "N/A" Then
                    SpecGrid.Item(1, i).Value = -1
                End If
            End If
        Next

        specs.maxdefects = Val(SpecGrid.Item(1, 8).Value)
        specs.maxdefectlength = Val(SpecGrid.Item(1, 9).Value)
        specs.maxtotaldefectlength = Val(SpecGrid.Item(1, 10).Value)
        specs.maxdefectwidth = Val(SpecGrid.Item(1, 11).Value)

        specs.maxscratches = Val(SpecGrid.Item(1, 12).Value)
        specs.maxscratchlength = Val(SpecGrid.Item(1, 13).Value)
        specs.maxtotalscratchlength = Val(SpecGrid.Item(1, 14).Value)
        specs.maxscratchwidth = Val(SpecGrid.Item(1, 15).Value)

        specs.maxpits = Val(SpecGrid.Item(1, 16).Value)
        specs.maxpitsize = Val(SpecGrid.Item(1, 17).Value)
        
        specs.maxarea = Val(SpecGrid.Item(1, 18).Value)

        specs.subapqty = Val(SpecGrid.Item(1, 19).Value)
        specs.subapsize = Val(SpecGrid.Item(1, 20).Value)
        specs.mindefectsize = Val(SpecGrid.Item(1, 21).Value)
        specs.minscratchsize = Val(SpecGrid.Item(1, 22).Value)


        If optic.width >= optic.height Then
            xres = optic.width / Part.Image.Width
            yres = optic.width / Part.Image.Height
        Else
            xres = optic.height / Part.Image.Width
            yres = optic.height / Part.Image.Height
        End If

        maxcount = 1

        NCMRgrid.Rows.Clear()

        info.totalscratchlength = 0
        info.totaldefectlength = 0
        info.totalpitarea = 0
        info.totalscratches = 0
        info.totaldefects = 0
        info.totalpits = 0
        info.totaldefectarea = 0

        For i = 0 To DefectGrid.RowCount - 2

            defects(i).ncmr = False
            defects(i).nearbydefects.Clear()
            deftype = defects(i).description

            If defects(i).width <> 0 And defects(i).exclude = False Then

                If defects(i).width > maxwidth Then maxwidth = defects(i).width
                If defects(i).length > maxlength Then maxlength = defects(i).length

                If defects(i).description = "Scratch" Then
                    If defects(i).length > maxscratchlength Then maxscratchlength = defects(i).length
                    If defects(i).width > maxscratchwidth Then maxscratchwidth = defects(i).width
                End If


                If defects(i).length > specs.maxdefectlength Then
                    If specs.maxdefectlength <> -1 Then
                        ncmrcount += 1
                        NCMRgrid.Rows.Add()
                        NCMRgrid.Item(0, ncmrcount).Value = "Defect (" & defects(i).number & ") exceeds maximum length."
                        defects(i).ncmr = True
                    End If
                End If


                If (defects(i).width - 0.001) > specs.maxdefectwidth Then
                    If specs.maxdefectwidth <> -1 Then
                        ncmrcount += 1
                        NCMRgrid.Rows.Add()
                        NCMRgrid.Item(0, ncmrcount).Value = "Defect (" & defects(i).number & ") exceeds maximum width."
                        defects(i).ncmr = True
                    End If
                End If

                If defects(i).description = "Scratch" Then
                    If defects(i).width > specs.maxscratchwidth Then
                        If specs.maxscratchwidth <> -1 Then
                            ncmrcount += 1
                            NCMRgrid.Rows.Add()
                            NCMRgrid.Item(0, ncmrcount).Value = "Scratch (" & defects(i).number & ") exceeds maximum width."
                            defects(i).ncmr = True
                        End If
                    End If
                End If
      

                If defects(i).description = "Scratch" Then
                    If defects(i).length > specs.maxscratchlength Then
                        If specs.maxscratchlength <> -1 Then
                            ncmrcount += 1
                            NCMRgrid.Rows.Add()
                            NCMRgrid.Item(0, ncmrcount).Value = "Scratch (" & defects(i).number & ") exceeds maximum length."
                            defects(i).ncmr = True
                        End If
                    End If
                    info.totalscratchlength += defects(i).length
                    info.totalscratches += 1
                End If

                If defects(i).description = "Pit/Dig" Then

                    If defects(i).length * defects(i).width > specs.maxpitsize Then
                        If specs.maxpitsize <> -1 Then
                            ncmrcount += 1
                            NCMRgrid.Rows.Add()
                            NCMRgrid.Item(0, ncmrcount).Value = "Pit/Dig (" & defects(i).number & ") exceeds maximum area."
                            defects(i).ncmr = True
                        End If
                    End If
                    info.totalpitarea += defects(i).length * defects(i).width
                    info.totalpits += 1

                End If

                If defects(i).description = "Fracture" Then
                    ncmrcount += 1
                    NCMRgrid.Rows.Add()
                    NCMRgrid.Item(0, ncmrcount).Value = "Fracture at (" & defects(i).x & "," & defects(i).y & ") ncmr may be required."
                    defects(i).ncmr = True
                End If

                info.totaldefectlength += defects(i).length
                info.totaldefectarea += defects(i).length * defects(i).width
                info.totaldefects += 1

                For j = 0 To DefectGrid.RowCount - 2
                    If i <> j Then
                        If defects(j).width <> 0 And defects(j).exclude = False Then
                            p1.X = defects(i).x
                            p1.Y = defects(i).y
                            p2.X = defects(j).x
                            p2.Y = defects(j).y
                            v.X = (p2.X - p1.X)
                            v.Y = (p2.Y - p1.Y)
                            If System.Math.Sqrt(v.X ^ 2 + v.Y ^ 2) < specs.subapsize Then
                                defects(i).nearbydefects.Add(j)
                            End If
                        End If
                    End If
                Next

            End If
        Next


        SpecGrid.Item(2, 8).Value = info.totaldefects
        SpecGrid.Item(2, 9).Value = maxlength
        SpecGrid.Item(2, 10).Value = info.totaldefectlength
        SpecGrid.Item(2, 11).Value = maxwidth
     
        SpecGrid.Item(2, 12).Value = info.totalscratches
        SpecGrid.Item(2, 13).Value = maxscratchlength
        SpecGrid.Item(2, 14).Value = info.totalscratchlength
        SpecGrid.Item(2, 15).Value = maxscratchwidth

        SpecGrid.Item(2, 16).Value = info.totalpits
        SpecGrid.Item(2, 17).Value = info.totalpitarea

        SpecGrid.Item(2, 18).Value = info.totaldefectarea


        'TextBox39.Text = Format(DefectGrid.DisplayedRowCount(True) - 1, "0")

        info.totaldefectlengthncmr = False
        info.totalareancmr = False
        info.totaldefectncmr = False


        For i = 0 To DefectGrid.RowCount - 2
            If defects(i).nearbydefects.Count > specs.subapqty - 1 Then
                If specs.subapqty <> -1 And specs.subapqty <> 0 Then
                    dlist = ""
                    NCMRgrid.Rows.Add()
                    ncmrcount += 1
                    'NCMRgrid.Item(0, ncmrcount).Value = "More than " & specs.subapqty & " defects within " & specs.subapsize & "mm of defect (" & defects(i).number & ")"
                    'NCMRgrid.Item(0, ncmrcount).Value = "( " & defects(i).nearbydefects.Count & ") defects within " & specs.subapsize & "mm of defect (" & defects(i).number & ")"
                    For Each num In defects(i).nearbydefects
                        If dlist = "" Then
                            dlist = "(" & Str(num + 1)
                        Else
                            dlist = dlist & "," & Str(num + 1)
                        End If
                    Next
                    NCMRgrid.Item(0, ncmrcount).Value = "defects " & dlist & " ) are within " & specs.subapsize & "mm of defect (" & defects(i).number & ")"
                End If
            End If
        Next

        If info.totaldefectlength > specs.maxtotaldefectlength Then
            If specs.maxtotaldefectlength <> -1 Then
                NCMRgrid.Rows.Add()
                ncmrcount += 1
                NCMRgrid.Item(0, ncmrcount).Value = "Combined defect length exceeds specification"
                info.totaldefectlengthncmr = True
            End If
        End If

        If info.totalscratchlength > specs.maxtotalscratchlength Then
            If specs.maxtotalscratchlength <> -1 Then
                NCMRgrid.Rows.Add()
                ncmrcount += 1
                NCMRgrid.Item(0, ncmrcount).Value = "Comined scratch length exceeds specification"
                info.totalscratchlengthncmr = True
            End If
        End If

        If info.totaldefectarea > specs.maxarea Then
            If specs.maxarea <> -1 Then
                ncmrcount += 1
                NCMRgrid.Rows.Add()
                NCMRgrid.Item(0, ncmrcount).Value = "Comined defect area exceeds specification"
                info.totalareancmr = True
            End If
        End If


        If info.totaldefects > specs.maxdefects Then
            If specs.maxdefects <> -1 Then
                ncmrcount += 1
                NCMRgrid.Rows.Add()
                NCMRgrid.Item(0, ncmrcount).Value = "Total defect quantity exceeds specification"
                info.totaldefectncmr = True
            End If
        End If

        If info.totalscratches > specs.maxscratches Then
            If specs.maxscratches <> -1 Then
                ncmrcount += 1
                NCMRgrid.Rows.Add()
                NCMRgrid.Item(0, ncmrcount).Value = "Total scratch quantity exceeds specification"
                info.totalscratchesncmr = True
            End If
        End If

        If info.totalpits > specs.maxpits Then
            If specs.maxpits <> -1 Then
                ncmrcount += 1
                NCMRgrid.Rows.Add()
                NCMRgrid.Item(0, ncmrcount).Value = "Total pit/dig quantity exceeds specification"
                info.totalpitsncmr = True
            End If
        End If


        For i = 8 To 22
            If Not (SpecGrid.Item(1, i).Value Is Nothing) Then
                If SpecGrid.Item(1, i).Value.ToString = "-1" Then
                    SpecGrid.Item(1, i).Value = "N/A"
                End If
            End If
        Next


    End Sub

    Public Sub DrawDefect(ByRef index As Integer)

        Dim p As New System.Drawing.Pen(Color.White)
        Dim p2 As New System.Drawing.Pen(Color.White)

        Dim f As New Font("Arial", mapsize / 75)
        Dim b As Brush

        optic.width = Val(SpecGrid.Item(1, 0).Value)
        optic.height = Val(SpecGrid.Item(1, 1).Value)
        optic.shape = SpecGrid.Item(1, 2).Value

        If optic.width >= optic.height Then
            xres = optic.width / Part.Image.Width
            yres = optic.width / Part.Image.Height
        Else
            xres = optic.height / Part.Image.Width
            yres = optic.height / Part.Image.Height
        End If

        Dim cx, cy As Integer
        Dim x0, x1 As Integer
        Dim y0, y1 As Integer
        Dim theta As Double
        Dim l As Single
        Dim pt() As PointF
        Dim arcsf As Single

        If xres > 0 And yres > 0 Then


            theta = defects(index).angle * System.Math.PI / 180

            cx = defects(index).x / xres
            cy = defects(index).y / yres

            l = defects(index).length / xres

            x0 = -(0.5 * defects(index).length / xres) * System.Math.Cos(theta) + cx
            x1 = +(0.5 * defects(index).length / xres) * System.Math.Cos(theta) + cx
            y0 = -(0.5 * defects(index).length / xres) * System.Math.Sin(theta) + cy
            y1 = +(0.5 * defects(index).length / xres) * System.Math.Sin(theta) + cy


            arcsf = defects(index).arcsf
            p.Width = Int(mapsize / 512) + 1
            p.Color = Color.White
            b = Brushes.Yellow

            If CheckBox2.Checked Then
                p.Color = Color.Black
                b = Brushes.Black
            End If

            If defects(index).description = "Broken Scratch" Then
                p.DashStyle = Drawing2D.DashStyle.Dash
            Else
                p.DashStyle = Drawing2D.DashStyle.Solid
            End If

            '            map.DrawLine(p, x0, y0, x1, y1)
            
            ReDim pt(2)

            pt(0).X = x0
            pt(0).Y = y0
            pt(1).X = (x1 + x0) / 2
            pt(1).Y = (y1 + y0) / 2
            pt(2).X = x1
            pt(2).Y = y1

          
            'Dim m As Single
            'Dim l As Single
            Dim t As Single
            t = System.Math.Atan2((pt(2).Y - pt(0).Y), (pt(2).X - pt(0).X))

            pt(1).X += -l * System.Math.Sin(t) * arcsf
            pt(1).Y += l * System.Math.Cos(t) * arcsf

            'If pt(2).X - pt(0).X <> 0 Then
            '    m = (pt(2).Y - pt(0).Y) / (pt(2).X - pt(0).X)
            'Else
            '    m = 1.0E+99
            'End If
            Dim ptinv(2) As PointF
            Dim cxinv, cyinv As Integer
            ptinv = pt.Clone
            ptinv(0).Y = Part.Image.Height - ptinv(0).Y
            ptinv(1).Y = Part.Image.Height - ptinv(1).Y
            ptinv(2).Y = Part.Image.Height - ptinv(2).Y
            cxinv = cx
            cyinv = Part.Image.Height - cy

            Try
                map.DrawCurve(p, ptinv)
            Catch
                p.DashStyle = Drawing2D.DashStyle.Solid
                map.DrawEllipse(p, ptinv(0).X, ptinv(0).Y, ptinv(0).X, ptinv(0).Y)

            End Try

            If Val(defects(index).number) > 0 Then
                If defects(index).width <> 0 Then
                    map.DrawString(defects(index).number, f, b, cxinv, cyinv)
                End If
            End If

            'map.DrawCurve(p, pt)

            'If Val(defects(index).number) > 0 Then
            '    If defects(index).width <> 0 Then
            '        map.DrawString(defects(index).number, f, b, cx, cy)
            '    End If
            'End If

        End If




    End Sub

    Public Sub DrawGrid()

        Dim gridstepx As Integer = 50
        Dim gridstepy As Integer = 50

        Dim f As New Font("Arial", mapsize / 75)
        Dim b As Brush
        b = Brushes.Gray

        gridstepx = Val(Gridx.Text)
        gridstepy = Val(Gridy.Text)

        If gridstepx < 5 Then gridstepx = 5
        If gridstepy < 5 Then gridstepy = 5

        Dim p1 As New System.Drawing.Pen(Color.Blue)
        Dim sx, sy As Integer
        Dim x0, x1, y0, y1 As Single
        Dim y0inv, y1inv As Single

        optic.width = Val(SpecGrid.Item(1, 0).Value)
        optic.height = Val(SpecGrid.Item(1, 1).Value)
        'optic.shape = ComboBox3.Text

        If optic.width >= optic.height Then
            xres = optic.width / Part.Image.Width
            yres = optic.width / Part.Image.Height
        Else
            xres = optic.height / Part.Image.Width
            yres = optic.height / Part.Image.Height
        End If
        If xres > 0 And yres > 0 Then


            sx = optic.width / xres
            sy = optic.height / yres

            'p1.Width = mapsize / 500
            p1.Width = 2
            p1.DashStyle = Drawing2D.DashStyle.Dot

            For i = 0 To optic.width Step gridstepx
                x0 = i / xres
                y0 = 0
                y0inv = Part.Image.Height - y0
                x1 = x0
                y1 = sy
                y1inv = Part.Image.Height - y1
                'map.DrawLine(p1, x0, y0, x1, y1)
                map.DrawLine(p1, x0, y1inv, x1, y0inv)
                map.DrawString(Format(x0 * yres, "0"), f, Brushes.Gray, x0, Part.Image.Height - f.Height)
            Next

            For i = 0 To optic.height Step gridstepy
                x0 = 0
                y0 = i / yres
                y0inv = Part.Image.Height - y0
                x1 = sx
                y1 = y0
                y1inv = Part.Image.Height - y1
                'map.DrawLine(p1, x0, y0, x1, y1)
                map.DrawLine(p1, x0, y1inv, x1, y0inv)
                map.DrawString(Format((Part.Image.Height - y0inv) * yres, "0"), f, Brushes.Gray, x0, y0inv)
            Next

            p1.DashStyle = Drawing2D.DashStyle.Solid

            For i = 0 To optic.width Step gridstepx / 5
                x0 = i / xres
                y0 = 0
                y0inv = Part.Image.Height - y0
                x1 = x0
                y1 = gridstepy / 5
                y1inv = Part.Image.Height - y1
                'map.DrawLine(p1, x0, y0, x1, y1)
                map.DrawLine(p1, x0, y1inv, x1, y0inv)
            Next

            For i = 0 To optic.height Step gridstepy / 5
                x0 = 0
                y0 = i / yres
                y0inv = Part.Image.Height - y0
                x1 = gridstepx / 5
                y1 = y0
                y1inv = Part.Image.Height - y1
                'map.DrawLine(p1, x0, y0, x1, y1)
                map.DrawLine(p1, x0, y1inv, x1, y0inv)
            Next


        End If

    End Sub

    Public Sub DrawOptic()

        Dim p1 As New System.Drawing.Pen(Color.White)
        Dim p2 As New System.Drawing.Pen(Color.Gray)
        Dim r As Rectangle
        Dim rca As Rectangle
        Dim cax0, cax1, cay0, cay1 As Integer
        Dim cay0inv, cay1inv As Integer

        Dim cx, cy As Integer
        Dim cyinv As Integer

        Dim b As Brush
        Dim sx, sy As Integer
        Dim syinv As Integer

        'map.ScaleTransform(1, -1)

        optic.width = Val(SpecGrid.Item(1, 0).Value)
        optic.height = Val(SpecGrid.Item(1, 1).Value)
        optic.shape = SpecGrid.Item(1, 2).Value
        optic.cawidth = Val(SpecGrid.Item(1, 3).Value)
        optic.caheight = Val(SpecGrid.Item(1, 4).Value)
        optic.cashape = Val(SpecGrid.Item(1, 7).Value)

        If optic.width >= optic.height Then
            xres = optic.width / Part.Image.Width
            yres = optic.width / Part.Image.Height
        Else
            xres = optic.height / Part.Image.Width
            yres = optic.height / Part.Image.Height
        End If

        If xres > 0 And yres > 0 Then

            sx = optic.width / xres
            sy = optic.height / yres
            syinv = Part.Image.Height - sy

            cx = Val(SpecGrid.Item(1, 5).Value) / xres
            cy = Val(SpecGrid.Item(1, 6).Value) / yres

            cyinv = Part.Image.Height - cy

            cax0 = cx - optic.cawidth / (2 * xres)
            cax1 = optic.cawidth / xres

            cay0 = cy - optic.caheight / (2 * yres)
            cay1 = (optic.caheight / yres)

            cay0inv = Part.Image.Height - cay0
            cay1inv = Part.Image.Height - cay1

            'r = New Rectangle(0, 0, sx, sy)
            'rca = New Rectangle(cax0, cay0, cax1, cay1)

            r = New Rectangle(0, Part.Image.Height - sy, sx, sy)
            rca = New Rectangle(cax0, Part.Image.Height - sy + cay0, cax1, cay1)

            b = Brushes.Blue

            p1.Width = mapsize / 128
            p1.Color = Color.Gray

            p2.Width = mapsize / 512
            p2.Color = Color.Red
            p2.DashStyle = Drawing2D.DashStyle.DashDot

            If optic.shape = "Circular" Then
                If CheckBox2.Checked Then
                    map.FillRectangle(Brushes.White, r)
                Else
                    map.FillRectangle(Brushes.Black, r)
                End If
                map.DrawEllipse(p1, r)
                map.DrawEllipse(p2, rca)
            Else
                If CheckBox2.Checked Then
                    map.FillRectangle(Brushes.White, r)
                Else
                    map.FillRectangle(Brushes.Black, r)
                End If
                'map.FillRectangle(Brushes.Black, r)
                map.DrawRectangle(p1, r)
                map.DrawRectangle(p2, rca)
            End If

 


        End If


        'map.FillRectangle(b, r)

    End Sub


    Public Function CheckOut(ByRef i As Integer) As Boolean

        Const si = 20

        Dim l As Single
        Dim theta As Single
        Dim x, y As Single
        Dim isout As Boolean
        Dim ts As Single
        Dim pt(si) As PointF
        Dim apcx As Single
        Dim apcy As Single
        Dim xax As Single
        Dim yax As Single
        Dim cx, cy As Single

        cx = defects(i).x
        cy = defects(i).y

        l = defects(i).length
        theta = defects(i).angle * System.Math.PI / 180

        For t = 0 To si Step 1

            ts = (t - (si / 2)) / si
            pt(t).X = -(ts * defects(i).length) * System.Math.Cos(theta) + cx
            pt(t).Y = -(ts * defects(i).length) * System.Math.Sin(theta) + cy

        Next t

        isout = True

        For t = 0 To si

            x = pt(t).X
            y = pt(t).Y

            If optic.shape = "Rectangular" Then
                If (x > optic.cax0 And x < optic.cax1) And (y < optic.cay1 And y > optic.cay0) Then
                    isout = False
                End If
            End If

            If optic.shape = "Circular" Then
                apcx = optic.cax0 + (optic.cax1 - optic.cax0) / 2
                apcy = optic.cay0 + (optic.cay1 - optic.cay0) / 2
                xax = apcx - optic.cax0
                yax = apcy - optic.cay0
                If (((x - apcx) / xax) ^ 2 + ((y - apcx) / yax) ^ 2) <= 1 Then
                    isout = False
                End If
            End If

        Next

        CheckOut = isout


    End Function

    Public Sub UpdateMap()

        Dim i As Integer
        Dim rc As Integer

        rc = DefectGrid.RowCount - 2
        If rc < 0 Then rc = 0

        ReDim Preserve defects(DefectGrid.RowCount)

        If Not map Is Nothing Then
            map.Clear(Color.Black)


            NCMRgrid.SelectAll()
            NCMRgrid.Rows.Clear()
            NCMRgrid.ClearSelection()

            optic.width = Val(SpecGrid.Item(1, 0).Value)
            optic.height = Val(SpecGrid.Item(1, 1).Value)
            optic.shape = SpecGrid.Item(1, 2).Value
            optic.cawidth = Val(SpecGrid.Item(1, 3).Value)
            optic.caheight = Val(SpecGrid.Item(1, 4).Value)
            optic.cacenterx = Val(SpecGrid.Item(1, 5).Value)
            optic.cacentery = Val(SpecGrid.Item(1, 6).Value)


            optic.cax0 = optic.cacenterx - optic.cawidth / 2
            optic.cax1 = optic.cacenterx + optic.cawidth / 2
            optic.cay0 = optic.cacentery - optic.caheight / 2
            optic.cay1 = optic.cacentery + optic.caheight / 2

            DrawOptic()

            For i = 0 To DefectGrid.RowCount - 2

                defects(i).number = Val(DefectGrid.Item(0, i).FormattedValue.ToString)
                defects(i).exclude = DefectGrid.Item(1, i).Value
                defects(i).width = Val(DefectGrid.Item(2, i).FormattedValue.ToString)
                defects(i).length = Val(DefectGrid.Item(3, i).FormattedValue.ToString)
                defects(i).area = defects(i).width * defects(i).length
                DefectGrid.Item(4, i).Value = defects(i).area
                defects(i).area = Val(DefectGrid.Item(4, i).FormattedValue.ToString)
                defects(i).x = Val(DefectGrid.Item(5, i).FormattedValue.ToString)
                defects(i).y = Val(DefectGrid.Item(6, i).FormattedValue.ToString)
                defects(i).angle = Val(DefectGrid.Item(7, i).FormattedValue.ToString)
                defects(i).arcsf = DefectGrid.Item(8, i).Value

                defects(i).image1 = DefectGrid.Item(9, i).Value

                defects(i).description = DefectGrid.Item(10, i).FormattedValue.ToString
                defects(i).comment = DefectGrid.Item(11, i).FormattedValue.ToString

                'defects(i).outsideca = CheckOut(i)

                If defects(i).exclude = True Then
                    DefectGrid.Item(1, i).Value = True
                Else
                    DefectGrid.Item(1, i).Value = False
                End If

                DrawDefect(i)
                defects(i).nearbydefects = New Collection
            Next

            defectcount = DefectGrid.RowCount - 1

            'TextBox7.Text = System.DateTime.Today

            If CheckBox1.Checked Then
                DrawGrid()
            End If


            'Part.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            Part.Refresh()

            GroupCheck()

        End If


    End Sub

    Public Sub LoadFile()


        Dim od As OpenFileDialog
        Dim sr As System.IO.StreamReader
        Dim imap As String
        Dim val As String
        Dim valstr() As String
        Dim v As String
        Dim i As Integer = -1

        od = New OpenFileDialog

        'od.InitialDirectory = System.Windows.Forms.Application.StartupPath & "\Maps"
        od.InitialDirectory = mappath
        od.Filter = "*(.sdm)|*.sdm|(*.*)|*.*"

        On Error GoTo 1

        If od.CheckFileExists And Not (od.ShowDialog = Windows.Forms.DialogResult.Cancel) Then

            DefectGrid.SelectAll()
            DefectGrid.Rows.Clear()
            DefectGrid.ClearSelection()

            sr = New System.IO.StreamReader(od.FileName)

            Filename = od.SafeFileName
            Filenamebox.Text = Filename

            'sw.WriteLine("bitmap: " & imadir & "\current.bmp")
            'sw.WriteLine("date: " & System.DateTime.Today.ToString)
            'sw.WriteLine("inspector: " & info.inspector)
            'sw.WriteLine("workorder: " & info.workorder)
            'sw.WriteLine("sn: " & info.serialnumber)
            'sw.WriteLine("snlocation: " & info.snloc)
            'sw.WriteLine("side: " & info.side)
            'sw.WriteLine("type: " & info.optictype)
            'sw.WriteLine("operation: " & info.Operation)
            'sw.WriteLine("count: " & DefectGrid.RowCount - 1)

            While sr.Peek <> -1
                val = sr.ReadLine
                valstr = Split(val, ": ")

                Select Case valstr(0)
                    Case "bitmap"
                        imap = valstr(1)
                    Case "date"
                        info.datestamp = valstr(1)
                    Case "inspector"
                        info.inspector = valstr(1)
                    Case "workorder"
                        info.workorder = valstr(1)
                    Case "sn"
                        info.serialnumber = valstr(1)
                    Case "snlocation"
                        info.snloc = valstr(1)
                    Case "side"
                        info.side = valstr(1)
                    Case "type"
                        info.optictype = valstr(1)
                    Case "operation"
                        info.Operation = valstr(1)
                    Case "defect"
                        i += 1
                        DefectGrid.Rows.AddCopy(i)
                        v = sr.ReadLine
                        DefectGrid.Item(0, i).Value = v
                        v = sr.ReadLine
                        DefectGrid.Item(1, i).Value = v
                        v = sr.ReadLine
                        DefectGrid.Item(2, i).Value = v
                        v = sr.ReadLine
                        DefectGrid.Item(3, i).Value = v
                        v = sr.ReadLine
                        DefectGrid.Item(5, i).Value = v
                        v = sr.ReadLine
                        DefectGrid.Item(6, i).Value = v
                        v = sr.ReadLine
                        DefectGrid.Item(7, i).Value = v
                        v = sr.ReadLine
                        DefectGrid.Item(8, i).Value = v
                        v = sr.ReadLine
                        DefectGrid.Item(9, i).Value = v
                        v = sr.ReadLine
                        DefectGrid.Item(10, i).Value = v
                        v = sr.ReadLine
                        DefectGrid.Item(11, i).Value = v
                End Select

            End While

            imap = sr.ReadLine
            ComboBox2.Text = info.inspector.Trim("""")
            TextBox7.Text = info.workorder
            TextBox13.Text = info.serialnumber
            ComboBox5.Text = info.snloc
            ComboBox4.Text = info.side
            ComboBox1.Text = info.optictype
            ComboBox3.Text = info.Operation

            sr.Close()

        End If
1:

        UpdateMap()

    End Sub

    Public Sub SaveFile(Optional ByRef export As Boolean = False, Optional ByRef filename As String = "")

        Dim sw As System.IO.StreamWriter
        Dim sd As SaveFileDialog
        Dim res As DialogResult
        Dim bm As Bitmap
        Dim direct As String
        Dim imadir As String
        Dim fname As String
        Dim iname As String

        info.inspector = ComboBox2.Text.ToString
        info.workorder = TextBox7.Text
        info.serialnumber = TextBox13.Text
        info.snloc = ComboBox5.Text
        info.side = ComboBox4.Text
        info.optictype = ComboBox1.Text
        info.Operation = ComboBox3.Text

        direct = System.Windows.Forms.Application.StartupPath
        imadir = direct & "\Images"

        System.IO.Directory.CreateDirectory(imadir)

        If filename = "" Then
            sd = New SaveFileDialog
            sd.FileName = TextBox13.Text & ".sdm"
            sd.Filter = "*.sdm|*.sdm"
            'sd.InitialDirectory = direct & "\Maps"
            sd.InitialDirectory = mappath

            res = sd.ShowDialog()

            If res = Windows.Forms.DialogResult.Cancel Then
                GoTo 1
            End If

            iname = My.Computer.FileSystem.GetName(sd.FileName)
            iname = iname.Substring(0, Len(iname) - 4)
            fname = sd.FileName
        Else
            fname = direct & "\Maps\" & filename
        End If



        sw = New System.IO.StreamWriter(fname)

        bm = Part.Image

        Dim sf As Single
        Dim h As Integer, w As Integer

        w = optic.width
        h = optic.height


        bm.RotateFlip(RotateFlipType.RotateNoneFlipY)

        If w >= h Then
            sf = h / w
            w = bm.Width
            h = bm.Height * sf

        Else
            sf = w / h
            w = bm.Width * sf
            h = bm.Height
        End If

        Dim rect As New Rectangle(0, 0, w, h)
        Dim bm2 As Bitmap = bm.Clone(rect, bm.PixelFormat)

        bm2.RotateFlip(RotateFlipType.RotateNoneFlipY)
        bm2.Save(imadir & "\current.bmp")
        bm.RotateFlip(RotateFlipType.RotateNoneFlipY)

        sw.WriteLine("bitmap: " & imadir & "\current.bmp")
        sw.WriteLine("date: " & System.DateTime.Today.ToString)
        sw.WriteLine("inspector: " & info.inspector)
        sw.WriteLine("workorder: " & info.workorder)
        sw.WriteLine("sn: " & info.serialnumber)
        sw.WriteLine("snlocation: " & info.snloc)
        sw.WriteLine("side: " & info.side)
        sw.WriteLine("type: " & info.optictype)
        sw.WriteLine("operation: " & info.Operation)
        sw.WriteLine("count: " & DefectGrid.RowCount - 1)

        For i = 0 To DefectGrid.RowCount - 2
            sw.WriteLine("defect: ")
            sw.WriteLine(defects(i).number)
            sw.WriteLine(defects(i).exclude.ToString)
            sw.WriteLine(defects(i).width)
            sw.WriteLine(defects(i).length)
            sw.WriteLine(defects(i).x)
            sw.WriteLine(defects(i).y)
            sw.WriteLine(defects(i).angle)
            sw.WriteLine(defects(i).arcsf)
            sw.WriteLine(defects(i).image1)
            sw.WriteLine(defects(i).description)
            sw.WriteLine(defects(i).comment)
        Next

        sw.Close()

        If export Then
            If excelbox.Text = "CEA-AMP.xlsm" Then
                ExportCEAAMP(excelbox.Text)
            Else
                ExportExcel(bm2, excelbox.Text)
            End If
        End If

1:



    End Sub

    Public Sub ExportGeneric(ByRef bm As Bitmap, ByRef template As String)

        Dim c As String
        Dim pname As String
        Dim fname As String
        Dim direct, imadir As String

        c = System.Windows.Forms.Application.StartupPath
        pname = c & "\Templates\" & template
        direct = System.Windows.Forms.Application.StartupPath
        imadir = direct & "\Images"


        Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
        Dim wBook As Microsoft.Office.Interop.Excel.Workbook
        Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim Rng As Microsoft.Office.Interop.Excel.Range
        Dim C1 As Object
        Dim C2 As Object

        fname = "I:\test.xls"

        wBook = excel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()

        'wBook.SaveAs()
        excel.Workbooks.Open(pname, , True)
        excel.Visible = True


        C1 = excel.Cells(2, 2)
        C2 = excel.Cells(5, 5)

        Rng = excel.Range("A1", "F19")



        Dim os As Microsoft.Office.Interop.Excel.Shape


        os = excel.ActiveSheet.Shapes("Map")
        os.Fill.UserPicture(imadir & "\current.bmp")

        Dim w, h As Integer
        Dim sf As Single

        w = bm.Width
        h = bm.Height

        Dim oh, ow As Integer
        Dim dh, dw As Integer

        dh = 0
        dw = 0

        If w >= h Then
            sf = h / w
            w = os.Width
            h = os.Height * sf
            oh = os.Height
            dh = (oh - h) / 2
        Else
            sf = w / h
            w = os.Width * sf
            h = os.Height
            ow = os.Width
            dw = (ow - w) / 2
        End If

        os.Width = w
        os.Height = h
        os.Top = os.Top + dh
        os.Left = os.Left + dw



        Dim cs As Integer = 34
        Dim value As String

        For i = 0 To DefectGrid.RowCount - 2

            value = defects(i).number
            If defects(i).exclude Then
                value = "(" & defects(i).number & ")"
                excel.Cells(i + cs, 1) = value
            Else
                excel.Cells(i + cs, 1) = value
            End If
            If defects(i).ncmr Then
                excel.Cells(i + cs, 1) = "**" & value & "**"
            End If
            excel.Cells(i + cs, 2) = defects(i).width
            excel.Cells(i + cs, 3) = defects(i).length
            excel.Cells(i + cs, 4) = defects(i).x
            excel.Cells(i + cs, 5) = defects(i).y
            excel.Cells(i + cs, 6) = defects(i).angle
            excel.Cells(i + cs, 7) = defects(i).area
            excel.Cells(i + cs, 8) = defects(i).description


        Next

        Dim a As String

        Dim tc() As Char

        ReDim tc(0)
        tc(0) = """"
        a = info.inspector.Trim(tc)

        excel.Cells(2, 3) = info.serialnumber & " (" & info.snloc & ")"
        excel.Cells(2, 5) = info.side
        excel.Cells(1, 8) = info.datestamp
        excel.Cells(28, 8) = a
        excel.Cells(30, 8) = info.workorder
        excel.Cells(1, 3) = info.optictype
        excel.Cells(30, 2) = info.totaldefectlength
        excel.Cells(29, 2) = info.totaldefectarea
        excel.Cells(31, 2) = info.totaldefects

        excel.Cells(30, 3) = info.totalscratchlength
        excel.Cells(31, 3) = info.totalscratches
        excel.Cells(29, 3) = info.totaldefectarea - info.totalpitarea

        excel.Cells(29, 4) = info.totalpitarea
        excel.Cells(31, 4) = info.totalpits
        excel.Cells(30, 4) = info.totaldefectlength - info.totalscratchlength

        'If info.totaldefectncmr Then
        '    value = info.totaldefects
        '    excel.Cells(31, 1) = "**" & value & "**"
        'End If
        'If info.totalareancmr Then
        '    value = info.totaldefectarea
        '    excel.Cells(29, 1) = "**" & value & "**"
        'End If
        'If info.totaldefectlengthncmr Then
        '    value = info.totaldefectlength
        '    excel.Cells(30, 1) = "**" & value & "**"
        'Else
        'End If

    End Sub

    Public Sub ExportCEAMDS(ByRef template As String)


        Dim c As String
        Dim pname As String
        Dim fname As String
        Dim direct, imadir As String

        direct = System.Windows.Forms.Application.StartupPath
        imadir = direct & "\Images"


        c = System.Windows.Forms.Application.StartupPath
        pname = c & "\" & template

        Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
        Dim wBook As Microsoft.Office.Interop.Excel.Workbook
        Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim Rng As Microsoft.Office.Interop.Excel.Range
        Dim C1 As Object
        Dim C2 As Object

        fname = "I:\test.xls"

        wBook = excel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()

        'wBook.SaveAs()
        excel.Workbooks.Open(pname, , True)
        excel.Visible = True


        C1 = excel.Cells(2, 2)
        C2 = excel.Cells(5, 5)

        Rng = excel.Range("A1", "F19")



        Dim gr As Microsoft.Office.Interop.Excel.Shape


        c = excel.ActiveSheet.shapes.count
        Dim os As Microsoft.Office.Interop.Excel.Shapes

        os = excel.ActiveSheet.Shapes

        Dim i As Integer
        For i = 0 To os.Count - 1
            gr = os.Item(i)
            gr.Select()
        Next

        gr = os.Item(8)
        gr.Fill.UserPicture(imadir & "\current.bmp")

        ' Dim value As String
        Dim cs As Integer = 47
        Dim col As Integer
        col = 4

        excel.Cells(2, 1) = info.serialnumber
        excel.Cells(2, 13) = info.datestamp
        For i = 0 To DefectGrid.RowCount - 2




            excel.Cells(i + cs, col) = defects(i).width
            excel.Cells(i + cs, col + 1) = defects(i).length
            excel.Cells(i + cs, col - 1) = defects(i).description

            'excel.Cells(i + cs, col) = defects(i).x
            'excel.Cells(i + cs, col) = defects(i).y
            'excel.Cells(i + cs, col) = defects(i).angle



        Next




    End Sub

    Public Sub ExportCEAAMP(ByRef template As String)

        Dim c As String
        Dim pname As String
        Dim fname As String
        Dim direct, imadir As String

        direct = System.Windows.Forms.Application.StartupPath
        imadir = direct & "\Images"


        c = System.Windows.Forms.Application.StartupPath
        pname = c & "\Templates\" & template

        Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
        Dim wBook As Microsoft.Office.Interop.Excel.Workbook
        Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim Rng As Microsoft.Office.Interop.Excel.Range
        Dim C1 As Object
        Dim C2 As Object

        fname = "I:\test.xls"

        wBook = excel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()

        'wBook.SaveAs()
        excel.Workbooks.Open(pname, , True)
        excel.Visible = True


        C1 = excel.Cells(2, 2)
        C2 = excel.Cells(5, 5)

        Rng = excel.Range("A1", "F19")



        c = excel.ActiveSheet.shapes.count
    
        Dim os As Microsoft.Office.Interop.Excel.Shape
     
        os = excel.ActiveSheet.Shapes("Map")
        os.Fill.UserPicture(imadir & "\current.bmp")

        ' Dim value As String
        Dim cs As Integer = 46
        Dim col As Integer
        col = 4

        excel.Cells(2, 1) = info.serialnumber
        excel.Cells(2, 13) = info.datestamp
        For i = 0 To DefectGrid.RowCount - 2

            If i = 5 Then
                col = 8
                cs = cs - 5
            End If

            If i = 10 Then
                col = 4
                cs = cs + 7
            End If


            excel.Cells(i + cs, col) = defects(i).width
            excel.Cells(i + cs, col + 1) = defects(i).length
            excel.Cells(i + cs, col - 1) = defects(i).description

            'excel.Cells(i + cs, col) = defects(i).x
            'excel.Cells(i + cs, col) = defects(i).y
            'excel.Cells(i + cs, col) = defects(i).angle



        Next



        'Dim w, h As Integer
        'Dim bm2 As Bitmap

        'bm2 = Part.Image

        'w = bm2.Width
        'h = bm2.Height

        'Dim oh, ow As Integer
        'Dim dh, dw As Integer
        'Dim sf As Single

        'dh = 0
        'dw = 0

        'If w >= h Then
        '    sf = h / w
        '    w = os.Width
        '    h = os.Height * sf
        '    oh = os.Height
        '    dh = (oh - h) / 2
        'Else
        '    sf = w / h
        '    w = os.Width * sf
        '    h = os.Height
        '    ow = os.Width
        '    dw = (ow - w) / 2
        'End If

        'os.Width = w
        'os.Height = h
        'os.Top = os.Top + dh
        'os.Left = os.Left + dw

    End Sub

    Public Sub ExportExcel(ByRef bm As Bitmap, ByRef template As String)


        Dim c As String
        Dim pname As String
        Dim direct, imadir As String
        Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
        Dim wBook As Microsoft.Office.Interop.Excel.Workbook
        Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim Rng As Microsoft.Office.Interop.Excel.Range
        Dim C1 As Object
        Dim C2 As Object


        c = System.Windows.Forms.Application.StartupPath
        pname = c & "\Templates\" & template
        direct = System.Windows.Forms.Application.StartupPath
        imadir = direct & "\Images"
        wBook = excel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()

        excel.Workbooks.Open(pname, , True)
        excel.Visible = True


        C1 = excel.Cells(2, 2)
        C2 = excel.Cells(5, 5)

        Rng = excel.Range("A1", "F19")

        Dim os As Microsoft.Office.Interop.Excel.Shape
        Dim rs As Microsoft.Office.Core.MsoTriState

        os = excel.ActiveSheet.Shapes("Map")
        os.Fill.UserPicture(imadir & "\current.bmp")
        rs = os.LockAspectRatio

        If rs = Microsoft.Office.Core.MsoTriState.msoFalse Then

            Dim w, h As Integer
            Dim sf As Single

            w = bm.Width
            h = bm.Height

            Dim oh, ow As Integer
            Dim dh, dw As Integer

            dh = 0
            dw = 0

            If w >= h Then
                sf = h / w
                w = os.Width
                h = os.Height * sf
                oh = os.Height
                dh = (oh - h) / 2
            Else
                sf = w / h
                w = os.Width * sf
                h = os.Height
                ow = os.Width
                dw = (ow - w) / 2
            End If

            os.Width = w
            os.Height = h
            os.Top = os.Top + dh
            os.Left = os.Left + dw

        End If

        Dim cs As Integer = 34
        Dim value As String
        Dim rang As Microsoft.Office.Interop.Excel.Range
        Dim a As String = ""
        Dim tc() As Char
        ReDim tc(0)
        tc(0) = """"
        If Not info.inspector Is Nothing Then
            a = info.inspector.Trim(tc)
        End If
        rang = excel.Cells.Find("(DATE)")
        If Not rang Is Nothing Then
            excel.Cells(rang.Row, rang.Column) = info.datestamp
        End If
        rang = excel.Cells.Find("(SN)")
        If Not rang Is Nothing Then
            excel.Cells(rang.Row, rang.Column) = info.serialnumber
        End If
        rang = excel.Cells.Find("(LOC)")
        If Not rang Is Nothing Then
            excel.Cells(rang.Row, rang.Column) = info.snloc
        End If
        rang = excel.Cells.Find("(SIDE)")
        If Not rang Is Nothing Then
            excel.Cells(rang.Row, rang.Column) = info.side
        End If
        rang = excel.Cells.Find("(PT)")
        If Not rang Is Nothing Then
            excel.Cells(rang.Row, rang.Column) = info.optictype
        End If
        rang = excel.Cells.Find("(WO)")
        If Not rang Is Nothing Then
            excel.Cells(rang.Row, rang.Column) = info.workorder
        End If
        rang = excel.Cells.Find("(INSP)")
        If Not rang Is Nothing Then
            excel.Cells(rang.Row, rang.Column) = a
        End If
        rang = excel.Cells.Find("(SEQ)")
        If Not rang Is Nothing Then
            excel.Cells(rang.Row, rang.Column) = info.Operation
        End If
        rang = excel.Cells.Find("(TDL)")
        If Not rang Is Nothing Then
            excel.Cells(rang.Row, rang.Column) = info.totaldefectlength
        End If
        rang = excel.Cells.Find("(TDA)")
        If Not rang Is Nothing Then
            excel.Cells(rang.Row, rang.Column) = info.totaldefectarea
        End If
        rang = excel.Cells.Find("(TDC)")
        If Not rang Is Nothing Then
            excel.Cells(rang.Row, rang.Column) = info.totaldefects
        End If
        rang = excel.Cells.Find("(TSL)")
        If Not rang Is Nothing Then
            excel.Cells(rang.Row, rang.Column) = info.totalscratchlength
        End If
        rang = excel.Cells.Find("(TSC)")
        If Not rang Is Nothing Then
            excel.Cells(rang.Row, rang.Column) = info.totalscratches
        End If
        'rang = excel.Cells.Find("(TSA)")
        'If Not rang Is Nothing Then
        '    excel.Cells(rang.Row, rang.Column) = info.totaldefectarea - info.totalpitarea
        'End If

        'rang = excel.Cells.Find("(TPL)")
        'If Not rang Is Nothing Then
        '    excel.Cells(rang.Row, rang.Column) = info.totaldefectlength - info.totalscratchlength
        'End If

        rang = excel.Cells.Find("(TPC)")
        If Not rang Is Nothing Then
            excel.Cells(rang.Row, rang.Column) = info.totalpits
        End If

        rang = excel.Cells.Find("(TPA)")
        If Not rang Is Nothing Then
            excel.Cells(rang.Row, rang.Column) = info.totalpitarea
        End If

        Dim startrow As Integer
        Dim startcol As Integer
        Dim widthcol As Integer
        Dim lengthcol As Integer
        Dim xcol As Integer
        Dim ycol As Integer
        Dim angcol As Integer
        Dim areacol As Integer
        Dim desccol As Integer
        Dim comcol As Integer

        rang = excel.Cells.Find("(START)")
        If Not rang Is Nothing Then
            startrow = rang.Row
            startcol = rang.Column
        End If

        rang = excel.Cells.Find("(WID)")
        If Not rang Is Nothing Then
            widthcol = rang.Column
        Else
            widthcol = -1
        End If

        rang = excel.Cells.Find("(LEN)")
        If Not rang Is Nothing Then
            lengthcol = rang.Column
        Else
            lengthcol = -1
        End If

        rang = excel.Cells.Find("(POSX)")
        If Not rang Is Nothing Then
            xcol = rang.Column
        Else
            xcol = -1
        End If

        rang = excel.Cells.Find("(POSY)")
        If Not rang Is Nothing Then
            ycol = rang.Column
        Else
            ycol = -1
        End If

        rang = excel.Cells.Find("(ANG)")
        If Not rang Is Nothing Then
            angcol = rang.Column
        Else
            angcol = -1
        End If

        rang = excel.Cells.Find("(AREA)")
        If Not rang Is Nothing Then
            areacol = rang.Column
        Else
            areacol = -1
        End If

        rang = excel.Cells.Find("(DESC)")
        If Not rang Is Nothing Then
            desccol = rang.Column
        Else
            desccol = -1
        End If
        rang = excel.Cells.Find("(COM)")
        If Not rang Is Nothing Then
            comcol = rang.Column
        Else
            comcol = -1
        End If


        For i = 0 To DefectGrid.RowCount - 2

            value = defects(i).number
            If defects(i).exclude Then
                value = "[" & defects(i).number & "]"
            Else
            End If

            'If defects(i).ncmr Then
            '    value = "*" & value & "*"
            'End If

            excel.Cells(startrow + i, startcol) = value

            If widthcol <> -1 Then
                excel.Cells(startrow + i, widthcol) = defects(i).width
            End If
            If lengthcol <> -1 Then
                excel.Cells(startrow + i, lengthcol) = defects(i).length
            End If
            If xcol <> -1 Then
                excel.Cells(startrow + i, xcol) = defects(i).x
            End If
            If ycol <> -1 Then
                excel.Cells(startrow + i, ycol) = defects(i).y
            End If

            If angcol <> -1 Then
                excel.Cells(startrow + i, angcol) = defects(i).angle
            End If

            If areacol <> -1 Then
                excel.Cells(startrow + i, areacol) = defects(i).area
            End If

            If desccol <> -1 Then
                excel.Cells(startrow + i, desccol) = defects(i).description
            End If
            If comcol <> -1 Then
                excel.Cells(startrow + i, comcol) = defects(i).comment
            End If



        Next



        'If info.totaldefectncmr Then
        '    value = info.totaldefects
        '    excel.Cells(31, 1) = "**" & value & "**"
        'End If
        'If info.totalareancmr Then
        '    value = info.totaldefectarea
        '    excel.Cells(29, 1) = "**" & value & "**"
        'End If
        'If info.totaldefectlengthncmr Then
        '    value = info.totaldefectlength
        '    excel.Cells(30, 1) = "**" & value & "**"
        'Else
        'End If

    End Sub

    Private Sub SaveImageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveImageToolStripMenuItem.Click

        Dim b As Bitmap
        b = Part.Image
        b.Save("I:\test.bmp")

    End Sub


    Private Sub TextBox4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyCode = Keys.Enter Then
            UpdateMap()
        End If

    End Sub




    Private Sub TextBox5_Leave(ByVal sender As Object, ByVal e As System.EventArgs)

        UpdateMap()

    End Sub



    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        UpdateMap()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        UpdateMap()
    End Sub



    Private Sub CheckBox2_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        UpdateMap()
    End Sub

    Private Sub CheckBox1_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        UpdateMap()
    End Sub



    Private Sub Load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExprotInspectinoReportToolStripMenuItem.Click

        LoadFile()
        UpdateSpecs()
        UpdateMap()

        '  Dim sw As System.IO.StreamWriter

        '      sd.ShowDialog()
        '       sw = New System.IO.StreamWriter(sd.FileName)

        'Shell("i:\Documents and Settings\All Users\Start Menu\Programs\Microsoft Office\Microsoft Office Excel 2007.exe")


    End Sub






    Private Sub TextBox4_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateMap()
    End Sub



    Private Sub DefectGrid_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs)
        UpdateMap()
    End Sub

 

    Private Sub ComboBox1_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged


        UpdateSpecs()
        UpdateMap()

    End Sub

    Public Sub UpdateSpecs()

        specs.optictype = ComboBox1.Text

        SpecGrid.Item(1, 0).Value = speclist(ComboBox1.SelectedIndex).dimensions.width
        SpecGrid.Item(1, 1).Value = speclist(ComboBox1.SelectedIndex).dimensions.height
        SpecGrid.Item(1, 2).Value = speclist(ComboBox1.SelectedIndex).dimensions.shape
        SpecGrid.Item(1, 3).Value = speclist(ComboBox1.SelectedIndex).dimensions.cawidth
        SpecGrid.Item(1, 4).Value = speclist(ComboBox1.SelectedIndex).dimensions.caheight
        SpecGrid.Item(1, 5).Value = speclist(ComboBox1.SelectedIndex).dimensions.cacenterx
        SpecGrid.Item(1, 6).Value = speclist(ComboBox1.SelectedIndex).dimensions.cacentery
        SpecGrid.Item(1, 7).Value = speclist(ComboBox1.SelectedIndex).dimensions.cashape

        SpecGrid.Item(1, 8).Value = speclist(ComboBox1.SelectedIndex).surface.maxdefects
        SpecGrid.Item(1, 9).Value = speclist(ComboBox1.SelectedIndex).surface.maxdefectlength
        SpecGrid.Item(1, 10).Value = speclist(ComboBox1.SelectedIndex).surface.maxtotaldefectlength
        SpecGrid.Item(1, 11).Value = speclist(ComboBox1.SelectedIndex).surface.maxdefectwidth

        SpecGrid.Item(1, 12).Value = speclist(ComboBox1.SelectedIndex).surface.maxscratches
        SpecGrid.Item(1, 13).Value = speclist(ComboBox1.SelectedIndex).surface.maxscratchlength
        SpecGrid.Item(1, 14).Value = speclist(ComboBox1.SelectedIndex).surface.maxtotalscratchlength
        SpecGrid.Item(1, 15).Value = speclist(ComboBox1.SelectedIndex).surface.maxscratchwidth


        SpecGrid.Item(1, 16).Value = speclist(ComboBox1.SelectedIndex).surface.maxpits
        SpecGrid.Item(1, 17).Value = speclist(ComboBox1.SelectedIndex).surface.maxpitsize
        'SpecGrid.Item(1, 18).Value = speclist(ComboBox1.SelectedIndex).surface.maxtotalpitlength
        SpecGrid.Item(1, 18).Value = speclist(ComboBox1.SelectedIndex).surface.maxarea

        SpecGrid.Item(1, 19).Value = speclist(ComboBox1.SelectedIndex).surface.subapqty
        SpecGrid.Item(1, 20).Value = speclist(ComboBox1.SelectedIndex).surface.subapsize

        SpecGrid.Item(1, 21).Value = speclist(ComboBox1.SelectedIndex).surface.mindefectsize
        SpecGrid.Item(1, 22).Value = speclist(ComboBox1.SelectedIndex).surface.minscratchsize

        Dim i As Integer
        For i = 0 To SpecGrid.RowCount - 2
            If SpecGrid.Item(1, i).Value.ToString = Str(-1) Then
                SpecGrid.Item(1, i).Value = "N/A"
            End If
        Next

    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click

        Filenamebox.Text = ""
        DefectGrid.SelectAll()
        DefectGrid.Rows.Clear()
        DefectGrid.ClearSelection()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
        ComboBox5.Text = ""
        TextBox7.Text = ""
        TextBox13.Text = ""

        For i = 0 To SpecGrid.RowCount - 1
            SpecGrid.Item(1, i).Value = ""
            SpecGrid.Item(2, i).Value = ""
        Next

        UpdateMap()

    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click

        SaveFile()

        'Dim sw As System.IO.StreamWriter
        'Dim bm As Bitmap
        'Dim direct As String
        'Dim imadir As String
        'Dim fname As String
        'Dim iname As String


        'info.inspector = ComboBox2.Text
        'info.workorder = TextBox7.Text
        'info.serialnumber = TextBox13.Text
        'info.snloc = ComboBox5.Text
        'info.side = ComboBox4.Text
        'info.optictype = ComboBox1.Text


        'direct = System.Windows.Forms.Application.StartupPath & "\" & specs.optictype
        'System.IO.Directory.CreateDirectory(direct)
        'imadir = direct & "\Images"
        'System.IO.Directory.CreateDirectory(imadir)


        'fname = TextBox13.Text

        'fname = InputBox("Filename:", "Save File", fname)
        'sw = New System.IO.StreamWriter(direct & "\" & fname & ".sdm")

        'sw.WriteLine(System.DateTime.Today.ToString)
        'sw.WriteLine(info.inspector)
        'sw.WriteLine(info.workorder)
        'sw.WriteLine(info.serialnumber)
        'sw.WriteLine(info.snloc)
        'sw.WriteLine(info.side)
        'sw.WriteLine(info.optictype)
        'sw.WriteLine(DefectGrid.RowCount - 1)

        'For i = 0 To DefectGrid.RowCount - 2

        '    bm = Nothing
        '    sw.WriteLine(defects(i).number)
        '    sw.WriteLine(defects(i).width)
        '    sw.WriteLine(defects(i).length)
        '    sw.WriteLine(defects(i).x)
        '    sw.WriteLine(defects(i).y)
        '    sw.WriteLine(defects(i).angle)
        '    sw.WriteLine(defects(i).arcsf)
        '    bm = defects(i).image1
        '    'If Not (bm Is Nothing) Then
        '    If Not (bm Is nullimage) Then
        '        iname = fname & "-" & "image1-" & Format(i, "0") & ".bmp"
        '        bm = defects(i).image1
        '        bm.Save(imadir & "\" & iname)
        '        sw.WriteLine(iname)
        '    Else
        '        sw.WriteLine("null")
        '    End If

        '    sw.WriteLine(defects(i).description)
        '    sw.WriteLine(defects(i).comment)
        'Next

        'sw.Close()

    End Sub



    Private Sub DefectGrid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim mview As Bitmap = Nothing
        Dim fname As String
        Dim dial As System.Windows.Forms.OpenFileDialog

        If DefectGrid.CurrentCell.ColumnIndex = 8 Then

            dial = New System.Windows.Forms.OpenFileDialog
            dial.Filter = "*.bmp|*.bmp"
            dial.ShowDialog()

            If DialogResult <> Windows.Forms.DialogResult.Cancel Then

                fname = dial.FileName

                If fname.EndsWith(".bmp") Then
                    mview = New Bitmap(fname)
                End If
            End If

        End If

        If Not mview Is Nothing Then
            DefectGrid.CurrentCell.Value = mview.Clone
        End If
        mview = Nothing

        UpdateMap()

    End Sub

    Private Sub DefectGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        'If DefectGrid.CurrentCell.ColumnIndex = 8 Then

        '    If Not (Iform Is Nothing) Then
        '        If Iform.IsDisposed Then
        '            Iform = Nothing
        '        End If
        '    End If


        '    If Iform Is Nothing Then Iform = New Image(Me)

        '    Iform.PictureBox1.Image = DefectGrid.CurrentCell.Value.clone
        '    Iform.PictureBox1.Refresh()
        '    Iform.Show()

        '    'PictureBox2.Image = DefectGrid.CurrentCell.Value
        '    'PictureBox2.Refresh()
        'End If
    End Sub

    Private Sub DefectGrid_CellEndEdit1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        UpdateMap()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub ExportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToolStripMenuItem.Click

        CheckBox2.Checked = True
        UpdateMap()
        SaveFile(True)
  

    End Sub

    Private Sub DefectGrid_BorderStyleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DefectGrid.BorderStyleChanged

    End Sub

  




    Private Sub DefectGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DefectGrid.CellEndEdit


        UpdateMap()

        Dim outsideca As Boolean

        If DefectGrid.CurrentCell.ColumnIndex = 3 Or DefectGrid.CurrentCell.ColumnIndex = 5 Or DefectGrid.CurrentCell.ColumnIndex = 6 Then
            outsideca = CheckOut(DefectGrid.CurrentCell.RowIndex)
            defects(DefectGrid.CurrentCell.RowIndex).exclude = CheckOut(DefectGrid.CurrentCell.RowIndex)
            DefectGrid(1, DefectGrid.CurrentCell.RowIndex).Value = defects(DefectGrid.CurrentCell.RowIndex).exclude

        End If

        If DefectGrid.CurrentCell.ColumnIndex = 2 Then
            If defects(DefectGrid.CurrentCell.RowIndex).width < specs.mindefectsize Then
                defects(DefectGrid.CurrentCell.RowIndex).exclude = True
            Else
                defects(DefectGrid.CurrentCell.RowIndex).exclude = False
            End If

            If defects(DefectGrid.CurrentCell.RowIndex).width < specs.minscratchsize Then
                defects(DefectGrid.CurrentCell.RowIndex).exclude = True
            Else
                defects(DefectGrid.CurrentCell.RowIndex).exclude = False

            End If

            DefectGrid(1, DefectGrid.CurrentCell.RowIndex).Value = defects(DefectGrid.CurrentCell.RowIndex).exclude
        End If

        If DefectGrid.CurrentCell.ColumnIndex = 3 Then
            If DefectGrid.CurrentCell.Value >= 2 Then
                DefectGrid.Item(10, DefectGrid.CurrentCell.RowIndex).Value = "Scratch"
            Else
                DefectGrid.Item(10, DefectGrid.CurrentCell.RowIndex).Value = "Pit/Dig"
            End If
        End If



        UpdateMap()

 
    End Sub



    Private Sub SpecGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles SpecGrid.CellEndEdit

        UpdateMap()

    End Sub

 

    Private Sub DefectGrid_RowsRemoved1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DefectGrid.RowsRemoved
        '        ReDim defects(DefectGrid.RowCount - 1)
        UpdateMap()
    End Sub



    Private Sub SaveSpecificationTemplateToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveSpecificationTemplateToolStripMenuItem1.Click

        SaveSpecTemplate()
    End Sub


    Private Sub DefectGrid_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DefectGrid.CellMouseDoubleClick

        Dim fname As String
  
        If DefectGrid.CurrentCell.ColumnIndex = 9 Then

            fname = imagepath & "\" & DefectGrid.CurrentCell.Value
            Dim im As New Image(DefectGrid, fname)
            im.ShowDialog()

        End If


        UpdateMap()
    End Sub

   
    Private Sub DefectGrid_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DefectGrid.CellContentClick

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click

    End Sub

    Private Sub ImagePathToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImagePathToolStripMenuItem.Click


        Dim f As New FolderBrowserDialog
        Dim dr As DialogResult

        f.SelectedPath = mappath

        dr = f.ShowDialog
        If dr <> Windows.Forms.DialogResult.Cancel Then
            mappath = f.SelectedPath
        End If



    End Sub

    Private Sub ImageDirectoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImageDirectoryToolStripMenuItem.Click

        Dim f As New FolderBrowserDialog
        Dim dr As DialogResult

        f.SelectedPath = imagepath

        dr = f.ShowDialog
        If dr <> Windows.Forms.DialogResult.Cancel Then
            imagepath = f.SelectedPath
        End If


    End Sub

    Private Sub Part_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Part.Click


        Dim x As Integer
        Dim y As Integer

        x = Val(px)
        y = Val(py)

        If optic.width >= optic.height Then
            xres = optic.width / Part.Width
            yres = optic.width / Part.Height
        Else
            xres = optic.height / Part.Width
            yres = optic.height / Part.Height
        End If

        Dim n As Integer

        DefectGrid.Rows.Add()
        n = DefectGrid.Rows.Count
        DefectGrid.Item(0, n - 2).Value = n - 1
        DefectGrid.Item(2, n - 2).Value = 0.01
        DefectGrid.Item(3, n - 2).Value = 0.01

        DefectGrid.Item(5, n - 2).Value = x
        DefectGrid.Item(6, n - 2).Value = y
        DefectGrid.Item(10, n - 2).Value = "Pit/Dig"

        UpdateMap()

        Dim outsideca As Boolean

        outsideca = CheckOut(n - 2)
        defects(n - 2).exclude = CheckOut(n - 2)
        DefectGrid(1, n - 2).Value = defects(n - 2).exclude
        UpdateMap()

        DefectGrid.FirstDisplayedScrollingRowIndex = n - 2

    End Sub

    Private Sub Part_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Part.MouseMove

        Dim x As Integer
        Dim y As Integer

        x = e.X
        y = Part.Height - e.Y

        If optic.width >= optic.height Then
            xres = optic.width / Part.Width
            yres = optic.width / Part.Height
        Else
            xres = optic.height / Part.Width
            yres = optic.height / Part.Height
        End If

        px = (Int(x * xres))
        py = (Int(y * yres))

        Dim p1 As Pen
        p1 = New Pen(Color.Red)

        Dim gr As System.Drawing.Graphics
        gr = Part.CreateGraphics

        Dim f As Drawing.Image

        f = Part.Image

        gr.DrawImage(f, 0, 0, Part.Width, Part.Height)
        gr.DrawLine(p1, 0, e.Y, Part.Width, e.Y)
        gr.DrawLine(p1, e.X, 0, e.X, Part.Height)

        Dim fo As New Font("Arial", 8)
        Dim b As Brush
        Dim st As String
        Dim offsetx As Integer
        Dim offsety As Integer

        Dim k, t As Integer
        Dim r As Single
        r = gr.DpiX

        b = Brushes.Gray
        st = "(" & Str(px) & "," & Str(py) & ")"
        offsetx = 0
        offsety = 0
        If e.X > Part.Width / 2 Then
            k = Len(st)
            t = fo.Size
            offsetx = Len(st) * 5
        End If
        If e.Y > Part.Height / 2 Then
            k = Len(st)
            t = fo.Size
            offsety = 14
        End If
        gr.DrawString(st, fo, Brushes.Red, e.X - offsetx, e.Y - offsety)


    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click

    SaveFile(True,"current.map")
    End Sub

    Private Sub Gridx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Gridx.TextChanged

        UpdateMap()

    End Sub

    Private Sub Gridy_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Gridy.TextChanged
        UpdateMap()
    End Sub
End Class
