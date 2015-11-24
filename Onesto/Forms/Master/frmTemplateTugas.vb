Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmTemplateTugas
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim flag As Integer
    Dim flag_detail As Integer
    Dim val1, val2 As String

    Private Sub frmTemplateTugas_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        flag = 0
        clear_obj()
        clear_objD()
        clear_lvw()
        lock_obj(False)
        lock_objD(False)
    End Sub

    Private Sub frmTemplateTugas_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Public Property m_Flag_detail() As Integer
        Get
            Return flag_detail
        End Get
        Set(ByVal Value As Integer)
            flag_detail = Value
        End Set
    End Property

    Public Property TemplateCode() As String
        Get
            Return txtKodeTemplateTugas.Text
        End Get
        Set(ByVal Value As String)
            txtKodeTemplateTugas.Text = Value
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
            Return txtTugasDeskripsi.Text
        End Get
        Set(ByVal Value As String)
            txtTugasDeskripsi.Text = Value
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

    Sub clear_obj()
        flag = 0
        txtKodeTemplateTugas.Text = ""
        txtTemplateDeskripsi.Text = ""
        txtKodeDept.Text = ""
        dtpDate.Value = FormatDateTime(Now, DateFormat.ShortDate)
    End Sub

    Sub clear_objD()
        flag_detail = 0
        txtKodeTugas.Text = ""
        txtTugasDeskripsi.Text = ""
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        txtKodeTemplateTugas.ReadOnly = isLock
        dtpDate.Enabled = Not isLock
        txtTemplateDeskripsi.ReadOnly = isLock

        btnEdit.Enabled = isLock
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
        btnDept.Enabled = Not isLock

        If flag = 0 Then
            txtKodeTemplateTugas.ReadOnly = False
            btnDelete.Enabled = False
        Else
            txtKodeTemplateTugas.ReadOnly = True
            btnDelete.Enabled = Not isLock
        End If

    End Sub

    Sub lock_objD(ByVal isLock As Boolean)
        btnTugas.Enabled = Not isLock
        btnSaveD.Enabled = Not isLock
        btnDeleteD.Enabled = Not isLock
        btnAddD.Enabled = Not isLock
    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("template_dtl_id", 0)
            .Columns.Add("Kode Tugas", 120)
            .Columns.Add("Tugas Deskripsi", 330)
        End With

        If flag <> 0 Then
            cmd = New SqlCommand("sp_mt_template_dtl_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@template_code", SqlDbType.NVarChar, 50)
            prm1.Value = txtKodeTemplateTugas.Text

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            'Call FillList(myReader, Me.ListView1, 12, 1)
            Dim lvItem As ListViewItem
            Dim i As Integer, intCurrRow As Integer

            While myReader.Read
                lvItem = New ListViewItem(CStr(myReader.Item(0))) 'template_id
                lvItem.Tag = intCurrRow 'ID
                'lvItem.Tag = "v" & CStr(DR.Item(0))
                For i = 1 To 2
                    If myReader.Item(i) Is System.DBNull.Value Then
                        lvItem.SubItems.Add("")
                    Else
                        lvItem.SubItems.Add(myReader.Item(i))
                    End If
                Next
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
            cn.Close()
        End If
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        With ListView1.SelectedItems.Item(0)
            flag_detail = .SubItems.Item(0).Text
            txtKodeTugas.Text = .SubItems.Item(1).Text
            txtTugasDeskripsi.Text = .SubItems.Item(2).Text

            If btnSaveD.Enabled = True Then
                btnTugas.Enabled = False
            End If

        End With
    End Sub

    Sub view_record()
        cmd = New SqlCommand("sp_mt_template_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm2 As SqlParameter = cmd.Parameters.Add("@template_code", SqlDbType.NVarChar, 50)
        prm2.Value = txtKodeTemplateTugas.Text

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            txtKodeTemplateTugas.Text = myReader.GetString(0)

            If Not myReader.IsDBNull(myReader.GetOrdinal("template_deskripsi")) Then
                txtTemplateDeskripsi.Text = myReader.GetString(1)
            Else
                txtTemplateDeskripsi.Text = ""
            End If

            If Not myReader.IsDBNull(myReader.GetOrdinal("dept_code")) Then
                txtKodeDept.Text = myReader.GetString(2)
            Else
                txtKodeDept.Text = ""
            End If

        End While

        myReader.Close()
        cn.Close()

    End Sub

    Sub saveHeader()
        Try
            cmd = New SqlCommand(IIf(flag = 0, "sp_mt_template_INS", "sp_mt_template_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm2 As SqlParameter = cmd.Parameters.Add("@template_code", SqlDbType.NVarChar, 50)
            prm2.Value = txtKodeTemplateTugas.Text
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@template_deskripsi", SqlDbType.NVarChar, 50)
            prm3.Value = txtTemplateDeskripsi.Text
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@dept_code", SqlDbType.NVarChar, 50)
            prm4.Value = txtKodeDept.Text
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
            prm5.Value = My.Settings.UserName

            If flag = 0 Then
                cn.Open()
                cmd.ExecuteReader()
                flag = 1
                cn.Close()

                txtKodeTemplateTugas.ReadOnly = True
            Else
                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
                'clear_lvw()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
            clear_objD()
        End Try
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        val1 = "mt_template_"
        val2 = "tambah"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        flag = 0
        clear_obj()
        clear_objD()
        clear_lvw()
        lock_obj(False)
        lock_objD(False)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        lock_obj(True)
        lock_objD(True)
        clear_objD()
        flag_detail = 0
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        val1 = "mt_simpan_"
        val2 = "tambah"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        If txtKodeTemplateTugas.Text = "" Then
            If ListView1.Items.Count = 0 Then
                MsgBox("Kode Template tidak boleh kosong!", vbCritical, "Warning")
                txtKodeTemplateTugas.Focus()
                Exit Sub
            End If
        End If

        If ListView1.Items.Count = 0 Then
            MsgBox("Template tugas ini tidak ada isi tugasnya!", vbCritical, "Warning")
            Exit Sub
        End If

        Try
            saveHeader()

            lock_obj(True)
            lock_objD(True)

        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        clear_objD()
        lock_obj(False)
        lock_objD(False)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        val1 = "mt_template_"
        val2 = "hapus"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        If flag <> 0 Then
            If MsgBox("Anda yakin menghapus?", vbYesNo + vbCritical, Me.Text) = vbYes Then
                cmd = New SqlCommand("sp_mt_template_DEL", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm1 As SqlParameter = cmd.Parameters.Add("@template_code", SqlDbType.NVarChar, 50)
                prm1.Value = txtKodeTemplateTugas.Text
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

    Private Sub btnSaveD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveD.Click
        val1 = "mt_template_"
        val2 = "simpan"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        Try
            If txtKodeTemplateTugas.Text = "" Then
                If ListView1.Items.Count = 0 Then
                    MsgBox("Kode Template tidak boleh kosong!", vbCritical, "Warning")
                    txtKodeTemplateTugas.Focus()
                    Exit Sub
                End If
            End If

            If txtKodeTugas.Text = "" Then
                MsgBox("Silahkan pilih tugas terlebih dahulu!", vbCritical + vbOKOnly, Me.Text)
                btnTugas.Focus()
                Exit Sub
            End If

            saveHeader()

            cmd = New SqlCommand(IIf(flag_detail = 0, "sp_mt_template_dtl_INS", "sp_mt_template_dtl_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm11 As SqlParameter = cmd.Parameters.Add("@template_code", SqlDbType.NVarChar, 50)
            prm11.Value = txtKodeTemplateTugas.Text
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@tugas_code", SqlDbType.NVarChar, 50)
            prm12.Value = txtKodeTugas.Text

            If flag_detail <> 0 Then
                Dim prm21 As SqlParameter = cmd.Parameters.Add("@template_dtl_id", SqlDbType.Int)
                prm21.Value = flag_detail
            End If
            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            clear_lvw()
            clear_objD()
        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
    End Sub

    Private Sub btnDeleteD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteD.Click
        val1 = "mt_template_"
        val2 = "hapus"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        If flag_detail = 0 Then Exit Sub
        If MsgBox("Anda yakin menghapus tugas ini?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            cmd = New SqlCommand("sp_mt_template_dtl_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@template_dtl_id", SqlDbType.Int)
            prm1.Value = flag_detail

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            clear_lvw()
            clear_objD()

            btnTugas.Enabled = True
        End If
    End Sub

    Private Sub btnAddD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddD.Click
        val1 = "mt_template_"
        val2 = "tambah"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        btnTugas.Enabled = True
        clear_objD()
    End Sub

    Private Sub btnTugas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTugas.Click
        val1 = "mt_template_"
        val2 = "tambah"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        Dim NewFormDialog As New fdlTugas
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnDept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDept.Click
        Dim NewFormDialog As New fdlDept
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTemplate.Click
        Dim NewFormDialog As New fdlTemplate
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        view_record()
        clear_lvw()
    End Sub

    'Autorefresh---Hendra
    Public Sub frmTemplateRefresh(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnFilter_Click(sender, e)
    End Sub
End Class