Option Strict Off
Option Explicit On
Friend Class Form1
	Inherits System.Windows.Forms.Form
	
	Private Sub cmdBack_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBack.Click
		Dim FullFileName As String
		Dim currIndex As Short
		Dim i As Short
		
		On Error GoTo ErrorSkip
		
		For i = 0 To 1
			currIndex = File1(i).SelectedIndex
			currIndex = currIndex - 1
			If currIndex < 0 Then
				currIndex = 0
			End If
			File1(i).SelectedIndex = currIndex
			FullFileName = Dir1.Path & "\" & File1(i).FileName
			Picture1(i).Image = System.Drawing.Image.FromFile(FullFileName)
		Next i
		
		Exit Sub
		
ErrorSkip: 
		Me.Text = "Couldn't open " & FullFileName
		Resume Next
	End Sub
	
	Private Sub cmdNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNext.Click
		Dim FullFileName As String
		Dim currIndex As Short
		Dim i As Short
		
		On Error GoTo ErrorSkip
		
		For i = 0 To 1
			currIndex = File1(i).SelectedIndex
			currIndex = currIndex + 1
			If currIndex > File1(i).Items.Count - 1 Then
				currIndex = File1(i).Items.Count - 1
			End If
			File1(i).SelectedIndex = currIndex
			FullFileName = Dir1.Path & "\" & File1(i).FileName
			Picture1(i).Image = System.Drawing.Image.FromFile(FullFileName)
		Next i
		
		Exit Sub
		
ErrorSkip: 
		Me.Text = "Couldn't open " & FullFileName
		Resume Next
		
	End Sub
	
	Private Sub cmdReset_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdReset.Click
		Dim FullFileName As String
		Dim currIndex As Short
		Dim i As Short
		
		On Error GoTo ErrorSkip
		
		For i = 0 To 1
			File1(i).SelectedIndex = 0
			FullFileName = Dir1.Path & "\" & File1(i).FileName
			Picture1(i).Image = System.Drawing.Image.FromFile(FullFileName)
		Next i
		
		Exit Sub
		
ErrorSkip: 
		Me.Text = "Couldn't open " & FullFileName
		Resume Next
	End Sub
	
	Private Sub Drive1_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Drive1.SelectedIndexChanged
		Dim i As Short
		
		Dir1.Path = Drive1.Drive
		
		For i = 0 To 1
			File1(i).Path = Dir1.Path
		Next i
	End Sub
	
	Private Sub File1_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles File1.SelectedIndexChanged
		Dim Index As Short = File1.GetIndex(eventSender)
		On Error GoTo ErrorSkip
		Dim FullFileName As String
		
		FullFileName = Dir1.Path & "\" & File1(Index).FileName
		Picture1(Index).Image = System.Drawing.Image.FromFile(FullFileName)
		Me.Text = FullFileName
		
		Exit Sub
		
ErrorSkip: 
		Me.Text = "Couldn't open " & FullFileName
		Resume Next
	End Sub
	
	'Initialization.
	'We could do this in the properties box for each widget
	Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim i As Short
		
		Dir1.Path = My.Application.Info.DirectoryPath
		For i = 0 To 1
			File1(i).Path = Dir1.Path
		Next i
		
		File1(0).Pattern = "*Eng*.jpg"
		File1(1).Pattern = "*Qual*.jpg"
		
		
	End Sub
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
		End
	End Sub
	
	
	'Set the directory, and make the FileListBox reflect that path
	Private Sub Dir1_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Dir1.Change
		Dim i As Short
		
		For i = 0 To 1
			File1(i).Path = Dir1.Path
			'Debug.Print "Path: " & File1(i).Path
		Next i
		
	End Sub
End Class