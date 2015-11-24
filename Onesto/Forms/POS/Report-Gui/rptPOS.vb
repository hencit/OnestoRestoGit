Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptPOS
    Private Sub rptPOList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"
        
    End Sub
    
    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        Dim dateFrom As String
        Dim dateTo As String
        
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "yyyy/MM/dd"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "yyyy/MM/dd"
        dateFrom = dtpFrom.Text
        dateTo = dtpTo.Text
            
        strSQL = "exec RPT_POS_Report '" & dateFrom & "' , '" & dateTo & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "POSReport_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_POS_Report.rpt"

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If

        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "POS Report"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("POSReport_"))

        '-----------------MENAMBAH PARAMETER FILTER DATE--------------------------
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim filterdate As String

        filterdate = "Tanggal : " & dtpFrom.Text & " - " & dtpTo.Text

        Dim filter As String = filterdate
        crParameterDiscreteValue.Value = filter
        crParameterFieldDefinitions = cr.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("filter")
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

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class