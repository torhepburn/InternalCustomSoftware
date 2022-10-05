Imports System.Data.SqlClient

Public Class BrowseInitialRequests
    Inherits System.Web.UI.Page
    Private cnxn As SqlConnection
    Private da As SqlDataAdapter
    Private cmd As SqlCommand
    Private BasicSelection As String
    Private Selection As String
    Private o As Object
    Private site As String
    Private SiteAllchangedFlag As Boolean
    Private db As String
    Private email As String
    Private yesTickets As String
    Private uname As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            db = "server = midsql01; password = Read+Write!; " +
                    "user = readwrite; database = PM_2015_A;"
            cnxn = New SqlConnection(db)

            'Dim uname As String
            uname = Environment.UserName.ToString()

            cmd = New SqlCommand("select RTRIM(site) from AssignedTo where networklogin = '" + uname + "'", cnxn)
            cnxn.Open()
            o = cmd.ExecuteScalar()
            cnxn.Close()
            site = o.ToString()

            SiteSelection()

            cmd = New SqlCommand("select email from tbl_employees " +
               "where networklogin = '" + uname + "'", cnxn)

            cnxn.Open()
            o = cmd.ExecuteScalar()
            cnxn.Close()
            email = o.ToString()

            cmd = New SqlCommand("select count(owner_email) from repair_requests " +
                "where owner_email like '%" + email + "%'", cnxn)

            cnxn.Open()
            o = cmd.ExecuteScalar()
            cnxn.Close()
            yesTickets = o.ToString

            If (yesTickets <> "0") Then

                Selection = "from repair_requests where owner_email like '%" + uname + "%' "

                GridData()

            Else

                Selection = BasicSelection
                GridData()

            End If

            da = New SqlDataAdapter("select distinct serial" + BasicSelection + " order by serial", cnxn)
            Dim dt As DataTable
            dt = New DataTable()
            da.Fill(dt)
            Dim newrow As DataRow = dt.NewRow()
            newrow("serial") = " "
            dt.Rows.InsertAt(newrow, 0)

            drpEquipmentID.DataSource = dt
            drpEquipmentID.DataValueField = "serial"
            drpEquipmentID.DataBind()


            da = New SqlDataAdapter("select distinct cost_center" + BasicSelection + " order by cost_center", cnxn)
            dt = New DataTable()
            da.Fill(dt)
            newrow = dt.NewRow()
            newrow("cost_center") = " "
            dt.Rows.InsertAt(newrow, 0)

            drpCostCenter.DataSource = dt
            drpCostCenter.DataValueField = "cost_center"
            drpCostCenter.DataBind()


            da = New SqlDataAdapter("select distinct owner_email" + BasicSelection + " order by owner_email", cnxn)
            dt = New DataTable()
            da.Fill(dt)
            newrow = dt.NewRow()
            newrow("owner_email") = " "
            dt.Rows.InsertAt(newrow, 0)

            drpOwner.DataSource = dt
            drpOwner.DataValueField = "owner_email"
            drpOwner.DataBind()


            da = New SqlDataAdapter("select distinct requestor" + BasicSelection + " order by requestor", cnxn)
            dt = New DataTable()
            da.Fill(dt)
            newrow = dt.NewRow()
            newrow("requestor") = " "
            dt.Rows.InsertAt(newrow, 0)

            drpReportedBy.DataSource = dt
            drpReportedBy.DataValueField = "requestor"
            drpReportedBy.DataBind()
        End If


    End Sub

    Sub SiteSelection()

        Dim whereFirst As String = " from repair_requests where "

        If (site = "ZEOS") Then

            BasicSelection = whereFirst + "serial like 'CM%' "

        ElseIf (site = "AZT") Then

            BasicSelection = whereFirst + "serial like 'TU%' "

        ElseIf (site = "ZEP") Then

            BasicSelection = whereFirst + "serial like 'RI%' "

        ElseIf (site = "ALL") Then

            'Lsite.Visible = True
            'cbddSite.Visible = True
            BasicSelection = whereFirst + " 'one' = 'one' "
        Else

            BasicSelection = whereFirst + "serial not like 'CM%' and " +
                             "serial not like 'TU%' and " +
                             "serial not like 'RI%'  "
        End If




    End Sub

    Sub GridData()

        db = "server = midsql01; password = Read+Write!; " +
                    "user = readwrite; database = PM_2015_A;"

        cnxn = New SqlConnection(db)

        da = New SqlDataAdapter("Select id, " +
                 "category Category, " +
                 "severity Severity, " +
                 "request_date [Date Reported], " +
                 "serial 'Equipment ID', " +
                 "trouble Task, " +
                 "requestor [Reported By] " +
                 Selection +
                 " order by serial", cnxn)



        Dim table As DataTable
        table = New DataTable()
        da.Fill(table)
        grd.DataSource = table
        grd.DataBind()





        'grd.Columns[0].Visible = false
        'grd.Columns[1].Width = 125
        'grd.Columns[2].Width = 50
        'grd.Columns[3].Width = 110
        'grd.Columns[4].Width = 250
        'grd.Columns[5].Width = 350
        'grd.Columns[6].Width = 150

        'LrecordCount.Text = "RECORD COUNT: " + (DGV.RowCount -1).ToString();

        'g.PreviousSelection = selection;
        'selection = "";
    End Sub



    Protected Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click

        Selection = BasicSelection

        If (site = "ALL" Or SiteAllchangedFlag = True) Then

            If drpSite.SelectedIndex > 0 Then

                If (drpSite.Text.Trim() = "Costa Mesa") Then

                    site = "ZEOS"

                ElseIf (drpSite.Text.Trim() = "Middlefield") Then

                    site = "ZAMS"

                ElseIf (drpSite.Text.Trim() = "Richmond") Then

                    site = "ZEP"

                ElseIf (drpSite.Text.Trim() = "Tucson") Then

                    site = "AZT"


                    SiteAllchangedFlag = True
                    SiteSelection()
                    Selection = BasicSelection

                ElseIf (drpSite.SelectedIndex = 0 And SiteAllchangedFlag = True) Then

                    SiteAllchangedFlag = False
                    site = "ALL"
                    SiteSelection()
                    Selection = BasicSelection

                End If

            End If

        End If

        If (drpEquipmentID.SelectedIndex > 0) Then

            Selection += " and serial = '" + drpEquipmentID.Text.Trim() + "' "

        End If


        If (drpSeverity.SelectedIndex > 0) Then

            Selection += " and severity = '" + drpSeverity.Text.Trim() + "' "

        End If

        If (drpCategory.SelectedIndex > 0) Then

            Selection += " and category = '" + drpCategory.Text.Trim() + "' "

        End If

        If (drpCostCenter.SelectedIndex > 0) Then

            Selection += " and cost_center = '" + drpCostCenter.Text.Trim() + "' "

        End If

        If (drpOwner.SelectedIndex > 0) Then

            Selection += " and owner_email like '%" + drpOwner.Text.Trim() + "%' "

        End If


        If (drpReportedBy.SelectedIndex > 0) Then

            Selection += " and requestor = '" + drpReportedBy.Text.Trim() + "' "

        End If

        GridData()

    End Sub
End Class