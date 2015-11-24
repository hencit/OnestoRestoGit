Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptGaji
    Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Gaji.rpt"
    Dim val1, val2 As String

    Private Sub rptGaji_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"
    End Sub

    Public Property KodeKaryawan() As String
        Get
            Return txtKaryawan.Text
        End Get
        Set(ByVal Value As String)
            txtKaryawan.Text = Value
        End Set
    End Property

    Private Sub btnClear_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtKaryawan.Text = ""
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        val1 = "rpt_gaji_"
        val2 = "cetak"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        Dim dateFrom1 As String
        Dim dateTo1 As String
        Dim karyawanID1 As String

        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "yyyy/MM/dd"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "yyyy/MM/dd"
        dateFrom1 = dtpFrom.Text
        dateTo1 = dtpTo.Text

        If txtKaryawan.Text <> "" Then
            karyawanID1 = txtKaryawan.Text
        Else
            karyawanID1 = ""
        End If

        strSQL = "exec RPT_Gaji '" & dateFrom1 & "' , '" & dateTo1 & "' , '" & karyawanID1 & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "RPT_Gaji_")

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If

        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "Report Gaji"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("RPT_Gaji_"))

        '-----------------MENAMBAH PARAMETER FILTER KE CR--------------------------
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim filterdate As String
        Dim filterkaryawan As String

        filterdate = "Tanggal : " & dtpFrom.Text & " - " & dtpTo.Text

        If txtKaryawan.Text = "" Then
            filterkaryawan = "Semua Karyawan"
        Else
            filterkaryawan = "ID Karyawan : " & txtKaryawan.Text
        End If

        Dim filter As String = filterdate + vbCrLf + filterkaryawan

        crParameterDiscreteValue.Value = filter
        crParameterFieldDefinitions = cr.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("filterscode")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
    End Sub

    Private Sub btnPchCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKaryawan.Click
        Dim NewFormDialog As New fdlKaryawan
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnUbah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUbah.Click
        val1 = "rpt_gaji_"
        val2 = "ubah"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        Try
            Process.Start(strReportPath)
        Catch ex As Exception
            MsgBox("Error code : " + ex.Message)
        End Try

    End Sub
End Class