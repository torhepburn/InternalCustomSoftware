<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class Form1
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents _Picture1_1 As System.Windows.Forms.PictureBox
	Public WithEvents cmdReset As System.Windows.Forms.Button
	Public WithEvents cmdNext As System.Windows.Forms.Button
	Public WithEvents cmdBack As System.Windows.Forms.Button
	Public WithEvents _File1_1 As Microsoft.VisualBasic.Compatibility.VB6.FileListBox
	Public WithEvents Drive1 As Microsoft.VisualBasic.Compatibility.VB6.DriveListBox
	Public WithEvents Dir1 As Microsoft.VisualBasic.Compatibility.VB6.DirListBox
	Public WithEvents _File1_0 As Microsoft.VisualBasic.Compatibility.VB6.FileListBox
	Public WithEvents _Picture1_0 As System.Windows.Forms.PictureBox
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents File1 As Microsoft.VisualBasic.Compatibility.VB6.FileListBoxArray
	Public WithEvents Picture1 As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me._Picture1_1 = New System.Windows.Forms.PictureBox
		Me.cmdReset = New System.Windows.Forms.Button
		Me.cmdNext = New System.Windows.Forms.Button
		Me.cmdBack = New System.Windows.Forms.Button
		Me._File1_1 = New Microsoft.VisualBasic.Compatibility.VB6.FileListBox
		Me.Drive1 = New Microsoft.VisualBasic.Compatibility.VB6.DriveListBox
		Me.Dir1 = New Microsoft.VisualBasic.Compatibility.VB6.DirListBox
		Me._File1_0 = New Microsoft.VisualBasic.Compatibility.VB6.FileListBox
		Me._Picture1_0 = New System.Windows.Forms.PictureBox
		Me.cmdExit = New System.Windows.Forms.Button
		Me.File1 = New Microsoft.VisualBasic.Compatibility.VB6.FileListBoxArray(components)
		Me.Picture1 = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.File1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "Form1"
		Me.ClientSize = New System.Drawing.Size(909, 733)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "Form1"
		Me._Picture1_1.Size = New System.Drawing.Size(617, 353)
		Me._Picture1_1.Location = New System.Drawing.Point(280, 368)
		Me._Picture1_1.TabIndex = 9
		Me._Picture1_1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._Picture1_1.Dock = System.Windows.Forms.DockStyle.None
		Me._Picture1_1.BackColor = System.Drawing.SystemColors.Control
		Me._Picture1_1.CausesValidation = True
		Me._Picture1_1.Enabled = True
		Me._Picture1_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Picture1_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._Picture1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Picture1_1.TabStop = True
		Me._Picture1_1.Visible = True
		Me._Picture1_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
		Me._Picture1_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._Picture1_1.Name = "_Picture1_1"
		Me.cmdReset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdReset.Text = "Reset"
		Me.cmdReset.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdReset.Size = New System.Drawing.Size(73, 33)
		Me.cmdReset.Location = New System.Drawing.Point(104, 288)
		Me.cmdReset.TabIndex = 8
		Me.cmdReset.BackColor = System.Drawing.SystemColors.Control
		Me.cmdReset.CausesValidation = True
		Me.cmdReset.Enabled = True
		Me.cmdReset.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdReset.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdReset.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdReset.TabStop = True
		Me.cmdReset.Name = "cmdReset"
		Me.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdNext.Text = "Next"
		Me.cmdNext.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdNext.Size = New System.Drawing.Size(73, 33)
		Me.cmdNext.Location = New System.Drawing.Point(24, 288)
		Me.cmdNext.TabIndex = 7
		Me.cmdNext.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNext.CausesValidation = True
		Me.cmdNext.Enabled = True
		Me.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNext.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNext.TabStop = True
		Me.cmdNext.Name = "cmdNext"
		Me.cmdBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdBack.Text = "Back"
		Me.cmdBack.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdBack.Size = New System.Drawing.Size(73, 33)
		Me.cmdBack.Location = New System.Drawing.Point(184, 288)
		Me.cmdBack.TabIndex = 6
		Me.cmdBack.BackColor = System.Drawing.SystemColors.Control
		Me.cmdBack.CausesValidation = True
		Me.cmdBack.Enabled = True
		Me.cmdBack.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdBack.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdBack.TabStop = True
		Me.cmdBack.Name = "cmdBack"
		Me._File1_1.Size = New System.Drawing.Size(261, 110)
		Me._File1_1.Location = New System.Drawing.Point(16, 368)
		Me._File1_1.Pattern = "*.jpg"
		Me._File1_1.TabIndex = 5
		Me._File1_1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._File1_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._File1_1.Archive = True
		Me._File1_1.BackColor = System.Drawing.SystemColors.Window
		Me._File1_1.CausesValidation = True
		Me._File1_1.Enabled = True
		Me._File1_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._File1_1.Hidden = False
		Me._File1_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._File1_1.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me._File1_1.Normal = True
		Me._File1_1.ReadOnly = True
		Me._File1_1.System = False
		Me._File1_1.TabStop = True
		Me._File1_1.TopIndex = 0
		Me._File1_1.Visible = True
		Me._File1_1.Name = "_File1_1"
		Me.Drive1.Size = New System.Drawing.Size(265, 21)
		Me.Drive1.Location = New System.Drawing.Point(8, 8)
		Me.Drive1.TabIndex = 4
		Me.Drive1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Drive1.BackColor = System.Drawing.SystemColors.Window
		Me.Drive1.CausesValidation = True
		Me.Drive1.Enabled = True
		Me.Drive1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Drive1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Drive1.TabStop = True
		Me.Drive1.Visible = True
		Me.Drive1.Name = "Drive1"
		Me.Dir1.Size = New System.Drawing.Size(265, 96)
		Me.Dir1.Location = New System.Drawing.Point(8, 32)
		Me.Dir1.TabIndex = 3
		Me.Dir1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Dir1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Dir1.BackColor = System.Drawing.SystemColors.Window
		Me.Dir1.CausesValidation = True
		Me.Dir1.Enabled = True
		Me.Dir1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Dir1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Dir1.TabStop = True
		Me.Dir1.Visible = True
		Me.Dir1.Name = "Dir1"
		Me._File1_0.Size = New System.Drawing.Size(261, 110)
		Me._File1_0.Location = New System.Drawing.Point(8, 136)
		Me._File1_0.Pattern = "*.jpg"
		Me._File1_0.TabIndex = 2
		Me._File1_0.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._File1_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._File1_0.Archive = True
		Me._File1_0.BackColor = System.Drawing.SystemColors.Window
		Me._File1_0.CausesValidation = True
		Me._File1_0.Enabled = True
		Me._File1_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._File1_0.Hidden = False
		Me._File1_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._File1_0.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me._File1_0.Normal = True
		Me._File1_0.ReadOnly = True
		Me._File1_0.System = False
		Me._File1_0.TabStop = True
		Me._File1_0.TopIndex = 0
		Me._File1_0.Visible = True
		Me._File1_0.Name = "_File1_0"
		Me._Picture1_0.Size = New System.Drawing.Size(617, 353)
		Me._Picture1_0.Location = New System.Drawing.Point(280, 8)
		Me._Picture1_0.TabIndex = 1
		Me._Picture1_0.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._Picture1_0.Dock = System.Windows.Forms.DockStyle.None
		Me._Picture1_0.BackColor = System.Drawing.SystemColors.Control
		Me._Picture1_0.CausesValidation = True
		Me._Picture1_0.Enabled = True
		Me._Picture1_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Picture1_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._Picture1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Picture1_0.TabStop = True
		Me._Picture1_0.Visible = True
		Me._Picture1_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
		Me._Picture1_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._Picture1_0.Name = "_Picture1_0"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "Exit"
		Me.cmdExit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdExit.Size = New System.Drawing.Size(129, 33)
		Me.cmdExit.Location = New System.Drawing.Point(80, 536)
		Me.cmdExit.TabIndex = 0
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.TabStop = True
		Me.cmdExit.Name = "cmdExit"
		Me.Controls.Add(_Picture1_1)
		Me.Controls.Add(cmdReset)
		Me.Controls.Add(cmdNext)
		Me.Controls.Add(cmdBack)
		Me.Controls.Add(_File1_1)
		Me.Controls.Add(Drive1)
		Me.Controls.Add(Dir1)
		Me.Controls.Add(_File1_0)
		Me.Controls.Add(_Picture1_0)
		Me.Controls.Add(cmdExit)
		Me.File1.SetIndex(_File1_1, CType(1, Short))
		Me.File1.SetIndex(_File1_0, CType(0, Short))
		Me.Picture1.SetIndex(_Picture1_1, CType(1, Short))
		Me.Picture1.SetIndex(_Picture1_0, CType(0, Short))
		CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.File1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class