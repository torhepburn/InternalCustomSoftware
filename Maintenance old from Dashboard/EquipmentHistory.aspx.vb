Imports Zygo.UI
Imports Dashweb.Core.UI.Common
Imports System
Imports System.Data.SqlClient
'Imports Zygo.Maintenance.Common
Imports Dashweb.Core.Maintenance.Common

Namespace Zygo.Maintenance

    Partial Class EquipmentHistory
        Inherits System.Web.UI.Page


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
            Dim t_id As Int32 = Request.QueryString("ID")
            Me.MachineIndex.Text = t_id
            Me.ResponseLabel.Text = ""
            If Not IsPostBack Then
                BindGrid(t_id)
            End If

        End Sub


        Public Sub SortList(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
            BindGrid(Me.MachineIndex.Text)
        End Sub

        Public Sub PageList(ByVal sender As Object, ByVal e As DataGridPageChangedEventArgs)
            EquipmentHistoryDataGrid.CurrentPageIndex = e.NewPageIndex
            BindGrid(Me.MachineIndex.Text)
        End Sub

        Sub BindGrid(ByVal id As Int32)
            Dim cn As New SqlConnection(DashWeb.Core.UI.Common.DBConnString)
            cn.ConnectionString = DashWeb.Core.UI.Common.DBConnString
            If (NumRows.Text Is Nothing Or Not Char.IsNumber(NumRows.Text)) Then
                NumRows.Text = "25"
            End If
            'Get Equipment Info
            Dim cmd As SqlCommand
            cmd = cn.CreateCommand()

            Try
                cmd.CommandText = "select * from [Maintenance - Machine] where machineindex = " & id
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet()
                cn.Open()
                da.Fill(ds)
                Me.EquipmentHistoryLabel.Text = "Maintenance History for<br/><B>" & ds.Tables(0).Rows(0).Item("Machine") & "</B><br/>Responsible User: <B>" & ds.Tables(0).Rows(0).Item("EngineerName") & "</B><br/>Responsible R&M: <B>" & ds.Tables(0).Rows(0).Item("RandMName") & "</B>"
            Catch ex As Exception
                Me.EquipmentHistoryLabel.Text = ex.Message
            Finally
                If Not cn Is Nothing AndAlso cn.State = ConnectionState.Open Then cn.Close()
            End Try

            Try
                cmd.CommandText = "select * from [Maintenance - History] where machine = " & id & " order by [Date] Desc"
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet()
                cn.Open()
                da.Fill(ds)

                Dim dv As DataView = ds.Tables(0).DefaultView
                Me.EquipmentHistoryDataGrid.DataSource = dv
                Me.EquipmentHistoryDataGrid.PageSize = NumRows.Text
                Me.EquipmentHistoryDataGrid.DataBind()


            Catch ex As Exception
                Me.EquipmentHistoryLabel.Text = ex.Message
            Finally
                If Not cn Is Nothing AndAlso cn.State = ConnectionState.Open Then cn.Close()
            End Try

        End Sub




        Private Sub AddEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim t_userid As Int32
            t_userid = GetUser().UserID

            Dim cn As New SqlConnection(DashWeb.Core.UI.Common.DBConnString)
            Dim sql As String = String.Format("insert into maintenance ([Date], Operator, Machine, Status) values (getdate()," & t_userid & " , " & Me.MachineIndex.Text & ",1)")
            Try
                Dim cmd As SqlCommand = cn.CreateCommand()
                cmd.CommandText = sql
                cn.Open()
                Dim num As Integer = cmd.ExecuteNonQuery()
                BindGrid(Me.MachineIndex.Text)
            Catch ex As Exception
                Me.ResponseLabel.BackColor = Color.Red
                Me.ResponseLabel.ForeColor = Color.White
                Me.ResponseLabel.Text = ex.Message
            Finally
                If Not cn Is Nothing AndAlso cn.State = ConnectionState.Open Then cn.Close()
            End Try

        End Sub

        Sub EquipmentHistoryDataGrid_Edit(ByVal sender As Object, ByVal e As DataGridCommandEventArgs)
            Dim t_username As String
            Dim my_username As String
            my_username = GetUser().UserName
            'As a bound column -> t_username = e.Item.Cells(2).Text
            t_username = CType(e.Item.FindControl("UserName"), Label).Text
            If t_username = my_username Then
                Me.EquipmentHistoryDataGrid.EditItemIndex = e.Item.ItemIndex
                BindGrid(Me.MachineIndex.Text)
            Else
                Me.ResponseLabel.BackColor = Color.Red
                Me.ResponseLabel.ForeColor = Color.White
                Me.ResponseLabel.Text = "<em>You cannot change an entry that you did not originally create.</em>"
            End If
        End Sub

        Sub EquipmentHistoryDataGrid_Cancel(ByVal sender As Object, ByVal e As DataGridCommandEventArgs)
            EquipmentHistoryDataGrid.EditItemIndex = -1
            Me.ResponseLabel.BackColor = Color.Red
            Me.ResponseLabel.ForeColor = Color.White
            Me.ResponseLabel.Text = "<em>Record Update Canceled by User</em>"
            BindGrid(Me.MachineIndex.Text)
        End Sub


        Sub EquipmentHistoryDataGrid_Update(ByVal sender As Object, ByVal e As DataGridCommandEventArgs)
            Dim cn As New SqlConnection(DashWeb.Core.UI.Common.DBConnString)
            Dim t_StatusIndex As String, t_Status As String, t_MaintenanceNumber As String, t_Comments As String
            t_StatusIndex = CType(e.Item.FindControl("StatusList"), _
                                  DropDownList).SelectedItem.Value
            t_Status = CType(e.Item.FindControl("StatusList"), _
                                    DropDownList).SelectedItem.Text
            t_Comments = Trim(CType(e.Item.FindControl("Comments"), TextBox).Text)

            If (Len(t_Comments) = 0) Then
                Me.ResponseLabel.BackColor = Color.Red
                Me.ResponseLabel.ForeColor = Color.White
                Me.ResponseLabel.Text = "Please fill out all white fields!"
            Else

                Try
                    Dim cmd As SqlCommand = cn.CreateCommand()
                    t_Comments = t_Comments.Replace("'", "''")
                    't_MaintenanceNumber = Me.EquipmentHistoryDataGrid.DataKeys(CInt(e.Item.ItemIndex))
                    t_MaintenanceNumber = e.Item.Cells(5).Text
                    Dim sql As String = String.Format("update maintenance set Status=" & t_StatusIndex & ", comments='" & t_Comments & "' where MaintenanceNumber = " & t_MaintenanceNumber)
                    cmd.CommandText = sql
                    cn.Open()
                    Dim num As Integer = cmd.ExecuteNonQuery()
                    BindGrid(Me.MachineIndex.Text)
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

                EquipmentHistoryDataGrid.EditItemIndex = -1
                BindGrid(Me.MachineIndex.Text)
            End If

        End Sub


        Dim ddlDataSet As DataSet = New DataSet()
        Function GetStatus() As DataSet
            Const strSQLDDL As String = "SELECT StatusIndex, Status FROM MaintenanceStatus ORDER BY Status"
            Dim cn As New SqlConnection(DashWeb.Core.UI.Common.DBConnString)
            Dim myDataAdapter As SqlDataAdapter = New SqlDataAdapter(strSQLDDL, cn)
            myDataAdapter.Fill(ddlDataSet, "MaintenanceStatus")
            Return ddlDataSet
        End Function



        Function GetSelIndex(ByVal t_Status As String) As Integer

            Dim iLoop As Integer

            'Loop through each row in the DataSet
            Dim dt As DataTable = ddlDataSet.Tables("MaintenanceStatus")
            For iLoop = 0 To dt.Rows.Count - 1
                If Int32.Parse(t_Status) = _
                      Int32.Parse(dt.Rows(iLoop)("StatusIndex")) Then
                    Return iLoop
                End If
            Next iLoop
        End Function

        Private Sub UpdateRows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateRows.Click
            BindGrid(Me.MachineIndex.Text)
        End Sub

    End Class
End Namespace
