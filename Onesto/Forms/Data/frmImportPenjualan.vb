Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc
Imports System.IO
Public Class frmImportPenjualan
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim sqlreader As SqlDataReader

    Dim strConnection2 As String = My.Settings.ConnStr2
    Dim cn2 As New OdbcConnection(strConnection2)
    Dim strSQL As String
    Dim comm As OdbcCommand
    Dim myReader As OdbcDataReader

    Dim path, path_header, path_detail, ext, bulan, tahun As String

    Dim val1, val2 As String

    Private Sub frmImportPenjualan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpPeriod.Value = System.DateTime.Now
        getArray()
        getPenjualan()
    End Sub

    Sub getArray()
        Try
            With ListView2
                .Clear()
                .View = View.Details
                .Columns.Add("path_header", 120)
                .Columns.Add("path_detail", 120)
            End With

            cmd = New SqlCommand("SELECT path_header, path_detail FROM sys_path", cn)

            cn.Open()
            sqlreader = cmd.ExecuteReader

            While sqlreader.Read
                Dim lvItem As ListViewItem
                Dim intCurrRow As Integer

                lvItem = New ListViewItem(CStr(sqlreader.Item(0)))
                lvItem.Tag = intCurrRow 'ID

                lvItem.SubItems.Add(sqlreader.Item(1))

                If intCurrRow Mod 2 = 0 Then
                    lvItem.BackColor = Color.Lavender
                Else
                    lvItem.BackColor = Color.White
                End If
                lvItem.UseItemStyleForSubItems = True

                ListView2.Items.Add(lvItem)
                intCurrRow += 1
            End While

            sqlreader.Close()
            cn.Close()
        Catch ex As Exception
            If ConnectionState.Open = True Then cn.Close()
            MsgBox("Error code: " + ex.Message)
            Me.Close()
        End Try
    End Sub

    Sub getPenjualan()
        Cursor = Cursors.WaitCursor
        ext = ".dat"

        If CInt(dtpPeriod.Value.Month) < 10 Then
            bulan = "0" + CStr(dtpPeriod.Value.Month)
        Else
            bulan = dtpPeriod.Value.Month
        End If

        tahun = dtpPeriod.Value.Year

        Try
            With ListView1
                .Clear()
                .View = View.Details
                .Columns.Add("POSID", 90)
                .Columns.Add("NOTRANS", 120)
                .Columns.Add("TANGGAL", 50)
                .Columns.Add("BULAN", 50)
                .Columns.Add("TAHUN", 50)
                .Columns.Add("STOCKID", 100)
                .Columns.Add("STOCKNAME", 200)
                .Columns.Add("DEPTID", 50)
                .Columns.Add("JUMLAH", 100, HorizontalAlignment.Right)

            End With

            For z = 0 To ListView2.Items.Count - 1
                path_header = ListView2.Items(z).Text
                path_detail = ListView2.Items(z).SubItems(1).Text

                For i = 1 To 31
                    If CInt(i) < 10 Then
                        path = path_header + path_detail + "\" + tahun + "-" + bulan + "\IT" + bulan + "" + "0" + CStr(i) + ext
                    Else
                        path = path_header + path_detail + "\" + tahun + "-" + bulan + "\IT" + bulan + "" + CStr(i) + ext
                    End If


                    If File.Exists(path) Then
                        strSQL = "SELECT NOTRANS,STOCKID,STOCKNAME,DEPTID,JUMLAH FROM " + Chr(34) + path + Chr(34) + " WHERE ISVOID = FALSE "
                        cn2.Open()
                        comm = New OdbcCommand(strSQL, cn2)
                        myReader = comm.ExecuteReader()

                        If myReader.HasRows Then
                            While myReader.Read
                                Dim lvItem As ListViewItem
                                Dim intCurrRow As Integer

                                lvItem = New ListViewItem(CStr(path_detail))
                                lvItem.Tag = intCurrRow 'ID
                                lvItem.SubItems.Add(myReader.Item(0))
                                lvItem.SubItems.Add(i) 'tanggal
                                lvItem.SubItems.Add(bulan) 'bulan
                                lvItem.SubItems.Add(tahun) 'tahun
                                For y = 1 To 3
                                    If myReader.Item(y) Is System.DBNull.Value Then
                                        lvItem.SubItems.Add("")
                                    Else
                                        lvItem.SubItems.Add(myReader.Item(y))
                                    End If
                                Next
                                lvItem.SubItems.Add(myReader.Item(4))

                                If intCurrRow Mod 2 = 0 Then
                                    lvItem.BackColor = Color.Lavender
                                Else
                                    lvItem.BackColor = Color.White
                                End If
                                lvItem.UseItemStyleForSubItems = True

                                ListView1.Items.Add(lvItem)
                                intCurrRow += 1
                            End While
                        End If
                        myReader.Close()
                        cn2.Close()
                    End If
                Next
            Next
        Catch ex As Exception
            If ConnectionState.Open = True Then cn2.Close()
            MsgBox("Error code: " + ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        val1 = "im_penjualan_"
        val2 = "import"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        If ListView1.Items.Count = 0 Then
            MsgBox("Tidak ada data penjualan pada periode ini!", vbCritical)
            Cursor = Cursors.Default
            Exit Sub
        End If

        If MsgBox("Anda yakin mau melakukan import data penjualan?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            'Hapus data penjualan sebelumnya
            Try
                cmd = New SqlCommand("sp_im_penjualan_DEL", cn)
                cmd.CommandType = CommandType.StoredProcedure
                Dim prm1 As SqlParameter = cmd.Parameters.Add("@BULAN", SqlDbType.NVarChar, 2)
                prm1.Value = ListView1.Items(0).SubItems(3).Text
                Dim prm2 As SqlParameter = cmd.Parameters.Add("@TAHUN", SqlDbType.NVarChar, 4)
                prm2.Value = ListView1.Items(0).SubItems(4).Text

                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                'Insert data penjualan baru
                For i = 0 To ListView1.Items.Count - 1
                    
                    cmd = New SqlCommand("sp_im_penjualan_INS", cn)
                    cmd.CommandType = CommandType.StoredProcedure

                    Dim prm11 As SqlParameter = cmd.Parameters.Add("@POSID", SqlDbType.NVarChar, 20)
                    prm11.Value = ListView1.Items(i).SubItems.Item(0).Text
                    Dim prm12 As SqlParameter = cmd.Parameters.Add("@NOTRANS", SqlDbType.NVarChar, 50)
                    prm12.Value = ListView1.Items(i).SubItems.Item(1).Text
                    Dim prm13 As SqlParameter = cmd.Parameters.Add("@TANGGAL", SqlDbType.NVarChar, 2)
                    prm13.Value = ListView1.Items(i).SubItems.Item(2).Text
                    Dim prm14 As SqlParameter = cmd.Parameters.Add("@BULAN", SqlDbType.NVarChar, 2)
                    prm14.Value = ListView1.Items(i).SubItems.Item(3).Text
                    Dim prm15 As SqlParameter = cmd.Parameters.Add("@TAHUN", SqlDbType.NVarChar, 4)
                    prm15.Value = ListView1.Items(i).SubItems.Item(4).Text
                    Dim prm16 As SqlParameter = cmd.Parameters.Add("@STOCKID", SqlDbType.NVarChar, 50)
                    prm16.Value = ListView1.Items(i).SubItems.Item(5).Text
                    Dim prm17 As SqlParameter = cmd.Parameters.Add("@STOCKNAME", SqlDbType.NVarChar, 50)
                    prm17.Value = ListView1.Items(i).SubItems.Item(6).Text
                    Dim prm18 As SqlParameter = cmd.Parameters.Add("@DEPTID", SqlDbType.NVarChar, 20)
                    prm18.Value = ListView1.Items(i).SubItems.Item(7).Text
                    Dim prm19 As SqlParameter = cmd.Parameters.Add("@JUMLAH", SqlDbType.Decimal)
                    prm19.Value = ListView1.Items(i).SubItems.Item(8).Text
                    Dim prm45 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
                    prm45.Value = My.Settings.UserName

                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                    ListView1.Items(i).Checked = True

                Next
                MsgBox("Import data penjualan berhasil", vbInformation)
            Catch ex As Exception
                MsgBox("Error Message: " + ex.Message)
                If ConnectionState.Open = True Then cn.Close()
            End Try
        End If
        Cursor = Cursors.Default
        Me.Close()
    End Sub

    Private Sub btnAmbil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAmbil.Click    
        getPenjualan()
    End Sub
End Class

