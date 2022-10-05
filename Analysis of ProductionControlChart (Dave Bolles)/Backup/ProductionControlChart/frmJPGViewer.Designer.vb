<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJPGViewer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.butEmail = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'butEmail
        '
        Me.butEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butEmail.Location = New System.Drawing.Point(725, 12)
        Me.butEmail.Name = "butEmail"
        Me.butEmail.Size = New System.Drawing.Size(86, 23)
        Me.butEmail.TabIndex = 0
        Me.butEmail.Text = "EMAIL"
        Me.butEmail.UseVisualStyleBackColor = True
        '
        'frmJPGViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(823, 601)
        Me.Controls.Add(Me.butEmail)
        Me.Name = "frmJPGViewer"
        Me.Text = "frmJPGViewer"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents butEmail As System.Windows.Forms.Button
End Class
