VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   10995
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   13635
   LinkTopic       =   "Form1"
   ScaleHeight     =   10995
   ScaleWidth      =   13635
   StartUpPosition =   3  'Windows Default
   Begin VB.PictureBox Picture1 
      AutoSize        =   -1  'True
      Height          =   5295
      Index           =   1
      Left            =   4200
      ScaleHeight     =   5235
      ScaleWidth      =   9195
      TabIndex        =   9
      Top             =   5520
      Width           =   9255
   End
   Begin VB.CommandButton cmdReset 
      Caption         =   "Reset"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   1560
      TabIndex        =   8
      Top             =   4320
      Width           =   1095
   End
   Begin VB.CommandButton cmdNext 
      Caption         =   "Next"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   360
      TabIndex        =   7
      Top             =   4320
      Width           =   1095
   End
   Begin VB.CommandButton cmdBack 
      Caption         =   "Back"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   2760
      TabIndex        =   6
      Top             =   4320
      Width           =   1095
   End
   Begin VB.FileListBox File1 
      Height          =   1650
      Index           =   1
      Left            =   240
      Pattern         =   "*.jpg"
      TabIndex        =   5
      Top             =   5520
      Width           =   3915
   End
   Begin VB.DriveListBox Drive1 
      Height          =   315
      Left            =   120
      TabIndex        =   4
      Top             =   120
      Width           =   3975
   End
   Begin VB.DirListBox Dir1 
      Height          =   1440
      Left            =   120
      TabIndex        =   3
      Top             =   480
      Width           =   3975
   End
   Begin VB.FileListBox File1 
      Height          =   1650
      Index           =   0
      Left            =   120
      Pattern         =   "*.jpg"
      TabIndex        =   2
      Top             =   2040
      Width           =   3915
   End
   Begin VB.PictureBox Picture1 
      AutoSize        =   -1  'True
      Height          =   5295
      Index           =   0
      Left            =   4200
      ScaleHeight     =   5235
      ScaleWidth      =   9195
      TabIndex        =   1
      Top             =   120
      Width           =   9255
   End
   Begin VB.CommandButton cmdExit 
      Caption         =   "Exit"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   1200
      TabIndex        =   0
      Top             =   8040
      Width           =   1935
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub cmdBack_Click()
Dim FullFileName As String
Dim currIndex As Integer
Dim i As Integer

    On Error GoTo ErrorSkip
   
    For i = 0 To 1
        currIndex = File1(i).ListIndex
        currIndex = currIndex - 1
        If currIndex < 0 Then
            currIndex = 0
        End If
        File1(i).ListIndex = currIndex
        FullFileName = Dir1.Path & "\" & File1(i).FileName
        Picture1(i).Picture = LoadPicture(FullFileName)
   Next i
   
   Exit Sub

ErrorSkip:
   Form1.Caption = "Couldn't open " & FullFileName
   Resume Next
End Sub

Private Sub cmdNext_Click()
Dim FullFileName As String
Dim currIndex As Integer
Dim i As Integer

    On Error GoTo ErrorSkip
   
    For i = 0 To 1
        currIndex = File1(i).ListIndex
        currIndex = currIndex + 1
        If currIndex > File1(i).ListCount - 1 Then
            currIndex = File1(i).ListCount - 1
        End If
        File1(i).ListIndex = currIndex
        FullFileName = Dir1.Path & "\" & File1(i).FileName
        Picture1(i).Picture = LoadPicture(FullFileName)
    Next i
   
   Exit Sub

ErrorSkip:
   Form1.Caption = "Couldn't open " & FullFileName
   Resume Next
   
End Sub

Private Sub cmdReset_Click()
Dim FullFileName As String
Dim currIndex As Integer
Dim i As Integer

    On Error GoTo ErrorSkip
   
    For i = 0 To 1
        File1(i).ListIndex = 0
        FullFileName = Dir1.Path & "\" & File1(i).FileName
        Picture1(i).Picture = LoadPicture(FullFileName)
    Next i
   
   Exit Sub

ErrorSkip:
   Form1.Caption = "Couldn't open " & FullFileName
   Resume Next
End Sub

Private Sub Drive1_Change()
Dim i As Integer

    Dir1.Path = Drive1.Drive
    
    For i = 0 To 1
        File1(i).Path = Dir1.Path
    Next i
End Sub

Private Sub File1_Click(Index As Integer)
   On Error GoTo ErrorSkip
   Dim FullFileName As String
   
   FullFileName = Dir1.Path & "\" & File1(Index).FileName
   Picture1(Index).Picture = LoadPicture(FullFileName)
   Form1.Caption = FullFileName
   
   Exit Sub

ErrorSkip:
   Form1.Caption = "Couldn't open " & FullFileName
   Resume Next
End Sub

'Initialization.
'We could do this in the properties box for each widget
Private Sub Form_Load()
Dim i As Integer

    Dir1.Path = App.Path
    For i = 0 To 1
        File1(i).Path = Dir1.Path
    Next i
    
    File1(0).Pattern = "*Eng*.jpg"
    File1(1).Pattern = "*Qual*.jpg"
    
        
End Sub

Private Sub cmdExit_Click()
    End
End Sub


'Set the directory, and make the FileListBox reflect that path
Private Sub Dir1_Change()
Dim i As Integer

    For i = 0 To 1
        File1(i).Path = Dir1.Path
        'Debug.Print "Path: " & File1(i).Path
    Next i

End Sub

