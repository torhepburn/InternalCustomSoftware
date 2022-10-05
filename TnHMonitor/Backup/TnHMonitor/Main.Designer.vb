<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.components = New System.ComponentModel.Container
        Me.StartButton = New System.Windows.Forms.Button
        Me.StopButton = New System.Windows.Forms.Button
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.txtTime = New System.Windows.Forms.TextBox
        Me.lblTime = New System.Windows.Forms.Label
        Me.lblLastIP = New System.Windows.Forms.Label
        Me.txtLastIP = New System.Windows.Forms.TextBox
        Me.txtTemp = New System.Windows.Forms.TextBox
        Me.lblTemp = New System.Windows.Forms.Label
        Me.txtHum = New System.Windows.Forms.TextBox
        Me.lblHum = New System.Windows.Forms.Label
        Me.cbRead_Location = New System.Windows.Forms.ComboBox
        Me.LupReadLocationsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TandHDataSet = New TnHMonitor.TandHDataSet
        Me.Lup_Read_LocationsTableAdapter = New TnHMonitor.TandHDataSetTableAdapters.lup_Read_LocationsTableAdapter
        Me.Label1 = New System.Windows.Forms.Label
        Me.Process1 = New System.Diagnostics.Process
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LupReadLocationsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TandHDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(209, 12)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(82, 33)
        Me.StartButton.TabIndex = 0
        Me.StartButton.Text = "Start"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'StopButton
        '
        Me.StopButton.Location = New System.Drawing.Point(297, 12)
        Me.StopButton.Name = "StopButton"
        Me.StopButton.Size = New System.Drawing.Size(82, 33)
        Me.StopButton.TabIndex = 1
        Me.StopButton.Text = "Stop"
        Me.StopButton.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(12, 68)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(949, 510)
        Me.DataGridView2.TabIndex = 2
        '
        'txtTime
        '
        Me.txtTime.BackColor = System.Drawing.SystemColors.Control
        Me.txtTime.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTime.Location = New System.Drawing.Point(409, 25)
        Me.txtTime.Name = "txtTime"
        Me.txtTime.Size = New System.Drawing.Size(130, 13)
        Me.txtTime.TabIndex = 3
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Location = New System.Drawing.Point(406, 9)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(67, 13)
        Me.lblTime.TabIndex = 4
        Me.lblTime.Text = "Time Check:"
        '
        'lblLastIP
        '
        Me.lblLastIP.AutoSize = True
        Me.lblLastIP.Location = New System.Drawing.Point(542, 9)
        Me.lblLastIP.Name = "lblLastIP"
        Me.lblLastIP.Size = New System.Drawing.Size(43, 13)
        Me.lblLastIP.TabIndex = 5
        Me.lblLastIP.Text = "Last IP:"
        '
        'txtLastIP
        '
        Me.txtLastIP.BackColor = System.Drawing.SystemColors.Control
        Me.txtLastIP.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLastIP.Location = New System.Drawing.Point(545, 25)
        Me.txtLastIP.Name = "txtLastIP"
        Me.txtLastIP.Size = New System.Drawing.Size(100, 13)
        Me.txtLastIP.TabIndex = 6
        '
        'txtTemp
        '
        Me.txtTemp.BackColor = System.Drawing.SystemColors.Control
        Me.txtTemp.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTemp.Location = New System.Drawing.Point(656, 25)
        Me.txtTemp.Name = "txtTemp"
        Me.txtTemp.Size = New System.Drawing.Size(54, 13)
        Me.txtTemp.TabIndex = 8
        '
        'lblTemp
        '
        Me.lblTemp.AutoSize = True
        Me.lblTemp.Location = New System.Drawing.Point(653, 9)
        Me.lblTemp.Name = "lblTemp"
        Me.lblTemp.Size = New System.Drawing.Size(60, 13)
        Me.lblTemp.TabIndex = 7
        Me.lblTemp.Text = "Last Temp:"
        '
        'txtHum
        '
        Me.txtHum.BackColor = System.Drawing.SystemColors.Control
        Me.txtHum.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtHum.Location = New System.Drawing.Point(716, 25)
        Me.txtHum.Name = "txtHum"
        Me.txtHum.Size = New System.Drawing.Size(54, 13)
        Me.txtHum.TabIndex = 10
        '
        'lblHum
        '
        Me.lblHum.AutoSize = True
        Me.lblHum.Location = New System.Drawing.Point(713, 9)
        Me.lblHum.Name = "lblHum"
        Me.lblHum.Size = New System.Drawing.Size(55, 13)
        Me.lblHum.TabIndex = 9
        Me.lblHum.Text = "Last Hum:"
        '
        'cbRead_Location
        '
        Me.cbRead_Location.DataSource = Me.LupReadLocationsBindingSource
        Me.cbRead_Location.DisplayMember = "Read_Location"
        Me.cbRead_Location.FormattingEnabled = True
        Me.cbRead_Location.Location = New System.Drawing.Point(12, 28)
        Me.cbRead_Location.Name = "cbRead_Location"
        Me.cbRead_Location.Size = New System.Drawing.Size(154, 21)
        Me.cbRead_Location.TabIndex = 11
        Me.cbRead_Location.ValueMember = "Read_Location"
        '
        'LupReadLocationsBindingSource
        '
        Me.LupReadLocationsBindingSource.DataMember = "lup_Read_Locations"
        Me.LupReadLocationsBindingSource.DataSource = Me.TandHDataSet
        '
        'TandHDataSet
        '
        Me.TandHDataSet.DataSetName = "TandHDataSet"
        Me.TandHDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Lup_Read_LocationsTableAdapter
        '
        Me.Lup_Read_LocationsTableAdapter.ClearBeforeFill = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Read for Location:"
        '
        'Process1
        '
        Me.Process1.StartInfo.Domain = ""
        Me.Process1.StartInfo.LoadUserProfile = False
        Me.Process1.StartInfo.Password = Nothing
        Me.Process1.StartInfo.StandardErrorEncoding = Nothing
        Me.Process1.StartInfo.StandardOutputEncoding = Nothing
        Me.Process1.StartInfo.UserName = ""
        Me.Process1.SynchronizingObject = Me
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(973, 590)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbRead_Location)
        Me.Controls.Add(Me.txtHum)
        Me.Controls.Add(Me.lblHum)
        Me.Controls.Add(Me.txtTemp)
        Me.Controls.Add(Me.lblTemp)
        Me.Controls.Add(Me.txtLastIP)
        Me.Controls.Add(Me.lblLastIP)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.txtTime)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.StopButton)
        Me.Controls.Add(Me.StartButton)
        Me.Name = "Main"
        Me.Text = "T & H Monitor"
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LupReadLocationsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TandHDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents StopButton As System.Windows.Forms.Button
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents txtTime As System.Windows.Forms.TextBox
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents lblLastIP As System.Windows.Forms.Label
    Friend WithEvents txtLastIP As System.Windows.Forms.TextBox
    Friend WithEvents txtTemp As System.Windows.Forms.TextBox
    Friend WithEvents lblTemp As System.Windows.Forms.Label
    Friend WithEvents txtHum As System.Windows.Forms.TextBox
    Friend WithEvents lblHum As System.Windows.Forms.Label
    Friend WithEvents cbRead_Location As System.Windows.Forms.ComboBox
    Friend WithEvents TandHDataSet As TnHMonitor.TandHDataSet
    Friend WithEvents LupReadLocationsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Lup_Read_LocationsTableAdapter As TnHMonitor.TandHDataSetTableAdapters.lup_Read_LocationsTableAdapter
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Process1 As System.Diagnostics.Process

End Class
