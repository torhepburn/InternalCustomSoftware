Imports Zygo.UI
Imports Dashweb.Core.UI.Common
Imports System
Imports System.Data.SqlClient
Imports DashWeb.Core.Maintenance.Common

Namespace Zygo.Maintenance

    Partial Class AdministerEquipment
        Inherits System.Web.UI.Page
        Protected WithEvents EquipmentHistoryDataGrid As ZygoControls.DataViewDataGrid


#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.ResponseLabel.Text = ""
            Me.AdministerEquipmentLabel.Text = "Maintenance - Administer Equipment"
            If Not IsPostBack Then
                BindGrid()
            End If

        End Sub

        Public Sub SortList(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
            BindGrid()
        End Sub

        Public Sub PageList(ByVal sender As Object, ByVal e As DataGridPageChangedEventArgs)
            Me.AdministerMachinesDataGrid.CurrentPageIndex = e.NewPageIndex
            BindGrid()
        End Sub


        Sub BindGrid()
            Dim cn As New SqlConnection(DashWeb.Core.UI.Common.DBConnString)
            cn.ConnectionString = DashWeb.Core.UI.Common.DBConnString
            If (NumRows.Text Is Nothing Or Not Char.IsNumber(NumRows.Text)) Then
                NumRows.Text = "25"
            End If
            'Get Equipment Info
            Dim cmd As SqlCommand
            cmd = cn.CreateCommand()

            Try
                Dim FilterInfo As String
                FilterInfo = ""
                '   ResponseLabel.Text = "*" & FilterDocNumber.Text
                If Not FilterMachine.Text Is Nothing Then
                    If Len(Trim(FilterMachine.Text)) > 0 Then
                        FilterInfo = " where Machine like '%" & FilterMachine.Text & "%' "
                    End If
                End If
                If Not FilterEngineer.Text Is Nothing Then
                    If Len(Trim(FilterEngineer.Text)) > 0 Then
                        If Len(Trim(FilterInfo)) > 0 Then
                            FilterInfo = FilterInfo & " and EngineerName like '%" & FilterEngineer.Text & "%' "
                        Else
                            FilterInfo = " where EngineerName like '%" & FilterEngineer.Text & "%' "
                        End If
                    End If
                End If
                If Not FilterRandM.Text Is Nothing Then
                    If Len(Trim(FilterRandM.Text)) > 0 Then
                        If Len(Trim(FilterInfo)) > 0 Then
                            FilterInfo = FilterInfo & " and RandMName like '%" & FilterRandM.Text & "%' "
                        Else
                            FilterInfo = " where (RandMName like '%" & FilterRandM.Text & "%' or RandMName like '%" & FilterRandM.Text & "%')"
                        End If
                    End If
                End If

                cmd.CommandText = "select * from [Maintenance - Machine] " & FilterInfo & "order by Machine"
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet()
                cn.Open()
                da.Fill(ds)

                Dim dv As DataView = ds.Tables(0).DefaultView
                Me.AdministerMachinesDataGrid.DataSource = dv
                Me.AdministerMachinesDataGrid.PageSize = NumRows.Text
                Me.AdministerMachinesDataGrid.DataBind()

            Catch ex As Exception
                Me.ResponseLabel.Text = ex.Message
            Finally
                If Not cn Is Nothing AndAlso cn.State = ConnectionState.Open Then cn.Close()
            End Try

        End Sub


        Private Sub AddEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim t_userid As Int32
            t_userid = GetUser().UserID

            Dim cn As New SqlConnection(DashWeb.Core.UI.Common.DBConnString)
            Dim sql As String = Nothing
            'sql = String.Format("insert into maintenance ([Date], Operator, Machine, Status) values (getdate()," & t_userid & " , " & Me.MachineIndex.Text & ",1)")
            Try
                Dim cmd As SqlCommand = cn.CreateCommand()
                cmd.CommandText = sql
                cn.Open()
                Dim num As Integer = cmd.ExecuteNonQuery()
                BindGrid()
            Catch ex As Exception
                Me.ResponseLabel.BackColor = Color.Red
                Me.ResponseLabel.ForeColor = Color.White
                Me.ResponseLabel.Text = ex.Message
            Finally
                If Not cn Is Nothing AndAlso cn.State = ConnectionState.Open Then cn.Close()
            End Try

        End Sub

        Sub EquipmentStatusDataGrid_Edit(ByVal sender As Object, ByVal e As DataGridCommandEventArgs)
            'As a bound column -> t_username = e.Item.Cells(2).Text
            If GetUser().CheckRole(DashWeb.Core.Authentication.DashWebAdmin) Or GetUser().CheckRole(DashWeb.Core.Authentication.FacilitiesAdmin) Then
                AdministerMachinesDataGrid.EditItemIndex = e.Item.ItemIndex
                BindGrid()
            Else
                Me.ResponseLabel.BackColor = Color.Red
                Me.ResponseLabel.ForeColor = Color.White
                Me.ResponseLabel.Text = "<em>You do not have authority to administer machines.</em>"
            End If
        End Sub

        Sub EquipmentStatusDataGrid_Cancel(ByVal sender As Object, ByVal e As DataGridCommandEventArgs)
            AdministerMachinesDataGrid.EditItemIndex = -1
            Me.ResponseLabel.BackColor = Color.Red
            Me.ResponseLabel.ForeColor = Color.White
            Me.ResponseLabel.Text = "<em>Record Update Canceled by User</em>"
            BindGrid()
        End Sub


        Sub EquipmentStatusDataGrid_Update(ByVal sender As Object, ByVal e As DataGridCommandEventArgs)
            Dim cn As New SqlConnection(DashWeb.Core.UI.Common.DBConnString)
            Dim t_StatusIndex As String
            Dim t_Status As String
            Dim t_Machine As String
            Dim t_MachineIndex As String
            Dim t_RandMName As String
            Dim t_RandMIndex As String
            Dim t_EngineerName As String
            Dim t_EngineerIndex As String
            Dim t_DepartmentIndex As String

            t_StatusIndex = CType(e.Item.FindControl("e_StatusList"), DropDownList).SelectedItem.Value
            t_Status = CType(e.Item.FindControl("e_StatusList"), DropDownList).SelectedItem.Text
            t_MachineIndex = e.Item.Cells(6).Text
            t_RandMIndex = CType(e.Item.FindControl("e_RandMName"), DropDownList).SelectedItem.Value
            t_EngineerIndex = CType(e.Item.FindControl("e_EngineerName"), DropDownList).SelectedItem.Value

            t_Machine = Trim(CType(e.Item.FindControl("e_Machine"), TextBox).Text)
            t_RandMName = CType(e.Item.FindControl("e_RandMName"), DropDownList).SelectedItem.Text
            t_EngineerName = CType(e.Item.FindControl("e_EngineerName"), DropDownList).SelectedItem.Text
            t_DepartmentIndex = CType(e.Item.FindControl("e_Department"), DropDownList).SelectedItem.Value
            't_Comments = Trim(CType(e.Item.FindControl("Comments"), TextBox).Text)

            If (Len(t_Machine) = 0) Then
                Me.ResponseLabel.BackColor = Color.Red
                Me.ResponseLabel.ForeColor = Color.White
                Me.ResponseLabel.Text = "Please fill out all white fields!"
            Else


                Try
                    Dim cmd As SqlCommand = cn.CreateCommand()
                    Dim sql As String
                    t_Machine = t_Machine.Replace("'", "''")
                    sql = String.Format("update maintenancemachine set Status=" & t_StatusIndex & ", Machine='" & t_Machine & "', RandM=" & t_RandMIndex & ", Engineer=" & t_EngineerIndex & ", Department=" & t_DepartmentIndex & " where MachineIndex = " & t_MachineIndex)
                    'sql = ("Insert into maintenancemachine (Machine, RandM, Engineer, Department, Status) values ('" & Me.t_Machine.Text & "'," & Me.t_RandM.SelectedItem.Value & " ," & Me.t_Engineer.SelectedItem.Value & " , " & Me.t_Department.SelectedItem.Value & " ,1 )")
                    cmd.CommandText = sql
                    cn.Open()
                    Dim num As Integer = cmd.ExecuteNonQuery()
                    BindGrid()
                    Me.ResponseLabel.BackColor = Color.White
                    Me.ResponseLabel.ForeColor = Color.Black
                    Me.ResponseLabel.Text = "<em>Record Updated</em>"

                Catch ex As Exception
                    Me.ResponseLabel.BackColor = Color.Red
                    Me.ResponseLabel.ForeColor = Color.White
                    Me.ResponseLabel.Text = "<em>" & ex.Message & "</em>"
                Finally
                    If Not cn Is Nothing AndAlso cn.State = ConnectionState.Open Then cn.Close()
                End Try

                Me.AdministerMachinesDataGrid.EditItemIndex = -1
                BindGrid()
            End If

        End Sub


        Dim StatusDataSet As DataSet = New DataSet()
        Function GetStatus() As DataSet
            Const strSQLDDL As String = "SELECT StatusIndex, Status FROM SimpleStatus ORDER BY Status"
            Dim cn As New SqlConnection(DashWeb.Core.UI.Common.DBConnString)
            Dim myDataAdapter As SqlDataAdapter = New SqlDataAdapter(strSQLDDL, cn)
            myDataAdapter.Fill(StatusDataSet, "SimpleStatus")
            Return StatusDataSet
        End Function
        Function GetStatusIndex(ByVal t_Status As String) As Integer
            Dim iLoop As Integer
            'Loop through each row in the DataSet
            Dim dt As DataTable = StatusDataSet.Tables("SimpleStatus")
            For iLoop = 0 To dt.Rows.Count - 1
                If Int32.Parse(t_Status) = _
                      Int32.Parse(dt.Rows(iLoop)("StatusIndex")) Then
                    Return iLoop
                End If
            Next iLoop
        End Function

        Dim DepartmentDataSet As DataSet = New DataSet()
        Function GetDepartment() As DataSet
            Const strSQLDDL As String = "SELECT id, department FROM Departments ORDER BY Department"
            Dim cn As New SqlConnection(DashWeb.Core.UI.Common.DBConnString)
            Dim myDataAdapter As SqlDataAdapter = New SqlDataAdapter(strSQLDDL, cn)
            myDataAdapter.Fill(DepartmentDataSet, "Departments")
            Return DepartmentDataSet
        End Function
        Function GetDepartmentIndex(ByVal t_Department As String) As Integer
            Dim iLoop As Integer
            'Loop through each row in the DataSet
            Dim dt As DataTable = DepartmentDataSet.Tables("Departments")
            For iLoop = 0 To dt.Rows.Count - 1
                If Int32.Parse(t_Department) = _
                      Int32.Parse(dt.Rows(iLoop)("ID")) Then
                    Return iLoop
                End If
            Next iLoop
        End Function

        Dim RandMNameDataSet As DataSet = New DataSet()
        Function GetRandMName() As DataSet
            Const strSQLDDL As String = "SELECT id, name FROM requisitioner WHERE status=1 ORDER BY name"
            Dim cn As New SqlConnection(DashWeb.Core.UI.Common.DBConnString)
            Dim myDataAdapter As SqlDataAdapter = New SqlDataAdapter(strSQLDDL, cn)
            myDataAdapter.Fill(RandMNameDataSet, "requisitioner")
            Return RandMNameDataSet
        End Function
        Function GetRandMNameIndex(ByVal t_RandMName As String) As Integer
            Dim iLoop As Integer
            'Loop through each row in the DataSet
            Dim dt As DataTable = RandMNameDataSet.Tables("Requisitioner")
            For iLoop = 0 To dt.Rows.Count - 1
                If Int32.Parse(t_RandMName) = _
                      Int32.Parse(dt.Rows(iLoop)("ID")) Then
                    Return iLoop
                End If
            Next iLoop
        End Function


        Dim EngineerNameDataSet As DataSet = New DataSet()
        Function GetEngineerName() As DataSet
            Const strSQLDDL As String = "SELECT id, name FROM requisitioner WHERE status=1 ORDER BY name"
            Dim cn As New SqlConnection(DashWeb.Core.UI.Common.DBConnString)
            Dim myDataAdapter As SqlDataAdapter = New SqlDataAdapter(strSQLDDL, cn)
            myDataAdapter.Fill(EngineerNameDataSet, "requisitioner")
            Return EngineerNameDataSet
        End Function
        Function GetEngineerNameIndex(ByVal t_EngineerName As String) As Integer
            Dim iLoop As Integer
            'Loop through each row in the DataSet
            Dim dt As DataTable = EngineerNameDataSet.Tables("Requisitioner")
            For iLoop = 0 To dt.Rows.Count - 1
                If Int32.Parse(t_EngineerName) = _
                      Int32.Parse(dt.Rows(iLoop)("ID")) Then
                    Return iLoop
                End If
            Next iLoop
        End Function


        Dim ddlDataSet As DataSet = New DataSet()
        Function GetPartStatus() As DataSet
            Const strSQLDDL As String = "SELECT StatusIndex, Status FROM MFGPartStatus ORDER BY Status"
            Dim cn As New SqlConnection(DashWeb.Core.UI.Common.DBConnString)
            Dim myDataAdapter As SqlDataAdapter = New SqlDataAdapter(strSQLDDL, cn)
            myDataAdapter.Fill(ddlDataSet, "MFGPartStatus")
            Return ddlDataSet
        End Function

        Function GetSelPartIndex(ByVal t_Status As String) As Integer

            Dim iLoop As Integer

            'Loop through each row in the DataSet
            Dim dt As DataTable = ddlDataSet.Tables("MFGPartStatus")
            For iLoop = 0 To dt.Rows.Count - 1
                If Int32.Parse(t_Status) = Int32.Parse(dt.Rows(iLoop)("StatusIndex")) Then
                    Return iLoop
                End If
            Next iLoop
        End Function




        Private Sub UpdateRows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateRows.Click
            BindGrid()
        End Sub

        Private Sub Filter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter.Click
            BindGrid()
        End Sub
    End Class
End Namespace
