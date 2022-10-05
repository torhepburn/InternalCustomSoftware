Imports Zygo.UI
Imports Dashweb.Core.UI.Common
Imports System
Imports System.Data.SqlClient
'Imports Zygo.Maintenance.Common
Imports Dashweb.Core.Maintenance.Common

Namespace Zygo.Maintenance
    Partial Class AddEquipment
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
            Me.ResponseLabel.BackColor = Color.Transparent
            Me.ResponseLabel.ForeColor = Color.White
            Me.ResponseLabel.Text = ""
            If Not IsPostBack Then
                LoadRandMList()
                LoadEngineerList()
                LoadDepartmentList()
                LoadExistingEquipmentList()
            End If
        End Sub



        Private Sub LoadRandMList()
            Dim list As New SortedList()
            Dim sql As String = String.Format("SELECT ID, Name FROM Requisitioner where status=1 ORDER BY name")
            Dim ds As DataSet
            Try
                ds = DbQuery(sql)
                Me.t_RandM.DataSource = ds
                Me.t_RandM.DataTextField = "Name"
                Me.t_RandM.DataValueField = "ID"
                Me.t_RandM.DataBind()
                Me.t_RandM.Items.Insert(0, "<Choose One>")
            Finally
            End Try
        End Sub

        Private Sub LoadEngineerList()
            Dim list As New SortedList()
            Dim sql As String = String.Format("SELECT ID, Name FROM Requisitioner where status=1 ORDER BY name")
            Dim ds As DataSet
            Try
                ds = DbQuery(sql)
                Me.t_Engineer.DataSource = ds
                Me.t_Engineer.DataTextField = "Name"
                Me.t_Engineer.DataValueField = "ID"
                Me.t_Engineer.DataBind()
                Me.t_Engineer.Items.Insert(0, "<Choose One>")
            Finally
            End Try
        End Sub

        Private Sub LoadDepartmentList()
            Dim list As New SortedList()
            Dim sql As String = "SELECT ID, Department FROM Departments ORDER BY Department"
            Dim ds As DataSet
            Try
                ds = DbQuery(sql)
                Me.t_Department.DataSource = ds
                Me.t_Department.DataTextField = "Department"
                Me.t_Department.DataValueField = "ID"
                Me.t_Department.DataBind()
                Me.t_Department.Items.Insert(0, "<Choose One>")
            Finally
            End Try
        End Sub

        Private Sub LoadExistingEquipmentList()
            Dim list As New SortedList()
            Dim sql As String = String.Format("SELECT MachineIndex, Machine + ' (' + (SELECT  'Status' = CASE when Status = 0 then 'Inactive' when Status = 1 then 'Active' Else 'Inactive' End )+ ')' as MachineAndStatus FROM MaintenanceMachine ORDER BY Machine")
            Dim ds As DataSet
            Try
                ds = DbQuery(sql)
                Me.t_ExistingEquipmentList.DataSource = ds
                Me.t_ExistingEquipmentList.DataTextField = "MachineAndStatus"
                Me.t_ExistingEquipmentList.DataValueField = "MachineIndex"
                Me.t_ExistingEquipmentList.DataBind()
                Me.t_ExistingEquipmentList.Items.Insert(0, "<View List>")
            Finally
            End Try
        End Sub


        Private Sub CancelAndExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelAndExit.Click
            Response.Redirect("EquipmentStatus.aspx")
        End Sub


        Private Sub SaveAndExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAndExit.Click
            Dim cn As New SqlConnection(DashWeb.Core.UI.Common.DBConnString)

            If Len(Me.t_Machine.Text) = 0 Or Me.t_RandM.SelectedIndex = 0 Or Me.t_Engineer.SelectedIndex = 0 Or Me.t_Department.SelectedIndex = 0 Then
                Me.ResponseLabel.BackColor = Color.Red
                Me.ResponseLabel.ForeColor = Color.White
                Me.ResponseLabel.Text = "All white fields must be entered."
            Else
                'Post the data and return message
                Try
                    Dim Result As Integer
                    Dim cmd As SqlCommand

                    cn.Open()
                    cmd = cn.CreateCommand()
                    Me.t_Machine.Text = t_Machine.Text.Replace("'", "''")
                    cmd.CommandText = ("Insert into maintenancemachine (Machine, RandM, Engineer, Department, Status) values ('" & Me.t_Machine.Text & "'," & Me.t_RandM.SelectedItem.Value & " ," & Me.t_Engineer.SelectedItem.Value & " , " & Me.t_Department.SelectedItem.Value & " ,1 )")
                    Result = cmd.ExecuteNonQuery()

                    If Result = 1 Then
                        Me.ResponseLabel.BackColor = Color.White
                        Me.ResponseLabel.ForeColor = Color.Black
                        Me.ResponseLabel.Text = "<em>Equipment entry successfully recorded.</em>"
                        Response.Redirect("AddMaintenanceEntry.aspx?Machine=" & Me.t_Machine.Text)
                    Else
                        Me.ResponseLabel.BackColor = Color.Red
                        Me.ResponseLabel.ForeColor = Color.White
                        Me.ResponseLabel.Text = "<B>Equipment entry has NOT been added!</B>"
                    End If
                Catch ex As Exception
                    Me.ResponseLabel.BackColor = Color.Red
                    Me.ResponseLabel.ForeColor = Color.White
                    Me.ResponseLabel.Text = ex.Message
                Finally
                    If Not cn Is Nothing AndAlso cn.State = ConnectionState.Open Then cn.Close()
                End Try

            End If
        End Sub
    End Class
End Namespace