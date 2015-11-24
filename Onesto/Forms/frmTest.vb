Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmTest
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand

    Private Sub frmTest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        dtp1.Format = DateTimePickerFormat.Custom
        dtp1.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        cmd = New SqlCommand("insert into test values ('" + dtp1.Text + "')", cn)
        
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If dtp2.Value <= dtp1.Value Then
            MsgBox("Salah")
        Else
            MsgBox("Benar")
        End If
    End Sub
End Class