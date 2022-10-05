Imports ProjectTotalTableAdapters
Imports System.Data
Imports System.Data.OleDb

Partial Class ProjectTotal_Dir_PrjTot_EmpHours_Detail
    Inherits System.Web.UI.Page
    Private Property GridViewSortDirection() As String
        Get
            Return IIf(ViewState("SortDirection") = Nothing, "ASC", ViewState("SortDirection"))
        End Get

        Set(ByVal value As String)
            ViewState("SortDirection") = value
        End Set

    End Property

    Private Property GridViewSortExpression() As String
        Get
            Return IIf(ViewState("SortExpression") = Nothing, String.Empty, ViewState("SortExpression"))
        End Get

        Set(ByVal value As String)
            ViewState("SortExpression") = value
        End Set
    End Property
    Private Function GetSortDirection() As String
        Select Case GridViewSortDirection
            Case "ASC"
                GridViewSortDirection = "DESC"
            Case "DESC"
                GridViewSortDirection = "ASC"
        End Select
        Return GridViewSortDirection
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tblAdapater As New tabProjectHrsDetailTableAdapter
        'If Request.QueryString("FINANCE_PERIOD") Is DBNull.Value Then
        If Request.QueryString("EMPLOYEE") <> "" Then
            GridView1.DataSource = tblAdapater.GetDataBy_ProjectHoursDetail_Proj_Employee(Request.QueryString("Project"), Request.QueryString("EMPLOYEE"))
            Label1.Text = Session("strProject") & " --- for one employee."
        ElseIf Request.QueryString("FINANCIAL_PERIOD") <> "" Then
            GridView1.DataSource = tblAdapater.GetDataBy_ProjectHoursDetail_Proj_FinPeriod(Request.QueryString("Project"), Request.QueryString("FINANCIAL_PERIOD"))
            Label1.Text = Session("strProject") & " --- Financial Period: " & Request.QueryString("FINANCIAL_PERIOD")
        End If
        GridView1.DataBind()
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        'Dim m_dataView As DataView = CType(GridView1.DataSource, System.Data.DataView)
        'Dim m_dataTable As DataTable = CType(m_dataView, System.Data.DataView).Table
        'GridView1.DataSource = SortDataTable(m_dataTable, True)
        GridView1.DataSource = SortDataTable(CType(GridView1.DataSource, DataTable), False).ToTable
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
    End Sub

    Protected Function SortDataTable(ByVal dataTable As DataTable, ByVal isPageIndexChanging As Boolean) As DataView
        If Not dataTable Is Nothing Then
            'Dim dataView As New DataView
            Dim dataView As New DataView(dataTable)

            If GridViewSortExpression <> String.Empty Then
                If isPageIndexChanging Then
                    dataView.Sort = String.Format("{0} {1}", GridViewSortExpression, GridViewSortDirection)
                Else
                    dataView.Sort = String.Format("{0} {1}", GridViewSortExpression, GetSortDirection())
                End If
            End If
            Return dataView
        Else
            Return New DataView()
        End If
    End Function
    Protected Sub gridView1_Sorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)

        GridViewSortExpression = e.SortExpression

        Dim pageIndex As Integer = GridView1.PageIndex

        GridView1.DataSource = SortDataTable(GridView1.DataSource, False)
        GridView1.DataBind()
        GridView1.PageIndex = pageIndex

    End Sub

End Class
