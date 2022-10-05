Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports System.Web.Security
Imports Zygo.UI
Imports DataService
Imports ErrorHandler
Imports DashWeb.Core
Imports DashWeb.Core.UI.Common
Imports System.Collections
Imports Telerik.Web.UI

Namespace Zygo.Production
    Partial Public Class LogEquipmentData
        Inherits System.Web.UI.Page
        Protected _visible As String = "hidden"

        Dim _dsrv As IDataService = New SqlService(MetricsCnString)
        Dim _dsrvMK As IDataService = New OracleService(MKCnString1)

        Dim _hshSOD As Hashtable
        Dim _hshSODDescription As Hashtable
        Dim _hshWarehouses As New Hashtable

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            On Error GoTo Handler

            ClearError()

            Dim Cookie As HttpCookie = Request.Cookies("UVSourceStatus")

            If Not Page.IsPostBack Then

                'Dim tblStatus As DataTable = _dsrv.GetTable("SELECT 'Open' AS ID, 'Open' AS Name UNION " & _
                '                                            "SELECT 'Closed' AS ID, 'Closed' AS Name UNION " & _
                '                                            "SELECT 'Signing' AS ID, 'Signing' AS Name UNION " & _
                '                                            "SELECT 'Dispositioning' AS ID, 'Dispositioning' AS Name")
                'ddlbStatus.DataSource = tblStatus
                'ddlbStatus.DataBind()

                'Data.FillDropDownList(drpSOD, _dsrv, "select SOD, SODID from FASTSOD order by SODID", True)
                Data.FillDropDownList(ddlEquipment, _dsrv, "select serial from MIDSQL01.PM_2015_A.dbo.pmequip where " +
                                      "description like 'green spot%' and status = 'Active'", True)
                'drpMKCompany.Items.Add("")
                'drpMKCompany.Items(0).Value = -1
                'drpMKCompany.Items.Add("200")
                'drpMKCompany.Items(1).Value = 200
                'drpMKCompany.Items.Add("600")
                'drpMKCompany.Items(2).Value = 600

                'drpRCCAExists.Items.Add("")
                'drpRCCAExists.Items(0).Value = -1
                'drpRCCAExists.Items.Add("No")
                'drpRCCAExists.Items(1).Value = 0
                'drpRCCAExists.Items.Add("Yes")
                'drpRCCAExists.Items(2).Value = 1

                '_hshSOD = GetLookupTable(_dsrv, "select SOD, SODID from FASTSOD order by SODID")
                '_hshSODDescription = GetLookupTable(_dsrv, "select case when sodid=3 then SODCommonID + ' - ' + [Description] else [Description] + ' - ' + SODCommonID end as Name, cast(sodid as varchar(10)) + cast(MKCompanyID as varchar(10))+cast(SODCommonID as varchar(15)) as cKey from FastSODDescription")
                'ViewState("SOD") = _hshSOD
                'ViewState("SODDescription") = _hshSODDescription

                If Not Cookie Is Nothing Then
                    'txtFastID.Text = Cookie.Values(txtFastID.ID)
                    'txtPartNumber.Text = Cookie.Values(txtPartNumber.ID)
                    'txtItemGroup.Text = Cookie.Values(txtItemGroup.ID)
                    'txtCustomer.Text = Cookie.Values(txtCustomer.ID)

                    'If Not Cookie.Values(drpResponsibleUser.ID) Is Nothing Then
                    '    drpResponsibleUser.SelectedIndex = FASTLib.Pub.GetIndexByValue(drpResponsibleUser, Cookie.Values(drpResponsibleUser.ID))
                    'End If
                    'If Not Cookie.Values(drpOriginatorUser.ID) Is Nothing Then
                    '    drpOriginatorUser.SelectedIndex = FASTLib.Pub.GetIndexByValue(drpOriginatorUser, Cookie.Values(drpOriginatorUser.ID))
                    'End If
                    'If Not Cookie.Values(drpOrigin.ID) Is Nothing Then
                    '    drpOrigin.SelectedIndex = FASTLib.Pub.GetIndexByValue(drpOrigin, Cookie.Values(drpOrigin.ID))
                    'End If
                    'If Not Cookie.Values(drpFastType.ID) Is Nothing Then
                    '    drpFastType.SelectedIndex = FASTLib.Pub.GetIndexByValue(drpFastType, Cookie.Values(drpFastType.ID))
                    'End If
                    'Dim SODID As Integer
                    'If Not Cookie.Values(drpSOD.ID) Is Nothing Then
                    '    SODID = Cookie.Values(drpSOD.ID)
                    '    drpSOD.SelectedIndex = FASTLib.Pub.GetIndexByValue(drpSOD, SODID)
                    'End If
                    'If Not Cookie.Values(drpMKCompany.ID) Is Nothing Then
                    '    drpMKCompany.SelectedIndex = FASTLib.Pub.GetIndexByValue(drpMKCompany, Cookie.Values(drpMKCompany.ID))
                    'End If
                    'If Not Cookie.Values(drpSites.ID) Is Nothing Then
                    '    drpSites.SelectedIndex = FASTLib.Pub.GetIndexByValue(drpSites, Cookie.Values(drpSites.ID))
                    'End If
                    'If Not Cookie.Values(drpSalesRegion.ID) Is Nothing Then
                    '    drpSalesRegion.SelectedIndex = FASTLib.Pub.GetIndexByValue(drpSalesRegion, Cookie.Values(drpSalesRegion.ID))
                    'End If

                    'drpSOD1.Visible = True
                    'Select Case SODID
                    '    Case 1
                    '        Data.FillDropDownList(drpSOD1, _dsrv, "select [Description] + ' - ' + SODCommonID as name, cast(sodid as varchar(10))+cast(MKCompanyID as varchar(10))+cast(SODCommonID as varchar(15)) as cKey from FastSODDescription where sodid=1 order by [Description]", True, drpSOD1.SelectedValue)
                    '    Case 2
                    '        Data.FillDropDownList(drpSOD1, _dsrv, "select [Description] + ' - ' + SODCommonID as name, cast(sodid as varchar(10))+cast(MKCompanyID as varchar(10))+cast(SODCommonID as varchar(15)) as cKey from FastSODDescription where sodid=2 order by [Description]", True, drpSOD1.SelectedValue)
                    '    Case 3
                    '        Data.FillDropDownList(drpSOD1, _dsrv, "select SODCommonID + ' - ' + [Description] as name, cast(sodid as varchar(10))+cast(MKCompanyID as varchar(10))+cast(SODCommonID as varchar(15)) as cKey from FastSODDescription where sodid=3 order by SODCommonID", True, drpSOD1.SelectedValue)
                    '    Case Else
                    '        drpSOD1.Visible = False
                    'End Select
                    'If drpSOD1.Visible Then drpSOD1.SelectedIndex = FASTLib.Pub.GetIndexByValue(drpSOD1, Cookie.Values(drpSOD1.ID))

                    'Dim statusSelection As String = Cookie.Values(ddlbStatus.ID)
                    'If Not String.IsNullOrEmpty(statusSelection) Then
                    '    Dim statusSingle As String() = statusSelection.Split(",")
                    '    For Each status As String In statusSingle
                    '        ddlbStatus.Items.FindByValue(status).Selected = True
                    '    Next
                    'End If

                    'txtStart.Text = Cookie.Values(txtStart.ID)
                    'txtEnd.Text = Cookie.Values(txtEnd.ID)
                    'txtProductionOrder.Text = Cookie.Values(txtProductionOrder.ID)
                    'txtMKProjectID.Text = Cookie.Values(txtMKProjectID.ID)
                    'txtServiceLogID.Text = Cookie.Values(txtServiceLogID.ID)
                    'txtTrackerID.Text = Cookie.Values(txtTrackerID.ID)

                    'txtPreviousFastID.Text = Cookie.Values(txtPreviousFastID.ID)
                    'drpSalesRegion.SelectedIndex = FASTLib.Pub.GetIndexByValue(drpSalesRegion, Cookie.Values(drpSalesRegion.ID))
                Else
                    'Skip
                End If

                'Dim dtSQL As String = String.Format("select e.serial, e.description, reading, reading_date from MIDSQL01.PM_2015_A.dbo.pmequip e " +
                '"left join MIDSQL01.PM_2015_A.dbo.log_parameters p on e.serial = p.serial " +
                ' "left join MIDSQL01.PM_2015_A.dbo.log_data d on p.lpid = d.lpid " +
                ' "where description like 'green spot%' order by serial ")

                ''dtSQL = dtSQL & whereClause

                ''dtSQL += " ORDER BY [FAST Responsible User], [Part Number]"

                'Dim ds As DataSet = GetData(dtSQL)


                'Dim dv As DataView = Nothing
                'dv = ds.Tables(0).DefaultView

                ''If dv.Count > 0 Then
                'gv.DataSource = dv
                'gv.DataBind()

                'Session("gv_DataSource") = dv.ToTable()
                'Session("gv_SortDirection") = SortDirection.Ascending

                'Try
                'Session("gv_Excel") = dv.ToTable()
                'Catch ex As Exception
                'Excel_BrowseSalesAndDemo.Visible = True
                'Else
                'Skip
                'gv.DataSource = Nothing
                'gv.DataBind()
                'End If

                ' Put Origin Warehouses in a hashtable
                'Dim filter As String = ""
                'Dim sql As String = "select distinct OriginWarehouse from Fast where OriginWarehouse<>''"
                'Dim tbl As DataTable = _dsrv.GetTable(sql)
                'For Each r As DataRow In tbl.Rows
                '    filter &= "'" & r("OriginWarehouse") & "',"
                'Next
                'If filter <> "" Then
                '    filter = " where trim(warehouse) in(" & filter.Substring(0, filter.Length - 1) & ")"
                'End If

                'sql = "select warehouse || ' - ' || description as OriginWarehouse, trim(warehouse), '200' || trim(Warehouse) as id from views200.warehouses " & filter & _
                '          "union " & _
                '      "select warehouse || ' - ' || description as OriginWarehouse, trim(warehouse), '600' || trim(Warehouse) as id from views600.warehouses " & filter & " order by id"
                'tbl = _dsrvMK.GetTable(sql)

                'Dim i As Integer = 0
                ''drpOrginWarehouse.Items.Add("")
                ''drpOrginWarehouse.Items(i).Value = "0"
                'For Each r As DataRow In tbl.Rows
                '    i = i + 1
                '    _hshWarehouses.Add(r("id").ToString, r("OriginWarehouse").ToString)
                '    'drpOrginWarehouse.Items.Add(r("OriginWarehouse").ToString)
                '    'drpOrginWarehouse.Items(i).Value = r("id")
                'Next

                'If Not Cookie Is Nothing Then
                '    If Not Cookie.Values(drpOrginWarehouse.ID) Is Nothing AndAlso Cookie.Values(drpOrginWarehouse.ID) > 0 Then
                '        drpOrginWarehouse.SelectedIndex = FASTLib.Pub.GetIndexByValue(drpOrginWarehouse, Cookie.Values(drpOrginWarehouse.ID))
                '    End If
                'End If

                'ViewState("OriginWarehouse") = _hshWarehouses
            Else
                '_hshSOD = ViewState("SOD")
                '_hshSODDescription = ViewState("SODDescription")
                '_hshWarehouses = ViewState("OriginWarehouse")
            End If

            'drpOrigin.Attributes.Add("onchange", "OriginChanged(this)")
            If Request.QueryString("msg") <> "" Then
                lblMsg.Text = Request.QueryString("msg")
            End If

            Exit Sub
Handler:
            If Common.DebugMode Then
                Dim msg As String = Err.Description
                Stop
                Resume
            Else
                ErrorHandler.Common.ErrHandler(Microsoft.VisualBasic.Err)
            End If
        End Sub

        'Function GetLookupTable(ByVal dsrv As IDataService, ByVal sql As String) As Hashtable
        '    Dim tbl As DataTable = dsrv.GetTable(sql)
        '    Dim hsh As New Hashtable()
        '    For Each r As DataRow In tbl.Rows
        '        hsh.Add(r(1).ToString(), r(0).ToString())
        '    Next

        '    Return hsh
        'End Function

        Private Function GetFAST()
            'Dim whereClause As String = GetCondition()
            'If String.IsNullOrEmpty(whereClause) Then
            'SetMessage(lblMsg, "Filter criteria is required.", True)
            'Else
            'Dim dt As DataTable = GetFastsTable(whereClause)
            'grd.MasterTableView.DataSource = dt
            'End If
        End Function

        Protected Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
            'grd.Rebind()
        End Sub

        Function GetCondition() As String
            'On Error GoTo Handler

            Dim cond As String = ""
            'Dim s As String = InputStr(txtFastID)

            'If s <> "" Then
            '    cond &= "FastID like '%" & s & "%' and "
            'End If

            's = InputStr(txtPartNumber)
            'If s <> "" Then
            '    cond &= "PartNumber like '" & s & "%' and "
            'End If

            's = InputStr(txtItemGroup)
            'If s <> "" Then
            '    cond &= "ItemGroup like '" & s & "%' and "
            'End If

            ' ResponsibleUser in [Fast-FastView] is the full name
            'If drpResponsibleUser.SelectedIndex > 0 Then
            '    cond &= "ResponsibleUser='" & drpResponsibleUser.SelectedItem.ToString & "' And "
            'End If

            '' Originator in [Fast-FastView] is the full name
            'If drpOriginatorUser.SelectedIndex > 0 Then
            '    cond &= "Operator='" & drpOriginatorUser.SelectedItem.ToString & "' And "
            'End If

            'If drpOrigin.SelectedIndex > 0 Then
            '    cond &= "FastOriginID=" & drpOrigin.SelectedValue & " and "
            'End If

            'If drpOrigin.SelectedValue = 4 Then
            '    s = InputStr(txtServiceLogID)
            '    If s <> "" Then
            '        cond &= "ServiceLogID=" & s & " and "
            '    End If
            'Else
            '    If InputStr(txtServiceLogID) <> "" Then
            '        SetMessage(lblMsg, "ServiceLog ID is ignored Unless Fast Origin 'Service Log' is selected.", True)
            '    End If
            'End If

            'If drpFastType.SelectedIndex > 0 Then
            '    cond &= "FastTypesID=" & drpFastType.SelectedValue & " and "
            'End If
            'If drpMKCompany.SelectedIndex > 0 Then
            '    cond &= "MK_Company_ID=" & drpMKCompany.SelectedValue & " and "
            'End If

            'If drpSOD.SelectedIndex > 0 Then
            '    cond &= "f.SODID=" & drpSOD.SelectedValue & " and "

            '    If drpSOD1.SelectedIndex > 0 Then
            '        Select Case drpSOD.SelectedValue
            '            Case 1
            '                cond &= "SODCustomer='" & drpSOD1.SelectedValue & "' and "
            '            Case 2
            '                cond &= "SODSupplier=" & drpSOD1.SelectedValue & " and "
            '            Case 3
            '                cond &= "SODCostCenter='" & drpSOD1.SelectedValue & "' and "
            '        End Select
            '    End If
            'End If

            '1-Closed '0-Open, 2-Signing, 3-Dispositioning
            'Dim statusClause As String = String.Empty
            'Dim firstTime As Boolean = True
            'For i As Integer = 0 To ddlbStatus.Items.Count - 1
            '    If ddlbStatus.Items(i).Selected Then
            '        Dim comma As String = IIf(firstTime, "", ",")
            '        statusClause &= String.Format(comma & "'{0}'", ddlbStatus.Items(i).Value)
            '        firstTime = False
            '    End If
            'Next
            'If Not String.IsNullOrEmpty(statusClause) Then
            '    cond &= String.Format("Status IN ({0}) and ", statusClause)
            'End If

            'If drpOrginWarehouse.SelectedIndex > 0 Then
            '    s = drpOrginWarehouse.SelectedValue
            '    cond &= "MK_Company_ID=" & s.Substring(0, 3) & " and OriginWarehouse='" & s.Substring(3) & "' and "
            'End If

            'If drpSites.SelectedIndex > 0 Then
            '    s = drpSites.SelectedValue
            '    cond &= "SiteID=" & drpSites.SelectedValue & " and "
            'End If

            'If drpSalesRegion.SelectedIndex > 0 Then
            '    s = drpSalesRegion.SelectedValue
            '    cond &= "SalesRegionID=" & drpSalesRegion.SelectedValue & " and "
            'End If

            's = InputStr(txtCustomer)
            'If s <> "" Then
            '    cond &= "Customer like '%" & s & "%' and "
            'End If

            'If txtStart.Text.Trim <> "" And IsDate(txtStart.Text.Trim) Then
            '    cond &= "DateCreated>='" & txtStart.Text.Trim & "' and "
            'End If

            'If txtEnd.Text.Trim <> "" And IsDate(txtEnd.Text.Trim) Then
            '    cond &= "DateCreated<'" & txtEnd.Text.Trim & "' and "
            'End If

            'Select Case drpRCCAExists.SelectedValue
            '    Case 0
            '        cond &= "(RCCACount<=0 or RCCACount is null) and "
            '    Case 1
            '        cond &= "RCCACount>0 and "
            'End Select

            's = InputStr(txtProductionOrder)
            'If s <> "" Then
            '    cond &= "ProductionOrder like '" & s & "%' and "
            'End If
            's = InputStr(txtMKProjectID)
            'If s <> "" Then
            '    cond &= "MKProjectID like '" & s & "%' and "
            'End If
            's = InputStr(txtServiceLogID)
            'If s <> "" Then
            '    cond &= "ServiceLogID like '" & s & "%' and "
            'End If
            's = InputStr(txtTrackerID)
            'If s <> "" Then
            '    cond &= "TrackerID like '" & s & "%' and "
            'End If
            's = InputStr(txtPreviousFastID)
            'If s <> "" Then
            '    cond &= "PreviousFastID = " & s & " and "
            'End If

            If cond <> "" Then cond = " where " & Left(cond, Len(cond) - 5) ' remove the last 'and'

            If String.IsNullOrEmpty(cond) Then
                SetMessage(lblMsg, "A filter entry is required before viewing FASTS. Please enter the appropriate information below then click the FILTER button.", True)
            End If

            Return cond

            Exit Function
            'Handler:
            '            If Common.DebugMode Then
            '                Dim msg As String = Err.Description
            '                Stop
            '                Resume
            '            Else
            '                ErrorHandler.Common.ErrHandler(Microsoft.VisualBasic.Err)
            '            End If
        End Function

        Function GetFastsTable(ByVal condition As String) As DataTable
            On Error GoTo Handler

            Dim sql As String = "select e.serial, " & _
                                "e.description, " & _
                                "reading, " & _
                                "reading_date, " +
                                "LPID from MIDSQL01.PM_2015_A.dbo.pmequip e " & _
                                "left join MIDSQL01.PM_2015_A.dbo.log_parameters p on e.serial = p.serial " & _
                                "left join MIDSQL01.PM_2015_A.dbo.log_data d on p.lpid = d.lpid " & _
                                "where description like 'green spot%' order by serial "

            Dim tbl As DataTable = _dsrv.GetTable(sql)
            'Dim status As String = ""
            'Dim SODDescription As String = ""
            'For Each r As DataRow In tbl.Rows
            '    status = r("Status").ToString

            '    If status = "Closed" Then
            '        r("Link") = "<a href='FastEdit.aspx?id=" & r("FastID") & "'>View</a>"
            '    Else
            '        r("Link") = "<a href='FastEdit.aspx?id=" & r("FastID") & "'>Edit</a>"
            '    End If

            '    r("Site") = FASTLib.Pub.hshFastSite(r("SiteID").ToString())
            '    r("SalesRegion") = FASTLib.Pub.hshFastBusinessUnit(r("SalesRegionID").ToString())

            '    r("FastType") = FASTLib.Pub.hshFastTypes(r("FastTypesID").ToString())
            '    r("FastIdentityType") = FASTLib.Pub.hshFastIdentityTypes(r("FastIdentityTypeID").ToString())
            '    r("FastOrigin") = FASTLib.Pub.hshFastOrigins(r("FastOriginID").ToString())

            '    If Data.DBInt(r("ServiceLogID")) = 0 Then r("ServiceLogID") = DBNull.Value
            '    If Data.DBInt(r("TrackerID")) = 0 Then r("TrackerID") = DBNull.Value

            '    r("SOD") = _hshSOD(Data.DBString(r("SODID")))
            '    SODDescription = Data.DBString(_hshSODDescription(r("cKey").ToString))
            '    If SODDescription.Trim <> "" Then r("SOD") = r("SOD").ToString & ": " & SODDescription
            '    If r("SODName").ToString.Trim.Length > 0 Then
            '        r("SOD") = r("SOD") & " (" & r("SODName") & ")"
            '    End If
            '    r("OriginWarehouse") = Data.DBString(_hshWarehouses(r("MK_Company_ID").ToString & r("OriginWarehouse").ToString.Trim))
            'Next

            SaveCookie()

            Return tbl

            Exit Function
Handler:
            If Common.DebugMode Then
                Dim msg As String = Err.Description
                Stop
                Resume
            Else
                ErrorHandler.Common.ErrHandler(Microsoft.VisualBasic.Err)
            End If
        End Function

        Function InputStr(ByVal txt As TextBox) As String
            Return txt.Text.Trim.Replace("'", "''")
        End Function

        Private Sub SaveCookie()
            On Error GoTo Handler

            Dim MyCookie As New HttpCookie("BrowseFAST", CStr(DateTime.Now()))
            'MyCookie.Values(txtFastID.ID) = txtFastID.Text.Trim
            'MyCookie.Values(txtPartNumber.ID) = txtPartNumber.Text.Trim
            'MyCookie.Values(txtItemGroup.ID) = txtItemGroup.Text.Trim
            'MyCookie.Values(txtNoRows.ID) = txtNoRows.Text

            'MyCookie.Values(drpResponsibleUser.ID) = drpResponsibleUser.SelectedItem.Value
            'MyCookie.Values(drpOriginatorUser.ID) = drpOriginatorUser.SelectedItem.Value
            'MyCookie.Values(drpOrigin.ID) = drpOrigin.SelectedItem.Value
            'MyCookie.Values(drpSOD.ID) = drpSOD.SelectedItem.Value
            'If drpSOD.SelectedIndex > 0 And drpSOD.SelectedIndex < 4 Then
            '    MyCookie.Values(drpSOD1.ID) = drpSOD1.SelectedItem.Value
            'Else
            '    MyCookie.Values(drpSOD1.ID) = -1
            'End If
            'MyCookie.Values(drpFastType.ID) = drpFastType.SelectedItem.Value
            'MyCookie.Values(drpMKCompany.ID) = drpMKCompany.SelectedItem.Value

            'Dim statusClause As String = String.Empty
            'Dim firstTime As Boolean = True
            'For i As Integer = 0 To ddlbStatus.Items.Count - 1
            '    If ddlbStatus.Items(i).Selected Then
            '        Dim comma As String = IIf(firstTime, "", ",")
            '        statusClause += String.Format(comma & "{0}", ddlbStatus.Items(i).Value)
            '        firstTime = False
            '    End If
            'Next
            'If Not String.IsNullOrEmpty(statusClause) Then
            '    MyCookie.Values(ddlbStatus.ID) = statusClause
            'End If

            'MyCookie.Values(drpOrginWarehouse.ID) = drpOrginWarehouse.SelectedItem.Value

            'MyCookie.Values(txtStart.ID) = txtStart.Text.Trim
            'MyCookie.Values(txtEnd.ID) = txtEnd.Text.Trim
            MyCookie.Values(ddlEquipment.ID) = ddlEquipment.SelectedItem.Value
            'MyCookie.Values(drpSalesRegion.ID) = drpSalesRegion.SelectedItem.Value
            'MyCookie.Values(txtCustomer.ID) = txtCustomer.Text.Trim
            'MyCookie.Values(txtProductionOrder.ID) = txtProductionOrder.Text.Trim
            'MyCookie.Values(txtMKProjectID.ID) = txtMKProjectID.Text.Trim
            'MyCookie.Values(txtServiceLogID.ID) = txtServiceLogID.Text.Trim
            'MyCookie.Values(txtTrackerID.ID) = txtTrackerID.Text.Trim
            'MyCookie.Values(txtPreviousFastID.ID) = txtPreviousFastID.Text.Trim

            'Dim dt As DateTime = DateTime.Now()
            'MyCookie.Expires = dt.AddYears(5)
            Response.Cookies.Add(MyCookie)

            Exit Sub
Handler:
            If Common.DebugMode Then
                Dim msg As String = Err.Description
                Stop
                Resume
            Else
                ErrorHandler.Common.ErrHandler(Microsoft.VisualBasic.Err)
            End If
        End Sub

        'Protected Sub drpSOD_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles drpSOD.SelectedIndexChanged
        'drpSOD1.Visible = True
        'Select Case drpSOD.SelectedIndex
        '    Case 1
        '        Data.FillDropDownList(drpSOD1, _dsrv, "select [Description] + ' - ' + SODCommonID as name, SODCommonID from FastSODDescription where sodid=1 order by [Description]", True)
        '    Case 2
        '        Data.FillDropDownList(drpSOD1, _dsrv, "select [Description] + ' - ' + SODCommonID as name, SODCommonID from FastSODDescription where sodid=2 order by [Description]", True)
        '    Case 3
        '        Data.FillDropDownList(drpSOD1, _dsrv, "select SODCommonID + ' - ' + [Description] as name, SODCommonID from FastSODDescription where sodid=3 order by SODCommonID", True)
        '    Case Else
        '        drpSOD1.Items.Clear()
        '        drpSOD1.Visible = False
        'End Select
        'End Sub

        Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As EventArgs) 'Handles btnReset.Click
            'txtFastID.Text = String.Empty
            'txtCustomer.Text = String.Empty
            'txtPartNumber.Text = String.Empty
            'txtItemGroup.Text = String.Empty
            'txtProductionOrder.Text = String.Empty
            'txtMKProjectID.Text = String.Empty
            'txtServiceLogID.Text = String.Empty
            'txtTrackerID.Text = String.Empty
            'txtStart.Text = String.Empty
            'txtEnd.Text = String.Empty
            'txtPreviousFastID.Text = String.Empty

            'drpMKCompany.SelectedIndex = -1
            ddlEquipment.SelectedIndex = -1
            'drpSalesRegion.SelectedIndex = -1
            'drpResponsibleUser.SelectedIndex = -1
            'drpOriginatorUser.SelectedIndex = -1
            'drpOrigin.SelectedIndex = -1
            'drpOrginWarehouse.SelectedIndex = -1
            'drpFastType.SelectedIndex = -1
            'drpSOD.SelectedIndex = -1
            'drpSOD1.SelectedIndex = -1
            'drpRCCAExists.SelectedIndex = -1
        End Sub

        'Private Function GetData(ByVal dtSQL As String) As DataSet
        '    Try
        '        GetData = Nothing
        '        GetData = DbQuery_Metrics(dtSQL)
        '    Catch ex As Exception
        '        'ShowError(ex.ToString)
        '    End Try
        'End Function

        Protected Sub grd_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles grd.NeedDataSource
            Dim Equipment As String = ddlEquipment.SelectedValue
            Dim dtSQL As String = "select e.serial, " & _
                                        "e.description, " & _
                                        "reading, " & _
                                        "reading_date, " +
                                        "p.LPID from MIDSQL01.PM_2015_A.dbo.pmequip e " & _
                                        "left join MIDSQL01.PM_2015_A.dbo.log_parameters p on e.serial = p.serial " & _
                                        "left join MIDSQL01.PM_2015_A.dbo.log_data d on p.lpid = d.lpid " & _
                                        "where description like 'green spot%' " & _
                                        "and d.id in (select MAX(ID) from MIDSQL01.PM_2015_A.dbo.LOG_DATA group by LPID)order by serial "
            Dim dt As DataTable = DbQuery_Metrics(dtSQL).Tables(0)

            grd.MasterTableView.DataSource = dt

            'GetFAST()
            'GetFastsTable("*")
        End Sub

        'Protected Sub grd_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles grd.ItemDataBound
        '    Try
        '        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
        '            Dim l_lbl_RCCACount As Label = CType(e.Item.FindControl("lbl_RCCACount"), Label)

        '            If Not l_lbl_RCCACount Is Nothing Then
        '                If IsNumeric(l_lbl_RCCACount.Text) AndAlso Val(l_lbl_RCCACount.Text) > 0 Then
        '                    l_lbl_RCCACount.Text = "Yes"
        '                Else
        '                    l_lbl_RCCACount.Text = ""
        '                End If
        '            End If
        '        End If
        '    Catch ex As Exception
        '    End Try

        'End Sub

        Protected Sub grd_ItemCommand(sender As Object, e As EventArgs) Handles grd.ItemCommand

            Dim ttest As String = grd.SelectedValue
            'grd.Visible = False
            'Label2.Text = ttest + ttest

        End Sub
    End Class

End Namespace

