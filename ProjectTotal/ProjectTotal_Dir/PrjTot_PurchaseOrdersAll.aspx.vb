
Imports System.Data
Imports System.Data.SqlClient

Partial Class ProjectTotal_Dir_PrjTot_PurchaseOrdersAll
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Text = Session("strProject")
    End Sub

Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Response.Clear()
        Response.AddHeader("content-disposition", String.Format("attachment;filename={0}.csv", "Zygo_PurchaseOrder_Export"))
        Response.Charset = ""
        Response.ContentType = "application/vnd.xls"

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Projects_Info_TotalSQLConnection").ConnectionString

        Dim cn = New SqlConnection(ConnectionString)
        'Dim query As String = Me.ObjectDataSource1.SelectMethod.ToString.Replace("\r\n", " ").Replace("\t", " ")
        ', SumOfTOTAL_BACKORDERED_QUANTITY, PO_LINE_STATUS,MaxOfPRICE, MaxOfORDER_POLICY , DELIVERY_DATE,DELIVERY_DATE_CONFIRMED
        Dim query As String = "SELECT   PROJECT, " & _
                                    "ORDER_NO AS 'PURCH. ORDER', " & _
                                    "POSITION AS POS, " & _
                                    "NAME as 'SUPPLIER NAME', " & _
                                    "ITEM_CODE AS 'ITEM CODE', " & _
                                    "ITEM_DESCRIPTION AS 'ITEM DESC', " & _
                                    "QtyOrd AS 'ON ORDER', " & _
                                    "QtyRecd AS 'QTY RECVD', " & _
                                    "OrdAmt AS 'EXT PO COST', " & _
                                    "Amount AS 'EXT RECVD', " & _
                                    "OrderDate AS 'ORDER DATE', " & _
                                    "DELIVERY_DATE_2 AS 'PLANNED DEL DATE', " & _
                                    "OpenQty AS 'OPEN QTY', " & _
                                    "OpenAmt AS 'OPEN AMOUNT' " & _
                                "FROM tabProjectPurchaseOrders where (PROJECT=@Param1)"

        Dim cmd = New SqlCommand(query, cn)
        Dim strsql As String = ""
        cmd.CommandTimeout = 999999

        strsql = query
        cmd.CommandText = strsql
        cmd.CommandType = System.Data.CommandType.Text
        cmd.Parameters.AddWithValue("@Param1", Session("strProject"))
        Try

            cn.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            Dim sb As New StringBuilder

            Dim count As Integer = 0
            While count < dr.FieldCount

                If Not IsDBNull(dr.GetName(count)) Then
                    sb.Append(dr.GetName(count))
                If (count < dr.FieldCount - 1) Then
                End If
                    sb.Append(",")
                End If
                count = count + 1
            End While
            'Response.Write(sb.ToString() + "\n")
            Response.Write(sb.ToString() + vbCrLf)
            Response.Flush()


            While dr.Read()

                sb = New StringBuilder()
                Dim col As Integer = 0
                While col < dr.FieldCount - 1

                    If Not IsDBNull(dr(col)) Then
                        sb.Append(dr.GetValue(col).ToString().Replace(",", " "))
                        sb.Append(",")
                    Else
                        sb.Append(",")
                    End If
                    col = col + 1
                End While
                If Not IsDBNull(dr(dr.FieldCount - 1)) Then
                    sb.Append(dr.GetValue(dr.FieldCount - 1).ToString().Replace(",", " "))

                End If
                'Response.Write(sb.ToString() + "\n")
                Response.Write(sb.ToString() + vbCrLf)
                Response.Flush()

            End While
            dr.Dispose()

        Catch ex As Exception

            Response.Write(ex.Message)

        Finally

            cmd.Connection.Close()
            cn.Close()
        End Try

        Response.End()

End Sub
End Class
