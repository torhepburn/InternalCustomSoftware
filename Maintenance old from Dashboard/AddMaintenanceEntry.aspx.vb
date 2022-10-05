Imports Zygo.UI
Imports Dashweb.Core.UI.Common
Imports System
Imports System.Data.SqlClient
'Imports Zygo.Maintenance.Common
Imports Dashweb.Core.Maintenance.Common
Imports System.Web.Mail

Namespace Zygo.Maintenance
    Partial Class AddMaintenanceEntry
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
                Me.t_Date.Text = Now()
                Me.t_Operator.Text = GetUser().UserID.ToString
                Me.t_UserName.Text = GetUser().UserName
                LoadStatusList()
                Dim q_Machine As String = Request.QueryString("Machine")
                LoadMachineList(q_Machine)
            End If

        End Sub



        Private Sub LoadMachineList(ByVal t_Machine As String)
            Dim list As New SortedList()
            Dim sql As String
            If Len(Trim(t_Machine)) = 0 Then
                Sql = String.Format("SELECT MachineIndex, Machine FROM MaintenanceMachine where status=1 ORDER BY Machine")
            Else
                Sql = String.Format("SELECT MachineIndex, Machine FROM MaintenanceMachine where machine = '" & t_Machine & "'")
            End If
            Dim ds As DataSet
            Try
                ds = DbQuery(Sql)
                Me.t_Machine.DataSource = ds
                Me.t_Machine.DataTextField = "Machine"
                Me.t_Machine.DataValueField = "MachineIndex"
                Me.t_Machine.DataBind()
                Me.t_Machine.Items.Insert(0, "<Choose One>")
            Finally
            End Try
        End Sub

        Private Sub LoadStatusList()
            Dim list As New SortedList()
            Dim sql As String = "SELECT StatusIndex, Status FROM MaintenanceStatus ORDER BY Status"
            Dim ds As DataSet
            Try
                ds = DbQuery(sql)
                Me.t_Status.DataSource = ds
                Me.t_Status.DataTextField = "Status"
                Me.t_Status.DataValueField = "StatusIndex"
                Me.t_Status.DataBind()
                Me.t_Status.Items.Insert(0, "<Choose One>")
            Finally
            End Try
        End Sub


        Private Sub CancelAndExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelAndExit.Click
            Response.Redirect("EquipmentStatus.aspx")
        End Sub



        Private Sub SaveAndExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAndExit.Click
            Dim cn As New SqlConnection(DashWeb.Core.UI.Common.DBConnString)

            If Len(Me.t_Comments.Text) = 0 Or Me.t_Machine.SelectedIndex = 0 Or Me.t_Status.SelectedIndex = 0 Then
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
                    t_Comments.Text = t_Comments.Text.Replace("'", "''")
                    cmd.CommandText = ("Insert into maintenance (Operator, [Date], Status, Comments, Machine) values (" & Me.t_Operator.Text & ",'" & Now() & "' ," & Me.t_Status.SelectedItem.Value & " , '" & Me.t_Comments.Text & "' , " & Me.t_Machine.SelectedItem.Value & ")")
                    Result = cmd.ExecuteNonQuery()

                    If Result = 1 Then
                        Me.ResponseLabel.BackColor = Color.White
                        Me.ResponseLabel.ForeColor = Color.Black
                        Me.ResponseLabel.Text = "<em>Maintenance entry successfully recorded.</em>"
                        If MachineStatusChangeNotification(Me.t_Machine.SelectedItem.Value, Me.t_Machine.SelectedItem.Text, Me.t_Status.SelectedItem.Text, Me.t_Comments.Text, GetUser.Name) Then
                            Response.Redirect("EquipmentStatus.aspx")
                        Else
                            Me.ResponseLabel.BackColor = Color.Red
                            Me.ResponseLabel.ForeColor = Color.White
                            Me.ResponseLabel.Text = "<B>Maintenance entry has been added but email notification has failed.  Make sure the SMTPServer setting has been set!</B>"
                            Me.SaveAndExit.Enabled = False
                        End If

                    Else
                    Me.ResponseLabel.BackColor = Color.Red
                    Me.ResponseLabel.ForeColor = Color.White
                    Me.ResponseLabel.Text = "<B>Maintenance entry has NOT been added!</B>"
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