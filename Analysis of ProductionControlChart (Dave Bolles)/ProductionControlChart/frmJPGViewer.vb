Imports Microsoft.Office.Interop
Public Class frmJPGViewer
    Private moApp As Outlook.Application
    Private mbKillMe As Boolean = True
    Private Function fillEmailPart(ByVal pStrPart As String) As String
        Dim strRet As String = ""
        Dim i As Integer = 0
        Dim strConnector As String = ""
        For i = 0 To UBound(gArrEmail, 2)
            If gArrEmail(0, i).ToUpper = pStrPart.ToUpper Then
                gArrEmail(1, i) = gArrEmail(1, i).Replace("~SN", gSN)
                strRet = strRet & strConnector & gArrEmail(1, i)
                If strConnector = "" Then
                    Select Case pStrPart
                        Case "TO", "CC", "BCC"
                            strConnector = ";"
                        Case "SUBJECT"
                            strConnector = "-"
                        Case "BODY"
                            strConnector = vbCrLf
                        Case Else
                            strConnector = "-"
                    End Select
                End If
            End If
        Next i
exitFunction:
        fillEmailPart = strRet
    End Function
    Private Sub butEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butEmail.Click
        Dim oEmail As Outlook.MailItem
        Me.Cursor = Cursors.WaitCursor
        oEmail = DirectCast(moApp.CreateItem(Outlook.OlItemType.olMailItem), Outlook.MailItem)
        With oEmail
            .To = fillEmailPart("TO") '"bsilvert@zygo.com"
            .CC = fillEmailPart("CC") '"bsilvert@zygo.com"
            .Subject = fillEmailPart("SUBJECT") '"Test of Minitab!"
            .Body = fillEmailPart("BODY")
            '
            .BodyFormat = Outlook.OlBodyFormat.olFormatPlain
            '.Body = "body of email..."
            .Importance = Outlook.OlImportance.olImportanceNormal
            '.ReadReceiptRequested = True
            Call xAddAttachments(oEmail)
            '.Attachments.Add("c:\file.txt", Outlook.OlAttachmentType.olByValue)
            .Recipients.ResolveAll()
            .Save()
            .Display() 'Show the email message and allow for editing before sending  
            '.Send() 'You can automatically send the email without displaying it.       
            Me.Cursor = Cursors.Default
        End With
    End Sub
    Private Sub xAddAttachments(ByVal pMail As Outlook.MailItem)
        Dim i As Integer = 0
        Dim oText As System.Windows.Forms.TextBox

        For i = 0 To Me.Controls.Count - 1
            If Me.Controls(i).Name Like "Txt*" Then
                oText = Me.Controls(i)
                pMail.Attachments.Add(oText.Text, Outlook.OlAttachmentType.olByValue, 1)
            End If
        Next


    End Sub
    Private Sub frmJPGViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If mbKillMe = True Then
            If Not moApp Is Nothing Then
                moApp.Quit()
                moApp = Nothing
            End If
        End If
    End Sub

    Private Sub frmJPGViewer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            moApp = CType(GetObject(, "Outlook.Application"), Outlook.Application)
            mbKillMe = False
        Catch ex As Exception
            If moApp Is Nothing Then
                moApp = New Outlook.Application
                mbKillMe = True
            End If
        End Try
        If moApp Is Nothing Then
            MessageBox.Show("Outlook is not installed or available.", "Application Message", MessageBoxButtons.OK)
            Me.butEmail.Enabled = False
            Exit Sub
        End If
    End Sub

End Class