Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc
Public Class frmImportKaryawan
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_FrmCallerId As String

    Dim strConnection2 As String = My.Settings.ConnStr2
    Dim cn2 As New OdbcConnection(strConnection2)
    Dim strSQL As String
    Dim comm As OdbcCommand
    Dim myReader As OdbcDataReader
    Dim val1, val2 As String

    Private Sub frmImportKaryawan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("ID", 50)
            .Columns.Add("DESC", 150)
            .Columns.Add("KOMISI", 100, HorizontalAlignment.Right)
            .Columns.Add("DEPTID", 100)
        End With

        strSQL = "SELECT ID,DESC,KOMISI,DEPTID FROM KARYA143 "

        cn2.Open()
        comm = New OdbcCommand(strSQL, cn2)
        myReader = comm.ExecuteReader()

        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(0)))
            lvItem.Tag = intCurrRow 'ID
            lvItem.SubItems.Add(myReader.Item(1))
            lvItem.SubItems.Add(FormatNumber(myReader.Item(2), 8))
            If myReader.IsDBNull(myReader.GetOrdinal("DEPTID")) Then
                lvItem.SubItems.Add("")
            Else
                lvItem.SubItems.Add(myReader.Item(3))
            End If
            If intCurrRow Mod 2 = 0 Then
                lvItem.BackColor = Color.Lavender
            Else
                lvItem.BackColor = Color.White
            End If
            lvItem.UseItemStyleForSubItems = True

            ListView1.Items.Add(lvItem)
            intCurrRow += 1
        End While

        myReader.Close()
        cn2.Close()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        val1 = "im_karyawan_"
        val2 = "import"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim id, desc, deptid As String
        Dim komisi As Decimal

        If MsgBox("Anda yakin mau melakukan import data karyawan?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            'Hapus data master sebelumnya
            Try
                cmd = New SqlCommand("sp_im_karyawan_DEL", cn)
                cmd.CommandType = CommandType.StoredProcedure
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                'Insert data master baru
                For i = 0 To ListView1.Items.Count - 1

                    id = ListView1.Items(i).SubItems.Item(0).Text
                    desc = ListView1.Items(i).SubItems.Item(1).Text
                    komisi = ListView1.Items(i).SubItems.Item(2).Text
                    If ListView1.Items(i).SubItems.Item(3).Text = "" Then
                        deptid = ""
                    Else
                        deptid = ListView1.Items(i).SubItems.Item(3).Text
                    End If

                    cmd = New SqlCommand("sp_im_karyawan_INS", cn)
                    cmd.CommandType = CommandType.StoredProcedure

                    Dim prm11 As SqlParameter = cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 50)
                    prm11.Value = id
                    Dim prm12 As SqlParameter = cmd.Parameters.Add("@DESC", SqlDbType.NVarChar, 50)
                    prm12.Value = desc
                    Dim prm13 As SqlParameter = cmd.Parameters.Add("@KOMISI", SqlDbType.Decimal)
                    prm13.Value = komisi
                    Dim prm14 As SqlParameter = cmd.Parameters.Add("@DEPTID", SqlDbType.NVarChar, 50)
                    prm14.Value = deptid
                    Dim prm15 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
                    prm15.Value = My.Settings.UserName

                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                    ListView1.Items(i).Checked = True

                Next
                MsgBox("Import data karyawan berhasil", vbInformation)
            Catch ex As Exception
                MsgBox("Error Message: " + ex.Message)
                If ConnectionState.Open = True Then cn.Close()
            End Try
        End If
        Cursor = Cursors.Default
        Me.Close()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub
    Private Sub TableLayoutPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub
End Class