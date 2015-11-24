Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
Public Class frmDelegasiTugas
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim flag As Integer
    Dim flagLampiran As Integer
    Dim m_val_before, m_val_after1, m_val_after2 As Boolean
    Dim m_kode_karyawan As String
    Dim val1, val2 As String

    'Untuk slideshow
    Dim excelicon As String = GetSysInit("lampiran") + "excel.png"
    Dim wordicon As String = GetSysInit("lampiran") + "word.png"
    Dim pdficon As String = GetSysInit("lampiran") + "pdf.png"
    Dim videoicon As String = GetSysInit("lampiran") + "video.png"
    Dim emptyicon As String = GetSysInit("lampiran") + "empty.png"
    Dim elseicon As String = GetSysInit("lampiran") + "else.png"
    Dim deleteicon As String = GetSysInit("lampiran") + "delete.png"
    Dim extension As String
    Dim original As Image
    Dim resized As Image
    Dim memStream As MemoryStream

    Private Sub frmDelegasiTugas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            With fdlApprove
                .m_TugasNo = txtNoTugas.Text
                .MdiParent = frmMenu
                .Show()
            End With
        End If
    End Sub

    Private Sub frmDelegasiTugas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If flag = 0 Then
            clear_obj()
            lock_obj(False)
        Else
            view_record()
            lock_obj(False)
        End If
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

    Public Property m_TugasNo() As String
        Get
            Return txtNoTugas.Text
        End Get
        Set(ByVal Value As String)
            txtNoTugas.Text = Value
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

    Public Property TugasDeskripsi() As String
        Get
            Return txtDeskripsi.Text
        End Get
        Set(ByVal Value As String)
            txtDeskripsi.Text = Value
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

    Public Property NamaKaryawan() As String
        Get
            Return txtNamaKaryawan.Text
        End Get
        Set(ByVal Value As String)
            txtNamaKaryawan.Text = Value
        End Set
    End Property

    Public Property LinkStandard() As String
        Get
            Return lblStandard.Text
        End Get
        Set(ByVal Value As String)
            lblStandard.Text = Value
        End Set
    End Property

    Public Property KodeKaryawan() As String
        Get
            Return m_kode_karyawan
        End Get
        Set(ByVal Value As String)
            m_kode_karyawan = Value
        End Set
    End Property

    Public Property ValBefore() As Boolean
        Get
            Return m_val_before
        End Get
        Set(ByVal Value As Boolean)
            m_val_before = Value
        End Set
    End Property

    Public Property ValAfter1() As Boolean
        Get
            Return m_val_after1
        End Get
        Set(ByVal Value As Boolean)
            m_val_after1 = Value
        End Set
    End Property

    Public Property ValAfter2() As Boolean
        Get
            Return m_val_after2
        End Get
        Set(ByVal Value As Boolean)
            m_val_after2 = Value
        End Set
    End Property

    Public Property Repeater() As String
        Get
            Return txtRepeat.Text
        End Get
        Set(ByVal Value As String)
            txtRepeat.Text = Value
        End Set
    End Property

    Sub view_record()
        'a.tugas_no,0
        'a.tugas_code,1
        'a.tugas_description,2
        'a.tugas_date,3
        'a.karyawan_code,4
        'a.karyawan_name,5
        'a.dept_code,6
        'a.tugas_status,7
        'a.ref_no,8
        'a.effective_date_from,9
        'a.effective_date_to,10
        'a.due_date,11
        'a.link_before,12
        'a.link_after1,13
        'a.link_after2,14
        'a.repeater,15
        'a.finish_flag,16
        'a.finish_percent,17
        'a.finish_date,18
        'a.finish_notes,19
        'a.approve1_flag,20
        'a.approve1_percent,21
        'a.approve1_date,22
        'a.approve1_notes,23
        'a.approve2_flag,24
        'a.approve2_percent,25
        'a.approve2_date,26
        'a.approve2_notes,27
        'a.submit,28
        'b.link_standard,29
        'b.val_before,30
        'b.val_after1,31
        'b.val_after2,32
        Try
            cmd = New SqlCommand("sp_tr_tugas_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@tugas_no", SqlDbType.NVarChar, 50)
            prm1.Value = txtNoTugas.Text

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            While myReader.Read
                flag = 1
                txtNoTugas.Text = myReader.GetInt32(0)
                txtKodeTugas.Text = myReader.GetString(1)
                txtDeskripsi.Text = myReader.GetString(2)
                dtpTugasDate.Value = myReader.GetDateTime(3)
                m_kode_karyawan = myReader.GetString(4)
                txtNamaKaryawan.Text = myReader.GetString(5)
                txtKodeDept.Text = myReader.GetString(6)
                txtStatus.Text = myReader.GetString(7)
                If myReader.IsDBNull(myReader.GetOrdinal("ref_no")) Then
                    txtRefNo.Text = ""
                Else
                    txtRefNo.Text = myReader.GetString(8)
                End If
                dtpFrom.Value = myReader.GetDateTime(9)
                dtpTo.Value = myReader.GetDateTime(10)
                dtpDeadline.Value = myReader.GetDateTime(11)
                If myReader.IsDBNull(myReader.GetOrdinal("link_before")) Then
                    lblBefore.Text = ""
                Else
                    lblBefore.Text = myReader.GetString(12)
                End If
                If myReader.IsDBNull(myReader.GetOrdinal("link_after1")) Then
                    lblAfter1.Text = ""
                Else
                    lblAfter1.Text = myReader.GetString(13)
                End If
                If myReader.IsDBNull(myReader.GetOrdinal("link_after2")) Then
                    lblAfter2.Text = ""
                Else
                    lblAfter2.Text = myReader.GetString(14)
                End If
                txtRepeat.Text = myReader.GetInt32(15)

                'Selesai
                cbSelesai.Checked = myReader.GetBoolean(16)
                txtSelesaiPersentase.Text = CStr(myReader.GetInt32(17))
                If myReader.IsDBNull(myReader.GetOrdinal("finish_date")) Then
                    dtpSelesai.Value = System.DateTime.Now
                Else
                    dtpSelesai.Value = myReader.GetDateTime(18)
                End If
                txtSelesaiNotes.Text = myReader.GetString(19)

                'Approve 1
                cbApprove1.Checked = myReader.GetBoolean(20)

                txtApprove1Persentase.Text = CStr(myReader.GetInt32(21))
                If myReader.IsDBNull(myReader.GetOrdinal("approve1_date")) Then
                    dtpApprove1.Value = System.DateTime.Now
                Else
                    dtpApprove1.Value = myReader.GetDateTime(22)
                End If
                txtApprove1Notes.Text = myReader.GetString(23)

                'Approve 2
                cbApprove2.Checked = myReader.GetBoolean(24)
                txtApprove2Persentase.Text = CStr(myReader.GetInt32(25))
                If myReader.IsDBNull(myReader.GetOrdinal("approve2_date")) Then
                    dtpApprove2.Value = System.DateTime.Now
                Else
                    dtpApprove2.Value = myReader.GetDateTime(26)
                End If
                txtApprove1Notes.Text = myReader.GetString(27)

                txtSubmit.Text = myReader.GetString(28)
                If myReader.IsDBNull(myReader.GetOrdinal("link_standard")) Then
                    lblStandard.Text = ""
                Else
                    lblStandard.Text = myReader.GetString(29)
                End If
                m_val_before = myReader.GetBoolean(30)
                m_val_after1 = myReader.GetBoolean(31)
                m_val_after2 = myReader.GetBoolean(32)

                loadImage()
            End While

            myReader.Close()
            cn.Close()

            lock_obj(True)
        Catch ex As Exception
            If ConnectionState.Open = True Then cn.Close()
            MsgBox("Error code: " + ex.Message)
        End Try

    End Sub

    Sub loadImage()
        If returnImage(lblStandard.Text) = "1" Then
            original = Image.FromFile(lblStandard.Text)
            resized = ResizeImage(original, New Size(pbStandard.Size))
            pbStandard.Image = resized
        Else
            pbStandard.Image = Image.FromFile(returnImage(lblStandard.Text))
        End If
        If returnImage(lblBefore.Text) = "1" Then
            original = Image.FromFile(lblBefore.Text)
            resized = ResizeImage(original, New Size(pbBefore.Size))
            pbBefore.Image = resized
        Else
            pbBefore.Image = Image.FromFile(returnImage(lblBefore.Text))
        End If
        If returnImage(lblAfter1.Text) = "1" Then
            original = Image.FromFile(lblAfter1.Text)
            resized = ResizeImage(original, New Size(pbAfter1.Size))
            pbAfter1.Image = resized
        Else
            pbAfter1.Image = Image.FromFile(returnImage(lblAfter1.Text))
        End If
        If returnImage(lblAfter2.Text) = "1" Then
            original = Image.FromFile(lblAfter2.Text)
            resized = ResizeImage(original, New Size(pbAfter2.Size))
            pbAfter2.Image = resized
        Else
            pbAfter2.Image = Image.FromFile(returnImage(lblAfter2.Text))
        End If
    End Sub

    'Sub getImage(ByVal ext As String)
    '    Try
    '        If ext = ".jpg" Or ext = ".png" Or ext = "jpeg" Then
    '            original = Image.FromFile(pictures(z))
    '            resized = ResizeImage(original, New Size(PictureBox1.Size))
    '            PictureBox1.Image = resized
    '        ElseIf ext = ".xls" Or ext = ".xlsx" Then
    '            PictureBox1.Image = Image.FromFile(excelicon)
    '        ElseIf ext = ".pdf" Then
    '            PictureBox1.Image = Image.FromFile(pdficon)
    '        ElseIf ext = ".mp4" Or ext = ".wav" Then
    '            PictureBox1.Image = Image.FromFile(videoicon)
    '        ElseIf ext = ".doc" Or ext = ".docx" Then
    '            PictureBox1.Image = Image.FromFile(wordicon)
    '        ElseIf ext = "" Then
    '            PictureBox1.Image = Image.FromFile(emptyicon)
    '        Else
    '            PictureBox1.Image = Image.FromFile(elseicon)
    '        End If
    '        lblImage.Text = pictures(z)
    '    Catch ex As System.IO.FileNotFoundException
    '        PictureBox1.Image = Image.FromFile(emptyicon)
    '    End Try
    'End Sub

    Function returnImage(ByVal ext As String) As String
        extension = Path.GetExtension(ext)
        If extension = ".jpg" Or extension = ".png" Or extension = "jpeg" Then
            Return "1"
        ElseIf extension = ".xls" Or extension = ".xlsx" Then
            Return excelicon
        ElseIf extension = ".pdf" Then
            Return pdficon
        ElseIf extension = ".mp4" Or extension = ".wav" Then
            Return videoicon
        ElseIf extension = ".doc" Or extension = ".docx" Then
            Return wordicon
        ElseIf extension = "" Then
            Return emptyicon
        Else
            Return elseicon
        End If
    End Function

    Sub clear_obj()
        flag = 0
        flagLampiran = 0
        txtNoTugas.Text = ""
        txtKodeTugas.Text = ""
        txtDeskripsi.Text = ""
        m_kode_karyawan = ""
        txtNamaKaryawan.Text = ""
        txtKodeDept.Text = ""
        dtpFrom.Value = System.DateTime.Now
        dtpTo.Value = System.DateTime.Now
        dtpDeadline.Value = System.DateTime.Now
        txtStatus.Text = ""
        txtRepeat.Text = "0"
        lblStandard.Text = ""
        lblBefore.Text = ""
        lblAfter1.Text = ""
        lblAfter2.Text = ""
        PictureBox1.Image = Image.FromFile(emptyicon)
        lblImage.Text = ""
        cbSelesai.Checked = False
        dtpSelesai.Value = System.DateTime.Now
        txtSelesaiPersentase.Text = "0"
        txtSelesaiNotes.Text = ""
        cbApprove1.Checked = False
        dtpApprove1.Value = System.DateTime.Now
        txtApprove1Persentase.Text = "0"
        txtApprove1Notes.Text = ""
        cbApprove2.Checked = False
        dtpApprove2.Value = System.DateTime.Now
        txtApprove2Persentase.Text = "0"
        txtApprove2Notes.Text = ""
        txtRefNo.Text = ""
        dtpTugasDate.Value = System.DateTime.Now
        txtSubmit.Text = ""
        m_val_before = False
        m_val_after1 = False
        m_val_after2 = False
        loadImage()
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        txtDeskripsi.ReadOnly = isLock
        txtRepeat.ReadOnly = isLock
        dtpDeadline.Enabled = Not isLock

        dtpFrom.Enabled = Not isLock
        dtpTo.Enabled = Not isLock

        btnBefore.Enabled = Not isLock
        btnEdit.Enabled = isLock
        btnAdd.Enabled = Not isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
        btnBatal.Enabled = Not isLock

        If flag = 0 Then
            btnKodeTugas.Enabled = True
            btnDept.Enabled = True
            btnKaryawan.Enabled = True
            btnBatal.Enabled = False
            btnAdd.Enabled = False
        Else
            btnKodeTugas.Enabled = False
            btnDept.Enabled = False
            btnKaryawan.Enabled = False
            dtpDeadline.Enabled = False
        End If

        If txtRefNo.Text <> "" Then
            gbHeader.Enabled = False
            btnEdit.Enabled = False
            btnSave.Enabled = False
            btnBatal.Enabled = False
        End If

        If txtStatus.Text = "" Then
            gbTugasSelesai.Enabled = False
            gbApprove1.Enabled = False
            gbApprove2.Enabled = False
            btnBatal.Enabled = False
        Else
            btnSave.Enabled = False
        End If

        If txtStatus.Text = "Outstanding" Then
            gbHeader.Enabled = False
            gbTugasSelesai.Enabled = Not isLock
            gbApprove1.Enabled = False
            gbApprove2.Enabled = False
        End If

        If txtStatus.Text = "Selesai" Then
            gbHeader.Enabled = False
            gbTugasSelesai.Enabled = False
            gbApprove1.Enabled = Not isLock
            gbApprove2.Enabled = False
        End If

        If txtStatus.Text = "Approve1" Then
            gbHeader.Enabled = False
            gbTugasSelesai.Enabled = False
            gbApprove1.Enabled = False
            gbApprove2.Enabled = Not isLock
        End If

        If txtStatus.Text = "Complete" Then
            gbHeader.Enabled = False
            gbTugasSelesai.Enabled = False
            gbApprove1.Enabled = False
            gbApprove2.Enabled = False
        End If

        If txtStatus.Text = "Batal" Then
            btnBatal.Enabled = False
            gbHeader.Enabled = False
            gbTugasSelesai.Enabled = False
            gbApprove1.Enabled = False
            gbApprove2.Enabled = False
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        val1 = "tr_tugas_"
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
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        lock_obj(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        val1 = "tr_tugas_"
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

        If txtNamaKaryawan.Text = "" Then
            MsgBox("Karyawan tidak boleh kosong!", vbCritical + vbOKOnly, Me.Text)
            btnKaryawan.Focus()
            Exit Sub
        End If

        If txtKodeDept.Text = "" Then
            MsgBox("Departemen tidak boleh kosong!", vbCritical + vbOKOnly, Me.Text)
            btnDept.Focus()
            Exit Sub
        End If

        Try
            If flag = 0 Then
                '@tugas_code nvarchar(50) = null, 
                '@tugas_description nvarchar(255) = null,
                '@karyawan_code nvarchar(50)=null,
                '@karyawan_name nvarchar(50)=null,
                '@dept_code nvarchar(50) = null,
                '@effective_date_from smalldatetime = null,
                '@effective_date_to smalldatetime = null,
                '@due_date nvarchar(30) = null,
                '@repeat int = 0,
                '@tugas_status nvarchar(25) = null,
                '@ref_no nvarchar(25) = null,
                '@user_code nvarchar(50) = null,
                '@tugas_date smalldatetime = null,
                '@link_before nvarchar(100)=null,
                cmd = New SqlCommand("sp_tr_tugas_INS", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm2 As SqlParameter = cmd.Parameters.Add("@tugas_code", SqlDbType.NVarChar, 50)
                prm2.Value = txtKodeTugas.Text
                Dim prm3 As SqlParameter = cmd.Parameters.Add("@tugas_description", SqlDbType.NVarChar, 255)
                prm3.Value = txtDeskripsi.Text
                Dim prm4 As SqlParameter = cmd.Parameters.Add("@karyawan_code", SqlDbType.NVarChar, 50)
                prm4.Value = m_kode_karyawan
                Dim prm5 As SqlParameter = cmd.Parameters.Add("@karyawan_name", SqlDbType.NVarChar, 50)
                prm5.Value = txtNamaKaryawan.Text
                Dim prm6 As SqlParameter = cmd.Parameters.Add("@dept_code", SqlDbType.NVarChar, 50)
                prm6.Value = txtKodeDept.Text
                Dim prm7 As SqlParameter = cmd.Parameters.Add("@effective_date_from", SqlDbType.DateTime)
                prm7.Value = dtpFrom.Value
                Dim prm8 As SqlParameter = cmd.Parameters.Add("@effective_date_to", SqlDbType.DateTime)
                prm8.Value = dtpTo.Value
                Dim prm9 As SqlParameter = cmd.Parameters.Add("@due_date", SqlDbType.DateTime)
                prm9.Value = dtpDeadline.Value
                Dim prm10 As SqlParameter = cmd.Parameters.Add("@repeat", SqlDbType.Int)
                prm10.Value = CInt(txtRepeat.Text)
                Dim prm11 As SqlParameter = cmd.Parameters.Add("@tugas_date", SqlDbType.SmallDateTime)
                prm11.Value = dtpTugasDate.Text

                Dim prm20 As SqlParameter = cmd.Parameters.Add("@tugas_status", SqlDbType.NVarChar, 25)
                prm20.Value = "Outstanding"

                Dim prm21 As SqlParameter = cmd.Parameters.Add("@ref_no", SqlDbType.NVarChar, 25)
                prm21.Value = ""

                Dim prm22 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
                prm22.Value = My.Settings.UserName

                Dim prm23 As SqlParameter = cmd.Parameters.Add("@tugas_no", SqlDbType.Int)
                prm23.Direction = ParameterDirection.Output

                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
                txtNoTugas.Text = CStr(prm23.Value)
                insert_Scheduler(dtpFrom.Value, dtpTo.Value)

            ElseIf flag <> 0 Then
                'cmd = New SqlCommand("sp_tr_tugas_UPD", cn)
                'cmd.CommandType = CommandType.StoredProcedure


                'Dim prm42 As SqlParameter = cmd.Parameters.Add("@tugas_no", SqlDbType.Int)
                'prm42.Value = CInt(txtNoTugas.Text)
                'Dim prm43 As SqlParameter = cmd.Parameters.Add("@tugas_description", SqlDbType.NVarChar, 255)
                'prm43.Value = txtDeskripsi.Text
                'Dim prm44 As SqlParameter = cmd.Parameters.Add("@due_date", SqlDbType.NVarChar, 30)
                'prm44.Value = dtpDeadline.Text
                'Dim prm45 As SqlParameter = cmd.Parameters.Add("@repeat", SqlDbType.Int)
                'prm45.Value = CInt(txtRepeat.Text)

                'Dim prm62 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
                'prm62.Value = My.Settings.UserName

                'cn.Open()
                'cmd.ExecuteNonQuery()
                'cn.Close()
            End If

            view_record()
            lock_obj(False)
            flag = 1
        Catch ex As Exception
            If ConnectionState.Open = True Then cn.Close()
            MsgBox("Error Message : " + ex.Message)
        End Try
        autoRefresh()
    End Sub

    Sub insert_Scheduler(ByVal timeFrom As DateTime, ByVal timeTo As DateTime)

        Dim m_datediff As Integer = CInt(DateDiff(DateInterval.Day, timeFrom, timeTo))
        Dim m_repeat As Integer = CInt(txtRepeat.Text)
        If m_datediff <> 0 And m_repeat <> 0 Then
            Try
                Dim range, i As Integer
                Dim m_tugas_date As DateTime = dtpTugasDate.Value
                Dim m_tugas_deadline As DateTime = dtpDeadline.Value
                range = m_datediff \ m_repeat

                For i = 1 To range

                    m_tugas_date = DateAdd(DateInterval.Day, CDbl(txtRepeat.Text), m_tugas_date)
                    m_tugas_deadline = DateAdd(DateInterval.Day, CDbl(txtRepeat.Text), m_tugas_deadline)

                    cmd = New SqlCommand("sp_tr_tugas_INS", cn)
                    cmd.CommandType = CommandType.StoredProcedure

                    Dim prm2 As SqlParameter = cmd.Parameters.Add("@tugas_code", SqlDbType.NVarChar, 50)
                    prm2.Value = txtKodeTugas.Text
                    Dim prm3 As SqlParameter = cmd.Parameters.Add("@tugas_description", SqlDbType.NVarChar, 255)
                    prm3.Value = txtDeskripsi.Text
                    Dim prm4 As SqlParameter = cmd.Parameters.Add("@karyawan_code", SqlDbType.NVarChar, 50)
                    prm4.Value = m_kode_karyawan
                    Dim prm5 As SqlParameter = cmd.Parameters.Add("@karyawan_name", SqlDbType.NVarChar, 50)
                    prm5.Value = txtNamaKaryawan.Text
                    Dim prm6 As SqlParameter = cmd.Parameters.Add("@dept_code", SqlDbType.NVarChar, 50)
                    prm6.Value = txtKodeDept.Text
                    Dim prm7 As SqlParameter = cmd.Parameters.Add("@effective_date_from", SqlDbType.DateTime)
                    prm7.Value = dtpFrom.Value
                    Dim prm8 As SqlParameter = cmd.Parameters.Add("@effective_date_to", SqlDbType.DateTime)
                    prm8.Value = dtpTo.Value
                    Dim prm9 As SqlParameter = cmd.Parameters.Add("@due_date", SqlDbType.SmallDateTime)
                    prm9.Value = m_tugas_deadline
                    Dim prm10 As SqlParameter = cmd.Parameters.Add("@repeat", SqlDbType.Int)
                    prm10.Value = CInt(txtRepeat.Text)
                    Dim prm11 As SqlParameter = cmd.Parameters.Add("@tugas_date", SqlDbType.SmallDateTime)
                    prm11.Value = m_tugas_date

                    Dim prm20 As SqlParameter = cmd.Parameters.Add("@tugas_status", SqlDbType.NVarChar, 25)
                    prm20.Value = "Outstanding"

                    Dim prm21 As SqlParameter = cmd.Parameters.Add("@ref_no", SqlDbType.NVarChar, 25)
                    prm21.Value = txtNoTugas.Text

                    Dim prm22 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
                    prm22.Value = My.Settings.UserName

                    Dim prm23 As SqlParameter = cmd.Parameters.Add("@tugas_no", SqlDbType.Int)
                    prm23.Direction = ParameterDirection.Output

                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                Next
            Catch ex As Exception
                If ConnectionState.Open = True Then cn.Close()
                MsgBox("Error Message : " + ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBatal.Click
        val1 = "tr_tugas_"
        val2 = "batal"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        If flag <> 0 Then
            Try
                If MsgBox("Anda yakin membatalkan daftar tugas yang tersisa dan belum diselesaikan dengan keterangan :" + vbCrLf + txtDeskripsi.Text + vbCrLf + "untuk karyawan dengan kode " + txtNamaKaryawan.Text + "?", vbYesNo + vbCritical, Me.Text) = vbYes Then
                    cmd = New SqlCommand("sp_tr_tugas_BATAL", cn)
                    cmd.CommandType = CommandType.StoredProcedure

                    Dim prm1 As SqlParameter = cmd.Parameters.Add("@tugas_code", SqlDbType.NVarChar, 50)
                    prm1.Value = txtKodeTugas.Text
                    Dim prm2 As SqlParameter = cmd.Parameters.Add("@ref_no", SqlDbType.NVarChar, 25)
                    prm2.Value = txtNoTugas.Text
                    Dim prm3 As SqlParameter = cmd.Parameters.Add("@tugas_status", SqlDbType.NVarChar, 25)
                    prm3.Value = "Outstanding"
                    Dim prm4 As SqlParameter = cmd.Parameters.Add("@effective_date_from", SqlDbType.DateTime)
                    prm4.Value = dtpFrom.Value
                    Dim prm5 As SqlParameter = cmd.Parameters.Add("@effective_date_to", SqlDbType.DateTime)
                    prm5.Value = dtpTo.Value
                    Dim prm22 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
                    prm22.Value = My.Settings.UserName

                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    MsgBox("Tugas " + txtDeskripsi.Text + vbCrLf + " yang masih tersisa untuk karyawan dengan kode : " + txtNamaKaryawan.Text + " sudah dibatalkan!", vbInformation)
                    view_record()
                    lock_obj(False)
                End If
            Catch ex As Exception
                If ConnectionState.Open = True Then cn.Close()
                MsgBox("Error Message : " + ex.Message)
            End Try
        End If
        autoRefresh()
    End Sub

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
    End Sub

    Private Sub btnTugas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKodeTugas.Click
        Dim NewFormDialog As New fdlTugas
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnDept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDept.Click
        Dim NewFormDialog As New fdlDept
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnKaryawan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKaryawan.Click
        Dim NewFormDialog As New fdlKaryawan
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub txtPersentase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSelesaiPersentase.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtApprove1Persentase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApprove1Persentase.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtApprove2Persentase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApprove2Persentase.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
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

    Private Sub btnBefore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBefore.Click
        flagLampiran = 2
        OFDLampiran.ShowDialog()
    End Sub

    Private Sub btnAfter1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAfter1.Click
        flagLampiran = 3
        OFDLampiran.ShowDialog()
    End Sub

    Private Sub btnAfter2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAfter2.Click
        flagLampiran = 4
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

                Dim link_after As String
                If flagLampiran = 2 Then
                    link_after = "link_before"
                    lblBefore.Text = DestinationPath
                ElseIf flagLampiran = 3 Then
                    link_after = "link_after1"
                    lblAfter1.Text = DestinationPath
                Else
                    link_after = "link_after2"
                    lblAfter2.Text = DestinationPath
                End If

                If flag <> 0 Then
                    Try
                        cmd = New SqlCommand("update tr_tugas set " + link_after + " = '" + DestinationPath + "' where tugas_no = '" + txtNoTugas.Text + "' ", cn)

                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If

            Catch ex As Exception
                MsgBox("Upload file gagal silahkan coba kembali!" + vbCrLf + "Error message :" + vbCrLf + ex.Message, vbCritical)
                Exit Sub
            End Try
        End If
        ProgressBar1.Visible = False
        loadImage()
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        view_record()
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        loadImage()
    End Sub

    'Private Sub btnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.Click
    '    'if I = 0 set it to pictures.length
    '    If z = 0 Then
    '        z = pictures.Length
    '    End If

    '    'decrement by 1
    '    z -= 1

    '    extension = Path.GetExtension(pictures(z))

    '    getImage(extension)
    'End Sub

    'Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
    '    'increment by 1
    '    z += 1

    '    'if I = pictures.length set it to 0
    '    If pictures.Length = z Then
    '        z = 0
    '    End If

    '    extension = Path.GetExtension(pictures(z))

    '    getImage(extension)
    'End Sub

    'Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
    '    Try
    '        If z = 0 Then
    '            If lblStandard.Text <> "" Then
    '                Process.Start(lblStandard.Text)
    '            End If
    '        ElseIf z = 1 Then
    '            If lblBefore.Text <> "" Then
    '                Process.Start(lblBefore.Text)
    '            End If
    '        ElseIf z = 2 Then
    '            If lblAfter1.Text <> "" Then
    '                Process.Start(lblAfter1.Text)
    '            End If
    '        ElseIf z = 3 Then
    '            If lblAfter2.Text <> "" Then
    '                Process.Start(lblAfter2.Text)
    '            End If
    '        End If
    '    Catch ex As Exception
    '        'PictureBox1.Image = Image.FromFile(deleteicon)
    '        MsgBox("File sudah dihapus diluar system" + vbCrLf + "Error Message: " + ex.Message)
    '    End Try
    'End Sub

    Private Sub txtSelesaiPersentase_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSelesaiPersentase.LostFocus
        If txtSelesaiPersentase.Text = "" Then
            txtSelesaiPersentase.Text = "0"
        End If
        If CInt(txtSelesaiPersentase.Text) > 100 Then
            txtSelesaiPersentase.Text = "100"
        End If
    End Sub

    Private Sub txtApprove1Persentase_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtApprove1Persentase.LostFocus
        If txtApprove1Persentase.Text = "" Then
            txtApprove1Persentase.Text = "0"
        End If
        If CInt(txtApprove1Persentase.Text) > 100 Then
            txtApprove1Persentase.Text = "100"
        End If
    End Sub

    Private Sub txtApprove2Persentase_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtApprove2Persentase.LostFocus
        If txtApprove2Persentase.Text = "" Then
            txtApprove2Persentase.Text = "0"
        End If
        If CInt(txtApprove2Persentase.Text) > 100 Then
            txtApprove2Persentase.Text = "100"
        End If
    End Sub

    'Autorefresh---Hendra
    Public Sub frmKasihTugasRefresh(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnFilter_Click(sender, e)
    End Sub

    Public Sub frmDelegasiTugasShow(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnShow_Click(sender, e)
    End Sub

    Sub autoRefresh()
        If Application.OpenForms().OfType(Of frmDelegasiTugasList).Any Then
            Call frmDelegasiTugasList.frmDelegasiTugasListShow(Nothing, EventArgs.Empty)
        End If
    End Sub

    Private Sub btnSelesai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelesai.Click
        val1 = "tr_tugas_"
        val2 = "submit"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        If CInt(txtSelesaiPersentase.Text) = 0 Then
            MsgBox("Persentase tugas tidak boleh kosong!", vbCritical + vbOKOnly, Me.Text)
            txtSelesaiPersentase.Focus()
            Exit Sub
        End If

        If lblBefore.Text = "" And m_val_before = True Then
            MsgBox("Tugas ini memerlukan lampiran before sebelum bisa disubmit selesai!", vbCritical + vbOKOnly, Me.Text)
            btnBefore.Focus()
            Exit Sub
        End If

        If lblAfter1.Text = "" And m_val_after1 = True Then
            MsgBox("Tugas ini memerlukan lampiran after 1 sebelum bisa disubmit selesai!", vbCritical + vbOKOnly, Me.Text)
            btnAfter1.Focus()
            Exit Sub
        End If

        If lblAfter2.Text = "" And m_val_after2 = True Then
            MsgBox("Tugas ini memerlukan lampiran after 2 sebelum bisa disubmit selesai!", vbCritical + vbOKOnly, Me.Text)
            btnAfter2.Focus()
            Exit Sub
        End If

        dtpSelesai.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        If MsgBox("Anda yakin submit tugas ini?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            Try
                cmd = New SqlCommand("sp_tr_tugas_SELESAI", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm1 As SqlParameter = cmd.Parameters.Add("@tugas_no", SqlDbType.Int)
                prm1.Value = CInt(txtNoTugas.Text)
                Dim prm12 As SqlParameter = cmd.Parameters.Add("@finish_flag", SqlDbType.Bit)
                prm12.Value = True
                Dim prm3 As SqlParameter = cmd.Parameters.Add("@finish_percent", SqlDbType.Int)
                prm3.Value = CInt(txtSelesaiPersentase.Text)
                Dim prm4 As SqlParameter = cmd.Parameters.Add("@finish_date", SqlDbType.NVarChar, 30)
                prm4.Value = dtpSelesai.Text
                Dim prm5 As SqlParameter = cmd.Parameters.Add("@link_before", SqlDbType.NVarChar, 100)
                prm5.Value = lblBefore.Text
                Dim prm6 As SqlParameter = cmd.Parameters.Add("@link_after1", SqlDbType.NVarChar, 100)
                prm6.Value = lblAfter1.Text
                Dim prm7 As SqlParameter = cmd.Parameters.Add("@link_after2", SqlDbType.NVarChar, 100)
                prm7.Value = lblAfter2.Text
                Dim prm8 As SqlParameter = cmd.Parameters.Add("@tugas_status", SqlDbType.NVarChar, 25)
                prm8.Value = "Selesai"
                Dim prm9 As SqlParameter = cmd.Parameters.Add("@finish_notes", SqlDbType.NVarChar, 255)
                prm9.Value = txtSelesaiNotes.Text

                Dim prm22 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
                prm22.Value = My.Settings.UserName

                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                view_record()
                lock_obj(False)
                flag = 1
            Catch ex As Exception
                If ConnectionState.Open = True Then cn.Close()
                MsgBox(ex.Message)
            End Try
        End If

        dtpSelesai.CustomFormat = "dd-MM-yyyy HH:mm:ss"
        autoRefresh()
    End Sub

    Private Sub btnApprove1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove1.Click
        val1 = "tr_tugas_"
        val2 = "approve1"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        If CInt(txtApprove1Persentase.Text) = 0 Then
            MsgBox("Approval Persentase tugas tidak boleh kosong!", vbCritical + vbOKOnly, Me.Text)
            txtApprove1Persentase.Focus()
            Exit Sub
        End If

        dtpApprove1.CustomFormat = "yyyy-MM-dd HH:mm:ss"

        If MsgBox("Anda yakin approve tugas ini?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            Try
                cmd = New SqlCommand("sp_tr_tugas_APPROVE1", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm1 As SqlParameter = cmd.Parameters.Add("@tugas_no", SqlDbType.Int)
                prm1.Value = CInt(txtNoTugas.Text)
                Dim prm12 As SqlParameter = cmd.Parameters.Add("@approve1_flag", SqlDbType.Bit)
                prm12.Value = True
                Dim prm3 As SqlParameter = cmd.Parameters.Add("@approve1_percent", SqlDbType.Int)
                prm3.Value = CInt(txtApprove1Persentase.Text)
                Dim prm4 As SqlParameter = cmd.Parameters.Add("@approve1_date", SqlDbType.NVarChar, 30)
                prm4.Value = dtpApprove1.Text
                Dim prm8 As SqlParameter = cmd.Parameters.Add("@tugas_status", SqlDbType.NVarChar, 25)
                prm8.Value = "Approve1"
                Dim prm9 As SqlParameter = cmd.Parameters.Add("@approve1_notes", SqlDbType.NVarChar, 255)
                prm9.Value = txtApprove1Notes.Text

                Dim prm22 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
                prm22.Value = My.Settings.UserName

                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                view_record()
                lock_obj(False)
                flag = 1
            Catch ex As Exception
                If ConnectionState.Open = True Then cn.Close()
                MsgBox(ex.Message)
            End Try
        End If
        
        dtpApprove1.CustomFormat = "dd-MM-yyyy HH:mm:ss"
        autoRefresh()
    End Sub

    Private Sub btnApprove2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove2.Click
        val1 = "tr_tugas_"
        val2 = "approve2"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        If CInt(txtApprove2Persentase.Text) = 0 Then
            MsgBox("Approval Persentase tugas tidak boleh kosong!", vbCritical + vbOKOnly, Me.Text)
            txtApprove2Persentase.Focus()
            Exit Sub
        End If

        dtpApprove2.CustomFormat = "yyyy-MM-dd HH:mm:ss"

        If MsgBox("Anda yakin approve tugas ini?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            Try
                cmd = New SqlCommand("sp_tr_tugas_approve2", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm1 As SqlParameter = cmd.Parameters.Add("@tugas_no", SqlDbType.Int)
                prm1.Value = CInt(txtNoTugas.Text)
                Dim prm12 As SqlParameter = cmd.Parameters.Add("@approve2_flag", SqlDbType.Bit)
                prm12.Value = True
                Dim prm3 As SqlParameter = cmd.Parameters.Add("@approve2_percent", SqlDbType.Int)
                prm3.Value = CInt(txtApprove2Persentase.Text)
                Dim prm4 As SqlParameter = cmd.Parameters.Add("@approve2_date", SqlDbType.NVarChar, 30)
                prm4.Value = dtpApprove2.Text
                Dim prm8 As SqlParameter = cmd.Parameters.Add("@tugas_status", SqlDbType.NVarChar, 25)
                prm8.Value = "Complete"
                Dim prm9 As SqlParameter = cmd.Parameters.Add("@approve2_notes", SqlDbType.NVarChar, 255)
                prm9.Value = txtApprove2Notes.Text

                Dim prm22 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
                prm22.Value = My.Settings.UserName

                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                view_record()
                lock_obj(False)
                flag = 1
            Catch ex As Exception
                If ConnectionState.Open = True Then cn.Close()
                MsgBox(ex.Message)
            End Try
        End If

        dtpApprove2.CustomFormat = "dd-MM-yyyy HH:mm:ss"
        autoRefresh()
    End Sub

    Private Sub dtpTo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpTo.LostFocus
        If CDate(dtpTo.Text) < CDate(dtpFrom.Text) Then
            MsgBox("Batas akhir tanggal efektif tugas tidak boleh lebih dari tanggal tugas efektif awal", vbCritical)
            dtpTo.Value = dtpFrom.Value
        End If
    End Sub

    Private Sub pbStandard_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbStandard.MouseHover
        With PictureBox1
            .Visible = True
            If returnImage(lblStandard.Text) = "1" Then
                original = Image.FromFile(lblStandard.Text)
                resized = ResizeImage(original, New Size(.Size))
                .Image = resized
            Else
                .Image = Image.FromFile(returnImage(lblStandard.Text))
            End If
            .BringToFront()
        End With
    End Sub

    Private Sub pbBefore_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbBefore.MouseHover
        With PictureBox1
            .Visible = True
            If returnImage(lblBefore.Text) = "1" Then
                original = Image.FromFile(lblBefore.Text)
                resized = ResizeImage(original, New Size(.Size))
                .Image = resized
            Else
                .Image = Image.FromFile(returnImage(lblBefore.Text))
            End If
            .BringToFront()
        End With
    End Sub

    Private Sub pbAfter1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbAfter1.MouseHover
        With PictureBox1
            .Visible = True
            If returnImage(lblAfter1.Text) = "1" Then
                original = Image.FromFile(lblAfter1.Text)
                resized = ResizeImage(original, New Size(.Size))
                .Image = resized
            Else
                .Image = Image.FromFile(returnImage(lblAfter1.Text))
            End If
            .BringToFront()
        End With
    End Sub

    Private Sub pbAfter2_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbAfter2.MouseHover
        With PictureBox1
            .Visible = True
            If returnImage(lblAfter2.Text) = "1" Then
                original = Image.FromFile(lblAfter2.Text)
                resized = ResizeImage(original, New Size(.Size))
                .Image = resized
            Else
                .Image = Image.FromFile(returnImage(lblAfter2.Text))
            End If
            .BringToFront()
        End With
    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        With PictureBox1
            .Visible = False
        End With
    End Sub

    Private Sub dtpFrom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFrom.LostFocus
        dtpTo.Value = dtpFrom.Value
        dtpTugasDate.Value = dtpFrom.Value
        dtpDeadline.Value = dtpFrom.Value
    End Sub

    Private Sub dtpDeadline_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDeadline.LostFocus
        If CDate(dtpDeadline.Text) < CDate(dtpFrom.Text) Then
            MsgBox("Tanggal deadline tugas tidak boleh lebih dari tanggal tugas efektif awal", vbCritical)
            dtpDeadline.Value = dtpFrom.Value
        End If
    End Sub
End Class