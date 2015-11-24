Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO

Public Class frmTugas
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim flag As Integer
    Dim flagLampiran As Integer
    Dim val1, val2 As String

    'Untuk slideshow
    Dim pictures() As String
    Dim excelicon As String = GetSysInit("lampiran") + "excel.png"
    Dim wordicon As String = GetSysInit("lampiran") + "word.png"
    Dim pdficon As String = GetSysInit("lampiran") + "pdf.png"
    Dim videoicon As String = GetSysInit("lampiran") + "video.png"
    Dim emptyicon As String = GetSysInit("lampiran") + "empty.png"
    Dim elseicon As String = GetSysInit("lampiran") + "else.png"
    Dim deleteicon As String = GetSysInit("lampiran") + "delete.png"
    Dim z As Integer = 0
    Dim extension As String
    Dim original As Image
    Dim resized As Image
    Dim memStream As MemoryStream

    Private Sub frmTugas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        clear_obj()
        lock_obj(False)
    End Sub

    Private Sub frmTugas_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If flag = 0 Then
            If MsgBox("Data belum tersimpan, Anda yakin mau menutup form ini?", vbYesNo + vbCritical, Me.Text) = vbNo Then
                e.Cancel = True
            End If
        End If
    End Sub

    Public Property m_Flag() As Integer
        Get
            Return flag
        End Get
        Set(ByVal Value As Integer)
            flag = Value
        End Set
    End Property

    Public Property TugasCode() As String
        Get
            Return txtKodeTugas.Text
        End Get
        Set(ByVal Value As String)
            txtKodeTugas.Text = Value
        End Set
    End Property

    Public Property DeptCode() As String
        Get
            Return txtKodeDept.Text
        End Get
        Set(ByVal Value As String)
            txtKodeDept.Text = Value
        End Set
    End Property


    'tugas_code,0
    'tugas_description,1
    'dept_code,2
    'repeater,3
    'link_standard,4
    'val_before,5
    'val_after1,6
    'val_after2,7
    
    Sub view_record()
        Try
            cmd = New SqlCommand("sp_mt_tugas_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@tugas_code", SqlDbType.NVarChar, 50)
            prm1.Value = txtKodeTugas.Text

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            While myReader.Read
                flag = 1
                txtKodeTugas.Text = myReader.GetString(0)
                txtDeskripsi.Text = myReader.GetString(1)
                txtKodeDept.Text = myReader.GetString(2)
                txtRepeat.Text = myReader.GetInt32(3)
                If myReader.IsDBNull(myReader.GetOrdinal("link_standard")) Then
                    lblStandard.Text = ""
                Else
                    lblStandard.Text = myReader.GetString(4)
                End If
                cbValBefore.Checked = myReader.GetBoolean(5)
                cbValAfter1.Checked = myReader.GetBoolean(6)
                cbValAfter2.Checked = myReader.GetBoolean(7)

                pictures = {lblStandard.Text}

                z = 0
                extension = Path.GetExtension(pictures(z))
                getImage(extension)

            End While

            myReader.Close()
            cn.Close()

            lock_obj(True)
        Catch ex As Exception
            MsgBox("Error code: " + ex.Message)
        End Try

    End Sub

    Sub getImage(ByVal ext As String)
        Try
            If ext = ".jpg" Or ext = ".png" Or ext = "jpeg" Then
                original = Image.FromFile(pictures(z))
                resized = ResizeImage(original, New Size(PictureBox1.Size))
                PictureBox1.Image = resized
            ElseIf ext = ".xls" Or ext = ".xlsx" Then
                PictureBox1.Image = Image.FromFile(excelicon)
            ElseIf ext = ".pdf" Then
                PictureBox1.Image = Image.FromFile(pdficon)
            ElseIf ext = ".mp4" Or ext = ".wav" Then
                PictureBox1.Image = Image.FromFile(videoicon)
            ElseIf ext = ".doc" Or ext = ".docx" Then
                PictureBox1.Image = Image.FromFile(wordicon)
            ElseIf ext = "" Then
                PictureBox1.Image = Image.FromFile(emptyicon)
            Else
                PictureBox1.Image = Image.FromFile(elseicon)
            End If
            lblImage.Text = pictures(z)
        Catch ex As System.IO.FileNotFoundException
            PictureBox1.Image = Image.FromFile(emptyicon)
        End Try
    End Sub

    Sub clear_obj()
        flag = 0
        flagLampiran = 0
        txtKodeTugas.Text = ""
        txtDeskripsi.Text = ""
        txtKodeDept.Text = ""
        txtRepeat.Text = "0"
        lblStandard.Text = ""
        cbValBefore.Checked = False
        cbValAfter1.Checked = False
        cbValAfter2.Checked = False
        PictureBox1.Image = Image.FromFile(emptyicon)
        lblImage.Text = ""
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        txtKodeTugas.ReadOnly = isLock
        txtDeskripsi.ReadOnly = isLock
        txtRepeat.ReadOnly = isLock
        btnDept.Enabled = Not isLock
        btnStandard.Enabled = Not isLock
        cbValBefore.Enabled = Not isLock
        cbValAfter1.Enabled = Not isLock
        cbValAfter2.Enabled = Not isLock

        btnEdit.Enabled = isLock
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock

        If flag = 0 Then
            txtKodeTugas.ReadOnly = Not isLock
            btnDelete.Enabled = False
        Else
            txtKodeTugas.ReadOnly = True
            btnDelete.Enabled = Not isLock
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        val1 = "mt_tugas_"
        val2 = "tambah"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        clear_obj()
        lock_obj(False)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        lock_obj(False)
        If flag <> 0 Then txtKodeTugas.ReadOnly = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        lock_obj(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        val1 = "mt_tugas_"
        val2 = "simpan"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        If txtKodeTugas.Text = "" Then
            MsgBox("Kode tugas tidak boleh kosong!", vbCritical + vbOKOnly, Me.Text)
            txtKodeTugas.Focus()
            Exit Sub
        End If

        If txtDeskripsi.Text = "" Then
            MsgBox("Deskripsi tidak boleh kosong!", vbCritical + vbOKOnly, Me.Text)
            txtDeskripsi.Focus()
            Exit Sub
        End If

        If txtKodeDept.Text = "" Then
            MsgBox("Departemen tidak boleh kosong!", vbCritical + vbOKOnly, Me.Text)
            txtKodeDept.Focus()
            Exit Sub
        End If

        Try
            cmd = New SqlCommand(IIf(flag = 0, "sp_mt_tugas_INS", "sp_mt_tugas_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm2 As SqlParameter = cmd.Parameters.Add("@tugas_code", SqlDbType.NVarChar, 50)
            prm2.Value = txtKodeTugas.Text
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@tugas_description", SqlDbType.NVarChar, 255)
            prm3.Value = txtDeskripsi.Text
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@dept_code", SqlDbType.NVarChar, 50)
            prm5.Value = txtKodeDept.Text
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@repeat", SqlDbType.Int)
            prm6.Value = CInt(txtRepeat.Text)
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@link_standard", SqlDbType.NVarChar, 100)
            prm7.Value = lblStandard.Text
            Dim prm8 As SqlParameter = cmd.Parameters.Add("@val_before", SqlDbType.Bit)
            prm8.Value = cbValBefore.Checked
            Dim prm9 As SqlParameter = cmd.Parameters.Add("@val_after1", SqlDbType.Bit)
            prm9.Value = cbValAfter1.Checked
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@val_after2", SqlDbType.Bit)
            prm10.Value = cbValAfter2.Checked

            Dim prm20 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
            prm20.Value = My.Settings.UserName

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            view_record()
            lock_obj(True)
            flag = 1
        Catch ex As Exception
            If ConnectionState.Open = True Then cn.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        val1 = "mt_tugas_"
        val2 = "hapus"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        If flag <> 0 Then
            If MsgBox("Anda yakin menghapus?", vbYesNo + vbCritical, Me.Text) = vbYes Then
                cmd = New SqlCommand("sp_mt_tugas_DEL", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm1 As SqlParameter = cmd.Parameters.Add("@tugas_code", SqlDbType.NVarChar, 50)
                prm1.Value = txtKodeTugas.Text
                Dim prm2 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
                prm2.Value = My.Settings.UserName
                cn.Open()
                cmd.ExecuteReader()

                cn.Close()

                clear_obj()
                btnAdd_Click(sender, e)
            End If
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
    End Sub

    Private Sub btnTugas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTugas.Click
        Dim NewFormDialog As New fdlTugas
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnDept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDept.Click
        Dim NewFormDialog As New fdlDept
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    'Private Sub txtWaktu_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
    '        If Not (Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 46 Or Asc(e.KeyChar) = 44) Then e.Handled = True
    '    End If
    'End Sub

    Private Sub btnLampiran1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStandard.Click
        flagLampiran = 1
        OFDLampiran.ShowDialog()
    End Sub

    Private Sub OFDLampiran_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OFDLampiran.FileOk
        ProgressBar1.Visible = True
        If OFDLampiran.FileName <> "" Then
            Try
                Dim FileName As String = CStr(System.IO.Path.GetFileName(OFDLampiran.FileName))
                'Dim Path As String = Application.StartupPath & "\Lampiran\"
                Dim DestinationPath As String = GetSysInit("lampiran") + FileName
                Dim SourcePath As String = OFDLampiran.FileName

                If System.IO.File.Exists(DestinationPath) Then
                    If MsgBox("Lampiran dengan nama yang sama sudah ada, apakah mau diganti?", vbYesNo + vbCritical, Me.Text) = vbYes Then
                        System.IO.File.Delete(DestinationPath)
                    Else
                        MsgBox("Upload lampiran dibatalkan!", vbCritical)
                        Exit Sub
                    End If
                End If

                Dim CF As New IO.FileStream(SourcePath, IO.FileMode.Open)
                Dim CT As New IO.FileStream(DestinationPath, IO.FileMode.Create)
                Dim len As Long = CF.Length - 1
                Dim buffer(1024) As Byte
                Dim byteCFead As Integer
                While CF.Position < len
                    byteCFead = (CF.Read(buffer, 0, 1024))
                    CT.Write(buffer, 0, byteCFead)
                    ProgressBar1.Value = CInt(CF.Position / len * 100)
                    Application.DoEvents()
                End While
                CT.Flush()
                CT.Close()
                CF.Close()

                MsgBox("Upload lampiran berhasil!", vbInformation)

                Dim link_before As String
                If flagLampiran = 1 Then
                    link_before = "link_standard"
                    lblStandard.Text = DestinationPath
                End If

                If flag <> 0 Then
                    Try
                        cmd = New SqlCommand("update mt_tugas set " + link_before + " = '" + DestinationPath + "' where tugas_code = '" + txtKodeTugas.Text + "' ", cn)

                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If

            Catch ex As Exception
                MsgBox("Upload lampiran gagal silahkan coba kembali!" + vbCrLf + "Error message :" + vbCrLf + ex.Message, vbCritical)
                Exit Sub
            End Try
        End If
        ProgressBar1.Visible = False
        pictures = {lblStandard.Text}
        z = flagLampiran - 1
        extension = Path.GetExtension(pictures(z))
        getImage(extension)
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        view_record()
    End Sub

    'Autorefresh---Hendra
    Public Sub frmTugasRefresh(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnFilter_Click(sender, e)
    End Sub

    Private Sub btnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.Click
        'if I = 0 set it to pictures.length
        If z = 0 Then
            z = pictures.Length
        End If

        'decrement by 1
        z -= 1

        extension = Path.GetExtension(pictures(z))

        getImage(extension)
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        'increment by 1
        z += 1

        'if I = pictures.length set it to 0
        If pictures.Length = z Then
            z = 0
        End If

        extension = Path.GetExtension(pictures(z))

        getImage(extension)
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Try
            If z = 0 Then
                If lblStandard.Text <> "" Then
                    Process.Start(lblStandard.Text)
                End If
            End If
        Catch ex As Exception
            'PictureBox1.Image = Image.FromFile(deleteicon)
            MsgBox("File sudah dihapus diluar system" + vbCrLf + "Error Message: " + ex.Message)
        End Try

    End Sub

    Private Sub txtRepeat_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRepeat.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtRepeat_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRepeat.LostFocus
        If txtRepeat.Text = "" Then
            txtRepeat.Text = "0"
        End If
        If CInt(txtRepeat.Text) > 100 Then
            txtRepeat.Text = "100"
        End If
    End Sub
End Class