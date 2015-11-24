Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class frmGroup
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim flag, flag_detail As Integer

    Private Sub frmGroup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        flag = 0

        clear_obj()
        clear_objD()
        clear_lvw()
        lock_obj(False)
        lock_objD(False)
    End Sub

    Private Sub frmGroup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Public Property GroupCode() As String
        Get
            Return txtKodeGroup.Text
        End Get
        Set(ByVal Value As String)
            txtKodeGroup.Text = Value
        End Set
    End Property

    Sub clear_obj()
        flag = 0
        txtKodeGroup.Text = ""
        txtGroupDeskripsi.Text = ""
        txtSubmit.Text = ""
    End Sub

    Sub clear_objD()
        flag_detail = 0
        txtFormName.Text = ""
        chbBuka.Checked = False
        chbTambah.Checked = False
        chbBatal.Checked = False
        chbHapus.Checked = False
        chbSimpan.Checked = False
        chbCetak.Checked = False
        chbSelesai.Checked = False
        chbApprove1.Checked = False
        chbApprove2.Checked = False
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        txtKodeGroup.ReadOnly = isLock
        txtGroupDeskripsi.ReadOnly = isLock

        btnEdit.Enabled = isLock
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock

        If flag = 0 Then
            txtKodeGroup.ReadOnly = False
            btnDelete.Enabled = False
        Else
            txtKodeGroup.ReadOnly = True
            btnDelete.Enabled = Not isLock
        End If

    End Sub

    Sub lock_objD(ByVal isLock As Boolean)
        btnSaveD.Enabled = Not isLock
        btnDeleteD.Enabled = Not isLock
        btnAddD.Enabled = Not isLock

        chbBuka.Enabled = Not isLock
        chbTambah.Enabled = Not isLock
        chbBatal.Enabled = Not isLock
        chbHapus.Enabled = Not isLock
        chbSimpan.Enabled = Not isLock
        chbCetak.Enabled = Not isLock
        chbSelesai.Enabled = Not isLock
        chbApprove1.Enabled = Not isLock
        chbApprove2.Enabled = Not isLock
    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("group_dtl_id", 0)
            .Columns.Add("Nama Form", 240)
            .Columns.Add("Buka", 50)
            .Columns.Add("Tambah", 50)
            .Columns.Add("Batal", 50)
            .Columns.Add("Hapus", 50)
            .Columns.Add("Simpan", 50)
            .Columns.Add("Cetak", 50)
            .Columns.Add("Selesai", 50)
            .Columns.Add("Approve1", 100)
            .Columns.Add("Approve2", 100)
            .Columns.Add("Submit", 120)
        End With
        
        If flag <> 0 Then
            cmd = New SqlCommand("sp_mt_group_dtl_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@group_code", SqlDbType.NVarChar, 50)
            prm1.Value = txtKodeGroup.Text

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            'Call FillList(myReader, Me.ListView1, 12, 1)
            Dim lvItem As ListViewItem
            Dim i As Integer, intCurrRow As Integer

            While myReader.Read
                lvItem = New ListViewItem(CStr(myReader.Item(0))) 'template_id
                lvItem.Tag = intCurrRow 'ID
                'lvItem.Tag = "v" & CStr(DR.Item(0))
                lvItem.SubItems.Add(myReader.Item(1))
                For i = 2 To 10
                    If myReader.Item(i) = "True" Then
                        lvItem.SubItems.Add("Yes")
                    Else
                        lvItem.SubItems.Add("No")
                    End If
                Next
                lvItem.SubItems.Add(myReader.Item(11))
                
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
            txtFormName.Text = .SubItems.Item(1).Text
            If .SubItems.Item(2).Text = "Yes" Then
                chbBuka.Checked = True
            Else
                chbBuka.Checked = False
            End If
            If .SubItems.Item(3).Text = "Yes" Then
                chbTambah.Checked = True
            Else
                chbTambah.Checked = False
            End If
            If .SubItems.Item(4).Text = "Yes" Then
                chbBatal.Checked = True
            Else
                chbBatal.Checked = False
            End If
            If .SubItems.Item(5).Text = "Yes" Then
                chbHapus.Checked = True
            Else
                chbHapus.Checked = False
            End If
            If .SubItems.Item(6).Text = "Yes" Then
                chbSimpan.Checked = True
            Else
                chbSimpan.Checked = False
            End If
            If .SubItems.Item(7).Text = "Yes" Then
                chbCetak.Checked = True
            Else
                chbCetak.Checked = False
            End If
            If .SubItems.Item(8).Text = "Yes" Then
                chbSelesai.Checked = True
            Else
                chbSelesai.Checked = False
            End If
            If .SubItems.Item(9).Text = "Yes" Then
                chbApprove1.Checked = True
            Else
                chbApprove1.Checked = False
            End If
            If .SubItems.Item(10).Text = "Yes" Then
                chbApprove2.Checked = True
            Else
                chbApprove2.Checked = False
            End If
        End With
    End Sub

    Sub view_record()
        Try
            cmd = New SqlCommand("sp_mt_group_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm2 As SqlParameter = cmd.Parameters.Add("@group_code", SqlDbType.NVarChar, 50)
            prm2.Value = txtKodeGroup.Text

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            While myReader.Read
                'txtKodeGroup.Text = myReader.GetString(0)
                txtGroupDeskripsi.Text = myReader.GetString(1)
                txtSubmit.Text = myReader.GetString(2)
            End While

            myReader.Close()
            cn.Close()
        Catch ex As Exception
            MsgBox("Error Message: " + ex.Message)
            If ConnectionState.Open = True Then cn.Close()
        End Try
        
    End Sub

    Sub saveHeader()
        Try
            Dim gen As Integer = flag
            cmd = New SqlCommand(IIf(flag = 0, "sp_mt_group_INS", "sp_mt_group_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm2 As SqlParameter = cmd.Parameters.Add("@group_code", SqlDbType.NVarChar, 50)
            prm2.Value = txtKodeGroup.Text
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@group_description", SqlDbType.NVarChar, 50)
            prm3.Value = txtGroupDeskripsi.Text
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
            prm5.Value = My.Settings.UserName

            If flag = 0 Then
                cn.Open()
                cmd.ExecuteReader()
                flag = 1
                cn.Close()
                txtKodeGroup.ReadOnly = True
                If gen = 0 Then
                    GenerateListview()
                End If
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

    Sub GenerateListview()
        cmd = New SqlCommand("sp_mt_group_dtl_GENERATE", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm2 As SqlParameter = cmd.Parameters.Add("@group_code", SqlDbType.NVarChar, 50)
        prm2.Value = txtKodeGroup.Text
        Dim prm5 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
        prm5.Value = My.Settings.UserName

        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        clear_lvw()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        

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
        

        If txtKodeGroup.Text = "" Then
            MsgBox("Kode Group tidak boleh kosong!", vbCritical, "Warning")
            txtKodeGroup.Focus()
            Exit Sub
        End If

        If txtGroupDeskripsi.Text = "" Then
            MsgBox("Group Deskripsi tidak boleh kosong!", vbCritical, "Warning")
            txtGroupDeskripsi.Focus()
            Exit Sub
        End If

        Try
            saveHeader()

            lock_obj(True)
            lock_objD(True)

        Catch ex As Exception
            MsgBox("Error Message : " + ex.Message)
            If ConnectionState.Open = True Then cn.Close()
        End Try
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        clear_objD()
        lock_obj(False)
        lock_objD(False)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        
        If flag <> 0 Then
            If MsgBox("Anda yakin menghapus?", vbYesNo + vbCritical, Me.Text) = vbYes Then
                Try
                    cmd = New SqlCommand("sp_mt_group_DEL", cn)
                    cmd.CommandType = CommandType.StoredProcedure

                    Dim prm1 As SqlParameter = cmd.Parameters.Add("@group_code", SqlDbType.NVarChar, 50)
                    prm1.Value = txtKodeGroup.Text
                    Dim prm2 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
                    prm2.Value = My.Settings.UserName
                    Dim prm3 As SqlParameter = cmd.Parameters.Add("@row_count", SqlDbType.Int)
                    prm3.Direction = ParameterDirection.Output
                    cn.Open()
                    cmd.ExecuteReader()
                    cn.Close()
                    If prm3.Value = 1 Then
                        MsgBox("Kode Group tidak bisa dihapus karena sedang digunakan oleh user!", vbCritical, Me.Text)
                    Else
                        clear_obj()
                        btnAdd_Click(sender, e)
                    End If
                Catch ex As Exception
                    MsgBox("Error Message : " + ex.Message)
                    If ConnectionState.Open = True Then cn.Close()
                End Try
            End If
        End If
    End Sub

    Private Sub btnSaveD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveD.Click
        

        Try
            If txtKodeGroup.Text = "" Then
                MsgBox("Kode Group tidak boleh kosong!", vbCritical, "Warning")
                txtKodeGroup.Focus()
                Exit Sub
            End If

            If txtGroupDeskripsi.Text = "" Then
                MsgBox("Group Deskripsi tidak boleh kosong!", vbCritical, "Warning")
                txtGroupDeskripsi.Focus()
                Exit Sub
            End If

            saveHeader()

            If flag_detail = 0 Then
                'MsgBox("Silahkan pilih dahulu form yang mau diubah!", vbCritical, "Warning")
                ListView1.Focus()
                Exit Sub
            End If

            Dim z As Integer = 0
            If flag_detail <> 0 Then
                z = ListView1.SelectedIndices(0)
            End If

            cmd = New SqlCommand("sp_mt_group_dtl_UPD", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@group_dtl_id", SqlDbType.Int)
            prm1.Value = flag_detail
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@buka", SqlDbType.Bit)
            prm2.Value = chbBuka.Checked
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@tambah", SqlDbType.Bit)
            prm3.Value = chbTambah.Checked
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@batal", SqlDbType.Bit)
            prm4.Value = chbBatal.Checked
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@hapus", SqlDbType.Bit)
            prm5.Value = chbHapus.Checked
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@simpan", SqlDbType.Bit)
            prm6.Value = chbSimpan.Checked
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@cetak", SqlDbType.Bit)
            prm7.Value = chbCetak.Checked
            Dim prm8 As SqlParameter = cmd.Parameters.Add("@selesai", SqlDbType.Bit)
            prm8.Value = chbSelesai.Checked
            Dim prm9 As SqlParameter = cmd.Parameters.Add("@approve1", SqlDbType.Bit)
            prm9.Value = chbApprove1.Checked
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@approve2", SqlDbType.Bit)
            prm10.Value = chbApprove2.Checked

            Dim prm21 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
            prm21.Value = My.Settings.UserName
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            clear_lvw()

            ListView1.Items.Item(z).Selected = True
            ListView1_Click(sender, e)

            'clear_objD()
        Catch ex As Exception
            MsgBox("Error Message : " + ex.Message)
            If ConnectionState.Open = True Then cn.Close()
        End Try
    End Sub

    Private Sub btnDeleteD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteD.Click
        'If flag_detail = 0 Then Exit Sub
        'If MsgBox("Anda yakin menghapus tugas ini?", vbYesNo + vbCritical, Me.Text) = vbYes Then
        '    cmd = New SqlCommand("sp_mt_template_dtl_DEL", cn)
        '    cmd.CommandType = CommandType.StoredProcedure

        '    Dim prm1 As SqlParameter = cmd.Parameters.Add("@template_dtl_id", SqlDbType.Int)
        '    prm1.Value = flag_detail

        '    cn.Open()
        '    cmd.ExecuteReader()
        '    cn.Close()

        '    clear_lvw()
        '    clear_objD()
        'End If
    End Sub

    Private Sub btnAddD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddD.Click
        'clear_objD()
    End Sub

    Private Sub btnGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroup.Click
        Dim NewFormDialog As New fdlGroup
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        view_record()
        clear_lvw()
        lock_obj(False)
        lock_objD(False)
    End Sub

    'Autorefresh---Hendra
    Public Sub frmGroupRefresh(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnFilter_Click(sender, e)
    End Sub
 
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim z As Integer = 1
        'If flag_detail <> 0 Then
        '    z = ListView1.SelectedIndices(0)
        'End If
        If z <> 0 Then
            ListView1.Items.Item(z).Selected = True
            ListView1_Click(sender, e)
        End If
        MsgBox(CStr(z))
    End Sub
End Class