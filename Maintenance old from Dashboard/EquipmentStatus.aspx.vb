Imports Zygo.UI
Imports Dashweb.Core.UI.Common
Imports System
Imports System.Data.SqlClient
Imports DashWeb.Core.Maintenance.Common

Namespace Zygo.Maintenance
    Partial Class EquipmentStatus
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
            If Not IsPostBack Then
                Me.CurrentCommentsSize.Text = 0 '0 is short, 1 is long
                Me.CommentsSizeToggle.Text = "View complete comments"
            End If
            BindGrid(Me.CurrentCommentsSize.Text)
        End Sub

        Sub BindGrid(ByVal t_CommentsSize As Int32)
            Dim cn As New SqlConnection(DashWeb.Core.UI.Common.DBConnString)
            cn.ConnectionString = DashWeb.Core.UI.Common.DBConnString
            Me.EquipmentStatusLabel.Text = "Current Equipment Status"
            If (NumRows.Text Is Nothing Or Not Char.IsNumber(NumRows.Text)) Then
                NumRows.Text = "25"
            End If


            Try
                Dim cmd As SqlCommand
                cmd = cn.CreateCommand()

                If t_CommentsSize = 0 Then 'make it short
                    cmd.CommandText = "select MachineStatus, Machineid, Machine, CommentsShort as Comments, Date, Status, Name from [Maintenance - Status At A Glance] order by [Date] Desc"
                Else
                    cmd.CommandText = "select MachineStatus, MachineID, Machine, Comments, Date, Status, Name from [Maintenance - Status At A Glance] order by [Date] Desc"
                End If

                Dim st_da As New SqlDataAdapter(cmd)
                Dim st_ds As New DataSet()
                cn.Open()
                st_da.Fill(st_ds)
                Dim st_dv As DataView = st_ds.Tables(0).DefaultView
                Me.EquipmentStatusDataGrid.DataSource = st_dv
                Me.EquipmentStatusDataGrid.PageSize = NumRows.Text
                Me.EquipmentStatusDataGrid.DataBind()

            Finally
                If Not cn Is Nothing AndAlso cn.State = ConnectionState.Open Then cn.Close()
            End Try

        End Sub



        Public Shared Function GetQuickStatus(ByVal t_status As Integer) As String
            'Dim ReturnGetQuickStatus As New String()
            Dim ReturnGetQuickStatus As String

            If t_status = "1" Then 'Up
                ReturnGetQuickStatus = "<TD style='font-weight:bold;font-size:XX-Small;color=green' 'align='Left'>X</TD>"
            Else
                If t_status = "2" Then 'Down
                    ReturnGetQuickStatus = "<TD style='font-weight:bold;font-size:XX-Small;color=red' align='Middle'>X</TD>"
                Else 'Other
                    ReturnGetQuickStatus = "<TD style='font-weight:bold;font-size:XX-Small;color=blue' align='Right'>X</TD>"
                End If
            End If
            Return ReturnGetQuickStatus

        End Function



        Private Sub CommentsSizeToggle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommentsSizeToggle.Click
            If Me.CurrentCommentsSize.Text = 0 Then
                Me.CurrentCommentsSize.Text = 1
                Me.CommentsSizeToggle.Text = "View abbreviated comments"
                BindGrid(1)
            Else
                Me.CurrentCommentsSize.Text = 0
                BindGrid(0)
                Me.CommentsSizeToggle.Text = "View complete comments"
            End If
        End Sub

        Private Sub UpdateRows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateRows.Click
            BindGrid(Me.CurrentCommentsSize.Text)
        End Sub
    End Class
End Namespace
