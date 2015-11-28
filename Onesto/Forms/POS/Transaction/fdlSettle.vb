Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
Imports System.Reflection

Public Class fdlSettle
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand

    Public Property billNo() As String
        Get
            Return txtBillNo.Text
        End Get
        Set(ByVal Value As String)
            txtBillNo.Text = Value
        End Set
    End Property

    Private Sub fdlSettle_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Add item cbReceipt
        cmd = New SqlCommand("select receipt_code from sys_receipt where active = 1 ", cn)

        cn.Open()
        Dim myReader = cmd.ExecuteReader

        While myReader.Read
            cbReceipt.Items.Add(myReader.GetString(0))
        End While

        myReader.Close()
        cn.Close()

        cbReceipt.SelectedIndex = 0
        'end add item 

        view_record()

    End Sub

    Sub view_record()
        Try
            cmd = New SqlCommand("sp_tr_pos_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm2 As SqlParameter = cmd.Parameters.Add("@bill_no", SqlDbType.NVarChar, 20)
            prm2.Value = txtBillNo.Text

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            While myReader.Read
                dtpDate.Text = myReader.GetDateTime(1)
                txtTableCode.Text = myReader.GetString(2)

                If myReader.GetString(3) = "" Then
                    cbReceipt.SelectedIndex = 0
                Else
                    Dim i As Integer
                    For i = 1 To cbReceipt.Items.Count
                        If myReader.GetString(3) = cbReceipt.Items(i - 1).ToString Then
                            cbReceipt.SelectedIndex = i - 1
                            Exit For
                        End If
                    Next
                End If

                txtStatus.Text = myReader.GetString(4)
                txtTotalGross.Text = FormatNumber(myReader.GetDecimal(5), 0)
                txtTotalDisc.Text = FormatNumber(myReader.GetDecimal(6), 0)
                txtTotalSub.Text = FormatNumber(myReader.GetDecimal(7), 0)
                txtTotalTax.Text = FormatNumber(myReader.GetDecimal(8), 0)
                txtTotalGrand.Text = FormatNumber(myReader.GetDecimal(9), 0)
                txtCatatan.Text = myReader.GetString(10)
                txtTotalPembayaran.Text = FormatNumber(myReader.GetDecimal(11), 0)
                txtTotalAddDisc.Text = FormatNumber(myReader.GetDecimal(13), 0)
            End While

            myReader.Close()
            cn.Close()
        Catch ex As Exception
            MsgBox("Error Message :" + ex.Message)
            If ConnectionState.Open = True Then cn.Close()
        End Try
    End Sub

    Private Sub cbReceipt_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbReceipt.SelectedIndexChanged
        If cbReceipt.SelectedIndex <> 0 Then
            txtTotalPembayaran.Text = txtTotalGrand.Text
        End If
    End Sub

    Private Sub txtTotalPembayaran_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalPembayaran.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    
    Private Sub txtTotalPembayaran_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotalPembayaran.LostFocus
        txtTotalPembayaran.Text = FormatNumber(txtTotalPembayaran.Text, 0)
        txtTotalPengembalian.Text = FormatNumber(CInt(txtTotalPembayaran.Text) - CInt(txtTotalGrand.Text), 0)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If CInt(txtTotalGrand.Text) > CInt(txtTotalPembayaran.Text) Then
            MsgBox("Pembayaran tidak mencukupi, kekurangan " + CStr(FormatNumber(CInt(txtTotalGrand.Text) - CInt(txtTotalPembayaran.Text), 0)), vbCritical)
            Exit Sub
        End If

        Try
            cmd = New SqlCommand("sp_tr_pos_RECEIPT", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm0 As SqlParameter = cmd.Parameters.Add("@bill_no", SqlDbType.NVarChar, 20)
            prm0.Value = txtBillNo.Text
            Dim prm1 As SqlParameter = cmd.Parameters.Add("@pos_date", SqlDbType.DateTime)
            prm1.Value = dtpDate.Value
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@table_code", SqlDbType.NVarChar, 20)
            prm2.Value = txtTableCode.Text
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@receipt_type", SqlDbType.NVarChar, 20)
            prm3.Value = cbReceipt.SelectedItem.ToString
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@total_paid", SqlDbType.Decimal)
            prm4.Value = CDec(txtTotalPembayaran.Text)
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@keterangan", SqlDbType.NVarChar, 255)
            prm5.Value = txtCatatan.Text

            Dim prm22 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
            prm22.Value = My.Settings.UserName


            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            view_record()
            autoRefreshPOS()

            btnPrint_Click(sender, e)
        Catch ex As Exception
            MsgBox("Error Message :" + ex.Message)
            If ConnectionState.Open = True Then cn.Close()
        End Try

    End Sub

    'Set autorefresh list---hendra
    Sub autoRefreshPOS()
        If Application.OpenForms().OfType(Of frmPOS).Any Then
            Call frmPOS.frmPOSRefresh(Nothing, EventArgs.Empty)
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If MsgBox("Anda mau print bill?", vbYesNo + vbInformation) = vbYes Then
            Dim strConnection As String = My.Settings.ConnStr
            Dim Connection As New SqlConnection(strConnection)
            Dim strSQL As String

            strSQL = "exec RPT_POS_Form '" & txtBillNo.Text & "'"
            Dim DA As New SqlDataAdapter(strSQL, Connection)
            Dim DS As New DataSet

            DA.Fill(DS, "POS_Frm")

            Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_POS_Form.rpt"

            If Not IO.File.Exists(strReportPath) Then
                Throw (New Exception("Unable to locate report file:" & _
                  vbCrLf & strReportPath))
            End If

            Dim cr As New ReportDocument
            Dim NewMDIChild As New frmDocViewer()
            NewMDIChild.Text = "Print Bill"
            NewMDIChild.Show()

            Dim repOptions As CrystalDecisions.CrystalReports.Engine.PrintOptions
            cr.Load(strReportPath)
            cr.SetDataSource(DS.Tables("POS_Frm"))

            With cr
                repOptions = .PrintOptions
                With repOptions
                    .PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
                    .PaperSize = GetPapersizeID(GetSysInit("pos_printer_name"), GetSysInit("pos_paper_size"))
                    .PrinterName = GetSysInit("pos_printer_name")
                End With

                ''Digunakan untuk direct print
                .Load(strReportPath, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                .SetDataSource(DS.Tables(0))
                .Refresh()
                '.PrintToPrinter(NumberOFCopies, Collated, StartPage, EndPage)
                .PrintToPrinter(1, True, 1, 1)
            End With

            With NewMDIChild
                .myCrystalReportViewer.ShowRefreshButton = False
                .myCrystalReportViewer.ShowCloseButton = False
                .myCrystalReportViewer.ShowGroupTreeButton = False
                .myCrystalReportViewer.ReportSource = cr
            End With
        End If
    End Sub

    Public Function GetPapersizeID(ByVal ByValPrinterNameAsString, ByVal ByValPaperSizeNameAsString) As Integer
        Dim doctoprint As New System.Drawing.Printing.PrintDocument()
        Dim PaperSizeID As Integer = 0
        Dim ppname As String = ""
        Dim s As String = ""
        doctoprint.PrinterSettings.PrinterName = GetSysInit("pos_printer_name") '(ex."EpsonSQ-1170ESC/P2")

        For i As Integer = 0 To doctoprint.PrinterSettings.PaperSizes.Count - 1
            Dim rawKind As Integer
            ppname = GetSysInit("pos_paper_size")

            If doctoprint.PrinterSettings.PaperSizes(i).PaperName = ppname Then
                rawKind = CInt(doctoprint.PrinterSettings.PaperSizes(i).GetType().GetField("kind", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes(i))) ' Reflection.BindingFlags.InstanceOrReflection.BindingFlags.NonPublic
                PaperSizeID = rawKind
                Exit For
            End If

        Next

        Return (PaperSizeID)

    End Function


End Class